Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ucrObjectTypeSelector

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        'set up the combobox for object types
        Dim dct As New Dictionary(Of String, String) From {
            {"object", "Objects"},
            {RObjectTypeLabel.Summary, "Summaries"},
            {RObjectTypeLabel.Table, "Tables"},
            {RObjectTypeLabel.Graph, "Graphs"},
            {RObjectTypeLabel.Model, "Models"},
            {RObjectTypeLabel.StructureLabel, "Structured"}}

        cboObjectType.DataSource = New BindingSource(dct, Nothing)
        cboObjectType.ValueMember = "Key"
        cboObjectType.DisplayMember = "Value"
        cboObjectType.SelectedIndex = 0
    End Sub

    Private Sub cboObjectType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboObjectType.SelectedIndexChanged
        OnControlContentsChanged()
        OnControlValueChanged()
    End Sub

    Public Function GetSelectedValue() As String
        Return DirectCast(cboObjectType.SelectedItem, KeyValuePair(Of String, String)).Key
    End Function

    Public Function GetSelectedText() As String
        Return DirectCast(cboObjectType.SelectedItem, KeyValuePair(Of String, String)).Value
    End Function

    Public Sub SetSelectedIndex(index As Integer)
        cboObjectType.SelectedIndex = index
    End Sub

End Class
