Imports unvell.ReoGrid.IO.OpenXML.Schema

Public Class ucrHeaders

    Private clsHeaderRFunction, clsTitleRFunction, clsSubtitleRFunction, clsTitleFooterRFunction, clsSubtitleFooterRFunction, clsTitleNSubtitleFooterRFunction As New RFunction
    Private clsBaseOperator As New ROperator

    Private Sub ucrChkIncludeHeader_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkIncludeHeader.ControlValueChanged
        If ucrChkIncludeHeader.Checked Then
            clsBaseOperator.AddParameter(strParameterName:="tab_header_funct_param", clsRFunctionParameter:=clsHeaderRFunction, iPosition:=2, bIncludeArgumentName:=False)
        Else
            clsBaseOperator.RemoveParameterByName("tab_header_funct_param")
        End If
    End Sub

    Private Sub ucrInputHeaderTitle_ControlContentsChanged(ucrChangedControl As ucrCore)
        ' Raise footer control value changed event to remove the footer parameter
        ucrInputHeaderTitleFooter.OnControlValueChanged()
        ucrInputHeaderTitleNSubtitleFooter.OnControlValueChanged()

        updateHeaderFooterControlsVisibility()
    End Sub

    Private Sub ucrInputHeaderTitleFooter_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputHeaderTitleFooter.ControlValueChanged
        If ucrInputHeaderTitle.IsEmpty() OrElse ucrInputHeaderTitleFooter.IsEmpty() Then
            clsBaseOperator.RemoveParameterByName("tab_footnote_title_param")
        Else
            clsBaseOperator.AddParameter("tab_footnote_title_param", clsRFunctionParameter:=GetNewFooterRFunction(clsTitleFooterRFunction, {"title"}), iPosition:=3)
        End If
    End Sub

    Private Sub btnHeaderTitleFormat_Click(sender As Object, e As EventArgs)
        clsTablesUtils.ShowTextFormSubDialog(Me.ParentForm, clsTitleRFunction)
    End Sub

    Private Sub btnHeaderTitleFooterFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderTitleFooterFormat.Click
        clsTablesUtils.ShowTextFormSubDialog(Me.ParentForm, clsTitleFooterRFunction)
    End Sub

    Private Sub ucrInputHeaderSubtitle_ControlContentsChanged(ucrChangedControl As ucrCore)
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

    Private Sub btnHeaderSubTitleFormat_Click(sender As Object, e As EventArgs)
        clsTablesUtils.ShowTextFormSubDialog(Me.ParentForm, clsSubtitleRFunction)
    End Sub

    Private Sub btnHeaderSubtitleFooterFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderSubtitleFooterFormat.Click
        clsTablesUtils.ShowTextFormSubDialog(Me.ParentForm, clsSubtitleFooterRFunction)
    End Sub

    Private Sub ucrInputHeaderTitleNSubtitleFooter_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrInputHeaderTitleNSubtitleFooter.ControlValueChanged
        If ucrInputHeaderTitle.IsEmpty() OrElse ucrInputHeaderSubtitle.IsEmpty() OrElse ucrInputHeaderTitleNSubtitleFooter.IsEmpty() Then
            clsHeaderRFunction.RemoveParameterByName("tab_footnote_titleNsubtitle_param")
        Else
            clsBaseOperator.AddParameter("tab_footnote_titleNsubtitle_param", clsRFunctionParameter:=GetNewFooterRFunction(clsTitleNSubtitleFooterRFunction, {"title", "subtitle"}), iPosition:=5)
        End If
    End Sub

    Private Sub btnHeaderTitleNSubtitleFooterFormat_Click(sender As Object, e As EventArgs) Handles btnHeaderTitleNSubtitleFooterFormat.Click
        clsTablesUtils.ShowTextFormSubDialog(Me.ParentForm, clsTitleNSubtitleFooterRFunction)
    End Sub

    Private bFirstload As Boolean = True
    Private Sub ucrHeaders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstload Then
            initialiseControl()
            bFirstload = False
        End If
    End Sub

    Private Sub initialiseControl()

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

    End Sub




    Public Sub SetUpControl(clsOperator As ROperator)

        Dim lstRFunctions As List(Of RFunction) = clsTablesUtils.FindRFunctionsWithRCommand("tab_footnote", clsOperator)

        For Each clsFootNoteRFUnction As RFunction In lstRFunctions
            For Each clsFootNoteRParam As RParameter In clsFootNoteRFUnction.clsParameters
                If clsFootNoteRParam.strArgumentName = "footnote" Then

                ElseIf clsFootNoteRParam.strArgumentName = "locations" Then
                    Dim clsFooterLocationNoteRFunction As RFunction = clsFootNoteRParam.clsArgumentCodeStructure
                    If clsFooterLocationNoteRFunction.strRCommand = "cells_title" Then
                        Dim clsRParam As RParameter = clsFooterLocationNoteRFunction.GetParameter("groups")
                        If clsRParam IsNot Nothing AndAlso clsRParam.strArgumentValue = "title" Then

                        End If



                    End If

                    End If

            Next
        Next

        For Each clsRParam As RParameter In clsOperator.clsParameters
            If clsRParam.bIsFunction AndAlso clsRParam.HasValue() Then
                Dim clsFootNoteRFUnction As RFunction = clsRParam.clsArgumentCodeStructure
                If clsFootNoteRFUnction.strRCommand = "tab_footnote" Then

                End If

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

                        If clsFooterLocationNoteRFunction.strRCommand = "cells_body" Then
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



        clsSubtitleRFunction = New RFunction
        clsSubtitleFooterRFunction = New RFunction


        Dim lstRFunctions As List(Of RFunction) = FindRFunctionsWithRcommandContainingParam("cells_title", "groups", clsOperator.clsParameters)
        For Each clsRFunct As RFunction In lstRFunctions
            Dim clsGroupParam As RParameter = clsRFunct.GetParameter("groups")

            If "title" = clsGroupParam.strArgumentValue Then
            ElseIf "subttle" = clsGroupParam.strArgumentValue Then

            End If

        Next

        Dim lstFootNoteRFunctions As List(Of RFunction) = FindRFunctionsWithRcommandContainingParam("tab_footnote", "locations", clsOperator.clsParameters)
        Dim lstHeaderFootNoteRFunctions As List(Of RFunction) = FindRFunctionsContainingParamRCommand("cells_title", lstFootNoteRFunctions)


        ucrChkIncludeHeader.Checked = False
        updateHeaderFooterControlsVisibility()

        clsHeaderRFunction.SetPackageName("gt")
        clsHeaderRFunction.SetRCommand("tab_header")

        ' Title related R functions
        clsTitleRFunction = clsTablesUtils.GetNewHtmlSpanRFunction()
        clsHeaderRFunction.AddParameter("title",
                                        clsRFunctionParameter:=clsTitleRFunction,
                                        iPosition:=0)  ' Title parameter is always required so add it to the header function by default
        clsTitleFooterRFunction = clsTablesUtils.GetNewHtmlSpanRFunction()

        ' Subtitle related R functions
        clsSubtitleRFunction = clsTablesUtils.GetNewHtmlSpanRFunction()
        clsSubtitleFooterRFunction = clsTablesUtils.GetNewHtmlSpanRFunction()

        ' Title and Subtitle footer related R functions
        clsTitleNSubtitleFooterRFunction = clsTablesUtils.GetNewHtmlSpanRFunction()

    End Sub


    Private Function FindRFunctionsWithRcommandContainingParam(strRCommandName As String, strRParamName As String, lstParameters As IEnumerable(Of RParameter)) As List(Of RFunction)
        Dim lstRFunctions As New List(Of RFunction)
        For Each clsRParam As RParameter In lstParameters
            If clsRParam.bIsFunction AndAlso clsRParam.HasValue() Then
                Dim rFunction As RFunction = clsRParam.clsArgumentCodeStructure
                If rFunction.strRCommand = strRCommandName AndAlso rFunction.ContainsParameter(strRParamName) Then
                    lstRFunctions.Add(rFunction)
                Else
                    lstRFunctions.AddRange(FindRFunctionsWithRcommandContainingParam(strRCommandName, strRParamName, rFunction.clsParameters))
                End If
            End If
        Next
        Return lstRFunctions
    End Function

    Private Function FindRFunctionsContainingParamRCommand(strRCommandName As String, lstCheckRFunctions As IEnumerable(Of RFunction)) As List(Of RFunction)
        Dim lstRFunctions As New List(Of RFunction)
        For Each clsRFunct As RFunction In lstCheckRFunctions

            For Each clsRParam As RParameter In clsRFunct.clsParameters
                If clsRParam.bIsFunction AndAlso clsRParam.HasValue() Then
                    If DirectCast(clsRParam.clsArgumentCodeStructure, RFunction).strRCommand = strRCommandName Then
                        lstRFunctions.Add(clsRFunct)
                    Else
                        lstRFunctions.AddRange(FindRFunctionsContainingParamRCommand(strRCommandName, {clsRFunct}))
                    End If


                    Exit For
                End If

            Next
        Next

        Return lstRFunctions
    End Function

    Private Function FindRFunctions(strRCommandName As String, lstCheckRFunctions As List(Of RFunction)) As List(Of RFunction)
        Dim lstRFunctions As New List(Of RFunction)
        For Each clsRFunct As RFunction In lstCheckRFunctions
            If clsRFunct.strRCommand = strRCommandName Then
                lstRFunctions.Add(clsRFunct)
            End If
        Next
        Return lstRFunctions
    End Function

    Public Sub SetRCodeForControls(clsBaseOperator As ROperator, bReset As Boolean)


        ucrChkIncludeHeader.SetRCode(clsBaseOperator, bReset)
        ucrInputHeaderTitle.SetRCode(clsTitleRFunction, bReset)
        ucrInputHeaderTitleFooter.SetRCode(clsTitleFooterRFunction, bReset)
        ucrInputHeaderSubtitle.SetRCode(clsSubtitleRFunction, bReset)
        ucrInputHeaderSubtitleFooter.SetRCode(clsSubtitleFooterRFunction, bReset)
        ucrInputHeaderTitleNSubtitleFooter.SetRCode(clsTitleNSubtitleFooterRFunction, bReset)


    End Sub

    Private Sub updateHeaderFooterControlsVisibility()
        ucrInputHeaderTitleFooter.Visible = Not ucrInputHeaderTitle.IsEmpty()
        ucrInputHeaderSubtitleFooter.Visible = Not ucrInputHeaderSubtitle.IsEmpty()
        ucrInputHeaderTitleNSubtitleFooter.Visible = Not ucrInputHeaderSubtitle.IsEmpty() AndAlso Not ucrInputHeaderSubtitle.IsEmpty()
    End Sub
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



End Class
