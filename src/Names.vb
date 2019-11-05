Imports ABPDF.PDFObjects

''' <summary>
''' Фабрика для создания именных объектов.
''' </summary>
Public Class Names

#Region "StreamDictionary"

    ''' <summary>
    ''' Создаёт именной объект - Количество байтов.
    ''' </summary>
    Public Shared Function Length() As NameObject
        Return New NameObject("Length")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Фильтр декодирования, декомпрессирования, расшифровки.
    ''' </summary>
    Public Shared Function Filter() As NameObject
        Return New NameObject("Filter")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Параметры для фильтра декодирования, декомпрессирования, расшифровки.
    ''' </summary>
    Public Shared Function DecodeParams() As NameObject
        Return New NameObject("DecodeParams")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Внешний файл, содержащий данные потока.
    ''' </summary>
    Public Shared Function F() As NameObject
        Return New NameObject("F")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Фильтр декодирования, декомпрессирования, расшифровки для внешнего файла.
    ''' </summary>
    Public Shared Function FFilter() As NameObject
        Return New NameObject("FFilter")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Параметры для фильтра декодирования, декомпрессирования, расшифровки для внешнего файла.
    ''' </summary>
    Public Shared Function FDecodeParams() As NameObject
        Return New NameObject("FDecodeParams")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Количество байтов декодированного потока.
    ''' </summary>
    Public Shared Function DL() As NameObject
        Return New NameObject("DL")
    End Function

#End Region

#Region "TrailerDictionary"

    ''' <summary>
    ''' Создаёт именной объект - Количество записей в ссылочной таблице.
    ''' </summary>
    Public Shared Function Size() As NameObject
        Return New NameObject("Size")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Байтовый сдвиг для предыдущей ссылочной таблицы.
    ''' </summary>
    Public Shared Function Prev() As NameObject
        Return New NameObject("Prev")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ссылка на каталог документа.
    ''' </summary>
    Public Shared Function Root() As NameObject
        Return New NameObject("Root")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ссылка на объект шифрования.
    ''' </summary>
    Public Shared Function Encrypt() As NameObject
        Return New NameObject("Encrypt")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ссылка на объект с информацией о документе.
    ''' </summary>
    Public Shared Function Info() As NameObject
        Return New NameObject("Info")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Идентификатор файла.
    ''' </summary>
    Public Shared Function ID() As NameObject
        Return New NameObject("ID")
    End Function

#End Region

#Region "DocumentInformationDictionary"

    ''' <summary>
    ''' Создаёт именной объект - Наименование документа.
    ''' </summary>
    Public Shared Function Title() As NameObject
        Return New NameObject("Title")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Имя человека, создавшего документ.
    ''' </summary>
    Public Shared Function Author() As NameObject
        Return New NameObject("Author")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Тема документа.
    ''' </summary>
    Public Shared Function Subject() As NameObject
        Return New NameObject("Subject")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ключевые слова, связанные с документом.
    ''' </summary>
    Public Shared Function Keywords() As NameObject
        Return New NameObject("Keywords")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Если документ был преобразован в PDF из другого формата, имя соответствующего продукта, который создал исходный документ, с которого он был преобразован.
    ''' </summary>
    Public Shared Function Creator() As NameObject
        Return New NameObject("Creator")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Если документ был преобразован в PDF из другого формата, название соответствующего продукта, преобразующего его в PDF.
    ''' </summary>
    Public Shared Function Producer() As NameObject
        Return New NameObject("Producer")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Дата и время создания документа.
    ''' </summary>
    Public Shared Function CreationDate() As NameObject
        Return New NameObject("CreationDate")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Дата и время модификации документа.
    ''' </summary>
    Public Shared Function ModDate() As NameObject
        Return New NameObject("ModDate")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Свойство, указывающиее, был ли документ изменен для включения информации об улавливании.
    ''' </summary>
    Public Shared Function Trapped() As NameObject
        Return New NameObject("Trapped")
    End Function

#End Region

#Region "DocumentCatalog"

    ''' <summary>
    ''' Создаёт именной объект - Тип объекта документа.
    ''' </summary>
    Public Shared Function Type() As NameObject
        Return New NameObject("Type")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Каталог документа.
    ''' </summary>
    Public Shared Function Catalog() As NameObject
        Return New NameObject("Catalog")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Узел дерева страниц документа.
    ''' </summary>
    Public Shared Function Pages() As NameObject
        Return New NameObject("Pages")
    End Function

#End Region

#Region "DocumentPageTree"

    ''' <summary>
    ''' Создаёт именной объект - Родительский узел документа.
    ''' </summary>
    Public Shared Function Parent() As NameObject
        Return New NameObject("Parent")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Количество узлов.
    ''' </summary>
    Public Shared Function Count() As NameObject
        Return New NameObject("Count")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Дети узла.
    ''' </summary>
    Public Shared Function Kids() As NameObject
        Return New NameObject("Kids")
    End Function

#End Region

#Region "DocumentPage"

    ''' <summary>
    ''' Создаёт именной объект - Страница документа.
    ''' </summary>
    Public Shared Function Page() As NameObject
        Return New NameObject("Page")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ресурсы страницы.
    ''' </summary>
    Public Shared Function Resources() As NameObject
        Return New NameObject("Resources")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Границы физического носителя, на котором страница должна отображаться или печататься.
    ''' </summary>
    Public Shared Function MediaBox() As NameObject
        Return New NameObject("MediaBox")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Потоки содержимого.
    ''' </summary>
    Public Shared Function Contents() As NameObject
        Return New NameObject("Contents")
    End Function

#End Region

#Region "ResourceDictionary"

    ''' <summary>
    ''' Создаёт именной объект - Словарь параметров состояния графики.
    ''' </summary>
    Public Shared Function ExtGState() As NameObject
        Return New NameObject("ExtGState")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Словарь цветового пространста.
    ''' </summary>
    Public Shared Function ColorSpace() As NameObject
        Return New NameObject("ColorSpace")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Словарь шаблонов.
    ''' </summary>
    Public Shared Function Pattern() As NameObject
        Return New NameObject("Pattern")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Словарь затенений.
    ''' </summary>
    Public Shared Function Shading() As NameObject
        Return New NameObject("Shading")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Словарь внешних объектов.
    ''' </summary>
    Public Shared Function XObject() As NameObject
        Return New NameObject("XObject")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Словарь шрифтов.
    ''' </summary>
    Public Shared Function Font() As NameObject
        Return New NameObject("Font")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Массив набора процедур.
    ''' </summary>
    Public Shared Function ProcSet() As NameObject
        Return New NameObject("ProcSet")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Словарь списков свойств.
    ''' </summary>
    Public Shared Function Properties() As NameObject
        Return New NameObject("Properties")
    End Function

#End Region

#Region "Font"

    ''' <summary>
    ''' Создаёт именной объект - Подтип объекта.
    ''' </summary>
    Public Shared Function Subtype() As NameObject
        Return New NameObject("Subtype")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Имя шрифта в справочнике ресурсов.
    ''' </summary>
    Public Shared Function Name() As NameObject
        Return New NameObject("Name")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Имя шрифта.
    ''' </summary>
    Public Shared Function BaseFont() As NameObject
        Return New NameObject("BaseFont")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Шрифт, который определяет формы глифов с использованием технологии шрифтов Type 1.
    ''' </summary>
    Public Shared Function Type1() As NameObject
        Return New NameObject("Type1")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Шрифт Helvetica.
    ''' </summary>
    Public Shared Function Helvetica() As NameObject
        Return New NameObject("Helvetica")
    End Function

#End Region

#Region "Image"

    ''' <summary>
    ''' Создаёт именной объект - Изображение.
    ''' </summary>
    Public Shared Function Image() As NameObject
        Return New NameObject("Image")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ширина.
    ''' </summary>
    Public Shared Function Width() As NameObject
        Return New NameObject("Width")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Высота.
    ''' </summary>
    Public Shared Function Height() As NameObject
        Return New NameObject("Height")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Устройство отображает серые цвета.
    ''' </summary>
    Public Shared Function DeviceGray() As NameObject
        Return New NameObject("DeviceGray")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Устройство отображает цвета RGB.
    ''' </summary>
    Public Shared Function DeviceRGB() As NameObject
        Return New NameObject("DeviceRGB")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Глубина цвета.
    ''' </summary>
    Public Shared Function BitsPerComponent() As NameObject
        Return New NameObject("BitsPerComponent")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Распаковывает данные, сжатые по алгоритму Deflate.
    ''' </summary>
    Public Shared Function FlateDecode() As NameObject
        Return New NameObject("FlateDecode")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Распаковывает данные, закодированные с использованием метода DCT 
    ''' (дискретного косинусного преобразования), основанного на стандарте JPEG, 
    ''' воспроизводя данные образца изображения, которые приближаются к исходным данным.
    ''' </summary>
    Public Shared Function DCTDecode() As NameObject
        Return New NameObject("DCTDecode")
    End Function

#End Region

#Region "CIDSystemInfo"

    ''' <summary>
    ''' Создаёт именной объект - Реестр.
    ''' </summary>
    Public Shared Function Registry() As NameObject
        Return New NameObject("Registry")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Заказ.
    ''' </summary>
    Public Shared Function Ordering() As NameObject
        Return New NameObject("Ordering")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Дополнение.
    ''' </summary>
    Public Shared Function Supplement() As NameObject
        Return New NameObject("Supplement")
    End Function

#End Region

#Region "FontDescriptor"

    ''' <summary>
    ''' Создаёт именной объект - Дескриптор шрифта.
    ''' </summary>
    Public Shared Function FontDescriptor() As NameObject
        Return New NameObject("FontDescriptor")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Имя шрифта.
    ''' </summary>
    Public Shared Function FontName() As NameObject
        Return New NameObject("FontName")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Флаги.
    ''' </summary>
    Public Shared Function Flags() As NameObject
        Return New NameObject("Flags")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Угол наклона.
    ''' </summary>
    Public Shared Function ItalicAngle() As NameObject
        Return New NameObject("ItalicAngle")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Подъём.
    ''' </summary>
    Public Shared Function Ascent() As NameObject
        Return New NameObject("Ascent")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Спуск.
    ''' </summary>
    Public Shared Function Descent() As NameObject
        Return New NameObject("Descent")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Верхняя высота.
    ''' </summary>
    Public Shared Function CapHeight() As NameObject
        Return New NameObject("CapHeight")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Средняя ширина.
    ''' </summary>
    Public Shared Function AvgWidth() As NameObject
        Return New NameObject("AvgWidth")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Максимальная ширина.
    ''' </summary>
    Public Shared Function MaxWidth() As NameObject
        Return New NameObject("MaxWidth")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Вес шрифта.
    ''' </summary>
    Public Shared Function FontWeight() As NameObject
        Return New NameObject("FontWeight")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Высота x.
    ''' </summary>
    Public Shared Function XHeight() As NameObject
        Return New NameObject("XHeight")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Leading.
    ''' </summary>
    Public Shared Function Leading() As NameObject
        Return New NameObject("Leading")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - StemV.
    ''' </summary>
    Public Shared Function StemV() As NameObject
        Return New NameObject("StemV")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Контейнер шрифта.
    ''' </summary>
    Public Shared Function FontBBox() As NameObject
        Return New NameObject("FontBBox")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Файл TrueType шрифта.
    ''' </summary>
    Public Shared Function FontFile2() As NameObject
        Return New NameObject("FontFile2")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Длина.
    ''' </summary>
    Public Shared Function Length1() As NameObject
        Return New NameObject("Length1")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Кодировка Identity-H.
    ''' </summary>
    Public Shared Function Identity_H() As NameObject
        Dim dash = System.Text.Encoding.Default.GetString({&H2D})
        Return New NameObject("Identity" & dash & "H")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Коировка.
    ''' </summary>
    Public Shared Function Encoding() As NameObject
        Return New NameObject("Encoding")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Шрифт Type0 (состовной шрифт).
    ''' </summary>
    Public Shared Function Type0() As NameObject
        Return New NameObject("Type0")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Шрифы потомки.
    ''' </summary>
    Public Shared Function DescendantFonts() As NameObject
        Return New NameObject("DescendantFonts")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ширина глифов.
    ''' </summary>
    Public Shared Function W() As NameObject
        Return New NameObject("W")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Коировка Unicode.
    ''' </summary>
    Public Shared Function ToUnicode() As NameObject
        Return New NameObject("ToUnicode")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Ширина по умолчанию.
    ''' </summary>
    Public Shared Function DW() As NameObject
        Return New NameObject("DW")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Шрифт TimesNewRoman.
    ''' </summary>
    Public Shared Function TimesNewRoman() As NameObject
        Return New NameObject("TimesNewRoman")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Шрифт TimesNewRoman Bold.
    ''' </summary>
    Public Shared Function TimesNewRoman_Bold() As NameObject
        Return New NameObject("TimesNewRoman,Bold")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Тип шрифта CIDFontType2.
    ''' </summary>
    Public Shared Function CIDFontType2() As NameObject
        Return New NameObject("CIDFontType2")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Карта номеров глифов.
    ''' </summary>
    Public Shared Function CIDToGIDMap() As NameObject
        Return New NameObject("CIDToGIDMap")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Карта номеров глифов Identity.
    ''' </summary>
    Public Shared Function Identity() As NameObject
        Return New NameObject("Identity")
    End Function

    ''' <summary>
    ''' Создаёт именной объект - Реестр символов.
    ''' </summary>
    Public Shared Function CIDSystemInfo() As NameObject
        Return New NameObject("CIDSystemInfo")
    End Function

#End Region

End Class

