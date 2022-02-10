<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSettingScanner
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
        Me.gbScannerShotTest = New System.Windows.Forms.GroupBox()
        Me.btnScanShotContinousOn = New System.Windows.Forms.Button()
        Me.numLaserOnTime = New System.Windows.Forms.NumericUpDown()
        Me.btnScanShotOff = New System.Windows.Forms.Button()
        Me.btnScanShotBurstOn = New System.Windows.Forms.Button()
        Me.lbl15 = New System.Windows.Forms.Label()
        Me.gbScannerLaserParam = New System.Windows.Forms.GroupBox()
        Me.numScanLaserOffDelay = New System.Windows.Forms.NumericUpDown()
        Me.lblOffD1 = New System.Windows.Forms.Label()
        Me.numScanLaserOnDelay = New System.Windows.Forms.NumericUpDown()
        Me.lblOnD1 = New System.Windows.Forms.Label()
        Me.numPulseWidth2 = New System.Windows.Forms.NumericUpDown()
        Me.lblPw21 = New System.Windows.Forms.Label()
        Me.numPulseWidth1 = New System.Windows.Forms.NumericUpDown()
        Me.numHalfPulsePeriod = New System.Windows.Forms.NumericUpDown()
        Me.lblPw11 = New System.Windows.Forms.Label()
        Me.lblFreq1 = New System.Windows.Forms.Label()
        Me.gbScannerSimpleMark = New System.Windows.Forms.GroupBox()
        Me.chkMarkLineAxis = New System.Windows.Forms.CheckBox()
        Me.optMarkCircle = New System.Windows.Forms.RadioButton()
        Me.optMarkRect = New System.Windows.Forms.RadioButton()
        Me.optMarkLine = New System.Windows.Forms.RadioButton()
        Me.numScanRepeat = New System.Windows.Forms.NumericUpDown()
        Me.btnMark = New System.Windows.Forms.Button()
        Me.lbl12 = New System.Windows.Forms.Label()
        Me.numMarkSize = New System.Windows.Forms.NumericUpDown()
        Me.lbl11 = New System.Windows.Forms.Label()
        Me.btnScanParamApply = New System.Windows.Forms.Button()
        Me.gbScanStatus = New System.Windows.Forms.GroupBox()
        Me.lblScanStatusY = New System.Windows.Forms.Label()
        Me.lblScanStatusX = New System.Windows.Forms.Label()
        Me.txtScanWork = New System.Windows.Forms.TextBox()
        Me.lblScanY1 = New System.Windows.Forms.Label()
        Me.lblScanX1 = New System.Windows.Forms.Label()
        Me.gbScannerAxisParam = New System.Windows.Forms.GroupBox()
        Me.btnScannerParamSave = New System.Windows.Forms.Button()
        Me.numScanPolygonDelay = New System.Windows.Forms.NumericUpDown()
        Me.numScanMarkDelay = New System.Windows.Forms.NumericUpDown()
        Me.numScanMarkSPD = New System.Windows.Forms.NumericUpDown()
        Me.numScanJumpSPD = New System.Windows.Forms.NumericUpDown()
        Me.numScanJumpDelay = New System.Windows.Forms.NumericUpDown()
        Me.lblPolyD1 = New System.Windows.Forms.Label()
        Me.lblMarkD1 = New System.Windows.Forms.Label()
        Me.lblJumpD1 = New System.Windows.Forms.Label()
        Me.lblMarkS1 = New System.Windows.Forms.Label()
        Me.lblJumpS1 = New System.Windows.Forms.Label()
        Me.numScanAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblScanAngle1 = New System.Windows.Forms.Label()
        Me.btnInitScanner = New System.Windows.Forms.Button()
        Me.numScanBit = New System.Windows.Forms.NumericUpDown()
        Me.lblScanBit1 = New System.Windows.Forms.Label()
        Me.btnCorLoad = New System.Windows.Forms.Button()
        Me.txtCorFile = New System.Windows.Forms.TextBox()
        Me.lblCor1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optUsePowerMeter = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumX = New System.Windows.Forms.NumericUpDown()
        Me.NumY = New System.Windows.Forms.NumericUpDown()
        Me.btnMoveX = New System.Windows.Forms.Button()
        Me.btnAutoSeq = New System.Windows.Forms.Button()
        Me.gbScannerShotTest.SuspendLayout()
        CType(Me.numLaserOnTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbScannerLaserParam.SuspendLayout()
        CType(Me.numScanLaserOffDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanLaserOnDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPulseWidth2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPulseWidth1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHalfPulsePeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbScannerSimpleMark.SuspendLayout()
        CType(Me.numScanRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMarkSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbScanStatus.SuspendLayout()
        Me.gbScannerAxisParam.SuspendLayout()
        CType(Me.numScanPolygonDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanMarkDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanMarkSPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanJumpSPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanJumpDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanBit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbScannerShotTest
        '
        Me.gbScannerShotTest.Controls.Add(Me.btnScanShotContinousOn)
        Me.gbScannerShotTest.Controls.Add(Me.numLaserOnTime)
        Me.gbScannerShotTest.Controls.Add(Me.btnScanShotOff)
        Me.gbScannerShotTest.Controls.Add(Me.btnScanShotBurstOn)
        Me.gbScannerShotTest.Controls.Add(Me.lbl15)
        Me.gbScannerShotTest.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbScannerShotTest.Location = New System.Drawing.Point(343, 539)
        Me.gbScannerShotTest.Name = "gbScannerShotTest"
        Me.gbScannerShotTest.Size = New System.Drawing.Size(272, 143)
        Me.gbScannerShotTest.TabIndex = 356
        Me.gbScannerShotTest.TabStop = False
        Me.gbScannerShotTest.Text = "Laser Shot"
        '
        'btnScanShotContinousOn
        '
        Me.btnScanShotContinousOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanShotContinousOn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanShotContinousOn.ImageIndex = 0
        Me.btnScanShotContinousOn.Location = New System.Drawing.Point(142, 53)
        Me.btnScanShotContinousOn.Name = "btnScanShotContinousOn"
        Me.btnScanShotContinousOn.Size = New System.Drawing.Size(120, 40)
        Me.btnScanShotContinousOn.TabIndex = 153
        Me.btnScanShotContinousOn.Text = "Continous"
        Me.btnScanShotContinousOn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScanShotContinousOn.UseVisualStyleBackColor = True
        '
        'numLaserOnTime
        '
        Me.numLaserOnTime.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLaserOnTime.Location = New System.Drawing.Point(18, 25)
        Me.numLaserOnTime.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numLaserOnTime.Name = "numLaserOnTime"
        Me.numLaserOnTime.Size = New System.Drawing.Size(216, 22)
        Me.numLaserOnTime.TabIndex = 152
        Me.numLaserOnTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numLaserOnTime.Value = New Decimal(New Integer() {65500, 0, 0, 0})
        '
        'btnScanShotOff
        '
        Me.btnScanShotOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanShotOff.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanShotOff.ImageIndex = 0
        Me.btnScanShotOff.Location = New System.Drawing.Point(18, 95)
        Me.btnScanShotOff.Name = "btnScanShotOff"
        Me.btnScanShotOff.Size = New System.Drawing.Size(244, 40)
        Me.btnScanShotOff.TabIndex = 150
        Me.btnScanShotOff.Text = "Off"
        Me.btnScanShotOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScanShotOff.UseVisualStyleBackColor = True
        '
        'btnScanShotBurstOn
        '
        Me.btnScanShotBurstOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanShotBurstOn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanShotBurstOn.ImageIndex = 0
        Me.btnScanShotBurstOn.Location = New System.Drawing.Point(18, 53)
        Me.btnScanShotBurstOn.Name = "btnScanShotBurstOn"
        Me.btnScanShotBurstOn.Size = New System.Drawing.Size(120, 40)
        Me.btnScanShotBurstOn.TabIndex = 149
        Me.btnScanShotBurstOn.Text = "On"
        Me.btnScanShotBurstOn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScanShotBurstOn.UseVisualStyleBackColor = True
        '
        'lbl15
        '
        Me.lbl15.Location = New System.Drawing.Point(240, 25)
        Me.lbl15.Name = "lbl15"
        Me.lbl15.Size = New System.Drawing.Size(22, 22)
        Me.lbl15.TabIndex = 151
        Me.lbl15.Text = "us"
        Me.lbl15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbScannerLaserParam
        '
        Me.gbScannerLaserParam.Controls.Add(Me.numScanLaserOffDelay)
        Me.gbScannerLaserParam.Controls.Add(Me.lblOffD1)
        Me.gbScannerLaserParam.Controls.Add(Me.numScanLaserOnDelay)
        Me.gbScannerLaserParam.Controls.Add(Me.lblOnD1)
        Me.gbScannerLaserParam.Controls.Add(Me.numPulseWidth2)
        Me.gbScannerLaserParam.Controls.Add(Me.lblPw21)
        Me.gbScannerLaserParam.Controls.Add(Me.numPulseWidth1)
        Me.gbScannerLaserParam.Controls.Add(Me.numHalfPulsePeriod)
        Me.gbScannerLaserParam.Controls.Add(Me.lblPw11)
        Me.gbScannerLaserParam.Controls.Add(Me.lblFreq1)
        Me.gbScannerLaserParam.Location = New System.Drawing.Point(7, 147)
        Me.gbScannerLaserParam.Name = "gbScannerLaserParam"
        Me.gbScannerLaserParam.Size = New System.Drawing.Size(608, 121)
        Me.gbScannerLaserParam.TabIndex = 352
        Me.gbScannerLaserParam.TabStop = False
        Me.gbScannerLaserParam.Text = "Scanner Laser Parameter"
        '
        'numScanLaserOffDelay
        '
        Me.numScanLaserOffDelay.Location = New System.Drawing.Point(467, 87)
        Me.numScanLaserOffDelay.Maximum = New Decimal(New Integer() {8000, 0, 0, 0})
        Me.numScanLaserOffDelay.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numScanLaserOffDelay.Name = "numScanLaserOffDelay"
        Me.numScanLaserOffDelay.Size = New System.Drawing.Size(131, 23)
        Me.numScanLaserOffDelay.TabIndex = 155
        Me.numScanLaserOffDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numScanLaserOffDelay.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'lblOffD1
        '
        Me.lblOffD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOffD1.Location = New System.Drawing.Point(314, 87)
        Me.lblOffD1.Name = "lblOffD1"
        Me.lblOffD1.Size = New System.Drawing.Size(130, 21)
        Me.lblOffD1.TabIndex = 153
        Me.lblOffD1.Text = "Laser Off Delay[us]"
        '
        'numScanLaserOnDelay
        '
        Me.numScanLaserOnDelay.Location = New System.Drawing.Point(467, 53)
        Me.numScanLaserOnDelay.Maximum = New Decimal(New Integer() {8000, 0, 0, 0})
        Me.numScanLaserOnDelay.Minimum = New Decimal(New Integer() {8000, 0, 0, -2147483648})
        Me.numScanLaserOnDelay.Name = "numScanLaserOnDelay"
        Me.numScanLaserOnDelay.Size = New System.Drawing.Size(131, 23)
        Me.numScanLaserOnDelay.TabIndex = 152
        Me.numScanLaserOnDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numScanLaserOnDelay.Value = New Decimal(New Integer() {150, 0, 0, 0})
        '
        'lblOnD1
        '
        Me.lblOnD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOnD1.Location = New System.Drawing.Point(314, 53)
        Me.lblOnD1.Name = "lblOnD1"
        Me.lblOnD1.Size = New System.Drawing.Size(130, 21)
        Me.lblOnD1.TabIndex = 150
        Me.lblOnD1.Text = "Laser On Delay[us]"
        '
        'numPulseWidth2
        '
        Me.numPulseWidth2.Location = New System.Drawing.Point(164, 87)
        Me.numPulseWidth2.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numPulseWidth2.Name = "numPulseWidth2"
        Me.numPulseWidth2.Size = New System.Drawing.Size(131, 23)
        Me.numPulseWidth2.TabIndex = 149
        Me.numPulseWidth2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPulseWidth2.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblPw21
        '
        Me.lblPw21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPw21.Location = New System.Drawing.Point(18, 87)
        Me.lblPw21.Name = "lblPw21"
        Me.lblPw21.Size = New System.Drawing.Size(130, 21)
        Me.lblPw21.TabIndex = 147
        Me.lblPw21.Text = "Pulse Width #2[u]"
        '
        'numPulseWidth1
        '
        Me.numPulseWidth1.Location = New System.Drawing.Point(164, 53)
        Me.numPulseWidth1.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numPulseWidth1.Name = "numPulseWidth1"
        Me.numPulseWidth1.Size = New System.Drawing.Size(131, 23)
        Me.numPulseWidth1.TabIndex = 146
        Me.numPulseWidth1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPulseWidth1.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'numHalfPulsePeriod
        '
        Me.numHalfPulsePeriod.Location = New System.Drawing.Point(467, 22)
        Me.numHalfPulsePeriod.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numHalfPulsePeriod.Name = "numHalfPulsePeriod"
        Me.numHalfPulsePeriod.Size = New System.Drawing.Size(131, 23)
        Me.numHalfPulsePeriod.TabIndex = 145
        Me.numHalfPulsePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numHalfPulsePeriod.Value = New Decimal(New Integer() {130, 0, 0, 0})
        '
        'lblPw11
        '
        Me.lblPw11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPw11.Location = New System.Drawing.Point(18, 53)
        Me.lblPw11.Name = "lblPw11"
        Me.lblPw11.Size = New System.Drawing.Size(130, 21)
        Me.lblPw11.TabIndex = 143
        Me.lblPw11.Text = "Pulse Width #1[u]"
        '
        'lblFreq1
        '
        Me.lblFreq1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFreq1.Location = New System.Drawing.Point(314, 22)
        Me.lblFreq1.Name = "lblFreq1"
        Me.lblFreq1.Size = New System.Drawing.Size(130, 21)
        Me.lblFreq1.TabIndex = 141
        Me.lblFreq1.Text = "Half Pulse Period[kh]"
        '
        'gbScannerSimpleMark
        '
        Me.gbScannerSimpleMark.Controls.Add(Me.chkMarkLineAxis)
        Me.gbScannerSimpleMark.Controls.Add(Me.optMarkCircle)
        Me.gbScannerSimpleMark.Controls.Add(Me.optMarkRect)
        Me.gbScannerSimpleMark.Controls.Add(Me.optMarkLine)
        Me.gbScannerSimpleMark.Controls.Add(Me.numScanRepeat)
        Me.gbScannerSimpleMark.Controls.Add(Me.btnMark)
        Me.gbScannerSimpleMark.Controls.Add(Me.lbl12)
        Me.gbScannerSimpleMark.Controls.Add(Me.numMarkSize)
        Me.gbScannerSimpleMark.Controls.Add(Me.lbl11)
        Me.gbScannerSimpleMark.Location = New System.Drawing.Point(7, 539)
        Me.gbScannerSimpleMark.Name = "gbScannerSimpleMark"
        Me.gbScannerSimpleMark.Size = New System.Drawing.Size(328, 143)
        Me.gbScannerSimpleMark.TabIndex = 355
        Me.gbScannerSimpleMark.TabStop = False
        Me.gbScannerSimpleMark.Text = "Simple Laser Marking"
        '
        'chkMarkLineAxis
        '
        Me.chkMarkLineAxis.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMarkLineAxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMarkLineAxis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarkLineAxis.Location = New System.Drawing.Point(91, 23)
        Me.chkMarkLineAxis.Name = "chkMarkLineAxis"
        Me.chkMarkLineAxis.Size = New System.Drawing.Size(70, 30)
        Me.chkMarkLineAxis.TabIndex = 163
        Me.chkMarkLineAxis.Text = "Axis Y"
        Me.chkMarkLineAxis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkMarkLineAxis.UseVisualStyleBackColor = True
        '
        'optMarkCircle
        '
        Me.optMarkCircle.Appearance = System.Windows.Forms.Appearance.Button
        Me.optMarkCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optMarkCircle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMarkCircle.Location = New System.Drawing.Point(245, 23)
        Me.optMarkCircle.Name = "optMarkCircle"
        Me.optMarkCircle.Size = New System.Drawing.Size(70, 30)
        Me.optMarkCircle.TabIndex = 162
        Me.optMarkCircle.Text = "Circle"
        Me.optMarkCircle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optMarkCircle.UseVisualStyleBackColor = True
        '
        'optMarkRect
        '
        Me.optMarkRect.Appearance = System.Windows.Forms.Appearance.Button
        Me.optMarkRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optMarkRect.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMarkRect.Location = New System.Drawing.Point(168, 23)
        Me.optMarkRect.Name = "optMarkRect"
        Me.optMarkRect.Size = New System.Drawing.Size(70, 30)
        Me.optMarkRect.TabIndex = 161
        Me.optMarkRect.Text = "Rect"
        Me.optMarkRect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optMarkRect.UseVisualStyleBackColor = True
        '
        'optMarkLine
        '
        Me.optMarkLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.optMarkLine.Checked = True
        Me.optMarkLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optMarkLine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMarkLine.Location = New System.Drawing.Point(14, 23)
        Me.optMarkLine.Name = "optMarkLine"
        Me.optMarkLine.Size = New System.Drawing.Size(70, 30)
        Me.optMarkLine.TabIndex = 160
        Me.optMarkLine.TabStop = True
        Me.optMarkLine.Text = "Line"
        Me.optMarkLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optMarkLine.UseVisualStyleBackColor = True
        '
        'numScanRepeat
        '
        Me.numScanRepeat.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numScanRepeat.Location = New System.Drawing.Point(114, 105)
        Me.numScanRepeat.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numScanRepeat.Name = "numScanRepeat"
        Me.numScanRepeat.Size = New System.Drawing.Size(93, 23)
        Me.numScanRepeat.TabIndex = 159
        Me.numScanRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numScanRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnMark
        '
        Me.btnMark.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMark.ImageIndex = 0
        Me.btnMark.Location = New System.Drawing.Point(220, 65)
        Me.btnMark.Name = "btnMark"
        Me.btnMark.Size = New System.Drawing.Size(95, 63)
        Me.btnMark.TabIndex = 155
        Me.btnMark.Text = "Mark"
        Me.btnMark.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMark.UseVisualStyleBackColor = True
        '
        'lbl12
        '
        Me.lbl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl12.Location = New System.Drawing.Point(14, 105)
        Me.lbl12.Name = "lbl12"
        Me.lbl12.Size = New System.Drawing.Size(90, 23)
        Me.lbl12.TabIndex = 157
        Me.lbl12.Text = "Repeat[ea]"
        Me.lbl12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numMarkSize
        '
        Me.numMarkSize.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMarkSize.Location = New System.Drawing.Point(114, 65)
        Me.numMarkSize.Maximum = New Decimal(New Integer() {165500, 0, 0, 0})
        Me.numMarkSize.Name = "numMarkSize"
        Me.numMarkSize.Size = New System.Drawing.Size(93, 23)
        Me.numMarkSize.TabIndex = 154
        Me.numMarkSize.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'lbl11
        '
        Me.lbl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl11.Location = New System.Drawing.Point(14, 65)
        Me.lbl11.Name = "lbl11"
        Me.lbl11.Size = New System.Drawing.Size(90, 23)
        Me.lbl11.TabIndex = 152
        Me.lbl11.Text = "Size[um]"
        Me.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnScanParamApply
        '
        Me.btnScanParamApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScanParamApply.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanParamApply.ImageIndex = 0
        Me.btnScanParamApply.Location = New System.Drawing.Point(402, 128)
        Me.btnScanParamApply.Name = "btnScanParamApply"
        Me.btnScanParamApply.Size = New System.Drawing.Size(196, 40)
        Me.btnScanParamApply.TabIndex = 354
        Me.btnScanParamApply.Text = "Apply Scanner Parameter"
        Me.btnScanParamApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScanParamApply.UseVisualStyleBackColor = True
        '
        'gbScanStatus
        '
        Me.gbScanStatus.Controls.Add(Me.lblScanStatusY)
        Me.gbScanStatus.Controls.Add(Me.lblScanStatusX)
        Me.gbScanStatus.Controls.Add(Me.txtScanWork)
        Me.gbScanStatus.Controls.Add(Me.lblScanY1)
        Me.gbScanStatus.Controls.Add(Me.lblScanX1)
        Me.gbScanStatus.Location = New System.Drawing.Point(307, 20)
        Me.gbScanStatus.Name = "gbScanStatus"
        Me.gbScanStatus.Size = New System.Drawing.Size(291, 101)
        Me.gbScanStatus.TabIndex = 353
        Me.gbScanStatus.TabStop = False
        Me.gbScanStatus.Text = "Status"
        '
        'lblScanStatusY
        '
        Me.lblScanStatusY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScanStatusY.Location = New System.Drawing.Point(181, 30)
        Me.lblScanStatusY.Name = "lblScanStatusY"
        Me.lblScanStatusY.Size = New System.Drawing.Size(97, 21)
        Me.lblScanStatusY.TabIndex = 144
        Me.lblScanStatusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblScanStatusX
        '
        Me.lblScanStatusX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScanStatusX.Location = New System.Drawing.Point(39, 30)
        Me.lblScanStatusX.Name = "lblScanStatusX"
        Me.lblScanStatusX.Size = New System.Drawing.Size(97, 21)
        Me.lblScanStatusX.TabIndex = 143
        Me.lblScanStatusX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtScanWork
        '
        Me.txtScanWork.Enabled = False
        Me.txtScanWork.Location = New System.Drawing.Point(9, 63)
        Me.txtScanWork.Name = "txtScanWork"
        Me.txtScanWork.Size = New System.Drawing.Size(269, 23)
        Me.txtScanWork.TabIndex = 142
        '
        'lblScanY1
        '
        Me.lblScanY1.Location = New System.Drawing.Point(148, 30)
        Me.lblScanY1.Name = "lblScanY1"
        Me.lblScanY1.Size = New System.Drawing.Size(21, 21)
        Me.lblScanY1.TabIndex = 139
        Me.lblScanY1.Text = "Y"
        Me.lblScanY1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScanX1
        '
        Me.lblScanX1.Location = New System.Drawing.Point(6, 30)
        Me.lblScanX1.Name = "lblScanX1"
        Me.lblScanX1.Size = New System.Drawing.Size(21, 21)
        Me.lblScanX1.TabIndex = 127
        Me.lblScanX1.Text = "X :"
        Me.lblScanX1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbScannerAxisParam
        '
        Me.gbScannerAxisParam.Controls.Add(Me.btnScannerParamSave)
        Me.gbScannerAxisParam.Controls.Add(Me.numScanPolygonDelay)
        Me.gbScannerAxisParam.Controls.Add(Me.numScanMarkDelay)
        Me.gbScannerAxisParam.Controls.Add(Me.numScanMarkSPD)
        Me.gbScannerAxisParam.Controls.Add(Me.numScanJumpSPD)
        Me.gbScannerAxisParam.Controls.Add(Me.gbScanStatus)
        Me.gbScannerAxisParam.Controls.Add(Me.btnScanParamApply)
        Me.gbScannerAxisParam.Controls.Add(Me.numScanJumpDelay)
        Me.gbScannerAxisParam.Controls.Add(Me.lblPolyD1)
        Me.gbScannerAxisParam.Controls.Add(Me.lblMarkD1)
        Me.gbScannerAxisParam.Controls.Add(Me.lblJumpD1)
        Me.gbScannerAxisParam.Controls.Add(Me.lblMarkS1)
        Me.gbScannerAxisParam.Controls.Add(Me.lblJumpS1)
        Me.gbScannerAxisParam.Location = New System.Drawing.Point(7, 275)
        Me.gbScannerAxisParam.Name = "gbScannerAxisParam"
        Me.gbScannerAxisParam.Size = New System.Drawing.Size(608, 179)
        Me.gbScannerAxisParam.TabIndex = 351
        Me.gbScannerAxisParam.TabStop = False
        Me.gbScannerAxisParam.Text = "Scanner Axis Parameter"
        '
        'btnScannerParamSave
        '
        Me.btnScannerParamSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScannerParamSave.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScannerParamSave.ImageIndex = 0
        Me.btnScannerParamSave.Location = New System.Drawing.Point(307, 128)
        Me.btnScannerParamSave.Name = "btnScannerParamSave"
        Me.btnScannerParamSave.Size = New System.Drawing.Size(89, 40)
        Me.btnScannerParamSave.TabIndex = 360
        Me.btnScannerParamSave.Text = "save"
        Me.btnScannerParamSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScannerParamSave.UseVisualStyleBackColor = True
        '
        'numScanPolygonDelay
        '
        Me.numScanPolygonDelay.Location = New System.Drawing.Point(164, 148)
        Me.numScanPolygonDelay.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numScanPolygonDelay.Name = "numScanPolygonDelay"
        Me.numScanPolygonDelay.Size = New System.Drawing.Size(131, 23)
        Me.numScanPolygonDelay.TabIndex = 141
        Me.numScanPolygonDelay.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'numScanMarkDelay
        '
        Me.numScanMarkDelay.Location = New System.Drawing.Point(164, 118)
        Me.numScanMarkDelay.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numScanMarkDelay.Name = "numScanMarkDelay"
        Me.numScanMarkDelay.Size = New System.Drawing.Size(131, 23)
        Me.numScanMarkDelay.TabIndex = 140
        Me.numScanMarkDelay.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'numScanMarkSPD
        '
        Me.numScanMarkSPD.Location = New System.Drawing.Point(164, 58)
        Me.numScanMarkSPD.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numScanMarkSPD.Name = "numScanMarkSPD"
        Me.numScanMarkSPD.Size = New System.Drawing.Size(131, 23)
        Me.numScanMarkSPD.TabIndex = 139
        Me.numScanMarkSPD.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numScanJumpSPD
        '
        Me.numScanJumpSPD.Location = New System.Drawing.Point(164, 28)
        Me.numScanJumpSPD.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numScanJumpSPD.Name = "numScanJumpSPD"
        Me.numScanJumpSPD.Size = New System.Drawing.Size(131, 23)
        Me.numScanJumpSPD.TabIndex = 138
        Me.numScanJumpSPD.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numScanJumpDelay
        '
        Me.numScanJumpDelay.Location = New System.Drawing.Point(164, 88)
        Me.numScanJumpDelay.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numScanJumpDelay.Name = "numScanJumpDelay"
        Me.numScanJumpDelay.Size = New System.Drawing.Size(131, 23)
        Me.numScanJumpDelay.TabIndex = 137
        Me.numScanJumpDelay.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'lblPolyD1
        '
        Me.lblPolyD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPolyD1.Location = New System.Drawing.Point(18, 148)
        Me.lblPolyD1.Name = "lblPolyD1"
        Me.lblPolyD1.Size = New System.Drawing.Size(130, 21)
        Me.lblPolyD1.TabIndex = 135
        Me.lblPolyD1.Text = "Polygon Delay[us]"
        Me.lblPolyD1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMarkD1
        '
        Me.lblMarkD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMarkD1.Location = New System.Drawing.Point(18, 118)
        Me.lblMarkD1.Name = "lblMarkD1"
        Me.lblMarkD1.Size = New System.Drawing.Size(130, 21)
        Me.lblMarkD1.TabIndex = 133
        Me.lblMarkD1.Text = "Mark Delay[us]"
        Me.lblMarkD1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJumpD1
        '
        Me.lblJumpD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJumpD1.Location = New System.Drawing.Point(18, 88)
        Me.lblJumpD1.Name = "lblJumpD1"
        Me.lblJumpD1.Size = New System.Drawing.Size(130, 21)
        Me.lblJumpD1.TabIndex = 131
        Me.lblJumpD1.Text = "Jump Delay[us]"
        Me.lblJumpD1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMarkS1
        '
        Me.lblMarkS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMarkS1.Location = New System.Drawing.Point(18, 58)
        Me.lblMarkS1.Name = "lblMarkS1"
        Me.lblMarkS1.Size = New System.Drawing.Size(130, 21)
        Me.lblMarkS1.TabIndex = 129
        Me.lblMarkS1.Text = "Mark Speed[mm/s]"
        Me.lblMarkS1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblJumpS1
        '
        Me.lblJumpS1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJumpS1.Location = New System.Drawing.Point(18, 28)
        Me.lblJumpS1.Name = "lblJumpS1"
        Me.lblJumpS1.Size = New System.Drawing.Size(130, 21)
        Me.lblJumpS1.TabIndex = 127
        Me.lblJumpS1.Text = "Jump Speed[mm/s]"
        Me.lblJumpS1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numScanAngle
        '
        Me.numScanAngle.DecimalPlaces = 3
        Me.numScanAngle.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numScanAngle.Location = New System.Drawing.Point(365, 26)
        Me.numScanAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.numScanAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
        Me.numScanAngle.Name = "numScanAngle"
        Me.numScanAngle.Size = New System.Drawing.Size(62, 23)
        Me.numScanAngle.TabIndex = 350
        '
        'lblScanAngle1
        '
        Me.lblScanAngle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanAngle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanAngle1.Location = New System.Drawing.Point(245, 26)
        Me.lblScanAngle1.Name = "lblScanAngle1"
        Me.lblScanAngle1.Size = New System.Drawing.Size(114, 22)
        Me.lblScanAngle1.TabIndex = 349
        Me.lblScanAngle1.Text = "Angle :"
        '
        'btnInitScanner
        '
        Me.btnInitScanner.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInitScanner.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitScanner.ImageIndex = 0
        Me.btnInitScanner.Location = New System.Drawing.Point(148, 80)
        Me.btnInitScanner.Name = "btnInitScanner"
        Me.btnInitScanner.Size = New System.Drawing.Size(450, 42)
        Me.btnInitScanner.TabIndex = 348
        Me.btnInitScanner.Text = "Init Scanner #1"
        Me.btnInitScanner.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInitScanner.UseVisualStyleBackColor = True
        '
        'numScanBit
        '
        Me.numScanBit.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numScanBit.Location = New System.Drawing.Point(148, 25)
        Me.numScanBit.Maximum = New Decimal(New Integer() {600000, 0, 0, 0})
        Me.numScanBit.Name = "numScanBit"
        Me.numScanBit.Size = New System.Drawing.Size(62, 23)
        Me.numScanBit.TabIndex = 347
        Me.numScanBit.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'lblScanBit1
        '
        Me.lblScanBit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanBit1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanBit1.Location = New System.Drawing.Point(18, 25)
        Me.lblScanBit1.Name = "lblScanBit1"
        Me.lblScanBit1.Size = New System.Drawing.Size(114, 22)
        Me.lblScanBit1.TabIndex = 346
        Me.lblScanBit1.Text = "Bit / mm : "
        '
        'btnCorLoad
        '
        Me.btnCorLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCorLoad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorLoad.ImageIndex = 0
        Me.btnCorLoad.Location = New System.Drawing.Point(524, 45)
        Me.btnCorLoad.Name = "btnCorLoad"
        Me.btnCorLoad.Size = New System.Drawing.Size(74, 28)
        Me.btnCorLoad.TabIndex = 342
        Me.btnCorLoad.Text = "Load"
        Me.btnCorLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCorLoad.UseVisualStyleBackColor = True
        '
        'txtCorFile
        '
        Me.txtCorFile.Enabled = False
        Me.txtCorFile.Location = New System.Drawing.Point(148, 51)
        Me.txtCorFile.Name = "txtCorFile"
        Me.txtCorFile.Size = New System.Drawing.Size(370, 23)
        Me.txtCorFile.TabIndex = 341
        '
        'lblCor1
        '
        Me.lblCor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCor1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCor1.Location = New System.Drawing.Point(18, 51)
        Me.lblCor1.Name = "lblCor1"
        Me.lblCor1.Size = New System.Drawing.Size(114, 22)
        Me.lblCor1.TabIndex = 340
        Me.lblCor1.Text = "Correction File : "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnInitScanner)
        Me.GroupBox1.Controls.Add(Me.lblCor1)
        Me.GroupBox1.Controls.Add(Me.txtCorFile)
        Me.GroupBox1.Controls.Add(Me.btnCorLoad)
        Me.GroupBox1.Controls.Add(Me.numScanAngle)
        Me.GroupBox1.Controls.Add(Me.lblScanBit1)
        Me.GroupBox1.Controls.Add(Me.lblScanAngle1)
        Me.GroupBox1.Controls.Add(Me.numScanBit)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 135)
        Me.GroupBox1.TabIndex = 357
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Scanner Init"
        '
        'optUsePowerMeter
        '
        Me.optUsePowerMeter.Appearance = System.Windows.Forms.Appearance.Button
        Me.optUsePowerMeter.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.optUsePowerMeter.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.optUsePowerMeter.Location = New System.Drawing.Point(361, 500)
        Me.optUsePowerMeter.Name = "optUsePowerMeter"
        Me.optUsePowerMeter.Size = New System.Drawing.Size(244, 35)
        Me.optUsePowerMeter.TabIndex = 358
        Me.optUsePowerMeter.Text = "Use Manual PowerMeter"
        Me.optUsePowerMeter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optUsePowerMeter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(7, 500)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 23)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "ScannerY[um]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(7, 476)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 23)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "ScannerX[um]"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NumX
        '
        Me.NumX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumX.Location = New System.Drawing.Point(108, 476)
        Me.NumX.Maximum = New Decimal(New Integer() {165500, 0, 0, 0})
        Me.NumX.Name = "NumX"
        Me.NumX.Size = New System.Drawing.Size(93, 23)
        Me.NumX.TabIndex = 164
        Me.NumX.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'NumY
        '
        Me.NumY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumY.Location = New System.Drawing.Point(108, 500)
        Me.NumY.Maximum = New Decimal(New Integer() {165500, 0, 0, 0})
        Me.NumY.Name = "NumY"
        Me.NumY.Size = New System.Drawing.Size(93, 23)
        Me.NumY.TabIndex = 359
        Me.NumY.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'btnMoveX
        '
        Me.btnMoveX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMoveX.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveX.ImageIndex = 0
        Me.btnMoveX.Location = New System.Drawing.Point(207, 476)
        Me.btnMoveX.Name = "btnMoveX"
        Me.btnMoveX.Size = New System.Drawing.Size(95, 47)
        Me.btnMoveX.TabIndex = 164
        Me.btnMoveX.Text = "Move"
        Me.btnMoveX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMoveX.UseVisualStyleBackColor = True
        '
        'btnAutoSeq
        '
        Me.btnAutoSeq.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAutoSeq.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoSeq.ImageIndex = 0
        Me.btnAutoSeq.Location = New System.Drawing.Point(474, 466)
        Me.btnAutoSeq.Name = "btnAutoSeq"
        Me.btnAutoSeq.Size = New System.Drawing.Size(131, 28)
        Me.btnAutoSeq.TabIndex = 164
        Me.btnAutoSeq.Text = "Auto Focus"
        Me.btnAutoSeq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAutoSeq.UseVisualStyleBackColor = True
        '
        'ctrlSettingScanner
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnAutoSeq)
        Me.Controls.Add(Me.btnMoveX)
        Me.Controls.Add(Me.NumY)
        Me.Controls.Add(Me.NumX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.optUsePowerMeter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbScannerShotTest)
        Me.Controls.Add(Me.gbScannerLaserParam)
        Me.Controls.Add(Me.gbScannerSimpleMark)
        Me.Controls.Add(Me.gbScannerAxisParam)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Name = "ctrlSettingScanner"
        Me.Size = New System.Drawing.Size(622, 695)
        Me.gbScannerShotTest.ResumeLayout(False)
        CType(Me.numLaserOnTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbScannerLaserParam.ResumeLayout(False)
        CType(Me.numScanLaserOffDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanLaserOnDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPulseWidth2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPulseWidth1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHalfPulsePeriod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbScannerSimpleMark.ResumeLayout(False)
        CType(Me.numScanRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMarkSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbScanStatus.ResumeLayout(False)
        Me.gbScanStatus.PerformLayout()
        Me.gbScannerAxisParam.ResumeLayout(False)
        CType(Me.numScanPolygonDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanMarkDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanMarkSPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanJumpSPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanJumpDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanBit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbScannerShotTest As System.Windows.Forms.GroupBox
    Friend WithEvents btnScanShotContinousOn As System.Windows.Forms.Button
    Friend WithEvents numLaserOnTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnScanShotOff As System.Windows.Forms.Button
    Friend WithEvents btnScanShotBurstOn As System.Windows.Forms.Button
    Friend WithEvents lbl15 As System.Windows.Forms.Label
    Friend WithEvents gbScannerLaserParam As System.Windows.Forms.GroupBox
    Friend WithEvents numScanLaserOffDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblOffD1 As System.Windows.Forms.Label
    Friend WithEvents numScanLaserOnDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblOnD1 As System.Windows.Forms.Label
    Friend WithEvents numPulseWidth2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPw21 As System.Windows.Forms.Label
    Friend WithEvents numPulseWidth1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHalfPulsePeriod As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPw11 As System.Windows.Forms.Label
    Friend WithEvents lblFreq1 As System.Windows.Forms.Label
    Friend WithEvents gbScannerSimpleMark As System.Windows.Forms.GroupBox
    Friend WithEvents numScanRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnMark As System.Windows.Forms.Button
    Friend WithEvents lbl12 As System.Windows.Forms.Label
    Friend WithEvents numMarkSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl11 As System.Windows.Forms.Label
    Friend WithEvents btnScanParamApply As System.Windows.Forms.Button
    Friend WithEvents gbScanStatus As System.Windows.Forms.GroupBox
    Friend WithEvents lblScanStatusY As System.Windows.Forms.Label
    Friend WithEvents lblScanStatusX As System.Windows.Forms.Label
    Friend WithEvents txtScanWork As System.Windows.Forms.TextBox
    Friend WithEvents lblScanY1 As System.Windows.Forms.Label
    Friend WithEvents lblScanX1 As System.Windows.Forms.Label
    Friend WithEvents gbScannerAxisParam As System.Windows.Forms.GroupBox
    Friend WithEvents numScanPolygonDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScanMarkDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScanMarkSPD As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScanJumpSPD As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScanJumpDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPolyD1 As System.Windows.Forms.Label
    Friend WithEvents lblMarkD1 As System.Windows.Forms.Label
    Friend WithEvents lblJumpD1 As System.Windows.Forms.Label
    Friend WithEvents lblMarkS1 As System.Windows.Forms.Label
    Friend WithEvents lblJumpS1 As System.Windows.Forms.Label
    Friend WithEvents numScanAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblScanAngle1 As System.Windows.Forms.Label
    Friend WithEvents btnInitScanner As System.Windows.Forms.Button
    Friend WithEvents numScanBit As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblScanBit1 As System.Windows.Forms.Label
    Friend WithEvents btnCorLoad As System.Windows.Forms.Button
    Friend WithEvents txtCorFile As System.Windows.Forms.TextBox
    Friend WithEvents lblCor1 As System.Windows.Forms.Label
    Friend WithEvents chkMarkLineAxis As System.Windows.Forms.CheckBox
    Friend WithEvents optMarkCircle As System.Windows.Forms.RadioButton
    Friend WithEvents optMarkRect As System.Windows.Forms.RadioButton
    Friend WithEvents optMarkLine As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optUsePowerMeter As System.Windows.Forms.CheckBox
    Friend WithEvents btnScannerParamSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumX As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumY As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnMoveX As System.Windows.Forms.Button
    Friend WithEvents btnAutoSeq As System.Windows.Forms.Button

End Class
