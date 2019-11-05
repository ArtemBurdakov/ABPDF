Imports System.IO
Imports System.Text
Imports ABPDF.PDFObjects

Namespace FileStructures

    ''' <summary>
    ''' Тело файла PDF.
    ''' </summary>
    Public Class FileBody
        Inherits FileStructure
        Implements IEnumerable(Of InderectObject)

        Private _content As List(Of InderectObject)
        Private _numberObjectStructure As Integer

        ''' <summary>
        ''' Создаёт тело файла привязанное к документу.
        ''' </summary>
        ''' <param name="pdf">Документ</param>
        Public Shared Function CreateWithDocument(pdf As PDF) As FileBody
            Return New FileBody(pdf)
        End Function

        ''' <summary>
        ''' Создаёт тело файла PDF.
        ''' </summary>
        ''' <param name="pdf">PDF документ</param>
        Private Sub New(pdf As PDF)
            Me.PDF = pdf
            _content = New List(Of InderectObject)
            _numberObjectStructure = pdf.CountObjectStructures
        End Sub

        ''' <summary>
        ''' Возвращает количество объектов.
        ''' </summary>
        Public ReadOnly Property CountObjects As Integer
            Get
                Return _content.Count
            End Get
        End Property

        ''' <summary>
        ''' Возвращает количество байтов структуры.
        ''' </summary>
        Friend Overrides ReadOnly Property Length() As Integer
            Get
                Dim len = 0
                For Each c In _content
                    len += c.Length + 1
                Next
                Return len
            End Get
        End Property

        ''' <summary>
        ''' Добавляет косвенный объект в тело файла.
        ''' </summary>
        ''' <param name="content">Косвенный объект</param>
        Public Sub Add(content As InderectObject)
            BindReference(content.Reference)
            _content.Add(content)
        End Sub

        ''' <summary>
        ''' Возвращает строковое представление структуры.
        ''' </summary>
        Public Overrides Function ToString() As String
            Dim result = ""
            For Each c In _content
                result &= c.ToString() & vbLf
            Next
            Return result
        End Function

        ''' <summary>
        ''' Возвращает перечеслитель, перебирающий элементы в колекции.
        ''' </summary>
        Public Function GetEnumerator() As IEnumerator(Of InderectObject) Implements IEnumerable(Of InderectObject).GetEnumerator
            Return DirectCast(_content, IEnumerable(Of InderectObject)).GetEnumerator()
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Overrides Sub WriteIn(stream As MemoryStream)
            For Each c In _content
                c.WriteIn(stream)
                stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            Next
        End Sub

        ''' <summary>
        ''' Привязывает ссылку.
        ''' </summary>
        Private Sub BindReference(ref As ReferenceObject)
            ref.ObjectNumber = _content.Count + 1
        End Sub

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_content, IEnumerable(Of InderectObject)).GetEnumerator()
        End Function

    End Class

End Namespace

