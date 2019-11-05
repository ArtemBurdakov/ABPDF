Imports System.IO
Imports System.Text

Namespace PDFObjects

    ''' <summary>
    ''' Представляет объект PDF (косвенный объект и объект-контент: число, строка, словарь, поток и т.д.).
    ''' </summary>
    Public MustInherit Class PDFObject
        Implements IWritable

        Public Overrides Function ToString() As String
            If TypeOf Me Is InderectObject Then
                Return CType(Me, InderectObject).Reference.ToString()
            Else
                Return CType(Me, IContent).ToString()
            End If
        End Function

        ''' <summary>
        ''' Возвращает количество байтов объекта/структуры.
        ''' </summary>
        Friend ReadOnly Property Length() As Integer Implements IWritable.Length
            Get
                If TypeOf Me Is InderectObject Then
                    Return CType(Me, InderectObject).Reference.Length
                Else
                    Return CType(Me, IContent).Length
                End If
            End Get
        End Property

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Sub WriteIn(stream As MemoryStream) Implements IWritable.WriteIn
            If TypeOf Me Is InderectObject Then
                CType(Me, InderectObject).Reference.WriteIn(stream)
            Else
                CType(Me, IContent).WriteIn(stream)
            End If
        End Sub

    End Class

End Namespace

