Imports System.Data.SqlClient

Public Class Info
    Private Sub GetData()
        Try
            Dim name, desc, type As String
            Dim sql As SqlCommand = New SqlCommand("Select * from School_info", cn)
            cn.Open()
            Dim reader As SqlDataReader = sql.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                name = reader(0)
                type = reader(1)
                desc = reader(2)
                cn.Close()
            End If
            TextBox1.Text = name
            TextBox2.Text = desc
            ComboBox1.Text = type
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Defernet.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox3.Text = "splash" Then
            Try
                Dim sql As String = "INSERT INTO School_info (name,Description,type) " _
           & "VALUES (' " & TextBox1.Text & "',' " & TextBox2.Text & "',' " & ComboBox1.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم حفظ البيانات بنجاح", MsgBoxStyle.Information, "!!")
                Splash.Show()
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
            Finally
                cn.Close()
            End Try
        Else
            Try
                Dim sql As String = "Update School_info set name='" & TextBox1.Text & "',Description='" & TextBox2.Text & "',type='" & ComboBox1.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم حفظ البيانات بنجاح", MsgBoxStyle.Information, "!!")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
            Finally
                cn.Close()
            End Try
        End If
    End Sub
End Class