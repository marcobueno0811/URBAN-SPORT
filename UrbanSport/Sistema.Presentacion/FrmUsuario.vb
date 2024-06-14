Public Class FrmUsuario
    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(2).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 80
        DgvListado.Columns(3).Width = 120
        DgvListado.Columns(4).Width = 120
        DgvListado.Columns(5).Width = 100
        DgvListado.Columns(6).Width = 100
        DgvListado.Columns(7).Width = 120
        DgvListado.Columns(8).Width = 100
        DgvListado.Columns(9).Width = 120
        DgvListado.Columns(10).Width = 100

        DgvListado.Columns.Item("Seleccionar").Visible = False
        BtnEliminar.Visible = False
        BtnActivar.Visible = False
        BtnDesactivar.Visible = False
        ChkSeleccionar.CheckState = False
    End Sub
    Private Sub Listar()
        Try
            Dim Neg As New Negocio.NUsuario
            DgvListado.DataSource = Neg.Listar()
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
            Me.Limpiar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Buscar()
        Try
            Dim Neg As New Negocio.NUsuario
            Dim Valor As String
            Valor = TxtValor.Text
            DgvListado.DataSource = Neg.Buscar(Valor)
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Limpiar()
        BtnInsertar.Visible = True
        BtnActualizar.Visible = False
        TxtValor.Text = ""
        TxtId.Text = ""
        TxtNombre.Text = ""
        TxtNumDocumento.Text = ""
        TxtDireccion.Text = ""
        TxtTelefono.Text = ""
        TxtEmail.Text = ""
        TxtClave.Text = ""

    End Sub

    Private Sub CargarRol()
        Try
            Dim Neg As New Negocio.NRol
            CboRol.DataSource = Neg.Listar()
            CboRol.ValueMember = "idrol"
            CboRol.DisplayMember = "nombre"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Listar()
        Me.CargarRol()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        Try
            If Me.ValidateChildren = True And CboRol.Text <> "" And TxtNombre.Text <> "" And TxtEmail.Text <> "" And TxtClave.Text <> "" Then
                Dim obj As New Entidades.Usuario
                Dim Neg As New Negocio.NUsuario

                obj.IdRol = CboRol.SelectedValue
                obj.Nombre = TxtNombre.Text
                obj.TipoDocumento = CboTipoDocumento.Text
                obj.NumDocumento = TxtNumDocumento.Text
                obj.Direccion = TxtDireccion.Text
                obj.Telefono = TxtTelefono.Text
                obj.Email = TxtEmail.Text
                obj.Clave = TxtClave.Text

                If (Neg.Insertar(obj)) Then
                    MsgBox("Se ha registrado correctamente", vbOKOnly + vbInformation, "Registro correcto")
                    Me.Listar()
                Else
                    MsgBox("No se ha podido registrar", vbOKOnly + vbCritical, "Registro Incorrecto")
                End If
            Else
                MsgBox("Rellene todos los campos obligatorios(*)", vbOKOnly + vbCritical, "Falta ingresar datos")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Limpiar()
        TabGeneral.SelectedIndex = 0
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        Try
            If Me.ValidateChildren = True And CboRol.Text <> "" And TxtNombre.Text <> "" And TxtEmail.Text <> "" And TxtId.Text <> "" Then
                Dim obj As New Entidades.Usuario
                Dim Neg As New Negocio.NUsuario

                obj.IdUsuario = TxtId.Text
                obj.IdRol = CboRol.SelectedValue
                obj.Nombre = TxtNombre.Text
                obj.TipoDocumento = CboTipoDocumento.Text
                obj.NumDocumento = TxtNumDocumento.Text
                obj.Direccion = TxtDireccion.Text
                obj.Telefono = TxtTelefono.Text
                obj.Email = TxtEmail.Text
                obj.Clave = TxtClave.Text

                If (Neg.Actualizar(obj)) Then
                    MsgBox("Se ha actualizado correctamente", vbOKOnly + vbInformation, "Registro correcto")
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
    End Sub

    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        Try
            If DgvListado.SelectedCells.Item(10).Value = True Then
                TxtId.Text = DgvListado.SelectedCells.Item(1).Value
                CboRol.SelectedValue = DgvListado.SelectedCells.Item(2).Value
                TxtNombre.Text = DgvListado.SelectedCells.Item(4).Value
                CboTipoDocumento.Text = DgvListado.SelectedCells.Item(5).Value
                TxtNumDocumento.Text = DgvListado.SelectedCells.Item(6).Value
                TxtDireccion.Text = DgvListado.SelectedCells.Item(7).Value
                TxtTelefono.Text = DgvListado.SelectedCells.Item(8).Value
                TxtEmail.Text = DgvListado.SelectedCells.Item(9).Value

                BtnInsertar.Visible = False
                BtnActualizar.Visible = True
                TabGeneral.SelectedIndex = 1
            Else
                BtnInsertar.Visible = False
                BtnActualizar.Visible = False
                TabGeneral.SelectedIndex = 1
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

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
        If (MsgBox("Estas seguro de eliminar los registros seleccionados?", vbYesNo + vbQuestion, "Eliminar registros")) = vbYes Then
            Try
                Dim Neg As New Negocio.NUsuario
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado Then
                        Dim Onekey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Neg.Eliminar(Onekey)

                    End If
                Next
                Me.Listar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnActivar_Click(sender As Object, e As EventArgs) Handles BtnActivar.Click
        If (MsgBox("Estas seguro de activar los registros seleccionados?", vbYesNo + vbQuestion, "activar registros")) = vbYes Then
            Try
                Dim Neg As New Negocio.NUsuario
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado Then
                        Dim Onekey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Neg.Activar(Onekey)

                    End If
                Next
                Me.Listar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnDesactivar_Click(sender As Object, e As EventArgs) Handles BtnDesactivar.Click
        If (MsgBox("Estas seguro de desactivar los registros seleccionados?", vbYesNo + vbQuestion, "desactivar registros")) = vbYes Then
            Try
                Dim Neg As New Negocio.NUsuario
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado Then
                        Dim Onekey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Neg.Desactivar(Onekey)

                    End If
                Next
                Me.Listar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class