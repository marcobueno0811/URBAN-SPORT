Public Class FrmCategoria

    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 100
        DgvListado.Columns(2).Width = 150
        DgvListado.Columns(3).Width = 400
        DgvListado.Columns(4).Width = 100

        DgvListado.Columns.Item("Seleccionar").Visible = False
        BtnEliminar.Visible = False
        BtnActivar.Visible = False
        BtnDesactivar.Visible = False
        ChkSeleccionar.CheckState = False

    End Sub

    Private Sub listar()
        Try
            Dim Neg As New Negocio.NCategoria
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
            Dim Neg As New Negocio.NCategoria
            Dim Valor As String
            Valor = TxtValor.Text
            DgvListado.DataSource = Neg.Buscar(Valor)
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
        TxtNombre.Text = ""
        TxtDescripcion.Text = ""
    End Sub
    Private Sub FrmCategoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.listar()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        If Me.ValidateChildren = True And TxtNombre.Text <> "" And TxtId.Text <> "" Then
            Dim Obj As New Entidades.Categoria
            Dim Neg As New Negocio.NCategoria

            Obj.IdCategoria = TxtId.Text
            Obj.Categoria = TxtNombre.Text
            Obj.Descripcion = TxtDescripcion.Text

            If (Neg.Actualizar(Obj)) Then
                MsgBox("Se ha actualizado correctamente", vbOKOnly + vbInformation, "Registro Actualizado")

                Me.listar()
                TabGeneral.SelectedIndex = 0
            Else
                MsgBox("No se ha podido actualizar", vbOKOnly + vbCritical, "Actualizacion Incorrecta")
            End If

        Else
            MsgBox("Rellene todos los campos obligatorios (*)", vbOKOnly + vbCritical, "Falta Ingresar datos")
        End If
    End Sub

    Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click
        If Me.ValidateChildren = True And TxtNombre.Text <> "" Then
            Dim Obj As New Entidades.Categoria
            Dim Neg As New Negocio.NCategoria


            Obj.Categoria = TxtNombre.Text
            Obj.Descripcion = TxtDescripcion.Text

            If (Neg.Insertar(Obj)) Then
                MsgBox("Se ha registrador correctamente", vbOKOnly + vbInformation, "Registro Correcto")

                Me.listar()
            Else
                MsgBox("No se ha podido registrar", vbOKOnly + vbCritical, "Registro Incorrecto")
            End If

        Else
            MsgBox("Rellene todos los campos obligatorios (*)", vbOKOnly + vbCritical, "Falta Ingresar datos")
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.limpiar()
        TabGeneral.SelectedIndex = 0
    End Sub

    Private Sub TxtNombre_Validated(sender As Object, e As EventArgs) Handles TxtNombre.Validated

    End Sub

    Private Sub TxtNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtNombre.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorIcono.SetError(sender, "")
        Else
            Me.ErrorIcono.SetError(sender, "Ingrese el nombre de la categoria por favor, este dato es obligatorio")
        End If
    End Sub

    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        If DgvListado.SelectedCells.Item(4).Value = False Then
            MsgBox("Registro se encuentra inactivo", vbOKOnly + vbInformation, "Registro Inactivo")
        Else
            TxtId.Text = DgvListado.SelectedCells.Item(1).Value
            TxtNombre.Text = DgvListado.SelectedCells.Item(2).Value
            TxtDescripcion.Text = DgvListado.SelectedCells.Item(3).Value
            BtnInsertar.Visible = False
            BtnActualizar.Visible = True
            TabGeneral.SelectedIndex = 1
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

    Private Sub DgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellContentClick
        If e.ColumnIndex = DgvListado.Columns.Item("Seleccionar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = DgvListado.Rows(e.RowIndex).Cells("Seleccionar")
            chkcell.Value = Not chkcell.Value
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        If (MsgBox("Estas seguro de eliminar los registros seleccionados?", vbYesNo + vbQuestion, "Eliminar Registros") = vbYes) Then
            Try
                Dim Neg As New Negocio.NCategoria
                For Each row As DataGridViewRow In DgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Seleccionar").Value)
                    If marcado = True Then
                        Dim OneKey As Integer = Convert.ToInt32(row.Cells("ID").Value)
                        Neg.Eliminar(OneKey)
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
                Dim Neg As New Negocio.NCategoria
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
        If (MsgBox("Estas seguro de Desactivar los registros seleccionados?", vbYesNo + vbQuestion, "Desactivar Registros") = vbYes) Then
            Try
                Dim Neg As New Negocio.NCategoria
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
End Class