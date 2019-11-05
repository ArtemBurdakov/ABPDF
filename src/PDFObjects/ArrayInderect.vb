Imports ABPDF.FileStructures

Namespace PDFObjects

    ''' <summary>
    ''' Представляет косвенный массив.
    ''' </summary>
    Public Class ArrayInderect
        Inherits InderectObject

        ''' <summary>
        ''' Создаёт косвенный объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As ArrayInderect
            Return New ArrayInderect(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт косвенный массив.
        ''' </summary>
        Public Sub New()
            _content = New ArrayObject
        End Sub

        ''' <summary>
        ''' Создаёт косвенный массив.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _content = New ArrayObject
            _fileBody = fileBody
        End Sub

        ''' <summary>
        ''' Обёрнутый объект.
        ''' </summary>
        Public Shadows Property ContentObject As ArrayObject
            Get
                Return DirectCast(_content, ArrayObject)
            End Get
            Friend Set(value As ArrayObject)
                _content = value
            End Set
        End Property

        ''' <summary>
        ''' Тело файла, к которому привязан объект.
        ''' </summary>
        Public Shadows Property FileBody() As FileBody
            Get
                Return _fileBody
            End Get
            Friend Set(value As FileBody)
                _fileBody = value
            End Set
        End Property

    End Class

End Namespace

