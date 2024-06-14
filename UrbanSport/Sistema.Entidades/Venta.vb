﻿Public Class Venta
    Private _IdVenta As Integer
    Private _iddetalle_venta As Integer
    Private _IdCliente As Integer
    Private _IdUsuario As Integer
    Private _IdTipo_Venta As Integer
    Private _TipoComprobante As String
    Private _SerieComprobante As String
    Private _NumComprobante As String
    Private _Fecha As Date
    Private _Impuesto As Decimal
    Private _A_Cuenta As Decimal
    Private _Saldo As Decimal
    Private _Total As Decimal
    Private _Estado As String

    Public Property IdVenta As Integer
        Get
            Return _IdVenta
        End Get
        Set(value As Integer)
            _IdVenta = value
        End Set
    End Property

    Public Property IdCliente As Integer
        Get
            Return _IdCliente
        End Get
        Set(value As Integer)
            _IdCliente = value
        End Set
    End Property

    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
        End Set
    End Property

    Public Property TipoComprobante As String
        Get
            Return _TipoComprobante
        End Get
        Set(value As String)
            _TipoComprobante = value
        End Set
    End Property

    Public Property SerieComprobante As String
        Get
            Return _SerieComprobante
        End Get
        Set(value As String)
            _SerieComprobante = value
        End Set
    End Property

    Public Property NumComprobante As String
        Get
            Return _NumComprobante
        End Get
        Set(value As String)
            _NumComprobante = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Impuesto As Decimal
        Get
            Return _Impuesto
        End Get
        Set(value As Decimal)
            _Impuesto = value
        End Set
    End Property

    Public Property A_Cuenta As Decimal
        Get
            Return _A_Cuenta
        End Get
        Set(value As Decimal)
            _A_Cuenta = value
        End Set
    End Property

    Public Property Saldo As Decimal
        Get
            Return _Saldo
        End Get
        Set(value As Decimal)
            _Saldo = value
        End Set
    End Property

    Public Property Total As Decimal
        Get
            Return _Total
        End Get
        Set(value As Decimal)
            _Total = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property




    Public Property IdTipo_Venta As Integer
        Get
            Return _IdTipo_Venta
        End Get
        Set(value As Integer)
            _IdTipo_Venta = value
        End Set
    End Property

    Public Property Iddetalle_venta As Integer
        Get
            Return _iddetalle_venta
        End Get
        Set(value As Integer)
            _iddetalle_venta = value
        End Set
    End Property
End Class
