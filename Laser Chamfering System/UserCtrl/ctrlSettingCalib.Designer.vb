<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSettingCalib
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
        Me.gbCalibration = New System.Windows.Forms.GroupBox()
        Me.gbCalMark = New System.Windows.Forms.GroupBox()
        Me.btnCalMark = New System.Windows.Forms.Button()
        Me.gbCalData = New System.Windows.Forms.GroupBox()
        Me.txtCalDataPath = New System.Windows.Forms.TextBox()
        Me.btnSaveCalData = New System.Windows.Forms.Button()
        Me.gbCalMarkSPD = New System.Windows.Forms.GroupBox()
        Me.numCalMarkSpd = New System.Windows.Forms.NumericUpDown()
        Me.btnSetCalMarkSpd = New System.Windows.Forms.Button()
        Me.gbCTB = New System.Windows.Forms.GroupBox()
        Me.txtCalCTB = New System.Windows.Forms.TextBox()
        Me.btnOldCTB = New System.Windows.Forms.Button()
        Me.gbSelectScanner = New System.Windows.Forms.GroupBox()
        Me.BtnSelScanner = New System.Windows.Forms.Button()
        Me.chkLine = New System.Windows.Forms.CheckBox()
        Me.gbCalPosition = New System.Windows.Forms.GroupBox()
        Me.CalDataGrid = New System.Windows.Forms.DataGridView()
        Me.gbClaMarkInfo = New System.Windows.Forms.GroupBox()
        Me.lblGab = New System.Windows.Forms.Label()
        Me.lbl101 = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.numCalMarkGab = New System.Windows.Forms.NumericUpDown()
        Me.lbl100 = New System.Windows.Forms.Label()
        Me.numCalMarkSize = New System.Windows.Forms.NumericUpDown()
        Me.gbMatrix = New System.Windows.Forms.GroupBox()
        Me.btnMatrixMinus = New System.Windows.Forms.Button()
        Me.btnMatrixPlus = New System.Windows.Forms.Button()
        Me.numCalValue = New System.Windows.Forms.NumericUpDown()
        Me.picCalPosition = New System.Windows.Forms.PictureBox()
        Me.mItemRealPosX = New System.Windows.Forms.ToolStripMenuItem()
        Me.mItemRealPosY = New System.Windows.Forms.ToolStripMenuItem()
        Me.mItemGetPos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxtMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.gbCalibration.SuspendLayout()
        Me.gbCalMark.SuspendLayout()
        Me.gbCalData.SuspendLayout()
        Me.gbCalMarkSPD.SuspendLayout()
        CType(Me.numCalMarkSpd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCTB.SuspendLayout()
        Me.gbSelectScanner.SuspendLayout()
        Me.gbCalPosition.SuspendLayout()
        CType(Me.CalDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbClaMarkInfo.SuspendLayout()
        CType(Me.numCalMarkGab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCalMarkSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMatrix.SuspendLayout()
        CType(Me.numCalValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCalPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxtMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCalibration
        '
        Me.gbCalibration.Controls.Add(Me.gbCalMark)
        Me.gbCalibration.Controls.Add(Me.gbCalData)
        Me.gbCalibration.Controls.Add(Me.gbCalMarkSPD)
        Me.gbCalibration.Controls.Add(Me.gbCTB)
        Me.gbCalibration.Controls.Add(Me.gbSelectScanner)
        Me.gbCalibration.Controls.Add(Me.gbCalPosition)
        Me.gbCalibration.Controls.Add(Me.gbClaMarkInfo)
        Me.gbCalibration.Controls.Add(Me.gbMatrix)
        Me.gbCalibration.Controls.Add(Me.picCalPosition)
        Me.gbCalibration.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalibration.Location = New System.Drawing.Point(2, -17)
        Me.gbCalibration.Name = "gbCalibration"
        Me.gbCalibration.Size = New System.Drawing.Size(697, 804)
        Me.gbCalibration.TabIndex = 346
        Me.gbCalibration.TabStop = False
        Me.gbCalibration.Text = "Calibration"
        '
        'gbCalMark
        '
        Me.gbCalMark.Controls.Add(Me.btnCalMark)
        Me.gbCalMark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalMark.Location = New System.Drawing.Point(522, 383)
        Me.gbCalMark.Name = "gbCalMark"
        Me.gbCalMark.Size = New System.Drawing.Size(168, 59)
        Me.gbCalMark.TabIndex = 21
        Me.gbCalMark.TabStop = False
        Me.gbCalMark.Text = "Calibration Marking"
        '
        'btnCalMark
        '
        Me.btnCalMark.Location = New System.Drawing.Point(15, 17)
        Me.btnCalMark.Name = "btnCalMark"
        Me.btnCalMark.Size = New System.Drawing.Size(140, 36)
        Me.btnCalMark.TabIndex = 19
        Me.btnCalMark.Text = "Marking Start"
        Me.btnCalMark.UseVisualStyleBackColor = True
        '
        'gbCalData
        '
        Me.gbCalData.Controls.Add(Me.txtCalDataPath)
        Me.gbCalData.Controls.Add(Me.btnSaveCalData)
        Me.gbCalData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalData.Location = New System.Drawing.Point(522, 446)
        Me.gbCalData.Name = "gbCalData"
        Me.gbCalData.Size = New System.Drawing.Size(168, 80)
        Me.gbCalData.TabIndex = 20
        Me.gbCalData.TabStop = False
        Me.gbCalData.Text = "Data File Save"
        '
        'txtCalDataPath
        '
        Me.txtCalDataPath.Enabled = False
        Me.txtCalDataPath.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalDataPath.Location = New System.Drawing.Point(15, 17)
        Me.txtCalDataPath.Name = "txtCalDataPath"
        Me.txtCalDataPath.Size = New System.Drawing.Size(140, 22)
        Me.txtCalDataPath.TabIndex = 3
        '
        'btnSaveCalData
        '
        Me.btnSaveCalData.Location = New System.Drawing.Point(15, 44)
        Me.btnSaveCalData.Name = "btnSaveCalData"
        Me.btnSaveCalData.Size = New System.Drawing.Size(140, 30)
        Me.btnSaveCalData.TabIndex = 2
        Me.btnSaveCalData.Text = "Save"
        Me.btnSaveCalData.UseVisualStyleBackColor = True
        '
        'gbCalMarkSPD
        '
        Me.gbCalMarkSPD.Controls.Add(Me.numCalMarkSpd)
        Me.gbCalMarkSPD.Controls.Add(Me.btnSetCalMarkSpd)
        Me.gbCalMarkSPD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalMarkSPD.Location = New System.Drawing.Point(522, 176)
        Me.gbCalMarkSPD.Name = "gbCalMarkSPD"
        Me.gbCalMarkSPD.Size = New System.Drawing.Size(168, 59)
        Me.gbCalMarkSPD.TabIndex = 13
        Me.gbCalMarkSPD.TabStop = False
        Me.gbCalMarkSPD.Text = "Mark Speed Set (bit)"
        '
        'numCalMarkSpd
        '
        Me.numCalMarkSpd.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCalMarkSpd.Location = New System.Drawing.Point(12, 26)
        Me.numCalMarkSpd.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numCalMarkSpd.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numCalMarkSpd.Name = "numCalMarkSpd"
        Me.numCalMarkSpd.Size = New System.Drawing.Size(96, 21)
        Me.numCalMarkSpd.TabIndex = 5
        Me.numCalMarkSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numCalMarkSpd.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'btnSetCalMarkSpd
        '
        Me.btnSetCalMarkSpd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetCalMarkSpd.Location = New System.Drawing.Point(117, 20)
        Me.btnSetCalMarkSpd.Name = "btnSetCalMarkSpd"
        Me.btnSetCalMarkSpd.Size = New System.Drawing.Size(43, 30)
        Me.btnSetCalMarkSpd.TabIndex = 2
        Me.btnSetCalMarkSpd.Tag = Global.Laser_Chamfering_System.My.Resources.setLan.SelectVision
        Me.btnSetCalMarkSpd.Text = "Set"
        Me.btnSetCalMarkSpd.UseVisualStyleBackColor = True
        '
        'gbCTB
        '
        Me.gbCTB.Controls.Add(Me.txtCalCTB)
        Me.gbCTB.Controls.Add(Me.btnOldCTB)
        Me.gbCTB.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCTB.Location = New System.Drawing.Point(522, 92)
        Me.gbCTB.Name = "gbCTB"
        Me.gbCTB.Size = New System.Drawing.Size(168, 80)
        Me.gbCTB.TabIndex = 18
        Me.gbCTB.TabStop = False
        Me.gbCTB.Text = "CTB File Load"
        '
        'txtCalCTB
        '
        Me.txtCalCTB.Enabled = False
        Me.txtCalCTB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalCTB.Location = New System.Drawing.Point(15, 17)
        Me.txtCalCTB.Name = "txtCalCTB"
        Me.txtCalCTB.Size = New System.Drawing.Size(140, 22)
        Me.txtCalCTB.TabIndex = 3
        '
        'btnOldCTB
        '
        Me.btnOldCTB.Location = New System.Drawing.Point(15, 44)
        Me.btnOldCTB.Name = "btnOldCTB"
        Me.btnOldCTB.Size = New System.Drawing.Size(140, 30)
        Me.btnOldCTB.TabIndex = 2
        Me.btnOldCTB.Text = "Load"
        Me.btnOldCTB.UseVisualStyleBackColor = True
        '
        'gbSelectScanner
        '
        Me.gbSelectScanner.Controls.Add(Me.BtnSelScanner)
        Me.gbSelectScanner.Controls.Add(Me.chkLine)
        Me.gbSelectScanner.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSelectScanner.Location = New System.Drawing.Point(522, 21)
        Me.gbSelectScanner.Name = "gbSelectScanner"
        Me.gbSelectScanner.Size = New System.Drawing.Size(168, 67)
        Me.gbSelectScanner.TabIndex = 17
        Me.gbSelectScanner.TabStop = False
        Me.gbSelectScanner.Text = "Select Scanner"
        '
        'BtnSelScanner
        '
        Me.BtnSelScanner.Location = New System.Drawing.Point(12, 21)
        Me.BtnSelScanner.Name = "BtnSelScanner"
        Me.BtnSelScanner.Size = New System.Drawing.Size(84, 38)
        Me.BtnSelScanner.TabIndex = 346
        Me.BtnSelScanner.Text = "Scanner#1"
        Me.BtnSelScanner.UseVisualStyleBackColor = True
        '
        'chkLine
        '
        Me.chkLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkLine.Location = New System.Drawing.Point(99, 19)
        Me.chkLine.Name = "chkLine"
        Me.chkLine.Size = New System.Drawing.Size(63, 40)
        Me.chkLine.TabIndex = 345
        Me.chkLine.Text = "Line A"
        Me.chkLine.UseVisualStyleBackColor = True
        '
        'gbCalPosition
        '
        Me.gbCalPosition.Controls.Add(Me.CalDataGrid)
        Me.gbCalPosition.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalPosition.Location = New System.Drawing.Point(13, 532)
        Me.gbCalPosition.Name = "gbCalPosition"
        Me.gbCalPosition.Size = New System.Drawing.Size(677, 265)
        Me.gbCalPosition.TabIndex = 14
        Me.gbCalPosition.TabStop = False
        Me.gbCalPosition.Text = "Position Data"
        '
        'CalDataGrid
        '
        Me.CalDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CalDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.CalDataGrid.Location = New System.Drawing.Point(14, 21)
        Me.CalDataGrid.Name = "CalDataGrid"
        Me.CalDataGrid.RowTemplate.Height = 23
        Me.CalDataGrid.Size = New System.Drawing.Size(651, 242)
        Me.CalDataGrid.TabIndex = 1
        '
        'gbClaMarkInfo
        '
        Me.gbClaMarkInfo.Controls.Add(Me.lblGab)
        Me.gbClaMarkInfo.Controls.Add(Me.lbl101)
        Me.gbClaMarkInfo.Controls.Add(Me.lblSize)
        Me.gbClaMarkInfo.Controls.Add(Me.numCalMarkGab)
        Me.gbClaMarkInfo.Controls.Add(Me.lbl100)
        Me.gbClaMarkInfo.Controls.Add(Me.numCalMarkSize)
        Me.gbClaMarkInfo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbClaMarkInfo.Location = New System.Drawing.Point(522, 302)
        Me.gbClaMarkInfo.Name = "gbClaMarkInfo"
        Me.gbClaMarkInfo.Size = New System.Drawing.Size(168, 77)
        Me.gbClaMarkInfo.TabIndex = 13
        Me.gbClaMarkInfo.TabStop = False
        Me.gbClaMarkInfo.Text = "Calibration Marking Info"
        '
        'lblGab
        '
        Me.lblGab.AutoSize = True
        Me.lblGab.Location = New System.Drawing.Point(12, 50)
        Me.lblGab.Name = "lblGab"
        Me.lblGab.Size = New System.Drawing.Size(35, 15)
        Me.lblGab.TabIndex = 7
        Me.lblGab.Text = "Gap :"
        '
        'lbl101
        '
        Me.lbl101.AutoSize = True
        Me.lbl101.Location = New System.Drawing.Point(139, 50)
        Me.lbl101.Name = "lbl101"
        Me.lbl101.Size = New System.Drawing.Size(21, 15)
        Me.lbl101.TabIndex = 5
        Me.lbl101.Text = "bit"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(12, 22)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(37, 15)
        Me.lblSize.TabIndex = 6
        Me.lblSize.Text = "Size :"
        '
        'numCalMarkGab
        '
        Me.numCalMarkGab.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCalMarkGab.Location = New System.Drawing.Point(58, 48)
        Me.numCalMarkGab.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numCalMarkGab.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numCalMarkGab.Name = "numCalMarkGab"
        Me.numCalMarkGab.Size = New System.Drawing.Size(73, 21)
        Me.numCalMarkGab.TabIndex = 4
        Me.numCalMarkGab.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'lbl100
        '
        Me.lbl100.AutoSize = True
        Me.lbl100.Location = New System.Drawing.Point(139, 22)
        Me.lbl100.Name = "lbl100"
        Me.lbl100.Size = New System.Drawing.Size(21, 15)
        Me.lbl100.TabIndex = 5
        Me.lbl100.Text = "bit"
        '
        'numCalMarkSize
        '
        Me.numCalMarkSize.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCalMarkSize.Location = New System.Drawing.Point(58, 20)
        Me.numCalMarkSize.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numCalMarkSize.Minimum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numCalMarkSize.Name = "numCalMarkSize"
        Me.numCalMarkSize.Size = New System.Drawing.Size(73, 21)
        Me.numCalMarkSize.TabIndex = 4
        Me.numCalMarkSize.Value = New Decimal(New Integer() {65000, 0, 0, 0})
        '
        'gbMatrix
        '
        Me.gbMatrix.Controls.Add(Me.btnMatrixMinus)
        Me.gbMatrix.Controls.Add(Me.btnMatrixPlus)
        Me.gbMatrix.Controls.Add(Me.numCalValue)
        Me.gbMatrix.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMatrix.Location = New System.Drawing.Point(522, 239)
        Me.gbMatrix.Name = "gbMatrix"
        Me.gbMatrix.Size = New System.Drawing.Size(168, 59)
        Me.gbMatrix.TabIndex = 12
        Me.gbMatrix.TabStop = False
        Me.gbMatrix.Text = "Matrix Set"
        '
        'btnMatrixMinus
        '
        Me.btnMatrixMinus.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMatrixMinus.Location = New System.Drawing.Point(68, 20)
        Me.btnMatrixMinus.Name = "btnMatrixMinus"
        Me.btnMatrixMinus.Size = New System.Drawing.Size(43, 30)
        Me.btnMatrixMinus.TabIndex = 1
        Me.btnMatrixMinus.Tag = "-"
        Me.btnMatrixMinus.Text = "-"
        Me.btnMatrixMinus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMatrixMinus.UseVisualStyleBackColor = True
        '
        'btnMatrixPlus
        '
        Me.btnMatrixPlus.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMatrixPlus.Location = New System.Drawing.Point(117, 20)
        Me.btnMatrixPlus.Name = "btnMatrixPlus"
        Me.btnMatrixPlus.Size = New System.Drawing.Size(43, 30)
        Me.btnMatrixPlus.TabIndex = 2
        Me.btnMatrixPlus.Tag = "+"
        Me.btnMatrixPlus.Text = "+"
        Me.btnMatrixPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMatrixPlus.UseVisualStyleBackColor = True
        '
        'numCalValue
        '
        Me.numCalValue.Enabled = False
        Me.numCalValue.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numCalValue.Location = New System.Drawing.Point(12, 25)
        Me.numCalValue.Maximum = New Decimal(New Integer() {19, 0, 0, 0})
        Me.numCalValue.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numCalValue.Name = "numCalValue"
        Me.numCalValue.Size = New System.Drawing.Size(50, 21)
        Me.numCalValue.TabIndex = 3
        Me.numCalValue.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'picCalPosition
        '
        Me.picCalPosition.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.picCalPosition.Location = New System.Drawing.Point(13, 26)
        Me.picCalPosition.Name = "picCalPosition"
        Me.picCalPosition.Size = New System.Drawing.Size(500, 500)
        Me.picCalPosition.TabIndex = 11
        Me.picCalPosition.TabStop = False
        '
        'mItemRealPosX
        '
        Me.mItemRealPosX.Name = "mItemRealPosX"
        Me.mItemRealPosX.Size = New System.Drawing.Size(122, 22)
        Me.mItemRealPosX.Text = "X :"
        '
        'mItemRealPosY
        '
        Me.mItemRealPosY.Name = "mItemRealPosY"
        Me.mItemRealPosY.Size = New System.Drawing.Size(122, 22)
        Me.mItemRealPosY.Text = "Y :"
        '
        'mItemGetPos
        '
        Me.mItemGetPos.Name = "mItemGetPos"
        Me.mItemGetPos.Size = New System.Drawing.Size(122, 22)
        Me.mItemGetPos.Text = "좌표입력"
        '
        'ctxtMenu
        '
        Me.ctxtMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mItemRealPosX, Me.mItemRealPosY, Me.mItemGetPos})
        Me.ctxtMenu.Name = "cTxtMenu"
        Me.ctxtMenu.Size = New System.Drawing.Size(123, 70)
        '
        'ctrlSettingCalib
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.gbCalibration)
        Me.Name = "ctrlSettingCalib"
        Me.Size = New System.Drawing.Size(702, 800)
        Me.gbCalibration.ResumeLayout(False)
        Me.gbCalMark.ResumeLayout(False)
        Me.gbCalData.ResumeLayout(False)
        Me.gbCalData.PerformLayout()
        Me.gbCalMarkSPD.ResumeLayout(False)
        CType(Me.numCalMarkSpd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCTB.ResumeLayout(False)
        Me.gbCTB.PerformLayout()
        Me.gbSelectScanner.ResumeLayout(False)
        Me.gbCalPosition.ResumeLayout(False)
        CType(Me.CalDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbClaMarkInfo.ResumeLayout(False)
        Me.gbClaMarkInfo.PerformLayout()
        CType(Me.numCalMarkGab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCalMarkSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMatrix.ResumeLayout(False)
        CType(Me.numCalValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCalPosition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxtMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbCalibration As System.Windows.Forms.GroupBox
    Friend WithEvents gbCalMark As System.Windows.Forms.GroupBox
    Friend WithEvents btnCalMark As System.Windows.Forms.Button
    Friend WithEvents gbCalData As System.Windows.Forms.GroupBox
    Friend WithEvents txtCalDataPath As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveCalData As System.Windows.Forms.Button
    Friend WithEvents gbCalMarkSPD As System.Windows.Forms.GroupBox
    Friend WithEvents numCalMarkSpd As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnSetCalMarkSpd As System.Windows.Forms.Button
    Friend WithEvents gbCTB As System.Windows.Forms.GroupBox
    Friend WithEvents txtCalCTB As System.Windows.Forms.TextBox
    Friend WithEvents btnOldCTB As System.Windows.Forms.Button
    Friend WithEvents gbSelectScanner As System.Windows.Forms.GroupBox
    Friend WithEvents BtnSelScanner As System.Windows.Forms.Button
    Friend WithEvents chkLine As System.Windows.Forms.CheckBox
    Friend WithEvents gbCalPosition As System.Windows.Forms.GroupBox
    Friend WithEvents CalDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents gbClaMarkInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblGab As System.Windows.Forms.Label
    Friend WithEvents lbl101 As System.Windows.Forms.Label
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents numCalMarkGab As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl100 As System.Windows.Forms.Label
    Friend WithEvents numCalMarkSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbMatrix As System.Windows.Forms.GroupBox
    Friend WithEvents btnMatrixMinus As System.Windows.Forms.Button
    Friend WithEvents btnMatrixPlus As System.Windows.Forms.Button
    Friend WithEvents numCalValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents picCalPosition As System.Windows.Forms.PictureBox
    Friend WithEvents mItemRealPosX As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mItemRealPosY As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mItemGetPos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxtMenu As System.Windows.Forms.ContextMenuStrip

End Class
