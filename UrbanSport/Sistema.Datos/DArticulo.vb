Imports Sistema.Entidades
Imports System.Data.SqlClient

Public Class DArticulo
    Inherits Conexion

    Public Function listar() As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim Comando As New SqlCommand("articulo_listar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            MyBase.conn.Open()
            Resultado = Comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarPrecioVenta() As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim Comando As New SqlCommand("articulo_precio_venta", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            MyBase.conn.Open()
            Resultado = Comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Buscar(Valor As String, xtalla As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim Comando As New SqlCommand("articulo_Buscar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor
            Comando.Parameters.Add("@Xtalla", SqlDbType.VarChar).Value = xtalla
            MyBase.conn.Open()
            Resultado = Comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function BuscarVenta(Valor As String, xtalla As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim Comando As New SqlCommand("articulo_Buscar_venta", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor
            Comando.Parameters.Add("@Xtalla", SqlDbType.VarChar).Value = xtalla
            MyBase.conn.Open()
            Resultado = Comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarCodigo(Valor As String, Xtalla As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim Comando As New SqlCommand("articulo_Buscar_codigo", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor
            Comando.Parameters.Add("@Xtalla", SqlDbType.VarChar).Value = Xtalla
            MyBase.conn.Open()
            Resultado = Comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function buscarCodigoVenta(Valor As String, xtalla As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("articulo_buscar_codigo_venta", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor
            comando.Parameters.Add("@xtalla", SqlDbType.VarChar).Value = xtalla
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarCodigodetalle(Valor As String, Xtalla As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim Comando As New SqlCommand("articulo_Buscar_detalle", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = Valor
            Comando.Parameters.Add("@Xtalla", SqlDbType.VarChar).Value = Xtalla
            MyBase.conn.Open()
            Resultado = Comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaStock(Categoria As String, talla As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("stock_listar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@xvalor", SqlDbType.VarChar).Value = Categoria
            comando.Parameters.Add("@xvalor2", SqlDbType.VarChar).Value = talla
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaStockMarca(marca As String, modelo As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("marca_modelo_listar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@xvalor", SqlDbType.VarChar).Value = marca
            comando.Parameters.Add("@xvalor2", SqlDbType.VarChar).Value = modelo
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaMarcaTalla(marca As String, modelo As String) As DataTable
        Try
            Dim Resultado As SqlDataReader
            Dim Tabla As New DataTable
            Dim comando As New SqlCommand("marca_talla_listar", MyBase.conn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@xvalor", SqlDbType.VarChar).Value = marca
            comando.Parameters.Add("@xvalor2", SqlDbType.VarChar).Value = modelo
            MyBase.conn.Open()
            Resultado = comando.ExecuteReader()
            Tabla.Load(Resultado)
            MyBase.conn.Close()
            Return Tabla
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Insertar(Obj As Articulo)
        Try
            Dim Comando As New SqlCommand("articulo_insertar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.IdCategoria
            Comando.Parameters.Add("@idtalla", SqlDbType.Int).Value = Obj.IdTalla
            Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Obj.Codigo
            Comando.Parameters.Add("@marca", SqlDbType.VarChar).Value = Obj.Marca
            Comando.Parameters.Add("@modelo", SqlDbType.VarChar).Value = Obj.Modelo
            Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = Obj.PrecioVenta
            Comando.Parameters.Add("@stock", SqlDbType.Int).Value = Obj.Stock
            Comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = Obj.Imagen
            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Actualizar(Obj As Articulo)
        Try
            Dim Comando As New SqlCommand("articulo_actualizar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Obj.IdArticulo
            Comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.IdCategoria
            Comando.Parameters.Add("@idtalla", SqlDbType.Int).Value = Obj.IdTalla
            Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = Obj.Codigo
            Comando.Parameters.Add("@marca", SqlDbType.VarChar).Value = Obj.Marca
            Comando.Parameters.Add("@modelo", SqlDbType.VarChar).Value = Obj.Modelo
            Comando.Parameters.Add("@precio_venta", SqlDbType.Decimal).Value = Obj.PrecioVenta
            Comando.Parameters.Add("@stock", SqlDbType.Int).Value = Obj.Stock
            Comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = Obj.Imagen
            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Eliminar(Id As Integer)
        Try
            Dim Comando As New SqlCommand("articulo_eliminar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Id
            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Desactivar(Id As Integer)
        Try
            Dim Comando As New SqlCommand("articulo_desactivar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Id
            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Activar(Id As Integer)
        Try
            Dim Comando As New SqlCommand("articulo_activar", MyBase.conn)
            Comando.CommandType = CommandType.StoredProcedure
            Comando.Parameters.Add("@idarticulo", SqlDbType.Int).Value = Id
            MyBase.conn.Open()
            Comando.ExecuteNonQuery()
            MyBase.conn.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
