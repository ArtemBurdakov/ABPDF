Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет логический объект PDF.
    ''' </summary>
    Public Class BooleanObject
        Inherits PDFObject
        Implements IContent

        Private _content As String

        ''' <summary>
        ''' Создаёт логический объект.
        ''' </summary>
        ''' <param name="content">Содержимое объекта</param>
        Public Sub New(content As Boolean)
            _content = content.ToString
        End Sub

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                Return _content.Length
            End Get
        End Property

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return _content
        End Function

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return Boolean.Parse(_content)
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            stream.Write(Encoding.Default.GetBytes(_content), 0, _content.Length)
        End Sub

    End Class

End Namespace

