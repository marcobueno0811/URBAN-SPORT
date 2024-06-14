Imports System.Data.SqlClient

Public Class Conexion

    Public conn As SqlConnection



    Public Sub New()

        Me.conn = New SqlConnection("Data Source=DESKTOP-9UMOURE\SQLEXPRESS;Initial Catalog=dburban;User ID=sa;Password=180812;TrustServerCertificate=True")

    End Sub


End Class
