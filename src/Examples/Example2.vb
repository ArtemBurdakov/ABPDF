Imports System.IO
Imports ABPDF

Public Class Example2

    Public Shared Sub Start()
        Dim docPDF = New PDF
        Dim page1 = docPDF.CreatePage()
        Dim font1 = Fonts.TimesNewRoman_Bold()
        Dim sizeFont = 14
        Dim text1 = DrawingTools.TextWithFont(font1, sizeFont)
        Dim textString = "Hellow world!"
        Dim xPoint = page1.Width / 2 - font1.CalculateWidthString(textString, sizeFont) / 2
        Dim yPoint = page1.Height - font1.GetLineHeight(sizeFont)

        docPDF.
            PageTree.
            Add(page1)

        text1.Text = textString
        text1.Position = DrawingTools.Point(xPoint, yPoint)
        page1.Draw(text1)

        File.WriteAllBytes("ExamplePDF2.pdf", docPDF.ToArray())
        docPDF.Dispose()
    End Sub

End Class

