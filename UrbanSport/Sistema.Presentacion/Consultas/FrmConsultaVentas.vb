Imports System.IO

Public Class FrmConsultaVentas
    Private RutaOrigen As String
    Private RutaDestino As String
    Private Directorio As String = "c:\imagenes\"
    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(2).Visible = False
        DgvListado.Columns(9).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 60
        DgvListado.Columns(3).Width = 180
        DgvListado.Columns(4).Width = 180
        DgvListado.Columns(5).Width = 180
        DgvListado.Columns(6).Width = 100
        DgvListado.Columns(7).Width = 80
        DgvListado.Columns(8).Width = 80
        DgvListado.Columns(10).Width = 100
        DgvListado.Columns(11).Width = 100
        DgvListado.Columns(12).Width = 100
        DgvListado.Columns(13).Width = 100
        DgvListado.Columns(14).Width = 100
        DgvListado.Columns(15).Width = 100


        DgvListado.Columns.Item("Seleccionar").Visible = False


    End Sub

    Private Sub FormatoVenta()

        DgvListado.Columns(10).Visible = False
        DgvListado.Columns(0).Width = 50
        DgvListado.Columns(1).Width = 80
        DgvListado.Columns(2).Width = 100
        DgvListado.Columns(3).Width = 100
        DgvListado.Columns(4).Width = 80
        DgvListado.Columns(5).Width = 60
        DgvListado.Columns(6).Width = 60
        DgvListado.Columns(7).Width = 70
        DgvListado.Columns(8).Width = 80
        DgvListado.Columns(9).Width = 80

    End Sub

    Private Sub Filtrar()
        Try
            Dim Neg As New Negocio.NVenta
            Dim FechaInicio As Date, FechaFin As Date
            FechaInicio = DtFechaInicio.Value
            FechaFin = DtFechaFin.Value
            DgvListado.DataSource = Neg.ConsultaFechas(FechaInicio, FechaFin)
            Lbltotal.Text = "Total Registros: " & DgvListado.DataSource.Rows.Count
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FrmConsultaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelMostrar.Visible = False
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        Me.Filtrar()
    End Sub

    Private Sub BtnVerComprobante_Click(sender As Object, e As EventArgs) Handles BtnVerComprobante.Click
        Try
            Variables.IdVenta = DgvListado.SelectedCells.Item(1).Value
            FrmReporteComprobanteVenta.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        Try
            Dim Neg As New Negocio.NVenta
            DgvMostrarDetalle.DataSource = Neg.ListarDetalle(DgvListado.SelectedCells.Item(1).Value)
            Me.FormatoVenta()
            Dim Total As Decimal = 0
            Dim SubTotal As Decimal = 0
            Dim TotalImpuesto As Decimal = 0

            Total = DgvListado.SelectedCells.Item(14).Value
            SubTotal = Math.Round(Total / (1 + DgvListado.SelectedCells.Item(11).Value), 2)
            TotalImpuesto = Total - SubTotal

            LblTotalM.Text = Total
            LblTotalImpuestoM.Text = TotalImpuesto
            LblSubTotalM.Text = SubTotal

            PanelMostrar.Visible = True
            Me.FormatoVenta()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnCerrarM_Click(sender As Object, e As EventArgs) Handles BtnCerrarM.Click
        PanelMostrar.Visible = False
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

    Private Sub PanelMostrar_Paint(sender As Object, e As PaintEventArgs) Handles PanelMostrar.Paint
        Me.FormatoVenta()
    End Sub
End Class