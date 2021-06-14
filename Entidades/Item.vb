Public Class Item


    Private _id As Integer
    Private _producto As Producto
    Private _precioUnitario As Double
    Private _cantidad As Integer
    Private _precioTotal As Double

    Public Sub New(id As Integer)
        _id = id
    End Sub

    Public Sub New(producto As Producto, precioUnitario As Double, cantidad As Integer, precioTotal As Double)
        _producto = producto
        _precioUnitario = precioUnitario
        _cantidad = cantidad
        _precioTotal = precioTotal
    End Sub

    Public Sub New(id As Integer, producto As Producto, precioUnitario As Double, cantidad As Integer, precioTotal As Double)
        Me.Id = id
        Me.Producto = producto
        Me.PrecioUnitario = precioUnitario
        Me.Cantidad = cantidad
        Me.PrecioTotal = precioTotal
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Producto As Producto
        Get
            Return _producto
        End Get
        Set(value As Producto)
            _producto = value
        End Set
    End Property

    Public Property PrecioUnitario As Double
        Get
            Return _precioUnitario
        End Get
        Set(value As Double)
            _precioUnitario = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Public Property PrecioTotal As Double
        Get
            Return _precioTotal
        End Get
        Set(value As Double)
            _precioTotal = value
        End Set
    End Property
End Class
