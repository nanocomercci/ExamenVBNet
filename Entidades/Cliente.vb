Public Class Cliente

    Private _id As Integer
    Private _Cliente As String
    Private _telefono As String
    Private _correo As String

    Public Sub New(cliente As String, telefono As String, correo As String)
        _Cliente = cliente
        _telefono = telefono
        _correo = correo
    End Sub

    Public Sub New(id As Integer, cliente As String, telefono As String, correo As String)
        _id = id
        _Cliente = cliente
        _telefono = telefono
        _correo = correo
    End Sub

    Public Sub New(id As Integer)
        _id = id
    End Sub



    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _Cliente
        End Get
        Set(value As String)
            _Cliente = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _correo
        End Get
        Set(value As String)
            _correo = value
        End Set
    End Property
End Class
