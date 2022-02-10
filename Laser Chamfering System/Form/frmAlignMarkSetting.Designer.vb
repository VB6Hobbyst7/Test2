<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlignMarkSetting
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbMark = New System.Windows.Forms.PictureBox()
        Me.rbCenterPoint = New System.Windows.Forms.RadioButton()
        Me.rbMaskSetting = New System.Windows.Forms.RadioButton()
        Me.BtnSetting = New System.Windows.Forms.Button()
        Me.BtnCancle = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbMaskSize = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnZoom = New System.Windows.Forms.Button()
        Me.btnDetectCenter = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Masking = New System.Windows.Forms.RadioButton()
        Me.MaskingDel = New System.Windows.Forms.RadioButton()
        Me.MaskingSpeed = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkCenter = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pbMark, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 21)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "ALIGN MARK SETTING"
        '
        'pbMark
        '
        Me.pbMark.BackColor = System.Drawing.Color.Black
        Me.pbMark.Location = New System.Drawing.Point(17, 33)
        Me.pbMark.Name = "pbMark"
        Me.pbMark.Size = New System.Drawing.Size(350, 350)
        Me.pbMark.TabIndex = 7
        Me.pbMark.TabStop = False
        '
        'rbCenterPoint
        '
        Me.rbCenterPoint.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbCenterPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbCenterPoint.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rbCenterPoint.Location = New System.Drawing.Point(407, 33)
        Me.rbCenterPoint.Name = "rbCenterPoint"
        Me.rbCenterPoint.Size = New System.Drawing.Size(224, 45)
        Me.rbCenterPoint.TabIndex = 8
        Me.rbCenterPoint.TabStop = True
        Me.rbCenterPoint.Text = "Center Point Setting"
        Me.rbCenterPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbCenterPoint.UseVisualStyleBackColor = True
        '
        'rbMaskSetting
        '
        Me.rbMaskSetting.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbMaskSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbMaskSetting.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rbMaskSetting.Location = New System.Drawing.Point(407, 84)
        Me.rbMaskSetting.Name = "rbMaskSetting"
        Me.rbMaskSetting.Size = New System.Drawing.Size(224, 45)
        Me.rbMaskSetting.TabIndex = 9
        Me.rbMaskSetting.TabStop = True
        Me.rbMaskSetting.Text = "Mask Processing"
        Me.rbMaskSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbMaskSetting.UseVisualStyleBackColor = True
        '
        'BtnSetting
        '
        Me.BtnSetting.BackColor = System.Drawing.Color.Black
        Me.BtnSetting.Enabled = False
        Me.BtnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSetting.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnSetting.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSetting.Location = New System.Drawing.Point(374, 353)
        Me.BtnSetting.Name = "BtnSetting"
        Me.BtnSetting.Size = New System.Drawing.Size(120, 30)
        Me.BtnSetting.TabIndex = 10
        Me.BtnSetting.Text = "Save"
        Me.BtnSetting.UseVisualStyleBackColor = False
        '
        'BtnCancle
        '
        Me.BtnCancle.BackColor = System.Drawing.Color.Black
        Me.BtnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancle.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnCancle.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCancle.Location = New System.Drawing.Point(511, 353)
        Me.BtnCancle.Name = "BtnCancle"
        Me.BtnCancle.Size = New System.Drawing.Size(120, 30)
        Me.BtnCancle.TabIndex = 11
        Me.BtnCancle.Text = "Cancel"
        Me.BtnCancle.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(374, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 45)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "1."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(373, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 45)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "2."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbMaskSize
        '
        Me.cbMaskSize.FormattingEnabled = True
        Me.cbMaskSize.Items.AddRange(New Object() {"50", "40", "30", "25", "20", "15", "10", "5", "4", "3", "2", "1"})
        Me.cbMaskSize.Location = New System.Drawing.Point(407, 162)
        Me.cbMaskSize.Name = "cbMaskSize"
        Me.cbMaskSize.Size = New System.Drawing.Size(224, 24)
        Me.cbMaskSize.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Lime
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(407, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 24)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Mask Size Setting"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZoom
        '
        Me.btnZoom.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnZoom.Location = New System.Drawing.Point(247, 10)
        Me.btnZoom.Name = "btnZoom"
        Me.btnZoom.Size = New System.Drawing.Size(18, 23)
        Me.btnZoom.TabIndex = 16
        Me.btnZoom.Text = "Zoom"
        Me.btnZoom.UseVisualStyleBackColor = True
        Me.btnZoom.Visible = False
        '
        'btnDetectCenter
        '
        Me.btnDetectCenter.Location = New System.Drawing.Point(290, 10)
        Me.btnDetectCenter.Name = "btnDetectCenter"
        Me.btnDetectCenter.Size = New System.Drawing.Size(19, 22)
        Me.btnDetectCenter.TabIndex = 20
        Me.btnDetectCenter.Text = "Detect Center"
        Me.btnDetectCenter.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(192, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Masking
        '
        Me.Masking.AutoSize = True
        Me.Masking.Checked = True
        Me.Masking.Location = New System.Drawing.Point(387, 214)
        Me.Masking.Name = "Masking"
        Me.Masking.Size = New System.Drawing.Size(93, 20)
        Me.Masking.TabIndex = 22
        Me.Masking.TabStop = True
        Me.Masking.Text = "Masking"
        Me.Masking.UseVisualStyleBackColor = True
        '
        'MaskingDel
        '
        Me.MaskingDel.AutoSize = True
        Me.MaskingDel.Location = New System.Drawing.Point(504, 214)
        Me.MaskingDel.Name = "MaskingDel"
        Me.MaskingDel.Size = New System.Drawing.Size(124, 20)
        Me.MaskingDel.TabIndex = 23
        Me.MaskingDel.Text = "Masking Del"
        Me.MaskingDel.UseVisualStyleBackColor = True
        '
        'MaskingSpeed
        '
        Me.MaskingSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MaskingSpeed.FormattingEnabled = True
        Me.MaskingSpeed.Items.AddRange(New Object() {"1", "2", "3", "5"})
        Me.MaskingSpeed.Location = New System.Drawing.Point(504, 239)
        Me.MaskingSpeed.Name = "MaskingSpeed"
        Me.MaskingSpeed.Size = New System.Drawing.Size(121, 24)
        Me.MaskingSpeed.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(384, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "MouseSpeed:"
        '
        'chkCenter
        '
        '
        'frmAlignMarkSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(640, 390)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MaskingSpeed)
        Me.Controls.Add(Me.MaskingDel)
        Me.Controls.Add(Me.Masking)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDetectCenter)
        Me.Controls.Add(Me.btnZoom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbMaskSize)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnCancle)
        Me.Controls.Add(Me.BtnSetting)
        Me.Controls.Add(Me.rbMaskSetting)
        Me.Controls.Add(Me.rbCenterPoint)
        Me.Controls.Add(Me.pbMark)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("굴림", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmAlignMarkSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AlignMarkSetting"
        Me.TopMost = True
        CType(Me.pbMark, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbMark As System.Windows.Forms.PictureBox
    Friend WithEvents rbCenterPoint As System.Windows.Forms.RadioButton
    Friend WithEvents rbMaskSetting As System.Windows.Forms.RadioButton
    Friend WithEvents BtnSetting As System.Windows.Forms.Button
    Friend WithEvents BtnCancle As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbMaskSize As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnZoom As System.Windows.Forms.Button
    Friend WithEvents btnDetectCenter As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Masking As System.Windows.Forms.RadioButton
    Friend WithEvents MaskingDel As System.Windows.Forms.RadioButton
    Friend WithEvents MaskingSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkCenter As System.Windows.Forms.Timer
End Class
