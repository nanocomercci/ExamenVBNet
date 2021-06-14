Imports Entidades
Imports Datos
Imports Interfaces


Public Class FVenta
    Implements IABM(Of Venta)
    Private ReadOnly dv As New DVenta()
    Private Resultado As Boolean
    Private dt As New DataTable

    Public Function Alta(Entidad As Venta) As Boolean Implements IABM(Of Venta).Alta
        Resultado = dv.Alta(Entidad)
        Return Resultado
    End Function

    Public Function Modificacion(Entidad As Venta) As Boolean Implements IABM(Of Venta).Modificacion
        Resultado = dv.Modificacion(Entidad)
        Return Resultado
    End Function

    Public Function Baja(Entidad As Venta) As Boolean Implements IABM(Of Venta).Baja
        Resultado = dv.Baja(Entidad)
        Return Resultado
    End Function

    Public Function Mostrar() As DataTable Implements IABM(Of Venta).Mostrar
        dt = dv.Mostrar
        Return dt
    End Function

    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Venta).Buscar
        dt = dv.Buscar(BuscaTexto, Critero)
        Return dt

    End Function


    Public Function Consultar(id As Integer) As Venta Implements IABM(Of Venta).Consultar
        Dim v As Venta
        v = dv.Consultar(id)
        Return v

    End Function
End Class
