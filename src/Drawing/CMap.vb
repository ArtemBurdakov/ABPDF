Imports System.IO
Imports System.Text
Imports ABPDF.FileStructures
Imports ABPDF.PDFObjects

Namespace Drawing

    ''' <summary>
    ''' Представляет символьную карту шрифта,
    ''' Которая задаёт соответствие между кодом глифа и Unicode.
    ''' </summary>
    Public Class CMap
        Inherits InderectObject
        Implements IDisposable

        Private _stream As StreamObject

        ''' <summary>
        ''' Создаёт символьную карту шрифта.
        ''' </summary>
        Public Sub New()
            _stream = New StreamObject()
            _content = _stream
        End Sub

        ''' <summary>
        ''' Список соответствия кодов символов с кодами Unicode.
        ''' </summary>
        Public Property BFChars As GlyfChar()


        ''' <summary>
        ''' Тело файла.
        ''' </summary>
        Public Shadows Property FileBody As FileBody
            Get
                Return _fileBody
            End Get
            Friend Set(value As FileBody)
                _fileBody = value
            End Set
        End Property

        ''' <summary>
        ''' Данные потока.
        ''' </summary>
        Public ReadOnly Property Stream As MemoryStream
            Get
                Return DirectCast(_content, StreamObject).Stream
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            DirectCast(_stream, IDisposable).Dispose()
        End Sub

        ''' <summary>
        ''' Заполняет поток данными.
        ''' </summary>
        Friend Sub Flush()
            Dim space = Encoding.Default.GetBytes(" ")
            Dim newLine = Encoding.Default.GetBytes(vbLf)
            Dim cIDInit = New NameObject("CIDInit")
            Dim procSet = New NameObject("ProcSet")
            Dim findReSource = Encoding.Default.GetBytes("findresource")
            Dim begin = Encoding.Default.GetBytes("begin")
            Dim dict = Encoding.Default.GetBytes("dict")
            Dim cMapStr = Encoding.Default.GetBytes("cmap")
            Dim cIDSystemInfoName = New NameObject("CIDSystemInfo")
            Dim cIDSystemInfo = New CIDSystemInfo()
            cIDSystemInfo.Registry = New StringObject("Adobe")
            cIDSystemInfo.Ordering = New StringObject("UCS")
            cIDSystemInfo.Supplement = New NumericObject(0)
            Dim def = Encoding.Default.GetBytes("def")
            Dim cMapName = New NameObject("CMapName")
            Dim adobeIdentityUCS = New NameObject("Adobe-Identity-UCS")
            Dim cMapType = New NameObject("CMapType")
            Dim n2 = New NumericObject(2)
            Dim n1 = New NumericObject(1)
            Dim codeSpaceRange = Encoding.Default.GetBytes("codespacerange")
            Dim endBlock = Encoding.Default.GetBytes("end")
            Dim bfChar = Encoding.Default.GetBytes("bfchar")
            Dim bfRange = Encoding.Default.GetBytes("bfrange")
            Dim cMapNameStr = Encoding.Default.GetBytes("CMapName")
            Dim currentDict = Encoding.Default.GetBytes("currentdict")
            Dim cMap = New NameObject("CMap")
            Dim definereSource = Encoding.Default.GetBytes("defineresource pop")
            Dim h1 = New StringObject("0000") With {.Hexadecimal = True}
            Dim h2 = New StringObject("FFFF") With {.Hexadecimal = True}

            cIDInit.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            procSet.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(findReSource, 0, findReSource.Length)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(begin, 0, begin.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            _stream.Stream.Write(Encoding.Default.GetBytes(BFChars.Length.ToString), 0, BFChars.Length.ToString.Length)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(dict, 0, dict.Length)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(begin, 0, begin.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            _stream.Stream.Write(begin, 0, begin.Length)
            _stream.Stream.Write(cMapStr, 0, cMapStr.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            cIDSystemInfoName.WriteIn(_stream.Stream)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            cIDSystemInfo.ContentObject.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(def, 0, def.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            cMapName.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            adobeIdentityUCS.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(def, 0, def.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            cMapType.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            n2.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(def, 0, def.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)

            n1.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(begin, 0, begin.Length)
            _stream.Stream.Write(codeSpaceRange, 0, codeSpaceRange.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            h1.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            h2.WriteIn(_stream.Stream)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            _stream.Stream.Write(endBlock, 0, endBlock.Length)
            _stream.Stream.Write(codeSpaceRange, 0, codeSpaceRange.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)

            _stream.Stream.Write(Encoding.Default.GetBytes(BFChars.Length.ToString), 0, BFChars.Length.ToString.Length)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(begin, 0, begin.Length)
            _stream.Stream.Write(bfChar, 0, bfChar.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            For Each c In BFChars
                Dim codeChar = New StringObject(c.CodeChar.ToString("X4")) With {.Hexadecimal = True}
                codeChar.WriteIn(_stream.Stream)
                _stream.Stream.Write(space, 0, space.Length)
                Dim unicode = New StringObject(c.Unicode.ToString("X4")) With {.Hexadecimal = True}
                unicode.WriteIn(_stream.Stream)
                _stream.Stream.Write(newLine, 0, newLine.Length)
            Next
            _stream.Stream.Write(endBlock, 0, endBlock.Length)
            _stream.Stream.Write(bfChar, 0, bfChar.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)

            _stream.Stream.Write(endBlock, 0, endBlock.Length)
            _stream.Stream.Write(cMapStr, 0, cMapStr.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            _stream.Stream.Write(cMapNameStr, 0, cMapNameStr.Length)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(currentDict, 0, currentDict.Length)
            _stream.Stream.Write(space, 0, space.Length)
            cMap.WriteIn(_stream.Stream)
            _stream.Stream.Write(space, 0, space.Length)
            _stream.Stream.Write(definereSource, 0, definereSource.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            _stream.Stream.Write(endBlock, 0, endBlock.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
            _stream.Stream.Write(endBlock, 0, endBlock.Length)
            _stream.Stream.Write(newLine, 0, newLine.Length)
        End Sub

        ''' <summary>
        ''' Преобразует строку в шеснадцатиричный формат, в соответствии с картой.
        ''' </summary>
        ''' <param name="str">Преобразуемая строка</param>
        Friend Function Convert(str As String) As String
            Dim result As String = ""
            For Each c In str
                Dim cBytes = Encoding.Unicode.GetBytes(c)
                Dim unicode = (CType(cBytes(1), UShort) << 8) Or cBytes(0)
                Dim findBFChars = BFChars.Where(Function(x) x.Unicode = unicode)
                If findBFChars.Count > 0 Then
                    result &= findBFChars.First.CodeChar.ToString("X4")
                End If
            Next
            Return result
        End Function

        ''' <summary>
        ''' Создаёт массив ширины глифов.
        ''' </summary>
        Friend Function CreateGlifWidths() As ArrayObject
            Dim result = New ArrayObject()
            Dim widths = New ArrayObject
            Dim prevChar = New GlyfChar() With {.Width = -1}
            For Each c In BFChars
                If prevChar.Width = -1 OrElse c.CodeChar - 1 <> prevChar.CodeChar Then
                    result.Add(New NumericObject(c.CodeChar))
                    widths = New ArrayObject()
                    result.Add(widths)
                End If
                widths.Add(New NumericObject(c.Width))
                prevChar = c
            Next
            Return result
        End Function

    End Class

End Namespace

