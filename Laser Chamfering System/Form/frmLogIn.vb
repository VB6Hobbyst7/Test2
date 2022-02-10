Public Class frmLogIn

    Dim m_strLogInUser As String = ""
    Dim m_strLogInTech As String = ""
    Dim m_strLogInAdmin As String = ""
    '로그인 보안 20181211
    Dim AdminCheck1 As Boolean = False
    Dim AdminCheck2 As Boolean = False

    Private Sub BtnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogIn.Click

        Dim strUser As String = ""
        Dim strPassward As String = ""
        '20181210 현재 "시간분월일(HHmmMMdd)" 비밀번호로 사용
        Dim strNowDatePassward As String = ""
        strNowDatePassward = Format(Now, "HHmmMMdd")

        strUser = ComBoxUser.Text
        strPassward = TextPassward.Text


        If strUser = "User" Then   'User
            If strPassward = m_strLogInUser Then
                bLogInUser = True
                bModelRecipe = True
                '20181207 로그인 로그
                modPub.SystemLog("frmLogIn -- #User Login#")
            Else
                lalLog.Text = "Passward가 틀렸습니다."
            End If

        ElseIf strUser = "Tech" Then   'Tech
            If strPassward = m_strLogInTech Then
                bLogInTech = True
                bModelRecipe = True
                '20181207 로그인 로그
                modPub.SystemLog("frmLogIn -- #Tech Login#")
                '20190801
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LOGIN_TECH, True)
                'pLDLT.PC_Infomation.bPC = True
            Else
                lalLog.Text = "Passward가 틀렸습니다."
            End If
       
        ElseIf strUser = "Admin" Then   'Admin
            If strPassward = m_strLogInAdmin Then
                bLogInAdmin = True
                bModelRecipe = True
                '20181207 로그인 로그
                modPub.SystemLog("frmLogIn -- #admin Login#")
                '20181208 admin login
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LOGIN_ADMIN, True)
                pLDLT.PC_Infomation.bPC_AdminLogin = True
                lbGreenLight.BackColor = Color.MediumSlateBlue
            Else
                lalLog.Text = "Passward가 틀렸습니다."
            End If

        End If

        If bLogInUser Or bLogInTech Or bLogInAdmin Then
            Close()
        End If

    End Sub

    Private Sub BtnPasswardChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPasswardChange.Click

        lblPasswardOld.Show()
        lblPasswardNew.Show()
        lblPass.Show()
        TextPasswardOld.Show()
        TextPasswardNew.Show()
        BtnPasswardChangeOK.Show()

    End Sub

    Private Sub LogIn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error GoTo SysErr

        'frmLogIn.MdiParent = Me
        'Me.Show()
        'Return

        Exit Sub
SysErr:
    End Sub

    Private Sub BtnPasswardChangeOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPasswardChangeOK.Click

        Dim strUser As String = ""
        Dim strPasswardOld As String = ""
        Dim strPasswardNew As String = ""

        Dim bRtn As Boolean = False

        strUser = ComBoxUser.Text
        strPasswardOld = TextPasswardOld.Text
        strPasswardNew = TextPasswardNew.Text

        If strUser = "User" Then   'User

            If strPasswardOld = m_strLogInUser Then

                Utility.WriteRegistry("LogIn_User", strPasswardNew)
                bRtn = True
                '20181207 로그인 로그
                modPub.SystemLog("frmLogIn -- User Password Change")

            Else
                lalLog.Text = "기존 Passward가 틀렸습니다."
            End If

        ElseIf strUser = "Tech" Then   'Tech
            If strPasswardOld = m_strLogInTech Then

                Utility.WriteRegistry("LogIn_Tech", strPasswardNew)
                bRtn = True
                '20181207 로그인 로그
                modPub.SystemLog("frmLogIn -- Tech Password Change")

            Else
                lalLog.Text = "기존 Passward가 틀렸습니다."
            End If

        ElseIf strUser = "Admin" Then   'Admin
            If strPasswardOld = m_strLogInAdmin Then

                Utility.WriteRegistry("LogIn_Admin", strPasswardNew)
                bRtn = True
                '20181207 로그인 로그
                modPub.SystemLog("frmLogIn -- admin Password Change")

            Else
                lalLog.Text = "기존 Passward가 틀렸습니다."
            End If

        End If

        If bRtn = True Then

            frmMSG.ShowMsg("비밀번호 변경", "비밀번호가 변경 되었습니다.", False, 1)

            m_strLogInUser = Utility.ReadRegistry("LogIn_User")
            m_strLogInTech = Utility.ReadRegistry("LogIn_Tech")
            m_strLogInAdmin = Utility.ReadRegistry("LogIn_Admin")

            lblPasswardOld.Hide()
            lblPasswardNew.Hide()
            lblPass.Hide()
            TextPasswardOld.Hide()
            TextPasswardNew.Hide()
            BtnPasswardChangeOK.Hide()

        End If

        

    End Sub


    Private Sub LogIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo SysErr
        lblVersion.Text = modParam.pCurSystemParam.strVersion
        'GYN - 처음 프로그램 구동하는 PC에서는 아래 주석 풀고 비번 입력후 실행바랍니다.
        'WriteRegistry("LogIn_User", "1234")
        'WriteRegistry("LogIn_Tech", "12345")
        'WriteRegistry("LogIn_Admin", "123456")


        'Passward를 불러오자.
        m_strLogInUser = Utility.ReadRegistry("LogIn_User")
        m_strLogInTech = Utility.ReadRegistry("LogIn_Tech")
        m_strLogInAdmin = Utility.ReadRegistry("LogIn_Admin")


        lblPasswardOld.Hide()
        lblPasswardNew.Hide()
        lblPass.Hide()
        TextPasswardOld.Hide()
        TextPasswardNew.Hide()
        BtnPasswardChangeOK.Hide()

        Exit Sub
SysErr:

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        Dim strFileName As String = ""
        '엑셀 실행되어서 파일 열기 되도록 수정.
        strFileName = OpenFileDialog1.FileName()

        'Me.Cursor = New Cursor(OpenFileDialog1.OpenFile())
        Process.Start(strFileName)

    End Sub

    Private Sub BtnOpenFileDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpenFileDialog.Click

        OpenFileDialog1.ShowDialog()
       
    End Sub

    Private Sub cbPasswardChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPasswardChange.CheckedChanged

        Dim bRtn As Boolean

        bRtn = cbPasswardChange.Checked

        If bRtn = True Then

            lblPasswardOld.Show()
            lblPasswardNew.Show()
            lblPass.Show()
            TextPasswardOld.Show()
            TextPasswardNew.Show()
            BtnPasswardChangeOK.Show()

        Else

            lblPasswardOld.Hide()
            lblPasswardNew.Hide()
            lblPass.Hide()
            TextPasswardOld.Hide()
            TextPasswardNew.Hide()
            BtnPasswardChangeOK.Hide()

        End If

    End Sub

    Public Sub Form_Label2()
        With Me

            .lalPassward.Text = My.Resources.setLan.ResourceManager.GetObject("Password")

            '.lalUser.Text = My.Resources.setLan.ResourceManager.GetObject("사용자")
            '.lalLog.Text = My.Resources.setLan.ResourceManager.GetObject("비밀번호변경전0입니다")
            '.lblPass.Text = My.Resources.setLan.ResourceManager.GetObject("비밀번호변경")
            '.lblPasswardOld.Text = My.Resources.setLan.ResourceManager.GetObject("기존비밀번호")
            '.lblPasswardNew.Text = My.Resources.setLan.ResourceManager.GetObject("신규비밀번호")
            '.BtnLogIn.Text = My.Resources.setLan.ResourceManager.GetObject("로그인")
            '.BtnPasswardChange.Text = My.Resources.setLan.ResourceManager.GetObject("비밀번호변경")
            '.BtnPasswardChangeOK.Text = My.Resources.setLan.ResourceManager.GetObject("확인")
            '.BtnOpenFileDialog.Text = My.Resources.setLan.ResourceManager.GetObject("열기")
            '.cbPasswardChange.Text = My.Resources.setLan.ResourceManager.GetObject("비밀번호변경")
            '.Label1.Text = My.Resources.setLan.ResourceManager.GetObject("ProgramVersion")
            ''.lblVersion.Text = My.Resources.setLan.ResourceManager.GetObject("ver3020170319")
            '.Label3.Text = My.Resources.setLan.ResourceManager.GetObject("을확인하세요")
            '.Label4.Text = My.Resources.setLan.ResourceManager.GetObject("업데이트내역")
            '.Label5.Text = My.Resources.setLan.ResourceManager.GetObject("바탕화면에")
            '.Label6.Text = My.Resources.setLan.ResourceManager.GetObject("파일을확인하세요")

        End With
    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .lalPassward.Text = My.Resources.setLan.ResourceManager.GetObject("Password")

            .lalUser.Text = My.Resources.setLan.ResourceManager.GetObject("User")
            .lalLog.Text = My.Resources.setLan.ResourceManager.GetObject("Defult0")
            .lblPass.Text = My.Resources.setLan.ResourceManager.GetObject("ChangePassword")
            .lblPasswardOld.Text = My.Resources.setLan.ResourceManager.GetObject("ExistingPassword")
            .lblPasswardNew.Text = My.Resources.setLan.ResourceManager.GetObject("NewPasswodr")
            .BtnLogIn.Text = My.Resources.setLan.ResourceManager.GetObject("Login")
            .BtnPasswardChange.Text = My.Resources.setLan.ResourceManager.GetObject("ChangePassword")
            .BtnPasswardChangeOK.Text = My.Resources.setLan.ResourceManager.GetObject("OK")

            .BtnOpenFileDialog.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .cbPasswardChange.Text = My.Resources.setLan.ResourceManager.GetObject("ChangePassword")
            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("ProgramVersion")
            .lblVersion.Text = My.Resources.setLan.ResourceManager.GetObject("ver3020170319")

            .Label3.Text = My.Resources.setLan.ResourceManager.GetObject("check")

            .Label4.Text = My.Resources.setLan.ResourceManager.GetObject("Updatacontants")
            .Label5.Text = My.Resources.setLan.ResourceManager.GetObject("indesktop")
            .Label6.Text = My.Resources.setLan.ResourceManager.GetObject("checkfile")
        End With

    End Sub
    '로그인 보안 - 김영수 주임
    Private Sub btnAdminAble_Click(sender As System.Object, e As System.EventArgs) Handles btnAdminAble.Click
        AdminCheck1 = True
        If AdminCheck2 = True Then
            lbGreenLight.BackColor = Color.LightGreen
        End If
        SystemLog("Secret Admin Button Click")
    End Sub

    Private Sub btnAdminAble2_Click(sender As System.Object, e As System.EventArgs) Handles btnAdminAble2.Click
        AdminCheck2 = True
        If AdminCheck1 = True Then
            lbGreenLight.BackColor = Color.LightGreen
        End If
        SystemLog("Secret Admin Button Click")
    End Sub
End Class