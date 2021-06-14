Imports Logica
Imports Entidades
Imports Interfaces

Public Class FrmCliente

    Implements IFormulario

    ReadOnly fc As New FCliente
    Dim res As Boolean
    Dim EsNuevo As Boolean
    Dim c As Cliente


    Private Sub FrmCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Mostrar()
        Me.dgvClientes.Columns(0).Visible = False
        Habilitar(False)
        Me.dgvClientes.ClearSelection()
        Me.ComboBox1.SelectedIndex = 0
        Btn_Nuevo.Select()

    End Sub

    Public Sub Habilitar(valor As Boolean) Implements IFormulario.Habilitar


        Me.GroupBox1.Enabled = valor
        Me.GroupBox2.Enabled = Not valor
        Me.BtnCanelar.Enabled = valor
        Me.BtnEliminar.Enabled = valor
        Me.BtnGuardar.Enabled = valor
        Me.BtnGuardar.Visible = valor
        Me.BtnEditar.Enabled = valor
        Me.BtnEditar.Visible = Not valor
        Me.Btn_Nuevo.Enabled = Not valor


    End Sub

    Public Sub Limpiar() Implements IFormulario.Limpiar

        For Each txbox As TextBox In GroupBox1.Controls.OfType(Of TextBox)
            txbox.Text = String.Empty
        Next

    End Sub


    Public Function Validar() As Boolean Implements IFormulario.Validar

        Dim Valida As Boolean = True

        For Each txtbox As TextBox In Me.GroupBox1.Controls.OfType(Of TextBox)

            If txtbox.TextLength = 0 Then

                ErrorProvider1.SetError(txtbox, "Dato Obligatorio")
                ErrorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink
                txtbox.Select()
                Valida = False

            End If

        Next

        Return Valida

    End Function


    Public Sub Mostrar()

        Me.dgvClientes.DataSource = fc.Mostrar()

    End Sub

    Public Sub Buscar(BuscaTexto As String, Critero As String)

        Me.dgvClientes.DataSource = fc.Buscar(BuscaTexto, Critero)

    End Sub


    Private Sub DgvClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick

        Me.TxtCliente.Text = dgvClientes.SelectedCells(1).Value
        Me.TxtTelefono.Text = dgvClientes.SelectedCells(2).Value
        Me.TxtCorreo.Text = dgvClientes.SelectedCells(3).Value
        Me.BtnEditar.Enabled = True
        Me.BtnEditar.Visible = True
        Me.BtnEliminar.Enabled = True



    End Sub


    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged

        If Me.TxtBuscar.TextLength > 3 Then

            Buscar(Me.TxtBuscar.Text, Me.ComboBox1.Text)

        ElseIf TxtBuscar.Text = String.Empty Then

            Mostrar()

            Exit Sub

        End If

    End Sub


    Private Sub BtnEliminar_Click_1(sender As Object, e As EventArgs) Handles BtnEliminar.Click

        Dim conf As String = MsgBox("¿ESTÁ SEGURO QUE DESE ELEMINAR DEFINITIVAMENTE EL CLIENTE?", vbYesNo + vbCritical)
        If conf = vbYes Then

            c = New Cliente(dgvClientes.SelectedCells(0).Value)
            res = fc.Baja(c)

            If res Then

                MsgBox("El Cliente fue eliminado")
                Mostrar()

            Else

                MsgBox("EL cliente no fue eliminado")

            End If

        Else

            Exit Sub

        End If


    End Sub


    Private Sub TxtCorreo_Leave(sender As Object, e As EventArgs)

        Dim CorreoOk As Boolean = ValidaCorreo(Me.TxtCorreo.Text)
        If Not CorreoOk Then
            ErrorProvider1.SetError(TxtCorreo, "Formato No Valido")
        Else
            Exit Sub
        End If


    End Sub

    Private Function ValidaCorreo(correo As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(correo, "^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" &
             "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")
    End Function

    Private Sub TxtCorreo_TextChanged(sender As Object, e As EventArgs)

        Me.ErrorProvider1.Clear()

    End Sub

    Private Sub Btn_Nuevo_Click(sender As Object, e As EventArgs) Handles Btn_Nuevo.Click

        Habilitar(True)
        Limpiar()
        EsNuevo = True

    End Sub

    Private Sub BtnCanelar_Click(sender As Object, e As EventArgs) Handles BtnCanelar.Click

        Habilitar(False)
        Limpiar()
        Btn_Nuevo.Select()

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Dim valida As Boolean = Validar()
        If Not valida Then Exit Sub
        valida = ValidaCorreo(Me.TxtCorreo.Text)
        If Not valida Then
            ErrorProvider1.SetError(TxtCorreo, "Formato No Valido")
            Exit Sub
        End If



        If EsNuevo Then

            c = New Cliente(Me.TxtCliente.Text.ToUpper(), Me.TxtTelefono.Text, Me.TxtCorreo.Text.ToLower())
            res = fc.Alta(c)

            If res Then

                MsgBox("El Cliente fue añadido")

            Else

                MsgBox("El cliente no fue registrado")


            End If

        Else

            c = New Cliente(Me.dgvClientes.SelectedCells(0).Value, Me.TxtCliente.Text.ToUpper(), Me.TxtTelefono.Text, Me.TxtCorreo.Text.ToLower())
            res = fc.Modificacion(c)

            If res Then

                MsgBox("El Cliente fue Modificado")

            Else

                MsgBox("El cliente no fue Modificado")


            End If

        End If

        Limpiar()
        Habilitar(False)
        Mostrar()

    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Habilitar(True)

    End Sub

    Private Sub TxtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtTelefono.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub



    Private Sub TxtCorreo_LostFocus(sender As Object, e As EventArgs) Handles TxtCorreo.LostFocus
        Dim CorreoOk As Boolean = ValidaCorreo(Me.TxtCorreo.Text)
        If Not CorreoOk Then
            ErrorProvider1.SetError(TxtCorreo, "Formato No Valido")
        Else
            Exit Sub
        End If
    End Sub

    Private Sub TxtCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtCliente.TextChanged
        Me.ErrorProvider1.Clear()
    End Sub

    Private Sub TxtTelefono_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefono.TextChanged
        Me.ErrorProvider1.Clear()
    End Sub

    Private Sub TxtCorreo_TextChanged_1(sender As Object, e As EventArgs) Handles TxtCorreo.TextChanged
        Me.ErrorProvider1.Clear()
    End Sub
End Class