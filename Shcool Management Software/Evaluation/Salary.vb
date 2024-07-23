Imports System.Data.SqlClient

Public Class Salary
    Private Sub clear()
        TextBox2.Text = "0"
        TextBox3.Text = "0"
        TextBox5.Text = "0"
        TextBox4.Text = ""
        TextBox6.Text = "0"
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub
    Private Sub fillItemName_teacher(sql As String, ItemName As ComboBox)
        'combo box الدالة الخاصة بال
        ItemName.Items.Clear()
        Dim adp As New SqlClient.SqlDataAdapter(sql, cn)
        Dim ds As New DataSet
        adp.Fill(ds)
        Dim dt = ds.Tables(0)
        For i = 0 To dt.Rows.Count - 1
            'combo box نختار اسم الحقل الي نريدة ان يظهر في ال 
            ItemName.Items.Add(dt.Rows(i).Item("name_teacher"))
        Next
    End Sub
    Private Sub Salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Salary()
        fillItemName_teacher("select * from Teacher", ComboBox1)
    End Sub
    Private Sub Salary()
        Try
            Dim sql As String = "SELECT id as 'رقم الراتب',salary as 'الراتب',reward as 'المكافاءة',name_teacher as 'الاستاذ',type as 'النوع',allocations as 'المخصصات',total as 'الاجمالي' from salary,Teacher where id_teacher=teacher"
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
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "الاعدادية" Then
            TextBox4.Text = 25
        ElseIf ComboBox2.Text = "دبلوم" Then
            TextBox4.Text = 35
        ElseIf ComboBox2.Text = "البكالوريوس" Then
            TextBox4.Text = 45
        ElseIf ComboBox2.Text = "الماجستير" Then
            TextBox4.Text = 75
        ElseIf ComboBox2.Text = "الدكتواره" Then
            TextBox4.Text = 100
        End If
        operation()
    End Sub
    Private Sub operation()
        Dim x As Double
        x = Val(TextBox2.Text) + Val(TextBox3.Text)
        If TextBox4.Text = "25" Then
            TextBox5.Text = (Val(x) / 100) * 25
        ElseIf TextBox4.Text = "35" Then
            TextBox5.Text = (Val(x) / 100) * 35
        ElseIf TextBox4.Text = "45" Then
            TextBox5.Text = (Val(x) / 100) * 45
        ElseIf TextBox4.Text = "75" Then
            TextBox5.Text = (Val(x) / 100) * 75
        ElseIf TextBox4.Text = "100" Then
            TextBox5.Text = (Val(x) / 100) * 100
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        operation()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        operation()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        operation()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox6.Text = Val(TextBox5.Text) + Val(TextBox2.Text) + Val(TextBox3.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id_teacher From Teacher WHERE name_teacher='" & ComboBox1.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            Else
                cn.Open()
            End If
            TextBox7.Text = command.ExecuteScalar().ToString()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim max As Integer
        If TextBox2.Text = "" Then
            MsgBox("اختر المادة اولاً رجاءاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Select max(id) from Salary"
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
                Dim sql As String = "INSERT INTO Salary (id,salary,Reward,teacher,type,Allocations,Total)  " _
            & "VALUES ('" & max & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox7.Text & "','" & ComboBox2.Text & "','" & TextBox4.Text & "%','" & TextBox6.Text & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم ادخال البيانات بنجاح", MsgBoxStyle.Information, "!!")
                Salary()
                clear()
                TextBox1.Clear()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
                MsgBox("حدث خطا ؟؟", MsgBoxStyle.Critical)
            Finally
                cn.Close()
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As String = "Update Salary set salary='" & TextBox2.Text & "',Reward='" & TextBox3.Text & "',teacher='" & TextBox7.Text & "',type='" & ComboBox2.Text & "',Allocations='" & TextBox4.Text & "%',Total='" & TextBox6.Text & "'where id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information, "Warning !")
            Salary()
            TextBox1.Clear()
            clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الشي ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "DELETE FROM Salary WHERE id =" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                Salary()
                clear()
                TextBox1.Clear()
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Question, "Warning !")
            Else
                MsgBox("غير موجود", "حدث خطا ما !!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub selec()
        Try
            Dim sql As String = "select id,salary,reward,teacher,type,Allocations,Total, name_teacher from Salary,teacher where teacher=id_teacher and id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                TextBox3.Text = reader(2)
                TextBox7.Text = reader(3)
                ComboBox2.Text = reader(4)
                TextBox5.Text = reader(5)
                TextBox6.Text = reader(6)
                ComboBox1.Text = reader(7)
                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clear()
        selec()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        clear()
        selec()
    End Sub
End Class