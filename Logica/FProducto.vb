Imports System.Data
Imports Entidades
Imports Datos
Imports Interfaces
Public Class FProducto

    Implements IABM(Of Producto)

    Private dp As New DProducto
    Private resultado As Boolean
    Private dt As New DataTable
    Dim p As Producto
    Public Function Alta(Entidad As Producto) As Boolean Implements IABM(Of Producto).Alta

        resultado = dp.Alta(Entidad)
        Return resultado
    End Function

    Public Function Modificacion(Entidad As Producto) As Boolean Implements IABM(Of Producto).Modificacion

        resultado = dp.Modificacion(Entidad)
        Return resultado
    End Function

    Public Function Baja(Entidad As Producto) As Boolean Implements IABM(Of Producto).Baja

        resultado = dp.Baja(Entidad)
        Return resultado

    End Function

    Public Function Mostrar() As DataTable Implements IABM(Of Producto).Mostrar
        dt = dp.Mostrar()
        Return dt
    End Function

    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Producto).Buscar

        dt = dp.Buscar(BuscaTexto, Critero)
        Return dt

    End Function

    Public Function Consultar(id As Integer) As Producto Implements IABM(Of Producto).Consultar

        p = dp.Consultar(id)
        Return p
    End Function
End Class
