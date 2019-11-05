Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет пустой объект в PDF.
    ''' </summary>
    Public Class NullObject
        Inherits PDFObject
        Implements IContent

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                Return 4
            End Get
        End Property

        ''' <summary>
        '''  Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return "null"
        End Function

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return Nothing
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            stream.Write(Encoding.Default.GetBytes(ToString()), 0, ToString().Length)
        End Sub

    End Class

End Namespace

