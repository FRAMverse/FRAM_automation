<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FVS_RunModelMulti
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
        Me.ModelRunTitleLabel = New System.Windows.Forms.Label()
        Me.DatabaseNameLabel = New System.Windows.Forms.Label()
        Me.DatabaseTextLabel = New System.Windows.Forms.Label()
        Me.chkTS4 = New System.Windows.Forms.CheckBox()
        Me.chkCoastalIterations = New System.Windows.Forms.CheckBox()
        Me.OldCohort = New System.Windows.Forms.CheckBox()
        Me.ChinookSizeLimitCheck = New System.Windows.Forms.CheckBox()
        Me.MSFBiasCorrectionCheckBox = New System.Windows.Forms.CheckBox()
        Me.ChinookBYCheck = New System.Windows.Forms.CheckBox()
        Me.TammFwsCheck = New System.Windows.Forms.CheckBox()
        Me.OldTammCheck = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SelectionGuiButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SelectRunsManually = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RunAllButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TammFolderTextbox = New System.Windows.Forms.TextBox()
        Me.SelectRunsFromFolderButton = New System.Windows.Forms.Button()
        Me.CancelRunButton = New System.Windows.Forms.Button()
        Me.RepeatEachRunInput = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BatchProgressBar = New System.Windows.Forms.ProgressBar()
        Me.CurrentStepLabel = New System.Windows.Forms.Label()
        Me.EstimatedRunTimeLabel = New System.Windows.Forms.Label()
        Me.RunInfoNumLabel = New System.Windows.Forms.Label()
        Me.RunInfoTimeLabel = New System.Windows.Forms.Label()
        Me.ReturnButton = New System.Windows.Forms.Button()
        CType(Me.RepeatEachRunInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ModelRunTitleLabel
        '
        Me.ModelRunTitleLabel.AutoSize = True
        Me.ModelRunTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModelRunTitleLabel.Location = New System.Drawing.Point(251, 21)
        Me.ModelRunTitleLabel.Name = "ModelRunTitleLabel"
        Me.ModelRunTitleLabel.Size = New System.Drawing.Size(263, 32)
        Me.ModelRunTitleLabel.TabIndex = 1
        Me.ModelRunTitleLabel.Text = "Run Multiple Runs"
        '
        'DatabaseNameLabel
        '
        Me.DatabaseNameLabel.AutoSize = True
        Me.DatabaseNameLabel.BackColor = System.Drawing.Color.Yellow
        Me.DatabaseNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatabaseNameLabel.Location = New System.Drawing.Point(296, 62)
        Me.DatabaseNameLabel.Name = "DatabaseNameLabel"
        Me.DatabaseNameLabel.Size = New System.Drawing.Size(173, 25)
        Me.DatabaseNameLabel.TabIndex = 20
        Me.DatabaseNameLabel.Text = "database name"
        '
        'DatabaseTextLabel
        '
        Me.DatabaseTextLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.DatabaseTextLabel.AutoSize = True
        Me.DatabaseTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatabaseTextLabel.Location = New System.Drawing.Point(158, 62)
        Me.DatabaseTextLabel.Name = "DatabaseTextLabel"
        Me.DatabaseTextLabel.Size = New System.Drawing.Size(112, 25)
        Me.DatabaseTextLabel.TabIndex = 19
        Me.DatabaseTextLabel.Text = "Database"
        '
        'chkTS4
        '
        Me.chkTS4.AutoSize = True
        Me.chkTS4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkTS4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTS4.Location = New System.Drawing.Point(1171, 491)
        Me.chkTS4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkTS4.Name = "chkTS4"
        Me.chkTS4.Size = New System.Drawing.Size(295, 29)
        Me.chkTS4.TabIndex = 45
        Me.chkTS4.Text = "Don't reuse T1 when A5=0"
        Me.chkTS4.UseVisualStyleBackColor = False
        '
        'chkCoastalIterations
        '
        Me.chkCoastalIterations.AutoSize = True
        Me.chkCoastalIterations.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkCoastalIterations.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCoastalIterations.Location = New System.Drawing.Point(1171, 302)
        Me.chkCoastalIterations.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkCoastalIterations.Name = "chkCoastalIterations"
        Me.chkCoastalIterations.Size = New System.Drawing.Size(272, 29)
        Me.chkCoastalIterations.TabIndex = 44
        Me.chkCoastalIterations.Text = "Run Coastal Iterations"
        Me.chkCoastalIterations.UseVisualStyleBackColor = False
        Me.chkCoastalIterations.Visible = False
        '
        'OldCohort
        '
        Me.OldCohort.AutoSize = True
        Me.OldCohort.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.OldCohort.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OldCohort.Location = New System.Drawing.Point(1171, 465)
        Me.OldCohort.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OldCohort.Name = "OldCohort"
        Me.OldCohort.Size = New System.Drawing.Size(366, 29)
        Me.OldCohort.TabIndex = 43
        Me.OldCohort.Text = "Cohort T4 pre 2012 Processing"
        Me.OldCohort.UseVisualStyleBackColor = False
        '
        'ChinookSizeLimitCheck
        '
        Me.ChinookSizeLimitCheck.AutoSize = True
        Me.ChinookSizeLimitCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChinookSizeLimitCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChinookSizeLimitCheck.Location = New System.Drawing.Point(1171, 438)
        Me.ChinookSizeLimitCheck.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChinookSizeLimitCheck.Name = "ChinookSizeLimitCheck"
        Me.ChinookSizeLimitCheck.Size = New System.Drawing.Size(243, 33)
        Me.ChinookSizeLimitCheck.TabIndex = 42
        Me.ChinookSizeLimitCheck.Text = "No Size Limit Fix "
        Me.ChinookSizeLimitCheck.UseVisualStyleBackColor = False
        '
        'MSFBiasCorrectionCheckBox
        '
        Me.MSFBiasCorrectionCheckBox.AutoSize = True
        Me.MSFBiasCorrectionCheckBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MSFBiasCorrectionCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MSFBiasCorrectionCheckBox.Location = New System.Drawing.Point(1171, 384)
        Me.MSFBiasCorrectionCheckBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MSFBiasCorrectionCheckBox.Name = "MSFBiasCorrectionCheckBox"
        Me.MSFBiasCorrectionCheckBox.Size = New System.Drawing.Size(462, 29)
        Me.MSFBiasCorrectionCheckBox.TabIndex = 41
        Me.MSFBiasCorrectionCheckBox.Text = "Run w/o MSF Bias Correction for COHO "
        Me.MSFBiasCorrectionCheckBox.UseVisualStyleBackColor = False
        '
        'ChinookBYCheck
        '
        Me.ChinookBYCheck.AutoSize = True
        Me.ChinookBYCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChinookBYCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChinookBYCheck.Location = New System.Drawing.Point(1171, 410)
        Me.ChinookBYCheck.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ChinookBYCheck.Name = "ChinookBYCheck"
        Me.ChinookBYCheck.Size = New System.Drawing.Size(381, 29)
        Me.ChinookBYCheck.TabIndex = 40
        Me.ChinookBYCheck.Text = "Chinook Brood Year AEQ Report"
        Me.ChinookBYCheck.UseVisualStyleBackColor = False
        '
        'TammFwsCheck
        '
        Me.TammFwsCheck.AutoSize = True
        Me.TammFwsCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TammFwsCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TammFwsCheck.Location = New System.Drawing.Point(1171, 356)
        Me.TammFwsCheck.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TammFwsCheck.Name = "TammFwsCheck"
        Me.TammFwsCheck.Size = New System.Drawing.Size(460, 29)
        Me.TammFwsCheck.TabIndex = 39
        Me.TammFwsCheck.Text = "Use Chinook TAMM FWS (No Iterations)"
        Me.TammFwsCheck.UseVisualStyleBackColor = False
        '
        'OldTammCheck
        '
        Me.OldTammCheck.AutoSize = True
        Me.OldTammCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.OldTammCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OldTammCheck.Location = New System.Drawing.Point(1171, 330)
        Me.OldTammCheck.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.OldTammCheck.Name = "OldTammCheck"
        Me.OldTammCheck.Size = New System.Drawing.Size(584, 29)
        Me.OldTammCheck.TabIndex = 38
        Me.OldTammCheck.Text = "Old Chinook TAMM Format (10+11 Sport Combined)"
        Me.OldTammCheck.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(646, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(328, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Alternative approach to identify multiple runs. "
        '
        'SelectionGuiButton
        '
        Me.SelectionGuiButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.SelectionGuiButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectionGuiButton.Location = New System.Drawing.Point(1276, 194)
        Me.SelectionGuiButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SelectionGuiButton.Name = "SelectionGuiButton"
        Me.SelectionGuiButton.Size = New System.Drawing.Size(181, 60)
        Me.SelectionGuiButton.TabIndex = 48
        Me.SelectionGuiButton.Text = "Browser"
        Me.SelectionGuiButton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(645, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(686, 20)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "All .xlsx files in folder must be TAMM files, and must end with ""-{runid}.xlsx"" f" &
    "or associated run ID. "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(646, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(711, 20)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "For example, ""Chin-sensitivity-139.xlsx"" will be treated as a TAMM that should be" &
    " used with Run 139."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(645, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(345, 20)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "All RunIDs with associated TAMMs will be used." & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'SelectRunsManually
        '
        Me.SelectRunsManually.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SelectRunsManually.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectRunsManually.Location = New System.Drawing.Point(187, 106)
        Me.SelectRunsManually.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SelectRunsManually.Name = "SelectRunsManually"
        Me.SelectRunsManually.Size = New System.Drawing.Size(317, 55)
        Me.SelectRunsManually.TabIndex = 53
        Me.SelectRunsManually.Text = "Select runs manually"
        Me.SelectRunsManually.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label7.Location = New System.Drawing.Point(1167, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(402, 29)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Run options (applied to ALL runs)"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(26, 265)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1115, 654)
        Me.Panel1.TabIndex = 56
        '
        'RunAllButton
        '
        Me.RunAllButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RunAllButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunAllButton.Location = New System.Drawing.Point(1159, 715)
        Me.RunAllButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RunAllButton.Name = "RunAllButton"
        Me.RunAllButton.Size = New System.Drawing.Size(317, 55)
        Me.RunAllButton.TabIndex = 57
        Me.RunAllButton.Text = "RUN ALL"
        Me.RunAllButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(644, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(723, 32)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Advanced: Use folder of TAMMs ending in '-{RunID}.xlsx'"
        '
        'TammFolderTextbox
        '
        Me.TammFolderTextbox.AllowDrop = True
        Me.TammFolderTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TammFolderTextbox.Location = New System.Drawing.Point(648, 208)
        Me.TammFolderTextbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TammFolderTextbox.Name = "TammFolderTextbox"
        Me.TammFolderTextbox.Size = New System.Drawing.Size(599, 31)
        Me.TammFolderTextbox.TabIndex = 59
        '
        'SelectRunsFromFolderButton
        '
        Me.SelectRunsFromFolderButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SelectRunsFromFolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectRunsFromFolderButton.Location = New System.Drawing.Point(1464, 194)
        Me.SelectRunsFromFolderButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SelectRunsFromFolderButton.Name = "SelectRunsFromFolderButton"
        Me.SelectRunsFromFolderButton.Size = New System.Drawing.Size(180, 60)
        Me.SelectRunsFromFolderButton.TabIndex = 60
        Me.SelectRunsFromFolderButton.Text = "Use folder"
        Me.SelectRunsFromFolderButton.UseVisualStyleBackColor = False
        '
        'CancelRunButton
        '
        Me.CancelRunButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CancelRunButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelRunButton.Location = New System.Drawing.Point(1506, 715)
        Me.CancelRunButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CancelRunButton.Name = "CancelRunButton"
        Me.CancelRunButton.Size = New System.Drawing.Size(166, 55)
        Me.CancelRunButton.TabIndex = 61
        Me.CancelRunButton.Text = "CANCEL"
        Me.CancelRunButton.UseVisualStyleBackColor = False
        '
        'RepeatEachRunInput
        '
        Me.RepeatEachRunInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.RepeatEachRunInput.Location = New System.Drawing.Point(1575, 633)
        Me.RepeatEachRunInput.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RepeatEachRunInput.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.RepeatEachRunInput.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepeatEachRunInput.Name = "RepeatEachRunInput"
        Me.RepeatEachRunInput.Size = New System.Drawing.Size(68, 35)
        Me.RepeatEachRunInput.TabIndex = 63
        Me.RepeatEachRunInput.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1159, 633)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(365, 29)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "How many times to run each run?"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1161, 665)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(413, 20)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Set to > 1 to automatically run each RunID multiple times."
        '
        'BatchProgressBar
        '
        Me.BatchProgressBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BatchProgressBar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BatchProgressBar.Location = New System.Drawing.Point(26, 969)
        Me.BatchProgressBar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BatchProgressBar.Name = "BatchProgressBar"
        Me.BatchProgressBar.Size = New System.Drawing.Size(1641, 28)
        Me.BatchProgressBar.TabIndex = 68
        '
        'CurrentStepLabel
        '
        Me.CurrentStepLabel.AutoSize = True
        Me.CurrentStepLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentStepLabel.Location = New System.Drawing.Point(30, 934)
        Me.CurrentStepLabel.Name = "CurrentStepLabel"
        Me.CurrentStepLabel.Size = New System.Drawing.Size(148, 29)
        Me.CurrentStepLabel.TabIndex = 71
        Me.CurrentStepLabel.Text = "Current Step"
        Me.CurrentStepLabel.Visible = False
        '
        'EstimatedRunTimeLabel
        '
        Me.EstimatedRunTimeLabel.AutoSize = True
        Me.EstimatedRunTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstimatedRunTimeLabel.Location = New System.Drawing.Point(1058, 934)
        Me.EstimatedRunTimeLabel.Name = "EstimatedRunTimeLabel"
        Me.EstimatedRunTimeLabel.Size = New System.Drawing.Size(284, 29)
        Me.EstimatedRunTimeLabel.TabIndex = 72
        Me.EstimatedRunTimeLabel.Text = "Remaining time unclear..."
        Me.EstimatedRunTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.EstimatedRunTimeLabel.Visible = False
        '
        'RunInfoNumLabel
        '
        Me.RunInfoNumLabel.AutoSize = True
        Me.RunInfoNumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunInfoNumLabel.Location = New System.Drawing.Point(1160, 785)
        Me.RunInfoNumLabel.Name = "RunInfoNumLabel"
        Me.RunInfoNumLabel.Size = New System.Drawing.Size(147, 26)
        Me.RunInfoNumLabel.TabIndex = 73
        Me.RunInfoNumLabel.Text = "[RunInfoNum]"
        '
        'RunInfoTimeLabel
        '
        Me.RunInfoTimeLabel.AutoSize = True
        Me.RunInfoTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RunInfoTimeLabel.Location = New System.Drawing.Point(1160, 818)
        Me.RunInfoTimeLabel.Name = "RunInfoTimeLabel"
        Me.RunInfoTimeLabel.Size = New System.Drawing.Size(148, 26)
        Me.RunInfoTimeLabel.TabIndex = 74
        Me.RunInfoTimeLabel.Text = "[RunInfoTime]"
        '
        'ReturnButton
        '
        Me.ReturnButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ReturnButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReturnButton.Location = New System.Drawing.Point(1235, 864)
        Me.ReturnButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(317, 55)
        Me.ReturnButton.TabIndex = 75
        Me.ReturnButton.Text = "RETURN TO MAIN"
        Me.ReturnButton.UseVisualStyleBackColor = False
        Me.ReturnButton.Visible = False
        '
        'FVS_RunModelMulti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1678, 1014)
        Me.Controls.Add(Me.ReturnButton)
        Me.Controls.Add(Me.RunInfoTimeLabel)
        Me.Controls.Add(Me.RunInfoNumLabel)
        Me.Controls.Add(Me.EstimatedRunTimeLabel)
        Me.Controls.Add(Me.CurrentStepLabel)
        Me.Controls.Add(Me.BatchProgressBar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RepeatEachRunInput)
        Me.Controls.Add(Me.CancelRunButton)
        Me.Controls.Add(Me.SelectRunsFromFolderButton)
        Me.Controls.Add(Me.TammFolderTextbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RunAllButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SelectRunsManually)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SelectionGuiButton)
        Me.Controls.Add(Me.chkTS4)
        Me.Controls.Add(Me.chkCoastalIterations)
        Me.Controls.Add(Me.OldCohort)
        Me.Controls.Add(Me.ChinookSizeLimitCheck)
        Me.Controls.Add(Me.MSFBiasCorrectionCheckBox)
        Me.Controls.Add(Me.ChinookBYCheck)
        Me.Controls.Add(Me.TammFwsCheck)
        Me.Controls.Add(Me.OldTammCheck)
        Me.Controls.Add(Me.DatabaseNameLabel)
        Me.Controls.Add(Me.DatabaseTextLabel)
        Me.Controls.Add(Me.ModelRunTitleLabel)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FVS_RunModelMulti"
        Me.Text = "z"
        CType(Me.RepeatEachRunInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ModelRunTitleLabel As Label
    Friend WithEvents DatabaseNameLabel As Label
    Friend WithEvents DatabaseTextLabel As Label
    Friend WithEvents chkTS4 As CheckBox
    Friend WithEvents chkCoastalIterations As CheckBox
    Friend WithEvents OldCohort As CheckBox
    Friend WithEvents ChinookSizeLimitCheck As CheckBox
    Friend WithEvents MSFBiasCorrectionCheckBox As CheckBox
    Friend WithEvents ChinookBYCheck As CheckBox
    Friend WithEvents TammFwsCheck As CheckBox
    Friend WithEvents OldTammCheck As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SelectionGuiButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents SelectRunsManually As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RunAllButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TammFolderTextbox As TextBox
    Friend WithEvents SelectRunsFromFolderButton As Button
    Friend WithEvents CancelRunButton As Button
    Friend WithEvents RepeatEachRunInput As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents BatchProgressBar As ProgressBar
    Friend WithEvents CurrentStepLabel As Label
    Friend WithEvents EstimatedRunTimeLabel As Label
    Friend WithEvents RunInfoNumLabel As Label
    Friend WithEvents RunInfoTimeLabel As Label
    Friend WithEvents ReturnButton As Button
End Class
