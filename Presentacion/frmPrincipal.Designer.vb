<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.UNAEMPRESAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MANTENIMIENTOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLIENTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODCUTOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTASToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NUEVAVENTAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPORTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODUCTOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTASToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UNAEMPRESAToolStripMenuItem, Me.MANTENIMIENTOToolStripMenuItem, Me.VENTASToolStripMenuItem, Me.REPORTESToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(843, 28)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'UNAEMPRESAToolStripMenuItem
        '
        Me.UNAEMPRESAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SALIRToolStripMenuItem})
        Me.UNAEMPRESAToolStripMenuItem.Name = "UNAEMPRESAToolStripMenuItem"
        Me.UNAEMPRESAToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.UNAEMPRESAToolStripMenuItem.Text = "UNA EMPRESA"
        '
        'SALIRToolStripMenuItem
        '
        Me.SALIRToolStripMenuItem.Name = "SALIRToolStripMenuItem"
        Me.SALIRToolStripMenuItem.Size = New System.Drawing.Size(130, 26)
        Me.SALIRToolStripMenuItem.Text = "SALIR"
        '
        'MANTENIMIENTOToolStripMenuItem
        '
        Me.MANTENIMIENTOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLIENTESToolStripMenuItem, Me.PRODCUTOSToolStripMenuItem})
        Me.MANTENIMIENTOToolStripMenuItem.Name = "MANTENIMIENTOToolStripMenuItem"
        Me.MANTENIMIENTOToolStripMenuItem.Size = New System.Drawing.Size(142, 24)
        Me.MANTENIMIENTOToolStripMenuItem.Text = "MANTENIMIENTO"
        '
        'CLIENTESToolStripMenuItem
        '
        Me.CLIENTESToolStripMenuItem.Image = CType(resources.GetObject("CLIENTESToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CLIENTESToolStripMenuItem.Name = "CLIENTESToolStripMenuItem"
        Me.CLIENTESToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.CLIENTESToolStripMenuItem.Text = "CLIENTES"
        '
        'PRODCUTOSToolStripMenuItem
        '
        Me.PRODCUTOSToolStripMenuItem.Image = CType(resources.GetObject("PRODCUTOSToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PRODCUTOSToolStripMenuItem.Name = "PRODCUTOSToolStripMenuItem"
        Me.PRODCUTOSToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.PRODCUTOSToolStripMenuItem.Text = "PRODCUTOS"
        '
        'VENTASToolStripMenuItem
        '
        Me.VENTASToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VENTASToolStripMenuItem1, Me.NUEVAVENTAToolStripMenuItem})
        Me.VENTASToolStripMenuItem.Name = "VENTASToolStripMenuItem"
        Me.VENTASToolStripMenuItem.Size = New System.Drawing.Size(76, 24)
        Me.VENTASToolStripMenuItem.Text = "VENTAS"
        '
        'VENTASToolStripMenuItem1
        '
        Me.VENTASToolStripMenuItem1.Image = CType(resources.GetObject("VENTASToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.VENTASToolStripMenuItem1.Name = "VENTASToolStripMenuItem1"
        Me.VENTASToolStripMenuItem1.Size = New System.Drawing.Size(188, 26)
        Me.VENTASToolStripMenuItem1.Text = "VENTAS"
        '
        'NUEVAVENTAToolStripMenuItem
        '
        Me.NUEVAVENTAToolStripMenuItem.Image = CType(resources.GetObject("NUEVAVENTAToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NUEVAVENTAToolStripMenuItem.Name = "NUEVAVENTAToolStripMenuItem"
        Me.NUEVAVENTAToolStripMenuItem.Size = New System.Drawing.Size(188, 26)
        Me.NUEVAVENTAToolStripMenuItem.Text = "NUEVA VENTA"
        '
        'REPORTESToolStripMenuItem
        '
        Me.REPORTESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PRODUCTOSToolStripMenuItem, Me.VENTASToolStripMenuItem2})
        Me.REPORTESToolStripMenuItem.Name = "REPORTESToolStripMenuItem"
        Me.REPORTESToolStripMenuItem.Size = New System.Drawing.Size(91, 24)
        Me.REPORTESToolStripMenuItem.Text = "REPORTES"
        '
        'PRODUCTOSToolStripMenuItem
        '
        Me.PRODUCTOSToolStripMenuItem.Image = CType(resources.GetObject("PRODUCTOSToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PRODUCTOSToolStripMenuItem.Name = "PRODUCTOSToolStripMenuItem"
        Me.PRODUCTOSToolStripMenuItem.Size = New System.Drawing.Size(176, 26)
        Me.PRODUCTOSToolStripMenuItem.Text = "PRODUCTOS"
        '
        'VENTASToolStripMenuItem2
        '
        Me.VENTASToolStripMenuItem2.Image = CType(resources.GetObject("VENTASToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.VENTASToolStripMenuItem2.Name = "VENTASToolStripMenuItem2"
        Me.VENTASToolStripMenuItem2.Size = New System.Drawing.Size(176, 26)
        Me.VENTASToolStripMenuItem2.Text = "VENTAS"
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 532)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(843, 26)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(54, 20)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 558)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmPrincipal"
        Me.Text = "MDIParent1"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents UNAEMPRESAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MANTENIMIENTOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CLIENTESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PRODCUTOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VENTASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VENTASToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SALIRToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NUEVAVENTAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REPORTESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PRODUCTOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VENTASToolStripMenuItem2 As ToolStripMenuItem
End Class
