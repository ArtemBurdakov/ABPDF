Imports ABPDF.PDFObjects
Imports ABPDF.FileStructures
Imports ABPDF.Drawing

Namespace DocumentStructures

    ''' <summary>
    ''' Представляет справочник шрифтов.
    ''' </summary>
    Public Class FontDictionary
        Inherits DictionaryObject

        Private _fileBody As FileBody

        ''' <summary>
        ''' Создаёт объект привязанный к телу файла.
        ''' </summary>
        ''' <param name="fileBody">Тело файла</param>
        Public Shared Function CreateWithBody(fileBody As FileBody) As FontDictionary
            Return New FontDictionary(fileBody)
        End Function

        ''' <summary>
        ''' Создаёт словарь шрифтов.
        ''' </summary>
        Private Sub New(fileBody As FileBody)
            _fileBody = fileBody
        End Sub

        ''' <summary>
        ''' Добавляет шрифт.
        ''' </summary>
        ''' <param name="font">Шрифт</param>
        Friend Shadows Sub Add(ByRef font As Font)
            Dim searchFont = FindFont(font)
            If searchFont Is Nothing Then
                AddNewFont(font)
            Else
                font = searchFont
            End If
        End Sub

        ''' <summary>
        ''' Ищет шрифт в справочнике и возвращает его, если найдёт.
        ''' </summary>
        Private Function FindFont(font As Font) As Font
            For Each f In Values
                If CType(f, Font) = font Then
                    Return f
                End If
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Добавляет новый шрифт в справочник.
        ''' </summary>
        Private Sub AddNewFont(font As Font)
            font.Name = New NameObject("F" & (Keys.Count + 1).ToString)
            MyBase.Add(font.Name, font)
            font.FileBody = _fileBody
            _fileBody.Add(font)
            font.AddObjectsIn(_fileBody)
        End Sub

    End Class

End Namespace

