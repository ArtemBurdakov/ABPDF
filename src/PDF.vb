Imports System.IO
Imports System.Text
Imports ABPDF.DocumentStructures
Imports ABPDF.FileStructures
Imports ABPDF.Drawing

#Region "Enums"

''' <summary>
''' Перечесляет версии PDF.
''' </summary>
Public Enum Version
    pdf_1_0 = 0
    pdf_1_1 = 1
    pdf_1_2 = 2
    pdf_1_3 = 3
    pdf_1_4 = 4
    pdf_1_5 = 5
    pdf_1_6 = 6
    pdf_1_7 = 7
End Enum

''' <summary>
''' Тип изображения.
''' </summary>
Public Enum ImageType
    JPEG = 0
    PNG = 1
End Enum

#End Region

''' <summary>
''' Представляет документ формата PDF.
''' </summary>
Public Class PDF
    Implements IDisposable

    Private _version As Version
    Private _header As FileHeader
    Private _objectStructures As List(Of Tuple(Of FileBody, CrossReferenceTable, FileTrailer))
    Private _documentInformation As DocumentInformation
    Private _documentCatalog As DocumentCatalog
    Private _pageTree As DocumentPageTree
    Private _stream As MemoryStream

    ''' <summary>
    ''' Создаёт документ формата PDF версии 1.7.
    ''' </summary>
    Public Sub New()
        Me.New(Version.pdf_1_7)
    End Sub

    ''' <summary>
    ''' Создаёт документ формата PDF.
    ''' </summary>
    ''' <param name="version">Версия PDF</param>
    Public Sub New(version As Version)
        _stream = New MemoryStream()
        _version = version
        _header = FileHeader.CreateWithDocument(Me)
        _objectStructures = New List(Of Tuple(Of FileBody, CrossReferenceTable, FileTrailer))
        AddObjectStructure(CreateBody(), CrossReferenceTable.CreateWithDocument(Me), FileTrailer.CreateWithDocument(Me))
    End Sub

    ''' <summary>
    ''' Добавляет объектную структуру.
    ''' </summary>
    ''' <param name="fileBody">Тело файла</param>
    ''' <param name="refTable">Ссылочная таблица</param>
    Private Sub AddObjectStructure(fileBody As FileBody, refTable As CrossReferenceTable, trailer As FileTrailer)
        _objectStructures.Add(New Tuple(Of FileBody, CrossReferenceTable, FileTrailer)(fileBody, refTable, trailer))
    End Sub

    ''' <summary>
    ''' Создаёт тело файла.
    ''' </summary>
    Private Function CreateBody() As FileBody
        Dim body = FileBody.CreateWithDocument(Me)
        _documentInformation = DocumentInformation.CreateWithBody(body)
        _documentCatalog = DocumentCatalog.CreateWithBody(body)
        _pageTree = DocumentPageTree.CreateWithBody(body)
        body.Add(_documentInformation)
        body.Add(_documentCatalog)
        body.Add(_pageTree)
        Return body
    End Function

    ''' <summary>
    ''' Кол-во объектных структур (тело, ссылочная таблица, трейлер) в документе.
    ''' </summary>
    Public ReadOnly Property CountObjectStructures As Integer
        Get
            Return _objectStructures.Count
        End Get
    End Property

    ''' <summary>
    ''' Возвращает заголовок файла.
    ''' </summary>
    Public ReadOnly Property Header As FileHeader
        Get
            Return _header
        End Get
    End Property

    ''' <summary>
    ''' Возвращает версию PDF.
    ''' </summary>
    Public ReadOnly Property Version As Version
        Get
            Return _version
        End Get
    End Property

    ''' <summary>
    ''' Информация о документе.
    ''' </summary>
    Public ReadOnly Property Information As DocumentInformation
        Get
            Return _documentInformation
        End Get
    End Property

    ''' <summary>
    ''' Каталог документа.
    ''' </summary>
    Public ReadOnly Property Catalog As DocumentCatalog
        Get
            Return _documentCatalog
        End Get
    End Property

    ''' <summary>
    ''' Корень документа.
    ''' </summary>
    Public ReadOnly Property PageTree As DocumentPageTree
        Get
            Return _pageTree
        End Get
    End Property

    ''' <summary>
    ''' Создаёт страничное дерево привязанное к этому документу.
    ''' </summary>
    Public Function CreatePageTree() As DocumentPageTree
        Return DocumentPageTree.CreateWithBody(GetFileBody(0))
    End Function

    ''' <summary>
    ''' Создаёт страницу привязанную к этому документу.
    ''' </summary>
    Public Function CreatePage() As DocumentPage
        Return DocumentPage.CreateWithBody(GetFileBody(0))
    End Function

    ''' <summary>
    ''' Вычисляет байтовый сдвиг от начала файла до конца последнего объекта.
    ''' </summary>
    ''' <param name="generationNumber">Номер поколения</param>
    ''' <param name="objectNumber"> Номер объекта</param>
    ''' <returns></returns>
    Friend Function CalculateOffset(generationNumber As Integer, objectNumber As Integer) As Integer
        Dim offset = Header.Length
        For i = 0 To generationNumber - 1
            offset += GetFileBody(i).Length + GetCrossReferenceTable(i).Length + GetFileTrailer(i).Length
        Next
        For i = 0 To objectNumber - 2
            offset += GetFileBody(generationNumber).ElementAt(i).Length + 1
        Next
        Return offset
    End Function

    ''' <summary>
    ''' Возвращает тело файла по указанному индексу.
    ''' </summary>
    ''' <param name="index">Индекс</param>
    Public Function GetFileBody(index As Integer) As FileBody
        Dim result = _objectStructures.ElementAt(index)
        If result Is Nothing Then Throw New IndexOutOfRangeException()
        Return result.Item1
    End Function

    ''' <summary>
    ''' Возвращает ссылочную таблицу по указанному индексу.
    ''' </summary>
    ''' <param name="index">Индекс</param>
    Public Function GetCrossReferenceTable(index As Integer) As CrossReferenceTable
        Dim result = _objectStructures.ElementAt(index)
        If result Is Nothing Then Throw New IndexOutOfRangeException()
        Return result.Item2
    End Function

    ''' <summary>
    ''' Возвращает стрейлер файла по указанному индексу.
    ''' </summary>
    ''' <param name="index">Индекс</param>
    Public Function GetFileTrailer(index As Integer) As FileTrailer
        Dim result = _objectStructures.ElementAt(index)
        If result Is Nothing Then Throw New IndexOutOfRangeException()
        Return result.Item3
    End Function

    ''' <summary>
    ''' Возвращает строковое представление документа.
    ''' </summary>
    Public Overrides Function ToString() As String
        WriteInStream()
        Dim bytes = _stream.ToArray()
        Return Encoding.Default.GetString(bytes)
    End Function

    Public Function ToArray() As Byte()
        WriteInStream()
        Dim bytes = _stream.ToArray()
        Return bytes
    End Function

    ''' <summary>
    ''' Записывает документ в Stream.
    ''' </summary>
    Private Sub WriteInStream()
        _header.WriteIn(_stream)
        For Each os In _objectStructures
            os.Item1.WriteIn(_stream)
            os.Item2.WriteIn(_stream)
            os.Item3.WriteIn(_stream)
        Next
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        DirectCast(_stream, IDisposable).Dispose()
        _pageTree.Dispose()
    End Sub

End Class

