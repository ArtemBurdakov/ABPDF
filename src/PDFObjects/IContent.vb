Namespace PDFObjects

    ''' <summary>
    ''' Предоставляет механизм возврата содержимого PDF объекта.
    ''' </summary>
    Public Interface IContent
        Inherits IWritable

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Function GetContent() As Object

    End Interface

End Namespace

