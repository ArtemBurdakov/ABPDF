Imports System.Text
Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures
Imports ABPDF.Drawing

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет страницу документа.
    ''' </summary>
    Public Class DocumentPage
        Inherits DocumentNode
        Implements IDisposable

        Private _dictionary As DictionaryObject
        Private _drawingObjects As List(Of IDrawable)
        Private _height As Integer = 792
        Private _width As Integer = 612

        ''' <summary>
        ''' Создаёт косвенный объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As DocumentPage
            Return New DocumentPage(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт страничное дерево документа.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _dictionary = New DictionaryObject
            _content = _dictionary
            _fileBody = fileBody
            _drawingObjects = New List(Of IDrawable)
            Type = Names.Page
            MediaBox = New RectanglesObject With {.LowLeftX = 0, .LowLeftY = 0, .UpRightX = _width, .UpRightY = _height}
        End Sub

        ''' <summary>
        ''' Высота страницы (по умолчанию 792).
        ''' </summary>
        Public Property Height As Integer
            Get
                Return _height
            End Get
            Set(value As Integer)
                _height = value
                MediaBox.UpRightY = value
            End Set
        End Property

        ''' <summary>
        ''' Ширина страницы (по умолчанию 612).
        ''' </summary>
        Public Property Width As Integer
            Get
                Return _width
            End Get
            Set(value As Integer)
                _width = value
                MediaBox.UpRightX = value
            End Set
        End Property

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
        ''' Ресурсы страницы.
        ''' </summary>
        Public Property Resources As ResourceDictionary
            Get
                Return _dictionary.Item(Names.Resources)
            End Get
            Protected Set(value As ResourceDictionary)
                _dictionary.Item(Names.Resources) = value
            End Set
        End Property

        ''' <summary>
        ''' Границы физического носителя, на котором страница должна отображаться или печататься.
        ''' </summary>
        Public Property MediaBox As RectanglesObject
            Get
                Return _dictionary.Item(Names.MediaBox)
            End Get
            Protected Set(value As RectanglesObject)
                _dictionary.Item(Names.MediaBox) = value
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
        ''' Потоки содержимого.
        ''' </summary>
        Public Property Contents As ArrayObject(Of ContentPageObject)
            Get
                Return _dictionary.Item(Names.Contents)
            End Get
            Protected Set(value As ArrayObject(Of ContentPageObject))
                _dictionary.Item(Names.Contents) = value
            End Set
        End Property

        ''' <summary>
        ''' Рисует объект.
        ''' </summary>
        ''' <param name="drawing">Объект, который будет нарисован на странице</param>
        Public Sub Draw(drawing As IDrawable)
            drawing.AddObjectsIn(Resources)
            drawing.DrawTo(Contents.Last)
            _drawingObjects.Add(drawing)
        End Sub

        ''' <summary>
        ''' Добавляет этот узел и связанные с ним объекты в тело файла. 
        ''' </summary>
        Friend Overrides Sub AddInBody()
            FileBody.Add(Me)
            CreateResources()
            CreateContents()
        End Sub

        ''' <summary>
        ''' Создаёт справочник ресурсов.
        ''' </summary>
        Private Sub CreateResources()
            Resources = ResourceDictionary.CreateWithBody(FileBody)
            FileBody.Add(Resources)
        End Sub

        ''' <summary>
        ''' Создаёт массив содержимого.
        ''' </summary>
        Private Sub CreateContents()
            Contents = New ArrayObject(Of ContentPageObject) From {ContentPageObject.CreateWithBody(FileBody)}
            Contents.FirstAsArray = False
            Contents.WrapElements = True
            FileBody.Add(Contents.First)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            For Each c In Contents
                c.Dispose()
            Next
            For Each d In _drawingObjects
                d.Dispose()
            Next
        End Sub
    End Class

End Namespace

