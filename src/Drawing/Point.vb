Imports System.IO
Imports System.Text
Imports ABPDF.PDFObjects

Namespace Drawing

    ''' <summary>
    ''' Представляет координаты точки на странице.
    ''' </summary>
    Public Structure Point

        Private _x As Double
        Private _y As Double

        Public Shared Operator +(point1 As Point, point2 As Point) As Point
            Return New Point(point1._x + point2._x, point1._y + point2._y)
        End Operator

        Public Shared Operator -(point1 As Point, point2 As Point) As Point
            Return New Point(point1._x - point2._x, point1._y - point2._y)
        End Operator

        ''' <summary>
        ''' Создаёт координаты.
        ''' </summary>
        Public Sub New(x As Double, y As Double)
            _x = x
            _y = y
        End Sub

        Public Overrides Function ToString() As String
            Return New NumericObject(_x).ToString() & " " & New NumericObject(_y).ToString()
        End Function

        ''' <summary>
        ''' Записывает структуру в MemoryStream.
        ''' </summary>
        Friend Sub WriteIn(stream As MemoryStream)
            Dim nX = New NumericObject(_x)
            Dim nY = New NumericObject(_y)
            nX.WriteIn(stream)
            stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
            nY.WriteIn(stream)
        End Sub

    End Structure

End Namespace

