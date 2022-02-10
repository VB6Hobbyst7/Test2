<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetting
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
        Me.gbSettingChoice = New System.Windows.Forms.GroupBox()
        Me.btnIO = New System.Windows.Forms.Button()
        Me.btnDisplace = New System.Windows.Forms.Button()
        Me.btnPLC = New System.Windows.Forms.Button()
        Me.BtnLaserIO = New System.Windows.Forms.Button()
        Me.btnSystemParam = New System.Windows.Forms.Button()
        Me.gbScanner = New System.Windows.Forms.GroupBox()
        Me.RdoScanner4 = New System.Windows.Forms.RadioButton()
        Me.RdoScanner3 = New System.Windows.Forms.RadioButton()
        Me.RdoScanner2 = New System.Windows.Forms.RadioButton()
        Me.RdoScanner1 = New System.Windows.Forms.RadioButton()
        Me.btnCal = New System.Windows.Forms.Button()
        Me.btnScanner = New System.Windows.Forms.Button()
        Me.btnLaser = New System.Windows.Forms.Button()
        Me.tmSetting = New System.Windows.Forms.Timer(Me.components)
        Me.gbSettingChoice.SuspendLayout()
        Me.gbScanner.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbSettingChoice
        '
        Me.gbSettingChoice.Controls.Add(Me.btnIO)
        Me.gbSettingChoice.Controls.Add(Me.btnDisplace)
        Me.gbSettingChoice.Controls.Add(Me.btnPLC)
        Me.gbSettingChoice.Controls.Add(Me.BtnLaserIO)
        Me.gbSettingChoice.Controls.Add(Me.btnSystemParam)
        Me.gbSettingChoice.Controls.Add(Me.gbScanner)
        Me.gbSettingChoice.Controls.Add(Me.btnCal)
        Me.gbSettingChoice.Controls.Add(Me.btnScanner)
        Me.gbSettingChoice.Controls.Add(Me.btnLaser)
        Me.gbSettingChoice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSettingChoice.Location = New System.Drawing.Point(5, 7)
        Me.gbSettingChoice.Name = "gbSettingChoice"
        Me.gbSettingChoice.Size = New System.Drawing.Size(698, 60)
        Me.gbSettingChoice.TabIndex = 344
        Me.gbSettingChoice.TabStop = False
        Me.gbSettingChoice.Text = "Setting Choice"
        '
        'btnIO
        '
        Me.btnIO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIO.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIO.ImageIndex = 0
        Me.btnIO.Location = New System.Drawing.Point(683, 20)
        Me.btnIO.Name = "btnIO"
        Me.btnIO.Size = New System.Drawing.Size(10, 34)
        Me.btnIO.TabIndex = 351
        Me.btnIO.Tag = "4"
        Me.btnIO.Text = "I/O"
        Me.btnIO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIO.UseVisualStyleBackColor = True
        Me.btnIO.Visible = False
        '
        'btnDisplace
        '
        Me.btnDisplace.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDisplace.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisplace.ImageIndex = 0
        Me.btnDisplace.Location = New System.Drawing.Point(446, 20)
        Me.btnDisplace.Name = "btnDisplace"
        Me.btnDisplace.Size = New System.Drawing.Size(110, 34)
        Me.btnDisplace.TabIndex = 349
        Me.btnDisplace.Tag = "5"
        Me.btnDisplace.Text = "Displace"
        Me.btnDisplace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDisplace.UseVisualStyleBackColor = True
        '
        'btnPLC
        '
        Me.btnPLC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPLC.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPLC.ImageIndex = 0
        Me.btnPLC.Location = New System.Drawing.Point(556, 20)
        Me.btnPLC.Name = "btnPLC"
        Me.btnPLC.Size = New System.Drawing.Size(110, 34)
        Me.btnPLC.TabIndex = 162
        Me.btnPLC.Tag = "4"
        Me.btnPLC.Text = "PLC"
        Me.btnPLC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPLC.UseVisualStyleBackColor = True
        '
        'BtnLaserIO
        '
        Me.BtnLaserIO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnLaserIO.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLaserIO.ImageIndex = 0
        Me.BtnLaserIO.Location = New System.Drawing.Point(670, 20)
        Me.BtnLaserIO.Name = "BtnLaserIO"
        Me.BtnLaserIO.Size = New System.Drawing.Size(10, 34)
        Me.BtnLaserIO.TabIndex = 350
        Me.BtnLaserIO.Tag = "6"
        Me.BtnLaserIO.Text = "LaserI/O"
        Me.BtnLaserIO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnLaserIO.UseVisualStyleBackColor = True
        Me.BtnLaserIO.Visible = False
        '
        'btnSystemParam
        '
        Me.btnSystemParam.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSystemParam.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSystemParam.ImageIndex = 0
        Me.btnSystemParam.Location = New System.Drawing.Point(6, 20)
        Me.btnSystemParam.Name = "btnSystemParam"
        Me.btnSystemParam.Size = New System.Drawing.Size(110, 34)
        Me.btnSystemParam.TabIndex = 161
        Me.btnSystemParam.Tag = "0"
        Me.btnSystemParam.Text = "System Param"
        Me.btnSystemParam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSystemParam.UseVisualStyleBackColor = True
        '
        'gbScanner
        '
        Me.gbScanner.Controls.Add(Me.RdoScanner4)
        Me.gbScanner.Controls.Add(Me.RdoScanner3)
        Me.gbScanner.Controls.Add(Me.RdoScanner2)
        Me.gbScanner.Controls.Add(Me.RdoScanner1)
        Me.gbScanner.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbScanner.Location = New System.Drawing.Point(670, 60)
        Me.gbScanner.Name = "gbScanner"
        Me.gbScanner.Size = New System.Drawing.Size(698, 824)
        Me.gbScanner.TabIndex = 348
        Me.gbScanner.TabStop = False
        Me.gbScanner.Text = "Scanner"
        '
        'RdoScanner4
        '
        Me.RdoScanner4.AutoSize = True
        Me.RdoScanner4.Location = New System.Drawing.Point(506, 13)
        Me.RdoScanner4.Name = "RdoScanner4"
        Me.RdoScanner4.Size = New System.Drawing.Size(113, 23)
        Me.RdoScanner4.TabIndex = 327
        Me.RdoScanner4.TabStop = True
        Me.RdoScanner4.Text = "Scanner #4"
        Me.RdoScanner4.UseVisualStyleBackColor = True
        '
        'RdoScanner3
        '
        Me.RdoScanner3.AutoSize = True
        Me.RdoScanner3.Location = New System.Drawing.Point(365, 13)
        Me.RdoScanner3.Name = "RdoScanner3"
        Me.RdoScanner3.Size = New System.Drawing.Size(113, 23)
        Me.RdoScanner3.TabIndex = 326
        Me.RdoScanner3.TabStop = True
        Me.RdoScanner3.Text = "Scanner #3"
        Me.RdoScanner3.UseVisualStyleBackColor = True
        '
        'RdoScanner2
        '
        Me.RdoScanner2.AutoSize = True
        Me.RdoScanner2.Location = New System.Drawing.Point(224, 13)
        Me.RdoScanner2.Name = "RdoScanner2"
        Me.RdoScanner2.Size = New System.Drawing.Size(113, 23)
        Me.RdoScanner2.TabIndex = 325
        Me.RdoScanner2.TabStop = True
        Me.RdoScanner2.Text = "Scanner #2"
        Me.RdoScanner2.UseVisualStyleBackColor = True
        '
        'RdoScanner1
        '
        Me.RdoScanner1.AutoSize = True
        Me.RdoScanner1.Location = New System.Drawing.Point(83, 13)
        Me.RdoScanner1.Name = "RdoScanner1"
        Me.RdoScanner1.Size = New System.Drawing.Size(113, 23)
        Me.RdoScanner1.TabIndex = 324
        Me.RdoScanner1.TabStop = True
        Me.RdoScanner1.Text = "Scanner #1"
        Me.RdoScanner1.UseVisualStyleBackColor = True
        '
        'btnCal
        '
        Me.btnCal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCal.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCal.ImageIndex = 0
        Me.btnCal.Location = New System.Drawing.Point(336, 20)
        Me.btnCal.Name = "btnCal"
        Me.btnCal.Size = New System.Drawing.Size(110, 34)
        Me.btnCal.TabIndex = 160
        Me.btnCal.Tag = "3"
        Me.btnCal.Text = "Calibration"
        Me.btnCal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCal.UseVisualStyleBackColor = True
        '
        'btnScanner
        '
        Me.btnScanner.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScanner.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanner.ImageIndex = 0
        Me.btnScanner.Location = New System.Drawing.Point(226, 20)
        Me.btnScanner.Name = "btnScanner"
        Me.btnScanner.Size = New System.Drawing.Size(110, 34)
        Me.btnScanner.TabIndex = 159
        Me.btnScanner.Tag = "2"
        Me.btnScanner.Text = "Scanner"
        Me.btnScanner.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnScanner.UseVisualStyleBackColor = True
        '
        'btnLaser
        '
        Me.btnLaser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLaser.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaser.ImageIndex = 0
        Me.btnLaser.Location = New System.Drawing.Point(116, 20)
        Me.btnLaser.Name = "btnLaser"
        Me.btnLaser.Size = New System.Drawing.Size(110, 34)
        Me.btnLaser.TabIndex = 158
        Me.btnLaser.Tag = "1"
        Me.btnLaser.Text = "Laser"
        Me.btnLaser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLaser.UseVisualStyleBackColor = True
        '
        'tmSetting
        '
        '
        'frmSetting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(708, 914)
        Me.Controls.Add(Me.gbSettingChoice)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmSetting"
        Me.gbSettingChoice.ResumeLayout(False)
        Me.gbScanner.ResumeLayout(False)
        Me.gbScanner.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbSettingChoice As System.Windows.Forms.GroupBox
    Friend WithEvents btnPLC As System.Windows.Forms.Button
    Friend WithEvents btnSystemParam As System.Windows.Forms.Button
    Friend WithEvents btnCal As System.Windows.Forms.Button
    Friend WithEvents btnScanner As System.Windows.Forms.Button
    Friend WithEvents btnLaser As System.Windows.Forms.Button
    Friend WithEvents gbScanner As System.Windows.Forms.GroupBox
    Friend WithEvents tmSetting As System.Windows.Forms.Timer
    Friend WithEvents RdoScanner4 As System.Windows.Forms.RadioButton
    Friend WithEvents RdoScanner3 As System.Windows.Forms.RadioButton
    Friend WithEvents RdoScanner2 As System.Windows.Forms.RadioButton
    Friend WithEvents RdoScanner1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnDisplace As System.Windows.Forms.Button
    Friend WithEvents BtnLaserIO As System.Windows.Forms.Button
    Friend WithEvents btnIO As System.Windows.Forms.Button
End Class
