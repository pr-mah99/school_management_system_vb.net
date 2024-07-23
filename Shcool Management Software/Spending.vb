Imports System.Data.SqlClient

Public Class Spending
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Visible = True
        Button5.Visible = True
        DataGridView1.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Visible = False
        Button5.Visible = False
        DataGridView1.Visible = False
    End Sub
    Private Sub clear_textbox()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Select
        Try
            Dim sql As String = "Select * From Spending WHERE spending_id=" & TextBox1.Text
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                'idبأعتبار انة اول قيمة بالجدول مهملة وهي ال
                'Guna2TextBox1.Text = reader(0)
                TextBox2.Text = reader(1)
                TextBox3.Text = reader(2)
                TextBox4.Text = reader(3)
                cn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'add
        Try
            Try
                Dim sql2 As String = "Select max(spending_id) from Spending"
                Dim command As New SqlCommand(sql2, cn)
                cn.Open()
                Dim x As Integer = command.ExecuteScalar().ToString()
                TextBox1.Text = Val(x) + 1
                cn.Close()
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
            Dim sql As String = "INSERT INTO Spending (spending_id,Type,spending,detauls)  " _
        & "VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم اداخال البيانات بنجاح", MsgBoxStyle.Information, "!!")
            code_Sql()
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox()
            'أعادة استدعاء للبيانات لغرض التحديث
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'update
        Try
            Dim sql As String = "update Spending set Type='" & TextBox2.Text & "', spending='" & TextBox3.Text & "', detauls='" & TextBox4.Text & "' where spending_id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "!!")
            code_Sql()
            'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
            clear_textbox()
            'أعادة استدعاء للبيانات لغرض التحديث
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'delete
        Try
            If MsgBox("هل انت متاكد من حذف هذا ؟ ", MessageBoxButtons.YesNo + MessageBoxIcon.Question, "تحذير !!") = DialogResult.Yes Then
                'Delete Code
                Dim DeleteQuery As String = "delete from Spending where spending_id='" & TextBox1.Text & "'"
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم حذف البيانات بنجاح", MsgBoxStyle.Information, "!!")
                code_Sql()
                'استدعاء الدالة تفريغ الحقول بعد تنفيذ عملية ناجحة
                clear_textbox()
                'أعادة استدعاء للبيانات لغرض التحديث
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء الحذف", MsgBoxStyle.Information, "Warning !")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Spending_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        code_Sql()
    End Sub
    Private Sub code_Sql()
        Try
            Dim sql As String = "Select spending_id as 'التسلسل',Type as 'النوع',spending as 'السعر',detauls as 'التفاصيل',date as 'التاريخ' from Spending"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) 
    End Sub

End Class