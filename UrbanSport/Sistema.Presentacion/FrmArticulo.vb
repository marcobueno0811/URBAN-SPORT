Imports System.IO
Imports System.Linq.Expressions

Public Class FrmArticulo
    Private RutaOrigen As String
    Private RutaDestino As String
    Private Directorio As String = "c:\imagenes\"
    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(2).Visible = False
        DgvListado.Columns(7).Visible = False
        DgvListado.Columns(11).Visible = False
        '  DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 50
        DgvListado.Columns(3).Width = 100
        DgvListado.Columns(4).Width = 100
        DgvListado.Columns(5).Width = 100
        DgvListado.Columns(6).Width = 150
        DgvListado.Columns(8).Width = 75
        DgvListado.Columns(9).Width = 80
        DgvListado.Columns(10).Width = 90
        'DgvListado.Columns(11).Width = 90
        DgvListado.Columns(12).Width = 90

        DgvListado.Columns.Item("Seleccionar").Visible = False
        BtnEliminar.Visible = False
        BtnActivar.Visible = False
        BtnDesactivar.Visible = False
        ChkSeleccionar.CheckState = False

    End Sub

    Private Sub listar()
        Try
            Dim Neg As New Negocio.NArticulo
            DgvListado.DataSource = Neg.Listar
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.rows.count
            Me.Formato()
            Me.limpiar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Buscar()
        Try
            Dim Neg As New Negocio.NArticulo
            Dim Valor As String, xtalla As String
            Valor = TxtValor.Text
            xtalla = TxtTalla.Text
            DgvListado.DataSource = Neg.Buscar(Valor, xtalla)
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.rows.count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub limpiar()
        BtnInsertar.Visible = True
        BtnActualizar.Visible = False
        TxtValor.Text = ""
        TxtId.Text = ""
        TxtCodigo.Text = ""
        TxtMarca.Text = ""
        TxtModelo.Text = ""
        TxtPrecioVenta.Text = ""
        TxtStock.Text = ""
        txtimagen.Text = ""
        PicImagen.Image = Nothing

    End Sub

    Private Sub CargarCategoria()
        Try
            Dim Neg As New Negocio.NCategoria
            CboCategoria.DataSource = Neg.Seleccionar
            CboCategoria.ValueMember = "idcategoria"
            CboCategoria.DisplayMember = "categoria"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarTalla()
        Try
            Dim Neg As New Negocio.NTalla
            CboTalla.DataSource = Neg.Seleccionar
            CboTalla.ValueMember = "idtalla"
            CboTalla.DisplayMember = "talla"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FrmArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.listar()
        Me.CargarCategoria()
        Me.CargarTalla()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub BtnCargarImagen_Click(sender As Object, e As EventArgs) Handles BtnCargarImagen.Click
        Dim file As New OpenFileDialog()
        file.Filter = "Image Files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png "
        If file.ShowDialog() = DialogResult.OK Then
            PicImagen.Image = Image.FromFile(file.FileName)
            RutaOrigen = file.FileName
            txtimagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\") + 1)
        End If
    End Sub

    Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        Try
            If Me.ValidateChildren = True And CboCategoria.Text <> "" And TxtMarca.Text <> "" And CboTalla.Text <> "" And TxtPrecioVenta.Text <> "" And TxtStock.Text <> "" Then
                Dim Obj As New Entidades.Articulo
                Dim Neg As New Negocio.NArticulo

                Obj.IdCategoria = CboCategoria.SelectedValue
                Obj.Codigo = TxtCodigo.Text
                Obj.Marca = TxtMarca.Text
                Obj.Modelo = TxtModelo.Text
                Obj.IdTalla = CboTalla.SelectedValue
                Obj.PrecioVenta = TxtPrecioVenta.Text
                Obj.Stock = TxtStock.Text
                Obj.Imagen = txtimagen.Text



                If (Neg.Insertar(Obj)) Then
                    MsgBox("Se ha registrador correctamente", vbOKOnly + vbInformation, "Registro Correcto")
                    If (txtimagen.Text <> "") Then
                        RutaDestino = Directorio & txtimagen.Text
                        File.Copy(RutaOrigen, RutaDestino)
                    End If
                    Me.listar()
                Else
                    MsgBox("No se ha podido registrar", vbOKOnly + vbCritical, "Registro Incorrecto")
                End If

            Else
                MsgBox("Rellene todos los campos obligatorios (*)", vbOKOnly + vbCritical, "Falta Ingresar datos")
            End If
        Catch ex As Exception
            MsgBox(Ex.message)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.limpiar()
        TabGeneral.SelectedIndex = 0
    End Sub

    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        If DgvListado.SelectedCells.Item(12).Value = False Then
            MsgBox("Registro se encuentra inactivo", vbOKOnly + vbInformation, "Registro Inactivo")
        Else
            Try
                TxtId.Text = DgvListado.SelectedCells.Item(1).Value
                CboCategoria.SelectedValue = DgvListado.SelectedCells.Item(2).Value
                TxtCodigo.Text = DgvListado.SelectedCells.Item(4).Value
                TxtMarca.Text = DgvListado.SelectedCells.Item(5).Value
                TxtModelo.Text = DgvListado.SelectedCells.Item(6).Value
                CboTalla.SelectedValue = DgvListado.SelectedCells.Item(7).Value
                TxtPrecioVenta.Text = DgvListado.SelectedCells.Item(9).Value
                TxtStock.Text = DgvListado.SelectedCells.Item(10).Value
                Dim imagen As String
                imagen = DgvListado.SelectedCells.Item(11).Value
                If (imagen <> "") Then
                    PicImagen.Image = Image.FromFile(Directorio & imagen)
                    txtimagen.Text = imagen
                Else
                    PicImagen.Image = Nothing
                    txtimagen.Text = ""
                End If
                BtnInsertar.Visible = False
                BtnActualizar.Visible = True
                TabGeneral.SelectedIndex = 1
            Catch EX As Exception
                MsgBox(EX.Message)
            End Try
        End If

    End Sub

    Private Sub DgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellContentClick
        If e.ColumnIndex = DgvListado.Columns.Item("Seleccionar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = DgvListado.Rows(e.RowIndex).Cells("Seleccionar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub ChkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSeleccionar.CheckedChanged
        If ChkSeleccionar.CheckState = CheckState.Checked Then
            DgvListado.Columns.Item("Seleccionar").Visible = True
            BtnEliminar.Visible = True
            BtnActivar.Visible = True
            BtnDesactivar.Visible = True
        Else
            DgvListado.Columns.Item("Seleccionar").Visible = False
            BtnEliminar.Visible = False
            BtnActivar.Visible = False
            BtnDesactivar.Visible = False
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If (MsgBox("Estas seguro de eliminar los registros seleccionados?", vbYesNo + vbQuestion, "Eliminar Registros") = vbYes) Then
            Try
                Dim Neg As New Negocio.NArticulo
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado = True Then
                        Dim OneKey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Dim Imagen As String = Convert.ToString(row.Cells("Imagen").Value)
                        Neg.Eliminar(OneKey)
                        File.Delete(Directorio & Imagen)
                    End If
                Next
                Me.listar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnActivar_Click(sender As Object, e As EventArgs) Handles BtnActivar.Click
        If (MsgBox("Estas seguro de activar los registros seleccionados?", vbYesNo + vbQuestion, "Activar Registros") = vbYes) Then
            Try
                Dim Neg As New Negocio.NArticulo
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado = True Then
                        Dim OneKey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Neg.Activar(OneKey)
                    End If
                Next
                Me.listar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnDesactivar_Click(sender As Object, e As EventArgs) Handles BtnDesactivar.Click
        If (MsgBox("Estas seguro de Desactivar los registros seleccionados?", vbYesNo + vbQuestion, "Activar Registros") = vbYes) Then
            Try
                Dim Neg As New Negocio.NArticulo
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado = True Then
                        Dim OneKey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Neg.Desactivar(OneKey)
                    End If
                Next
                Me.listar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub CboTalla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTalla.SelectedIndexChanged

    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Try
            If Me.ValidateChildren = True And CboCategoria.Text <> "" And TxtCodigo.Text <> "" And TxtPrecioVenta.Text <> "" And TxtStock.Text <> "" And TxtId.Text <> "" Then
                Dim obj As New Entidades.Articulo
                Dim Neg As New Negocio.NArticulo

                obj.IdArticulo = TxtId.Text
                obj.IdCategoria = CboCategoria.SelectedValue
                obj.IdTalla = CboTalla.SelectedValue
                obj.Codigo = TxtCodigo.Text
                obj.Marca = TxtMarca.Text
                obj.Modelo = TxtModelo.Text
                obj.PrecioVenta = TxtPrecioVenta.Text
                obj.Stock = TxtStock.Text
                obj.Imagen = txtimagen.Text

                If (Neg.Actualizar(obj)) Then
                    MsgBox("Se ha actualizado correctamente", vbOKOnly + vbInformation, "Actualizacion correcta")
                    If (txtimagen.Text <> "" And RutaOrigen <> "") Then
                        RutaDestino = Directorio & txtimagen.Text
                        File.Copy(RutaOrigen, RutaDestino)
                    End If
                    Me.listar()
                Else
                    MsgBox("No se ha podido actualizar", vbOKOnly + vbCritical, "Actualizacion Incorrecta")
                End If
            Else
                MsgBox("Rellene todos los campos obligatorios(*)", vbOKOnly + vbCritical, "Falta ingresar datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        FrmReporteArticulos.ShowDialog()
    End Sub
End Class