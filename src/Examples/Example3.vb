Imports System.IO
Imports ABPDF

Public Class Example3

    Public Shared Sub Start()
        Dim docPDF = New PDF
        Dim page1 = docPDF.CreatePage()
        Dim font1 = Fonts.TimesNewRoman()
        Dim text1 = DrawingTools.TextWithFont(font1, 14)
        Dim graph1 = DrawingTools.Graphics()
        Dim graph2 = DrawingTools.Graphics()
        Dim graph3 = DrawingTools.Graphics()

        docPDF.
            PageTree.
            Add(page1)

        text1.Text = ""
        page1.Draw(text1)

        graph1.Rect(DrawingTools.Point(10, 10), 100, 100)
        graph1.Stroke()
        page1.Draw(graph1)

        graph2.Rect(DrawingTools.Point(110, 110), 100, 100)
        graph2.Fill()
        page1.Draw(graph2)

        graph3.MoveTo(DrawingTools.Point(210, 210))
        graph3.LineTo(DrawingTools.Point(210, 310))
        graph3.LineTo(DrawingTools.Point(310, 310))
        graph3.ClosePath()
        graph3.Stroke()
        page1.Draw(graph3)

        File.WriteAllBytes("ExamplePDF3.pdf", docPDF.ToArray())
        docPDF.Dispose()
    End Sub

End Class

