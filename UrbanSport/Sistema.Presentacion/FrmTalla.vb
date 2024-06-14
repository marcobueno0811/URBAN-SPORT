Public Class FrmTalla

    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 100
        DgvListado.Columns(2).Width = 100
        DgvListado.Columns(3).Width = 100
        ' DgvListado.Columns(4).Width = 100

        DgvListado.Columns.Item("Seleccionar").Visible = False
        BtnEliminar.Visible = False
        BtnActivar.Visible = False
        BtnDesactivar.Visible = False
        ChkSeleccionar.CheckState = False

    End Sub
    Private Sub limpiar()
        BtnInsertar.Visible = True
        BtnActualizar.Visible = False
        TxtValor.Text = ""
        TxtId.Text = ""
        TxtTalla.Text = ""

    End Sub

    Private Sub listar()

        Dim Neg As New Negocio.NTalla
            DgvListado.DataSource = Neg.Listar
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.rows.count
            Me.Formato()
            Me.limpiar()


    End Sub
    Private Sub FrmTalla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.listar()
    End Sub

    Private Sub BtnInsertar_Click(sender As Object, e As EventArgs) Handles BtnInsertar.Click

        If Me.ValidateChildren = True And TxtTalla.Text <> "" Then
            Dim Obj As New Entidades.Talla
            Dim Neg As New Negocio.NTalla


            Obj.Talla = TxtTalla.Text

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

    Private Sub Buscar()
        Try
            Dim Neg As New Negocio.NTalla
            Dim xtalla As String
            xtalla = TxtValor.Text
            DgvListado.DataSource = Neg.Buscar(xtalla)
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.rows.count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        Me.Buscar()
    End Sub
End Class