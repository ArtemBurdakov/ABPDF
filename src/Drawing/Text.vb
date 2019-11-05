Imports System.IO
Imports System.Text
Imports ABPDF.PDFObjects
Imports ABPDF.DocumentStructures

Namespace Drawing

    ''' <summary>
    ''' Представляет объект для рисования текста.
    ''' </summary>
    Public Class Text
        Implements IDrawable, IDisposable

        Private _font As Font
        Private _size As UShort

        ''' <summary>
        ''' Создаёт текст с шрифтом.
        ''' </summary>
        ''' <param name="font">Шрифт</param>
        ''' <param name="size">Размер шрифта</param>
        Public Shared Function CreateWithFont(font As Font, size As UShort) As Text
            Return New Text(font, size)
        End Function

        ''' <summary>
        ''' Создаёт объект для рисования графики.
        ''' </summary>
        Private Sub New(font As Font, size As UShort)
            _font = font
            _size = size
        End Sub

        ''' <summary>
        ''' Отображаемый текст.
        ''' </summary>
        Public Property Text() As String

        ''' <summary>
        '''  Расположение текста на странице (координаты нижнего левого угла блока текста).
        ''' </summary>
        Public Property Position() As Point

        ''' <summary>
        ''' Размер шрифта.
        ''' </summary>
        Public ReadOnly Property Size() As UShort
            Get
                Return _size
            End Get
        End Property

        ''' <summary>
        ''' Шрифт.
        ''' </summary>
        Public ReadOnly Property Font() As Font
            Get
                Return _font
            End Get
        End Property

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
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Sub WriteIn(stream As MemoryStream)
            Dim str = New StringObject(Font.ToUnicode.Convert(Text)) With {.Hexadecimal = True}
            stream.Write(Encoding.Default.GetBytes("BT" & vbLf), 0, 3)
            If Font.Reference.ObjectNumber > 0 Then 'Если шрифт добавлен в тело файла.
                Font.Name.WriteIn(stream)
            End If
            stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
            stream.Write(Encoding.Default.GetBytes(Size.ToString()), 0, Size.ToString().Length)
            stream.Write(Encoding.Default.GetBytes(" Tf" & vbLf), 0, 4)
            Position.WriteIn(stream)
            stream.Write(Encoding.Default.GetBytes(" Td" & vbLf), 0, 4)
            str.WriteIn(stream)
            stream.Write(Encoding.Default.GetBytes(" Tj" & vbLf), 0, 4)
            stream.Write(Encoding.Default.GetBytes("ET" & vbLf), 0, 3)
        End Sub

        ''' <summary>
        ''' Добаляет объекты компонента в справочник ресурсов.
        ''' </summary>
        Friend Sub AddObjectsIn(resources As ResourceDictionary) Implements IDrawable.AddObjectsIn
            resources.Font.Add(Font)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(_font, IDisposable).Dispose()
        End Sub

    End Class

End Namespace

