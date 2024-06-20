Imports System.IO

Public Class FrmVenta
    Private DtDetalle As New DataTable
    Private RutaOrigen As String
    Private RutaDestino As String
    Private Directorio As String = "c:\imagenes\"

    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(2).Visible = False
        DgvListado.Columns(9).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 30
        DgvListado.Columns(3).Width = 180
        DgvListado.Columns(4).Width = 180
        DgvListado.Columns(5).Width = 100
        DgvListado.Columns(6).Width = 100
        DgvListado.Columns(7).Width = 80
        DgvListado.Columns(8).Width = 80
        DgvListado.Columns(10).Width = 100
        DgvListado.Columns(11).Width = 75
        DgvListado.Columns(12).Width = 75
        DgvListado.Columns(13).Width = 75
        DgvListado.Columns(14).Width = 75
        DgvListado.Columns(15).Width = 100


        DgvListado.Columns.Item("Seleccionar").Visible = False

        BtnAnular.Visible = False
        ChkSeleccionar.CheckState = False
    End Sub

    Private Sub FormatoArticulos()
        DgvArticulos.Columns(0).Visible = False
        DgvArticulos.Columns(1).Visible = False
        DgvArticulos.Columns(6).Visible = False
        DgvArticulos.Columns(10).Visible = False
        DgvArticulos.Columns(11).Visible = False
        DgvArticulos.Columns(2).Width = 100
        DgvArticulos.Columns(3).Width = 100
        DgvArticulos.Columns(4).Width = 150
        DgvArticulos.Columns(5).Width = 150
        DgvArticulos.Columns(7).Width = 80
        DgvArticulos.Columns(8).Width = 150
        DgvArticulos.Columns(9).Width = 100
        DgvArticulos.Columns(10).Width = 100 'imagen
        DgvArticulos.Columns(11).Width = 100

    End Sub

    Private Sub FormatoListaVenta()
        DgvMostrarDetalle.Columns(10).Visible = False
        DgvMostrarDetalle.Columns(0).Width = 50
        DgvMostrarDetalle.Columns(1).Width = 50
        DgvMostrarDetalle.Columns(2).Width = 100
        DgvMostrarDetalle.Columns(3).Width = 120
        DgvMostrarDetalle.Columns(4).Width = 100
        DgvMostrarDetalle.Columns(5).Width = 70
        DgvMostrarDetalle.Columns(6).Width = 80
        DgvMostrarDetalle.Columns(7).Width = 80
        DgvMostrarDetalle.Columns(8).Width = 100
        DgvMostrarDetalle.Columns(9).Width = 100
    End Sub
    Private Sub Limpiar()
        BtnInsertar.Visible = True
        BtnActualizar.Visible = False
        BtnActualizar_Venta.Visible = False
        TxtValor.Text = ""
        TxtId.Text = ""
        TxtCodigo.Text = ""
        TxtIdCliente.Text = ""
        TxtNombreCliente.Text = ""
        TxtSerieComprobante.Text = ""
        TxtNumComprobante.Text = ""
        DtDetalle.Clear()
        TxtSubTotal.Text = 0
        TxtTotalImpuesto.Text = 0
        TxtTotal.Text = 0
        TxtA_cuenta.Text = 0
        TxtSaldo.Text = 0
        TxtA_cuenta.Enabled = True

    End Sub

    Private Sub Listar()
        Try
            Dim Neg As New Negocio.NVenta
            DgvListado.DataSource = Neg.Listar()
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
            Me.Limpiar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FrmVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Listar()
        Me.CrearTablaDetalle()
        Me.CargarVenta()
        Me.tipo_venta()

    End Sub

    Private Sub tipo_venta()


        If Me.CboTipo_Venta.Text = "CONTADO" Then
            TxtA_cuenta.Visible = False
            TxtSaldo.Visible = False
            Lcuenta.Visible = False
            Lsaldo.Visible = False

        ElseIf Me.CboTipo_Venta.Text = "CREDITO" Then
            TxtA_cuenta.Visible = True
            TxtSaldo.Visible = True
            Lcuenta.Visible = True
            Lsaldo.Visible = True
        End If
    End Sub

    Private Sub CargarVenta()

        Try
            Dim Neg As New Negocio.NVenta
            CboTipo_Venta.DataSource = Neg.Seleccionar
            CboTipo_Venta.ValueMember = "idTipo_Venta"
            CboTipo_Venta.DisplayMember = "Tipo"
            If Me.CboTipo_Venta.SelectedText = "CONTADO" Then
                TxtA_cuenta.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles BtnBuscarArticulo.Click
        PanelArticulos.Visible = True
    End Sub
    Private Sub Buscar()
        Try
            Dim Neg As New Negocio.NVenta
            Dim Valor As String
            Valor = TxtValor.Text
            DgvListado.DataSource = Neg.Buscar(Valor)
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub BtnBuscarCliente_Click(sender As Object, e As EventArgs) Handles BtnBuscarCliente.Click
        FrmCliente_Venta.ShowDialog()
        TxtIdCliente.Text = Variables.IdCliente
        TxtNombreCliente.Text = Variables.NombreCliente
        TxtSerieComprobante.Focus()
    End Sub

    Private Sub TxtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodigo.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Try
                Dim Neg As New Negocio.NArticulo
                Dim Obj As New Entidades.Articulo
                Obj = Neg.BuscarCodigoVenta(TxtCodigo.Text, TxtTalla.Text)
                If (Obj Is Nothing) Then
                    MsgBox("No existe articulo con ese codigo de barras", vbOKOnly + vbCritical, "No existe articulo")
                Else
                    Me.AgregarDetalle(Obj)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub CrearTablaDetalle()
        Me.DtDetalle = New DataTable("Detalle")
        Me.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"))
        Me.DtDetalle.Columns.Add("codigo", System.Type.GetType("System.String"))
        Me.DtDetalle.Columns.Add("categoria", System.Type.GetType("System.String"))
        Me.DtDetalle.Columns.Add("marca", System.Type.GetType("System.String"))
        Me.DtDetalle.Columns.Add("modelo", System.Type.GetType("System.String"))
        Me.DtDetalle.Columns.Add("idtalla", System.Type.GetType("System.Int32"))
        Me.DtDetalle.Columns.Add("talla", System.Type.GetType("System.String"))
        Me.DtDetalle.Columns.Add("stock", System.Type.GetType("System.Int32"))
        Me.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"))
        Me.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"))
        Me.DtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"))
        Me.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"))
        Me.DtDetalle.Columns.Add("imagen", System.Type.GetType("System.String"))

        DgvDetalle.DataSource = Me.DtDetalle
        DgvDetalle.Columns(0).Visible = False
        DgvDetalle.Columns(5).Visible = False
        DgvDetalle.Columns(12).Visible = False
        DgvDetalle.Columns(1).HeaderText = "CODIGO"
        DgvDetalle.Columns(1).Width = 100
        DgvDetalle.Columns(2).HeaderText = "CATEGORIA"
        DgvDetalle.Columns(2).Width = 100
        DgvDetalle.Columns(3).HeaderText = "MARCA"
        DgvDetalle.Columns(3).Width = 100
        DgvDetalle.Columns(4).HeaderText = "MODELO"
        DgvDetalle.Columns(4).Width = 180
        DgvDetalle.Columns(6).HeaderText = "TALLA"
        DgvDetalle.Columns(6).Width = 80
        DgvDetalle.Columns(7).HeaderText = "STOCK"
        DgvDetalle.Columns(7).Width = 80
        'DgvDetalle.Columns(5).Width = 60
        DgvDetalle.Columns(8).HeaderText = "CANTIDAD"
        DgvDetalle.Columns(8).Width = 100
        DgvDetalle.Columns(9).HeaderText = "PRECIO"
        DgvDetalle.Columns(9).Width = 80
        DgvDetalle.Columns(10).HeaderText = "DESCUENTO"
        DgvDetalle.Columns(10).Width = 120
        DgvDetalle.Columns(11).HeaderText = "IMPORTE"
        DgvDetalle.Columns(11).Width = 100
        DgvDetalle.Columns(12).HeaderText = "IMAGEN"
        DgvDetalle.Columns(11).Width = 100

        DgvDetalle.Columns(1).ReadOnly = True
        DgvDetalle.Columns(2).ReadOnly = True
        DgvDetalle.Columns(3).ReadOnly = True
        DgvDetalle.Columns(5).ReadOnly = True
        ' DgvDetalle.Columns(8).ReadOnly = True

    End Sub

    Private Sub CalcularTotales()
        Dim Total As Decimal
        Dim SubTotal As Decimal

        Dim TotalImpuesto As Decimal = 0

        For Each FilaTemp As DataGridViewRow In DgvDetalle.Rows
            Total = Total + CDec(FilaTemp.Cells("importe").Value)

        Next

        SubTotal = Math.Round((Total / (1 + TxtImpuesto.Text)), 2)
        TxtTotal.Text = Total
        TxtSubTotal.Text = SubTotal
        TxtTotalImpuesto.Text = CStr(Total - SubTotal)

        If TxtTotal.Text = 0 Then
            TxtA_cuenta.Text = 0
            TxtSaldo.Text = 0
        End If
        TxtTotal.Focus()

    End Sub

    Private Sub AgregarDetalle(Fila As Entidades.Articulo)
        Dim Agregar As Boolean = True

        For Each FilaTemp As DataGridViewRow In DgvDetalle.Rows
            If (Convert.ToInt32(FilaTemp.Cells("idarticulo").Value) = Convert.ToInt32(Fila.IdArticulo)) Then
                Agregar = False
                MsgBox("El articulo ya ha sido agregado", vbOKOnly + vbCritical, "Error agregando detalles")
            End If
        Next

        If (Agregar) Then
            Dim Row As DataRow
            Row = Me.DtDetalle.NewRow()
            Row("idarticulo") = Convert.ToString(Fila.IdArticulo)
            Row("codigo") = Convert.ToString(Fila.Codigo)
            Row("categoria") = Convert.ToString(Fila.Categoria)
            Row("marca") = Convert.ToString(Fila.Marca)
            Row("modelo") = Convert.ToString(Fila.Modelo)
            Row("idtalla") = Convert.ToString(Fila.IdTalla)
            Row("talla") = Convert.ToString(Fila.Talla)
            Row("stock") = Convert.ToString(Fila.Stock)
            Row("cantidad") = Convert.ToString(1)
            Row("precio") = Convert.ToString(Fila.PrecioVenta)
            Row("descuento") = Convert.ToString(0)
            Row("importe") = Convert.ToString(Fila.PrecioVenta)
            Row("imagen") = Convert.ToString(Fila.Imagen)
            Me.DtDetalle.Rows.Add(Row)
            Me.CalcularTotales()
        End If
    End Sub

    Private Sub TxtTalla_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTalla.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Try
                Dim Neg As New Negocio.NArticulo
                Dim Obj As New Entidades.Articulo
                Obj = Neg.BuscarCodigo(TxtCodigo.Text, TxtTalla.Text)
                If (Obj Is Nothing) Then
                    MsgBox("No existe articulo con ese codigo de barras", vbOKOnly + vbCritical, "No existe articulo")
                Else
                    Me.AgregarDetalle(Obj)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnBuscarArticulosDetalle_Click(sender As Object, e As EventArgs) Handles BtnBuscarArticulosDetalle.Click
        Try
            Dim Neg As New Negocio.NArticulo
            Dim Valor, xtalla As String
            Valor = TxtBuscarArticulos.Text
            xtalla = XTxtTalla.Text
            DgvArticulos.DataSource = Neg.BuscarVenta(Valor, xtalla)
            LblTotalArticulos.Text = "Total Articulos: " & DgvArticulos.DataSource.Rows.count
            Me.FormatoArticulos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgvArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellDoubleClick
        Try
            Dim Obj As New Entidades.Articulo
            Obj.IdArticulo = DgvArticulos.SelectedCells.Item(0).Value
            Obj.Codigo = DgvArticulos.SelectedCells.Item(3).Value
            Obj.Categoria = DgvArticulos.SelectedCells.Item(2).Value
            Obj.Marca = DgvArticulos.SelectedCells.Item(4).Value
            Obj.Modelo = DgvArticulos.SelectedCells.Item(5).Value
            Obj.Talla = DgvArticulos.SelectedCells.Item(7).Value
            Obj.Stock = DgvArticulos.SelectedCells.Item(9).Value
            Obj.PrecioVenta = DgvArticulos.SelectedCells.Item(8).Value
            Obj.Imagen = DgvArticulos.SelectedCells.Item(10).Value
            Me.AgregarDetalle(Obj)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        PanelArticulos.Visible = False
    End Sub

    Private Sub DgvDetalle_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalle.CellEndEdit
        Dim Fila As DataGridViewRow = CType(DgvDetalle.Rows(e.RowIndex), DataGridViewRow)
        Dim Precio As Decimal = Fila.Cells("precio").Value
        Dim Cantidad As Integer = Fila.Cells("Cantidad").Value
        Dim Descuento As Decimal = Fila.Cells("descuento").Value
        Dim Stock As Integer = Fila.Cells("stock").Value
        Dim Marca As String = Fila.Cells("marca").Value

        If (Cantidad > Stock) Then
            Cantidad = Stock
            MsgBox("La cantidad de venta del articulo " & Marca & " supera el stock disponible " & Stock, vbOKCancel + vbCritical, "Stock Insuficiente")
        End If

        Fila.Cells("cantidad").Value = Cantidad
        Fila.Cells("importe").Value = (Precio * Cantidad) - Descuento
        ' Me.CalcularTotales()
        Dim ACuenta As Decimal
        Dim total As Decimal
        Dim saldo As Decimal
        Dim subtotal As Decimal
        Dim impuesto As Decimal
        ACuenta = TxtA_cuenta.Text
        total = TxtTotal.Text
        subtotal = TxtSubTotal.Text
        impuesto = TxtTotalImpuesto.Text
        saldo = CStr(total - ACuenta)
        TxtSaldo.Text = saldo
        TxtTotal.Focus()

    End Sub

    Private Sub TxtA_cuenta_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtA_cuenta.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ' Me.CalcularTotales()
            Dim ACuenta As Decimal
            Dim total As Decimal
            Dim saldo As Decimal
            Dim subtotal As Decimal
            Dim impuesto As Decimal
            ACuenta = TxtA_cuenta.Text
            total = TxtTotal.Text
            subtotal = TxtSubTotal.Text
            impuesto = TxtTotalImpuesto.Text
            saldo = CStr(total - ACuenta)
            TxtSaldo.Text = saldo
            TxtTotal.Text = CStr(subtotal + impuesto)
            TxtTotal.Focus()
            If TxtSaldo.Text = 0 Then
                CboTipo_Venta.SelectedValue = 1
            End If
        End If
    End Sub

    Private Sub DgvDetalle_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DgvDetalle.RowsRemoved
        Me.CalcularTotales()
        Dim ACuenta As Decimal
        Dim total As Decimal
        Dim saldo As Decimal
        Dim subtotal As Decimal
        Dim impuesto As Decimal
        ACuenta = TxtA_cuenta.Text
        total = TxtTotal.Text
        subtotal = TxtSubTotal.Text
        impuesto = TxtTotalImpuesto.Text
        saldo = CStr(total - ACuenta)
        TxtSaldo.Text = saldo
    End Sub

    Private Sub DgvDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalle.CellDoubleClick
        Dim imagen As String
        imagen = DgvDetalle.SelectedCells.Item(12).Value
        If (imagen <> "") Then
            FrmImagen.Show()
            FrmImagen.PicImagen.Image = Image.FromFile(Directorio & imagen)
            FrmImagen.txtimagen.Text = imagen
        Else
            FrmImagen.PicImagen.Image = Nothing
            FrmImagen.txtimagen.Text = ""
        End If
    End Sub

    Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        Try
            If (TxtIdCliente.Text <> "" And CboTipoComprobante.Text <> "" And TxtNumComprobante.Text <> "" And DtDetalle.Rows.Count > 0) Then
                Dim obj As New Entidades.Venta
                Dim Neg As New Negocio.NVenta

                obj.IdUsuario = Variables.IdUsuario
                obj.IdCliente = TxtIdCliente.Text
                obj.IdTipo_Venta = CboTipo_Venta.SelectedValue
                obj.TipoComprobante = CboTipoComprobante.Text
                obj.SerieComprobante = TxtSerieComprobante.Text
                obj.NumComprobante = TxtNumComprobante.Text
                obj.Impuesto = TxtImpuesto.Text
                obj.SubTotal = TxtSubTotal.Text
                obj.A_Cuenta = TxtA_cuenta.Text
                obj.Saldo = TxtSaldo.Text
                obj.Total = TxtTotal.Text

                If (Neg.Insertar(obj, DtDetalle)) Then
                    MsgBox("Se ha registrado correctamente", vbOKOnly + vbInformation, "Registro correcto")
                    Me.Listar()
                Else
                    MsgBox("No Se ha podido registrar", vbOKOnly + vbCritical, "Registro incorrecto")
                End If
            Else
                MsgBox("Rellene todos los campos obligatorios, agregue al menos un detalle", vbOKOnly + vbCritical, "Falta ingresar datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CboTipo_Venta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTipo_Venta.SelectedIndexChanged
        Me.tipo_venta()
    End Sub

    Private Sub PanelArticulos_Paint(sender As Object, e As PaintEventArgs) Handles PanelArticulos.Paint

    End Sub

    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        Try
            Dim Neg As New Negocio.NVenta
            DgvMostrarDetalle.DataSource = Neg.ListarDetalle(DgvListado.SelectedCells.Item(1).Value)

            Dim Total As Decimal = 0
            Dim SubTotal As Decimal = 0
            Dim TotalImpuesto As Decimal = 0

            Total = DgvListado.SelectedCells.Item(15).Value
            SubTotal = Math.Round(Total / (1 + DgvListado.SelectedCells.Item(11).Value), 2)
            TotalImpuesto = Total - SubTotal

            LblTotalM.Text = Total
            LblTotalImpuestoM.Text = TotalImpuesto
            LblSubTotalM.Text = SubTotal

            PanelMostrar.Visible = True
            Me.FormatoListaVenta()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnAnular_Click(sender As Object, e As EventArgs) Handles BtnAnular.Click
        If (MsgBox("Estas seguro de anular la venta seleccionada?", vbYesNo + vbQuestion, "Anular Vneta")) = vbYes Then
            Try
                Dim Neg As New Negocio.NVenta
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado Then
                        Dim Onekey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Neg.Anular(Onekey)
                    End If
                Next
                Me.Listar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnCerrarM_Click(sender As Object, e As EventArgs) Handles BtnCerrarM.Click
        PanelMostrar.Visible = False
    End Sub

    Private Sub ChkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSeleccionar.CheckedChanged
        If ChkSeleccionar.CheckState = CheckState.Checked Then
            DgvListado.Columns.Item("Seleccionar").Visible = True
            BtnAnular.Visible = True
            BtnActualizar.Visible = True
            BtnActualizar_Venta.Visible = True
        Else
            DgvListado.Columns.Item("Seleccionar").Visible = False
            BtnAnular.Visible = False
            BtnActualizar.Visible = False
            BtnActualizar_Venta.Visible = False
        End If
    End Sub

    Private Sub DgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellContentClick
        If e.ColumnIndex = DgvListado.Columns.Item("Seleccionar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = DgvListado.Rows(e.RowIndex).Cells("Seleccionar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Try

            TxtId.Text = DgvListado.SelectedCells.Item(1).Value
            TxtA_cuenta.Text = DgvListado.SelectedCells.Item(12).Value
            TxtSaldo.Text = DgvListado.SelectedCells.Item(13).Value
            TxtTotalImpuesto.Text = DgvListado.SelectedCells.Item(11).Value
            TxtTotal.Text = DgvListado.SelectedCells.Item(14).Value
            CboTipo_Venta.SelectedValue = DgvListado.SelectedCells.Item(9).Value

            PanelArticulos.Visible = False
            DgvDetalle.Visible = False
            TxtA_cuenta.Visible = True
            TxtSaldo.Visible = True

            Lcuenta.Visible = True
            Lsaldo.Visible = True

            TabGeneral.SelectedIndex = 1
            Dim total As Decimal
            Dim impuesto As Decimal
            total = TxtTotal.Text
            impuesto = TxtTotalImpuesto.Text
            TxtSubTotal.Text = (total - impuesto)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BtnActualizar_Venta_Click(sender As Object, e As EventArgs) Handles BtnActualizar_Venta.Click
        Try
            If Me.ValidateChildren = True And TxtSaldo.Text <> "" And TxtA_cuenta.Text <> "" Then
                Dim obj As New Entidades.Venta
                Dim Neg As New Negocio.NVenta

                obj.IdVenta = TxtId.Text
                obj.IdTipo_Venta = CboTipo_Venta.SelectedValue
                obj.A_Cuenta = TxtA_cuenta.Text
                obj.Saldo = TxtSaldo.Text


                If (Neg.Actualizar(obj)) Then
                    MsgBox("Se ha actualizado correctamente", vbOKOnly + vbInformation, "Actualizacion correcta")
                    Me.Listar()
                Else
                    MsgBox("No se ha podido actualizar", vbOKOnly + vbCritical, "Actualizacion Incorrecta")
                End If
            Else
                MsgBox("Rellene todos los campos obligatorios(*)", vbOKOnly + vbCritical, "Falta ingresar datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TabGeneral.SelectedIndex = 0
    End Sub

    Private Sub BtnVerComprobante_Click(sender As Object, e As EventArgs) Handles BtnVerComprobante.Click
        Try
            Variables.IdVenta = DgvListado.SelectedCells.Item(1).Value
            FrmReporteComprobanteVenta.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub XTxtTalla_KeyDown(sender As Object, e As KeyEventArgs) Handles XTxtTalla.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            Try
                Dim Neg As New Negocio.NArticulo
                Dim Valor, xtalla As String
                Valor = TxtBuscarArticulos.Text
                xtalla = XTxtTalla.Text
                DgvArticulos.DataSource = Neg.BuscarVenta(Valor, xtalla)
                LblTotalArticulos.Text = "Total Articulos: " & DgvArticulos.DataSource.Rows.count
                Me.FormatoArticulos()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If


    End Sub

    Private Sub DgvMostrarDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvMostrarDetalle.CellDoubleClick
        Dim imagen As String
        imagen = DgvMostrarDetalle.SelectedCells.Item(10).Value
        If (imagen <> "") Then
            FrmImagen.Show()
            FrmImagen.PicImagen.Image = Image.FromFile(Directorio & imagen)
            FrmImagen.txtimagen.Text = imagen
        Else
            FrmImagen.PicImagen.Image = Nothing
            FrmImagen.txtimagen.Text = ""
        End If
    End Sub
End Class