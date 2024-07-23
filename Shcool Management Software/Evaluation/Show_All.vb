Imports System.Data.SqlClient

Public Class Show_All
    Private Sub Show_All_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQL()
    End Sub

    Private Sub SQL()

        Dim sql As String = "select Assess.id as 'التسلسل',Student_Name as 'اسم الطالب',Subject as 'اسم المادة',name_teacher as 'المعلم',Assess.Assess as'التقيم',study_Level as 'المرحلة',department as 'القسم',Class as 'الشعبة',assess.date as 'تاريخ' from student,Assess,Teacher where assess.student=Student_id and assess.teacher=id_teacher"
        Dim dataadapter As New SqlDataAdapter(sql, cn)
            Dim ds As New DataSet()
            cn.Open()
            dataadapter.Fill(ds, "column_name")
            cn.Close()
            DataGridView2.DataSource = ds
        DataGridView2.DataMember = "column_name"
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class