Imports System.IO
Imports System.Text
Imports ABPDF.PDFObjects

Namespace FileStructures

    ''' <summary>
    ''' Таблица с ссылками на объекты в файле PDF.
    ''' </summary>
    Public Class CrossReferenceTable
        Inherits FileStructure

        Private _numberObjectStructure As Integer

        ''' <summary>
        ''' Создаёт ссылочную таблицу привязанную к документу.
        ''' </summary>
        ''' <param name="pdf">Документ</param>
        Public Shared Function CreateWithDocument(pdf As PDF) As CrossReferenceTable
            Return New CrossReferenceTable(pdf)
        End Function

        ''' <summary>
        ''' Создаёт ссылочную таблицу.
        ''' </summary>
        ''' <param name="pdf">PDF документ</param>
        Private Sub New(pdf As PDF)
            Me.PDF = pdf
            _numberObjectStructure = pdf.CountObjectStructures
            CreateDefaultReference()
        End Sub

        ''' <summary>
        ''' Количество записей в таблице.
        ''' </summary>
        Public ReadOnly Property CountEntryes As Integer
            Get
                Return PDF.GetFileBody(_numberObjectStructure).CountObjects + 1
            End Get
        End Property

        ''' <summary>
        ''' Возвращает количество байтов структуры.
        ''' </summary>
        Friend Overrides ReadOnly Property Length() As Integer
            Get
                Return 8 + CountEntryes.ToString.Length + CountEntryes * 20
            End Get
        End Property

        ''' <summary>
        ''' Возвращает строковое представление структуры.
        ''' </summary>
        Public Overrides Function ToString() As String
            Dim result = "xref" & vbLf & "0 " & CountEntryes.ToString & vbLf & CreateDefaultReference().GetXRef() & vbLf
            For Each iobj In PDF.GetFileBody(_numberObjectStructure)
                result &= iobj.Reference.GetXRef() & vbLf
            Next
            Return result
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Overrides Sub WriteIn(stream As MemoryStream)
            stream.Write(Encoding.Default.GetBytes("xref" & vbLf & "0 "), 0, 7)
            stream.Write(Encoding.Default.GetBytes(CountEntryes.ToString), 0, CountEntryes.ToString.Length)
            stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            stream.Write(Encoding.Default.GetBytes(CreateDefaultReference().GetXRef()), 0, CreateDefaultReference().GetXRef().Length)
            stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            For Each iobj In PDF.GetFileBody(_numberObjectStructure)
                stream.Write(Encoding.Default.GetBytes(iobj.Reference.GetXRef()), 0, iobj.Reference.GetXRef().Length)
                stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            Next
        End Sub

        ''' <summary>
        ''' Создаёт ссылку по умолчанию.
        ''' </summary>
        Private Function CreateDefaultReference() As ReferenceObject
            Return New ReferenceObject
        End Function

    End Class

End Namespace

