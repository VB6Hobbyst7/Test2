<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutoFocus
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
        Me.btnScanner1 = New System.Windows.Forms.Button()
        Me.btnScanner2 = New System.Windows.Forms.Button()
        Me.btnScanner3 = New System.Windows.Forms.Button()
        Me.btnScanner4 = New System.Windows.Forms.Button()
        Me.btnSeqStart = New System.Windows.Forms.Button()
        Me.btnSeqStop = New System.Windows.Forms.Button()
        Me.numStageX = New System.Windows.Forms.NumericUpDown()
        Me.numStageY = New System.Windows.Forms.NumericUpDown()
        Me.numScannerZ = New System.Windows.Forms.NumericUpDown()
        Me.numRepeat = New System.Windows.Forms.NumericUpDown()
        Me.btnLineA = New System.Windows.Forms.Button()
        Me.btnLineB = New System.Windows.Forms.Button()
        Me.chkMarkLineAxis = New System.Windows.Forms.CheckBox()
        Me.numPitch = New System.Windows.Forms.NumericUpDown()
        Me.chkScannerZup = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkStageLineAxis = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.numStageX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numStageY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScannerZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPitch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnScanner1
        '
        Me.btnScanner1.BackColor = System.Drawing.Color.White
        Me.btnScanner1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanner1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnScanner1.Location = New System.Drawing.Point(12, 59)
        Me.btnScanner1.Name = "btnScanner1"
        Me.btnScanner1.Size = New System.Drawing.Size(101, 55)
        Me.btnScanner1.TabIndex = 0
        Me.btnScanner1.Text = "Scanner1"
        Me.btnScanner1.UseVisualStyleBackColor = False
        '
        'btnScanner2
        '
        Me.btnScanner2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanner2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnScanner2.Location = New System.Drawing.Point(119, 59)
        Me.btnScanner2.Name = "btnScanner2"
        Me.btnScanner2.Size = New System.Drawing.Size(101, 55)
        Me.btnScanner2.TabIndex = 0
        Me.btnScanner2.Text = "Scanner2"
        Me.btnScanner2.UseVisualStyleBackColor = True
        '
        'btnScanner3
        '
        Me.btnScanner3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanner3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnScanner3.Location = New System.Drawing.Point(226, 59)
        Me.btnScanner3.Name = "btnScanner3"
        Me.btnScanner3.Size = New System.Drawing.Size(101, 55)
        Me.btnScanner3.TabIndex = 0
        Me.btnScanner3.Text = "Scanner3"
        Me.btnScanner3.UseVisualStyleBackColor = True
        '
        'btnScanner4
        '
        Me.btnScanner4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScanner4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnScanner4.Location = New System.Drawing.Point(333, 59)
        Me.btnScanner4.Name = "btnScanner4"
        Me.btnScanner4.Size = New System.Drawing.Size(101, 55)
        Me.btnScanner4.TabIndex = 0
        Me.btnScanner4.Text = "Scanner4"
        Me.btnScanner4.UseVisualStyleBackColor = True
        '
        'btnSeqStart
        '
        Me.btnSeqStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSeqStart.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSeqStart.Location = New System.Drawing.Point(226, 188)
        Me.btnSeqStart.Name = "btnSeqStart"
        Me.btnSeqStart.Size = New System.Drawing.Size(208, 68)
        Me.btnSeqStart.TabIndex = 0
        Me.btnSeqStart.Text = "Auto Focus Start"
        Me.btnSeqStart.UseVisualStyleBackColor = True
        '
        'btnSeqStop
        '
        Me.btnSeqStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSeqStop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSeqStop.Location = New System.Drawing.Point(226, 268)
        Me.btnSeqStop.Name = "btnSeqStop"
        Me.btnSeqStop.Size = New System.Drawing.Size(208, 68)
        Me.btnSeqStop.TabIndex = 0
        Me.btnSeqStop.Text = "Auto Focus Stop"
        Me.btnSeqStop.UseVisualStyleBackColor = True
        '
        'numStageX
        '
        Me.numStageX.DecimalPlaces = 3
        Me.numStageX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numStageX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStageX.Location = New System.Drawing.Point(79, 188)
        Me.numStageX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numStageX.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numStageX.Name = "numStageX"
        Me.numStageX.Size = New System.Drawing.Size(100, 22)
        Me.numStageX.TabIndex = 642
        Me.numStageX.TabStop = False
        Me.numStageX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numStageY
        '
        Me.numStageY.DecimalPlaces = 3
        Me.numStageY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numStageY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numStageY.Location = New System.Drawing.Point(79, 220)
        Me.numStageY.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numStageY.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numStageY.Name = "numStageY"
        Me.numStageY.Size = New System.Drawing.Size(100, 22)
        Me.numStageY.TabIndex = 642
        Me.numStageY.TabStop = False
        Me.numStageY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numScannerZ
        '
        Me.numScannerZ.DecimalPlaces = 3
        Me.numScannerZ.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numScannerZ.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numScannerZ.Location = New System.Drawing.Point(79, 252)
        Me.numScannerZ.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numScannerZ.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numScannerZ.Name = "numScannerZ"
        Me.numScannerZ.Size = New System.Drawing.Size(100, 22)
        Me.numScannerZ.TabIndex = 642
        Me.numScannerZ.TabStop = False
        Me.numScannerZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numRepeat
        '
        Me.numRepeat.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numRepeat.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numRepeat.Location = New System.Drawing.Point(79, 314)
        Me.numRepeat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numRepeat.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numRepeat.Name = "numRepeat"
        Me.numRepeat.Size = New System.Drawing.Size(100, 22)
        Me.numRepeat.TabIndex = 642
        Me.numRepeat.TabStop = False
        Me.numRepeat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnLineA
        '
        Me.btnLineA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLineA.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLineA.Location = New System.Drawing.Point(12, 12)
        Me.btnLineA.Name = "btnLineA"
        Me.btnLineA.Size = New System.Drawing.Size(208, 37)
        Me.btnLineA.TabIndex = 0
        Me.btnLineA.Text = "LineA"
        Me.btnLineA.UseVisualStyleBackColor = True
        '
        'btnLineB
        '
        Me.btnLineB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLineB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnLineB.Location = New System.Drawing.Point(226, 12)
        Me.btnLineB.Name = "btnLineB"
        Me.btnLineB.Size = New System.Drawing.Size(206, 37)
        Me.btnLineB.TabIndex = 0
        Me.btnLineB.Text = "LineB"
        Me.btnLineB.UseVisualStyleBackColor = True
        '
        'chkMarkLineAxis
        '
        Me.chkMarkLineAxis.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMarkLineAxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMarkLineAxis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarkLineAxis.Location = New System.Drawing.Point(333, 120)
        Me.chkMarkLineAxis.Name = "chkMarkLineAxis"
        Me.chkMarkLineAxis.Size = New System.Drawing.Size(101, 55)
        Me.chkMarkLineAxis.TabIndex = 643
        Me.chkMarkLineAxis.Text = "Stage Axis Y"
        Me.chkMarkLineAxis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkMarkLineAxis.UseVisualStyleBackColor = True
        '
        'numPitch
        '
        Me.numPitch.DecimalPlaces = 3
        Me.numPitch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numPitch.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numPitch.Location = New System.Drawing.Point(79, 284)
        Me.numPitch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numPitch.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numPitch.Name = "numPitch"
        Me.numPitch.Size = New System.Drawing.Size(100, 22)
        Me.numPitch.TabIndex = 642
        Me.numPitch.TabStop = False
        Me.numPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkScannerZup
        '
        Me.chkScannerZup.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkScannerZup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkScannerZup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkScannerZup.Location = New System.Drawing.Point(119, 120)
        Me.chkScannerZup.Name = "chkScannerZup"
        Me.chkScannerZup.Size = New System.Drawing.Size(101, 55)
        Me.chkScannerZup.TabIndex = 643
        Me.chkScannerZup.Text = "Scanner Axis Z +"
        Me.chkScannerZup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkScannerZup.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.TabIndex = 645
        Me.Label2.Text = "Stage X"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 645
        Me.Label1.Text = "Stage Y"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 255)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 20)
        Me.Label3.TabIndex = 645
        Me.Label3.Text = "Scanner Z"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 287)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 645
        Me.Label4.Text = "Pitch"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 317)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 20)
        Me.Label5.TabIndex = 645
        Me.Label5.Text = "Repeat"
        '
        'chkStageLineAxis
        '
        Me.chkStageLineAxis.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkStageLineAxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkStageLineAxis.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStageLineAxis.Location = New System.Drawing.Point(226, 120)
        Me.chkStageLineAxis.Name = "chkStageLineAxis"
        Me.chkStageLineAxis.Size = New System.Drawing.Size(101, 55)
        Me.chkStageLineAxis.TabIndex = 643
        Me.chkStageLineAxis.Text = "Stage Axis +"
        Me.chkStageLineAxis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkStageLineAxis.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(187, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 20)
        Me.Label6.TabIndex = 645
        Me.Label6.Text = "mm"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(187, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 20)
        Me.Label7.TabIndex = 645
        Me.Label7.Text = "mm"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(187, 254)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 20)
        Me.Label8.TabIndex = 645
        Me.Label8.Text = "mm"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(187, 286)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 20)
        Me.Label10.TabIndex = 645
        Me.Label10.Text = "mm"
        '
        'frmAutoFocus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(444, 373)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkStageLineAxis)
        Me.Controls.Add(Me.chkScannerZup)
        Me.Controls.Add(Me.chkMarkLineAxis)
        Me.Controls.Add(Me.numPitch)
        Me.Controls.Add(Me.numRepeat)
        Me.Controls.Add(Me.numScannerZ)
        Me.Controls.Add(Me.numStageY)
        Me.Controls.Add(Me.numStageX)
        Me.Controls.Add(Me.btnSeqStop)
        Me.Controls.Add(Me.btnSeqStart)
        Me.Controls.Add(Me.btnLineB)
        Me.Controls.Add(Me.btnLineA)
        Me.Controls.Add(Me.btnScanner4)
        Me.Controls.Add(Me.btnScanner3)
        Me.Controls.Add(Me.btnScanner2)
        Me.Controls.Add(Me.btnScanner1)
        Me.Name = "frmAutoFocus"
        Me.Text = "frmAutoFocus"
        CType(Me.numStageX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numStageY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScannerZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPitch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnScanner1 As System.Windows.Forms.Button
    Friend WithEvents btnScanner2 As System.Windows.Forms.Button
    Friend WithEvents btnScanner3 As System.Windows.Forms.Button
    Friend WithEvents btnScanner4 As System.Windows.Forms.Button
    Friend WithEvents btnSeqStart As System.Windows.Forms.Button
    Friend WithEvents btnSeqStop As System.Windows.Forms.Button
    Friend WithEvents numStageX As System.Windows.Forms.NumericUpDown
    Friend WithEvents numStageY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScannerZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents numRepeat As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnLineA As System.Windows.Forms.Button
    Friend WithEvents btnLineB As System.Windows.Forms.Button
    Friend WithEvents chkMarkLineAxis As System.Windows.Forms.CheckBox
    Friend WithEvents numPitch As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkScannerZup As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkStageLineAxis As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
