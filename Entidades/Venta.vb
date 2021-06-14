Public Class Venta

    Private _id As Integer
    Private _cliente As Cliente
    Private _fecha As DateTime
    Private _items As List(Of Item)
    Private _total As Double

    Public Sub New(id As Integer)
        _id = id
    End Sub

    Public Sub New(cliente As Cliente, fecha As Date, items As List(Of Item))
        _cliente = cliente
        _fecha = fecha
        _items = items

        For Each item As Item In items
            _total = _total + item.PrecioTotal
        Next

    End Sub

    Public Sub New(cliente As Cliente, fecha As Date, items As List(Of Item), total As Double)
        _cliente = cliente
        _fecha = fecha
        _items = items
        _total = total
    End Sub

    Public Sub New(id As Integer, cliente As Cliente, fecha As Date, items As List(Of Item), total As Double)
        _id = id
        _cliente = cliente
        _fecha = fecha
        _items = items
        _total = total
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Cliente As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property

    Public Property Items As List(Of Item)
        Get
            Return _items
        End Get
        Set(value As List(Of Item))
            _items = value
        End Set
    End Property

    Public Property Total As Double
        Get
            Return _total
        End Get
        Set(value As Double)
            _total = value
        End Set
    End Property
End Class
