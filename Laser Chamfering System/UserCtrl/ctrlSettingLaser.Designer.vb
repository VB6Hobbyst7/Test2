<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSettingLaser
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbLaserChiller = New System.Windows.Forms.GroupBox()
        Me.gbChillerSet1 = New System.Windows.Forms.GroupBox()
        Me.btnChillerFilterReset = New System.Windows.Forms.Button()
        Me.btnChillerFilter = New System.Windows.Forms.Button()
        Me.numChillerFilter = New System.Windows.Forms.NumericUpDown()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.btnChillerWaterReset = New System.Windows.Forms.Button()
        Me.btnChillerWaterSet = New System.Windows.Forms.Button()
        Me.numChillerWater = New System.Windows.Forms.NumericUpDown()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.gbChiller1 = New System.Windows.Forms.GroupBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.lblChillerFilter = New System.Windows.Forms.Label()
        Me.pbChillerFilter = New System.Windows.Forms.ProgressBar()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.lblChillerWater = New System.Windows.Forms.Label()
        Me.pbChillerWater = New System.Windows.Forms.ProgressBar()
        Me.gbLaserSet = New System.Windows.Forms.GroupBox()
        Me.btnPowerMeterOff = New System.Windows.Forms.Button()
        Me.lblPowerMeterBottum = New System.Windows.Forms.Label()
        Me.lblPowerMeterTop = New System.Windows.Forms.Label()
        Me.btnPowerMeterBottum = New System.Windows.Forms.Button()
        Me.btnPowerMeterTop = New System.Windows.Forms.Button()
        Me.gbTHGTemp = New System.Windows.Forms.GroupBox()
        Me.lblTHGTemp = New System.Windows.Forms.Label()
        Me.gbSHGTemp1 = New System.Windows.Forms.GroupBox()
        Me.lblSHGTemp = New System.Windows.Forms.Label()
        Me.gbTransMission = New System.Windows.Forms.GroupBox()
        Me.numTransMission = New System.Windows.Forms.NumericUpDown()
        Me.lblTransMission = New System.Windows.Forms.Label()
        Me.btnTransMissionSet = New System.Windows.Forms.Button()
        Me.gbSwitchOn = New System.Windows.Forms.GroupBox()
        Me.lblSwitchOn = New System.Windows.Forms.Label()
        Me.gbLaserRFP = New System.Windows.Forms.GroupBox()
        Me.numRFPLevel = New System.Windows.Forms.NumericUpDown()
        Me.lblRFPLevel = New System.Windows.Forms.Label()
        Me.btnRFPLevel = New System.Windows.Forms.Button()
        Me.gbLaserFault = New System.Windows.Forms.GroupBox()
        Me.btnClearFault = New System.Windows.Forms.Button()
        Me.lbSystemFault = New System.Windows.Forms.ListBox()
        Me.gbLaser1Heater = New System.Windows.Forms.GroupBox()
        Me.btnShutterOpen = New System.Windows.Forms.Button()
        Me.gbLaserState = New System.Windows.Forms.GroupBox()
        Me.lblLaserState = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnShutterClose = New System.Windows.Forms.Button()
        Me.gbLaser1Power = New System.Windows.Forms.GroupBox()
        Me.lblPower = New System.Windows.Forms.Label()
        Me.gbLaser1RepetitionRate = New System.Windows.Forms.GroupBox()
        Me.numRepetitionRate = New System.Windows.Forms.NumericUpDown()
        Me.lblRepetitionRate = New System.Windows.Forms.Label()
        Me.btnRepetitionRate = New System.Windows.Forms.Button()
        Me.gbLaser1Trigger = New System.Windows.Forms.GroupBox()
        Me.lblTriggerMode = New System.Windows.Forms.Label()
        Me.cbTriggermode = New System.Windows.Forms.ComboBox()
        Me.btnTriggerSet = New System.Windows.Forms.Button()
        Me.gbLaser1ATT = New System.Windows.Forms.GroupBox()
        Me.numAttenuation = New System.Windows.Forms.NumericUpDown()
        Me.lblAttenuation = New System.Windows.Forms.Label()
        Me.btnAttenuationSet = New System.Windows.Forms.Button()
        Me.gbLaserChiller.SuspendLayout()
        Me.gbChillerSet1.SuspendLayout()
        CType(Me.numChillerFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChillerWater, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChiller1.SuspendLayout()
        Me.gbLaserSet.SuspendLayout()
        Me.gbTHGTemp.SuspendLayout()
        Me.gbSHGTemp1.SuspendLayout()
        Me.gbTransMission.SuspendLayout()
        CType(Me.numTransMission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSwitchOn.SuspendLayout()
        Me.gbLaserRFP.SuspendLayout()
        CType(Me.numRFPLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLaserFault.SuspendLayout()
        Me.gbLaser1Heater.SuspendLayout()
        Me.gbLaserState.SuspendLayout()
        Me.gbLaser1Power.SuspendLayout()
        Me.gbLaser1RepetitionRate.SuspendLayout()
        CType(Me.numRepetitionRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLaser1Trigger.SuspendLayout()
        Me.gbLaser1ATT.SuspendLayout()
        CType(Me.numAttenuation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbLaserChiller
        '
        Me.gbLaserChiller.Controls.Add(Me.gbChillerSet1)
        Me.gbLaserChiller.Controls.Add(Me.gbChiller1)
        Me.gbLaserChiller.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaserChiller.Location = New System.Drawing.Point(18, 545)
        Me.gbLaserChiller.Name = "gbLaserChiller"
        Me.gbLaserChiller.Size = New System.Drawing.Size(691, 120)
        Me.gbLaserChiller.TabIndex = 348
        Me.gbLaserChiller.TabStop = False
        Me.gbLaserChiller.Text = "Chiller"
        '
        'gbChillerSet1
        '
        Me.gbChillerSet1.Controls.Add(Me.btnChillerFilterReset)
        Me.gbChillerSet1.Controls.Add(Me.btnChillerFilter)
        Me.gbChillerSet1.Controls.Add(Me.numChillerFilter)
        Me.gbChillerSet1.Controls.Add(Me.Label52)
        Me.gbChillerSet1.Controls.Add(Me.btnChillerWaterReset)
        Me.gbChillerSet1.Controls.Add(Me.btnChillerWaterSet)
        Me.gbChillerSet1.Controls.Add(Me.numChillerWater)
        Me.gbChillerSet1.Controls.Add(Me.Label53)
        Me.gbChillerSet1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbChillerSet1.Location = New System.Drawing.Point(355, 22)
        Me.gbChillerSet1.Name = "gbChillerSet1"
        Me.gbChillerSet1.Size = New System.Drawing.Size(328, 93)
        Me.gbChillerSet1.TabIndex = 321
        Me.gbChillerSet1.TabStop = False
        Me.gbChillerSet1.Text = "Chiller Maintain Set"
        '
        'btnChillerFilterReset
        '
        Me.btnChillerFilterReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChillerFilterReset.Location = New System.Drawing.Point(253, 49)
        Me.btnChillerFilterReset.Name = "btnChillerFilterReset"
        Me.btnChillerFilterReset.Size = New System.Drawing.Size(60, 28)
        Me.btnChillerFilterReset.TabIndex = 38
        Me.btnChillerFilterReset.Text = "Reset"
        Me.btnChillerFilterReset.UseVisualStyleBackColor = True
        '
        'btnChillerFilter
        '
        Me.btnChillerFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChillerFilter.Location = New System.Drawing.Point(187, 49)
        Me.btnChillerFilter.Name = "btnChillerFilter"
        Me.btnChillerFilter.Size = New System.Drawing.Size(60, 28)
        Me.btnChillerFilter.TabIndex = 37
        Me.btnChillerFilter.Text = "Set"
        Me.btnChillerFilter.UseVisualStyleBackColor = True
        '
        'numChillerFilter
        '
        Me.numChillerFilter.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numChillerFilter.Location = New System.Drawing.Point(104, 53)
        Me.numChillerFilter.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numChillerFilter.Name = "numChillerFilter"
        Me.numChillerFilter.Size = New System.Drawing.Size(77, 25)
        Me.numChillerFilter.TabIndex = 36
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(15, 55)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(88, 17)
        Me.Label52.TabIndex = 35
        Me.Label52.Text = "Fiter D-Day :"
        '
        'btnChillerWaterReset
        '
        Me.btnChillerWaterReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChillerWaterReset.Location = New System.Drawing.Point(253, 17)
        Me.btnChillerWaterReset.Name = "btnChillerWaterReset"
        Me.btnChillerWaterReset.Size = New System.Drawing.Size(60, 28)
        Me.btnChillerWaterReset.TabIndex = 34
        Me.btnChillerWaterReset.Text = "Reset"
        Me.btnChillerWaterReset.UseVisualStyleBackColor = True
        '
        'btnChillerWaterSet
        '
        Me.btnChillerWaterSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChillerWaterSet.Location = New System.Drawing.Point(187, 17)
        Me.btnChillerWaterSet.Name = "btnChillerWaterSet"
        Me.btnChillerWaterSet.Size = New System.Drawing.Size(60, 28)
        Me.btnChillerWaterSet.TabIndex = 33
        Me.btnChillerWaterSet.Text = "Set"
        Me.btnChillerWaterSet.UseVisualStyleBackColor = True
        '
        'numChillerWater
        '
        Me.numChillerWater.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numChillerWater.Location = New System.Drawing.Point(104, 21)
        Me.numChillerWater.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numChillerWater.Name = "numChillerWater"
        Me.numChillerWater.Size = New System.Drawing.Size(77, 25)
        Me.numChillerWater.TabIndex = 1
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(6, 23)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(97, 17)
        Me.Label53.TabIndex = 0
        Me.Label53.Text = "Water D-Day :"
        '
        'gbChiller1
        '
        Me.gbChiller1.Controls.Add(Me.Label54)
        Me.gbChiller1.Controls.Add(Me.lblChillerFilter)
        Me.gbChiller1.Controls.Add(Me.pbChillerFilter)
        Me.gbChiller1.Controls.Add(Me.Label56)
        Me.gbChiller1.Controls.Add(Me.lblChillerWater)
        Me.gbChiller1.Controls.Add(Me.pbChillerWater)
        Me.gbChiller1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbChiller1.Location = New System.Drawing.Point(18, 22)
        Me.gbChiller1.Name = "gbChiller1"
        Me.gbChiller1.Size = New System.Drawing.Size(328, 93)
        Me.gbChiller1.TabIndex = 320
        Me.gbChiller1.TabStop = False
        Me.gbChiller1.Text = "Chiller Maintenance (Day)"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(7, 64)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(48, 17)
        Me.Label54.TabIndex = 324
        Me.Label54.Text = "Filter :"
        '
        'lblChillerFilter
        '
        Me.lblChillerFilter.AutoSize = True
        Me.lblChillerFilter.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblChillerFilter.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChillerFilter.Location = New System.Drawing.Point(182, 64)
        Me.lblChillerFilter.Name = "lblChillerFilter"
        Me.lblChillerFilter.Size = New System.Drawing.Size(19, 19)
        Me.lblChillerFilter.TabIndex = 323
        Me.lblChillerFilter.Text = "--"
        '
        'pbChillerFilter
        '
        Me.pbChillerFilter.Location = New System.Drawing.Point(67, 57)
        Me.pbChillerFilter.Name = "pbChillerFilter"
        Me.pbChillerFilter.Size = New System.Drawing.Size(244, 29)
        Me.pbChillerFilter.TabIndex = 322
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(7, 28)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(53, 17)
        Me.Label56.TabIndex = 321
        Me.Label56.Text = "Water :"
        '
        'lblChillerWater
        '
        Me.lblChillerWater.AutoSize = True
        Me.lblChillerWater.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.lblChillerWater.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChillerWater.Location = New System.Drawing.Point(182, 28)
        Me.lblChillerWater.Name = "lblChillerWater"
        Me.lblChillerWater.Size = New System.Drawing.Size(19, 19)
        Me.lblChillerWater.TabIndex = 320
        Me.lblChillerWater.Text = "--"
        '
        'pbChillerWater
        '
        Me.pbChillerWater.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.pbChillerWater.Location = New System.Drawing.Point(67, 21)
        Me.pbChillerWater.Name = "pbChillerWater"
        Me.pbChillerWater.Size = New System.Drawing.Size(244, 29)
        Me.pbChillerWater.TabIndex = 319
        '
        'gbLaserSet
        '
        Me.gbLaserSet.Controls.Add(Me.btnPowerMeterOff)
        Me.gbLaserSet.Controls.Add(Me.lblPowerMeterBottum)
        Me.gbLaserSet.Controls.Add(Me.lblPowerMeterTop)
        Me.gbLaserSet.Controls.Add(Me.btnPowerMeterBottum)
        Me.gbLaserSet.Controls.Add(Me.btnPowerMeterTop)
        Me.gbLaserSet.Controls.Add(Me.gbTHGTemp)
        Me.gbLaserSet.Controls.Add(Me.gbSHGTemp1)
        Me.gbLaserSet.Controls.Add(Me.gbTransMission)
        Me.gbLaserSet.Controls.Add(Me.gbSwitchOn)
        Me.gbLaserSet.Controls.Add(Me.gbLaserRFP)
        Me.gbLaserSet.Controls.Add(Me.gbLaserFault)
        Me.gbLaserSet.Controls.Add(Me.gbLaser1Heater)
        Me.gbLaserSet.Controls.Add(Me.gbLaser1Power)
        Me.gbLaserSet.Controls.Add(Me.gbLaser1RepetitionRate)
        Me.gbLaserSet.Controls.Add(Me.gbLaser1Trigger)
        Me.gbLaserSet.Controls.Add(Me.gbLaser1ATT)
        Me.gbLaserSet.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaserSet.Location = New System.Drawing.Point(18, 3)
        Me.gbLaserSet.Name = "gbLaserSet"
        Me.gbLaserSet.Size = New System.Drawing.Size(691, 534)
        Me.gbLaserSet.TabIndex = 347
        Me.gbLaserSet.TabStop = False
        Me.gbLaserSet.Text = "Laser"
        '
        'btnPowerMeterOff
        '
        Me.btnPowerMeterOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPowerMeterOff.Location = New System.Drawing.Point(419, 449)
        Me.btnPowerMeterOff.Name = "btnPowerMeterOff"
        Me.btnPowerMeterOff.Size = New System.Drawing.Size(158, 79)
        Me.btnPowerMeterOff.TabIndex = 352
        Me.btnPowerMeterOff.Text = "POWER METER OFF"
        Me.btnPowerMeterOff.UseVisualStyleBackColor = True
        '
        'lblPowerMeterBottum
        '
        Me.lblPowerMeterBottum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPowerMeterBottum.Location = New System.Drawing.Point(654, 446)
        Me.lblPowerMeterBottum.Name = "lblPowerMeterBottum"
        Me.lblPowerMeterBottum.Size = New System.Drawing.Size(21, 30)
        Me.lblPowerMeterBottum.TabIndex = 351
        Me.lblPowerMeterBottum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPowerMeterBottum.Visible = False
        '
        'lblPowerMeterTop
        '
        Me.lblPowerMeterTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPowerMeterTop.Location = New System.Drawing.Point(627, 446)
        Me.lblPowerMeterTop.Name = "lblPowerMeterTop"
        Me.lblPowerMeterTop.Size = New System.Drawing.Size(21, 30)
        Me.lblPowerMeterTop.TabIndex = 23
        Me.lblPowerMeterTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPowerMeterTop.Visible = False
        '
        'btnPowerMeterBottum
        '
        Me.btnPowerMeterBottum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPowerMeterBottum.Location = New System.Drawing.Point(226, 449)
        Me.btnPowerMeterBottum.Name = "btnPowerMeterBottum"
        Me.btnPowerMeterBottum.Size = New System.Drawing.Size(187, 79)
        Me.btnPowerMeterBottum.TabIndex = 350
        Me.btnPowerMeterBottum.Text = "하부 POWER METER 측정"
        Me.btnPowerMeterBottum.UseVisualStyleBackColor = True
        '
        'btnPowerMeterTop
        '
        Me.btnPowerMeterTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPowerMeterTop.Location = New System.Drawing.Point(33, 449)
        Me.btnPowerMeterTop.Name = "btnPowerMeterTop"
        Me.btnPowerMeterTop.Size = New System.Drawing.Size(187, 79)
        Me.btnPowerMeterTop.TabIndex = 349
        Me.btnPowerMeterTop.Text = "상부 POWER METER 측정"
        Me.btnPowerMeterTop.UseVisualStyleBackColor = True
        '
        'gbTHGTemp
        '
        Me.gbTHGTemp.Controls.Add(Me.lblTHGTemp)
        Me.gbTHGTemp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTHGTemp.Location = New System.Drawing.Point(189, 277)
        Me.gbTHGTemp.Name = "gbTHGTemp"
        Me.gbTHGTemp.Size = New System.Drawing.Size(165, 62)
        Me.gbTHGTemp.TabIndex = 348
        Me.gbTHGTemp.TabStop = False
        Me.gbTHGTemp.Text = "THG Temp"
        Me.gbTHGTemp.Visible = False
        '
        'lblTHGTemp
        '
        Me.lblTHGTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTHGTemp.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblTHGTemp.Location = New System.Drawing.Point(15, 27)
        Me.lblTHGTemp.Name = "lblTHGTemp"
        Me.lblTHGTemp.Size = New System.Drawing.Size(119, 21)
        Me.lblTHGTemp.TabIndex = 22
        Me.lblTHGTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbSHGTemp1
        '
        Me.gbSHGTemp1.Controls.Add(Me.lblSHGTemp)
        Me.gbSHGTemp1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSHGTemp1.Location = New System.Drawing.Point(18, 277)
        Me.gbSHGTemp1.Name = "gbSHGTemp1"
        Me.gbSHGTemp1.Size = New System.Drawing.Size(165, 62)
        Me.gbSHGTemp1.TabIndex = 347
        Me.gbSHGTemp1.TabStop = False
        Me.gbSHGTemp1.Text = "SHG Temp"
        Me.gbSHGTemp1.Visible = False
        '
        'lblSHGTemp
        '
        Me.lblSHGTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSHGTemp.Location = New System.Drawing.Point(15, 27)
        Me.lblSHGTemp.Name = "lblSHGTemp"
        Me.lblSHGTemp.Size = New System.Drawing.Size(119, 21)
        Me.lblSHGTemp.TabIndex = 22
        Me.lblSHGTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbTransMission
        '
        Me.gbTransMission.Controls.Add(Me.numTransMission)
        Me.gbTransMission.Controls.Add(Me.lblTransMission)
        Me.gbTransMission.Controls.Add(Me.btnTransMissionSet)
        Me.gbTransMission.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTransMission.Location = New System.Drawing.Point(359, 209)
        Me.gbTransMission.Name = "gbTransMission"
        Me.gbTransMission.Size = New System.Drawing.Size(324, 56)
        Me.gbTransMission.TabIndex = 346
        Me.gbTransMission.TabStop = False
        Me.gbTransMission.Text = "Attenuator 0~100[%]"
        '
        'numTransMission
        '
        Me.numTransMission.DecimalPlaces = 3
        Me.numTransMission.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numTransMission.Location = New System.Drawing.Point(111, 22)
        Me.numTransMission.Name = "numTransMission"
        Me.numTransMission.Size = New System.Drawing.Size(107, 22)
        Me.numTransMission.TabIndex = 22
        Me.numTransMission.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblTransMission
        '
        Me.lblTransMission.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTransMission.Location = New System.Drawing.Point(15, 22)
        Me.lblTransMission.Name = "lblTransMission"
        Me.lblTransMission.Size = New System.Drawing.Size(82, 21)
        Me.lblTransMission.TabIndex = 21
        Me.lblTransMission.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnTransMissionSet
        '
        Me.btnTransMissionSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransMissionSet.Location = New System.Drawing.Point(232, 17)
        Me.btnTransMissionSet.Name = "btnTransMissionSet"
        Me.btnTransMissionSet.Size = New System.Drawing.Size(82, 30)
        Me.btnTransMissionSet.TabIndex = 0
        Me.btnTransMissionSet.Text = "Set"
        Me.btnTransMissionSet.UseVisualStyleBackColor = True
        '
        'gbSwitchOn
        '
        Me.gbSwitchOn.Controls.Add(Me.lblSwitchOn)
        Me.gbSwitchOn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSwitchOn.Location = New System.Drawing.Point(18, 209)
        Me.gbSwitchOn.Name = "gbSwitchOn"
        Me.gbSwitchOn.Size = New System.Drawing.Size(154, 62)
        Me.gbSwitchOn.TabIndex = 333
        Me.gbSwitchOn.TabStop = False
        Me.gbSwitchOn.Text = "Key Status"
        '
        'lblSwitchOn
        '
        Me.lblSwitchOn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSwitchOn.Location = New System.Drawing.Point(15, 28)
        Me.lblSwitchOn.Name = "lblSwitchOn"
        Me.lblSwitchOn.Size = New System.Drawing.Size(119, 21)
        Me.lblSwitchOn.TabIndex = 22
        Me.lblSwitchOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbLaserRFP
        '
        Me.gbLaserRFP.Controls.Add(Me.numRFPLevel)
        Me.gbLaserRFP.Controls.Add(Me.lblRFPLevel)
        Me.gbLaserRFP.Controls.Add(Me.btnRFPLevel)
        Me.gbLaserRFP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaserRFP.Location = New System.Drawing.Point(359, 270)
        Me.gbLaserRFP.Name = "gbLaserRFP"
        Me.gbLaserRFP.Size = New System.Drawing.Size(324, 56)
        Me.gbLaserRFP.TabIndex = 309
        Me.gbLaserRFP.TabStop = False
        Me.gbLaserRFP.Text = "RF Percent Level 0~100[%]"
        '
        'numRFPLevel
        '
        Me.numRFPLevel.DecimalPlaces = 3
        Me.numRFPLevel.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numRFPLevel.Location = New System.Drawing.Point(111, 22)
        Me.numRFPLevel.Name = "numRFPLevel"
        Me.numRFPLevel.Size = New System.Drawing.Size(107, 22)
        Me.numRFPLevel.TabIndex = 22
        '
        'lblRFPLevel
        '
        Me.lblRFPLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRFPLevel.Location = New System.Drawing.Point(15, 22)
        Me.lblRFPLevel.Name = "lblRFPLevel"
        Me.lblRFPLevel.Size = New System.Drawing.Size(82, 21)
        Me.lblRFPLevel.TabIndex = 21
        Me.lblRFPLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRFPLevel
        '
        Me.btnRFPLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRFPLevel.Location = New System.Drawing.Point(232, 17)
        Me.btnRFPLevel.Name = "btnRFPLevel"
        Me.btnRFPLevel.Size = New System.Drawing.Size(82, 30)
        Me.btnRFPLevel.TabIndex = 0
        Me.btnRFPLevel.Text = "Set"
        Me.btnRFPLevel.UseVisualStyleBackColor = True
        '
        'gbLaserFault
        '
        Me.gbLaserFault.Controls.Add(Me.btnClearFault)
        Me.gbLaserFault.Controls.Add(Me.lbSystemFault)
        Me.gbLaserFault.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaserFault.Location = New System.Drawing.Point(17, 345)
        Me.gbLaserFault.Name = "gbLaserFault"
        Me.gbLaserFault.Size = New System.Drawing.Size(666, 98)
        Me.gbLaserFault.TabIndex = 344
        Me.gbLaserFault.TabStop = False
        Me.gbLaserFault.Text = "System Fault Stauts "
        '
        'btnClearFault
        '
        Me.btnClearFault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFault.Location = New System.Drawing.Point(574, 24)
        Me.btnClearFault.Name = "btnClearFault"
        Me.btnClearFault.Size = New System.Drawing.Size(82, 68)
        Me.btnClearFault.TabIndex = 1
        Me.btnClearFault.Text = "Clear"
        Me.btnClearFault.UseVisualStyleBackColor = True
        '
        'lbSystemFault
        '
        Me.lbSystemFault.FormattingEnabled = True
        Me.lbSystemFault.ItemHeight = 16
        Me.lbSystemFault.Location = New System.Drawing.Point(14, 24)
        Me.lbSystemFault.Name = "lbSystemFault"
        Me.lbSystemFault.Size = New System.Drawing.Size(546, 68)
        Me.lbSystemFault.TabIndex = 0
        '
        'gbLaser1Heater
        '
        Me.gbLaser1Heater.Controls.Add(Me.btnShutterOpen)
        Me.gbLaser1Heater.Controls.Add(Me.gbLaserState)
        Me.gbLaser1Heater.Controls.Add(Me.btnShutterClose)
        Me.gbLaser1Heater.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaser1Heater.Location = New System.Drawing.Point(17, 17)
        Me.gbLaser1Heater.Name = "gbLaser1Heater"
        Me.gbLaser1Heater.Size = New System.Drawing.Size(658, 63)
        Me.gbLaser1Heater.TabIndex = 307
        Me.gbLaser1Heater.TabStop = False
        '
        'btnShutterOpen
        '
        Me.btnShutterOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutterOpen.Location = New System.Drawing.Point(6, 21)
        Me.btnShutterOpen.Name = "btnShutterOpen"
        Me.btnShutterOpen.Size = New System.Drawing.Size(155, 34)
        Me.btnShutterOpen.TabIndex = 34
        Me.btnShutterOpen.Text = "SHUTTER OPEN"
        Me.btnShutterOpen.UseVisualStyleBackColor = True
        '
        'gbLaserState
        '
        Me.gbLaserState.Controls.Add(Me.lblLaserState)
        Me.gbLaserState.Controls.Add(Me.btnStop)
        Me.gbLaserState.Controls.Add(Me.btnStart)
        Me.gbLaserState.Location = New System.Drawing.Point(356, 11)
        Me.gbLaserState.Name = "gbLaserState"
        Me.gbLaserState.Size = New System.Drawing.Size(292, 49)
        Me.gbLaserState.TabIndex = 345
        Me.gbLaserState.TabStop = False
        Me.gbLaserState.Text = "System State"
        '
        'lblLaserState
        '
        Me.lblLaserState.BackColor = System.Drawing.Color.LightGray
        Me.lblLaserState.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaserState.Location = New System.Drawing.Point(12, 20)
        Me.lblLaserState.Name = "lblLaserState"
        Me.lblLaserState.Size = New System.Drawing.Size(88, 21)
        Me.lblLaserState.TabIndex = 500
        Me.lblLaserState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStop
        '
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Location = New System.Drawing.Point(205, 13)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(70, 30)
        Me.btnStop.TabIndex = 346
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Location = New System.Drawing.Point(125, 13)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(70, 30)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnShutterClose
        '
        Me.btnShutterClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShutterClose.Location = New System.Drawing.Point(171, 21)
        Me.btnShutterClose.Name = "btnShutterClose"
        Me.btnShutterClose.Size = New System.Drawing.Size(155, 34)
        Me.btnShutterClose.TabIndex = 33
        Me.btnShutterClose.Text = "SHUTTER CLOSE"
        Me.btnShutterClose.UseVisualStyleBackColor = True
        '
        'gbLaser1Power
        '
        Me.gbLaser1Power.Controls.Add(Me.lblPower)
        Me.gbLaser1Power.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaser1Power.Location = New System.Drawing.Point(192, 209)
        Me.gbLaser1Power.Name = "gbLaser1Power"
        Me.gbLaser1Power.Size = New System.Drawing.Size(154, 62)
        Me.gbLaser1Power.TabIndex = 332
        Me.gbLaser1Power.TabStop = False
        Me.gbLaser1Power.Text = "Output Power (W)"
        '
        'lblPower
        '
        Me.lblPower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPower.Location = New System.Drawing.Point(15, 28)
        Me.lblPower.Name = "lblPower"
        Me.lblPower.Size = New System.Drawing.Size(119, 21)
        Me.lblPower.TabIndex = 22
        Me.lblPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbLaser1RepetitionRate
        '
        Me.gbLaser1RepetitionRate.Controls.Add(Me.numRepetitionRate)
        Me.gbLaser1RepetitionRate.Controls.Add(Me.lblRepetitionRate)
        Me.gbLaser1RepetitionRate.Controls.Add(Me.btnRepetitionRate)
        Me.gbLaser1RepetitionRate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaser1RepetitionRate.Location = New System.Drawing.Point(17, 147)
        Me.gbLaser1RepetitionRate.Name = "gbLaser1RepetitionRate"
        Me.gbLaser1RepetitionRate.Size = New System.Drawing.Size(324, 56)
        Me.gbLaser1RepetitionRate.TabIndex = 309
        Me.gbLaser1RepetitionRate.TabStop = False
        Me.gbLaser1RepetitionRate.Text = "Repetition Rate (khz)"
        '
        'numRepetitionRate
        '
        Me.numRepetitionRate.DecimalPlaces = 3
        Me.numRepetitionRate.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numRepetitionRate.Location = New System.Drawing.Point(112, 22)
        Me.numRepetitionRate.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numRepetitionRate.Minimum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numRepetitionRate.Name = "numRepetitionRate"
        Me.numRepetitionRate.Size = New System.Drawing.Size(107, 22)
        Me.numRepetitionRate.TabIndex = 22
        Me.numRepetitionRate.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'lblRepetitionRate
        '
        Me.lblRepetitionRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRepetitionRate.Location = New System.Drawing.Point(15, 22)
        Me.lblRepetitionRate.Name = "lblRepetitionRate"
        Me.lblRepetitionRate.Size = New System.Drawing.Size(82, 21)
        Me.lblRepetitionRate.TabIndex = 21
        Me.lblRepetitionRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRepetitionRate
        '
        Me.btnRepetitionRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRepetitionRate.Location = New System.Drawing.Point(232, 18)
        Me.btnRepetitionRate.Name = "btnRepetitionRate"
        Me.btnRepetitionRate.Size = New System.Drawing.Size(70, 30)
        Me.btnRepetitionRate.TabIndex = 0
        Me.btnRepetitionRate.Text = "Set"
        Me.btnRepetitionRate.UseVisualStyleBackColor = True
        '
        'gbLaser1Trigger
        '
        Me.gbLaser1Trigger.Controls.Add(Me.lblTriggerMode)
        Me.gbLaser1Trigger.Controls.Add(Me.cbTriggermode)
        Me.gbLaser1Trigger.Controls.Add(Me.btnTriggerSet)
        Me.gbLaser1Trigger.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaser1Trigger.Location = New System.Drawing.Point(17, 85)
        Me.gbLaser1Trigger.Name = "gbLaser1Trigger"
        Me.gbLaser1Trigger.Size = New System.Drawing.Size(439, 56)
        Me.gbLaser1Trigger.TabIndex = 310
        Me.gbLaser1Trigger.TabStop = False
        Me.gbLaser1Trigger.Text = "Trigger Mode (PM)"
        '
        'lblTriggerMode
        '
        Me.lblTriggerMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTriggerMode.Location = New System.Drawing.Point(15, 23)
        Me.lblTriggerMode.Name = "lblTriggerMode"
        Me.lblTriggerMode.Size = New System.Drawing.Size(149, 21)
        Me.lblTriggerMode.TabIndex = 26
        Me.lblTriggerMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbTriggermode
        '
        Me.cbTriggermode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbTriggermode.FormattingEnabled = True
        Me.cbTriggermode.Items.AddRange(New Object() {"Internal", "External", "Internal & Gated", "External & Gated"})
        Me.cbTriggermode.Location = New System.Drawing.Point(177, 21)
        Me.cbTriggermode.Name = "cbTriggermode"
        Me.cbTriggermode.Size = New System.Drawing.Size(149, 24)
        Me.cbTriggermode.TabIndex = 3
        '
        'btnTriggerSet
        '
        Me.btnTriggerSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTriggerSet.Location = New System.Drawing.Point(356, 17)
        Me.btnTriggerSet.Name = "btnTriggerSet"
        Me.btnTriggerSet.Size = New System.Drawing.Size(70, 30)
        Me.btnTriggerSet.TabIndex = 0
        Me.btnTriggerSet.Text = "Set"
        Me.btnTriggerSet.UseVisualStyleBackColor = True
        '
        'gbLaser1ATT
        '
        Me.gbLaser1ATT.Controls.Add(Me.numAttenuation)
        Me.gbLaser1ATT.Controls.Add(Me.lblAttenuation)
        Me.gbLaser1ATT.Controls.Add(Me.btnAttenuationSet)
        Me.gbLaser1ATT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaser1ATT.Location = New System.Drawing.Point(359, 147)
        Me.gbLaser1ATT.Name = "gbLaser1ATT"
        Me.gbLaser1ATT.Size = New System.Drawing.Size(324, 56)
        Me.gbLaser1ATT.TabIndex = 308
        Me.gbLaser1ATT.TabStop = False
        Me.gbLaser1ATT.Text = "IR Power(W)"
        '
        'numAttenuation
        '
        Me.numAttenuation.DecimalPlaces = 3
        Me.numAttenuation.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numAttenuation.Location = New System.Drawing.Point(111, 22)
        Me.numAttenuation.Name = "numAttenuation"
        Me.numAttenuation.Size = New System.Drawing.Size(107, 22)
        Me.numAttenuation.TabIndex = 22
        Me.numAttenuation.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numAttenuation.Visible = False
        '
        'lblAttenuation
        '
        Me.lblAttenuation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAttenuation.Location = New System.Drawing.Point(15, 22)
        Me.lblAttenuation.Name = "lblAttenuation"
        Me.lblAttenuation.Size = New System.Drawing.Size(82, 21)
        Me.lblAttenuation.TabIndex = 21
        Me.lblAttenuation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAttenuationSet
        '
        Me.btnAttenuationSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAttenuationSet.Location = New System.Drawing.Point(232, 18)
        Me.btnAttenuationSet.Name = "btnAttenuationSet"
        Me.btnAttenuationSet.Size = New System.Drawing.Size(82, 30)
        Me.btnAttenuationSet.TabIndex = 0
        Me.btnAttenuationSet.Text = "Set"
        Me.btnAttenuationSet.UseVisualStyleBackColor = True
        Me.btnAttenuationSet.Visible = False
        '
        'ctrlSettingLaser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.gbLaserChiller)
        Me.Controls.Add(Me.gbLaserSet)
        Me.Name = "ctrlSettingLaser"
        Me.Size = New System.Drawing.Size(730, 668)
        Me.gbLaserChiller.ResumeLayout(False)
        Me.gbChillerSet1.ResumeLayout(False)
        Me.gbChillerSet1.PerformLayout()
        CType(Me.numChillerFilter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChillerWater, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbChiller1.ResumeLayout(False)
        Me.gbChiller1.PerformLayout()
        Me.gbLaserSet.ResumeLayout(False)
        Me.gbTHGTemp.ResumeLayout(False)
        Me.gbSHGTemp1.ResumeLayout(False)
        Me.gbTransMission.ResumeLayout(False)
        CType(Me.numTransMission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSwitchOn.ResumeLayout(False)
        Me.gbLaserRFP.ResumeLayout(False)
        CType(Me.numRFPLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLaserFault.ResumeLayout(False)
        Me.gbLaser1Heater.ResumeLayout(False)
        Me.gbLaserState.ResumeLayout(False)
        Me.gbLaser1Power.ResumeLayout(False)
        Me.gbLaser1RepetitionRate.ResumeLayout(False)
        CType(Me.numRepetitionRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLaser1Trigger.ResumeLayout(False)
        Me.gbLaser1ATT.ResumeLayout(False)
        CType(Me.numAttenuation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbLaserChiller As System.Windows.Forms.GroupBox
    Friend WithEvents gbChillerSet1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnChillerFilterReset As System.Windows.Forms.Button
    Friend WithEvents btnChillerFilter As System.Windows.Forms.Button
    Friend WithEvents numChillerFilter As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents btnChillerWaterReset As System.Windows.Forms.Button
    Friend WithEvents btnChillerWaterSet As System.Windows.Forms.Button
    Friend WithEvents numChillerWater As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents gbChiller1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents lblChillerFilter As System.Windows.Forms.Label
    Friend WithEvents pbChillerFilter As System.Windows.Forms.ProgressBar
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents lblChillerWater As System.Windows.Forms.Label
    Friend WithEvents pbChillerWater As System.Windows.Forms.ProgressBar
    Friend WithEvents gbLaserSet As System.Windows.Forms.GroupBox
    Friend WithEvents gbLaserFault As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearFault As System.Windows.Forms.Button
    Friend WithEvents lbSystemFault As System.Windows.Forms.ListBox
    Friend WithEvents gbLaser1Heater As System.Windows.Forms.GroupBox
    Friend WithEvents btnShutterOpen As System.Windows.Forms.Button
    Friend WithEvents btnShutterClose As System.Windows.Forms.Button
    Friend WithEvents gbLaser1Power As System.Windows.Forms.GroupBox
    Friend WithEvents lblPower As System.Windows.Forms.Label
    Friend WithEvents gbLaser1RepetitionRate As System.Windows.Forms.GroupBox
    Friend WithEvents numRepetitionRate As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRepetitionRate As System.Windows.Forms.Label
    Friend WithEvents btnRepetitionRate As System.Windows.Forms.Button
    Friend WithEvents gbLaser1Trigger As System.Windows.Forms.GroupBox
    Friend WithEvents lblTriggerMode As System.Windows.Forms.Label
    Friend WithEvents cbTriggermode As System.Windows.Forms.ComboBox
    Friend WithEvents btnTriggerSet As System.Windows.Forms.Button
    Friend WithEvents gbLaser1ATT As System.Windows.Forms.GroupBox
    Friend WithEvents numAttenuation As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAttenuation As System.Windows.Forms.Label
    Friend WithEvents btnAttenuationSet As System.Windows.Forms.Button
    Friend WithEvents gbLaserRFP As System.Windows.Forms.GroupBox
    Friend WithEvents numRFPLevel As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRFPLevel As System.Windows.Forms.Label
    Friend WithEvents btnRFPLevel As System.Windows.Forms.Button
    Friend WithEvents gbSwitchOn As System.Windows.Forms.GroupBox
    Friend WithEvents lblSwitchOn As System.Windows.Forms.Label
    Friend WithEvents gbLaserState As System.Windows.Forms.GroupBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblLaserState As System.Windows.Forms.Label
    Friend WithEvents gbTransMission As System.Windows.Forms.GroupBox
    Friend WithEvents numTransMission As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTransMission As System.Windows.Forms.Label
    Friend WithEvents btnTransMissionSet As System.Windows.Forms.Button
    Friend WithEvents gbTHGTemp As System.Windows.Forms.GroupBox
    Friend WithEvents gbSHGTemp1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSHGTemp As System.Windows.Forms.Label
    Friend WithEvents lblTHGTemp As System.Windows.Forms.Label
    Friend WithEvents btnPowerMeterBottum As System.Windows.Forms.Button
    Friend WithEvents btnPowerMeterTop As System.Windows.Forms.Button
    Friend WithEvents lblPowerMeterBottum As System.Windows.Forms.Label
    Friend WithEvents lblPowerMeterTop As System.Windows.Forms.Label
    Friend WithEvents btnPowerMeterOff As System.Windows.Forms.Button

End Class
