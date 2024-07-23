Public Class Type
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Evaluation.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Spending.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Salary.Show()
    End Sub

    Private Sub Type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Main.TextBox1.Text = "Manager" Then
            Button5.Enabled = True
        Else
            Button5.Enabled = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Users.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Security.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Info.Show()
    End Sub
End Class