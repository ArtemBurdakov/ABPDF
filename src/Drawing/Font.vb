Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures

Namespace Drawing

    ''' <summary>
    ''' Представляет шрифт в PDF.
    ''' </summary>
    Public Class Font
        Inherits InderectObject
        Implements IEquatable(Of Font), IDisposable

        Private _dictionary As DictionaryObject
        Private _subtype As NameObject
        Private _name As NameObject
        Private _baseFont As NameObject
        Private _encoding As NameObject
        Private _descendantFonts As ArrayInderect
        Private _descendantFont As CIDFont
        Private _fontDescriptor As FontDescriptor
        Private _cMap As CMap

        Public Shared Operator =(name1 As Font, name2 As Font) As Boolean
            Return name1.Equals(name2)
        End Operator

        Public Shared Operator <>(name1 As Font, name2 As Font) As Boolean
            Return Not name1.Equals(name2)
        End Operator

        ''' <summary>
        ''' Создаёт шрифт.
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
            Set(value As FileBody)
                _fileBody = value
            End Set
        End Property

        ''' <summary>
        ''' Тип шрифта.
        ''' </summary>
        Public Property Subtype As NameObject
            Get
                Return _subtype
            End Get
            Friend Set(value As NameObject)
                _subtype = value
                _dictionary.Item(Names.Subtype) = value
            End Set
        End Property

        ''' <summary>
        ''' Имя шрифта в справочнике ресурсов.
        ''' </summary>
        Public Property Name As NameObject
            Get
                Return _name
            End Get
            Friend Set(value As NameObject)
                _name = value
                _dictionary.Item(Names.Name) = value
            End Set
        End Property

        ''' <summary>
        ''' Имя шрифта.
        ''' </summary>
        Public Property BaseFont As NameObject
            Get
                Return _baseFont
            End Get
            Set(value As NameObject)
                _baseFont = value
                _dictionary.Item(Names.BaseFont) = value
            End Set
        End Property

        ''' <summary>
        ''' Кодировка.
        ''' </summary>
        Public Property Encoding As NameObject
            Get
                Return _encoding
            End Get
            Set(value As NameObject)
                _encoding = value
                _dictionary.Item(Names.Encoding) = value
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
        ''' Поток, содержащий карту соответствия символов коду Unicode.
        ''' </summary>
        Public Property ToUnicode As CMap
            Get
                Return _cMap
            End Get
            Set(value As CMap)
                _cMap = value
                _dictionary.Item(Names.ToUnicode) = value
            End Set
        End Property

        ''' <summary>
        ''' Задаёт шрифт потомок.
        ''' </summary>
        ''' <param name="font">Шрифт потомок</param>
        Public Sub SetDescendantFont(font As CIDFont)
            _descendantFonts = New ArrayInderect()
            _descendantFont = font
            _descendantFont.Font = Me
            _descendantFonts.ContentObject.Add(_descendantFont)
            _dictionary.Add(Names.DescendantFonts, _descendantFonts)
        End Sub

        ''' <summary>
        ''' Добаляет объекты компонента в тело файла.
        ''' </summary>
        Friend Sub AddObjectsIn(fileBody As FileBody)
            If _descendantFonts IsNot Nothing Then
                AddDescendantFontsIn(fileBody)
            End If
            If _cMap IsNot Nothing Then
                AddCMap(fileBody)
            End If
            If _fontDescriptor IsNot Nothing Then
                AddDescriptor(fileBody)
            End If
        End Sub

        ''' <summary>
        ''' Добаляет массив и шрифт потомок в тело файла.
        ''' </summary>
        Private Sub AddDescendantFontsIn(fileBody As FileBody)
            _descendantFonts.FileBody = fileBody
            _descendantFont.FileBody = fileBody
            fileBody.Add(_descendantFonts)
            fileBody.Add(_descendantFont)
            _descendantFont.AddObjectsIn(fileBody)
        End Sub

        ''' <summary>
        ''' Добаляет карту соответствия символов кодам Unicode.
        ''' </summary>
        Private Sub AddCMap(fileBody As FileBody)
            ToUnicode.FileBody = fileBody
            fileBody.Add(ToUnicode)
        End Sub

        ''' <summary>
        ''' Добаляет дескриптор шрифта в тело файла.
        ''' </summary>
        Private Sub AddDescriptor(fileBody As FileBody)
            _fontDescriptor.FileBody = fileBody
            fileBody.Add(_fontDescriptor)
            _fontDescriptor.AddObjectsIn(fileBody)
        End Sub

        ''' <summary>
        ''' Определяет равен ли объект, текущему объекту.
        ''' </summary>
        Public Overloads Function Equals(other As Font) As Boolean Implements IEquatable(Of Font).Equals
            Return Subtype = other.Subtype AndAlso BaseFont = other.BaseFont
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            Return Equals(DirectCast(obj, Font))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return (Subtype.ToString & BaseFont.ToString).GetHashCode()
        End Function

        ''' <summary>
        ''' Вычисляет длину строки.
        ''' </summary>
        ''' <param name="str">Строка, которой определяется длина</param>
        ''' <param name="size">Размер шрифта</param>
        Public Function CalculateWidthString(str As String, size As UShort) As Double
            Dim widthStr = 0.0
            If _descendantFont IsNot Nothing AndAlso ToUnicode IsNot Nothing Then
                For Each c In str
                    Dim cBytes = System.Text.Encoding.Unicode.GetBytes(c)
                    Dim unicode = (CType(cBytes(1), UShort) << 8) Or cBytes(0)
                    Dim findBFChars = ToUnicode.BFChars.Where(Function(x) x.Unicode = unicode)
                    If findBFChars.Count > 0 Then
                        widthStr += findBFChars.First.Width
                    End If
                Next
            End If
            Return (widthStr / 1000) * size
        End Function

        ''' <summary>
        ''' Возвращает высоту плоских заглавных букв.
        ''' </summary>
        ''' <param name="size">Размер шрифта</param>
        Public Function GetCapHeight(size As UShort) As Double
            If _fontDescriptor IsNot Nothing Then
                Return _fontDescriptor.CapHeight / 1000 * size
            Else
                If _descendantFont IsNot Nothing Then
                    Return _descendantFont.GetCapHeight(size)
                End If
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
            Else
                If _descendantFont IsNot Nothing Then
                    Return _descendantFont.GetLineHeight(size)
                End If
            End If
            Return 0.0
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            If _descendantFont IsNot Nothing Then
                DirectCast(_descendantFont, IDisposable).Dispose()
            End If
            If _fontDescriptor IsNot Nothing Then
                DirectCast(_fontDescriptor, IDisposable).Dispose()
            End If
            If _cMap IsNot Nothing Then
                DirectCast(_cMap, IDisposable).Dispose()
            End If
        End Sub
    End Class

End Namespace

