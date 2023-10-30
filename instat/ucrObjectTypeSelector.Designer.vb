<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrObjectTypeSelector
    Inherits instat.ucrCore

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboObjectType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cboObjectType
        '
        Me.cboObjectType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectType.FormattingEnabled = True
        Me.cboObjectType.Location = New System.Drawing.Point(0, 0)
        Me.cboObjectType.Name = "cboObjectType"
        Me.cboObjectType.Size = New System.Drawing.Size(181, 28)
        Me.cboObjectType.TabIndex = 13
        '
        'ucrObjectTypeSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = False
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.cboObjectType)
        Me.Name = "ucrObjectTypeSelector"
        Me.Size = New System.Drawing.Size(181, 30)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboObjectType As ComboBox
End Class
