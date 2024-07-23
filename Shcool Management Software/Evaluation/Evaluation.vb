Imports System.Data.SqlClient

Public Class Evaluation
    Private Sub Evaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Student()
        Teacher()
    End Sub
    Private Sub Student()
        Try
            Dim sql As String = "select Student_id as 'التسلسل',Student_Name as 'اسم الطالب',study_Level as 'المرحلة' from Student"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Teacher()
        Try
            Dim sql As String = "select id_teacher as 'التسلسل' ,name_teacher as 'الاسم',Graduate as 'التخصص' from Teacher"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "column_name"
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Show_All.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("أدخل اسم الطالب رجاءاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Select max(id) from Assess"
                Dim command As New SqlCommand(sql, cn)
                cn.Open()
                Dim x = command.ExecuteScalar().ToString()
                TextBox1.Text = Val(x) + 1
                cn.Close()
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
            Try
                Dim sql As String = "INSERT INTO Assess (id,Assess,student,teacher,Subject)  " _
            & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox1.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم ادخال البيانات بنجاح", MsgBoxStyle.Information, "!!")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                MsgBox("حدث خطا ؟؟", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Try
            Dim sql2 As String = "Select id_student From Student WHERE name='" & TextBox3.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox5.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            Dim sql2 As String = "Select id_teacher From Teacher WHERE name='" & TextBox4.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox6.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox5.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox3.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        TextBox6.Text = DataGridView2.CurrentRow.Cells(0).Value.ToString()
        TextBox4.Text = DataGridView2.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الشي ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Assess WHERE id =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "Warning !")
            Else
                MsgBox("غير موجود", "حدث خطا ما !!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim sql As String = "Update Assess set Assess='" & TextBox2.Text & "',student='" & TextBox5.Text & "',teacher='" & TextBox6.Text & "',Subject='" & ComboBox1.Text & "' where id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information, "Warning !")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "select * from Assess where id ='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                TextBox5.Text = reader(3)
                TextBox6.Text = reader(4)
                ComboBox1.Text = reader(5)
                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class