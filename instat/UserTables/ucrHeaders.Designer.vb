Partial Class ucrHeaders
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnHeaderTitleNSubtitleFooterFormat = New System.Windows.Forms.Button()
        Me.ucrInputHeaderTitleNSubtitleFooter = New instat.ucrInputTextBox()
        Me.lblHeaderTitleNSubtitleFooter = New System.Windows.Forms.Label()
        Me.btnHeaderSubtitleFooterFormat = New System.Windows.Forms.Button()
        Me.ucrInputHeaderSubtitleFooter = New instat.ucrInputTextBox()
        Me.lblHeaderTitleFooter = New System.Windows.Forms.Label()
        Me.btnHeaderTitleFooterFormat = New System.Windows.Forms.Button()
        Me.ucrInputHeaderTitleFooter = New instat.ucrInputTextBox()
        Me.ucrChkIncludeHeader = New instat.ucrCheck()
        Me.lblHeaderSubtitleFooter = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnHeaderTitleNSubtitleFooterFormat
        '
        Me.btnHeaderTitleNSubtitleFooterFormat.Location = New System.Drawing.Point(239, 157)
        Me.btnHeaderTitleNSubtitleFooterFormat.Name = "btnHeaderTitleNSubtitleFooterFormat"
        Me.btnHeaderTitleNSubtitleFooterFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderTitleNSubtitleFooterFormat.TabIndex = 38
        Me.btnHeaderTitleNSubtitleFooterFormat.Text = "Format"
        Me.btnHeaderTitleNSubtitleFooterFormat.UseVisualStyleBackColor = True
        '
        'ucrInputHeaderTitleNSubtitleFooter
        '
        Me.ucrInputHeaderTitleNSubtitleFooter.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderTitleNSubtitleFooter.AutoSize = True
        Me.ucrInputHeaderTitleNSubtitleFooter.IsMultiline = False
        Me.ucrInputHeaderTitleNSubtitleFooter.IsReadOnly = False
        Me.ucrInputHeaderTitleNSubtitleFooter.Location = New System.Drawing.Point(11, 159)
        Me.ucrInputHeaderTitleNSubtitleFooter.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderTitleNSubtitleFooter.Name = "ucrInputHeaderTitleNSubtitleFooter"
        Me.ucrInputHeaderTitleNSubtitleFooter.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderTitleNSubtitleFooter.TabIndex = 37
        '
        'lblHeaderTitleNSubtitleFooter
        '
        Me.lblHeaderTitleNSubtitleFooter.AutoSize = True
        Me.lblHeaderTitleNSubtitleFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderTitleNSubtitleFooter.Location = New System.Drawing.Point(9, 143)
        Me.lblHeaderTitleNSubtitleFooter.Name = "lblHeaderTitleNSubtitleFooter"
        Me.lblHeaderTitleNSubtitleFooter.Size = New System.Drawing.Size(122, 13)
        Me.lblHeaderTitleNSubtitleFooter.TabIndex = 36
        Me.lblHeaderTitleNSubtitleFooter.Text = "Title and Subtitle Footer:"
        '
        'btnHeaderSubtitleFooterFormat
        '
        Me.btnHeaderSubtitleFooterFormat.Location = New System.Drawing.Point(239, 105)
        Me.btnHeaderSubtitleFooterFormat.Name = "btnHeaderSubtitleFooterFormat"
        Me.btnHeaderSubtitleFooterFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderSubtitleFooterFormat.TabIndex = 35
        Me.btnHeaderSubtitleFooterFormat.Text = "Format"
        Me.btnHeaderSubtitleFooterFormat.UseVisualStyleBackColor = True
        '
        'ucrInputHeaderSubtitleFooter
        '
        Me.ucrInputHeaderSubtitleFooter.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderSubtitleFooter.AutoSize = True
        Me.ucrInputHeaderSubtitleFooter.IsMultiline = False
        Me.ucrInputHeaderSubtitleFooter.IsReadOnly = False
        Me.ucrInputHeaderSubtitleFooter.Location = New System.Drawing.Point(11, 107)
        Me.ucrInputHeaderSubtitleFooter.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderSubtitleFooter.Name = "ucrInputHeaderSubtitleFooter"
        Me.ucrInputHeaderSubtitleFooter.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderSubtitleFooter.TabIndex = 34
        '
        'lblHeaderTitleFooter
        '
        Me.lblHeaderTitleFooter.AutoSize = True
        Me.lblHeaderTitleFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderTitleFooter.Location = New System.Drawing.Point(9, 40)
        Me.lblHeaderTitleFooter.Name = "lblHeaderTitleFooter"
        Me.lblHeaderTitleFooter.Size = New System.Drawing.Size(63, 13)
        Me.lblHeaderTitleFooter.TabIndex = 33
        Me.lblHeaderTitleFooter.Text = "Title Footer:"
        '
        'btnHeaderTitleFooterFormat
        '
        Me.btnHeaderTitleFooterFormat.Location = New System.Drawing.Point(239, 54)
        Me.btnHeaderTitleFooterFormat.Name = "btnHeaderTitleFooterFormat"
        Me.btnHeaderTitleFooterFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderTitleFooterFormat.TabIndex = 32
        Me.btnHeaderTitleFooterFormat.Text = "Format"
        Me.btnHeaderTitleFooterFormat.UseVisualStyleBackColor = True
        '
        'ucrInputHeaderTitleFooter
        '
        Me.ucrInputHeaderTitleFooter.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderTitleFooter.AutoSize = True
        Me.ucrInputHeaderTitleFooter.IsMultiline = False
        Me.ucrInputHeaderTitleFooter.IsReadOnly = False
        Me.ucrInputHeaderTitleFooter.Location = New System.Drawing.Point(11, 56)
        Me.ucrInputHeaderTitleFooter.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderTitleFooter.Name = "ucrInputHeaderTitleFooter"
        Me.ucrInputHeaderTitleFooter.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderTitleFooter.TabIndex = 31
        '
        'ucrChkIncludeHeader
        '
        Me.ucrChkIncludeHeader.AutoSize = True
        Me.ucrChkIncludeHeader.Checked = False
        Me.ucrChkIncludeHeader.Location = New System.Drawing.Point(9, 8)
        Me.ucrChkIncludeHeader.Name = "ucrChkIncludeHeader"
        Me.ucrChkIncludeHeader.Size = New System.Drawing.Size(248, 23)
        Me.ucrChkIncludeHeader.TabIndex = 30
        '
        'lblHeaderSubtitleFooter
        '
        Me.lblHeaderSubtitleFooter.AutoSize = True
        Me.lblHeaderSubtitleFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderSubtitleFooter.Location = New System.Drawing.Point(9, 90)
        Me.lblHeaderSubtitleFooter.Name = "lblHeaderSubtitleFooter"
        Me.lblHeaderSubtitleFooter.Size = New System.Drawing.Size(78, 13)
        Me.lblHeaderSubtitleFooter.TabIndex = 39
        Me.lblHeaderSubtitleFooter.Text = "Subtitle Footer:"
        '
        'ucrHeaders
        '
        Me.Controls.Add(Me.lblHeaderSubtitleFooter)
        Me.Controls.Add(Me.btnHeaderTitleNSubtitleFooterFormat)
        Me.Controls.Add(Me.ucrInputHeaderTitleNSubtitleFooter)
        Me.Controls.Add(Me.lblHeaderTitleNSubtitleFooter)
        Me.Controls.Add(Me.btnHeaderSubtitleFooterFormat)
        Me.Controls.Add(Me.ucrInputHeaderSubtitleFooter)
        Me.Controls.Add(Me.lblHeaderTitleFooter)
        Me.Controls.Add(Me.btnHeaderTitleFooterFormat)
        Me.Controls.Add(Me.ucrInputHeaderTitleFooter)
        Me.Controls.Add(Me.ucrChkIncludeHeader)
        Me.Name = "ucrHeaders"
        Me.Size = New System.Drawing.Size(326, 196)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnHeaderTitleNSubtitleFooterFormat As Button
    Friend WithEvents ucrInputHeaderTitleNSubtitleFooter As ucrInputTextBox
    Friend WithEvents lblHeaderTitleNSubtitleFooter As Label
    Friend WithEvents btnHeaderSubtitleFooterFormat As Button
    Friend WithEvents ucrInputHeaderSubtitleFooter As ucrInputTextBox
    Friend WithEvents lblHeaderTitleFooter As Label
    Friend WithEvents btnHeaderTitleFooterFormat As Button
    Friend WithEvents ucrInputHeaderTitleFooter As ucrInputTextBox
    Friend WithEvents ucrChkIncludeHeader As ucrCheck
    Friend WithEvents lblHeaderSubtitleFooter As Label
End Class
