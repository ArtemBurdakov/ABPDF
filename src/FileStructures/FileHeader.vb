Imports System.IO
Imports System.Text

Namespace FileStructures

    ''' <summary>
    ''' Загаловок файла PDF.
    ''' </summary>
    Public Class FileHeader
        Inherits FileStructure

        Private _content As String

        ''' <summary>
        ''' Создаёт заголовок файла привязанный к документу.
        ''' </summary>
        ''' <param name="pdf">Документ</param>
        Public Shared Function CreateWithDocument(pdf As PDF) As FileHeader
            Return New FileHeader(pdf)
        End Function

        ''' <summary>
        ''' Создаёт заголовок файла PDF.
        ''' </summary>
        ''' <param name="pdf">PDF документ</param>
        Private Sub New(pdf As PDF)
            Me.PDF = pdf
            SetVersion(pdf.Version)
            BinaryData = True
        End Sub

        ''' <summary>
        ''' задаёт версию PDF.
        ''' </summary>
        ''' <param name="version">Версия PDF</param>
        Private Sub SetVersion(version As Version)
            Dim dash = Encoding.Default.GetString({&H2D})
            Select Case version
                Case 0
                    _content = "%PDF" & dash & "1.0"
                Case 1
                    _content = "%PDF" & dash & "1.1"
                Case 2
                    _content = "%PDF" & dash & "1.2"
                Case 3
                    _content = "%PDF" & dash & "1.3"
                Case 4
                    _content = "%PDF" & dash & "1.4"
                Case 5
                    _content = "%PDF" & dash & "1.5"
                Case 6
                    _content = "%PDF" & dash & "1.6"
                Case 7
                    _content = "%PDF" & dash & "1.7"
                Case Else
                    Throw New Exception("Такой версии PDF не существует.")
            End Select
        End Sub

        ''' <summary>
        ''' Признак содржания двоичных данных в файле.
        ''' </summary>
        Public Property BinaryData As Boolean

        ''' <summary>
        ''' Возвращает количество байтов структуры.
        ''' </summary>
        Friend Overrides ReadOnly Property Length() As Integer
            Get
                Return _content.Length + 1 + If(BinaryData, 7, 0)
            End Get
        End Property

        ''' <summary>
        ''' Возвращает строковое представление структуры.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return _content & vbLf & If(BinaryData, "%туфхц" & vbLf, String.Empty)
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Overrides Sub WriteIn(stream As MemoryStream)
            stream.Write(Encoding.Default.GetBytes(_content), 0, _content.Length)
            stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            If BinaryData Then
                stream.Write(Encoding.Default.GetBytes("%туфхц"), 0, 6)
                stream.Write(Encoding.Default.GetBytes(vbLf), 0, 1)
            End If
        End Sub

    End Class

End Namespace

