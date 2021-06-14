Imports Entidades
Imports Logica
Public Class frmVentaEdicion

    Dim v As Venta
    Dim p As Producto
    Dim it As Item

    Dim fv As New FVenta
    Dim fp As New FProducto
    Dim fi As New FItem

    Dim esNuevo As Boolean
    Private Sub frmVentaEdicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ComboBox1.Enabled = False
        Me.ComboBox1.DataSource = fp.Mostrar
        Me.ComboBox1.DisplayMember = "nombre"
        Me.ComboBox1.ValueMember = "id"
        Me.NumCantidad.Enabled = False


    End Sub

    Friend Sub Cargar(v As Venta)

        Me.txtIdCliente.Text = v.Cliente.Id
        Me.TxtCliente.Text = v.Cliente.Cliente
        Me.TxtTelefono.Text = v.Cliente.Telefono
        Me.TxtCorreo.Text = v.Cliente.Correo

        For Each item As Item In v.Items

            Dim fila As New DataGridViewRow
            fila.CreateCells(Me.DataGridView1)
            fila.Cells(0).Value = item.Id
            fila.Cells(1).Value = item.Producto.Id
            fila.Cells(2).Value = item.Producto.Nombre
            fila.Cells(3).Value = Format(item.PrecioUnitario, "$ #,###,##0.00")
            fila.Cells(4).Value = item.Cantidad
            fila.Cells(5).Value = Format(item.PrecioTotal, "$ #,###,##0.00")
            fila.DefaultCellStyle.BackColor = Color.LightGreen

            Me.DataGridView1.Rows.Add(fila)


        Next
        Me.TextBox1.Text = v.Id
        Me.txtFecha.Text = v.Fecha.ToString("dd/MM/yyyy")
        Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Select Case e.ColumnIndex

            Case 6
                EliminarItem(Me.DataGridView1.SelectedCells(0).Value)
            Case 7
                Me.DataGridView1.Enabled = False
                Me.NumCantidad.Enabled = True
                Me.BtnGuardaItem.Visible = True


                esNuevo = False

                it = fi.Consultar(Me.DataGridView1.SelectedCells(0).Value)

                Me.ComboBox1.SelectedValue = it.Producto.Id

                Me.txtPrecioU.Text = it.PrecioUnitario
                Me.txtPrecioT.Text = it.PrecioTotal
                Me.NumCantidad.Value = it.Cantidad
                Me.NumCantidad.Enabled = True
            Case Else
                Exit Sub

        End Select


    End Sub

    Public Sub EditarItem()
        esNuevo = False

        it = fi.Consultar(Me.DataGridView1.SelectedCells(0).Value)

        it.Cantidad = Me.NumCantidad.Value
        it.PrecioTotal = Me.txtPrecioT.Text
        fi.Modificacion(it)
        actualizarGrid()
        Me.DataGridView1.Enabled = True
        Me.NumCantidad.Enabled = False
        Me.BtnGuardaItem.Visible = False





    End Sub

    Sub actualizarGrid()

        Me.DataGridView1.Rows.Clear()
        v = fv.Consultar(Me.TextBox1.Text)
        For Each item As Item In v.Items

            Dim fila As New DataGridViewRow
            fila.CreateCells(Me.DataGridView1)
            fila.Cells(0).Value = item.Id
            fila.Cells(1).Value = item.Producto.Id
            fila.Cells(2).Value = item.Producto.Nombre
            fila.Cells(3).Value = item.PrecioUnitario
            fila.Cells(4).Value = item.Cantidad
            fila.Cells(5).Value = item.PrecioTotal
            fila.DefaultCellStyle.BackColor = Color.LightGreen

            Me.DataGridView1.Rows.Add(fila)

        Next
    End Sub

    Private Sub EliminarItem(id As Integer)

        If Me.DataGridView1.Rows.Count = 1 Then

            MsgBox("NO SE PUEDE REGISTRAR UNA VENTA SIN ITEMS, DEBE ELIMINAR LA VENTA COMPLETA")

            Exit Sub

        End If

        Dim conf As String = MsgBox("¿ESTÁ SEGURO QUE DESE ELEMINAR ESTE ITEM?", vbYesNo + vbCritical)

        If conf = vbYes Then

            it = New Item(id)
            fi.Baja(it)
            actualizarGrid()

        End If

    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs)

        Dim frm As New frmProductoBusqueda
        AddOwnedForm(frm)
        frm.ShowDialog()

    End Sub

    Private Sub calularTotal()
        If Me.DataGridView1.Rows.Count < 1 Then Exit Sub

        Dim valor As Double
        For Each fila As DataGridViewRow In Me.DataGridView1.Rows



            valor = valor + fila.Cells(5).Value


        Next

        Me.lblTotal.Text = "TOTAL VENTA: " & Format(valor, "$ #,###,##0.00")
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        calularTotal()

    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        calularTotal()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        esNuevo = True
        Me.ComboBox1.Enabled = True
        Me.ComboBox1.Text = ""
        Me.NumCantidad.Enabled = True
        Me.BtnGuardaItem.Visible = True


    End Sub

    Private Sub AgregarItem()


        p = fp.Consultar(Me.ComboBox1.SelectedValue)

        it = New Item(p, Me.txtPrecioU.Text, Me.NumCantidad.Value, Me.txtPrecioT.Text)

        v = New Venta(Me.TextBox1.Text)

        Dim resultado As Boolean = fi.AgregarItemVenta(v, it)

        If resultado Then

            actualizarGrid()
        Else
            MsgBox("No se agregó el item")

        End If

        Me.ComboBox1.Enabled = False
        Me.ComboBox1.Text = ""
        Me.NumCantidad.Enabled = False
        Me.NumCantidad.Value = 1


    End Sub

    Private Sub BtnGuardaItem_Click(sender As Object, e As EventArgs) Handles BtnGuardaItem.Click
        If esNuevo Then
            AgregarItem()
        Else
            EditarItem()
        End If

    End Sub



    Private Sub CalcularPrecioItem()



    End Sub



    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged

        If Me.ComboBox1.Enabled = False Then Exit Sub


        p = fp.Consultar(Me.ComboBox1.SelectedValue.ToString)
        Me.txtPrecioU.Text = p.Precio
        Me.txtPrecioT.Text = p.Precio
        Me.NumCantidad.Value = 1


    End Sub

    Private Sub NumCantidad_ValueChanged(sender As Object, e As EventArgs) Handles NumCantidad.ValueChanged
        If Me.NumCantidad.Enabled = False Then Exit Sub
        Me.txtPrecioT.Text = Format(Me.txtPrecioU.Text * NumCantidad.Value, "$ #,###,##0.00")

    End Sub

    Friend Sub CalcularPrecio(p As Producto, cant As Integer)


        Me.txtPrecioT.Text = Format(it.PrecioTotal, "$ #,###,##0.00")

    End Sub
End Class