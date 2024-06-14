Imports Sistema.Datos
Imports Sistema.Entidades
Public Class NTalla

    Public Function Listar() As DataTable
        Try
            Dim Datos As New DTalla
            Dim Tabla As New DataTable
            Tabla = Datos.listar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function Seleccionar() As DataTable
        Try
            Dim Datos As New DTalla
            Dim Tabla As New DataTable
            Tabla = Datos.Seleccionar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Insertar(Obj As Talla) As Boolean
        Try
            Dim Datos As New DTalla
            Datos.Insertar(Obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Buscar(talla As String) As DataTable
        Try
            Dim Datos As New DTalla
            Dim Tabla As New DataTable
            Tabla = Datos.buscar(talla)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
