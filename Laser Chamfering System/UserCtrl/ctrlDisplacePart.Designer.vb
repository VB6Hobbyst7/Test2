<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDisplacePart
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BtnRead = New System.Windows.Forms.Button()
        Me.LblLine = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblPanel = New System.Windows.Forms.Label()
        Me.GridListView = New System.Windows.Forms.DataGridView()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnDel = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCurBlock = New System.Windows.Forms.Label()
        Me.Index = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_cur = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.GridListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnRead
        '
        Me.BtnRead.Location = New System.Drawing.Point(126, 469)
        Me.BtnRead.Name = "BtnRead"
        Me.BtnRead.Size = New System.Drawing.Size(115, 23)
        Me.BtnRead.TabIndex = 0
        Me.BtnRead.Text = "READ"
        Me.BtnRead.UseVisualStyleBackColor = True
        '
        'LblLine
        '
        Me.LblLine.AutoSize = True
        Me.LblLine.Location = New System.Drawing.Point(43, 9)
        Me.LblLine.Name = "LblLine"
        Me.LblLine.Size = New System.Drawing.Size(11, 12)
        Me.LblLine.TabIndex = 2
        Me.LblLine.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Line:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Panel:"
        '
        'LblPanel
        '
        Me.LblPanel.AutoSize = True
        Me.LblPanel.Location = New System.Drawing.Point(125, 9)
        Me.LblPanel.Name = "LblPanel"
        Me.LblPanel.Size = New System.Drawing.Size(11, 12)
        Me.LblPanel.TabIndex = 4
        Me.LblPanel.Text = "-"
        '
        'GridListView
        '
        Me.GridListView.AllowUserToAddRows = False
        Me.GridListView.AllowUserToDeleteRows = False
        Me.GridListView.AllowUserToResizeColumns = False
        Me.GridListView.AllowUserToResizeRows = False
        Me.GridListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridListView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Index, Me.col_1, Me.col_2, Me.btn_cur})
        Me.GridListView.Location = New System.Drawing.Point(4, 27)
        Me.GridListView.Name = "GridListView"
        Me.GridListView.RowHeadersVisible = False
        Me.GridListView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.GridListView.RowTemplate.Height = 23
        Me.GridListView.Size = New System.Drawing.Size(243, 436)
        Me.GridListView.TabIndex = 649
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(3, 469)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(115, 23)
        Me.BtnSave.TabIndex = 650
        Me.BtnSave.Text = "SAVE"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(3, 498)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(115, 23)
        Me.BtnAdd.TabIndex = 651
        Me.BtnAdd.Text = "ADD"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnDel
        '
        Me.BtnDel.Location = New System.Drawing.Point(126, 498)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(115, 23)
        Me.BtnDel.TabIndex = 652
        Me.BtnDel.Text = "DEL"
        Me.BtnDel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(150, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 12)
        Me.Label1.TabIndex = 654
        Me.Label1.Text = "Select Block:"
        '
        'LblCurBlock
        '
        Me.LblCurBlock.AutoSize = True
        Me.LblCurBlock.Location = New System.Drawing.Point(231, 9)
        Me.LblCurBlock.Name = "LblCurBlock"
        Me.LblCurBlock.Size = New System.Drawing.Size(11, 12)
        Me.LblCurBlock.TabIndex = 653
        Me.LblCurBlock.Text = "-"
        '
        'Index
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Index.DefaultCellStyle = DataGridViewCellStyle1
        Me.Index.HeaderText = "Inx"
        Me.Index.Name = "Index"
        Me.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Index.Width = 25
        '
        'col_1
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Format = "N3"
        DataGridViewCellStyle2.NullValue = "0"
        Me.col_1.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_1.HeaderText = "Pos X"
        Me.col_1.Name = "col_1"
        Me.col_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_1.Width = 60
        '
        'col_2
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = "0"
        Me.col_2.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_2.HeaderText = "Pos Y"
        Me.col_2.Name = "col_2"
        Me.col_2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.col_2.Width = 60
        '
        'btn_cur
        '
        Me.btn_cur.HeaderText = "현재위치"
        Me.btn_cur.Name = "btn_cur"
        Me.btn_cur.Text = "현재위치"
        Me.btn_cur.UseColumnTextForButtonValue = True
        Me.btn_cur.Width = 85
        '
        'ctrlDisplacePart
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblCurBlock)
        Me.Controls.Add(Me.BtnDel)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GridListView)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblPanel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblLine)
        Me.Controls.Add(Me.BtnRead)
        Me.Name = "ctrlDisplacePart"
        Me.Size = New System.Drawing.Size(261, 522)
        CType(Me.GridListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnRead As System.Windows.Forms.Button
    Friend WithEvents LblLine As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LblPanel As System.Windows.Forms.Label
    Friend WithEvents GridListView As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnDel As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblCurBlock As System.Windows.Forms.Label
    Friend WithEvents Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_cur As System.Windows.Forms.DataGridViewButtonColumn

End Class
