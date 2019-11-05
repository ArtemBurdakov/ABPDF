Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures
Imports ABPDF.Drawing

Namespace DocumentStructures

    ''' <summary>
    ''' редставляет справочник внешних объектов.
    ''' </summary>
    Public Class XObjectDictionary
        Inherits DictionaryObject

        Private _fileBody As FileBody

        ''' <summary>
        ''' Создаёт объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As XObjectDictionary
            Return New XObjectDictionary(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт словарь шрифтов.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _fileBody = fileBody
        End Sub

        ''' <summary>
        ''' Добавляет изображение.
        ''' </summary>
        ''' <param name="img">Изображение</param>
        Friend Sub AddImage(ByRef img As Image)
            img.Name = New NameObject("Im" & (Keys.Count + 1).ToString)
            Add(img.Name, img)
            img.FileBody = _fileBody
            _fileBody.Add(img)
        End Sub

    End Class

End Namespace

