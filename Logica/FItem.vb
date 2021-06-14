Imports Entidades
Imports Interfaces
Imports Datos


Public Class FItem
    Implements IABM(Of Item)

    Private di As New DItem
    Private resultado As Boolean
    Private dt As New DataTable
    Dim it As Item

    Public Function Alta(Entidad As Item) As Boolean Implements IABM(Of Item).Alta
        Throw New NotImplementedException()
    End Function

    Public Function Modificacion(Entidad As Item) As Boolean Implements IABM(Of Item).Modificacion
        resultado = di.Modificacion(Entidad)
        Return resultado
    End Function

    Public Function Baja(Entidad As Item) As Boolean Implements IABM(Of Item).Baja
        resultado = di.Baja(Entidad)
        Return resultado

    End Function

    Public Function Mostrar() As DataTable Implements IABM(Of Item).Mostrar
        Throw New NotImplementedException()
    End Function

    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Item).Buscar
        Throw New NotImplementedException()
    End Function

    Public Function Consultar(id As Integer) As Item Implements IABM(Of Item).Consultar
        it = di.Consultar(id)
        Return it
    End Function

    Public Function AgregarItemVenta(v As Venta, item As Item)

        resultado = di.AgregarItemVenta(v, item)
        Return resultado


    End Function
End Class
