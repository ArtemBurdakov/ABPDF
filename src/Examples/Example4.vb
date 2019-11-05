Imports System.IO
Imports ABPDF

Public Class Example4

    Public Shared Sub Start()
        Dim docPDF = New PDF
        Dim page1 = docPDF.CreatePage()
        Dim dataImg = File.ReadAllBytes("images/chess.jpg")
        Dim streamImg = New MemoryStream(dataImg)
        Dim img1 = DrawingTools.Image(streamImg, ImageType.JPEG)

        streamImg.Close()

        docPDF.
            PageTree.
            Add(page1)

        img1.Position = DrawingTools.Point(200, 500)
        img1.ScaleBy(0.5)
        page1.Draw(img1)

        File.WriteAllBytes("ExamplePDF4.pdf", docPDF.ToArray())
        docPDF.Dispose()
    End Sub

End Class

