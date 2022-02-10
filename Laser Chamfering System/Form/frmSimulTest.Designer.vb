<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSimulTest
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
        Me.btnImgLoad2 = New System.Windows.Forms.Button()
        Me.btnImgLoad1 = New System.Windows.Forms.Button()
        Me.txtImg2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblImgFile1 = New System.Windows.Forms.Label()
        Me.txtImg1 = New System.Windows.Forms.TextBox()
        Me.rdoLineB = New System.Windows.Forms.RadioButton()
        Me.rdoLineA = New System.Windows.Forms.RadioButton()
        Me.btnGrab4 = New System.Windows.Forms.Button()
        Me.btnGrab3 = New System.Windows.Forms.Button()
        Me.btnGrab2 = New System.Windows.Forms.Button()
        Me.btnGrab1 = New System.Windows.Forms.Button()
        Me.txtData = New System.Windows.Forms.RichTextBox()
        Me.txtMarkingPos = New System.Windows.Forms.RichTextBox()
        Me.btnCalcMarkingPos1 = New System.Windows.Forms.Button()
        Me.btnCalcMarkingPos2 = New System.Windows.Forms.Button()
        Me.btnCalcMarkingPos3 = New System.Windows.Forms.Button()
        Me.btnCalcMarkingPos4 = New System.Windows.Forms.Button()
        Me.btnCalVisionValue = New System.Windows.Forms.Button()
        Me.chkLine = New System.Windows.Forms.CheckBox()
        Me.numStageMove = New System.Windows.Forms.NumericUpDown()
        Me.lboxGetVisionData = New System.Windows.Forms.ListBox()
        Me.btnFindModel_2 = New System.Windows.Forms.Button()
        Me.btnMoveStageX = New System.Windows.Forms.Button()
        Me.btnFindModel_1 = New System.Windows.Forms.Button()
        Me.numCamera = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnlInput = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlOutput = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.numStageMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCamera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImgLoad2
        '
        Me.btnImgLoad2.Location = New System.Drawing.Point(268, 78)
        Me.btnImgLoad2.Name = "btnImgLoad2"
        Me.btnImgLoad2.Size = New System.Drawing.Size(75, 23)
        Me.btnImgLoad2.TabIndex = 37
        Me.btnImgLoad2.Text = "open"
        Me.btnImgLoad2.UseVisualStyleBackColor = True
        '
        'btnImgLoad1
        '
        Me.btnImgLoad1.Location = New System.Drawing.Point(268, 49)
        Me.btnImgLoad1.Name = "btnImgLoad1"
        Me.btnImgLoad1.Size = New System.Drawing.Size(75, 23)
        Me.btnImgLoad1.TabIndex = 36
        Me.btnImgLoad1.Text = "open"
        Me.btnImgLoad1.UseVisualStyleBackColor = True
        '
        'txtImg2
        '
        Me.txtImg2.Location = New System.Drawing.Point(84, 81)
        Me.txtImg2.Name = "txtImg2"
        Me.txtImg2.Size = New System.Drawing.Size(182, 21)
        Me.txtImg2.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 12)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "image2"
        '
        'lblImgFile1
        '
        Me.lblImgFile1.AutoSize = True
        Me.lblImgFile1.Location = New System.Drawing.Point(10, 57)
        Me.lblImgFile1.Name = "lblImgFile1"
        Me.lblImgFile1.Size = New System.Drawing.Size(46, 12)
        Me.lblImgFile1.TabIndex = 33
        Me.lblImgFile1.Text = "image1"
        '
        'txtImg1
        '
        Me.txtImg1.Location = New System.Drawing.Point(84, 52)
        Me.txtImg1.Name = "txtImg1"
        Me.txtImg1.Size = New System.Drawing.Size(182, 21)
        Me.txtImg1.TabIndex = 32
        '
        'rdoLineB
        '
        Me.rdoLineB.AutoSize = True
        Me.rdoLineB.Location = New System.Drawing.Point(132, 21)
        Me.rdoLineB.Name = "rdoLineB"
        Me.rdoLineB.Size = New System.Drawing.Size(59, 16)
        Me.rdoLineB.TabIndex = 31
        Me.rdoLineB.TabStop = True
        Me.rdoLineB.Text = "Line B"
        Me.rdoLineB.UseVisualStyleBackColor = True
        '
        'rdoLineA
        '
        Me.rdoLineA.AutoSize = True
        Me.rdoLineA.Checked = True
        Me.rdoLineA.Location = New System.Drawing.Point(28, 21)
        Me.rdoLineA.Name = "rdoLineA"
        Me.rdoLineA.Size = New System.Drawing.Size(59, 16)
        Me.rdoLineA.TabIndex = 30
        Me.rdoLineA.TabStop = True
        Me.rdoLineA.Text = "Line A"
        Me.rdoLineA.UseVisualStyleBackColor = True
        '
        'btnGrab4
        '
        Me.btnGrab4.Location = New System.Drawing.Point(12, 485)
        Me.btnGrab4.Name = "btnGrab4"
        Me.btnGrab4.Size = New System.Drawing.Size(99, 36)
        Me.btnGrab4.TabIndex = 27
        Me.btnGrab4.Text = "#4 Grab"
        Me.btnGrab4.UseVisualStyleBackColor = True
        '
        'btnGrab3
        '
        Me.btnGrab3.Location = New System.Drawing.Point(12, 443)
        Me.btnGrab3.Name = "btnGrab3"
        Me.btnGrab3.Size = New System.Drawing.Size(99, 36)
        Me.btnGrab3.TabIndex = 26
        Me.btnGrab3.Text = "#3 Grab"
        Me.btnGrab3.UseVisualStyleBackColor = True
        '
        'btnGrab2
        '
        Me.btnGrab2.Location = New System.Drawing.Point(12, 401)
        Me.btnGrab2.Name = "btnGrab2"
        Me.btnGrab2.Size = New System.Drawing.Size(52, 36)
        Me.btnGrab2.TabIndex = 25
        Me.btnGrab2.Text = "#2 Grab"
        Me.btnGrab2.UseVisualStyleBackColor = True
        '
        'btnGrab1
        '
        Me.btnGrab1.Location = New System.Drawing.Point(12, 359)
        Me.btnGrab1.Name = "btnGrab1"
        Me.btnGrab1.Size = New System.Drawing.Size(52, 36)
        Me.btnGrab1.TabIndex = 24
        Me.btnGrab1.Text = "#1 Grab"
        Me.btnGrab1.UseVisualStyleBackColor = True
        '
        'txtData
        '
        Me.txtData.Location = New System.Drawing.Point(12, 117)
        Me.txtData.Name = "txtData"
        Me.txtData.Size = New System.Drawing.Size(195, 227)
        Me.txtData.TabIndex = 23
        Me.txtData.Text = ""
        '
        'txtMarkingPos
        '
        Me.txtMarkingPos.Location = New System.Drawing.Point(213, 117)
        Me.txtMarkingPos.Name = "txtMarkingPos"
        Me.txtMarkingPos.Size = New System.Drawing.Size(130, 227)
        Me.txtMarkingPos.TabIndex = 38
        Me.txtMarkingPos.Text = ""
        '
        'btnCalcMarkingPos1
        '
        Me.btnCalcMarkingPos1.Location = New System.Drawing.Point(117, 359)
        Me.btnCalcMarkingPos1.Name = "btnCalcMarkingPos1"
        Me.btnCalcMarkingPos1.Size = New System.Drawing.Size(149, 36)
        Me.btnCalcMarkingPos1.TabIndex = 29
        Me.btnCalcMarkingPos1.Text = "Calc Marking Position"
        Me.btnCalcMarkingPos1.UseVisualStyleBackColor = True
        '
        'btnCalcMarkingPos2
        '
        Me.btnCalcMarkingPos2.Location = New System.Drawing.Point(117, 401)
        Me.btnCalcMarkingPos2.Name = "btnCalcMarkingPos2"
        Me.btnCalcMarkingPos2.Size = New System.Drawing.Size(149, 36)
        Me.btnCalcMarkingPos2.TabIndex = 39
        Me.btnCalcMarkingPos2.Text = "Calc Marking Position"
        Me.btnCalcMarkingPos2.UseVisualStyleBackColor = True
        '
        'btnCalcMarkingPos3
        '
        Me.btnCalcMarkingPos3.Location = New System.Drawing.Point(117, 443)
        Me.btnCalcMarkingPos3.Name = "btnCalcMarkingPos3"
        Me.btnCalcMarkingPos3.Size = New System.Drawing.Size(149, 36)
        Me.btnCalcMarkingPos3.TabIndex = 40
        Me.btnCalcMarkingPos3.Text = "Calc Marking Position"
        Me.btnCalcMarkingPos3.UseVisualStyleBackColor = True
        '
        'btnCalcMarkingPos4
        '
        Me.btnCalcMarkingPos4.Location = New System.Drawing.Point(117, 485)
        Me.btnCalcMarkingPos4.Name = "btnCalcMarkingPos4"
        Me.btnCalcMarkingPos4.Size = New System.Drawing.Size(149, 36)
        Me.btnCalcMarkingPos4.TabIndex = 41
        Me.btnCalcMarkingPos4.Text = "Calc Marking Position"
        Me.btnCalcMarkingPos4.UseVisualStyleBackColor = True
        '
        'btnCalVisionValue
        '
        Me.btnCalVisionValue.Location = New System.Drawing.Point(64, 662)
        Me.btnCalVisionValue.Name = "btnCalVisionValue"
        Me.btnCalVisionValue.Size = New System.Drawing.Size(71, 21)
        Me.btnCalVisionValue.TabIndex = 53
        Me.btnCalVisionValue.Text = "Cal"
        Me.btnCalVisionValue.UseVisualStyleBackColor = True
        '
        'chkLine
        '
        Me.chkLine.AutoSize = True
        Me.chkLine.Location = New System.Drawing.Point(390, 534)
        Me.chkLine.Name = "chkLine"
        Me.chkLine.Size = New System.Drawing.Size(60, 16)
        Me.chkLine.TabIndex = 52
        Me.chkLine.Text = "Line A"
        Me.chkLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkLine.UseVisualStyleBackColor = True
        '
        'numStageMove
        '
        Me.numStageMove.DecimalPlaces = 3
        Me.numStageMove.Location = New System.Drawing.Point(104, 531)
        Me.numStageMove.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numStageMove.Minimum = New Decimal(New Integer() {2, 0, 0, -2147483648})
        Me.numStageMove.Name = "numStageMove"
        Me.numStageMove.Size = New System.Drawing.Size(79, 21)
        Me.numStageMove.TabIndex = 51
        Me.numStageMove.Value = New Decimal(New Integer() {2, 0, 0, -2147483648})
        '
        'lboxGetVisionData
        '
        Me.lboxGetVisionData.FormattingEnabled = True
        Me.lboxGetVisionData.ItemHeight = 12
        Me.lboxGetVisionData.Location = New System.Drawing.Point(12, 558)
        Me.lboxGetVisionData.Name = "lboxGetVisionData"
        Me.lboxGetVisionData.Size = New System.Drawing.Size(422, 88)
        Me.lboxGetVisionData.TabIndex = 50
        '
        'btnFindModel_2
        '
        Me.btnFindModel_2.Location = New System.Drawing.Point(298, 531)
        Me.btnFindModel_2.Name = "btnFindModel_2"
        Me.btnFindModel_2.Size = New System.Drawing.Size(86, 21)
        Me.btnFindModel_2.TabIndex = 49
        Me.btnFindModel_2.Text = "Get_2"
        Me.btnFindModel_2.UseVisualStyleBackColor = True
        '
        'btnMoveStageX
        '
        Me.btnMoveStageX.Location = New System.Drawing.Point(189, 531)
        Me.btnMoveStageX.Name = "btnMoveStageX"
        Me.btnMoveStageX.Size = New System.Drawing.Size(103, 21)
        Me.btnMoveStageX.TabIndex = 48
        Me.btnMoveStageX.Text = "Move Stage X"
        Me.btnMoveStageX.UseVisualStyleBackColor = True
        '
        'btnFindModel_1
        '
        Me.btnFindModel_1.Location = New System.Drawing.Point(12, 531)
        Me.btnFindModel_1.Name = "btnFindModel_1"
        Me.btnFindModel_1.Size = New System.Drawing.Size(86, 21)
        Me.btnFindModel_1.TabIndex = 47
        Me.btnFindModel_1.Text = "Get_1"
        Me.btnFindModel_1.UseVisualStyleBackColor = True
        '
        'numCamera
        '
        Me.numCamera.Location = New System.Drawing.Point(12, 664)
        Me.numCamera.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.numCamera.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCamera.Name = "numCamera"
        Me.numCamera.Size = New System.Drawing.Size(44, 21)
        Me.numCamera.TabIndex = 46
        Me.numCamera.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 401)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 36)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "#2 Grab"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(64, 359)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(52, 36)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "#1 Grab"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnlInput
        '
        Me.pnlInput.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.pnlInput.Location = New System.Drawing.Point(456, 12)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.Size = New System.Drawing.Size(765, 1030)
        Me.pnlInput.TabIndex = 56
        '
        'pnlOutput
        '
        Me.pnlOutput.Location = New System.Drawing.Point(50, 749)
        Me.pnlOutput.Name = "pnlOutput"
        Me.pnlOutput.Size = New System.Drawing.Size(206, 33)
        Me.pnlOutput.TabIndex = 57
        '
        'frmSimulTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1227, 1054)
        Me.Controls.Add(Me.pnlOutput)
        Me.Controls.Add(Me.pnlInput)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnCalVisionValue)
        Me.Controls.Add(Me.chkLine)
        Me.Controls.Add(Me.numStageMove)
        Me.Controls.Add(Me.lboxGetVisionData)
        Me.Controls.Add(Me.btnFindModel_2)
        Me.Controls.Add(Me.btnMoveStageX)
        Me.Controls.Add(Me.btnFindModel_1)
        Me.Controls.Add(Me.numCamera)
        Me.Controls.Add(Me.btnCalcMarkingPos4)
        Me.Controls.Add(Me.btnCalcMarkingPos3)
        Me.Controls.Add(Me.btnCalcMarkingPos2)
        Me.Controls.Add(Me.txtMarkingPos)
        Me.Controls.Add(Me.btnImgLoad2)
        Me.Controls.Add(Me.btnImgLoad1)
        Me.Controls.Add(Me.txtImg2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblImgFile1)
        Me.Controls.Add(Me.txtImg1)
        Me.Controls.Add(Me.rdoLineB)
        Me.Controls.Add(Me.rdoLineA)
        Me.Controls.Add(Me.btnCalcMarkingPos1)
        Me.Controls.Add(Me.btnGrab4)
        Me.Controls.Add(Me.btnGrab3)
        Me.Controls.Add(Me.btnGrab2)
        Me.Controls.Add(Me.btnGrab1)
        Me.Controls.Add(Me.txtData)
        Me.Name = "frmSimulTest"
        Me.Text = "frmSimulTest"
        CType(Me.numStageMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCamera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImgLoad2 As System.Windows.Forms.Button
    Friend WithEvents btnImgLoad1 As System.Windows.Forms.Button
    Friend WithEvents txtImg2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblImgFile1 As System.Windows.Forms.Label
    Friend WithEvents txtImg1 As System.Windows.Forms.TextBox
    Friend WithEvents rdoLineB As System.Windows.Forms.RadioButton
    Friend WithEvents rdoLineA As System.Windows.Forms.RadioButton
    Friend WithEvents btnGrab4 As System.Windows.Forms.Button
    Friend WithEvents btnGrab3 As System.Windows.Forms.Button
    Friend WithEvents btnGrab2 As System.Windows.Forms.Button
    Friend WithEvents btnGrab1 As System.Windows.Forms.Button
    Friend WithEvents txtData As System.Windows.Forms.RichTextBox
    Friend WithEvents txtMarkingPos As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCalcMarkingPos1 As System.Windows.Forms.Button
    Friend WithEvents btnCalcMarkingPos2 As System.Windows.Forms.Button
    Friend WithEvents btnCalcMarkingPos3 As System.Windows.Forms.Button
    Friend WithEvents btnCalcMarkingPos4 As System.Windows.Forms.Button
    Friend WithEvents btnCalVisionValue As System.Windows.Forms.Button
    Friend WithEvents chkLine As System.Windows.Forms.CheckBox
    Friend WithEvents numStageMove As System.Windows.Forms.NumericUpDown
    Friend WithEvents lboxGetVisionData As System.Windows.Forms.ListBox
    Friend WithEvents btnFindModel_2 As System.Windows.Forms.Button
    Friend WithEvents btnMoveStageX As System.Windows.Forms.Button
    Friend WithEvents btnFindModel_1 As System.Windows.Forms.Button
    Friend WithEvents numCamera As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pnlInput As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlOutput As System.Windows.Forms.FlowLayoutPanel
End Class
