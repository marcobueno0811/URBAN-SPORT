Imports System.Windows.Forms

Public Class frmPrincipal
    Private _IdUsuario As String
    Private _idRol As String
    Private _Rol As String
    Private _Nombre As String


    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim frm As New FrmTalla
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Public Property IdUsuario As String
        Get
            Return _IdUsuario
        End Get
        Set(value As String)
            _IdUsuario = value
        End Set
    End Property

    Public Property IdRol As String
        Get
            Return _idRol
        End Get
        Set(value As String)
            _idRol = value
        End Set
    End Property

    Public Property Rol As String
        Get
            Return _Rol
        End Get
        Set(value As String)
            _Rol = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TsBarraInferior.Text = "Desarrollado por www.incanatoit.com, Usuario: " & Me.Nombre
        MsgBox("Bienvenido " & Me.Nombre, vbOKOnly + vbInformation, "Bienvenido al Sistema")

        If (Me.Rol = "Administrador") Then

            MnuAlmacen.Enabled = True
            MnuIngresos.Enabled = True
            MnuVentas.Enabled = True
            MnuAcceso.Enabled = True
            MnuConsultas.Enabled = True
            'TsCompras.Enabled = True
            'TsVentas.Enabled = True
        ElseIf (Me.Rol = "Almacenero") Then
            MnuAlmacen.Enabled = True
            MnuIngresos.Enabled = True
            MnuVentas.Enabled = False
            MnuAcceso.Enabled = False
            MnuConsultas.Enabled = False
            'TsCompras.Enabled = True
            ' TsVentas.Enabled = False
        ElseIf (Me.Rol = "Vendedor") Then
            MnuAlmacen.Enabled = False
            MnuIngresos.Enabled = False
            MnuVentas.Enabled = True
            MnuAcceso.Enabled = False
            MnuConsultas.Enabled = False
            'TsCompras.Enabled = False
            'TsVentas.Enabled = True
        Else
            MnuAlmacen.Enabled = False
            MnuIngresos.Enabled = False
            MnuVentas.Enabled = False
            MnuAcceso.Enabled = False
            MnuConsultas.Enabled = False
            ' TsCompras.Enabled = False
            ' TsVentas.Enabled = False
        End If
    End Sub

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click
        If (MsgBox("Esta seguro de salir del sistema?", vbYesNo + vbQuestion, "Sistema") = vbYes) Then
            End

        End If
    End Sub

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim frm As New FrmProveedor
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim frm As New FrmCliente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click
        Dim frm As New FrmIngreso
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulosToolStripMenuItem.Click
        Dim frm As New FrmArticulo
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriasToolStripMenuItem.Click
        Dim frm As New FrmCategoria
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        Dim frm As New FrmVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConsultasVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultasVentasToolStripMenuItem.Click
        Dim frm As New FrmConsultaVentas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConsultaStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaStockToolStripMenuItem.Click
        Dim frm As New FrmConsultaStock
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConsultaMarcaModeloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaMarcaModeloToolStripMenuItem.Click
        Dim frm As New FrmConsultaMarca
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConsultaPrecioDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaPrecioDeVentaToolStripMenuItem.Click
        Dim frm As New FrmPrecioVenta
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
