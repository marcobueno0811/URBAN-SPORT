Imports Sistema.Datos
Imports Sistema.Entidades

Public Class NUsuario
    Public Function Listar() As DataTable
        Try
            Dim Datos As New DUsuario
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
            Dim Datos As New DUsuario
            Dim Tabla As New DataTable
            Tabla = Datos.buscar(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Login(Email As String, Clave As String) As Usuario
        Try
            Dim Usu As New Usuario
            Dim Datos As New DUsuario
            Dim Tabla As New DataTable
            Tabla = Datos.Login(Email, Clave)
            If (Tabla.Rows.Count > 0) Then
                Usu.IdUsuario = Tabla.Rows(0).Item(0).ToString
                Usu.IdRol = Tabla.Rows(0).Item(1).ToString
                Usu.Rol = Tabla.Rows(0).Item(2).ToString
                Usu.Nombre = Tabla.Rows(0).Item(3).ToString
                Usu.Estado = Tabla.Rows(0).Item(4).ToString
                Return Usu
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Insertar(obj As Usuario) As Boolean
        Try
            Dim Datos As New DUsuario
            Datos.Insertar(obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function Actualizar(obj As Usuario) As Boolean
        Try
            Dim Datos As New DUsuario
            Datos.Actualizar(obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        Try
            Dim Datos As New DUsuario
            Datos.Eliminar(id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Desactivar(id As Integer) As Boolean
        Try
            Dim Datos As New DUsuario
            Datos.Desactivar(id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Activar(id As Integer) As Boolean
        Try
            Dim Datos As New DUsuario
            Datos.Activar(id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
