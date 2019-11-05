Imports System.IO
Imports ABPDF.DocumentStructures

Namespace Drawing

    ''' <summary>
    ''' Представляет таблицу, отображаемую на странице PDF.
    ''' </summary>
    Public Class TableObject
        Implements IDrawable

        Private _currentPosition As Point
        Private _currentNumberColumn As Integer
        Private _grafs As List(Of Graphics)
        Private _texts As List(Of Text)
        Private _width As Double?

        Public Sub New()
            _grafs = New List(Of Graphics)
            _texts = New List(Of Text)
            HeightRow = 20
        End Sub

        ''' <summary>
        ''' Источник таблицы.
        ''' </summary>
        Public Property Source As IEnumerable

        ''' <summary>
        ''' Ширина таблицы.
        ''' </summary>
        Public Property Width As Double
            Get
                If Not _width.HasValue Then
                    _width = 0
                    CalculateWith()
                End If

                Return _width.Value
            End Get
            Private Set(value As Double)
                _width = value
            End Set
        End Property

        ''' <summary>
        ''' Массив, содержащий ширину столбцов.
        ''' </summary>
        Public Property Columns As ColumnObject()

        ''' <summary>
        ''' Высота заголовка.
        ''' </summary>
        Public Property HeightHeader As Double

        ''' <summary>
        ''' Высота строки.
        ''' </summary>
        Public Property HeightRow As Double

        ''' <summary>
        '''  Расположение таблицы на странице (координаты верхнего левого угла).
        ''' </summary>
        Public Property Position() As Point

        ''' <summary>
        ''' Шрифт.
        ''' </summary>
        Public Property Font() As Font

        ''' <summary>
        ''' Размер шрифа.
        ''' </summary>
        Public Property SizeFont() As UShort

        ''' <summary>
        ''' Шрифт заголовка.
        ''' </summary>
        Public Property FontHeader() As Font

        ''' <summary>
        ''' Размер шрифа заголовка.
        ''' </summary>
        Public Property SizeFontHeader() As UShort

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return ""
        End Function

        ''' <summary>
        ''' Рисуент компонент в контенте страницы.
        ''' </summary>
        Friend Sub DrawTo(content As ContentPageObject) Implements IDrawable.DrawTo
            WriteIn(content.Stream)
        End Sub

        ''' <summary>
        ''' Добаляет объекты компонента в справочник ресурсов.
        ''' </summary>
        Friend Sub AddObjectsIn(resources As ResourceDictionary) Implements IDrawable.AddObjectsIn
            resources.Font.Add(Font)
            resources.Font.Add(FontHeader)
        End Sub

        ''' <summary>
        ''' Записывает компонент в MemoryStream.
        ''' </summary>
        Friend Sub WriteIn(stream As MemoryStream)
            _currentPosition = Position - New Point(0, HeightHeader)
            _currentNumberColumn = 0
            If Source IsNot Nothing AndAlso Columns IsNot Nothing Then
                DrawHeader(stream)
                DrawRows(stream)
            End If
        End Sub

        ''' <summary>
        ''' Вычисляет ширину таблицы.
        ''' </summary>
        Private Sub CalculateWith()
            For Each c In Columns
                Width += c.Width
            Next
        End Sub

        ''' <summary>
        ''' Рисует загаловок таблицы.
        ''' </summary>
        Private Sub DrawHeader(stream As MemoryStream)
            For Each r In Source
                For Each c In Columns
                    DrawCurrentCell(stream, True)
                    DrawTextInCurrentCellHeader(stream, c.Name)
                    NextCell()
                Next
                NextRow()
                Exit For
            Next
        End Sub

        ''' <summary>
        ''' Рисует строки таблицы.
        ''' </summary>
        Private Sub DrawRows(stream As MemoryStream)
            For Each r In Source
                For Each p In r.GetType().GetProperties()
                    DrawCurrentCell(stream, False)
                    DrawTextInCurrentCell(stream, p.GetValue(r).ToString())
                    NextCell()
                Next
                NextRow()
            Next
        End Sub

        ''' <summary>
        ''' Следущая ячейка для рисования.
        ''' </summary>
        Private Sub NextCell()
            _currentPosition += New Point(Columns(_currentNumberColumn).Width, 0)
            _currentNumberColumn += 1
        End Sub

        ''' <summary>
        ''' Следующая строка для рисования.
        ''' </summary>
        Private Sub NextRow()
            _currentPosition -= New Point(Width, HeightRow)
            _currentNumberColumn = 0
        End Sub

        ''' <summary>
        ''' Рисует текущую ячейку.
        ''' </summary>
        Private Sub DrawCurrentCell(stream As MemoryStream, isHeader As Boolean)
            Dim graf = New Graphics()
            graf.Rect(_currentPosition, Columns(_currentNumberColumn).Width, If(isHeader, HeightHeader, HeightRow))
            graf.Stroke()
            graf.WriteIn(stream)
            _grafs.Add(graf)
        End Sub

        ''' <summary>
        ''' Рисует текст в текущей ячейке для заголовка.
        ''' </summary>
        Private Sub DrawTextInCurrentCellHeader(stream As MemoryStream, str As String)
            Dim words = str.Split(" ")
            Dim lines = New List(Of String)
            Dim line = ""
            For Each w In words
                If FontHeader.CalculateWidthString(line & w, SizeFontHeader) + 8 >= Columns(_currentNumberColumn).Width Then
                    If line.Length > 0 Then
                        line = line.Remove(line.Length - 1)
                    End If
                    lines.Add(line)
                    line = ""
                End If
                line &= w & " "
            Next
            If line <> "" Then
                line = line.Remove(line.Length - 1)
                lines.Add(line)
            End If
            For i = 0 To lines.Count - 1
                Dim txt = Text.CreateWithFont(FontHeader, SizeFontHeader)
                txt.Text = lines(i)
                SetPositionCenter(txt, FontHeader.GetLineHeight(SizeFontHeader) * (i + 1) - HeightHeader + 4)
                txt.WriteIn(stream)
                _texts.Add(txt)
            Next
        End Sub

        ''' <summary>
        ''' Рисует текст в текущей ячейке.
        ''' </summary>
        Private Sub DrawTextInCurrentCell(stream As MemoryStream, str As String)
            Dim txt = Text.CreateWithFont(Font, SizeFont)
            txt.Text = str
            If Columns(_currentNumberColumn).AlignmentH = ColumnObject.AlignmentHorisontal.Right Then
                SetPositionRight(txt)
            ElseIf Columns(_currentNumberColumn).AlignmentH = ColumnObject.AlignmentHorisontal.Center Then
                SetPositionCenter(txt)
            Else
                SetPositionLeft(txt)
            End If
            txt.WriteIn(stream)
            _texts.Add(txt)
        End Sub

        ''' <summary>
        ''' Возвращает позицию для выравнивания текста по горизонтале справа.
        ''' </summary>
        Private Sub SetPositionRight(txt As Text)
            Dim offsetWidth = Columns(_currentNumberColumn).Width - txt.Font.CalculateWidthString(txt.Text, txt.Size) - 4
            txt.Position = _currentPosition + New Point(offsetWidth, GetOffsetHeight(txt))
        End Sub

        ''' <summary>
        ''' Возвращает позицию для выравнивания текста по горизонтале по центру.
        ''' </summary>
        Private Sub SetPositionCenter(txt As Text)
            SetPositionCenter(txt, 0.0)
        End Sub

        ''' <summary>
        ''' Возвращает позицию для выравнивания текста по горизонтале по центру.
        ''' </summary>
        Private Sub SetPositionCenter(txt As Text, offsetLine As Double)
            Dim offsetWidth = (Columns(_currentNumberColumn).Width - txt.Font.CalculateWidthString(txt.Text, txt.Size)) / 2
            txt.Position = _currentPosition + New Point(offsetWidth, GetOffsetHeight(txt) - offsetLine)
        End Sub

        ''' <summary>
        ''' Возвращает позицию для выравнивания текста по горизонтале слева.
        ''' </summary>
        Private Sub SetPositionLeft(txt As Text)
            txt.Position = _currentPosition + New Point(4, GetOffsetHeight(txt))
        End Sub

        ''' <summary>
        ''' Возвращает отступ для выравнивания текста по вертикале по центру.
        ''' </summary>
        Private Function GetOffsetHeight(txt As Text) As Double
            Return (HeightRow - txt.Font.GetCapHeight(txt.Size)) / 2
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            For Each g In _grafs
                g.Dispose()
            Next
            For Each t In _texts
                t.Dispose()
            Next
        End Sub

    End Class

End Namespace

