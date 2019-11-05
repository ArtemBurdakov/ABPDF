Imports System.IO

Namespace PDFObjects

    ''' <summary>
    ''' Представляет прямоугольник, задающийся координатами двух диагональных точек.
    ''' </summary>
    Public Class RectanglesObject
        Inherits PDFObject
        Implements IContent

        Private _content As ArrayObject(Of NumericObject)

        ''' <summary>
        ''' Создаёт прямоугольник, задающийся координатами двух диагональных точек.
        ''' </summary>
        Public Sub New()
            _content = New ArrayObject(Of NumericObject)
            _content.Add(New NumericObject(0))
            _content.Add(New NumericObject(0))
            _content.Add(New NumericObject(0))
            _content.Add(New NumericObject(0))
        End Sub

        ''' <summary>
        ''' Координата x нижней левой точки.
        ''' </summary>
        Public Property LowLeftX As Integer
            Get
                Return _content.Item(0).GetContent()
            End Get
            Set(value As Integer)
                _content.Item(0) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Координата y нижней левой точки.
        ''' </summary>
        Public Property LowLeftY As Integer
            Get
                Return _content.Item(1).GetContent()
            End Get
            Set(value As Integer)
                _content.Item(1) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Координата x верхней правой точки.
        ''' </summary>
        Public Property UpRightX As Integer
            Get
                Return _content.Item(2).GetContent()
            End Get
            Set(value As Integer)
                _content.Item(2) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Координата y верхней правой точки.
        ''' </summary>
        Public Property UpRightY As Integer
            Get
                Return _content.Item(3).GetContent()
            End Get
            Set(value As Integer)
                _content.Item(3) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend Shadows ReadOnly Property Length() As Integer Implements IContent.Length
            Get
                Return _content.Length
            End Get
        End Property

        ''' <summary>
        ''' Возвращает содержимое объекта.
        ''' </summary>
        Public Function GetContent() As Object Implements IContent.GetContent
            Return {LowLeftX, LowLeftY, UpRightX, UpRightY}
        End Function

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return _content.ToString()
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream) Implements IContent.WriteIn
            _content.WriteIn(stream)
        End Sub

    End Class

End Namespace

