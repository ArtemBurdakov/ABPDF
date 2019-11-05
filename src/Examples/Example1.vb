Imports System.IO
Imports ABPDF

Public Class Example1

    Public Shared Sub Start()
        Dim docPDF = New PDF
        Dim page1 = docPDF.CreatePage()
        Dim font1 = Fonts.TimesNewRoman()
        Dim text1 = DrawingTools.TextWithFont(font1, 14)

        docPDF.
            Information.
            Title = "Test Title"

        docPDF.
            Information.
            Author = "Ivanov I.I."

        docPDF.
            PageTree.
            Add(page1)

        page1.Height = 500
        page1.Width = 250

        text1.Text = "Hellow world!"
        text1.Position = DrawingTools.Point(100, 400)
        page1.Draw(text1)

        File.WriteAllBytes("ExamplePDF1.pdf", docPDF.ToArray())
        docPDF.Dispose()
    End Sub

End Class

