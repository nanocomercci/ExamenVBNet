Imports Entidades
Imports Interfaces
Imports System.Data.SqlClient

Public Class DVenta
    Inherits Conexion
    Implements IABM(Of Venta)

    Dim cmd As New SqlCommand
    Dim esNuevo As Boolean
    Dim ditem As New DItem

    Public Function Alta(Entidad As Venta) As Boolean Implements IABM(Of Venta).Alta


        'Cadena SQL para el alta
        cmd.CommandText = "INSERT INTO VENTAS(IDCLIENTE, FECHA, TOTAL) VALUES (" & Entidad.Cliente.Id &
            ", '" & Entidad.Fecha.ToString("yyyy-MM-dd") & "', " & Replace(Entidad.Total.ToString, ",", ".") & ") SELECT SCOPE_IDENTITY() as id"

        cmd.CommandType = CommandType.Text

        Try
            'intentamos abrir DB y ejecutar consulta SQL para registrar la venta en la tabla
            Conectar()
            cmd.Connection = Cnn
            Dim dt As New DataTable("Ventas")
            Dim sqladp As New SqlDataAdapter(cmd)
            sqladp.Fill(dt)


            'tomamos el id generado para poder registrar los items

            Dim idventa As Integer = dt.Rows(0).Item("id").ToString
            sqladp.Dispose()
            ' registramos items de venta
            For Each item As Item In Entidad.Items

                cmd.CommandText = "INSERT INTO VENTASITEMS (IDVENTA, IDPRODUCTO, PRECIOUNITARIO, CANTIDAD, PRECIOTOTAL) VALUES
                (" & idventa & ", " & item.Producto.Id & ", " & Replace(item.Producto.Precio.ToString, ",", ".") & ", " & item.Cantidad &
                ", " & Replace(item.PrecioTotal.ToString, ",", ".") & ")"

                cmd.ExecuteNonQuery()
            Next



            Return True




        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        Finally

            'cerramos independientemente del resultado
            Cerrar()


        End Try

    End Function

    Public Function Modificacion(Entidad As Venta) As Boolean Implements IABM(Of Venta).Modificacion
        Throw New NotImplementedException()
    End Function

    Public Function Baja(Entidad As Venta) As Boolean Implements IABM(Of Venta).Baja
        cmd.CommandText = "DELETE FROM VENTAS WHERE ID=" & Entidad.Id
        cmd.CommandType = CommandType.Text

        'PRIMERO BORRAR LOS ITEMS DE LA VENTA
        Try

            For Each item As Item In Entidad.Items

                ditem.Baja(item)

            Next

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

    Public Function Mostrar() As DataTable Implements IABM(Of Venta).Mostrar
        'cadena para mostrar todos los registros de la consulta
        cmd.CommandText = "SELECT DBO.VENTAS.ID, DBO.CLIENTES.CLIENTE, DBO.VENTAS.FECHA, DBO.VENTAS.TOTAL
                           FROM DBO.CLIENTES INNER JOIN DBO.VENTAS ON DBO.CLIENTES.ID = DBO.VENTAS.IDCLIENTE"


        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("ventas")
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

    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Venta).Buscar
        Throw New NotImplementedException()
    End Function

    Public Function Consultar(id As Integer) As Venta Implements IABM(Of Venta).Consultar

        'CONSULTAR EL CLIENTE QUE CORRESPONDE A LA VENTA
        cmd.CommandText = "SELECT DBO.VENTAS.ID, DBO.VENTAS.IDCLIENTE, DBO.VENTASITEMS.ID AS IDITEM, DBO.VENTASITEMS.IDPRODUCTO, 
                          DBO.VENTASITEMS.PRECIOUNITARIO, DBO.VENTASITEMS.CANTIDAD, DBO.VENTASITEMS.PRECIOTOTAL, DBO.VENTAS.FECHA, DBO.VENTAS.TOTAL
                          FROM DBO.VENTAS 
                          INNER JOIN
                          DBO.VENTASITEMS ON DBO.VENTAS.ID = DBO.VENTASITEMS.IDVENTA
                          WHERE  (DBO.VENTAS.ID = " & id & ")"


        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("Ventas")
            Dim sqladp As New SqlDataAdapter(cmd)
            sqladp.Fill(dt)

            'cliente de la venta
            Dim dc As New DCliente
            Dim c As Cliente
            c = dc.Consultar(dt.Rows(0).Item(1).ToString)


            'Objeto prodcuto para almacenar cada producto de cada item
            Dim dp As New DProducto
            Dim p As Producto
            Dim listitem As New List(Of Item)


            For Each fila As DataRow In dt.Rows

                p = dp.Consultar(fila.Item(3).ToString)

                Dim it As New Item(fila.Item(2).ToString, p, fila.Item(4).ToString, fila.Item(5).ToString, fila.Item(6).ToString)

                listitem.Add(it)

            Next

            Dim v As New Venta(dt.Rows(0).Item(0).ToString, c, dt.Rows(0).Item(7).ToString, listitem, dt.Rows(0).Item(8).ToString)



            Return v


        Catch ex As Exception

            MsgBox(ex.Message)

            Return Nothing
        Finally

            'cerramos independientemente del resultado
            Cerrar()


        End Try


    End Function


End Class
