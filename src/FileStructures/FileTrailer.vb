Imports System.IO
Imports System.Text
Imports ABPDF.PDFObjects
Imports ABPDF.DocumentStructures

Namespace FileStructures

    ''' <summary>
    ''' Трейлер файла PDF.
    ''' </summary>
    Public Class FileTrailer
        Inherits FileStructure

        Private _content As DictionaryObject
        Private _numberObjectStructure As Integer

        ''' <summary>
        ''' Создаёт трейлер файла привязанный к документу.
        ''' </summary>
        ''' <param name="pdf">Документ</param>
        Public Shared Function CreateWithDocument(pdf As PDF) As FileTrailer
            Return New FileTrailer(pdf)
        End Function

        ''' <summary>
        ''' Создаёт трейлер файла PDF.
        ''' </summary>
        ''' <param name="pdf">PDF документ</param>
        Private Sub New(pdf As PDF)
            Me.PDF = pdf
            _numberObjectStructure = pdf.CountObjectStructures
            _content = New DictionaryObject()
            SetPrev()
            SetDocumetInformation()
            SetDocumentCatalog()
            CreateID()
        End Sub

        ''' <summary>
        ''' Задаёт байтовый сдвиг для предыдущей ссылочной таблицы.
        ''' </summary>
        Private Sub SetPrev()
            If PDF.CountObjectStructures > 0 Then
                Prev = PDF.GetFileTrailer(_numberObjectStructure - 1).StartXRef
            End If
        End Sub

        ''' <summary>
        ''' Задаёт справочник информации о докменте.
        ''' </summary>
        Private Sub SetDocumetInformation()
            Info = PDF.Information
        End Sub

        ''' <summary>
        ''' Задаёт каталог документа.
        ''' </summary>
        Private Sub SetDocumentCatalog()
            Root = PDF.Catalog
            PDF.Catalog.Pages = PDF.PageTree
        End Sub

        ''' <summary>
        ''' Создаёт индефикатор файла.
        ''' </summary>
        Private Sub CreateID()
            Dim str = New StringObject(Guid.NewGuid().ToString("N")) With {.Hexadecimal = True}
            ID = New ArrayObject(Of StringObject) From {str, str}
            ID.WrapElements = True
        End Sub

        ''' <summary>
        ''' Количество записей в ссылочной таблице.
        ''' </summary>
        Public Property Size As Integer
            Get
                Return CType(_content.Item(Names.Size), IContent).GetContent()
            End Get
            Friend Set(value As Integer)
                _content.Item(Names.Size) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Байтовый сдвиг для предыдущей ссылочной таблицы.
        ''' </summary>
        Public Property Prev As Integer
            Get
                Return CType(_content.Item(Names.Prev), IContent).GetContent()
            End Get
            Friend Set(value As Integer)
                _content.Item(Names.Prev) = New NumericObject(value)
            End Set
        End Property

        ''' <summary>
        ''' Каталог документа.
        ''' </summary>
        Public Property Root As DocumentCatalog
            Get
                Return _content.Item(Names.Root)
            End Get
            Friend Set(value As DocumentCatalog)
                _content.Item(Names.Root) = value
            End Set
        End Property

        ''' <summary>
        ''' Ссылка на объект шифрования.
        ''' </summary>
        Public Property Encrypt As InderectObject
            Get
                Return _content.Item(Names.Encrypt)
            End Get
            Friend Set(value As InderectObject)
                _content.Item(Names.Encrypt) = value
            End Set
        End Property

        ''' <summary>
        ''' Ссылка на объект с информацией о документе.
        ''' </summary>
        Public Property Info As DocumentInformation
            Get
                Return _content.Item(Names.Info)
            End Get
            Friend Set(value As DocumentInformation)
                _content.Item(Names.Info) = value
            End Set
        End Property

        ''' <summary>
        ''' Идентификатор файла.
        ''' </summary>
        Public Property ID As ArrayObject(Of StringObject)
            Get
                Return _content.Item(Names.ID)
            End Get
            Friend Set(value As ArrayObject(Of StringObject))
                _content.Item(Names.ID) = value
            End Set
        End Property

        ''' <summary>
        ''' Возвращает байтовы сдвиг от начала файла до последней ссылочной таблицы.
        ''' </summary>
        Public ReadOnly Property StartXRef As Integer
            Get
                Return PDF.CalculateOffset(_numberObjectStructure, PDF.GetFileBody(_numberObjectStructure).CountObjects + 1)
            End Get
        End Property

        ''' <summary>
        ''' Возвращает количество байтов структуры.
        ''' </summary>
        Friend Overrides ReadOnly Property Length() As Integer
            Get
                SetSize()
                Return 25 + _content.Length + StartXRef.ToString.Length
            End Get
        End Property

        ''' <summary>
        ''' Возвращает строковое представление структуры.
        ''' </summary>
        Public Overrides Function ToString() As String
            SetSize()
            Return "trailer" & vbLf & _content.ToString() & vbLf & "startxref" & vbLf & StartXRef.ToString & vbLf & "%%EOF"
        End Function

        ''' <summary>
        ''' Записывает объект в MemoryStream.
        ''' </summary>
        Friend Overrides Sub WriteIn(stream As MemoryStream)
            SetSize()
            stream.Write(Encoding.Default.GetBytes("trailer" & vbLf), 0, 8)
            _content.WriteIn(stream)
            stream.Write(Encoding.Default.GetBytes(vbLf & "startxref" & vbLf), 0, 11)
            stream.Write(Encoding.Default.GetBytes(StartXRef.ToString), 0, StartXRef.ToString.Length)
            stream.Write(Encoding.Default.GetBytes(vbLf & "%%EOF"), 0, 6)
        End Sub

        ''' <summary>
        ''' Задаёт кол-во записей сыллочной таблицы в справочник трейлера.
        ''' </summary>
        Private Sub SetSize()
            Size = PDF.GetCrossReferenceTable(_numberObjectStructure).CountEntryes
        End Sub

    End Class

End Namespace

