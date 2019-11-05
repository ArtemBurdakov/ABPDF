Imports System.IO
Imports ABPDF.FileStructures
Imports ABPDF.PDFObjects

Namespace Drawing

    ''' <summary>
    ''' Представляет поток содержащий файл шрифта.
    ''' </summary>
    Public Class FontStream
        Inherits InderectObject
        Implements IDisposable

        Private _stream As StreamObject

        ''' <summary>
        ''' Создаёт поток содержащий файл шрифта.
        ''' </summary>
        ''' <param name="path">Путь к файлу шрифта</param>
        Public Sub New(path As String)
            _stream = New StreamObject()
            _content = _stream
            CompressAndWriteFile(path)
        End Sub

        ''' <summary>
        ''' Сжимает и записывает файл в поток.
        ''' </summary>
        Private Sub CompressAndWriteFile(path As String)
            Dim fontData = File.ReadAllBytes(path)
            Dim resultStream = New MemoryStream()

            resultStream.WriteByte(&H58)
            resultStream.WriteByte(&H85)

            Dim def = New Compression.DeflateStream(resultStream, Compression.CompressionMode.Compress)
            def.Write(fontData, 0, fontData.Length)
            resultStream.WriteTo(_stream.Stream)
            def.Dispose()

            CalculateAdler(fontData)

            _stream.Filter = New ArrayObject(Of NameObject) From {Names.FlateDecode}
            _stream.Filter.FirstAsArray = False
            _stream.AddDictionary(Names.Length1, New NumericObject(fontData.Length))
        End Sub

        ''' <summary>
        ''' Вычисление чек суммы Adler-32
        ''' </summary>
        Private Sub CalculateAdler(fontData() As Byte)
            Dim s1 As ULong = 1
            Dim s2 As ULong = 0
            For i = 0 To fontData.Length - 1
                s1 = (s1 + fontData(i)) Mod 65521
                s2 = (s2 + s1) Mod 65521
            Next
            appendAdler((s2 << 16) + s1, _stream.Stream)
        End Sub

        ''' <summary>
        ''' Добавляет в конец потока сумму Adler-32.
        ''' </summary>
        Private Sub appendAdler(adler As ULong, buf As MemoryStream)
            buf.WriteByte(CType(adler >> 24, Byte))
            buf.WriteByte(CType((adler >> 16) And &H00FF, Byte))
            buf.WriteByte(CType((adler >> 8) And &H0000FF, Byte))
            buf.WriteByte(CType(adler And &H000000FF, Byte))
            buf.Flush()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(_stream, IDisposable).Dispose()
        End Sub

        ''' <summary>
        ''' Тело файла.
        ''' </summary>
        Public Shadows Property FileBody As FileBody
            Get
                Return _fileBody
            End Get
            Friend Set(value As FileBody)
                _fileBody = value
            End Set
        End Property

        ''' <summary>
        ''' Данные потока.
        ''' </summary>
        Public ReadOnly Property Stream As MemoryStream
            Get
                Return DirectCast(_content, StreamObject).Stream
            End Get
        End Property

        ''' <summary>
        ''' Длина распаковонного файла шрифта TrueType или сегмент файла шрифта Type1.
        ''' </summary>
        Public ReadOnly Property Length1 As Integer
            Get
                Return CType(_stream.ItemDictionary(Names.Length1), IContent).GetContent()
            End Get
        End Property

    End Class

End Namespace

