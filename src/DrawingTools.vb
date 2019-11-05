Imports System.IO
Imports ABPDF.Drawing

''' <summary>
''' Фабрика для создания объектов отображаемых на странице.
''' </summary>
Public Class DrawingTools

    ''' <summary>
    ''' Создаёт структуру, представляющую координаты точки.
    ''' </summary>
    Public Shared Function Point(x As Double, y As Double) As Point
        Return New Point(x, y)
    End Function

    ''' <summary>
    ''' Создаёт объект для рисования графики.
    ''' </summary>
    Public Shared Function Graphics() As Graphics
        Return New Graphics()
    End Function

    ''' <summary>
    ''' Создаёт объект для рисования текста.
    ''' </summary>
    ''' <param name="font">Шрифт</param>
    ''' <param name="size">Размер шрифта</param>
    Public Shared Function TextWithFont(font As Font, size As UShort) As Text
        Return Text.CreateWithFont(font, size)
    End Function

    ''' <summary>
    ''' Создаёт объект для рисования таблицы.
    ''' </summary>
    Public Shared Function Table() As TableObject
        Return New TableObject()
    End Function

    ''' <summary>
    ''' Создаёт объект для рисования изображения.
    ''' </summary>
    Public Shared Function Image(stream As MemoryStream, imgType As ImageType) As Image
        Return New Image(stream, imgType)
    End Function

End Class
