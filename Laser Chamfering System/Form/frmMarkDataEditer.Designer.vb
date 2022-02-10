<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarkDataEditer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarkDataEditer))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chkInverse = New System.Windows.Forms.CheckBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.numPointSize = New System.Windows.Forms.NumericUpDown()
        Me.pbPreview = New System.Windows.Forms.PictureBox()
        Me.btnCenter = New System.Windows.Forms.Button()
        Me.btnLeftX = New System.Windows.Forms.Button()
        Me.numOffset = New System.Windows.Forms.NumericUpDown()
        Me.btnRightX = New System.Windows.Forms.Button()
        Me.btnDnY = New System.Windows.Forms.Button()
        Me.btnUPY = New System.Windows.Forms.Button()
        Me.btnZoom = New System.Windows.Forms.Button()
        Me.btnZoomOut = New System.Windows.Forms.Button()
        Me.btnZoomIn = New System.Windows.Forms.Button()
        Me.lblMarkDataName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblX_Minus = New System.Windows.Forms.Label()
        Me.lblY_Plus = New System.Windows.Forms.Label()
        Me.lblX_Plus = New System.Windows.Forms.Label()
        Me.lblY_Minus = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPenDataApply = New System.Windows.Forms.Button()
        Me.cbMarkMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numMarkRepeat = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numJumpSpd = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numMarkSpd = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPenNumver = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvPenData = New System.Windows.Forms.DataGridView()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarkSpeed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JumpSpeed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarkRepeat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarkMode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.chkTopBottom = New System.Windows.Forms.CheckBox()
        Me.lblStatusY = New System.Windows.Forms.Label()
        CType(Me.numPointSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numMarkRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numJumpSpd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMarkSpd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvPenData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkInverse
        '
        Me.chkInverse.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkInverse.Checked = True
        Me.chkInverse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInverse.Enabled = False
        Me.chkInverse.Location = New System.Drawing.Point(639, 131)
        Me.chkInverse.Name = "chkInverse"
        Me.chkInverse.Size = New System.Drawing.Size(46, 40)
        Me.chkInverse.TabIndex = 3
        Me.chkInverse.Text = "Back"
        Me.chkInverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInverse.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Black
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(542, 34)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(137, 20)
        Me.lblStatus.TabIndex = 534
        Me.lblStatus.Text = "Back"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numPointSize
        '
        Me.numPointSize.Location = New System.Drawing.Point(640, 655)
        Me.numPointSize.Name = "numPointSize"
        Me.numPointSize.Size = New System.Drawing.Size(41, 21)
        Me.numPointSize.TabIndex = 1
        Me.numPointSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numPointSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pbPreview
        '
        Me.pbPreview.BackColor = System.Drawing.Color.Black
        Me.pbPreview.Location = New System.Drawing.Point(10, 20)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(600, 600)
        Me.pbPreview.TabIndex = 0
        Me.pbPreview.TabStop = False
        '
        'btnCenter
        '
        Me.btnCenter.BackColor = System.Drawing.Color.White
        Me.btnCenter.FlatAppearance.BorderSize = 2
        Me.btnCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCenter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCenter.Image = CType(resources.GetObject("btnCenter.Image"), System.Drawing.Image)
        Me.btnCenter.Location = New System.Drawing.Point(641, 493)
        Me.btnCenter.Name = "btnCenter"
        Me.btnCenter.Size = New System.Drawing.Size(40, 40)
        Me.btnCenter.TabIndex = 532
        Me.btnCenter.TabStop = False
        Me.btnCenter.Tag = "X1R"
        Me.btnCenter.UseVisualStyleBackColor = False
        '
        'btnLeftX
        '
        Me.btnLeftX.BackColor = System.Drawing.Color.White
        Me.btnLeftX.FlatAppearance.BorderSize = 2
        Me.btnLeftX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLeftX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeftX.Location = New System.Drawing.Point(641, 445)
        Me.btnLeftX.Name = "btnLeftX"
        Me.btnLeftX.Size = New System.Drawing.Size(40, 40)
        Me.btnLeftX.TabIndex = 528
        Me.btnLeftX.TabStop = False
        Me.btnLeftX.Tag = "X1L"
        Me.btnLeftX.Text = "X-"
        Me.btnLeftX.UseVisualStyleBackColor = False
        '
        'numOffset
        '
        Me.numOffset.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numOffset.Location = New System.Drawing.Point(641, 367)
        Me.numOffset.Name = "numOffset"
        Me.numOffset.Size = New System.Drawing.Size(40, 22)
        Me.numOffset.TabIndex = 531
        Me.numOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numOffset.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'btnRightX
        '
        Me.btnRightX.BackColor = System.Drawing.Color.White
        Me.btnRightX.FlatAppearance.BorderSize = 2
        Me.btnRightX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRightX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRightX.Location = New System.Drawing.Point(641, 397)
        Me.btnRightX.Name = "btnRightX"
        Me.btnRightX.Size = New System.Drawing.Size(40, 40)
        Me.btnRightX.TabIndex = 527
        Me.btnRightX.TabStop = False
        Me.btnRightX.Tag = "X1R"
        Me.btnRightX.Text = "X+"
        Me.btnRightX.UseVisualStyleBackColor = False
        '
        'btnDnY
        '
        Me.btnDnY.BackColor = System.Drawing.Color.White
        Me.btnDnY.FlatAppearance.BorderSize = 2
        Me.btnDnY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDnY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDnY.Location = New System.Drawing.Point(641, 589)
        Me.btnDnY.Name = "btnDnY"
        Me.btnDnY.Size = New System.Drawing.Size(40, 40)
        Me.btnDnY.TabIndex = 530
        Me.btnDnY.TabStop = False
        Me.btnDnY.Tag = "Y1D"
        Me.btnDnY.Text = "Y -"
        Me.btnDnY.UseVisualStyleBackColor = False
        '
        'btnUPY
        '
        Me.btnUPY.BackColor = System.Drawing.Color.White
        Me.btnUPY.FlatAppearance.BorderSize = 2
        Me.btnUPY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUPY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUPY.Location = New System.Drawing.Point(641, 541)
        Me.btnUPY.Name = "btnUPY"
        Me.btnUPY.Size = New System.Drawing.Size(40, 40)
        Me.btnUPY.TabIndex = 529
        Me.btnUPY.TabStop = False
        Me.btnUPY.Tag = "Y1U"
        Me.btnUPY.Text = "Y +"
        Me.btnUPY.UseVisualStyleBackColor = False
        '
        'btnZoom
        '
        Me.btnZoom.BackColor = System.Drawing.Color.White
        Me.btnZoom.FlatAppearance.BorderSize = 2
        Me.btnZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoom.Image = CType(resources.GetObject("btnZoom.Image"), System.Drawing.Image)
        Me.btnZoom.Location = New System.Drawing.Point(641, 245)
        Me.btnZoom.Name = "btnZoom"
        Me.btnZoom.Size = New System.Drawing.Size(40, 40)
        Me.btnZoom.TabIndex = 526
        Me.btnZoom.TabStop = False
        Me.btnZoom.Tag = "X1R"
        Me.btnZoom.UseVisualStyleBackColor = False
        '
        'btnZoomOut
        '
        Me.btnZoomOut.BackColor = System.Drawing.Color.White
        Me.btnZoomOut.FlatAppearance.BorderSize = 2
        Me.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomOut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomOut.Image = CType(resources.GetObject("btnZoomOut.Image"), System.Drawing.Image)
        Me.btnZoomOut.Location = New System.Drawing.Point(641, 291)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(40, 40)
        Me.btnZoomOut.TabIndex = 525
        Me.btnZoomOut.TabStop = False
        Me.btnZoomOut.Tag = "X1R"
        Me.btnZoomOut.UseVisualStyleBackColor = False
        '
        'btnZoomIn
        '
        Me.btnZoomIn.BackColor = System.Drawing.Color.White
        Me.btnZoomIn.FlatAppearance.BorderSize = 2
        Me.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomIn.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomIn.Image = CType(resources.GetObject("btnZoomIn.Image"), System.Drawing.Image)
        Me.btnZoomIn.Location = New System.Drawing.Point(641, 199)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(40, 40)
        Me.btnZoomIn.TabIndex = 524
        Me.btnZoomIn.TabStop = False
        Me.btnZoomIn.Tag = "X1R"
        Me.btnZoomIn.UseVisualStyleBackColor = False
        '
        'lblMarkDataName
        '
        Me.lblMarkDataName.BackColor = System.Drawing.Color.LimeGreen
        Me.lblMarkDataName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarkDataName.ForeColor = System.Drawing.Color.White
        Me.lblMarkDataName.Location = New System.Drawing.Point(21, 11)
        Me.lblMarkDataName.Name = "lblMarkDataName"
        Me.lblMarkDataName.Size = New System.Drawing.Size(513, 41)
        Me.lblMarkDataName.TabIndex = 523
        Me.lblMarkDataName.Text = "--"
        Me.lblMarkDataName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblX_Minus)
        Me.GroupBox1.Controls.Add(Me.lblY_Plus)
        Me.GroupBox1.Controls.Add(Me.lblX_Plus)
        Me.GroupBox1.Controls.Add(Me.lblY_Minus)
        Me.GroupBox1.Controls.Add(Me.pbPreview)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(620, 630)
        Me.GroupBox1.TabIndex = 521
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mark Data Preview"
        '
        'lblX_Minus
        '
        Me.lblX_Minus.AutoSize = True
        Me.lblX_Minus.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX_Minus.Location = New System.Drawing.Point(23, 297)
        Me.lblX_Minus.Name = "lblX_Minus"
        Me.lblX_Minus.Size = New System.Drawing.Size(43, 29)
        Me.lblX_Minus.TabIndex = 2
        Me.lblX_Minus.Text = "X+"
        '
        'lblY_Plus
        '
        Me.lblY_Plus.AutoSize = True
        Me.lblY_Plus.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblY_Plus.Location = New System.Drawing.Point(293, 30)
        Me.lblY_Plus.Name = "lblY_Plus"
        Me.lblY_Plus.Size = New System.Drawing.Size(42, 29)
        Me.lblY_Plus.TabIndex = 3
        Me.lblY_Plus.Text = "Y+"
        '
        'lblX_Plus
        '
        Me.lblX_Plus.AutoSize = True
        Me.lblX_Plus.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblX_Plus.Location = New System.Drawing.Point(557, 297)
        Me.lblX_Plus.Name = "lblX_Plus"
        Me.lblX_Plus.Size = New System.Drawing.Size(37, 29)
        Me.lblX_Plus.TabIndex = 1
        Me.lblX_Plus.Text = "X-"
        '
        'lblY_Minus
        '
        Me.lblY_Minus.AutoSize = True
        Me.lblY_Minus.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblY_Minus.Location = New System.Drawing.Point(293, 579)
        Me.lblY_Minus.Name = "lblY_Minus"
        Me.lblY_Minus.Size = New System.Drawing.Size(35, 29)
        Me.lblY_Minus.TabIndex = 4
        Me.lblY_Minus.Text = "Y-"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPenDataApply)
        Me.GroupBox2.Controls.Add(Me.cbMarkMode)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.numMarkRepeat)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.numJumpSpd)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.numMarkSpd)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtPenNumver)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(469, 691)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(167, 203)
        Me.GroupBox2.TabIndex = 708
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pen Data Editer"
        '
        'btnPenDataApply
        '
        Me.btnPenDataApply.Enabled = False
        Me.btnPenDataApply.Location = New System.Drawing.Point(9, 164)
        Me.btnPenDataApply.Name = "btnPenDataApply"
        Me.btnPenDataApply.Size = New System.Drawing.Size(150, 33)
        Me.btnPenDataApply.TabIndex = 10
        Me.btnPenDataApply.Text = "Apply"
        Me.btnPenDataApply.UseVisualStyleBackColor = True
        '
        'cbMarkMode
        '
        Me.cbMarkMode.FormattingEnabled = True
        Me.cbMarkMode.Items.AddRange(New Object() {"CW", "CCW", "Mode3"})
        Me.cbMarkMode.Location = New System.Drawing.Point(95, 134)
        Me.cbMarkMode.Name = "cbMarkMode"
        Me.cbMarkMode.Size = New System.Drawing.Size(64, 23)
        Me.cbMarkMode.TabIndex = 9
        Me.cbMarkMode.Text = "Mode3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Mark Mode :"
        '
        'numMarkRepeat
        '
        Me.numMarkRepeat.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMarkRepeat.Location = New System.Drawing.Point(95, 106)
        Me.numMarkRepeat.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numMarkRepeat.Name = "numMarkRepeat"
        Me.numMarkRepeat.Size = New System.Drawing.Size(64, 21)
        Me.numMarkRepeat.TabIndex = 7
        Me.numMarkRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Repeat :"
        '
        'numJumpSpd
        '
        Me.numJumpSpd.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numJumpSpd.Location = New System.Drawing.Point(95, 78)
        Me.numJumpSpd.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numJumpSpd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numJumpSpd.Name = "numJumpSpd"
        Me.numJumpSpd.Size = New System.Drawing.Size(64, 21)
        Me.numJumpSpd.TabIndex = 5
        Me.numJumpSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numJumpSpd.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Jump Speed :"
        '
        'numMarkSpd
        '
        Me.numMarkSpd.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMarkSpd.Location = New System.Drawing.Point(95, 48)
        Me.numMarkSpd.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.numMarkSpd.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMarkSpd.Name = "numMarkSpd"
        Me.numMarkSpd.Size = New System.Drawing.Size(64, 21)
        Me.numMarkSpd.TabIndex = 3
        Me.numMarkSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numMarkSpd.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Mark Speed :"
        '
        'txtPenNumver
        '
        Me.txtPenNumver.Enabled = False
        Me.txtPenNumver.Location = New System.Drawing.Point(95, 18)
        Me.txtPenNumver.Name = "txtPenNumver"
        Me.txtPenNumver.Size = New System.Drawing.Size(64, 21)
        Me.txtPenNumver.TabIndex = 1
        Me.txtPenNumver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Pen Number :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvPenData)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 691)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 203)
        Me.GroupBox3.TabIndex = 707
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pen Data View"
        '
        'dgvPenData
        '
        Me.dgvPenData.AllowUserToAddRows = False
        Me.dgvPenData.AllowUserToDeleteRows = False
        Me.dgvPenData.AllowUserToResizeColumns = False
        Me.dgvPenData.AllowUserToResizeRows = False
        Me.dgvPenData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPenData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Index, Me.MarkSpeed, Me.JumpSpeed, Me.MarkRepeat, Me.MarkMode})
        Me.dgvPenData.Location = New System.Drawing.Point(8, 21)
        Me.dgvPenData.Name = "dgvPenData"
        Me.dgvPenData.RowHeadersVisible = False
        Me.dgvPenData.RowTemplate.Height = 23
        Me.dgvPenData.Size = New System.Drawing.Size(384, 176)
        Me.dgvPenData.TabIndex = 1
        '
        'Index
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Index.DefaultCellStyle = DataGridViewCellStyle1
        Me.Index.HeaderText = "Number"
        Me.Index.Name = "Index"
        Me.Index.ReadOnly = True
        Me.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Index.Width = 65
        '
        'MarkSpeed
        '
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.MarkSpeed.DefaultCellStyle = DataGridViewCellStyle2
        Me.MarkSpeed.HeaderText = "Mark Speed"
        Me.MarkSpeed.Name = "MarkSpeed"
        Me.MarkSpeed.ReadOnly = True
        Me.MarkSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MarkSpeed.Width = 90
        '
        'JumpSpeed
        '
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.JumpSpeed.DefaultCellStyle = DataGridViewCellStyle3
        Me.JumpSpeed.HeaderText = "Jump Speed"
        Me.JumpSpeed.Name = "JumpSpeed"
        Me.JumpSpeed.ReadOnly = True
        Me.JumpSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.JumpSpeed.Width = 90
        '
        'MarkRepeat
        '
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.MarkRepeat.DefaultCellStyle = DataGridViewCellStyle4
        Me.MarkRepeat.HeaderText = "Repeat"
        Me.MarkRepeat.Name = "MarkRepeat"
        Me.MarkRepeat.ReadOnly = True
        Me.MarkRepeat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.MarkRepeat.Width = 70
        '
        'MarkMode
        '
        DataGridViewCellStyle5.NullValue = "1"
        Me.MarkMode.DefaultCellStyle = DataGridViewCellStyle5
        Me.MarkMode.HeaderText = "Mode"
        Me.MarkMode.Items.AddRange(New Object() {"CW", "CCW", "Mode3"})
        Me.MarkMode.Name = "MarkMode"
        Me.MarkMode.ReadOnly = True
        Me.MarkMode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MarkMode.Width = 65
        '
        'chkTopBottom
        '
        Me.chkTopBottom.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTopBottom.Enabled = False
        Me.chkTopBottom.Location = New System.Drawing.Point(639, 72)
        Me.chkTopBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.chkTopBottom.Name = "chkTopBottom"
        Me.chkTopBottom.Size = New System.Drawing.Size(46, 40)
        Me.chkTopBottom.TabIndex = 709
        Me.chkTopBottom.Text = "Top"
        Me.chkTopBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTopBottom.UseVisualStyleBackColor = True
        '
        'lblStatusY
        '
        Me.lblStatusY.BackColor = System.Drawing.Color.Black
        Me.lblStatusY.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusY.ForeColor = System.Drawing.Color.White
        Me.lblStatusY.Location = New System.Drawing.Point(542, 9)
        Me.lblStatusY.Name = "lblStatusY"
        Me.lblStatusY.Size = New System.Drawing.Size(137, 20)
        Me.lblStatusY.TabIndex = 710
        Me.lblStatusY.Text = "Top"
        Me.lblStatusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMarkDataEditer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(690, 914)
        Me.Controls.Add(Me.lblStatusY)
        Me.Controls.Add(Me.chkTopBottom)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkInverse)
        Me.Controls.Add(Me.numPointSize)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnCenter)
        Me.Controls.Add(Me.btnLeftX)
        Me.Controls.Add(Me.numOffset)
        Me.Controls.Add(Me.btnRightX)
        Me.Controls.Add(Me.btnDnY)
        Me.Controls.Add(Me.btnUPY)
        Me.Controls.Add(Me.btnZoom)
        Me.Controls.Add(Me.btnZoomOut)
        Me.Controls.Add(Me.btnZoomIn)
        Me.Controls.Add(Me.lblMarkDataName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMarkDataEditer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmMarkDataEditer"
        CType(Me.numPointSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOffset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numMarkRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numJumpSpd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMarkSpd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvPenData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkInverse As System.Windows.Forms.CheckBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents numPointSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox
    Friend WithEvents btnCenter As System.Windows.Forms.Button
    Friend WithEvents btnLeftX As System.Windows.Forms.Button
    Friend WithEvents numOffset As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnRightX As System.Windows.Forms.Button
    Friend WithEvents btnDnY As System.Windows.Forms.Button
    Friend WithEvents btnUPY As System.Windows.Forms.Button
    Friend WithEvents btnZoom As System.Windows.Forms.Button
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents btnZoomIn As System.Windows.Forms.Button
    Friend WithEvents lblMarkDataName As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblX_Minus As System.Windows.Forms.Label
    Friend WithEvents lblY_Plus As System.Windows.Forms.Label
    Friend WithEvents lblX_Plus As System.Windows.Forms.Label
    Friend WithEvents lblY_Minus As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPenDataApply As System.Windows.Forms.Button
    Friend WithEvents cbMarkMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numMarkRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numJumpSpd As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numMarkSpd As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPenNumver As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPenData As System.Windows.Forms.DataGridView
    Friend WithEvents Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarkSpeed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JumpSpeed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarkRepeat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarkMode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents chkTopBottom As System.Windows.Forms.CheckBox
    Friend WithEvents lblStatusY As System.Windows.Forms.Label
End Class
