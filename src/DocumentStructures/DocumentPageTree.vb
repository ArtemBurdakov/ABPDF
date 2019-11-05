Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет страничное дерево документа.
    ''' </summary>
    Public Class DocumentPageTree
        Inherits DocumentNode
        Implements IEnumerable(Of DocumentNode), IDisposable

        Private _dictionary As DictionaryObject
        Private _kids As ArrayObject(Of DocumentNode)

        ''' <summary>
        ''' Создаёт косвенный объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As DocumentPageTree
            Return New DocumentPageTree(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт страничное дерево документа.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _dictionary = New DictionaryObject
            _content = _dictionary
            _fileBody = fileBody
            Type = Names.Pages
            CreateKids()
            Count = 0
        End Sub

        ''' <summary>
        ''' Создаёт массив детей. 
        ''' </summary>
        Private Sub CreateKids()
            _kids = New ArrayObject(Of DocumentNode)
            _kids.WrapElements = True
            _dictionary.Add(Names.Kids, _kids)
        End Sub

        ''' <summary>
        ''' Тип объекта документа.
        ''' </summary>
        Public Property Type As NameObject
            Get
                Return _dictionary.Item(Names.Type)
            End Get
            Protected Set(value As NameObject)
                _dictionary.Item(Names.Type) = value
            End Set
        End Property

        ''' <summary>
        ''' Количество узлов.
        ''' </summary>
        Public Property Count As Integer
            Get
                Return CType(_dictionary.Item(Names.Count), NumericObject).GetContent()
            End Get
            Friend Set(value As Integer)
                Dim test = Names.Count
                _dictionary.Item(test) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Родительский узел.
        ''' </summary>
        Public Overrides Property ParentNode As DocumentNode
            Get
                Return _dictionary.Item(Names.Parent)
            End Get
            Set(value As DocumentNode)
                _dictionary.Item(Names.Parent) = value
            End Set
        End Property

        ''' <summary>
        ''' Дети узла.
        ''' </summary>
        Public ReadOnly Property Kids As ArrayObject(Of DocumentNode)
            Get
                Return _kids
            End Get
        End Property

        ''' <summary>
        ''' Добавляет узел в дерево.
        ''' </summary>
        ''' <param name="node"></param>
        Public Sub Add(node As DocumentNode)
            node.ParentNode = Me
            _kids.Add(node)
            node.AddInBody()
            Count = _kids.Count
        End Sub

        Public Function GetEnumerator() As IEnumerator(Of DocumentNode) Implements IEnumerable(Of DocumentNode).GetEnumerator
            Return DirectCast(_kids, IEnumerable(Of DocumentNode)).GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_kids, IEnumerable(Of DocumentNode)).GetEnumerator()
        End Function

        ''' <summary>
        ''' Добавляет этот узел в тело файла. 
        ''' </summary>
        Friend Overrides Sub AddInBody()
            FileBody.Add(Me)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            For Each k In _kids
                If k.isPage Then
                    DirectCast(k, IDisposable).Dispose()
                End If
            Next
        End Sub

    End Class

End Namespace

