<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCamResolution
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlCam = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSizeLR = New System.Windows.Forms.Button()
        Me.rdoRight = New System.Windows.Forms.RadioButton()
        Me.btnRight = New System.Windows.Forms.Button()
        Me.btnLeft = New System.Windows.Forms.Button()
        Me.rdoLeft = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSizeUD = New System.Windows.Forms.Button()
        Me.rdoBot = New System.Windows.Forms.RadioButton()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.rdoTop = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtResY = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtResX = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObjY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObjX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdoCam4 = New System.Windows.Forms.RadioButton()
        Me.rdoCam3 = New System.Windows.Forms.RadioButton()
        Me.rdoCam2 = New System.Windows.Forms.RadioButton()
        Me.rdoCam1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1498, 803)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'pnlCam
        '
        Me.pnlCam.Location = New System.Drawing.Point(0, 0)
        Me.pnlCam.Name = "pnlCam"
        Me.pnlCam.Size = New System.Drawing.Size(1360, 1040)
        Me.pnlCam.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSizeLR)
        Me.GroupBox1.Controls.Add(Me.rdoRight)
        Me.GroupBox1.Controls.Add(Me.btnRight)
        Me.GroupBox1.Controls.Add(Me.btnLeft)
        Me.GroupBox1.Controls.Add(Me.rdoLeft)
        Me.GroupBox1.Location = New System.Drawing.Point(1382, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(199, 171)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'btnSizeLR
        '
        Me.btnSizeLR.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSizeLR.Location = New System.Drawing.Point(69, 71)
        Me.btnSizeLR.Name = "btnSizeLR"
        Me.btnSizeLR.Size = New System.Drawing.Size(61, 82)
        Me.btnSizeLR.TabIndex = 9
        Me.btnSizeLR.Text = "10"
        Me.btnSizeLR.UseVisualStyleBackColor = True
        '
        'rdoRight
        '
        Me.rdoRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoRight.Location = New System.Drawing.Point(102, 20)
        Me.rdoRight.Name = "rdoRight"
        Me.rdoRight.Size = New System.Drawing.Size(70, 45)
        Me.rdoRight.TabIndex = 8
        Me.rdoRight.Text = "Right"
        Me.rdoRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoRight.UseVisualStyleBackColor = True
        '
        'btnRight
        '
        Me.btnRight.Location = New System.Drawing.Point(134, 71)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(38, 83)
        Me.btnRight.TabIndex = 7
        Me.btnRight.Text = "▶"
        Me.btnRight.UseVisualStyleBackColor = True
        '
        'btnLeft
        '
        Me.btnLeft.Location = New System.Drawing.Point(26, 71)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(38, 83)
        Me.btnLeft.TabIndex = 6
        Me.btnLeft.Text = "◀"
        Me.btnLeft.UseVisualStyleBackColor = True
        '
        'rdoLeft
        '
        Me.rdoLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoLeft.Checked = True
        Me.rdoLeft.Location = New System.Drawing.Point(26, 20)
        Me.rdoLeft.Name = "rdoLeft"
        Me.rdoLeft.Size = New System.Drawing.Size(70, 45)
        Me.rdoLeft.TabIndex = 0
        Me.rdoLeft.TabStop = True
        Me.rdoLeft.Text = "Left"
        Me.rdoLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoLeft.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSizeUD)
        Me.GroupBox2.Controls.Add(Me.rdoBot)
        Me.GroupBox2.Controls.Add(Me.btnDown)
        Me.GroupBox2.Controls.Add(Me.btnUp)
        Me.GroupBox2.Controls.Add(Me.rdoTop)
        Me.GroupBox2.Location = New System.Drawing.Point(1382, 177)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(199, 173)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'btnSizeUD
        '
        Me.btnSizeUD.Font = New System.Drawing.Font("굴림", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSizeUD.Location = New System.Drawing.Point(94, 64)
        Me.btnSizeUD.Name = "btnSizeUD"
        Me.btnSizeUD.Size = New System.Drawing.Size(78, 54)
        Me.btnSizeUD.TabIndex = 9
        Me.btnSizeUD.Text = "10"
        Me.btnSizeUD.UseVisualStyleBackColor = True
        '
        'rdoBot
        '
        Me.rdoBot.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoBot.Location = New System.Drawing.Point(26, 96)
        Me.rdoBot.Name = "rdoBot"
        Me.rdoBot.Size = New System.Drawing.Size(62, 62)
        Me.rdoBot.TabIndex = 8
        Me.rdoBot.Text = "Bottom"
        Me.rdoBot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoBot.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Location = New System.Drawing.Point(94, 124)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(78, 34)
        Me.btnDown.TabIndex = 7
        Me.btnDown.Text = "▼"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Location = New System.Drawing.Point(94, 24)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(78, 34)
        Me.btnUp.TabIndex = 6
        Me.btnUp.Text = "▲"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'rdoTop
        '
        Me.rdoTop.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoTop.Checked = True
        Me.rdoTop.Location = New System.Drawing.Point(26, 24)
        Me.rdoTop.Name = "rdoTop"
        Me.rdoTop.Size = New System.Drawing.Size(62, 66)
        Me.rdoTop.TabIndex = 0
        Me.rdoTop.TabStop = True
        Me.rdoTop.Text = "Top"
        Me.rdoTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoTop.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtResY)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtResX)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.btnCalc)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtObjY)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtObjX)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(1382, 356)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(199, 290)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Camera Resolution"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(23, 249)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 24)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(145, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "mm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Y"
        '
        'txtResY
        '
        Me.txtResY.Location = New System.Drawing.Point(53, 207)
        Me.txtResY.Name = "txtResY"
        Me.txtResY.ReadOnly = True
        Me.txtResY.Size = New System.Drawing.Size(90, 21)
        Me.txtResY.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(145, 189)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 12)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "mm"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 12)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "X"
        '
        'txtResX
        '
        Me.txtResX.Location = New System.Drawing.Point(53, 180)
        Me.txtResX.Name = "txtResX"
        Me.txtResX.ReadOnly = True
        Me.txtResX.Size = New System.Drawing.Size(90, 21)
        Me.txtResX.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 12)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Pixel Resolution"
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(27, 115)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(145, 24)
        Me.btnCalc.TabIndex = 7
        Me.btnCalc.Text = "Calculate"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(145, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "mm"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Y"
        '
        'txtObjY
        '
        Me.txtObjY.Location = New System.Drawing.Point(53, 78)
        Me.txtObjY.Name = "txtObjY"
        Me.txtObjY.Size = New System.Drawing.Size(90, 21)
        Me.txtObjY.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(145, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "mm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "X"
        '
        'txtObjX
        '
        Me.txtObjX.Location = New System.Drawing.Point(53, 51)
        Me.txtObjX.Name = "txtObjX"
        Me.txtObjX.Size = New System.Drawing.Size(90, 21)
        Me.txtObjX.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Object Size"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdoCam4)
        Me.GroupBox4.Controls.Add(Me.rdoCam3)
        Me.GroupBox4.Controls.Add(Me.rdoCam2)
        Me.GroupBox4.Controls.Add(Me.rdoCam1)
        Me.GroupBox4.Location = New System.Drawing.Point(1382, 885)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(199, 109)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        Me.GroupBox4.Visible = False
        '
        'rdoCam4
        '
        Me.rdoCam4.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoCam4.Location = New System.Drawing.Point(102, 56)
        Me.rdoCam4.Name = "rdoCam4"
        Me.rdoCam4.Size = New System.Drawing.Size(81, 30)
        Me.rdoCam4.TabIndex = 3
        Me.rdoCam4.Text = "Cam #4"
        Me.rdoCam4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoCam4.UseVisualStyleBackColor = True
        '
        'rdoCam3
        '
        Me.rdoCam3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoCam3.Location = New System.Drawing.Point(15, 56)
        Me.rdoCam3.Name = "rdoCam3"
        Me.rdoCam3.Size = New System.Drawing.Size(81, 30)
        Me.rdoCam3.TabIndex = 2
        Me.rdoCam3.Text = "Cam #3"
        Me.rdoCam3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoCam3.UseVisualStyleBackColor = True
        '
        'rdoCam2
        '
        Me.rdoCam2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoCam2.Location = New System.Drawing.Point(102, 20)
        Me.rdoCam2.Name = "rdoCam2"
        Me.rdoCam2.Size = New System.Drawing.Size(81, 30)
        Me.rdoCam2.TabIndex = 1
        Me.rdoCam2.Text = "Cam #2"
        Me.rdoCam2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoCam2.UseVisualStyleBackColor = True
        '
        'rdoCam1
        '
        Me.rdoCam1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoCam1.Checked = True
        Me.rdoCam1.Location = New System.Drawing.Point(15, 20)
        Me.rdoCam1.Name = "rdoCam1"
        Me.rdoCam1.Size = New System.Drawing.Size(81, 30)
        Me.rdoCam1.TabIndex = 0
        Me.rdoCam1.TabStop = True
        Me.rdoCam1.Text = "Cam #1"
        Me.rdoCam1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoCam1.UseVisualStyleBackColor = True
        '
        'frmCamResolution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1599, 1032)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlCam)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmCamResolution"
        Me.Text = "frmCamResolution"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pnlCam As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoRight As System.Windows.Forms.RadioButton
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents rdoLeft As System.Windows.Forms.RadioButton
    Friend WithEvents btnSizeLR As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSizeUD As System.Windows.Forms.Button
    Friend WithEvents rdoBot As System.Windows.Forms.RadioButton
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents rdoTop As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtResY As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtResX As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCalc As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObjY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObjX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoCam4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCam3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCam2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCam1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
