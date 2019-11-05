Imports ABPDF.PDFObjects

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет узел документа.
    ''' </summary>
    Public MustInherit Class DocumentNode
        Inherits InderectObject

        ''' <summary>
        ''' Родительский узел.
        ''' </summary>
        Public MustOverride Property ParentNode As DocumentNode

        ''' <summary>
        ''' Возвращает значение, указывающее является ли узел страницей.
        ''' </summary>
        Public ReadOnly Property isPage As Boolean
            Get
                Return If(TypeOf Me Is DocumentPage, True, False)
            End Get
        End Property

        ''' <summary>
        ''' Добавляет этот узел в тело файла. 
        ''' </summary>
        Friend MustOverride Sub AddInBody()

    End Class

End Namespace

