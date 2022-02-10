<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTopMenu
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.lblCurDate = New System.Windows.Forms.Label()
        Me.lblCurTime = New System.Windows.Forms.Label()
        Me.lbAccount = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnInit = New System.Windows.Forms.Button()
        Me.btnMain = New System.Windows.Forms.Button()
        Me.btnRecipe = New System.Windows.Forms.Button()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.tmTopeMenu = New System.Windows.Forms.Timer(Me.components)
        Me.lblAuto_Manual_A = New System.Windows.Forms.Label()
        Me.lblSystemStatus = New System.Windows.Forms.Label()
        Me.lblCurCpuTemp_3 = New System.Windows.Forms.Label()
        Me.lblCpu_3 = New System.Windows.Forms.Label()
        Me.lblCurCpuTemp_4 = New System.Windows.Forms.Label()
        Me.lblCpu_4 = New System.Windows.Forms.Label()
        Me.lblCurCpuTemp_2 = New System.Windows.Forms.Label()
        Me.lblCpu_2 = New System.Windows.Forms.Label()
        Me.lblCurCpuTemp_1 = New System.Windows.Forms.Label()
        Me.lblCpu_1 = New System.Windows.Forms.Label()
        Me.lblAuto_Manual_B = New System.Windows.Forms.Label()
        Me.lblMoveStage_A = New System.Windows.Forms.Label()
        Me.lblModelNum = New System.Windows.Forms.Label()
        Me.btnLogIn = New System.Windows.Forms.Button()
        Me.BtnKorea = New System.Windows.Forms.Button()
        Me.BtnEng = New System.Windows.Forms.Button()
        Me.BtnVietnam = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCurDate
        '
        Me.lblCurDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCurDate.Location = New System.Drawing.Point(289, 13)
        Me.lblCurDate.Name = "lblCurDate"
        Me.lblCurDate.Size = New System.Drawing.Size(76, 18)
        Me.lblCurDate.TabIndex = 480
        Me.lblCurDate.Text = "2000-00-00"
        Me.lblCurDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurTime
        '
        Me.lblCurTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCurTime.Location = New System.Drawing.Point(289, 36)
        Me.lblCurTime.Name = "lblCurTime"
        Me.lblCurTime.Size = New System.Drawing.Size(76, 18)
        Me.lblCurTime.TabIndex = 479
        Me.lblCurTime.Text = "00 : 00 : 00"
        Me.lblCurTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAccount
        '
        Me.lbAccount.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAccount.Location = New System.Drawing.Point(154, 41)
        Me.lbAccount.Name = "lbAccount"
        Me.lbAccount.Size = New System.Drawing.Size(134, 21)
        Me.lbAccount.TabIndex = 478
        Me.lbAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("맑은 고딕", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(276, 38)
        Me.lblTitle.TabIndex = 477
        Me.lblTitle.Text = "Chamfering System"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnInit
        '
        Me.btnInit.BackColor = System.Drawing.Color.White
        Me.btnInit.FlatAppearance.BorderSize = 2
        Me.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInit.ImageIndex = 21
        Me.btnInit.Location = New System.Drawing.Point(1225, 8)
        Me.btnInit.Name = "btnInit"
        Me.btnInit.Size = New System.Drawing.Size(120, 50)
        Me.btnInit.TabIndex = 485
        Me.btnInit.TabStop = False
        Me.btnInit.Text = "Init"
        Me.btnInit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInit.UseVisualStyleBackColor = False
        '
        'btnMain
        '
        Me.btnMain.BackColor = System.Drawing.Color.White
        Me.btnMain.FlatAppearance.BorderSize = 2
        Me.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMain.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMain.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMain.ImageIndex = 21
        Me.btnMain.Location = New System.Drawing.Point(1362, 8)
        Me.btnMain.Name = "btnMain"
        Me.btnMain.Size = New System.Drawing.Size(120, 50)
        Me.btnMain.TabIndex = 484
        Me.btnMain.TabStop = False
        Me.btnMain.Text = "Main"
        Me.btnMain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMain.UseVisualStyleBackColor = False
        '
        'btnRecipe
        '
        Me.btnRecipe.BackColor = System.Drawing.Color.White
        Me.btnRecipe.FlatAppearance.BorderSize = 2
        Me.btnRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecipe.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecipe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRecipe.ImageIndex = 21
        Me.btnRecipe.Location = New System.Drawing.Point(1499, 8)
        Me.btnRecipe.Name = "btnRecipe"
        Me.btnRecipe.Size = New System.Drawing.Size(120, 50)
        Me.btnRecipe.TabIndex = 483
        Me.btnRecipe.TabStop = False
        Me.btnRecipe.Text = "Recipe"
        Me.btnRecipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRecipe.UseVisualStyleBackColor = False
        '
        'btnSetting
        '
        Me.btnSetting.BackColor = System.Drawing.Color.White
        Me.btnSetting.FlatAppearance.BorderSize = 2
        Me.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetting.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSetting.ImageIndex = 21
        Me.btnSetting.Location = New System.Drawing.Point(1636, 8)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(120, 50)
        Me.btnSetting.TabIndex = 482
        Me.btnSetting.TabStop = False
        Me.btnSetting.Text = "Setting"
        Me.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSetting.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExit.FlatAppearance.BorderSize = 2
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.ImageIndex = 21
        Me.btnExit.Location = New System.Drawing.Point(1773, 8)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(120, 50)
        Me.btnExit.TabIndex = 481
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'tmTopeMenu
        '
        Me.tmTopeMenu.Interval = 200
        '
        'lblAuto_Manual_A
        '
        Me.lblAuto_Manual_A.BackColor = System.Drawing.Color.Yellow
        Me.lblAuto_Manual_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAuto_Manual_A.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuto_Manual_A.ForeColor = System.Drawing.Color.Black
        Me.lblAuto_Manual_A.Location = New System.Drawing.Point(968, 3)
        Me.lblAuto_Manual_A.Name = "lblAuto_Manual_A"
        Me.lblAuto_Manual_A.Size = New System.Drawing.Size(126, 27)
        Me.lblAuto_Manual_A.TabIndex = 497
        Me.lblAuto_Manual_A.Text = "PLC A - Manual"
        Me.lblAuto_Manual_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSystemStatus
        '
        Me.lblSystemStatus.BackColor = System.Drawing.Color.Black
        Me.lblSystemStatus.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemStatus.ForeColor = System.Drawing.Color.Red
        Me.lblSystemStatus.Location = New System.Drawing.Point(637, 3)
        Me.lblSystemStatus.Name = "lblSystemStatus"
        Me.lblSystemStatus.Size = New System.Drawing.Size(314, 59)
        Me.lblSystemStatus.TabIndex = 496
        Me.lblSystemStatus.Text = "System need to Init"
        Me.lblSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurCpuTemp_3
        '
        Me.lblCurCpuTemp_3.BackColor = System.Drawing.Color.Lime
        Me.lblCurCpuTemp_3.Enabled = False
        Me.lblCurCpuTemp_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurCpuTemp_3.Location = New System.Drawing.Point(421, 33)
        Me.lblCurCpuTemp_3.Name = "lblCurCpuTemp_3"
        Me.lblCurCpuTemp_3.Size = New System.Drawing.Size(40, 14)
        Me.lblCurCpuTemp_3.TabIndex = 495
        Me.lblCurCpuTemp_3.Text = "00 ℃"
        Me.lblCurCpuTemp_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCpu_3
        '
        Me.lblCpu_3.Enabled = False
        Me.lblCpu_3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCpu_3.Location = New System.Drawing.Point(375, 33)
        Me.lblCpu_3.Name = "lblCpu_3"
        Me.lblCpu_3.Size = New System.Drawing.Size(45, 12)
        Me.lblCpu_3.TabIndex = 494
        Me.lblCpu_3.Text = "CPU#3 :"
        '
        'lblCurCpuTemp_4
        '
        Me.lblCurCpuTemp_4.BackColor = System.Drawing.Color.Lime
        Me.lblCurCpuTemp_4.Enabled = False
        Me.lblCurCpuTemp_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurCpuTemp_4.Location = New System.Drawing.Point(421, 48)
        Me.lblCurCpuTemp_4.Name = "lblCurCpuTemp_4"
        Me.lblCurCpuTemp_4.Size = New System.Drawing.Size(40, 14)
        Me.lblCurCpuTemp_4.TabIndex = 493
        Me.lblCurCpuTemp_4.Text = "00 ℃"
        Me.lblCurCpuTemp_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCpu_4
        '
        Me.lblCpu_4.Enabled = False
        Me.lblCpu_4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCpu_4.Location = New System.Drawing.Point(375, 48)
        Me.lblCpu_4.Name = "lblCpu_4"
        Me.lblCpu_4.Size = New System.Drawing.Size(45, 12)
        Me.lblCpu_4.TabIndex = 492
        Me.lblCpu_4.Text = "CPU#4 :"
        '
        'lblCurCpuTemp_2
        '
        Me.lblCurCpuTemp_2.BackColor = System.Drawing.Color.Lime
        Me.lblCurCpuTemp_2.Enabled = False
        Me.lblCurCpuTemp_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurCpuTemp_2.Location = New System.Drawing.Point(421, 18)
        Me.lblCurCpuTemp_2.Name = "lblCurCpuTemp_2"
        Me.lblCurCpuTemp_2.Size = New System.Drawing.Size(40, 14)
        Me.lblCurCpuTemp_2.TabIndex = 491
        Me.lblCurCpuTemp_2.Text = "00 ℃"
        Me.lblCurCpuTemp_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCpu_2
        '
        Me.lblCpu_2.Enabled = False
        Me.lblCpu_2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCpu_2.Location = New System.Drawing.Point(375, 18)
        Me.lblCpu_2.Name = "lblCpu_2"
        Me.lblCpu_2.Size = New System.Drawing.Size(45, 12)
        Me.lblCpu_2.TabIndex = 490
        Me.lblCpu_2.Text = "CPU#2 :"
        '
        'lblCurCpuTemp_1
        '
        Me.lblCurCpuTemp_1.BackColor = System.Drawing.Color.Lime
        Me.lblCurCpuTemp_1.Enabled = False
        Me.lblCurCpuTemp_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurCpuTemp_1.Location = New System.Drawing.Point(421, 3)
        Me.lblCurCpuTemp_1.Name = "lblCurCpuTemp_1"
        Me.lblCurCpuTemp_1.Size = New System.Drawing.Size(40, 14)
        Me.lblCurCpuTemp_1.TabIndex = 489
        Me.lblCurCpuTemp_1.Text = "00 ℃"
        Me.lblCurCpuTemp_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCpu_1
        '
        Me.lblCpu_1.Enabled = False
        Me.lblCpu_1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCpu_1.Location = New System.Drawing.Point(375, 3)
        Me.lblCpu_1.Name = "lblCpu_1"
        Me.lblCpu_1.Size = New System.Drawing.Size(45, 12)
        Me.lblCpu_1.TabIndex = 488
        Me.lblCpu_1.Text = "CPU#1 :"
        '
        'lblAuto_Manual_B
        '
        Me.lblAuto_Manual_B.BackColor = System.Drawing.Color.Yellow
        Me.lblAuto_Manual_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAuto_Manual_B.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuto_Manual_B.ForeColor = System.Drawing.Color.Black
        Me.lblAuto_Manual_B.Location = New System.Drawing.Point(968, 35)
        Me.lblAuto_Manual_B.Name = "lblAuto_Manual_B"
        Me.lblAuto_Manual_B.Size = New System.Drawing.Size(126, 27)
        Me.lblAuto_Manual_B.TabIndex = 498
        Me.lblAuto_Manual_B.Text = "PLC B - Manual"
        Me.lblAuto_Manual_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMoveStage_A
        '
        Me.lblMoveStage_A.BackColor = System.Drawing.Color.Lime
        Me.lblMoveStage_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMoveStage_A.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoveStage_A.ForeColor = System.Drawing.Color.Black
        Me.lblMoveStage_A.Location = New System.Drawing.Point(1109, 3)
        Me.lblMoveStage_A.Name = "lblMoveStage_A"
        Me.lblMoveStage_A.Size = New System.Drawing.Size(106, 59)
        Me.lblMoveStage_A.TabIndex = 499
        Me.lblMoveStage_A.Text = "PLC Control Stage"
        Me.lblMoveStage_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblModelNum
        '
        Me.lblModelNum.BackColor = System.Drawing.Color.GreenYellow
        Me.lblModelNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModelNum.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelNum.ForeColor = System.Drawing.Color.Black
        Me.lblModelNum.Location = New System.Drawing.Point(586, 4)
        Me.lblModelNum.Name = "lblModelNum"
        Me.lblModelNum.Size = New System.Drawing.Size(45, 59)
        Me.lblModelNum.TabIndex = 501
        Me.lblModelNum.Text = "-"
        Me.lblModelNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogIn
        '
        Me.btnLogIn.BackColor = System.Drawing.Color.White
        Me.btnLogIn.FlatAppearance.BorderSize = 2
        Me.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogIn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLogIn.ImageIndex = 21
        Me.btnLogIn.Location = New System.Drawing.Point(18, 36)
        Me.btnLogIn.Name = "btnLogIn"
        Me.btnLogIn.Size = New System.Drawing.Size(120, 26)
        Me.btnLogIn.TabIndex = 502
        Me.btnLogIn.TabStop = False
        Me.btnLogIn.Text = "LogIn"
        Me.btnLogIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLogIn.UseVisualStyleBackColor = False
        '
        'BtnKorea
        '
        Me.BtnKorea.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnKorea.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKorea.Location = New System.Drawing.Point(467, 3)
        Me.BtnKorea.Name = "BtnKorea"
        Me.BtnKorea.Size = New System.Drawing.Size(33, 59)
        Me.BtnKorea.TabIndex = 503
        Me.BtnKorea.Text = "KOR"
        Me.BtnKorea.UseVisualStyleBackColor = True
        '
        'BtnEng
        '
        Me.BtnEng.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEng.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEng.Location = New System.Drawing.Point(506, 3)
        Me.BtnEng.Name = "BtnEng"
        Me.BtnEng.Size = New System.Drawing.Size(74, 29)
        Me.BtnEng.TabIndex = 504
        Me.BtnEng.Text = "English"
        Me.BtnEng.UseVisualStyleBackColor = True
        '
        'BtnVietnam
        '
        Me.BtnVietnam.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnVietnam.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVietnam.Location = New System.Drawing.Point(506, 33)
        Me.BtnVietnam.Name = "BtnVietnam"
        Me.BtnVietnam.Size = New System.Drawing.Size(74, 29)
        Me.BtnVietnam.TabIndex = 505
        Me.BtnVietnam.Text = "Vietnam"
        Me.BtnVietnam.UseVisualStyleBackColor = True
        '
        'frmTopMenu
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1910, 65)
        Me.Controls.Add(Me.BtnVietnam)
        Me.Controls.Add(Me.BtnEng)
        Me.Controls.Add(Me.BtnKorea)
        Me.Controls.Add(Me.btnLogIn)
        Me.Controls.Add(Me.lblModelNum)
        Me.Controls.Add(Me.lblMoveStage_A)
        Me.Controls.Add(Me.lblAuto_Manual_B)
        Me.Controls.Add(Me.lblAuto_Manual_A)
        Me.Controls.Add(Me.lblSystemStatus)
        Me.Controls.Add(Me.lblCurCpuTemp_3)
        Me.Controls.Add(Me.lblCpu_3)
        Me.Controls.Add(Me.lblCurCpuTemp_4)
        Me.Controls.Add(Me.lblCpu_4)
        Me.Controls.Add(Me.lblCurCpuTemp_2)
        Me.Controls.Add(Me.lblCpu_2)
        Me.Controls.Add(Me.lblCurCpuTemp_1)
        Me.Controls.Add(Me.lblCpu_1)
        Me.Controls.Add(Me.btnInit)
        Me.Controls.Add(Me.btnMain)
        Me.Controls.Add(Me.btnRecipe)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblCurDate)
        Me.Controls.Add(Me.lblCurTime)
        Me.Controls.Add(Me.lbAccount)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmTopMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmTopMenu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCurDate As System.Windows.Forms.Label
    Friend WithEvents lblCurTime As System.Windows.Forms.Label
    Friend WithEvents lbAccount As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnInit As System.Windows.Forms.Button
    Friend WithEvents btnMain As System.Windows.Forms.Button
    Friend WithEvents btnRecipe As System.Windows.Forms.Button
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents tmTopeMenu As System.Windows.Forms.Timer
    Friend WithEvents lblAuto_Manual_A As System.Windows.Forms.Label
    Friend WithEvents lblSystemStatus As System.Windows.Forms.Label
    Friend WithEvents lblCurCpuTemp_3 As System.Windows.Forms.Label
    Friend WithEvents lblCpu_3 As System.Windows.Forms.Label
    Friend WithEvents lblCurCpuTemp_4 As System.Windows.Forms.Label
    Friend WithEvents lblCpu_4 As System.Windows.Forms.Label
    Friend WithEvents lblCurCpuTemp_2 As System.Windows.Forms.Label
    Friend WithEvents lblCpu_2 As System.Windows.Forms.Label
    Friend WithEvents lblCurCpuTemp_1 As System.Windows.Forms.Label
    Friend WithEvents lblCpu_1 As System.Windows.Forms.Label
    Friend WithEvents lblAuto_Manual_B As System.Windows.Forms.Label
    Friend WithEvents lblMoveStage_A As System.Windows.Forms.Label
    Friend WithEvents lblModelNum As System.Windows.Forms.Label
    Friend WithEvents btnLogIn As System.Windows.Forms.Button
    Friend WithEvents BtnKorea As System.Windows.Forms.Button
    Friend WithEvents BtnEng As System.Windows.Forms.Button
    Friend WithEvents BtnVietnam As System.Windows.Forms.Button
End Class
