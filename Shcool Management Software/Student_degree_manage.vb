Imports System.Data.SqlClient
Imports DGVPrinterHelper

Public Class Student_degree_manage
    Private Sub code(x As String)
        Try
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            cn.Open()
            cmd.Connection = cn
            If (x = "الكل") Then
                cmd.CommandText = "select degree_id as '#',year as 'السنة',course as 'الكورس',subject as 'المادة',degree as 'الدرجة',type as 'الحالة' from Degrees where student='" & TextBox1.Text & "'"
                Label4.Visible = False
                Label6.Visible = False
            ElseIf (x = "نجاح") Then
                cmd.CommandText = "select degree_id as '#',year as 'السنة',course as 'الكورس',subject as 'المادة',degree as 'الدرجة',type as 'الحالة' from Degrees where type='نجاح' and student='" & TextBox1.Text & "'"
            ElseIf (x = "رسوب") Then
                cmd.CommandText = "select degree_id as '#',year as 'السنة',course as 'الكورس',subject as 'المادة',degree as 'الدرجة',type as 'الحالة' from Degrees where type='رسوب' and student='" & TextBox1.Text & "'"
            End If
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
    Private Sub GetData()
        If (CheckBox1.Checked = True) Then
            code("نجاح")
        ElseIf (CheckBox2.Checked = True) Then
            code("رسوب")
        Else
            code("الكل")
        End If
        If (Me.TopMost = True) Then
            Me.TopMost = False
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If (CheckBox1.Checked = True) Then
            CheckBox2.Checked = False
            Label4.Visible = True
            Label6.Visible = False
        End If
        GetData()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If (CheckBox2.Checked = True) Then
            CheckBox1.Checked = False
            Label4.Visible = False
            Label6.Visible = True
        End If
        GetData()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        GetData()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim max As Integer
        Dim type As String = ""
        If (CheckBox1.Checked = True) Then
            type = "نجاح"
        ElseIf (CheckBox2.Checked = True) Then
            type = "رسوب"
        End If

        Try
            Dim sql As String = "Select max(degree_id) from Degrees"
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
            sql = "INSERT INTO Degrees(degree_id,year,course,subject,degree,student,type)  " _
      & "VALUES ('" & max & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox16.Text & "','" & TextBox1.Text & "','" & type & "')"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            With cmd
                cn.Open()
                .ExecuteNonQuery()
                cn.Close()
                MsgBox("تم الاضافة بنجاح", MsgBoxStyle.Information, "!!")
                Button6.Visible = True
            End With
            GetData()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim type As String = ""
        If (CheckBox1.Checked = True) Then
            type = "نجاح"
        ElseIf (CheckBox2.Checked = True) Then
            type = "رسوب"
        End If
        Try
            Dim sql As String = "update Degrees set year='" & ComboBox1.Text & "',course='" & ComboBox2.Text & "',subject='" & ComboBox3.Text & "',degree='" & TextBox16.Text & "',type='" & type & "' where degree_id='" & TextBox2.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم تحديث البيانات بنجاح", MsgBoxStyle.Information, "!!")
            GetData()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If MsgBox("هل انت متاكد من حذف هذه الدرجة ?", MsgBoxStyle.YesNo, "تحذير !!") = DialogResult.Yes Then
                Dim sql As String = "delete from Degrees where degree_id='" & TextBox2.Text & "'"
                Dim sda As New SqlDataAdapter(sql, cn)
                Dim cmd As New SqlCommand(sql, cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                MsgBox("تم حذف الدرجة بنجاح", MsgBoxStyle.Information, "!!")
                GetData()
            ElseIf DialogResult.No Then
                MsgBox("تم الغاء عملية الحذف", MsgBoxStyle.Information, "Warning !")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
    End Sub
    Private Sub clear()
        TextBox16.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        clear()
        Dim y As String = ""
        Try
            Dim sql As String = "select * from Degrees where degree_id ='" & TextBox2.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                ComboBox1.Text = reader(1)
                ComboBox2.Text = reader(2)
                ComboBox3.Text = reader(3)
                TextBox16.Text = reader(4)
                TextBox1.Text = reader(5)
                y = reader(6)
                cn.Close()
            End If
            If (y = "نجاح") Then
                CheckBox1.Checked = True
            ElseIf (y = "رسوب") Then
                CheckBox2.Checked = True
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub Grid_Width()
        DataGridView1.Columns(0).Width = 45 'id
        DataGridView1.Columns(1).Width = 55 'Name
        DataGridView1.Columns(2).Width = 77 'City
        DataGridView1.Columns(3).Width = 110 'Age
        DataGridView1.Columns(4).Width = 65 'Gender
        DataGridView1.Columns(5).Width = 65 'Gender
    End Sub
    Private Sub Student_degree_manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Grid_Width()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.TopMost = False
        Dim Printer = New DGVPrinter
        If CheckBox1.Checked = True Then
            Printer.Title = "تقرير درجات الطلاب - " & Label4.Text
        ElseIf CheckBox2.Checked = True Then
            Printer.Title = "تقرير درجات الطلاب - " & Label6.Text
        Else
            Printer.Title = "تقرير درجات الطلاب"
        End If
        Printer.SubTitle = "-------------------------------------------------"
        Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
        Printer.PageNumbers = True
        Printer.PageNumberInHeader = False
        Printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional
        Printer.HeaderCellAlignment = StringAlignment.Near
        Printer.Footer = "Student Degree"
        Printer.FooterSpacing = 15
        Printer.PrintDataGridView(DataGridView1)
        'Me.TopMost = False
    End Sub
End Class