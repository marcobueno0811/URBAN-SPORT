Imports System.Text.RegularExpressions

Public Class FrmPrecioVenta
    Private RutaOrigen As String
    Private RutaDestino As String
    Private Directorio As String = "c:\imagenes\"
    Private Sub FrmPrecioVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim Neg As New Negocio.NArticulo
            DgvListado.DataSource = Neg.ListarPrecioVenta
            Me.Formato()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.CalcularTotales()
    End Sub

    Private Sub Formato()
        DgvListado.Columns(0).Visible = False
        DgvListado.Columns(7).Visible = False
        DgvListado.Columns(0).Width = 100
        DgvListado.Columns(1).Width = 200
        DgvListado.Columns(2).Width = 180
        DgvListado.Columns(3).Width = 60
        DgvListado.Columns(4).Width = 60
        DgvListado.Columns(5).Width = 100
        DgvListado.Columns(6).Width = 80


        DgvListado.Columns.Item("Seleccionar").Visible = False
    End Sub

    Private Sub DgvListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvListado.CellDoubleClick
        Dim imagen As String
        imagen = DgvListado.SelectedCells.Item(7).Value
        If (imagen <> "") Then
            FrmImagen.Show()
            FrmImagen.PicImagen.Image = Image.FromFile(Directorio & imagen)
            FrmImagen.txtimagen.Text = imagen
        Else
            FrmImagen.PicImagen.Image = Nothing
            FrmImagen.txtimagen.Text = ""
        End If
    End Sub

    Private Sub CalcularTotales()
        Dim monto As Decimal
        Dim zapatillas As Integer
        For Each FilaTemp As DataGridViewRow In DgvListado.Rows
            monto = monto + CDec(FilaTemp.Cells("Total").Value)
            zapatillas = zapatillas + (FilaTemp.Cells("stock").Value)
        Next

        LblZapaptillas.Text = zapatillas
        LblMonto.Text = monto
    End Sub

End Class