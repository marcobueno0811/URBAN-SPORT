<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteComprobanteVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DburbanDataSet1 = New Sistema.Presentacion.dburbanDataSet1()
        Me.DburbanDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSistema = New Sistema.Presentacion.DsSistema()
        Me.DsSistemaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VentacomprobanteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Venta_comprobanteTableAdapter = New Sistema.Presentacion.DsSistemaTableAdapters.venta_comprobanteTableAdapter()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.venta_comprobanteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DburbanDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DburbanDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSistemaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VentacomprobanteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.venta_comprobanteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'DsSistema
        '
        Me.DsSistema.DataSetName = "DsSistema"
        Me.DsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsSistemaBindingSource
        '
        Me.DsSistemaBindingSource.DataSource = Me.DsSistema
        Me.DsSistemaBindingSource.Position = 0
        '
        'VentacomprobanteBindingSource
        '
        Me.VentacomprobanteBindingSource.DataMember = "venta_comprobante"
        Me.VentacomprobanteBindingSource.DataSource = Me.DsSistemaBindingSource
        '
        'Venta_comprobanteTableAdapter
        '
        Me.Venta_comprobanteTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsComprobanteVenta"
        ReportDataSource1.Value = Me.venta_comprobanteBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Presentacion.RptComprobanteVenta.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(992, 642)
        Me.ReportViewer1.TabIndex = 0
        '
        'venta_comprobanteBindingSource
        '
        Me.venta_comprobanteBindingSource.DataMember = "venta_comprobante"
        Me.venta_comprobanteBindingSource.DataSource = Me.DsSistema
        '
        'FrmReporteComprobanteVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 642)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FrmReporteComprobanteVenta"
        Me.Text = "Comprobante de Venta"
        CType(Me.DburbanDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DburbanDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSistemaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VentacomprobanteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.venta_comprobanteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DburbanDataSet1BindingSource As BindingSource
    Friend WithEvents DburbanDataSet1 As dburbanDataSet1
    Friend WithEvents DsSistemaBindingSource As BindingSource
    Friend WithEvents DsSistema As DsSistema
    Friend WithEvents VentacomprobanteBindingSource As BindingSource
    Friend WithEvents Venta_comprobanteTableAdapter As DsSistemaTableAdapters.venta_comprobanteTableAdapter
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents venta_comprobanteBindingSource As BindingSource
End Class
