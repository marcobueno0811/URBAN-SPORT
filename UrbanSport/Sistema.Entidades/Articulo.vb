Public Class Articulo
    Private _IdArticulo As Integer
    Private _IdCategoria As Integer
    Private _Categoria As String
    Private _Codigo As String
    Private _Marca As String
    Private _Modelo As String
    Private _IdTalla As Integer
    Private _Talla As String
    Private _PrecioVenta As Decimal
    Private _Stock As Integer
    Private _Imagen As String
    Private _Estado As Boolean
    Private _Descuento As Decimal


    Public Property IdArticulo As Integer
        Get
            Return _IdArticulo
        End Get
        Set(value As Integer)
            _IdArticulo = value
        End Set
    End Property

    Public Property IdCategoria As Integer
        Get
            Return _IdCategoria
        End Get
        Set(value As Integer)
            _IdCategoria = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return _Codigo
        End Get
        Set(value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Marca As String
        Get
            Return _Marca
        End Get
        Set(value As String)
            _Marca = value
        End Set
    End Property

    Public Property Modelo As String
        Get
            Return _Modelo
        End Get
        Set(value As String)
            _Modelo = value
        End Set
    End Property

    Public Property IdTalla As Integer
        Get
            Return _IdTalla
        End Get
        Set(value As Integer)
            _IdTalla = value
        End Set
    End Property

    Public Property Talla As Object
        Get
            Return _Talla
        End Get
        Set(value As Object)
            _Talla = value
        End Set
    End Property

    Public Property PrecioVenta As Decimal
        Get
            Return _PrecioVenta
        End Get
        Set(value As Decimal)
            _PrecioVenta = value
        End Set
    End Property

    Public Property Stock As Integer
        Get
            Return _Stock
        End Get
        Set(value As Integer)
            _Stock = value
        End Set
    End Property

    Public Property Imagen As String
        Get
            Return _Imagen
        End Get
        Set(value As String)
            _Imagen = value
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

    Public Property Categoria As String
        Get
            Return _Categoria
        End Get
        Set(value As String)
            _Categoria = value
        End Set
    End Property

    Public Property Descuento As Decimal
        Get
            Return _Descuento
        End Get
        Set(value As Decimal)
            _Descuento = value
        End Set
    End Property
End Class
