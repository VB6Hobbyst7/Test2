<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Panel_Display = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btMarkFind1 = New System.Windows.Forms.Button()
        Me.btMarkFind2 = New System.Windows.Forms.Button()
        Me.Panel_Display2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextAlignX1 = New System.Windows.Forms.TextBox()
        Me.TextAlignY1 = New System.Windows.Forms.TextBox()
        Me.TextAlignT1 = New System.Windows.Forms.TextBox()
        Me.TextAlignScore1 = New System.Windows.Forms.TextBox()
        Me.TextAlignScore2 = New System.Windows.Forms.TextBox()
        Me.TextAlignT2 = New System.Windows.Forms.TextBox()
        Me.TextAlignY2 = New System.Windows.Forms.TextBox()
        Me.TextAlignX2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Panel_Display
        '
        Me.Panel_Display.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel_Display.Location = New System.Drawing.Point(15, 36)
        Me.Panel_Display.Name = "Panel_Display"
        Me.Panel_Display.Size = New System.Drawing.Size(573, 471)
        Me.Panel_Display.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 513)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 33)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Img Load 1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(495, 513)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Camera1 Init"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btMarkFind1
        '
        Me.btMarkFind1.Location = New System.Drawing.Point(114, 513)
        Me.btMarkFind1.Name = "btMarkFind1"
        Me.btMarkFind1.Size = New System.Drawing.Size(93, 33)
        Me.btMarkFind1.TabIndex = 3
        Me.btMarkFind1.Text = "Mark Find 1"
        Me.btMarkFind1.UseVisualStyleBackColor = True
        '
        'btMarkFind2
        '
        Me.btMarkFind2.Location = New System.Drawing.Point(707, 513)
        Me.btMarkFind2.Name = "btMarkFind2"
        Me.btMarkFind2.Size = New System.Drawing.Size(93, 33)
        Me.btMarkFind2.TabIndex = 4
        Me.btMarkFind2.Text = "Mark Find 2"
        Me.btMarkFind2.UseVisualStyleBackColor = True
        '
        'Panel_Display2
        '
        Me.Panel_Display2.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel_Display2.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Panel_Display2.Location = New System.Drawing.Point(608, 36)
        Me.Panel_Display2.Name = "Panel_Display2"
        Me.Panel_Display2.Size = New System.Drawing.Size(573, 471)
        Me.Panel_Display2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(575, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Camera 1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(606, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(575, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Camera 2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(608, 513)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(93, 33)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Img Load 2"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 555)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Align X1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 584)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 12)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Align Y1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 612)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Align T1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 636)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Align Score"
        '
        'TextAlignX1
        '
        Me.TextAlignX1.Location = New System.Drawing.Point(114, 552)
        Me.TextAlignX1.Name = "TextAlignX1"
        Me.TextAlignX1.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignX1.TabIndex = 16
        '
        'TextAlignY1
        '
        Me.TextAlignY1.Location = New System.Drawing.Point(114, 581)
        Me.TextAlignY1.Name = "TextAlignY1"
        Me.TextAlignY1.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignY1.TabIndex = 17
        '
        'TextAlignT1
        '
        Me.TextAlignT1.Location = New System.Drawing.Point(114, 609)
        Me.TextAlignT1.Name = "TextAlignT1"
        Me.TextAlignT1.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignT1.TabIndex = 18
        '
        'TextAlignScore1
        '
        Me.TextAlignScore1.Location = New System.Drawing.Point(114, 636)
        Me.TextAlignScore1.Name = "TextAlignScore1"
        Me.TextAlignScore1.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignScore1.TabIndex = 19
        '
        'TextAlignScore2
        '
        Me.TextAlignScore2.Location = New System.Drawing.Point(701, 636)
        Me.TextAlignScore2.Name = "TextAlignScore2"
        Me.TextAlignScore2.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignScore2.TabIndex = 27
        '
        'TextAlignT2
        '
        Me.TextAlignT2.Location = New System.Drawing.Point(701, 609)
        Me.TextAlignT2.Name = "TextAlignT2"
        Me.TextAlignT2.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignT2.TabIndex = 26
        '
        'TextAlignY2
        '
        Me.TextAlignY2.Location = New System.Drawing.Point(701, 581)
        Me.TextAlignY2.Name = "TextAlignY2"
        Me.TextAlignY2.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignY2.TabIndex = 25
        '
        'TextAlignX2
        '
        Me.TextAlignX2.Location = New System.Drawing.Point(701, 552)
        Me.TextAlignX2.Name = "TextAlignX2"
        Me.TextAlignX2.Size = New System.Drawing.Size(100, 21)
        Me.TextAlignX2.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(606, 636)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 12)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Align Score"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(606, 612)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 12)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Align T1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(606, 584)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 12)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Align Y1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(606, 555)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 12)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Align X1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 662)
        Me.Controls.Add(Me.TextAlignScore2)
        Me.Controls.Add(Me.TextAlignT2)
        Me.Controls.Add(Me.TextAlignY2)
        Me.Controls.Add(Me.TextAlignX2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextAlignScore1)
        Me.Controls.Add(Me.TextAlignT1)
        Me.Controls.Add(Me.TextAlignY1)
        Me.Controls.Add(Me.TextAlignX1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel_Display2)
        Me.Controls.Add(Me.btMarkFind2)
        Me.Controls.Add(Me.btMarkFind1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel_Display)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Panel_Display As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btMarkFind1 As System.Windows.Forms.Button
    Friend WithEvents btMarkFind2 As System.Windows.Forms.Button
    Private WithEvents Panel_Display2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextAlignX1 As System.Windows.Forms.TextBox
    Friend WithEvents TextAlignY1 As System.Windows.Forms.TextBox
    Friend WithEvents TextAlignT1 As System.Windows.Forms.TextBox
    Friend WithEvents TextAlignScore1 As System.Windows.Forms.TextBox
    Friend WithEvents TextAlignScore2 As System.Windows.Forms.TextBox
    Friend WithEvents TextAlignT2 As System.Windows.Forms.TextBox
    Friend WithEvents TextAlignY2 As System.Windows.Forms.TextBox
    Friend WithEvents TextAlignX2 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
