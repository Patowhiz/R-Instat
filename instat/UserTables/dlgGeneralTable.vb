' R- Instat
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

Imports System.Reflection
Imports instat.Translations
Imports unvell.ReoGrid.IO.OpenXML.Schema

Public Class dlgGeneralTable
    Private clsBaseOperator As New ROperator
    Private clsGtFunction As New RFunction
    Private clsHeaderRFunction, clsTitleRFunction, clsSubtitleRFunction, clsTitleFooterRFunction, clsSubtitleFooterRFunction, clsTitleNSubtitleFooterRFunction As New RFunction

    Private clsThemeRFunction As New RFunction

    Private bFirstload As Boolean = True
    Private bReset As Boolean = True

    Private Sub dlgGeneralTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstload Then
            initialiseDialog()
            bFirstload = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
    End Sub

    Private Sub ucrChkIncludeHeader_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkIncludeHeader.ControlValueChanged
        If ucrChkIncludeHeader.Checked Then
            clsBaseOperator.AddParameter(strParameterName:="tab_header_funct_param", clsRFunctionParameter:=clsHeaderRFunction, iPosition:=2, bIncludeArgumentName:=False)
        Else
            clsBaseOperator.RemoveParameterByName("tab_header_funct_param")
        End If
    End Sub

    Private Sub ucrInputHeaderTitle_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrInputHeaderTitle.ControlContentsChanged
        ' Raise footer control value changed event to remove the footer parameter
        ucrInputHeaderTitleFooter.OnControlValueChanged()
        ucrInputHeaderTitleNSubtitleFooter.OnControlValueChanged()

        updateHeaderFooterControlsVisibility()
    End Sub

    Private Sub ucrInputHeaderTitleFooter_CControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputHeaderTitleFooter.ControlValueChanged
        If ucrInputHeaderTitle.IsEmpty() OrElse ucrInputHeaderTitleFooter.IsEmpty() Then
            clsBaseOperator.RemoveParameterByName("tab_footnote_title_param")
        Else
            clsBaseOperator.AddParameter("tab_footnote_title_param", clsRFunctionParameter:=GetNewFooterRFunction(clsTitleFooterRFunction, {"title"}), iPosition:=3)
        End If
    End Sub

    Private Sub btnHeaderTitleFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderTitleFormat.Click
        ShowTextFormSubDialog(clsTitleRFunction)
    End Sub

    Private Sub btnHeaderTitleFooterFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderTitleFooterFormat.Click
        ShowTextFormSubDialog(clsTitleFooterRFunction)
    End Sub


    Private Sub ucrInputHeaderSubtitle_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrInputHeaderSubtitle.ControlContentsChanged
        ' Subtitle is optional, so remove the parameter when empty
        If ucrInputHeaderSubtitle.IsEmpty() Then
            ' Remove Subtitle footer parameter 
            clsHeaderRFunction.RemoveParameterByName("subtitle")
        Else
            clsHeaderRFunction.AddParameter("subtitle", clsRFunctionParameter:=clsSubtitleRFunction, iPosition:=1)
        End If

        ' Raise footer control value changed event to remove the footer parameter
        ucrInputHeaderSubtitleFooter.OnControlValueChanged()
        ucrInputHeaderTitleNSubtitleFooter.OnControlValueChanged()

        updateHeaderFooterControlsVisibility()
    End Sub

    Private Sub ucrInputHeaderSubtitleFooter_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputHeaderSubtitleFooter.ControlValueChanged
        If ucrInputHeaderSubtitle.IsEmpty() OrElse ucrInputHeaderSubtitleFooter.IsEmpty() Then
            ' Remove Subtitle footer parameter when Subtitle has not been input is empty or when the footer has not been input 
            clsHeaderRFunction.RemoveParameterByName("tab_footnote_subtitle_param")
        Else
            clsBaseOperator.AddParameter("tab_footnote_subtitle_param", clsRFunctionParameter:=GetNewFooterRFunction(clsSubtitleFooterRFunction, {"subtitle"}), iPosition:=4)
        End If
    End Sub

    Private Sub btnHeaderSubTitleFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderSubtitleFormat.Click
        ShowTextFormSubDialog(clsSubtitleRFunction)
    End Sub


    Private Sub btnHeaderSubtitleFooterFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderSubtitleFooterFormat.Click
        ShowTextFormSubDialog(clsSubtitleFooterRFunction)
    End Sub

    Private Sub ucrInputHeaderTitleNSubtitleFooter_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputHeaderTitleNSubtitleFooter.ControlValueChanged
        If ucrInputHeaderTitle.IsEmpty() OrElse ucrInputHeaderSubtitle.IsEmpty() OrElse ucrInputHeaderTitleNSubtitleFooter.IsEmpty() Then
            clsHeaderRFunction.RemoveParameterByName("tab_footnote_titleNsubtitle_param")
        Else
            clsBaseOperator.AddParameter("tab_footnote_titleNsubtitle_param", clsRFunctionParameter:=GetNewFooterRFunction(clsTitleNSubtitleFooterRFunction, {"title", "subtitle"}), iPosition:=5)
        End If
    End Sub

    Private Sub btnHeaderTitleNSubtitleFooterFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderTitleNSubtitleFooterFormat.Click
        ShowTextFormSubDialog(clsTitleNSubtitleFooterRFunction)
    End Sub






    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub initialiseDialog()

        ucrDataFrameTable.SetParameter(New RParameter("dataframe", 0))
        ucrDataFrameTable.SetParameterIsRFunction()

        '-----------------------------------------
        ' HEADER CONTROLS 

        ucrChkIncludeHeader.SetText("Include Header")
        ucrChkIncludeHeader.AddParameterPresentCondition(True, "tab_header_funct_param", True)
        ucrChkIncludeHeader.AddParameterPresentCondition(False, "tab_header_funct_param", False)
        ucrChkIncludeHeader.AddToLinkedControls({ucrInputHeaderTitle, ucrInputHeaderSubtitle}, {True}, bNewLinkedHideIfParameterMissing:=True)

        ' Title controls
        ucrInputHeaderTitle.SetParameter(New RParameter("title_text_param", 0, bNewIncludeArgumentName:=False))
        ucrInputHeaderTitle.SetLinkedDisplayControl(New List(Of Control)({lblHeaderTitle, btnHeaderTitleFormat}))
        ucrInputHeaderTitleFooter.SetParameter(New RParameter("title_footnote_text_param", 0, bNewIncludeArgumentName:=False))
        ucrInputHeaderTitleFooter.SetLinkedDisplayControl(New List(Of Control)({lblHeaderTitleFooter, btnHeaderTitleFooterFormat}))

        ucrInputHeaderSubtitle.SetParameter(New RParameter("subtitle_text_param", 0, bNewIncludeArgumentName:=False))
        ucrInputHeaderSubtitle.SetLinkedDisplayControl(New List(Of Control)({lblHeaderSubtitle, btnHeaderSubtitleFormat}))
        ucrInputHeaderSubtitleFooter.SetParameter(New RParameter("subtitle_footnote_text_param", 0, bNewIncludeArgumentName:=False))
        ucrInputHeaderSubtitleFooter.SetLinkedDisplayControl(New List(Of Control)({lblHeaderSubtitleFooter, btnHeaderSubtitleFooterFormat}))

        ucrInputHeaderTitleNSubtitleFooter.SetParameter(New RParameter("title_n_subtitle_footnote_text_param", 0, bNewIncludeArgumentName:=False))
        ucrInputHeaderTitleNSubtitleFooter.SetLinkedDisplayControl(New List(Of Control)({lblHeaderTitleNSubtitleFooter, btnHeaderTitleNSubtitleFooterFormat}))
        '-----------------------------------------

        ucrChkIncludeCellFootNotes.SetText("Include Cell Foot Notes")
        ucrChkIncludeSourceNotes.SetText("Include Source Notes")



        ucrPnlThemesPanel.AddRadioButton(rdoSelectTheme)
        ucrPnlThemesPanel.AddRadioButton(rdoManualTheme)

        ucrCboSelectThemes.SetItems({"None", "Dark Theme", "538 Theme", "Dot Matrix Theme", "Espn Theme", "Excel Theme", "Guardian Theme", "NY Times Theme", "PFF Theme"})
        ucrCboSelectThemes.SetDropDownStyleAsNonEditable()

        ucrSaveTable.SetPrefix("table")
        ucrSaveTable.SetSaveType(RObjectTypeLabel.Table, strRObjectFormat:=RObjectFormat.Html)
        ucrSaveTable.SetDataFrameSelector(ucrDataFrameTable)
        ucrSaveTable.SetIsComboBox()
        ucrSaveTable.SetCheckBoxText("Save Table")
        ucrSaveTable.SetAssignToIfUncheckedValue("last_table")
    End Sub

    Private Sub SetDefaults()
        clsBaseOperator = New ROperator
        clsGtFunction = New RFunction

        clsHeaderRFunction = New RFunction
        clsTitleRFunction = New RFunction
        clsTitleFooterRFunction = New RFunction
        clsSubtitleRFunction = New RFunction
        clsSubtitleFooterRFunction = New RFunction
        clsTitleNSubtitleFooterRFunction = New RFunction

        clsThemeRFunction = New RFunction

        ucrChkIncludeHeader.Checked = False
        updateHeaderFooterControlsVisibility()
        ucrSaveTable.Reset()

        clsBaseOperator.SetOperation("%>%")
        clsBaseOperator.bBrackets = False

        clsGtFunction.SetPackageName("gt")
        clsGtFunction.SetRCommand("gt")
        clsBaseOperator.AddParameter(strParameterName:="gt_funct_param", clsRFunctionParameter:=clsGtFunction, iPosition:=1, bIncludeArgumentName:=False)

        '-----------------------------------------
        ' HEADER  
        clsHeaderRFunction.SetPackageName("gt")
        clsHeaderRFunction.SetRCommand("tab_header")

        ' Title related R functions
        clsTitleRFunction = GetNewHtmlSpanRFunction()
        clsHeaderRFunction.AddParameter("title",
                                        clsRFunctionParameter:=clsTitleRFunction,
                                        iPosition:=0)  ' Title parameter is always required so add it to the header function by default
        clsTitleFooterRFunction = GetNewHtmlSpanRFunction()

        ' Subtitle related R functions
        clsSubtitleRFunction = GetNewHtmlSpanRFunction()
        clsSubtitleFooterRFunction = GetNewHtmlSpanRFunction()

        ' Title and Subtitle footer related R functions
        clsTitleNSubtitleFooterRFunction = GetNewHtmlSpanRFunction()

        '-----------------------------------------

        ucrBase.clsRsyntax.SetBaseROperator(clsBaseOperator)

    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)

        ucrDataFrameTable.SetRCode(clsBaseOperator, bReset)

        ucrChkIncludeHeader.SetRCode(clsBaseOperator, bReset)
        ucrInputHeaderTitle.SetRCode(clsTitleRFunction, bReset)
        ucrInputHeaderTitleFooter.SetRCode(clsTitleFooterRFunction, bReset)
        ucrInputHeaderSubtitle.SetRCode(clsSubtitleRFunction, bReset)
        ucrInputHeaderSubtitleFooter.SetRCode(clsSubtitleFooterRFunction, bReset)
        ucrInputHeaderTitleNSubtitleFooter.SetRCode(clsTitleNSubtitleFooterRFunction, bReset)

        SetCellFootNotesGridContentsFromRCode(clsBaseOperator)
        SetSourceNotesGridContentsFromRCode(clsBaseOperator)

        ucrSaveTable.SetRCode(clsBaseOperator, bReset)

    End Sub

    Private Function GetNewHtmlSpanRFunction() As RFunction
        Dim clsHtmlDivRFunction As New RFunction
        clsHtmlDivRFunction.SetPackageName("htmltools")
        clsHtmlDivRFunction.SetRCommand("tags$span")
        Return clsHtmlDivRFunction
    End Function

    Private Function GetNewHtmlStyleRFunction() As RFunction
        Dim clsStyleRFunction As New RFunction
        clsStyleRFunction.SetPackageName("htmltools")
        clsStyleRFunction.SetRCommand("css")
        Return clsStyleRFunction
    End Function

    Private Function GetNewFooterRFunction(footNoteRFunction As RFunction, groupsParameterValues() As String)

        Dim clsCellsTitleRFunction As New RFunction
        clsCellsTitleRFunction.SetPackageName("gt")
        clsCellsTitleRFunction.SetRCommand("cells_title")

        For Each str As String In groupsParameterValues

        Next

        For index As Integer = 0 To groupsParameterValues.Count - 1
            groupsParameterValues(index) = Chr(34) & groupsParameterValues(index) & Chr(34)
        Next
        clsCellsTitleRFunction.AddParameter("groups", strParameterValue:=mdlCoreControl.GetRVector(groupsParameterValues, bOnlyIfMultipleElement:=True))

        Dim clsFooterRFunction As New RFunction
        clsFooterRFunction.SetPackageName("gt")
        clsFooterRFunction.SetRCommand("tab_footnote")
        clsFooterRFunction.AddParameter("footnote", clsRFunctionParameter:=footNoteRFunction, iPosition:=0)
        clsFooterRFunction.AddParameter("locations", clsRFunctionParameter:=clsCellsTitleRFunction, iPosition:=1)

        Return clsFooterRFunction
    End Function

    Private Sub TestOKEnabled()
        ucrBase.OKEnabled(ucrSaveTable.IsComplete)
    End Sub

    Private Sub ShowTextFormSubDialog(clsHtmlTagRFunction As RFunction)
        If Not clsHtmlTagRFunction.ContainsParameter("style") Then
            clsHtmlTagRFunction.AddParameter(strParameterName:="style", clsRFunctionParameter:=GetNewHtmlStyleRFunction(), iPosition:=1)
        End If
        sdgTableOptionsTextFormat.Setup(clsHtmlTagRFunction)
        sdgTableOptionsTextFormat.ShowDialog(Me)
    End Sub

    Private Sub updateHeaderFooterControlsVisibility()
        ucrInputHeaderTitleFooter.Visible = Not ucrInputHeaderTitle.IsEmpty()
        ucrInputHeaderSubtitleFooter.Visible = Not ucrInputHeaderSubtitle.IsEmpty()
        ucrInputHeaderTitleNSubtitleFooter.Visible = Not ucrInputHeaderSubtitle.IsEmpty() AndAlso Not ucrInputHeaderSubtitle.IsEmpty()
    End Sub

    '----------------------------------------------------------


    Private Sub SetCellFootNotesGridContentsFromRCode(clsOperator As ROperator)
        dataGridCellFooterNotes.Rows.Clear()

        For Each clsRParam As RParameter In clsOperator.clsParameters
            If clsRParam.strArgumentName.Contains("cell_foot_note_param") Then
                ' Create a new row that represents the tab_footnote() parameters 
                Dim row As New DataGridViewRow
                row.CreateCells(dataGridCellFooterNotes)

                Dim clsFooterRFunction As RFunction = clsRParam.clsArgumentCodeStructure

                For Each clsFootNoteRParam As RParameter In clsFooterRFunction.clsParameters

                    If clsFootNoteRParam.strArgumentName = "footnote" Then
                        ' Set the foot note text
                        row.Cells(0).Value = GetStringValue(clsFootNoteRParam.clsArgumentCodeStructure.clsParameters(0).strArgumentValue, False)
                    ElseIf clsFootNoteRParam.strArgumentName = "locations" Then
                        ' todo go through the location function
                        Dim clsFooterLocationNoteRFunction As RFunction = clsFootNoteRParam.clsArgumentCodeStructure

                        If clsFooterLocationNoteRFunction.strRCommand = "cells_body" AndAlso dataGridCellFooterNotes Is Me.dataGridCellFooterNotes Then
                            For Each clsFootNoteLocationRParam As RParameter In clsFooterLocationNoteRFunction.clsParameters
                                If clsFootNoteLocationRParam.strArgumentName = "columns" Then
                                    row.Cells(1).Value = GetStringValue(clsFootNoteLocationRParam.strArgumentValue, False)
                                ElseIf clsFootNoteLocationRParam.strArgumentName = "rows" Then
                                    row.Cells(2).Value = GetStringValue(clsFootNoteLocationRParam.strArgumentValue, False)
                                End If
                            Next
                        End If
                    End If

                    ' Tag and add the tab_footnote() function contents as a row
                    ' Check if second cell has a value
                    If row.Cells(1).Value IsNot Nothing Then
                        row.Tag = clsFooterRFunction
                        dataGridCellFooterNotes.Rows.Add(row)
                    End If


                Next

            End If
        Next

        ucrChkIncludeCellFootNotes.Checked = dataGridCellFooterNotes.Rows.Count > 0

        ' Always add a place holder row for new foot note
        dataGridCellFooterNotes.Rows.Add()

    End Sub



    Private Sub SetSourceNotesGridContentsFromRCode(clsOperator As ROperator)
        dataGridSourceNotes.Rows.Clear()

        For Each clsRParam As RParameter In clsOperator.clsParameters
            If clsRParam.strArgumentName.Contains("source_note_param") Then
                ' Create a new row that represents the tab_footnote() parameters
                Dim row As New DataGridViewRow
                row.CreateCells(dataGridSourceNotes)

                Dim clsFooterRFunction As RFunction = clsRParam.clsArgumentCodeStructure
                For Each clsFootNoteRParam As RParameter In clsFooterRFunction.clsParameters
                    If clsFootNoteRParam.strArgumentName = "source_note" Then
                        ' Set the foot note text
                        row.Cells(0).Value = GetStringValue(clsFootNoteRParam.clsArgumentCodeStructure.clsParameters(0).strArgumentValue, False)
                    End If
                Next

                ' Tag and add the tab_footnote() function contents as a row
                row.Tag = clsFooterRFunction
                dataGridSourceNotes.Rows.Add(row)

            End If
        Next

        ucrChkIncludeSourceNotes.Checked = dataGridSourceNotes.Rows.Count > 0

        ' Always add a place holder row for new foot note
        dataGridSourceNotes.Rows.Add()

    End Sub


    Private Sub dataGridNotes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridCellFooterNotes.CellEndEdit, dataGridSourceNotes.CellEndEdit
        Dim dataGrid As DataGridView = sender
        Dim row As DataGridViewRow = dataGrid.Rows.Item(e.RowIndex)
        Dim strNoteTextValue As String = row.Cells(0).Value

        ' If no foot note typed by user then just exit the sub
        If String.IsNullOrEmpty(strNoteTextValue) Then
            Exit Sub
        End If

        Dim clsNoteRFunction As RFunction = Nothing
        Dim strParameterNamePrefix As String = ""

        If dataGrid Is dataGridCellFooterNotes Then

            clsNoteRFunction = SetupAndGetNewNoteRFunction(row.Tag, "tab_footnote", "footnote", strNoteTextValue)
            strParameterNamePrefix = "cell_foot_note_param"

            ' Add column and row expressions as paramters if user has typed them
            If Not String.IsNullOrEmpty(row.Cells(1).Value) AndAlso Not String.IsNullOrEmpty(row.Cells(2).Value) Then
                Dim clsFooterLocationNoteRFunction As New RFunction
                clsFooterLocationNoteRFunction.SetPackageName("gt")
                clsFooterLocationNoteRFunction.SetRCommand("cells_body")
                clsFooterLocationNoteRFunction.AddParameter(New RParameter(strParameterName:="columns", strParamValue:=GetStringValue(row.Cells(1).Value, False)))
                clsFooterLocationNoteRFunction.AddParameter(New RParameter(strParameterName:="rows", strParamValue:=GetStringValue(row.Cells(2).Value, False)))
                clsNoteRFunction.AddParameter(New RParameter(strParameterName:="locations", strParamValue:=clsFooterLocationNoteRFunction, iNewPosition:=1))
            End If

        ElseIf dataGrid Is dataGridSourceNotes Then
            clsNoteRFunction = SetupAndGetNewNoteRFunction(row.Tag, "tab_source_note", "source_note", strNoteTextValue)
            strParameterNamePrefix = "source_note_param"
        End If

        ' Overwrite the tag with the new foot function
        row.Tag = clsNoteRFunction

        clsBaseOperator.AddParameter(strParameterNamePrefix & e.RowIndex, clsRFunctionParameter:=clsNoteRFunction, bIncludeArgumentName:=False)


        ' If last row then add new empty row
        If e.RowIndex = dataGrid.Rows.Count - 1 Then
            dataGrid.Rows.Add()
        End If
    End Sub

    Private Function SetupAndGetNewNoteRFunction(clsPossibleNoteRFunction As RFunction, strNoteRCommand As String, strRNoteTextParameterName As String, strNoteTextValue As String) As RFunction
        Dim clsNewNoteRFunction As RFunction = clsPossibleNoteRFunction
        ' Get the prevous style parameter to retain any format options previously done
        Dim clsStyleParam As RParameter
        If clsNewNoteRFunction IsNot Nothing Then
            clsStyleParam = clsNewNoteRFunction.GetParameter(strRNoteTextParameterName).clsArgumentCodeStructure.GetParameter("style")
        Else
            clsStyleParam = New RParameter(strParameterName:="style", strParamValue:=GetNewHtmlStyleRFunction(), iNewPosition:=1)
        End If


        ' Recreate the footer function
        clsNewNoteRFunction = New RFunction
        clsNewNoteRFunction.SetPackageName("gt")
        clsNewNoteRFunction.SetRCommand(strNoteRCommand)

        Dim clsNoteTextRFunction As RFunction = GetNewHtmlSpanRFunction()
        clsNoteTextRFunction.AddParameter(New RParameter(strParameterName:="", strParamValue:=GetStringValue(strNoteTextValue, True), iNewPosition:=0, bNewIncludeArgumentName:=False))
        clsNoteTextRFunction.AddParameter(clsStyleParam) ' Add the style parameter for formating

        ' Add the foot note text parameter to the footer R function
        clsNewNoteRFunction.AddParameter(New RParameter(strParameterName:=strRNoteTextParameterName, strParamValue:=clsNoteTextRFunction, iNewPosition:=0))
        Return clsNewNoteRFunction
    End Function

    Private Function GetStringValue(str As String, bwithQuotes As Boolean) As String
        If String.IsNullOrEmpty(str) Then
            str = ""
        End If
        Return If(bwithQuotes, """" & str & """", str.Replace("""", ""))
    End Function


    Private Sub dataGridNotes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridCellFooterNotes.CellClick, dataGridSourceNotes.CellClick

        Dim dataGrid As DataGridView = sender
        Dim clsNoteRFunction As RFunction = dataGrid.Rows.Item(e.RowIndex).Tag
        Dim strParameterName As String = Nothing

        '---------------------------
        ' Ignore clicks that are not from button cells. 
        If dataGrid Is dataGridCellFooterNotes Then
            strParameterName = "footnote"
            If e.ColumnIndex <> 3 Then
                Exit Sub
            End If
        ElseIf dataGrid Is dataGridSourceNotes Then
            strParameterName = "source_note"
            If e.ColumnIndex <> 1 Then
                Exit Sub
            End If
        End If
        '---------------------------

        If clsNoteRFunction IsNot Nothing AndAlso strParameterName IsNot Nothing Then
            ShowTextFormSubDialog(clsNoteRFunction.GetParameter(strParameterName).clsArgumentCodeStructure.GetParameter("style").clsArgumentCodeStructure)
        End If

    End Sub


End Class