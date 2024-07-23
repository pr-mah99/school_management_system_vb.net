Imports System.Data.SqlClient

Public Class Teacher
    Private Sub code()
        Try
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            cn.Open()
            cmd.Connection = cn
            cmd.CommandText = "select id_teacher as '#',name_teacher as 'ألاسم', Birthday as 'المواليد',city as 'السكن',Gender as 'الجنس',Mobile as 'رقم الموبايل',Email as 'العمل',Circle as 'الدائرة' from Teacher"
            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            cn.Close()
        Catch ex As Exception
        Finally
            cn.Close()
        End Try

    End Sub
    Private Sub Teacher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim max As Integer
        Try
            Dim sql As String = "Select max(id_teacher) from Teacher"
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
            Dim sql As String = "INSERT INTO Teacher(id_teacher,name_teacher,Birthday,City,Gender,Mobile,Email,Circle)  " _
       & "VALUES ('" & max & "','" & TextBox2.Text & "','" & DateTimePicker2.Value.Date & "','" & TextBox4.Text & "','" & ComboBox6.Text & "','" & TextBox6.Text & "','" & ComboBox1.Text & "','" & TextBox8.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم الاضافة بنجاح", MsgBoxStyle.Information, "!!")
            code
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub
    Private Sub clear()
        'TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        ComboBox1.Text = ""
        TextBox8.Clear()
        ComboBox6.Text = ""
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim x = TextBox1.Text
        clear()
        TextBox1.Text = x
        Try
            Dim sql As String = "select * from Teacher where id_teacher ='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                TextBox4.Text = reader(3)
                TextBox6.Text = reader(5)
                ComboBox1.Text = reader(6)
                TextBox8.Text = reader(7)
                ComboBox6.Text = reader(4)
                DateTimePicker2.Value = reader(2)
                cn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "update Teacher set name_teacher='" & TextBox2.Text & "',Birthday='" & DateTimePicker2.Value.Date & "',City='" & TextBox4.Text & "',Gender='" & ComboBox6.Text & "',Mobile='" & TextBox6.Text & "',Email='" & ComboBox1.Text & "',Circle='" & TextBox8.Text & "' where id_teacher='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "!!")
            code()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الاستاذ ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                Dim sql As String = "delete from Teacher where id_teacher='" & TextBox1.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم حذف البيانات بنجاح", MsgBoxStyle.Information, "!!")
                code()
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "Warning !")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If TextBox2.Text = "" Then
        Else
            Dim form As New Teacher_insert
            Try
                form.TextBox20.Text = TextBox1.Text
                form.ShowDialog()
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        FilterData(TextBox3.Text)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        If TextBox3.Text = "" Then
            code()
        Else
            Dim searchQuery As String = "select id_teacher as '#',name_teacher as 'ألاسم', Birthday as 'المواليد',city as 'السكن',Gender as 'الجنس',Mobile as 'رقم الموبايل',Email as 'العمل',Circle as 'الدائرة' from Teacher where CONCAT(city,name_teacher,id_teacher,Mobile,Email,Circle) like '%" & valueToSearch & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End If
    End Sub
End Class