<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeqVision
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
        Me.tmrScannerTac = New System.Windows.Forms.Timer(Me.components)
        Me.gbLineA = New System.Windows.Forms.GroupBox()
        Me.gbLineB = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'tmrScannerTac
        '
        Me.tmrScannerTac.Interval = 50
        '
        'gbLineA
        '
        Me.gbLineA.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLineA.Location = New System.Drawing.Point(4, 2)
        Me.gbLineA.Name = "gbLineA"
        Me.gbLineA.Size = New System.Drawing.Size(684, 440)
        Me.gbLineA.TabIndex = 87
        Me.gbLineA.TabStop = False
        Me.gbLineA.Text = "LINE A"
        '
        'gbLineB
        '
        Me.gbLineB.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLineB.Location = New System.Drawing.Point(4, 452)
        Me.gbLineB.Name = "gbLineB"
        Me.gbLineB.Size = New System.Drawing.Size(684, 440)
        Me.gbLineB.TabIndex = 88
        Me.gbLineB.TabStop = False
        Me.gbLineB.Text = "LINE B"
        '
        'frmSeqVision
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(690, 914)
        Me.Controls.Add(Me.gbLineB)
        Me.Controls.Add(Me.gbLineA)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSeqVision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmSeqVision"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrScannerTac As System.Windows.Forms.Timer
    Friend WithEvents gbLineA As System.Windows.Forms.GroupBox
    Friend WithEvents gbLineB As System.Windows.Forms.GroupBox
End Class
