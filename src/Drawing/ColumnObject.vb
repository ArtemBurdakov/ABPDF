Namespace Drawing

    ''' <summary>
    ''' Представляет столбец таблицы, отображаемой на странице PDF.
    ''' </summary>
    Public Class ColumnObject

        Enum AlignmentHorisontal
            Left = 0
            Center = 1
            Right = 2
        End Enum

        Public Property Name As String
        Public Property Width As Double
        Public Property AlignmentH As AlignmentHorisontal

    End Class

End Namespace

