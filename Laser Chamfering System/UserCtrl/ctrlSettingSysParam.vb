Public Class ctrlSettingSysParam

    Dim tmpLaserPosX As Double
    Dim tmpLaserPosY As Double
    Dim tmpVisionPosX As Double
    Dim tmpVisionPosY As Double
    Dim tmpMovePosX As Double
    Dim tmpMovePosY As Double
    Dim dOffsetValueX As Double
    Dim dOffsetValueY As Double
    Dim bSystemShot(1, 3) As Boolean
    Public m_bLaserOffsetMoveing(1) As Boolean
    Dim MoveCount As Integer = 0
    Dim CkAutoFirst As Boolean '크로스라인 오토 1회 우선 사용 후 매뉴얼 동작

    Dim nPanelA As Integer = -1
    Dim nPanelB As Integer = -1

    Dim nModeA As Integer = -1
    Dim nModeB As Integer = -1

    Dim tmpdPosX As Double
    Dim tmpdPosY As Double

    'sbs1  Dim bClossLineCheck(8, 5) As Boolean 8 = 8개 척 , 5 버튼갯수
    Dim bClossLineCheck(7, 1) As Boolean

    Private bCheckMoveLaserOK() As Boolean
    Private bCheckMoveToVisionOK() As Boolean
    Private Sub ctrlSettingSysParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If bLogInUser = True Or bLogInTech = True Then
            gbSystemPort.Enabled = False
            gbSystemFilePath.Enabled = False
            gbScanMinSpd.Enabled = False
            gbLogSaveDay.Enabled = False
            gbVisionDelay.Enabled = False
            gbPowerMeterTime.Enabled = False
            gbTrimmingDelay.Enabled = False
            gbDustCollector.Enabled = False
            gbLaserPowerLimit.Enabled = False
            btnCamUseA.Enabled = False
            btnCamUseB.Enabled = False
            gbCameraUse.Enabled = False
        ElseIf bLogInAdmin = True Then
            gbSystemPort.Enabled = True
            gbSystemFilePath.Enabled = True
            gbScanMinSpd.Enabled = True
            gbLogSaveDay.Enabled = True
            gbVisionDelay.Enabled = True
            gbPowerMeterTime.Enabled = True
            gbTrimmingDelay.Enabled = True
            gbDustCollector.Enabled = True
            gbLaserPowerLimit.Enabled = True
            btnCamUseA.Enabled = True
            btnCamUseB.Enabled = True
            gbCameraUse.Enabled = True
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        FormSetting()
    End Sub

    Public Sub FormSetting()
        On Error GoTo SysErr
        Dim tmpPath() As String = {}
        txtSystemPath.Text = pCurSystemParam.strSystemRootPath
        txtSystemLogPath.Text = pCurSystemParam.strSystemLogPath
        txtSystemImagePathA.Text = pCurSystemParam.strAlignImagePath(LINE.A)
        txtSystemImagePathB.Text = pCurSystemParam.strAlignImagePath(LINE.B)
        txtScannerSettingPath.Text = pCurSystemParam.strScannerSettingPath

        numLaser1Port.Value = pCurSystemParam.nPortLaser(0)
        numLaser2Port.Value = pCurSystemParam.nPortLaser(1)
        numLaser3Port.Value = pCurSystemParam.nPortLaser(2)
        numLaser4Port.Value = pCurSystemParam.nPortLaser(3)
        numLightPort.Value = pCurSystemParam.nPortLight
        numDustPort.Value = pCurSystemParam.nPortDustCollecter(0)
        numDustPort2.Value = pCurSystemParam.nPortDustCollecter(1)
        numChiller1Port.Value = pCurSystemParam.nPortChiller(0)
        numChiller2Port.Value = pCurSystemParam.nPortChiller(1)
        numChiller3Port.Value = pCurSystemParam.nPortChiller(2)
        numChiller4Port.Value = pCurSystemParam.nPortChiller(3)
        numPowerMeterport1.Value = pCurSystemParam.nPortPowerMeter(0)
        numPowerMeterport2.Value = pCurSystemParam.nPortPowerMeter(1)
        numPowerMeterport3.Value = pCurSystemParam.nPortPowerMeter(2)
        numPowerMeterport4.Value = pCurSystemParam.nPortPowerMeter(3)
        numPowerMeterport_Stage.Value = pCurSystemParam.nPortPowerMeter(4)
        numDisplacePort.Value = pCurSystemParam.nPortDisplace

        lblSystemLineOffsetX_A1.Text = pCurSystemParam.dVisionLaserOffsetX(0, 0).ToString
        lblSystemLineOffsetY_A1.Text = pCurSystemParam.dVisionLaserOffsetY(0, 0).ToString
        lblSystemLineOffsetX_A2.Text = pCurSystemParam.dVisionLaserOffsetX(0, 1).ToString
        lblSystemLineOffsetY_A2.Text = pCurSystemParam.dVisionLaserOffsetY(0, 1).ToString
        lblSystemLineOffsetX_A3.Text = pCurSystemParam.dVisionLaserOffsetX(0, 2).ToString
        lblSystemLineOffsetY_A3.Text = pCurSystemParam.dVisionLaserOffsetY(0, 2).ToString
        lblSystemLineOffsetX_A4.Text = pCurSystemParam.dVisionLaserOffsetX(0, 3).ToString
        lblSystemLineOffsetY_A4.Text = pCurSystemParam.dVisionLaserOffsetY(0, 3).ToString

        lblSystemLineOffsetX_B1.Text = pCurSystemParam.dVisionLaserOffsetX(1, 0).ToString
        lblSystemLineOffsetY_B1.Text = pCurSystemParam.dVisionLaserOffsetY(1, 0).ToString
        lblSystemLineOffsetX_B2.Text = pCurSystemParam.dVisionLaserOffsetX(1, 1).ToString
        lblSystemLineOffsetY_B2.Text = pCurSystemParam.dVisionLaserOffsetY(1, 1).ToString
        lblSystemLineOffsetX_B3.Text = pCurSystemParam.dVisionLaserOffsetX(1, 2).ToString
        lblSystemLineOffsetY_B3.Text = pCurSystemParam.dVisionLaserOffsetY(1, 2).ToString
        lblSystemLineOffsetX_B4.Text = pCurSystemParam.dVisionLaserOffsetX(1, 3).ToString
        lblSystemLineOffsetY_B4.Text = pCurSystemParam.dVisionLaserOffsetY(1, 3).ToString

        '처음 실행 될때 선택한다.
        RbtnPanelA1.Focus()
        RbtnPanelB1.Focus()

        numTrimmingDelay.Value = pCurSystemParam.nTrimmingDelay
        numVisionAlignDelay.Value = pCurSystemParam.nVisionAlignDelay
        numVisionAlignRetryDelay.Value = pCurSystemParam.nVisionAlignRetryDelay
        numPowerMeterTime.Value = pCurSystemParam.nPowerMeterTime

        numDustStopTimer.Value = pCurSystemParam.nDustTimer

        numScanMarkSpdLimit.Value = pCurSystemParam.nScanMarkSpdLimt
        numScanJumpSpdLimit.Value = pCurSystemParam.nScanJumpSpdLimt
        numLogSaveDay.Value = pCurSystemParam.nLogSaveDay
        numImageSaveDay.Value = pCurSystemParam.nImageSaveDay
        '20190807
        numPowerMax.Value = pCurSystemParam.nLaserPowerMaxLimit
        numPowerMin.Value = pCurSystemParam.nLaserPowerMinLimit

        '20200317 카메라 사용모드
        If pCurSystemParam.btnCameraUseMode(0) = 1 Then
            btnCamUse_1.BackColor = Color.Lime
        Else
            btnCamUse_1.BackColor = Color.White
        End If

        If pCurSystemParam.btnCameraUseMode(1) = 1 Then
            btnCamUse_2.BackColor = Color.Lime
        Else
            btnCamUse_2.BackColor = Color.White
        End If

        If pCurSystemParam.btnCameraUseMode(2) = 1 Then
            btnCamUse_3.BackColor = Color.Lime
        Else
            btnCamUse_3.BackColor = Color.White
        End If

        If pCurSystemParam.btnCameraUseMode(3) = 1 Then
            btnCamUse_4.BackColor = Color.Lime
        Else
            btnCamUse_4.BackColor = Color.White
        End If

        pSetSystemParam.btnCameraUseMode_A1 = pCurSystemParam.btnCameraUseMode(0)
        pSetSystemParam.btnCameraUseMode_A2 = pCurSystemParam.btnCameraUseMode(1)
        pSetSystemParam.btnCameraUseMode_B1 = pCurSystemParam.btnCameraUseMode(2)
        pSetSystemParam.btnCameraUseMode_B2 = pCurSystemParam.btnCameraUseMode(3)

        'If pCurSystemParam.btnCameraAUse = False Then
        '    btnCamUseA.BackColor = Color.White
        'Else
        '    btnCamUseA.BackColor = Color.Lime
        'End If

        'If pCurSystemParam.btnCameraBUse = False Then
        '    btnCamUseB.BackColor = Color.White
        'Else
        '    btnCamUseB.BackColor = Color.Lime
        'End If

        'cbLightUse.Checked = pCurSystemParam.nLightUse

        If Me.Visible = True Then
            RTick.Enabled = True
        End If

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserA.Enabled = True '오토 한번 무조건
            btnLaserShotA.Enabled = False
            btnMoveToVisionA.Enabled = False

            'btnMoveToLaserB.Enabled = True '오토 한번 무조건
            btnLaserShotB.Enabled = False
            btnMoveToVisionB.Enabled = False
        End If
        ReDim bCheckMoveLaserOK(1)
        ReDim bCheckMoveToVisionOK(1)

        For i = 0 To 1
            bCheckMoveLaserOK(i) = False
            bCheckMoveToVisionOK(i) = False
        Next

        'sbs1
        For i = 0 To 7
            For j = 0 To 1
                bClossLineCheck(i, j) = False
            Next
        Next

        pSetSystemParam = pCurSystemParam

        Exit Sub
SysErr:

    End Sub

    Private Sub btnSystemPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemPath.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting -- btnSystemPath_Click")
        Dim FolderSelect As New FolderBrowserDialog
        Dim strPath As String = ""
        FolderSelect.SelectedPath = "C:\"
        If FolderSelect.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strPath = FolderSelect.SelectedPath
            pSetSystemParam.strSystemRootPath = strPath
            txtSystemPath.Text = strPath
        End If
        FolderSelect.Dispose()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSystemPath_Click")
    End Sub

    Private Sub btnSystemLogPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemLogPath.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting -- btnSystemLogPath_Click")
        Dim FolderSelect As New FolderBrowserDialog
        Dim strPath As String = ""

        If FolderSelect.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strPath = FolderSelect.SelectedPath
            pSetSystemParam.strSystemLogPath = strPath
            txtSystemLogPath.Text = strPath
        End If
        FolderSelect.Dispose()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSystemLogPath_Click")
    End Sub

    Private Sub btnSystemImagePathA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemImagePathA.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting -- btnSystemImagePathA_Click")
        Dim FolderSelect As New FolderBrowserDialog
        Dim strPath As String = ""

        If FolderSelect.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strPath = FolderSelect.SelectedPath
            pSetSystemParam.strAlignImagePath(LINE.A) = strPath
            txtSystemLogPath.Text = strPath
        End If
        FolderSelect.Dispose()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSystemImagePathA_Click")
    End Sub

    Private Sub btnSystemImagePathB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemImagePathB.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting -- btnSystemImagePathB_Click")
        Dim FolderSelect As New FolderBrowserDialog
        Dim strPath As String = ""

        If FolderSelect.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strPath = FolderSelect.SelectedPath
            pSetSystemParam.strAlignImagePath(LINE.B) = strPath
            txtSystemLogPath.Text = strPath
        End If
        FolderSelect.Dispose()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSystemImagePathB_Click")
    End Sub

    Private Sub btnScannerSettingPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScannerSettingPath.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting -- btnScannerSettingPath_Click")
        Dim FolderSelect As New FolderBrowserDialog
        Dim strPath As String = ""

        If FolderSelect.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strPath = FolderSelect.SelectedPath
            pSetSystemParam.strScannerSettingPath = strPath
            txtSystemLogPath.Text = strPath
        End If
        FolderSelect.Dispose()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnScannerSettingPath_Click")
    End Sub

    Private Sub btnSetPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetPort.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting -- btnSetPort_Click")
        pSetSystemParam.nPortLaser(0) = numLaser1Port.Value
        pSetSystemParam.nPortLaser(1) = numLaser2Port.Value
        pSetSystemParam.nPortLaser(2) = numLaser3Port.Value
        pSetSystemParam.nPortLaser(3) = numLaser4Port.Value

        pSetSystemParam.nPortChiller(0) = numChiller1Port.Value
        pSetSystemParam.nPortChiller(1) = numChiller2Port.Value
        pSetSystemParam.nPortChiller(2) = numChiller3Port.Value
        pSetSystemParam.nPortChiller(3) = numChiller4Port.Value

        pSetSystemParam.nPortLight = numLightPort.Value

        pSetSystemParam.nPortDustCollecter(0) = numDustPort.Value
        pSetSystemParam.nPortDustCollecter(1) = numDustPort2.Value

        pSetSystemParam.nPortPowerMeter(0) = numPowerMeterport1.Value
        pSetSystemParam.nPortPowerMeter(1) = numPowerMeterport2.Value
        pSetSystemParam.nPortPowerMeter(2) = numPowerMeterport3.Value
        pSetSystemParam.nPortPowerMeter(3) = numPowerMeterport4.Value

        'pSetSystemParam.nPortPowerMeterStage = numPowerMeterport_Stage.Value

        pSetSystemParam.nPortPowerMeter(4) = numPowerMeterport_Stage.Value
        'nPortDisplace
        pSetSystemParam.nPortDisplace = numDisplacePort.Value
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSetPort_Click")
    End Sub

    Private Sub btnDustStopTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDustStopTimer.Click
        On Error GoTo SysErr
        pSetSystemParam.nDustTimer = numDustStopTimer.Value
        Exit Sub
SysErr:
    End Sub

    Private Sub btnVisionAlignDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionAlignDelay.Click
        On Error GoTo SysErr

        modPub.SystemLog("ctrlSettingSysParam -- btnVisionAlignDelay Click")
        pSetSystemParam.nVisionAlignDelay = numVisionAlignDelay.Value

        Exit Sub
SysErr:

    End Sub

    Private Sub btnVisionAlignRetryDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionAlignRetryDelay.Click
        On Error GoTo SysErr

        modPub.SystemLog("ctrlSettingSysParam -- btnVisionAlignRetryDelay Click")
        pSetSystemParam.nVisionAlignRetryDelay = numVisionAlignRetryDelay.Value

        Exit Sub
SysErr:
    End Sub

    Private Sub btnDustCollectorRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDustCollectorRun.Click
        On Error GoTo SysErr
        'pDustCollector(0).RunDustCollector()
        'pDustCollector(1).RunDustCollector()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnScanSpdLimit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanSpdLimit.Click
        On Error GoTo SysErr
        modPub.SystemLog("ctrlSettingSysParam -- btnScanSpdLimit Click")

        pSetSystemParam.nScanMarkSpdLimt = numScanMarkSpdLimit.Value
        pSetSystemParam.nScanJumpSpdLimt = numScanJumpSpdLimit.Value
        Exit Sub
SysErr:

    End Sub

    Private Sub btnSaveDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveDay.Click
        On Error GoTo SysErr
        modPub.SystemLog("ctrlSettingSysParam -- btnSaveDay Click")

        pSetSystemParam.nLogSaveDay = numLogSaveDay.Value
        pSetSystemParam.nImageSaveDay = numImageSaveDay.Value
        Exit Sub
SysErr:

    End Sub

    Private Sub btnTrimmingDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrimmingDelay.Click
        On Error GoTo SysErr
        modPub.SystemLog("ctrlSettingSysParam -- btnTrimmingDelay Click")
        pSetSystemParam.nTrimmingDelay = numTrimmingDelay.Value

        Exit Sub
SysErr:

    End Sub

    Private Sub btnPowerMeterTime_Click(sender As System.Object, e As System.EventArgs) Handles btnPowerMeterTime.Click
        modPub.SystemLog("ctrlSettingSysParam -- btnPowerMeterTime Click")
        pSetSystemParam.nPowerMeterTime = numPowerMeterTime.Value
    End Sub

    Private Sub btnSystemParamSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemParamSave.Click
        modPub.SystemLog("ctrlSettingSysParam -- btnSystemParamSave_Click")

        Dim strFilePath As String
        Dim dVisionLaserOffsetX(1, 3) As Double       ' index : Line, Laser
        Dim dVisionLaserOffsetY(1, 3) As Double
        Dim strTemp As String
        Dim str(1) As String

        str(0) = "A"
        str(1) = "B"

        strFilePath = "C:\Chamfering System\DEFAULT.ini"

        ' Cross Line Laser Offset 값이 변경되면 변경전, 변경후 의 값을 Log에 저장
        For nLine As Integer = 0 To 1
            For i As Integer = 0 To 3
                dVisionLaserOffsetX(nLine, i) = CDbl(ReadIni("SYSTEM_OFFSET", str(nLine) & "_LINE_VISION_LASER_OFFSET" & (i + 1).ToString() & "_X", "0.001", strFilePath))
                If dVisionLaserOffsetX(nLine, i) <> pSetSystemParam.dVisionLaserOffsetX(nLine, i) Then
                    strTemp = str(nLine) & "_" & (i + 1).ToString & "_OFFSET_X"
                    modPub.ParamLog(strTemp & " :: [" & dVisionLaserOffsetX(nLine, i).ToString & "] => [" & pSetSystemParam.dVisionLaserOffsetX(nLine, i).ToString & "]")
                End If

                dVisionLaserOffsetY(nLine, i) = CDbl(ReadIni("SYSTEM_OFFSET", str(nLine) & "_LINE_VISION_LASER_OFFSET" & (i + 1).ToString() & "_Y", "0.001", strFilePath))
                If dVisionLaserOffsetY(nLine, i) <> pSetSystemParam.dVisionLaserOffsetY(nLine, i) Then
                    strTemp = str(nLine) & "_" & (i + 1).ToString & "_OFFSET_Y"
                    modPub.ParamLog(strTemp & " :: [" & dVisionLaserOffsetY(nLine, i).ToString & "] => [" & pSetSystemParam.dVisionLaserOffsetY(nLine, i).ToString & "]")
                End If

            Next
        Next
        '20200409 확인필요 pSetSystemParam을 수정하면 pCurSystemParam도 같이 수정됨
        If pCurSystemParam.btnCameraUseMode(0) <> pSetSystemParam.btnCameraUseMode_A1 Then
            frmMSG.ShowMsg("카메라 미사용 모드 전환", "프로그램 재실행 후 적용됩니다.(Program ReStart Plase)", False, 1)
        End If

        If pCurSystemParam.btnCameraUseMode(1) <> pSetSystemParam.btnCameraUseMode_A2 Then
            frmMSG.ShowMsg("카메라 미사용 모드 전환", "프로그램 재실행 후 적용됩니다.(Program ReStart Plase)", False, 1)
        End If

        If pCurSystemParam.btnCameraUseMode(2) <> pSetSystemParam.btnCameraUseMode_B1 Then
            frmMSG.ShowMsg("카메라 미사용 모드 전환", "프로그램 재실행 후 적용됩니다.(Program ReStart Plase)", False, 1)
        End If

        If pCurSystemParam.btnCameraUseMode(3) <> pSetSystemParam.btnCameraUseMode_B2 Then
            frmMSG.ShowMsg("카메라 미사용 모드 전환", "프로그램 재실행 후 적용됩니다.(Program ReStart Plase)", False, 1)
        End If
        pCurSystemParam.btnCameraUseMode(0) = pSetSystemParam.btnCameraUseMode_A1
        pCurSystemParam.btnCameraUseMode(1) = pSetSystemParam.btnCameraUseMode_A2
        pCurSystemParam.btnCameraUseMode(2) = pSetSystemParam.btnCameraUseMode_B1
        pCurSystemParam.btnCameraUseMode(3) = pSetSystemParam.btnCameraUseMode_B2

        pCurSystemParam = pSetSystemParam
        modParam.SaveParam(pStrTmpSystemRoot, pSetSystemParam)
    End Sub

#Region "LaserShot"

    Private Sub LaserShot(ByVal nLine As Integer, ByVal nIndex As Integer)
        On Error GoTo SysErr

        Select Case nLine

            Case LINE.A

                Select Case nIndex

                    Case Panel.p1

                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p2).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p2).RTC6ResetList()
                        pScanner(Panel.p2).RTC6_CrossShot(2000)

                    Case Panel.p2

                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p1).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p1).RTC6ResetList()
                        pScanner(Panel.p1).RTC6_CrossShot(2000)

                    Case Panel.p3

                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p4).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p4).RTC6ResetList()
                        pScanner(Panel.p4).RTC6_CrossShot(2000)

                    Case Panel.p4

                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p3).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p3).RTC6ResetList()
                        pScanner(Panel.p3).RTC6_CrossShot(2000)

                End Select

            Case LINE.B

                Select Case nIndex

                    Case Panel.p1

                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p1).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p1).RTC6ResetList()
                        pScanner(Panel.p1).RTC6_CrossShot(2000)

                    Case Panel.p2
                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p2).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p2).RTC6ResetList()
                        pScanner(Panel.p2).RTC6_CrossShot(2000)

                    Case Panel.p3
                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p3).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p3).RTC6ResetList()
                        pScanner(Panel.p3).RTC6_CrossShot(2000)

                    Case Panel.p4
                        'GYN - Scanner Move 0,0
                        pScanner(Panel.p4).RTC6ABSMove(0, 0)
                        System.Threading.Thread.Sleep(200)
                        pScanner(Panel.p4).RTC6ResetList()
                        pScanner(Panel.p4).RTC6_CrossShot(2000)

                End Select

        End Select

        If nLine = LINE.A Then
            btnMoveToVisionA.Enabled = True
            btnLaserShotA.Enabled = False
        Else
            btnMoveToVisionB.Enabled = True
            btnLaserShotB.Enabled = False
        End If

        tmpLaserPosX = pLDLT.PLC_Infomation.dCurPosX(nLine)
        tmpLaserPosY = pLDLT.PLC_Infomation.dCurPosY(nLine)

        bSystemShot(nLine, nIndex) = True

SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnLaserShot_Click")
    End Sub

    Private Sub btnLaserShotA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.A, 1)
    End Sub

    Private Sub btnLaserShotA2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.A, 0)
    End Sub

    Private Sub btnLaserShotA3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.A, 3)
    End Sub

    Private Sub btnLaserShotA4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.A, 2)
    End Sub

    Private Sub btnLaserShotB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.B, 0)
    End Sub

    Private Sub btnLaserShotB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.B, 1)
    End Sub

    Private Sub btnLaserShotB3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.B, 2)
    End Sub

    Private Sub btnLaserShotB4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LaserShot(LINE.B, 3)
    End Sub

#End Region

#Region "MoveToLaser"

    Private Sub MoveToLaser(ByVal nLine As Integer, ByVal nlndex As Integer)
        On Error GoTo SysErr
        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            If pLDLT.pbConnect = True Then
                tmpMovePosX = ((pLDLT.PLC_Infomation.dCurPosX(nLine)) + pSetSystemParam.dVisionLaserOffsetX(nLine, nlndex)) * 1000
                tmpMovePosY = ((pLDLT.PLC_Infomation.dCurPosY(nLine)) + pSetSystemParam.dVisionLaserOffsetY(nLine, nlndex)) * 1000
                pLDLT.MoveStage(nLine, Axis.x, tmpMovePosX)
                pLDLT.MoveStage(nLine, Axis.y, tmpMovePosY)
                bCheckMoveLaserOK(nLine) = True
            End If
        Else
            tmpMovePosX = 0
            tmpMovePosY = 0
        End If
        '2018.05. Ryo
        If MoveCount = 1 Then
            RTick.Enabled = True
            'If PerPosion = True Then
            '    If nLine = LINE.A Then
            '        btnMoveToLaserA.Enabled = False
            '        btnLaserShotA.Enabled = True
            '        RTick.Enabled = False
            '    Else
            '        btnMoveToLaserB.Enabled = False
            '        btnLaserShotB.Enabled = True
            '        RTick.Enabled = False
            '    End If
            'End If
        Else
            MsgBox("충돌 위험 : pc 제어권을 해제하고 측정 위치로 돌아가주세요.")
            pMXComponent.WriteWordIntegerByAddress(CInt(pLDLT.PLC_Infomation.dCurPosX(nLine)), 0)
            pMXComponent.WriteWordIntegerByAddress(CInt(pLDLT.PLC_Infomation.dCurPosY(nLine)), 0)

            MoveCount = 0
        End If
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & "MoveToLaser")
    End Sub

#End Region

#Region "MoveToVision"
    Private Sub MoveToVision(ByVal nLine As Integer, ByVal nIndex As Integer)
        On Error GoTo SysErr
        'modPub.SystemLog("frmSetting -- btnMoveVisionA3_Click")
        ' If m_bLaserOffsetMoveing(nLine) = False Then
        If pLDLT.pbConnect = True Then
            tmpMovePosX = (pLDLT.PLC_Infomation.dCurPosX(nLine) - pCurSystemParam.dVisionLaserOffsetX(nLine, nIndex)) * 1000
            tmpMovePosY = (pLDLT.PLC_Infomation.dCurPosY(nLine) - pCurSystemParam.dVisionLaserOffsetY(nLine, nIndex)) * 1000
            pLDLT.MoveStage(nLine, Axis.x, tmpMovePosX)
            pLDLT.MoveStage(nLine, Axis.y, tmpMovePosY)
            bCheckMoveToVisionOK(nLine) = True
        End If
        RTick.Enabled = True

        If nLine = LINE.A Then
            btnMoveToVisionA.Enabled = False
            If CkAutoFirst = True Then
                btnMoveToLaserA.Enabled = True
            End If
        Else
            btnMoveToVisionB.Enabled = False
            If CkAutoFirst = True Then
                btnMoveToLaserB.Enabled = True
            End If
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- MoveToVision")
    End Sub

#End Region

#Region "Offset Set"
    Private Sub OffsetSet(ByVal nLine As Integer, ByVal nIndex As Integer)
        On Error GoTo SysErr

        modPub.SystemLog("frmSetting -- btnOffsetSet_Click")

        If bSystemShot(nLine, nIndex) = True Then

            If nModeA = CrossLineMode.MODE_AUTO Or nModeB = CrossLineMode.MODE_AUTO Then

                tmpLaserPosX = OperationSeq.tmpLaserPosX
                tmpLaserPosY = OperationSeq.tmpLaserPosY

            End If

            Dim lblX As Label = Nothing
            Dim lblY As Label = Nothing
            Dim btnShot As Button = Nothing
            'Dim tmpdPosX As Double
            'Dim tmpdPosY As Double

            tmpVisionPosX = pLDLT.PLC_Infomation.dCurPosX(nLine)
            tmpVisionPosY = pLDLT.PLC_Infomation.dCurPosY(nLine)

            tmpdPosX = pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
            tmpdPosY = pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)

            pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = tmpLaserPosX - tmpVisionPosX
            pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = tmpLaserPosY - tmpVisionPosY
            If nLine = LINE.A Then
                If nIndex = 0 Then
                    lblX = lblSystemLineOffsetX_A1
                    lblY = lblSystemLineOffsetY_A1
                    'btnShot = btnLaserShotA1
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser1_A.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                ElseIf nIndex = 1 Then
                    lblX = lblSystemLineOffsetX_A2
                    lblY = lblSystemLineOffsetY_A2
                    'btnShot = btnLaserShotA2
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser2_A.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                ElseIf nIndex = 2 Then
                    lblX = lblSystemLineOffsetX_A3
                    lblY = lblSystemLineOffsetY_A3
                    'btnShot = btnLaserShotA3
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser3_A.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                ElseIf nIndex = 3 Then
                    lblX = lblSystemLineOffsetX_A4
                    lblY = lblSystemLineOffsetY_A4
                    'btnShot = btnLaserShotA4
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser4_A.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                End If
            ElseIf nLine = LINE.B Then
                If nIndex = 0 Then
                    lblX = lblSystemLineOffsetX_B1
                    lblY = lblSystemLineOffsetY_B1
                    'btnShot = btnLaserShotB1
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser1_B.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                ElseIf nIndex = 1 Then
                    lblX = lblSystemLineOffsetX_B2
                    lblY = lblSystemLineOffsetY_B2
                    'btnShot = btnLaserShotB2
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser2_B.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                ElseIf nIndex = 2 Then
                    lblX = lblSystemLineOffsetX_B3
                    lblY = lblSystemLineOffsetY_B3
                    'btnShot = btnLaserShotB3
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser3_B.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                ElseIf nIndex = 3 Then
                    lblX = lblSystemLineOffsetX_B4
                    lblY = lblSystemLineOffsetY_B4
                    'btnShot = btnLaserShotB4
                    dOffsetValueX = tmpdPosX - pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
                    dOffsetValueY = tmpdPosY - pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)
                    lblOffsetValueLaser4_B.Text = "X=" & Math.Round(dOffsetValueX, 3) & vbCrLf & "Y=" & Math.Round(dOffsetValueY, 3)
                End If
            End If
            lblX.Text = pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex).ToString
            lblY.Text = pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex).ToString

            If nLine = LINE.A Then
                btnOffsetSetA.BackColor = Color.White
                btnMoveToLaserA.Enabled = True
                btnMoveToVisionA.Enabled = False
                btnLaserShotA.Enabled = False

                btnMoveToLaserA.BackColor = Color.White
                btnLaserShotA.BackColor = Color.White
                btnMoveToVisionA.BackColor = Color.White

            Else
                btnOffsetSetB.BackColor = Color.White
                btnMoveToLaserB.Enabled = True
                btnMoveToVisionB.Enabled = False
                btnLaserShotB.Enabled = False

                btnMoveToLaserB.BackColor = Color.White
                btnLaserShotB.BackColor = Color.White
                btnMoveToVisionB.BackColor = Color.White

            End If

            bSystemShot(nLine, nIndex) = False
        End If
        Exit Sub
SysErr:
        'modPub.ErrorLog(Err.Description & " - frmSetting -- btnOffsetSetA1_Click")
    End Sub

    Private Sub btnOffsetSetA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.A, 0)
    End Sub

    Private Sub btnOffsetSetA2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.A, 1)
    End Sub

    Private Sub btnOffsetSetA3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.A, 2)
    End Sub

    Private Sub btnOffsetSetA4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.A, 3)
    End Sub

    Private Sub btnOffsetSetB1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.B, 0)
    End Sub

    Private Sub btnOffsetSetB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.B, 1)
    End Sub

    Private Sub btnOffsetSetB3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.B, 2)
    End Sub

    Private Sub btnOffsetSetB4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OffsetSet(LINE.B, 3)
    End Sub

#End Region


#Region "Offset Set Return"
    '값이 초과되면 이전값으로 되돌아간다 RYO
    Private Sub OffsetSetReturn(ByVal nLine As Integer, ByVal nIndex As Integer)
        On Error GoTo SysErr

        Dim lblX As Label = Nothing
        Dim lblY As Label = Nothing
        Dim btnShot As Button = Nothing


        tmpdPosX = pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex)
        tmpdPosY = pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex)

        If nLine = LINE.A Then
            If nIndex = 0 Then
                lblSystemLineOffsetX_A1.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_A1.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_A1.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_A1.Text

            ElseIf nIndex = 1 Then
                lblSystemLineOffsetX_A2.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_A2.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_A2.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_A2.Text

            ElseIf nIndex = 2 Then
                lblSystemLineOffsetX_A3.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_A3.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_A3.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_A3.Text

            ElseIf nIndex = 3 Then
                lblSystemLineOffsetX_A4.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_A4.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_A4.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_A4.Text

            End If
        ElseIf nLine = LINE.B Then
            If nIndex = 0 Then
                lblSystemLineOffsetX_B1.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_B1.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_B1.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_B1.Text

            ElseIf nIndex = 1 Then
                lblSystemLineOffsetX_B2.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_B2.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_B2.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_B2.Text

            ElseIf nIndex = 2 Then
                lblSystemLineOffsetX_B3.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_B3.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_B3.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_B3.Text

            ElseIf nIndex = 3 Then
                lblSystemLineOffsetX_B4.Text = tmpdPosX + dOffsetValueX
                lblSystemLineOffsetY_B4.Text = tmpdPosY + dOffsetValueY

                pSetSystemParam.dVisionLaserOffsetX(nLine, nIndex) = lblSystemLineOffsetX_B4.Text
                pSetSystemParam.dVisionLaserOffsetY(nLine, nIndex) = lblSystemLineOffsetY_B4.Text

            End If
        End If

        Exit Sub
SysErr:

    End Sub

#End Region





    'Private Sub cbLightUse_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbLightUse.CheckedChanged

    '    If cbLightUse.Checked = True Then
    '        pSetSystemParam.nLightUse = 1
    '        cbLightUse.BackColor = Color.LimeGreen
    '    Else
    '        pSetSystemParam.nLightUse = 0
    '        cbLightUse.BackColor = Color.White
    '    End If

    'End Sub

    Private Sub RbtnPanelA1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelA1.CheckedChanged

        'SBS1 1버튼

        'sbs1 A1 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(0, 0) = True
        bClossLineCheck(0, 1) = False

        btnOffsetSetA.Enabled = False


        RbtnPanelA1.BackColor = Color.LimeGreen
        RbtnPanelA2.BackColor = Color.White
        RbtnPanelA3.BackColor = Color.White
        RbtnPanelA4.BackColor = Color.White

        lblSystemLineOffsetX_A1.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_A1.BackColor = Color.LimeGreen
        lblSystemLineOffsetX_A2.BackColor = Color.White
        lblSystemLineOffsetY_A2.BackColor = Color.White
        lblSystemLineOffsetX_A3.BackColor = Color.White
        lblSystemLineOffsetY_A3.BackColor = Color.White
        lblSystemLineOffsetX_A4.BackColor = Color.White
        lblSystemLineOffsetY_A4.BackColor = Color.White

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserA.Enabled = False
            btnLaserShotA.Enabled = False
            btnMoveToVisionA.Enabled = False
        End If
        btnMoveToLaserA.BackColor = Color.White
        btnLaserShotA.BackColor = Color.White
        btnMoveToVisionA.BackColor = Color.White

        frmVision.SelectVision(LINE.A, CAM.Cam1)

        nPanelA = 0

    End Sub

    Private Sub RbtnPanelA2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelA2.CheckedChanged

        'sbs1 A2 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(1, 0) = True
        bClossLineCheck(1, 1) = False
        btnOffsetSetA.Enabled = False

        RbtnPanelA1.BackColor = Color.White
        RbtnPanelA2.BackColor = Color.LimeGreen
        RbtnPanelA3.BackColor = Color.White
        RbtnPanelA4.BackColor = Color.White

        lblSystemLineOffsetX_A1.BackColor = Color.White
        lblSystemLineOffsetY_A1.BackColor = Color.White
        lblSystemLineOffsetX_A2.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_A2.BackColor = Color.LimeGreen
        lblSystemLineOffsetX_A3.BackColor = Color.White
        lblSystemLineOffsetY_A3.BackColor = Color.White
        lblSystemLineOffsetX_A4.BackColor = Color.White
        lblSystemLineOffsetY_A4.BackColor = Color.White

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserA.Enabled = True
            btnLaserShotA.Enabled = False
            btnMoveToVisionA.Enabled = False
        End If
        btnMoveToLaserA.BackColor = Color.White
        btnLaserShotA.BackColor = Color.White
        btnMoveToVisionA.BackColor = Color.White

        frmVision.SelectVision(LINE.A, CAM.Cam2)

        nPanelA = 1

    End Sub

    Private Sub RbtnPanelA3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelA3.CheckedChanged

        'sbs1 A3 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(2, 0) = True
        bClossLineCheck(2, 1) = False
        btnOffsetSetA.Enabled = False


        RbtnPanelA1.BackColor = Color.White
        RbtnPanelA2.BackColor = Color.White
        RbtnPanelA3.BackColor = Color.LimeGreen
        RbtnPanelA4.BackColor = Color.White

        lblSystemLineOffsetX_A1.BackColor = Color.White
        lblSystemLineOffsetY_A1.BackColor = Color.White
        lblSystemLineOffsetX_A2.BackColor = Color.White
        lblSystemLineOffsetY_A2.BackColor = Color.White
        lblSystemLineOffsetX_A3.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_A3.BackColor = Color.LimeGreen
        lblSystemLineOffsetX_A4.BackColor = Color.White
        lblSystemLineOffsetY_A4.BackColor = Color.White

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserA.Enabled = True
            btnLaserShotA.Enabled = False
            btnMoveToVisionA.Enabled = False
        End If

        btnMoveToLaserA.BackColor = Color.White
        btnLaserShotA.BackColor = Color.White
        btnMoveToVisionA.BackColor = Color.White

        frmVision.SelectVision(LINE.A, CAM.Cam1)

        nPanelA = 2

    End Sub

    Private Sub RbtnPanelA4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelA4.CheckedChanged

        'sbs1 A4 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(3, 0) = True
        bClossLineCheck(3, 1) = False
        btnOffsetSetA.Enabled = False

        RbtnPanelA1.BackColor = Color.White
        RbtnPanelA2.BackColor = Color.White
        RbtnPanelA3.BackColor = Color.White
        RbtnPanelA4.BackColor = Color.LimeGreen

        lblSystemLineOffsetX_A1.BackColor = Color.White
        lblSystemLineOffsetY_A1.BackColor = Color.White
        lblSystemLineOffsetX_A2.BackColor = Color.White
        lblSystemLineOffsetY_A2.BackColor = Color.White
        lblSystemLineOffsetX_A3.BackColor = Color.White
        lblSystemLineOffsetY_A3.BackColor = Color.White
        lblSystemLineOffsetX_A4.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_A4.BackColor = Color.LimeGreen

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserA.Enabled = True
            btnLaserShotA.Enabled = False
            btnMoveToVisionA.Enabled = False
        End If

        btnMoveToLaserA.BackColor = Color.White
        btnLaserShotA.BackColor = Color.White
        btnMoveToVisionA.BackColor = Color.White

        frmVision.SelectVision(LINE.A, CAM.Cam2)

        nPanelA = 3

    End Sub




    Private Sub cbMoveLaserA_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbMoveLaserA.SelectedIndexChanged
        If cbMoveLaserA.Text = "MANUAL" Then
            nModeA = CrossLineMode.MODE_MANUAL
        ElseIf cbMoveLaserA.Text = "AUTO" Then
            nModeA = CrossLineMode.MODE_AUTO
        End If
    End Sub

    Private Sub btnMoveToLaserA_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveToLaserA.Click
        If pLDLT.PLC_Infomation.bStageManualControl = False Or CkAutoFirst = False Then 'PC제어권 & 오토 1회 사용 아닐시 사용 불가
            MsgBox("PC제어권 체크 또는 Auto Seq를 1회 이상 사용해주세요.")
            Exit Sub
        End If

        btnOffsetSetA.Enabled = False
        btnPosCalculA.Enabled = False

        If nModeA = CrossLineMode.MODE_MANUAL Then
            MoveCount += 1
            MoveToLaser(LINE.A, nPanelA)

            btnMoveToLaserA.BackColor = Color.LimeGreen
            btnLaserShotA.BackColor = Color.White
            btnMoveToVisionA.BackColor = Color.White



        Else
            MsgBox("Select Mode [MANUAL]", MsgBoxStyle.OkOnly, "Cross Line")
        End If

    End Sub

    Private Sub btnLaserShotA_Click(sender As System.Object, e As System.EventArgs) Handles btnLaserShotA.Click

        If nModeA = CrossLineMode.MODE_MANUAL Then
            LaserShot(LINE.A, nPanelA)

            btnMoveToLaserA.BackColor = Color.White
            btnLaserShotA.BackColor = Color.LimeGreen
            btnMoveToVisionA.BackColor = Color.White

            MoveCount = 0

        Else
            MsgBox("Select Mode [MANUAL]", MsgBoxStyle.OkOnly, "Cross Line")
        End If

    End Sub

    Private Sub btnMoveToVisionA_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveToVisionA.Click

        If nModeA = CrossLineMode.MODE_MANUAL Then
            MoveToVision(LINE.A, nPanelA)

            btnMoveToLaserA.BackColor = Color.White
            btnLaserShotA.BackColor = Color.White
            btnMoveToVisionA.BackColor = Color.LimeGreen

            bClossLineCheck(nPanelA, 1) = True
            'If bClossLineCheck(nPanelA, 0) = True And bClossLineCheck(nPanelA, 1) = True Then
            '    btnPosCalculA.Enabled = True
            'End If
            btnPosCalculA.Enabled = True
        Else
            MsgBox("Select Mode [MANUAL]", MsgBoxStyle.OkOnly, "Cross Line")
        End If

    End Sub

    Private Sub btnOffsetSetA_Click(sender As System.Object, e As System.EventArgs) Handles btnOffsetSetA.Click
        Dim nRet As Integer = -1
        nRet = MsgBox("Do You Wanna Set?", MsgBoxStyle.YesNo, "Cross Line Auto Seq")

        If nRet = 7 Then

            If CkAutoFirst = True Then
                btnMoveToLaserA.Enabled = True
            End If
            btnMoveToVisionA.Enabled = False
            btnLaserShotA.Enabled = False

            btnMoveToLaserA.BackColor = Color.White
            btnLaserShotA.BackColor = Color.White
            btnMoveToVisionA.BackColor = Color.White


            Return
        End If

        'If nModeA = CrossLineMode.MODE_MANUAL Then



        'sbs1
        btnOffsetSetA.Enabled = False
        btnOffsetSetA.BackColor = Color.White
        'End If

    End Sub

    Private Sub BtnSeqAStart_Click(sender As System.Object, e As System.EventArgs) Handles BtnSeqAStart.Click
        If pLDLT.PLC_Infomation.bStageManualControl = False Then
            Exit Sub
        End If
        Dim nRet As Integer = -1
        nRet = MsgBox("[PLC] [Cross Position] Click 하셨습니까?", MsgBoxStyle.YesNo, "Cross Line Auto Seq")

        If nRet = 7 Then
            Return
        End If

        'GYN - Scanner Move 0,0
        pScanner(0).RTC6ABSMove(0, 0)
        pScanner(1).RTC6ABSMove(0, 0)
        pScanner(2).RTC6ABSMove(0, 0)
        pScanner(3).RTC6ABSMove(0, 0)

        If nModeA = CrossLineMode.MODE_AUTO Then

            OperationSeq.nLine = 0
            OperationSeq.nPanel = nPanelA
            OperationSeq.nSeqIndex = CrossLineAutoseq.SEQ_MOVETOSTAGE
            bSystemShot(LINE.A, nPanelA) = True
            CkAutoFirst = True 'auto모드 우선 사용

            btnMoveToLaserA.Enabled = True
            btnPosCalculA.Enabled = True

        End If

    End Sub


    Private Sub BtnSeqAStop_Click(sender As System.Object, e As System.EventArgs) Handles BtnSeqAStop.Click

        OperationSeq.nLine = -1
        OperationSeq.nPanel = -1
        OperationSeq.nSeqIndex = CrossLineAutoseq.SEQ_STOP
        bSystemShot(LINE.A, nPanelA) = False

    End Sub





    Private Sub RbtnPanelB1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelB1.CheckedChanged
        'SBS1 1버튼

        'sbs1 B1 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(4, 0) = True
        bClossLineCheck(4, 1) = False

        btnOffsetSetB.Enabled = False


        RbtnPanelB1.BackColor = Color.LimeGreen
        RbtnPanelB2.BackColor = Color.White
        RbtnPanelB3.BackColor = Color.White
        RbtnPanelB4.BackColor = Color.White

        lblSystemLineOffsetX_B1.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_B1.BackColor = Color.LimeGreen
        lblSystemLineOffsetX_B2.BackColor = Color.White
        lblSystemLineOffsetY_B2.BackColor = Color.White
        lblSystemLineOffsetX_B3.BackColor = Color.White
        lblSystemLineOffsetY_B3.BackColor = Color.White
        lblSystemLineOffsetX_B4.BackColor = Color.White
        lblSystemLineOffsetY_B4.BackColor = Color.White

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserB.Enabled = True
            btnLaserShotB.Enabled = False
            btnMoveToVisionB.Enabled = False
        End If

        btnMoveToLaserB.BackColor = Color.White
        btnLaserShotB.BackColor = Color.White
        btnMoveToVisionB.BackColor = Color.White

        frmVision.SelectVision(LINE.B, CAM.Cam1)

        nPanelB = 0
    End Sub

    Private Sub RbtnPanelB2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelB2.CheckedChanged
        'sbs1 B1 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(5, 0) = True
        bClossLineCheck(5, 1) = False

        btnOffsetSetB.Enabled = False


        RbtnPanelB1.BackColor = Color.White
        RbtnPanelB2.BackColor = Color.LimeGreen
        RbtnPanelB3.BackColor = Color.White
        RbtnPanelB4.BackColor = Color.White

        lblSystemLineOffsetX_B1.BackColor = Color.White
        lblSystemLineOffsetY_B1.BackColor = Color.White
        lblSystemLineOffsetX_B2.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_B2.BackColor = Color.LimeGreen
        lblSystemLineOffsetX_B3.BackColor = Color.White
        lblSystemLineOffsetY_B3.BackColor = Color.White
        lblSystemLineOffsetX_B4.BackColor = Color.White
        lblSystemLineOffsetY_B4.BackColor = Color.White

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserB.Enabled = True
            btnLaserShotB.Enabled = False
            btnMoveToVisionB.Enabled = False
        End If

        btnMoveToLaserB.BackColor = Color.White
        btnLaserShotB.BackColor = Color.White
        btnMoveToVisionB.BackColor = Color.White

        frmVision.SelectVision(LINE.B, CAM.Cam2)

        nPanelB = 1
    End Sub

    Private Sub RbtnPanelB3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelB3.CheckedChanged

        'sbs1 B1 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(6, 0) = True
        bClossLineCheck(6, 1) = False

        btnOffsetSetB.Enabled = False


        RbtnPanelB1.BackColor = Color.White
        RbtnPanelB2.BackColor = Color.White
        RbtnPanelB3.BackColor = Color.LimeGreen
        RbtnPanelB4.BackColor = Color.White

        lblSystemLineOffsetX_B1.BackColor = Color.White
        lblSystemLineOffsetY_B1.BackColor = Color.White
        lblSystemLineOffsetX_B2.BackColor = Color.White
        lblSystemLineOffsetY_B2.BackColor = Color.White
        lblSystemLineOffsetX_B3.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_B3.BackColor = Color.LimeGreen
        lblSystemLineOffsetX_B4.BackColor = Color.White
        lblSystemLineOffsetY_B4.BackColor = Color.White

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserB.Enabled = True
            btnLaserShotB.Enabled = False
            btnMoveToVisionB.Enabled = False
        End If

        btnMoveToLaserB.BackColor = Color.White
        btnLaserShotB.BackColor = Color.White
        btnMoveToVisionB.BackColor = Color.White

        frmVision.SelectVision(LINE.B, CAM.Cam1)

        nPanelB = 2
    End Sub

    Private Sub RbtnPanelB4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnPanelB4.CheckedChanged

        'sbs1 B1 척을 고르는 버튼을 클릭하면 초기화 시킨다.
        bClossLineCheck(7, 0) = True
        bClossLineCheck(7, 1) = False

        btnOffsetSetB.Enabled = False

        RbtnPanelB1.BackColor = Color.White
        RbtnPanelB2.BackColor = Color.White
        RbtnPanelB3.BackColor = Color.White
        RbtnPanelB4.BackColor = Color.LimeGreen

        lblSystemLineOffsetX_B1.BackColor = Color.White
        lblSystemLineOffsetY_B1.BackColor = Color.White
        lblSystemLineOffsetX_B2.BackColor = Color.White
        lblSystemLineOffsetY_B2.BackColor = Color.White
        lblSystemLineOffsetX_B3.BackColor = Color.White
        lblSystemLineOffsetY_B3.BackColor = Color.White
        lblSystemLineOffsetX_B4.BackColor = Color.LimeGreen
        lblSystemLineOffsetY_B4.BackColor = Color.LimeGreen

        CkAutoFirst = False 'auto사용 초기화

        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            'btnMoveToLaserB.Enabled = True
            btnLaserShotB.Enabled = False
            btnMoveToVisionB.Enabled = False
        End If

        btnMoveToLaserB.BackColor = Color.White
        btnLaserShotB.BackColor = Color.White
        btnMoveToVisionB.BackColor = Color.White

        frmVision.SelectVision(LINE.B, CAM.Cam2)

        nPanelB = 3
    End Sub

    Private Sub btnMoveToLaserB_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveToLaserB.Click

        'If pLDLT.PLC_Infomation.bStageManualControl = False Or CkAutoFirst = False Then 'PC제어권 & 오토모드 1회 미사용시 사용 불가
        '    MsgBox("PC제어권 체크 또는 Auto Seq를 1회 이상 사용해주세요.")
        '    Exit Sub
        'End If
        btnPosCalculB.Enabled = False
        btnOffsetSetB.Enabled = False

        If nModeB = CrossLineMode.MODE_MANUAL Then
            MoveCount += 1
            MoveToLaser(LINE.B, nPanelB)

            btnMoveToLaserB.BackColor = Color.LimeGreen
            btnLaserShotB.BackColor = Color.White
            btnMoveToVisionB.BackColor = Color.White

        Else
            MsgBox("Select Mode [MANUAL]", MsgBoxStyle.OkOnly, "Cross Line")
        End If
    End Sub

    Private Sub btnLaserShotB_Click(sender As System.Object, e As System.EventArgs) Handles btnLaserShotB.Click

        If nModeB = CrossLineMode.MODE_MANUAL Then

            LaserShot(LINE.B, nPanelB)

            btnMoveToLaserB.BackColor = Color.White
            btnLaserShotB.BackColor = Color.LimeGreen
            btnMoveToVisionB.BackColor = Color.White

            MoveCount = 0
        Else
            MsgBox("Select Mode [MANUAL]", MsgBoxStyle.OkOnly, "Cross Line")
        End If
    End Sub

    Private Sub btnMoveToVisionB_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveToVisionB.Click
        If nModeB = CrossLineMode.MODE_MANUAL Then

            MoveToVision(LINE.B, nPanelB)

            btnMoveToLaserB.BackColor = Color.White
            btnLaserShotB.BackColor = Color.White
            btnMoveToVisionB.BackColor = Color.LimeGreen

            bClossLineCheck(nPanelB, 1) = True
            'If bClossLineCheck(nPanelB, 0) = True And bClossLineCheck(nPanelB, 1) = True Then
            '    'btnOffsetSetB.Enabled = True
            '   
            'End If
            'btnPosCalculB.Enabled = True
        Else
            MsgBox("Select Mode [MANUAL]", MsgBoxStyle.OkOnly, "Cross Line")
        End If
    End Sub

    Private Sub btnOffsetSetB_Click(sender As System.Object, e As System.EventArgs) Handles btnOffsetSetB.Click
        'If nModeB = CrossLineMode.MODE_MANUAL Then
        Dim nRet As Integer = -1
        nRet = MsgBox("Do You Wanna Set?", MsgBoxStyle.YesNo, "Cross Line Auto Seq")

        If nRet = 7 Then
            If CkAutoFirst = True Then
                btnMoveToLaserB.Enabled = True
            End If
            btnMoveToVisionB.Enabled = False
            btnLaserShotB.Enabled = False

            btnMoveToLaserB.BackColor = Color.White
            btnLaserShotB.BackColor = Color.White
            btnMoveToVisionB.BackColor = Color.White

            Return
        End If

        'sbs1
        btnOffsetSetB.Enabled = False
        btnOffsetSetB.BackColor = Color.White


        'End If
    End Sub

    Private Sub cbMoveLaserB_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbMoveLaserB.SelectedIndexChanged
        If cbMoveLaserB.Text = "MANUAL" Then
            nModeB = CrossLineMode.MODE_MANUAL
        ElseIf cbMoveLaserB.Text = "AUTO" Then
            nModeB = CrossLineMode.MODE_AUTO
        End If
    End Sub

    Private Sub BtnSeqBStart_Click(sender As System.Object, e As System.EventArgs) Handles BtnSeqBStart.Click
        If pLDLT.PLC_Infomation.bStageManualControl = False Then
            Exit Sub
        End If
        Dim nRet As Integer = -1
        nRet = MsgBox("[PLC] [Cross Position] Click 하셨습니까?", MsgBoxStyle.YesNo, "Cross Line Auto Seq")

        If nRet = 7 Then
            Return
        End If

        'GYN - Scanner Move 0,0
        pScanner(0).RTC6ABSMove(0, 0)
        pScanner(1).RTC6ABSMove(0, 0)
        pScanner(2).RTC6ABSMove(0, 0)
        pScanner(3).RTC6ABSMove(0, 0)

        If nModeB = CrossLineMode.MODE_AUTO Then

            OperationSeq.nLine = 1
            OperationSeq.nPanel = nPanelB
            OperationSeq.nSeqIndex = CrossLineAutoseq.SEQ_MOVETOSTAGE
            bSystemShot(LINE.B, nPanelB) = True
            CkAutoFirst = True 'auto 우선 사용


            btnMoveToLaserB.Enabled = True
            btnPosCalculB.Enabled = True

        End If
    End Sub

    Private Sub BtnSeqBStop_Click(sender As System.Object, e As System.EventArgs) Handles BtnSeqBStop.Click

        OperationSeq.nLine = -1
        OperationSeq.nPanel = -1
        OperationSeq.nSeqIndex = CrossLineAutoseq.SEQ_STOP
        bSystemShot(LINE.B, nPanelB) = False

    End Sub

    Private Sub cbTest_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbTest.CheckedChanged

        If cbTest.Checked = True Then
            bAlignPass = True

            pScanner(0).RTC6_LaserPowerTRUMF(0, pSetSystemParam.dLaserPower(0))
            pScanner(1).RTC6_LaserPowerTRUMF(1, pSetSystemParam.dLaserPower(1))
            pScanner(2).RTC6_LaserPowerTRUMF(2, pSetSystemParam.dLaserPower(2))
            pScanner(3).RTC6_LaserPowerTRUMF(3, pSetSystemParam.dLaserPower(3))

        ElseIf cbTest.Checked = False Then
            bAlignPass = False

            pScanner(0).RTC6_LaserPowerTRUMF(0, 0)
            pScanner(1).RTC6_LaserPowerTRUMF(1, 0)
            pScanner(2).RTC6_LaserPowerTRUMF(2, 0)
            pScanner(3).RTC6_LaserPowerTRUMF(3, 0)
            'Test
            'pScanner(3).RTC6_LaserPowerTRUMF(3, dPower)

            'pSetSystemParam.dLaserPower(m_iIndex) = numRFPLevel.Value   'dPower

        End If

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbSystemFilePath.Text = My.Resources.setLan.ResourceManager.GetObject("FilePath")
            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("SystemPath")
            .Label2.Text = My.Resources.setLan.ResourceManager.GetObject("SystemLogPath")
            .Label3.Text = My.Resources.setLan.ResourceManager.GetObject("ALineAlignImagePath")
            .Label4.Text = My.Resources.setLan.ResourceManager.GetObject("BLineAlignImagePath")
            .Label5.Text = My.Resources.setLan.ResourceManager.GetObject("ScannerSettingPath")
            .btnSystemPath.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .btnSystemLogPath.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .btnSystemImagePathA.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .btnSystemImagePathB.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .btnScannerSettingPath.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .gbSystemOffsetA.Text = My.Resources.setLan.ResourceManager.GetObject("SystemALineOffsetSetting")
            .gbSystemOffsetB.Text = My.Resources.setLan.ResourceManager.GetObject("SystemBLineOffsetSetting")
            .gbSystemPort.Text = My.Resources.setLan.ResourceManager.GetObject("SystemPort")
            .PowerMeter1.Text = My.Resources.setLan.ResourceManager.GetObject("PowerMeter1")
            .PowerMeter2.Text = My.Resources.setLan.ResourceManager.GetObject("PowerMeter2")
            .PowerMeter3.Text = My.Resources.setLan.ResourceManager.GetObject("PowerMeter3")
            .PowerMeter4.Text = My.Resources.setLan.ResourceManager.GetObject("PowerMeter4")
            .PowerMeter_Stage.Text = My.Resources.setLan.ResourceManager.GetObject("PowerStage")
            .btnSetPort.Text = My.Resources.setLan.ResourceManager.GetObject("SetPort")
            .gbVisionDelay.Text = My.Resources.setLan.ResourceManager.GetObject("VisionDelayms")
            .Label19.Text = My.Resources.setLan.ResourceManager.GetObject("Retry")
            .Label12.Text = My.Resources.setLan.ResourceManager.GetObject("Align")
            .btnVisionAlignRetryDelay.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .btnVisionAlignDelay.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .gbPowerMeterTime.Text = My.Resources.setLan.ResourceManager.GetObject("PowerMeterTimems")
            .btnPowerMeterTime.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .gbTrimmingDelay.Text = My.Resources.setLan.ResourceManager.GetObject("TrimmingDelayms")
            .btnTrimmingDelay.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .gbScanMinSpd.Text = My.Resources.setLan.ResourceManager.GetObject("ScannerMinimumSpeed")
            .Label27.Text = My.Resources.setLan.ResourceManager.GetObject("Mark")
            .Label26.Text = My.Resources.setLan.ResourceManager.GetObject("Jump")
            .btnScanSpdLimit.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .gbLogSaveDay.Text = My.Resources.setLan.ResourceManager.GetObject("DeleteAfter")
            .Label23.Text = My.Resources.setLan.ResourceManager.GetObject("Log")
            .Label10.Text = My.Resources.setLan.ResourceManager.GetObject("Image")
            .btnSaveDay.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .gbDustCollector.Text = My.Resources.setLan.ResourceManager.GetObject("DustCollector")
            .Label13.Text = My.Resources.setLan.ResourceManager.GetObject("Timer")
            .btnDustStopTimer.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .btnDustCollectorRun.Text = My.Resources.setLan.ResourceManager.GetObject("Run")
            .btnSystemParamSave.Text = My.Resources.setLan.ResourceManager.GetObject("SaveSystemParam")
            '.cbLightUse.Text = My.Resources.setLan.ResourceManager.GetObject("LightONOFFUSE")

        End With

    End Sub

    Private Sub RTick_Tick(sender As System.Object, e As System.EventArgs) Handles RTick.Tick '2018.04.26 Ryo , RTick 추가
        If bCheckMoveLaserOK(LINE.A) = True And pLDLT.PC_Infomation.bMoveRequestStageX(LINE.A) = False Then
            btnMoveToLaserA.Enabled = False
            btnLaserShotA.Enabled = True
            bCheckMoveLaserOK(LINE.A) = False

            RTick.Enabled = False
        End If

        If bCheckMoveLaserOK(LINE.B) = True And pLDLT.PC_Infomation.bMoveRequestStageX(LINE.B) = False Then
            btnMoveToLaserB.Enabled = False
            btnLaserShotB.Enabled = True
            bCheckMoveLaserOK(LINE.B) = False

            RTick.Enabled = False
        End If

        If bCheckMoveToVisionOK(LINE.A) = True And pLDLT.PC_Infomation.bMoveRequestStageX(LINE.A) = False Then
            btnPosCalculB.Enabled = True
            bCheckMoveToVisionOK(LINE.A) = False

            RTick.Enabled = False
        End If

        If bCheckMoveToVisionOK(LINE.B) = True And pLDLT.PC_Infomation.bMoveRequestStageX(LINE.B) = False Then
            btnPosCalculB.Enabled = True
            bCheckMoveToVisionOK(LINE.B) = False

            RTick.Enabled = False
        End If
        'Test 20181025
        If Me.Visible = True Then
            If pLDLT.PLC_Infomation.bStageManualControl = False Then
                tmpMovePosX = 0
                tmpMovePosY = 0
            End If
        Else
            If pLDLT.PLC_Infomation.bStageManualControl = False Then
                tmpMovePosX = 0
                tmpMovePosY = 0
            End If
            RTick.Enabled = False
        End If


    End Sub


    Private Sub btnPosCalculA_Click(sender As System.Object, e As System.EventArgs) Handles btnPosCalculA.Click
        OffsetSet(LINE.A, nPanelA)
        btnOffsetSetA.Enabled = False
        If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = False Then
            If dOffsetValueX > 3 Or dOffsetValueY > 3 Or dOffsetValueX < -3 Or dOffsetValueY < -3 Then
                MsgBox("CrossLine Value Over 3mm or -3mm ! Can't save! Back to 'AutoMode'")

                OffsetSetReturn(LINE.A, nPanelA)

                btnOffsetSetA.Enabled = False
            Else
                btnOffsetSetA.BackColor = Color.Lime
                btnOffsetSetA.Enabled = True
                '1번만 누르게
                btnPosCalculA.Enabled = False
                End If
        Else
            btnOffsetSetA.BackColor = Color.Lime
            btnOffsetSetA.Enabled = True
            '1번만 누르게
            btnPosCalculA.Enabled = False
            End If
    End Sub

    Private Sub btnPosCalculB_Click(sender As System.Object, e As System.EventArgs) Handles btnPosCalculB.Click
        OffsetSet(LINE.B, nPanelB)
        btnOffsetSetB.Enabled = False
        If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = False Then
            If dOffsetValueX > 3 Or dOffsetValueY > 3 Or dOffsetValueX < -3 Or dOffsetValueY < -3 Then
                MsgBox("CrossLine Value Over 3mm or -3mm ! Can't save!  Back to 'AutoMode'")
                OffsetSetReturn(LINE.B, nPanelB)

                btnOffsetSetB.Enabled = False
            Else
                btnOffsetSetB.BackColor = Color.Lime
                btnOffsetSetB.Enabled = True
                '1번만 누르게
                btnPosCalculB.Enabled = False
            End If
        Else
            btnOffsetSetB.BackColor = Color.Lime
            btnOffsetSetB.Enabled = True
            '1번만 누르게
            btnPosCalculB.Enabled = False
        End If
    End Sub

    Private Sub btnPowerLimitSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerLimitSave.Click
        On Error GoTo SysErr
        modPub.SystemLog("ctrlSettingSysParam -- btnPowerLimitSave Click")

        pSetSystemParam.nLaserPowerMaxLimit = numPowerMax.Value
        pSetSystemParam.nLaserPowerMinLimit = numPowerMin.Value
        Exit Sub
SysErr:
    End Sub
    '20200317 카메라 사용모드
    Private Sub btnCamUseA_Click(sender As System.Object, e As System.EventArgs) Handles btnCamUseA.Click
        If pSetSystemParam.btnCameraAUse = 1 Then
            pSetSystemParam.btnCameraAUse = 0
            btnCamUseA.BackColor = Color.White
        Else
            pSetSystemParam.btnCameraAUse = 1
            btnCamUseA.BackColor = Color.Lime
        End If
    End Sub

    Private Sub btnCamUseB_Click(sender As System.Object, e As System.EventArgs) Handles btnCamUseB.Click
        If pSetSystemParam.btnCameraBUse = 1 Then
            pSetSystemParam.btnCameraBUse = 0
            btnCamUseB.BackColor = Color.White
        Else
            pSetSystemParam.btnCameraBUse = 1
            btnCamUseB.BackColor = Color.Lime
        End If
    End Sub

    Private Sub btnCamUse_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCamUse_1.Click
        If pSetSystemParam.btnCameraUseMode_A1 = 1 Then
            pSetSystemParam.btnCameraUseMode_A1 = 0
            btnCamUse_1.BackColor = Color.White
        Else
            pSetSystemParam.btnCameraUseMode_A1 = 1
            btnCamUse_1.BackColor = Color.Lime
        End If
    End Sub

    Private Sub btnCamUse_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCamUse_2.Click
        If pSetSystemParam.btnCameraUseMode_A2 = 1 Then
            pSetSystemParam.btnCameraUseMode_A2 = 0
            btnCamUse_2.BackColor = Color.White
        Else
            pSetSystemParam.btnCameraUseMode_A2 = 1
            btnCamUse_2.BackColor = Color.Lime
        End If
    End Sub

    Private Sub btnCamUse_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCamUse_3.Click
        If pSetSystemParam.btnCameraUseMode_B1 = 1 Then
            pSetSystemParam.btnCameraUseMode_B1 = 0
            btnCamUse_3.BackColor = Color.White
        Else
            pSetSystemParam.btnCameraUseMode_B1 = 1
            btnCamUse_3.BackColor = Color.Lime
        End If
    End Sub

    Private Sub btnCamUse_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCamUse_4.Click
        If pSetSystemParam.btnCameraUseMode_B2 = 1 Then
            pSetSystemParam.btnCameraUseMode_B2 = 0
            btnCamUse_4.BackColor = Color.White
        Else
            pSetSystemParam.btnCameraUseMode_B2 = 1
            btnCamUse_4.BackColor = Color.Lime
        End If
    End Sub
End Class
