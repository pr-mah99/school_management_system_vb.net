Imports System.Data.SqlClient

Public Class Money
    Private Sub grid_style()
        DataGridView1.Columns(0).Width = 8
        DataGridView1.Columns(1).Width = 26
        DataGridView1.Columns(2).Width = 15
        DataGridView1.Columns(3).Width = 15
        DataGridView1.Columns(4).Width = 120
    End Sub
    Private Sub money()
        Try
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "select id_money as '#',student_name as 'اسم الطالب',money_part1 as 'القسط 1',money_part2 as 'القسط 2',State as  'حالة الدفع' from pay, Student where Pay.Studnet_number=Student.student_id"
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            cn.Close()
            DataGridView1.DataSource = dt
            grid_style()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Money_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        money()
        fillItemName("select * from Student", ComboBox1)
    End Sub
    Private Sub fillItemName(sql As String, ItemName As ComboBox)
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("Student_Name"))
        Next
    End Sub
    Sub update_student()
        Try
            Dim sql As String = "update Pay set money_part1='" & TextBox2.Text & "',money_part2='" & TextBox4.Text & "',State='" & ComboBox2.Text & "' where id_money='" & TextBox3.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم الدفع بنجاح", MsgBoxStyle.Information, "!!")
            money()
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("خطا !!", MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        update_student()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        TextBox3.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel4.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Panel4.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim max As Integer
        Try
            Dim sql As String = "Select max(id_money) from Pay"
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
            Dim sql As String = "INSERT INTO Pay(id_money,Studnet_number)  " _
       & "VALUES ('" & max & "','" & TextBox5.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم الاضافة بنجاح", MsgBoxStyle.Information, "!!")
            money()
            TextBox5.Text = ""
            ComboBox1.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select Student_id From Student WHERE Student_Name='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            cn.Open()
            TextBox5.Text = command.ExecuteScalar().ToString()
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If MsgBox("هل انت متاكد من حذف عملية الدفع ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                Dim sql As String = "delete from Pay where id_money='" & TextBox3.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم حذف البيانات بنجاح", MsgBoxStyle.Information, "!!")
                money()
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "Warning !")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub
End Class