Imports System.Data.SqlClient

Module SQL
    'Public cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Shcool Management System.mdf;Integrated Security=True;Connect Timeout=30")
    Public cn As New SqlConnection("Data Source=.\SQLEXPRESS; Initial Catalog=Shcool Management System ;Integrated Security=True")
End Module
