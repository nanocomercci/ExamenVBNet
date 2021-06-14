Imports Entidades
Imports Logica



Public Class FrmClienteBusqueda
    ReadOnly fc As New FCliente

    Private Sub FrmClienteBusqueda_Load(sender As Object, e As EventArgs) Handles Me.Load
        Mostrar()
        dgvClientes.Columns(0).Visible = False
        Me.ComboBox1.SelectedIndex = 0


    End Sub

    Private Sub Mostrar()

        Me.dgvClientes.DataSource = fc.Mostrar()

    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged

        If Me.TxtBuscar.TextLength > 3 Then

            Me.dgvClientes.DataSource = fc.Buscar(Me.TxtBuscar.Text, Me.ComboBox1.Text)

        ElseIf TxtBuscar.Text = String.Empty Then

            Mostrar()
            Exit Sub

        End If

    End Sub

    Private Sub dgvClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellDoubleClick

        Dim frm As frmVentaDetalle = CType(Owner, frmVentaDetalle)


        frm.txtIdCliente.Text = Me.dgvClientes.SelectedCells(0).Value
        frm.TxtCliente.Text = Me.dgvClientes.SelectedCells(1).Value
        frm.TxtTelefono.Text = Me.dgvClientes.SelectedCells(2).Value
        frm.TxtCorreo.Text = Me.dgvClientes.SelectedCells(3).Value
        Me.Close()
        frm.GroupBox2.Enabled = True
        frm.Button2.Enabled = False


    End Sub

    Private Sub dgvClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick

    End Sub
End Class