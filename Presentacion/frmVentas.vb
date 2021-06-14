Imports Entidades
Imports Logica
Public Class frmVentas
    Dim fv As New FVenta
    Friend Sub mostrar()
        Me.DataGridView1.DataSource = fv.Mostrar()


    End Sub
    Private Sub frmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mostrar()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Me.btnEditar.Enabled = True
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick





    End Sub



    Private Sub btnEliminar_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub frmVentas_Activated(sender As Object, e As EventArgs) Handles Me.Activated


    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click

        Dim frm As New frmVentaDetalle
        AddOwnedForm(frm)
        frm.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub DataGridView1_LostFocus(sender As Object, e As EventArgs) Handles DataGridView1.LostFocus


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Editar()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Editar()
    End Sub

    Private Sub Editar()
        Dim frm As New frmVentaEdicion
        Dim v As Venta
        v = fv.Consultar(Me.DataGridView1.SelectedCells(0).Value)
        frm.Cargar(v)
        frm.ShowDialog()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Me.btnEditar.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim conf As String = MsgBox("¿ESTÁ SEGURO QUE DESE ELEMINAR DEFINITIVAMENTE ESTA VENTA Y TODOS SUS ITEMS?", vbYesNo + vbCritical)
        If conf = vbYes Then

            Dim v As Venta
            Dim fv As New FVenta

            v = fv.Consultar(Me.DataGridView1.SelectedCells(0).Value)
            Dim Res As Boolean = fv.Baja(v)
            If Res Then

                MsgBox("SE ELIMINÓ LA VENTA")
                mostrar()

            Else

                MsgBox("NO SE ELIMINÓ EL REGISTRO")

            End If

        Else

            Exit Sub

        End If

    End Sub
End Class