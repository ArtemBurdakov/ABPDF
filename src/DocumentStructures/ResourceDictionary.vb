Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures
Imports ABPDF.Drawing

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет словарь ресурсов.
    ''' </summary>
    Public Class ResourceDictionary
        Inherits InderectObject

        Private _dictionary As DictionaryObject

        ''' <summary>
        ''' Создаёт косвенный объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As ResourceDictionary
            Return New ResourceDictionary(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт словарь ресурсов.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _dictionary = New DictionaryObject
            _content = _dictionary
            _fileBody = fileBody
        End Sub

        ''' <summary>
        ''' Словарь параметров состояния графики.
        ''' </summary>
        Public Property ExtGState As InderectObject
            Get
                Return _dictionary.Item(Names.ExtGState)
            End Get
            Protected Set(value As InderectObject)
                _dictionary.Item(Names.ExtGState) = value
            End Set
        End Property

        ''' <summary>
        ''' Словарь цветового пространста.
        ''' </summary>
        Public Property ColorSpace As InderectObject
            Get
                Return _dictionary.Item(Names.ColorSpace)
            End Get
            Protected Set(value As InderectObject)
                _dictionary.Item(Names.ColorSpace) = value
            End Set
        End Property

        ''' <summary>
        ''' Словарь шаблонов.
        ''' </summary>
        Public Property Pattern As InderectObject
            Get
                Return _dictionary.Item(Names.Pattern)
            End Get
            Protected Set(value As InderectObject)
                _dictionary.Item(Names.Pattern) = value
            End Set
        End Property

        ''' <summary>
        ''' Словарь затенений.
        ''' </summary>
        Public Property Shading As InderectObject
            Get
                Return _dictionary.Item(Names.Shading)
            End Get
            Protected Set(value As InderectObject)
                _dictionary.Item(Names.Shading) = value
            End Set
        End Property

        ''' <summary>
        ''' Словарь внешних объектов.
        ''' </summary>
        Public Property XObject As XObjectDictionary
            Get
                CreateXObjectDictionaryIfNothing()
                Return _dictionary.Item(Names.XObject)
            End Get
            Protected Set(value As XObjectDictionary)
                _dictionary.Item(Names.XObject) = value
            End Set
        End Property

        ''' <summary>
        ''' Создаёт справочник внешних объектов, если его нет.
        ''' </summary>
        Private Sub CreateXObjectDictionaryIfNothing()
            If Not _dictionary.Keys.Any(Function(x) x = Names.XObject) Then
                XObject = XObjectDictionary.CreateWithBody(FileBody)
            End If
        End Sub

        ''' <summary>
        ''' Словарь шрифтов.
        ''' </summary>
        Public Property Font As FontDictionary
            Get
                CreateFontDictionaryIfNothing()
                Return _dictionary.Item(Names.Font)
            End Get
            Friend Set(value As FontDictionary)
                _dictionary.Item(Names.Font) = value
            End Set
        End Property

        ''' <summary>
        ''' Создаёт справочник шрифтов, если его нет.
        ''' </summary>
        Private Sub CreateFontDictionaryIfNothing()
            If Not _dictionary.Keys.Any(Function(x) x = Names.Font) Then
                Font = FontDictionary.CreateWithBody(FileBody)
            End If
        End Sub

        ''' <summary>
        ''' Массив набора процедур.
        ''' </summary>
        Public Property ProcSet As InderectObject
            Get
                Return _dictionary.Item(Names.ProcSet)
            End Get
            Protected Set(value As InderectObject)
                _dictionary.Item(Names.ProcSet) = value
            End Set
        End Property

        ''' <summary>
        ''' Словарь списков свойств.
        ''' </summary>
        Public Property Properties As InderectObject
            Get
                Return _dictionary.Item(Names.Properties)
            End Get
            Protected Set(value As InderectObject)
                _dictionary.Item(Names.Properties) = value
            End Set
        End Property

    End Class

End Namespace

