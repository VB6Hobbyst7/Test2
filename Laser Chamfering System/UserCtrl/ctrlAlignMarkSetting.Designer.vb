<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlAlignMarkSetting
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
        Me.gbAlignA1_M1_L1 = New System.Windows.Forms.GroupBox()
        Me.numCnt = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnCopy = New System.Windows.Forms.Button()
        Me.btnSetRoi = New System.Windows.Forms.Button()
        Me.BtnDrowMODEL = New System.Windows.Forms.Button()
        Me.BtnDrowROI = New System.Windows.Forms.Button()
        Me.lblRBY = New System.Windows.Forms.Label()
        Me.lblTLY = New System.Windows.Forms.Label()
        Me.lblRBX = New System.Windows.Forms.Label()
        Me.lblTLX = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Save = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnAcceptSave = New System.Windows.Forms.Button()
        Me.lblREFY = New System.Windows.Forms.Label()
        Me.lblREFX = New System.Windows.Forms.Label()
        Me.lblModel_OffsetX = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label163 = New System.Windows.Forms.Label()
        Me.ChkRefPoint = New System.Windows.Forms.CheckBox()
        Me.numModelSizeY = New System.Windows.Forms.NumericUpDown()
        Me.picModel = New System.Windows.Forms.PictureBox()
        Me.lblModel_OffsetY = New System.Windows.Forms.Label()
        Me.numModelSizeX = New System.Windows.Forms.NumericUpDown()
        Me.Label167 = New System.Windows.Forms.Label()
        Me.Label160 = New System.Windows.Forms.Label()
        Me.Label162 = New System.Windows.Forms.Label()
        Me.numAcceptM = New System.Windows.Forms.NumericUpDown()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.numCertM = New System.Windows.Forms.NumericUpDown()
        Me.Label168 = New System.Windows.Forms.Label()
        Me.btnModelApply = New System.Windows.Forms.Button()
        Me.chkMarkUse = New System.Windows.Forms.CheckBox()
        Me.btnModelCheck = New System.Windows.Forms.Button()
        Me.lblPosY = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.numSizeY = New System.Windows.Forms.NumericUpDown()
        Me.numSizeX = New System.Windows.Forms.NumericUpDown()
        Me.Label156 = New System.Windows.Forms.Label()
        Me.Label157 = New System.Windows.Forms.Label()
        Me.Label158 = New System.Windows.Forms.Label()
        Me.lblStartY = New System.Windows.Forms.Label()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.lblStartX = New System.Windows.Forms.Label()
        Me.btnModelSetting = New System.Windows.Forms.Button()
        Me.lblPosX = New System.Windows.Forms.Label()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.btnToM = New System.Windows.Forms.Button()
        Me.Label161 = New System.Windows.Forms.Label()
        Me.lblOK = New System.Windows.Forms.Label()
        Me.Label164 = New System.Windows.Forms.Label()
        Me.Label165 = New System.Windows.Forms.Label()
        Me.Label166 = New System.Windows.Forms.Label()
        Me.gbAlignA1_M1_L1.SuspendLayout()
        CType(Me.numCnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numModelSizeY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picModel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numModelSizeX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAcceptM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCertM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox14.SuspendLayout()
        CType(Me.numSizeY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSizeX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbAlignA1_M1_L1
        '
        Me.gbAlignA1_M1_L1.BackColor = System.Drawing.Color.White
        Me.gbAlignA1_M1_L1.Controls.Add(Me.numCnt)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Label3)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.BtnCopy)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.btnSetRoi)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.BtnDrowMODEL)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.BtnDrowROI)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblRBY)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblTLY)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblRBX)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblTLX)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Label2)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Label1)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Save)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.GroupBox1)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.btnModelApply)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.chkMarkUse)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.btnModelCheck)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblPosY)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.GroupBox14)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.btnModelSetting)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblPosX)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblScore)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.btnToM)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Label161)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.lblOK)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Label164)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Label165)
        Me.gbAlignA1_M1_L1.Controls.Add(Me.Label166)
        Me.gbAlignA1_M1_L1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gbAlignA1_M1_L1.Location = New System.Drawing.Point(3, 3)
        Me.gbAlignA1_M1_L1.Name = "gbAlignA1_M1_L1"
        Me.gbAlignA1_M1_L1.Size = New System.Drawing.Size(667, 253)
        Me.gbAlignA1_M1_L1.TabIndex = 310
        Me.gbAlignA1_M1_L1.TabStop = False
        '
        'numCnt
        '
        Me.numCnt.Location = New System.Drawing.Point(539, 94)
        Me.numCnt.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numCnt.Name = "numCnt"
        Me.numCnt.Size = New System.Drawing.Size(44, 22)
        Me.numCnt.TabIndex = 407
        Me.numCnt.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gray
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(386, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 41)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Select [Mark Set], and then double-click the image."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCopy
        '
        Me.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCopy.Location = New System.Drawing.Point(609, 67)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(50, 30)
        Me.BtnCopy.TabIndex = 405
        Me.BtnCopy.Text = "Copy"
        Me.BtnCopy.UseVisualStyleBackColor = True
        Me.BtnCopy.Visible = False
        '
        'btnSetRoi
        '
        Me.btnSetRoi.FlatAppearance.BorderSize = 2
        Me.btnSetRoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetRoi.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetRoi.Location = New System.Drawing.Point(103, 16)
        Me.btnSetRoi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSetRoi.Name = "btnSetRoi"
        Me.btnSetRoi.Size = New System.Drawing.Size(85, 30)
        Me.btnSetRoi.TabIndex = 262
        Me.btnSetRoi.Text = "ROI Save"
        Me.btnSetRoi.UseVisualStyleBackColor = True
        '
        'BtnDrowMODEL
        '
        Me.BtnDrowMODEL.FlatAppearance.BorderSize = 2
        Me.BtnDrowMODEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDrowMODEL.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDrowMODEL.Location = New System.Drawing.Point(193, 16)
        Me.BtnDrowMODEL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnDrowMODEL.Name = "BtnDrowMODEL"
        Me.BtnDrowMODEL.Size = New System.Drawing.Size(100, 30)
        Me.BtnDrowMODEL.TabIndex = 400
        Me.BtnDrowMODEL.Text = "Mark Area"
        Me.BtnDrowMODEL.UseVisualStyleBackColor = True
        '
        'BtnDrowROI
        '
        Me.BtnDrowROI.FlatAppearance.BorderSize = 2
        Me.BtnDrowROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDrowROI.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDrowROI.Location = New System.Drawing.Point(13, 16)
        Me.BtnDrowROI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnDrowROI.Name = "BtnDrowROI"
        Me.BtnDrowROI.Size = New System.Drawing.Size(85, 30)
        Me.BtnDrowROI.TabIndex = 399
        Me.BtnDrowROI.Text = "ROI Area"
        Me.BtnDrowROI.UseVisualStyleBackColor = True
        '
        'lblRBY
        '
        Me.lblRBY.BackColor = System.Drawing.Color.Gainsboro
        Me.lblRBY.Location = New System.Drawing.Point(109, 78)
        Me.lblRBY.Name = "lblRBY"
        Me.lblRBY.Size = New System.Drawing.Size(36, 16)
        Me.lblRBY.TabIndex = 398
        Me.lblRBY.Text = "0"
        Me.lblRBY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTLY
        '
        Me.lblTLY.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTLY.Location = New System.Drawing.Point(109, 59)
        Me.lblTLY.Name = "lblTLY"
        Me.lblTLY.Size = New System.Drawing.Size(36, 16)
        Me.lblTLY.TabIndex = 397
        Me.lblTLY.Text = "0"
        Me.lblTLY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRBX
        '
        Me.lblRBX.BackColor = System.Drawing.Color.Gainsboro
        Me.lblRBX.Location = New System.Drawing.Point(70, 78)
        Me.lblRBX.Name = "lblRBX"
        Me.lblRBX.Size = New System.Drawing.Size(36, 16)
        Me.lblRBX.TabIndex = 396
        Me.lblRBX.Text = "0"
        Me.lblRBX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTLX
        '
        Me.lblTLX.BackColor = System.Drawing.Color.Gainsboro
        Me.lblTLX.Location = New System.Drawing.Point(70, 59)
        Me.lblTLX.Name = "lblTLX"
        Me.lblTLX.Size = New System.Drawing.Size(36, 16)
        Me.lblTLX.TabIndex = 395
        Me.lblTLX.Text = "0"
        Me.lblTLX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 16)
        Me.Label2.TabIndex = 394
        Me.Label2.Text = "RB(x,y)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 393
        Me.Label1.Text = "TL(x,y)"
        '
        'Save
        '
        Me.Save.FlatAppearance.BorderSize = 2
        Me.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Save.Location = New System.Drawing.Point(600, 14)
        Me.Save.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(60, 45)
        Me.Save.TabIndex = 392
        Me.Save.Text = "Model Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnAcceptSave)
        Me.GroupBox1.Controls.Add(Me.lblREFY)
        Me.GroupBox1.Controls.Add(Me.lblREFX)
        Me.GroupBox1.Controls.Add(Me.lblModel_OffsetX)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label163)
        Me.GroupBox1.Controls.Add(Me.ChkRefPoint)
        Me.GroupBox1.Controls.Add(Me.numModelSizeY)
        Me.GroupBox1.Controls.Add(Me.picModel)
        Me.GroupBox1.Controls.Add(Me.lblModel_OffsetY)
        Me.GroupBox1.Controls.Add(Me.numModelSizeX)
        Me.GroupBox1.Controls.Add(Me.Label167)
        Me.GroupBox1.Controls.Add(Me.Label160)
        Me.GroupBox1.Controls.Add(Me.Label162)
        Me.GroupBox1.Controls.Add(Me.numAcceptM)
        Me.GroupBox1.Controls.Add(Me.Label169)
        Me.GroupBox1.Controls.Add(Me.numCertM)
        Me.GroupBox1.Controls.Add(Me.Label168)
        Me.GroupBox1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(148, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 186)
        Me.GroupBox1.TabIndex = 391
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "모델 정보"
        '
        'BtnAcceptSave
        '
        Me.BtnAcceptSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAcceptSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcceptSave.Location = New System.Drawing.Point(163, 127)
        Me.BtnAcceptSave.Name = "BtnAcceptSave"
        Me.BtnAcceptSave.Size = New System.Drawing.Size(45, 46)
        Me.BtnAcceptSave.TabIndex = 406
        Me.BtnAcceptSave.Text = "Save"
        Me.BtnAcceptSave.UseVisualStyleBackColor = True
        '
        'lblREFY
        '
        Me.lblREFY.BackColor = System.Drawing.Color.Gainsboro
        Me.lblREFY.Location = New System.Drawing.Point(146, -9)
        Me.lblREFY.Name = "lblREFY"
        Me.lblREFY.Size = New System.Drawing.Size(36, 16)
        Me.lblREFY.TabIndex = 404
        Me.lblREFY.Text = "0"
        Me.lblREFY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblREFY.Visible = False
        '
        'lblREFX
        '
        Me.lblREFX.BackColor = System.Drawing.Color.Gainsboro
        Me.lblREFX.Location = New System.Drawing.Point(146, -9)
        Me.lblREFX.Name = "lblREFX"
        Me.lblREFX.Size = New System.Drawing.Size(36, 16)
        Me.lblREFX.TabIndex = 403
        Me.lblREFX.Text = "0"
        Me.lblREFX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblREFX.Visible = False
        '
        'lblModel_OffsetX
        '
        Me.lblModel_OffsetX.BackColor = System.Drawing.Color.Gainsboro
        Me.lblModel_OffsetX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblModel_OffsetX.Location = New System.Drawing.Point(117, 29)
        Me.lblModel_OffsetX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lblModel_OffsetX.Name = "lblModel_OffsetX"
        Me.lblModel_OffsetX.Size = New System.Drawing.Size(90, 19)
        Me.lblModel_OffsetX.TabIndex = 356
        Me.lblModel_OffsetX.Text = "0"
        Me.lblModel_OffsetX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(146, -9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 402
        Me.Label5.Text = "Ref(x,y)"
        Me.Label5.Visible = False
        '
        'Label163
        '
        Me.Label163.AutoSize = True
        Me.Label163.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label163.Location = New System.Drawing.Point(6, 31)
        Me.Label163.Name = "Label163"
        Me.Label163.Size = New System.Drawing.Size(65, 16)
        Me.Label163.TabIndex = 355
        Me.Label163.Text = "Offset X :"
        '
        'ChkRefPoint
        '
        Me.ChkRefPoint.AutoSize = True
        Me.ChkRefPoint.Enabled = False
        Me.ChkRefPoint.Location = New System.Drawing.Point(146, -9)
        Me.ChkRefPoint.Name = "ChkRefPoint"
        Me.ChkRefPoint.Size = New System.Drawing.Size(81, 21)
        Me.ChkRefPoint.TabIndex = 401
        Me.ChkRefPoint.Text = "RefPoint"
        Me.ChkRefPoint.UseVisualStyleBackColor = True
        Me.ChkRefPoint.Visible = False
        '
        'numModelSizeY
        '
        Me.numModelSizeY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numModelSizeY.Location = New System.Drawing.Point(117, 102)
        Me.numModelSizeY.Maximum = New Decimal(New Integer() {1040, 0, 0, 0})
        Me.numModelSizeY.Name = "numModelSizeY"
        Me.numModelSizeY.Size = New System.Drawing.Size(90, 25)
        Me.numModelSizeY.TabIndex = 386
        Me.numModelSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picModel
        '
        Me.picModel.BackColor = System.Drawing.Color.Black
        Me.picModel.Location = New System.Drawing.Point(213, 17)
        Me.picModel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picModel.Name = "picModel"
        Me.picModel.Size = New System.Drawing.Size(160, 160)
        Me.picModel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picModel.TabIndex = 369
        Me.picModel.TabStop = False
        '
        'lblModel_OffsetY
        '
        Me.lblModel_OffsetY.BackColor = System.Drawing.Color.Gainsboro
        Me.lblModel_OffsetY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblModel_OffsetY.Location = New System.Drawing.Point(117, 52)
        Me.lblModel_OffsetY.Name = "lblModel_OffsetY"
        Me.lblModel_OffsetY.Size = New System.Drawing.Size(90, 19)
        Me.lblModel_OffsetY.TabIndex = 362
        Me.lblModel_OffsetY.Text = "0"
        Me.lblModel_OffsetY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numModelSizeX
        '
        Me.numModelSizeX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numModelSizeX.Location = New System.Drawing.Point(117, 75)
        Me.numModelSizeX.Maximum = New Decimal(New Integer() {1340, 0, 0, 0})
        Me.numModelSizeX.Name = "numModelSizeX"
        Me.numModelSizeX.Size = New System.Drawing.Size(90, 25)
        Me.numModelSizeX.TabIndex = 385
        Me.numModelSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label167
        '
        Me.Label167.AutoSize = True
        Me.Label167.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label167.Location = New System.Drawing.Point(6, 54)
        Me.Label167.Name = "Label167"
        Me.Label167.Size = New System.Drawing.Size(64, 16)
        Me.Label167.TabIndex = 359
        Me.Label167.Text = "Offset Y :"
        '
        'Label160
        '
        Me.Label160.AutoSize = True
        Me.Label160.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label160.Location = New System.Drawing.Point(6, 79)
        Me.Label160.Name = "Label160"
        Me.Label160.Size = New System.Drawing.Size(57, 16)
        Me.Label160.TabIndex = 363
        Me.Label160.Text = "Size X :"
        '
        'Label162
        '
        Me.Label162.AutoSize = True
        Me.Label162.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label162.Location = New System.Drawing.Point(6, 106)
        Me.Label162.Name = "Label162"
        Me.Label162.Size = New System.Drawing.Size(56, 16)
        Me.Label162.TabIndex = 365
        Me.Label162.Text = "Size Y :"
        '
        'numAcceptM
        '
        Me.numAcceptM.BackColor = System.Drawing.Color.Gainsboro
        Me.numAcceptM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.numAcceptM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.numAcceptM.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numAcceptM.Location = New System.Drawing.Point(117, 130)
        Me.numAcceptM.Name = "numAcceptM"
        Me.numAcceptM.Size = New System.Drawing.Size(41, 18)
        Me.numAcceptM.TabIndex = 372
        Me.numAcceptM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numAcceptM.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'Label169
        '
        Me.Label169.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label169.Location = New System.Drawing.Point(5, 131)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(108, 17)
        Me.Label169.TabIndex = 370
        Me.Label169.Text = "Acceptance(%)"
        '
        'numCertM
        '
        Me.numCertM.BackColor = System.Drawing.Color.Gainsboro
        Me.numCertM.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.numCertM.Enabled = False
        Me.numCertM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.numCertM.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCertM.Location = New System.Drawing.Point(117, 155)
        Me.numCertM.Name = "numCertM"
        Me.numCertM.Size = New System.Drawing.Size(41, 18)
        Me.numCertM.TabIndex = 373
        Me.numCertM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numCertM.Value = New Decimal(New Integer() {95, 0, 0, 0})
        '
        'Label168
        '
        Me.Label168.Enabled = False
        Me.Label168.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label168.Location = New System.Drawing.Point(5, 154)
        Me.Label168.Name = "Label168"
        Me.Label168.Size = New System.Drawing.Size(108, 17)
        Me.Label168.TabIndex = 371
        Me.Label168.Text = "Certainty(%)"
        '
        'btnModelApply
        '
        Me.btnModelApply.Enabled = False
        Me.btnModelApply.FlatAppearance.BorderSize = 2
        Me.btnModelApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModelApply.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnModelApply.Location = New System.Drawing.Point(535, 14)
        Me.btnModelApply.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnModelApply.Name = "btnModelApply"
        Me.btnModelApply.Size = New System.Drawing.Size(60, 45)
        Me.btnModelApply.TabIndex = 357
        Me.btnModelApply.Text = "Model Apply"
        Me.btnModelApply.UseVisualStyleBackColor = True
        '
        'chkMarkUse
        '
        Me.chkMarkUse.Checked = True
        Me.chkMarkUse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMarkUse.Location = New System.Drawing.Point(535, 66)
        Me.chkMarkUse.Name = "chkMarkUse"
        Me.chkMarkUse.Size = New System.Drawing.Size(55, 25)
        Me.chkMarkUse.TabIndex = 390
        Me.chkMarkUse.Text = "Use"
        Me.chkMarkUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkMarkUse.UseVisualStyleBackColor = True
        '
        'btnModelCheck
        '
        Me.btnModelCheck.FlatAppearance.BorderSize = 2
        Me.btnModelCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModelCheck.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnModelCheck.Location = New System.Drawing.Point(574, 219)
        Me.btnModelCheck.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnModelCheck.Name = "btnModelCheck"
        Me.btnModelCheck.Size = New System.Drawing.Size(84, 27)
        Me.btnModelCheck.TabIndex = 368
        Me.btnModelCheck.Text = "Verify"
        Me.btnModelCheck.UseVisualStyleBackColor = True
        '
        'lblPosY
        '
        Me.lblPosY.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPosY.Location = New System.Drawing.Point(588, 199)
        Me.lblPosY.Name = "lblPosY"
        Me.lblPosY.Size = New System.Drawing.Size(70, 16)
        Me.lblPosY.TabIndex = 382
        Me.lblPosY.Text = "-- mm"
        Me.lblPosY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.numSizeY)
        Me.GroupBox14.Controls.Add(Me.numSizeX)
        Me.GroupBox14.Controls.Add(Me.Label156)
        Me.GroupBox14.Controls.Add(Me.Label157)
        Me.GroupBox14.Controls.Add(Me.Label158)
        Me.GroupBox14.Controls.Add(Me.lblStartY)
        Me.GroupBox14.Controls.Add(Me.Label159)
        Me.GroupBox14.Controls.Add(Me.lblStartX)
        Me.GroupBox14.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox14.Location = New System.Drawing.Point(13, 108)
        Me.GroupBox14.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox14.Size = New System.Drawing.Size(130, 137)
        Me.GroupBox14.TabIndex = 348
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "ROI 정보"
        '
        'numSizeY
        '
        Me.numSizeY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numSizeY.Location = New System.Drawing.Point(67, 105)
        Me.numSizeY.Maximum = New Decimal(New Integer() {1040, 0, 0, 0})
        Me.numSizeY.Name = "numSizeY"
        Me.numSizeY.Size = New System.Drawing.Size(58, 25)
        Me.numSizeY.TabIndex = 385
        Me.numSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numSizeY.Value = New Decimal(New Integer() {1040, 0, 0, 0})
        '
        'numSizeX
        '
        Me.numSizeX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numSizeX.Location = New System.Drawing.Point(67, 76)
        Me.numSizeX.Maximum = New Decimal(New Integer() {1360, 0, 0, 0})
        Me.numSizeX.Name = "numSizeX"
        Me.numSizeX.Size = New System.Drawing.Size(58, 25)
        Me.numSizeX.TabIndex = 384
        Me.numSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numSizeX.Value = New Decimal(New Integer() {1360, 0, 0, 0})
        '
        'Label156
        '
        Me.Label156.AutoSize = True
        Me.Label156.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label156.Location = New System.Drawing.Point(4, 79)
        Me.Label156.Name = "Label156"
        Me.Label156.Size = New System.Drawing.Size(57, 16)
        Me.Label156.TabIndex = 258
        Me.Label156.Text = "Size X :"
        '
        'Label157
        '
        Me.Label157.AutoSize = True
        Me.Label157.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label157.Location = New System.Drawing.Point(4, 108)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(56, 16)
        Me.Label157.TabIndex = 260
        Me.Label157.Text = "Size Y :"
        '
        'Label158
        '
        Me.Label158.AutoSize = True
        Me.Label158.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label158.Location = New System.Drawing.Point(4, 27)
        Me.Label158.Name = "Label158"
        Me.Label158.Size = New System.Drawing.Size(59, 16)
        Me.Label158.TabIndex = 258
        Me.Label158.Text = "Start X :"
        '
        'lblStartY
        '
        Me.lblStartY.BackColor = System.Drawing.Color.Gainsboro
        Me.lblStartY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblStartY.Location = New System.Drawing.Point(67, 51)
        Me.lblStartY.Name = "lblStartY"
        Me.lblStartY.Size = New System.Drawing.Size(58, 18)
        Me.lblStartY.TabIndex = 261
        Me.lblStartY.Text = "0"
        Me.lblStartY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label159
        '
        Me.Label159.AutoSize = True
        Me.Label159.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label159.Location = New System.Drawing.Point(4, 52)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(58, 16)
        Me.Label159.TabIndex = 260
        Me.Label159.Text = "Start Y :"
        '
        'lblStartX
        '
        Me.lblStartX.BackColor = System.Drawing.Color.Gainsboro
        Me.lblStartX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblStartX.Location = New System.Drawing.Point(67, 26)
        Me.lblStartX.Name = "lblStartX"
        Me.lblStartX.Size = New System.Drawing.Size(58, 18)
        Me.lblStartX.TabIndex = 259
        Me.lblStartX.Text = "0"
        Me.lblStartX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnModelSetting
        '
        Me.btnModelSetting.Enabled = False
        Me.btnModelSetting.FlatAppearance.BorderSize = 2
        Me.btnModelSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModelSetting.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModelSetting.Location = New System.Drawing.Point(298, 16)
        Me.btnModelSetting.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnModelSetting.Name = "btnModelSetting"
        Me.btnModelSetting.Size = New System.Drawing.Size(85, 30)
        Me.btnModelSetting.TabIndex = 367
        Me.btnModelSetting.Text = "Mark Set"
        Me.btnModelSetting.UseVisualStyleBackColor = True
        '
        'lblPosX
        '
        Me.lblPosX.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPosX.Location = New System.Drawing.Point(588, 173)
        Me.lblPosX.Name = "lblPosX"
        Me.lblPosX.Size = New System.Drawing.Size(70, 16)
        Me.lblPosX.TabIndex = 381
        Me.lblPosX.Text = "-- mm"
        Me.lblPosX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblScore
        '
        Me.lblScore.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblScore.Location = New System.Drawing.Point(588, 148)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(70, 16)
        Me.lblScore.TabIndex = 380
        Me.lblScore.Text = "-- %"
        Me.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnToM
        '
        Me.btnToM.FlatAppearance.BorderSize = 2
        Me.btnToM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToM.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnToM.Location = New System.Drawing.Point(640, 230)
        Me.btnToM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnToM.Name = "btnToM"
        Me.btnToM.Size = New System.Drawing.Size(27, 26)
        Me.btnToM.TabIndex = 379
        Me.btnToM.Text = "Go Mark"
        Me.btnToM.UseVisualStyleBackColor = True
        Me.btnToM.Visible = False
        '
        'Label161
        '
        Me.Label161.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label161.Location = New System.Drawing.Point(530, 119)
        Me.Label161.Name = "Label161"
        Me.Label161.Size = New System.Drawing.Size(60, 19)
        Me.Label161.TabIndex = 378
        Me.Label161.Text = "결과 :"
        '
        'lblOK
        '
        Me.lblOK.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblOK.ForeColor = System.Drawing.Color.Black
        Me.lblOK.Location = New System.Drawing.Point(588, 114)
        Me.lblOK.Name = "lblOK"
        Me.lblOK.Size = New System.Drawing.Size(70, 24)
        Me.lblOK.TabIndex = 377
        Me.lblOK.Text = "--"
        Me.lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label164
        '
        Me.Label164.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label164.Location = New System.Drawing.Point(530, 198)
        Me.Label164.Name = "Label164"
        Me.Label164.Size = New System.Drawing.Size(51, 16)
        Me.Label164.TabIndex = 376
        Me.Label164.Text = "Pos Y :"
        '
        'Label165
        '
        Me.Label165.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label165.Location = New System.Drawing.Point(530, 173)
        Me.Label165.Name = "Label165"
        Me.Label165.Size = New System.Drawing.Size(52, 16)
        Me.Label165.TabIndex = 375
        Me.Label165.Text = "Pos X :"
        '
        'Label166
        '
        Me.Label166.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label166.Location = New System.Drawing.Point(530, 148)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(53, 16)
        Me.Label166.TabIndex = 374
        Me.Label166.Text = "Score :"
        '
        'ctrlAlignMarkSetting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.gbAlignA1_M1_L1)
        Me.Name = "ctrlAlignMarkSetting"
        Me.Size = New System.Drawing.Size(670, 259)
        Me.gbAlignA1_M1_L1.ResumeLayout(False)
        Me.gbAlignA1_M1_L1.PerformLayout()
        CType(Me.numCnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numModelSizeY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picModel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numModelSizeX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAcceptM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCertM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        CType(Me.numSizeY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSizeX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbAlignA1_M1_L1 As System.Windows.Forms.GroupBox
    Friend WithEvents numModelSizeY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numModelSizeX As System.Windows.Forms.NumericUpDown
    Friend WithEvents picModel As System.Windows.Forms.PictureBox
    Friend WithEvents btnModelCheck As System.Windows.Forms.Button
    Friend WithEvents btnModelApply As System.Windows.Forms.Button
    Friend WithEvents lblPosY As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents numSizeY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numSizeX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label156 As System.Windows.Forms.Label
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents lblStartY As System.Windows.Forms.Label
    Friend WithEvents btnSetRoi As System.Windows.Forms.Button
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents lblStartX As System.Windows.Forms.Label
    Friend WithEvents btnModelSetting As System.Windows.Forms.Button
    Friend WithEvents lblPosX As System.Windows.Forms.Label
    Friend WithEvents Label160 As System.Windows.Forms.Label
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents btnToM As System.Windows.Forms.Button
    Friend WithEvents Label161 As System.Windows.Forms.Label
    Friend WithEvents Label162 As System.Windows.Forms.Label
    Friend WithEvents lblOK As System.Windows.Forms.Label
    Friend WithEvents Label163 As System.Windows.Forms.Label
    Friend WithEvents Label164 As System.Windows.Forms.Label
    Friend WithEvents lblModel_OffsetY As System.Windows.Forms.Label
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents lblModel_OffsetX As System.Windows.Forms.Label
    Friend WithEvents numCertM As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label167 As System.Windows.Forms.Label
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents numAcceptM As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents chkMarkUse As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents lblRBX As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRBY As System.Windows.Forms.Label
    Friend WithEvents lblTLY As System.Windows.Forms.Label
    Friend WithEvents BtnDrowMODEL As System.Windows.Forms.Button
    Friend WithEvents BtnDrowROI As System.Windows.Forms.Button
    Friend WithEvents ChkRefPoint As System.Windows.Forms.CheckBox
    Friend WithEvents lblREFY As System.Windows.Forms.Label
    Friend WithEvents lblREFX As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCopy As System.Windows.Forms.Button
    Friend WithEvents BtnAcceptSave As System.Windows.Forms.Button
    Public WithEvents lblTLX As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numCnt As System.Windows.Forms.NumericUpDown

End Class
