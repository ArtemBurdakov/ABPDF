Imports System.IO
Imports System.Text
Imports ABPDF.PDFObjects
Imports ABPDF.DocumentStructures

Namespace Drawing

    ''' <summary>
    ''' Представляет объект для рисования графики.
    ''' </summary>
    Public Class Graphics
        Implements IDrawable

        Private _content As MemoryStream

        ''' <summary>
        ''' Создаёт объект для рисования графики.
        ''' </summary>
        Sub New()
            _content = New MemoryStream()
        End Sub

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend ReadOnly Property Length() As Integer
            Get
                Return _content.Length
            End Get
        End Property

        ''' <summary>
        ''' Перемещает "курсор" в позицию x, y и делает её текущей.
        ''' </summary>
        ''' <param name="coordinate">Координаты позиции</param>
        Public Sub MoveTo(coordinate As Point)
            coordinate.WriteIn(_content)
            _content.Write(Encoding.Default.GetBytes(" m" & vbLf), 0, 3)
        End Sub

        ''' <summary>
        ''' Ведёт линию из текущей позиции в указанную, и делает в последствии указанную текущей.
        ''' </summary>
        ''' <param name="coordinate">Координаты позиции</param>
        Public Sub LineTo(coordinate As Point)
            coordinate.WriteIn(_content)
            _content.Write(Encoding.Default.GetBytes(" l" & vbLf), 0, 3)
        End Sub

        ''' <summary>
        ''' Завершает путь, проводя линию из текущей позиции к начальной.
        ''' </summary>
        Public Sub ClosePath()
            _content.Write(Encoding.Default.GetBytes("h" & vbLf), 0, 2)
        End Sub

        ''' <summary>
        ''' Создаёт путь в виде прямоугольника.
        ''' </summary>
        ''' <param name="coordinate">Координаты позиции</param>
        ''' <param name="width">Ширина прямоугольника</param>
        ''' <param name="height">Высота прямоугольника</param>
        Public Sub Rect(coordinate As Point, width As Double, height As Double)
            Dim widthN = New NumericObject(width)
            Dim heightN = New NumericObject(height)
            coordinate.WriteIn(_content)
            _content.Write(Encoding.Default.GetBytes(" "), 0, 1)
            widthN.WriteIn(_content)
            _content.Write(Encoding.Default.GetBytes(" "), 0, 1)
            heightN.WriteIn(_content)
            _content.Write(Encoding.Default.GetBytes(" re" & vbLf), 0, 4)
        End Sub

        ''' <summary>
        ''' Обводит путь линиями.
        ''' </summary>
        Public Sub Stroke()
            _content.Write(Encoding.Default.GetBytes("S" & vbLf), 0, 2)
        End Sub

        ''' <summary>
        ''' Заливает путь сплошным цветом.
        ''' </summary>
        Public Sub Fill()
            _content.Write(Encoding.Default.GetBytes("F" & vbLf), 0, 2)
        End Sub

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            Dim bytes = _content.ToArray()
            Return Encoding.Default.GetString(bytes)
        End Function

        ''' <summary>
        ''' Рисуент компонент в контенте страницы.
        ''' </summary>
        Friend Sub DrawTo(content As ContentPageObject) Implements IDrawable.DrawTo
            WriteIn(content.Stream)
        End Sub

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Sub WriteIn(stream As MemoryStream)
            _content.WriteTo(stream)
        End Sub

        ''' <summary>
        ''' Добаляет объекты компонента в справочник ресурсов.
        ''' </summary>
        Friend Sub AddObjectsIn(resources As ResourceDictionary) Implements IDrawable.AddObjectsIn
            'Ресурсов у объекта графики нет.
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(_content, IDisposable).Dispose()
        End Sub

    End Class

End Namespace

