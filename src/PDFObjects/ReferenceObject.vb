Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет ссылку на косвенный объект PDF.
    ''' </summary>
    Public Class ReferenceObject
        Implements IWritable

        Private _objectNumber As Integer
        Private _generationNumber As Integer
        Private _used As Boolean
        Private _inderectObject As InderectObject

        ''' <summary>
        ''' Создаёт ссылку привязанную к косвенныму объекту.
        ''' </summary>
        ''' <param name="inderectObject">Косвенный объект</param>
        Public Shared Function CreateWithObject(inderectObject As InderectObject) As ReferenceObject
            Return New ReferenceObject(inderectObject)
        End Function

        ''' <summary>
        ''' Создаёт ссылку.
        ''' </summary>
        Public Sub New()
            _objectNumber = 0
            _generationNumber = 65535
            _used = False
        End Sub

        Private Sub New(inderectObject As InderectObject)
            _objectNumber = 0
            _generationNumber = 0
            _used = True
            _inderectObject = inderectObject
        End Sub

        ''' <summary>
        ''' Номер объекта.
        ''' </summary>
        Public Property ObjectNumber As Integer
            Get
                Return _objectNumber
            End Get
            Friend Set(value As Integer)
                _objectNumber = value
            End Set
        End Property

        ''' <summary>
        ''' Номер поколения.
        ''' </summary>
        Public Property GenerationNumber As Integer
            Get
                Return _generationNumber
            End Get
            Friend Set(value As Integer)
                _generationNumber = value
            End Set
        End Property

        ''' <summary>
        ''' Признак использования ссылки объектом.
        ''' </summary>
        Public Property Used As Boolean
            Get
                Return _used
            End Get
            Friend Set(value As Boolean)
                _used = value
            End Set
        End Property

        ''' <summary>
        ''' Косвенный объект, на который ведёт ссылка.
        ''' </summary>
        Public Property InderectObject As InderectObject
            Get
                Return _inderectObject
            End Get
            Friend Set(value As InderectObject)
                _inderectObject = value
            End Set
        End Property

        ''' <summary>
        '''  Возвращает ссылку на объект для ссылочной таблицы.
        ''' </summary>
        Friend Function GetXRef() As String
            Return GetOffset.ToString.PadLeft(10, "0") & " " & _generationNumber.ToString.PadLeft(5, "0") & If(_used, " n ", " f ")
        End Function

        ''' <summary>
        ''' Возвращает байтовый сдвиг от начала файла.
        ''' </summary>
        Friend Function GetOffset() As Integer
            If _inderectObject Is Nothing Then
                Return 0
            Else
                Return _inderectObject.FileBody.PDF.CalculateOffset(GenerationNumber, ObjectNumber)
            End If
        End Function

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Friend ReadOnly Property Length() As Integer Implements IWritable.Length
            Get
                Return _objectNumber.ToString.Length + _generationNumber.ToString.Length + 3
            End Get
        End Property

        ''' <summary>
        ''' Возвращает строковое представление объекта.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return _objectNumber.ToString & " " & _generationNumber.ToString & " R"
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Sub WriteIn(stream As MemoryStream) Implements IWritable.WriteIn
            stream.Write(Encoding.Default.GetBytes(ToString()), 0, ToString().Length)
        End Sub

    End Class

End Namespace

