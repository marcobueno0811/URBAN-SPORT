Imports Sistema.Datos
Imports Sistema.Entidades

Public Class NVenta
    Public Function Listar() As DataTable
        Try
            Dim Datos As New DVenta
            Dim Tabla As New DataTable
            Tabla = Datos.Listar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Buscar(Valor As String) As DataTable
        Try
            Dim Datos As New DVenta
            Dim Tabla As New DataTable
            Tabla = Datos.buscar(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ConsultaFechas(FechaInicio As Date, FechaFin As Date) As DataTable
        Try
            Dim Datos As New DVenta
            Dim Tabla As New DataTable
            Tabla = Datos.ConsultaFechas(FechaInicio, FechaFin)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function Seleccionar() As DataTable
        Try
            Dim Datos As New DVenta
            Dim Tabla As New DataTable
            Tabla = Datos.Seleccionar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ListarDetalle(Id As Integer) As DataTable
        Try
            Dim Datos As New DVenta
            Dim Tabla As New DataTable
            Tabla = Datos.ListarDetalle(Id)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Insertar(obj As Venta, Det As DataTable) As Boolean
        Try
            Dim Datos As New DVenta
            Datos.Insertar(obj, Det)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function Anular(id As Integer) As Boolean
        Try
            Dim Datos As New DVenta
            Datos.Anular(id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Actualizar(Obj As Venta) As Boolean
        Try
            Dim Datos As New DVenta
            Datos.Actualizar(Obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
