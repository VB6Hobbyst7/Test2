<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlRecipeMarkEditor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbEditMark = New System.Windows.Forms.GroupBox()
        Me.btn_AllApply = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnTotalRApply = New System.Windows.Forms.Button()
        Me.btnTotalYApply = New System.Windows.Forms.Button()
        Me.btnTotalXApply = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numTotalPosition_T = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numTotalPosition_Y = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numTotalPosition_X = New System.Windows.Forms.NumericUpDown()
        Me.optSystemMode_Mode2 = New System.Windows.Forms.RadioButton()
        Me.optSystemMode_Mode1 = New System.Windows.Forms.RadioButton()
        Me.optSystemMode_Normal = New System.Windows.Forms.RadioButton()
        Me.gbVLine = New System.Windows.Forms.GroupBox()
        Me.chkVline = New System.Windows.Forms.CheckBox()
        Me.numV_LineRepeat = New System.Windows.Forms.NumericUpDown()
        Me.Label422 = New System.Windows.Forms.Label()
        Me.numV_LineMarkSpeed = New System.Windows.Forms.NumericUpDown()
        Me.Label459 = New System.Windows.Forms.Label()
        Me.Label465 = New System.Windows.Forms.Label()
        Me.Label468 = New System.Windows.Forms.Label()
        Me.Label473 = New System.Windows.Forms.Label()
        Me.Label476 = New System.Windows.Forms.Label()
        Me.numV_LineX1 = New System.Windows.Forms.NumericUpDown()
        Me.Label479 = New System.Windows.Forms.Label()
        Me.Label482 = New System.Windows.Forms.Label()
        Me.numV_LineY = New System.Windows.Forms.NumericUpDown()
        Me.numV_LineX2 = New System.Windows.Forms.NumericUpDown()
        Me.Label486 = New System.Windows.Forms.Label()
        Me.btnSelectPen = New System.Windows.Forms.Button()
        Me.btnSaveMarkData = New System.Windows.Forms.Button()
        Me.gbGroupEditer = New System.Windows.Forms.GroupBox()
        Me.GroupBox76 = New System.Windows.Forms.GroupBox()
        Me.Label487 = New System.Windows.Forms.Label()
        Me.lblGroupShowScale = New System.Windows.Forms.Label()
        Me.numGroupShowScale = New System.Windows.Forms.NumericUpDown()
        Me.numCurrentGroup = New System.Windows.Forms.NumericUpDown()
        Me.btnGroupApply = New System.Windows.Forms.Button()
        Me.btnGroupShow = New System.Windows.Forms.Button()
        Me.lblGroupAngle = New System.Windows.Forms.Label()
        Me.numGroupAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblGroupPosition_Y = New System.Windows.Forms.Label()
        Me.numGroupPosition_Y = New System.Windows.Forms.NumericUpDown()
        Me.lblGroupPosition_X = New System.Windows.Forms.Label()
        Me.numGroupPosition_X = New System.Windows.Forms.NumericUpDown()
        Me.lblCurrentPen = New System.Windows.Forms.Label()
        Me.numCurrentPen = New System.Windows.Forms.NumericUpDown()
        Me.dgvMarkData = New System.Windows.Forms.DataGridView()
        Me.Spec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Group_Num = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Group_Num2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Command = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Pos_X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pos_Y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Angle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value_X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value_Y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value_Angle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnApply = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.OutPos_X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutPos_Y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OutAngle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnShow = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.gbEditMark.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.numTotalPosition_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTotalPosition_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTotalPosition_X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVLine.SuspendLayout()
        CType(Me.numV_LineRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numV_LineMarkSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numV_LineX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numV_LineY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numV_LineX2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGroupEditer.SuspendLayout()
        Me.GroupBox76.SuspendLayout()
        CType(Me.numGroupShowScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCurrentGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGroupAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGroupPosition_Y, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGroupPosition_X, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCurrentPen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMarkData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbEditMark
        '
        Me.gbEditMark.Controls.Add(Me.btn_AllApply)
        Me.gbEditMark.Controls.Add(Me.GroupBox3)
        Me.gbEditMark.Controls.Add(Me.optSystemMode_Mode2)
        Me.gbEditMark.Controls.Add(Me.optSystemMode_Mode1)
        Me.gbEditMark.Controls.Add(Me.optSystemMode_Normal)
        Me.gbEditMark.Controls.Add(Me.gbVLine)
        Me.gbEditMark.Controls.Add(Me.btnSelectPen)
        Me.gbEditMark.Controls.Add(Me.btnSaveMarkData)
        Me.gbEditMark.Controls.Add(Me.gbGroupEditer)
        Me.gbEditMark.Controls.Add(Me.lblCurrentPen)
        Me.gbEditMark.Controls.Add(Me.numCurrentPen)
        Me.gbEditMark.Controls.Add(Me.dgvMarkData)
        Me.gbEditMark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEditMark.Location = New System.Drawing.Point(3, 3)
        Me.gbEditMark.Name = "gbEditMark"
        Me.gbEditMark.Size = New System.Drawing.Size(698, 820)
        Me.gbEditMark.TabIndex = 695
        Me.gbEditMark.TabStop = False
        Me.gbEditMark.Text = "Mark Data Editer"
        '
        'btn_AllApply
        '
        Me.btn_AllApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AllApply.Font = New System.Drawing.Font("맑은 고딕", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_AllApply.Location = New System.Drawing.Point(322, 758)
        Me.btn_AllApply.Name = "btn_AllApply"
        Me.btn_AllApply.Size = New System.Drawing.Size(97, 50)
        Me.btn_AllApply.TabIndex = 713
        Me.btn_AllApply.Text = "All Apply"
        Me.btn_AllApply.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnTotalRApply)
        Me.GroupBox3.Controls.Add(Me.btnTotalYApply)
        Me.GroupBox3.Controls.Add(Me.btnTotalXApply)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.numTotalPosition_T)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.numTotalPosition_Y)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.numTotalPosition_X)
        Me.GroupBox3.Location = New System.Drawing.Point(124, 117)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(565, 70)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Total Data(㎛)"
        '
        'btnTotalRApply
        '
        Me.btnTotalRApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTotalRApply.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTotalRApply.Location = New System.Drawing.Point(405, 39)
        Me.btnTotalRApply.Name = "btnTotalRApply"
        Me.btnTotalRApply.Size = New System.Drawing.Size(139, 23)
        Me.btnTotalRApply.TabIndex = 13
        Me.btnTotalRApply.Text = "OffsetR Apply"
        Me.btnTotalRApply.UseVisualStyleBackColor = True
        '
        'btnTotalYApply
        '
        Me.btnTotalYApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTotalYApply.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTotalYApply.Location = New System.Drawing.Point(204, 39)
        Me.btnTotalYApply.Name = "btnTotalYApply"
        Me.btnTotalYApply.Size = New System.Drawing.Size(138, 23)
        Me.btnTotalYApply.TabIndex = 12
        Me.btnTotalYApply.Text = "OffsetY Apply"
        Me.btnTotalYApply.UseVisualStyleBackColor = True
        '
        'btnTotalXApply
        '
        Me.btnTotalXApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTotalXApply.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTotalXApply.Location = New System.Drawing.Point(18, 40)
        Me.btnTotalXApply.Name = "btnTotalXApply"
        Me.btnTotalXApply.Size = New System.Drawing.Size(138, 23)
        Me.btnTotalXApply.TabIndex = 11
        Me.btnTotalXApply.Text = "OffsetX Apply"
        Me.btnTotalXApply.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(402, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 21)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Radius : "
        '
        'numTotalPosition_T
        '
        Me.numTotalPosition_T.DecimalPlaces = 3
        Me.numTotalPosition_T.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numTotalPosition_T.Location = New System.Drawing.Point(476, 15)
        Me.numTotalPosition_T.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numTotalPosition_T.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.numTotalPosition_T.Name = "numTotalPosition_T"
        Me.numTotalPosition_T.Size = New System.Drawing.Size(68, 21)
        Me.numTotalPosition_T.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(201, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Offset Y : "
        '
        'numTotalPosition_Y
        '
        Me.numTotalPosition_Y.DecimalPlaces = 3
        Me.numTotalPosition_Y.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numTotalPosition_Y.Location = New System.Drawing.Point(275, 15)
        Me.numTotalPosition_Y.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numTotalPosition_Y.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.numTotalPosition_Y.Name = "numTotalPosition_Y"
        Me.numTotalPosition_Y.Size = New System.Drawing.Size(68, 21)
        Me.numTotalPosition_Y.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 21)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Offset X : "
        '
        'numTotalPosition_X
        '
        Me.numTotalPosition_X.DecimalPlaces = 3
        Me.numTotalPosition_X.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numTotalPosition_X.Location = New System.Drawing.Point(88, 15)
        Me.numTotalPosition_X.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numTotalPosition_X.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.numTotalPosition_X.Name = "numTotalPosition_X"
        Me.numTotalPosition_X.Size = New System.Drawing.Size(68, 21)
        Me.numTotalPosition_X.TabIndex = 0
        '
        'optSystemMode_Mode2
        '
        Me.optSystemMode_Mode2.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSystemMode_Mode2.Enabled = False
        Me.optSystemMode_Mode2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSystemMode_Mode2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.optSystemMode_Mode2.Location = New System.Drawing.Point(200, 763)
        Me.optSystemMode_Mode2.Name = "optSystemMode_Mode2"
        Me.optSystemMode_Mode2.Size = New System.Drawing.Size(91, 45)
        Me.optSystemMode_Mode2.TabIndex = 712
        Me.optSystemMode_Mode2.Text = "Mode 2"
        Me.optSystemMode_Mode2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSystemMode_Mode2.UseVisualStyleBackColor = True
        Me.optSystemMode_Mode2.Visible = False
        '
        'optSystemMode_Mode1
        '
        Me.optSystemMode_Mode1.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSystemMode_Mode1.Checked = True
        Me.optSystemMode_Mode1.Enabled = False
        Me.optSystemMode_Mode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSystemMode_Mode1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.optSystemMode_Mode1.Location = New System.Drawing.Point(103, 763)
        Me.optSystemMode_Mode1.Name = "optSystemMode_Mode1"
        Me.optSystemMode_Mode1.Size = New System.Drawing.Size(91, 45)
        Me.optSystemMode_Mode1.TabIndex = 711
        Me.optSystemMode_Mode1.TabStop = True
        Me.optSystemMode_Mode1.Text = "Mode 1"
        Me.optSystemMode_Mode1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSystemMode_Mode1.UseVisualStyleBackColor = True
        Me.optSystemMode_Mode1.Visible = False
        '
        'optSystemMode_Normal
        '
        Me.optSystemMode_Normal.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSystemMode_Normal.Enabled = False
        Me.optSystemMode_Normal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSystemMode_Normal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.optSystemMode_Normal.Location = New System.Drawing.Point(6, 763)
        Me.optSystemMode_Normal.Name = "optSystemMode_Normal"
        Me.optSystemMode_Normal.Size = New System.Drawing.Size(91, 45)
        Me.optSystemMode_Normal.TabIndex = 710
        Me.optSystemMode_Normal.Text = "Normal"
        Me.optSystemMode_Normal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSystemMode_Normal.UseVisualStyleBackColor = True
        Me.optSystemMode_Normal.Visible = False
        '
        'gbVLine
        '
        Me.gbVLine.Controls.Add(Me.chkVline)
        Me.gbVLine.Controls.Add(Me.numV_LineRepeat)
        Me.gbVLine.Controls.Add(Me.Label422)
        Me.gbVLine.Controls.Add(Me.numV_LineMarkSpeed)
        Me.gbVLine.Controls.Add(Me.Label459)
        Me.gbVLine.Controls.Add(Me.Label465)
        Me.gbVLine.Controls.Add(Me.Label468)
        Me.gbVLine.Controls.Add(Me.Label473)
        Me.gbVLine.Controls.Add(Me.Label476)
        Me.gbVLine.Controls.Add(Me.numV_LineX1)
        Me.gbVLine.Controls.Add(Me.Label479)
        Me.gbVLine.Controls.Add(Me.Label482)
        Me.gbVLine.Controls.Add(Me.numV_LineY)
        Me.gbVLine.Controls.Add(Me.numV_LineX2)
        Me.gbVLine.Controls.Add(Me.Label486)
        Me.gbVLine.Location = New System.Drawing.Point(6, 172)
        Me.gbVLine.Name = "gbVLine"
        Me.gbVLine.Size = New System.Drawing.Size(686, 10)
        Me.gbVLine.TabIndex = 709
        Me.gbVLine.TabStop = False
        Me.gbVLine.Text = "V-Line Data"
        Me.gbVLine.Visible = False
        '
        'chkVline
        '
        Me.chkVline.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkVline.Checked = True
        Me.chkVline.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVline.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVline.Location = New System.Drawing.Point(625, 21)
        Me.chkVline.Name = "chkVline"
        Me.chkVline.Size = New System.Drawing.Size(51, 26)
        Me.chkVline.TabIndex = 715
        Me.chkVline.Text = "First"
        Me.chkVline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkVline.UseVisualStyleBackColor = True
        '
        'numV_LineRepeat
        '
        Me.numV_LineRepeat.Location = New System.Drawing.Point(583, 24)
        Me.numV_LineRepeat.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.numV_LineRepeat.Name = "numV_LineRepeat"
        Me.numV_LineRepeat.Size = New System.Drawing.Size(36, 21)
        Me.numV_LineRepeat.TabIndex = 713
        Me.numV_LineRepeat.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label422
        '
        Me.Label422.AutoSize = True
        Me.Label422.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label422.Location = New System.Drawing.Point(531, 26)
        Me.Label422.Name = "Label422"
        Me.Label422.Size = New System.Drawing.Size(53, 15)
        Me.Label422.TabIndex = 712
        Me.Label422.Text = "Repeat :"
        '
        'numV_LineMarkSpeed
        '
        Me.numV_LineMarkSpeed.Location = New System.Drawing.Point(417, 24)
        Me.numV_LineMarkSpeed.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.numV_LineMarkSpeed.Name = "numV_LineMarkSpeed"
        Me.numV_LineMarkSpeed.Size = New System.Drawing.Size(65, 21)
        Me.numV_LineMarkSpeed.TabIndex = 710
        Me.numV_LineMarkSpeed.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label459
        '
        Me.Label459.AutoSize = True
        Me.Label459.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label459.Location = New System.Drawing.Point(366, 26)
        Me.Label459.Name = "Label459"
        Me.Label459.Size = New System.Drawing.Size(49, 15)
        Me.Label459.TabIndex = 711
        Me.Label459.Text = "Speed :"
        '
        'Label465
        '
        Me.Label465.AutoSize = True
        Me.Label465.Location = New System.Drawing.Point(485, 26)
        Me.Label465.Name = "Label465"
        Me.Label465.Size = New System.Drawing.Size(39, 15)
        Me.Label465.TabIndex = 709
        Me.Label465.Text = "mm/s"
        '
        'Label468
        '
        Me.Label468.AutoSize = True
        Me.Label468.Location = New System.Drawing.Point(335, 26)
        Me.Label468.Name = "Label468"
        Me.Label468.Size = New System.Drawing.Size(29, 15)
        Me.Label468.TabIndex = 698
        Me.Label468.Text = "mm"
        '
        'Label473
        '
        Me.Label473.AutoSize = True
        Me.Label473.Location = New System.Drawing.Point(220, 26)
        Me.Label473.Name = "Label473"
        Me.Label473.Size = New System.Drawing.Size(29, 15)
        Me.Label473.TabIndex = 148
        Me.Label473.Text = "mm"
        '
        'Label476
        '
        Me.Label476.AutoSize = True
        Me.Label476.Location = New System.Drawing.Point(99, 26)
        Me.Label476.Name = "Label476"
        Me.Label476.Size = New System.Drawing.Size(29, 15)
        Me.Label476.TabIndex = 148
        Me.Label476.Text = "mm"
        '
        'numV_LineX1
        '
        Me.numV_LineX1.DecimalPlaces = 3
        Me.numV_LineX1.Location = New System.Drawing.Point(37, 24)
        Me.numV_LineX1.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numV_LineX1.Minimum = New Decimal(New Integer() {30, 0, 0, -2147483648})
        Me.numV_LineX1.Name = "numV_LineX1"
        Me.numV_LineX1.Size = New System.Drawing.Size(60, 21)
        Me.numV_LineX1.TabIndex = 692
        '
        'Label479
        '
        Me.Label479.AutoSize = True
        Me.Label479.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label479.Location = New System.Drawing.Point(251, 26)
        Me.Label479.Name = "Label479"
        Me.Label479.Size = New System.Drawing.Size(20, 15)
        Me.Label479.TabIndex = 695
        Me.Label479.Text = "Y :"
        '
        'Label482
        '
        Me.Label482.AutoSize = True
        Me.Label482.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label482.Location = New System.Drawing.Point(9, 26)
        Me.Label482.Name = "Label482"
        Me.Label482.Size = New System.Drawing.Size(27, 15)
        Me.Label482.TabIndex = 691
        Me.Label482.Text = "X1 :"
        '
        'numV_LineY
        '
        Me.numV_LineY.DecimalPlaces = 3
        Me.numV_LineY.Location = New System.Drawing.Point(272, 24)
        Me.numV_LineY.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numV_LineY.Minimum = New Decimal(New Integer() {30, 0, 0, -2147483648})
        Me.numV_LineY.Name = "numV_LineY"
        Me.numV_LineY.Size = New System.Drawing.Size(60, 21)
        Me.numV_LineY.TabIndex = 696
        '
        'numV_LineX2
        '
        Me.numV_LineX2.DecimalPlaces = 3
        Me.numV_LineX2.Location = New System.Drawing.Point(158, 24)
        Me.numV_LineX2.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numV_LineX2.Minimum = New Decimal(New Integer() {30, 0, 0, -2147483648})
        Me.numV_LineX2.Name = "numV_LineX2"
        Me.numV_LineX2.Size = New System.Drawing.Size(60, 21)
        Me.numV_LineX2.TabIndex = 694
        '
        'Label486
        '
        Me.Label486.AutoSize = True
        Me.Label486.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label486.Location = New System.Drawing.Point(130, 26)
        Me.Label486.Name = "Label486"
        Me.Label486.Size = New System.Drawing.Size(27, 15)
        Me.Label486.TabIndex = 693
        Me.Label486.Text = "X2 :"
        '
        'btnSelectPen
        '
        Me.btnSelectPen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectPen.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectPen.Location = New System.Drawing.Point(19, 69)
        Me.btnSelectPen.Name = "btnSelectPen"
        Me.btnSelectPen.Size = New System.Drawing.Size(96, 31)
        Me.btnSelectPen.TabIndex = 3
        Me.btnSelectPen.Text = "선택"
        Me.btnSelectPen.UseVisualStyleBackColor = True
        '
        'btnSaveMarkData
        '
        Me.btnSaveMarkData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveMarkData.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveMarkData.Location = New System.Drawing.Point(425, 758)
        Me.btnSaveMarkData.Name = "btnSaveMarkData"
        Me.btnSaveMarkData.Size = New System.Drawing.Size(269, 50)
        Me.btnSaveMarkData.TabIndex = 12
        Me.btnSaveMarkData.Text = "Save Mark Data"
        Me.btnSaveMarkData.UseVisualStyleBackColor = True
        '
        'gbGroupEditer
        '
        Me.gbGroupEditer.Controls.Add(Me.GroupBox76)
        Me.gbGroupEditer.Location = New System.Drawing.Point(124, 17)
        Me.gbGroupEditer.Name = "gbGroupEditer"
        Me.gbGroupEditer.Size = New System.Drawing.Size(565, 99)
        Me.gbGroupEditer.TabIndex = 8
        Me.gbGroupEditer.TabStop = False
        Me.gbGroupEditer.Text = "Group Editer(㎛)"
        '
        'GroupBox76
        '
        Me.GroupBox76.Controls.Add(Me.Label487)
        Me.GroupBox76.Controls.Add(Me.lblGroupShowScale)
        Me.GroupBox76.Controls.Add(Me.numGroupShowScale)
        Me.GroupBox76.Controls.Add(Me.numCurrentGroup)
        Me.GroupBox76.Controls.Add(Me.btnGroupApply)
        Me.GroupBox76.Controls.Add(Me.btnGroupShow)
        Me.GroupBox76.Controls.Add(Me.lblGroupAngle)
        Me.GroupBox76.Controls.Add(Me.numGroupAngle)
        Me.GroupBox76.Controls.Add(Me.lblGroupPosition_Y)
        Me.GroupBox76.Controls.Add(Me.numGroupPosition_Y)
        Me.GroupBox76.Controls.Add(Me.lblGroupPosition_X)
        Me.GroupBox76.Controls.Add(Me.numGroupPosition_X)
        Me.GroupBox76.Location = New System.Drawing.Point(8, 14)
        Me.GroupBox76.Name = "GroupBox76"
        Me.GroupBox76.Size = New System.Drawing.Size(549, 79)
        Me.GroupBox76.TabIndex = 4
        Me.GroupBox76.TabStop = False
        Me.GroupBox76.Text = "Data"
        '
        'Label487
        '
        Me.Label487.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label487.Location = New System.Drawing.Point(7, 52)
        Me.Label487.Name = "Label487"
        Me.Label487.Size = New System.Drawing.Size(60, 15)
        Me.Label487.TabIndex = 14
        Me.Label487.Text = "Group : "
        '
        'lblGroupShowScale
        '
        Me.lblGroupShowScale.Location = New System.Drawing.Point(155, 52)
        Me.lblGroupShowScale.Name = "lblGroupShowScale"
        Me.lblGroupShowScale.Size = New System.Drawing.Size(81, 15)
        Me.lblGroupShowScale.TabIndex = 13
        Me.lblGroupShowScale.Text = "Show Scale : "
        '
        'numGroupShowScale
        '
        Me.numGroupShowScale.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numGroupShowScale.Location = New System.Drawing.Point(242, 50)
        Me.numGroupShowScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numGroupShowScale.Name = "numGroupShowScale"
        Me.numGroupShowScale.Size = New System.Drawing.Size(56, 21)
        Me.numGroupShowScale.TabIndex = 12
        Me.numGroupShowScale.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'numCurrentGroup
        '
        Me.numCurrentGroup.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.numCurrentGroup.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCurrentGroup.Location = New System.Drawing.Point(71, 50)
        Me.numCurrentGroup.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numCurrentGroup.Name = "numCurrentGroup"
        Me.numCurrentGroup.Size = New System.Drawing.Size(68, 21)
        Me.numCurrentGroup.TabIndex = 2
        Me.numCurrentGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnGroupApply
        '
        Me.btnGroupApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGroupApply.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGroupApply.Location = New System.Drawing.Point(315, 45)
        Me.btnGroupApply.Name = "btnGroupApply"
        Me.btnGroupApply.Size = New System.Drawing.Size(125, 29)
        Me.btnGroupApply.TabIndex = 11
        Me.btnGroupApply.Text = "Apply"
        Me.btnGroupApply.UseVisualStyleBackColor = True
        '
        'btnGroupShow
        '
        Me.btnGroupShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGroupShow.Location = New System.Drawing.Point(453, 16)
        Me.btnGroupShow.Name = "btnGroupShow"
        Me.btnGroupShow.Size = New System.Drawing.Size(83, 58)
        Me.btnGroupShow.TabIndex = 8
        Me.btnGroupShow.Text = "Show"
        Me.btnGroupShow.UseVisualStyleBackColor = True
        '
        'lblGroupAngle
        '
        Me.lblGroupAngle.Enabled = False
        Me.lblGroupAngle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupAngle.Location = New System.Drawing.Point(312, 20)
        Me.lblGroupAngle.Name = "lblGroupAngle"
        Me.lblGroupAngle.Size = New System.Drawing.Size(60, 15)
        Me.lblGroupAngle.TabIndex = 5
        Me.lblGroupAngle.Text = "Radius : "
        Me.lblGroupAngle.Visible = False
        '
        'numGroupAngle
        '
        Me.numGroupAngle.DecimalPlaces = 3
        Me.numGroupAngle.Enabled = False
        Me.numGroupAngle.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numGroupAngle.Location = New System.Drawing.Point(372, 18)
        Me.numGroupAngle.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numGroupAngle.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.numGroupAngle.Name = "numGroupAngle"
        Me.numGroupAngle.Size = New System.Drawing.Size(68, 21)
        Me.numGroupAngle.TabIndex = 4
        Me.numGroupAngle.Visible = False
        '
        'lblGroupPosition_Y
        '
        Me.lblGroupPosition_Y.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupPosition_Y.Location = New System.Drawing.Point(155, 20)
        Me.lblGroupPosition_Y.Name = "lblGroupPosition_Y"
        Me.lblGroupPosition_Y.Size = New System.Drawing.Size(60, 15)
        Me.lblGroupPosition_Y.TabIndex = 3
        Me.lblGroupPosition_Y.Text = "Offset Y : "
        '
        'numGroupPosition_Y
        '
        Me.numGroupPosition_Y.DecimalPlaces = 3
        Me.numGroupPosition_Y.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numGroupPosition_Y.Location = New System.Drawing.Point(230, 18)
        Me.numGroupPosition_Y.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numGroupPosition_Y.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.numGroupPosition_Y.Name = "numGroupPosition_Y"
        Me.numGroupPosition_Y.Size = New System.Drawing.Size(68, 21)
        Me.numGroupPosition_Y.TabIndex = 2
        '
        'lblGroupPosition_X
        '
        Me.lblGroupPosition_X.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupPosition_X.Location = New System.Drawing.Point(7, 20)
        Me.lblGroupPosition_X.Name = "lblGroupPosition_X"
        Me.lblGroupPosition_X.Size = New System.Drawing.Size(60, 15)
        Me.lblGroupPosition_X.TabIndex = 1
        Me.lblGroupPosition_X.Text = "Offset X : "
        '
        'numGroupPosition_X
        '
        Me.numGroupPosition_X.DecimalPlaces = 3
        Me.numGroupPosition_X.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numGroupPosition_X.Location = New System.Drawing.Point(71, 18)
        Me.numGroupPosition_X.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numGroupPosition_X.Minimum = New Decimal(New Integer() {50, 0, 0, -2147483648})
        Me.numGroupPosition_X.Name = "numGroupPosition_X"
        Me.numGroupPosition_X.Size = New System.Drawing.Size(68, 21)
        Me.numGroupPosition_X.TabIndex = 0
        '
        'lblCurrentPen
        '
        Me.lblCurrentPen.AutoSize = True
        Me.lblCurrentPen.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPen.Location = New System.Drawing.Point(18, 34)
        Me.lblCurrentPen.Name = "lblCurrentPen"
        Me.lblCurrentPen.Size = New System.Drawing.Size(45, 16)
        Me.lblCurrentPen.TabIndex = 7
        Me.lblCurrentPen.Text = "Pen : "
        '
        'numCurrentPen
        '
        Me.numCurrentPen.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCurrentPen.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCurrentPen.Location = New System.Drawing.Point(66, 30)
        Me.numCurrentPen.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numCurrentPen.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCurrentPen.Name = "numCurrentPen"
        Me.numCurrentPen.Size = New System.Drawing.Size(50, 26)
        Me.numCurrentPen.TabIndex = 6
        Me.numCurrentPen.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dgvMarkData
        '
        Me.dgvMarkData.AllowUserToAddRows = False
        Me.dgvMarkData.AllowUserToDeleteRows = False
        Me.dgvMarkData.AllowUserToResizeColumns = False
        Me.dgvMarkData.AllowUserToResizeRows = False
        Me.dgvMarkData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMarkData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Spec, Me.Index, Me.Group_Num, Me.Group_Num2, Me.Command, Me.Pos_X, Me.Pos_Y, Me.Angle, Me.Value_X, Me.Value_Y, Me.Value_Angle, Me.btnApply, Me.OutPos_X, Me.OutPos_Y, Me.OutAngle, Me.btnShow})
        Me.dgvMarkData.Location = New System.Drawing.Point(2, 188)
        Me.dgvMarkData.Name = "dgvMarkData"
        Me.dgvMarkData.RowHeadersVisible = False
        Me.dgvMarkData.RowTemplate.Height = 23
        Me.dgvMarkData.Size = New System.Drawing.Size(692, 559)
        Me.dgvMarkData.TabIndex = 1
        '
        'Spec
        '
        Me.Spec.HeaderText = "Spec"
        Me.Spec.Name = "Spec"
        Me.Spec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Spec.Width = 50
        '
        'Index
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Index.DefaultCellStyle = DataGridViewCellStyle1
        Me.Index.HeaderText = "Idx"
        Me.Index.Name = "Index"
        Me.Index.ReadOnly = True
        Me.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Index.Width = 30
        '
        'Group_Num
        '
        DataGridViewCellStyle2.NullValue = "1"
        Me.Group_Num.DefaultCellStyle = DataGridViewCellStyle2
        Me.Group_Num.HeaderText = "Group X"
        Me.Group_Num.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
        Me.Group_Num.Name = "Group_Num"
        Me.Group_Num.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Group_Num.Width = 45
        '
        'Group_Num2
        '
        DataGridViewCellStyle3.NullValue = "1"
        Me.Group_Num2.DefaultCellStyle = DataGridViewCellStyle3
        Me.Group_Num2.HeaderText = "Group Y"
        Me.Group_Num2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99"})
        Me.Group_Num2.Name = "Group_Num2"
        Me.Group_Num2.Width = 45
        '
        'Command
        '
        DataGridViewCellStyle4.NullValue = "JA"
        Me.Command.DefaultCellStyle = DataGridViewCellStyle4
        Me.Command.HeaderText = "Cmd"
        Me.Command.Items.AddRange(New Object() {"JA", "MA", "AA"})
        Me.Command.Name = "Command"
        Me.Command.ReadOnly = True
        Me.Command.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Command.Width = 50
        '
        'Pos_X
        '
        DataGridViewCellStyle5.NullValue = "000.000"
        Me.Pos_X.DefaultCellStyle = DataGridViewCellStyle5
        Me.Pos_X.HeaderText = "Pos X"
        Me.Pos_X.Name = "Pos_X"
        Me.Pos_X.ReadOnly = True
        Me.Pos_X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Pos_X.Width = 54
        '
        'Pos_Y
        '
        DataGridViewCellStyle6.NullValue = "000.000"
        Me.Pos_Y.DefaultCellStyle = DataGridViewCellStyle6
        Me.Pos_Y.HeaderText = "Pos Y"
        Me.Pos_Y.Name = "Pos_Y"
        Me.Pos_Y.ReadOnly = True
        Me.Pos_Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Pos_Y.Width = 54
        '
        'Angle
        '
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "00.000"
        Me.Angle.DefaultCellStyle = DataGridViewCellStyle7
        Me.Angle.HeaderText = "Radius"
        Me.Angle.Name = "Angle"
        Me.Angle.ReadOnly = True
        Me.Angle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Angle.Width = 50
        '
        'Value_X
        '
        DataGridViewCellStyle8.Format = "N3"
        DataGridViewCellStyle8.NullValue = "0"
        Me.Value_X.DefaultCellStyle = DataGridViewCellStyle8
        Me.Value_X.HeaderText = "Value X"
        Me.Value_X.Name = "Value_X"
        Me.Value_X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Value_X.Width = 54
        '
        'Value_Y
        '
        DataGridViewCellStyle9.Format = "N3"
        DataGridViewCellStyle9.NullValue = "0"
        Me.Value_Y.DefaultCellStyle = DataGridViewCellStyle9
        Me.Value_Y.HeaderText = "Value Y"
        Me.Value_Y.Name = "Value_Y"
        Me.Value_Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Value_Y.Width = 54
        '
        'Value_Angle
        '
        DataGridViewCellStyle10.Format = "N3"
        DataGridViewCellStyle10.NullValue = "0"
        Me.Value_Angle.DefaultCellStyle = DataGridViewCellStyle10
        Me.Value_Angle.HeaderText = "Value Radius"
        Me.Value_Angle.Name = "Value_Angle"
        Me.Value_Angle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Value_Angle.Width = 50
        '
        'btnApply
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.NullValue = "Apply"
        Me.btnApply.DefaultCellStyle = DataGridViewCellStyle11
        Me.btnApply.HeaderText = "Value Apply"
        Me.btnApply.Name = "btnApply"
        Me.btnApply.ReadOnly = True
        Me.btnApply.Text = "Apply"
        Me.btnApply.Width = 45
        '
        'OutPos_X
        '
        DataGridViewCellStyle12.NullValue = "000.000"
        Me.OutPos_X.DefaultCellStyle = DataGridViewCellStyle12
        Me.OutPos_X.HeaderText = "Adjust Pos X"
        Me.OutPos_X.Name = "OutPos_X"
        Me.OutPos_X.ReadOnly = True
        Me.OutPos_X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OutPos_X.Width = 54
        '
        'OutPos_Y
        '
        DataGridViewCellStyle13.NullValue = "000.000"
        Me.OutPos_Y.DefaultCellStyle = DataGridViewCellStyle13
        Me.OutPos_Y.HeaderText = "Adjust Pos Y"
        Me.OutPos_Y.Name = "OutPos_Y"
        Me.OutPos_Y.ReadOnly = True
        Me.OutPos_Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OutPos_Y.Width = 54
        '
        'OutAngle
        '
        DataGridViewCellStyle14.NullValue = "00.000"
        Me.OutAngle.DefaultCellStyle = DataGridViewCellStyle14
        Me.OutAngle.HeaderText = "Adjust Radius"
        Me.OutAngle.Name = "OutAngle"
        Me.OutAngle.ReadOnly = True
        Me.OutAngle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.OutAngle.Width = 50
        '
        'btnShow
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.NullValue = "Show"
        Me.btnShow.DefaultCellStyle = DataGridViewCellStyle15
        Me.btnShow.HeaderText = "Show"
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Text = "Show"
        Me.btnShow.Width = 45
        '
        'ctrlRecipeMarkEditor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.gbEditMark)
        Me.Name = "ctrlRecipeMarkEditor"
        Me.Size = New System.Drawing.Size(703, 825)
        Me.gbEditMark.ResumeLayout(False)
        Me.gbEditMark.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.numTotalPosition_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTotalPosition_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTotalPosition_X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVLine.ResumeLayout(False)
        Me.gbVLine.PerformLayout()
        CType(Me.numV_LineRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numV_LineMarkSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numV_LineX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numV_LineY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numV_LineX2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGroupEditer.ResumeLayout(False)
        Me.GroupBox76.ResumeLayout(False)
        CType(Me.numGroupShowScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCurrentGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGroupAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGroupPosition_Y, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGroupPosition_X, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCurrentPen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMarkData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbEditMark As System.Windows.Forms.GroupBox
    Friend WithEvents optSystemMode_Mode2 As System.Windows.Forms.RadioButton
    Friend WithEvents optSystemMode_Mode1 As System.Windows.Forms.RadioButton
    Friend WithEvents optSystemMode_Normal As System.Windows.Forms.RadioButton
    Friend WithEvents gbVLine As System.Windows.Forms.GroupBox
    Friend WithEvents chkVline As System.Windows.Forms.CheckBox
    Friend WithEvents numV_LineRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label422 As System.Windows.Forms.Label
    Friend WithEvents numV_LineMarkSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label459 As System.Windows.Forms.Label
    Friend WithEvents Label465 As System.Windows.Forms.Label
    Friend WithEvents Label468 As System.Windows.Forms.Label
    Friend WithEvents Label473 As System.Windows.Forms.Label
    Friend WithEvents Label476 As System.Windows.Forms.Label
    Friend WithEvents numV_LineX1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label479 As System.Windows.Forms.Label
    Friend WithEvents Label482 As System.Windows.Forms.Label
    Friend WithEvents numV_LineY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numV_LineX2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label486 As System.Windows.Forms.Label
    Friend WithEvents btnSelectPen As System.Windows.Forms.Button
    Friend WithEvents btnSaveMarkData As System.Windows.Forms.Button
    Friend WithEvents gbGroupEditer As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox76 As System.Windows.Forms.GroupBox
    Friend WithEvents Label487 As System.Windows.Forms.Label
    Friend WithEvents lblGroupShowScale As System.Windows.Forms.Label
    Friend WithEvents numGroupShowScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents numCurrentGroup As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnGroupApply As System.Windows.Forms.Button
    Friend WithEvents btnGroupShow As System.Windows.Forms.Button
    Friend WithEvents lblGroupAngle As System.Windows.Forms.Label
    Friend WithEvents numGroupAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblGroupPosition_Y As System.Windows.Forms.Label
    Friend WithEvents numGroupPosition_Y As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblGroupPosition_X As System.Windows.Forms.Label
    Friend WithEvents numGroupPosition_X As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblCurrentPen As System.Windows.Forms.Label
    Friend WithEvents numCurrentPen As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgvMarkData As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTotalXApply As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numTotalPosition_T As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numTotalPosition_Y As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numTotalPosition_X As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnTotalRApply As System.Windows.Forms.Button
    Friend WithEvents btnTotalYApply As System.Windows.Forms.Button
    Friend WithEvents btn_AllApply As System.Windows.Forms.Button
    Friend WithEvents Spec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Group_Num As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Group_Num2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Command As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Pos_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pos_Y As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Angle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value_Y As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value_Angle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnApply As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents OutPos_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutPos_Y As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutAngle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnShow As System.Windows.Forms.DataGridViewButtonColumn

End Class
