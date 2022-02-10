Imports System.Threading
Public Class clsOperationSequence
    Dim tmpMsg As String = ""
    Dim tmpSplit() As String = {}
    Dim m_TimeCheck As New clsTimer

    Public nSeqIndex As Integer = 0
    Public nLine As Integer = 0
    Public nPanel As Integer = 0

    Dim tmpMovePosX As Double
    Dim tmpMovePosY As Double
    Public tmpLaserPosX As Double
    Public tmpLaserPosY As Double

    Dim bUsePC As Boolean = False

    Public m_ctrlPcBitdata As New ctrlPcBitdata
    Public m_ctrlPlcBitdata As New ctrlPlcBitdata
    Public m_ctrlLine(1, 3) As ctrlDisplacePart
    Public m_ctrlDisplace As ctrlDisplace

    Public m_MeasureCnt As Integer = 0
    Public m_bAline As Integer

    Private m_startx As Double = 0
    Private m_starty As Double = 0
    Private m_endx As Double = 0
    Private m_endy As Double = 0
    Private m_StartCtsX As Integer = 0
    Private m_StartCtsY As Integer = 0
    Private m_CurrCtsX As Integer = 0
    Private m_CurrCtsY As Integer = 0

    Public strTmp As String
    Public nCnt As String = 1
    Dim PosX As Integer = 0
    Dim PosY As Integer = 0
    Dim bSeqend As Boolean = False
    Public m_DisplaceSeq As Integer = 0
    'auto focus
    Dim ScannerCurPosZ As Double = 0
    Dim StageCurPosX As Double = 0
    Dim StageCurPosY As Double = 0
    Dim Repeat As Integer = 0
    Dim Rev As Boolean = False
    Dim ScannerAxisZ As Integer = 0
    Dim Displace_ZeroSet As Boolean = False


#Region "Thread"
    Private ThreadOperation As Thread
    Public bThreadRunningOperation As Boolean
    Private nKillThread As Integer
    Dim bRead As Boolean

    ReadOnly Property ThreadRunningOperation() As Boolean
        Get
            Return bThreadRunningOperation
        End Get
    End Property

    Function StartOperation() As Boolean
        On Error GoTo SysErr

        ThreadOperation = New Thread(AddressOf OperationSequence)
        nKillThread = 0
        ThreadOperation.SetApartmentState(ApartmentState.MTA)
        ThreadOperation.Priority = ThreadPriority.Lowest
        ThreadOperation.Start()
        StartOperation = True

        Exit Function
SysErr:
        StartOperation = False
        'ErrorMsg = ErrorMsg & "Start Power Meter Thread Error" & ","
    End Function

    Function EndOperation() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThread, 1)
        If bThreadRunningOperation = True Then
            ThreadOperation.Join(1000)
        End If

        ThreadOperation = Nothing
        Return True
        Exit Function
SysErr:
        EndOperation = False
        ' ErrorMsg = ErrorMsg & "End Power Meter Thread Error" & ","
    End Function

    
    Sub OperationSequence()

        On Error GoTo SysErr

        While nKillThread = 0

            CrossLineSeq()
            DisplaceSeq()
            AutoFocusSeq()

            Thread.Sleep(50)

        End While

        bThreadRunningOperation = False
        Exit Sub
SysErr:
        bThreadRunningOperation = False
        'ErrorMsg = ErrorMsg & "Power Meter Status Thread Error" & ","
    End Sub

    Sub CrossLineSeq()
        Select Case nSeqIndex

            Case CrossLineAutoseq.SEQ_STOP

                'WAIT


            Case CrossLineAutoseq.SEQ_MOVETOSTAGE

                tmpMovePosX = pLDLT.PLC_Infomation.dTrimmingPosX(nLine)
                tmpMovePosY = pLDLT.PLC_Infomation.dTrimmingPosY(nLine)

                If pLDLT.PLC_Infomation.dCurPosX(nLine) <> tmpMovePosX Or pLDLT.PLC_Infomation.dCurPosY(nLine) <> tmpMovePosY Then  '현 위치, 명령위치 값 비교하여 맞으면 ㄱㄱ

                    MoveToLaser_Auto(nLine, nPanel)

                End If

                nSeqIndex = CrossLineAutoseq.SEQ_LASERSHOT

            Case CrossLineAutoseq.SEQ_LASERSHOT
                If pLDLT.PLC_Infomation.dCurPosX(nLine) = tmpMovePosX And pLDLT.PLC_Infomation.dCurPosY(nLine) = tmpMovePosY Then  '현 위치, 명령위치 값 비교하여 맞으면 ㄱㄱ
                    For i As Integer = 1 To 500
                        System.Threading.Thread.Sleep(1)
                    Next
                    LaserShot(nLine, nPanel)

                    nSeqIndex = CrossLineAutoseq.SEQ_MOVETOVISION

                End If

            Case CrossLineAutoseq.SEQ_MOVETOVISION
                If LaserShotStatus(nLine, nPanel) = False Then

                    MoveToVision(nLine, nPanel)

                    nSeqIndex = CrossLineAutoseq.SEQ_STOP

                End If

        End Select
    End Sub

    Sub DisplaceSeq()

        Select Case m_DisplaceSeq

            Case 700 '준비

                'If pDisplaceData.pnMaxCnt <> 16 Then
                '    frmMSG.ShowMsg("변위 센서 자동 시퀀스", "변위센서 측정위치 티칭 값을 확인하세요", False, 1)
                '    m_DisplaceSeq = 1000
                '    Return
                'End If
                If pLDLT.pbConnect = False Or pDisplace.IsOpen = False Then
                    frmMSG.ShowMsg("변위 센서 자동 시퀀스", "PLC,변위센서 통신상태를 확인하세요", False, 1)
                    m_DisplaceSeq = 1000
                Else
                    m_DisplaceSeq = 701
                End If

            Case 701

                bSeqend = False
                Displace_ZeroSet = True

                '아래 두개의 SendCmd는 무저껀 순서대로 진행이 되어야 변위센서를 사용할 수 있음
                pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_COM)
                pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_SETTING)
                m_DisplaceSeq = 710
                SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)

            Case 710 '위치이동

                PosX = pDisplaceData.pdValueX(m_MeasureCnt) * 1000
                PosY = pDisplaceData.pdValueY(m_MeasureCnt) * 1000

                pLDLT.MoveStage(pDisplaceData.m_bline, Axis.x, PosX)
                pLDLT.MoveStage(pDisplaceData.m_bline, Axis.y, PosY)

                m_DisplaceSeq = 720
                SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)

            Case 720 '위 seq에서 명령한 위치와 실제 위치를 비교해서 판단
                For i As Integer = 1 To 500
                    System.Threading.Thread.Sleep(1)
                Next
                If pLDLT.PLC_Infomation.dCurPosX(pDisplaceData.m_bline) >= PosX And pLDLT.PLC_Infomation.dCurPosY(pDisplaceData.m_bline) >= PosY Then
                    m_DisplaceSeq = 730
                    SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)
                End If

            Case 730 '측정값을 받아옴

                Dim isOk As Boolean = False
                'If Displace_ZeroSet = True Then
                '    pDisplace.SendCmd(clsDisplace.SetCmd.SET_ZERO_POINT)
                '    System.Threading.Thread.Sleep(200)
                '    Displace_ZeroSet = False
                'End If
                isOk = pDisplace.SendCmd(clsDisplace.GetCmd.GET_VALUE)
                'm_TimeSeq.Restart()
                m_DisplaceSeq = 750
                SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)


            Case 750 '측정 값을 기록
                For i As Integer = 1 To 500
                    System.Threading.Thread.Sleep(1)
                Next
                If pDisplace.m_isRcvComplete = True Then
                    If pDisplaceData.m_bline = 0 Then
                        strTmp = Mid(pDisplace.rtnStr, 4, 8)
                    ElseIf pDisplaceData.m_bline = 1 Then
                        strTmp = Mid(pDisplace.rtnStr, 13, 8)
                    End If


                    DisplaceDataRead = True

                    If strTmp = "-FFFFFFF" Then
                        'frmMSG.ShowMsg("변위센서 시퀀스", "측정값이 상이합니다", False, 1)
                        m_DisplaceSeq = 1000
                    Else
                        pDisplaceData.dGridviewVal(m_MeasureCnt) = CDbl(strTmp)
                        m_DisplaceSeq = 900
                    End If

                End If

                SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)

            Case 800 '측정값을 계산 (아직 미완 최저,최고의 편차가 필요할듯 하다)

                Dim dTotal As Double = 0
                Dim dMax As Double = 0
                Dim dMin As Double = 0
                Dim dStablity As Double = 0
                For i As Integer = 0 To pnMaxCnt - 1
                    dTotal += pDisplaceData.dGridviewVal(i)
                Next

                Dim dTmp As Double = 0

                'And i <> pnMaxCnt - 1
                For i As Integer = 0 To pnMaxCnt - 2
                    For k As Integer = i To pnMaxCnt - 2
                        If pDisplaceData.dGridviewVal(k) > pDisplaceData.dGridviewVal(k + 1) Then
                            dTmp = pDisplaceData.dGridviewVal(k)
                            pDisplaceData.dGridviewVal(k) = pDisplaceData.dGridviewVal(k + 1)
                            pDisplaceData.dGridviewVal(k + 1) = dTmp
                        End If
                    Next
                Next

                dMax = pDisplaceData.dGridviewVal(pnMaxCnt - 1)
                dMin = pDisplaceData.dGridviewVal(0)
                dStablity = dMax - dMin


                'lblAvg1.Text = dTotal / pnMaxCnt
                pDisplaceData.m_lblValueMax(frmSetting.m_ctrlSetting_Displace.tabPanel.SelectedIndex) = dMax
                pDisplaceData.m_lblValueMin(frmSetting.m_ctrlSetting_Displace.tabPanel.SelectedIndex) = dMin
                pDisplaceData.m_lblValueAvg(frmSetting.m_ctrlSetting_Displace.tabPanel.SelectedIndex) = dStablity

                DisplaceMeasureEnd = True
                m_DisplaceSeq = 1000

                SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)

            Case 900 '측정값을 저장
                If DisplaceDataReadok = True Then
                    WriteIni(dp_strLine & Format(Now, " yyyy-MM-dd"), Format(Now, "HH:mm:ss ") & pDisplaceData.pdIndex(m_MeasureCnt) & " ", pDisplaceData.dGridviewVal(m_MeasureCnt), m_DirDisplaceDatasavePath)

                    SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)

                    If m_MeasureCnt = pnMaxCnt - 1 Then
                        m_DisplaceSeq = 1000
                        m_strMsg = "변위센서 측정 완료"
                    Else
                        m_DisplaceSeq = 710
                        m_MeasureCnt += 1
                    End If

                    DisplaceDataReadok = False
                End If

            Case 1000 '동작하지 않는 상태
                m_MeasureCnt = 0

                '추가할게있는지 확인 필요

                If bSeqend = False Then
                    SequenceLog(m_bAline, "변위센서 시퀀스 ::" & m_DisplaceSeq)
                    bSeqend = True
                    If pDisplace.IsOpen Then
                        m_strMsg = "변위센서 자동시퀀스 Ready"
                    Else
                        m_strMsg = "변위센서 통신확인하세요"
                    End If
                End If

            Case 1001 '초기화

        End Select
    End Sub

    Sub AutoFocusSeq()
        'Auto Focus Mode
        Select Case nfocusseq
            Case 0
                '준비
                Repeat = 0

            Case 1
                Select Case pScanNum
                    Case 0
                        ScannerAxisZ = 0
                    Case 1
                        ScannerAxisZ = 1
                    Case 2
                        ScannerAxisZ = 2
                    Case 3
                        ScannerAxisZ = 3
                End Select
                nLine = pbLine
                nfocusseq = 2

            Case 2  '스테이지 시작위치 이동

                StageCurPosX = pbStageX
                StageCurPosY = pbStageY
                pScanPosZ = pLDLT.PLC_Infomation.dCurPosScannerZ(ScannerAxisZ).ToString
                ScannerCurPosZ = pScanPosZ
                '이동명령 한번에 주면 인식 못함
                If pLDLT.PLC_Infomation.dCurPosX(nLine) <> StageCurPosX Or pLDLT.PLC_Infomation.dCurPosY(nLine) <> StageCurPosY Then

                    pLDLT.MoveStage(nLine, Axis.x, StageCurPosX * 1000)
                End If
                nfocusseq = 3

            Case 3  '위치 확인
                If pLDLT.PLC_Infomation.dCurPosX(nLine) = StageCurPosX Then
                    If pLDLT.PLC_Infomation.dCurPosY(nLine) <> StageCurPosY Then
                        pLDLT.MoveStage(nLine, Axis.y, StageCurPosY * 1000)
                    End If
                    System.Threading.Thread.Sleep(100)
                    nfocusseq = 4
                End If

            Case 4  '위치 확인
                If pLDLT.PLC_Infomation.dCurPosY(nLine) = StageCurPosY Then
                    If pLDLT.PLC_Infomation.dCurPosScannerZ(ScannerAxisZ) <> pScanPosZ Then
                        pLDLT.MoveScannerZ(ScannerAxisZ, pScanPosZ * 1000)
                    End If
                    System.Threading.Thread.Sleep(100)
                    nfocusseq = 5
                End If

            Case 5  '위치 확인
                If pLDLT.PLC_Infomation.dCurPosScannerZ(ScannerAxisZ) = ScannerCurPosZ Then
                    System.Threading.Thread.Sleep(100)
                    nfocusseq = 6
                End If

            Case 6  '레이저 샷  스테이지, 스캐너 이동

                AutoFocusLaserShot(pScanNum)
                System.Threading.Thread.Sleep(500)

                AutoFocusStageMove(nLine)
                System.Threading.Thread.Sleep(100)
                AutoFoucusScannerMove(ScannerAxisZ)
                nfocusseq = 3
                Repeat = Repeat + 1
                If Repeat > pbRepeat Then
                    nfocusseq = 7
                End If
                System.Threading.Thread.Sleep(500)
            Case 7


                pLDLT.MoveStage(nLine, Axis.y, 10000)
                pLDLT.MoveScannerZ(ScannerAxisZ, pScanPosZ * 1000)

                nfocusseq = 0

        End Select
    End Sub

    Sub Close()

        If Not (ThreadOperation Is Nothing) Then
            ThreadOperation.Join(10000)
        End If

        Call Finalize()

    End Sub
#End Region

    Private Sub MoveToLaser_Auto(ByVal nLine As Integer, ByVal nlndex As Integer)
        On Error GoTo SysErr

        'If nlndex = 0 Or nlndex = 0 Then
        tmpMovePosX = pLDLT.PLC_Infomation.dTrimmingPosX(nLine)
        tmpMovePosY = pLDLT.PLC_Infomation.dTrimmingPosY(nLine)
        'End If

        pLDLT.MoveStage(nLine, Axis.x, tmpMovePosX)
        pLDLT.MoveStage(nLine, Axis.y, tmpMovePosY)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & "[Error] MoveToLaser_Auto")

    End Sub

    Private Sub LaserShot(ByVal nLine As Integer, ByVal nIndex As Integer)
        On Error GoTo SysErr

        Select Case nLine

            Case LINE.A

                Select Case nIndex

                    Case Panel.p1

                        pScanner(Panel.p2).RTC6ResetList()
                        pScanner(Panel.p2).RTC6_CrossShot(2000)

                    Case Panel.p2

                        pScanner(Panel.p1).RTC6ResetList()
                        pScanner(Panel.p1).RTC6_CrossShot(2000)

                    Case Panel.p3

                        pScanner(Panel.p4).RTC6ResetList()
                        pScanner(Panel.p4).RTC6_CrossShot(2000)

                    Case Panel.p4

                        pScanner(Panel.p3).RTC6ResetList()
                        pScanner(Panel.p3).RTC6_CrossShot(2000)

                End Select

            Case LINE.B

                Select Case nIndex

                    Case Panel.p1

                        pScanner(Panel.p1).RTC6ResetList()
                        pScanner(Panel.p1).RTC6_CrossShot(2000)

                    Case Panel.p2

                        pScanner(Panel.p2).RTC6ResetList()
                        pScanner(Panel.p2).RTC6_CrossShot(2000)

                    Case Panel.p3

                        pScanner(Panel.p3).RTC6ResetList()
                        pScanner(Panel.p3).RTC6_CrossShot(2000)

                    Case Panel.p4

                        pScanner(Panel.p4).RTC6ResetList()
                        pScanner(Panel.p4).RTC6_CrossShot(2000)

                End Select

        End Select

        tmpLaserPosX = pLDLT.PLC_Infomation.dCurPosX(nLine)
        tmpLaserPosY = pLDLT.PLC_Infomation.dCurPosY(nLine)

SysErr:
        modPub.ErrorLog(Err.Description & " LaserShot Error")
    End Sub

    Private Sub AutoFocusStageMove(ByVal nLine As Integer)
        On Error GoTo SysErr
        Dim temp As Integer = -1
        If pbStageup = True Then
            If pbLineAxis = True Then
                StageCurPosX = StageCurPosX + pbPitch
                pLDLT.MoveStage(nLine, Axis.x, StageCurPosX)

            ElseIf pbLineAxis = False Then
                StageCurPosY = StageCurPosY + pbPitch
                pLDLT.MoveStage(nLine, Axis.y, StageCurPosY)

            End If
        ElseIf pbStageup = False Then
            If pbLineAxis = True Then
                StageCurPosX = StageCurPosX + (pbPitch * temp)
                pLDLT.MoveStage(nLine, Axis.x, StageCurPosX)

            ElseIf pbLineAxis = False Then
                StageCurPosY = StageCurPosY + (pbPitch * temp)
                pLDLT.MoveStage(nLine, Axis.y, StageCurPosY)

            End If
        End If


        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & "[Error] AutoFocusStageMove Error")

    End Sub

    Private Sub AutoFocusLaserShot(ByVal nIndex As Integer)
        On Error GoTo SysErr

        pScanner(nIndex).RTC6ResetList()
        pScanner(nIndex).RTC6_CrossShot(1000)

SysErr:
        modPub.ErrorLog(Err.Description & " AutoFocusLaserShot Error")
    End Sub

    Private Sub AutoFoucusScannerMove(ByVal nIndex As Integer)
        On Error GoTo SysErr

        Dim temp As Integer = -1

        If pbScannerZup = True Then
            ScannerCurPosZ = ScannerCurPosZ + pbScannerZ
        ElseIf pbScannerZup = False Then
            ScannerCurPosZ = ScannerCurPosZ + (pbScannerZ * temp)
        End If
        pLDLT.MoveScannerZ(nIndex, ScannerCurPosZ * 1000)

SysErr:
        modPub.ErrorLog(Err.Description & "[Error] AutoFoucusScannerMove Error")
    End Sub

    Private Function LaserShotStatus(ByVal nLine As Integer, ByVal nIndex As Integer) As Boolean
        On Error GoTo SysErr

        Dim bShot As Boolean = False

        Select Case nLine

            Case LINE.A

                Select Case nIndex

                    Case Panel.p1

                        bShot = pScanner(Panel.p2).pStatus.bShot

                    Case Panel.p2

                        bShot = pScanner(Panel.p1).pStatus.bShot

                    Case Panel.p3

                        bShot = pScanner(Panel.p4).pStatus.bShot

                    Case Panel.p4

                        bShot = pScanner(Panel.p3).pStatus.bShot

                End Select

            Case LINE.B

                Select Case nIndex

                    Case Panel.p1

                        bShot = pScanner(Panel.p1).pStatus.bShot

                    Case Panel.p2

                        bShot = pScanner(Panel.p2).pStatus.bShot

                    Case Panel.p3

                        bShot = pScanner(Panel.p3).pStatus.bShot

                    Case Panel.p4

                        bShot = pScanner(Panel.p4).pStatus.bShot

                End Select

        End Select

        LaserShotStatus = bShot

SysErr:
        modPub.ErrorLog(Err.Description & " LaserShotStatus Error")
    End Function

    Private Sub MoveToVision(ByVal nLine As Integer, ByVal nIndex As Integer)
        On Error GoTo SysErr

        tmpMovePosX = (pLDLT.PLC_Infomation.dCurPosX(nLine)) - (pCurSystemParam.dVisionLaserOffsetX(nLine, nIndex) * 1000)
        tmpMovePosY = (pLDLT.PLC_Infomation.dCurPosY(nLine)) - (pCurSystemParam.dVisionLaserOffsetY(nLine, nIndex) * 1000)
        pLDLT.MoveStage(nLine, Axis.x, tmpMovePosX)
        pLDLT.MoveStage(nLine, Axis.y, tmpMovePosY)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & "MoveToVision Error")
    End Sub



End Class
