<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDisplace
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
        Me.BtnMeasureCycleStop = New System.Windows.Forms.Button()
        Me.BtnMeasureCycle = New System.Windows.Forms.Button()
        Me.btnSetALine = New System.Windows.Forms.Button()
        Me.tmDisplace = New System.Windows.Forms.Timer(Me.components)
        Me.TxtRunState = New System.Windows.Forms.TextBox()
        Me.BtnComMode = New System.Windows.Forms.Button()
        Me.BtnSettingMode = New System.Windows.Forms.Button()
        Me.BtnZeroSet = New System.Windows.Forms.Button()
        Me.BtnZeroRelease = New System.Windows.Forms.Button()
        Me.BtnMeasureOne = New System.Windows.Forms.Button()
        Me.LbMeasureOne = New System.Windows.Forms.Label()
        Me.tabPanel = New System.Windows.Forms.TabControl()
        Me.tabPagePanel1 = New System.Windows.Forms.TabPage()
        Me.tabPagePanel2 = New System.Windows.Forms.TabPage()
        Me.tabPagePanel3 = New System.Windows.Forms.TabPage()
        Me.tabPagePanel4 = New System.Windows.Forms.TabPage()
        Me.MainB = New System.Windows.Forms.Button()
        Me.ScrapB3 = New System.Windows.Forms.Button()
        Me.ScrapB2 = New System.Windows.Forms.Button()
        Me.ScrapB1 = New System.Windows.Forms.Button()
        Me.LblCurXPos = New System.Windows.Forms.Label()
        Me.LblCurYPos = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnSetBLine = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Top_Scrap3 = New System.Windows.Forms.Label()
        Me.Top_Scrap2 = New System.Windows.Forms.Label()
        Me.Top_Scrap1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Main_Chuck7 = New System.Windows.Forms.Label()
        Me.Main_Chuck2 = New System.Windows.Forms.Label()
        Me.Main_Chuck6 = New System.Windows.Forms.Label()
        Me.Main_Chuck5 = New System.Windows.Forms.Label()
        Me.Main_Chuck4 = New System.Windows.Forms.Label()
        Me.Main_Chuck3 = New System.Windows.Forms.Label()
        Me.Main_Chuck1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Left_Scrap3 = New System.Windows.Forms.Label()
        Me.Left_Scrap2 = New System.Windows.Forms.Label()
        Me.Left_Scrap1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Right_Scrap3 = New System.Windows.Forms.Label()
        Me.Right_Scrap2 = New System.Windows.Forms.Label()
        Me.Right_Scrap1 = New System.Windows.Forms.Label()
        Me.tabPanel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnMeasureCycleStop
        '
        Me.BtnMeasureCycleStop.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMeasureCycleStop.ImageIndex = 0
        Me.BtnMeasureCycleStop.Location = New System.Drawing.Point(305, 120)
        Me.BtnMeasureCycleStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnMeasureCycleStop.Name = "BtnMeasureCycleStop"
        Me.BtnMeasureCycleStop.Size = New System.Drawing.Size(110, 51)
        Me.BtnMeasureCycleStop.TabIndex = 497
        Me.BtnMeasureCycleStop.Tag = "0"
        Me.BtnMeasureCycleStop.Text = "초기화"
        Me.BtnMeasureCycleStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMeasureCycleStop.UseVisualStyleBackColor = True
        '
        'BtnMeasureCycle
        '
        Me.BtnMeasureCycle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMeasureCycle.ImageIndex = 0
        Me.BtnMeasureCycle.Location = New System.Drawing.Point(305, 66)
        Me.BtnMeasureCycle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnMeasureCycle.Name = "BtnMeasureCycle"
        Me.BtnMeasureCycle.Size = New System.Drawing.Size(110, 51)
        Me.BtnMeasureCycle.TabIndex = 496
        Me.BtnMeasureCycle.Tag = "0"
        Me.BtnMeasureCycle.Text = "측정 시작"
        Me.BtnMeasureCycle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMeasureCycle.UseVisualStyleBackColor = True
        '
        'btnSetALine
        '
        Me.btnSetALine.BackColor = System.Drawing.Color.White
        Me.btnSetALine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetALine.ImageIndex = 0
        Me.btnSetALine.Location = New System.Drawing.Point(28, 66)
        Me.btnSetALine.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetALine.Name = "btnSetALine"
        Me.btnSetALine.Size = New System.Drawing.Size(131, 37)
        Me.btnSetALine.TabIndex = 493
        Me.btnSetALine.Tag = "0"
        Me.btnSetALine.Text = "A-Line"
        Me.btnSetALine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSetALine.UseVisualStyleBackColor = False
        '
        'tmDisplace
        '
        '
        'TxtRunState
        '
        Me.TxtRunState.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRunState.Location = New System.Drawing.Point(28, 21)
        Me.TxtRunState.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtRunState.MaxLength = 11
        Me.TxtRunState.Name = "TxtRunState"
        Me.TxtRunState.ReadOnly = True
        Me.TxtRunState.Size = New System.Drawing.Size(653, 26)
        Me.TxtRunState.TabIndex = 651
        '
        'BtnComMode
        '
        Me.BtnComMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.BtnComMode.ImageIndex = 0
        Me.BtnComMode.Location = New System.Drawing.Point(6, 19)
        Me.BtnComMode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnComMode.Name = "BtnComMode"
        Me.BtnComMode.Size = New System.Drawing.Size(87, 33)
        Me.BtnComMode.TabIndex = 661
        Me.BtnComMode.Tag = "0"
        Me.BtnComMode.Text = "통신 모드"
        Me.BtnComMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnComMode.UseVisualStyleBackColor = True
        '
        'BtnSettingMode
        '
        Me.BtnSettingMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSettingMode.ImageIndex = 0
        Me.BtnSettingMode.Location = New System.Drawing.Point(99, 19)
        Me.BtnSettingMode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSettingMode.Name = "BtnSettingMode"
        Me.BtnSettingMode.Size = New System.Drawing.Size(87, 33)
        Me.BtnSettingMode.TabIndex = 662
        Me.BtnSettingMode.Tag = "1"
        Me.BtnSettingMode.Text = "세팅 모드"
        Me.BtnSettingMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSettingMode.UseVisualStyleBackColor = True
        '
        'BtnZeroSet
        '
        Me.BtnZeroSet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.BtnZeroSet.ImageIndex = 0
        Me.BtnZeroSet.Location = New System.Drawing.Point(6, 56)
        Me.BtnZeroSet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnZeroSet.Name = "BtnZeroSet"
        Me.BtnZeroSet.Size = New System.Drawing.Size(87, 33)
        Me.BtnZeroSet.TabIndex = 663
        Me.BtnZeroSet.Tag = "2"
        Me.BtnZeroSet.Text = "영점 설정"
        Me.BtnZeroSet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnZeroSet.UseVisualStyleBackColor = True
        '
        'BtnZeroRelease
        '
        Me.BtnZeroRelease.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.BtnZeroRelease.ImageIndex = 0
        Me.BtnZeroRelease.Location = New System.Drawing.Point(99, 56)
        Me.BtnZeroRelease.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnZeroRelease.Name = "BtnZeroRelease"
        Me.BtnZeroRelease.Size = New System.Drawing.Size(87, 33)
        Me.BtnZeroRelease.TabIndex = 664
        Me.BtnZeroRelease.Tag = "3"
        Me.BtnZeroRelease.Text = "영점 해제"
        Me.BtnZeroRelease.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnZeroRelease.UseVisualStyleBackColor = True
        '
        'BtnMeasureOne
        '
        Me.BtnMeasureOne.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMeasureOne.ImageIndex = 0
        Me.BtnMeasureOne.Location = New System.Drawing.Point(6, 92)
        Me.BtnMeasureOne.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnMeasureOne.Name = "BtnMeasureOne"
        Me.BtnMeasureOne.Size = New System.Drawing.Size(87, 33)
        Me.BtnMeasureOne.TabIndex = 665
        Me.BtnMeasureOne.Tag = "4"
        Me.BtnMeasureOne.Text = "1회 측정"
        Me.BtnMeasureOne.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnMeasureOne.UseVisualStyleBackColor = True
        '
        'LbMeasureOne
        '
        Me.LbMeasureOne.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LbMeasureOne.Location = New System.Drawing.Point(99, 100)
        Me.LbMeasureOne.Margin = New System.Windows.Forms.Padding(3)
        Me.LbMeasureOne.Name = "LbMeasureOne"
        Me.LbMeasureOne.Size = New System.Drawing.Size(87, 19)
        Me.LbMeasureOne.TabIndex = 645
        Me.LbMeasureOne.Text = "000.000"
        Me.LbMeasureOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabPanel
        '
        Me.tabPanel.Controls.Add(Me.tabPagePanel1)
        Me.tabPanel.Controls.Add(Me.tabPagePanel2)
        Me.tabPanel.Controls.Add(Me.tabPagePanel3)
        Me.tabPanel.Controls.Add(Me.tabPagePanel4)
        Me.tabPanel.Location = New System.Drawing.Point(24, 241)
        Me.tabPanel.Name = "tabPanel"
        Me.tabPanel.SelectedIndex = 0
        Me.tabPanel.Size = New System.Drawing.Size(250, 574)
        Me.tabPanel.TabIndex = 707
        '
        'tabPagePanel1
        '
        Me.tabPagePanel1.Location = New System.Drawing.Point(4, 22)
        Me.tabPagePanel1.Name = "tabPagePanel1"
        Me.tabPagePanel1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagePanel1.Size = New System.Drawing.Size(242, 548)
        Me.tabPagePanel1.TabIndex = 0
        Me.tabPagePanel1.Text = "Panel #1"
        Me.tabPagePanel1.UseVisualStyleBackColor = True
        '
        'tabPagePanel2
        '
        Me.tabPagePanel2.Location = New System.Drawing.Point(4, 22)
        Me.tabPagePanel2.Name = "tabPagePanel2"
        Me.tabPagePanel2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagePanel2.Size = New System.Drawing.Size(242, 548)
        Me.tabPagePanel2.TabIndex = 1
        Me.tabPagePanel2.Text = "#2"
        Me.tabPagePanel2.UseVisualStyleBackColor = True
        '
        'tabPagePanel3
        '
        Me.tabPagePanel3.Location = New System.Drawing.Point(4, 22)
        Me.tabPagePanel3.Name = "tabPagePanel3"
        Me.tabPagePanel3.Size = New System.Drawing.Size(242, 548)
        Me.tabPagePanel3.TabIndex = 2
        Me.tabPagePanel3.Text = "#3"
        Me.tabPagePanel3.UseVisualStyleBackColor = True
        '
        'tabPagePanel4
        '
        Me.tabPagePanel4.Location = New System.Drawing.Point(4, 22)
        Me.tabPagePanel4.Name = "tabPagePanel4"
        Me.tabPagePanel4.Size = New System.Drawing.Size(242, 548)
        Me.tabPagePanel4.TabIndex = 3
        Me.tabPagePanel4.Text = "#4"
        Me.tabPagePanel4.UseVisualStyleBackColor = True
        '
        'MainB
        '
        Me.MainB.BackColor = System.Drawing.Color.White
        Me.MainB.FlatAppearance.BorderSize = 2
        Me.MainB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MainB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainB.Location = New System.Drawing.Point(63, 145)
        Me.MainB.Margin = New System.Windows.Forms.Padding(2)
        Me.MainB.Name = "MainB"
        Me.MainB.Padding = New System.Windows.Forms.Padding(1)
        Me.MainB.Size = New System.Drawing.Size(85, 81)
        Me.MainB.TabIndex = 711
        Me.MainB.TabStop = False
        Me.MainB.Tag = "3"
        Me.MainB.Text = "4"
        Me.MainB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.MainB.UseVisualStyleBackColor = False
        '
        'ScrapB3
        '
        Me.ScrapB3.BackColor = System.Drawing.Color.White
        Me.ScrapB3.FlatAppearance.BorderSize = 2
        Me.ScrapB3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ScrapB3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrapB3.Location = New System.Drawing.Point(152, 145)
        Me.ScrapB3.Margin = New System.Windows.Forms.Padding(2)
        Me.ScrapB3.Name = "ScrapB3"
        Me.ScrapB3.Padding = New System.Windows.Forms.Padding(1)
        Me.ScrapB3.Size = New System.Drawing.Size(31, 81)
        Me.ScrapB3.TabIndex = 710
        Me.ScrapB3.TabStop = False
        Me.ScrapB3.Tag = "2"
        Me.ScrapB3.Text = "3"
        Me.ScrapB3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ScrapB3.UseVisualStyleBackColor = False
        '
        'ScrapB2
        '
        Me.ScrapB2.BackColor = System.Drawing.Color.White
        Me.ScrapB2.FlatAppearance.BorderSize = 2
        Me.ScrapB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ScrapB2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrapB2.Location = New System.Drawing.Point(28, 115)
        Me.ScrapB2.Margin = New System.Windows.Forms.Padding(2)
        Me.ScrapB2.Name = "ScrapB2"
        Me.ScrapB2.Padding = New System.Windows.Forms.Padding(1)
        Me.ScrapB2.Size = New System.Drawing.Size(155, 27)
        Me.ScrapB2.TabIndex = 709
        Me.ScrapB2.TabStop = False
        Me.ScrapB2.Tag = "1"
        Me.ScrapB2.Text = "2"
        Me.ScrapB2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ScrapB2.UseVisualStyleBackColor = False
        '
        'ScrapB1
        '
        Me.ScrapB1.BackColor = System.Drawing.Color.White
        Me.ScrapB1.FlatAppearance.BorderSize = 2
        Me.ScrapB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ScrapB1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrapB1.Location = New System.Drawing.Point(28, 145)
        Me.ScrapB1.Margin = New System.Windows.Forms.Padding(2)
        Me.ScrapB1.Name = "ScrapB1"
        Me.ScrapB1.Padding = New System.Windows.Forms.Padding(1)
        Me.ScrapB1.Size = New System.Drawing.Size(31, 81)
        Me.ScrapB1.TabIndex = 708
        Me.ScrapB1.TabStop = False
        Me.ScrapB1.Tag = "0"
        Me.ScrapB1.Text = "1"
        Me.ScrapB1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ScrapB1.UseVisualStyleBackColor = False
        '
        'LblCurXPos
        '
        Me.LblCurXPos.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblCurXPos.Location = New System.Drawing.Point(207, 138)
        Me.LblCurXPos.Margin = New System.Windows.Forms.Padding(3)
        Me.LblCurXPos.Name = "LblCurXPos"
        Me.LblCurXPos.Size = New System.Drawing.Size(85, 19)
        Me.LblCurXPos.TabIndex = 724
        Me.LblCurXPos.Text = "000.000"
        Me.LblCurXPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCurYPos
        '
        Me.LblCurYPos.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblCurYPos.Location = New System.Drawing.Point(207, 194)
        Me.LblCurYPos.Margin = New System.Windows.Forms.Padding(3)
        Me.LblCurYPos.Name = "LblCurYPos"
        Me.LblCurYPos.Size = New System.Drawing.Size(85, 19)
        Me.LblCurYPos.TabIndex = 725
        Me.LblCurYPos.Text = "000.000"
        Me.LblCurYPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(207, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 19)
        Me.Label10.TabIndex = 726
        Me.Label10.Text = "X 현재 위치"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Silver
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(207, 172)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 19)
        Me.Label11.TabIndex = 727
        Me.Label11.Text = "Y 현재 위치"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSetBLine
        '
        Me.btnSetBLine.BackColor = System.Drawing.Color.White
        Me.btnSetBLine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetBLine.ImageIndex = 0
        Me.btnSetBLine.Location = New System.Drawing.Point(165, 66)
        Me.btnSetBLine.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetBLine.Name = "btnSetBLine"
        Me.btnSetBLine.Size = New System.Drawing.Size(131, 37)
        Me.btnSetBLine.TabIndex = 666
        Me.btnSetBLine.Tag = "0"
        Me.btnSetBLine.Text = "B-Line"
        Me.btnSetBLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSetBLine.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnSettingMode)
        Me.GroupBox1.Controls.Add(Me.BtnComMode)
        Me.GroupBox1.Controls.Add(Me.BtnZeroSet)
        Me.GroupBox1.Controls.Add(Me.BtnZeroRelease)
        Me.GroupBox1.Controls.Add(Me.BtnMeasureOne)
        Me.GroupBox1.Controls.Add(Me.LbMeasureOne)
        Me.GroupBox1.Location = New System.Drawing.Point(485, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 131)
        Me.GroupBox1.TabIndex = 767
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Manual동작"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Top_Scrap3)
        Me.Panel1.Controls.Add(Me.Top_Scrap2)
        Me.Panel1.Controls.Add(Me.Top_Scrap1)
        Me.Panel1.Location = New System.Drawing.Point(300, 263)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 41)
        Me.Panel1.TabIndex = 768
        '
        'Top_Scrap3
        '
        Me.Top_Scrap3.AutoSize = True
        Me.Top_Scrap3.Location = New System.Drawing.Point(257, 15)
        Me.Top_Scrap3.Name = "Top_Scrap3"
        Me.Top_Scrap3.Size = New System.Drawing.Size(33, 12)
        Me.Top_Scrap3.TabIndex = 0
        Me.Top_Scrap3.Text = "Top3"
        '
        'Top_Scrap2
        '
        Me.Top_Scrap2.AutoSize = True
        Me.Top_Scrap2.Location = New System.Drawing.Point(170, 15)
        Me.Top_Scrap2.Name = "Top_Scrap2"
        Me.Top_Scrap2.Size = New System.Drawing.Size(33, 12)
        Me.Top_Scrap2.TabIndex = 0
        Me.Top_Scrap2.Text = "Top2"
        '
        'Top_Scrap1
        '
        Me.Top_Scrap1.AutoSize = True
        Me.Top_Scrap1.Location = New System.Drawing.Point(85, 15)
        Me.Top_Scrap1.Name = "Top_Scrap1"
        Me.Top_Scrap1.Size = New System.Drawing.Size(33, 12)
        Me.Top_Scrap1.TabIndex = 0
        Me.Top_Scrap1.Text = "Top1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Main_Chuck7)
        Me.Panel2.Controls.Add(Me.Main_Chuck2)
        Me.Panel2.Controls.Add(Me.Main_Chuck6)
        Me.Panel2.Controls.Add(Me.Main_Chuck5)
        Me.Panel2.Controls.Add(Me.Main_Chuck4)
        Me.Panel2.Controls.Add(Me.Main_Chuck3)
        Me.Panel2.Controls.Add(Me.Main_Chuck1)
        Me.Panel2.Location = New System.Drawing.Point(371, 310)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(244, 325)
        Me.Panel2.TabIndex = 768
        '
        'Main_Chuck7
        '
        Me.Main_Chuck7.AutoSize = True
        Me.Main_Chuck7.Location = New System.Drawing.Point(187, 253)
        Me.Main_Chuck7.Name = "Main_Chuck7"
        Me.Main_Chuck7.Size = New System.Drawing.Size(39, 12)
        Me.Main_Chuck7.TabIndex = 0
        Me.Main_Chuck7.Text = "Main7"
        '
        'Main_Chuck2
        '
        Me.Main_Chuck2.AutoSize = True
        Me.Main_Chuck2.Location = New System.Drawing.Point(99, 25)
        Me.Main_Chuck2.Name = "Main_Chuck2"
        Me.Main_Chuck2.Size = New System.Drawing.Size(39, 12)
        Me.Main_Chuck2.TabIndex = 0
        Me.Main_Chuck2.Text = "Main2"
        '
        'Main_Chuck6
        '
        Me.Main_Chuck6.AutoSize = True
        Me.Main_Chuck6.Location = New System.Drawing.Point(14, 253)
        Me.Main_Chuck6.Name = "Main_Chuck6"
        Me.Main_Chuck6.Size = New System.Drawing.Size(39, 12)
        Me.Main_Chuck6.TabIndex = 0
        Me.Main_Chuck6.Text = "Main6"
        '
        'Main_Chuck5
        '
        Me.Main_Chuck5.AutoSize = True
        Me.Main_Chuck5.Location = New System.Drawing.Point(187, 139)
        Me.Main_Chuck5.Name = "Main_Chuck5"
        Me.Main_Chuck5.Size = New System.Drawing.Size(39, 12)
        Me.Main_Chuck5.TabIndex = 0
        Me.Main_Chuck5.Text = "Main5"
        '
        'Main_Chuck4
        '
        Me.Main_Chuck4.AutoSize = True
        Me.Main_Chuck4.Location = New System.Drawing.Point(14, 139)
        Me.Main_Chuck4.Name = "Main_Chuck4"
        Me.Main_Chuck4.Size = New System.Drawing.Size(39, 12)
        Me.Main_Chuck4.TabIndex = 0
        Me.Main_Chuck4.Text = "Main4"
        '
        'Main_Chuck3
        '
        Me.Main_Chuck3.AutoSize = True
        Me.Main_Chuck3.Location = New System.Drawing.Point(187, 25)
        Me.Main_Chuck3.Name = "Main_Chuck3"
        Me.Main_Chuck3.Size = New System.Drawing.Size(39, 12)
        Me.Main_Chuck3.TabIndex = 0
        Me.Main_Chuck3.Text = "Main3"
        '
        'Main_Chuck1
        '
        Me.Main_Chuck1.AutoSize = True
        Me.Main_Chuck1.Location = New System.Drawing.Point(14, 25)
        Me.Main_Chuck1.Name = "Main_Chuck1"
        Me.Main_Chuck1.Size = New System.Drawing.Size(39, 12)
        Me.Main_Chuck1.TabIndex = 0
        Me.Main_Chuck1.Text = "Main1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Left_Scrap3)
        Me.Panel3.Controls.Add(Me.Left_Scrap2)
        Me.Panel3.Controls.Add(Me.Left_Scrap1)
        Me.Panel3.Location = New System.Drawing.Point(300, 310)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(65, 325)
        Me.Panel3.TabIndex = 768
        '
        'Left_Scrap3
        '
        Me.Left_Scrap3.AutoSize = True
        Me.Left_Scrap3.Location = New System.Drawing.Point(7, 253)
        Me.Left_Scrap3.Name = "Left_Scrap3"
        Me.Left_Scrap3.Size = New System.Drawing.Size(31, 12)
        Me.Left_Scrap3.TabIndex = 0
        Me.Left_Scrap3.Text = "Left3"
        '
        'Left_Scrap2
        '
        Me.Left_Scrap2.AutoSize = True
        Me.Left_Scrap2.Location = New System.Drawing.Point(7, 139)
        Me.Left_Scrap2.Name = "Left_Scrap2"
        Me.Left_Scrap2.Size = New System.Drawing.Size(31, 12)
        Me.Left_Scrap2.TabIndex = 0
        Me.Left_Scrap2.Text = "Left2"
        '
        'Left_Scrap1
        '
        Me.Left_Scrap1.AutoSize = True
        Me.Left_Scrap1.Location = New System.Drawing.Point(7, 25)
        Me.Left_Scrap1.Name = "Left_Scrap1"
        Me.Left_Scrap1.Size = New System.Drawing.Size(31, 12)
        Me.Left_Scrap1.TabIndex = 0
        Me.Left_Scrap1.Text = "Left1"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Right_Scrap3)
        Me.Panel4.Controls.Add(Me.Right_Scrap2)
        Me.Panel4.Controls.Add(Me.Right_Scrap1)
        Me.Panel4.Location = New System.Drawing.Point(621, 310)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(65, 325)
        Me.Panel4.TabIndex = 768
        '
        'Right_Scrap3
        '
        Me.Right_Scrap3.AutoSize = True
        Me.Right_Scrap3.Location = New System.Drawing.Point(6, 253)
        Me.Right_Scrap3.Name = "Right_Scrap3"
        Me.Right_Scrap3.Size = New System.Drawing.Size(39, 12)
        Me.Right_Scrap3.TabIndex = 0
        Me.Right_Scrap3.Text = "Right3"
        '
        'Right_Scrap2
        '
        Me.Right_Scrap2.AutoSize = True
        Me.Right_Scrap2.Location = New System.Drawing.Point(6, 139)
        Me.Right_Scrap2.Name = "Right_Scrap2"
        Me.Right_Scrap2.Size = New System.Drawing.Size(39, 12)
        Me.Right_Scrap2.TabIndex = 0
        Me.Right_Scrap2.Text = "Right2"
        '
        'Right_Scrap1
        '
        Me.Right_Scrap1.AutoSize = True
        Me.Right_Scrap1.Location = New System.Drawing.Point(6, 25)
        Me.Right_Scrap1.Name = "Right_Scrap1"
        Me.Right_Scrap1.Size = New System.Drawing.Size(39, 12)
        Me.Right_Scrap1.TabIndex = 0
        Me.Right_Scrap1.Text = "Right1"
        '
        'ctrlDisplace
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblCurYPos)
        Me.Controls.Add(Me.LblCurXPos)
        Me.Controls.Add(Me.MainB)
        Me.Controls.Add(Me.ScrapB3)
        Me.Controls.Add(Me.ScrapB2)
        Me.Controls.Add(Me.ScrapB1)
        Me.Controls.Add(Me.tabPanel)
        Me.Controls.Add(Me.btnSetBLine)
        Me.Controls.Add(Me.TxtRunState)
        Me.Controls.Add(Me.BtnMeasureCycleStop)
        Me.Controls.Add(Me.BtnMeasureCycle)
        Me.Controls.Add(Me.btnSetALine)
        Me.Name = "ctrlDisplace"
        Me.Size = New System.Drawing.Size(710, 828)
        Me.tabPanel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnMeasureCycleStop As System.Windows.Forms.Button
    Friend WithEvents BtnMeasureCycle As System.Windows.Forms.Button
    Friend WithEvents btnSetALine As System.Windows.Forms.Button
    Friend WithEvents tmDisplace As System.Windows.Forms.Timer
    Friend WithEvents TxtRunState As System.Windows.Forms.TextBox
    Friend WithEvents BtnComMode As System.Windows.Forms.Button
    Friend WithEvents BtnSettingMode As System.Windows.Forms.Button
    Friend WithEvents BtnZeroSet As System.Windows.Forms.Button
    Friend WithEvents BtnZeroRelease As System.Windows.Forms.Button
    Friend WithEvents BtnMeasureOne As System.Windows.Forms.Button
    Friend WithEvents LbMeasureOne As System.Windows.Forms.Label
    Friend WithEvents tabPanel As System.Windows.Forms.TabControl
    Friend WithEvents tabPagePanel1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePanel2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePanel3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePanel4 As System.Windows.Forms.TabPage
    Friend WithEvents MainB As System.Windows.Forms.Button
    Friend WithEvents ScrapB3 As System.Windows.Forms.Button
    Friend WithEvents ScrapB2 As System.Windows.Forms.Button
    Friend WithEvents ScrapB1 As System.Windows.Forms.Button
    Friend WithEvents LblCurXPos As System.Windows.Forms.Label
    Friend WithEvents LblCurYPos As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnSetBLine As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Top_Scrap3 As System.Windows.Forms.Label
    Friend WithEvents Top_Scrap2 As System.Windows.Forms.Label
    Friend WithEvents Top_Scrap1 As System.Windows.Forms.Label
    Friend WithEvents Main_Chuck7 As System.Windows.Forms.Label
    Friend WithEvents Main_Chuck2 As System.Windows.Forms.Label
    Friend WithEvents Main_Chuck6 As System.Windows.Forms.Label
    Friend WithEvents Main_Chuck5 As System.Windows.Forms.Label
    Friend WithEvents Main_Chuck4 As System.Windows.Forms.Label
    Friend WithEvents Main_Chuck3 As System.Windows.Forms.Label
    Friend WithEvents Main_Chuck1 As System.Windows.Forms.Label
    Friend WithEvents Left_Scrap3 As System.Windows.Forms.Label
    Friend WithEvents Left_Scrap2 As System.Windows.Forms.Label
    Friend WithEvents Left_Scrap1 As System.Windows.Forms.Label
    Friend WithEvents Right_Scrap3 As System.Windows.Forms.Label
    Friend WithEvents Right_Scrap2 As System.Windows.Forms.Label
    Friend WithEvents Right_Scrap1 As System.Windows.Forms.Label

End Class
