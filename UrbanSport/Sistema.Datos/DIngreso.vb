Imports System.Data.SqlClient
Imports Sistema.Entidades


Public Class DIngreso

    Inherits Conexion
    Public Function Listar() As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("ingreso_listar", MyBase.conn)
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
            Dim comando As New SqlCommand("ingreso_buscar", MyBase.conn)
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

    Public Function ListarDetalle(Id As Integer) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("ingreso_listar_detalle", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idingreso", SqlDbType.Int).Value = Id
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Anular(id As Integer)
        Try

            Dim comando As New SqlCommand("ingreso_anular", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idingreso", SqlDbType.Int).Value = id
            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insertar(obj As Ingreso, Det As DataTable)
        Try

            Dim comando As New SqlCommand("ingreso_insertar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idingreso", SqlDbType.Int).Value = obj.IdIngreso
            comando.Parameters("@idingreso").Direction = ParameterDirection.Output
            comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = obj.IdUsuario
            comando.Parameters.Add("@idproveedor", SqlDbType.Int).Value = obj.IdProveedor
            comando.Parameters.Add("@Tipo_comprobante", SqlDbType.VarChar).Value = obj.TipoComprobante
            comando.Parameters.Add("@serie_comprobante", SqlDbType.VarChar).Value = obj.SerieComprobante
            comando.Parameters.Add("@num_comprobante", SqlDbType.VarChar).Value = obj.NumComprobante
            comando.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = obj.Impuesto
            comando.Parameters.Add("@total", SqlDbType.Decimal).Value = obj.Total
            comando.Parameters.Add("@detalle", SqlDbType.Structured).Value = Det


            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

