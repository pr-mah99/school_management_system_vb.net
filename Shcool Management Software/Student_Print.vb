Public Class Student_Print
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'PrintPreviewDialog1.Size = Me.Size
        'PrintPreviewDialog1.StartPosition = FormStartPosition.CenterScreen
        'If PrintPreviewDialog1.ShowDialog() = DialogResult.OK Then
        '    PrintDocument1.Print()
        'End If
        PrintDocument1.Print()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim image As New Bitmap(Panel2.Width, Panel2.Height)
        Panel2.DrawToBitmap(image, New Rectangle(Point.Empty, Panel2.Size))
        e.Graphics.DrawImage(image, New Point(0, 0))
    End Sub
End Class