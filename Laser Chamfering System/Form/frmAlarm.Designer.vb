<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlarm
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
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.dgvAlarmData = New System.Windows.Forms.DataGridView()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlarmCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlarmName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlarmDescript = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlarmType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimerAlarm = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvAlarmData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Lime
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(419, 335)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(189, 38)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "Clear Alarm && Close"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Blue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("맑은 고딕", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(612, 31)
        Me.lblTitle.TabIndex = 11
        Me.lblTitle.Text = "Alarm"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvAlarmData
        '
        Me.dgvAlarmData.AllowUserToAddRows = False
        Me.dgvAlarmData.AllowUserToDeleteRows = False
        Me.dgvAlarmData.AllowUserToResizeColumns = False
        Me.dgvAlarmData.AllowUserToResizeRows = False
        Me.dgvAlarmData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvAlarmData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAlarmData.BackgroundColor = System.Drawing.Color.White
        Me.dgvAlarmData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlarmData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Index, Me.AlarmCode, Me.AlarmName, Me.AlarmDescript, Me.AlarmType})
        Me.dgvAlarmData.Location = New System.Drawing.Point(5, 36)
        Me.dgvAlarmData.Name = "dgvAlarmData"
        Me.dgvAlarmData.ReadOnly = True
        Me.dgvAlarmData.RowHeadersVisible = False
        Me.dgvAlarmData.RowTemplate.Height = 23
        Me.dgvAlarmData.Size = New System.Drawing.Size(603, 295)
        Me.dgvAlarmData.TabIndex = 18
        '
        'Index
        '
        DataGridViewCellStyle26.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Index.DefaultCellStyle = DataGridViewCellStyle26
        Me.Index.HeaderText = "Idx"
        Me.Index.Name = "Index"
        Me.Index.ReadOnly = True
        Me.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Index.Width = 28
        '
        'AlarmCode
        '
        DataGridViewCellStyle27.NullValue = "000.000"
        Me.AlarmCode.DefaultCellStyle = DataGridViewCellStyle27
        Me.AlarmCode.HeaderText = "AlarmCode"
        Me.AlarmCode.Name = "AlarmCode"
        Me.AlarmCode.ReadOnly = True
        Me.AlarmCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AlarmCode.Width = 74
        '
        'AlarmName
        '
        DataGridViewCellStyle28.NullValue = "000.000"
        Me.AlarmName.DefaultCellStyle = DataGridViewCellStyle28
        Me.AlarmName.HeaderText = "AlarmName"
        Me.AlarmName.Name = "AlarmName"
        Me.AlarmName.ReadOnly = True
        Me.AlarmName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AlarmName.Width = 78
        '
        'AlarmDescript
        '
        DataGridViewCellStyle29.Format = "N2"
        DataGridViewCellStyle29.NullValue = "00.000"
        Me.AlarmDescript.DefaultCellStyle = DataGridViewCellStyle29
        Me.AlarmDescript.HeaderText = "AlarmDescript"
        Me.AlarmDescript.Name = "AlarmDescript"
        Me.AlarmDescript.ReadOnly = True
        Me.AlarmDescript.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AlarmDescript.Width = 90
        '
        'AlarmType
        '
        DataGridViewCellStyle30.Format = "N3"
        DataGridViewCellStyle30.NullValue = "0"
        Me.AlarmType.DefaultCellStyle = DataGridViewCellStyle30
        Me.AlarmType.HeaderText = "AlarmType"
        Me.AlarmType.Name = "AlarmType"
        Me.AlarmType.ReadOnly = True
        Me.AlarmType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AlarmType.Width = 73
        '
        'TimerAlarm
        '
        Me.TimerAlarm.Enabled = True
        Me.TimerAlarm.Interval = 300
        '
        'frmAlarm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 397)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvAlarmData)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmAlarm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAlarm"
        Me.TopMost = True
        CType(Me.dgvAlarmData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgvAlarmData As System.Windows.Forms.DataGridView
    Friend WithEvents TimerAlarm As System.Windows.Forms.Timer
    Friend WithEvents Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlarmCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlarmName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlarmDescript As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlarmType As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
