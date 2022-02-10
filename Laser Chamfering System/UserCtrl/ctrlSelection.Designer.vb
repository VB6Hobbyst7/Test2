<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSelection
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
        Me.rdoSel4 = New System.Windows.Forms.RadioButton()
        Me.rdoSel3 = New System.Windows.Forms.RadioButton()
        Me.rdoSel2 = New System.Windows.Forms.RadioButton()
        Me.rdoSel1 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'rdoSel4
        '
        Me.rdoSel4.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoSel4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoSel4.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdoSel4.Location = New System.Drawing.Point(535, 5)
        Me.rdoSel4.Name = "rdoSel4"
        Me.rdoSel4.Size = New System.Drawing.Size(165, 40)
        Me.rdoSel4.TabIndex = 350
        Me.rdoSel4.Text = "#4"
        Me.rdoSel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoSel4.UseVisualStyleBackColor = True
        '
        'rdoSel3
        '
        Me.rdoSel3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoSel3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoSel3.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdoSel3.Location = New System.Drawing.Point(359, 5)
        Me.rdoSel3.Name = "rdoSel3"
        Me.rdoSel3.Size = New System.Drawing.Size(165, 40)
        Me.rdoSel3.TabIndex = 349
        Me.rdoSel3.Text = "#3"
        Me.rdoSel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoSel3.UseVisualStyleBackColor = True
        '
        'rdoSel2
        '
        Me.rdoSel2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoSel2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoSel2.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdoSel2.Location = New System.Drawing.Point(183, 5)
        Me.rdoSel2.Name = "rdoSel2"
        Me.rdoSel2.Size = New System.Drawing.Size(165, 40)
        Me.rdoSel2.TabIndex = 348
        Me.rdoSel2.Text = "#2"
        Me.rdoSel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoSel2.UseVisualStyleBackColor = True
        '
        'rdoSel1
        '
        Me.rdoSel1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rdoSel1.Checked = True
        Me.rdoSel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoSel1.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.rdoSel1.Location = New System.Drawing.Point(7, 5)
        Me.rdoSel1.Name = "rdoSel1"
        Me.rdoSel1.Size = New System.Drawing.Size(165, 40)
        Me.rdoSel1.TabIndex = 347
        Me.rdoSel1.TabStop = True
        Me.rdoSel1.Text = "#1"
        Me.rdoSel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdoSel1.UseVisualStyleBackColor = True
        '
        'ctrlSelection
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.rdoSel4)
        Me.Controls.Add(Me.rdoSel3)
        Me.Controls.Add(Me.rdoSel2)
        Me.Controls.Add(Me.rdoSel1)
        Me.Name = "ctrlSelection"
        Me.Size = New System.Drawing.Size(708, 50)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdoSel4 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSel3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSel2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSel1 As System.Windows.Forms.RadioButton

End Class
