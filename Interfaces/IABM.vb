Imports System.Data
Public Interface IABM(Of T)



    Function Alta(Entidad As T) As Boolean

    Function Modificacion(Entidad As T) As Boolean

    Function Baja(Entidad As T) As Boolean

    Function Mostrar() As DataTable

    Function Buscar(BuscaTexto As String, Critero As String) As DataTable

    Function Consultar(id As Integer) As T




End Interface
