<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgGeneralTable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbpFormatOptions = New System.Windows.Forms.TabControl()
        Me.tbpHeader = New System.Windows.Forms.TabPage()
        Me.btnHeaderTitleNSubtitleFooterFormat = New System.Windows.Forms.Button()
        Me.ucrInputHeaderTitleNSubtitleFooter = New instat.ucrInputTextBox()
        Me.lblHeaderTitleNSubtitleFooter = New System.Windows.Forms.Label()
        Me.btnHeaderSubtitleFooterFormat = New System.Windows.Forms.Button()
        Me.ucrInputHeaderSubtitleFooter = New instat.ucrInputTextBox()
        Me.lblHeaderSubtitleFooter = New System.Windows.Forms.Label()
        Me.lblHeaderTitleFooter = New System.Windows.Forms.Label()
        Me.btnHeaderTitleFooterFormat = New System.Windows.Forms.Button()
        Me.ucrInputHeaderTitleFooter = New instat.ucrInputTextBox()
        Me.ucrChkIncludeHeader = New instat.ucrCheck()
        Me.btnHeaderSubtitleFormat = New System.Windows.Forms.Button()
        Me.btnHeaderTitleFormat = New System.Windows.Forms.Button()
        Me.ucrInputHeaderSubtitle = New instat.ucrInputTextBox()
        Me.ucrInputHeaderTitle = New instat.ucrInputTextBox()
        Me.lblHeaderSubtitle = New System.Windows.Forms.Label()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.tbpCells = New System.Windows.Forms.TabPage()
        Me.dataGridCellFooterNotes = New System.Windows.Forms.DataGridView()
        Me.colFooterNoteText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFooterColExpression = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFooterRowExpression = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFooterFormat = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblFooterCellNotes = New System.Windows.Forms.Label()
        Me.tbpSourceNotes = New System.Windows.Forms.TabPage()
        Me.dataGridSourceNotes = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSourceNoteFormat = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblSourceNotes = New System.Windows.Forms.Label()
        Me.tbpThemes = New System.Windows.Forms.TabPage()
        Me.ucrCboSelectThemes = New instat.ucrInputComboBox()
        Me.btnManualTheme = New System.Windows.Forms.Button()
        Me.rdoSelectTheme = New System.Windows.Forms.RadioButton()
        Me.rdoManualTheme = New System.Windows.Forms.RadioButton()
        Me.ucrPnlThemesPanel = New instat.UcrPanel()
        Me.ucrSaveTable = New instat.ucrSave()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrDataFrameTable = New instat.ucrDataFrame()
        Me.ucrChkIncludeCellFootNotes = New instat.ucrCheck()
        Me.ucrChkIncludeSourceNotes = New instat.ucrCheck()
        Me.tbpFormatOptions.SuspendLayout()
        Me.tbpHeader.SuspendLayout()
        Me.tbpCells.SuspendLayout()
        CType(Me.dataGridCellFooterNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpSourceNotes.SuspendLayout()
        CType(Me.dataGridSourceNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpThemes.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbpFormatOptions
        '
        Me.tbpFormatOptions.Controls.Add(Me.tbpHeader)
        Me.tbpFormatOptions.Controls.Add(Me.tbpCells)
        Me.tbpFormatOptions.Controls.Add(Me.tbpSourceNotes)
        Me.tbpFormatOptions.Controls.Add(Me.tbpThemes)
        Me.tbpFormatOptions.Location = New System.Drawing.Point(10, 56)
        Me.tbpFormatOptions.Name = "tbpFormatOptions"
        Me.tbpFormatOptions.SelectedIndex = 0
        Me.tbpFormatOptions.Size = New System.Drawing.Size(650, 333)
        Me.tbpFormatOptions.TabIndex = 5
        '
        'tbpHeader
        '
        Me.tbpHeader.Controls.Add(Me.btnHeaderTitleNSubtitleFooterFormat)
        Me.tbpHeader.Controls.Add(Me.ucrInputHeaderTitleNSubtitleFooter)
        Me.tbpHeader.Controls.Add(Me.lblHeaderTitleNSubtitleFooter)
        Me.tbpHeader.Controls.Add(Me.btnHeaderSubtitleFooterFormat)
        Me.tbpHeader.Controls.Add(Me.ucrInputHeaderSubtitleFooter)
        Me.tbpHeader.Controls.Add(Me.lblHeaderSubtitleFooter)
        Me.tbpHeader.Controls.Add(Me.lblHeaderTitleFooter)
        Me.tbpHeader.Controls.Add(Me.btnHeaderTitleFooterFormat)
        Me.tbpHeader.Controls.Add(Me.ucrInputHeaderTitleFooter)
        Me.tbpHeader.Controls.Add(Me.ucrChkIncludeHeader)
        Me.tbpHeader.Controls.Add(Me.btnHeaderSubtitleFormat)
        Me.tbpHeader.Controls.Add(Me.btnHeaderTitleFormat)
        Me.tbpHeader.Controls.Add(Me.ucrInputHeaderSubtitle)
        Me.tbpHeader.Controls.Add(Me.ucrInputHeaderTitle)
        Me.tbpHeader.Controls.Add(Me.lblHeaderSubtitle)
        Me.tbpHeader.Controls.Add(Me.lblHeaderTitle)
        Me.tbpHeader.Location = New System.Drawing.Point(4, 22)
        Me.tbpHeader.Name = "tbpHeader"
        Me.tbpHeader.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpHeader.Size = New System.Drawing.Size(642, 307)
        Me.tbpHeader.TabIndex = 0
        Me.tbpHeader.Text = "Headers"
        Me.tbpHeader.UseVisualStyleBackColor = True
        '
        'btnHeaderTitleNSubtitleFooterFormat
        '
        Me.btnHeaderTitleNSubtitleFooterFormat.Location = New System.Drawing.Point(240, 166)
        Me.btnHeaderTitleNSubtitleFooterFormat.Name = "btnHeaderTitleNSubtitleFooterFormat"
        Me.btnHeaderTitleNSubtitleFooterFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderTitleNSubtitleFooterFormat.TabIndex = 23
        Me.btnHeaderTitleNSubtitleFooterFormat.Text = "Format"
        Me.btnHeaderTitleNSubtitleFooterFormat.UseVisualStyleBackColor = True
        '
        'ucrInputHeaderTitleNSubtitleFooter
        '
        Me.ucrInputHeaderTitleNSubtitleFooter.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderTitleNSubtitleFooter.AutoSize = True
        Me.ucrInputHeaderTitleNSubtitleFooter.IsMultiline = False
        Me.ucrInputHeaderTitleNSubtitleFooter.IsReadOnly = False
        Me.ucrInputHeaderTitleNSubtitleFooter.Location = New System.Drawing.Point(12, 168)
        Me.ucrInputHeaderTitleNSubtitleFooter.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderTitleNSubtitleFooter.Name = "ucrInputHeaderTitleNSubtitleFooter"
        Me.ucrInputHeaderTitleNSubtitleFooter.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderTitleNSubtitleFooter.TabIndex = 22
        '
        'lblHeaderTitleNSubtitleFooter
        '
        Me.lblHeaderTitleNSubtitleFooter.AutoSize = True
        Me.lblHeaderTitleNSubtitleFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderTitleNSubtitleFooter.Location = New System.Drawing.Point(10, 152)
        Me.lblHeaderTitleNSubtitleFooter.Name = "lblHeaderTitleNSubtitleFooter"
        Me.lblHeaderTitleNSubtitleFooter.Size = New System.Drawing.Size(122, 13)
        Me.lblHeaderTitleNSubtitleFooter.TabIndex = 21
        Me.lblHeaderTitleNSubtitleFooter.Text = "Title and Subtitle Footer:"
        '
        'btnHeaderSubtitleFooterFormat
        '
        Me.btnHeaderSubtitleFooterFormat.Location = New System.Drawing.Point(558, 108)
        Me.btnHeaderSubtitleFooterFormat.Name = "btnHeaderSubtitleFooterFormat"
        Me.btnHeaderSubtitleFooterFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderSubtitleFooterFormat.TabIndex = 20
        Me.btnHeaderSubtitleFooterFormat.Text = "Format"
        Me.btnHeaderSubtitleFooterFormat.UseVisualStyleBackColor = True
        '
        'ucrInputHeaderSubtitleFooter
        '
        Me.ucrInputHeaderSubtitleFooter.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderSubtitleFooter.AutoSize = True
        Me.ucrInputHeaderSubtitleFooter.IsMultiline = False
        Me.ucrInputHeaderSubtitleFooter.IsReadOnly = False
        Me.ucrInputHeaderSubtitleFooter.Location = New System.Drawing.Point(330, 110)
        Me.ucrInputHeaderSubtitleFooter.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderSubtitleFooter.Name = "ucrInputHeaderSubtitleFooter"
        Me.ucrInputHeaderSubtitleFooter.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderSubtitleFooter.TabIndex = 19
        '
        'lblHeaderSubtitleFooter
        '
        Me.lblHeaderSubtitleFooter.AutoSize = True
        Me.lblHeaderSubtitleFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderSubtitleFooter.Location = New System.Drawing.Point(328, 92)
        Me.lblHeaderSubtitleFooter.Name = "lblHeaderSubtitleFooter"
        Me.lblHeaderSubtitleFooter.Size = New System.Drawing.Size(78, 13)
        Me.lblHeaderSubtitleFooter.TabIndex = 18
        Me.lblHeaderSubtitleFooter.Text = "Subtitle Footer:"
        '
        'lblHeaderTitleFooter
        '
        Me.lblHeaderTitleFooter.AutoSize = True
        Me.lblHeaderTitleFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderTitleFooter.Location = New System.Drawing.Point(328, 43)
        Me.lblHeaderTitleFooter.Name = "lblHeaderTitleFooter"
        Me.lblHeaderTitleFooter.Size = New System.Drawing.Size(63, 13)
        Me.lblHeaderTitleFooter.TabIndex = 17
        Me.lblHeaderTitleFooter.Text = "Title Footer:"
        '
        'btnHeaderTitleFooterFormat
        '
        Me.btnHeaderTitleFooterFormat.Location = New System.Drawing.Point(558, 57)
        Me.btnHeaderTitleFooterFormat.Name = "btnHeaderTitleFooterFormat"
        Me.btnHeaderTitleFooterFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderTitleFooterFormat.TabIndex = 16
        Me.btnHeaderTitleFooterFormat.Text = "Format"
        Me.btnHeaderTitleFooterFormat.UseVisualStyleBackColor = True
        '
        'ucrInputHeaderTitleFooter
        '
        Me.ucrInputHeaderTitleFooter.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderTitleFooter.AutoSize = True
        Me.ucrInputHeaderTitleFooter.IsMultiline = False
        Me.ucrInputHeaderTitleFooter.IsReadOnly = False
        Me.ucrInputHeaderTitleFooter.Location = New System.Drawing.Point(330, 59)
        Me.ucrInputHeaderTitleFooter.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderTitleFooter.Name = "ucrInputHeaderTitleFooter"
        Me.ucrInputHeaderTitleFooter.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderTitleFooter.TabIndex = 15
        '
        'ucrChkIncludeHeader
        '
        Me.ucrChkIncludeHeader.AutoSize = True
        Me.ucrChkIncludeHeader.Checked = False
        Me.ucrChkIncludeHeader.Location = New System.Drawing.Point(10, 9)
        Me.ucrChkIncludeHeader.Name = "ucrChkIncludeHeader"
        Me.ucrChkIncludeHeader.Size = New System.Drawing.Size(248, 23)
        Me.ucrChkIncludeHeader.TabIndex = 14
        '
        'btnHeaderSubtitleFormat
        '
        Me.btnHeaderSubtitleFormat.Location = New System.Drawing.Point(240, 109)
        Me.btnHeaderSubtitleFormat.Name = "btnHeaderSubtitleFormat"
        Me.btnHeaderSubtitleFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderSubtitleFormat.TabIndex = 13
        Me.btnHeaderSubtitleFormat.Text = "Format"
        Me.btnHeaderSubtitleFormat.UseVisualStyleBackColor = True
        '
        'btnHeaderTitleFormat
        '
        Me.btnHeaderTitleFormat.Location = New System.Drawing.Point(240, 57)
        Me.btnHeaderTitleFormat.Name = "btnHeaderTitleFormat"
        Me.btnHeaderTitleFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnHeaderTitleFormat.TabIndex = 12
        Me.btnHeaderTitleFormat.Text = "Format"
        Me.btnHeaderTitleFormat.UseVisualStyleBackColor = True
        '
        'ucrInputHeaderSubtitle
        '
        Me.ucrInputHeaderSubtitle.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderSubtitle.AutoSize = True
        Me.ucrInputHeaderSubtitle.IsMultiline = False
        Me.ucrInputHeaderSubtitle.IsReadOnly = False
        Me.ucrInputHeaderSubtitle.Location = New System.Drawing.Point(12, 111)
        Me.ucrInputHeaderSubtitle.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderSubtitle.Name = "ucrInputHeaderSubtitle"
        Me.ucrInputHeaderSubtitle.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderSubtitle.TabIndex = 11
        '
        'ucrInputHeaderTitle
        '
        Me.ucrInputHeaderTitle.AddQuotesIfUnrecognised = True
        Me.ucrInputHeaderTitle.AutoSize = True
        Me.ucrInputHeaderTitle.IsMultiline = False
        Me.ucrInputHeaderTitle.IsReadOnly = False
        Me.ucrInputHeaderTitle.Location = New System.Drawing.Point(12, 59)
        Me.ucrInputHeaderTitle.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrInputHeaderTitle.Name = "ucrInputHeaderTitle"
        Me.ucrInputHeaderTitle.Size = New System.Drawing.Size(224, 21)
        Me.ucrInputHeaderTitle.TabIndex = 10
        '
        'lblHeaderSubtitle
        '
        Me.lblHeaderSubtitle.AutoSize = True
        Me.lblHeaderSubtitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderSubtitle.Location = New System.Drawing.Point(10, 93)
        Me.lblHeaderSubtitle.Name = "lblHeaderSubtitle"
        Me.lblHeaderSubtitle.Size = New System.Drawing.Size(45, 13)
        Me.lblHeaderSubtitle.TabIndex = 9
        Me.lblHeaderSubtitle.Text = "Subtitle:"
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeaderTitle.Location = New System.Drawing.Point(10, 43)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(30, 13)
        Me.lblHeaderTitle.TabIndex = 8
        Me.lblHeaderTitle.Text = "Title:"
        '
        'tbpCells
        '
        Me.tbpCells.Controls.Add(Me.ucrChkIncludeCellFootNotes)
        Me.tbpCells.Controls.Add(Me.dataGridCellFooterNotes)
        Me.tbpCells.Controls.Add(Me.lblFooterCellNotes)
        Me.tbpCells.Location = New System.Drawing.Point(4, 22)
        Me.tbpCells.Name = "tbpCells"
        Me.tbpCells.Size = New System.Drawing.Size(642, 307)
        Me.tbpCells.TabIndex = 3
        Me.tbpCells.Text = "Cells"
        Me.tbpCells.UseVisualStyleBackColor = True
        '
        'dataGridCellFooterNotes
        '
        Me.dataGridCellFooterNotes.AllowUserToAddRows = False
        Me.dataGridCellFooterNotes.AllowUserToDeleteRows = False
        Me.dataGridCellFooterNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridCellFooterNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFooterNoteText, Me.colFooterColExpression, Me.colFooterRowExpression, Me.colFooterFormat})
        Me.dataGridCellFooterNotes.Location = New System.Drawing.Point(7, 58)
        Me.dataGridCellFooterNotes.Name = "dataGridCellFooterNotes"
        Me.dataGridCellFooterNotes.RowHeadersWidth = 62
        Me.dataGridCellFooterNotes.Size = New System.Drawing.Size(630, 162)
        Me.dataGridCellFooterNotes.TabIndex = 5
        '
        'colFooterNoteText
        '
        Me.colFooterNoteText.HeaderText = "Note Text"
        Me.colFooterNoteText.MinimumWidth = 8
        Me.colFooterNoteText.Name = "colFooterNoteText"
        Me.colFooterNoteText.Width = 220
        '
        'colFooterColExpression
        '
        Me.colFooterColExpression.HeaderText = "Column Expression"
        Me.colFooterColExpression.MinimumWidth = 8
        Me.colFooterColExpression.Name = "colFooterColExpression"
        Me.colFooterColExpression.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colFooterColExpression.Width = 140
        '
        'colFooterRowExpression
        '
        Me.colFooterRowExpression.HeaderText = "Row Expression(s)"
        Me.colFooterRowExpression.MinimumWidth = 8
        Me.colFooterRowExpression.Name = "colFooterRowExpression"
        Me.colFooterRowExpression.Width = 140
        '
        'colFooterFormat
        '
        Me.colFooterFormat.HeaderText = ""
        Me.colFooterFormat.Name = "colFooterFormat"
        Me.colFooterFormat.ReadOnly = True
        Me.colFooterFormat.Text = "Format"
        Me.colFooterFormat.UseColumnTextForButtonValue = True
        Me.colFooterFormat.Width = 60
        '
        'lblFooterCellNotes
        '
        Me.lblFooterCellNotes.AutoSize = True
        Me.lblFooterCellNotes.Location = New System.Drawing.Point(10, 40)
        Me.lblFooterCellNotes.Name = "lblFooterCellNotes"
        Me.lblFooterCellNotes.Size = New System.Drawing.Size(77, 13)
        Me.lblFooterCellNotes.TabIndex = 4
        Me.lblFooterCellNotes.Text = "Cell foot notes:"
        '
        'tbpSourceNotes
        '
        Me.tbpSourceNotes.Controls.Add(Me.ucrChkIncludeSourceNotes)
        Me.tbpSourceNotes.Controls.Add(Me.dataGridSourceNotes)
        Me.tbpSourceNotes.Controls.Add(Me.lblSourceNotes)
        Me.tbpSourceNotes.Location = New System.Drawing.Point(4, 22)
        Me.tbpSourceNotes.Name = "tbpSourceNotes"
        Me.tbpSourceNotes.Size = New System.Drawing.Size(642, 307)
        Me.tbpSourceNotes.TabIndex = 4
        Me.tbpSourceNotes.Text = "Source Notes"
        Me.tbpSourceNotes.UseVisualStyleBackColor = True
        '
        'dataGridSourceNotes
        '
        Me.dataGridSourceNotes.AllowUserToAddRows = False
        Me.dataGridSourceNotes.AllowUserToDeleteRows = False
        Me.dataGridSourceNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridSourceNotes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.colSourceNoteFormat})
        Me.dataGridSourceNotes.Location = New System.Drawing.Point(7, 57)
        Me.dataGridSourceNotes.Name = "dataGridSourceNotes"
        Me.dataGridSourceNotes.RowHeadersWidth = 62
        Me.dataGridSourceNotes.Size = New System.Drawing.Size(630, 203)
        Me.dataGridSourceNotes.TabIndex = 7
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Note Text"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 8
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'colSourceNoteFormat
        '
        Me.colSourceNoteFormat.HeaderText = ""
        Me.colSourceNoteFormat.Name = "colSourceNoteFormat"
        Me.colSourceNoteFormat.ReadOnly = True
        Me.colSourceNoteFormat.Text = "Format"
        Me.colSourceNoteFormat.UseColumnTextForButtonValue = True
        Me.colSourceNoteFormat.Width = 55
        '
        'lblSourceNotes
        '
        Me.lblSourceNotes.AutoSize = True
        Me.lblSourceNotes.Location = New System.Drawing.Point(5, 41)
        Me.lblSourceNotes.Name = "lblSourceNotes"
        Me.lblSourceNotes.Size = New System.Drawing.Size(73, 13)
        Me.lblSourceNotes.TabIndex = 6
        Me.lblSourceNotes.Text = "Source notes:"
        '
        'tbpThemes
        '
        Me.tbpThemes.Controls.Add(Me.ucrCboSelectThemes)
        Me.tbpThemes.Controls.Add(Me.btnManualTheme)
        Me.tbpThemes.Controls.Add(Me.rdoSelectTheme)
        Me.tbpThemes.Controls.Add(Me.rdoManualTheme)
        Me.tbpThemes.Controls.Add(Me.ucrPnlThemesPanel)
        Me.tbpThemes.Location = New System.Drawing.Point(4, 22)
        Me.tbpThemes.Name = "tbpThemes"
        Me.tbpThemes.Size = New System.Drawing.Size(642, 307)
        Me.tbpThemes.TabIndex = 6
        Me.tbpThemes.Text = "Themes"
        Me.tbpThemes.UseVisualStyleBackColor = True
        '
        'ucrCboSelectThemes
        '
        Me.ucrCboSelectThemes.AddQuotesIfUnrecognised = True
        Me.ucrCboSelectThemes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrCboSelectThemes.GetSetSelectedIndex = -1
        Me.ucrCboSelectThemes.IsReadOnly = False
        Me.ucrCboSelectThemes.Location = New System.Drawing.Point(157, 29)
        Me.ucrCboSelectThemes.Margin = New System.Windows.Forms.Padding(9)
        Me.ucrCboSelectThemes.Name = "ucrCboSelectThemes"
        Me.ucrCboSelectThemes.Size = New System.Drawing.Size(168, 21)
        Me.ucrCboSelectThemes.TabIndex = 3
        '
        'btnManualTheme
        '
        Me.btnManualTheme.Location = New System.Drawing.Point(157, 59)
        Me.btnManualTheme.Name = "btnManualTheme"
        Me.btnManualTheme.Size = New System.Drawing.Size(168, 21)
        Me.btnManualTheme.TabIndex = 2
        Me.btnManualTheme.Text = "Custom Theme"
        Me.btnManualTheme.UseVisualStyleBackColor = True
        '
        'rdoSelectTheme
        '
        Me.rdoSelectTheme.AutoSize = True
        Me.rdoSelectTheme.Checked = True
        Me.rdoSelectTheme.Location = New System.Drawing.Point(22, 31)
        Me.rdoSelectTheme.Name = "rdoSelectTheme"
        Me.rdoSelectTheme.Size = New System.Drawing.Size(91, 17)
        Me.rdoSelectTheme.TabIndex = 0
        Me.rdoSelectTheme.TabStop = True
        Me.rdoSelectTheme.Text = "Select Theme"
        Me.rdoSelectTheme.UseVisualStyleBackColor = True
        '
        'rdoManualTheme
        '
        Me.rdoManualTheme.AutoSize = True
        Me.rdoManualTheme.Location = New System.Drawing.Point(22, 61)
        Me.rdoManualTheme.Name = "rdoManualTheme"
        Me.rdoManualTheme.Size = New System.Drawing.Size(96, 17)
        Me.rdoManualTheme.TabIndex = 1
        Me.rdoManualTheme.Text = "Manual Theme"
        Me.rdoManualTheme.UseVisualStyleBackColor = True
        '
        'ucrPnlThemesPanel
        '
        Me.ucrPnlThemesPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrPnlThemesPanel.Location = New System.Drawing.Point(12, 16)
        Me.ucrPnlThemesPanel.Margin = New System.Windows.Forms.Padding(6)
        Me.ucrPnlThemesPanel.Name = "ucrPnlThemesPanel"
        Me.ucrPnlThemesPanel.Size = New System.Drawing.Size(349, 70)
        Me.ucrPnlThemesPanel.TabIndex = 4
        '
        'ucrSaveTable
        '
        Me.ucrSaveTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrSaveTable.Location = New System.Drawing.Point(14, 397)
        Me.ucrSaveTable.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSaveTable.Name = "ucrSaveTable"
        Me.ucrSaveTable.Size = New System.Drawing.Size(319, 24)
        Me.ucrSaveTable.TabIndex = 13
        '
        'ucrBase
        '
        Me.ucrBase.AutoSize = True
        Me.ucrBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ucrBase.Location = New System.Drawing.Point(10, 435)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(408, 52)
        Me.ucrBase.TabIndex = 7
        '
        'ucrDataFrameTable
        '
        Me.ucrDataFrameTable.AutoSize = True
        Me.ucrDataFrameTable.bDropUnusedFilterLevels = False
        Me.ucrDataFrameTable.bUseCurrentFilter = True
        Me.ucrDataFrameTable.Location = New System.Drawing.Point(10, 7)
        Me.ucrDataFrameTable.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrDataFrameTable.Name = "ucrDataFrameTable"
        Me.ucrDataFrameTable.Size = New System.Drawing.Size(151, 43)
        Me.ucrDataFrameTable.TabIndex = 1
        '
        'ucrChkIncludeCellFootNotes
        '
        Me.ucrChkIncludeCellFootNotes.AutoSize = True
        Me.ucrChkIncludeCellFootNotes.Checked = False
        Me.ucrChkIncludeCellFootNotes.Location = New System.Drawing.Point(10, 11)
        Me.ucrChkIncludeCellFootNotes.Name = "ucrChkIncludeCellFootNotes"
        Me.ucrChkIncludeCellFootNotes.Size = New System.Drawing.Size(248, 23)
        Me.ucrChkIncludeCellFootNotes.TabIndex = 15
        '
        'ucrChkIncludeSourceNotes
        '
        Me.ucrChkIncludeSourceNotes.AutoSize = True
        Me.ucrChkIncludeSourceNotes.Checked = False
        Me.ucrChkIncludeSourceNotes.Location = New System.Drawing.Point(10, 12)
        Me.ucrChkIncludeSourceNotes.Name = "ucrChkIncludeSourceNotes"
        Me.ucrChkIncludeSourceNotes.Size = New System.Drawing.Size(248, 23)
        Me.ucrChkIncludeSourceNotes.TabIndex = 16
        '
        'dlgGeneralTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 502)
        Me.Controls.Add(Me.ucrSaveTable)
        Me.Controls.Add(Me.ucrBase)
        Me.Controls.Add(Me.ucrDataFrameTable)
        Me.Controls.Add(Me.tbpFormatOptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "dlgGeneralTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Table Options"
        Me.tbpFormatOptions.ResumeLayout(False)
        Me.tbpHeader.ResumeLayout(False)
        Me.tbpHeader.PerformLayout()
        Me.tbpCells.ResumeLayout(False)
        Me.tbpCells.PerformLayout()
        CType(Me.dataGridCellFooterNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpSourceNotes.ResumeLayout(False)
        Me.tbpSourceNotes.PerformLayout()
        CType(Me.dataGridSourceNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpThemes.ResumeLayout(False)
        Me.tbpThemes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbpFormatOptions As TabControl
    Friend WithEvents tbpHeader As TabPage
    Friend WithEvents tbpCells As TabPage
    Friend WithEvents tbpSourceNotes As TabPage
    Friend WithEvents tbpThemes As TabPage
    Friend WithEvents ucrCboSelectThemes As ucrInputComboBox
    Friend WithEvents btnManualTheme As Button
    Friend WithEvents rdoSelectTheme As RadioButton
    Friend WithEvents rdoManualTheme As RadioButton
    Friend WithEvents ucrPnlThemesPanel As UcrPanel
    Friend WithEvents ucrInputHeaderSubtitle As ucrInputTextBox
    Friend WithEvents ucrInputHeaderTitle As ucrInputTextBox
    Friend WithEvents lblHeaderSubtitle As Label
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents btnHeaderSubtitleFormat As Button
    Friend WithEvents btnHeaderTitleFormat As Button
    Friend WithEvents lblFooterCellNotes As Label
    Friend WithEvents dataGridCellFooterNotes As DataGridView
    Friend WithEvents dataGridSourceNotes As DataGridView
    Friend WithEvents lblSourceNotes As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents colSourceNoteFormat As DataGridViewButtonColumn
    Friend WithEvents colFooterNoteText As DataGridViewTextBoxColumn
    Friend WithEvents colFooterColExpression As DataGridViewTextBoxColumn
    Friend WithEvents colFooterRowExpression As DataGridViewTextBoxColumn
    Friend WithEvents colFooterFormat As DataGridViewButtonColumn
    Friend WithEvents ucrDataFrameTable As ucrDataFrame
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrChkIncludeHeader As ucrCheck
    Friend WithEvents ucrInputHeaderTitleFooter As ucrInputTextBox
    Friend WithEvents btnHeaderSubtitleFooterFormat As Button
    Friend WithEvents ucrInputHeaderSubtitleFooter As ucrInputTextBox
    Friend WithEvents lblHeaderSubtitleFooter As Label
    Friend WithEvents lblHeaderTitleFooter As Label
    Friend WithEvents btnHeaderTitleFooterFormat As Button
    Friend WithEvents ucrSaveTable As ucrSave
    Friend WithEvents btnHeaderTitleNSubtitleFooterFormat As Button
    Friend WithEvents ucrInputHeaderTitleNSubtitleFooter As ucrInputTextBox
    Friend WithEvents lblHeaderTitleNSubtitleFooter As Label
    Friend WithEvents ucrChkIncludeCellFootNotes As ucrCheck
    Friend WithEvents ucrChkIncludeSourceNotes As ucrCheck
End Class
