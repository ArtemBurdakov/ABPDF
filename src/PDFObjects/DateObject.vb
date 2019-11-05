Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет дату PDF.
    ''' </summary>
    Public Class DateObject
        Inherits PDFObject
        Implements IContent

        Private _content As String

        ''' <summary>
        ''' Создаёт дату.
        ''' </summary>
        ''' <param name="content">Содержимое объекта</param>
        Public Sub New(content As Date)
            Dim UT As String
            If content.ToUniversalTime() < content Then
                UT = "+" & (content - content.ToUniversalTime()).Hours.ToString.PadLeft(2, "0") & "'" & (content - content.ToUniversalTime()).Minutes.ToString.PadLeft(2, "0")
            ElseIf content.ToUniversalTime() > content
                UT = "-" & (content.ToUniversalTime() - content).Hours.ToString.PadLeft(2, "0") & "'" & (content.ToUniversalTime() - content).Minutes.ToString.PadLeft(2, "0")
            Else
                UT = "Z"
            End If
            _content = "(D:" & content.ToString("yyyyMMddHHmmss") & UT & ")"
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
            Return Date.Parse(_content)
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            stream.Write(Encoding.Default.GetBytes(_content), 0, _content.Length)
        End Sub

    End Class

End Namespace

