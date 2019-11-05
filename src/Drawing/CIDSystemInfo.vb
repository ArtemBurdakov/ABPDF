Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures

Namespace Drawing

    ''' <summary>
    ''' Представляет реестр символов.
    ''' </summary>
    Public Class CIDSystemInfo
        Inherits InderectObject

        Private _dictionary As DictionaryObject

        ''' <summary>
        ''' Создаёт реестр символов.
        ''' </summary>
        Public Sub New()
            _dictionary = New DictionaryObject
            _content = _dictionary
        End Sub

        ''' <summary>
        ''' Тело файла.
        ''' </summary>
        Public Shadows Property FileBody As FileBody
            Get
                Return _fileBody
            End Get
            Friend Set(value As FileBody)
                _fileBody = value
            End Set
        End Property

        ''' <summary>
        ''' Издатель набора символов.
        ''' </summary>
        Public Property Registry As StringObject
            Get
                Return _dictionary.Item(Names.Registry)
            End Get
            Friend Set(value As StringObject)
                _dictionary.Item(Names.Registry) = value
            End Set
        End Property

        ''' <summary>
        ''' Строка, которая уникально именует коллекцию символов в указанном реестре.
        ''' </summary>
        Public Property Ordering As StringObject
            Get
                Return _dictionary.Item(Names.Ordering)
            End Get
            Friend Set(value As StringObject)
                _dictionary.Item(Names.Ordering) = value
            End Set
        End Property

        ''' <summary>
        ''' Дополнительный номер.
        ''' </summary>
        Public Property Supplement As NumericObject
            Get
                Return _dictionary.Item(Names.Supplement)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.Supplement) = value
            End Set
        End Property

    End Class

End Namespace

