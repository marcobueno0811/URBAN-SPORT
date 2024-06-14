Imports System.Data.SqlClient
Imports Sistema.Entidades

Public Class DUsuario
    Inherits Conexion

    Public Function Listar() As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("usuario_listar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function buscar(Valor As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("usuario_buscar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Login(Email As String, Clave As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("usuario_login", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Email
            comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = Clave
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Sub Insertar(obj As Usuario)
        Try

            Dim comando As New SqlCommand("usuario_insertar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idrol", SqlDbType.Int).Value = obj.IdRol
            comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre
            comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = obj.TipoDocumento
            comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = obj.NumDocumento
            comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion
            comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = obj.Telefono
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email
            comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.Clave
            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Actualizar(obj As Usuario)
        Try

            Dim comando As New SqlCommand("usuario_actualizar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = obj.IdUsuario
            comando.Parameters.Add("@idrol", SqlDbType.Int).Value = obj.IdRol
            comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre
            comando.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = obj.TipoDocumento
            comando.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = obj.NumDocumento
            comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = obj.Direccion
            comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = obj.Telefono
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Email
            comando.Parameters.Add("@clave", SqlDbType.VarChar).Value = obj.Clave
            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar(Id As Integer)
        Try

            Dim comando As New SqlCommand("usuario_eliminar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id
            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub Desactivar(id As Integer)
        Try

            Dim comando As New SqlCommand("usuario_desactivar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = id
            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Activar(id As Integer)
        Try

            Dim comando As New SqlCommand("usuario_activar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = id
            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
