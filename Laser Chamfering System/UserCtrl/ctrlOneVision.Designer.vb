<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlOneVision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlOneVision))
        Me.gbMotion = New System.Windows.Forms.GroupBox()
        Me.cmbLaser = New System.Windows.Forms.ComboBox()
        Me.numMoveScannerPosZ = New System.Windows.Forms.NumericUpDown()
        Me.numMoveCameraPosZ = New System.Windows.Forms.NumericUpDown()
        Me.numMovePosY = New System.Windows.Forms.NumericUpDown()
        Me.numMovePosX = New System.Windows.Forms.NumericUpDown()
        Me.btnAllStop = New System.Windows.Forms.Button()
        Me.btnStopScannerPosZ = New System.Windows.Forms.Button()
        Me.btnStopCameraPosZ = New System.Windows.Forms.Button()
        Me.btnStopPosY = New System.Windows.Forms.Button()
        Me.btnStopPosX = New System.Windows.Forms.Button()
        Me.btnMoveScannerPosZ = New System.Windows.Forms.Button()
        Me.btnMoveCameraPosZ = New System.Windows.Forms.Button()
        Me.btnMovePosY = New System.Windows.Forms.Button()
        Me.btnMovePosX = New System.Windows.Forms.Button()
        Me.lblStageLaser = New System.Windows.Forms.Label()
        Me.lblStageVision = New System.Windows.Forms.Label()
        Me.lblStageY = New System.Windows.Forms.Label()
        Me.lblStageX = New System.Windows.Forms.Label()
        Me.gbBinarize = New System.Windows.Forms.GroupBox()
        Me.tbBinarize = New System.Windows.Forms.TrackBar()
        Me.btnBinarize = New System.Windows.Forms.Button()
        Me.numBinarize = New System.Windows.Forms.NumericUpDown()
        Me.chkBinarize = New System.Windows.Forms.CheckBox()
        Me.lBoxResult = New System.Windows.Forms.ListBox()
        Me.gbLightCh1 = New System.Windows.Forms.GroupBox()
        Me.tbLight = New System.Windows.Forms.TrackBar()
        Me.numLight = New System.Windows.Forms.NumericUpDown()
        Me.btnMeasure = New System.Windows.Forms.Button()
        Me.btnCross = New System.Windows.Forms.Button()
        Me.pnlDisplay = New System.Windows.Forms.Panel()
        Me.BtnImgSave = New System.Windows.Forms.Button()
        Me.BtnImgLoad = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbLight2 = New System.Windows.Forms.TrackBar()
        Me.numLight2 = New System.Windows.Forms.NumericUpDown()
        Me.BtnTest = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumExposureTime = New System.Windows.Forms.NumericUpDown()
        Me.labelExposureTime = New System.Windows.Forms.Label()
        Me.btnExposureTime = New System.Windows.Forms.Button()
        Me.btnMeasureRes = New System.Windows.Forms.Button()
        Me.Use_Light_Time = New System.Windows.Forms.Button()
        Me.gbMotion.SuspendLayout()
        CType(Me.numMoveScannerPosZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMoveCameraPosZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMovePosY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMovePosX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBinarize.SuspendLayout()
        CType(Me.tbBinarize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBinarize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLightCh1.SuspendLayout()
        CType(Me.tbLight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDisplay.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tbLight2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLight2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumExposureTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbMotion
        '
        Me.gbMotion.Controls.Add(Me.cmbLaser)
        Me.gbMotion.Controls.Add(Me.numMoveScannerPosZ)
        Me.gbMotion.Controls.Add(Me.numMoveCameraPosZ)
        Me.gbMotion.Controls.Add(Me.numMovePosY)
        Me.gbMotion.Controls.Add(Me.numMovePosX)
        Me.gbMotion.Controls.Add(Me.btnAllStop)
        Me.gbMotion.Controls.Add(Me.btnStopScannerPosZ)
        Me.gbMotion.Controls.Add(Me.btnStopCameraPosZ)
        Me.gbMotion.Controls.Add(Me.btnStopPosY)
        Me.gbMotion.Controls.Add(Me.btnStopPosX)
        Me.gbMotion.Controls.Add(Me.btnMoveScannerPosZ)
        Me.gbMotion.Controls.Add(Me.btnMoveCameraPosZ)
        Me.gbMotion.Controls.Add(Me.btnMovePosY)
        Me.gbMotion.Controls.Add(Me.btnMovePosX)
        Me.gbMotion.Controls.Add(Me.lblStageLaser)
        Me.gbMotion.Controls.Add(Me.lblStageVision)
        Me.gbMotion.Controls.Add(Me.lblStageY)
        Me.gbMotion.Controls.Add(Me.lblStageX)
        Me.gbMotion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMotion.Location = New System.Drawing.Point(8, 617)
        Me.gbMotion.Name = "gbMotion"
        Me.gbMotion.Size = New System.Drawing.Size(670, 88)
        Me.gbMotion.TabIndex = 371
        Me.gbMotion.TabStop = False
        Me.gbMotion.Text = "Motion (ABS MOVE)"
        '
        'cmbLaser
        '
        Me.cmbLaser.FormattingEnabled = True
        Me.cmbLaser.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cmbLaser.Location = New System.Drawing.Point(360, 49)
        Me.cmbLaser.Name = "cmbLaser"
        Me.cmbLaser.Size = New System.Drawing.Size(46, 24)
        Me.cmbLaser.TabIndex = 358
        '
        'numMoveScannerPosZ
        '
        Me.numMoveScannerPosZ.DecimalPlaces = 3
        Me.numMoveScannerPosZ.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMoveScannerPosZ.Location = New System.Drawing.Point(412, 50)
        Me.numMoveScannerPosZ.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.numMoveScannerPosZ.Name = "numMoveScannerPosZ"
        Me.numMoveScannerPosZ.Size = New System.Drawing.Size(87, 22)
        Me.numMoveScannerPosZ.TabIndex = 349
        '
        'numMoveCameraPosZ
        '
        Me.numMoveCameraPosZ.DecimalPlaces = 3
        Me.numMoveCameraPosZ.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMoveCameraPosZ.Location = New System.Drawing.Point(412, 24)
        Me.numMoveCameraPosZ.Name = "numMoveCameraPosZ"
        Me.numMoveCameraPosZ.Size = New System.Drawing.Size(87, 22)
        Me.numMoveCameraPosZ.TabIndex = 346
        '
        'numMovePosY
        '
        Me.numMovePosY.DecimalPlaces = 3
        Me.numMovePosY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMovePosY.Location = New System.Drawing.Point(62, 49)
        Me.numMovePosY.Maximum = New Decimal(New Integer() {880, 0, 0, 0})
        Me.numMovePosY.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.numMovePosY.Name = "numMovePosY"
        Me.numMovePosY.Size = New System.Drawing.Size(87, 22)
        Me.numMovePosY.TabIndex = 343
        Me.numMovePosY.Value = New Decimal(New Integer() {10, 0, 0, -2147483648})
        '
        'numMovePosX
        '
        Me.numMovePosX.DecimalPlaces = 3
        Me.numMovePosX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMovePosX.Location = New System.Drawing.Point(62, 23)
        Me.numMovePosX.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.numMovePosX.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.numMovePosX.Name = "numMovePosX"
        Me.numMovePosX.Size = New System.Drawing.Size(87, 22)
        Me.numMovePosX.TabIndex = 1
        Me.numMovePosX.Value = New Decimal(New Integer() {10, 0, 0, -2147483648})
        '
        'btnAllStop
        '
        Me.btnAllStop.Location = New System.Drawing.Point(603, 24)
        Me.btnAllStop.Name = "btnAllStop"
        Me.btnAllStop.Size = New System.Drawing.Size(61, 49)
        Me.btnAllStop.TabIndex = 357
        Me.btnAllStop.Text = "Stop All"
        Me.btnAllStop.UseVisualStyleBackColor = True
        '
        'btnStopScannerPosZ
        '
        Me.btnStopScannerPosZ.Location = New System.Drawing.Point(552, 49)
        Me.btnStopScannerPosZ.Name = "btnStopScannerPosZ"
        Me.btnStopScannerPosZ.Size = New System.Drawing.Size(50, 24)
        Me.btnStopScannerPosZ.TabIndex = 354
        Me.btnStopScannerPosZ.Text = "Stop"
        Me.btnStopScannerPosZ.UseVisualStyleBackColor = True
        '
        'btnStopCameraPosZ
        '
        Me.btnStopCameraPosZ.Location = New System.Drawing.Point(552, 23)
        Me.btnStopCameraPosZ.Name = "btnStopCameraPosZ"
        Me.btnStopCameraPosZ.Size = New System.Drawing.Size(50, 24)
        Me.btnStopCameraPosZ.TabIndex = 353
        Me.btnStopCameraPosZ.Text = "Stop"
        Me.btnStopCameraPosZ.UseVisualStyleBackColor = True
        '
        'btnStopPosY
        '
        Me.btnStopPosY.Location = New System.Drawing.Point(212, 48)
        Me.btnStopPosY.Name = "btnStopPosY"
        Me.btnStopPosY.Size = New System.Drawing.Size(50, 24)
        Me.btnStopPosY.TabIndex = 352
        Me.btnStopPosY.Text = "Stop"
        Me.btnStopPosY.UseVisualStyleBackColor = True
        '
        'btnStopPosX
        '
        Me.btnStopPosX.Location = New System.Drawing.Point(212, 22)
        Me.btnStopPosX.Name = "btnStopPosX"
        Me.btnStopPosX.Size = New System.Drawing.Size(50, 24)
        Me.btnStopPosX.TabIndex = 351
        Me.btnStopPosX.Text = "Stop"
        Me.btnStopPosX.UseVisualStyleBackColor = True
        '
        'btnMoveScannerPosZ
        '
        Me.btnMoveScannerPosZ.Location = New System.Drawing.Point(500, 49)
        Me.btnMoveScannerPosZ.Name = "btnMoveScannerPosZ"
        Me.btnMoveScannerPosZ.Size = New System.Drawing.Size(50, 24)
        Me.btnMoveScannerPosZ.TabIndex = 350
        Me.btnMoveScannerPosZ.Text = "Move"
        Me.btnMoveScannerPosZ.UseVisualStyleBackColor = True
        '
        'btnMoveCameraPosZ
        '
        Me.btnMoveCameraPosZ.Location = New System.Drawing.Point(500, 23)
        Me.btnMoveCameraPosZ.Name = "btnMoveCameraPosZ"
        Me.btnMoveCameraPosZ.Size = New System.Drawing.Size(50, 24)
        Me.btnMoveCameraPosZ.TabIndex = 347
        Me.btnMoveCameraPosZ.Text = "Move"
        Me.btnMoveCameraPosZ.UseVisualStyleBackColor = True
        '
        'btnMovePosY
        '
        Me.btnMovePosY.Location = New System.Drawing.Point(158, 48)
        Me.btnMovePosY.Name = "btnMovePosY"
        Me.btnMovePosY.Size = New System.Drawing.Size(50, 24)
        Me.btnMovePosY.TabIndex = 344
        Me.btnMovePosY.Text = "Move"
        Me.btnMovePosY.UseVisualStyleBackColor = True
        '
        'btnMovePosX
        '
        Me.btnMovePosX.Location = New System.Drawing.Point(158, 22)
        Me.btnMovePosX.Name = "btnMovePosX"
        Me.btnMovePosX.Size = New System.Drawing.Size(50, 24)
        Me.btnMovePosX.TabIndex = 341
        Me.btnMovePosX.Text = "Move"
        Me.btnMovePosX.UseVisualStyleBackColor = True
        '
        'lblStageLaser
        '
        Me.lblStageLaser.AutoSize = True
        Me.lblStageLaser.Location = New System.Drawing.Point(264, 53)
        Me.lblStageLaser.Name = "lblStageLaser"
        Me.lblStageLaser.Size = New System.Drawing.Size(93, 16)
        Me.lblStageLaser.TabIndex = 348
        Me.lblStageLaser.Text = "Laser_Z[mm]:"
        '
        'lblStageVision
        '
        Me.lblStageVision.AutoSize = True
        Me.lblStageVision.Location = New System.Drawing.Point(264, 28)
        Me.lblStageVision.Name = "lblStageVision"
        Me.lblStageVision.Size = New System.Drawing.Size(97, 16)
        Me.lblStageVision.TabIndex = 345
        Me.lblStageVision.Text = "Vision_Z[mm]:"
        '
        'lblStageY
        '
        Me.lblStageY.AutoSize = True
        Me.lblStageY.Location = New System.Drawing.Point(9, 52)
        Me.lblStageY.Name = "lblStageY"
        Me.lblStageY.Size = New System.Drawing.Size(52, 16)
        Me.lblStageY.TabIndex = 342
        Me.lblStageY.Text = "Y[mm]:"
        '
        'lblStageX
        '
        Me.lblStageX.AutoSize = True
        Me.lblStageX.Location = New System.Drawing.Point(9, 26)
        Me.lblStageX.Name = "lblStageX"
        Me.lblStageX.Size = New System.Drawing.Size(53, 16)
        Me.lblStageX.TabIndex = 0
        Me.lblStageX.Text = "X[mm]:"
        '
        'gbBinarize
        '
        Me.gbBinarize.Controls.Add(Me.tbBinarize)
        Me.gbBinarize.Controls.Add(Me.btnBinarize)
        Me.gbBinarize.Controls.Add(Me.numBinarize)
        Me.gbBinarize.Controls.Add(Me.chkBinarize)
        Me.gbBinarize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBinarize.Location = New System.Drawing.Point(333, 237)
        Me.gbBinarize.Name = "gbBinarize"
        Me.gbBinarize.Size = New System.Drawing.Size(307, 72)
        Me.gbBinarize.TabIndex = 370
        Me.gbBinarize.TabStop = False
        Me.gbBinarize.Text = "BINARIZE"
        Me.gbBinarize.Visible = False
        '
        'tbBinarize
        '
        Me.tbBinarize.AutoSize = False
        Me.tbBinarize.Location = New System.Drawing.Point(98, 26)
        Me.tbBinarize.Maximum = 255
        Me.tbBinarize.Name = "tbBinarize"
        Me.tbBinarize.Size = New System.Drawing.Size(130, 29)
        Me.tbBinarize.TabIndex = 315
        Me.tbBinarize.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'btnBinarize
        '
        Me.btnBinarize.Location = New System.Drawing.Point(243, 43)
        Me.btnBinarize.Name = "btnBinarize"
        Me.btnBinarize.Size = New System.Drawing.Size(52, 24)
        Me.btnBinarize.TabIndex = 2
        Me.btnBinarize.Text = "Set"
        Me.btnBinarize.UseVisualStyleBackColor = True
        '
        'numBinarize
        '
        Me.numBinarize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numBinarize.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numBinarize.Location = New System.Drawing.Point(244, 21)
        Me.numBinarize.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numBinarize.Name = "numBinarize"
        Me.numBinarize.Size = New System.Drawing.Size(50, 22)
        Me.numBinarize.TabIndex = 1
        Me.numBinarize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numBinarize.Value = New Decimal(New Integer() {128, 0, 0, 0})
        '
        'chkBinarize
        '
        Me.chkBinarize.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBinarize.Location = New System.Drawing.Point(17, 21)
        Me.chkBinarize.Name = "chkBinarize"
        Me.chkBinarize.Size = New System.Drawing.Size(75, 40)
        Me.chkBinarize.TabIndex = 0
        Me.chkBinarize.Text = "Use Binarize"
        Me.chkBinarize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkBinarize.UseVisualStyleBackColor = True
        '
        'lBoxResult
        '
        Me.lBoxResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lBoxResult.FormattingEnabled = True
        Me.lBoxResult.ItemHeight = 18
        Me.lBoxResult.Location = New System.Drawing.Point(592, 503)
        Me.lBoxResult.Name = "lBoxResult"
        Me.lBoxResult.Size = New System.Drawing.Size(84, 22)
        Me.lBoxResult.TabIndex = 369
        Me.lBoxResult.Visible = False
        '
        'gbLightCh1
        '
        Me.gbLightCh1.Controls.Add(Me.tbLight)
        Me.gbLightCh1.Controls.Add(Me.numLight)
        Me.gbLightCh1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLightCh1.Location = New System.Drawing.Point(181, 525)
        Me.gbLightCh1.Name = "gbLightCh1"
        Me.gbLightCh1.Size = New System.Drawing.Size(233, 49)
        Me.gbLightCh1.TabIndex = 368
        Me.gbLightCh1.TabStop = False
        Me.gbLightCh1.Text = "BOX Light"
        '
        'tbLight
        '
        Me.tbLight.AutoSize = False
        Me.tbLight.Location = New System.Drawing.Point(10, 17)
        Me.tbLight.Maximum = 255
        Me.tbLight.Name = "tbLight"
        Me.tbLight.Size = New System.Drawing.Size(150, 29)
        Me.tbLight.TabIndex = 314
        Me.tbLight.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'numLight
        '
        Me.numLight.Location = New System.Drawing.Point(166, 21)
        Me.numLight.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numLight.Name = "numLight"
        Me.numLight.Size = New System.Drawing.Size(56, 22)
        Me.numLight.TabIndex = 315
        '
        'btnMeasure
        '
        Me.btnMeasure.BackColor = System.Drawing.Color.White
        Me.btnMeasure.FlatAppearance.BorderSize = 2
        Me.btnMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMeasure.ImageIndex = 14
        Me.btnMeasure.Location = New System.Drawing.Point(66, 525)
        Me.btnMeasure.Name = "btnMeasure"
        Me.btnMeasure.Size = New System.Drawing.Size(107, 49)
        Me.btnMeasure.TabIndex = 367
        Me.btnMeasure.TabStop = False
        Me.btnMeasure.Text = "Measure"
        Me.btnMeasure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMeasure.UseVisualStyleBackColor = False
        '
        'btnCross
        '
        Me.btnCross.BackColor = System.Drawing.Color.White
        Me.btnCross.FlatAppearance.BorderSize = 2
        Me.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCross.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCross.Image = CType(resources.GetObject("btnCross.Image"), System.Drawing.Image)
        Me.btnCross.Location = New System.Drawing.Point(8, 524)
        Me.btnCross.Name = "btnCross"
        Me.btnCross.Size = New System.Drawing.Size(52, 50)
        Me.btnCross.TabIndex = 363
        Me.btnCross.TabStop = False
        Me.btnCross.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnCross.UseVisualStyleBackColor = False
        '
        'pnlDisplay
        '
        Me.pnlDisplay.Controls.Add(Me.gbBinarize)
        Me.pnlDisplay.Location = New System.Drawing.Point(8, 0)
        Me.pnlDisplay.Name = "pnlDisplay"
        Me.pnlDisplay.Size = New System.Drawing.Size(670, 510)
        Me.pnlDisplay.TabIndex = 372
        '
        'BtnImgSave
        '
        Me.BtnImgSave.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnImgSave.Location = New System.Drawing.Point(8, 709)
        Me.BtnImgSave.Name = "BtnImgSave"
        Me.BtnImgSave.Size = New System.Drawing.Size(110, 25)
        Me.BtnImgSave.TabIndex = 373
        Me.BtnImgSave.Text = "Image Save"
        Me.BtnImgSave.UseVisualStyleBackColor = True
        Me.BtnImgSave.Visible = False
        '
        'BtnImgLoad
        '
        Me.BtnImgLoad.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnImgLoad.Location = New System.Drawing.Point(124, 709)
        Me.BtnImgLoad.Name = "BtnImgLoad"
        Me.BtnImgLoad.Size = New System.Drawing.Size(110, 25)
        Me.BtnImgLoad.TabIndex = 374
        Me.BtnImgLoad.Text = "Image Load"
        Me.BtnImgLoad.UseVisualStyleBackColor = True
        Me.BtnImgLoad.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbLight2)
        Me.GroupBox1.Controls.Add(Me.numLight2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(442, 525)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(233, 49)
        Me.GroupBox1.TabIndex = 369
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SPOT Light"
        '
        'tbLight2
        '
        Me.tbLight2.AutoSize = False
        Me.tbLight2.Location = New System.Drawing.Point(10, 17)
        Me.tbLight2.Maximum = 255
        Me.tbLight2.Name = "tbLight2"
        Me.tbLight2.Size = New System.Drawing.Size(150, 29)
        Me.tbLight2.TabIndex = 314
        Me.tbLight2.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'numLight2
        '
        Me.numLight2.Location = New System.Drawing.Point(166, 21)
        Me.numLight2.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numLight2.Name = "numLight2"
        Me.numLight2.Size = New System.Drawing.Size(56, 22)
        Me.numLight2.TabIndex = 315
        '
        'BtnTest
        '
        Me.BtnTest.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnTest.Location = New System.Drawing.Point(255, 709)
        Me.BtnTest.Name = "BtnTest"
        Me.BtnTest.Size = New System.Drawing.Size(110, 25)
        Me.BtnTest.TabIndex = 376
        Me.BtnTest.Text = "Test"
        Me.BtnTest.UseVisualStyleBackColor = True
        Me.BtnTest.Visible = False
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(255, 590)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 25)
        Me.Label1.TabIndex = 359
        Me.Label1.Text = "ExposureTime[Sec]"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'NumExposureTime
        '
        Me.NumExposureTime.DecimalPlaces = 3
        Me.NumExposureTime.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.NumExposureTime.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumExposureTime.Location = New System.Drawing.Point(519, 590)
        Me.NumExposureTime.Name = "NumExposureTime"
        Me.NumExposureTime.Size = New System.Drawing.Size(87, 25)
        Me.NumExposureTime.TabIndex = 359
        Me.NumExposureTime.Visible = False
        '
        'labelExposureTime
        '
        Me.labelExposureTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelExposureTime.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.labelExposureTime.Location = New System.Drawing.Point(387, 590)
        Me.labelExposureTime.Name = "labelExposureTime"
        Me.labelExposureTime.Size = New System.Drawing.Size(127, 25)
        Me.labelExposureTime.TabIndex = 377
        Me.labelExposureTime.Text = "---"
        Me.labelExposureTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.labelExposureTime.Visible = False
        '
        'btnExposureTime
        '
        Me.btnExposureTime.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnExposureTime.Location = New System.Drawing.Point(611, 590)
        Me.btnExposureTime.Name = "btnExposureTime"
        Me.btnExposureTime.Size = New System.Drawing.Size(61, 25)
        Me.btnExposureTime.TabIndex = 359
        Me.btnExposureTime.Text = "Save"
        Me.btnExposureTime.UseVisualStyleBackColor = True
        Me.btnExposureTime.Visible = False
        '
        'btnMeasureRes
        '
        Me.btnMeasureRes.Location = New System.Drawing.Point(527, 711)
        Me.btnMeasureRes.Name = "btnMeasureRes"
        Me.btnMeasureRes.Size = New System.Drawing.Size(145, 26)
        Me.btnMeasureRes.TabIndex = 379
        Me.btnMeasureRes.Text = "Measure Resolution"
        Me.btnMeasureRes.UseVisualStyleBackColor = True
        Me.btnMeasureRes.Visible = False
        '
        'Use_Light_Time
        '
        Me.Use_Light_Time.Location = New System.Drawing.Point(387, 709)
        Me.Use_Light_Time.Name = "Use_Light_Time"
        Me.Use_Light_Time.Size = New System.Drawing.Size(110, 25)
        Me.Use_Light_Time.TabIndex = 380
        Me.Use_Light_Time.Text = "Use Light Time"
        Me.Use_Light_Time.UseVisualStyleBackColor = True
        Me.Use_Light_Time.Visible = False
        '
        'ctrlOneVision
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Use_Light_Time)
        Me.Controls.Add(Me.btnMeasureRes)
        Me.Controls.Add(Me.btnExposureTime)
        Me.Controls.Add(Me.labelExposureTime)
        Me.Controls.Add(Me.NumExposureTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnTest)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnImgLoad)
        Me.Controls.Add(Me.BtnImgSave)
        Me.Controls.Add(Me.pnlDisplay)
        Me.Controls.Add(Me.gbMotion)
        Me.Controls.Add(Me.gbLightCh1)
        Me.Controls.Add(Me.lBoxResult)
        Me.Controls.Add(Me.btnMeasure)
        Me.Controls.Add(Me.btnCross)
        Me.Name = "ctrlOneVision"
        Me.Size = New System.Drawing.Size(684, 800)
        Me.gbMotion.ResumeLayout(False)
        Me.gbMotion.PerformLayout()
        CType(Me.numMoveScannerPosZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMoveCameraPosZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMovePosY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMovePosX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBinarize.ResumeLayout(False)
        CType(Me.tbBinarize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBinarize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLightCh1.ResumeLayout(False)
        CType(Me.tbLight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDisplay.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tbLight2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLight2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumExposureTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbMotion As System.Windows.Forms.GroupBox
    Friend WithEvents btnAllStop As System.Windows.Forms.Button
    Friend WithEvents btnStopScannerPosZ As System.Windows.Forms.Button
    Friend WithEvents btnStopCameraPosZ As System.Windows.Forms.Button
    Friend WithEvents btnStopPosY As System.Windows.Forms.Button
    Friend WithEvents btnStopPosX As System.Windows.Forms.Button
    Friend WithEvents btnMoveScannerPosZ As System.Windows.Forms.Button
    Friend WithEvents numMoveScannerPosZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStageLaser As System.Windows.Forms.Label
    Friend WithEvents btnMoveCameraPosZ As System.Windows.Forms.Button
    Friend WithEvents numMoveCameraPosZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStageVision As System.Windows.Forms.Label
    Friend WithEvents btnMovePosY As System.Windows.Forms.Button
    Friend WithEvents numMovePosY As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStageY As System.Windows.Forms.Label
    Friend WithEvents btnMovePosX As System.Windows.Forms.Button
    Friend WithEvents numMovePosX As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblStageX As System.Windows.Forms.Label
    Friend WithEvents gbBinarize As System.Windows.Forms.GroupBox
    Friend WithEvents tbBinarize As System.Windows.Forms.TrackBar
    Friend WithEvents btnBinarize As System.Windows.Forms.Button
    Friend WithEvents numBinarize As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkBinarize As System.Windows.Forms.CheckBox
    Friend WithEvents lBoxResult As System.Windows.Forms.ListBox
    Friend WithEvents gbLightCh1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbLight As System.Windows.Forms.TrackBar
    Friend WithEvents numLight As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnMeasure As System.Windows.Forms.Button
    Friend WithEvents btnCross As System.Windows.Forms.Button
    Friend WithEvents cmbLaser As System.Windows.Forms.ComboBox
    Friend WithEvents pnlDisplay As System.Windows.Forms.Panel
    Friend WithEvents BtnImgSave As System.Windows.Forms.Button
    Friend WithEvents BtnImgLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbLight2 As System.Windows.Forms.TrackBar
    Friend WithEvents numLight2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnTest As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumExposureTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents labelExposureTime As System.Windows.Forms.Label
    Friend WithEvents btnExposureTime As System.Windows.Forms.Button
    Friend WithEvents btnMeasureRes As System.Windows.Forms.Button
    Friend WithEvents Use_Light_Time As System.Windows.Forms.Button

End Class
