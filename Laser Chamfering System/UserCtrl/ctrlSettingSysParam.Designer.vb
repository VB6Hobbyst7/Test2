<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSettingSysParam
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
        Me.components = New System.ComponentModel.Container()
        Me.gbTrimmingDelay = New System.Windows.Forms.GroupBox()
        Me.numTrimmingDelay = New System.Windows.Forms.NumericUpDown()
        Me.btnTrimmingDelay = New System.Windows.Forms.Button()
        Me.gbLogSaveDay = New System.Windows.Forms.GroupBox()
        Me.btnSaveDay = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numImageSaveDay = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.numLogSaveDay = New System.Windows.Forms.NumericUpDown()
        Me.gbScanMinSpd = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnScanSpdLimit = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.numScanJumpSpdLimit = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.numScanMarkSpdLimit = New System.Windows.Forms.NumericUpDown()
        Me.gbVisionDelay = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.numVisionAlignDelay = New System.Windows.Forms.NumericUpDown()
        Me.btnVisionAlignDelay = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.numVisionAlignRetryDelay = New System.Windows.Forms.NumericUpDown()
        Me.btnVisionAlignRetryDelay = New System.Windows.Forms.Button()
        Me.gbDustCollector = New System.Windows.Forms.GroupBox()
        Me.btnDustStopTimer = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.numDustStopTimer = New System.Windows.Forms.NumericUpDown()
        Me.btnDustCollectorRun = New System.Windows.Forms.Button()
        Me.gbSystemPort = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.numDisplacePort = New System.Windows.Forms.NumericUpDown()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.numLaser4Port = New System.Windows.Forms.NumericUpDown()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.numLaser2Port = New System.Windows.Forms.NumericUpDown()
        Me.numLaser3Port = New System.Windows.Forms.NumericUpDown()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.numLaser1Port = New System.Windows.Forms.NumericUpDown()
        Me.PowerMeter_Stage = New System.Windows.Forms.Label()
        Me.PowerMeter4 = New System.Windows.Forms.Label()
        Me.numPowerMeterport4 = New System.Windows.Forms.NumericUpDown()
        Me.numPowerMeterport_Stage = New System.Windows.Forms.NumericUpDown()
        Me.PowerMeter3 = New System.Windows.Forms.Label()
        Me.numPowerMeterport3 = New System.Windows.Forms.NumericUpDown()
        Me.PowerMeter2 = New System.Windows.Forms.Label()
        Me.numPowerMeterport2 = New System.Windows.Forms.NumericUpDown()
        Me.PowerMeter1 = New System.Windows.Forms.Label()
        Me.numPowerMeterport1 = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.numDustPort2 = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numChiller4Port = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numChiller3Port = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numChiller2Port = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.numChiller1Port = New System.Windows.Forms.NumericUpDown()
        Me.btnSetPort = New System.Windows.Forms.Button()
        Me.lbl53 = New System.Windows.Forms.Label()
        Me.numDustPort = New System.Windows.Forms.NumericUpDown()
        Me.lbl52 = New System.Windows.Forms.Label()
        Me.numLightPort = New System.Windows.Forms.NumericUpDown()
        Me.btnSystemParamSave = New System.Windows.Forms.Button()
        Me.gbSystemOffsetB = New System.Windows.Forms.GroupBox()
        Me.btnPosCalculB = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.RbtnPanelB4 = New System.Windows.Forms.RadioButton()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.RbtnPanelB3 = New System.Windows.Forms.RadioButton()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetX_B3 = New System.Windows.Forms.Label()
        Me.RbtnPanelB2 = New System.Windows.Forms.RadioButton()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.RbtnPanelB1 = New System.Windows.Forms.RadioButton()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetY_B3 = New System.Windows.Forms.Label()
        Me.BtnSeqBStop = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbMoveLaserB = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnOffsetSetB = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.btnMoveToVisionB = New System.Windows.Forms.Button()
        Me.lblSystemLineOffsetX_B4 = New System.Windows.Forms.Label()
        Me.btnLaserShotB = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnMoveToLaserB = New System.Windows.Forms.Button()
        Me.lblSystemLineOffsetY_B4 = New System.Windows.Forms.Label()
        Me.BtnSeqBStart = New System.Windows.Forms.Button()
        Me.lblSystemLineOffsetX_B2 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetX_B1 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetY_B2 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetY_B1 = New System.Windows.Forms.Label()
        Me.gbSystemFilePath = New System.Windows.Forms.GroupBox()
        Me.btnScannerSettingPath = New System.Windows.Forms.Button()
        Me.btnSystemImagePathB = New System.Windows.Forms.Button()
        Me.btnSystemImagePathA = New System.Windows.Forms.Button()
        Me.btnSystemLogPath = New System.Windows.Forms.Button()
        Me.btnSystemPath = New System.Windows.Forms.Button()
        Me.txtScannerSettingPath = New System.Windows.Forms.TextBox()
        Me.txtSystemImagePathB = New System.Windows.Forms.TextBox()
        Me.txtSystemLogPath = New System.Windows.Forms.TextBox()
        Me.txtSystemPath = New System.Windows.Forms.TextBox()
        Me.txtSystemImagePathA = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbPowerMeterTime = New System.Windows.Forms.GroupBox()
        Me.numPowerMeterTime = New System.Windows.Forms.NumericUpDown()
        Me.btnPowerMeterTime = New System.Windows.Forms.Button()
        Me.lblSystemLineOffsetY_A1 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetY_A2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetX_A1 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetY_A3 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetX_A2 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetX_A3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetY_A4 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.lblSystemLineOffsetX_A4 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.gbSystemOffsetA = New System.Windows.Forms.GroupBox()
        Me.btnPosCalculA = New System.Windows.Forms.Button()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.RbtnPanelA4 = New System.Windows.Forms.RadioButton()
        Me.RbtnPanelA3 = New System.Windows.Forms.RadioButton()
        Me.RbtnPanelA2 = New System.Windows.Forms.RadioButton()
        Me.RbtnPanelA1 = New System.Windows.Forms.RadioButton()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.BtnSeqAStop = New System.Windows.Forms.Button()
        Me.cbMoveLaserA = New System.Windows.Forms.ComboBox()
        Me.btnOffsetSetA = New System.Windows.Forms.Button()
        Me.btnMoveToVisionA = New System.Windows.Forms.Button()
        Me.btnLaserShotA = New System.Windows.Forms.Button()
        Me.btnMoveToLaserA = New System.Windows.Forms.Button()
        Me.BtnSeqAStart = New System.Windows.Forms.Button()
        Me.cbTest = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblOffsetValueLaser3_A = New System.Windows.Forms.Label()
        Me.lblOffsetValueLaser1_A = New System.Windows.Forms.Label()
        Me.lblOffsetValueLaser4_A = New System.Windows.Forms.Label()
        Me.lblOffsetValueLaser2_A = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblOffsetValueLaser3_B = New System.Windows.Forms.Label()
        Me.lblOffsetValueLaser1_B = New System.Windows.Forms.Label()
        Me.lblOffsetValueLaser4_B = New System.Windows.Forms.Label()
        Me.lblOffsetValueLaser2_B = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.RTick = New System.Windows.Forms.Timer(Me.components)
        Me.gbLaserPowerLimit = New System.Windows.Forms.GroupBox()
        Me.btnPowerLimitSave = New System.Windows.Forms.Button()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.numPowerMin = New System.Windows.Forms.NumericUpDown()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.numPowerMax = New System.Windows.Forms.NumericUpDown()
        Me.btnCamUseA = New System.Windows.Forms.Button()
        Me.btnCamUseB = New System.Windows.Forms.Button()
        Me.btnCamUse_1 = New System.Windows.Forms.Button()
        Me.btnCamUse_2 = New System.Windows.Forms.Button()
        Me.btnCamUse_3 = New System.Windows.Forms.Button()
        Me.btnCamUse_4 = New System.Windows.Forms.Button()
        Me.gbCameraUse = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.gbTrimmingDelay.SuspendLayout()
        CType(Me.numTrimmingDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLogSaveDay.SuspendLayout()
        CType(Me.numImageSaveDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLogSaveDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbScanMinSpd.SuspendLayout()
        CType(Me.numScanJumpSpdLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScanMarkSpdLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVisionDelay.SuspendLayout()
        CType(Me.numVisionAlignDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numVisionAlignRetryDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDustCollector.SuspendLayout()
        CType(Me.numDustStopTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSystemPort.SuspendLayout()
        CType(Me.numDisplacePort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLaser4Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLaser2Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLaser3Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLaser1Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPowerMeterport4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPowerMeterport_Stage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPowerMeterport3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPowerMeterport2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPowerMeterport1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDustPort2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChiller4Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChiller3Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChiller2Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChiller1Port, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDustPort, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLightPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSystemOffsetB.SuspendLayout()
        Me.gbSystemFilePath.SuspendLayout()
        Me.gbPowerMeterTime.SuspendLayout()
        CType(Me.numPowerMeterTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSystemOffsetA.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbLaserPowerLimit.SuspendLayout()
        CType(Me.numPowerMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPowerMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCameraUse.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTrimmingDelay
        '
        Me.gbTrimmingDelay.Controls.Add(Me.numTrimmingDelay)
        Me.gbTrimmingDelay.Controls.Add(Me.btnTrimmingDelay)
        Me.gbTrimmingDelay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbTrimmingDelay.Location = New System.Drawing.Point(514, 639)
        Me.gbTrimmingDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbTrimmingDelay.Name = "gbTrimmingDelay"
        Me.gbTrimmingDelay.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbTrimmingDelay.Size = New System.Drawing.Size(185, 52)
        Me.gbTrimmingDelay.TabIndex = 356
        Me.gbTrimmingDelay.TabStop = False
        Me.gbTrimmingDelay.Text = "Trimming Delay (ms)"
        '
        'numTrimmingDelay
        '
        Me.numTrimmingDelay.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numTrimmingDelay.Location = New System.Drawing.Point(44, 23)
        Me.numTrimmingDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numTrimmingDelay.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numTrimmingDelay.Name = "numTrimmingDelay"
        Me.numTrimmingDelay.Size = New System.Drawing.Size(71, 22)
        Me.numTrimmingDelay.TabIndex = 22
        Me.numTrimmingDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numTrimmingDelay.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'btnTrimmingDelay
        '
        Me.btnTrimmingDelay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTrimmingDelay.Location = New System.Drawing.Point(126, 20)
        Me.btnTrimmingDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnTrimmingDelay.Name = "btnTrimmingDelay"
        Me.btnTrimmingDelay.Size = New System.Drawing.Size(44, 27)
        Me.btnTrimmingDelay.TabIndex = 0
        Me.btnTrimmingDelay.Text = "Set"
        Me.btnTrimmingDelay.UseVisualStyleBackColor = True
        '
        'gbLogSaveDay
        '
        Me.gbLogSaveDay.Controls.Add(Me.btnSaveDay)
        Me.gbLogSaveDay.Controls.Add(Me.Label10)
        Me.gbLogSaveDay.Controls.Add(Me.numImageSaveDay)
        Me.gbLogSaveDay.Controls.Add(Me.Label23)
        Me.gbLogSaveDay.Controls.Add(Me.numLogSaveDay)
        Me.gbLogSaveDay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLogSaveDay.Location = New System.Drawing.Point(157, 704)
        Me.gbLogSaveDay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLogSaveDay.Name = "gbLogSaveDay"
        Me.gbLogSaveDay.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLogSaveDay.Size = New System.Drawing.Size(136, 107)
        Me.gbLogSaveDay.TabIndex = 355
        Me.gbLogSaveDay.TabStop = False
        Me.gbLogSaveDay.Text = "Delete After"
        '
        'btnSaveDay
        '
        Me.btnSaveDay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveDay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveDay.ImageIndex = 0
        Me.btnSaveDay.Location = New System.Drawing.Point(15, 74)
        Me.btnSaveDay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSaveDay.Name = "btnSaveDay"
        Me.btnSaveDay.Size = New System.Drawing.Size(115, 27)
        Me.btnSaveDay.TabIndex = 167
        Me.btnSaveDay.Text = "Set"
        Me.btnSaveDay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveDay.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Image :"
        '
        'numImageSaveDay
        '
        Me.numImageSaveDay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numImageSaveDay.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numImageSaveDay.Location = New System.Drawing.Point(73, 45)
        Me.numImageSaveDay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numImageSaveDay.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.numImageSaveDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numImageSaveDay.Name = "numImageSaveDay"
        Me.numImageSaveDay.Size = New System.Drawing.Size(51, 22)
        Me.numImageSaveDay.TabIndex = 35
        Me.numImageSaveDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numImageSaveDay.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(16, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 16)
        Me.Label23.TabIndex = 36
        Me.Label23.Text = "Log :"
        '
        'numLogSaveDay
        '
        Me.numLogSaveDay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLogSaveDay.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLogSaveDay.Location = New System.Drawing.Point(73, 19)
        Me.numLogSaveDay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numLogSaveDay.Maximum = New Decimal(New Integer() {365, 0, 0, 0})
        Me.numLogSaveDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLogSaveDay.Name = "numLogSaveDay"
        Me.numLogSaveDay.Size = New System.Drawing.Size(51, 22)
        Me.numLogSaveDay.TabIndex = 35
        Me.numLogSaveDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numLogSaveDay.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'gbScanMinSpd
        '
        Me.gbScanMinSpd.Controls.Add(Me.GroupBox1)
        Me.gbScanMinSpd.Controls.Add(Me.btnScanSpdLimit)
        Me.gbScanMinSpd.Controls.Add(Me.Label26)
        Me.gbScanMinSpd.Controls.Add(Me.numScanJumpSpdLimit)
        Me.gbScanMinSpd.Controls.Add(Me.Label27)
        Me.gbScanMinSpd.Controls.Add(Me.numScanMarkSpdLimit)
        Me.gbScanMinSpd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbScanMinSpd.Location = New System.Drawing.Point(298, 704)
        Me.gbScanMinSpd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbScanMinSpd.Name = "gbScanMinSpd"
        Me.gbScanMinSpd.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbScanMinSpd.Size = New System.Drawing.Size(209, 88)
        Me.gbScanMinSpd.TabIndex = 354
        Me.gbScanMinSpd.TabStop = False
        Me.gbScanMinSpd.Text = "Scanner Minimum Speed(ms)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 28)
        Me.GroupBox1.TabIndex = 168
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'btnScanSpdLimit
        '
        Me.btnScanSpdLimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScanSpdLimit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanSpdLimit.ImageIndex = 0
        Me.btnScanSpdLimit.Location = New System.Drawing.Point(129, 34)
        Me.btnScanSpdLimit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnScanSpdLimit.Name = "btnScanSpdLimit"
        Me.btnScanSpdLimit.Size = New System.Drawing.Size(65, 42)
        Me.btnScanSpdLimit.TabIndex = 167
        Me.btnScanSpdLimit.Text = "Set"
        Me.btnScanSpdLimit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScanSpdLimit.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(7, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(51, 16)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = "Jump :"
        '
        'numScanJumpSpdLimit
        '
        Me.numScanJumpSpdLimit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numScanJumpSpdLimit.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numScanJumpSpdLimit.Location = New System.Drawing.Point(60, 55)
        Me.numScanJumpSpdLimit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numScanJumpSpdLimit.Maximum = New Decimal(New Integer() {3500, 0, 0, 0})
        Me.numScanJumpSpdLimit.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numScanJumpSpdLimit.Name = "numScanJumpSpdLimit"
        Me.numScanJumpSpdLimit.Size = New System.Drawing.Size(58, 22)
        Me.numScanJumpSpdLimit.TabIndex = 35
        Me.numScanJumpSpdLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numScanJumpSpdLimit.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(7, 31)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(51, 16)
        Me.Label27.TabIndex = 36
        Me.Label27.Text = "Mark  :"
        '
        'numScanMarkSpdLimit
        '
        Me.numScanMarkSpdLimit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numScanMarkSpdLimit.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numScanMarkSpdLimit.Location = New System.Drawing.Point(60, 28)
        Me.numScanMarkSpdLimit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numScanMarkSpdLimit.Maximum = New Decimal(New Integer() {3500, 0, 0, 0})
        Me.numScanMarkSpdLimit.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numScanMarkSpdLimit.Name = "numScanMarkSpdLimit"
        Me.numScanMarkSpdLimit.Size = New System.Drawing.Size(58, 22)
        Me.numScanMarkSpdLimit.TabIndex = 35
        Me.numScanMarkSpdLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numScanMarkSpdLimit.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'gbVisionDelay
        '
        Me.gbVisionDelay.Controls.Add(Me.Label12)
        Me.gbVisionDelay.Controls.Add(Me.numVisionAlignDelay)
        Me.gbVisionDelay.Controls.Add(Me.btnVisionAlignDelay)
        Me.gbVisionDelay.Controls.Add(Me.Label19)
        Me.gbVisionDelay.Controls.Add(Me.numVisionAlignRetryDelay)
        Me.gbVisionDelay.Controls.Add(Me.btnVisionAlignRetryDelay)
        Me.gbVisionDelay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVisionDelay.Location = New System.Drawing.Point(514, 519)
        Me.gbVisionDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbVisionDelay.Name = "gbVisionDelay"
        Me.gbVisionDelay.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbVisionDelay.Size = New System.Drawing.Size(185, 76)
        Me.gbVisionDelay.TabIndex = 353
        Me.gbVisionDelay.TabStop = False
        Me.gbVisionDelay.Text = "Vision Delay (ms)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 16)
        Me.Label12.TabIndex = 325
        Me.Label12.Text = "Align :"
        '
        'numVisionAlignDelay
        '
        Me.numVisionAlignDelay.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numVisionAlignDelay.Location = New System.Drawing.Point(64, 48)
        Me.numVisionAlignDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numVisionAlignDelay.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numVisionAlignDelay.Name = "numVisionAlignDelay"
        Me.numVisionAlignDelay.Size = New System.Drawing.Size(50, 22)
        Me.numVisionAlignDelay.TabIndex = 22
        Me.numVisionAlignDelay.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'btnVisionAlignDelay
        '
        Me.btnVisionAlignDelay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVisionAlignDelay.Location = New System.Drawing.Point(126, 45)
        Me.btnVisionAlignDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVisionAlignDelay.Name = "btnVisionAlignDelay"
        Me.btnVisionAlignDelay.Size = New System.Drawing.Size(44, 24)
        Me.btnVisionAlignDelay.TabIndex = 0
        Me.btnVisionAlignDelay.Text = "Set"
        Me.btnVisionAlignDelay.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 16)
        Me.Label19.TabIndex = 324
        Me.Label19.Text = "Retry :"
        '
        'numVisionAlignRetryDelay
        '
        Me.numVisionAlignRetryDelay.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numVisionAlignRetryDelay.Location = New System.Drawing.Point(65, 19)
        Me.numVisionAlignRetryDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numVisionAlignRetryDelay.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numVisionAlignRetryDelay.Name = "numVisionAlignRetryDelay"
        Me.numVisionAlignRetryDelay.Size = New System.Drawing.Size(50, 22)
        Me.numVisionAlignRetryDelay.TabIndex = 22
        Me.numVisionAlignRetryDelay.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'btnVisionAlignRetryDelay
        '
        Me.btnVisionAlignRetryDelay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVisionAlignRetryDelay.Location = New System.Drawing.Point(126, 15)
        Me.btnVisionAlignRetryDelay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVisionAlignRetryDelay.Name = "btnVisionAlignRetryDelay"
        Me.btnVisionAlignRetryDelay.Size = New System.Drawing.Size(44, 24)
        Me.btnVisionAlignRetryDelay.TabIndex = 0
        Me.btnVisionAlignRetryDelay.Text = "Set"
        Me.btnVisionAlignRetryDelay.UseVisualStyleBackColor = True
        '
        'gbDustCollector
        '
        Me.gbDustCollector.Controls.Add(Me.btnDustStopTimer)
        Me.gbDustCollector.Controls.Add(Me.Label13)
        Me.gbDustCollector.Controls.Add(Me.numDustStopTimer)
        Me.gbDustCollector.Controls.Add(Me.btnDustCollectorRun)
        Me.gbDustCollector.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDustCollector.Location = New System.Drawing.Point(514, 690)
        Me.gbDustCollector.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbDustCollector.Name = "gbDustCollector"
        Me.gbDustCollector.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbDustCollector.Size = New System.Drawing.Size(185, 63)
        Me.gbDustCollector.TabIndex = 352
        Me.gbDustCollector.TabStop = False
        Me.gbDustCollector.Text = "DustCollector"
        '
        'btnDustStopTimer
        '
        Me.btnDustStopTimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDustStopTimer.Location = New System.Drawing.Point(90, 25)
        Me.btnDustStopTimer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDustStopTimer.Name = "btnDustStopTimer"
        Me.btnDustStopTimer.Size = New System.Drawing.Size(44, 22)
        Me.btnDustStopTimer.TabIndex = 170
        Me.btnDustStopTimer.Text = "Set"
        Me.btnDustStopTimer.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(2, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 16)
        Me.Label13.TabIndex = 169
        Me.Label13.Text = "Timer :"
        '
        'numDustStopTimer
        '
        Me.numDustStopTimer.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDustStopTimer.Location = New System.Drawing.Point(55, 25)
        Me.numDustStopTimer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numDustStopTimer.Name = "numDustStopTimer"
        Me.numDustStopTimer.Size = New System.Drawing.Size(33, 22)
        Me.numDustStopTimer.TabIndex = 168
        Me.numDustStopTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDustCollectorRun
        '
        Me.btnDustCollectorRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDustCollectorRun.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDustCollectorRun.ImageIndex = 0
        Me.btnDustCollectorRun.Location = New System.Drawing.Point(137, 25)
        Me.btnDustCollectorRun.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDustCollectorRun.Name = "btnDustCollectorRun"
        Me.btnDustCollectorRun.Size = New System.Drawing.Size(45, 23)
        Me.btnDustCollectorRun.TabIndex = 167
        Me.btnDustCollectorRun.Text = "Run"
        Me.btnDustCollectorRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDustCollectorRun.UseVisualStyleBackColor = True
        '
        'gbSystemPort
        '
        Me.gbSystemPort.Controls.Add(Me.Label29)
        Me.gbSystemPort.Controls.Add(Me.numDisplacePort)
        Me.gbSystemPort.Controls.Add(Me.Label51)
        Me.gbSystemPort.Controls.Add(Me.Label28)
        Me.gbSystemPort.Controls.Add(Me.numLaser4Port)
        Me.gbSystemPort.Controls.Add(Me.Label49)
        Me.gbSystemPort.Controls.Add(Me.numLaser2Port)
        Me.gbSystemPort.Controls.Add(Me.numLaser3Port)
        Me.gbSystemPort.Controls.Add(Me.Label25)
        Me.gbSystemPort.Controls.Add(Me.numLaser1Port)
        Me.gbSystemPort.Controls.Add(Me.PowerMeter_Stage)
        Me.gbSystemPort.Controls.Add(Me.PowerMeter4)
        Me.gbSystemPort.Controls.Add(Me.numPowerMeterport4)
        Me.gbSystemPort.Controls.Add(Me.numPowerMeterport_Stage)
        Me.gbSystemPort.Controls.Add(Me.PowerMeter3)
        Me.gbSystemPort.Controls.Add(Me.numPowerMeterport3)
        Me.gbSystemPort.Controls.Add(Me.PowerMeter2)
        Me.gbSystemPort.Controls.Add(Me.numPowerMeterport2)
        Me.gbSystemPort.Controls.Add(Me.PowerMeter1)
        Me.gbSystemPort.Controls.Add(Me.numPowerMeterport1)
        Me.gbSystemPort.Controls.Add(Me.Label21)
        Me.gbSystemPort.Controls.Add(Me.numDustPort2)
        Me.gbSystemPort.Controls.Add(Me.Label7)
        Me.gbSystemPort.Controls.Add(Me.numChiller4Port)
        Me.gbSystemPort.Controls.Add(Me.Label9)
        Me.gbSystemPort.Controls.Add(Me.numChiller3Port)
        Me.gbSystemPort.Controls.Add(Me.Label11)
        Me.gbSystemPort.Controls.Add(Me.numChiller2Port)
        Me.gbSystemPort.Controls.Add(Me.Label16)
        Me.gbSystemPort.Controls.Add(Me.numChiller1Port)
        Me.gbSystemPort.Controls.Add(Me.btnSetPort)
        Me.gbSystemPort.Controls.Add(Me.lbl53)
        Me.gbSystemPort.Controls.Add(Me.numDustPort)
        Me.gbSystemPort.Controls.Add(Me.lbl52)
        Me.gbSystemPort.Controls.Add(Me.numLightPort)
        Me.gbSystemPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSystemPort.Location = New System.Drawing.Point(18, 519)
        Me.gbSystemPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemPort.Name = "gbSystemPort"
        Me.gbSystemPort.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemPort.Size = New System.Drawing.Size(490, 186)
        Me.gbSystemPort.TabIndex = 351
        Me.gbSystemPort.TabStop = False
        Me.gbSystemPort.Text = "System Port "
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(11, 154)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(96, 22)
        Me.Label29.TabIndex = 197
        Me.Label29.Text = "Displace"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numDisplacePort
        '
        Me.numDisplacePort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDisplacePort.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDisplacePort.Location = New System.Drawing.Point(110, 154)
        Me.numDisplacePort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numDisplacePort.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numDisplacePort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDisplacePort.Name = "numDisplacePort"
        Me.numDisplacePort.Size = New System.Drawing.Size(55, 22)
        Me.numDisplacePort.TabIndex = 196
        Me.numDisplacePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numDisplacePort.Value = New Decimal(New Integer() {11, 0, 0, 0})
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(351, 50)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(60, 22)
        Me.Label51.TabIndex = 195
        Me.Label51.Text = "Laser4"
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(191, 50)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 22)
        Me.Label28.TabIndex = 195
        Me.Label28.Text = "Laser2"
        '
        'numLaser4Port
        '
        Me.numLaser4Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLaser4Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLaser4Port.Location = New System.Drawing.Point(415, 50)
        Me.numLaser4Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numLaser4Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numLaser4Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLaser4Port.Name = "numLaser4Port"
        Me.numLaser4Port.Size = New System.Drawing.Size(55, 22)
        Me.numLaser4Port.TabIndex = 194
        Me.numLaser4Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numLaser4Port.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(351, 24)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(60, 22)
        Me.Label49.TabIndex = 193
        Me.Label49.Text = "Laser3"
        '
        'numLaser2Port
        '
        Me.numLaser2Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLaser2Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLaser2Port.Location = New System.Drawing.Point(255, 50)
        Me.numLaser2Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numLaser2Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numLaser2Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLaser2Port.Name = "numLaser2Port"
        Me.numLaser2Port.Size = New System.Drawing.Size(55, 22)
        Me.numLaser2Port.TabIndex = 194
        Me.numLaser2Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numLaser2Port.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'numLaser3Port
        '
        Me.numLaser3Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLaser3Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLaser3Port.Location = New System.Drawing.Point(415, 24)
        Me.numLaser3Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numLaser3Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numLaser3Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLaser3Port.Name = "numLaser3Port"
        Me.numLaser3Port.Size = New System.Drawing.Size(55, 22)
        Me.numLaser3Port.TabIndex = 192
        Me.numLaser3Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numLaser3Port.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(191, 24)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 22)
        Me.Label25.TabIndex = 193
        Me.Label25.Text = "Laser1"
        '
        'numLaser1Port
        '
        Me.numLaser1Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLaser1Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLaser1Port.Location = New System.Drawing.Point(255, 24)
        Me.numLaser1Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numLaser1Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numLaser1Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLaser1Port.Name = "numLaser1Port"
        Me.numLaser1Port.Size = New System.Drawing.Size(55, 22)
        Me.numLaser1Port.TabIndex = 192
        Me.numLaser1Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numLaser1Port.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'PowerMeter_Stage
        '
        Me.PowerMeter_Stage.Location = New System.Drawing.Point(11, 128)
        Me.PowerMeter_Stage.Name = "PowerMeter_Stage"
        Me.PowerMeter_Stage.Size = New System.Drawing.Size(96, 22)
        Me.PowerMeter_Stage.TabIndex = 191
        Me.PowerMeter_Stage.Text = "Power_Stage"
        Me.PowerMeter_Stage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PowerMeter4
        '
        Me.PowerMeter4.Location = New System.Drawing.Point(11, 102)
        Me.PowerMeter4.Name = "PowerMeter4"
        Me.PowerMeter4.Size = New System.Drawing.Size(96, 22)
        Me.PowerMeter4.TabIndex = 189
        Me.PowerMeter4.Text = "PowerMeter4"
        Me.PowerMeter4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numPowerMeterport4
        '
        Me.numPowerMeterport4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMeterport4.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMeterport4.Location = New System.Drawing.Point(110, 102)
        Me.numPowerMeterport4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMeterport4.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numPowerMeterport4.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPowerMeterport4.Name = "numPowerMeterport4"
        Me.numPowerMeterport4.Size = New System.Drawing.Size(55, 22)
        Me.numPowerMeterport4.TabIndex = 188
        Me.numPowerMeterport4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPowerMeterport4.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'numPowerMeterport_Stage
        '
        Me.numPowerMeterport_Stage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMeterport_Stage.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMeterport_Stage.Location = New System.Drawing.Point(110, 128)
        Me.numPowerMeterport_Stage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMeterport_Stage.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numPowerMeterport_Stage.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPowerMeterport_Stage.Name = "numPowerMeterport_Stage"
        Me.numPowerMeterport_Stage.Size = New System.Drawing.Size(55, 22)
        Me.numPowerMeterport_Stage.TabIndex = 190
        Me.numPowerMeterport_Stage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPowerMeterport_Stage.Value = New Decimal(New Integer() {17, 0, 0, 0})
        '
        'PowerMeter3
        '
        Me.PowerMeter3.Location = New System.Drawing.Point(11, 76)
        Me.PowerMeter3.Name = "PowerMeter3"
        Me.PowerMeter3.Size = New System.Drawing.Size(96, 22)
        Me.PowerMeter3.TabIndex = 187
        Me.PowerMeter3.Text = "PowerMeter3"
        Me.PowerMeter3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numPowerMeterport3
        '
        Me.numPowerMeterport3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMeterport3.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMeterport3.Location = New System.Drawing.Point(110, 76)
        Me.numPowerMeterport3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMeterport3.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numPowerMeterport3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPowerMeterport3.Name = "numPowerMeterport3"
        Me.numPowerMeterport3.Size = New System.Drawing.Size(55, 22)
        Me.numPowerMeterport3.TabIndex = 186
        Me.numPowerMeterport3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPowerMeterport3.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'PowerMeter2
        '
        Me.PowerMeter2.Location = New System.Drawing.Point(11, 50)
        Me.PowerMeter2.Name = "PowerMeter2"
        Me.PowerMeter2.Size = New System.Drawing.Size(96, 22)
        Me.PowerMeter2.TabIndex = 185
        Me.PowerMeter2.Text = "PowerMeter2"
        Me.PowerMeter2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numPowerMeterport2
        '
        Me.numPowerMeterport2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMeterport2.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMeterport2.Location = New System.Drawing.Point(110, 50)
        Me.numPowerMeterport2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMeterport2.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numPowerMeterport2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPowerMeterport2.Name = "numPowerMeterport2"
        Me.numPowerMeterport2.Size = New System.Drawing.Size(55, 22)
        Me.numPowerMeterport2.TabIndex = 184
        Me.numPowerMeterport2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPowerMeterport2.Value = New Decimal(New Integer() {14, 0, 0, 0})
        '
        'PowerMeter1
        '
        Me.PowerMeter1.Location = New System.Drawing.Point(11, 24)
        Me.PowerMeter1.Name = "PowerMeter1"
        Me.PowerMeter1.Size = New System.Drawing.Size(96, 22)
        Me.PowerMeter1.TabIndex = 183
        Me.PowerMeter1.Text = "PowerMeter1"
        Me.PowerMeter1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numPowerMeterport1
        '
        Me.numPowerMeterport1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMeterport1.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMeterport1.Location = New System.Drawing.Point(110, 24)
        Me.numPowerMeterport1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMeterport1.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numPowerMeterport1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPowerMeterport1.Name = "numPowerMeterport1"
        Me.numPowerMeterport1.Size = New System.Drawing.Size(55, 22)
        Me.numPowerMeterport1.TabIndex = 182
        Me.numPowerMeterport1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPowerMeterport1.Value = New Decimal(New Integer() {13, 0, 0, 0})
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(349, 102)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 22)
        Me.Label21.TabIndex = 181
        Me.Label21.Text = "Inverter"
        '
        'numDustPort2
        '
        Me.numDustPort2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDustPort2.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDustPort2.Location = New System.Drawing.Point(415, 102)
        Me.numDustPort2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numDustPort2.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numDustPort2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDustPort2.Name = "numDustPort2"
        Me.numDustPort2.Size = New System.Drawing.Size(55, 22)
        Me.numDustPort2.TabIndex = 180
        Me.numDustPort2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numDustPort2.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(191, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 22)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "Chiller4"
        '
        'numChiller4Port
        '
        Me.numChiller4Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numChiller4Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numChiller4Port.Location = New System.Drawing.Point(255, 154)
        Me.numChiller4Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numChiller4Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numChiller4Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numChiller4Port.Name = "numChiller4Port"
        Me.numChiller4Port.Size = New System.Drawing.Size(55, 22)
        Me.numChiller4Port.TabIndex = 177
        Me.numChiller4Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numChiller4Port.Value = New Decimal(New Integer() {9, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(191, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 22)
        Me.Label9.TabIndex = 178
        Me.Label9.Text = "Chiller3"
        '
        'numChiller3Port
        '
        Me.numChiller3Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numChiller3Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numChiller3Port.Location = New System.Drawing.Point(255, 128)
        Me.numChiller3Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numChiller3Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numChiller3Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numChiller3Port.Name = "numChiller3Port"
        Me.numChiller3Port.Size = New System.Drawing.Size(55, 22)
        Me.numChiller3Port.TabIndex = 176
        Me.numChiller3Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numChiller3Port.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(191, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 22)
        Me.Label11.TabIndex = 175
        Me.Label11.Text = "Chiller2"
        '
        'numChiller2Port
        '
        Me.numChiller2Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numChiller2Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numChiller2Port.Location = New System.Drawing.Point(255, 102)
        Me.numChiller2Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numChiller2Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numChiller2Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numChiller2Port.Name = "numChiller2Port"
        Me.numChiller2Port.Size = New System.Drawing.Size(55, 22)
        Me.numChiller2Port.TabIndex = 172
        Me.numChiller2Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numChiller2Port.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(191, 76)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 22)
        Me.Label16.TabIndex = 174
        Me.Label16.Text = "Chiller1"
        '
        'numChiller1Port
        '
        Me.numChiller1Port.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numChiller1Port.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numChiller1Port.Location = New System.Drawing.Point(255, 76)
        Me.numChiller1Port.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numChiller1Port.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numChiller1Port.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numChiller1Port.Name = "numChiller1Port"
        Me.numChiller1Port.Size = New System.Drawing.Size(55, 22)
        Me.numChiller1Port.TabIndex = 173
        Me.numChiller1Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numChiller1Port.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'btnSetPort
        '
        Me.btnSetPort.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSetPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetPort.ImageIndex = 0
        Me.btnSetPort.Location = New System.Drawing.Point(357, 156)
        Me.btnSetPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetPort.Name = "btnSetPort"
        Me.btnSetPort.Size = New System.Drawing.Size(113, 27)
        Me.btnSetPort.TabIndex = 167
        Me.btnSetPort.Text = "Set Port"
        Me.btnSetPort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSetPort.UseVisualStyleBackColor = True
        '
        'lbl53
        '
        Me.lbl53.Location = New System.Drawing.Point(349, 76)
        Me.lbl53.Name = "lbl53"
        Me.lbl53.Size = New System.Drawing.Size(60, 22)
        Me.lbl53.TabIndex = 41
        Me.lbl53.Text = "Dust"
        '
        'numDustPort
        '
        Me.numDustPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDustPort.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numDustPort.Location = New System.Drawing.Point(415, 76)
        Me.numDustPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numDustPort.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numDustPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numDustPort.Name = "numDustPort"
        Me.numDustPort.Size = New System.Drawing.Size(55, 22)
        Me.numDustPort.TabIndex = 39
        Me.numDustPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numDustPort.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lbl52
        '
        Me.lbl52.Location = New System.Drawing.Point(349, 128)
        Me.lbl52.Name = "lbl52"
        Me.lbl52.Size = New System.Drawing.Size(60, 22)
        Me.lbl52.TabIndex = 40
        Me.lbl52.Text = "Light"
        '
        'numLightPort
        '
        Me.numLightPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numLightPort.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numLightPort.Location = New System.Drawing.Point(415, 128)
        Me.numLightPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numLightPort.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numLightPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLightPort.Name = "numLightPort"
        Me.numLightPort.Size = New System.Drawing.Size(55, 22)
        Me.numLightPort.TabIndex = 38
        Me.numLightPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numLightPort.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'btnSystemParamSave
        '
        Me.btnSystemParamSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSystemParamSave.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.btnSystemParamSave.ImageIndex = 0
        Me.btnSystemParamSave.Location = New System.Drawing.Point(545, 761)
        Me.btnSystemParamSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSystemParamSave.Name = "btnSystemParamSave"
        Me.btnSystemParamSave.Size = New System.Drawing.Size(154, 79)
        Me.btnSystemParamSave.TabIndex = 350
        Me.btnSystemParamSave.Text = "System Param Save"
        Me.btnSystemParamSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemParamSave.UseVisualStyleBackColor = True
        '
        'gbSystemOffsetB
        '
        Me.gbSystemOffsetB.Controls.Add(Me.btnPosCalculB)
        Me.gbSystemOffsetB.Controls.Add(Me.Label39)
        Me.gbSystemOffsetB.Controls.Add(Me.RbtnPanelB4)
        Me.gbSystemOffsetB.Controls.Add(Me.Label41)
        Me.gbSystemOffsetB.Controls.Add(Me.Label50)
        Me.gbSystemOffsetB.Controls.Add(Me.Label42)
        Me.gbSystemOffsetB.Controls.Add(Me.RbtnPanelB3)
        Me.gbSystemOffsetB.Controls.Add(Me.Label44)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetX_B3)
        Me.gbSystemOffsetB.Controls.Add(Me.RbtnPanelB2)
        Me.gbSystemOffsetB.Controls.Add(Me.Label61)
        Me.gbSystemOffsetB.Controls.Add(Me.RbtnPanelB1)
        Me.gbSystemOffsetB.Controls.Add(Me.Label37)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetY_B3)
        Me.gbSystemOffsetB.Controls.Add(Me.BtnSeqBStop)
        Me.gbSystemOffsetB.Controls.Add(Me.Label6)
        Me.gbSystemOffsetB.Controls.Add(Me.cbMoveLaserB)
        Me.gbSystemOffsetB.Controls.Add(Me.Label14)
        Me.gbSystemOffsetB.Controls.Add(Me.btnOffsetSetB)
        Me.gbSystemOffsetB.Controls.Add(Me.Label38)
        Me.gbSystemOffsetB.Controls.Add(Me.btnMoveToVisionB)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetX_B4)
        Me.gbSystemOffsetB.Controls.Add(Me.btnLaserShotB)
        Me.gbSystemOffsetB.Controls.Add(Me.Label8)
        Me.gbSystemOffsetB.Controls.Add(Me.btnMoveToLaserB)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetY_B4)
        Me.gbSystemOffsetB.Controls.Add(Me.BtnSeqBStart)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetX_B2)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetX_B1)
        Me.gbSystemOffsetB.Controls.Add(Me.Label36)
        Me.gbSystemOffsetB.Controls.Add(Me.Label40)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetY_B2)
        Me.gbSystemOffsetB.Controls.Add(Me.lblSystemLineOffsetY_B1)
        Me.gbSystemOffsetB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSystemOffsetB.Location = New System.Drawing.Point(18, 329)
        Me.gbSystemOffsetB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemOffsetB.Name = "gbSystemOffsetB"
        Me.gbSystemOffsetB.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemOffsetB.Size = New System.Drawing.Size(681, 133)
        Me.gbSystemOffsetB.TabIndex = 349
        Me.gbSystemOffsetB.TabStop = False
        Me.gbSystemOffsetB.Text = "System B-Line Offset Setting(mm)"
        '
        'btnPosCalculB
        '
        Me.btnPosCalculB.Enabled = False
        Me.btnPosCalculB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPosCalculB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPosCalculB.ImageIndex = 0
        Me.btnPosCalculB.Location = New System.Drawing.Point(542, 51)
        Me.btnPosCalculB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPosCalculB.Name = "btnPosCalculB"
        Me.btnPosCalculB.Size = New System.Drawing.Size(59, 43)
        Me.btnPosCalculB.TabIndex = 417
        Me.btnPosCalculB.Text = "Check"
        Me.btnPosCalculB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPosCalculB.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(13, 105)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(25, 16)
        Me.Label39.TabIndex = 408
        Me.Label39.Text = "B4"
        '
        'RbtnPanelB4
        '
        Me.RbtnPanelB4.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelB4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelB4.Location = New System.Drawing.Point(578, 21)
        Me.RbtnPanelB4.Name = "RbtnPanelB4"
        Me.RbtnPanelB4.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelB4.TabIndex = 416
        Me.RbtnPanelB4.TabStop = True
        Me.RbtnPanelB4.Text = "P4 to L4"
        Me.RbtnPanelB4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelB4.UseVisualStyleBackColor = True
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(13, 77)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(25, 16)
        Me.Label41.TabIndex = 407
        Me.Label41.Text = "B3"
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(150, 77)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(24, 16)
        Me.Label50.TabIndex = 359
        Me.Label50.Text = "Y :"
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(13, 49)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(25, 16)
        Me.Label42.TabIndex = 406
        Me.Label42.Text = "B2"
        '
        'RbtnPanelB3
        '
        Me.RbtnPanelB3.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelB3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelB3.Location = New System.Drawing.Point(471, 21)
        Me.RbtnPanelB3.Name = "RbtnPanelB3"
        Me.RbtnPanelB3.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelB3.TabIndex = 415
        Me.RbtnPanelB3.TabStop = True
        Me.RbtnPanelB3.Text = "P3 to L3"
        Me.RbtnPanelB3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelB3.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(13, 21)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(25, 16)
        Me.Label44.TabIndex = 405
        Me.Label44.Text = "B1"
        '
        'lblSystemLineOffsetX_B3
        '
        Me.lblSystemLineOffsetX_B3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_B3.Location = New System.Drawing.Point(74, 77)
        Me.lblSystemLineOffsetX_B3.Name = "lblSystemLineOffsetX_B3"
        Me.lblSystemLineOffsetX_B3.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_B3.TabIndex = 354
        Me.lblSystemLineOffsetX_B3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RbtnPanelB2
        '
        Me.RbtnPanelB2.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelB2.Location = New System.Drawing.Point(365, 21)
        Me.RbtnPanelB2.Name = "RbtnPanelB2"
        Me.RbtnPanelB2.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelB2.TabIndex = 414
        Me.RbtnPanelB2.TabStop = True
        Me.RbtnPanelB2.Text = "P2 to L2"
        Me.RbtnPanelB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelB2.UseVisualStyleBackColor = True
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(43, 77)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(25, 16)
        Me.Label61.TabIndex = 358
        Me.Label61.Text = "X :"
        '
        'RbtnPanelB1
        '
        Me.RbtnPanelB1.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelB1.Location = New System.Drawing.Point(259, 21)
        Me.RbtnPanelB1.Name = "RbtnPanelB1"
        Me.RbtnPanelB1.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelB1.TabIndex = 413
        Me.RbtnPanelB1.TabStop = True
        Me.RbtnPanelB1.Text = "P1 to L1"
        Me.RbtnPanelB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelB1.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.Location = New System.Drawing.Point(259, 51)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(80, 43)
        Me.Label37.TabIndex = 412
        Me.Label37.Text = "M  O  D  E"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSystemLineOffsetY_B3
        '
        Me.lblSystemLineOffsetY_B3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_B3.Location = New System.Drawing.Point(180, 77)
        Me.lblSystemLineOffsetY_B3.Name = "lblSystemLineOffsetY_B3"
        Me.lblSystemLineOffsetY_B3.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_B3.TabIndex = 357
        Me.lblSystemLineOffsetY_B3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSeqBStop
        '
        Me.BtnSeqBStop.Enabled = False
        Me.BtnSeqBStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSeqBStop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeqBStop.ImageIndex = 0
        Me.BtnSeqBStop.Location = New System.Drawing.Point(531, 96)
        Me.BtnSeqBStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSeqBStop.Name = "BtnSeqBStop"
        Me.BtnSeqBStop.Size = New System.Drawing.Size(143, 25)
        Me.BtnSeqBStop.TabIndex = 411
        Me.BtnSeqBStop.Text = "Auto Seq Stop"
        Me.BtnSeqBStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSeqBStop.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(150, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 323
        Me.Label6.Text = "Y :"
        '
        'cbMoveLaserB
        '
        Me.cbMoveLaserB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMoveLaserB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbMoveLaserB.FormattingEnabled = True
        Me.cbMoveLaserB.Items.AddRange(New Object() {"AUTO", "MANUAL"})
        Me.cbMoveLaserB.Location = New System.Drawing.Point(259, 97)
        Me.cbMoveLaserB.Name = "cbMoveLaserB"
        Me.cbMoveLaserB.Size = New System.Drawing.Size(118, 24)
        Me.cbMoveLaserB.TabIndex = 410
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(150, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 16)
        Me.Label14.TabIndex = 323
        Me.Label14.Text = "Y :"
        '
        'btnOffsetSetB
        '
        Me.btnOffsetSetB.Enabled = False
        Me.btnOffsetSetB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOffsetSetB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOffsetSetB.ImageIndex = 0
        Me.btnOffsetSetB.Location = New System.Drawing.Point(605, 51)
        Me.btnOffsetSetB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOffsetSetB.Name = "btnOffsetSetB"
        Me.btnOffsetSetB.Size = New System.Drawing.Size(69, 43)
        Me.btnOffsetSetB.TabIndex = 409
        Me.btnOffsetSetB.Text = "Set"
        Me.btnOffsetSetB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOffsetSetB.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(150, 21)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(24, 16)
        Me.Label38.TabIndex = 335
        Me.Label38.Text = "Y :"
        '
        'btnMoveToVisionB
        '
        Me.btnMoveToVisionB.Enabled = False
        Me.btnMoveToVisionB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMoveToVisionB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveToVisionB.ImageIndex = 0
        Me.btnMoveToVisionB.Location = New System.Drawing.Point(470, 51)
        Me.btnMoveToVisionB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMoveToVisionB.Name = "btnMoveToVisionB"
        Me.btnMoveToVisionB.Size = New System.Drawing.Size(69, 43)
        Me.btnMoveToVisionB.TabIndex = 407
        Me.btnMoveToVisionB.Text = "MoveToVision"
        Me.btnMoveToVisionB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMoveToVisionB.UseVisualStyleBackColor = True
        '
        'lblSystemLineOffsetX_B4
        '
        Me.lblSystemLineOffsetX_B4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_B4.Location = New System.Drawing.Point(74, 104)
        Me.lblSystemLineOffsetX_B4.Name = "lblSystemLineOffsetX_B4"
        Me.lblSystemLineOffsetX_B4.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_B4.TabIndex = 25
        Me.lblSystemLineOffsetX_B4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLaserShotB
        '
        Me.btnLaserShotB.Enabled = False
        Me.btnLaserShotB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLaserShotB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaserShotB.ImageIndex = 0
        Me.btnLaserShotB.Location = New System.Drawing.Point(412, 51)
        Me.btnLaserShotB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLaserShotB.Name = "btnLaserShotB"
        Me.btnLaserShotB.Size = New System.Drawing.Size(55, 43)
        Me.btnLaserShotB.TabIndex = 408
        Me.btnLaserShotB.Text = "Laser Shot"
        Me.btnLaserShotB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLaserShotB.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(43, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 16)
        Me.Label8.TabIndex = 322
        Me.Label8.Text = "X :"
        '
        'btnMoveToLaserB
        '
        Me.btnMoveToLaserB.Enabled = False
        Me.btnMoveToLaserB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMoveToLaserB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveToLaserB.ImageIndex = 0
        Me.btnMoveToLaserB.Location = New System.Drawing.Point(342, 51)
        Me.btnMoveToLaserB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMoveToLaserB.Name = "btnMoveToLaserB"
        Me.btnMoveToLaserB.Size = New System.Drawing.Size(67, 43)
        Me.btnMoveToLaserB.TabIndex = 406
        Me.btnMoveToLaserB.Text = "MoveToLaser"
        Me.btnMoveToLaserB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMoveToLaserB.UseVisualStyleBackColor = True
        '
        'lblSystemLineOffsetY_B4
        '
        Me.lblSystemLineOffsetY_B4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_B4.Location = New System.Drawing.Point(180, 104)
        Me.lblSystemLineOffsetY_B4.Name = "lblSystemLineOffsetY_B4"
        Me.lblSystemLineOffsetY_B4.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_B4.TabIndex = 174
        Me.lblSystemLineOffsetY_B4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSeqBStart
        '
        Me.BtnSeqBStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSeqBStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeqBStart.ImageIndex = 0
        Me.BtnSeqBStart.Location = New System.Drawing.Point(383, 96)
        Me.BtnSeqBStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSeqBStart.Name = "BtnSeqBStart"
        Me.BtnSeqBStart.Size = New System.Drawing.Size(143, 25)
        Me.BtnSeqBStart.TabIndex = 405
        Me.BtnSeqBStart.Text = "Auto Seq Start"
        Me.BtnSeqBStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSeqBStart.UseVisualStyleBackColor = True
        '
        'lblSystemLineOffsetX_B2
        '
        Me.lblSystemLineOffsetX_B2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_B2.Location = New System.Drawing.Point(74, 49)
        Me.lblSystemLineOffsetX_B2.Name = "lblSystemLineOffsetX_B2"
        Me.lblSystemLineOffsetX_B2.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_B2.TabIndex = 25
        Me.lblSystemLineOffsetX_B2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSystemLineOffsetX_B1
        '
        Me.lblSystemLineOffsetX_B1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_B1.Location = New System.Drawing.Point(74, 21)
        Me.lblSystemLineOffsetX_B1.Name = "lblSystemLineOffsetX_B1"
        Me.lblSystemLineOffsetX_B1.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_B1.TabIndex = 330
        Me.lblSystemLineOffsetX_B1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(43, 49)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(25, 16)
        Me.Label36.TabIndex = 322
        Me.Label36.Text = "X :"
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(43, 21)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(25, 16)
        Me.Label40.TabIndex = 334
        Me.Label40.Text = "X :"
        '
        'lblSystemLineOffsetY_B2
        '
        Me.lblSystemLineOffsetY_B2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_B2.Location = New System.Drawing.Point(180, 49)
        Me.lblSystemLineOffsetY_B2.Name = "lblSystemLineOffsetY_B2"
        Me.lblSystemLineOffsetY_B2.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_B2.TabIndex = 174
        Me.lblSystemLineOffsetY_B2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSystemLineOffsetY_B1
        '
        Me.lblSystemLineOffsetY_B1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_B1.Location = New System.Drawing.Point(180, 21)
        Me.lblSystemLineOffsetY_B1.Name = "lblSystemLineOffsetY_B1"
        Me.lblSystemLineOffsetY_B1.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_B1.TabIndex = 333
        Me.lblSystemLineOffsetY_B1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbSystemFilePath
        '
        Me.gbSystemFilePath.Controls.Add(Me.btnScannerSettingPath)
        Me.gbSystemFilePath.Controls.Add(Me.btnSystemImagePathB)
        Me.gbSystemFilePath.Controls.Add(Me.btnSystemImagePathA)
        Me.gbSystemFilePath.Controls.Add(Me.btnSystemLogPath)
        Me.gbSystemFilePath.Controls.Add(Me.btnSystemPath)
        Me.gbSystemFilePath.Controls.Add(Me.txtScannerSettingPath)
        Me.gbSystemFilePath.Controls.Add(Me.txtSystemImagePathB)
        Me.gbSystemFilePath.Controls.Add(Me.txtSystemLogPath)
        Me.gbSystemFilePath.Controls.Add(Me.txtSystemPath)
        Me.gbSystemFilePath.Controls.Add(Me.txtSystemImagePathA)
        Me.gbSystemFilePath.Controls.Add(Me.Label5)
        Me.gbSystemFilePath.Controls.Add(Me.Label4)
        Me.gbSystemFilePath.Controls.Add(Me.Label3)
        Me.gbSystemFilePath.Controls.Add(Me.Label2)
        Me.gbSystemFilePath.Controls.Add(Me.Label1)
        Me.gbSystemFilePath.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSystemFilePath.Location = New System.Drawing.Point(18, -2)
        Me.gbSystemFilePath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemFilePath.Name = "gbSystemFilePath"
        Me.gbSystemFilePath.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemFilePath.Size = New System.Drawing.Size(681, 146)
        Me.gbSystemFilePath.TabIndex = 347
        Me.gbSystemFilePath.TabStop = False
        Me.gbSystemFilePath.Text = "File Path"
        '
        'btnScannerSettingPath
        '
        Me.btnScannerSettingPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScannerSettingPath.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScannerSettingPath.ImageIndex = 0
        Me.btnScannerSettingPath.Location = New System.Drawing.Point(594, 118)
        Me.btnScannerSettingPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnScannerSettingPath.Name = "btnScannerSettingPath"
        Me.btnScannerSettingPath.Size = New System.Drawing.Size(80, 22)
        Me.btnScannerSettingPath.TabIndex = 166
        Me.btnScannerSettingPath.Text = "Select"
        Me.btnScannerSettingPath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScannerSettingPath.UseVisualStyleBackColor = True
        '
        'btnSystemImagePathB
        '
        Me.btnSystemImagePathB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSystemImagePathB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemImagePathB.ImageIndex = 0
        Me.btnSystemImagePathB.Location = New System.Drawing.Point(594, 94)
        Me.btnSystemImagePathB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSystemImagePathB.Name = "btnSystemImagePathB"
        Me.btnSystemImagePathB.Size = New System.Drawing.Size(80, 22)
        Me.btnSystemImagePathB.TabIndex = 165
        Me.btnSystemImagePathB.Text = "Select"
        Me.btnSystemImagePathB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemImagePathB.UseVisualStyleBackColor = True
        '
        'btnSystemImagePathA
        '
        Me.btnSystemImagePathA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSystemImagePathA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemImagePathA.ImageIndex = 0
        Me.btnSystemImagePathA.Location = New System.Drawing.Point(594, 70)
        Me.btnSystemImagePathA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSystemImagePathA.Name = "btnSystemImagePathA"
        Me.btnSystemImagePathA.Size = New System.Drawing.Size(80, 22)
        Me.btnSystemImagePathA.TabIndex = 164
        Me.btnSystemImagePathA.Text = "Select"
        Me.btnSystemImagePathA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemImagePathA.UseVisualStyleBackColor = True
        '
        'btnSystemLogPath
        '
        Me.btnSystemLogPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSystemLogPath.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemLogPath.ImageIndex = 0
        Me.btnSystemLogPath.Location = New System.Drawing.Point(594, 44)
        Me.btnSystemLogPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSystemLogPath.Name = "btnSystemLogPath"
        Me.btnSystemLogPath.Size = New System.Drawing.Size(80, 22)
        Me.btnSystemLogPath.TabIndex = 163
        Me.btnSystemLogPath.Text = "Select"
        Me.btnSystemLogPath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemLogPath.UseVisualStyleBackColor = True
        '
        'btnSystemPath
        '
        Me.btnSystemPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSystemPath.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemPath.ImageIndex = 0
        Me.btnSystemPath.Location = New System.Drawing.Point(594, 20)
        Me.btnSystemPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSystemPath.Name = "btnSystemPath"
        Me.btnSystemPath.Size = New System.Drawing.Size(80, 22)
        Me.btnSystemPath.TabIndex = 162
        Me.btnSystemPath.Text = "Select"
        Me.btnSystemPath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemPath.UseVisualStyleBackColor = True
        '
        'txtScannerSettingPath
        '
        Me.txtScannerSettingPath.Enabled = False
        Me.txtScannerSettingPath.Location = New System.Drawing.Point(192, 118)
        Me.txtScannerSettingPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtScannerSettingPath.Name = "txtScannerSettingPath"
        Me.txtScannerSettingPath.Size = New System.Drawing.Size(396, 22)
        Me.txtScannerSettingPath.TabIndex = 10
        '
        'txtSystemImagePathB
        '
        Me.txtSystemImagePathB.Enabled = False
        Me.txtSystemImagePathB.Location = New System.Drawing.Point(192, 94)
        Me.txtSystemImagePathB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSystemImagePathB.Name = "txtSystemImagePathB"
        Me.txtSystemImagePathB.Size = New System.Drawing.Size(396, 22)
        Me.txtSystemImagePathB.TabIndex = 9
        '
        'txtSystemLogPath
        '
        Me.txtSystemLogPath.Enabled = False
        Me.txtSystemLogPath.Location = New System.Drawing.Point(192, 45)
        Me.txtSystemLogPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSystemLogPath.Name = "txtSystemLogPath"
        Me.txtSystemLogPath.Size = New System.Drawing.Size(396, 22)
        Me.txtSystemLogPath.TabIndex = 8
        '
        'txtSystemPath
        '
        Me.txtSystemPath.Enabled = False
        Me.txtSystemPath.Location = New System.Drawing.Point(192, 21)
        Me.txtSystemPath.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSystemPath.Name = "txtSystemPath"
        Me.txtSystemPath.Size = New System.Drawing.Size(396, 22)
        Me.txtSystemPath.TabIndex = 7
        '
        'txtSystemImagePathA
        '
        Me.txtSystemImagePathA.Enabled = False
        Me.txtSystemImagePathA.Location = New System.Drawing.Point(192, 70)
        Me.txtSystemImagePathA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSystemImagePathA.Name = "txtSystemImagePathA"
        Me.txtSystemImagePathA.Size = New System.Drawing.Size(396, 22)
        Me.txtSystemImagePathA.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Scanner Setting Path :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "B Line Align Image Path :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "A Line Align Image Path :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "System Log Path :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "System Path :"
        '
        'gbPowerMeterTime
        '
        Me.gbPowerMeterTime.Controls.Add(Me.numPowerMeterTime)
        Me.gbPowerMeterTime.Controls.Add(Me.btnPowerMeterTime)
        Me.gbPowerMeterTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPowerMeterTime.Location = New System.Drawing.Point(514, 594)
        Me.gbPowerMeterTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbPowerMeterTime.Name = "gbPowerMeterTime"
        Me.gbPowerMeterTime.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbPowerMeterTime.Size = New System.Drawing.Size(185, 48)
        Me.gbPowerMeterTime.TabIndex = 357
        Me.gbPowerMeterTime.TabStop = False
        Me.gbPowerMeterTime.Text = "PowerMeterTime (ms)"
        '
        'numPowerMeterTime
        '
        Me.numPowerMeterTime.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMeterTime.Location = New System.Drawing.Point(44, 23)
        Me.numPowerMeterTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMeterTime.Maximum = New Decimal(New Integer() {120000, 0, 0, 0})
        Me.numPowerMeterTime.Name = "numPowerMeterTime"
        Me.numPowerMeterTime.Size = New System.Drawing.Size(71, 22)
        Me.numPowerMeterTime.TabIndex = 22
        Me.numPowerMeterTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numPowerMeterTime.Value = New Decimal(New Integer() {60000, 0, 0, 0})
        '
        'btnPowerMeterTime
        '
        Me.btnPowerMeterTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPowerMeterTime.Location = New System.Drawing.Point(126, 20)
        Me.btnPowerMeterTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPowerMeterTime.Name = "btnPowerMeterTime"
        Me.btnPowerMeterTime.Size = New System.Drawing.Size(44, 27)
        Me.btnPowerMeterTime.TabIndex = 0
        Me.btnPowerMeterTime.Text = "Set"
        Me.btnPowerMeterTime.UseVisualStyleBackColor = True
        '
        'lblSystemLineOffsetY_A1
        '
        Me.lblSystemLineOffsetY_A1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_A1.Location = New System.Drawing.Point(181, 22)
        Me.lblSystemLineOffsetY_A1.Name = "lblSystemLineOffsetY_A1"
        Me.lblSystemLineOffsetY_A1.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_A1.TabIndex = 332
        Me.lblSystemLineOffsetY_A1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSystemLineOffsetY_A2
        '
        Me.lblSystemLineOffsetY_A2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_A2.Location = New System.Drawing.Point(181, 50)
        Me.lblSystemLineOffsetY_A2.Name = "lblSystemLineOffsetY_A2"
        Me.lblSystemLineOffsetY_A2.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_A2.TabIndex = 174
        Me.lblSystemLineOffsetY_A2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(44, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 16)
        Me.Label18.TabIndex = 333
        Me.Label18.Text = "X :"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(44, 50)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(25, 16)
        Me.Label20.TabIndex = 322
        Me.Label20.Text = "X :"
        '
        'lblSystemLineOffsetX_A1
        '
        Me.lblSystemLineOffsetX_A1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_A1.Location = New System.Drawing.Point(75, 22)
        Me.lblSystemLineOffsetX_A1.Name = "lblSystemLineOffsetX_A1"
        Me.lblSystemLineOffsetX_A1.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_A1.TabIndex = 329
        Me.lblSystemLineOffsetX_A1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSystemLineOffsetY_A3
        '
        Me.lblSystemLineOffsetY_A3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_A3.Location = New System.Drawing.Point(181, 78)
        Me.lblSystemLineOffsetY_A3.Name = "lblSystemLineOffsetY_A3"
        Me.lblSystemLineOffsetY_A3.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_A3.TabIndex = 174
        Me.lblSystemLineOffsetY_A3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSystemLineOffsetX_A2
        '
        Me.lblSystemLineOffsetX_A2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_A2.Location = New System.Drawing.Point(75, 50)
        Me.lblSystemLineOffsetX_A2.Name = "lblSystemLineOffsetX_A2"
        Me.lblSystemLineOffsetX_A2.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_A2.TabIndex = 25
        Me.lblSystemLineOffsetX_A2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(44, 78)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(25, 16)
        Me.Label24.TabIndex = 322
        Me.Label24.Text = "X :"
        '
        'lblSystemLineOffsetX_A3
        '
        Me.lblSystemLineOffsetX_A3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_A3.Location = New System.Drawing.Point(75, 78)
        Me.lblSystemLineOffsetX_A3.Name = "lblSystemLineOffsetX_A3"
        Me.lblSystemLineOffsetX_A3.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_A3.TabIndex = 25
        Me.lblSystemLineOffsetX_A3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(151, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(24, 16)
        Me.Label17.TabIndex = 334
        Me.Label17.Text = "Y :"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(151, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 16)
        Me.Label15.TabIndex = 323
        Me.Label15.Text = "Y :"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(151, 78)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 16)
        Me.Label22.TabIndex = 323
        Me.Label22.Text = "Y :"
        '
        'lblSystemLineOffsetY_A4
        '
        Me.lblSystemLineOffsetY_A4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetY_A4.Location = New System.Drawing.Point(181, 105)
        Me.lblSystemLineOffsetY_A4.Name = "lblSystemLineOffsetY_A4"
        Me.lblSystemLineOffsetY_A4.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetY_A4.TabIndex = 356
        Me.lblSystemLineOffsetY_A4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(44, 105)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(25, 16)
        Me.Label43.TabIndex = 357
        Me.Label43.Text = "X :"
        '
        'lblSystemLineOffsetX_A4
        '
        Me.lblSystemLineOffsetX_A4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSystemLineOffsetX_A4.Location = New System.Drawing.Point(75, 105)
        Me.lblSystemLineOffsetX_A4.Name = "lblSystemLineOffsetX_A4"
        Me.lblSystemLineOffsetX_A4.Size = New System.Drawing.Size(70, 17)
        Me.lblSystemLineOffsetX_A4.TabIndex = 353
        Me.lblSystemLineOffsetX_A4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(151, 106)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(24, 16)
        Me.Label33.TabIndex = 358
        Me.Label33.Text = "Y :"
        '
        'gbSystemOffsetA
        '
        Me.gbSystemOffsetA.Controls.Add(Me.btnPosCalculA)
        Me.gbSystemOffsetA.Controls.Add(Me.Label35)
        Me.gbSystemOffsetA.Controls.Add(Me.Label34)
        Me.gbSystemOffsetA.Controls.Add(Me.Label32)
        Me.gbSystemOffsetA.Controls.Add(Me.Label31)
        Me.gbSystemOffsetA.Controls.Add(Me.RbtnPanelA4)
        Me.gbSystemOffsetA.Controls.Add(Me.RbtnPanelA3)
        Me.gbSystemOffsetA.Controls.Add(Me.RbtnPanelA2)
        Me.gbSystemOffsetA.Controls.Add(Me.RbtnPanelA1)
        Me.gbSystemOffsetA.Controls.Add(Me.Label30)
        Me.gbSystemOffsetA.Controls.Add(Me.BtnSeqAStop)
        Me.gbSystemOffsetA.Controls.Add(Me.cbMoveLaserA)
        Me.gbSystemOffsetA.Controls.Add(Me.btnOffsetSetA)
        Me.gbSystemOffsetA.Controls.Add(Me.btnMoveToVisionA)
        Me.gbSystemOffsetA.Controls.Add(Me.btnLaserShotA)
        Me.gbSystemOffsetA.Controls.Add(Me.btnMoveToLaserA)
        Me.gbSystemOffsetA.Controls.Add(Me.BtnSeqAStart)
        Me.gbSystemOffsetA.Controls.Add(Me.Label33)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetX_A4)
        Me.gbSystemOffsetA.Controls.Add(Me.Label43)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetY_A4)
        Me.gbSystemOffsetA.Controls.Add(Me.Label22)
        Me.gbSystemOffsetA.Controls.Add(Me.Label15)
        Me.gbSystemOffsetA.Controls.Add(Me.Label17)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetX_A3)
        Me.gbSystemOffsetA.Controls.Add(Me.Label24)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetX_A2)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetY_A3)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetX_A1)
        Me.gbSystemOffsetA.Controls.Add(Me.Label20)
        Me.gbSystemOffsetA.Controls.Add(Me.Label18)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetY_A2)
        Me.gbSystemOffsetA.Controls.Add(Me.lblSystemLineOffsetY_A1)
        Me.gbSystemOffsetA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSystemOffsetA.Location = New System.Drawing.Point(18, 143)
        Me.gbSystemOffsetA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemOffsetA.Name = "gbSystemOffsetA"
        Me.gbSystemOffsetA.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSystemOffsetA.Size = New System.Drawing.Size(681, 133)
        Me.gbSystemOffsetA.TabIndex = 348
        Me.gbSystemOffsetA.TabStop = False
        Me.gbSystemOffsetA.Text = "System A-Line Offset Setting(mm)"
        '
        'btnPosCalculA
        '
        Me.btnPosCalculA.Enabled = False
        Me.btnPosCalculA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPosCalculA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPosCalculA.ImageIndex = 0
        Me.btnPosCalculA.Location = New System.Drawing.Point(542, 52)
        Me.btnPosCalculA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPosCalculA.Name = "btnPosCalculA"
        Me.btnPosCalculA.Size = New System.Drawing.Size(59, 43)
        Me.btnPosCalculA.TabIndex = 418
        Me.btnPosCalculA.Text = "Check"
        Me.btnPosCalculA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPosCalculA.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(13, 105)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(25, 16)
        Me.Label35.TabIndex = 404
        Me.Label35.Text = "A4"
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(13, 78)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(25, 16)
        Me.Label34.TabIndex = 403
        Me.Label34.Text = "A3"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(13, 50)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(25, 16)
        Me.Label32.TabIndex = 402
        Me.Label32.Text = "A2"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(13, 22)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(25, 16)
        Me.Label31.TabIndex = 401
        Me.Label31.Text = "A1"
        '
        'RbtnPanelA4
        '
        Me.RbtnPanelA4.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelA4.Location = New System.Drawing.Point(578, 22)
        Me.RbtnPanelA4.Name = "RbtnPanelA4"
        Me.RbtnPanelA4.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelA4.TabIndex = 400
        Me.RbtnPanelA4.TabStop = True
        Me.RbtnPanelA4.Text = "P4 to L3"
        Me.RbtnPanelA4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelA4.UseVisualStyleBackColor = True
        '
        'RbtnPanelA3
        '
        Me.RbtnPanelA3.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelA3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelA3.Location = New System.Drawing.Point(471, 22)
        Me.RbtnPanelA3.Name = "RbtnPanelA3"
        Me.RbtnPanelA3.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelA3.TabIndex = 399
        Me.RbtnPanelA3.TabStop = True
        Me.RbtnPanelA3.Text = "P3 to L4"
        Me.RbtnPanelA3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelA3.UseVisualStyleBackColor = True
        '
        'RbtnPanelA2
        '
        Me.RbtnPanelA2.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelA2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelA2.Location = New System.Drawing.Point(365, 22)
        Me.RbtnPanelA2.Name = "RbtnPanelA2"
        Me.RbtnPanelA2.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelA2.TabIndex = 398
        Me.RbtnPanelA2.TabStop = True
        Me.RbtnPanelA2.Text = "P2 to L1"
        Me.RbtnPanelA2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelA2.UseVisualStyleBackColor = True
        '
        'RbtnPanelA1
        '
        Me.RbtnPanelA1.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnPanelA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnPanelA1.Location = New System.Drawing.Point(259, 22)
        Me.RbtnPanelA1.Name = "RbtnPanelA1"
        Me.RbtnPanelA1.Size = New System.Drawing.Size(96, 25)
        Me.RbtnPanelA1.TabIndex = 397
        Me.RbtnPanelA1.TabStop = True
        Me.RbtnPanelA1.Text = "P1 to L2"
        Me.RbtnPanelA1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnPanelA1.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Location = New System.Drawing.Point(259, 52)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(80, 43)
        Me.Label30.TabIndex = 396
        Me.Label30.Text = "M  O  D  E"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSeqAStop
        '
        Me.BtnSeqAStop.Enabled = False
        Me.BtnSeqAStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSeqAStop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeqAStop.ImageIndex = 0
        Me.BtnSeqAStop.Location = New System.Drawing.Point(531, 97)
        Me.BtnSeqAStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSeqAStop.Name = "BtnSeqAStop"
        Me.BtnSeqAStop.Size = New System.Drawing.Size(143, 25)
        Me.BtnSeqAStop.TabIndex = 395
        Me.BtnSeqAStop.Text = "Auto Seq Stop"
        Me.BtnSeqAStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSeqAStop.UseVisualStyleBackColor = True
        '
        'cbMoveLaserA
        '
        Me.cbMoveLaserA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMoveLaserA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbMoveLaserA.FormattingEnabled = True
        Me.cbMoveLaserA.Items.AddRange(New Object() {"AUTO", "MANUAL"})
        Me.cbMoveLaserA.Location = New System.Drawing.Point(259, 98)
        Me.cbMoveLaserA.Name = "cbMoveLaserA"
        Me.cbMoveLaserA.Size = New System.Drawing.Size(118, 24)
        Me.cbMoveLaserA.TabIndex = 394
        '
        'btnOffsetSetA
        '
        Me.btnOffsetSetA.Enabled = False
        Me.btnOffsetSetA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOffsetSetA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOffsetSetA.ImageIndex = 0
        Me.btnOffsetSetA.Location = New System.Drawing.Point(605, 52)
        Me.btnOffsetSetA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOffsetSetA.Name = "btnOffsetSetA"
        Me.btnOffsetSetA.Size = New System.Drawing.Size(69, 43)
        Me.btnOffsetSetA.TabIndex = 393
        Me.btnOffsetSetA.Text = "Set"
        Me.btnOffsetSetA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOffsetSetA.UseVisualStyleBackColor = True
        '
        'btnMoveToVisionA
        '
        Me.btnMoveToVisionA.Enabled = False
        Me.btnMoveToVisionA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMoveToVisionA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveToVisionA.ImageIndex = 0
        Me.btnMoveToVisionA.Location = New System.Drawing.Point(470, 52)
        Me.btnMoveToVisionA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMoveToVisionA.Name = "btnMoveToVisionA"
        Me.btnMoveToVisionA.Size = New System.Drawing.Size(69, 43)
        Me.btnMoveToVisionA.TabIndex = 391
        Me.btnMoveToVisionA.Text = "MoveToVision"
        Me.btnMoveToVisionA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMoveToVisionA.UseVisualStyleBackColor = True
        '
        'btnLaserShotA
        '
        Me.btnLaserShotA.Enabled = False
        Me.btnLaserShotA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLaserShotA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaserShotA.ImageIndex = 0
        Me.btnLaserShotA.Location = New System.Drawing.Point(412, 52)
        Me.btnLaserShotA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLaserShotA.Name = "btnLaserShotA"
        Me.btnLaserShotA.Size = New System.Drawing.Size(55, 43)
        Me.btnLaserShotA.TabIndex = 392
        Me.btnLaserShotA.Text = "Laser Shot"
        Me.btnLaserShotA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLaserShotA.UseVisualStyleBackColor = True
        '
        'btnMoveToLaserA
        '
        Me.btnMoveToLaserA.Enabled = False
        Me.btnMoveToLaserA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMoveToLaserA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveToLaserA.ImageIndex = 0
        Me.btnMoveToLaserA.Location = New System.Drawing.Point(342, 52)
        Me.btnMoveToLaserA.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMoveToLaserA.Name = "btnMoveToLaserA"
        Me.btnMoveToLaserA.Size = New System.Drawing.Size(67, 43)
        Me.btnMoveToLaserA.TabIndex = 390
        Me.btnMoveToLaserA.Text = "MoveToLaser"
        Me.btnMoveToLaserA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMoveToLaserA.UseVisualStyleBackColor = True
        '
        'BtnSeqAStart
        '
        Me.BtnSeqAStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSeqAStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeqAStart.ImageIndex = 0
        Me.BtnSeqAStart.Location = New System.Drawing.Point(383, 97)
        Me.BtnSeqAStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSeqAStart.Name = "BtnSeqAStart"
        Me.BtnSeqAStart.Size = New System.Drawing.Size(143, 25)
        Me.BtnSeqAStart.TabIndex = 389
        Me.BtnSeqAStart.Text = "Auto Seq Start"
        Me.BtnSeqAStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSeqAStart.UseVisualStyleBackColor = True
        '
        'cbTest
        '
        Me.cbTest.Location = New System.Drawing.Point(401, 880)
        Me.cbTest.Name = "cbTest"
        Me.cbTest.Size = New System.Drawing.Size(104, 16)
        Me.cbTest.TabIndex = 359
        Me.cbTest.Text = "Test Verion"
        Me.cbTest.UseVisualStyleBackColor = True
        Me.cbTest.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblOffsetValueLaser3_A)
        Me.GroupBox2.Controls.Add(Me.lblOffsetValueLaser1_A)
        Me.GroupBox2.Controls.Add(Me.lblOffsetValueLaser4_A)
        Me.GroupBox2.Controls.Add(Me.lblOffsetValueLaser2_A)
        Me.GroupBox2.Controls.Add(Me.Label45)
        Me.GroupBox2.Controls.Add(Me.Label46)
        Me.GroupBox2.Controls.Add(Me.Label47)
        Me.GroupBox2.Controls.Add(Me.Label48)
        Me.GroupBox2.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(18, 275)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 57)
        Me.GroupBox2.TabIndex = 360
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Crossline Offset Value(mm)"
        '
        'lblOffsetValueLaser3_A
        '
        Me.lblOffsetValueLaser3_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser3_A.Location = New System.Drawing.Point(380, 16)
        Me.lblOffsetValueLaser3_A.Name = "lblOffsetValueLaser3_A"
        Me.lblOffsetValueLaser3_A.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser3_A.TabIndex = 336
        Me.lblOffsetValueLaser3_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOffsetValueLaser1_A
        '
        Me.lblOffsetValueLaser1_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser1_A.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOffsetValueLaser1_A.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOffsetValueLaser1_A.Location = New System.Drawing.Point(70, 16)
        Me.lblOffsetValueLaser1_A.Name = "lblOffsetValueLaser1_A"
        Me.lblOffsetValueLaser1_A.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOffsetValueLaser1_A.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser1_A.TabIndex = 340
        Me.lblOffsetValueLaser1_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOffsetValueLaser4_A
        '
        Me.lblOffsetValueLaser4_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser4_A.Location = New System.Drawing.Point(535, 16)
        Me.lblOffsetValueLaser4_A.Name = "lblOffsetValueLaser4_A"
        Me.lblOffsetValueLaser4_A.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser4_A.TabIndex = 337
        Me.lblOffsetValueLaser4_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOffsetValueLaser2_A
        '
        Me.lblOffsetValueLaser2_A.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser2_A.Location = New System.Drawing.Point(225, 16)
        Me.lblOffsetValueLaser2_A.Name = "lblOffsetValueLaser2_A"
        Me.lblOffsetValueLaser2_A.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOffsetValueLaser2_A.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser2_A.TabIndex = 341
        Me.lblOffsetValueLaser2_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(500, 17)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(29, 25)
        Me.Label45.TabIndex = 339
        Me.Label45.Text = "A-4"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(194, 17)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(29, 25)
        Me.Label46.TabIndex = 343
        Me.Label46.Text = "A-2"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(349, 17)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(29, 25)
        Me.Label47.TabIndex = 338
        Me.Label47.Text = "A-3"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(39, 17)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(29, 25)
        Me.Label48.TabIndex = 342
        Me.Label48.Text = "A-1"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblOffsetValueLaser3_B)
        Me.GroupBox4.Controls.Add(Me.lblOffsetValueLaser1_B)
        Me.GroupBox4.Controls.Add(Me.lblOffsetValueLaser4_B)
        Me.GroupBox4.Controls.Add(Me.lblOffsetValueLaser2_B)
        Me.GroupBox4.Controls.Add(Me.Label54)
        Me.GroupBox4.Controls.Add(Me.Label55)
        Me.GroupBox4.Controls.Add(Me.Label56)
        Me.GroupBox4.Controls.Add(Me.Label57)
        Me.GroupBox4.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(18, 462)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(681, 57)
        Me.GroupBox4.TabIndex = 361
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Crossline Offset Value(mm)"
        '
        'lblOffsetValueLaser3_B
        '
        Me.lblOffsetValueLaser3_B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser3_B.Location = New System.Drawing.Point(380, 16)
        Me.lblOffsetValueLaser3_B.Name = "lblOffsetValueLaser3_B"
        Me.lblOffsetValueLaser3_B.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser3_B.TabIndex = 336
        Me.lblOffsetValueLaser3_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOffsetValueLaser1_B
        '
        Me.lblOffsetValueLaser1_B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser1_B.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOffsetValueLaser1_B.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOffsetValueLaser1_B.Location = New System.Drawing.Point(70, 16)
        Me.lblOffsetValueLaser1_B.Name = "lblOffsetValueLaser1_B"
        Me.lblOffsetValueLaser1_B.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOffsetValueLaser1_B.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser1_B.TabIndex = 340
        Me.lblOffsetValueLaser1_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOffsetValueLaser4_B
        '
        Me.lblOffsetValueLaser4_B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser4_B.Location = New System.Drawing.Point(535, 16)
        Me.lblOffsetValueLaser4_B.Name = "lblOffsetValueLaser4_B"
        Me.lblOffsetValueLaser4_B.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser4_B.TabIndex = 337
        Me.lblOffsetValueLaser4_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOffsetValueLaser2_B
        '
        Me.lblOffsetValueLaser2_B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOffsetValueLaser2_B.Location = New System.Drawing.Point(225, 16)
        Me.lblOffsetValueLaser2_B.Name = "lblOffsetValueLaser2_B"
        Me.lblOffsetValueLaser2_B.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOffsetValueLaser2_B.Size = New System.Drawing.Size(114, 34)
        Me.lblOffsetValueLaser2_B.TabIndex = 341
        Me.lblOffsetValueLaser2_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(500, 17)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(29, 25)
        Me.Label54.TabIndex = 339
        Me.Label54.Text = "B-4"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(194, 17)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(29, 25)
        Me.Label55.TabIndex = 343
        Me.Label55.Text = "B-2"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(349, 17)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(29, 25)
        Me.Label56.TabIndex = 338
        Me.Label56.Text = "B-3"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(39, 17)
        Me.Label57.Name = "Label57"
        Me.Label57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label57.Size = New System.Drawing.Size(29, 25)
        Me.Label57.TabIndex = 342
        Me.Label57.Text = "B-1"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RTick
        '
        Me.RTick.Interval = 300
        '
        'gbLaserPowerLimit
        '
        Me.gbLaserPowerLimit.Controls.Add(Me.btnPowerLimitSave)
        Me.gbLaserPowerLimit.Controls.Add(Me.Label52)
        Me.gbLaserPowerLimit.Controls.Add(Me.numPowerMin)
        Me.gbLaserPowerLimit.Controls.Add(Me.Label53)
        Me.gbLaserPowerLimit.Controls.Add(Me.numPowerMax)
        Me.gbLaserPowerLimit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLaserPowerLimit.Location = New System.Drawing.Point(18, 704)
        Me.gbLaserPowerLimit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLaserPowerLimit.Name = "gbLaserPowerLimit"
        Me.gbLaserPowerLimit.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbLaserPowerLimit.Size = New System.Drawing.Size(135, 107)
        Me.gbLaserPowerLimit.TabIndex = 355
        Me.gbLaserPowerLimit.TabStop = False
        Me.gbLaserPowerLimit.Text = "Power Limit"
        '
        'btnPowerLimitSave
        '
        Me.btnPowerLimitSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPowerLimitSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPowerLimitSave.ImageIndex = 0
        Me.btnPowerLimitSave.Location = New System.Drawing.Point(61, 74)
        Me.btnPowerLimitSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPowerLimitSave.Name = "btnPowerLimitSave"
        Me.btnPowerLimitSave.Size = New System.Drawing.Size(63, 28)
        Me.btnPowerLimitSave.TabIndex = 167
        Me.btnPowerLimitSave.Text = "Set"
        Me.btnPowerLimitSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPowerLimitSave.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(16, 48)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(39, 16)
        Me.Label52.TabIndex = 37
        Me.Label52.Text = "Min :"
        '
        'numPowerMin
        '
        Me.numPowerMin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMin.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMin.Location = New System.Drawing.Point(61, 45)
        Me.numPowerMin.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMin.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numPowerMin.Name = "numPowerMin"
        Me.numPowerMin.Size = New System.Drawing.Size(63, 22)
        Me.numPowerMin.TabIndex = 35
        Me.numPowerMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPowerMin.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(16, 22)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(43, 16)
        Me.Label53.TabIndex = 36
        Me.Label53.Text = "Max :"
        '
        'numPowerMax
        '
        Me.numPowerMax.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPowerMax.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPowerMax.Location = New System.Drawing.Point(61, 19)
        Me.numPowerMax.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.numPowerMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numPowerMax.Name = "numPowerMax"
        Me.numPowerMax.Size = New System.Drawing.Size(63, 22)
        Me.numPowerMax.TabIndex = 35
        Me.numPowerMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPowerMax.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'btnCamUseA
        '
        Me.btnCamUseA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCamUseA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCamUseA.Location = New System.Drawing.Point(503, 871)
        Me.btnCamUseA.Name = "btnCamUseA"
        Me.btnCamUseA.Size = New System.Drawing.Size(66, 25)
        Me.btnCamUseA.TabIndex = 362
        Me.btnCamUseA.Text = "Cam A"
        Me.btnCamUseA.UseVisualStyleBackColor = True
        Me.btnCamUseA.Visible = False
        '
        'btnCamUseB
        '
        Me.btnCamUseB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCamUseB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCamUseB.Location = New System.Drawing.Point(578, 871)
        Me.btnCamUseB.Name = "btnCamUseB"
        Me.btnCamUseB.Size = New System.Drawing.Size(62, 25)
        Me.btnCamUseB.TabIndex = 363
        Me.btnCamUseB.Text = "Cam B"
        Me.btnCamUseB.UseVisualStyleBackColor = True
        Me.btnCamUseB.Visible = False
        '
        'btnCamUse_1
        '
        Me.btnCamUse_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCamUse_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCamUse_1.Location = New System.Drawing.Point(7, 20)
        Me.btnCamUse_1.Name = "btnCamUse_1"
        Me.btnCamUse_1.Size = New System.Drawing.Size(52, 25)
        Me.btnCamUse_1.TabIndex = 365
        Me.btnCamUse_1.Text = "A1"
        Me.btnCamUse_1.UseVisualStyleBackColor = True
        '
        'btnCamUse_2
        '
        Me.btnCamUse_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCamUse_2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCamUse_2.Location = New System.Drawing.Point(63, 20)
        Me.btnCamUse_2.Name = "btnCamUse_2"
        Me.btnCamUse_2.Size = New System.Drawing.Size(52, 25)
        Me.btnCamUse_2.TabIndex = 366
        Me.btnCamUse_2.Text = "A2"
        Me.btnCamUse_2.UseVisualStyleBackColor = True
        '
        'btnCamUse_3
        '
        Me.btnCamUse_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCamUse_3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCamUse_3.Location = New System.Drawing.Point(119, 20)
        Me.btnCamUse_3.Name = "btnCamUse_3"
        Me.btnCamUse_3.Size = New System.Drawing.Size(52, 25)
        Me.btnCamUse_3.TabIndex = 367
        Me.btnCamUse_3.Text = "B1"
        Me.btnCamUse_3.UseVisualStyleBackColor = True
        '
        'btnCamUse_4
        '
        Me.btnCamUse_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCamUse_4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnCamUse_4.Location = New System.Drawing.Point(173, 20)
        Me.btnCamUse_4.Name = "btnCamUse_4"
        Me.btnCamUse_4.Size = New System.Drawing.Size(52, 25)
        Me.btnCamUse_4.TabIndex = 368
        Me.btnCamUse_4.Text = "B2"
        Me.btnCamUse_4.UseVisualStyleBackColor = True
        '
        'gbCameraUse
        '
        Me.gbCameraUse.Controls.Add(Me.GroupBox5)
        Me.gbCameraUse.Controls.Add(Me.btnCamUse_4)
        Me.gbCameraUse.Controls.Add(Me.btnCamUse_1)
        Me.gbCameraUse.Controls.Add(Me.btnCamUse_3)
        Me.gbCameraUse.Controls.Add(Me.btnCamUse_2)
        Me.gbCameraUse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCameraUse.Location = New System.Drawing.Point(298, 791)
        Me.gbCameraUse.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbCameraUse.Name = "gbCameraUse"
        Me.gbCameraUse.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbCameraUse.Size = New System.Drawing.Size(231, 51)
        Me.gbCameraUse.TabIndex = 355
        Me.gbCameraUse.TabStop = False
        Me.gbCameraUse.Text = "Camera Use"
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(2, 91)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(206, 28)
        Me.GroupBox5.TabIndex = 168
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "GroupBox5"
        '
        'ctrlSettingSysParam
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.gbCameraUse)
        Me.Controls.Add(Me.btnCamUseB)
        Me.Controls.Add(Me.btnCamUseA)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cbTest)
        Me.Controls.Add(Me.gbPowerMeterTime)
        Me.Controls.Add(Me.gbTrimmingDelay)
        Me.Controls.Add(Me.gbLaserPowerLimit)
        Me.Controls.Add(Me.gbLogSaveDay)
        Me.Controls.Add(Me.gbScanMinSpd)
        Me.Controls.Add(Me.gbVisionDelay)
        Me.Controls.Add(Me.gbDustCollector)
        Me.Controls.Add(Me.gbSystemPort)
        Me.Controls.Add(Me.btnSystemParamSave)
        Me.Controls.Add(Me.gbSystemOffsetB)
        Me.Controls.Add(Me.gbSystemOffsetA)
        Me.Controls.Add(Me.gbSystemFilePath)
        Me.Name = "ctrlSettingSysParam"
        Me.Size = New System.Drawing.Size(710, 914)
        Me.gbTrimmingDelay.ResumeLayout(False)
        CType(Me.numTrimmingDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLogSaveDay.ResumeLayout(False)
        Me.gbLogSaveDay.PerformLayout()
        CType(Me.numImageSaveDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLogSaveDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbScanMinSpd.ResumeLayout(False)
        Me.gbScanMinSpd.PerformLayout()
        CType(Me.numScanJumpSpdLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScanMarkSpdLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVisionDelay.ResumeLayout(False)
        Me.gbVisionDelay.PerformLayout()
        CType(Me.numVisionAlignDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numVisionAlignRetryDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDustCollector.ResumeLayout(False)
        Me.gbDustCollector.PerformLayout()
        CType(Me.numDustStopTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSystemPort.ResumeLayout(False)
        CType(Me.numDisplacePort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLaser4Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLaser2Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLaser3Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLaser1Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPowerMeterport4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPowerMeterport_Stage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPowerMeterport3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPowerMeterport2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPowerMeterport1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDustPort2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChiller4Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChiller3Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChiller2Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChiller1Port, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDustPort, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLightPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSystemOffsetB.ResumeLayout(False)
        Me.gbSystemFilePath.ResumeLayout(False)
        Me.gbSystemFilePath.PerformLayout()
        Me.gbPowerMeterTime.ResumeLayout(False)
        CType(Me.numPowerMeterTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSystemOffsetA.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.gbLaserPowerLimit.ResumeLayout(False)
        Me.gbLaserPowerLimit.PerformLayout()
        CType(Me.numPowerMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPowerMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCameraUse.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTrimmingDelay As System.Windows.Forms.GroupBox
    Friend WithEvents numTrimmingDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnTrimmingDelay As System.Windows.Forms.Button
    Friend WithEvents gbLogSaveDay As System.Windows.Forms.GroupBox
    Friend WithEvents btnSaveDay As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents numImageSaveDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents numLogSaveDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbScanMinSpd As System.Windows.Forms.GroupBox
    Friend WithEvents btnScanSpdLimit As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents numScanJumpSpdLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents numScanMarkSpdLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbVisionDelay As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents numVisionAlignDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnVisionAlignDelay As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents numVisionAlignRetryDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnVisionAlignRetryDelay As System.Windows.Forms.Button
    Friend WithEvents gbDustCollector As System.Windows.Forms.GroupBox
    Friend WithEvents btnDustStopTimer As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents numDustStopTimer As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnDustCollectorRun As System.Windows.Forms.Button
    Friend WithEvents gbSystemPort As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetPort As System.Windows.Forms.Button
    Friend WithEvents lbl53 As System.Windows.Forms.Label
    Friend WithEvents numDustPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl52 As System.Windows.Forms.Label
    Friend WithEvents numLightPort As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnSystemParamSave As System.Windows.Forms.Button
    Friend WithEvents gbSystemOffsetB As System.Windows.Forms.GroupBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_B3 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetY_B3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_B4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetY_B4 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_B2 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_B1 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetY_B2 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetY_B1 As System.Windows.Forms.Label
    Friend WithEvents gbSystemFilePath As System.Windows.Forms.GroupBox
    Friend WithEvents btnScannerSettingPath As System.Windows.Forms.Button
    Friend WithEvents btnSystemImagePathB As System.Windows.Forms.Button
    Friend WithEvents btnSystemImagePathA As System.Windows.Forms.Button
    Friend WithEvents btnSystemLogPath As System.Windows.Forms.Button
    Friend WithEvents btnSystemPath As System.Windows.Forms.Button
    Friend WithEvents txtScannerSettingPath As System.Windows.Forms.TextBox
    Friend WithEvents txtSystemImagePathB As System.Windows.Forms.TextBox
    Friend WithEvents txtSystemLogPath As System.Windows.Forms.TextBox
    Friend WithEvents txtSystemPath As System.Windows.Forms.TextBox
    Friend WithEvents txtSystemImagePathA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numChiller4Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numChiller3Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numChiller2Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents numChiller1Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents numDustPort2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PowerMeter4 As System.Windows.Forms.Label
    Friend WithEvents numPowerMeterport4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PowerMeter3 As System.Windows.Forms.Label
    Friend WithEvents numPowerMeterport3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PowerMeter2 As System.Windows.Forms.Label
    Friend WithEvents numPowerMeterport2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PowerMeter1 As System.Windows.Forms.Label
    Friend WithEvents numPowerMeterport1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents PowerMeter_Stage As System.Windows.Forms.Label
    Friend WithEvents numPowerMeterport_Stage As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbPowerMeterTime As System.Windows.Forms.GroupBox
    Friend WithEvents numPowerMeterTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnPowerMeterTime As System.Windows.Forms.Button
    'Friend WithEvents cbLightUse As System.Windows.Forms.CheckBox
    Friend WithEvents lblSystemLineOffsetY_A1 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetY_A2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_A1 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetY_A3 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_A2 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_A3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetY_A4 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents lblSystemLineOffsetX_A4 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents gbSystemOffsetA As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents numDisplacePort As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents numLaser2Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents numLaser1Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnSeqAStart As System.Windows.Forms.Button
    Friend WithEvents BtnSeqAStop As System.Windows.Forms.Button
    Friend WithEvents cbMoveLaserA As System.Windows.Forms.ComboBox
    Friend WithEvents btnOffsetSetA As System.Windows.Forms.Button
    Friend WithEvents btnMoveToVisionA As System.Windows.Forms.Button
    Friend WithEvents btnLaserShotA As System.Windows.Forms.Button
    Friend WithEvents btnMoveToLaserA As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents RbtnPanelA4 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnPanelA3 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnPanelA2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnPanelA1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents RbtnPanelB4 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnPanelB3 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnPanelB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnPanelB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents BtnSeqBStop As System.Windows.Forms.Button
    Friend WithEvents cbMoveLaserB As System.Windows.Forms.ComboBox
    Friend WithEvents btnOffsetSetB As System.Windows.Forms.Button
    Friend WithEvents btnMoveToVisionB As System.Windows.Forms.Button
    Friend WithEvents btnLaserShotB As System.Windows.Forms.Button
    Friend WithEvents btnMoveToLaserB As System.Windows.Forms.Button
    Friend WithEvents BtnSeqBStart As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cbTest As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOffsetValueLaser3_A As System.Windows.Forms.Label
    Friend WithEvents lblOffsetValueLaser1_A As System.Windows.Forms.Label
    Friend WithEvents lblOffsetValueLaser4_A As System.Windows.Forms.Label
    Friend WithEvents lblOffsetValueLaser2_A As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblOffsetValueLaser3_B As System.Windows.Forms.Label
    Friend WithEvents lblOffsetValueLaser1_B As System.Windows.Forms.Label
    Friend WithEvents lblOffsetValueLaser4_B As System.Windows.Forms.Label
    Friend WithEvents lblOffsetValueLaser2_B As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents numLaser4Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents numLaser3Port As System.Windows.Forms.NumericUpDown
    Friend WithEvents RTick As System.Windows.Forms.Timer
    Friend WithEvents btnPosCalculB As System.Windows.Forms.Button
    Friend WithEvents btnPosCalculA As System.Windows.Forms.Button
    Friend WithEvents gbLaserPowerLimit As System.Windows.Forms.GroupBox
    Friend WithEvents btnPowerLimitSave As System.Windows.Forms.Button
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents numPowerMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents numPowerMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnCamUseA As System.Windows.Forms.Button
    Friend WithEvents btnCamUseB As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCamUse_1 As System.Windows.Forms.Button
    Friend WithEvents btnCamUse_2 As System.Windows.Forms.Button
    Friend WithEvents btnCamUse_3 As System.Windows.Forms.Button
    Friend WithEvents btnCamUse_4 As System.Windows.Forms.Button
    Friend WithEvents gbCameraUse As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox

End Class
