Imports Interfaces
Imports Entidades
Imports System.Data.SqlClient

Public Class DProducto
    Inherits Conexion
    Implements IABM(Of Producto)

    ReadOnly cmd As New SqlCommand

    Public Function Alta(Entidad As Producto) As Boolean Implements IABM(Of Producto).Alta
        'Cadena SQL para el alta
        cmd.CommandText = "INSERT INTO PRODUCTOS (NOMBRE, PRECIO, CATEGORIA) VALUES
                           ('" & Entidad.Nombre & "', '" & Replace(Entidad.Precio.ToString, ",", ".") & "','" & Entidad.Categoria & "')"

        cmd.CommandType = CommandType.Text

        Try
            'intentamos abrir DB y ejecutar consulta SQL
            Conectar()
            cmd.Connection = Cnn

            cmd.ExecuteNonQuery()


            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        Finally

            'cerramos independientemente del resultado
            Cerrar()


        End Try
    End Function

    Public Function Modificacion(Entidad As Producto) As Boolean Implements IABM(Of Producto).Modificacion
        'Cadena SQL para modificar el registro
        cmd.CommandText = "UPDATE PRODUCTOS SET NOMBRE='" & Entidad.Nombre & "', PRECIO='" & Replace(Entidad.Precio.ToString, ",", ".") &
                          "', CATEGORIA='" & Entidad.Categoria & "' WHERE ID=" & Entidad.Id


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

    Public Function Baja(Entidad As Producto) As Boolean Implements IABM(Of Producto).Baja
        'Cadena SQL para modificar el registro
        cmd.CommandText = "DELETE FROM PRODUCTOS WHERE ID=" & Entidad.Id


        cmd.CommandType = CommandType.Text

        Try
            'intentamos abrir DB y ejecutar consulta SQL
            Conectar()
            cmd.Connection = Cnn

            cmd.ExecuteNonQuery()

            Return True


        Catch sqlEx As SqlException When sqlEx.Number = 547

            MsgBox("El Prodcuto está afectado a una o más ventas. No se puede eliminar")

            Return False

        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        Finally

            'cerramos independientemente del resultado
            Cerrar()


        End Try
    End Function

    Public Function Mostrar() As DataTable Implements IABM(Of Producto).Mostrar
        'cadena para mostrar todos los registros de la consulta
        cmd.CommandText = "SELECT ID, NOMBRE, PRECIO, CATEGORIA FROM PRODUCTOS"
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("PRODCUTOS")
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

    Public Function Buscar(BuscaTexto As String, Critero As String) As DataTable Implements IABM(Of Producto).Buscar
        'cadena para mostrar los registros que coindicden con la busqueda
        cmd.CommandText = "SELECT ID, NOMBRE, PRECIO, CATEGORIA FROM PRODUCTOS WHERE " & Critero & " LIKE '%" & BuscaTexto & "%'"
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("PRODUCTOS")
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

    Public Function Consultar(id As Integer) As Producto Implements IABM(Of Producto).Consultar
        'cadena para mostrar los registros que coindicden con la busqueda
        cmd.CommandText = "SELECT ID, NOMBRE, PRECIO, CATEGORIA FROM PRODUCTOS WHERE ID=" & id
        cmd.CommandType = CommandType.Text

        Try

            Conectar()
            cmd.Connection = Cnn
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable("PRODUCTOS")
            Dim sqladp As New SqlDataAdapter(cmd)
            sqladp.Fill(dt)
            Dim dr As DataRow = dt.Rows(0)


            Dim P As New Producto(dr.Item(0).ToString(), dr.Item(1).ToString(), dr.Item(2).ToString(), dr.Item(3).ToString())

            Return P

        Catch ex As Exception

            MsgBox(ex.Message)
            Return Nothing

        Finally

            Cerrar()


        End Try
    End Function
End Class
