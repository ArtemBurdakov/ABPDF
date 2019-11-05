Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Namespace PDFObjects

    ''' <summary>
    ''' Представляет строковой объект PDF.
    ''' </summary>
    Public Class StringObject
        Inherits PDFObject
        Implements IContent

        Private _content As String

        ''' <summary>
        ''' Создаёт строковой объект.
        ''' </summary>
        ''' <param name="content">Содержимое объекта</param>
        Public Sub New(content As String)
            _content = content
            Hexadecimal = False
        End Sub

        ''' <summary>
        ''' Признак шеснадцетиричной строки.
        ''' </summary>
        Public Property Hexadecimal As Boolean

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                Return _content.Length + 2
            End Get
        End Property

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return _content
        End Function

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            If Hexadecimal Then
                Return ToStringHexadecimal()
            End If
            Return "(" & _content & ")"
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            stream.Write(Encoding.Default.GetBytes(ToString()), 0, ToString().Length)
        End Sub

        ''' <summary>
        ''' Возвращает строковое представление шеснадцетиричной строки.
        ''' </summary>
        Private Function ToStringHexadecimal() As String
            If _content = "" OrElse Regex.IsMatch(_content, "[0-9,A-F,a-f]+") Then
                Return "<" & _content & ">"
            Else
                Throw New Exception("В шеснадцетиричной строке должны содержаться только следующие символы: 0-9, A-F, a-f.")
            End If
        End Function

    End Class

End Namespace

