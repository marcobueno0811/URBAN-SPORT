Public Class FrmReporteArticulos
    Private Sub FrmReporteArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DburbanDataSet1.articulo_listar' Puede moverla o quitarla según sea necesario.
        Me.Articulo_listarTableAdapter.Fill(Me.DburbanDataSet1.articulo_listar)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ArticulolistarBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles ArticulolistarBindingSource.CurrentChanged

    End Sub

    Private Sub articulo_listarBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles articulo_listarBindingSource.CurrentChanged

    End Sub
End Class