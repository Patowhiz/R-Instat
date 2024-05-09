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

Imports instat.Translations
Public Class dlgGeneralTable
    Private clsOperator As ROperator
    Private clsHeaderRFunction, clsTitleRFunction, clsSubtitleRFunction As RFunction

    Private clsThemeRFunction As RFunction

    Private bFirstload As Boolean = True
    Private bReset As Boolean = True

    Private Sub dlgGeneralTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            initialiseDialog()
            SetDefaults()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
    End Sub

    Private Sub initialiseDialog()
        ucrChkIncludeHeader.SetText("Include Header")
        ucrChkIncludeHeader.AddParameterPresentCondition(True, "tab_header", True)
        ucrChkIncludeHeader.AddParameterPresentCondition(False, "tab_header", False)

        ucrChkIncludeHeader.AddToLinkedControls(ucrInputHeaderTitle, {True}, bNewLinkedHideIfParameterMissing:=True)
        ucrChkIncludeHeader.AddToLinkedControls(ucrInputHeaderTitleFooter, {True}, bNewLinkedHideIfParameterMissing:=True)
        ucrChkIncludeHeader.AddToLinkedControls(ucrInputHeaderSubtitle, {True}, bNewLinkedHideIfParameterMissing:=True)
        ucrChkIncludeHeader.AddToLinkedControls(ucrInputHeaderSubtitleFooter, {True}, bNewLinkedHideIfParameterMissing:=True)

        ucrInputHeaderTitle.SetParameter(New RParameter("title", 0))
        ucrInputHeaderTitle.SetLinkedDisplayControl(New List(Of Control)({lblHeaderTitle, btnHeaderTitleFormat}))

        ucrInputHeaderSubtitle.SetParameter(New RParameter("subtitle", 0))
        ucrInputHeaderSubtitle.SetLinkedDisplayControl(New List(Of Control)({lblHeaderSubtitle, btnHeaderSubTitleFormat}))


        ucrPnlThemesPanel.AddRadioButton(rdoSelectTheme)
        ucrPnlThemesPanel.AddRadioButton(rdoManualTheme)

        ucrCboSelectThemes.SetItems({"None", "Dark Theme", "538 Theme", "Dot Matrix Theme", "Espn Theme", "Excel Theme", "Guardian Theme", "NY Times Theme", "PFF Theme"})
        ucrCboSelectThemes.SetDropDownStyleAsNonEditable()
    End Sub

    Private Sub SetDefaults()
        clsOperator = New ROperator
        clsTitleRFunction = New RFunction
        clsSubtitleRFunction = New RFunction
        clsThemeRFunction = New RFunction

        clsHeaderRFunction.SetPackageName("gt")
        clsHeaderRFunction.SetRCommand("tab_header")

        clsTitleRFunction = GetNewHtmlDivRFunction()
        clsTitleRFunction.AddParameter(strParameterValue:=Chr(34) & "" & Chr(34), iPosition:=0)
        clsHeaderRFunction.AddParameter("title", clsRFunctionParameter:=clsTitleRFunction)

        clsTitleRFunction = GetNewHtmlDivRFunction()
        clsTitleRFunction.AddParameter(strParameterValue:=Chr(34) & "" & Chr(34), iPosition:=0)
        clsHeaderRFunction.AddParameter("title", clsRFunctionParameter:=clsTitleRFunction)

        ucrBase.clsRsyntax.SetBaseROperator(clsOperator)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrChkIncludeHeader.SetRCode(clsOperator, bReset)
        ucrInputHeaderTitle.SetRCode(clsTitleRFunction, bReset)
        ucrInputHeaderSubtitle.SetRCode(clsSubtitleRFunction, bReset)


    End Sub

    Private Sub ucrChkIncludeHeader_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkIncludeHeader.ControlValueChanged

    End Sub

    Private Sub ucrInputHeaderTitle_ControlValueChanged(ucrChangedControl As ucrCore)

        ' Use existing header function it's in the operator,
        ' if it's not in the operator create one and add it to the operator.
        Dim clsHeaderRFunction As RFunction

        If clsOperator.ContainsParameter("tab_header") Then
            clsHeaderRFunction = clsOperator.GetParameter("tab_header").clsArgumentCodeStructure
        Else
            ' Create new header function
            clsHeaderRFunction = New RFunction
            clsHeaderRFunction.SetPackageName("gt")
            clsHeaderRFunction.SetRCommand("tab_header")
            ' add the header function into the operator
            clsOperator.AddParameter("tab_header", clsRFunctionParameter:=clsHeaderRFunction, bIncludeArgumentName:=False)
        End If

        If clsHeaderRFunction.ContainsParameter("title") Then
            clsTitleRFunction = clsHeaderRFunction.GetParameter("title").clsArgumentCodeStructure
        Else
            ' create new title function and add it to into the header function
            clsTitleRFunction = GetNewHtmlDivRFunction()
            clsTitleRFunction.AddParameter(strParameterValue:=Chr(34) & "" & Chr(34), iPosition:=0)
            clsTitleRFunction.AddParameter(strParameterName:="style", clsRFunctionParameter:=GetNewStyleRFunction(), iPosition:=1)

            ' Add the title function as the paramter value of header function
            clsHeaderRFunction.AddParameter("title", clsRFunctionParameter:=clsTitleRFunction)

        End If

        If clsHeaderRFunction.ContainsParameter("subtitle") Then
            clsSubtitleRFunction = clsHeaderRFunction.GetParameter("subtitle").clsArgumentCodeStructure
        Else
            ' Create new sub title function and add it to into the header function
            clsSubtitleRFunction = GetNewHtmlDivRFunction()
            clsSubtitleRFunction.AddParameter(strParameterValue:=Chr(34) & "" & Chr(34), iPosition:=0)
            clsSubtitleRFunction.AddParameter(strParameterName:="style", clsRFunctionParameter:=GetNewStyleRFunction(), iPosition:=1)

            ' Add the subtitle function as the paramter value of header function
            clsHeaderRFunction.AddParameter("subtitle", clsRFunctionParameter:=clsSubtitleRFunction)

        End If

        ' set the header controls values
        'ucrInputHeaderTitle.SetName(GetStringValue(clsTitleRFunction.clsParameters(0).strArgumentValue, False))
        'ucrInputHeaderSubtitle.SetName(GetStringValue(clsSubtitleRFunction.clsParameters(0).strArgumentValue, False))
    End Sub

    Private Function GetNewHtmlDivRFunction() As RFunction
        Dim clsHtmlDivRFunction As New RFunction
        clsHtmlDivRFunction.SetPackageName("htmltools")
        clsHtmlDivRFunction.SetRCommand("tags$span")
        Return clsHtmlDivRFunction
    End Function

    Private Function GetNewStyleRFunction() As RFunction
        Dim clsStyleRFunction As New RFunction
        clsStyleRFunction.SetPackageName("htmltools")
        clsStyleRFunction.SetRCommand("css")
        Return clsStyleRFunction
    End Function

End Class