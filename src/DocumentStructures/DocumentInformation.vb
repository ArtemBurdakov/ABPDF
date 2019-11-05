Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет словарь информации о документе.
    ''' </summary>
    Public Class DocumentInformation
        Inherits InderectObject

        Private _dictionary As DictionaryObject

        ''' <summary>
        ''' Создаёт косвенный объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As DocumentInformation
            Return New DocumentInformation(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт словарь информации о документе.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _dictionary = New DictionaryObject
            _content = _dictionary
            _fileBody = fileBody
            CreationDate = Date.Now
            Producer = "ABPDF"
        End Sub

        ''' <summary>
        ''' Наименование документа.
        ''' </summary>
        Public Property Title As String
            Get
                Return CType(CType(_dictionary.Item(Names.Title), IContent).GetContent(), String)
            End Get
            Set(value As String)
                _dictionary.Item(Names.Title) = New StringObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Имя человека, создавшего документ.
        ''' </summary>
        Public Property Author As String
            Get
                Return CType(CType(_dictionary.Item(Names.Author), IContent).GetContent(), String)
            End Get
            Set(value As String)
                _dictionary.Item(Names.Author) = New StringObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Тема документа.
        ''' </summary>
        Public Property Subject As String
            Get
                Return CType(CType(_dictionary.Item(Names.Subject), IContent).GetContent(), String)
            End Get
            Set(value As String)
                _dictionary.Item(Names.Subject) = New StringObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Ключевые слова, связанные с документом.
        ''' </summary>
        Public Property Keywords As String
            Get
                Return CType(CType(_dictionary.Item(Names.Keywords), IContent).GetContent(), String)
            End Get
            Set(value As String)
                _dictionary.Item(Names.Keywords) = New StringObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Если документ был преобразован в PDF из другого формата, имя соответствующего продукта, который создал исходный документ, с которого он был преобразован.
        ''' </summary>
        Public Property Creator As String
            Get
                Return CType(CType(_dictionary.Item(Names.Creator), IContent).GetContent(), String)
            End Get
            Set(value As String)
                _dictionary.Item(Names.Creator) = New StringObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Если документ был преобразован в PDF из другого формата, название соответствующего продукта, преобразующего его в PDF.
        ''' </summary>
        Public Property Producer As String
            Get
                Return CType(CType(_dictionary.Item(Names.Producer), IContent).GetContent(), String)
            End Get
            Set(value As String)
                _dictionary.Item(Names.Producer) = New StringObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Дата и время создания документа.
        ''' </summary>
        Public Property CreationDate As Date
            Get
                Return CType(CType(_dictionary.Item(Names.CreationDate), IContent).GetContent(), Date)
            End Get
            Set(value As Date)
                _dictionary.Item(Names.CreationDate) = New DateObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Дата и время модификации документа.
        ''' </summary>
        Public Property ModDate As Date
            Get
                Return CType(CType(_dictionary.Item(Names.ModDate), IContent).GetContent(), Date)
            End Get
            Set(value As Date)
                _dictionary.Item(Names.ModDate) = New DateObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Свойство, указывающиее, был ли документ изменен для включения информации об улавливании.
        ''' </summary>
        Public Property Trapped As NameObject
            Get
                Return _dictionary.Item(Names.Trapped)
            End Get
            Set(value As NameObject)
                _dictionary.Item(Names.Trapped) = value
            End Set
        End Property

    End Class

End Namespace

