Imports System.Data.SqlClient

Public Class Total
    Sub GET1()
        Dim sql As String = "select COUNT(*) from Student"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        Label11.Text = command.ExecuteScalar().ToString()
        cn.Close()
    End Sub
    Sub GET2()
        Dim sql As String = "select COUNT(*) from Teacher"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        Label10.Text = command.ExecuteScalar().ToString()
        cn.Close()
    End Sub
    Sub GET3()
        Dim sql As String = "select COUNT(Subject) from Courses"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        Label9.Text = command.ExecuteScalar().ToString()
        cn.Close()
    End Sub
    Sub GET4()
        Dim sql As String = "select sum(salary) from Salary"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        Label8.Text = command.ExecuteScalar().ToString() & " $ "
        cn.Close()
    End Sub
    Sub GET5()
        Dim sql As String = "select sum(money_part1 + money_part2) from Pay"
        Dim command As New SqlCommand(sql, cn)
        cn.Open()
        Label7.Text = command.ExecuteScalar().ToString() & " $ "
        cn.Close()
    End Sub
    Private Sub Total_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GET1()
        GET2()
        GET3()
        GET4()
        GET5()
    End Sub
    Private Sub Label7_TextChanged(sender As Object, e As EventArgs) Handles Label7.TextChanged
        If Label7.Text = "" Then
            Label7.Text = "0 $"
        End If
    End Sub
End Class