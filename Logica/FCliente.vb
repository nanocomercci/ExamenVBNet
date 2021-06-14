Imports Entidades
Imports Datos
Imports Interfaces
Public Class FCliente
    Implements IABM(Of Cliente)
    Private ReadOnly dc As New DCliente()
    Private Resultado As Boolean
    Private dt As New DataTable
    Dim c As Cliente



    Public Function Alta(Entidad As Cliente) As Boolean Implements IABM(Of Cliente).Alta

        Resultado = dc.Alta(Entidad)
        Return Resultado

    End Function

    Public Function Modificacion(Entidad As Cliente) As Boolean Implements IABM(Of Cliente).Modificacion

        Resultado = dc.Modificacion(Entidad)
        Return Resultado

    End Function

    Public Function Baja(Entidad As Cliente) As Boolean Implements IABM(Of Cliente).Baja

        Resultado = dc.Baja(Entidad)
        Return Resultado

    End Function

    Public Function Mostrar() As DataTable Implements IABM(Of Cliente).Mostrar

        dt = dc.Mostrar
        Return dt

    End Function

    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Cliente).Buscar

        dt = dc.Buscar(BuscaTexto, Critero)
        Return dt

    End Function

    Public Function Consultar(id As Integer) As Cliente Implements IABM(Of Cliente).Consultar

        c = dc.Consultar(id)
        Return c

    End Function
End Class
