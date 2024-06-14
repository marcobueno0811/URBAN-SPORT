<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrecioVenta
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
        Me.TabGeneral = New System.Windows.Forms.TabControl()
        Me.TxtMarca = New System.Windows.Forms.TabPage()
        Me.LblMonto = New System.Windows.Forms.Label()
        Me.LblZapaptillas = New System.Windows.Forms.Label()
        Me.Lbltotal = New System.Windows.Forms.Label()
        Me.DgvListado = New System.Windows.Forms.DataGridView()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabGeneral.SuspendLayout()
        Me.TxtMarca.SuspendLayout()
        CType(Me.DgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabGeneral
        '
        Me.TabGeneral.Controls.Add(Me.TxtMarca)
        Me.TabGeneral.Location = New System.Drawing.Point(9, 19)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.SelectedIndex = 0
        Me.TabGeneral.Size = New System.Drawing.Size(782, 624)
        Me.TabGeneral.TabIndex = 8
        '
        'TxtMarca
        '
        Me.TxtMarca.Controls.Add(Me.Label2)
        Me.TxtMarca.Controls.Add(Me.Label1)
        Me.TxtMarca.Controls.Add(Me.LblMonto)
        Me.TxtMarca.Controls.Add(Me.LblZapaptillas)
        Me.TxtMarca.Controls.Add(Me.Lbltotal)
        Me.TxtMarca.Controls.Add(Me.DgvListado)
        Me.TxtMarca.Location = New System.Drawing.Point(4, 22)
        Me.TxtMarca.Name = "TxtMarca"
        Me.TxtMarca.Padding = New System.Windows.Forms.Padding(3)
        Me.TxtMarca.Size = New System.Drawing.Size(774, 598)
        Me.TxtMarca.TabIndex = 0
        Me.TxtMarca.Text = "Listado"
        Me.TxtMarca.UseVisualStyleBackColor = True
        '
        'LblMonto
        '
        Me.LblMonto.AutoSize = True
        Me.LblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonto.Location = New System.Drawing.Point(571, 547)
        Me.LblMonto.Name = "LblMonto"
        Me.LblMonto.Size = New System.Drawing.Size(0, 18)
        Me.LblMonto.TabIndex = 16
        '
        'LblZapaptillas
        '
        Me.LblZapaptillas.AutoSize = True
        Me.LblZapaptillas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblZapaptillas.Location = New System.Drawing.Point(200, 547)
        Me.LblZapaptillas.Name = "LblZapaptillas"
        Me.LblZapaptillas.Size = New System.Drawing.Size(0, 18)
        Me.LblZapaptillas.TabIndex = 10
        '
        'Lbltotal
        '
        Me.Lbltotal.AutoSize = True
        Me.Lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbltotal.Location = New System.Drawing.Point(1234, 472)
        Me.Lbltotal.Name = "Lbltotal"
        Me.Lbltotal.Size = New System.Drawing.Size(36, 13)
        Me.Lbltotal.TabIndex = 1
        Me.Lbltotal.Text = "Total"
        '
        'DgvListado
        '
        Me.DgvListado.AllowUserToAddRows = False
        Me.DgvListado.AllowUserToDeleteRows = False
        Me.DgvListado.AllowUserToOrderColumns = True
        Me.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvListado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar})
        Me.DgvListado.Location = New System.Drawing.Point(18, 21)
        Me.DgvListado.Name = "DgvListado"
        Me.DgvListado.ReadOnly = True
        Me.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvListado.Size = New System.Drawing.Size(727, 504)
        Me.DgvListado.TabIndex = 0
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 547)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 18)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Total de Zapatillas:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(461, 547)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 18)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Monto Total:"
        '
        'FrmPrecioVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(804, 663)
        Me.Controls.Add(Me.TabGeneral)
        Me.Name = "FrmPrecioVenta"
        Me.Text = "PrecioVenta"
        Me.TabGeneral.ResumeLayout(False)
        Me.TxtMarca.ResumeLayout(False)
        Me.TxtMarca.PerformLayout()
        CType(Me.DgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabGeneral As TabControl
    Friend WithEvents TxtMarca As TabPage
    Friend WithEvents LblMonto As Label
    Friend WithEvents LblZapaptillas As Label
    Friend WithEvents Lbltotal As Label
    Friend WithEvents DgvListado As DataGridView
    Friend WithEvents Seleccionar As DataGridViewCheckBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
