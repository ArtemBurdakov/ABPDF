Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет потоковый объект в PDF.
    ''' </summary>
    Public Class StreamObject
        Implements IContent, IDisposable

        Private _dictionary As DictionaryObject
        Private _stream As MemoryStream

        ''' <summary>
        ''' Создаёт потоковый объект.
        ''' </summary>
        Public Sub New()
            _stream = New MemoryStream
            _dictionary = New DictionaryObject
        End Sub

        ''' <summary>
        ''' Данные потока.
        ''' </summary>
        Public ReadOnly Property Stream As MemoryStream
            Get
                Return _stream
            End Get
        End Property

        ''' <summary>
        ''' Количество байтов потока.
        ''' </summary>
        Public ReadOnly Property LengthStream As Integer
            Get
                Return _stream.Length
            End Get
        End Property

        ''' <summary>
        ''' Фильтр декодирования, декомпрессирования, расшифровки потока.
        ''' </summary>
        Public Property Filter As ArrayObject(Of NameObject)
            Get
                Return CType(_dictionary.Item(Names.Filter), ArrayObject(Of NameObject))
            End Get
            Set(value As ArrayObject(Of NameObject))
                _dictionary.Item(Names.Filter) = value
            End Set
        End Property

        ''' <summary>
        ''' Параметры для фильтра декодирования, декомпрессирования, расшифровки потока.
        ''' </summary>
        Public Property DecodeParams As ArrayObject(Of DictionaryObject)
            Get
                Return CType(_dictionary.Item(Names.DecodeParams), ArrayObject(Of DictionaryObject))
            End Get
            Set(value As ArrayObject(Of DictionaryObject))
                _dictionary.Item(Names.DecodeParams) = value
            End Set
        End Property

        ''' <summary>
        ''' Внешний файл, содержащий данные потока.
        ''' </summary>
        Public Property F As StringObject
            Get
                Return CType(_dictionary.Item(Names.F), StringObject)
            End Get
            Set(value As StringObject)
                _dictionary.Item(Names.F) = value
            End Set
        End Property

        ''' <summary>
        ''' Фильтр декодирования, декомпрессирования, расшифровки для внешнего файла.
        ''' </summary>
        Public Property FFilter As ArrayObject(Of NameObject)
            Get
                Return CType(_dictionary.Item(Names.FFilter), ArrayObject(Of NameObject))
            End Get
            Set(value As ArrayObject(Of NameObject))
                _dictionary.Item(Names.FFilter) = value
            End Set
        End Property

        ''' <summary>
        ''' Параметры для фильтра декодирования, декомпрессирования, расшифровки для внешнего файла.
        ''' </summary>
        Public Property FDecodeParams As ArrayObject(Of DictionaryObject)
            Get
                Return CType(_dictionary.Item(Names.FDecodeParams), ArrayObject(Of DictionaryObject))
            End Get
            Set(value As ArrayObject(Of DictionaryObject))
                _dictionary.Item(Names.FDecodeParams) = value
            End Set
        End Property

        ''' <summary>
        ''' Количество байтов декодированного потока.
        ''' </summary>
        Public Property DL As NumericObject
            Get
                Return CType(_dictionary.Item(Names.DL), NumericObject)
            End Get
            Set(value As NumericObject)
                _dictionary.Item(Names.DL) = value
            End Set
        End Property

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                SetLenghtStream()
                Return _dictionary.Length + 18 + LengthStream
            End Get
        End Property

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return Stream
        End Function

        ''' <summary>
        ''' Возвращает или задаёт значенние, связанное с указанным ключом словоря.
        ''' </summary>
        ''' <param name="key">Ключ записи в словаре</param>
        Friend Property ItemDictionary(key As NameObject) As PDFObject
            Get
                Return _dictionary.Item(key)
            End Get
            Set(value As PDFObject)
                _dictionary.Item(key) = value
            End Set
        End Property

        ''' <summary>
        ''' Добавляет объект в словарь.
        ''' </summary>
        ''' <param name="key">Ключ записи в словаре</param>
        ''' <param name="value">Значение записи в словаре</param>
        Friend Sub AddDictionary(key As NameObject, value As PDFObject)
            _dictionary.Add(key, value)
        End Sub

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            SetLenghtStream()
            Return _dictionary.ToString & vbLf & "stream" & vbLf & Encoding.Default.GetString(_stream.ToArray()) & vbLf & "endstream"
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            SetLenghtStream()
            _dictionary.WriteIn(stream)
            stream.Write(Encoding.Default.GetBytes(vbLf & "stream" & vbLf), 0, 8)
            _stream.WriteTo(stream)
            stream.Write(Encoding.Default.GetBytes(vbLf & "endstream"), 0, 10)
        End Sub

        ''' <summary>
        ''' Задаёт кло-во байт потока в справочнике.
        ''' </summary>
        Private Sub SetLenghtStream()
            _dictionary.Item(Names.Length) = New NumericObject(LengthStream)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(_stream, IDisposable).Dispose()
        End Sub
    End Class

End Namespace

