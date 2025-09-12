Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Office.Core
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Media
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class FVS_RunModelMulti
    Private MultirunPanel As TableLayoutPanel 'creating outside of Subs so that it can be accessed by multiple functions
    Private RunNamesArr(0) As String 'storing runnames for error checking
    Private RunPossible As Boolean = True ' to prevent model running if any selected run is missing from database
    Private NumRepeats As Integer = 1

    'Dim SelectedRuns As List(Of String)

    Private Sub FVS_ModelRunMulti_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'UseTAMMFlag = 0
        Dim cmd1 As New OleDb.OleDbCommand()

        CurrentStepLabel.Visible = False
        EstimatedRunTimeLabel.Visible = False
        BatchProgressBar.Visible = False
        RunInfoNumLabel.Visible = False
        RunInfoTimeLabel.Visible = False
        ReturnButton.Visible = False




        If FVSdatabasename.Length > 50 Then
            DatabaseNameLabel.Text = FVSshortname
        Else
            DatabaseNameLabel.Text = FVSdatabasename
        End If

        TAMMSpreadSheet = ""



        ' Handle blocking off checklists based on species
        If SpeciesName = "COHO" Then
            ChinookBYCheck.Visible = False
            ChinookBYCheck.Enabled = False
            OldTammCheck.Visible = False
            OldTammCheck.Enabled = False
            TammFwsCheck.Visible = False
            ChinookSizeLimitCheck.Visible = False

            ChinookSizeLimitCheck.Visible = False
            TammFwsCheck.Enabled = False
            MSFBiasCorrectionCheckBox.Visible = True
            MSFBiasCorrectionCheckBox.Enabled = True
            'MSFBiasCorrectionCheckBox.Checked = True
            OldCohort.Visible = False
            OldCohort.Enabled = False
            chkCoastalIterations.Visible = True
            chkTS4.Visible = False
            chkTS4.Enabled = False
            'MSFBiasFlag = True
            'GetBP.Visible = False

        ElseIf SpeciesName = "CHINOOK" Then
            ChinookBYCheck.Visible = True
            ChinookBYCheck.Enabled = True
            OldTammCheck.Visible = True
            OldTammCheck.Enabled = True
            ChinookSizeLimitCheck.Visible = True
            TammFwsCheck.Visible = True
            TammFwsCheck.Enabled = True
            MSFBiasCorrectionCheckBox.Visible = False
            MSFBiasCorrectionCheckBox.Enabled = False
            OldCohort.Visible = True
            OldCohort.Enabled = True
            chkTS4.Visible = True
            chkTS4.Enabled = True
            MSFBiasFlag = False
            chkCoastalIterations.Visible = False
        End If


    End Sub



    Private Sub SelectRunsManually_Click(sender As Object, e As EventArgs) Handles SelectRunsManually.Click


        RecordsetSelectionType = 99
        Me.Visible = False
        FVS_ModelRunSelection.ShowDialog()
        If RecordsetSelectionType = 9 Then
            MsgBox("Multi-Run selection Cancelled", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If RunIDMultirun.Length > 0 Then

            'populate TAMM list
            ReDim TAMMsMultirun(NumMultirunID - 1)
            ReDim TAMMsMultirunPaths(NumMultirunID - 1)
            For i As Integer = 0 To TAMMsMultirun.Length - 1
                TAMMsMultirun(i) = "none"
                TAMMsMultirunPaths(i) = "none"
            Next

            PopulatePanel(True)
        End If
        Me.Refresh()
    End Sub

    Private Sub PopulatePanel(ShowButtons As Boolean)
        'Handling panel stuff
        Dim MissingRun As Boolean = False

        If MultirunPanel IsNot Nothing Then
            Me.Controls.Remove(MultirunPanel)
            MultirunPanel.Dispose()
        End If

        MultirunPanel = New TableLayoutPanel()
        'layout stuff to support scrolling
        MultirunPanel.AutoSize = True
        MultirunPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MultirunPanel.Dock = DockStyle.Top ' Or None, depending on layout
        ' rows and cols
        MultirunPanel.ColumnCount = 5
        MultirunPanel.RowCount = NumMultirunID + 1
        ' relative sizes
        With MultirunPanel.ColumnStyles
            .Clear()
            .Add(New ColumnStyle(SizeType.Percent, 10))  ' RunID only needs a little space
            .Add(New ColumnStyle(SizeType.Percent, 30))  ' Run Name needs more space
            .Add(New ColumnStyle(SizeType.Percent, 30))  ' Tamm File needs more space
            .Add(New ColumnStyle(SizeType.Percent, 15))  ' Button column
            .Add(New ColumnStyle(SizeType.Percent, 15))  ' button column
        End With


        '   Adding headers
        Dim headers() As String = {"Run ID", "Run Name", "TAMM File", "Add TAMM", "Remove TAMM"}
        For col As Integer = 0 To headers.Length - 1
            Dim headerLabel As New Windows.Forms.Label()
            With headerLabel
                .Text = headers(col)
                .Dock = DockStyle.Fill
                .TextAlign = ContentAlignment.MiddleLeft
                .Font = New Font("Arial", 11, FontStyle.Bold)
                .Padding = New Padding(5)
                .Height = 50
            End With
            MultirunPanel.Controls.Add(headerLabel, col, 0)

        Next

        Panel1.Controls.Add(MultirunPanel)

        ' Populating panel
        Dim FramDB As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FVSdatabasename)
        FramDB.Open()

        ReDim RunIDNameMultirun(NumMultirunID - 1)

        For i As Integer = 1 To NumMultirunID
            'reminder that indexing starts at 0!!
            Dim drd1 As OleDb.OleDbDataReader ' for getting run names
            Dim cmd1 As New OleDb.OleDbCommand() ' for getting run names

            'Add runID
            Dim RunIDLab As New Windows.Forms.Label()
            With RunIDLab
                .Text = RunIDMultirun(i - 1)
                .TextAlign = ContentAlignment.MiddleCenter
            End With
            MultirunPanel.Controls.Add(RunIDLab, 0, i)

            'add run name
            Dim RunNameLab As New Windows.Forms.Label()
            With RunNameLab
                .Text = "-"
                .TextAlign = ContentAlignment.MiddleLeft
            End With
            cmd1.Connection = FramDB
            cmd1.CommandText = "SELECT RunName FROM RunID WHERE RunID = " & RunIDMultirun(i - 1)
            drd1 = cmd1.ExecuteReader
            While drd1.Read
                RunNameLab.Text = Convert.ToString(drd1(0))
            End While
            If RunNameLab.Text = "-" Then
                MissingRun = True
            End If
            RunIDNameMultirun(i - 1) = RunNameLab.Text

            MultirunPanel.Controls.Add(RunNameLab, 1, i)

            'populate TAMM names

            Dim TammLab As New Windows.Forms.Label()
            With TammLab
                .Text = TAMMsMultirun(i - 1)
                .TextAlign = ContentAlignment.MiddleLeft
            End With
            MultirunPanel.Controls.Add(TammLab, 2, i)

            'add TAMM button
            Dim btn As New Windows.Forms.Button()
            btn.Text = "Add TAMM"
            btn.Width = 150
            btn.Top = (i) * 50

            btn.Name = "Button" & i.ToString()
            btn.Tag = i ' Useful for identifying which button was clicked
            ' Add event handler
            AddHandler btn.Click, AddressOf DynamicButton_Click

            'Hide button if toggled off, for reading by folder
            If ShowButtons <> True Then
                btn.Visible = False
            End If

            MultirunPanel.Controls.Add(btn)
            MultirunPanel.SetCellPosition(btn, New TableLayoutPanelCellPosition(3, i))
            'MultirunPanel.Controls.Add(btn)

            'add TAMM removal button
            Dim btnRemove As New Windows.Forms.Button()
            btnRemove.Text = "No TAMM"
            btnRemove.Width = 150
            btnRemove.Top = (i) * 50

            btnRemove.Name = "Button" & i.ToString()
            btnRemove.Tag = i + NumMultirunID
            ' Useful for identifying which button was clicked
            ' Add event handler
            AddHandler btnRemove.Click, AddressOf DynamicButton_Click

            'Hide buttons if toggled off, for reading by folder
            If ShowButtons <> True Then
                btnRemove.Visible = False
            End If

            MultirunPanel.Controls.Add(btnRemove)
            MultirunPanel.SetCellPosition(btnRemove, New TableLayoutPanelCellPosition(4, i))
            'MultirunPanel.Controls.Add(btn)
        Next
        FramDB.Close()

        If MissingRun Then
            MsgBox("One or more TAMMs identify a run not present in this database. Check TAMM filenames or database choice. Table populated")
            RunPossible = False
        Else
            RunPossible = True
        End If
        RunAllButton.Visible = RunPossible


    End Sub

    Private Sub DynamicButton_Click(sender As Object, e As EventArgs)
        Dim i As New Integer
        Dim RemovalFlag As New Boolean

        Dim clickedButton As Windows.Forms.Button = DirectCast(sender, Windows.Forms.Button)

        'Challenge: buttons can only have 1 tag, so having two columns of buttons is annoying. 
        ' I went with defining all the TAMM buttons as i, and then all the tamm removal buttons as i + NumMultirunID
        '  NOTE!!! The tags start at 1! Not 0!
        'For simplicity, parse out the scenarios: convert 
        If clickedButton.Tag < 1 + NumMultirunID Then
            RemovalFlag = False
            i = clickedButton.Tag
        Else
            RemovalFlag = True
            i = clickedButton.Tag - NumMultirunID
        End If



        'TAMM buttons: TAMM to change is TAMMsMultirun(i-1)

        If RemovalFlag = False Then



            Dim OpenTAMMspreadsheet As New OpenFileDialog()

            TAMMSpreadSheet = ""
            OpenTAMMspreadsheet.Filter = "TAMM Spreadsheets (*.xls*)|*.xls*|All files (*.*)|*.*"
            OpenTAMMspreadsheet.FilterIndex = 1
            OpenTAMMspreadsheet.RestoreDirectory = True

            If OpenTAMMspreadsheet.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    TAMMSpreadSheet = OpenTAMMspreadsheet.FileName
                    TAMMSpreadSheetPath = My.Computer.FileSystem.GetFileInfo(TAMMSpreadSheet).DirectoryName
                Catch Ex As Exception
                    MessageBox.Show("Cannot read file selected. Original error: " & Ex.Message)
                End Try
            End If

            If TAMMSpreadSheet = "" Then Exit Sub

            TAMMsMultirun(i - 1) = My.Computer.FileSystem.GetFileInfo(TAMMSpreadSheet).Name
            TAMMsMultirunPaths(i - 1) = TAMMSpreadSheetPath

            'TammNameLabel.Text = TAMMSpreadSheetName

        Else
            'Remove TAMM buttons: TAMM to change is TAMMsMultirun(i-1-NumMultirunID)
            TAMMsMultirun(i - 1) = "none"
            TAMMsMultirunPaths(i - 1) = "none"
        End If

        'Either way, update tamm label
        Dim TammLab As New Windows.Forms.Label()
        With TammLab
            .Text = TAMMsMultirun(i - 1)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        ReplaceCellContent(2, i, TammLab)
    End Sub

    'helper for replacing content of the layout panel
    Private Sub ReplaceCellContent(col As Integer, row As Integer, newControl As Control)
        ' Check if a control already exists in the cell
        For Each ctrl As Control In MultirunPanel.Controls
            Dim cellRow As Integer = MultirunPanel.GetRow(ctrl)
            Dim cellCol As Integer = MultirunPanel.GetColumn(ctrl)

            If cellRow = row AndAlso cellCol = col Then
                MultirunPanel.Controls.Remove(ctrl)
                Exit For
            End If
        Next

        ' Add the new control to the specified cell
        MultirunPanel.Controls.Add(newControl, col, row)
    End Sub

    Dim OpenTAMMFolder As New FolderBrowserDialog()

    Private Sub SelectionGuiButton_Click(sender As Object, e As EventArgs) Handles SelectionGuiButton.Click

        'track what was used last
        If TammFolderTextbox.Text <> "" Then
            OpenTAMMFolder.SelectedPath = TammFolderTextbox.Text
        End If

        If OpenTAMMFolder.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TammFolderTextbox.Text = OpenTAMMFolder.SelectedPath
        End If

    End Sub

    Private Sub SelectRunsFromFolderButton_Click(sender As Object, e As EventArgs) Handles SelectRunsFromFolderButton.Click

        If Directory.Exists(TammFolderTextbox.Text) Then 'is directory

            Dim TempTammFiles() As String = Directory.GetFiles(TammFolderTextbox.Text, "*.xlsx")
            'Populate # of runs, TAMM info
            NumMultirunID = TempTammFiles.Length


            'TAMMsMultirun = TempTammFiles.Select(Function(path) path.GetFileName(path)).ToArray()

            ReDim TAMMsMultirun(NumMultirunID - 1)
            For k As Integer = 0 To (NumMultirunID - 1)
                TAMMsMultirun(k) = Path.GetFileName(TempTammFiles(k))
            Next

            'TAMMsMultirun = TempTammFiles

            'all tamms have the same path
            ReDim TAMMsMultirunPaths(NumMultirunID - 1)
            For k As Integer = 0 To (NumMultirunID - 1)
                TAMMsMultirunPaths(k) = TammFolderTextbox.Text
            Next

            'extract RunIDs from the TAMM names

            Dim pattern As String = "-(\d+)\.xlsx$"
            Dim regex As New Regex(pattern)

            ReDim RunIDMultirun(NumMultirunID - 1)
            Dim j As Integer = 0
            For Each fileName As String In TAMMsMultirun
                Dim match As Match = regex.Match(fileName)
                If match.Success Then
                    RunIDMultirun(j) = match.Groups(1).Value
                Else
                    MessageBox.Show("One or more excel files in this folder do not match necessary pattery. Files should end in '-{RUNID}.xlsx', as in 'Chin-sensitivity-38.xlsx' for run 38. Resolve and try again.")
                    ' resetting things we changed, just to play it safe
                    NumMultirunID = 0
                    ReDim TAMMsMultirun(NumMultirunID)
                    ReDim TAMMsMultirunPaths(NumMultirunID)
                    Exit Sub
                End If
                j = j + 1
            Next
            PopulatePanel(False)
        Else
            MsgBox("Not a valid directory. Update textbox manually or use the GUI selection button.")
        End If
    End Sub


    ' Checkbox handling -----------------------------------------------------------------------

    Private Sub chkCoastalIterations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCoastalIterations.CheckedChanged
        If chkCoastalIterations.Checked = True Then
            CoastalIterations = True
            ReDim FisheryQuotaCompare(NumFish, NumSteps)
        Else
            CoastalIterations = False
        End If
    End Sub
    Private Sub OldTammCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OldTammCheck.CheckedChanged
        If OldTammCheck.Checked = True Then
            OptionOldTAMMformat = True
        Else
            OptionOldTAMMformat = False
        End If
    End Sub
    Private Sub TammFwsCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TammFwsCheck.CheckedChanged
        If TammFwsCheck.Checked = True Then
            OptionUseTAMMfws = True
        Else
            OptionUseTAMMfws = False
        End If
    End Sub

    Private Sub MSFBiasCorrectionCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSFBiasCorrectionCheckBox.CheckedChanged
        If MSFBiasCorrectionCheckBox.Checked = True Then
            MSFBiasFlag = False
        Else
            MSFBiasFlag = True
        End If
    End Sub

    Private Sub ChinookBYCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChinookBYCheck.CheckedChanged
        If ChinookBYCheck.Checked = True Then
            OptionChinookBYAEQ = 1
        Else
            OptionChinookBYAEQ = 0
        End If
    End Sub
    Private Sub ChinookSizeLimitCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChinookSizeLimitCheck.CheckedChanged
        If ChinookSizeLimitCheck.Checked = True Then
            SizeLimitFix = False
        Else
            SizeLimitFix = True
        End If
    End Sub

    Private Sub OldCohort_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OldCohort.CheckedChanged
        'will not place time 1 cohort into time 4 for stocks with a missing abundance of age-1 - time 4 age will be zero

        If OldCohort.Checked = True Then
            T4CohortFlag = True
        Else
            T4CohortFlag = False
        End If
    End Sub

    Private Sub chkTS4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTS4.CheckedChanged
        'when T4CohortFlag2 = True then time 1 cohort will not be recycled in time 4 (for stocks missing age-1 abundance) when age 5 = 0
        If chkTS4.Checked = True Then
            T4CohortFlag2 = True
        Else
            T4CohortFlag2 = False
        End If
    End Sub

    Private Sub RepeatEachRunInput_ValueChanged(sender As Object, e As EventArgs) Handles RepeatEachRunInput.ValueChanged
        Dim control As NumericUpDown = DirectCast(sender, NumericUpDown)
        NumRepeats = CInt(control.Value)
    End Sub


    Private Sub RunAllButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RunAllButton.Click

        Dim result

        CurrentStepLabel.Visible = True
        EstimatedRunTimeLabel.Visible = True
        BatchProgressBar.Visible = True


        result = MsgBox("For ALL runs: Do You Want to SAVE TAMM Tranfer Values into TAMM SpreadSheet?", MsgBoxStyle.YesNo)
        If result = vbYes Then
            TammTransferSave = True
        Else
            TammTransferSave = False
        End If

        Dim startTime = DateTime.Now


        Dim totalIterations = NumMultirunID * NumRepeats
        BatchProgressBar.Maximum = totalIterations
        BatchProgressBar.Value = 0

        'Update labels with batch run info

        RunInfoNumLabel.Text = "Total of " & totalIterations & " runs (" & NumMultirunID & " RunIDs x " & NumRepeats & " each)"
        RunInfoNumLabel.Visible = True
        RunInfoTimeLabel.Text = "Started at " & DateTime.Now.ToString("HH:mm:ss")
        RunInfoTimeLabel.Visible = True




        For iRun As Integer = 0 To NumMultirunID - 1

            'Handle setting run-specific info: runID, TAMM if present.
            If TAMMsMultirun(iRun) = "none" Then
                TAMMSpreadSheet = ""
            Else
                TAMMSpreadSheet = TAMMsMultirunPaths(iRun) & "\" & TAMMsMultirun(iRun)
                'replace placeholder if needed.
            End If
            'Normal TAMM processing:
            If TAMMSpreadSheet <> "" Then
                TAMMName = My.Computer.FileSystem.GetFileInfo(TAMMSpreadSheet).Name
            Else
                TAMMName = ""
            End If

            RunIDSelect = RunIDMultirun(iRun)
            RunIDNameSelect = RunIDNameMultirun(iRun)


            For iRepeat As Integer = 1 To NumRepeats

                CurrentStepLabel.Text = "Run " & iRun + 1 & " of " & NumMultirunID & ": " & RunIDNameSelect & " (RunID " & RunIDSelect & ") - Repeat " & iRepeat & " Of " & NumRepeats
                Me.Refresh()

                'PPPPPP------------------------------------------------------------------------------------------------------------
                '- Pete 12/13 Code for Executing an integrated update system for external S:L Ratio based EncounterRateAdjustments
                '- Outer flank to original RunModelButtonClick code...

                FinalUpdatePass = False 'This should always be false unless set to true during S:L Ratio Update
                Dim iters As Integer = 1
                Dim c As Integer = 1 'Allows RunModelButton_Click to execute as normal (for coho or non-update Chinook runs)




                FRAMVers = FramVersion



                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                If SizeLimitFix = True Then
                    'automatically updates Sublegal/Legal ratios (make sure table SLRatio table in FRAMDb is updated) and then performs
                    'size limit corrected algorithms to deal with size limit changes (make sure SizeLimit table is up to date)
                    'This is done in 5 steps
                    '1. Set size limit to base period (or original pre-change) size limit
                    '2. Run calculations to update Sublegal/legal ratios
                    '3. Re-set size limits to new size limits
                    '4. Run FRAM with size limit corrected algorithms 

                    ReDim NewSizeLimit(NumFish + 1, NumSteps + 1)

                    If RunIDNameSelect.Substring(0, 4) <> "SLC-" Then
                        RunIDNameSelect = "SLC-" & RunIDNameSelect
                    End If



                    SizeLimitFix = False 'first set to false to not trigger size limit calcualtions before sublegal/legal ratios are updated

                    'first save new size limits
                    For Fish As Integer = 1 To NumFish
                        For TStep As Integer = 1 To NumSteps
                            NewSizeLimit(Fish, TStep) = MinSizeLimit(Fish, TStep)
                        Next
                    Next



                    'STEP 1: Sets size limit to base period size limit
                    For Fish As Integer = 1 To NumFish
                        For TStep As Integer = 1 To NumSteps
                            MinSizeLimit(Fish, TStep) = ChinookBaseSizeLimit(Fish, TStep)
                        Next
                    Next

                    'STEP 2: S:L Update Run
                    'Does not ask to load in from spreadsheet

                    UpdateRunEncounterRateAdjustment = True
                    WhoUpdated = Environment.UserName


                    If UpdateRunEncounterRateAdjustment = True Then
                        'set limit on outer loop iterations (3 is plenty for convergence, but we'll do 4 to be overachievers)
                        iters = 4
                    End If

                    Do While c <= iters

                        '- Set Chinook Tamm Run Option
                        TammChinookRunFlag = 0

                        If OptionOldTAMMformat = True And OptionUseTAMMfws = False Then
                            TammChinookRunFlag = 1
                        ElseIf OptionOldTAMMformat = False And OptionUseTAMMfws = True Then
                            TammChinookRunFlag = 2
                        ElseIf OptionOldTAMMformat = True And OptionUseTAMMfws = True Then
                            TammChinookRunFlag = 3
                        End If

                        FVS_MainMenu.RecordSetNameLabel.Text = RunIDNameSelect


                        '- Check for TAMM Selection
                        If FinalUpdatePass = True Then ' only ask to transfer on the final iteration
                            If TAMMSpreadSheet <> "" Then
                                RunTAMMIter = 1
                            End If
                        End If
                        ' MRProgressBar.Visible = True

                        '****************End PETE-2/27/13-Code for adding Delineation to Model Run Name if Bias Correction Is Applied

                        Call RunCalcs()


                        'PPPPPP------------------------------------------------------------------------------------------------------------
                        '- Closing flank of Pete 12/13 SL Ratio Code 
                        If UpdateRunEncounterRateAdjustment = True And c < iters Then 'don't enter ExternalSubCalcs on last pass
                            ' RunProgressLabel.Text = " Loading Kfat For SLratio update pass #" & c & " ..."
                            ' RunProgressLabel.Refresh()
                            Call ExternalSubCalcs(c, iters)
                        End If
                        c = c + 1
                    Loop

                    '- Set the UpdateRunEncounterRateAdjustment back to False
                    '(should always be false except when set to true during update runs)
                    UpdateRunEncounterRateAdjustment = False
                    RunTAMMIter = 0 'This Needs to be zero OR things will get goofy on sequential runs.

                    ' STEP 3: Set size limits back to what they're supposed to be
                    For Fish As Integer = 1 To NumFish
                        For TStep As Integer = 1 To NumSteps
                            MinSizeLimit(Fish, TStep) = NewSizeLimit(Fish, TStep)
                        Next
                    Next


                    'STEP 4: Run model with size limit corrected algorithems keeping total encounters constant
                    UpdateRunEncounterRateAdjustment = False
                    RunTAMMIter = 0 'This Needs to be zero OR things will get goofy on sequential runs.

                    SizeLimitFix = True

                    TammChinookRunFlag = 0

                    If OptionOldTAMMformat = True And OptionUseTAMMfws = False Then
                        TammChinookRunFlag = 1
                    ElseIf OptionOldTAMMformat = False And OptionUseTAMMfws = True Then
                        TammChinookRunFlag = 2
                    ElseIf OptionOldTAMMformat = True And OptionUseTAMMfws = True Then
                        TammChinookRunFlag = 3
                    End If

                    FVS_MainMenu.RecordSetNameLabel.Text = RunIDNameSelect

                    'tag111
                    ' - Check for TAMM Selection
                    If TAMMSpreadSheet <> "" Then
                        RunTAMMIter = 1
                    End If
                    '  MRProgressBar.Visible = True
                    FVS_MainMenu.RecordSetNameLabel.Text = RunIDNameSelect
                    '****************End PETE-2/27/13-Code for adding Delineation to Model Run Name if Bias Correction Is Applied

                    Call RunCalcs()



                    SizeLimitFix = False


                    'ChangeAnyInput = True
                    'ChangeFishScalers = True
                    'ChangeNonRetention = True
                    'ChangeSizeLimit = True


                Else 'Auto SizeLimitFix = False @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    ' run without size limit fix or perform Sublegal/Legal ratio update (if selected) without size limit fix

                    If RunIDNameSelect.Substring(0, 4) = "SLC-" Then
                        RunIDNameSelect = RunIDNameSelect.Substring(4, RunIDNameSelect.Length - 4)
                    End If



                    If UpdateRunEncounterRateAdjustment = True Then

                        'set limit on outer loop iterations (3 is plenty for convergence, but we'll do 4 to be overachievers)
                        iters = 4
                    End If

                    Do While c <= iters
                        'PPPPPP--(end of leading Pete 12/13 Block, more at end of loop)-------------------------------------------------


                        '- Set Chinook Tamm Run Option
                        TammChinookRunFlag = 0
                        If SpeciesName = "CHINOOK" Then
                            If OptionOldTAMMformat = True And OptionUseTAMMfws = False Then
                                TammChinookRunFlag = 1
                            ElseIf OptionOldTAMMformat = False And OptionUseTAMMfws = True Then
                                TammChinookRunFlag = 2
                            ElseIf OptionOldTAMMformat = True And OptionUseTAMMfws = True Then
                                TammChinookRunFlag = 3
                            End If
                            'If SizeLimitFix = True Then
                            '    If RunIDNameSelect.Substring(0, 4) <> "SLC-" Then
                            '        RunIDNameSelect = "SLC-" & RunIDNameSelect
                            '    End If
                            'ElseIf SizeLimitFix = False Then
                            '    If RunIDNameSelect.Substring(0, 4) = "SLC-" Then
                            '        RunIDNameSelect = RunIDNameSelect.Substring(4, RunIDNameSelect.Length - 4)
                            '    End If
                            'End If
                            FVS_MainMenu.RecordSetNameLabel.Text = RunIDNameSelect
                        End If

                        '- Check for TAMM Selection
                        If TAMMSpreadSheet <> "" Then
                            RunTAMMIter = 1

                        End If
                        '  MRProgressBar.Visible = True


                        '****************Begin PETE-2/27/13-Code for adding Delineation to Model Run Name if Bias Correction Is Applied
                        If SpeciesName = "COHO" Then
                            If MSFBiasFlag = True Then
                                If RunIDNameSelect.Substring(0, 3) <> "bc-" Then
                                    RunIDNameSelect = "bc-" & RunIDNameSelect
                                End If
                            ElseIf MSFBiasFlag = False Then
                                If RunIDNameSelect.Substring(0, 3) = "bc-" Then
                                    RunIDNameSelect = RunIDNameSelect.Substring(3, RunIDNameSelect.Length - 3)
                                End If
                            End If

                            If CoastalIterations = True Then
                                CoastalIter = "Yes"
                            Else
                                CoastalIter = "No"
                            End If
                        End If



                        FVS_MainMenu.RecordSetNameLabel.Text = RunIDNameSelect
                        '****************End PETE-2/27/13-Code for adding Delineation to Model Run Name if Bias Correction Is Applied


                        Call RunCalcs() 'run with size limit corrected algorithms


                        'PPPPPP------------------------------------------------------------------------------------------------------------
                        '- Closing flank of Pete 12/13 SL Ratio Code 
                        If UpdateRunEncounterRateAdjustment = True And c < iters Then 'don't enter ExternalSubCalcs on last pass
                            'RunProgressLabel.Text = " Loading Kfat For SLratio update pass #" & c & " ..."
                            'RunProgressLabel.Refresh()
                            Call ExternalSubCalcs(c, iters)
                        End If
                        c = c + 1
                    Loop



                End If 'Auto SizeLimitFix = True@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                '- Set the UpdateRunEncounterRateAdjustment back to False
                '(should always be false except when set to true during update runs)
                UpdateRunEncounterRateAdjustment = False
                RunTAMMIter = 0 'This Needs to be zero OR things will get goofy on sequential runs.
                'PPPPPP---(end of closing Pete 12/13 Block)------------------------------------------------------------------------
                If AnyNegativeEscapement = 1 Then
                    If msgFlag = False Then
                        MsgBox("You have negative escapements. Please check the PopStat report!")
                    End If
                End If
                AnyNegativeEscapement = 0

                'provide a warning when a sublegal nonretention input does not result in mortality (due to small size limit in net)

                If SpeciesName = "CHINOOK" Then
                    ReDim FTNonRetention(NumFish, NumSteps)
                    For Fish = 1 To NumFish
                        For TStep = 1 To NumSteps
                            For Stk = 1 To NumStk
                                For Age = 1 To MaxAge
                                    FTNonRetention(Fish, TStep) += NonRetention(Stk, Age, Fish, TStep) / ModelStockProportion(Fish)
                                Next Age
                            Next Stk
                        Next TStep
                    Next Fish
                    For Fish = 1 To NumFish
                        For TStep = 1 To NumSteps
                            If Fish = 2 And TStep = 3 Then
                                Jim = 1
                            End If
                            If NonRetentionFlag(Fish, TStep) = 3 Then
                                If Fish >= 36 And InStr(FisheryTitle(Fish), "Sport") > 0 Then
                                    If FTNonRetention(Fish, TStep) - (NonRetentionInput(Fish, TStep, 1) * ShakerMortRate(Fish, TStep) / 2 + NonRetentionInput(Fish, TStep, 2) * ShakerMortRate(Fish, TStep)) > 1 Then
                                        MsgBox("Sublegal nonretention input For fishery " & Fish & " does Not produce a mortality. Consider modeling fishery As 'Total Encounters'")
                                    End If
                                Else
                                    If Math.Abs(FTNonRetention(Fish, TStep) - (NonRetentionInput(Fish, TStep, 1) * ShakerMortRate(Fish, TStep) + NonRetentionInput(Fish, TStep, 2) * ShakerMortRate(Fish, TStep))) > 1 Then
                                        MsgBox("Sublegal nonretention input for fishery " & Fish & " does not produce a mortality. Consider modeling fishery as 'Total Encounters'")
                                    End If
                                End If
                            End If
                        Next
                    Next
                End If

                ' saving results
                SaveModelRunInputs()

                ' Close out the current TAMM so we can use another one
                ' I DON'T LIKE THIS APPROACH
                ' But the alternative is to modify code elsewhere to enable handling multiple situations (e.g., being able to save and close TAMMs)
                ' It sounds like that is to be avoided
                ' And since Excel interaction objects are declared as public, we can just work with them here
                If TAMMSpreadSheet <> "" Then

                    xlWorkBook.Save()
                    xlWorkBook.Close()
                    xlApp.Quit()
                End If

                BatchProgressBar.Value = iRun * NumRepeats + iRepeat

                'Update estimation
                Dim midTime = DateTime.Now
                Dim midduration = midTime - startTime
                Dim expectedMinutes = midduration.TotalSeconds / (iRun * NumRepeats + iRepeat) _ 'seconds per item
                    * (totalIterations - (iRun * NumRepeats + iRepeat)) / 60 ' times # of remaining items, translate to minutes

                EstimatedRunTimeLabel.Text = (iRun * NumRepeats + iRepeat) & "/" & totalIterations & " completed  |  Time remaining: ~" & Math.Round(expectedMinutes, 1) & " minutes"



                'add garbage collection and closure stuff here
                Application.DoEvents()
            Next
        Next

        Dim endTime = DateTime.Now
        Dim duration = endTime - startTime

        SystemSounds.Asterisk.Play()
        EstimatedRunTimeLabel.Text = "Multi-run Done! Duration: " & Math.Round(duration.TotalMinutes, 2) & " minutes."

        ReturnButton.Visible = True
        CancelRunButton.Visible = False
        RunAllButton.Visible = False

        Me.Refresh()

        'MsgBox("Multi-run Done! Duration: " & Math.Round(duration.TotalMinutes, 2) & " minutes.")

    End Sub

    Private Sub CancelRunButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelRunButton.Click
        UpdateRunEncounterRateAdjustment = False
        Me.Close()
        FVS_MainMenu.Visible = True
    End Sub

    Private Sub ReturnButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RunAllButton.Click
        Me.Close()
        FVS_MainMenu.Visible = True
    End Sub

    Sub ExternalSubCalcs(ByVal c As Integer, ByVal iters As Integer)

        ''Now that the run is done, calculate the encounter rate adjustments needed to achieve targets
        ''get the external ratio and enc rate adjustment tables for calculations
        '  Dim dbconn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FVSdatabasename)
        '  Dim sql As String       'SQL Query text string
        '  Dim oledbAdapter As OleDb.OleDbDataAdapter
        '  'start(clean)
        '  dsSLquery.Clear()
        '  Try
        '      dbconn.Open()

        '      ' This creates a simple table of legal and sublegal mortalities for computing SLRatio below.
        '      sql = "SELECT Mortality.RunID, Mortality.FisheryID, Mortality.TimeStep, Sum(Mortality.MSFShaker) AS MSFSub, " & _
        '            "Sum(Mortality.MSFEncounter) AS MSFLeg, Sum(Mortality.LandedCatch) AS NSLeg, Sum(Mortality.Shaker) " & _
        '            "AS NSSub " & _
        '            "FROM Mortality " & _
        '            "GROUP BY Mortality.RunID, Mortality.FisheryID, Mortality.TimeStep " & _
        '            "HAVING (((Mortality.RunID)=" & RunIDSelect & "));"

        '      oledbAdapter = New OleDb.OleDbDataAdapter(sql, dbconn)
        '      oledbAdapter.Fill(dsSLquery, "TheMeat")
        '      oledbAdapter.Dispose()
        '      dbconn.Close()

        '  Catch ex As Exception
        '      MsgBox("S:L Ratio Calc Query Bombed!" & vbCr & "Verify that your database contains this correct tables and try again.")
        '  End Try

        'Now compute the new Kfats and modify the EncounterRateAdjustment for the next run...
        Dim leg(NumFish + 1, TStep + 1), subleg(NumFish + 1, TStep + 1), subrat(NumFish + 1, TStep + 1) As Double
        For Stk = 1 To NumStk
            For Age = MinAge To MaxAge
                For Fish = 1 To NumFish
                    For TStep = 1 To NumSteps
                        leg(Fish, TStep) += LandedCatch(Stk, Age, Fish, TStep) + MSFLandedCatch(Stk, Age, Fish, TStep)
                        If MarkSelectiveMortRate(Fish, TStep) <> 0 Then
                            leg(Fish, TStep) += MSFNonRetention(Stk, Age, Fish, TStep) / MarkSelectiveMortRate(Fish, TStep)
                        End If
                        subleg(Fish, TStep) += Shakers(Stk, Age, Fish, TStep) / ShakerMortRate(Fish, TStep) + MSFShakers(Stk, Age, Fish, TStep) / ShakerMortRate(Fish, TStep)
                        If Fish = 67 And TStep = 3 And c = 3 Then
                            If LandedCatch(Stk, Age, Fish, TStep) + MSFLandedCatch(Stk, Age, Fish, TStep) + Shakers(Stk, Age, Fish, TStep) + MSFShakers(Stk, Age, Fish, TStep) + MSFNonRetention(Stk, Age, Fish, TStep) > 0 Then
                                Debug.Print("Fishery =, " & Fish & ",stock =, " & Stk & ",Tstep =, " & TStep & ",iteration = ," & c.ToString & " ,Age =," & Age.ToString & " ,MSFNR =," & MSFNonRetention(Stk, Age, Fish, TStep) _
                                           & " ,Landed =," & LandedCatch(Stk, Age, Fish, TStep) & " ,MSFLanded =," & MSFLandedCatch(Stk, Age, Fish, TStep) & " ,Shakers =," & Shakers(Stk, Age, Fish, TStep) & " ,MSFShakers =," & MSFShakers(Stk, Age, Fish, TStep))
                            End If
                        End If
                    Next
                Next
            Next
        Next
        Dim F, A, T As Integer
        For F = 1 To NumFish
            For T = 1 To NumSteps

                Dim kfatold As Double
                If F = 67 And T = 3 Then
                    Jim = 1
                End If

                'tag111
                'Dim leg2, subleg2, subrat2, kfatold2 As Double



                For A = MinAge To MaxAge
                    '    kfatold2 = Kfat2(F, A, T) 'debugging variable
                    '    If leg2 = 0 Or subleg2 = 0 Then
                    '        Kfat2(F, A, T) = 1 'Leave it at 1.00 = no adjustment.
                    '    Else
                    '        If TargetRatio(F, A, T) <> -1 Then 'Only compute new adjustments for fisheries providing an estimate of SL ratio 
                    '            subrat2 = subleg2 / leg2
                    '            Kfat2(F, A, T) = TargetRatio(F, A, T) / subrat2

                    '        End If
                    '    End If
                    kfatold = Kfat(F, A, T) 'debugging variable
                    If leg(F, T) = 0 Or subleg(F, T) = 0 Then
                        Kfat(F, A, T) = 1 'Leave it at 1.00 = no adjustment.
                    Else
                        If TargetRatio(F, A, T) <> -1 Then 'Only compute new adjustments for fisheries providing an estimate of SL ratio 

                            subrat(F, T) = subleg(F, T) / leg(F, T) '<-FRAM SL Ratio
                            Kfat(F, A, T) = TargetRatio(F, A, T) / subrat(F, T)
                            RunEncounterRateAdjustment(F, A, T) = RunEncounterRateAdjustment(F, A, T) * Kfat(F, A, T) 'Put it here for correct update/storage for saving
                            EncounterRateAdjustment(A, F, T) = EncounterRateAdjustment(A, F, T) * Kfat(F, A, T) 'Put it here for correct execution during iterations
                            'If (F = 16 Or F = 17) And T = 3 Then
                            'Debug.Print("Fishery =, " & F & ",iteration = ," & c.ToString & " ,Age =," & A.ToString & " ,subrat =," & subrat.ToString & " ,Target =," & TargetRatio(F, A, T).ToString & " ,OldKfat =," & kfatold.ToString & " ,NewKfat =," & Kfat(F, A, T).ToString & " ,EncounterRateAdj =," & EncounterRateAdjustment(A, F, T).ToString & " ,RUNEncounterRateAdj =," & RunEncounterRateAdjustment(F, A, T).ToString)
                            'End If
                        End If
                    End If
                Next

                ' dr = dsSLquery.Tables("TheMeat").Select(Str) 'Gets query results for fishery and time step


                'If dr.Length = 1 Then
                '    leg = dr(0)("MSFLeg") + dr(0)("NSLeg")
                '    subleg = dr(0)("MSFSub") + dr(0)("NSSub")
                '    For A = MinAge To MaxAge
                '        kfatold = Kfat(F, A, T) 'debugging variable
                '        If leg = 0 Or subleg = 0 Then
                '            Kfat(F, A, T) = 1 'Leave it at 1.00 = no adjustment.
                '        Else
                '            If TargetRatio(F, A, T) <> -1 Then 'Only compute new adjustments for fisheries providing an estimate of SL ratio 
                '                subrat = (subleg / ShakerMortRate(F, T)) / leg '<-FRAM SL Ratio
                '                Kfat(F, A, T) = TargetRatio(F, A, T) / subrat
                '                RunEncounterRateAdjustment(F, A, T) = RunEncounterRateAdjustment(F, A, T) * Kfat(F, A, T) 'Put it here for correct update/storage for saving
                '                EncounterRateAdjustment(A, F, T) = EncounterRateAdjustment(A, F, T) * Kfat(F, A, T) 'Put it here for correct execution during iterations
                '                'If (F = 16 Or F = 17) And T = 3 Then
                '                'Debug.Print("Fishery =, " & F & ",iteration = ," & c.ToString & " ,Age =," & A.ToString & " ,subrat =," & subrat.ToString & " ,Target =," & TargetRatio(F, A, T).ToString & " ,OldKfat =," & kfatold.ToString & " ,NewKfat =," & Kfat(F, A, T).ToString & " ,EncounterRateAdj =," & EncounterRateAdjustment(A, F, T).ToString & " ,RUNEncounterRateAdj =," & RunEncounterRateAdjustment(F, A, T).ToString)
                '                'End If
                '            End If
                '        End If
                '    Next
                'End If
            Next
        Next

        'Set the boolean to true once FRAM has made all update passes; the last one will just be a calculation pass
        'If c = iters - 1 Then
        '    FinalUpdatePass = True
        'End If

    End Sub
End Class