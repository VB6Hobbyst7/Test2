<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlRecipeAlignMark
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
        Me.tabMarks = New System.Windows.Forms.TabControl()
        Me.tpMark1_1 = New System.Windows.Forms.TabPage()
        Me.tpMark1_2 = New System.Windows.Forms.TabPage()
        Me.tpMark1_3 = New System.Windows.Forms.TabPage()
        Me.tabMarks.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMarks
        '
        Me.tabMarks.Controls.Add(Me.tpMark1_1)
        Me.tabMarks.Controls.Add(Me.tpMark1_2)
        Me.tabMarks.Controls.Add(Me.tpMark1_3)
        Me.tabMarks.Location = New System.Drawing.Point(1, 3)
        Me.tabMarks.Name = "tabMarks"
        Me.tabMarks.SelectedIndex = 0
        Me.tabMarks.Size = New System.Drawing.Size(670, 588)
        Me.tabMarks.TabIndex = 1
        '
        'tpMark1_1
        '
        Me.tpMark1_1.Location = New System.Drawing.Point(4, 22)
        Me.tpMark1_1.Name = "tpMark1_1"
        Me.tpMark1_1.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMark1_1.Size = New System.Drawing.Size(662, 562)
        Me.tpMark1_1.TabIndex = 0
        Me.tpMark1_1.Text = "Mark #1"
        Me.tpMark1_1.UseVisualStyleBackColor = True
        '
        'tpMark1_2
        '
        Me.tpMark1_2.Location = New System.Drawing.Point(4, 22)
        Me.tpMark1_2.Name = "tpMark1_2"
        Me.tpMark1_2.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMark1_2.Size = New System.Drawing.Size(662, 562)
        Me.tpMark1_2.TabIndex = 1
        Me.tpMark1_2.Text = "#2"
        Me.tpMark1_2.UseVisualStyleBackColor = True
        '
        'tpMark1_3
        '
        Me.tpMark1_3.Location = New System.Drawing.Point(4, 22)
        Me.tpMark1_3.Name = "tpMark1_3"
        Me.tpMark1_3.Size = New System.Drawing.Size(662, 562)
        Me.tpMark1_3.TabIndex = 2
        Me.tpMark1_3.Text = "#3"
        Me.tpMark1_3.UseVisualStyleBackColor = True
        '
        'ctrlRecipeAlignMark
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tabMarks)
        Me.Name = "ctrlRecipeAlignMark"
        Me.Size = New System.Drawing.Size(672, 594)
        Me.tabMarks.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMarks As System.Windows.Forms.TabControl
    Friend WithEvents tpMark1_1 As System.Windows.Forms.TabPage
    Friend WithEvents tpMark1_2 As System.Windows.Forms.TabPage
    Friend WithEvents tpMark1_3 As System.Windows.Forms.TabPage

End Class
