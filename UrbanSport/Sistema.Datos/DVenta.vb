Imports System.Data.SqlClient
Imports Sistema.Entidades
Public Class DVenta
    Inherits Conexion
    Public Function Listar() As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("venta_listar", MyBase.conn)
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
            Dim comando As New SqlCommand("venta_buscar", MyBase.conn)
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

    Public Function ConsultasFechas(FechaInicio As Date, FechaFin As Date) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("venta_consulta_fechas", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@fexha_inicio", SqlDbType.VarChar).Value = FechaInicio
            comando.Parameters.Add("@fexha_final", SqlDbType.VarChar).Value = FechaFin
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Seleccionar() As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("venta_seleccionar", MyBase.conn)
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

    Public Function ConsultaFechas(FechaInicio As Date, FechaFin As Date) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("venta_consulta_fechas", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@fecha_inicio", SqlDbType.Date).Value = FechaInicio
            comando.Parameters.Add("@fecha_fin", SqlDbType.Date).Value = FechaFin
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
            Dim comando As New SqlCommand("venta_listar_detalle", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idventa", SqlDbType.Int).Value = Id
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

            Dim comando As New SqlCommand("venta_anular", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idventa", SqlDbType.Int).Value = id
            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insertar(obj As Venta, Det As DataTable)
        Try

            Dim comando As New SqlCommand("venta_insertar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@idventa", SqlDbType.Int).Value = obj.IdVenta
            comando.Parameters("@idventa").Direction = ParameterDirection.Output
            comando.Parameters.Add("@idusuario", SqlDbType.Int).Value = obj.IdUsuario
            comando.Parameters.Add("@idcliente", SqlDbType.Int).Value = obj.IdCliente
            comando.Parameters.Add("@idTipo_Venta", SqlDbType.Int).Value = obj.IdTipo_Venta
            comando.Parameters.Add("@Tipo_comprobante", SqlDbType.VarChar).Value = obj.TipoComprobante
            comando.Parameters.Add("@serie_comprobante", SqlDbType.VarChar).Value = obj.SerieComprobante
            comando.Parameters.Add("@num_comprobante", SqlDbType.VarChar).Value = obj.NumComprobante
            comando.Parameters.Add("@impuesto", SqlDbType.Decimal).Value = obj.Impuesto
            comando.Parameters.Add("@Sub_Total", SqlDbType.Decimal).Value = obj.SubTotal
            comando.Parameters.Add("@A_Cuenta", SqlDbType.Decimal).Value = obj.A_Cuenta
            comando.Parameters.Add("@saldo", SqlDbType.Decimal).Value = obj.Saldo
            comando.Parameters.Add("@total", SqlDbType.Decimal).Value = obj.Total
            comando.Parameters.Add("@detalle", SqlDbType.Structured).Value = Det


            MyBase.conn.Open()
            comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Actualizar(Obj As Venta)
        Try
            Dim Comando As New SqlCommand("venta_actualizar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@idventa", SqlDbType.Int).Value = Obj.IdVenta
            Comando.Parameters.Add("@idTipo_Venta", SqlDbType.Int).Value = Obj.IdTipo_Venta
            Comando.Parameters.Add("@A_Cuenta", SqlDbType.Int).Value = Obj.A_Cuenta
            Comando.Parameters.Add("@saldo", SqlDbType.VarChar).Value = Obj.Saldo

            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
