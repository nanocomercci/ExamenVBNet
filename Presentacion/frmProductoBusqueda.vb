Imports Entidades
Imports Logica

Public Class frmProductoBusqueda

    Dim fp As New FProducto
    Dim p As Producto
    Dim it As Item
    Dim fi As New FItem
    Private Sub frmProductoBusqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
        Me.dgvProductos.Columns(0).Visible = False
        Me.ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        If Me.TxtBuscar.TextLength > 3 Then

            Me.dgvProductos.DataSource = fp.Buscar(Me.TxtBuscar.Text, Me.ComboBox1.Text)

        ElseIf TxtBuscar.Text = String.Empty Then

            Mostrar()
            Exit Sub

        End If

    End Sub

    Public Sub Mostrar()
        Me.dgvProductos.DataSource = fp.Mostrar()
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick


        Dim frm As frmVentaDetalle = CType(Owner, frmVentaDetalle)
        p = fp.Consultar(dgvProductos.SelectedCells(0).Value)
        it = New Item(p, p.Precio, 1, p.Precio)



        frm.txtIdProducto.Text = it.Producto.Id
        frm.txtProdcuto.Text = it.Producto.Nombre
        frm.txtPrecioU.Text = Format(it.Producto.Precio, "$ #,###,##0.00")
        frm.txtPrecioT.Text = Format(it.Producto.Precio, "$ #,###,##0.00")
        Me.Close()
        frm.Button2.Enabled = True


    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub dgvProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellContentClick

    End Sub
End Class