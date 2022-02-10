Public Class ctrlDisplace
    Dim bUsePC As Boolean = False

    Public m_ctrlPcBitdata As New ctrlPcBitdata
    Public m_ctrlPlcBitdata As New ctrlPlcBitdata
    Public m_ctrlLine(1, 3) As ctrlDisplacePart

    Public m_bAline As Integer

    Private m_nSelBlockInx As Integer = 0

    Dim m_TimeSeq As New Stopwatch

    Public dp_nPannel As Integer = 0
    Dim strPositionName() As String
    Dim bBtnClickLeft As Boolean = False
    Dim bBtnClickRight As Boolean = False
    Dim bBtnClickTop As Boolean = False
    Dim bBtnClickMain As Boolean = False
    Dim m_displace_value() As Label
    Dim strLabelName() As String

    Public Sub New()
        '    ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        '    ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        For t = 0 To 1
            For p = 0 To 3

                m_ctrlLine(t, p) = New ctrlDisplacePart(t, p)
                tabPanel.TabPages(p).Controls.Add(m_ctrlLine(t, p))

                m_ctrlLine(t, p).Visible = True
            Next
        Next

        ReDim m_displace_value(15)
        ReDim strLabelName(15)
        ReDim strPositionName(3)
        ReDim pbSelectposition(3)

        m_displace_value = {Left_Scrap1, Left_Scrap2, Left_Scrap3, Top_Scrap1, Top_Scrap2, Top_Scrap3, Right_Scrap1, Right_Scrap2, Right_Scrap3, Main_Chuck1, Main_Chuck2, Main_Chuck3, Main_Chuck4, Main_Chuck5, Main_Chuck6, Main_Chuck7}
        strLabelName = {"Left1", "Left2", "Left3", "Top1", "Top2", "Top3", "Right1", "Right2", "Right3", "Main1", "Main2", "Main3", "Main4", "Main5", "Main6", "Main7"}
        strPositionName = {"LEFT", "TOP", "RIGHT", "MAIN"}
    End Sub

#Region "UIEvent"
    Private Sub btnSetALine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetALine.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmSetting - btnDisplace A-Line Click")

        m_bAline = 0
        dp_strLine = "A"

        For p = 0 To 3
            tabPanel.TabPages(p).Controls.Remove(m_ctrlLine(1, p))

            'm_ctrlLine(m_bAline, p) = New ctrlDisplacePart(m_bAline, p)
            tabPanel.TabPages(p).Controls.Add(m_ctrlLine(m_bAline, p))

            m_ctrlLine(m_bAline, p).Visible = True

            If m_nSelBlockInx <> -1 Then
                m_ctrlLine(m_bAline, p).m_nSelBlock = m_nSelBlockInx
            End If
        Next

        btnSetALine.BackColor = Color.Lime
        btnSetBLine.BackColor = Color.White

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnDisplace A-Line Click")
    End Sub

    Private Sub btnSetBLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBLine.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmSetting - btnDisplace B-Line Click")

        m_bAline = 1
        dp_strLine = "B"

        For p = 0 To 3
            tabPanel.TabPages(p).Controls.Remove(m_ctrlLine(0, p))

            'm_ctrlLine(m_bAline, p) = New ctrlDisplacePart(m_bAline, p)
            tabPanel.TabPages(p).Controls.Add(m_ctrlLine(m_bAline, p))

            m_ctrlLine(m_bAline, p).Visible = True

            If m_nSelBlockInx <> -1 Then
                m_ctrlLine(m_bAline, p).m_nSelBlock = m_nSelBlockInx
            End If
        Next

        btnSetALine.BackColor = Color.White
        btnSetBLine.BackColor = Color.Lime

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnDisplace B-Line Click")
    End Sub

   
    Private Sub BtnComMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnComMode.Click, BtnSettingMode.Click, BtnZeroSet.Click, BtnZeroRelease.Click
        Dim isOk As Boolean = False
        TxtRunState.Text = "READY"
        System.Threading.Thread.Sleep(1000)
        Select Case sender.tag
            Case 0
                modPub.SystemLog("frmSetting - Displace : BtnComMode_Click")
                isOk = pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_COM)

            Case 1
                modPub.SystemLog("frmSetting - Displace : BtnSettingMode_Click")
                isOk = pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_SETTING)

            Case 2
                modPub.SystemLog("frmSetting - Displace : BtnZeroSet_Click")
                isOk = pDisplace.SendCmd(clsDisplace.SetCmd.SET_ZERO_POINT)

            Case 3
                modPub.SystemLog("frmSetting - Displace : BtnZeroRelease_Click")
                isOk = pDisplace.SendCmd(clsDisplace.SetCmd.SET_ZERO_RELEASE)
        End Select

        If isOk = False Then
            TxtRunState.Text = "통신 연결 안됨.."
        Else
            TxtRunState.Text = "송신 완료"
        End If
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnDisplace B-Line Click")

    End Sub

    Private Sub BtnMeasureOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMeasureOne.Click
        On Error GoTo SysErr

        Dim isOk As Boolean = False
        TxtRunState.Text = "-"
        modPub.SystemLog("frmSetting - Displace : BtnMeasureOne_Click")
        isOk = pDisplace.SendCmd(clsDisplace.GetCmd.GET_VALUE)

        If isOk = False Then
            TxtRunState.Text = "통신 연결 안됨.."
        Else
            If m_bAline = 0 Then
                System.Threading.Thread.Sleep(500)
                LbMeasureOne.Text = Mid(pDisplace.rtnStr, 4, 8)
            ElseIf m_bAline = 1 Then
                System.Threading.Thread.Sleep(500)
                LbMeasureOne.Text = Mid(pDisplace.rtnStr, 13, 8)
            End If
            
        End If

SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnDisplace B-Line Click")
    End Sub

    Public Sub tmDisplace_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmDisplace.Tick
        On Error GoTo SysErr
        If m_bAline = 0 Then
            btnSetALine.BackColor = Color.Lime
            btnSetBLine.BackColor = Color.WhiteSmoke
        Else
            btnSetALine.BackColor = Color.WhiteSmoke
            btnSetBLine.BackColor = Color.Lime
        End If

        'DisplaceSeq() '변위센서 시퀀스
        If m_strMsg <> "" Then
            TxtRunState.Text = m_strMsg
        End If

        If m_bAline = 0 Then
            LblCurXPos.Text = pLDLT.PLC_Infomation.dCurPosX(LINE.A).ToString
            LblCurYPos.Text = pLDLT.PLC_Infomation.dCurPosY(LINE.A).ToString
        Else
            LblCurXPos.Text = pLDLT.PLC_Infomation.dCurPosX(LINE.B).ToString
            LblCurYPos.Text = pLDLT.PLC_Infomation.dCurPosY(LINE.B).ToString
        End If

        '변위센서 측정값 출력
        If DisplaceDataRead = True Then
            m_displace_value(OperationSeq.m_MeasureCnt).Text = OperationSeq.strTmp
            DisplaceDataRead = False
            DisplaceDataReadok = True
        End If
        System.Threading.Thread.Sleep(10)
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnDisplace B-Line Click")
    End Sub

#End Region

    Private Sub ctrlDisplace_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnMeasureCycle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMeasureCycle.Click
        modRecipe.Displace_Data_Read(m_bAline)
        For i As Integer = 0 To 15
            m_displace_value(i).Text = strLabelName(i)
        Next
        OperationSeq.m_DisplaceSeq = 700

    End Sub

    Private Sub BtnMeasureCycleStop_Click(sender As System.Object, e As System.EventArgs) Handles BtnMeasureCycleStop.Click
        'OperationSeq.bThreadRunningOperation = True
        For i As Integer = 0 To 15
            m_displace_value(i).Text = strLabelName(i)
        Next
        OperationSeq.m_DisplaceSeq = 1000
    End Sub

    Private Sub tabPagePanel3_Click(sender As System.Object, e As System.EventArgs) Handles tabPagePanel3.Click
        dp_nPannel = 3
    End Sub

    Private Sub ScrapB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScrapB1.Click
        On Error GoTo SysErr

        Select Case bBtnClickLeft
            Case False
                bBtnClickLeft = True
                ScrapB1.BackColor = Color.Lime
                pbSelectposition(0) = True
                pnSelectPosition = 0
                m_nSelBlockInx = 0
            Case True
                bBtnClickLeft = False
                ScrapB1.BackColor = Color.White
                pbSelectposition(0) = False
                pnSelectPosition = 4
                m_nSelBlockInx = 4
        End Select

SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- ScrapB1_Click")
    End Sub
    Private Sub ScrapB2_Click(sender As System.Object, e As System.EventArgs) Handles ScrapB2.Click
        On Error GoTo SysErr

        Select Case bBtnClickTop
            Case False
                bBtnClickTop = True
                ScrapB2.BackColor = Color.Lime
                pbSelectposition(1) = True
                pnSelectPosition = 1
                m_nSelBlockInx = 1
            Case True
                bBtnClickTop = False
                ScrapB2.BackColor = Color.White
                pbSelectposition(1) = False
                pnSelectPosition = 4
                m_nSelBlockInx = 4
        End Select

SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- ScrapB1_Click")
    End Sub

    Private Sub ScrapB3_Click(sender As System.Object, e As System.EventArgs) Handles ScrapB3.Click
        On Error GoTo SysErr

        Select Case bBtnClickRight
            Case False
                bBtnClickRight = True
                ScrapB3.BackColor = Color.Lime
                pbSelectposition(2) = True
                pnSelectPosition = 2
                m_nSelBlockInx = 2
            Case True
                bBtnClickRight = False
                ScrapB3.BackColor = Color.White
                pbSelectposition(2) = False
                pnSelectPosition = 4
                m_nSelBlockInx = 4
        End Select

SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- ScrapB1_Click")
    End Sub

    Private Sub MainB_Click(sender As System.Object, e As System.EventArgs) Handles MainB.Click
        On Error GoTo SysErr
        Select Case bBtnClickMain
            Case False
                bBtnClickMain = True
                MainB.BackColor = Color.Lime
                pbSelectposition(3) = True
                pnSelectPosition = 3
                m_nSelBlockInx = 3
            Case True
                bBtnClickMain = False
                MainB.BackColor = Color.White
                pbSelectposition(3) = False
                pnSelectPosition = 4
                m_nSelBlockInx = 4
        End Select

SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- ScrapB1_Click")
    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .btnSetALine.Text = My.Resources.setLan.ResourceManager.GetObject("ALine")
            .btnSetBLine.Text = My.Resources.setLan.ResourceManager.GetObject("BLine")

            .BtnComMode.Text = My.Resources.setLan.ResourceManager.GetObject("interfacemode")
            .BtnSettingMode.Text = My.Resources.setLan.ResourceManager.GetObject("settingmode")
            .BtnZeroSet.Text = My.Resources.setLan.ResourceManager.GetObject("zeropointset")

            .BtnZeroRelease.Text = My.Resources.setLan.ResourceManager.GetObject("zeropointdel")
            .BtnMeasureOne.Text = My.Resources.setLan.ResourceManager.GetObject("oncemeasure")
            .BtnMeasureCycle.Text = My.Resources.setLan.ResourceManager.GetObject("measuretime")
            .BtnMeasureCycleStop.Text = My.Resources.setLan.ResourceManager.GetObject("measurestop")

            

            .Label10.Text = My.Resources.setLan.ResourceManager.GetObject("XCurruntPos")
            .Label11.Text = My.Resources.setLan.ResourceManager.GetObject("YCurruntPos")
            .GroupBox1.Text = My.Resources.setLan.ResourceManager.GetObject("GroupBox1")
            .BtnMeasureCycleStop.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
        End With

    End Sub
End Class
