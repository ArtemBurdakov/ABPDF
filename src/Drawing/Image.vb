Imports System.IO
Imports System.Text
Imports sysDraw = System.Drawing
Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures
Imports ABPDF.DocumentStructures

Namespace Drawing

    ''' <summary>
    ''' Представляет изображения для отображения на странице PDF.
    ''' </summary>
    Public Class Image
        Inherits InderectObject
        Implements IDrawable

        Private _stream As StreamObject
        Private _width As NumericObject
        Private _height As NumericObject

        ''' <summary>
        ''' Создаёт изображение для отображения на странице PDF.
        ''' </summary>
        Sub New(stream As MemoryStream, imgType As ImageType)
            _content = New StreamObject()
            _stream = _content
            Dim img = sysDraw.Bitmap.FromStream(stream)
            stream.WriteTo(_stream.Stream)
            _stream.AddDictionary(Names.Type, Names.XObject)
            _stream.AddDictionary(Names.Subtype, Names.Image)
            _stream.Filter = New ArrayObject(Of NameObject)() From {DefineFilter(imgType)}
            _stream.Filter.FirstAsArray = False
            _stream.AddDictionary(Names.Width, New NumericObject(img.Width))
            _stream.AddDictionary(Names.Height, New NumericObject(img.Height))
            _stream.AddDictionary(Names.ColorSpace, DefineColorSpace(img))
            _stream.AddDictionary(Names.BitsPerComponent, DefinePixelFormatSize(img, imgType))
            ScaleBy(1)
        End Sub

        ''' <summary>
        ''' Тело файла.
        ''' </summary>
        Public Shadows Property FileBody As FileBody
            Get
                Return _fileBody
            End Get
            Friend Set(value As FileBody)
                _fileBody = value
            End Set
        End Property

        ''' <summary>
        ''' Определяет пространство цвета у изображения.
        ''' </summary>
        Private Function DefineColorSpace(img As sysDraw.Image) As NameObject
            Dim colorSpace As NameObject
            If img.PixelFormat = sysDraw.Imaging.PixelFormat.Format16bppGrayScale Then
                colorSpace = Names.DeviceGray
            Else
                colorSpace = Names.DeviceRGB
            End If
            Return colorSpace
        End Function

        ''' <summary>
        ''' Определяет глубину цвета.
        ''' </summary>
        Private Function DefinePixelFormatSize(img As sysDraw.Image, imgType As ImageType) As NumericObject
            Dim result As NumericObject
            If imgType = ImageType.JPEG Then
                result = New NumericObject(8)
            Else
                result = New NumericObject(sysDraw.Bitmap.GetPixelFormatSize(img.PixelFormat))
            End If
            Return result
        End Function

        ''' <summary>
        ''' Определяет фильтр декодирования.
        ''' </summary>
        Private Function DefineFilter(imgType As ImageType) As NameObject
            Dim filter As NameObject
            If imgType = ImageType.JPEG Then
                filter = Names.DCTDecode
            ElseIf imgType = ImageType.PNG Then
                filter = Names.FlateDecode
            Else
                Throw New Exception("Этот тип изображения не определён.")
            End If
            Return filter
        End Function

        ''' <summary>
        '''  Расположение изображения на странице (координаты нижнего левого угла изображения).
        ''' </summary>
        Public Property Position() As Point

        ''' <summary>
        ''' Имя внешнего объекта в справочнике ресурсов.
        ''' </summary>
        Public Property Name As NameObject
            Get
                Return _stream.ItemDictionary(Names.Name)
            End Get
            Friend Set(value As NameObject)
                _stream.ItemDictionary(Names.Name) = value
            End Set
        End Property

        ''' <summary>
        ''' Масштабирует изображение.
        ''' </summary>
        Public Sub ScaleBy(k As Double)
            Dim width As Double = CType(_stream.ItemDictionary(Names.Width), IContent).GetContent()
            Dim height As Double = CType(_stream.ItemDictionary(Names.Height), IContent).GetContent()
            _width = New NumericObject(width * k)
            _height = New NumericObject(height * k)
        End Sub

        ''' <summary>
        ''' Рисуент компонент в контенте страницы.
        ''' </summary>
        Friend Sub DrawTo(content As ContentPageObject) Implements IDrawable.DrawTo
            Dim str = "q" & vbLf & _width.ToString() & " 0 0 " & _height.ToString() & " " &
                Position.ToString & " cm" & vbLf & Name.ToString() & " Do" & vbLf & "Q" & vbLf
            content.Stream.Write(Encoding.Default.GetBytes(str), 0, str.Length)
        End Sub

        ''' <summary>
        ''' Добаляет объекты компонента в справочник ресурсов.
        ''' </summary>
        Friend Sub AddObjectsIn(resources As ResourceDictionary) Implements IDrawable.AddObjectsIn
            resources.XObject.AddImage(Me)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(_stream, IDisposable).Dispose()
        End Sub
    End Class

End Namespace

