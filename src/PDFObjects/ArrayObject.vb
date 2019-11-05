Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет массив PDF.
    ''' </summary>
    Public Class ArrayObject
        Inherits PDFObject
        Implements IContent, IEnumerable

        Private _content As List(Of PDFObject)

        ''' <summary>
        ''' Создаёт массив.
        ''' </summary>
        Public Sub New()
            _content = New List(Of PDFObject)
            WrapElements = False
            FirstAsArray = True
        End Sub

        ''' <summary>
        ''' Возвращает число объектов массива.
        ''' </summary>
        Public ReadOnly Property Count() As Integer
            Get
                Return _content.Count
            End Get
        End Property

        ''' <summary>
        ''' Признак переноса элементов массива на новую строку, по умолчанию False.
        ''' </summary>
        Public Property WrapElements As Boolean

        ''' <summary>
        ''' Признак отображения массива когда в нём один элемент, по умолчанию True.
        ''' </summary>
        Public Property FirstAsArray As Boolean

        ''' <summary>
        ''' Возвращает или задаёт объект по указанному индексу.
        ''' </summary>
        ''' <param name="index">Отсчитываемый от нуля индекс элемента,который требуется возвратить или задать</param>
        Public Property Item(index As Integer) As PDFObject
            Get
                Return _content.Item(index)
            End Get
            Set(value As PDFObject)
                _content.Item(index) = value
            End Set
        End Property

        ''' <summary>
        ''' Добавляет объект в массив.
        ''' </summary>
        ''' <param name="content">Содержимое объекта</param>
        Public Sub Add(content As PDFObject)
            _content.Add(content)
        End Sub

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                If _content.Count = 0 Then
                    Return 4
                ElseIf _content.Count = 1 AndAlso Not FirstAsArray
                    Return _content.First.Length
                Else
                    Return LengthAllObjects()
                End If
            End Get
        End Property

        ''' <summary>
        ''' Возвращает количество байтов всех объектов массива.
        ''' </summary>
        Private Function LengthAllObjects() As Integer
            Dim len As Integer = 3
            For Each c In _content
                len += c.Length + 1
            Next
            Return len
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_content, IEnumerable).GetEnumerator()
        End Function

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return _content.ToArray()
        End Function

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            If _content.Count = 0 Then
                Return New NullObject().ToString()
            ElseIf _content.Count = 1 AndAlso Not FirstAsArray
                Return _content.First.ToString()
            Else
                Return ToStringAllObjects()
            End If
        End Function

        ''' <summary>
        ''' Возвращает строковое представление всех объектов массива.
        ''' </summary>
        Private Function ToStringAllObjects() As String
            Dim result = "["
            If WrapElements Then
                result &= vbLf
            Else
                result &= " "
            End If
            For Each c In _content
                If WrapElements Then
                    result &= c.ToString() & vbLf
                Else
                    result &= c.ToString() & " "
                End If
            Next
            Return result & "]"
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            If _content.Count = 0 Then
                Dim null = New NullObject()
                null.WriteIn(stream)
            ElseIf _content.Count = 1 AndAlso Not FirstAsArray
                _content.First.WriteIn(stream)
            Else
                AddAllObjects(stream)
            End If
        End Sub

        ''' <summary>
        ''' Добавляет все объекты массива в MemoryStream.
        ''' </summary>
        Private Sub AddAllObjects(stream As MemoryStream)
            stream.Write(Encoding.Default.GetBytes("["), 0, 1)
            If WrapElements Then
                stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            Else
                stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
            End If
            For Each c In _content
                c.WriteIn(stream)
                If WrapElements Then
                    stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
                Else
                    stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
                End If
            Next
            stream.Write(Encoding.Default.GetBytes("]"), 0, 1)
        End Sub

    End Class

    ''' <summary>
    ''' Представляет массив PDF.
    ''' </summary>
    Public Class ArrayObject(Of TPDFObject As PDFObject)
        Inherits PDFObject
        Implements IContent, IEnumerable(Of TPDFObject)

        Private _content As List(Of TPDFObject)

        ''' <summary>
        ''' Создаёт массив.
        ''' </summary>
        Public Sub New()
            _content = New List(Of TPDFObject)
            WrapElements = False
            FirstAsArray = True
        End Sub

        ''' <summary>
        ''' Возвращает число объектов массива.
        ''' </summary>
        Public ReadOnly Property Count() As Integer
            Get
                Return _content.Count
            End Get
        End Property

        ''' <summary>
        ''' Признак переноса элементов массива на новую строку, по умолчанию False.
        ''' </summary>
        Public Property WrapElements As Boolean

        ''' <summary>
        ''' Признак отображения массива когда в нём один элемент, по умолчанию True.
        ''' </summary>
        Public Property FirstAsArray As Boolean

        ''' <summary>
        ''' Возвращает или задаёт объект по указанному индексу.
        ''' </summary>
        ''' <param name="index">Отсчитываемый от нуля индекс элемента, который требуется возвратить или задать</param>
        Public Property Item(index As Integer) As TPDFObject
            Get
                Return _content.Item(index)
            End Get
            Set(value As TPDFObject)
                _content.Item(index) = value
            End Set
        End Property

        ''' <summary>
        ''' Добавляет объект в массив.
        ''' </summary>
        ''' <param name="content">Содержимое объекта</param>
        Public Sub Add(content As TPDFObject)
            _content.Add(content)
        End Sub

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                If _content.Count = 0 Then
                    Return 4
                ElseIf _content.Count = 1 AndAlso Not FirstAsArray
                    Return _content.First.Length
                Else
                    Return LengthAllObjects()
                End If
            End Get
        End Property

        ''' <summary>
        ''' Возвращает количество байтов всех объектов массива.
        ''' </summary>
        Private Function LengthAllObjects() As Integer
            Dim len As Integer = 3
            For Each c In _content
                len += c.Length + 1
            Next
            Return len
        End Function

        Public Function GetEnumerator() As IEnumerator(Of TPDFObject) Implements IEnumerable(Of TPDFObject).GetEnumerator
            Return DirectCast(_content, IEnumerable(Of TPDFObject)).GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_content, IEnumerable(Of TPDFObject)).GetEnumerator()
        End Function

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return _content.ToArray()
        End Function

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            If _content.Count = 0 Then
                Return New NullObject().ToString()
            ElseIf _content.Count = 1 AndAlso Not FirstAsArray
                Return _content.First.ToString()
            Else
                Return ToStringAllObjects()
            End If
        End Function

        ''' <summary>
        ''' Возвращает строковое представление всех объектов массива.
        ''' </summary>
        Private Function ToStringAllObjects() As String
            Dim result = "["
            If WrapElements Then
                result &= vbLf
            Else
                result &= " "
            End If
            For Each c In _content
                If WrapElements Then
                    result &= c.ToString() & vbLf
                Else
                    result &= c.ToString() & " "
                End If
            Next
            Return result & "]"
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            If _content.Count = 0 Then
                Dim null = New NullObject()
                null.WriteIn(stream)
            ElseIf _content.Count = 1 AndAlso Not FirstAsArray
                _content.First.WriteIn(stream)
            Else
                AddAllObjects(stream)
            End If
        End Sub

        ''' <summary>
        ''' Добавляет все объекты массива в MemoryStream.
        ''' </summary>
        Private Sub AddAllObjects(stream As MemoryStream)
            stream.Write(Encoding.Default.GetBytes("["), 0, 1)
            If WrapElements Then
                stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            Else
                stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
            End If
            For Each c In _content
                c.WriteIn(stream)
                If WrapElements Then
                    stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
                Else
                    stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
                End If
            Next
            stream.Write(Encoding.Default.GetBytes("]"), 0, 1)
        End Sub

    End Class

End Namespace

