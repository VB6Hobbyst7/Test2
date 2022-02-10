<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
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
        Me.lBoxLog = New System.Windows.Forms.ListBox()
        Me.gbLog = New System.Windows.Forms.GroupBox()
        Me.gbLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'lBoxLog
        '
        Me.lBoxLog.FormattingEnabled = True
        Me.lBoxLog.ItemHeight = 15
        Me.lBoxLog.Location = New System.Drawing.Point(5, 19)
        Me.lBoxLog.Name = "lBoxLog"
        Me.lBoxLog.Size = New System.Drawing.Size(1890, 64)
        Me.lBoxLog.TabIndex = 0
        '
        'gbLog
        '
        Me.gbLog.BackColor = System.Drawing.Color.White
        Me.gbLog.Controls.Add(Me.lBoxLog)
        Me.gbLog.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLog.Location = New System.Drawing.Point(5, 5)
        Me.gbLog.Name = "gbLog"
        Me.gbLog.Size = New System.Drawing.Size(1900, 95)
        Me.gbLog.TabIndex = 1
        Me.gbLog.TabStop = False
        Me.gbLog.Text = "System Log"
        '
        'frmLog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1910, 105)
        Me.Controls.Add(Me.gbLog)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmLog"
        Me.gbLog.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lBoxLog As System.Windows.Forms.ListBox
    Friend WithEvents gbLog As System.Windows.Forms.GroupBox
End Class
