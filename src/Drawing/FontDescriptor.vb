Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures

Namespace Drawing

    ''' <summary>
    ''' Определяет метрики и другие атрибуты простого шрифта или CID шрифта. 
    ''' </summary>
    Public Class FontDescriptor
        Inherits InderectObject
        Implements IDisposable

        Private _dictionary As DictionaryObject
        Private _fontFile2 As FontStream
        Private _capHeight As Double

        ''' <summary>
        ''' Создаёт дескриптор шрифта.
        ''' </summary>
        Public Sub New()
            _dictionary = New DictionaryObject
            _content = _dictionary
            Type = Names.FontDescriptor
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
        ''' Тип объекта документа.
        ''' </summary>
        Public Property Type As NameObject
            Get
                Return _dictionary.Item(Names.Type)
            End Get
            Protected Set(value As NameObject)
                _dictionary.Item(Names.Type) = value
            End Set
        End Property

        ''' <summary>
        ''' PostScript имя шрифта.
        ''' </summary>
        Public Property FontName As NameObject
            Get
                Return _dictionary.Item(Names.FontName)
            End Get
            Friend Set(value As NameObject)
                _dictionary.Item(Names.FontName) = value
            End Set
        End Property

        ''' <summary>
        ''' Набор флагов, определяющих различные характеристики шрифта.
        ''' </summary>
        Public Property Flags As NumericObject
            Get
                Return _dictionary.Item(Names.Flags)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.Flags) = value
            End Set
        End Property

        ''' <summary>
        ''' Угол наклона шрифта, выраженный в градусах против часовой стрелки.
        ''' </summary>
        Public Property ItalicAngle As NumericObject
            Get
                Return _dictionary.Item(Names.ItalicAngle)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.ItalicAngle) = value
            End Set
        End Property

        ''' <summary>
        ''' Максимальная высота над базовой линией, достигаемая глифами в этом шрифте.
        ''' </summary>
        Public Property Ascent As NumericObject
            Get
                Return _dictionary.Item(Names.Ascent)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.Ascent) = value
            End Set
        End Property

        ''' <summary>
        ''' Максимальная глубина ниже базовой линии, достигнутая глифами в этом шрифте.
        ''' </summary>
        Public Property Descent As NumericObject
            Get
                Return _dictionary.Item(Names.Descent)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.Descent) = value
            End Set
        End Property

        ''' <summary>
        ''' Вертикальная координата верхней части плоских заглавных букв, измеренная от базовой линии.
        ''' </summary>
        Public Property CapHeight As Double
            Get
                Return _capHeight
            End Get
            Friend Set(value As Double)
                _capHeight = value
                _dictionary.Item(Names.CapHeight) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Средняя ширина глифов.
        ''' </summary>
        Public Property AvgWidth As NumericObject
            Get
                Return _dictionary.Item(Names.AvgWidth)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.AvgWidth) = value
            End Set
        End Property

        ''' <summary>
        ''' Максимальная ширина глифов.
        ''' </summary>
        Public Property MaxWidth As NumericObject
            Get
                Return _dictionary.Item(Names.MaxWidth)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.MaxWidth) = value
            End Set
        End Property

        ''' <summary>
        ''' Компонент веса (толщины) шрифта.
        ''' </summary>
        Public Property FontWeight As NumericObject
            Get
                Return _dictionary.Item(Names.FontWeight)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.FontWeight) = value
            End Set
        End Property

        ''' <summary>
        ''' Вертикальная координата вершины плоских не восходящих строчных букв (например, буквы x), 
        ''' измеренная от базовой линии.
        ''' </summary>
        Public Property XHeight As NumericObject
            Get
                Return _dictionary.Item(Names.XHeight)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.XHeight) = value
            End Set
        End Property

        ''' <summary>
        ''' Интервал между базовыми линиями последовательных строк текста.
        ''' </summary>
        Public Property Leading As NumericObject
            Get
                Return _dictionary.Item(Names.Leading)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.Leading) = value
            End Set
        End Property

        ''' <summary>
        ''' Толщина, измеренная по горизонтали, доминирующих вертикальных основ глифов в шрифте.
        ''' </summary>
        Public Property StemV As NumericObject
            Get
                Return _dictionary.Item(Names.StemV)
            End Get
            Friend Set(value As NumericObject)
                _dictionary.Item(Names.StemV) = value
            End Set
        End Property

        ''' <summary>
        ''' Прямоугольник, выраженный в системе координат глифа, 
        ''' который должен указывать ограничивающий прямоугольник шрифта.
        ''' </summary>
        Public Property FontBBox As RectanglesObject
            Get
                Return _dictionary.Item(Names.FontBBox)
            End Get
            Friend Set(value As RectanglesObject)
                _dictionary.Item(Names.FontBBox) = value
            End Set
        End Property

        ''' <summary>
        ''' Файл TrueType шрифта.
        ''' </summary>
        Public Property FontFile2 As FontStream
            Get
                Return _fontFile2
            End Get
            Friend Set(value As FontStream)
                _fontFile2 = value
                _dictionary.Item(Names.FontFile2) = value
            End Set
        End Property

        ''' <summary>
        ''' Добаляет объекты компонента в тело файла.
        ''' </summary>
        Friend Sub AddObjectsIn(fileBody As FileBody)
            If FontFile2 IsNot Nothing Then
                FontFile2.FileBody = fileBody
                fileBody.Add(FontFile2)
            End If
        End Sub

        ''' <summary>
        ''' Максимальная высота глифа в шрифте.
        ''' </summary>
        Public ReadOnly Property MaxHeight() As Double
            Get
                Return CType(Ascent.GetContent, Double) - CType(Descent.GetContent, Double)
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            If _fontFile2 IsNot Nothing Then
                DirectCast(_fontFile2, IDisposable).Dispose()
            End If
        End Sub

    End Class

End Namespace

