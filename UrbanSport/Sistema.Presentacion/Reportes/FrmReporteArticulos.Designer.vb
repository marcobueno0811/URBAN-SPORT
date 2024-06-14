<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporteArticulos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.articulo_listarBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DburbanDataSet1 = New Sistema.Presentacion.dburbanDataSet1()
        Me.DburbanDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ArticulolistarBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Articulo_listarTableAdapter = New Sistema.Presentacion.dburbanDataSet1TableAdapters.articulo_listarTableAdapter()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.articulo_listarBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DburbanDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DburbanDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArticulolistarBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'articulo_listarBindingSource
        '
        Me.articulo_listarBindingSource.DataMember = "articulo_listar"
        Me.articulo_listarBindingSource.DataSource = Me.DburbanDataSet1
        '
        'DburbanDataSet1
        '
        Me.DburbanDataSet1.DataSetName = "dburbanDataSet1"
        Me.DburbanDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DburbanDataSet1BindingSource
        '
        Me.DburbanDataSet1BindingSource.DataSource = Me.DburbanDataSet1
        Me.DburbanDataSet1BindingSource.Position = 0
        '
        'ArticulolistarBindingSource
        '
        Me.ArticulolistarBindingSource.DataMember = "articulo_listar"
        Me.ArticulolistarBindingSource.DataSource = Me.DburbanDataSet1BindingSource
        '
        'Articulo_listarTableAdapter
        '
        Me.Articulo_listarTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DsArticulo"
        ReportDataSource1.Value = Me.articulo_listarBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Presentacion.RptArticulos.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1154, 669)
        Me.ReportViewer1.TabIndex = 0
        '
        'FrmReporteArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1154, 669)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmReporteArticulos"
        Me.Text = "Reporte de Articulos"
        CType(Me.articulo_listarBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DburbanDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DburbanDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArticulolistarBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DburbanDataSet1BindingSource As BindingSource
    Friend WithEvents DburbanDataSet1 As dburbanDataSet1
    Friend WithEvents ArticulolistarBindingSource As BindingSource
    Friend WithEvents Articulo_listarTableAdapter As dburbanDataSet1TableAdapters.articulo_listarTableAdapter
    Friend WithEvents articulo_listarBindingSource As BindingSource
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
