<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogIn
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
        Me.BtnLogIn = New System.Windows.Forms.Button()
        Me.TextPassward = New System.Windows.Forms.TextBox()
        Me.lalPassward = New System.Windows.Forms.Label()
        Me.lalUser = New System.Windows.Forms.Label()
        Me.ComBoxUser = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnPasswardChange = New System.Windows.Forms.Button()
        Me.lalLog = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextPasswardOld = New System.Windows.Forms.TextBox()
        Me.TextPasswardNew = New System.Windows.Forms.TextBox()
        Me.BtnPasswardChangeOK = New System.Windows.Forms.Button()
        Me.lblPasswardOld = New System.Windows.Forms.Label()
        Me.lblPasswardNew = New System.Windows.Forms.Label()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BtnOpenFileDialog = New System.Windows.Forms.Button()
        Me.cbPasswardChange = New System.Windows.Forms.CheckBox()
        Me.btnAdminAble = New System.Windows.Forms.Button()
        Me.lbGreenLight = New System.Windows.Forms.Label()
        Me.btnAdminAble2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnLogIn
        '
        Me.BtnLogIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnLogIn.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnLogIn.Location = New System.Drawing.Point(369, 105)
        Me.BtnLogIn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnLogIn.Name = "BtnLogIn"
        Me.BtnLogIn.Size = New System.Drawing.Size(107, 109)
        Me.BtnLogIn.TabIndex = 0
        Me.BtnLogIn.Text = "Login"
        Me.BtnLogIn.UseVisualStyleBackColor = False
        '
        'TextPassward
        '
        Me.TextPassward.Location = New System.Drawing.Point(156, 141)
        Me.TextPassward.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextPassward.Name = "TextPassward"
        Me.TextPassward.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPassward.Size = New System.Drawing.Size(201, 29)
        Me.TextPassward.TabIndex = 1
        Me.TextPassward.UseSystemPasswordChar = True
        '
        'lalPassward
        '
        Me.lalPassward.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lalPassward.Location = New System.Drawing.Point(32, 145)
        Me.lalPassward.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lalPassward.Name = "lalPassward"
        Me.lalPassward.Size = New System.Drawing.Size(102, 21)
        Me.lalPassward.TabIndex = 2
        Me.lalPassward.Text = "PASSWORD"
        '
        'lalUser
        '
        Me.lalUser.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lalUser.Location = New System.Drawing.Point(36, 109)
        Me.lalUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lalUser.Name = "lalUser"
        Me.lalUser.Size = New System.Drawing.Size(82, 21)
        Me.lalUser.TabIndex = 4
        Me.lalUser.Text = "USER"
        '
        'ComBoxUser
        '
        Me.ComBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComBoxUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComBoxUser.FormattingEnabled = True
        Me.ComBoxUser.Items.AddRange(New Object() {"User", "Tech", "Admin"})
        Me.ComBoxUser.Location = New System.Drawing.Point(156, 105)
        Me.ComBoxUser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComBoxUser.Name = "ComBoxUser"
        Me.ComBoxUser.Size = New System.Drawing.Size(201, 29)
        Me.ComBoxUser.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 21)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Program Version"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.White
        Me.lblVersion.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Red
        Me.lblVersion.Location = New System.Drawing.Point(188, 20)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(169, 25)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "ver 3.0_20170319"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(404, 20)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 21)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Please Check"
        '
        'BtnPasswardChange
        '
        Me.BtnPasswardChange.Enabled = False
        Me.BtnPasswardChange.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnPasswardChange.Location = New System.Drawing.Point(483, 172)
        Me.BtnPasswardChange.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnPasswardChange.Name = "BtnPasswardChange"
        Me.BtnPasswardChange.Size = New System.Drawing.Size(48, 42)
        Me.BtnPasswardChange.TabIndex = 9
        Me.BtnPasswardChange.Text = "--"
        Me.BtnPasswardChange.UseVisualStyleBackColor = True
        Me.BtnPasswardChange.Visible = False
        '
        'lalLog
        '
        Me.lalLog.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lalLog.ForeColor = System.Drawing.Color.Red
        Me.lalLog.Location = New System.Drawing.Point(28, 220)
        Me.lalLog.Name = "lalLog"
        Me.lalLog.Size = New System.Drawing.Size(494, 24)
        Me.lalLog.TabIndex = 10
        Me.lalLog.Text = "It is '0' before password change."
        Me.lalLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(116, 55)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 37)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Update History"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 60)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 21)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Wallpapers"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(284, 60)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(180, 21)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Please check the file."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextPasswardOld
        '
        Me.TextPasswardOld.Location = New System.Drawing.Point(156, 296)
        Me.TextPasswardOld.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextPasswardOld.Name = "TextPasswardOld"
        Me.TextPasswardOld.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPasswardOld.Size = New System.Drawing.Size(201, 29)
        Me.TextPasswardOld.TabIndex = 14
        Me.TextPasswardOld.UseSystemPasswordChar = True
        '
        'TextPasswardNew
        '
        Me.TextPasswardNew.Location = New System.Drawing.Point(156, 330)
        Me.TextPasswardNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextPasswardNew.Name = "TextPasswardNew"
        Me.TextPasswardNew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPasswardNew.Size = New System.Drawing.Size(201, 29)
        Me.TextPasswardNew.TabIndex = 15
        Me.TextPasswardNew.UseSystemPasswordChar = True
        '
        'BtnPasswardChangeOK
        '
        Me.BtnPasswardChangeOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnPasswardChangeOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnPasswardChangeOK.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.BtnPasswardChangeOK.Location = New System.Drawing.Point(369, 296)
        Me.BtnPasswardChangeOK.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BtnPasswardChangeOK.Name = "BtnPasswardChangeOK"
        Me.BtnPasswardChangeOK.Size = New System.Drawing.Size(107, 63)
        Me.BtnPasswardChangeOK.TabIndex = 16
        Me.BtnPasswardChangeOK.Text = "Apply"
        Me.BtnPasswardChangeOK.UseVisualStyleBackColor = False
        '
        'lblPasswardOld
        '
        Me.lblPasswardOld.AutoSize = True
        Me.lblPasswardOld.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPasswardOld.Location = New System.Drawing.Point(32, 300)
        Me.lblPasswardOld.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPasswardOld.Name = "lblPasswardOld"
        Me.lblPasswardOld.Size = New System.Drawing.Size(79, 21)
        Me.lblPasswardOld.TabIndex = 17
        Me.lblPasswardOld.Text = "Password"
        Me.lblPasswardOld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPasswardNew
        '
        Me.lblPasswardNew.AutoSize = True
        Me.lblPasswardNew.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPasswardNew.Location = New System.Drawing.Point(32, 333)
        Me.lblPasswardNew.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPasswardNew.Name = "lblPasswardNew"
        Me.lblPasswardNew.Size = New System.Drawing.Size(118, 21)
        Me.lblPasswardNew.TabIndex = 18
        Me.lblPasswardNew.Text = "New Password"
        Me.lblPasswardNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPass
        '
        Me.lblPass.BackColor = System.Drawing.Color.White
        Me.lblPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPass.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPass.Location = New System.Drawing.Point(36, 250)
        Me.lblPass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(440, 32)
        Me.lblPass.TabIndex = 19
        Me.lblPass.Text = "Password Change"
        Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.InitialDirectory = "C:\"
        '
        'BtnOpenFileDialog
        '
        Me.BtnOpenFileDialog.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnOpenFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOpenFileDialog.Location = New System.Drawing.Point(469, 55)
        Me.BtnOpenFileDialog.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnOpenFileDialog.Name = "BtnOpenFileDialog"
        Me.BtnOpenFileDialog.Size = New System.Drawing.Size(66, 37)
        Me.BtnOpenFileDialog.TabIndex = 20
        Me.BtnOpenFileDialog.Text = "Open"
        Me.BtnOpenFileDialog.UseVisualStyleBackColor = False
        '
        'cbPasswardChange
        '
        Me.cbPasswardChange.Appearance = System.Windows.Forms.Appearance.Button
        Me.cbPasswardChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cbPasswardChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbPasswardChange.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbPasswardChange.Location = New System.Drawing.Point(156, 179)
        Me.cbPasswardChange.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbPasswardChange.Name = "cbPasswardChange"
        Me.cbPasswardChange.Size = New System.Drawing.Size(201, 35)
        Me.cbPasswardChange.TabIndex = 21
        Me.cbPasswardChange.Text = "Passward Change"
        Me.cbPasswardChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cbPasswardChange.UseVisualStyleBackColor = False
        '
        'btnAdminAble
        '
        Me.btnAdminAble.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdminAble.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble.Location = New System.Drawing.Point(1, 346)
        Me.btnAdminAble.Name = "btnAdminAble"
        Me.btnAdminAble.Size = New System.Drawing.Size(20, 23)
        Me.btnAdminAble.TabIndex = 22
        Me.btnAdminAble.TabStop = False
        Me.btnAdminAble.UseVisualStyleBackColor = True
        '
        'lbGreenLight
        '
        Me.lbGreenLight.AutoSize = True
        Me.lbGreenLight.Font = New System.Drawing.Font("맑은 고딕", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbGreenLight.Location = New System.Drawing.Point(544, 2)
        Me.lbGreenLight.Name = "lbGreenLight"
        Me.lbGreenLight.Size = New System.Drawing.Size(11, 13)
        Me.lbGreenLight.TabIndex = 23
        Me.lbGreenLight.Text = " "
        '
        'btnAdminAble2
        '
        Me.btnAdminAble2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdminAble2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdminAble2.Location = New System.Drawing.Point(537, 346)
        Me.btnAdminAble2.Name = "btnAdminAble2"
        Me.btnAdminAble2.Size = New System.Drawing.Size(20, 23)
        Me.btnAdminAble2.TabIndex = 24
        Me.btnAdminAble2.UseVisualStyleBackColor = True
        '
        'frmLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(558, 370)
        Me.Controls.Add(Me.btnAdminAble2)
        Me.Controls.Add(Me.lbGreenLight)
        Me.Controls.Add(Me.btnAdminAble)
        Me.Controls.Add(Me.cbPasswardChange)
        Me.Controls.Add(Me.BtnOpenFileDialog)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblPasswardNew)
        Me.Controls.Add(Me.lblPasswardOld)
        Me.Controls.Add(Me.BtnPasswardChangeOK)
        Me.Controls.Add(Me.TextPasswardNew)
        Me.Controls.Add(Me.TextPasswardOld)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lalLog)
        Me.Controls.Add(Me.BtnPasswardChange)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComBoxUser)
        Me.Controls.Add(Me.lalUser)
        Me.Controls.Add(Me.lalPassward)
        Me.Controls.Add(Me.TextPassward)
        Me.Controls.Add(Me.BtnLogIn)
        Me.Font = New System.Drawing.Font("맑은 고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ForeColor = System.Drawing.Color.Blue
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmLogIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLogIn"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnLogIn As System.Windows.Forms.Button
    Friend WithEvents TextPassward As System.Windows.Forms.TextBox
    Friend WithEvents lalPassward As System.Windows.Forms.Label
    Friend WithEvents lalUser As System.Windows.Forms.Label
    Friend WithEvents ComBoxUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnPasswardChange As System.Windows.Forms.Button
    Friend WithEvents lalLog As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextPasswardOld As System.Windows.Forms.TextBox
    Friend WithEvents TextPasswardNew As System.Windows.Forms.TextBox
    Friend WithEvents BtnPasswardChangeOK As System.Windows.Forms.Button
    Friend WithEvents lblPasswardOld As System.Windows.Forms.Label
    Friend WithEvents lblPasswardNew As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BtnOpenFileDialog As System.Windows.Forms.Button
    Friend WithEvents cbPasswardChange As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdminAble As System.Windows.Forms.Button
    Friend WithEvents lbGreenLight As System.Windows.Forms.Label
    Friend WithEvents btnAdminAble2 As System.Windows.Forms.Button
End Class
