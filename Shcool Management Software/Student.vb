Imports System.Data.SqlClient
Imports System.IO
Imports DGVPrinterHelper

Public Class Student
    Private Sub code(X As String)
        Try
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            cn.Open()
            cmd.Connection = cn
            If (X = "full") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student"

                'six

            ElseIf (X = "student_six") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='سادس'"
            ElseIf (X = "student_six_literary") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='سادس' and department='ادبي'"
            ElseIf (X = "student_six_Applied_science") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='سادس' and department='علمي تطبيقي'"
            ElseIf (X = "student_six_Biological_science") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='سادس' and department='علمي احيائي'"

                'five

            ElseIf (X = "student_five") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='خامس'"
            ElseIf (X = "student_five_literary") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='خامس' and department='ادبي'"
            ElseIf (X = "student_five_Applied_science") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='خامس' and department='علمي تطبيقي'"
            ElseIf (X = "student_five_Biological_science") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='خامس' and department='علمي احيائي'"

                'four

            ElseIf (X = "student_fourth") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='رابع'"
            ElseIf (X = "student_fourth_literary") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='رابع' and department='ادبي'"
            ElseIf (X = "student_fourth_science") Then
                cmd.CommandText = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where study_Level='رابع' and department='علمي'"
            End If


            da.SelectCommand = cmd
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            cn.Close()
        Catch ex As Exception
            MsgBox("حدث خطا ما !!", MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Grid_Width()
        DataGridView1.Columns(0).Width = 45 'id
        DataGridView1.Columns(1).Width = 110 'Name
        DataGridView1.Columns(2).Width = 77 'City
        DataGridView1.Columns(3).Width = 55 'Age
        DataGridView1.Columns(4).Width = 65 'Gender
        DataGridView1.Columns(5).Width = 65 'Gender
    End Sub
    Private Sub Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.PerformClick()
        ComboBox2.Items.Add("علمي احيائي")
        ComboBox2.Items.Add("علمي تطبيقي")
        ComboBox2.Items.Add("ادبي")
        'ComboBox2.Items.Add("متوسطة")
        'ComboBox3.Items.Add("مليون")
        'ComboBox3.Items.Add("مليون ونص")
        'ComboBox3.Items.Add("مليونين")
        'ComboBox4.Items.Add("تم الدفع")
        'ComboBox4.Items.Add("مطلوب")
        ComboBox5.Text = "كل الطلاب"
        ComboBox6.Text = "ذكر"
        Grid_Width()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "سادس" Then
            code("student_six")
            ComboBox4.Items.Clear()
            ComboBox4.Items.Add("علمي احيائي")
            ComboBox4.Items.Add("علمي تطبيقي")
            ComboBox4.Items.Add("ادبي")
            TextBox7.Text = "6"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "خامس" Then
            code("student_five")
            ComboBox4.Items.Clear()
            ComboBox4.Items.Add("علمي احيائي")
            ComboBox4.Items.Add("علمي تطبيقي")
            ComboBox4.Items.Add("ادبي")
            TextBox7.Text = "5"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "رابع" Then
            code("student_fourth")
            ComboBox4.Items.Clear()
            ComboBox4.Items.Add("علمي")
            ComboBox4.Items.Add("ادبي")
            TextBox7.Text = "4"
        End If
    End Sub
    Private Sub insert()
        'Dim a As String
        'If ComboBox3.Text = "مليون" Then
        '    a = 1000000
        'ElseIf ComboBox3.Text = "مليون ونص" Then
        '    a = 1500000
        'ElseIf ComboBox3.Text = "مليونين" Then
        '    a = 2000000
        'End If       
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim max As Integer
        Try
            Dim sql As String = "Select max(Student_id) from Student"
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
            Dim sql As String
            Dim ms As New MemoryStream
            If (PictureBox1.Image Is Nothing) Then
                sql = "INSERT INTO Student(Student_id,Student_Name,Gender,study_Level,department,phone,Class)  " _
      & "VALUES ('" & max & "','" & TextBox2.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox5.Text & "','" & ComboBox3.Text & "')"
            Else
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim arrPic() As Byte = ms.GetBuffer()
                sql = "INSERT INTO Student(Student_id,Student_Name,Gender,study_Level,department,phone,Class,image)  " _
      & "VALUES ('" & max & "','" & TextBox2.Text & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox5.Text & "','" & ComboBox3.Text & "',@emPic)"
            End If
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            With cmd
                .Parameters.AddWithValue("@emPic", SqlDbType.Image).Value = ms.ToArray
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الاضافة بنجاح", MsgBoxStyle.Information, "!!")
                Button6.Visible = True
            End With
            code("full")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        If ComboBox5.Text = "أعدادية" Then
            Button1.Text = "سادس"
            Button2.Text = "خامس"
            Button3.Text = "رابع"
            Panel4.Visible = True
            Label12.Visible = True
            ComboBox4.Visible = True
        ElseIf ComboBox5.Text = "كل الطلاب" Then
            code("full")
            Panel4.Visible = False
            Label12.Visible = False
            ComboBox4.Visible = False
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim sql As String = "update Student set Student_Name='" & TextBox2.Text & "',Gender='" & ComboBox6.Text & "',study_Level='" & ComboBox1.Text & "',department='" & ComboBox2.Text & "',phone='" & TextBox5.Text & "',Class='" & ComboBox3.Text & "' where Student_id='" & TextBox1.Text & "'"
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            If (PictureBox1.Image Is Nothing) Then
            Else
                upate_image()
            End If

            MsgBox("تم تحديث صوره الطالب بنجاح", MsgBoxStyle.Information, "!!")
            code("full")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub upate_image()
        Try
            Dim ms As New MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim arrPic() As Byte = ms.GetBuffer()
            Dim command As New SqlCommand("update Student set image=@emPic where Student_id='" & TextBox1.Text & "'", cn)
            With command
                .Parameters.AddWithValue("@emPic", SqlDbType.Image).Value = ms.ToArray
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذا الطالب ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                Dim sql As String = "delete from Student where Student_id='" & TextBox1.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم حذف البيانات بنجاح", MsgBoxStyle.Information, "!!")
                code("full")
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "Warning !")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear()
        'TextBox1.Clear()
        TextBox2.Clear()
        TextBox5.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox6.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim x = TextBox1.Text
        clear()
        PictureBox1.Image = Nothing
        TextBox1.Text = x
        Try
            Dim sql As String = "select * from Student where Student_id ='" & TextBox1.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(1)
                ComboBox6.Text = reader(2)
                'TextBox4.Text = reader(3)
                ComboBox1.Text = reader(4)
                ComboBox2.Text = reader(5)
                TextBox5.Text = reader(7)
                ComboBox3.Text = reader(8)
                cn.Close()
                img()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub img()
        Try
            Dim cmd As New SqlCommand("select image from Student where Student_id='" & TextBox1.Text & "'", cn)
            cn.Open()
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            cn.Close()
            PictureBox1.Image = Image.FromStream(ImgStream)
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        FilterData(TextBox6.Text)
    End Sub
    Public Sub FilterData(valueToSearch As String)
        If TextBox6.Text = "" Then
            code("full")
        Else
            Dim searchQuery As String = "select Student_id as '#',Student_Name as 'اسم الطالب',department as 'القسم',study_Level as 'المرحلة',Class as 'الشعبة',Gender as 'الجنس'from Student where CONCAT(Student_id,Student_Name,Class) like '%" & valueToSearch & "%'"
            Dim command As New SqlCommand(searchQuery, cn)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim x = ComboBox4.Text
        If (TextBox7.Text = "4") Then
            If (x = "علمي") Then
                code("student_fourth_science")
            ElseIf (x = "ادبي") Then
                code("student_fourth_literary")
            End If
        ElseIf (TextBox7.Text = "5") Then
            If (x = "علمي احيائي") Then
                code("student_five_Biological_science")
            ElseIf (x = "علمي تطبيقي") Then
                code("student_five_Applied_science")
            ElseIf (x = "ادبي") Then
                code("student_five_literary")
            End If
        ElseIf (TextBox7.Text = "6") Then
            If (x = "علمي احيائي") Then
                code("student_six_Biological_science")
            ElseIf (x = "علمي تطبيقي") Then
                code("student_six_Applied_science")
            ElseIf (x = "ادبي") Then
                code("student_six_literary")
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()
        If ComboBox1.Text = "رابع" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("علمي")
            ComboBox2.Items.Add("ادبي")
        ElseIf ComboBox1.Text = "خامس" Or ComboBox1.Text = "سادس" Then
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("علمي احيائي")
            ComboBox2.Items.Add("علمي تطبيقي")
            ComboBox2.Items.Add("ادبي")
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim form As New Student_insert
        If (PictureBox1.Image Is Nothing) Then
            form.Label1.Visible = True
        Else
            Try
                form.PictureBox1.Image = PictureBox1.Image
            Catch ex As Exception
                'MsgBox(ex.Message)
            Finally
                cn.Close()
            End Try
        End If
        form.TextBox1.Text = TextBox2.Text
        form.TextBox16.Text = TextBox1.Text
        form.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With OpenFileDialog1
            'المكان الافتراضي
            .InitialDirectory = Application.StartupPath & "\images"
            'فلاتر امتداد الملفات
            .Filter = "JPEG Files|*.jpg|AllFiles|*.*"
            .FilterIndex = 1
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
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
