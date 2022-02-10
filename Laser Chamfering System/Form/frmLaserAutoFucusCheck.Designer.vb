<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaserAutoFucusCheck
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
        Me.tmAutoFocusCheck = New System.Windows.Forms.Timer(Me.components)
        Me.numStartPosX = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numStartPosY = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numStartPosZ = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numStepZ = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numStepY = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numStepX = New System.Windows.Forms.NumericUpDown()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.optLaser1_A = New System.Windows.Forms.RadioButton()
        Me.optLaser2_A = New System.Windows.Forms.RadioButton()
        Me.optLaser2_B = New System.Windows.Forms.RadioButton()
        Me.optLaser1_B = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numMoveCount = New System.Windows.Forms.NumericUpDown()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.numStartPosX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartPosY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStartPosZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStepZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStepY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStepX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMoveCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmAutoFocusCheck
        '
        '
        'numStartPosX
        '
        Me.numStartPosX.DecimalPlaces = 3
        Me.numStartPosX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStartPosX.Location = New System.Drawing.Point(152, 128)
        Me.numStartPosX.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numStartPosX.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numStartPosX.Name = "numStartPosX"
        Me.numStartPosX.Size = New System.Drawing.Size(87, 21)
        Me.numStartPosX.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Start Position X : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Start Position Y : "
        '
        'numStartPosY
        '
        Me.numStartPosY.DecimalPlaces = 3
        Me.numStartPosY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStartPosY.Location = New System.Drawing.Point(152, 163)
        Me.numStartPosY.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numStartPosY.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numStartPosY.Name = "numStartPosY"
        Me.numStartPosY.Size = New System.Drawing.Size(87, 21)
        Me.numStartPosY.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Start Position Z : "
        '
        'numStartPosZ
        '
        Me.numStartPosZ.DecimalPlaces = 3
        Me.numStartPosZ.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStartPosZ.Location = New System.Drawing.Point(152, 198)
        Me.numStartPosZ.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numStartPosZ.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numStartPosZ.Name = "numStartPosZ"
        Me.numStartPosZ.Size = New System.Drawing.Size(87, 21)
        Me.numStartPosZ.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Step Move Z : "
        '
        'numStepZ
        '
        Me.numStepZ.DecimalPlaces = 3
        Me.numStepZ.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStepZ.Location = New System.Drawing.Point(153, 198)
        Me.numStepZ.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numStepZ.Minimum = New Decimal(New Integer() {2, 0, 0, -2147483648})
        Me.numStepZ.Name = "numStepZ"
        Me.numStepZ.Size = New System.Drawing.Size(87, 21)
        Me.numStepZ.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Step Move Y : "
        '
        'numStepY
        '
        Me.numStepY.DecimalPlaces = 3
        Me.numStepY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStepY.Location = New System.Drawing.Point(153, 163)
        Me.numStepY.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numStepY.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.numStepY.Name = "numStepY"
        Me.numStepY.Size = New System.Drawing.Size(87, 21)
        Me.numStepY.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Step Move X : "
        '
        'numStepX
        '
        Me.numStepX.DecimalPlaces = 3
        Me.numStepX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStepX.Location = New System.Drawing.Point(153, 128)
        Me.numStepX.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numStepX.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.numStepX.Name = "numStepX"
        Me.numStepX.Size = New System.Drawing.Size(87, 21)
        Me.numStepX.TabIndex = 6
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(43, 265)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(196, 43)
        Me.btnStart.TabIndex = 12
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(44, 265)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(196, 43)
        Me.btnStop.TabIndex = 13
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'optLaser1_A
        '
        Me.optLaser1_A.Appearance = System.Windows.Forms.Appearance.Button
        Me.optLaser1_A.Checked = True
        Me.optLaser1_A.Location = New System.Drawing.Point(38, 36)
        Me.optLaser1_A.Name = "optLaser1_A"
        Me.optLaser1_A.Size = New System.Drawing.Size(101, 36)
        Me.optLaser1_A.TabIndex = 14
        Me.optLaser1_A.TabStop = True
        Me.optLaser1_A.Text = "A Line Laser 1"
        Me.optLaser1_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optLaser1_A.UseVisualStyleBackColor = True
        '
        'optLaser2_A
        '
        Me.optLaser2_A.Appearance = System.Windows.Forms.Appearance.Button
        Me.optLaser2_A.Location = New System.Drawing.Point(145, 36)
        Me.optLaser2_A.Name = "optLaser2_A"
        Me.optLaser2_A.Size = New System.Drawing.Size(101, 36)
        Me.optLaser2_A.TabIndex = 15
        Me.optLaser2_A.Text = "A Line Laser 2"
        Me.optLaser2_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optLaser2_A.UseVisualStyleBackColor = True
        '
        'optLaser2_B
        '
        Me.optLaser2_B.Appearance = System.Windows.Forms.Appearance.Button
        Me.optLaser2_B.Location = New System.Drawing.Point(146, 36)
        Me.optLaser2_B.Name = "optLaser2_B"
        Me.optLaser2_B.Size = New System.Drawing.Size(101, 36)
        Me.optLaser2_B.TabIndex = 17
        Me.optLaser2_B.Text = "B Line Laser 2"
        Me.optLaser2_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optLaser2_B.UseVisualStyleBackColor = True
        '
        'optLaser1_B
        '
        Me.optLaser1_B.Appearance = System.Windows.Forms.Appearance.Button
        Me.optLaser1_B.Location = New System.Drawing.Point(39, 36)
        Me.optLaser1_B.Name = "optLaser1_B"
        Me.optLaser1_B.Size = New System.Drawing.Size(101, 36)
        Me.optLaser1_B.TabIndex = 16
        Me.optLaser1_B.Text = "B Line Laser 1"
        Me.optLaser1_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optLaser1_B.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 238)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 12)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Move Count : "
        '
        'numMoveCount
        '
        Me.numMoveCount.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numMoveCount.Location = New System.Drawing.Point(152, 233)
        Me.numMoveCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMoveCount.Name = "numMoveCount"
        Me.numMoveCount.Size = New System.Drawing.Size(87, 21)
        Me.numMoveCount.TabIndex = 18
        Me.numMoveCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'RadioButton1
        '
        Me.RadioButton1.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton1.Location = New System.Drawing.Point(146, 77)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(101, 36)
        Me.RadioButton1.TabIndex = 23
        Me.RadioButton1.Text = "B Line Laser 4"
        Me.RadioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton2.Location = New System.Drawing.Point(39, 77)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(101, 36)
        Me.RadioButton2.TabIndex = 22
        Me.RadioButton2.Text = "B Line Laser 3"
        Me.RadioButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton3.Location = New System.Drawing.Point(145, 77)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(101, 36)
        Me.RadioButton3.TabIndex = 21
        Me.RadioButton3.Text = "A Line Laser 4"
        Me.RadioButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.Appearance = System.Windows.Forms.Appearance.Button
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(38, 77)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(101, 36)
        Me.RadioButton4.TabIndex = 20
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "A Line Laser 3"
        Me.RadioButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.numMoveCount)
        Me.GroupBox1.Controls.Add(Me.optLaser2_A)
        Me.GroupBox1.Controls.Add(Me.optLaser1_A)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.numStartPosZ)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.numStartPosY)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numStartPosX)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(283, 345)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "LINE A"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.optLaser2_B)
        Me.GroupBox2.Controls.Add(Me.optLaser1_B)
        Me.GroupBox2.Controls.Add(Me.btnStop)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.numStepZ)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.numStepY)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.numStepX)
        Me.GroupBox2.Location = New System.Drawing.Point(325, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(276, 344)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "LINE B"
        '
        'frmLaserAutoFucusCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 369)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmLaserAutoFucusCheck"
        Me.Text = "Auto Focus Check"
        Me.TopMost = True
        CType(Me.numStartPosX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartPosY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStartPosZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStepZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStepY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStepX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMoveCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmAutoFocusCheck As System.Windows.Forms.Timer
    Friend WithEvents numStartPosX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numStartPosY As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numStartPosZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numStepZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numStepY As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numStepX As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents optLaser1_A As System.Windows.Forms.RadioButton
    Friend WithEvents optLaser2_A As System.Windows.Forms.RadioButton
    Friend WithEvents optLaser2_B As System.Windows.Forms.RadioButton
    Friend WithEvents optLaser1_B As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numMoveCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
