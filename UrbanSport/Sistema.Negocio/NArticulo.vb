Imports Sistema.Datos
Imports Sistema.Entidades

Public Class NArticulo
    Public Function Listar() As DataTable
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Tabla = Datos.listar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ListarPrecioVenta() As DataTable
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Tabla = Datos.listarPrecioVenta()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Buscar(Valor As String, xtalla As String) As DataTable
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Tabla = Datos.Buscar(Valor, xtalla)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function BuscarVenta(Valor As String, xtalla As String) As DataTable
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Tabla = Datos.BuscarVenta(Valor, xtalla)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function BuscarCodigo(Valor As String, xtalla As String) As Articulo
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Dim Art As New Articulo
            Tabla = Datos.BuscarCodigo(Valor, xtalla)

            If (Tabla.Rows.Count > 0) Then
                Art.IdArticulo = Tabla.Rows(0).Item(0).ToString
                Art.Codigo = Tabla.Rows(0).Item(1).ToString
                Art.Categoria = Tabla.Rows(0).Item(2)
                Art.Marca = Tabla.Rows(0).Item(3).ToString
                Art.Modelo = Tabla.Rows(0).Item(4).ToString
                Art.IdTalla = Tabla.Rows(0).Item(5).ToString
                Art.Talla = Tabla.Rows(0).Item(6).ToString
                Art.PrecioVenta = Tabla.Rows(0).Item(7).ToString
                Art.Stock = Tabla.Rows(0).Item(8).ToString
                Return Art
            Else
                Return Nothing

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function BuscarCodigodetalle(Valor As String, xtalla As String) As Articulo
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Dim Art As New Articulo
            Tabla = Datos.BuscarCodigodetalle(Valor, xtalla)

            If (Tabla.Rows.Count > 0) Then
                Art.IdArticulo = Tabla.Rows(0).Item(0).ToString
                Art.Categoria = Tabla.Rows(0).Item(1).ToString
                Art.Codigo = Tabla.Rows(0).Item(2).ToString
                Art.Marca = Tabla.Rows(0).Item(3).ToString
                Art.Modelo = Tabla.Rows(0).Item(4).ToString
                Art.Talla = Tabla.Rows(0).Item(5).ToString
                Art.PrecioVenta = Tabla.Rows(0).Item(6).ToString
                Art.Stock = Tabla.Rows(0).Item(7).ToString
                Art.Estado = Tabla.Rows(0).Item(8).ToString
                Return Art
            Else
                Return Nothing

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function BuscarCodigoVenta(Valor As String, xtalla As String) As Articulo
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Dim Art As New Articulo
            Tabla = Datos.buscarCodigoVenta(Valor, xtalla)
            If (Tabla.Rows.Count > 0) Then
                Art.IdArticulo = Tabla.Rows(0).Item(0).ToString
                Art.Categoria = Tabla.Rows(0).Item(1).ToString
                Art.Codigo = Tabla.Rows(0).Item(2).ToString
                Art.Marca = Tabla.Rows(0).Item(3).ToString
                Art.Modelo = Tabla.Rows(0).Item(4).ToString
                Art.Talla = Tabla.Rows(0).Item(5).ToString
                Art.Stock = Tabla.Rows(0).Item(6).ToString
                Art.PrecioVenta = Tabla.Rows(0).Item(7).ToString
                Return Art
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Function ConsultaStock(Categoria As String, talla As String) As DataTable
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Tabla = Datos.ConsultaStock(Categoria, talla)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ConsultaStockMarca(marca As String, modelo As String) As DataTable
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Tabla = Datos.ConsultaStockMarca(marca, modelo)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ConsultaMarcaTalla(marca As String, talla As String) As DataTable
        Try
            Dim Datos As New DArticulo
            Dim Tabla As New DataTable
            Tabla = Datos.ConsultaMarcaTalla(marca, talla)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function Insertar(Obj As Articulo) As Boolean
        Try
            Dim Datos As New DArticulo
            Datos.Insertar(Obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Actualizar(Obj As Articulo) As Boolean
        Try
            Dim Datos As New DArticulo
            Datos.Actualizar(Obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Eliminar(Id As Integer) As Boolean
        Try
            Dim Datos As New DArticulo
            Datos.Eliminar(Id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Desactivar(Id As Integer) As Boolean
        Try
            Dim Datos As New DArticulo
            Datos.Desactivar(Id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Activar(id As Integer) As Boolean
        Try
            Dim Datos As New DArticulo
            Datos.Activar(id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
