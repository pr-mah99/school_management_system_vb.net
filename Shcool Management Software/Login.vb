Imports System.Data.SqlClient

Public Class Login
    Private Sub allow()
        Try
            Dim allow, temp As String
            Dim sql As SqlCommand = New SqlCommand("Select allow,type from Users where username='" + TextBox1.Text + "'", cn)
            Dim reader As SqlDataReader = sql.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                allow = reader(0)
                temp = reader(1)
                cn.Close()
                If allow = "True" Then
                    Main.Show()
                    Main.TextBox1.Text = temp
                    Me.Close()
                Else
                    MsgBox("انت غير مصرح لك بالدخول الى البرنامج", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As SqlCommand = New SqlCommand("Select * from Users where username='" + TextBox1.Text + "' And password='" + TextBox2.Text + "'", cn)
            Dim dt As New DataTable()
            cn.Open()
            Dim dataadapter As New SqlDataAdapter(sql)
            dataadapter.Fill(dt)
            If (dt.Rows.Count > 0) Then
                allow
            Else
                MsgBox("رجاءاً , تفقد اسم المستخدم وكلمة المرور", MsgBoxStyle.Critical, "!!")
            End If
            cn.Close()
        Catch ex As Exception
            MsgBox("حدث خطأ ما !؟ ", MsgBoxStyle.Critical, "!!")
        End Try

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class