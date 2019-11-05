Imports ABPDF.DocumentStructures

Namespace Drawing

    ''' <summary>
    ''' Интерфейс, который требуется для компонентов, которые можно нарисовать на странице PDF.
    ''' </summary>
    Public Interface IDrawable
        Inherits IDisposable

        ''' <summary>
        ''' Рисуент компонент в контенте страницы.
        ''' </summary>
        Sub DrawTo(content As ContentPageObject)

        ''' <summary>
        ''' Добаляет объекты компонента в справочник ресурсов.
        ''' </summary>
        Sub AddObjectsIn(resources As ResourceDictionary)

    End Interface

End Namespace

