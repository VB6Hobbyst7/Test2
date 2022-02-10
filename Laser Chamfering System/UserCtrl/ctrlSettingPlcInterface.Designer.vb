<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlSettingPlcInterface
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
        Me.btnResetBitData = New System.Windows.Forms.Button()
        Me.btnSetBitData = New System.Windows.Forms.Button()
        Me.txtBitName = New System.Windows.Forms.TextBox()
        Me.btnPC_Data = New System.Windows.Forms.Button()
        Me.btnPLC_Data = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnResetBitData
        '
        Me.btnResetBitData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetBitData.ImageIndex = 0
        Me.btnResetBitData.Location = New System.Drawing.Point(529, 13)
        Me.btnResetBitData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnResetBitData.Name = "btnResetBitData"
        Me.btnResetBitData.Size = New System.Drawing.Size(105, 32)
        Me.btnResetBitData.TabIndex = 497
        Me.btnResetBitData.Tag = "0"
        Me.btnResetBitData.Text = "Reset Bit Data"
        Me.btnResetBitData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnResetBitData.UseVisualStyleBackColor = True
        '
        'btnSetBitData
        '
        Me.btnSetBitData.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetBitData.ImageIndex = 0
        Me.btnSetBitData.Location = New System.Drawing.Point(408, 13)
        Me.btnSetBitData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetBitData.Name = "btnSetBitData"
        Me.btnSetBitData.Size = New System.Drawing.Size(105, 32)
        Me.btnSetBitData.TabIndex = 496
        Me.btnSetBitData.Tag = "0"
        Me.btnSetBitData.Text = "Set Bit Data"
        Me.btnSetBitData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSetBitData.UseVisualStyleBackColor = True
        '
        'txtBitName
        '
        Me.txtBitName.Enabled = False
        Me.txtBitName.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBitName.Location = New System.Drawing.Point(287, 15)
        Me.txtBitName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtBitName.Name = "txtBitName"
        Me.txtBitName.Size = New System.Drawing.Size(106, 29)
        Me.txtBitName.TabIndex = 495
        '
        'btnPC_Data
        '
        Me.btnPC_Data.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPC_Data.ImageIndex = 0
        Me.btnPC_Data.Location = New System.Drawing.Point(161, 16)
        Me.btnPC_Data.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPC_Data.Name = "btnPC_Data"
        Me.btnPC_Data.Size = New System.Drawing.Size(116, 27)
        Me.btnPC_Data.TabIndex = 494
        Me.btnPC_Data.Tag = "0"
        Me.btnPC_Data.Text = "PC Bit Data"
        Me.btnPC_Data.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPC_Data.UseVisualStyleBackColor = True
        '
        'btnPLC_Data
        '
        Me.btnPLC_Data.BackColor = System.Drawing.Color.Lime
        Me.btnPLC_Data.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPLC_Data.ImageIndex = 0
        Me.btnPLC_Data.Location = New System.Drawing.Point(40, 16)
        Me.btnPLC_Data.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPLC_Data.Name = "btnPLC_Data"
        Me.btnPLC_Data.Size = New System.Drawing.Size(116, 27)
        Me.btnPLC_Data.TabIndex = 493
        Me.btnPLC_Data.Tag = "0"
        Me.btnPLC_Data.Text = "PLC Bit Data"
        Me.btnPLC_Data.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPLC_Data.UseVisualStyleBackColor = False
        '
        'ctrlSettingPlcInterface
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnResetBitData)
        Me.Controls.Add(Me.btnSetBitData)
        Me.Controls.Add(Me.txtBitName)
        Me.Controls.Add(Me.btnPC_Data)
        Me.Controls.Add(Me.btnPLC_Data)
        Me.Name = "ctrlSettingPlcInterface"
        Me.Size = New System.Drawing.Size(703, 721)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnResetBitData As System.Windows.Forms.Button
    Friend WithEvents btnSetBitData As System.Windows.Forms.Button
    Friend WithEvents txtBitName As System.Windows.Forms.TextBox
    Friend WithEvents btnPC_Data As System.Windows.Forms.Button
    Friend WithEvents btnPLC_Data As System.Windows.Forms.Button

End Class
