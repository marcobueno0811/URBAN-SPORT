Imports Sistema.Datos
Imports Sistema.Entidades

Public Class NCategoria
    Public Function Listar() As DataTable
        Try
            Dim Datos As New DCategoria
            Dim Tabla As New DataTable
            Tabla = Datos.listar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Buscar(Valor As String) As DataTable
        Try
            Dim Datos As New DCategoria
            Dim Tabla As New DataTable
            Tabla = Datos.Buscar(Valor)
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Seleccionar() As DataTable
        Try
            Dim Datos As New DCategoria
            Dim Tabla As New DataTable
            Tabla = Datos.Seleccionar()
            Return Tabla
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function Insertar(Obj As Categoria) As Boolean
        Try
            Dim Datos As New DCategoria
            Datos.Insertar(Obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Actualizar(Obj As Categoria) As Boolean
        Try
            Dim Datos As New DCategoria
            Datos.Actualizar(Obj)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Eliminar(Id As Integer) As Boolean
        Try
            Dim Datos As New DCategoria
            Datos.Eliminar(Id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Desactivar(Id As Integer) As Boolean
        Try
            Dim Datos As New DCategoria
            Datos.Desactivar(Id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function Activar(id As Integer) As Boolean
        Try
            Dim Datos As New DCategoria
            Datos.Activar(id)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
