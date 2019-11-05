Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет словарь PDF.
    ''' </summary>
    Public Class DictionaryObject
        Inherits PDFObject
        Implements IContent

        Private _content As Dictionary(Of NameObject, PDFObject)

        ''' <summary>
        ''' Создаёт словарь.
        ''' </summary>
        Public Sub New()
            _content = New Dictionary(Of NameObject, PDFObject)
        End Sub

        ''' <summary>
        ''' Возвращает колекцию, содержащую ключи из словоря.
        ''' </summary>
        Public ReadOnly Property Keys() As Dictionary(Of NameObject, PDFObject).KeyCollection
            Get
                Return _content.Keys
            End Get
        End Property

        ''' <summary>
        ''' Возвращает колекцию, содержащую значения из словоря.
        ''' </summary>
        Public ReadOnly Property Values() As Dictionary(Of NameObject, PDFObject).ValueCollection
            Get
                Return _content.Values
            End Get
        End Property

        ''' <summary>
        ''' Возвращает или задаёт значенние, связанное с указанным ключом.
        ''' </summary>
        ''' <param name="key">Ключ записи в словаре</param>
        Public Property Item(key As NameObject) As PDFObject
            Get
                Return _content.Item(key)
            End Get
            Set(value As PDFObject)
                _content.Item(key) = value
            End Set
        End Property

        ''' <summary>
        ''' Добавляет объект в словарь.
        ''' </summary>
        ''' <param name="key">Ключ записи в словаре</param>
        ''' <param name="value">Значение записи в словаре</param>
        Public Sub Add(key As NameObject, value As PDFObject)
            _content.Add(key, value)
        End Sub

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                Dim len = 5
                If _content.Count = 0 Then
                    len += 5
                Else
                    For Each c In _content
                        If c.Value IsNot Nothing Then
                            len += c.Key.Length + c.Value.Length + 2
                        End If
                    Next
                End If
                Return len
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
            If _content.Count = 0 Then
                Return "<<" & vbLf & New NullObject().ToString() & ">>"
            Else
                Return "<<" & vbLf & ToStringAllEntries() & ">>"
            End If
        End Function

        ''' <summary>
        ''' Возвращает все записи словаря в виде строки.
        ''' </summary>
        Private Function ToStringAllEntries() As String
            Dim result = ""
            For Each c In _content
                If c.Value IsNot Nothing Then
                    result &= c.Key.ToString() & " " & c.Value.ToString() & vbLf
                End If
            Next
            Return result
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            stream.Write(Encoding.Default.GetBytes("<<" & vbLf), 0, 3)
            If _content.Count = 0 Then
                AddNullObject(stream)
            Else
                AddAllEntries(stream)
            End If
            stream.Write(Encoding.Default.GetBytes(">>"), 0, 2)
        End Sub

        ''' <summary>
        ''' Добавляет пустой объект в MemoryStream.
        ''' </summary>
        Private Sub AddNullObject(stream As MemoryStream)
            Dim null = New NullObject()
            null.WriteIn(stream)
            stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
        End Sub

        ''' <summary>
        ''' Добавляет все записи словаря в MemoryStream.
        ''' </summary>
        Private Sub AddAllEntries(stream As MemoryStream)
            For Each c In _content
                If c.Value IsNot Nothing Then
                    c.Key.WriteIn(stream)
                    stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
                    c.Value.WriteIn(stream)
                    stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
                End If
            Next
        End Sub

    End Class

End Namespace

