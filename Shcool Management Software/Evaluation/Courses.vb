Imports System.Data.SqlClient

Public Class Courses
    Private Sub clear()
        TextBox4.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        ComboBox6.Text = ""
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
    Private Sub Courses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Courses()
        fillItemName_teacher("select * from Teacher", ComboBox3)
        ComboBox5.Items.Add("علمي احيائي")
        ComboBox5.Items.Add("علمي تطبيقي")
        ComboBox5.Items.Add("ادبي")
    End Sub
    Private Sub grid_style()
        DataGridView1.Columns(0).Width = 16
        DataGridView1.Columns(1).Width = 46
        DataGridView1.Columns(2).Width = 20
        DataGridView1.Columns(3).Width = 30
        DataGridView1.Columns(4).Width = 30
        DataGridView1.Columns(5).Width = 40
        DataGridView1.Columns(6).Width = 30
        DataGridView1.Columns(7).Width = 100
    End Sub
    Private Sub Courses()
        Try
            Dim sql As String = "select id as '#',subject as 'المادة',class as 'الصف',c_level as 'المرحلة',department as 'القسم',name_teacher as 'الاستاذ',Date as 'تاريخ',Time as 'الوقت' from Courses,Teacher where teacher=id_teacher"
            Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "column_name"
            grid_style()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            Dim sql2 As String = "Select id_teacher From Teacher WHERE name_teacher='" & ComboBox3.Text & "'"
            Dim command As New SqlCommand(sql2, cn)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            Else
                cn.Open()
            End If
            TextBox4.Text = command.ExecuteScalar().ToString()
        Catch ex As Exception

        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim max As Integer
        If ComboBox1.Text = "" Then
            MsgBox("اختر المادة اولاً رجاءاً", MsgBoxStyle.Critical)
        Else
            Try
                Dim sql As String = "Select max(id) from Courses"
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
                Dim sql As String = "INSERT INTO Courses (id,subject,c_level,department,class,teacher,Date,Time)  " _
            & "VALUES ('" & max & "','" & ComboBox1.Text & "','" & ComboBox6.Text & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "','" & DateTimePicker2.Value.ToShortTimeString & "')"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم ادخال البيانات بنجاح", MsgBoxStyle.Information, "!!")
                Courses()
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
            Dim sql As String = "Update Courses set subject='" & ComboBox1.Text & "',c_level='" & ComboBox6.Text & "',department='" & ComboBox5.Text & "',class='" & ComboBox4.Text & "',teacher='" & TextBox4.Text & "' ,Date='" & ComboBox2.Text & "',Time='" & DateTimePicker2.Value.ToShortTimeString & "' where id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم التحديث بنجاح", MsgBoxStyle.Information, "Warning !")
            Courses()
            clear()
            TextBox1.Clear()
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
                Dim DeleteQuery As String = "DELETE FROM Courses WHERE id=" & TextBox1.Text
                Dim sda As New SqlDataAdapter(DeleteQuery, cn)
                Dim com = New SqlCommand(DeleteQuery, cn)
                cn.Open()
                com.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الحذف بنجاح", MsgBoxStyle.Information, "Warning !")
                Courses()
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
    Private Sub sele()
        Try
            Dim sql As String = "select id,subject,c_level,department,class,teacher,name_teacher,Date,Time from Courses,Teacher where id_teacher=teacher and id='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                ComboBox1.Text = reader(1)
                ComboBox6.Text = reader(2)
                ComboBox5.Text = reader(3)

                ComboBox4.Text = reader(4)
                TextBox4.Text = reader(5)
                ComboBox2.Text = reader(7)
                ComboBox3.Text = reader(6)

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clear()
        sele()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        clear()
        sele()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6.Text = "رابع" Then
            ComboBox5.Items.Clear()
            ComboBox5.Items.Add("علمي")
            ComboBox5.Items.Add("ادبي")
        ElseIf ComboBox6.Text = "خامس" Or ComboBox6.Text = "سادس" Then
            ComboBox5.Items.Clear()
            ComboBox5.Items.Add("علمي احيائي")
            ComboBox5.Items.Add("علمي تطبيقي")
            ComboBox5.Items.Add("ادبي")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PrintGridView()
    End Sub
    Private Sub PrintGridView()
        ' Create the PrintDocument object
        Dim pd As New Printing.PrintDocument()

        ' Set the print page event handler
        AddHandler pd.PrintPage, AddressOf PrintGridViewHandler

        ' Set the print preview dialog properties
        Dim ppd As New PrintPreviewDialog()
        ppd.Document = pd
        ppd.WindowState = FormWindowState.Maximized

        ' Show the print preview dialog
        ppd.ShowDialog()
    End Sub

    Private Sub PrintGridViewHandler(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)

        Dim headerText As String = "School Management System - نظام ادارة مدرسة"

        Dim x As Integer = e.MarginBounds.Left
        Dim y As Integer = e.MarginBounds.Top + DataGridView1.ColumnHeadersHeight + 20 ' Add extra space for header

        ' Print the header
        e.Graphics.DrawString(headerText, New Font(DataGridView1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - 50)


        ' Print the column headers
        For Each column As DataGridViewColumn In DataGridView1.Columns
            e.Graphics.DrawString(column.HeaderText, DataGridView1.Font, Brushes.Black, x, y)
            x += column.Width
        Next

        ' Move to the next row
        y += DataGridView1.Rows(0).Height
        x = e.MarginBounds.Left

        ' Print the rows
        For i As Integer = DataGridView1.FirstDisplayedScrollingRowIndex To DataGridView1.Rows.Count - 1
            Dim row As DataGridViewRow = DataGridView1.Rows(i)

            ' Print each cell in the row
            For Each cell As DataGridViewCell In row.Cells
                e.Graphics.DrawString(cell.FormattedValue.ToString(), DataGridView1.Font, Brushes.Black, x, y)
                x += cell.Size.Width
            Next

            ' Move to the next row
            y += row.Height
            x = e.MarginBounds.Left

            ' Check if there is enough space to print another row
            If y + row.Height > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Return
            End If
        Next

        ' If there are no more rows to print, mark the print job as complete
        e.HasMorePages = False
    End Sub


End Class