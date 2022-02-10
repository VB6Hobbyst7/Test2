<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlPLCBit
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnPLCBit = New System.Windows.Forms.Button()
        Me.btnPCBit = New System.Windows.Forms.Button()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.dgvPCBitData = New System.Windows.Forms.DataGridView()
        Me.PCBitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description_PC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.check_PC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPLCBitData = New System.Windows.Forms.DataGridView()
        Me.PLCBitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description_PLC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.check_PLC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnPLCWord = New System.Windows.Forms.Button()
        Me.btnPCWord = New System.Windows.Forms.Button()
        Me.gbData.SuspendLayout()
        CType(Me.dgvPCBitData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPLCBitData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPLCBit
        '
        Me.btnPLCBit.BackColor = System.Drawing.Color.White
        Me.btnPLCBit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPLCBit.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPLCBit.Location = New System.Drawing.Point(3, 3)
        Me.btnPLCBit.Name = "btnPLCBit"
        Me.btnPLCBit.Size = New System.Drawing.Size(82, 27)
        Me.btnPLCBit.TabIndex = 0
        Me.btnPLCBit.Text = "PLC_Bit1"
        Me.btnPLCBit.UseVisualStyleBackColor = False
        '
        'btnPCBit
        '
        Me.btnPCBit.BackColor = System.Drawing.Color.White
        Me.btnPCBit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPCBit.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPCBit.Location = New System.Drawing.Point(352, 3)
        Me.btnPCBit.Name = "btnPCBit"
        Me.btnPCBit.Size = New System.Drawing.Size(82, 27)
        Me.btnPCBit.TabIndex = 0
        Me.btnPCBit.Text = "PC_Bit1"
        Me.btnPCBit.UseVisualStyleBackColor = False
        '
        'gbData
        '
        Me.gbData.Controls.Add(Me.dgvPCBitData)
        Me.gbData.Controls.Add(Me.dgvPLCBitData)
        Me.gbData.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.gbData.Location = New System.Drawing.Point(-2, 34)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(701, 660)
        Me.gbData.TabIndex = 1
        Me.gbData.TabStop = False
        Me.gbData.Text = "Data"
        '
        'dgvPCBitData
        '
        Me.dgvPCBitData.AllowUserToAddRows = False
        Me.dgvPCBitData.AllowUserToDeleteRows = False
        Me.dgvPCBitData.AllowUserToResizeColumns = False
        Me.dgvPCBitData.AllowUserToResizeRows = False
        Me.dgvPCBitData.BackgroundColor = System.Drawing.Color.White
        Me.dgvPCBitData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPCBitData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgvPCBitData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.dgvPCBitData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPCBitData.ColumnHeadersHeight = 30
        Me.dgvPCBitData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPCBitData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PCBitNo, Me.Description_PC, Me.check_PC})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPCBitData.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPCBitData.Location = New System.Drawing.Point(353, 19)
        Me.dgvPCBitData.MultiSelect = False
        Me.dgvPCBitData.Name = "dgvPCBitData"
        Me.dgvPCBitData.RowHeadersVisible = False
        Me.dgvPCBitData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPCBitData.RowTemplate.Height = 23
        Me.dgvPCBitData.Size = New System.Drawing.Size(345, 633)
        Me.dgvPCBitData.TabIndex = 2
        '
        'PCBitNo
        '
        Me.PCBitNo.HeaderText = "Bit No"
        Me.PCBitNo.Name = "PCBitNo"
        Me.PCBitNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PCBitNo.Width = 70
        '
        'Description_PC
        '
        Me.Description_PC.HeaderText = "Description"
        Me.Description_PC.Name = "Description_PC"
        Me.Description_PC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Description_PC.Width = 190
        '
        'check_PC
        '
        Me.check_PC.HeaderText = "Check"
        Me.check_PC.Name = "check_PC"
        Me.check_PC.ReadOnly = True
        Me.check_PC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.check_PC.Width = 70
        '
        'dgvPLCBitData
        '
        Me.dgvPLCBitData.AllowUserToAddRows = False
        Me.dgvPLCBitData.AllowUserToDeleteRows = False
        Me.dgvPLCBitData.AllowUserToResizeColumns = False
        Me.dgvPLCBitData.AllowUserToResizeRows = False
        Me.dgvPLCBitData.BackgroundColor = System.Drawing.Color.White
        Me.dgvPLCBitData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPLCBitData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dgvPLCBitData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.dgvPLCBitData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPLCBitData.ColumnHeadersHeight = 30
        Me.dgvPLCBitData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPLCBitData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PLCBitNo, Me.description_PLC, Me.check_PLC})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPLCBitData.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPLCBitData.Location = New System.Drawing.Point(6, 19)
        Me.dgvPLCBitData.MultiSelect = False
        Me.dgvPLCBitData.Name = "dgvPLCBitData"
        Me.dgvPLCBitData.ReadOnly = True
        Me.dgvPLCBitData.RowHeadersVisible = False
        Me.dgvPLCBitData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPLCBitData.RowTemplate.Height = 23
        Me.dgvPLCBitData.Size = New System.Drawing.Size(345, 633)
        Me.dgvPLCBitData.TabIndex = 1
        '
        'PLCBitNo
        '
        Me.PLCBitNo.HeaderText = "Bit No"
        Me.PLCBitNo.Name = "PLCBitNo"
        Me.PLCBitNo.ReadOnly = True
        Me.PLCBitNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PLCBitNo.Width = 70
        '
        'description_PLC
        '
        Me.description_PLC.HeaderText = "Description"
        Me.description_PLC.Name = "description_PLC"
        Me.description_PLC.ReadOnly = True
        Me.description_PLC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.description_PLC.Width = 190
        '
        'check_PLC
        '
        Me.check_PLC.HeaderText = "Check"
        Me.check_PLC.Name = "check_PLC"
        Me.check_PLC.ReadOnly = True
        Me.check_PLC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.check_PLC.Width = 70
        '
        'Timer1
        '
        '
        'btnPLCWord
        '
        Me.btnPLCWord.BackColor = System.Drawing.Color.White
        Me.btnPLCWord.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPLCWord.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPLCWord.Location = New System.Drawing.Point(91, 3)
        Me.btnPLCWord.Name = "btnPLCWord"
        Me.btnPLCWord.Size = New System.Drawing.Size(105, 27)
        Me.btnPLCWord.TabIndex = 0
        Me.btnPLCWord.Text = "PLC_Word1"
        Me.btnPLCWord.UseVisualStyleBackColor = False
        '
        'btnPCWord
        '
        Me.btnPCWord.BackColor = System.Drawing.Color.White
        Me.btnPCWord.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPCWord.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnPCWord.Location = New System.Drawing.Point(440, 3)
        Me.btnPCWord.Name = "btnPCWord"
        Me.btnPCWord.Size = New System.Drawing.Size(105, 27)
        Me.btnPCWord.TabIndex = 0
        Me.btnPCWord.Text = "PC_Word1"
        Me.btnPCWord.UseVisualStyleBackColor = False
        '
        'ctrlPLCBit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.gbData)
        Me.Controls.Add(Me.btnPCWord)
        Me.Controls.Add(Me.btnPCBit)
        Me.Controls.Add(Me.btnPLCWord)
        Me.Controls.Add(Me.btnPLCBit)
        Me.Name = "ctrlPLCBit"
        Me.Size = New System.Drawing.Size(699, 686)
        Me.gbData.ResumeLayout(False)
        CType(Me.dgvPCBitData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPLCBitData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPLCBit As System.Windows.Forms.Button
    Friend WithEvents btnPCBit As System.Windows.Forms.Button
    Friend WithEvents gbData As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPLCBitData As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPCBitData As System.Windows.Forms.DataGridView
    Friend WithEvents PLCBitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents description_PLC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check_PLC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnPLCWord As System.Windows.Forms.Button
    Friend WithEvents btnPCWord As System.Windows.Forms.Button
    Friend WithEvents PCBitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description_PC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents check_PC As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
