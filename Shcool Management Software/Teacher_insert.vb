Imports System.Data.SqlClient

Public Class Teacher_insert
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim sql As String = "update Teacher set Graduate='" & ComboBox1.Text & "',university='" & TextBox1.Text & "',college='" & TextBox2.Text & "',Mother_name='" & TextBox3.Text & "',wife_name='" & TextBox4.Text & "',wife_profession='" & TextBox5.Text & "',number_of_children='" & TextBox6.Text & "',Date_of_marriage='" & DateTimePicker2.Value.Date.ToShortDateString & "',Date_and_order_of_the_first_appointment='" & DateTimePicker1.Value.Date.ToShortDateString & "',Date_and_first_order_directly='" & DateTimePicker3.Value.Date.ToShortDateString & "',At_the_current_school='" & DateTimePicker4.Value.Date.ToShortDateString & "',Jurisdiction='" & TextBox7.Text & "',National_ID_number='" & TextBox8.Text & "',National_ID_date='" & DateTimePicker5.Value.Date.ToShortDateString & "',Residence_card_number='" & TextBox9.Text & "',Residence_card_date='" & DateTimePicker6.Value.Date.ToShortDateString & "',ration_card_number='" & TextBox10.Text & "',ration_card_date='" & DateTimePicker7.Value.Date.ToShortDateString & "',Agent_name='" & TextBox11.Text & "',Center_number='" & TextBox12.Text & "',Center_name='" & TextBox13.Text & "',MasterCard='" & TextBox14.Text & "',Graduation_Year='" & TextBox15.Text & "',average='" & TextBox16.Text & "',teacher_status='" & ComboBox2.Text & "',Thanks_Books='" & TextBox17.Text & "',A_special_place_1='" & TextBox18.Text & "',A_special_place_2='" & TextBox19.Text & "' where id_teacher='" & TextBox20.Text & "'"
            Dim sda As New SqlDataAdapter(sql, cn)
            Dim cmd As New SqlCommand(sql, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            MsgBox("تم تحديث بيانات المعلم بنجاح", MsgBoxStyle.Information, "!!")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "!!")
        Finally
            cn.Close()
        End Try
    End Sub
    Private Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox17.Clear()
        TextBox18.Clear()
        TextBox19.Clear()
        DateTimePicker1.Value = Now.Date
        DateTimePicker2.Value = Now.Date
        DateTimePicker3.Value = Now.Date
        DateTimePicker4.Value = Now.Date
        DateTimePicker5.Value = Now.Date
        DateTimePicker6.Value = Now.Date
        DateTimePicker7.Value = Now.Date
    End Sub
    Private Sub TextBox20_TextChanged(sender As Object, e As EventArgs) Handles TextBox20.TextChanged
        clear()
        Try
            Dim sql As String = "select Graduate,university,college,Mother_name,wife_name,wife_profession,number_of_children,Date_of_marriage,Date_and_order_of_the_first_appointment,Date_and_first_order_directly,At_the_current_school,Jurisdiction,National_ID_number,National_ID_date,Residence_card_number,Residence_card_date,ration_card_number,ration_card_date,Agent_name,Center_number,Center_name,MasterCard,Graduation_Year,average,teacher_status,Thanks_Books,A_special_place_1,A_special_place_2 from Teacher where id_teacher ='" & TextBox20.Text & "'"
            Dim com As SqlCommand = New SqlCommand(sql, cn)
            cn.Open()
            Dim reader As SqlDataReader = com.ExecuteReader
            reader.Read()
            If reader.HasRows Then
                TextBox1.Text = reader(1)
                TextBox2.Text = reader(2)

                TextBox3.Text = reader(3)
                TextBox4.Text = reader(4)
                TextBox5.Text = reader(5)
                TextBox6.Text = reader(6)



                TextBox7.Text = reader(11)
                TextBox8.Text = reader(12)


                TextBox9.Text = reader(14)


                TextBox10.Text = reader(16)


                TextBox11.Text = reader(18)
                TextBox12.Text = reader(19)
                TextBox13.Text = reader(20)
                TextBox14.Text = reader(21)
                TextBox15.Text = reader(22)
                TextBox16.Text = reader(23)
                TextBox17.Text = reader(25)
                TextBox18.Text = reader(26)
                TextBox19.Text = reader(27)

                ComboBox1.Text = reader(0)
                ComboBox2.Text = reader(24)


                DateTimePicker5.Text = reader(13)
                DateTimePicker6.Text = reader(15)
                DateTimePicker2.Value = reader(7)
                DateTimePicker1.Value = reader(8)
                DateTimePicker3.Value = reader(9)
                DateTimePicker4.Value = reader(10)
                DateTimePicker7.Text = reader(17)


                cn.Close()
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            cn.Close()
        End Try
    End Sub
End Class