Imports System.IO
Imports ABPDF.FileStructures
Imports ABPDF.PDFObjects

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет контент страницы.
    ''' </summary>
    Public Class ContentPageObject
        Inherits InderectObject
        Implements IDisposable

        ''' <summary>
        ''' Создаёт косвенный объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As ContentPageObject
            Return New ContentPageObject(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт контент страницы.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _content = New StreamObject()
            _fileBody = fileBody
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(Stream, IDisposable).Dispose()
        End Sub

        ''' <summary>
        ''' Данные потока.
        ''' </summary>
        Public ReadOnly Property Stream As MemoryStream
            Get
                Return DirectCast(_content, StreamObject).Stream
            End Get
        End Property

    End Class

End Namespace

