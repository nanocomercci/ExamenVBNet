Imports Entidades
Imports Interfaces
Imports Logica

Public Class frmVentaDetalle

    Dim esNuevo As Boolean = True
    Dim resultado As Boolean

    Dim fv As New FVenta
    Dim fp As New FProducto
    Dim fc As New FCliente
    Dim fi As New FItem

    Dim p As Producto
    Dim c As Cliente
    Dim v As Venta
    Dim it As Item



    Private Sub Habilitar(valor As Boolean)
        Me.GroupBox2.Enabled = valor
    End Sub

    Private Sub Limpiar()


    End Sub

    Private Sub BtnBuscarCliente_Click(sender As Object, e As EventArgs) Handles BtnBuscarCliente.Click

        Dim frm As New FrmClienteBusqueda

        AddOwnedForm(frm)
        frm.ShowDialog()


    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click

        Dim frm As New frmProductoBusqueda
        AddOwnedForm(frm)
        frm.ShowDialog()

    End Sub

    Private Sub NumCantidad_ValueChanged(sender As Object, e As EventArgs) Handles NumCantidad.ValueChanged
        If Me.txtIdProducto.Text = String.Empty Then Exit Sub

        Me.txtPrecioT.Text = Format(Me.txtPrecioU.Text * Me.NumCantidad.Value, "$ #,###,##0.00")


    End Sub

    Friend Sub CalcularPrecio(p As Producto, cant As Integer)



        'Me.txtPrecioT.Text = Format(it.PrecioTotal, "$ #,###,##0.00")

    End Sub

    Private Sub frmVentaDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.GroupBox2.Enabled = False

    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If e.ColumnIndex = 5 Then

            Dim conf As String = MsgBox("¿ESTÁ SEGURO QUE DESE ELEMINAR ESTE ITEM?", vbYesNo + vbCritical)
            If conf = vbYes Then

                DataGridView1.Rows.RemoveAt(e.RowIndex)


            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim arr = New String() {Me.txtIdProducto.Text, Me.txtProdcuto.Text, Me.txtPrecioU.Text, Me.NumCantidad.Value, Me.txtPrecioT.Text}
        Me.DataGridView1.Rows.Add(arr)

        Me.txtIdProducto.Text = String.Empty
        Me.txtProdcuto.Text = String.Empty
        Me.txtPrecioT.Text = String.Empty
        Me.txtPrecioU.Text = String.Empty


        Me.NumCantidad.Value = 1
        Me.Button2.Enabled = False



    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs)

        If Me.DataGridView1.Rows.Count < 1 Then

            MsgBox("No existen items para esta venta")
            Exit Sub

        End If

        c = fc.Consultar(Me.txtIdCliente.Text)

        Dim listaitems As New List(Of Item)

        For Each fila As DataGridViewRow In Me.DataGridView1.Rows

            p = fp.Consultar(fila.Cells("COD").Value)
            it = New Item(p, p.Precio, fila.Cells("CANT").Value, p.Precio * fila.Cells("CANT").Value)
            listaitems.Add(it)

        Next



        v = New Venta(c, Me.DateTimePicker1.Value.ToString("yyyy-MM-dd"), listaitems)

        resultado = fv.Alta(v)
        If resultado Then
            MsgBox("La venta fue registrada")
            Limpiar()
            Habilitar(False)
        Else
            MsgBox("La venta no fue registrada")
        End If





    End Sub

    Private Sub CalcularTotal()

        If Me.DataGridView1.Rows.Count < 1 Then Exit Sub

        Dim valor As Double
        For Each fila As DataGridViewRow In Me.DataGridView1.Rows



            valor = valor + fila.Cells(4).Value


        Next

        Me.lblTotal.Text = "TOTAL VENTA: " & Format(valor, "$ #,###,##0.00")

    End Sub


    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        CalcularTotal()

    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        CalcularTotal()
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnGuardar_Click_1(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If Me.DataGridView1.Rows.Count < 1 Then

            MsgBox("No existen items para esta venta")
            Exit Sub

        End If

        c = fc.Consultar(Me.txtIdCliente.Text)

        Dim listaitems As New List(Of Item)

        For Each fila As DataGridViewRow In Me.DataGridView1.Rows

            p = fp.Consultar(fila.Cells("COD").Value)
            it = New Item(p, p.Precio, fila.Cells("CANT").Value, p.Precio * fila.Cells("CANT").Value)
            listaitems.Add(it)

        Next



        v = New Venta(c, Me.DateTimePicker1.Value.ToString("yyyy-MM-dd"), listaitems)

        resultado = fv.Alta(v)
        If resultado Then
            MsgBox("La venta fue registrada")
            Limpiar()
            Habilitar(False)
        Else
            MsgBox("La venta no fue registrada")
        End If

    End Sub

    Private Sub BtnCanelar_Click(sender As Object, e As EventArgs) Handles BtnCanelar.Click
        Me.GroupBox1.Enabled = False
        Me.TxtCliente.Text = String.Empty
        Me.txtIdCliente.Text = String.Empty
        Me.TxtCorreo.Text = String.Empty
        Me.TxtTelefono.Text = String.Empty
        Me.txtIdProducto.Text = String.Empty
        Me.txtPrecioT.Text = String.Empty
        Me.txtProdcuto.Text = String.Empty
        Me.txtPrecioU.Text = String.Empty
        Me.DataGridView1.Rows.Clear()
    End Sub

    Private Sub frmVentaDetalle_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dim frm As frmVentas = CType(Owner, frmVentas)
        frm.mostrar()

    End Sub
End Class