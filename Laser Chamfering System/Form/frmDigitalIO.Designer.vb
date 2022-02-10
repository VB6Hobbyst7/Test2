<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDigitalIO
    Inherits System.Windows.Forms.Form

#Region "Windows Form 디자이너에서 생성한 코드 "
    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then

            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    '시작 폼의 경우 처음 만든 인스턴스가 기본 인스턴스가 됩니다.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        '이 호출은 Windows Form 디자이너에 필요합니다.
        InitializeComponent()
    End Sub
#End Region

#Region "업그레이드 지원 "
    Private Shared m_vb6FormDefInstance As frmDigitalIO
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmDigitalIO
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmDigitalIO()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As frmDigitalIO)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

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
        Me.chkInterrupt = New System.Windows.Forms.CheckBox()
        Me.chkFalling = New System.Windows.Forms.CheckBox()
        Me.chkRising = New System.Windows.Forms.CheckBox()
        Me.List1 = New System.Windows.Forms.ListBox()
        Me.cmdListClear = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Fra2ndWord = New System.Windows.Forms.GroupBox()
        Me._chk2ndWord_0 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_1 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_2 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_3 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_4 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_5 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_6 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_7 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_8 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_9 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_10 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_11 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_12 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_13 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_14 = New System.Windows.Forms.CheckBox()
        Me._chk2ndWord_15 = New System.Windows.Forms.CheckBox()
        Me.Fra1stWord = New System.Windows.Forms.GroupBox()
        Me._chk1stWord_0 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_1 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_2 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_3 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_4 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_5 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_6 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_7 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_8 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_9 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_10 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_11 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_12 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_13 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_14 = New System.Windows.Forms.CheckBox()
        Me._chk1stWord_15 = New System.Windows.Forms.CheckBox()
        Me.cobModule = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Fra2ndWord.SuspendLayout()
        Me.Fra1stWord.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkInterrupt
        '
        Me.chkInterrupt.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkInterrupt.BackColor = System.Drawing.SystemColors.Control
        Me.chkInterrupt.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkInterrupt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkInterrupt.Location = New System.Drawing.Point(23, 58)
        Me.chkInterrupt.Name = "chkInterrupt"
        Me.chkInterrupt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkInterrupt.Size = New System.Drawing.Size(161, 25)
        Me.chkInterrupt.TabIndex = 51
        Me.chkInterrupt.Text = "Enable Interrupt"
        Me.chkInterrupt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInterrupt.UseVisualStyleBackColor = False
        '
        'chkFalling
        '
        Me.chkFalling.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkFalling.BackColor = System.Drawing.SystemColors.Control
        Me.chkFalling.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFalling.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFalling.Location = New System.Drawing.Point(383, 58)
        Me.chkFalling.Name = "chkFalling"
        Me.chkFalling.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFalling.Size = New System.Drawing.Size(89, 25)
        Me.chkFalling.TabIndex = 50
        Me.chkFalling.Text = "Falling"
        Me.chkFalling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFalling.UseVisualStyleBackColor = False
        '
        'chkRising
        '
        Me.chkRising.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRising.BackColor = System.Drawing.SystemColors.Control
        Me.chkRising.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkRising.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRising.Location = New System.Drawing.Point(287, 58)
        Me.chkRising.Name = "chkRising"
        Me.chkRising.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRising.Size = New System.Drawing.Size(89, 25)
        Me.chkRising.TabIndex = 49
        Me.chkRising.Text = "Rising"
        Me.chkRising.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRising.UseVisualStyleBackColor = False
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.List1.ItemHeight = 12
        Me.List1.Location = New System.Drawing.Point(23, 258)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(449, 184)
        Me.List1.TabIndex = 48
        '
        'cmdListClear
        '
        Me.cmdListClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdListClear.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdListClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdListClear.Location = New System.Drawing.Point(23, 450)
        Me.cmdListClear.Name = "cmdListClear"
        Me.cmdListClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdListClear.Size = New System.Drawing.Size(185, 33)
        Me.cmdListClear.TabIndex = 47
        Me.cmdListClear.Text = "List Clear"
        Me.cmdListClear.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(287, 450)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(185, 33)
        Me.cmdClose.TabIndex = 46
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Fra2ndWord
        '
        Me.Fra2ndWord.BackColor = System.Drawing.SystemColors.Control
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_0)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_1)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_2)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_3)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_4)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_5)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_6)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_7)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_8)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_9)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_10)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_11)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_12)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_13)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_14)
        Me.Fra2ndWord.Controls.Add(Me._chk2ndWord_15)
        Me.Fra2ndWord.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Fra2ndWord.Location = New System.Drawing.Point(23, 178)
        Me.Fra2ndWord.Name = "Fra2ndWord"
        Me.Fra2ndWord.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Fra2ndWord.Size = New System.Drawing.Size(449, 73)
        Me.Fra2ndWord.TabIndex = 45
        Me.Fra2ndWord.TabStop = False
        Me.Fra2ndWord.Text = "Frame2"
        '
        '_chk2ndWord_0
        '
        Me._chk2ndWord_0.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_0.Location = New System.Drawing.Point(16, 24)
        Me._chk2ndWord_0.Name = "_chk2ndWord_0"
        Me._chk2ndWord_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_0.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_0.TabIndex = 35
        Me._chk2ndWord_0.Text = "16"
        Me._chk2ndWord_0.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_1
        '
        Me._chk2ndWord_1.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_1.Location = New System.Drawing.Point(72, 24)
        Me._chk2ndWord_1.Name = "_chk2ndWord_1"
        Me._chk2ndWord_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_1.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_1.TabIndex = 34
        Me._chk2ndWord_1.Text = "17"
        Me._chk2ndWord_1.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_2
        '
        Me._chk2ndWord_2.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_2.Location = New System.Drawing.Point(128, 24)
        Me._chk2ndWord_2.Name = "_chk2ndWord_2"
        Me._chk2ndWord_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_2.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_2.TabIndex = 33
        Me._chk2ndWord_2.Text = "18"
        Me._chk2ndWord_2.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_3
        '
        Me._chk2ndWord_3.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_3.Location = New System.Drawing.Point(176, 24)
        Me._chk2ndWord_3.Name = "_chk2ndWord_3"
        Me._chk2ndWord_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_3.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_3.TabIndex = 32
        Me._chk2ndWord_3.Text = "19"
        Me._chk2ndWord_3.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_4
        '
        Me._chk2ndWord_4.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_4.Location = New System.Drawing.Point(232, 24)
        Me._chk2ndWord_4.Name = "_chk2ndWord_4"
        Me._chk2ndWord_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_4.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_4.TabIndex = 31
        Me._chk2ndWord_4.Text = "20"
        Me._chk2ndWord_4.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_5
        '
        Me._chk2ndWord_5.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_5.Location = New System.Drawing.Point(288, 24)
        Me._chk2ndWord_5.Name = "_chk2ndWord_5"
        Me._chk2ndWord_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_5.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_5.TabIndex = 30
        Me._chk2ndWord_5.Text = "21"
        Me._chk2ndWord_5.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_6
        '
        Me._chk2ndWord_6.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_6.Location = New System.Drawing.Point(344, 24)
        Me._chk2ndWord_6.Name = "_chk2ndWord_6"
        Me._chk2ndWord_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_6.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_6.TabIndex = 29
        Me._chk2ndWord_6.Text = "22"
        Me._chk2ndWord_6.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_7
        '
        Me._chk2ndWord_7.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_7.Location = New System.Drawing.Point(400, 24)
        Me._chk2ndWord_7.Name = "_chk2ndWord_7"
        Me._chk2ndWord_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_7.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_7.TabIndex = 28
        Me._chk2ndWord_7.Text = "23"
        Me._chk2ndWord_7.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_8
        '
        Me._chk2ndWord_8.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_8.Location = New System.Drawing.Point(16, 48)
        Me._chk2ndWord_8.Name = "_chk2ndWord_8"
        Me._chk2ndWord_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_8.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_8.TabIndex = 27
        Me._chk2ndWord_8.Text = "24"
        Me._chk2ndWord_8.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_9
        '
        Me._chk2ndWord_9.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_9.Location = New System.Drawing.Point(72, 48)
        Me._chk2ndWord_9.Name = "_chk2ndWord_9"
        Me._chk2ndWord_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_9.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_9.TabIndex = 26
        Me._chk2ndWord_9.Text = "25"
        Me._chk2ndWord_9.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_10
        '
        Me._chk2ndWord_10.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_10.Location = New System.Drawing.Point(128, 48)
        Me._chk2ndWord_10.Name = "_chk2ndWord_10"
        Me._chk2ndWord_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_10.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_10.TabIndex = 25
        Me._chk2ndWord_10.Text = "26"
        Me._chk2ndWord_10.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_11
        '
        Me._chk2ndWord_11.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_11.Location = New System.Drawing.Point(176, 48)
        Me._chk2ndWord_11.Name = "_chk2ndWord_11"
        Me._chk2ndWord_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_11.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_11.TabIndex = 24
        Me._chk2ndWord_11.Text = "27"
        Me._chk2ndWord_11.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_12
        '
        Me._chk2ndWord_12.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_12.Location = New System.Drawing.Point(232, 48)
        Me._chk2ndWord_12.Name = "_chk2ndWord_12"
        Me._chk2ndWord_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_12.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_12.TabIndex = 23
        Me._chk2ndWord_12.Text = "28"
        Me._chk2ndWord_12.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_13
        '
        Me._chk2ndWord_13.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_13.Location = New System.Drawing.Point(288, 48)
        Me._chk2ndWord_13.Name = "_chk2ndWord_13"
        Me._chk2ndWord_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_13.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_13.TabIndex = 22
        Me._chk2ndWord_13.Text = "29"
        Me._chk2ndWord_13.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_14
        '
        Me._chk2ndWord_14.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_14.Location = New System.Drawing.Point(344, 48)
        Me._chk2ndWord_14.Name = "_chk2ndWord_14"
        Me._chk2ndWord_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_14.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_14.TabIndex = 21
        Me._chk2ndWord_14.Text = "30"
        Me._chk2ndWord_14.UseVisualStyleBackColor = False
        '
        '_chk2ndWord_15
        '
        Me._chk2ndWord_15.BackColor = System.Drawing.SystemColors.Control
        Me._chk2ndWord_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk2ndWord_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk2ndWord_15.Location = New System.Drawing.Point(400, 48)
        Me._chk2ndWord_15.Name = "_chk2ndWord_15"
        Me._chk2ndWord_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk2ndWord_15.Size = New System.Drawing.Size(41, 17)
        Me._chk2ndWord_15.TabIndex = 20
        Me._chk2ndWord_15.Text = "31"
        Me._chk2ndWord_15.UseVisualStyleBackColor = False
        '
        'Fra1stWord
        '
        Me.Fra1stWord.BackColor = System.Drawing.SystemColors.Control
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_0)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_1)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_2)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_3)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_4)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_5)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_6)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_7)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_8)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_9)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_10)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_11)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_12)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_13)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_14)
        Me.Fra1stWord.Controls.Add(Me._chk1stWord_15)
        Me.Fra1stWord.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Fra1stWord.Location = New System.Drawing.Point(23, 98)
        Me.Fra1stWord.Name = "Fra1stWord"
        Me.Fra1stWord.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Fra1stWord.Size = New System.Drawing.Size(449, 73)
        Me.Fra1stWord.TabIndex = 44
        Me.Fra1stWord.TabStop = False
        Me.Fra1stWord.Text = "Frame1"
        '
        '_chk1stWord_0
        '
        Me._chk1stWord_0.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_0.Location = New System.Drawing.Point(16, 24)
        Me._chk1stWord_0.Name = "_chk1stWord_0"
        Me._chk1stWord_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_0.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_0.TabIndex = 18
        Me._chk1stWord_0.Text = "00"
        Me._chk1stWord_0.UseVisualStyleBackColor = False
        '
        '_chk1stWord_1
        '
        Me._chk1stWord_1.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_1.Location = New System.Drawing.Point(72, 24)
        Me._chk1stWord_1.Name = "_chk1stWord_1"
        Me._chk1stWord_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_1.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_1.TabIndex = 17
        Me._chk1stWord_1.Text = "01"
        Me._chk1stWord_1.UseVisualStyleBackColor = False
        '
        '_chk1stWord_2
        '
        Me._chk1stWord_2.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_2.Location = New System.Drawing.Point(128, 24)
        Me._chk1stWord_2.Name = "_chk1stWord_2"
        Me._chk1stWord_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_2.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_2.TabIndex = 16
        Me._chk1stWord_2.Text = "02"
        Me._chk1stWord_2.UseVisualStyleBackColor = False
        '
        '_chk1stWord_3
        '
        Me._chk1stWord_3.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_3.Location = New System.Drawing.Point(176, 24)
        Me._chk1stWord_3.Name = "_chk1stWord_3"
        Me._chk1stWord_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_3.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_3.TabIndex = 15
        Me._chk1stWord_3.Text = "03"
        Me._chk1stWord_3.UseVisualStyleBackColor = False
        '
        '_chk1stWord_4
        '
        Me._chk1stWord_4.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_4.Location = New System.Drawing.Point(232, 24)
        Me._chk1stWord_4.Name = "_chk1stWord_4"
        Me._chk1stWord_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_4.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_4.TabIndex = 14
        Me._chk1stWord_4.Text = "04"
        Me._chk1stWord_4.UseVisualStyleBackColor = False
        '
        '_chk1stWord_5
        '
        Me._chk1stWord_5.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_5.Location = New System.Drawing.Point(288, 24)
        Me._chk1stWord_5.Name = "_chk1stWord_5"
        Me._chk1stWord_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_5.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_5.TabIndex = 13
        Me._chk1stWord_5.Text = "05"
        Me._chk1stWord_5.UseVisualStyleBackColor = False
        '
        '_chk1stWord_6
        '
        Me._chk1stWord_6.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_6.Location = New System.Drawing.Point(344, 24)
        Me._chk1stWord_6.Name = "_chk1stWord_6"
        Me._chk1stWord_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_6.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_6.TabIndex = 12
        Me._chk1stWord_6.Text = "06"
        Me._chk1stWord_6.UseVisualStyleBackColor = False
        '
        '_chk1stWord_7
        '
        Me._chk1stWord_7.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_7.Location = New System.Drawing.Point(400, 24)
        Me._chk1stWord_7.Name = "_chk1stWord_7"
        Me._chk1stWord_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_7.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_7.TabIndex = 11
        Me._chk1stWord_7.Text = "07"
        Me._chk1stWord_7.UseVisualStyleBackColor = False
        '
        '_chk1stWord_8
        '
        Me._chk1stWord_8.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_8.Location = New System.Drawing.Point(16, 48)
        Me._chk1stWord_8.Name = "_chk1stWord_8"
        Me._chk1stWord_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_8.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_8.TabIndex = 10
        Me._chk1stWord_8.Text = "08"
        Me._chk1stWord_8.UseVisualStyleBackColor = False
        '
        '_chk1stWord_9
        '
        Me._chk1stWord_9.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_9.Location = New System.Drawing.Point(72, 48)
        Me._chk1stWord_9.Name = "_chk1stWord_9"
        Me._chk1stWord_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_9.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_9.TabIndex = 9
        Me._chk1stWord_9.Text = "09"
        Me._chk1stWord_9.UseVisualStyleBackColor = False
        '
        '_chk1stWord_10
        '
        Me._chk1stWord_10.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_10.Location = New System.Drawing.Point(128, 48)
        Me._chk1stWord_10.Name = "_chk1stWord_10"
        Me._chk1stWord_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_10.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_10.TabIndex = 8
        Me._chk1stWord_10.Text = "10"
        Me._chk1stWord_10.UseVisualStyleBackColor = False
        '
        '_chk1stWord_11
        '
        Me._chk1stWord_11.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_11.Location = New System.Drawing.Point(176, 48)
        Me._chk1stWord_11.Name = "_chk1stWord_11"
        Me._chk1stWord_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_11.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_11.TabIndex = 7
        Me._chk1stWord_11.Text = "11"
        Me._chk1stWord_11.UseVisualStyleBackColor = False
        '
        '_chk1stWord_12
        '
        Me._chk1stWord_12.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_12.Location = New System.Drawing.Point(232, 48)
        Me._chk1stWord_12.Name = "_chk1stWord_12"
        Me._chk1stWord_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_12.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_12.TabIndex = 6
        Me._chk1stWord_12.Text = "12"
        Me._chk1stWord_12.UseVisualStyleBackColor = False
        '
        '_chk1stWord_13
        '
        Me._chk1stWord_13.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_13.Location = New System.Drawing.Point(288, 48)
        Me._chk1stWord_13.Name = "_chk1stWord_13"
        Me._chk1stWord_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_13.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_13.TabIndex = 5
        Me._chk1stWord_13.Text = "13"
        Me._chk1stWord_13.UseVisualStyleBackColor = False
        '
        '_chk1stWord_14
        '
        Me._chk1stWord_14.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_14.Location = New System.Drawing.Point(344, 48)
        Me._chk1stWord_14.Name = "_chk1stWord_14"
        Me._chk1stWord_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_14.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_14.TabIndex = 4
        Me._chk1stWord_14.Text = "14"
        Me._chk1stWord_14.UseVisualStyleBackColor = False
        '
        '_chk1stWord_15
        '
        Me._chk1stWord_15.BackColor = System.Drawing.SystemColors.Control
        Me._chk1stWord_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._chk1stWord_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._chk1stWord_15.Location = New System.Drawing.Point(400, 48)
        Me._chk1stWord_15.Name = "_chk1stWord_15"
        Me._chk1stWord_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._chk1stWord_15.Size = New System.Drawing.Size(41, 17)
        Me._chk1stWord_15.TabIndex = 3
        Me._chk1stWord_15.Text = "15"
        Me._chk1stWord_15.UseVisualStyleBackColor = False
        '
        'cobModule
        '
        Me.cobModule.BackColor = System.Drawing.SystemColors.Window
        Me.cobModule.Cursor = System.Windows.Forms.Cursors.Default
        Me.cobModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobModule.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cobModule.Location = New System.Drawing.Point(199, 23)
        Me.cobModule.Name = "cobModule"
        Me.cobModule.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cobModule.Size = New System.Drawing.Size(273, 20)
        Me.cobModule.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(161, 17)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "[Bo.No.:Mo.No.] Mo.ID"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'frmDigitalIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 494)
        Me.Controls.Add(Me.chkInterrupt)
        Me.Controls.Add(Me.chkFalling)
        Me.Controls.Add(Me.chkRising)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.cmdListClear)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Fra2ndWord)
        Me.Controls.Add(Me.Fra1stWord)
        Me.Controls.Add(Me.cobModule)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDigitalIO"
        Me.Text = "frmEmpty"
        Me.Fra2ndWord.ResumeLayout(False)
        Me.Fra1stWord.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents chkInterrupt As System.Windows.Forms.CheckBox
    Public WithEvents chkFalling As System.Windows.Forms.CheckBox
    Public WithEvents chkRising As System.Windows.Forms.CheckBox
    Public WithEvents List1 As System.Windows.Forms.ListBox
    Public WithEvents cmdListClear As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Fra2ndWord As System.Windows.Forms.GroupBox
    Public WithEvents _chk2ndWord_0 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_1 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_2 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_3 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_4 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_5 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_6 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_7 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_8 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_9 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_10 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_11 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_12 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_13 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_14 As System.Windows.Forms.CheckBox
    Public WithEvents _chk2ndWord_15 As System.Windows.Forms.CheckBox
    Public WithEvents Fra1stWord As System.Windows.Forms.GroupBox
    Public WithEvents _chk1stWord_0 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_1 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_2 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_3 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_4 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_5 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_6 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_7 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_8 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_9 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_10 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_11 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_12 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_13 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_14 As System.Windows.Forms.CheckBox
    Public WithEvents _chk1stWord_15 As System.Windows.Forms.CheckBox
    Public WithEvents cobModule As System.Windows.Forms.ComboBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Timer1 As System.Windows.Forms.Timer

End Class
