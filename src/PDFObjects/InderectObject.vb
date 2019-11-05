Imports System.IO
Imports System.Text
Imports ABPDF.FileStructures

Namespace PDFObjects

    ''' <summary>
    ''' Представляет косвенный объект PDF.
    ''' </summary>
    Public MustInherit Class InderectObject
        Inherits PDFObject

        Private _reference As ReferenceObject
        Protected _content As IContent
        Protected _fileBody As FileBody

        ''' <summary>
        ''' Создаёт косвенный объект.
        ''' </summary>
        Public Sub New()
            _reference = ReferenceObject.CreateWithObject(Me)
        End Sub

        ''' <summary>
        ''' Тело файла, к которому привязан объект.
        ''' </summary>
        Public ReadOnly Property FileBody() As FileBody
            Get
                Return _fileBody
            End Get
        End Property

        ''' <summary>
        ''' Обёрнутый объект.
        ''' </summary>
        Public ReadOnly Property ContentObject() As IContent
            Get
                Return _content
            End Get
        End Property

        ''' <summary>
        ''' Ссылка на объект.
        ''' </summary>
        Public ReadOnly Property Reference As ReferenceObject
            Get
                Return _reference
            End Get
        End Property

        ''' <summary>
        ''' Возвращает количество байтов объекта.
        ''' </summary>
        Public Shadows ReadOnly Property Length() As Integer
            Get
                Return 13 + _reference.ObjectNumber.ToString.Length + _reference.GenerationNumber.ToString.Length + _content.Length
            End Get
        End Property

        ''' <summary>
        '''  Возвращает строковое представление объекта.
        ''' </summary>
        Public Shadows Function ToString() As String
            Return _reference.ObjectNumber.ToString & " " & _reference.GenerationNumber.ToString & " obj" & vbLf & _content.ToString() & vbLf & "endobj"
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Shadows Sub WriteIn(stream As MemoryStream)
            stream.Write(Encoding.Default.GetBytes(_reference.ObjectNumber.ToString), 0, _reference.ObjectNumber.ToString.Length)
            stream.Write(Encoding.Default.GetBytes(" "), 0, 1)
            stream.Write(Encoding.Default.GetBytes(_reference.GenerationNumber.ToString), 0, _reference.GenerationNumber.ToString.Length)
            stream.Write(Encoding.Default.GetBytes(" obj" & vbLf), 0, 5)
            _content.WriteIn(stream)
            stream.Write(Encoding.Default.GetBytes(vbLf & "endobj"), 0, 7)
        End Sub

    End Class

End Namespace

