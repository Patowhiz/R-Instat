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
        Me.lblObjectType = New System.Windows.Forms.Label()
        Me.cboObjectType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblObjectType
        '
        Me.lblObjectType.AutoSize = True
        Me.lblObjectType.Location = New System.Drawing.Point(2, 2)
        Me.lblObjectType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblObjectType.Name = "lblObjectType"
        Me.lblObjectType.Size = New System.Drawing.Size(97, 20)
        Me.lblObjectType.TabIndex = 12
        Me.lblObjectType.Text = "Object Type:"
        '
        'cboObjectType
        '
        Me.cboObjectType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectType.FormattingEnabled = True
        Me.cboObjectType.Location = New System.Drawing.Point(2, 25)
        Me.cboObjectType.Name = "cboObjectType"
        Me.cboObjectType.Size = New System.Drawing.Size(220, 28)
        Me.cboObjectType.TabIndex = 13
        '
        'ucrObjectTypeSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboObjectType)
        Me.Controls.Add(Me.lblObjectType)
        Me.Name = "ucrObjectTypeSelector"
        Me.Size = New System.Drawing.Size(225, 56)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblObjectType As Label
    Friend WithEvents cboObjectType As ComboBox
End Class
