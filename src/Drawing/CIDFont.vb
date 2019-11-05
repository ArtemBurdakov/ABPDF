Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures

Namespace Drawing

    ''' <summary>
    ''' Представляет CID шрифт в PDF.
    ''' </summary>
    Public Class CIDFont
        Inherits InderectObject
        Implements IEquatable(Of CIDFont), IDisposable

        Private _dictionary As DictionaryObject
        Private _font As Font
        Private _subtype As NameObject
        Private _cIDToGIDMap As NameObject
        Private _defaultWidth As Double
        Private _cidSystemInfo As CIDSystemInfo
        Private _fontDescriptor As FontDescriptor
        Private _widthGlyfs As ArrayInderect

        Public Shared Operator =(name1 As CIDFont, name2 As CIDFont) As Boolean
            Return name1.Equals(name2)
        End Operator

        Public Shared Operator <>(name1 As CIDFont, name2 As CIDFont) As Boolean
            Return Not name1.Equals(name2)
        End Operator

        ''' <summary>
        ''' Создаёт CID шрифт.
        ''' </summary>
        Public Sub New()
            _dictionary = New DictionaryObject()
            _content = _dictionary
            _dictionary.Item(Names.Type) = Names.Font
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
        ''' Название карты номеров глифов.
        ''' </summary>
        Public Property CIDToGIDMap As NameObject
            Get
                Return _cIDToGIDMap
            End Get
            Set(value As NameObject)
                _cIDToGIDMap = value
                _dictionary.Item(Names.CIDToGIDMap) = value
            End Set
        End Property

        ''' <summary>
        ''' Тип шрифта.
        ''' </summary>
        Public Property Subtype As NameObject
            Get
                Return _subtype
            End Get
            Set(value As NameObject)
                _subtype = value
                _dictionary.Item(Names.Subtype) = value
            End Set
        End Property

        ''' <summary>
        ''' Родительский шрифт.
        ''' </summary>
        Public Property Font As Font
            Get
                Return _font
            End Get
            Friend Set(value As Font)
                _font = value
                _dictionary.Item(Names.BaseFont) = value.BaseFont
            End Set
        End Property

        ''' <summary>
        ''' Ширина глифа по умолчанию.
        ''' </summary>
        Public Property DefaultWidth As Double
            Get
                Return _defaultWidth
            End Get
            Set(value As Double)
                _defaultWidth = value
                _dictionary.Item(Names.DW) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Массив содержащий ширину глифов.
        ''' </summary>
        Public Property WidthGlyfs As ArrayInderect
            Get
                Return _widthGlyfs
            End Get
            Set(value As ArrayInderect)
                _widthGlyfs = value
                _dictionary.Item(Names.W) = value
            End Set
        End Property

        ''' <summary>
        ''' Реестр символов.
        ''' </summary>
        Public Property CIDSystemInfo As CIDSystemInfo
            Get
                Return _cidSystemInfo
            End Get
            Friend Set(value As CIDSystemInfo)
                _cidSystemInfo = value
                _dictionary.Item(Names.CIDSystemInfo) = value
            End Set
        End Property

        ''' <summary>
        ''' Дескриптор шрифта.
        ''' </summary>
        Public Property FontDescriptor As FontDescriptor
            Get
                Return _fontDescriptor
            End Get
            Friend Set(value As FontDescriptor)
                _fontDescriptor = value
                _dictionary.Item(Names.FontDescriptor) = value
            End Set
        End Property

        ''' <summary>
        ''' Добаляет объекты компонента в тело файла.
        ''' </summary>
        Friend Sub AddObjectsIn(fileBody As FileBody)
            If _cidSystemInfo IsNot Nothing Then
                _cidSystemInfo.FileBody = fileBody
                fileBody.Add(_cidSystemInfo)
            End If
            If _widthGlyfs IsNot Nothing Then
                _widthGlyfs.FileBody = fileBody
                fileBody.Add(_widthGlyfs)
            End If
            If _fontDescriptor IsNot Nothing Then
                _fontDescriptor.FileBody = fileBody
                fileBody.Add(_fontDescriptor)
                _fontDescriptor.AddObjectsIn(fileBody)
            End If
        End Sub

        ''' <summary>
        ''' Возвращает высоту плоских заглавных букв.
        ''' </summary>
        ''' <param name="size">Размер шрифта</param>
        Public Function GetCapHeight(size As UShort) As Double
            If _fontDescriptor IsNot Nothing Then
                Return _fontDescriptor.CapHeight / 1000 * size
            End If
            Return 0.0
        End Function

        ''' <summary>
        ''' Возвращает высоту строки.
        ''' </summary>
        ''' <param name="size">Размер шрифта</param>
        Public Function GetLineHeight(size As UShort) As Double
            If _fontDescriptor IsNot Nothing Then
                Return (_fontDescriptor.MaxHeight + 30) / 1000 * size
            End If
            Return 0.0
        End Function

        ''' <summary>
        ''' Определяет равен ли объект, текущему объекту.
        ''' </summary>
        Public Overloads Function Equals(other As CIDFont) As Boolean Implements IEquatable(Of CIDFont).Equals
            Return Subtype = other.Subtype AndAlso Font.BaseFont = other.Font.BaseFont
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            Return Equals(DirectCast(obj, CIDFont))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return (Subtype.ToString & Font.BaseFont.ToString).GetHashCode()
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(_fontDescriptor, IDisposable).Dispose()
        End Sub

    End Class

End Namespace

