Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет каталог документа.
    ''' </summary>
    Public Class DocumentCatalog
        Inherits InderectObject

        Private _dictionary As DictionaryObject

        ''' <summary>
        ''' Создаёт косвенный объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As DocumentCatalog
            Return New DocumentCatalog(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт каталог документа.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _dictionary = New DictionaryObject
            _content = _dictionary
            _fileBody = fileBody
            Type = Names.Catalog
            Dim dash = Text.Encoding.Default.GetString({&H2D})
            _dictionary.Add(New NameObject("Lang"), New StringObject("ru" & dash & "RU"))
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
        ''' Корень дерева страниц документа.
        ''' </summary>
        Public Property Pages As DocumentNode
            Get
                Return _dictionary.Item(Names.Pages)
            End Get
            Friend Set(value As DocumentNode)
                _dictionary.Item(Names.Pages) = value
            End Set
        End Property

    End Class

End Namespace

