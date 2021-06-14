Imports Logica
Imports Entidades
Imports Interfaces
Imports System.Globalization.CultureInfo

Public Class FrmProdcuto
    Implements IFormulario
    ReadOnly fp As New FProducto
    Dim res As Boolean
    Dim EsNuevo As Boolean = True
    Dim p As Producto

    Private Sub FrmProdcuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Mostrar()
        Habilitar(False)
        Me.dgvProductos.Columns(0).Visible = False
        Me.dgvProductos.ClearSelection()
        Me.ComboBox1.SelectedIndex = 0
        Btn_Nuevo.Select()

    End Sub

    Public Sub Habilitar(valor As Boolean) Implements IFormulario.Habilitar

        Me.GroupBox1.Enabled = valor
        Me.GroupBox2.Enabled = Not valor
        Me.BtnCanelar.Enabled = valor
        Me.BtnEditar.Enabled = valor
        Me.BtnEditar.Visible = Not valor
        Me.BtnGuardar.Enabled = valor
        Me.Btn_Nuevo.Enabled = Not valor
        Me.BtnEliminar.Enabled = valor

    End Sub


    Public Sub Limpiar() Implements IFormulario.Limpiar

        Me.TxtNombre.Text = String.Empty
        Me.TxtPrecio.Text = String.Empty
        Me.TxtCategoria.Text = String.Empty

    End Sub

    Public Function Validar() As Boolean Implements IFormulario.Validar

        Dim Valida As Boolean = True
        Dim esDecimal As Boolean = Double.TryParse(Me.TxtPrecio.Text, 10.5)

        For Each txtbox As TextBox In Me.GroupBox1.Controls.OfType(Of TextBox)

            If txtbox.TextLength = 0 Then

                ErrorProvider1.SetError(txtbox, "Dato Obligatorio")
                ErrorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink
                txtbox.Select()
                Valida = False

            End If

        Next

        If esDecimal = False Then
            ErrorProvider1.SetError(Me.TxtPrecio, "formato no valido")
            ErrorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink
            Valida = False



        End If



        Return Valida

    End Function
    Public Sub Mostrar()
        Me.dgvProductos.DataSource = fp.Mostrar()
    End Sub


    Private Sub Alta(nombre As String, precio As Double, categoria As String)

        p = New Producto(nombre, precio, categoria)
        res = fp.Alta(p)

        If res Then

            MsgBox("El registro fue añadido")

        Else

            MsgBox("No se añadió el registro")

        End If

    End Sub

    Private Sub Modificacion(id As Integer, nombre As String, precio As Double, categoria As String)

        p = New Producto(id, nombre, precio, categoria)
        res = fp.Modificacion(p)

        If res = True Then

            MsgBox("El registro fue modificado")

        Else

            MsgBox("No se modificó el registro")

        End If

    End Sub

    Private Sub Eliminar(id As Integer)

        p = New Producto(id)
        res = fp.Baja(p)

        If res = True Then

            MsgBox("El registro fue ELIMINADO")

        Else

            MsgBox("No se eliminó el registro")

        End If

        Mostrar()

    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click

        EsNuevo = True
        Habilitar(True)
        Limpiar()

    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Habilitar(True)
        EsNuevo = False
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim conf As String = MsgBox("¿ESTÁ SEGURO QUE DESE ELEMINAR DEFINITIVAMENTE EL PRODUCTO?", vbYesNo + vbCritical)
        If conf = vbYes Then

            Eliminar(dgvProductos.SelectedCells(0).Value)

        Else

            Exit Sub

        End If
    End Sub

    Private Sub BtnCanelar_Click(sender As Object, e As EventArgs) Handles BtnCanelar.Click
        Habilitar(False)
        Limpiar()

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click


        Dim valida As Boolean = Validar()

        If valida Then

            If EsNuevo Then

                Alta(Me.TxtNombre.Text.ToUpper(), CDbl(Me.TxtPrecio.Text), Me.TxtCategoria.Text.ToUpper())


            Else

                Modificacion(dgvProductos.SelectedCells(0).Value, Me.TxtNombre.Text.ToUpper(), CDbl(Me.TxtPrecio.Text), Me.TxtCategoria.Text.ToUpper())

            End If


            Mostrar()
            Habilitar(False)
            Limpiar()

        Else

            Exit Sub

        End If

    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged
        If Me.TxtBuscar.TextLength > 3 Then

            Me.dgvProductos.DataSource = fp.Buscar(Me.TxtBuscar.Text, Me.ComboBox1.Text)

        ElseIf TxtBuscar.Text = String.Empty Then

            Mostrar()
            Exit Sub

        End If
    End Sub

    Private Sub DgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        Me.TxtNombre.Text = dgvProductos.SelectedCells(1).Value
        Me.TxtPrecio.Text = dgvProductos.SelectedCells(2).Value
        Me.TxtCategoria.Text = dgvProductos.SelectedCells(3).Value
        Me.BtnEditar.Enabled = True
        Me.BtnEditar.Visible = True
        Me.BtnEliminar.Enabled = True

    End Sub

    Private Sub DgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick

        Me.TxtNombre.Text = dgvProductos.SelectedCells(1).Value
        Me.TxtPrecio.Text = dgvProductos.SelectedCells(2).Value
        Me.TxtCategoria.Text = dgvProductos.SelectedCells(3).Value
        EsNuevo = False
        Habilitar(True)

    End Sub

    Private Sub TxtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPrecio.KeyPress



    End Sub

    Private Sub TxtPrecio_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecio.TextChanged

    End Sub

    Private Sub TxtPrecio_LostFocus(sender As Object, e As EventArgs) Handles TxtPrecio.LostFocus
        If Me.TxtPrecio.Text = String.Empty Then Exit Sub
        Me.TxtPrecio.Text = Replace(Me.TxtPrecio.Text, ".", ",")
    End Sub
End Class