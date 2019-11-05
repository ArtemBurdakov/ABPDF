Imports System.IO
Imports ABPDF
Imports ABPDF.Drawing

Public Class Example5

    Public Shared Sub Start()
        Dim docPDF = New PDF
        Dim page1 = docPDF.CreatePage()
        Dim font1 = Fonts.TimesNewRoman()
        Dim font2 = Fonts.TimesNewRoman_Bold()
        Dim sizeFont = 14
        Dim table1 = DrawingTools.Table()
        Dim sourceTest = New List(Of Tuple(Of String, String, String)) From {
            New Tuple(Of String, String, String)("Test1", 100, 100),
            New Tuple(Of String, String, String)("Test2", 10, 10),
            New Tuple(Of String, String, String)("Test3", 1000, 1000)
        }

        docPDF.
            PageTree.
            Add(page1)

        table1.Source = sourceTest
        table1.HeightHeader = font2.GetLineHeight(sizeFont) * 2 + 4
        table1.Font = font1
        table1.SizeFont = sizeFont
        table1.FontHeader = font2
        table1.SizeFontHeader = sizeFont

        table1.Columns = {
            New ColumnObject With {
                .Width = 200,
                .Name = "Column1",
                .AlignmentH = ColumnObject.AlignmentHorisontal.Center},
            New ColumnObject With {
                .Width = 100,
                .Name = "Column2",
                .AlignmentH = ColumnObject.AlignmentHorisontal.Right},
            New ColumnObject With {
                .Width = 80,
                .Name = "Test Column3",
                .AlignmentH = ColumnObject.AlignmentHorisontal.Right}
        }

        Dim xPoint = page1.Width / 2 - table1.Width / 2
        Dim yPoint = page1.Height - 20

        table1.Position = DrawingTools.Point(xPoint, yPoint)
        page1.Draw(table1)

        File.WriteAllBytes("ExamplePDF5.pdf", docPDF.ToArray())
        docPDF.Dispose()
    End Sub

End Class

