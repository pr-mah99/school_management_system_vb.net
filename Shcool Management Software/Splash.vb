Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Splash
    Dim x As String = ""
    Dim name As String = ""
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Val(Label2.Text) + 1
        If Label2.Text = 1 Then
        ElseIf Label2.Text = 2 Then
            ProgressBar1.Visible = True
            ProgressBar1.Value = 7
            Label4.Visible = True
            check()
        ElseIf Label2.Text = 3 Then
            ProgressBar1.Value = 36
            PictureBox6.Visible = True
        ElseIf Label2.Text = 4 Then
            Label3.Visible = True
            ProgressBar1.Value = 53
        ElseIf Label2.Text = 5 Then
            ProgressBar1.Value = 89
            PictureBox4.Visible = True
        ElseIf Label2.Text = 6 Then
            ProgressBar1.Value = 100
            Label3.Visible = False
        ElseIf Label2.Text = 7 Then
            Login.Show()
            Me.Close()
        End If
    End Sub
    Private Sub check()

        Dim sql2 As String = "select name from School_info"
        Dim command As New SqlCommand(sql2, cn)
        cn.Open()
        name = command.ExecuteScalar().ToString()
        If name = "" Then
            Info.Show()
            Info.TextBox3.Text = "splash"
            Me.Close()
        Else
            Label1.Text = name.ToString
        End If
        cn.Close()
    End Sub
End Class