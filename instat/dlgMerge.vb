﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat
Imports instat.Translations

Public Class dlgMerge
    Private bFirstLoad As Boolean = True
    Private clsMergeFunction As New RFunction
    Private clsByListFunction As New RFunction
    Private bReset As Boolean = True
    Private bResetSubdialog As Boolean = True
    Private ttJoinType As New ToolTip
    Private dctJoinTexts As New Dictionary(Of String, String)
    Private bMergeColumnsExist As Boolean
    Private clsSuffixCFunction As New RFunction

    ' This dialog has a bug when using numeric and integer columns as the joining columns.
    ' Issue reported here: https://github.com/hadley/dplyr/issues/2164
    ' The current fix we suggest is to first convert integer joining columns to numeric columns.
    ' Alternatives would be to use the much slower base merge 
    ' or plyr::join which cannot handle joining columns with different names
    Private Sub dlgMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        SetMergingBy()
        TestOKEnabled()
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        Dim dctJoinTypes As New Dictionary(Of String, String)
        ucrBase.iHelpTopicID = 60

        'sdgMerge.SetRSyntax(ucrBase.clsRsyntax)
        dctJoinTypes.Add("Full Join", "full_join")
        dctJoinTypes.Add("Left Join", "left_join")
        dctJoinTypes.Add("Right Join", "right_join")
        dctJoinTypes.Add("Inner Join", "inner_join")
        dctJoinTypes.Add("Semi Join", "semi_join")
        dctJoinTypes.Add("Anti Join", "anti_join")
        ucrInputJoinType.SetItems(dctItemParameterValuePairs:=dctJoinTypes, bSetConditions:=False)

        dctJoinTexts.Add("Full Join", "Include all rows and all columns from both data frames. Where there are not matching values, returns NA for the one missing.")
        dctJoinTexts.Add("Left Join", "Include all rows from the 1st data frame, and all columns from both data frames." & Environment.NewLine & "Rows in the 1st data frame with no match in the second data frame will have NA values in the new columns." & Environment.NewLine & "If there are multiple matches, all combinations of the matches are included.")
        dctJoinTexts.Add("Right Join", "Include all rows from the 2nd data frame, and all columns from both data frames." & Environment.NewLine & "Rows in the second data frame with no match in the 1st data frame will have NA values in the new columns." & Environment.NewLine & "If there are multiple matches, all combinations of the matches are included.")
        dctJoinTexts.Add("Inner Join", "Include all rows from the 1st data frame where there are matching values in the 2nd data frame, and all columns from both data frames." & Environment.NewLine & "If there are multiple matches, all combination of the matches are included.")
        dctJoinTexts.Add("Semi Join", "Include all rows from the 1st data frame where there are matching values in the 2nd data frame, keeping just columns from the 1st data frame." & Environment.NewLine & "(A semi join differs from an inner join because an inner join will include one row of the 1st data frame for each matching row of the 2nd data frame, where a semi join will never duplicate rows of the 1st data frame.)")
        dctJoinTexts.Add("Anti Join", "Include all rows from the 1st data frame where there are not matching values the 2nd data frame, keeping just columns from the 1st data frame.")

        ucrInputJoinType.AddFunctionNamesCondition("Full Join", "full_join")
        ucrInputJoinType.AddFunctionNamesCondition("Left Join", "left_join")
        ucrInputJoinType.AddFunctionNamesCondition("Right Join", "right_join")
        ucrInputJoinType.AddFunctionNamesCondition("Inner Join", "inner_join")
        ucrInputJoinType.AddFunctionNamesCondition("Semi Join", "semi_join")
        ucrInputJoinType.AddFunctionNamesCondition("Anti Join", "anti_join")
        ucrInputJoinType.SetDropDownStyleAsNonEditable()

        ucrFirstDataFrame.SetParameter(New RParameter("x", 0))
        ucrFirstDataFrame.SetParameterIsRFunction()
        ucrFirstDataFrame.SetLabelText("First Data Frame:")

        ucrSecondDataFrame.SetParameter(New RParameter("y", 1))
        ucrSecondDataFrame.SetParameterIsRFunction()
        ucrSecondDataFrame.SetLabelText("Second Data Frame:")

        ucrInputMergingBy.IsReadOnly = True
        ucrInputMergingBy.IsMultiline = True
        ucrInputMergingBy.bIsActiveRControl = False
        ucrInputMergingBy.txtInput.ScrollBars = ScrollBars.Vertical

        ucrSaveMerge.SetLabelText("New Data Frame Name:")
        ucrSaveMerge.SetIsTextBox()
        ucrSaveMerge.SetSaveTypeAsDataFrame()
        ucrSaveMerge.SetPrefix("merge")
    End Sub

    Private Sub SetDefaults()
        clsMergeFunction = New RFunction
        clsByListFunction = New RFunction
        clsSuffixCFunction = New RFunction

        ucrFirstDataFrame.Reset()
        ucrSecondDataFrame.Reset()
        ucrSaveMerge.Reset()

        clsMergeFunction.SetPackageName("dplyr")
        clsMergeFunction.SetRCommand("full_join")
        clsByListFunction.SetRCommand("c")
        clsSuffixCFunction.SetRCommand("c")

        ucrBase.clsRsyntax.SetBaseRFunction(clsMergeFunction)
        bResetSubdialog = True
    End Sub

    Private Sub SetRCodeForControls(bResetControls As Boolean)
        ucrFirstDataFrame.SetRCode(clsMergeFunction, bResetControls)
        ucrSecondDataFrame.SetRCode(clsMergeFunction, bResetControls)
        ucrInputJoinType.SetRCode(clsMergeFunction, bResetControls)
        ucrSaveMerge.SetRCode(clsMergeFunction, bResetControls)
    End Sub

    Private Sub TestOKEnabled()
        If ucrSaveMerge.IsComplete() AndAlso ucrFirstDataFrame.cboAvailableDataFrames.Text <> "" AndAlso ucrSecondDataFrame.cboAvailableDataFrames.Text <> "" AndAlso bMergeColumnsExist Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub cmdJoinOptions_Click(sender As Object, e As EventArgs) Handles cmdJoinOptions.Click
        sdgMerge.Setup(ucrFirstDataFrame.cboAvailableDataFrames.Text, ucrSecondDataFrame.cboAvailableDataFrames.Text, clsMergeFunction, clsByListFunction, bResetSubdialog)
        sdgMerge.ShowDialog()
        bResetSubdialog = False
        SetMergingBy()
    End Sub

    Private Sub cmdColumnOptions_Click(sender As Object, e As EventArgs) Handles cmdColumnOptions.Click
        sdgMergeColumnstoInclude.Setup(ucrFirstDataFrame.cboAvailableDataFrames.Text, ucrSecondDataFrame.cboAvailableDataFrames.Text, clsMergeFunction, clsByListFunction, bResetSubdialog)
        sdgMergeColumnstoInclude.ShowDialog()
        bResetSubdialog = False
        SetMergingBy()
    End Sub

    Private Sub ucrInputJoinType_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputJoinType.ControlValueChanged
        Dim bFound As Boolean = True

        If Not ucrInputJoinType.IsEmpty() Then
            Select Case ucrInputJoinType.GetText()
                Case "Full Join"
                    clsMergeFunction.SetRCommand("full_join")
                Case "Left Join"
                    clsMergeFunction.SetRCommand("left_join")
                Case "Right Join"
                    clsMergeFunction.SetRCommand("right_join")
                Case "Inner Join"
                    clsMergeFunction.SetRCommand("inner_join")
                Case "Semi Join"
                    clsMergeFunction.SetRCommand("semi_join")
                Case "Anti Join"
                    clsMergeFunction.SetRCommand("anti_join")
                Case Else
                    bFound = False
            End Select
            'This stops the tool tip popping up during selection
            ttJoinType.Active = False
            If bFound Then
                ttJoinType.SetToolTip(ucrInputJoinType.cboInput, dctJoinTexts(ucrInputJoinType.GetText()))
                ttJoinType.Active = True
            End If
        End If
    End Sub

    Private Sub DataFrames_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrFirstDataFrame.ControlValueChanged, ucrSecondDataFrame.ControlValueChanged
        If ucrFirstDataFrame.cboAvailableDataFrames.Text <> "" AndAlso ucrSecondDataFrame.cboAvailableDataFrames.Text <> "" Then
            clsSuffixCFunction.AddParameter("0", strParameterValue:=Chr(34) & ucrFirstDataFrame.cboAvailableDataFrames.Text & Chr(34), iPosition:=0, bIncludeArgumentName:=False)
            clsSuffixCFunction.AddParameter("1", strParameterValue:=Chr(34) & ucrSecondDataFrame.cboAvailableDataFrames.Text & Chr(34), iPosition:=1, bIncludeArgumentName:=False)
        Else
            clsMergeFunction.RemoveParameterByName("suffix")
        End If
        ' Ensures options set on the subdialog are "reset" since they depend on data frame choice
        clsMergeFunction.RemoveParameterByName("by")
        clsByListFunction.ClearParameters()
        clsMergeFunction.AddParameter("x", clsRFunctionParameter:=ucrFirstDataFrame.clsCurrDataFrame, iPosition:=0)
        clsMergeFunction.AddParameter("y", clsRFunctionParameter:=ucrSecondDataFrame.clsCurrDataFrame, iPosition:=1)
        SetMergingBy()
    End Sub

    Private Sub ucrFirstDataFrame_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrFirstDataFrame.ControlContentsChanged, ucrSecondDataFrame.ControlContentsChanged, ucrSaveMerge.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub SetMergingBy()
        Dim dctJoinColumns As New Dictionary(Of String, String)
        Dim lstJoinPairs As New List(Of String)
        Dim lstFirstColumns As List(Of String)
        Dim lstSecondColumns As List(Of String)
        Dim i As Integer = 0

        If ucrFirstDataFrame.cboAvailableDataFrames.Text <> "" AndAlso ucrSecondDataFrame.cboAvailableDataFrames.Text <> "" Then
            If clsMergeFunction.ContainsParameter("by") Then
                For Each clsTempParam As RParameter In clsByListFunction.clsParameters
                    dctJoinColumns.Add(clsTempParam.strArgumentName.Trim(Chr(34)), clsTempParam.strArgumentValue.Trim(Chr(34)))
                Next
            Else
                lstFirstColumns = frmMain.clsRLink.GetColumnNames(ucrFirstDataFrame.cboAvailableDataFrames.Text)
                lstSecondColumns = frmMain.clsRLink.GetColumnNames(ucrSecondDataFrame.cboAvailableDataFrames.Text)
                i = 0
                For Each strFirst As String In lstFirstColumns
                    If lstSecondColumns.Contains(strFirst) Then
                        dctJoinColumns.Add(strFirst, strFirst)
                        clsByListFunction.AddParameter(Chr(34) & strFirst & Chr(34), Chr(34) & strFirst & Chr(34), iPosition:=i)
                        i = i + 1
                    End If
                Next
                If clsByListFunction.iParameterCount > 0 Then
                    clsMergeFunction.AddParameter("by", clsRFunctionParameter:=clsByListFunction, iPosition:=2)
                End If
            End If
            If dctJoinColumns.Count > 0 Then
                For Each kvpTemp As KeyValuePair(Of String, String) In dctJoinColumns
                    lstJoinPairs.Add(kvpTemp.Key & " = " & kvpTemp.Value)
                Next
                ucrInputMergingBy.SetName(String.Join(", ", lstJoinPairs))
                ucrInputMergingBy.txtInput.BackColor = SystemColors.Control
                cmdJoinOptions.BackColor = SystemColors.ButtonFace
                cmdJoinOptions.UseVisualStyleBackColor = True
            Else
                ucrInputMergingBy.SetName("No columns to merge by!" & Environment.NewLine & "Click Join Options to specify merging columns.")
                ucrInputMergingBy.txtInput.BackColor = Color.LightCoral
                cmdJoinOptions.BackColor = Color.LemonChiffon
            End If
        Else
            ucrInputMergingBy.SetName("")
            ucrInputMergingBy.txtInput.BackColor = SystemColors.Control
            clsMergeFunction.RemoveParameterByName("by")
            clsByListFunction.ClearParameters()
        End If
        bMergeColumnsExist = (dctJoinColumns.Count > 0)
        TestOKEnabled()
    End Sub
End Class