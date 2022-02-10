<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlignDataView
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.RbtnLineA = New System.Windows.Forms.RadioButton()
        Me.RbtnLineB = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnView = New System.Windows.Forms.Button()
        Me.dgvMarkData = New System.Windows.Forms.DataGridView()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pos_X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pos_Y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mark2PosX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mark2PosY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnShow = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnClear = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnPanel1 = New System.Windows.Forms.Button()
        Me.btnPanel2 = New System.Windows.Forms.Button()
        Me.btnPanel3 = New System.Windows.Forms.Button()
        Me.btnPanel4 = New System.Windows.Forms.Button()
        Me.BtnAllClear = New System.Windows.Forms.Button()
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.pbPreview2 = New System.Windows.Forms.PictureBox()
        Me.pbPreview1 = New System.Windows.Forms.PictureBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnAllView = New System.Windows.Forms.Button()
        CType(Me.dgvMarkData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPreview2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPreview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(12, 353)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(206, 38)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "Close"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Blue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(942, 31)
        Me.lblTitle.TabIndex = 11
        Me.lblTitle.Text = "Align Data View"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RbtnLineA
        '
        Me.RbtnLineA.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnLineA.BackColor = System.Drawing.Color.White
        Me.RbtnLineA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnLineA.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.RbtnLineA.Location = New System.Drawing.Point(12, 34)
        Me.RbtnLineA.Name = "RbtnLineA"
        Me.RbtnLineA.Size = New System.Drawing.Size(100, 50)
        Me.RbtnLineA.TabIndex = 14
        Me.RbtnLineA.TabStop = True
        Me.RbtnLineA.Text = "Line A"
        Me.RbtnLineA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnLineA.UseVisualStyleBackColor = False
        '
        'RbtnLineB
        '
        Me.RbtnLineB.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbtnLineB.BackColor = System.Drawing.Color.White
        Me.RbtnLineB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbtnLineB.Font = New System.Drawing.Font("맑은 고딕", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.RbtnLineB.Location = New System.Drawing.Point(118, 34)
        Me.RbtnLineB.Name = "RbtnLineB"
        Me.RbtnLineB.Size = New System.Drawing.Size(100, 50)
        Me.RbtnLineB.TabIndex = 15
        Me.RbtnLineB.TabStop = True
        Me.RbtnLineB.Text = "Line B"
        Me.RbtnLineB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbtnLineB.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkRed
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(236, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 23)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Mark 1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkRed
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(590, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(340, 23)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Mark 2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnView
        '
        Me.BtnView.BackColor = System.Drawing.Color.Blue
        Me.BtnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnView.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnView.ForeColor = System.Drawing.Color.Transparent
        Me.BtnView.Location = New System.Drawing.Point(12, 309)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(206, 38)
        Me.BtnView.TabIndex = 24
        Me.BtnView.Text = "View"
        Me.BtnView.UseVisualStyleBackColor = False
        '
        'dgvMarkData
        '
        Me.dgvMarkData.AllowUserToAddRows = False
        Me.dgvMarkData.AllowUserToDeleteRows = False
        Me.dgvMarkData.AllowUserToResizeColumns = False
        Me.dgvMarkData.AllowUserToResizeRows = False
        Me.dgvMarkData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMarkData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Index, Me.Pos_X, Me.Pos_Y, Me.Mark2PosX, Me.Mark2PosY, Me.btnShow, Me.btnClear})
        Me.dgvMarkData.Location = New System.Drawing.Point(236, 397)
        Me.dgvMarkData.Name = "dgvMarkData"
        Me.dgvMarkData.RowHeadersVisible = False
        Me.dgvMarkData.RowTemplate.Height = 23
        Me.dgvMarkData.Size = New System.Drawing.Size(570, 177)
        Me.dgvMarkData.TabIndex = 25
        '
        'Index
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle1.NullValue = "00"
        Me.Index.DefaultCellStyle = DataGridViewCellStyle1
        Me.Index.HeaderText = "Idx"
        Me.Index.Name = "Index"
        Me.Index.ReadOnly = True
        Me.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Index.Width = 50
        '
        'Pos_X
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.NullValue = "000.000"
        Me.Pos_X.DefaultCellStyle = DataGridViewCellStyle2
        Me.Pos_X.HeaderText = "Mark1 Pos X"
        Me.Pos_X.Name = "Pos_X"
        Me.Pos_X.ReadOnly = True
        Me.Pos_X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Pos_Y
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.NullValue = "000.000"
        Me.Pos_Y.DefaultCellStyle = DataGridViewCellStyle3
        Me.Pos_Y.HeaderText = "Mark1 Pos Y"
        Me.Pos_Y.Name = "Pos_Y"
        Me.Pos_Y.ReadOnly = True
        Me.Pos_Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Mark2PosX
        '
        DataGridViewCellStyle4.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle4.NullValue = "000.000"
        Me.Mark2PosX.DefaultCellStyle = DataGridViewCellStyle4
        Me.Mark2PosX.HeaderText = "Mark2 Pos X"
        Me.Mark2PosX.Name = "Mark2PosX"
        Me.Mark2PosX.ReadOnly = True
        Me.Mark2PosX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Mark2PosY
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.NullValue = "000.000"
        Me.Mark2PosY.DefaultCellStyle = DataGridViewCellStyle5
        Me.Mark2PosY.HeaderText = "Mark2 Pos Y"
        Me.Mark2PosY.Name = "Mark2PosY"
        Me.Mark2PosY.ReadOnly = True
        Me.Mark2PosY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'btnShow
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle6.NullValue = "Show"
        Me.btnShow.DefaultCellStyle = DataGridViewCellStyle6
        Me.btnShow.HeaderText = "Show"
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Width = 50
        '
        'btnClear
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle7.NullValue = "Clear"
        Me.btnClear.DefaultCellStyle = DataGridViewCellStyle7
        Me.btnClear.HeaderText = "Clear"
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Width = 50
        '
        'btnPanel1
        '
        Me.btnPanel1.BackColor = System.Drawing.Color.Lavender
        Me.btnPanel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPanel1.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPanel1.ForeColor = System.Drawing.Color.Black
        Me.btnPanel1.Location = New System.Drawing.Point(12, 90)
        Me.btnPanel1.Name = "btnPanel1"
        Me.btnPanel1.Size = New System.Drawing.Size(206, 38)
        Me.btnPanel1.TabIndex = 26
        Me.btnPanel1.Text = "Panel 1"
        Me.btnPanel1.UseVisualStyleBackColor = False
        '
        'btnPanel2
        '
        Me.btnPanel2.BackColor = System.Drawing.Color.Lavender
        Me.btnPanel2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPanel2.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPanel2.ForeColor = System.Drawing.Color.Black
        Me.btnPanel2.Location = New System.Drawing.Point(12, 141)
        Me.btnPanel2.Name = "btnPanel2"
        Me.btnPanel2.Size = New System.Drawing.Size(206, 38)
        Me.btnPanel2.TabIndex = 27
        Me.btnPanel2.Text = "Panel 2"
        Me.btnPanel2.UseVisualStyleBackColor = False
        '
        'btnPanel3
        '
        Me.btnPanel3.BackColor = System.Drawing.Color.Lavender
        Me.btnPanel3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPanel3.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPanel3.ForeColor = System.Drawing.Color.Black
        Me.btnPanel3.Location = New System.Drawing.Point(12, 192)
        Me.btnPanel3.Name = "btnPanel3"
        Me.btnPanel3.Size = New System.Drawing.Size(206, 38)
        Me.btnPanel3.TabIndex = 28
        Me.btnPanel3.Text = "Panel 3"
        Me.btnPanel3.UseVisualStyleBackColor = False
        '
        'btnPanel4
        '
        Me.btnPanel4.BackColor = System.Drawing.Color.Lavender
        Me.btnPanel4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPanel4.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPanel4.ForeColor = System.Drawing.Color.Black
        Me.btnPanel4.Location = New System.Drawing.Point(12, 243)
        Me.btnPanel4.Name = "btnPanel4"
        Me.btnPanel4.Size = New System.Drawing.Size(206, 38)
        Me.btnPanel4.TabIndex = 29
        Me.btnPanel4.Text = "Panel 4"
        Me.btnPanel4.UseVisualStyleBackColor = False
        '
        'BtnAllClear
        '
        Me.BtnAllClear.BackColor = System.Drawing.Color.Blue
        Me.BtnAllClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAllClear.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnAllClear.ForeColor = System.Drawing.Color.Transparent
        Me.BtnAllClear.Location = New System.Drawing.Point(812, 397)
        Me.BtnAllClear.Name = "BtnAllClear"
        Me.BtnAllClear.Size = New System.Drawing.Size(118, 38)
        Me.BtnAllClear.TabIndex = 30
        Me.BtnAllClear.Text = "All Clear"
        Me.BtnAllClear.UseVisualStyleBackColor = False
        '
        'pbImage
        '
        Me.pbImage.BackColor = System.Drawing.Color.White
        Me.pbImage.Image = Global.Laser_Chamfering_System.My.Resources.Resources.bPic
        Me.pbImage.Location = New System.Drawing.Point(13, 397)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(205, 177)
        Me.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbImage.TabIndex = 31
        Me.pbImage.TabStop = False
        '
        'pbPreview2
        '
        Me.pbPreview2.BackColor = System.Drawing.Color.White
        Me.pbPreview2.Location = New System.Drawing.Point(590, 60)
        Me.pbPreview2.Name = "pbPreview2"
        Me.pbPreview2.Size = New System.Drawing.Size(340, 330)
        Me.pbPreview2.TabIndex = 23
        Me.pbPreview2.TabStop = False
        '
        'pbPreview1
        '
        Me.pbPreview1.BackColor = System.Drawing.Color.White
        Me.pbPreview1.Location = New System.Drawing.Point(236, 60)
        Me.pbPreview1.Name = "pbPreview1"
        Me.pbPreview1.Size = New System.Drawing.Size(340, 330)
        Me.pbPreview1.TabIndex = 22
        Me.pbPreview1.TabStop = False
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.Blue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLoad.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnLoad.ForeColor = System.Drawing.Color.Transparent
        Me.btnLoad.Location = New System.Drawing.Point(812, 483)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(118, 38)
        Me.btnLoad.TabIndex = 32
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnAllView
        '
        Me.btnAllView.BackColor = System.Drawing.Color.Blue
        Me.btnAllView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAllView.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAllView.ForeColor = System.Drawing.Color.Transparent
        Me.btnAllView.Location = New System.Drawing.Point(812, 440)
        Me.btnAllView.Name = "btnAllView"
        Me.btnAllView.Size = New System.Drawing.Size(118, 38)
        Me.btnAllView.TabIndex = 32
        Me.btnAllView.Text = "All View"
        Me.btnAllView.UseVisualStyleBackColor = False
        '
        'frmAlignDataView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(942, 586)
        Me.Controls.Add(Me.btnAllView)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.pbImage)
        Me.Controls.Add(Me.BtnAllClear)
        Me.Controls.Add(Me.btnPanel4)
        Me.Controls.Add(Me.btnPanel3)
        Me.Controls.Add(Me.btnPanel2)
        Me.Controls.Add(Me.btnPanel1)
        Me.Controls.Add(Me.dgvMarkData)
        Me.Controls.Add(Me.BtnView)
        Me.Controls.Add(Me.pbPreview2)
        Me.Controls.Add(Me.pbPreview1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RbtnLineB)
        Me.Controls.Add(Me.RbtnLineA)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAlignDataView"
        Me.Text = "AlignDataView"
        Me.TopMost = True
        CType(Me.dgvMarkData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPreview2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPreview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents RbtnLineA As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnLineB As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbPreview1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbPreview2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnView As System.Windows.Forms.Button
    Friend WithEvents dgvMarkData As System.Windows.Forms.DataGridView
    Friend WithEvents btnPanel1 As System.Windows.Forms.Button
    Friend WithEvents btnPanel2 As System.Windows.Forms.Button
    Friend WithEvents btnPanel3 As System.Windows.Forms.Button
    Friend WithEvents btnPanel4 As System.Windows.Forms.Button
    Friend WithEvents BtnAllClear As System.Windows.Forms.Button
    Friend WithEvents Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pos_X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pos_Y As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mark2PosX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mark2PosY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnShow As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnClear As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents pbImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnAllView As System.Windows.Forms.Button
End Class
