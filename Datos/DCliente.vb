Imports System.Data.SqlClient
Imports Entidades
Imports Interfaces
Public Class DCliente
    Inherits Conexion
    Implements IABM(Of Cliente)

    ReadOnly cmd As New SqlCommand

    Public Function Alta(Entidad As Cliente) As Boolean Implements IABM(Of Cliente).Alta

        'Cadena SQL para el alta
        cmd.CommandText = "INSERT INTO CLIENTES(CLIENTE, TELEFONO, CORREO) VALUES
                           ('" & Entidad.Cliente & "', '" & Entidad.Telefono & "','" & Entidad.Correo & "')"

        cmd.CommandType = CommandType.Text

        Try
            'intentamos abrir DB y ejecutar consulta SQL
            Conectar()
            cmd.Connection = Cnn

            If cmd.ExecuteNonQuery Then

                Return True

            Else

                Return False


            End If

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        Finally

            'cerramos independientemente del resultado
            Cerrar()


        End Try


    End Function

    Public Function Modificacion(Entidad As Cliente) As Boolean Implements IABM(Of Cliente).Modificacion


        'Cadena SQL para modificar el registro
        cmd.CommandText = "UPDATE CLIENTES SET CLIENTE='" & Entidad.Cliente & "', TELEFONO='" & Entidad.Telefono &
                          "', CORREO='" & Entidad.Correo & "' WHERE ID=" & Entidad.Id


        cmd.CommandType = CommandType.Text

        Try
            'intentamos abrir DB y ejecutar consulta SQL
            Conectar()
            cmd.Connection = Cnn

            If cmd.ExecuteNonQuery Then

                Return True

            Else

                Return False


            End If

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        Finally

            'cerramos independientemente del resultado
            Cerrar()


        End Try

    End Function

    Public Function Baja(Entidad As Cliente) As Boolean Implements IABM(Of Cliente).Baja
        'Cadena SQL para modificar el registro
        cmd.CommandText = "DELETE FROM CLIENTES WHERE ID=" & Entidad.Id


        cmd.CommandType = CommandType.Text

        Try
            'intentamos abrir DB y ejecutar consulta SQL
            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()

            Return True


        Catch sqlEx As SqlException When sqlEx.Number = 547

            MsgBox("El cliente registra una o más ventas. No puede eliminarse")
            Return False

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False



        Finally

            'cerramos independientemente del resultado
            Cerrar()


        End Try
    End Function

    Public Function Mostrar() As DataTable Implements IABM(Of Cliente).Mostrar

        'cadena para mostrar todos los registros de la consulta
        cmd.CommandText = "SELECT ID, CLIENTE, TELEFONO, CORREO FROM CLIENTES"
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("Clientes")
            Dim sqladp As New SqlDataAdapter(cmd)
            sqladp.Fill(dt)

            Return dt

        Catch ex As Exception

            MsgBox(ex.Message)
            Return Nothing

        Finally

            Cerrar()


        End Try

    End Function


    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Cliente).Buscar


        'cadena para mostrar los registros que coindicden con la busqueda
        cmd.CommandText = "SELECT ID, CLIENTE, TELEFONO, CORREO FROM CLIENTES WHERE " & Critero & " LIKE '%" & BuscaTexto & "%'"
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("Clientes")
            Dim sqladp As New SqlDataAdapter(cmd)
            sqladp.Fill(dt)


            Return dt

        Catch ex As Exception

            MsgBox(ex.Message)
            Return Nothing

        Finally

            Cerrar()


        End Try
    End Function

    Public Function Consultar(id As Integer) As Cliente Implements IABM(Of Cliente).Consultar

        'cadena para mostrar los registros que coindicden con la busqueda
        cmd.CommandText = "SELECT ID, CLIENTE, TELEFONO, CORREO FROM CLIENTES WHERE ID=" & id
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("CLIENTES")
            Dim sqladp As New SqlDataAdapter(cmd)
            sqladp.Fill(dt)
            Dim dr As DataRow = dt.Rows(0)

            Dim c As New Cliente(dr.Item(0).ToString(), dr.Item(1).ToString(), dr.Item(2).ToString(), dr.Item(3).ToString())

            Return c

        Catch ex As Exception

            MsgBox(ex.Message)
            Return Nothing

        Finally

            Cerrar()


        End Try
    End Function
End Class
