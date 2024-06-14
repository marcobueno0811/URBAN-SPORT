
Imports Sistema.Datos
Imports Sistema.Entidades

Public Class NPersona
    Public Function Listar() As DataTable
        Try
            Dim Datos As New DPersona
            Dim Tabla As New DataTable
            Tabla = Datos.Listar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ListarProveedores() As DataTable
        Try
            Dim Datos As New DPersona
            Dim Tabla As New DataTable
            Tabla = Datos.ListarProveedores()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ListarClientes() As DataTable
        Try
            Dim Datos As New DPersona
            Dim Tabla As New DataTable
            Tabla = Datos.ListarClientes()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Buscar(Valor As String) As DataTable
        Try
            Dim Datos As New DPersona
            Dim Tabla As New DataTable
            Tabla = Datos.buscar(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function BuscarProveedores(Valor As String) As DataTable
        Try
            Dim Datos As New DPersona
            Dim Tabla As New DataTable
            Tabla = Datos.BuscarProveedores(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function BuscarClientes(Valor As String) As DataTable
        Try
            Dim Datos As New DPersona
            Dim Tabla As New DataTable
            Tabla = Datos.BuscarClientes(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Insertar(obj As Persona) As Boolean
        Try
            Dim Datos As New DPersona
            Datos.Insertar(obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function Actualizar(obj As Persona) As Boolean
        Try
            Dim Datos As New DPersona
            Datos.Actualizar(obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        Try
            Dim Datos As New DPersona
            Datos.Eliminar(id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
