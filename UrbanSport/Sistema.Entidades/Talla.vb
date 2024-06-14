Public Class Talla
    Private _IdTalla As Integer
    Private _Talla As String
    Private _Estado As Boolean

    Public Property IdTalla As Integer
        Get
            Return _IdTalla
        End Get
        Set(value As Integer)
            _IdTalla = value
        End Set
    End Property

    Public Property Talla As String
        Get
            Return _Talla
        End Get
        Set(value As String)
            _Talla = value
        End Set
    End Property

    Public Property Estado As Boolean
        Get
            Return _Estado
        End Get
        Set(value As Boolean)
            _Estado = value
        End Set
    End Property
End Class
