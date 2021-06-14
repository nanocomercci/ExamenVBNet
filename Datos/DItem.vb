Imports Entidades
Imports Interfaces
Imports System.Data.SqlClient

Public Class DItem
    Inherits Conexion
    Implements IABM(Of Item)
    Dim cmd As New SqlCommand

    Public Function Alta(Entidad As Item) As Boolean Implements IABM(Of Item).Alta
        Throw New NotImplementedException()
    End Function

    Public Function Modificacion(Entidad As Item) As Boolean Implements IABM(Of Item).Modificacion
        cmd.CommandText = "UPDATE VENTASITEMS SET PRECIOUNITARIO=" & Replace(Entidad.PrecioUnitario.ToString, ",", ".") &
        ", CANTIDAD=" & Entidad.Cantidad & ", PRECIOTOTAL=" & Replace(Entidad.PrecioTotal.ToString, ",", ".") & " WHERE ID=" & Entidad.Id
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False
        Finally
            Cerrar()


        End Try
    End Function

    Public Function Baja(Entidad As Item) As Boolean Implements IABM(Of Item).Baja
        'Cadena SQL para modificar el registro
        cmd.CommandText = "DELETE FROM VENTASITEMS WHERE ID=" & Entidad.Id


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

    Public Function Mostrar() As DataTable Implements IABM(Of Item).Mostrar
        Throw New NotImplementedException()
    End Function

    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Item).Buscar
        Throw New NotImplementedException()
    End Function

    Public Function Consultar(id As Integer) As Item Implements IABM(Of Item).Consultar
        cmd.CommandText = "SELECT ID, IDVENTA, IDPRODUCTO, PRECIOUNITARIO, CANTIDAD, PRECIOTOTAL FROM VENTASITEMS WHERE ID=" & id
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            Dim dt As New DataTable("CLIENTES")
            Dim sqladp As New SqlDataAdapter(cmd)
            sqladp.Fill(dt)
            Dim dr As DataRow = dt.Rows(0)

            Dim dp As New DProducto
            Dim p As Producto

            p = dp.Consultar(dr.Item(2).ToString)

            Dim item As New Item(dr.Item(0).ToString, p, dr.Item(3).ToString, dr.Item(4).ToString, dr.Item(5).ToString)

            Return item

        Catch ex As Exception

            MsgBox(ex.Message)
            Return Nothing

        Finally

            Cerrar()


        End Try
    End Function

    Public Function AgregarItemVenta(v As Venta, item As Item) As Boolean

        cmd.CommandText = "INSERT INTO VENTASITEMS(IDVENTA, IDPRODUCTO, PRECIOUNITARIO, CANTIDAD, PRECIOTOTAL)
                           VALUES(" & v.Id & ", " & item.Producto.Id & ", " & Replace(item.PrecioUnitario.ToString, ",", ".") & ", " & item.Cantidad & ", " & Replace(item.PrecioTotal.ToString, ",", ".") & ")"
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        Finally

            Cerrar()


        End Try


    End Function

End Class
