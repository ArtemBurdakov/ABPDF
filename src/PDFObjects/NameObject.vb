Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет именной объект в PDF.
    ''' </summary>
    Public Class NameObject
        Inherits PDFObject
        Implements IContent, IEquatable(Of NameObject)

        Private _content As String

        Public Shared Operator =(name1 As NameObject, name2 As NameObject) As Boolean
            Return name1.Equals(name2)
        End Operator

        Public Shared Operator <>(name1 As NameObject, name2 As NameObject) As Boolean
            Return Not name1.Equals(name2)
        End Operator

        ''' <summary>
        ''' Создаёт именной объект.
        ''' </summary>
        ''' <param name="content">Содержимое объекта</param>
        Public Sub New(content As String)
            _content = content
        End Sub

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                Return _content.Length + 1
            End Get
        End Property

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return "/" & _content
        End Function

        ''' <summary>
        ''' Переименовывает объект.
        ''' </summary>
        Public Sub ReName(name As String)
            _content = name
        End Sub

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return _content
        End Function

        ''' <summary>
        ''' Определяет равен ли объект, текущему объекту.
        ''' </summary>
        ''' <param name="other">Именной объект</param>
        Public Overloads Function Equals(other As NameObject) As Boolean Implements IEquatable(Of NameObject).Equals
            Return ToString() = other.ToString()
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            Return Equals(DirectCast(obj, NameObject))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return ToString().GetHashCode()
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            stream.Write(Encoding.Default.GetBytes("/"), 0, 1)
            stream.Write(Encoding.Default.GetBytes(_content), 0, _content.Length)
        End Sub

    End Class

End Namespace

