﻿Imports System.Data.SqlClient

Public Class Users
    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code()
    End Sub
    Private Sub code()
        Try
            Dim sql As String = "select id_user as '#' ,username  as 'اسم المستخدم' , allow as 'السماح'  ,type as 'نوع الحساب'  from users"
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim spending_a As String
        If CheckBox3.Checked = True Then
            spending_a = "True"
        Else
            spending_a = "False"
        End If

        Try
            Dim sql As String = "update users set allow='" & spending_a & "' where id_user='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "!!")
            code()
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            'أعادة استدعاء للبيانات لغرض التحديث
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا المستخدم ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM users WHERE id_user =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                code()
                'أعادة استدعاء للبيانات لغرض التحديث                
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel1.Visible = True
        Button2.Visible = False
        Button3.Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim max As Integer
        Try
            Dim sql As String = "Select max(id_user) from Users"
            Dim command As New SqlCommand(sql, cn)
            cn.Open()
            Dim x = command.ExecuteScalar().ToString()
            max = Val(x) + 1
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
        Try
            Dim DeleteQuery As String = "insert into Users(id_user,username,password)  " _
       & "VALUES ('" & max & "','" & TextBox4.Text & "','" & TextBox3.Text & "')"

            Dim sda As New SqlDataAdapter(DeleteQuery, cn)
            Dim com = New SqlCommand(DeleteQuery, cn)
            cn.Open()
            com.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم الاضافة بنجاح", MsgBoxStyle.Information, "Warning !")
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            code()
            TextBox3.Clear()
            TextBox4.Clear()
            'أعادة استدعاء للبيانات لغرض التحديث                           
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class