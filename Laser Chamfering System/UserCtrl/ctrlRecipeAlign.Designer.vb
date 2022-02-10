<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlRecipeAlign
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
        Me.gbAlign = New System.Windows.Forms.GroupBox()
        Me.tabPanel = New System.Windows.Forms.TabControl()
        Me.tabPagePanel1 = New System.Windows.Forms.TabPage()
        Me.tabPagePanel2 = New System.Windows.Forms.TabPage()
        Me.tabPagePanel3 = New System.Windows.Forms.TabPage()
        Me.tabPagePanel4 = New System.Windows.Forms.TabPage()
        Me.gbAlignDistace = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnMatch = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAlignCenterY = New System.Windows.Forms.Button()
        Me.btnAlignCenterX = New System.Windows.Forms.Button()
        Me.numAlignCenterY = New System.Windows.Forms.NumericUpDown()
        Me.numAlignCenterX = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAlignRetry = New System.Windows.Forms.Button()
        Me.numAlignRetry = New System.Windows.Forms.NumericUpDown()
        Me.numAlignErrorRange = New System.Windows.Forms.NumericUpDown()
        Me.btnAlignDistance = New System.Windows.Forms.Button()
        Me.numAlignDistance = New System.Windows.Forms.NumericUpDown()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.gbAlignLightSet = New System.Windows.Forms.GroupBox()
        Me.btnAlignVisionParam = New System.Windows.Forms.Button()
        Me.gbAlign.SuspendLayout()
        Me.tabPanel.SuspendLayout()
        Me.gbAlignDistace.SuspendLayout()
        CType(Me.numAlignCenterY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAlignCenterX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAlignRetry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAlignErrorRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAlignDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAlignLightSet.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbAlign
        '
        Me.gbAlign.Controls.Add(Me.tabPanel)
        Me.gbAlign.Controls.Add(Me.gbAlignDistace)
        Me.gbAlign.Controls.Add(Me.gbAlignLightSet)
        Me.gbAlign.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbAlign.Location = New System.Drawing.Point(3, 3)
        Me.gbAlign.Name = "gbAlign"
        Me.gbAlign.Size = New System.Drawing.Size(685, 820)
        Me.gbAlign.TabIndex = 8
        Me.gbAlign.TabStop = False
        Me.gbAlign.Text = "Align"
        '
        'tabPanel
        '
        Me.tabPanel.Controls.Add(Me.tabPagePanel1)
        Me.tabPanel.Controls.Add(Me.tabPagePanel2)
        Me.tabPanel.Controls.Add(Me.tabPagePanel3)
        Me.tabPanel.Controls.Add(Me.tabPagePanel4)
        Me.tabPanel.Location = New System.Drawing.Point(2, 145)
        Me.tabPanel.Name = "tabPanel"
        Me.tabPanel.SelectedIndex = 0
        Me.tabPanel.Size = New System.Drawing.Size(680, 669)
        Me.tabPanel.TabIndex = 706
        '
        'tabPagePanel1
        '
        Me.tabPagePanel1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.tabPagePanel1.Location = New System.Drawing.Point(4, 26)
        Me.tabPagePanel1.Name = "tabPagePanel1"
        Me.tabPagePanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagePanel1.Size = New System.Drawing.Size(672, 639)
        Me.tabPagePanel1.TabIndex = 0
        Me.tabPagePanel1.Text = "Panel #1"
        Me.tabPagePanel1.UseVisualStyleBackColor = True
        '
        'tabPagePanel2
        '
        Me.tabPagePanel2.Location = New System.Drawing.Point(4, 26)
        Me.tabPagePanel2.Name = "tabPagePanel2"
        Me.tabPagePanel2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagePanel2.Size = New System.Drawing.Size(672, 639)
        Me.tabPagePanel2.TabIndex = 1
        Me.tabPagePanel2.Text = "#2"
        Me.tabPagePanel2.UseVisualStyleBackColor = True
        '
        'tabPagePanel3
        '
        Me.tabPagePanel3.Location = New System.Drawing.Point(4, 26)
        Me.tabPagePanel3.Name = "tabPagePanel3"
        Me.tabPagePanel3.Size = New System.Drawing.Size(672, 639)
        Me.tabPagePanel3.TabIndex = 2
        Me.tabPagePanel3.Text = "#3"
        Me.tabPagePanel3.UseVisualStyleBackColor = True
        '
        'tabPagePanel4
        '
        Me.tabPagePanel4.Location = New System.Drawing.Point(4, 26)
        Me.tabPagePanel4.Name = "tabPagePanel4"
        Me.tabPagePanel4.Size = New System.Drawing.Size(672, 639)
        Me.tabPagePanel4.TabIndex = 3
        Me.tabPagePanel4.Text = "#4"
        Me.tabPagePanel4.UseVisualStyleBackColor = True
        '
        'gbAlignDistace
        '
        Me.gbAlignDistace.Controls.Add(Me.Label5)
        Me.gbAlignDistace.Controls.Add(Me.btnMatch)
        Me.gbAlignDistace.Controls.Add(Me.Label4)
        Me.gbAlignDistace.Controls.Add(Me.Label2)
        Me.gbAlignDistace.Controls.Add(Me.Label3)
        Me.gbAlignDistace.Controls.Add(Me.btnAlignCenterY)
        Me.gbAlignDistace.Controls.Add(Me.btnAlignCenterX)
        Me.gbAlignDistace.Controls.Add(Me.numAlignCenterY)
        Me.gbAlignDistace.Controls.Add(Me.numAlignCenterX)
        Me.gbAlignDistace.Controls.Add(Me.Label1)
        Me.gbAlignDistace.Controls.Add(Me.btnAlignRetry)
        Me.gbAlignDistace.Controls.Add(Me.numAlignRetry)
        Me.gbAlignDistace.Controls.Add(Me.numAlignErrorRange)
        Me.gbAlignDistace.Controls.Add(Me.btnAlignDistance)
        Me.gbAlignDistace.Controls.Add(Me.numAlignDistance)
        Me.gbAlignDistace.Controls.Add(Me.Label34)
        Me.gbAlignDistace.Controls.Add(Me.Label35)
        Me.gbAlignDistace.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbAlignDistace.Location = New System.Drawing.Point(122, 22)
        Me.gbAlignDistace.Name = "gbAlignDistace"
        Me.gbAlignDistace.Size = New System.Drawing.Size(559, 117)
        Me.gbAlignDistace.TabIndex = 703
        Me.gbAlignDistace.TabStop = False
        Me.gbAlignDistace.Text = "Align Setting [mm]"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(107, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 17)
        Me.Label5.TabIndex = 651
        Me.Label5.Text = "±"
        '
        'btnMatch
        '
        Me.btnMatch.FlatAppearance.BorderSize = 2
        Me.btnMatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMatch.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnMatch.Location = New System.Drawing.Point(291, 56)
        Me.btnMatch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnMatch.Name = "btnMatch"
        Me.btnMatch.Size = New System.Drawing.Size(64, 52)
        Me.btnMatch.TabIndex = 650
        Me.btnMatch.Text = "Match"
        Me.btnMatch.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(354, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 17)
        Me.Label4.TabIndex = 649
        Me.Label4.Text = "Panel Center Position"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(357, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 16)
        Me.Label2.TabIndex = 648
        Me.Label2.Text = "X :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(357, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 647
        Me.Label3.Text = "Y :"
        '
        'btnAlignCenterY
        '
        Me.btnAlignCenterY.FlatAppearance.BorderSize = 2
        Me.btnAlignCenterY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlignCenterY.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAlignCenterY.Location = New System.Drawing.Point(478, 76)
        Me.btnAlignCenterY.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAlignCenterY.Name = "btnAlignCenterY"
        Me.btnAlignCenterY.Size = New System.Drawing.Size(75, 32)
        Me.btnAlignCenterY.TabIndex = 646
        Me.btnAlignCenterY.Text = "Set"
        Me.btnAlignCenterY.UseVisualStyleBackColor = True
        '
        'btnAlignCenterX
        '
        Me.btnAlignCenterX.FlatAppearance.BorderSize = 2
        Me.btnAlignCenterX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlignCenterX.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAlignCenterX.Location = New System.Drawing.Point(478, 40)
        Me.btnAlignCenterX.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAlignCenterX.Name = "btnAlignCenterX"
        Me.btnAlignCenterX.Size = New System.Drawing.Size(75, 32)
        Me.btnAlignCenterX.TabIndex = 645
        Me.btnAlignCenterX.Text = "Set"
        Me.btnAlignCenterX.UseVisualStyleBackColor = True
        '
        'numAlignCenterY
        '
        Me.numAlignCenterY.DecimalPlaces = 3
        Me.numAlignCenterY.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numAlignCenterY.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numAlignCenterY.Location = New System.Drawing.Point(388, 76)
        Me.numAlignCenterY.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numAlignCenterY.Name = "numAlignCenterY"
        Me.numAlignCenterY.Size = New System.Drawing.Size(84, 25)
        Me.numAlignCenterY.TabIndex = 644
        Me.numAlignCenterY.TabStop = False
        Me.numAlignCenterY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numAlignCenterX
        '
        Me.numAlignCenterX.DecimalPlaces = 3
        Me.numAlignCenterX.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numAlignCenterX.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numAlignCenterX.Location = New System.Drawing.Point(388, 45)
        Me.numAlignCenterX.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numAlignCenterX.Name = "numAlignCenterX"
        Me.numAlignCenterX.Size = New System.Drawing.Size(84, 25)
        Me.numAlignCenterX.TabIndex = 643
        Me.numAlignCenterX.TabStop = False
        Me.numAlignCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 642
        Me.Label1.Text = "Retry:"
        '
        'btnAlignRetry
        '
        Me.btnAlignRetry.FlatAppearance.BorderSize = 2
        Me.btnAlignRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlignRetry.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAlignRetry.Location = New System.Drawing.Point(220, 20)
        Me.btnAlignRetry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAlignRetry.Name = "btnAlignRetry"
        Me.btnAlignRetry.Size = New System.Drawing.Size(70, 32)
        Me.btnAlignRetry.TabIndex = 640
        Me.btnAlignRetry.Text = "Set"
        Me.btnAlignRetry.UseVisualStyleBackColor = True
        '
        'numAlignRetry
        '
        Me.numAlignRetry.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numAlignRetry.Location = New System.Drawing.Point(130, 25)
        Me.numAlignRetry.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.numAlignRetry.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numAlignRetry.Name = "numAlignRetry"
        Me.numAlignRetry.Size = New System.Drawing.Size(84, 25)
        Me.numAlignRetry.TabIndex = 638
        Me.numAlignRetry.TabStop = False
        Me.numAlignRetry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numAlignRetry.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numAlignErrorRange
        '
        Me.numAlignErrorRange.DecimalPlaces = 3
        Me.numAlignErrorRange.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numAlignErrorRange.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numAlignErrorRange.Location = New System.Drawing.Point(130, 86)
        Me.numAlignErrorRange.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numAlignErrorRange.Name = "numAlignErrorRange"
        Me.numAlignErrorRange.Size = New System.Drawing.Size(84, 25)
        Me.numAlignErrorRange.TabIndex = 641
        Me.numAlignErrorRange.TabStop = False
        Me.numAlignErrorRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numAlignErrorRange.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnAlignDistance
        '
        Me.btnAlignDistance.FlatAppearance.BorderSize = 2
        Me.btnAlignDistance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlignDistance.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAlignDistance.Location = New System.Drawing.Point(220, 56)
        Me.btnAlignDistance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAlignDistance.Name = "btnAlignDistance"
        Me.btnAlignDistance.Size = New System.Drawing.Size(70, 52)
        Me.btnAlignDistance.TabIndex = 640
        Me.btnAlignDistance.Text = "Set"
        Me.btnAlignDistance.UseVisualStyleBackColor = True
        '
        'numAlignDistance
        '
        Me.numAlignDistance.DecimalPlaces = 3
        Me.numAlignDistance.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.numAlignDistance.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.numAlignDistance.Location = New System.Drawing.Point(130, 56)
        Me.numAlignDistance.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numAlignDistance.Name = "numAlignDistance"
        Me.numAlignDistance.Size = New System.Drawing.Size(84, 25)
        Me.numAlignDistance.TabIndex = 638
        Me.numAlignDistance.TabStop = False
        Me.numAlignDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numAlignDistance.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label34.Location = New System.Drawing.Point(12, 88)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(86, 17)
        Me.Label34.TabIndex = 260
        Me.Label34.Text = "Mark Offset:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label35.Location = New System.Drawing.Point(12, 59)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(101, 17)
        Me.Label35.TabIndex = 259
        Me.Label35.Text = "Mark Distance:"
        '
        'gbAlignLightSet
        '
        Me.gbAlignLightSet.Controls.Add(Me.btnAlignVisionParam)
        Me.gbAlignLightSet.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbAlignLightSet.Location = New System.Drawing.Point(8, 22)
        Me.gbAlignLightSet.Name = "gbAlignLightSet"
        Me.gbAlignLightSet.Size = New System.Drawing.Size(108, 117)
        Me.gbAlignLightSet.TabIndex = 641
        Me.gbAlignLightSet.TabStop = False
        Me.gbAlignLightSet.Text = "Light Setting"
        '
        'btnAlignVisionParam
        '
        Me.btnAlignVisionParam.FlatAppearance.BorderSize = 2
        Me.btnAlignVisionParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlignVisionParam.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAlignVisionParam.Location = New System.Drawing.Point(6, 18)
        Me.btnAlignVisionParam.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAlignVisionParam.Name = "btnAlignVisionParam"
        Me.btnAlignVisionParam.Size = New System.Drawing.Size(96, 90)
        Me.btnAlignVisionParam.TabIndex = 656
        Me.btnAlignVisionParam.Text = "Light Setting"
        Me.btnAlignVisionParam.UseVisualStyleBackColor = True
        '
        'ctrlRecipeAlign
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.gbAlign)
        Me.Name = "ctrlRecipeAlign"
        Me.Size = New System.Drawing.Size(707, 825)
        Me.gbAlign.ResumeLayout(False)
        Me.tabPanel.ResumeLayout(False)
        Me.gbAlignDistace.ResumeLayout(False)
        Me.gbAlignDistace.PerformLayout()
        CType(Me.numAlignCenterY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAlignCenterX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAlignRetry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAlignErrorRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAlignDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAlignLightSet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbAlign As System.Windows.Forms.GroupBox
    Friend WithEvents tabPanel As System.Windows.Forms.TabControl
    Friend WithEvents tabPagePanel2 As System.Windows.Forms.TabPage
    Friend WithEvents gbAlignDistace As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAlignRetry As System.Windows.Forms.Button
    Friend WithEvents numAlignRetry As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAlignErrorRange As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnAlignDistance As System.Windows.Forms.Button
    Friend WithEvents numAlignDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents gbAlignLightSet As System.Windows.Forms.GroupBox
    Friend WithEvents tabPagePanel1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePanel3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePanel4 As System.Windows.Forms.TabPage
    Friend WithEvents btnAlignVisionParam As System.Windows.Forms.Button
    Friend WithEvents numAlignCenterY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAlignCenterX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAlignCenterY As System.Windows.Forms.Button
    Friend WithEvents btnAlignCenterX As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnMatch As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
