Imports System.IO

Public Class FrmConsultaStock

    Private RutaOrigen As String
    Private RutaDestino As String
    Private Directorio As String = "c:\imagenes\"

    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(8).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 60
        DgvListado.Columns(2).Width = 180
        DgvListado.Columns(3).Width = 180
        DgvListado.Columns(4).Width = 250
        DgvListado.Columns(5).Width = 100
        DgvListado.Columns(6).Width = 80
        DgvListado.Columns(7).Width = 80

        DgvListado.Columns.Item("Seleccionar").Visible = False


    End Sub
    Private Sub FrmConsultaStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CargarCategoria()
        Me.CargarTalla()
        CboCategoria.Text = ""
        CboTalla.Text = ""

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

    Private Sub Filtrar()
        Try
            Dim Neg As New Negocio.NArticulo
            Dim Categoria As String, Talla As String
            Categoria = CboCategoria.Text
            Talla = CboTalla.Text
            DgvListado.DataSource = Neg.ConsultaStock(Categoria, Talla)
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        Me.Filtrar()
    End Sub

    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        Dim imagen As String
        imagen = DgvListado.SelectedCells.Item(8).Value
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