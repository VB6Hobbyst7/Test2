<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSeqVision
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
        Me.gbAlignGls = New System.Windows.Forms.GroupBox()
        Me.lblMark1Cnt = New System.Windows.Forms.Label()
        Me.lblMark2Cnt = New System.Windows.Forms.Label()
        Me.lblDiffPosX_Mark2 = New System.Windows.Forms.Label()
        Me.lblDiffPosY_Mark2 = New System.Windows.Forms.Label()
        Me.lblOK_Mark2 = New System.Windows.Forms.Label()
        Me.lblScoreMark2 = New System.Windows.Forms.Label()
        Me.picMark2 = New System.Windows.Forms.PictureBox()
        Me.lblDiffPosX_Mark1 = New System.Windows.Forms.Label()
        Me.lblDiffPosY_Mark1 = New System.Windows.Forms.Label()
        Me.lblOK_Mark1 = New System.Windows.Forms.Label()
        Me.lblScoreMark1 = New System.Windows.Forms.Label()
        Me.picMark1 = New System.Windows.Forms.PictureBox()
        Me.lblDistance = New System.Windows.Forms.Label()
        Me.gbAlignGls.SuspendLayout()
        CType(Me.picMark2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMark1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbAlignGls
        '
        Me.gbAlignGls.Controls.Add(Me.lblDistance)
        Me.gbAlignGls.Controls.Add(Me.lblMark1Cnt)
        Me.gbAlignGls.Controls.Add(Me.lblMark2Cnt)
        Me.gbAlignGls.Controls.Add(Me.lblDiffPosX_Mark2)
        Me.gbAlignGls.Controls.Add(Me.lblDiffPosY_Mark2)
        Me.gbAlignGls.Controls.Add(Me.lblOK_Mark2)
        Me.gbAlignGls.Controls.Add(Me.lblScoreMark2)
        Me.gbAlignGls.Controls.Add(Me.picMark2)
        Me.gbAlignGls.Controls.Add(Me.lblDiffPosX_Mark1)
        Me.gbAlignGls.Controls.Add(Me.lblDiffPosY_Mark1)
        Me.gbAlignGls.Controls.Add(Me.lblOK_Mark1)
        Me.gbAlignGls.Controls.Add(Me.lblScoreMark1)
        Me.gbAlignGls.Controls.Add(Me.picMark1)
        Me.gbAlignGls.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbAlignGls.Location = New System.Drawing.Point(3, -3)
        Me.gbAlignGls.Name = "gbAlignGls"
        Me.gbAlignGls.Size = New System.Drawing.Size(335, 207)
        Me.gbAlignGls.TabIndex = 79
        Me.gbAlignGls.TabStop = False
        Me.gbAlignGls.Text = "Glass 1"
        '
        'lblMark1Cnt
        '
        Me.lblMark1Cnt.AutoSize = True
        Me.lblMark1Cnt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblMark1Cnt.ForeColor = System.Drawing.Color.Lime
        Me.lblMark1Cnt.Location = New System.Drawing.Point(146, 21)
        Me.lblMark1Cnt.Name = "lblMark1Cnt"
        Me.lblMark1Cnt.Size = New System.Drawing.Size(12, 15)
        Me.lblMark1Cnt.TabIndex = 54
        Me.lblMark1Cnt.Text = "-"
        Me.lblMark1Cnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMark2Cnt
        '
        Me.lblMark2Cnt.AutoSize = True
        Me.lblMark2Cnt.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblMark2Cnt.ForeColor = System.Drawing.Color.Lime
        Me.lblMark2Cnt.Location = New System.Drawing.Point(310, 22)
        Me.lblMark2Cnt.Name = "lblMark2Cnt"
        Me.lblMark2Cnt.Size = New System.Drawing.Size(12, 15)
        Me.lblMark2Cnt.TabIndex = 54
        Me.lblMark2Cnt.Text = "-"
        Me.lblMark2Cnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiffPosX_Mark2
        '
        Me.lblDiffPosX_Mark2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDiffPosX_Mark2.Location = New System.Drawing.Point(171, 166)
        Me.lblDiffPosX_Mark2.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDiffPosX_Mark2.Name = "lblDiffPosX_Mark2"
        Me.lblDiffPosX_Mark2.Size = New System.Drawing.Size(79, 16)
        Me.lblDiffPosX_Mark2.TabIndex = 53
        Me.lblDiffPosX_Mark2.Text = "X : 000.000"
        Me.lblDiffPosX_Mark2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiffPosY_Mark2
        '
        Me.lblDiffPosY_Mark2.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDiffPosY_Mark2.Location = New System.Drawing.Point(249, 166)
        Me.lblDiffPosY_Mark2.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDiffPosY_Mark2.Name = "lblDiffPosY_Mark2"
        Me.lblDiffPosY_Mark2.Size = New System.Drawing.Size(79, 16)
        Me.lblDiffPosY_Mark2.TabIndex = 52
        Me.lblDiffPosY_Mark2.Text = "Y : 000.000"
        Me.lblDiffPosY_Mark2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOK_Mark2
        '
        Me.lblOK_Mark2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOK_Mark2.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblOK_Mark2.ForeColor = System.Drawing.Color.Lime
        Me.lblOK_Mark2.Location = New System.Drawing.Point(278, 137)
        Me.lblOK_Mark2.Name = "lblOK_Mark2"
        Me.lblOK_Mark2.Size = New System.Drawing.Size(50, 25)
        Me.lblOK_Mark2.TabIndex = 51
        Me.lblOK_Mark2.Text = "OK"
        Me.lblOK_Mark2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblScoreMark2
        '
        Me.lblScoreMark2.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblScoreMark2.Location = New System.Drawing.Point(171, 142)
        Me.lblScoreMark2.Name = "lblScoreMark2"
        Me.lblScoreMark2.Size = New System.Drawing.Size(100, 15)
        Me.lblScoreMark2.TabIndex = 50
        Me.lblScoreMark2.Text = "Score : 00.000"
        '
        'picMark2
        '
        Me.picMark2.BackColor = System.Drawing.Color.Black
        Me.picMark2.Location = New System.Drawing.Point(171, 18)
        Me.picMark2.Name = "picMark2"
        Me.picMark2.Size = New System.Drawing.Size(157, 116)
        Me.picMark2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMark2.TabIndex = 49
        Me.picMark2.TabStop = False
        '
        'lblDiffPosX_Mark1
        '
        Me.lblDiffPosX_Mark1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDiffPosX_Mark1.Location = New System.Drawing.Point(7, 166)
        Me.lblDiffPosX_Mark1.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDiffPosX_Mark1.Name = "lblDiffPosX_Mark1"
        Me.lblDiffPosX_Mark1.Size = New System.Drawing.Size(79, 16)
        Me.lblDiffPosX_Mark1.TabIndex = 42
        Me.lblDiffPosX_Mark1.Text = "X : 000.000"
        Me.lblDiffPosX_Mark1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDiffPosY_Mark1
        '
        Me.lblDiffPosY_Mark1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDiffPosY_Mark1.Location = New System.Drawing.Point(85, 166)
        Me.lblDiffPosY_Mark1.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDiffPosY_Mark1.Name = "lblDiffPosY_Mark1"
        Me.lblDiffPosY_Mark1.Size = New System.Drawing.Size(79, 16)
        Me.lblDiffPosY_Mark1.TabIndex = 41
        Me.lblDiffPosY_Mark1.Text = "Y : 000.000"
        Me.lblDiffPosY_Mark1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOK_Mark1
        '
        Me.lblOK_Mark1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOK_Mark1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblOK_Mark1.ForeColor = System.Drawing.Color.Lime
        Me.lblOK_Mark1.Location = New System.Drawing.Point(114, 137)
        Me.lblOK_Mark1.Name = "lblOK_Mark1"
        Me.lblOK_Mark1.Size = New System.Drawing.Size(50, 25)
        Me.lblOK_Mark1.TabIndex = 38
        Me.lblOK_Mark1.Text = "OK"
        Me.lblOK_Mark1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblScoreMark1
        '
        Me.lblScoreMark1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblScoreMark1.Location = New System.Drawing.Point(7, 142)
        Me.lblScoreMark1.Name = "lblScoreMark1"
        Me.lblScoreMark1.Size = New System.Drawing.Size(100, 15)
        Me.lblScoreMark1.TabIndex = 32
        Me.lblScoreMark1.Text = "Score : 00.000"
        '
        'picMark1
        '
        Me.picMark1.BackColor = System.Drawing.Color.Black
        Me.picMark1.Location = New System.Drawing.Point(7, 18)
        Me.picMark1.Name = "picMark1"
        Me.picMark1.Size = New System.Drawing.Size(157, 116)
        Me.picMark1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMark1.TabIndex = 1
        Me.picMark1.TabStop = False
        '
        'lblDistance
        '
        Me.lblDistance.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblDistance.Location = New System.Drawing.Point(174, 186)
        Me.lblDistance.Margin = New System.Windows.Forms.Padding(2)
        Me.lblDistance.Name = "lblDistance"
        Me.lblDistance.Size = New System.Drawing.Size(148, 16)
        Me.lblDistance.TabIndex = 55
        Me.lblDistance.Text = "Distance : 000.000"
        Me.lblDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctrlSeqVision
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.gbAlignGls)
        Me.Name = "ctrlSeqVision"
        Me.Size = New System.Drawing.Size(340, 205)
        Me.gbAlignGls.ResumeLayout(False)
        Me.gbAlignGls.PerformLayout()
        CType(Me.picMark2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMark1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbAlignGls As System.Windows.Forms.GroupBox
    Friend WithEvents lblDiffPosX_Mark1 As System.Windows.Forms.Label
    Friend WithEvents lblDiffPosY_Mark1 As System.Windows.Forms.Label
    Friend WithEvents lblOK_Mark1 As System.Windows.Forms.Label
    Friend WithEvents lblScoreMark1 As System.Windows.Forms.Label
    Friend WithEvents picMark1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblDiffPosX_Mark2 As System.Windows.Forms.Label
    Friend WithEvents lblDiffPosY_Mark2 As System.Windows.Forms.Label
    Friend WithEvents lblOK_Mark2 As System.Windows.Forms.Label
    Friend WithEvents lblScoreMark2 As System.Windows.Forms.Label
    Friend WithEvents picMark2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMark1Cnt As System.Windows.Forms.Label
    Friend WithEvents lblMark2Cnt As System.Windows.Forms.Label
    Friend WithEvents lblDistance As System.Windows.Forms.Label

End Class
