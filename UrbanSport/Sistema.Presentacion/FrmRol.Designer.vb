<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRol
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
        Me.DgvListado = New System.Windows.Forms.DataGridView()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        CType(Me.DgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvListado
        '
        Me.DgvListado.AllowUserToAddRows = False
        Me.DgvListado.AllowUserToDeleteRows = False
        Me.DgvListado.AllowUserToOrderColumns = True
        Me.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvListado.Location = New System.Drawing.Point(6, 23)
        Me.DgvListado.Name = "DgvListado"
        Me.DgvListado.ReadOnly = True
        Me.DgvListado.Size = New System.Drawing.Size(296, 184)
        Me.DgvListado.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.LblTotal)
        Me.TabPage1.Controls.Add(Me.DgvListado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(321, 269)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Listado"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Location = New System.Drawing.Point(223, 223)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(39, 13)
        Me.LblTotal.TabIndex = 1
        Me.LblTotal.Text = "Label1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(329, 295)
        Me.TabControl1.TabIndex = 1
        '
        'FrmRol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(364, 332)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmRol"
        Me.Text = "Roles"
        CType(Me.DgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvListado As DataGridView
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents LblTotal As Label
    Friend WithEvents TabControl1 As TabControl
End Class
