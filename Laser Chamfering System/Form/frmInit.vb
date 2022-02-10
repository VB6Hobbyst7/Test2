Public Class frmInit
    Dim nLaserSeqIndex(3) As Integer
    Dim nScannerSeqIndex(3) As Integer
    Dim nVisionSeqIndex(1, 1) As Integer

    Dim nLightSeqIndex As Integer = 0

    Dim nPLC_SeqIndex As Integer = 0
    Dim nPowerMeterSeqIndex(4) As Integer


    Public nDustCollectorSeqIndex(1) As Integer
    Public bDustCollectorInitComp(1) As Boolean

    Dim nDustInverterSeqIndex(1) As Integer

    Dim bLaserInitComp(3) As Boolean
    Dim bScannerInitComp(3) As Boolean
    Dim bVisionInitComp(1, 1) As Boolean
    Dim bLightInitComp As Boolean = False
    Dim bDustInitComp As Boolean = False
    Dim bPLC_InitComp As Boolean = False
    Dim bPowerMeterInitComp(4) As Boolean

    Dim bDustInverter As Boolean = False   '전체초기화에서 인버터는 취합 안함 , 이유는 솔직히 없어도 모른다 lsuny

    Public bDisplaceConnect As Boolean = False

    Dim nLaserErrCnt(3) As Integer

    Private Sub frmInit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- frmInit_Load")

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- frmInit_Load")
    End Sub

    Private Sub frmInit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- frmInit_FormClosing")
        tmInit.Enabled = False
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- frmInit_FormClosing")
    End Sub

    Private Sub btnInitLaser1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitLaser1.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitLaser_Click")

        Dim nIndex As Integer = 0
        pLaser(nIndex).Connect(pCurSystemParam.nPortLaser(nIndex), clsLaser.BaudRate.n19200)
        'pLaser(nIndex).Initialize(nIndex)
        LaserInitAlarm(0) = True
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitLaser_Click")

    End Sub

    Private Sub btnInitLaser2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitLaser2.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitLaser2_Click")
        Dim nIndex As Integer = 1
        pLaser(nIndex).Connect(pCurSystemParam.nPortLaser(nIndex), clsLaser.BaudRate.n19200)
        'pLaser(nIndex).Initialize(nIndex)
        LaserInitAlarm(1) = True
        
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitLaser2_Click")
    End Sub

    Private Sub btnInitLaser3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitLaser3.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitLaser3_Click")
        Dim nIndex As Integer = 2
        pLaser(nIndex).Connect(pCurSystemParam.nPortLaser(nIndex), clsLaser.BaudRate.n19200)
        'pLaser(nIndex).Initialize(nIndex)
        LaserInitAlarm(2) = True
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitLaser2_Click")
    End Sub


    Private Sub btnInitLaser4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitLaser4.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitLaser4_Click")
        Dim nIndex As Integer = 3
        pLaser(nIndex).Connect(pCurSystemParam.nPortLaser(nIndex), clsLaser.BaudRate.n19200)
        'pLaser(nIndex).Initialize(nIndex)
        LaserInitAlarm(3) = True
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitLaser2_Click")
    End Sub

    Public Sub StartInitScanner(ByVal nIndex As Integer)
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- StartInitScanner" & (nIndex + 1).ToString)

        nScannerSeqIndex(nIndex) = 1
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitScanner1_Click")

    End Sub
    Private Sub btnInitScanner1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitScanner1.Click
        StartInitScanner(0)
    End Sub

    Private Sub btnInitScanner2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitScanner2.Click
        StartInitScanner(1)

    End Sub


    Private Sub btnInitScanner3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitScanner3.Click
        StartInitScanner(2)

    End Sub

    Private Sub btnInitScanner4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitScanner4.Click
        StartInitScanner(3)

    End Sub


    Private Sub btnPowerMeter_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerMeter_1.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnPowerMeter_1_Click")
        Dim nIndex As Integer = 0

        'Power Meter wavelengh 355로 고정
        If pPowerMeter(nIndex).Connect(pCurSystemParam.nPortPowerMeter(nIndex), 57600) = True Then
            'pPowerMeter(nIndex).Reset()
            pPowerMeter(nIndex).SetWaveLenth(clsPowerMeter.WaveLength.nm_355)
            'pPowerMeter(nIndex).EnergyMode(False)
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnPowerMeter_1_Click")
    End Sub

    Private Sub btnPowerMeter_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerMeter_2.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnPowerMeter_2_Click")
        Dim nIndex As Integer = 1

        'Power Meter wavelengh 355로 고정
        If pPowerMeter(nIndex).Connect(pCurSystemParam.nPortPowerMeter(nIndex), 57600) = True Then
            'pPowerMeter(nIndex).Reset()
            pPowerMeter(nIndex).SetWaveLenth(clsPowerMeter.WaveLength.nm_355)
            'pPowerMeter(nIndex).EnergyMode(False)
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnPowerMeter_2_Click")
    End Sub

    Private Sub btnPowerMeter_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerMeter_3.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnPowerMeter_3_Click")
        Dim nIndex As Integer = 2

        'Power Meter wavelengh 355로 고정
        If pPowerMeter(nIndex).Connect(pCurSystemParam.nPortPowerMeter(nIndex), 57600) = True Then
            'pPowerMeter(nIndex).Reset()
            pPowerMeter(nIndex).SetWaveLenth(clsPowerMeter.WaveLength.nm_355)
            'pPowerMeter(nIndex).EnergyMode(False)
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnPowerMeter_3_Click")
    End Sub

    Private Sub btnPowerMeter_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerMeter_4.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnPowerMeter_4_Click")
        Dim nIndex As Integer = 3

        'Power Meter wavelengh 355로 고정
        If pPowerMeter(nIndex).Connect(pCurSystemParam.nPortPowerMeter(nIndex), 57600) = True Then
            'pPowerMeter(nIndex).Reset()
            pPowerMeter(nIndex).SetWaveLenth(clsPowerMeter.WaveLength.nm_355)
            'pPowerMeter(nIndex).EnergyMode(False)
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnPowerMeter_4_Click")
    End Sub

    Private Sub btnPowerMeter_Stage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPowerMeter_Stage.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnPowerMeter_Stage_Click")
        Dim nIndex As Integer = 4

        'Power Meter wavelengh 355로 고정
        If pPowerMeter(nIndex).Connect(pCurSystemParam.nPortPowerMeter(nIndex), 57600) = True Then
            'pPowerMeter(nIndex).Reset()
            pPowerMeter(nIndex).SetWaveLenth(clsPowerMeter.WaveLength.nm_355)
            'pPowerMeter(nIndex).EnergyMode(False)
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnPowerMeter_Stage_Click")
    End Sub


    Private Sub btnInitVisionLineA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitVisionLineA1.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitVisionLineA1_Click")
        'nVisionSeqIndex(0, 0) = 1
        If lblVisionA1.BackColor = Color.Green Then

        Else
            'pCamera(0).m_strCam = "Cam" & 1
            'pCamera(0).m_iIndex = 0

            ''GYN - TEST (우선 막고 진행)
            'pCamera(0).Connecting()

            'If pCamera(0).m_bConnected Then
            '    pCamera(0).Configuring()
            'End If

            '' streaming은 view form이 로도된 후에...
            'pCamera(0).StartingStream()
            'pCamera(0).Streaming()
        End If
        

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitVisionLineA1_Click")
    End Sub

    Private Sub btnInitVisionLineA2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitVisionLineA2.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitVisionLineA2_Click")
        'nVisionSeqIndex(0, 1) = 1
        If lblVisionA2.BackColor = Color.Green Then

        Else
            'pCamera(1).m_strCam = "Cam" & 2
            'pCamera(1).m_iIndex = 1

            ''GYN - TEST (우선 막고 진행)
            'pCamera(1).Connecting()

            'If pCamera(1).m_bConnected Then
            '    pCamera(1).Configuring()
            'End If

            '' streaming은 view form이 로도된 후에...
            'pCamera(1).StartingStream()
            'pCamera(1).Streaming()
        End If
        

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitVisionLineA2_Click")
    End Sub

    Private Sub btnInitVisionLineB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitVisionLineB1.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitVisionLineB1_Click")
        'nVisionSeqIndex(1, 0) = 1
        If lblVisionB1.BackColor = Color.Green Then

        Else
            'pCamera(2).m_strCam = "Cam" & 3
            'pCamera(2).m_iIndex = 2

            ''GYN - TEST (우선 막고 진행)
            'pCamera(2).Connecting()

            'If pCamera(2).m_bConnected Then
            '    pCamera(2).Configuring()
            'End If

            '' streaming은 view form이 로도된 후에...
            'pCamera(2).StartingStream()
            'pCamera(2).Streaming()
        End If
        

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitVisionLineB1_Click")
    End Sub

    Private Sub btnInitVisionLineB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitVisionLineB2.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitVisionLineB2_Click")
        'nVisionSeqIndex(1, 1) = 1
        If lblVisionB2.BackColor = Color.Green Then

        Else
            'pCamera(3).m_strCam = "Cam" & 4
            'pCamera(3).m_iIndex = 3

            ''GYN - TEST (우선 막고 진행)
            'pCamera(3).Connecting()

            'If pCamera(3).m_bConnected Then
            '    pCamera(3).Configuring()
            'End If

            '' streaming은 view form이 로도된 후에...
            'pCamera(3).StartingStream()
            'pCamera(3).Streaming()
        End If
        

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitVisionLineB2_Click")
    End Sub

    Private Sub btnInitLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitLight.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitLight_Click")
        InitLight()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitLight_Click")

    End Sub

    Private Sub btnInitDustCollecter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitDustCollecter.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitDustCollecter1_Click")
        nDustCollectorSeqIndex(0) = 1

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitDustCollecter1_Click")
    End Sub

    Private Sub btnInitDustCollecter2_Click(sender As System.Object, e As System.EventArgs) Handles btnInitDustCollecter2.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitDustCollecter2_Click")
        nDustCollectorSeqIndex(1) = 1

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitDustCollecter2_Click")
    End Sub

    Private Sub btnInitPLC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitPLC.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmInit -- btnInitPLC_Click")
        nPLC_SeqIndex = 1

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmInit -- btnInitPLC_Click")
    End Sub

    '    Private Sub InitLaser(ByVal nIndex As Integer)
    '        On Error GoTo SysErr
    '        If nLaserErrCnt(nIndex) > 20 Then
    '            nLaserSeqIndex(nIndex) = 9999
    '        End If

    '        Dim lblLaser(3) As Label

    '        lblLaser(0) = lblLaser1
    '        lblLaser(1) = lblLaser2
    '        lblLaser(2) = lblLaser3
    '        lblLaser(3) = lblLaser4

    '        Select Case nLaserSeqIndex(nIndex)
    '            Case 0

    '            Case 1
    '                If pLaser(nIndex).pLaserStatus.bConnect = True Then
    '                    pLaser(nIndex).DisConnect()
    '                End If
    '                If pLaser(nIndex).Connect(pCurSystemParam.nPortLaser(nIndex), clsLaser.BaudRate.n19200) = True Then
    '                    lblLaser(nIndex).BackColor = Color.Yellow
    '                    lblLaser(nIndex).Text = "Laser Connect Success"
    '                    nLaserErrCnt(nIndex) = 0
    '                    nLaserSeqIndex(nIndex) = 2
    '                Else
    '                    nLaserErrCnt(nIndex) = nLaserErrCnt(nIndex) + 1
    '                End If

    '            Case 2

    '                If pLaser(nIndex).StartThread() = True Then
    '                    If pLaser(nIndex).m_bLaserInit = True Then
    '                        nLaserSeqIndex(nIndex) = 3
    '                    End If
    '                End If

    '                'nLaserSeqIndex(nIndex) = 3

    '            Case 3
    '                    If pLaser(nIndex).FACK(1) = True Then
    '                        nLaserErrCnt(nIndex) = 0
    '                        'nLaserSeqIndex(nIndex) = nLaserErrCnt(nIndex) + 1
    '                    Else
    '                        nLaserErrCnt(nIndex) = nLaserErrCnt(nIndex) + 1
    '                    End If

    '                    nLaserSeqIndex(nIndex) = 4

    '            Case 4
    '                    'If pLaser(nIndex).SetLaserOn(True) = True Then
    '                    '    nLaserErrCnt(nIndex) = 0
    '                    '    nLaserSeqIndex(nIndex) = 10000
    '                    '    'Else
    '                    '    '    nLaserErrCnt(nIndex) = nLaserErrCnt(nIndex) + 1
    '                    'End If

    '                    nLaserSeqIndex(nIndex) = 10000

    '            Case 999
    '                    If bLaserInitComp(nIndex) = False Then
    '                        lblLaser(nIndex).BackColor = Color.Red
    '                        lblLaser(nIndex).Text = "Stop"
    '                        nLaserErrCnt(nIndex) = 0
    '                    End If
    '                    nLaserSeqIndex(nIndex) = 0

    '            Case 9999
    '                    lblLaser(nIndex).BackColor = Color.Red
    '                    lblLaser(nIndex).Text = "Failed"
    '                    nLaserErrCnt(nIndex) = 0
    '                    nLaserSeqIndex(nIndex) = 0

    '            Case 10000
    '                    bLaserInitComp(nIndex) = True
    '                    lblLaser(nIndex).BackColor = Color.Lime
    '                    lblLaser(nIndex).Text = "Complete"
    '                    nLaserErrCnt(nIndex) = 0
    '                    nLaserSeqIndex(nIndex) = 0

    '        End Select

    '        Exit Sub
    'SysErr:

    '    End Sub


    Private Sub InitScanner(ByVal nIndex As Integer)
        On Error GoTo SysErr

        Dim lblScanner(3) As Label

        lblScanner(0) = lblScanner1
        lblScanner(1) = lblScanner2
        lblScanner(2) = lblScanner3
        lblScanner(3) = lblScanner4

        Dim intSeq As Integer

        intSeq = nScannerSeqIndex(nIndex)

        Select Case intSeq
            Case 0

            Case 1
                pScanner(nIndex).SetCorrectionFilePath(pCurSystemParam.strScannerCorFilePath(nIndex))
                pScanner(nIndex).SetProgramFilePath(pCurSystemParam.strScannerHexFilePath(nIndex))
                pScanner(nIndex).SetScanScale(1000 / pCurSystemParam.nScannerScanScale(nIndex))
                'pScanner(nIndex).SetScanScale(pCurRecipe.nScannerScanScale(nIndex))
                lblScanner(nIndex).Text = "Start Init Scanner" & (nIndex + 1).ToString
                lblScanner(nIndex).BackColor = Color.Yellow
                nScannerSeqIndex(nIndex) = 2

            Case 2
                Dim bInitialized As Boolean = pScanner(nIndex).RTC6Init()

                If bInitialized Then
                    pScanner(nIndex).SetMarkSpeed(pCurSystemParam.nScanMarkSpeed(nIndex))
                    pScanner(nIndex).SetJumpSpeed(pCurSystemParam.nScanJumpSpeed(nIndex))
                    pScanner(nIndex).SetPulsePeriod(pCurSystemParam.nScanHalfPulseWith(nIndex))
                    pScanner(nIndex).SetPulseWidth1(pCurSystemParam.nScanPulseWidth1(nIndex))
                    pScanner(nIndex).SetPulseWidth2(pCurSystemParam.nScanPulseWidth2(nIndex))
                    pScanner(nIndex).SetLaserOnDelay(pCurSystemParam.nScanLaserOnDelay(nIndex))
                    pScanner(nIndex).SetLaserOffDelay(pCurSystemParam.nScanLaserOffDelay(nIndex))
                    pScanner(nIndex).SetJumpDelay(pCurSystemParam.nScanJumpDelay(nIndex))
                    pScanner(nIndex).SetMarkDelay(pCurSystemParam.nScanMarkDelay(nIndex))
                    pScanner(nIndex).SetPolygonDelay(pCurSystemParam.nScanPolygonDelay(nIndex))
                    lblScanner(nIndex).Text = "Scanner" & (nIndex + 1).ToString & "Parameter Apply"
                    lblScanner(nIndex).BackColor = Color.Yellow
                    nScannerSeqIndex(nIndex) = 3
                Else
                    nScannerSeqIndex(nIndex) = 9999
                End If

            Case 3
                If pScanner(nIndex).RTC6ParamApply() = True Then
                    lblScanner(nIndex).Text = "Scanner" & (nIndex + 1).ToString & "Parameter Apply Complete"
                    pScanner(nIndex).RTC6SetMatrix(0)
                    lblScanner(nIndex).BackColor = Color.LightGreen
                    nScannerSeqIndex(nIndex) = 4
                Else
                    nScannerSeqIndex(nIndex) = 9999
                End If

            Case 4
                bScannerInitComp(nIndex) = True
                lblScanner(nIndex).Text = "Complete"
                lblScanner(nIndex).BackColor = Color.Lime
                nScannerSeqIndex(nIndex) = 5

            Case 5  'Laser Power 전달.

                System.Threading.Thread.Sleep(500)

                'Dim dPower As Double = 0
                'Dim dTempPower As Double = 0
                'dTempPower = pCurSystemParam.dLaserPower(nIndex)

                ''% 입력을 0~10V로 변경 적용. :10V면... 30W 출력. 5V면... 15W 출력되야 함.
                'dPower = (dTempPower / 10)
                'pScanner(nIndex).RTC6_LaserPowerTRUMF(nIndex, dPower)

                nScannerSeqIndex(nIndex) = 0

            Case 999
                If bScannerInitComp(1) = False Then
                    lblScanner(nIndex).Text = "Stop"
                    lblScanner(nIndex).BackColor = Color.Red
                End If
                nScannerSeqIndex(nIndex) = 0

            Case 9999
                lblScanner(nIndex).Text = "Failed"
                lblScanner(nIndex).BackColor = Color.Red
                nScannerSeqIndex(nIndex) = 0

        End Select

        Exit Sub
SysErr:


    End Sub




    Private Sub InitLight()
        On Error GoTo SysErr

        pLight.Connect(modParam.pCurSystemParam.nPortLight)

        Exit Sub
SysErr:

    End Sub

    Private Sub InitPLC()
        On Error GoTo SysErr

        Select Case nPLC_SeqIndex

            Case 0

            Case 1
                If pMXComponent.IsOpened() = True Then
                    pMXComponent.Close()
                End If


                pMXComponent.Initializing("D:\\MxComponent.csv")

                If pMXComponent.Open(1) = True Then
                    lblPLC.Text = "PLC Connect Success"
                    pLDLT.ResetMoveBit()
                    lblPLC.BackColor = Color.Yellow
                    nPLC_SeqIndex = 2
                Else
                    nPLC_SeqIndex = 9999
                End If

            Case 2
                bPLC_InitComp = True
                lblPLC.Text = "Complete"
                lblPLC.BackColor = Color.Lime
                nPLC_SeqIndex = 0



            Case 999
                If bPLC_InitComp = False Then
                    lblPLC.Text = "Stop"
                    lblPLC.BackColor = Color.Red
                End If
                nPLC_SeqIndex = 0



            Case 9999
                lblPLC.Text = "Failed"
                lblPLC.BackColor = Color.Red
                nPLC_SeqIndex = 0



        End Select

        Exit Sub
SysErr:

    End Sub
    
    Private Sub InitPowerMeter(ByVal nIndex As Integer)
        Dim lblPowerMeter(4) As Label
        Dim lblPowerMeterStatus(4) As Label

        lblPowerMeter(0) = lblPowerMeter_1
        lblPowerMeter(1) = lblPowerMeter_2
        lblPowerMeter(2) = lblPowerMeter_3
        lblPowerMeter(3) = lblPowerMeter_4
        lblPowerMeter(4) = lblPowerMeter_Stage

        Try
            Select Case nPowerMeterSeqIndex(nIndex)
                Case 0

                Case 1
                    If pPowerMeter(nIndex).PowerMeterStatus.bConnect = True Then
                        pPowerMeter(nIndex).EndPowerMeter()
                    End If
                    If pPowerMeter(nIndex).Connect(pCurSystemParam.nPortPowerMeter(nIndex), 57600) = True Then
                        lblPowerMeter(nIndex).Text = "Power Meter Conect Success"
                        lblPowerMeter(nIndex).BackColor = Color.Yellow
                        nPowerMeterSeqIndex(nIndex) = 2
                    Else
                        nPowerMeterSeqIndex(nIndex) = 9999
                    End If

                Case 2
                    pPowerMeter(nIndex).Reset()
                    pPowerMeter(nIndex).SetWaveLenth(clsPowerMeter.WaveLength.nm_355)
                    pPowerMeter(nIndex).EnergyMode(False)
                    nPowerMeterSeqIndex(nIndex) = 3

                Case 3
                    lblPowerMeter(nIndex).Text = "Complete"
                    lblPowerMeter(nIndex).BackColor = Color.Lime

                    bPowerMeterInitComp(nIndex) = True
                    nPowerMeterSeqIndex(nIndex) = 0

                Case 999
                    If bPowerMeterInitComp(nIndex) = False Then
                        lblPowerMeter(nIndex).Text = "Stop"
                        lblPowerMeter(nIndex).BackColor = Color.Red
                    End If
                    nPowerMeterSeqIndex(nIndex) = 0

                Case 9999
                    bPowerMeterInitComp(nIndex) = False
                    lblPowerMeter(nIndex).Text = "FAILED"
                    lblPowerMeter(nIndex).BackColor = Color.Crimson
                    nPowerMeterSeqIndex(nIndex) = 0
            End Select
        Catch ex As Exception

        End Try
    End Sub


    Private Sub InitDustCollector(ByVal nIndex As Integer)
        Static bRun As Boolean = False
        If bRun = True Then Exit Sub
        Dim Status(0) As Label
        Dim Machine_Status(1) As Label

        bRun = True

        Status(0) = lblDust
        'Status(1) = lblDust2
        Machine_Status(0) = frmMachine.lblDust
        
        Select Case nDustCollectorSeqIndex(nIndex)
            Case 0

            Case 1
                pDustCollector(nIndex).EndThread()
                If pDustCollector(nIndex).OpenPort(pCurSystemParam.nPortDustCollecter(nIndex)) = True Then
                    Status(nIndex).Text = "Dust Collector Connect Success"
                    Status(nIndex).BackColor = Color.Yellow
                    nDustCollectorSeqIndex(nIndex) = 2
                Else
                    nDustCollectorSeqIndex(nIndex) = 9999
                End If

            Case 2
                'GYN - 이건 아직 잘 안도니깐 막아놓자.
                pDustCollector(nIndex).StartThread()
                nDustCollectorSeqIndex(nIndex) = 3

            Case 3
                Status(nIndex).Text = "Complete"
                Status(nIndex).BackColor = Color.Lime
                bDustCollectorInitComp(nIndex) = True
                nDustCollectorSeqIndex(nIndex) = 0



            Case 9999
                bDustCollectorInitComp(nIndex) = False
                Status(nIndex).Text = "FAILED"
                Status(nIndex).BackColor = Color.Crimson
                Machine_Status(nIndex).BackColor = Color.Crimson
                Machine_Status(nIndex).Text = "FAILED"
                nDustCollectorSeqIndex(nIndex) = 0

        End Select

        bRun = False
        Exit Sub
SysErr:
        bRun = False
    End Sub

    Private Sub InitDustInverter(ByVal nIndex As Integer)
        Static bRun As Boolean = False
        If bRun = True Then Exit Sub
        bRun = True

        Select Case nDustInverterSeqIndex(nIndex)
            Case 0

            Case 1
                pDustCollector(nIndex).EndThread()
                If pDustInverter(nIndex).OpenPort(pCurSystemParam.nPortDustInverter(nIndex)) = True Then
                    nDustInverterSeqIndex(nIndex) = 2
                Else
                    nDustInverterSeqIndex(nIndex) = 9999
                End If

            Case 2
                pDustInverter(nIndex).StartThread()

                nDustInverterSeqIndex(nIndex) = 3

            Case 3
                'bDustCollectorInitComp = True
                nDustInverterSeqIndex(nIndex) = 4


            Case 999
                'If bDustCollectorInitComp = False Then
                lblDust.Text = "Stop"
                lblDust.BackColor = Color.Red
                'End If
                nDustInverterSeqIndex(nIndex) = 0



            Case 9999
                'bDustCollectorInitComp = False
                lblDust.Text = "FAILED"
                lblDust.BackColor = Color.Crimson
                frmMachine.lblDust.BackColor = Color.Crimson
                frmMachine.lblDust.Text = "FAILED"
                nDustInverterSeqIndex(nIndex) = 0



        End Select

        bRun = False
        Exit Sub
SysErr:
        bRun = False
    End Sub


    Private Sub tmInit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmInit.Tick
        On Error GoTo SysErr

        'For i = 0 To 3 'Step 3
        '    InitLaser(i)
        'Next

        'For i = 0 To 3 Step 3
        'InitScanner(i)
        'Next
        UpdateStatus()

        'InitLaser(0)
        'InitLaser(1)
        'InitLaser(2)
        'InitLaser(3)

        InitScanner(0)
        InitScanner(1)
        InitScanner(2)
        InitScanner(3)

        'InitVision(LINE.A, 0)
        'InitVision(LINE.A, 1)
        'InitVision(LINE.B, 0)
        'InitVision(LINE.B, 1)
        'InitLight()
        'InitPLC()
        'InitPowerMeter(0)
        'InitPowerMeter(1)
        'InitPowerMeter(2)
        'InitPowerMeter(3)
        'InitPowerMeter(4)

        InitDustCollector(0)
        InitDustCollector(1)

        'If pLDLT.PLC_Infomation.bPLC_ManualMode(LINE.A) = False Or pLDLT.PLC_Infomation.bPLC_ManualMode(LINE.B) = False Then
        '    gbInit.Enabled = False
        'Else
        '    gbInit.Enabled = True
        'End If

        Exit Sub
SysErr:

    End Sub

    Private Sub btnInitAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitAll.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmInit -- btnInitAll Click")

        'Laser
        pLaser(0).Connect(pCurSystemParam.nPortLaser(0), clsLaser.BaudRate.n19200)
        'pLaser(0).Initialize(0)
        System.Threading.Thread.Sleep(200)
        LaserInitAlarm(0) = True
        pLaser(1).Connect(pCurSystemParam.nPortLaser(1), clsLaser.BaudRate.n19200)
        'pLaser(1).Initialize(1)
        System.Threading.Thread.Sleep(200)
        LaserInitAlarm(1) = True
        pLaser(2).Connect(pCurSystemParam.nPortLaser(2), clsLaser.BaudRate.n19200)
        'pLaser(2).Initialize(2)
        System.Threading.Thread.Sleep(200)
        LaserInitAlarm(2) = True
        pLaser(3).Connect(pCurSystemParam.nPortLaser(3), clsLaser.BaudRate.n19200)
        'pLaser(3).Initialize(3)
        System.Threading.Thread.Sleep(200)
        LaserInitAlarm(3) = True

        'Scanner
        If lblScanner1.BackColor = Color.Green Or lblScanner1.BackColor = Color.Lime Then
        Else
            StartInitScanner(0)
            System.Threading.Thread.Sleep(200)
        End If

        If lblScanner2.BackColor = Color.Green Or lblScanner2.BackColor = Color.Lime Then
        Else
            StartInitScanner(1)
            System.Threading.Thread.Sleep(200)
        End If

        If lblScanner3.BackColor = Color.Green Or lblScanner3.BackColor = Color.Lime Then
        Else
            StartInitScanner(2)
            System.Threading.Thread.Sleep(200)
        End If

        If lblScanner4.BackColor = Color.Green Or lblScanner4.BackColor = Color.Lime Then
        Else
            StartInitScanner(3)
            System.Threading.Thread.Sleep(200)
        End If

       

        'PowerMeter
        btnPowerMeter_1_Click(Nothing, Nothing)
        System.Threading.Thread.Sleep(200)
        btnPowerMeter_2_Click(Nothing, Nothing)
        System.Threading.Thread.Sleep(200)
        btnPowerMeter_3_Click(Nothing, Nothing)
        System.Threading.Thread.Sleep(200)
        btnPowerMeter_4_Click(Nothing, Nothing)
        System.Threading.Thread.Sleep(200)
        btnPowerMeter_Stage_Click(Nothing, Nothing)
        System.Threading.Thread.Sleep(200)

        'Camera
        '시작할때 Init.

        'Light
        InitLight()

        'Chiller
        InitChiller(0)
        System.Threading.Thread.Sleep(200)
        InitChiller(1)
        System.Threading.Thread.Sleep(200)
        InitChiller(2)
        System.Threading.Thread.Sleep(200)
        InitChiller(3)
        System.Threading.Thread.Sleep(200)

        'DustCollecter
        nDustCollectorSeqIndex(0) = 1
        System.Threading.Thread.Sleep(200)
        'nDustCollectorSeqIndex(1) = 1
        'System.Threading.Thread.Sleep(200)

        'PLC
        '시작할때 Init.

        'For index = 0 To 3
        '    InitChiller(index)
        '    pPowerMeter(index).Connect(pCurSystemParam.nPortPowerMeter(index), 57600)
        'Next
        'pPowerMeter(4).Connect(pCurSystemParam.nPortPowerMeter(4), 57600)

        'pDustCollector(0).OpenPort(pCurSystemParam.nPortDustCollecter(0))
        'pDustCollector(1).OpenPort(pCurSystemParam.nPortDustCollecter(1))

        'InitLight()

        'For index = 0 To 3
        '    nLaserSeqIndex(index) = 1
        '    nScannerSeqIndex(index) = 1
        '    System.Threading.Thread.Sleep(200)
        'Next

        ' Mil dcf 파일로 연결하기 때문에 Stctech API 연결은 삭제
        ''Camera1
        'If lblVisionA1.BackColor = Color.Green Then

        'Else
        '    pCamera(0).m_strCam = "Cam" & 1
        '    pCamera(0).m_iIndex = 0
        '    pCamera(0).Connecting()
        '    If pCamera(0).m_bConnected Then
        '        pCamera(0).Configuring()
        '    End If
        '    pCamera(0).StartingStream()
        '    pCamera(0).Streaming()
        '    System.Threading.Thread.Sleep(200)
        'End If

        ''Camera2
        'If lblVisionA2.BackColor = Color.Green Then

        'Else
        '    pCamera(1).m_strCam = "Cam" & 2
        '    pCamera(1).m_iIndex = 1
        '    pCamera(1).Connecting()
        '    If pCamera(1).m_bConnected Then
        '        pCamera(1).Configuring()
        '    End If
        '    pCamera(1).StartingStream()
        '    pCamera(1).Streaming()
        '    System.Threading.Thread.Sleep(200)

        'End If

        ''Camera3
        'If lblVisionB1.BackColor = Color.Green Then

        'Else
        '    pCamera(2).m_strCam = "Cam" & 3
        '    pCamera(2).m_iIndex = 2
        '    pCamera(2).Connecting()
        '    If pCamera(2).m_bConnected Then
        '        pCamera(2).Configuring()
        '    End If
        '    pCamera(2).StartingStream()
        '    pCamera(2).Streaming()
        '    System.Threading.Thread.Sleep(200)

        'End If

        ''Camera4
        'If lblVisionB2.BackColor = Color.Green Then

        'Else
        '    pCamera(3).m_strCam = "Cam" & 4
        '    pCamera(3).m_iIndex = 3
        '    pCamera(3).Connecting()
        '    If pCamera(3).m_bConnected Then
        '        pCamera(3).Configuring()
        '    End If
        '    pCamera(3).StartingStream()
        '    pCamera(3).Streaming()
        '    System.Threading.Thread.Sleep(200)

        'End If
        

        'Displace

        pDisplacePlcThread.bDisplaceConnect = pDisplace.Connect(pCurSystemParam.nPortDisplace)
        System.Threading.Thread.Sleep(200)
        'Laser IO

        'pIO.Initialize()

        Exit Sub
SysErr:

    End Sub

    Private Sub frmInit_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            tmInit.Enabled = True
        Else
            tmInit.Enabled = False
        End If
    End Sub

    Private Sub UpdateStatus()

        Dim lblLaser() As Label = {lblLaser1, lblLaser2, lblLaser3, lblLaser4}
        Dim lblScanner() As Label = {lblScanner1, lblScanner2, lblScanner3, lblScanner4}
        Dim lblVision() As Label = {lblVisionA1, lblVisionA2, lblVisionB1, lblVisionB2}
        Dim lblPowermeter() As Label = {lblPowerMeter_1, lblPowerMeter_2, lblPowerMeter_3, lblPowerMeter_4}
        Dim lblChiller() As Label = {lblChiller1, lblChiller2, lblChiller3, lblChiller4}

        For i = 0 To 3
            'If pLaser(i).bConnect(i) Then
            'If pLaser(i).m_bLaserInit Then
            If pLaser(i).pLaserStatus.bConnect Then
                lblLaser(i).Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
                lblLaser(i).BackColor = Color.Green
            Else
                lblLaser(i).Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
                lblLaser(i).BackColor = Color.Yellow
            End If

            If pPowerMeter(i).PowerMeterStatus.bConnect Then
                lblPowermeter(i).Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
                lblPowermeter(i).BackColor = Color.Green
            Else
                lblPowermeter(i).Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
                lblPowermeter(i).BackColor = Color.Yellow
            End If

            If pScanner(i).pStatus.bAbleWork Then
                lblScanner(i).BackColor = Color.Green
                lblScanner(i).Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            Else
                lblScanner(i).BackColor = Color.Yellow
                lblScanner(i).Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            End If

            If pChiller(i).ChillerComm.IsOpen Then
                lblChiller(i).Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
                lblChiller(i).BackColor = Color.Green
            Else
                lblChiller(i).Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
                lblChiller(i).BackColor = Color.Yellow
            End If
            'ZYX 막음
#If SIMUL <> 1 Then
            'pMilInterface.CheckIP()

            'If pCamera(i).m_bConnected Then
            If pMilInterface.CheckCam(i) = True Then
                lblVision(i).BackColor = Color.Green
                lblVision(i).Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            Else

                lblVision(i).BackColor = Color.Yellow
                lblVision(i).Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            End If
#End If
            

        Next

        If pPowerMeter(4).PowerMeterStatus.bConnect Then
            lblPowerMeter_Stage.Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            lblPowerMeter_Stage.BackColor = Color.Green
        Else
            lblPowerMeter_Stage.Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            lblPowerMeter_Stage.BackColor = Color.Yellow
        End If

        'Dust Collector
        If pDustCollector(0).IsOpen Then
            lblDust.Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            lblDust.BackColor = Color.Green
        Else
            lblDust.Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            lblDust.BackColor = Color.Yellow
        End If
        If pDustCollector(1).IsOpen Then
            lblDust2.Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            lblDust2.BackColor = Color.Green
        Else
            lblDust2.Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            lblDust2.BackColor = Color.Yellow
        End If

        If pLight.IsOpen Then
            lblLight.Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            lblLight.BackColor = Color.Green
        Else
            lblLight.Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            lblLight.BackColor = Color.Yellow
        End If

        ' plc
        If pLDLT.pbConnect Then
            lblPLC.Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            lblPLC.BackColor = Color.Green
        Else
            lblPLC.Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            lblPLC.BackColor = Color.Yellow
        End If

        If pDisplace.IsOpen Then
            lbDisplace.Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
            lbDisplace.BackColor = Color.Green
        Else
            lbDisplace.Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
            lbDisplace.BackColor = Color.Yellow
        End If

        'If pIO.pbConnect Then
        '    lbIO.Text = My.Resources.setLan.ResourceManager.GetObject("Connected")    '"Connected"
        '    lbIO.BackColor = Color.Green
        'Else
        '    lbIO.Text = My.Resources.setLan.ResourceManager.GetObject("NotConnected")    '"Not Connected"
        '    lbIO.BackColor = Color.Yellow
        'End If

    End Sub

    Public Sub InitChiller(ByVal nIndex As Integer)
        modPub.pChiller(nIndex).Init(pCurSystemParam.nPortChiller(nIndex))
    End Sub

    Private Sub btnInitChiller1_Click(sender As System.Object, e As System.EventArgs) Handles btnInitChiller1.Click
        InitChiller(0)
    End Sub

    Private Sub btnInitChiller2_Click(sender As System.Object, e As System.EventArgs) Handles btnInitChiller2.Click
        InitChiller(1)

    End Sub

    Private Sub btnInitChiller3_Click(sender As System.Object, e As System.EventArgs) Handles btnInitChiller3.Click
        InitChiller(2)

    End Sub

    Private Sub btnInitChiller4_Click(sender As System.Object, e As System.EventArgs) Handles btnInitChiller4.Click
        InitChiller(3)

    End Sub

    Private Sub btnInitDisplace_Click(sender As System.Object, e As System.EventArgs) Handles btnInitDisplace.Click
        'pDisplace.Connect(11)
        pDisplacePlcThread.bDisplaceConnect = pDisplace.Connect(pCurSystemParam.nPortDisplace)
    End Sub

    Private Sub btnInitIO_Click(sender As System.Object, e As System.EventArgs) Handles btnInitIO.Click

        'pIO.Initialize()

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbInit.Text = My.Resources.setLan.ResourceManager.GetObject("Init")

            .btnInitLaser1.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitLaser2.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitLaser3.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitLaser4.Text = My.Resources.setLan.ResourceManager.GetObject("Open")

            .btnInitScanner1.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
            .btnInitScanner2.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
            .btnInitScanner3.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
            .btnInitScanner4.Text = My.Resources.setLan.ResourceManager.GetObject("Init")

            .btnPowerMeter_1.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnPowerMeter_2.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnPowerMeter_3.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnPowerMeter_4.Text = My.Resources.setLan.ResourceManager.GetObject("Open")

            .btnPowerMeter_Stage.Text = My.Resources.setLan.ResourceManager.GetObject("Open")

            .btnInitVisionLineA1.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
            .btnInitVisionLineA2.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
            .btnInitVisionLineB1.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
            .btnInitVisionLineB2.Text = My.Resources.setLan.ResourceManager.GetObject("Init")

            .btnInitLight.Text = My.Resources.setLan.ResourceManager.GetObject("Open")

            .btnInitChiller1.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitChiller2.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitChiller3.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitChiller4.Text = My.Resources.setLan.ResourceManager.GetObject("Open")

            .btnInitDustCollecter.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitDustCollecter2.Text = My.Resources.setLan.ResourceManager.GetObject("Open")

            .btnInitDisplace.Text = My.Resources.setLan.ResourceManager.GetObject("Open")
            .btnInitIO.Text = My.Resources.setLan.ResourceManager.GetObject("Open")

            .btnInitPLC.Text = My.Resources.setLan.ResourceManager.GetObject("Init")

            .Label16.Text = My.Resources.setLan.ResourceManager.GetObject("Chiller1")
            .Label20.Text = My.Resources.setLan.ResourceManager.GetObject("Chiller2")
            .Label21.Text = My.Resources.setLan.ResourceManager.GetObject("Chiller3")
            .Label22.Text = My.Resources.setLan.ResourceManager.GetObject("Chiller4")

            .Label4.Text = My.Resources.setLan.ResourceManager.GetObject("Dust1")
            .Label9.Text = My.Resources.setLan.ResourceManager.GetObject("Dust2")

            .Label23.Text = My.Resources.setLan.ResourceManager.GetObject("Displace")

            If StrCulture = "vi" Then
                .Label23.Font = New System.Drawing.Font("맑은 고딕", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Else
                .Label23.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            End If

            Label31.Text = My.Resources.setLan.ResourceManager.GetObject("LIGHT")

        End With

    End Sub

End Class