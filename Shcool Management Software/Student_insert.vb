Imports System.Data.SqlClient

Public Class Student_insert
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Student_degree_manage.Show()
        Student_degree_manage.TextBox1.Text = TextBox16.Text
        Student_degree_manage.Label7.Text = "اسم الطالب : " + TextBox1.Text
        Me.Close()
        Student_degree_manage.TopMost = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim sql As String = "update Student set Student_Name='" & TextBox1.Text & "',Guardian='" & TextBox2.Text & "',Neighborhood='" & TextBox3.Text & "',Mahalla='" & TextBox4.Text & "',Alley_and_number='" & TextBox5.Text & "',hometown='" & TextBox6.Text & "',Birthday='" & DateTimePicker1.Value.Date.ToShortDateString & "',Nationality='" & TextBox7.Text & "',identity_number='" & TextBox8.Text & "',record='" & TextBox9.Text & "',page='" & TextBox10.Text & "',Civil_Status='" & TextBox11.Text & "',Old_school='" & TextBox12.Text & "',city='" & TextBox13.Text & "',Recruitment_Department='" & TextBox14.Text & "',Transfer_document_total='" & TextBox15.Text & "',Document_date='" & DateTimePicker2.Value.Date.ToShortDateString & "' where Student_id='" & TextBox16.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم تحديث بيانات الطالب بنجاح", MsgBoxStyle.Information, "!!")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        DateTimePicker1.Value = Now.Date
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        DateTimePicker2.Value = Now.Date
    End Sub
    Private Sub TextBox16_TextChanged(sender As Object, e As EventArgs) Handles TextBox16.TextChanged
        Dim x = TextBox16.Text
        clear()
        TextBox16.Text = x
        Try
            Dim sql As String = "select Guardian,Neighborhood,Mahalla,Alley_and_number,hometown,Birthday,Nationality,identity_number,record,page,Civil_Status,Old_school,city,Recruitment_Department,Transfer_document_total,Document_date from Student where Student_id ='" & TextBox16.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox2.Text = reader(0)
                TextBox3.Text = reader(1)
                TextBox4.Text = reader(2)
                TextBox5.Text = reader(3)
                TextBox6.Text = reader(4)
                TextBox7.Text = reader(6)
                TextBox8.Text = reader(7)
                TextBox9.Text = reader(8)
                TextBox10.Text = reader(9)
                TextBox11.Text = reader(10)
                TextBox12.Text = reader(11)
                TextBox13.Text = reader(12)
                TextBox14.Text = reader(13)
                TextBox15.Text = reader(14)
                '------------------------ date
                DateTimePicker1.Value = reader(5)
                DateTimePicker2.Value = reader(15)
                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim report As New Report_Student
        'Dim tool As ReportPrintTool = New ReportPrintTool(report)
        'report.XrLabel1.Text = TextBox1.Text
        'report.CreateDocument()
        'report.ShowPreview()
        '-------------
        Student_Print.Show()
        Student_Print.PictureBox1.Image = Me.PictureBox1.Image
        Student_Print.Label3.Text = "اسم الطالب الرباعي واللقب : " & Me.TextBox1.Text
        Student_Print.Label1.Text = "اسم ولي الامر : " & Me.TextBox2.Text
        Student_Print.Label4.Text = "الحي : " & Me.TextBox3.Text
        Student_Print.Label5.Text = "المحلة : " & Me.TextBox4.Text
        Student_Print.Label6.Text = "الزقاق ورقم الدار : " & Me.TextBox5.Text

        Student_Print.Label7.Text = "مسقط رأس الطالب : " & Me.TextBox6.Text
        Student_Print.Label8.Text = "تاريخ الولادة : " & Me.DateTimePicker1.Value.ToString
        Student_Print.Label9.Text = "الجنسية : " & Me.TextBox7.Text

        Student_Print.Label10.Text = "رقم الهوية : " & Me.TextBox8.Text
        Student_Print.Label11.Text = "السجل : " & Me.TextBox9.Text
        Student_Print.Label12.Text = "الصفحة : " & Me.TextBox10.Text


        Student_Print.Label13.Text = "اسم دائرة الاحوال المدنية : " & Me.TextBox11.Text
        Student_Print.Label14.Text = "المدرسة التي انتقل منها : " & Me.TextBox12.Text
        Student_Print.Label15.Text = "المحافظة : " & Me.TextBox13.Text
        Student_Print.Label16.Text = "اسم دائرة التجنيد : " & Me.TextBox14.Text
        Student_Print.Label17.Text = "عدد وثيقة الانتقال : " & Me.TextBox15.Text
        Student_Print.Label18.Text = "تاريخ وثيقة : " & Me.DateTimePicker2.Value.ToString




    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage


        'Dim font1 As New Font("arial", 16, FontStyle.Regular)
        'e.Graphics.DrawString("RichTextBox1.Text", font1, Brushes.Black, 100, 100)

        'Dim image As New Bitmap(panel1.width, panel1.height)
        'panel1.drawtobutmap(image, New Rectangle(Point.Empty, panel1.size))
        'e.Graphics.DrawImage(image, New Point(0, 0))


        '----------



        ''e.Graphics.DrawImage(Bitmap, 120, 30)
        'Dim printview As RectangleF = e.PageSettings.PrintableArea
        ''If Me.DataGridView3.Height - printview.Height > 0 Then
        ''    e.HasMorePages = True
        ''End If
        'e.HasMorePages = True
        ''كود فاشل
        ''Dim c1 = DataGridView1.CurrentCell.RowIndex
        ''e.Graphics.DrawString(DataGridView1.Item(DataGridView.cell.headertext, c1).Value.tostring, SystemFonts.DefaultFont, Brushes.Black, 300, 200)

        'Dim margin As Single = 40
        'Dim marginBetween As Single = 5
        'Dim currentTop As Single = margin

        'Dim fnt As New Font("Tahoma", 14, FontStyle.Bold)
        'Dim fnt2 As New Font("Tahoma", 12, FontStyle.Regular)
        'Dim p_fnt As New Font("Tahoma", 16, FontStyle.Bold)

        'Dim strNo As String = "#NO " & Label19.Text
        'Dim strDate As String = "التاريخ: " & Now.ToString
        'Dim strName As String = "أسم العميل: " & TextBox7.Text
        'Dim com As String = "Warehouse Management System"


        'Dim Company As SizeF = e.Graphics.MeasureString(com, fnt)



        'Dim fontsizeNo As SizeF = e.Graphics.MeasureString(strNo, fnt)
        'Dim fontsizeDate As SizeF = e.Graphics.MeasureString(strDate, fnt)
        'Dim fontsizeName As SizeF = e.Graphics.MeasureString(strName, fnt)
        'e.Graphics.DrawImage(PictureBox1.Image, 3, 3, 200, 200)



        'e.Graphics.DrawString(com, fnt, Brushes.Teal, (e.PageBounds.Width - Company.Width) - 35, 52)
        'currentTop += Company.Height + marginBetween

        'e.Graphics.DrawString(strNo, fnt2, Brushes.Black, (e.PageBounds.Width - fontsizeNo.Width) / 3, 0)
        'currentTop += fontsizeNo.Height + marginBetween
        'e.Graphics.DrawString(strDate, fnt, Brushes.Red, e.PageBounds.Width - fontsizeDate.Width - margin, currentTop)
        'currentTop += fontsizeDate.Height + marginBetween
        'e.Graphics.DrawString(strName, fnt, Brushes.Navy, e.PageBounds.Width - fontsizeName.Width - margin, currentTop)
        'currentTop += fontsizeName.Height + marginBetween + 40
        'e.Graphics.DrawRectangle(Pens.Black, margin, currentTop, e.PageBounds.Width - margin * 2, e.PageBounds.Height - currentTop - margin)
        'currentTop += marginBetween

        'Dim colHight As Single = 40

        'Dim col1Width As Single = 300
        'Dim col2Width As Single = 125 + col1Width
        'Dim col3Width As Single = 125 + col2Width
        'Dim col4Width As Single = 125 + col3Width

        'e.Graphics.DrawLine(Pens.Black, margin, currentTop + colHight, e.PageBounds.Width - margin, currentTop + colHight)

        'e.Graphics.DrawString("الصنف", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col1Width / 2), currentTop)
        'e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col1Width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col1Width, e.PageBounds.Height - margin)

        'e.Graphics.DrawString("الكمية", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col2Width - 40), currentTop)
        'e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col2Width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col2Width, e.PageBounds.Height - margin)

        'e.Graphics.DrawString("السعر", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - (col3Width - 40), currentTop)
        'e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col3Width, currentTop - marginBetween, e.PageBounds.Width - margin * 2 - col3Width, e.PageBounds.Height - margin)

        'e.Graphics.DrawString("اجمالي فرعي", fnt, Brushes.Black, e.PageBounds.Width - margin * 2 - 22 - (col4Width - 3), currentTop)

        ''----------------------------------------------

        'Dim rowHeight As Single = 55

        ''For x = 0 To DataGridView3.Rows.Count - 1

        ''    e.Graphics.DrawString(DataGridView3.Rows(x).Cells(0).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col1Width + 20, currentTop + rowHeight + 5)
        ''    e.Graphics.DrawString(DataGridView3.Rows(x).Cells(1).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col2Width + 40, currentTop + rowHeight + 5)
        ''    e.Graphics.DrawString(DataGridView3.Rows(x).Cells(2).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col3Width + 10, currentTop + rowHeight + 5)
        ''    e.Graphics.DrawString(DataGridView3.Rows(x).Cells(3).Value.ToString(), p_fnt, Brushes.Navy, e.PageBounds.Width - margin * 2 - col4Width + 10, currentTop + rowHeight + 5)

        ''    e.Graphics.DrawLine(Pens.Black, margin, currentTop + rowHeight + colHight, e.PageBounds.Width - margin, currentTop + rowHeight + colHight)

        ''    rowHeight += 55
        ''Next
        'e.Graphics.DrawString("الأجمالي", fnt, Brushes.Red, e.PageBounds.Width - margin * 2 - col3Width + 10, currentTop + rowHeight)
        'e.Graphics.DrawString(TextBox6.Text, fnt, Brushes.Blue, e.PageBounds.Width - margin * 2 - col4Width + 10, currentTop + rowHeight)
        'e.Graphics.DrawLine(Pens.Black, margin, currentTop + rowHeight + colHight, e.PageBounds.Width - margin, currentTop + rowHeight + colHight)

    End Sub

End Class