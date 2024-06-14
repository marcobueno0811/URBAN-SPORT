Public Class FrmLogin
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        End
    End Sub

    Private Sub BtnAcceder_Click(sender As Object, e As EventArgs) Handles BtnAcceder.Click
        Try
            Dim email As String, clave As String
            Dim obj As New Entidades.Usuario
            Dim neg As New Negocio.NUsuario
            email = TxtEmail.Text.Trim()
            clave = TxtClave.Text.Trim()
            obj = neg.Login(email, clave)
            If (obj Is Nothing) Then
                MsgBox("no existe un usuario con ese email o clave", vbOKOnly + vbCritical, "Datos Incorrectos")
            Else
                If (obj.Estado = False) Then
                    MsgBox("el usuario no esta activo", vbOKOnly + vbCritical, "Usuario no tiene acceso")
                Else
                    Me.Hide()

                    frmPrincipal.IdUsuario = obj.IdUsuario
                    Variables.IdUsuario = obj.IdUsuario
                    frmPrincipal.IdRol = obj.IdRol
                    frmPrincipal.Rol = obj.Rol
                    frmPrincipal.Nombre = obj.Nombre
                    frmPrincipal.Show()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtClave.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Try
                Dim email As String, clave As String
                Dim obj As New Entidades.Usuario
                Dim neg As New Negocio.NUsuario
                email = TxtEmail.Text.Trim()
                clave = TxtClave.Text.Trim()
                obj = neg.Login(email, clave)
                If (obj Is Nothing) Then
                    MsgBox("no existe un usuario con ese email o clave", vbOKOnly + vbCritical, "Datos Incorrectos")
                Else
                    If (obj.Estado = False) Then
                        MsgBox("el usuario no esta activo", vbOKOnly + vbCritical, "Usuario no tiene acceso")
                    Else
                        Me.Hide()

                        frmPrincipal.IdUsuario = obj.IdUsuario
                        Variables.IdUsuario = obj.IdUsuario
                        frmPrincipal.IdRol = obj.IdRol
                        frmPrincipal.Rol = obj.Rol
                        frmPrincipal.Nombre = obj.Nombre
                        frmPrincipal.Show()
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub
End Class