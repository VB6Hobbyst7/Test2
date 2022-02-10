Imports System.Threading

Public Class clsSequence_New
    Private m_nLine As Integer = 0
    Private m_nSeqIndex As Integer = 0
    Private m_nExSeqIndex As Integer = 0

    'GYN - 시컨스 도는거 쫌 더 줄여보자! - 2017.07.17
    Private m_nMainSeqIndex As Integer = 0

    ' form
    Private Mainform As MDI_MAIN

    Private ThreadSeq As System.Threading.Thread
    Private bThreadRunningSeq As Boolean
    Private nKillThreadSeq As Integer

    Dim m_strLine As String = ""

    Dim bGetAlignComplete(7) As Boolean
    Dim nCurRetryCnt(7) As Integer

    Dim nChCamera1 As Integer = 0
    Dim nChCamera2 As Integer = 0
    Dim nSavePath As Integer = 9999

    Public nRetryCnt As Integer = 3 '2
    Public bManualAlignPopUp As Boolean
    Public bUseManualAlign As Boolean
    Public bManualAlignMark(7) As Boolean
    Public bManualAlignMark_Get(7) As Boolean
    Public bManualAlignMode As Boolean
    Public nManualAlingIndex As Integer = 9999

    Public m_bLightOnOff As Boolean

    Dim bTrimmingAble(3) As Boolean

    Private m_bStop As Boolean = False
    Public m_bSet As Boolean = False

    Public tmpStrImage(7) As String

    Dim dTmpAlignPosX_Mark1 As Double
    Dim dTmpAlignPosY_Mark1 As Double
    Dim dTmpAlignPosX_Mark2 As Double
    Dim dTmpAlignPosY_Mark2 As Double
    Dim dTmpDistance(3) As Double


    Private nExDistanceIndex As Integer = 9999
    Private nExMarkPosSameErrorIndex As Integer = 9999 '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드


    Public bDistanceError As Boolean = False
    Public bThetaError1 As Boolean = False
    Public bThetaError2 As Boolean = False
    Public bThetaError3 As Boolean = False
    Public bThetaError4 As Boolean = False
    Public nDistanceErrorGlass As Integer = 9999

	Dim nSeqIndex As Integer = -1
    Dim bRet As Boolean = False

    Dim bFirstRetry(7, 2) As Boolean '20170810 YDY 서브 마크
    Dim nAlignSubMark(7) As Integer '20170810 YDY 서브 마크 
    Public bMarkUseError As Boolean = False '20170810 YDY 서브 마크
    '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
    Private pdPrePanelMark(1, 3, 1, 1) As Double 'line 2, panel 4, mark 2, x an y.
    Dim bMarkPosSameError As Boolean = False
    Dim bMarkUseNot(7, 2) As Boolean '20180409 chy mark use/not
    Dim bMarkUse(7, 2) As Boolean '20180409 chy mark use/not

    Public Sub UpdateStatus()

#If HEAD_2 Then
        If frmSeqVision_2Head.ctrlVision(0, 0).InvokeRequired Then
            frmSeqVision_2Head.ctrlVision(0, 0).Invoke(New MethodInvoker(AddressOf UpdateStatus))
#Else
		If frmSeqVision.ctrlVision(0, 0).InvokeRequired Then
            frmSeqVision.ctrlVision(0, 0).Invoke(New MethodInvoker(AddressOf UpdateStatus))
#End If
            Return

        End If

    End Sub


    Public Sub New(frm As MDI_MAIN)
        Mainform = frm
    End Sub

    Public Sub StartSeq()
        m_bStop = False
        m_bSet = True
    End Sub

    Public Sub StopSeq()
        m_bStop = True
        m_bSet = True
    End Sub

    Public Function GetStatus() As Integer
        Return m_nSeqIndex
    End Function

    Private m_nStartTick As Integer
    Private m_bStarted As Boolean = False

    Private Function IsSleepTime(ByVal nIntervalMil As Integer) As Boolean
        If m_bStarted = False Then
            m_bStarted = True
            m_nStartTick = My.Computer.Clock.TickCount
        Else
            If (My.Computer.Clock.TickCount - m_nStartTick) > nIntervalMil Then
                m_nStartTick = 0
                m_bStarted = False
                Return True
            End If
        End If

        Return False
    End Function

    Public Sub Initialize(ByVal index As Integer)
        m_nLine = index
        Select Case index
            Case 0
                m_strLine = "A"
                nChCamera1 = 0
                nChCamera2 = 1
            Case 1
                m_strLine = "B"
                nChCamera1 = 2
                nChCamera2 = 3
        End Select

	'카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
        For i As Integer = 0 To 1
            For j As Integer = 0 To 3
                For k As Integer = 0 To 1
                    For l As Integer = 0 To 1
                        pdPrePanelMark(i, j, k, l) = 10000
                    Next
                Next
            Next
        Next

        ThreadSeq = New System.Threading.Thread(AddressOf SeqThead)
        nKillThreadSeq = 0
        ThreadSeq.SetApartmentState(Threading.ApartmentState.STA)
        ThreadSeq.Priority = Threading.ThreadPriority.Normal
        ThreadSeq.Start()

        ResetAlignBit()

        nRetryCnt = pCurRecipe.nAlignRetry
    End Sub

    Public Sub EndSeq()
        Interlocked.Exchange(nKillThreadSeq, 1)
        If bThreadRunningSeq = True Then
            ThreadSeq.Join(1000)
        End If
        ThreadSeq = Nothing
    End Sub

    Dim strAlignLog As String = ""

    Sub SeqThead()
        While nKillThreadSeq = 0
            bThreadRunningSeq = True

            If m_bSet = True Then
                If m_bStop = True Then

                    m_nSeqIndex = 0

                    'GYN - 2017.07.07 - Add
                    'For i As Integer = 0 To 3
                    '    If pCamera(i).IsStreaming() = True Then
                    '        pCamera(i).StoppingStream()
                    '    End If
                    'Next

                    'If m_nLine = 0 Then
                    '    If pCamera(0).m_bConnected Then
                    '        If pCamera(0).IsStreaming() = True Then
                    '            pCamera(0).StoppingStream() 'StoppingStream()
                    '        End If
                    '    End If
                    '    If pCamera(1).m_bConnected Then
                    '        If pCamera(1).IsStreaming() = True Then
                    '            pCamera(1).StoppingStream() 'StoppingStream()
                    '        End If
                    '    End If

                    'End If

                    'If m_nLine = 1 Then
                    '    If pCamera(2).m_bConnected Then
                    '        If pCamera(2).IsStreaming() = True Then
                    '            pCamera(2).StoppingStream()
                    '        End If
                    '    End If
                    '    If pCamera(3).m_bConnected Then
                    '        If pCamera(3).IsStreaming() = True Then
                    '            pCamera(3).StoppingStream()
                    '        End If
                    '    End If
                    'End If

                    '20180823정지시 초기화
                    For i As Integer = 0 To 1
                        For j As Integer = 0 To 3
                            For k As Integer = 0 To 1
                                For l As Integer = 0 To 1
                                    pdPrePanelMark(i, j, k, l) = 9999
                                Next
                            Next
                        Next
                    Next

                ElseIf m_bStop = False Then

                    m_nSeqIndex = 1
                    m_nMainSeqIndex = 0
                    m_bSet = False 'sbs_20180808 운전시작시 Panel1에서 측정지연 알람이 발생하고 무한 대기 하는 문제(여기로 위치 이동)

                    'Load mark Data 불러오기
                    If pCurRecipe.bMultiCutting = False Then
                        modRecipe.LoadMarkingData(pCurRecipe.strMarkRecipeFile(m_nLine, Panel.p1), pCurRecipe.RecipeMarkingData(m_nLine, Panel.p1))
                        modRecipe.LoadMarkingData(pCurRecipe.strMarkRecipeFile(m_nLine, Panel.p2), pCurRecipe.RecipeMarkingData(m_nLine, Panel.p2))
                        modRecipe.LoadMarkingData(pCurRecipe.strMarkRecipeFile(m_nLine, Panel.p3), pCurRecipe.RecipeMarkingData(m_nLine, Panel.p3))
                        modRecipe.LoadMarkingData(pCurRecipe.strMarkRecipeFile(m_nLine, Panel.p4), pCurRecipe.RecipeMarkingData(m_nLine, Panel.p4))
                    ElseIf pCurRecipe.bMultiCutting = True Then
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiFirstMarkRecipeFile(m_nLine, 0), pCurRecipe.RecipeMultiFirstMarkingData(m_nLine, Panel.p1))
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiSecondMarkRecipeFile(m_nLine, 0), pCurRecipe.RecipeMultiSecondMarkingData(m_nLine, Panel.p1))
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiFirstMarkRecipeFile(m_nLine, 1), pCurRecipe.RecipeMultiFirstMarkingData(m_nLine, Panel.p2))
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiSecondMarkRecipeFile(m_nLine, 1), pCurRecipe.RecipeMultiSecondMarkingData(m_nLine, Panel.p2))
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiFirstMarkRecipeFile(m_nLine, 2), pCurRecipe.RecipeMultiFirstMarkingData(m_nLine, Panel.p3))
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiSecondMarkRecipeFile(m_nLine, 2), pCurRecipe.RecipeMultiSecondMarkingData(m_nLine, Panel.p3))
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiFirstMarkRecipeFile(m_nLine, 3), pCurRecipe.RecipeMultiFirstMarkingData(m_nLine, Panel.p4))
                        modRecipe.LoadMarkingData(pCurRecipe.strMultiSecondMarkRecipeFile(m_nLine, 3), pCurRecipe.RecipeMultiSecondMarkingData(m_nLine, Panel.p4))
                    End If

                    'Align Mark 측정 위치 불러오기.
                    pCurRecipe.dStageAlignMark1PosX(m_nLine, Panel.p1) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p1)
                    pCurRecipe.dStageAlignMark1PosY(m_nLine, Panel.p1) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p1)
                    pCurRecipe.dStageAlignMark1PosX(m_nLine, Panel.p2) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p1)
                    pCurRecipe.dStageAlignMark1PosY(m_nLine, Panel.p2) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p1)

                    pCurRecipe.dStageAlignMark2PosX(m_nLine, Panel.p1) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p2)
                    pCurRecipe.dStageAlignMark2PosY(m_nLine, Panel.p1) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p2)
                    pCurRecipe.dStageAlignMark2PosX(m_nLine, Panel.p2) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p2)
                    pCurRecipe.dStageAlignMark2PosY(m_nLine, Panel.p2) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p2)

                    pCurRecipe.dStageAlignMark1PosX(m_nLine, Panel.p3) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p3)
                    pCurRecipe.dStageAlignMark1PosY(m_nLine, Panel.p3) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p3)
                    pCurRecipe.dStageAlignMark1PosX(m_nLine, Panel.p4) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p3)
                    pCurRecipe.dStageAlignMark1PosY(m_nLine, Panel.p4) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p3)

                    pCurRecipe.dStageAlignMark2PosX(m_nLine, Panel.p3) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p4)
                    pCurRecipe.dStageAlignMark2PosY(m_nLine, Panel.p3) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p4)
                    pCurRecipe.dStageAlignMark2PosX(m_nLine, Panel.p4) = pLDLT.PLC_Infomation.dAlignPosX(m_nLine, Panel.p4)
                    pCurRecipe.dStageAlignMark2PosY(m_nLine, Panel.p4) = pLDLT.PLC_Infomation.dAlignPosY(m_nLine, Panel.p4)

                    '20180115 Mark Merge
                    'sbs_20180728 For nLine = 0 To 1
                    For nPanel = 0 To 3
                        For nMark = 0 To 1
                            For nSubMark = 0 To 2

                                'pMilInterface.LoadAlignModelTemplate(pRcpMark_Data(nLine, nPanel, nMark, nSubMark).nBuffer, pRcpMark_Data(nLine, nPanel, nMark, nSubMark).strAlignMarkImageMMF_FileName)
#If SIMUL <> 1 Then
                                pMilInterface.LoadAlignModelTemplate_Total(m_nLine, nPanel, nMark, nSubMark, pRcpMark_Data(m_nLine, nPanel, nMark, nSubMark).strAlignMarkImageMMF_FileName)
#End If
                            Next
                        Next
                    Next
                    'sbs_20180728 Next

                End If

                ResetAlignBit()
                ResetParam()

                'sbs_20180808 운전시작시 Panel1에서 측정지연 알람이 발생하고 무한 대기 하는 문제(위로 위치 이동)
                ' Auto mode가 되어 Sequence가 Start하면 m_bSet 이 True가 되어도 Sequence가 여기 루틴을 실행 중일 경우에는 
                'm_bSet가 다시 False가 되기 때문에 무한대기 상태가 된다.
                'm_bSet = False 

                pTimeTac(m_nLine).bPLC_StageVisionPos1 = False
                pTimeTac(m_nLine).bPLC_StageVisionPos2 = False
                pTimeTac(m_nLine).bPLC_StageVisionPos3 = False
                pTimeTac(m_nLine).bPLC_StageVisionPos4 = False

            End If

            'GYN - LogIn 완료 후 동작되도록 수정
            If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
                'GYN - Alarm 발생 시 시컨스 구동 불가.
                If bAlarmUse = False Then
                    'GYN - Tack 줄여볼까?
                    Select Case m_nMainSeqIndex
                        Case 0
                            CheckGlass()
                        Case 1
                            Align()
                            ManualAlign()
                        Case 2
                            Trimming()
                    End Select
                End If
            End If

            Thread.Sleep(50)    '10 -> 50
            
        End While
        bThreadRunningSeq = False
    End Sub

    Private Sub CheckGlass()
        Select Case m_nSeqIndex
            Case 0 'None Work

            Case 1 'Init Seq Bit And Param

                m_nMainSeqIndex = 0

                ResetAlignBit()
                ResetParam()

                'GYN - 20170315 - T/T Start
                modSequence.GetTactTime(pTimeTac(m_nLine).dStart_Time, pTimeTac(m_nLine).dStart_Time, 0)
                modPub.TacLog_A("[T/T] Start Time")
                pTimeTac(m_nLine).bTotal_Time = True

                m_nSeqIndex = 2

            Case 2  'Wait Main Stage GlassIn Pos Move Complete

                m_nSeqIndex = 5

            Case 3  'Wait Glass Exist (check)

                '상황에 따라 받기 때문에 1장만 받았다는 신호를 받으면 Glass 받은 것으로 간주한다.
                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = True Or
                   pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = True Or
                   pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = True Or
                   pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = True Then

                    'GYN - 20170315 - T/T GlassCheck
                    'modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_GlassCheck, pTimeTac(m_nLine).dPLC_GlassCheckTemp, pTimeTac(m_nLine).dPLC_StageLoadingPosCompleteTemp)
                    'modPub.TacLog(m_nLine, "[PLC] GlassCheck:: " & pTimeTac(m_nLine).dPLC_GlassCheck.ToString)

                    m_nSeqIndex = 5

                End If

            Case 5 ' Wait Align Request 
                If pLDLT.PLC_Infomation.bAlignRequest(m_nLine, Panel.p1) = True Then

                    '20181217RYO - case 3 사용 하지않아, StageVisionPos1 Tac 값이 계속증가하는 버그를 없애기 위해 옮김
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_GlassCheck, pTimeTac(m_nLine).dPLC_GlassCheck, pTimeTac(m_nLine).dPLC_StageLoadingPosCompleteTemp)
                    modPub.TacLog(m_nLine, "[PLC] GlassCheck:: " & pTimeTac(m_nLine).dPLC_GlassCheck.ToString)

                    m_nMainSeqIndex = 1
                    'GYN- 2017.07.04.- Camera On/Off Mode 변경.
                    'If m_nLine = 0 Then
                    '    If pCamera(0).IsStreaming() = False Then
                    '        'pMilInterface.SetClearImage(0)
                    '        pCamera(0).StartingStream()

                    '    End If
                    '    If pCamera(1).IsStreaming() = False Then
                    '        'pMilInterface.SetClearImage(1)
                    '        pCamera(1).StartingStream()
                    '    End If
                    'End If

                    'If m_nLine = 1 Then
                    '    If pCamera(2).IsStreaming() = False Then
                    '        'pMilInterface.SetClearImage(2)
                    '        pCamera(2).StartingStream()
                    '    End If
                    '    If pCamera(3).IsStreaming() = False Then
                    '        'pMilInterface.SetClearImage(3)
                    '        pCamera(3).StartingStream()
                    '    End If
                    'End If

                    m_nSeqIndex = 11

                ElseIf pLDLT.PLC_Infomation.bAlignRequest(m_nLine, Panel.p3) = True Then

                    m_nMainSeqIndex = 1

                    'GYN- 2017.07.04.- Camera On/Off Mode 변경.
                    'If m_nLine = 0 Then
                    '    If pCamera(0).IsStreaming() = False Then
                    '        pCamera(0).StartingStream()
                    '    End If
                    '    If pCamera(1).IsStreaming() = False Then
                    '        pCamera(1).StartingStream()
                    '    End If
                    'End If

                    'If m_nLine = 1 Then
                    '    If pCamera(2).IsStreaming() = False Then
                    '        pCamera(2).StartingStream()
                    '    End If
                    '    If pCamera(3).IsStreaming() = False Then
                    '        pCamera(3).StartingStream()
                    '    End If
                    'End If

                    m_nSeqIndex = 21
                End If
        End Select

        If m_nSeqIndex <> nSeqIndex Then

            nSeqIndex = m_nSeqIndex
            SequenceLog(m_nLine, "CheckGlassSeq ::" & m_nSeqIndex)

        End If

    End Sub



    Private Sub Align()
        Select Case m_nSeqIndex
            Case 11 'Fisrt Align Position Set Align Data
                If pLDLT.PLC_Infomation.bAlignRequest(m_nLine, Panel.p1) = False Then
                    Exit Sub
                End If

                m_nMainSeqIndex = 1

                'If m_nLine = 0 Then
                '    If pCamera(0).IsStreaming = False Then
                '        pCamera(0).StartingStream()
                '    End If
                '    If pCamera(1).IsStreaming = False Then
                '        pCamera(1).StartingStream()
                '    End If
                'End If

                'If m_nLine = 1 Then
                '    If pCamera(2).IsStreaming = False Then
                '        pCamera(2).StartingStream()
                '    End If
                '    If pCamera(3).IsStreaming = False Then
                '        pCamera(3).StartingStream()
                '    End If
                'End If

                'GYN - Tact Time Check [얼라인 전체 T/T]
                modSequence.GetTactTime(pTimeTac(m_nLine).dStart_Time, pTimeTac(m_nLine).dTmpAlignTime, 0)
                pTimeTac(m_nLine).bAlignTime = True

                'GYN - 20170315 - T/T StageVisionPos1
                If pTimeTac(m_nLine).bPLC_StageVisionPos1 = False Then
                    'modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_StageVisionPos1, pTimeTac(m_nLine).dPLC_StageVisionPos1Temp, pTimeTac(m_nLine).dPLC_GlassCheckTemp)
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_StageVisionPos1, pTimeTac(m_nLine).dPLC_StageVisionPos1Temp, pTimeTac(m_nLine).dPLC_GlassCheck)
                    modPub.TacLog(m_nLine, "[PLC] StageVisionPos1:: " & pTimeTac(m_nLine).dPLC_StageVisionPos1.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos1 = True
                End If

                If m_nLine = LINE.A Then
                    pLight.SetLight(1, pCurRecipe.nAlignLight(m_nLine, 0))
                    pLight.SetLight(5, pCurRecipe.nAlignLight2(m_nLine, 0))

                    pLight.SetLight(2, pCurRecipe.nAlignLight(m_nLine, 1))
                    pLight.SetLight(6, pCurRecipe.nAlignLight2(m_nLine, 1))
                Else
                    pLight.SetLight(3, pCurRecipe.nAlignLight(m_nLine, 0))
                    pLight.SetLight(7, pCurRecipe.nAlignLight2(m_nLine, 0))

                    pLight.SetLight(4, pCurRecipe.nAlignLight(m_nLine, 1))
                    pLight.SetLight(8, pCurRecipe.nAlignLight2(m_nLine, 1))
                End If

                If IsSleepTime(pCurSystemParam.nVisionAlignDelay) = True Then

                    modPub.TacLog(m_nLine, "[PC] VisionAlignDelay ::" & pCurSystemParam.nVisionAlignDelay.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos1 = False

                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = True Then
                        pCurMark_Data_1 = pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 0)        '' line, panel, mark 순서, 갯수
                    End If
                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = True Then
                        pCurMark_Data_2 = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 0)        '' line, panel, mark 순서, 갯수
                    End If

                    m_nSeqIndex = 12

                End If

            Case 12  'Find First Mark Align Glass1 and Glass2
                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = True And pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = False Then
                    nSavePath = AlignMark.Panel1_Mark1 + (m_nLine * 10)

                    If nCurRetryCnt(AlignMark.Panel1_Mark1) < nRetryCnt Then

                        'If m_nLine = LINE.A Then
                        '    pLight.SetLight(1, pCurRecipe.nAlignLight(m_nLine, 0))
                        '    pLight.SetLight(5, pCurRecipe.nAlignLight2(m_nLine, 0))
                        'Else
                        '    pLight.SetLight(3, pCurRecipe.nAlignLight(m_nLine, 0))
                        '    pLight.SetLight(7, pCurRecipe.nAlignLight2(m_nLine, 0))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel1_Mark1) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p1, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel1_Mark1))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 0)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(0, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel1_Mark1) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p1, AlignMarkNumber.Mark1, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p1, AlignMarkNumber.Mark1, _
                                               pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark1).PositionDiffX, _
                                               pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark1).positionDiffY, _
                                               bGetAlignComplete(AlignMark.Panel1_Mark1)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera1) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel1_Mark1")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel1_Mark1) = True Then

                                pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = True

                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark1).PositionDiffX, pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark1).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam1), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam1), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam1), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p1).dMark1DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p1).dMark1DifferencePositionY)

                                tmpStrImage(0) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark1" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p1 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel1_Mark1) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark1.bmp", tmpStrImage(0))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p1, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel1_Mark1)})


                                'GYN - 20170315 - T/T VisionAlign1Mark1
                                'modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign1Mark1, pTimeTac(m_nLine).dPC_VisionAlign1Mark1Temp, pTimeTac(m_nLine).dPLC_StageVisionPos1Temp)
                                'modPub.TacLog(m_nLine, "[PC] VisionAlign1Mark1:: " & pTimeTac(m_nLine).dPC_VisionAlign1Mark1.ToString)

                            Else
                                nCurRetryCnt(AlignMark.Panel1_Mark1) = nCurRetryCnt(AlignMark.Panel1_Mark1) + 1
                                tmpStrImage(0) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark1_" & nCurRetryCnt(AlignMark.Panel1_Mark1) & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p1 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel1_Mark1) & "_Align NG")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark1.bmp", tmpStrImage(0))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p1, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel1_Mark1)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel1_Mark1" & "  " & nCurRetryCnt(AlignMark.Panel1_Mark1))

                            End If

                        Else

                            bGetAlignComplete(AlignMark.Panel1_Mark1) = True

                        End If


                    Else
                        'Manual Align 
                        If bManualAlignMark(AlignMark.Panel2_Mark1) = False Then
                            bManualAlignMark(AlignMark.Panel1_Mark1) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel1_Mark1
                            m_nExSeqIndex = 12
                            m_nSeqIndex = 50
                            strAlignLog = "MARK1:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p1, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel1_Mark1")
                            Exit Sub
                        End If
                    End If
                End If

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = False Then
                    nSavePath = AlignMark.Panel2_Mark1 + (m_nLine * 10)

                    If nCurRetryCnt(AlignMark.Panel2_Mark1) < nRetryCnt Then

                        'If m_nLine = LINE.A Then
                        '    pLight.SetLight(2, pCurRecipe.nAlignLight(m_nLine, 1))
                        '    pLight.SetLight(6, pCurRecipe.nAlignLight2(m_nLine, 1))
                        'Else
                        '    pLight.SetLight(4, pCurRecipe.nAlignLight(m_nLine, 1))
                        '    pLight.SetLight(8, pCurRecipe.nAlignLight2(m_nLine, 1))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel2_Mark1) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p2, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel2_Mark1))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 1)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(1, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel2_Mark1) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p2, AlignMarkNumber.Mark1, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p2, AlignMarkNumber.Mark1, _
                                               pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark1).PositionDiffX, _
                                               pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark1).positionDiffY, _
                                               bGetAlignComplete(AlignMark.Panel2_Mark1)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera2) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel2_Mark1")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel2_Mark1) = True Then
                                pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = True
                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark1).PositionDiffX, pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark1).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam2), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam2), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam2), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p2).dMark1DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p2).dMark1DifferencePositionY)

                                tmpStrImage(2) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark1" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p2 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel2_Mark1) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark1.bmp", tmpStrImage(2))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p2, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel2_Mark1)})


                                'GYN - 20170315 - T/T VisionAlign2Mark1
                                'modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign2Mark1, pTimeTac(m_nLine).dPC_VisionAlign2Mark1Temp, pTimeTac(m_nLine).dPC_VisionAlign1Mark1Temp)
                                'modPub.TacLog(m_nLine, "[PC] VisionAlign2Mark1:: " & pTimeTac(m_nLine).dPC_VisionAlign2Mark1.ToString)

                            Else
                                nCurRetryCnt(AlignMark.Panel2_Mark1) = nCurRetryCnt(AlignMark.Panel2_Mark1) + 1
                                tmpStrImage(2) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark1_" & nCurRetryCnt(AlignMark.Panel2_Mark1) & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p2 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel2_Mark1) & "_Align NG")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark1.bmp", tmpStrImage(2))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p2, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel2_Mark1)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel2_Mark1" & "  " & nCurRetryCnt(AlignMark.Panel2_Mark1))

                            End If

                        Else

                            bGetAlignComplete(AlignMark.Panel2_Mark1) = True

                        End If

                    Else
                        ' Manual Align 
                        If bManualAlignMark(AlignMark.Panel1_Mark1) = False Then
                            bManualAlignMark(AlignMark.Panel2_Mark1) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel2_Mark1
                            m_nExSeqIndex = 12
                            m_nSeqIndex = 50
                            strAlignLog = "MARK1:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p2, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel2_Mark1")
                            Exit Sub
                        End If
                    End If
                End If

                If pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = True Then

                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_1, True)
                            pLDLT.PC_Infomation.bAlignOK1(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_1, True)
                            pLDLT.PC_Infomation.bAlignOK1(LINE.B) = True
                    End Select
                    SendAlignResult(0)

                    'GYN - 20170315 - T/T VisionAlign1
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign1, pTimeTac(m_nLine).dPC_VisionAlign1Temp, pTimeTac(m_nLine).dPLC_StageVisionPos1Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign1:: " & pTimeTac(m_nLine).dPC_VisionAlign1.ToString)

                    m_nSeqIndex = 13 'normal

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = False And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = True Then
                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_1, True)
                            pLDLT.PC_Infomation.bAlignOK1(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_1, True)
                            pLDLT.PC_Infomation.bAlignOK1(LINE.B) = True
                    End Select

                    'PLC에 OK 신호를 주기 위해서..
                    pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = True
                    SendAlignResult(0)

                    'GYN - 20170315 - T/T VisionAlign1
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign1, pTimeTac(m_nLine).dPC_VisionAlign1Temp, pTimeTac(m_nLine).dPLC_StageVisionPos1Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign1:: " & pTimeTac(m_nLine).dPC_VisionAlign1.ToString)

                    m_nSeqIndex = 13 'No glass Panel1

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = False And pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = True Then
                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_1, True)
                            pLDLT.PC_Infomation.bAlignOK1(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_1, True)
                            pLDLT.PC_Infomation.bAlignOK1(LINE.B) = True
                    End Select

                    pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = True
                    SendAlignResult(0)

                    'GYN - 20170315 - T/T VisionAlign1
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign1, pTimeTac(m_nLine).dPC_VisionAlign1Temp, pTimeTac(m_nLine).dPLC_StageVisionPos1Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign1:: " & pTimeTac(m_nLine).dPC_VisionAlign1.ToString)

                    m_nSeqIndex = 13 'No glass Panel2

                End If

            Case 13 'Second Align Position Set Align Data
                If pLDLT.PLC_Infomation.bAlignRequest(m_nLine, Panel.p2) = False Then
                    Exit Sub
                End If

                'GYN - 20170315 - T/T StageVisionPos2
                If pTimeTac(m_nLine).bPLC_StageVisionPos2 = False Then
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_StageVisionPos2, pTimeTac(m_nLine).dPLC_StageVisionPos2Temp, pTimeTac(m_nLine).dPC_VisionAlign1Temp)
                    modPub.TacLog(m_nLine, "[PLC] StageVisionPos2:: " & pTimeTac(m_nLine).dPLC_StageVisionPos2.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos2 = True

                End If

                If m_nLine = LINE.A Then
                    pLight.SetLight(1, pCurRecipe.nAlignLight_mark2(m_nLine, 0))
                    pLight.SetLight(5, pCurRecipe.nAlignLight2_mark2(m_nLine, 0))

                    pLight.SetLight(2, pCurRecipe.nAlignLight_mark2(m_nLine, 1))
                    pLight.SetLight(6, pCurRecipe.nAlignLight2_mark2(m_nLine, 1))
                Else
                    pLight.SetLight(3, pCurRecipe.nAlignLight_mark2(m_nLine, 0))
                    pLight.SetLight(7, pCurRecipe.nAlignLight2_mark2(m_nLine, 0))

                    pLight.SetLight(4, pCurRecipe.nAlignLight_mark2(m_nLine, 1))
                    pLight.SetLight(8, pCurRecipe.nAlignLight2_mark2(m_nLine, 1))
                End If

                If IsSleepTime(pCurSystemParam.nVisionAlignDelay) = True Then

                    modPub.TacLog(m_nLine, "[PC] VisionAlignDelay ::" & pCurSystemParam.nVisionAlignDelay.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos2 = False

                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = True Then
                        pCurMark_Data_1 = pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 0)        '' line, panel, mark 순서, 갯수
                    End If
                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = True Then
                        pCurMark_Data_2 = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 0)        '' line, panel, mark 순서, 갯수
                    End If

                    m_nSeqIndex = 14
                End If

            Case 14

                'Mark2인 경우 500ms 더 줌... 모터 가감속문제 발생.
                'If IsSleepTime(pCurSystemParam.nVisionAlignDelay) = True Then

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = True And pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = False Then
                    nSavePath = AlignMark.Panel1_Mark2 + (m_nLine * 10)
                    If nCurRetryCnt(AlignMark.Panel1_Mark2) < nRetryCnt Then

                        'If m_nLine = LINE.A Then
                        '    pLight.SetLight(1, pCurRecipe.nAlignLight_mark2(m_nLine, 0))
                        '    pLight.SetLight(5, pCurRecipe.nAlignLight2_mark2(m_nLine, 0))
                        'Else
                        '    pLight.SetLight(3, pCurRecipe.nAlignLight_mark2(m_nLine, 0))
                        '    pLight.SetLight(7, pCurRecipe.nAlignLight2_mark2(m_nLine, 0))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel1_Mark2) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p1, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel1_Mark2))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 2)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(2, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel1_Mark2) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p1, AlignMarkNumber.Mark2, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p1, AlignMarkNumber.Mark2, _
                                               pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark2).PositionDiffX, _
                                               pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark2).positionDiffY, _
                                               bGetAlignComplete(AlignMark.Panel1_Mark2)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera1) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel1_Mark2")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel1_Mark2) = True Then
                                pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = True
                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark2).PositionDiffX, pMF_Result(m_nLine, Panel.p1, AlignMarkNumber.Mark2).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam1), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam1), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam1), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p1).dMark2DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p1).dMark2DifferencePositionY)
                                tmpStrImage(1) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark2" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p1 + 1).ToString & "_Mark2" & "_" & nAlignSubMark(AlignMark.Panel1_Mark2) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark2.bmp", tmpStrImage(1))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p1, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel1_Mark2)})


                                'GYN - 20170315 - T/T StageVisionPos2
                                'modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_StageVisionPos2, pTimeTac(m_nLine).dPLC_StageVisionPos2Temp, pTimeTac(m_nLine).dPC_VisionAlign2Mark1Temp)
                                'modPub.TacLog(m_nLine, "[PC] StageVisionPos2:: " & pTimeTac(m_nLine).dPLC_StageVisionPos2.ToString)

                            Else
                                nCurRetryCnt(AlignMark.Panel1_Mark2) = nCurRetryCnt(AlignMark.Panel1_Mark2) + 1
                                tmpStrImage(1) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark2_" & nCurRetryCnt(AlignMark.Panel1_Mark2) & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p1 + 1).ToString & "_Mark2" & "_" & nAlignSubMark(AlignMark.Panel1_Mark2) & "_Align NG")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p1 + 1).ToString & "_Mark2.bmp", tmpStrImage(1))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p1, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel1_Mark2)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel1_Mark2" & "  " & nCurRetryCnt(AlignMark.Panel1_Mark2))

                            End If

                        Else

                            bGetAlignComplete(AlignMark.Panel1_Mark2) = True

                        End If


                    Else
                        ' Manual Align 
                        If bManualAlignMark(AlignMark.Panel2_Mark2) = False Then
                            bManualAlignMark(AlignMark.Panel1_Mark2) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel1_Mark2
                            m_nExSeqIndex = 14
                            m_nSeqIndex = 50
                            strAlignLog = "MARK2:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p1, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel1_Mark2")
                            Exit Sub
                        End If
                    End If
                End If

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = False Then
                    nSavePath = AlignMark.Panel2_Mark2 + (m_nLine * 10)
                    If nCurRetryCnt(AlignMark.Panel2_Mark2) < nRetryCnt Then

                        'If m_nLine = LINE.A Then
                        '    pLight.SetLight(2, pCurRecipe.nAlignLight_mark2(m_nLine, 1))
                        '    pLight.SetLight(6, pCurRecipe.nAlignLight2_mark2(m_nLine, 1))
                        'Else
                        '    pLight.SetLight(4, pCurRecipe.nAlignLight_mark2(m_nLine, 1))
                        '    pLight.SetLight(8, pCurRecipe.nAlignLight2_mark2(m_nLine, 1))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel2_Mark2) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p2, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel2_Mark2))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 3)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(3, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel2_Mark2) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p2, AlignMarkNumber.Mark2, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p2, AlignMarkNumber.Mark2, _
                                               pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark2).PositionDiffX, _
                                               pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark2).positionDiffY, _
                                               bGetAlignComplete(AlignMark.Panel2_Mark2)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera2) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel2_Mark2")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel2_Mark2) = True Then
                                pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = True
                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark2).PositionDiffX, pMF_Result(m_nLine, Panel.p2, AlignMarkNumber.Mark2).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam2), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam2), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam2), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p2).dMark2DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p2).dMark2DifferencePositionY)
                                tmpStrImage(3) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark2" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p2 + 1).ToString & "_Mark2" & "_" & nAlignSubMark(AlignMark.Panel2_Mark2) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark2.bmp", tmpStrImage(3))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p2, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel2_Mark2)})



                            Else
                                nCurRetryCnt(AlignMark.Panel2_Mark2) = nCurRetryCnt(AlignMark.Panel2_Mark2) + 1
                                tmpStrImage(3) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark2_" & nCurRetryCnt(AlignMark.Panel2_Mark2) & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p2 + 1).ToString & "_Mark2" & "_" & nAlignSubMark(AlignMark.Panel2_Mark2) & "_Align NG")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p2 + 1).ToString & "_Mark2.bmp", tmpStrImage(3))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p2, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel2_Mark2)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel2_Mark2" & "  " & nCurRetryCnt(AlignMark.Panel2_Mark2))

                            End If

                        Else

                            bGetAlignComplete(AlignMark.Panel2_Mark2) = True

                        End If

                    Else
                        ' Manual Align 
                        If bManualAlignMark(AlignMark.Panel1_Mark2) = False Then
                            bManualAlignMark(AlignMark.Panel2_Mark2) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel2_Mark2
                            m_nExSeqIndex = 14
                            m_nSeqIndex = 50
                            strAlignLog = "MARK2:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p2, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel2_Mark2")
                            Exit Sub
                        End If
                    End If
                End If

                If pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = True Then

                    'AlignMarkDistance(Panel.p1)
                    ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p1, AlignMarkNumber.Mark2, dTmpDistance(Panel.p1)})

                    'If Math.Abs(dTmpDistance(Panel.p1) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                    '    nExDistanceIndex = m_nSeqIndex
                    '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                    '    nDistanceErrorGlass = 1
                    '    bDistanceError = True
                    '    m_nSeqIndex = 40
                    '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel1:" & dTmpDistance(Panel.p1))
                    '    Exit Select
                    'End If

                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 0).dAngle > pCurRecipe.dThetaLimit_2 Then
                    '            bThetaError2 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 0).dAngle > pCurRecipe.dThetaLimit_1 Then
                    '            bThetaError1 = True
                    '            StopSeq()
                    '        End If
                    'End Select


                    'AlignMarkDistance(Panel.p2)
                    ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p2, AlignMarkNumber.Mark2, dTmpDistance(Panel.p2)})

                    'If Math.Abs(dTmpDistance(Panel.p2) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                    '    nExDistanceIndex = m_nSeqIndex
                    '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                    '    nDistanceErrorGlass = 2
                    '    bDistanceError = True
                    '    m_nSeqIndex = 40
                    '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel2:" & dTmpDistance(Panel.p2))
                    '    Exit Select
                    'End If

                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 1).dAngle > pCurRecipe.dThetaLimit_1 Then
                    '            bThetaError1 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 1).dAngle > pCurRecipe.dThetaLimit_2 Then
                    '            bThetaError2 = True
                    '            StopSeq()
                    '        End If
                    'End Select

                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_2, True)
                            pLDLT.PC_Infomation.bAlignOK2(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_2, True)
                            pLDLT.PC_Infomation.bAlignOK2(LINE.B) = True
                    End Select

                    SendAlignResult(1)

                    'GYN - 20170315 - T/T VisionAlign2
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign2, pTimeTac(m_nLine).dPC_VisionAlign2Temp, pTimeTac(m_nLine).dPLC_StageVisionPos2Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign2:: " & pTimeTac(m_nLine).dPC_VisionAlign2.ToString)

                    m_nSeqIndex = 15 'normal

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = False And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = True Then

                    If bAlignPass = False Then
                        'AlignMarkDistance(Panel.p2)
                        ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p2, AlignMarkNumber.Mark2, dTmpDistance(Panel.p2)})

                        'If Math.Abs(dTmpDistance(Panel.p2) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                        '    nExDistanceIndex = m_nSeqIndex
                        '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                        '    nDistanceErrorGlass = 2
                        '    bDistanceError = True
                        '    m_nSeqIndex = 40
                        '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel2:" & dTmpDistance(Panel.p2))
                        '    Exit Select
                        'End If
                    End If

                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 1).dAngle > pCurRecipe.dThetaLimit_1 Then
                    '            bThetaError1 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 1).dAngle > pCurRecipe.dThetaLimit_2 Then
                    '            bThetaError2 = True
                    '            StopSeq()
                    '        End If
                    'End Select

                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_2, True)
                            pLDLT.PC_Infomation.bAlignOK2(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_2, True)
                            pLDLT.PC_Infomation.bAlignOK2(LINE.B) = True
                    End Select

                    pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = True
                    SendAlignResult(1)

                    'GYN - 20170315 - T/T VisionAlign2
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign2, pTimeTac(m_nLine).dPC_VisionAlign2Temp, pTimeTac(m_nLine).dPLC_StageVisionPos2Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign2:: " & pTimeTac(m_nLine).dPC_VisionAlign2.ToString)

                    m_nSeqIndex = 15 'No glass Panel1 

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = False And pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = True Then

                    If bAlignPass = False Then
                        'AlignMarkDistance(Panel.p1)
                        ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p1, AlignMarkNumber.Mark2, dTmpDistance(Panel.p1)})

                        'If Math.Abs(dTmpDistance(Panel.p1) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                        '    nExDistanceIndex = m_nSeqIndex
                        '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                        '    nDistanceErrorGlass = 1
                        '    bDistanceError = True
                        '    m_nSeqIndex = 40
                        '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel1:" & dTmpDistance(Panel.p1))
                        '    Exit Select
                        'End If
                    End If


                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 0).dAngle > pCurRecipe.dThetaLimit_2 Then
                    '            bThetaError2 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 0).dAngle > pCurRecipe.dThetaLimit_1 Then
                    '            bThetaError1 = True
                    '            StopSeq()
                    '        End If
                    'End Select

                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_2, True)
                            pLDLT.PC_Infomation.bAlignOK2(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_2, True)
                            pLDLT.PC_Infomation.bAlignOK2(LINE.B) = True
                    End Select

                    pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = True
                    SendAlignResult(1)

                    'GYN - 20170315 - T/T VisionAlign2
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign2, pTimeTac(m_nLine).dPC_VisionAlign2Temp, pTimeTac(m_nLine).dPLC_StageVisionPos2Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign2:: " & pTimeTac(m_nLine).dPC_VisionAlign2.ToString)

                    m_nSeqIndex = 15 'No glass Panel2 

                End If

                'End If

            Case 15
                If pLDLT.PLC_Infomation.bAlignRequest(m_nLine, Panel.p3) = True Then
                    m_nSeqIndex = 21
                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = False And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = False Then
                    m_nSeqIndex = 30
                End If

            Case 21 'Third Align Position 
                If pLDLT.PLC_Infomation.bAlignRequest(m_nLine, Panel.p3) = False Then
                    Exit Sub
                End If

                'Tact Time Check.
                If pTimeTac(m_nLine).bAlignTime = False Then
                    modSequence.GetTactTime(pTimeTac(m_nLine).dAlignTime, pTimeTac(m_nLine).dTmpAlignTime, 0)
                End If

                'GYN - 20170315 - T/T StageVisionPos3
                If pTimeTac(m_nLine).bPLC_StageVisionPos3 = False Then
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_StageVisionPos3, pTimeTac(m_nLine).dPLC_StageVisionPos3Temp, pTimeTac(m_nLine).dPC_VisionAlign2Temp)
                    modPub.TacLog(m_nLine, "[PLC] StageVisionPos3:: " & pTimeTac(m_nLine).dPLC_StageVisionPos3.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos3 = True
                End If

                If m_nLine = LINE.A Then
                    pLight.SetLight(1, pCurRecipe.nAlignLight(m_nLine, 2))
                    pLight.SetLight(5, pCurRecipe.nAlignLight2(m_nLine, 2))

                    pLight.SetLight(2, pCurRecipe.nAlignLight(m_nLine, 3))
                    pLight.SetLight(6, pCurRecipe.nAlignLight2(m_nLine, 3))
                Else

                    pLight.SetLight(3, pCurRecipe.nAlignLight(m_nLine, 2))
                    pLight.SetLight(7, pCurRecipe.nAlignLight2(m_nLine, 2))

                    pLight.SetLight(4, pCurRecipe.nAlignLight(m_nLine, 3))
                    pLight.SetLight(8, pCurRecipe.nAlignLight2(m_nLine, 3))
                End If

                If IsSleepTime(pCurSystemParam.nVisionAlignDelay) = True Then

                    modPub.TacLog(m_nLine, "[PC] VisionAlignDelay ::" & pCurSystemParam.nVisionAlignDelay.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos3 = False

                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = True Then
                        pCurMark_Data_1 = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 0)        '' line, panel, mark 순서, 갯수
                    End If

                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = True Then
                        pCurMark_Data_2 = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 0)        '' line, panel, mark 순서, 갯수
                    End If

                    m_nSeqIndex = 22

                End If

            Case 22  'Find Third Mark Align Glass1 and Glass2
                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = True And pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = False Then
                    nSavePath = AlignMark.Panel3_Mark1 + (m_nLine * 10)

                    If nCurRetryCnt(AlignMark.Panel3_Mark1) < nRetryCnt Then

                        'If m_nLine = LINE.A Then
                        '    pLight.SetLight(1, pCurRecipe.nAlignLight(m_nLine, 2))
                        '    pLight.SetLight(5, pCurRecipe.nAlignLight2(m_nLine, 2))
                        'Else

                        '    pLight.SetLight(3, pCurRecipe.nAlignLight(m_nLine, 2))
                        '    pLight.SetLight(7, pCurRecipe.nAlignLight2(m_nLine, 2))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel3_Mark1) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p3, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel3_Mark1))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 4)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(4, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel3_Mark1) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p3, AlignMarkNumber.Mark1, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p3, AlignMarkNumber.Mark1, _
                                               pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark1).PositionDiffX, _
                                               pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark1).positionDiffY, _
                                               bGetAlignComplete(AlignMark.Panel3_Mark1)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera1) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel3_Mark1")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel3_Mark1) = True Then
                                pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = True
                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark1).PositionDiffX, pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark1).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam1), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam1), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam1), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p3).dMark1DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p3).dMark1DifferencePositionY)
                                tmpStrImage(4) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark1" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p3 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel3_Mark1) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark1.bmp", tmpStrImage(4))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p3, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel3_Mark1)})


                            Else
                                nCurRetryCnt(AlignMark.Panel3_Mark1) = nCurRetryCnt(AlignMark.Panel3_Mark1) + 1
                                tmpStrImage(4) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark1_" & nCurRetryCnt(AlignMark.Panel3_Mark1) & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p3 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel3_Mark1) & "_Align NG")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark1.bmp", tmpStrImage(4))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p3, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel3_Mark1)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel3_Mark1" & "  " & nCurRetryCnt(AlignMark.Panel3_Mark1))

                            End If


                        Else

                            bGetAlignComplete(AlignMark.Panel3_Mark1) = True

                        End If

                    Else
                        ' Manual Align 
                        If bManualAlignMark(AlignMark.Panel4_Mark1) = False Then
                            bManualAlignMark(AlignMark.Panel3_Mark1) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel3_Mark1
                            m_nExSeqIndex = 22
                            m_nSeqIndex = 50
                            strAlignLog = "MARK1:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p3, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel3_Mark1")
                            Exit Sub
                        End If
                    End If
                End If

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = False Then
                    nSavePath = AlignMark.Panel4_Mark1 + (m_nLine * 10)
                    If nCurRetryCnt(AlignMark.Panel4_Mark1) < nRetryCnt Then
                        '20170810 YDY 서브 마크 
                        'AlignSubMark(5)
                        'Select Case m_nLine
                        '    Case LINE.A
                        '        ChangeMMF_Model(_CAMERA.A_CAMERA_2, pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, nAlignSubMark(AlignMark.Panel4_Mark1)).strAlignMarkImageMMF_FileName)
                        '    Case LINE.B
                        '        ChangeMMF_Model(_CAMERA.B_CAMERA_2, pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, nAlignSubMark(AlignMark.Panel4_Mark1)).strAlignMarkImageMMF_FileName)
                        'End Select

                        'If m_nLine = LINE.A Then

                        '    pLight.SetLight(2, pCurRecipe.nAlignLight(m_nLine, 3))
                        '    pLight.SetLight(6, pCurRecipe.nAlignLight2(m_nLine, 3))
                        'Else
                        '    pLight.SetLight(4, pCurRecipe.nAlignLight(m_nLine, 3))
                        '    pLight.SetLight(8, pCurRecipe.nAlignLight2(m_nLine, 3))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel4_Mark1) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p4, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel4_Mark1))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 5)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(5, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel4_Mark1) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p4, AlignMarkNumber.Mark1, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p4, AlignMarkNumber.Mark1, _
                                              pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark1).PositionDiffX, _
                                              pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark1).positionDiffY, _
                                              bGetAlignComplete(AlignMark.Panel4_Mark1)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera2) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel4_Mark1")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel4_Mark1) = True Then
                                pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = True
                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark1).PositionDiffX, pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark1).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam2), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam2), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam2), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p4).dMark1DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p4).dMark1DifferencePositionY)
                                tmpStrImage(6) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark1" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p4 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel4_Mark1) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark1.bmp", tmpStrImage(6))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p4, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel4_Mark1)})


                            Else
                                nCurRetryCnt(AlignMark.Panel4_Mark1) = nCurRetryCnt(AlignMark.Panel4_Mark1) + 1
                                tmpStrImage(6) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark1_" & nCurRetryCnt(AlignMark.Panel4_Mark1) & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p4 + 1).ToString & "_Mark1" & "_" & nAlignSubMark(AlignMark.Panel4_Mark1) & "_Align NG")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark1.bmp", tmpStrImage(6))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p4, AlignMarkNumber.Mark1, nCurRetryCnt(AlignMark.Panel4_Mark1)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel4_Mark1" & "  " & nCurRetryCnt(AlignMark.Panel4_Mark1))

                            End If

                        Else

                            bGetAlignComplete(AlignMark.Panel4_Mark1) = True

                        End If

                    Else
                        ' Manual Align 
                        If bManualAlignMark(AlignMark.Panel3_Mark1) = False Then
                            bManualAlignMark(AlignMark.Panel4_Mark1) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel4_Mark1
                            m_nExSeqIndex = 22
                            m_nSeqIndex = 50

                            strAlignLog = "MARK1:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p4, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel4_Mark1")
                            Exit Sub
                        End If
                    End If
                End If

                If pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = True Then
                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_3, True)
                            pLDLT.PC_Infomation.bAlignOK3(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_3, True)
                            pLDLT.PC_Infomation.bAlignOK3(LINE.B) = True
                    End Select
                    SendAlignResult(2)

                    'GYN - 20170315 - T/T VisionAlign3
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign3, pTimeTac(m_nLine).dPC_VisionAlign3Temp, pTimeTac(m_nLine).dPLC_StageVisionPos3Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign3:: " & pTimeTac(m_nLine).dPC_VisionAlign3.ToString)
                    m_nSeqIndex = 23 ' normal

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = False And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = True Then
                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_3, True)
                            pLDLT.PC_Infomation.bAlignOK3(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_3, True)
                            pLDLT.PC_Infomation.bAlignOK3(LINE.B) = True
                    End Select
                    pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = True
                    SendAlignResult(2)
                    'GYN - 20170315 - T/T VisionAlign3
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign3, pTimeTac(m_nLine).dPC_VisionAlign3Temp, pTimeTac(m_nLine).dPLC_StageVisionPos3Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign3:: " & pTimeTac(m_nLine).dPC_VisionAlign3.ToString)
                    m_nSeqIndex = 23 'No glass Panel1

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = False And pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = True Then
                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_3, True)
                            pLDLT.PC_Infomation.bAlignOK3(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_3, True)
                            pLDLT.PC_Infomation.bAlignOK3(LINE.B) = True
                    End Select
                    pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = True
                    SendAlignResult(2)

                    'GYN - 20170315 - T/T VisionAlign3
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign3, pTimeTac(m_nLine).dPC_VisionAlign3Temp, pTimeTac(m_nLine).dPLC_StageVisionPos3Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign3:: " & pTimeTac(m_nLine).dPC_VisionAlign3.ToString)
                    m_nSeqIndex = 23 'No glass Panel2

                End If

            Case 23 'Forth Align Position Set Align Data
                If pLDLT.PLC_Infomation.bAlignRequest(m_nLine, Panel.p4) = False Then
                    Exit Sub
                End If

                'GYN - 20170315 - T/T StageVisionPos4
                If pTimeTac(m_nLine).bPLC_StageVisionPos4 = False Then
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_StageVisionPos4, pTimeTac(m_nLine).dPLC_StageVisionPos4Temp, pTimeTac(m_nLine).dPC_VisionAlign3Temp)
                    modPub.TacLog(m_nLine, "[PLC] StageVisionPos4:: " & pTimeTac(m_nLine).dPLC_StageVisionPos4.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos4 = True
                End If

                If m_nLine = LINE.A Then

                    pLight.SetLight(1, pCurRecipe.nAlignLight_mark2(m_nLine, 2))
                    pLight.SetLight(5, pCurRecipe.nAlignLight2_mark2(m_nLine, 2))

                    pLight.SetLight(2, pCurRecipe.nAlignLight_mark2(m_nLine, 3))
                    pLight.SetLight(6, pCurRecipe.nAlignLight2_mark2(m_nLine, 3))
                Else
                    pLight.SetLight(3, pCurRecipe.nAlignLight_mark2(m_nLine, 2))
                    pLight.SetLight(7, pCurRecipe.nAlignLight2_mark2(m_nLine, 2))

                    pLight.SetLight(4, pCurRecipe.nAlignLight_mark2(m_nLine, 3))
                    pLight.SetLight(8, pCurRecipe.nAlignLight2_mark2(m_nLine, 3))
                End If

                If IsSleepTime(pCurSystemParam.nVisionAlignDelay) = True Then

                    modPub.TacLog(m_nLine, "[PC] VisionAlignDelay ::" & pCurSystemParam.nVisionAlignDelay.ToString)
                    pTimeTac(m_nLine).bPLC_StageVisionPos4 = False

                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = True Then
                        pCurMark_Data_1 = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 0)        '' line, panel, mark 순서, 갯수
                    End If

                    If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = True Then
                        pCurMark_Data_2 = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 0)        '' line, panel, mark 순서, 갯수
                    End If

                    m_nSeqIndex = 24
                End If

            Case 24

                'Mark2인 경우 500ms 더 줌... 모터 가감속문제 발생 및 카메라 노출 시간 문제 발생.
                'If IsSleepTime(pCurSystemParam.nVisionAlignDelay) = True Then

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = True And pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = False Then
                    nSavePath = AlignMark.Panel3_Mark2 + (m_nLine * 10)
                    If nCurRetryCnt(AlignMark.Panel3_Mark2) < nRetryCnt Then

                        'If m_nLine = LINE.A Then

                        '    pLight.SetLight(1, pCurRecipe.nAlignLight_mark2(m_nLine, 2))
                        '    pLight.SetLight(5, pCurRecipe.nAlignLight2_mark2(m_nLine, 2))
                        'Else
                        '    pLight.SetLight(3, pCurRecipe.nAlignLight_mark2(m_nLine, 2))
                        '    pLight.SetLight(7, pCurRecipe.nAlignLight2_mark2(m_nLine, 2))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel3_Mark2) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p3, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel3_Mark2))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 6)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(6, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel3_Mark2) = modVision.FindModel(nChCamera1, pMF_Result, nSavePath, m_nLine, Panel.p3, AlignMarkNumber.Mark2, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p3, AlignMarkNumber.Mark2, _
                                               pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark2).PositionDiffX, _
                                               pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark2).positionDiffY, _
                                               bGetAlignComplete(AlignMark.Panel3_Mark2)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera1) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel3_Mark2")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel3_Mark2) = True Then
                                pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = True
                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark2).PositionDiffX, pMF_Result(m_nLine, Panel.p3, AlignMarkNumber.Mark2).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam1), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam1), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam1), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p3).dMark2DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p3).dMark2DifferencePositionY)
                                tmpStrImage(5) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark2" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p3 + 1).ToString & "_Mark2" & "_" & nAlignSubMark(AlignMark.Panel3_Mark2) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark2.bmp", tmpStrImage(5))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p3, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel3_Mark2)})


                            Else
                                nCurRetryCnt(AlignMark.Panel3_Mark2) = nCurRetryCnt(AlignMark.Panel3_Mark2) + 1
                                tmpStrImage(5) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark2_" & nCurRetryCnt(AlignMark.Panel3_Mark2) & Format(Now, "_HH_mm_ss") & ".jpg"
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p3 + 1).ToString & "_Mark2.bmp", tmpStrImage(5))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p3, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel3_Mark2)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel3_Mark2" & "  " & nCurRetryCnt(AlignMark.Panel3_Mark2))

                            End If

                        Else

                            bGetAlignComplete(AlignMark.Panel3_Mark2) = True

                        End If



                    Else
                        ' Manual Align 
                        If bManualAlignMark(AlignMark.Panel4_Mark2) = False Then
                            bManualAlignMark(AlignMark.Panel3_Mark2) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel3_Mark2
                            m_nExSeqIndex = 24
                            m_nSeqIndex = 50

                            strAlignLog = "MARK2:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p3, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel3_Mark2")
                            Exit Sub
                        End If
                    End If
                End If

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = False Then
                    nSavePath = AlignMark.Panel4_Mark2 + (m_nLine * 10)
                    If nCurRetryCnt(AlignMark.Panel4_Mark2) < nRetryCnt Then

                        'If m_nLine = LINE.A Then

                        '    pLight.SetLight(2, pCurRecipe.nAlignLight_mark2(m_nLine, 3))
                        '    pLight.SetLight(6, pCurRecipe.nAlignLight2_mark2(m_nLine, 3))
                        'Else
                        '    pLight.SetLight(4, pCurRecipe.nAlignLight_mark2(m_nLine, 3))
                        '    pLight.SetLight(8, pCurRecipe.nAlignLight2_mark2(m_nLine, 3))
                        'End If

                        '20180115 Mark Merge
                        'bGetAlignComplete(AlignMark.Panel4_Mark2) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p4, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel4_Mark2))
                        '20180409 mark use
                        AlignSubMark(m_nLine, 7)
                        'For i As Integer = 0 To 2
                        '    If bMarkUse(7, i) = True Then
                        '        bGetAlignComplete(AlignMark.Panel4_Mark2) = modVision.FindModel(nChCamera2, pMF_Result, nSavePath, m_nLine, Panel.p4, AlignMarkNumber.Mark2, i)
                        '        Exit For
                        '    End If
                        'Next
                        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                        If CheckMarkPrePosSame(m_nLine, Panel.p4, AlignMarkNumber.Mark2, _
                                               pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark2).PositionDiffX, _
                                               pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark2).positionDiffY, _
                                               bGetAlignComplete(AlignMark.Panel4_Mark2)) = True Then
                            AlarmSeq.bMarkPosError(nChCamera2) = True
                            nExMarkPosSameErrorIndex = m_nSeqIndex
                            bMarkPosSameError = True
                            m_nSeqIndex = 60
                            SequenceLog(m_nLine, "Align Seq : Mark PreValue and CurValue Same Error Panel4_Mark2:")
                            Exit Sub
                        End If

                        If bAlignPass = False Then

                            If bGetAlignComplete(AlignMark.Panel4_Mark2) = True Then
                                pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = True
                                AdjustCameraFactor(pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark2).PositionDiffX, pMF_Result(m_nLine, Panel.p4, AlignMarkNumber.Mark2).positionDiffY, pCurSystemParam.dVisionScaleX(m_nLine, CAM.Cam2), pCurSystemParam.dVisionScaleY(m_nLine, CAM.Cam2), pCurSystemParam.dVisionTheta(m_nLine, CAM.Cam2), _
                                                   pCurRecipe.AlignResult(m_nLine, Panel.p4).dMark2DifferencePositionX, pCurRecipe.AlignResult(m_nLine, Panel.p4).dMark2DifferencePositionY)
                                tmpStrImage(7) = pCurSystemParam.strAlignImagePath(m_nLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark2" & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p4 + 1).ToString & "_Mark2" & "_" & nAlignSubMark(AlignMark.Panel4_Mark2) & "_Align Ok")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark2.bmp", tmpStrImage(7))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p4, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel4_Mark2)})



                            Else
                                nCurRetryCnt(AlignMark.Panel4_Mark2) = nCurRetryCnt(AlignMark.Panel4_Mark2) + 1
                                tmpStrImage(7) = pCurSystemParam.strAlignImagePath(m_nLine) & "\NG\" & Format(Now, "yyyy-MM-dd") & "\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark2_" & nCurRetryCnt(AlignMark.Panel4_Mark2) & Format(Now, "_HH_mm_ss") & ".jpg"
                                modPub.AlignSubMarkLog(m_strLine & (Panel.p4 + 1).ToString & "_Mark2" & "_" & nAlignSubMark(AlignMark.Panel4_Mark2) & "_Align NG")
                                FileCopy("C:\Vision Temp\" & m_strLine & (Panel.p4 + 1).ToString & "_Mark2.bmp", tmpStrImage(7))
                                Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p4, AlignMarkNumber.Mark2, nCurRetryCnt(AlignMark.Panel4_Mark2)})

                                modPub.TacLog(m_nLine, "[PC] RetryAlign :: " & "Panel4_Mark2" & "  " & nCurRetryCnt(AlignMark.Panel4_Mark2))

                            End If

                        Else

                            bGetAlignComplete(AlignMark.Panel4_Mark2) = True

                        End If

                    Else
                        ' Manual Align 
                        If bManualAlignMark(AlignMark.Panel3_Mark2) = False Then
                            bManualAlignMark(AlignMark.Panel4_Mark2) = True
                            bManualAlignMode = True
                            m_bLightOnOff = True
                            nManualAlingIndex = AlignMark.Panel4_Mark2
                            m_nExSeqIndex = 24
                            m_nSeqIndex = 50

                            strAlignLog = "MARK2:: " & "0" & ", " & "0"
                            AlignDataLog(m_nLine, Panel.p4, strAlignLog)
                            modPub.TacLog(m_nLine, "[PC] ManualAlign :: " & "Panel4_Mark2")
                            Exit Sub
                        End If
                    End If
                End If

                If pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = True Then

                    If bAlignPass = False Then
                        'AlignMarkDistance(Panel.p3)
                        ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p3, AlignMarkNumber.Mark2, dTmpDistance(Panel.p3)})

                        'If Math.Abs(dTmpDistance(Panel.p3) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                        '    nExDistanceIndex = m_nSeqIndex
                        '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                        '    nDistanceErrorGlass = 3
                        '    bDistanceError = True
                        '    m_nSeqIndex = 40
                        '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel3:" & dTmpDistance(Panel.p3))
                        '    Exit Select
                        'End If
                    End If


                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 2).dAngle > pCurRecipe.dThetaLimit_4 Then
                    '            bThetaError4 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 2).dAngle > pCurRecipe.dThetaLimit_3 Then
                    '            bThetaError3 = True
                    '            StopSeq()
                    '        End If
                    'End Select

                    If bAlignPass = False Then
                        'AlignMarkDistance(Panel.p4)
                        ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p4, AlignMarkNumber.Mark2, dTmpDistance(Panel.p4)})

                        'If Math.Abs(dTmpDistance(Panel.p4) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                        '    nExDistanceIndex = m_nSeqIndex
                        '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                        '    nDistanceErrorGlass = 4
                        '    bDistanceError = True
                        '    m_nSeqIndex = 40
                        '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel4:" & dTmpDistance(Panel.p4))
                        '    Exit Select
                        'End If
                    End If


                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 3).dAngle > pCurRecipe.dThetaLimit_3 Then
                    '            bThetaError3 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 3).dAngle > pCurRecipe.dThetaLimit_4 Then
                    '            bThetaError4 = True
                    '            StopSeq()
                    '        End If
                    'End Select

                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_4, True)
                            pLDLT.PC_Infomation.bAlignOK4(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_4, True)
                            pLDLT.PC_Infomation.bAlignOK4(LINE.B) = True
                    End Select
                    SendAlignResult(3)

                    'GYN - 20170315 - T/T VisionAlign4
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign4, pTimeTac(m_nLine).dPC_VisionAlign4Temp, pTimeTac(m_nLine).dPLC_StageVisionPos4Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign4:: " & pTimeTac(m_nLine).dPC_VisionAlign4.ToString)

                    m_nSeqIndex = 30 ' normal

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = False And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = True Then
                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_4, True)
                            pLDLT.PC_Infomation.bAlignOK4(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_4, True)
                            pLDLT.PC_Infomation.bAlignOK4(LINE.B) = True
                    End Select

                    If bAlignPass = False Then

                        'AlignMarkDistance(Panel.p4)
                        ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p4, AlignMarkNumber.Mark2, dTmpDistance(Panel.p4)})

                        'If Math.Abs(dTmpDistance(Panel.p4) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                        '    nExDistanceIndex = m_nSeqIndex
                        '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                        '    nDistanceErrorGlass = 4
                        '    bDistanceError = True
                        '    bDistanceError = True
                        '    m_nSeqIndex = 40
                        '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel4:" & dTmpDistance(Panel.p4))
                        '    Exit Select
                        'End If
                    End If

                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 3).dAngle > pCurRecipe.dThetaLimit_3 Then
                    '            bThetaError3 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 3).dAngle > pCurRecipe.dThetaLimit_4 Then
                    '            bThetaError4 = True
                    '            StopSeq()
                    '        End If
                    'End Select


                    pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = True
                    SendAlignResult(3)

                    'GYN - 20170315 - T/T VisionAlign4
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign4, pTimeTac(m_nLine).dPC_VisionAlign4Temp, pTimeTac(m_nLine).dPLC_StageVisionPos4Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign4:: " & pTimeTac(m_nLine).dPC_VisionAlign4.ToString)

                    m_nSeqIndex = 30 'No glass Panel1

                ElseIf pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = False And pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = True Then

                    If bAlignPass = False Then
                        'AlignMarkDistance(Panel.p3)
                        ''Mainform.Invoke(Mainform.deleVisionUpdate, New Object(3) {m_nLine, Panel.p3, AlignMarkNumber.Mark2, dTmpDistance(Panel.p3)})

                        'If Math.Abs(dTmpDistance(Panel.p3) - pCurRecipe.dAlignDistance) > pCurRecipe.dAlignErrorRange Then
                        '    nExDistanceIndex = m_nSeqIndex
                        '    AlarmSeq.bDistanceError(m_nLine) = True  'Alarm Merge
                        '    nDistanceErrorGlass = 3
                        '    bDistanceError = True
                        '    m_nSeqIndex = 40
                        '    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error Panel3:" & dTmpDistance(Panel.p3))
                        '    Exit Select
                        'End If
                    End If

                    'Select Case m_nLine
                    '    Case 0
                    '        If pCurRecipe.AlignResult(m_nLine, 2).dAngle > pCurRecipe.dThetaLimit_4 Then
                    '            bThetaError4 = True
                    '            StopSeq()
                    '        End If
                    '    Case 1
                    '        If pCurRecipe.AlignResult(m_nLine, 2).dAngle > pCurRecipe.dThetaLimit_3 Then
                    '            bThetaError3 = True
                    '            StopSeq()
                    '        End If
                    'End Select

                    Select Case m_nLine
                        Case LINE.A
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_4, True)
                            pLDLT.PC_Infomation.bAlignOK4(LINE.A) = True
                        Case LINE.B
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_4, True)
                            pLDLT.PC_Infomation.bAlignOK4(LINE.B) = True
                    End Select

                    pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = True
                    SendAlignResult(3)

                    'GYN - 20170315 - T/T VisionAlign4
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPC_VisionAlign4, pTimeTac(m_nLine).dPC_VisionAlign4Temp, pTimeTac(m_nLine).dPLC_StageVisionPos4Temp)
                    modPub.TacLog(m_nLine, "[PC] VisionAlign4:: " & pTimeTac(m_nLine).dPC_VisionAlign4.ToString)
                    m_nSeqIndex = 30 'No glass Panel2

                End If
                'End If

            Case 30

                'Tact Time Check.
                modSequence.GetTactTime(pTimeTac(m_nLine).dAlignTime, pTimeTac(m_nLine).dTmpAlignTime, pTimeTac(m_nLine).dStart_Time)
                pTimeTac(m_nLine).bAlignTime = False
                TacLog(m_nLine, "[TOTAL] VisionAlignComplete:: " & pTimeTac(m_nLine).dAlignTime)
                SequenceLog(m_nLine, "Align Seq Complete")

                If pLDLT.PLC_Infomation.bPLC_AlignCheckMode = True Then
                    Thread.Sleep(100)
                    m_nMainSeqIndex = 0
                    m_nSeqIndex = 1
                    modPub.TestLog("얼라인 모드 사용 중 입니다!")
                Else
                    m_nMainSeqIndex = 2
                    m_nSeqIndex = 100
                End If
                

            Case 40 'Mark Distance Error... 
                If bDistanceError = True Then
                    'Distance Error
                    'bDistanceError = False
                    'm_nSeqIndex = nExDistanceIndex
                    SequenceLog(m_nLine, "Align Seq : Mark DistanceIndex Error :" & nExDistanceIndex)
                    StopSeq()
                Else
                    SequenceLog(m_nLine, "Align Seq" & m_nSeqIndex & "들어올수없는 Case 항목..")
                End If

            Case 60 '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
                If bMarkPosSameError = True Then
                    SequenceLog(m_nLine, "Align Seq : Previous Mark Position Same Error :" & nExMarkPosSameErrorIndex)
                    StopSeq()
                    bMarkPosSameError = False
                Else
                    SequenceLog(m_nLine, "Align Seq" & m_nSeqIndex & "들어올수없는 Case 항목..")
                End If
        End Select

        If m_nSeqIndex <> nSeqIndex Then

            nSeqIndex = m_nSeqIndex
            SequenceLog(m_nLine, "Align Seq ::" & m_nSeqIndex)

        End If


    End Sub

    Private Sub ManualAlign()
        Select Case m_nSeqIndex
            Case 50
                If bManualAlignMode = False And bManualAlignMark_Get(nManualAlingIndex) = True Then
                    bManualAlignMark(nManualAlingIndex) = False
                    bManualAlignMark_Get(nManualAlingIndex) = False
                    m_nSeqIndex = m_nExSeqIndex
                Else
                    '여기서 PLC에 NG 신호 전달.
                    Select Case nManualAlingIndex
                        Case AlignMark.Panel1_Mark1, AlignMark.Panel2_Mark1
                            SendAlignResult(0)
                        Case AlignMark.Panel1_Mark2, AlignMark.Panel2_Mark2
                            SendAlignResult(1)
                        Case AlignMark.Panel3_Mark1, AlignMark.Panel4_Mark1
                            SendAlignResult(2)
                        Case AlignMark.Panel3_Mark2, AlignMark.Panel4_Mark2
                            SendAlignResult(3)
                    End Select

                    ''GYN - 2017.03.14 - 조명값 '0'으로 변경
                    ''화이트 조명으로 진행 시 한곳에서 오래동안 빛을 발하면 제품에 손상된다는...
                    ''그래서 조명 끝다.
                    ''* 조명이 잘 안꺼지면 Sleep을 늘려보고...
                    ''* 조명이 잘 꺼지면 Sleep을 줄이는 걸로.
                    ''* 화이트 조명만 끄면 되니깐... 박스 조명만 꺼볼까? IR은 말고?
                    'If pCurSystemParam.nLightUse = 1 Then
                     '   If m_bLightOnOff = True Then
                      '      Select Case m_nLine
                       '         Case LINE.A
                        '            pLight.SetLight(1, 0)
                         '           pLight.SetLight(2, 0)
                          '          pLight.SetLight(5, 0)
                           '         pLight.SetLight(6, 0)
                            '    Case LINE.B
'
 '                                   pLight.SetLight(3, 0)
  '                                  pLight.SetLight(4, 0)
   '                                 pLight.SetLight(7, 0)
    '                                pLight.SetLight(8, 0)
     '                       End Select

      '                      m_bLightOnOff = False

                    '    End If
                    'End If

                End If
        End Select

        If m_nSeqIndex <> nSeqIndex Then

            nSeqIndex = m_nSeqIndex
            SequenceLog(m_nLine, "ManualAlignSeq ::" & m_nSeqIndex)

        End If

    End Sub

    Private dInspOffsetX(3) As Double
    Private dRcpOffsetX(3) As Double
    Private dInspOffsetY(3) As Double
    Private dRcpOffsetY(3) As Double
    Private dInspAngle(3) As Double
    Private dRcpAngle(3) As Double
    Private nCuttingCnt As Integer

    Private Sub Trimming()

        Dim tmpStrAddress As String = ""

        Select Case m_nSeqIndex
            Case 100

                m_nMainSeqIndex = 2

                'GYN - Camera On/Off 
                'If m_nLine = 0 Then
                '    If pCamera(0).m_bConnected Then
                '        If pCamera(0).IsStreaming() = True Then
                '            pCamera(0).StoppingStream() 'StoppingStream()
                '        End If
                '    End If
                '    If pCamera(1).m_bConnected Then
                '        If pCamera(1).IsStreaming() = True Then
                '            pCamera(1).StoppingStream() 'StoppingStream()
                '        End If
                '    End If

                'End If

                'If m_nLine = 1 Then
                '    If pCamera(2).m_bConnected Then
                '        If pCamera(2).IsStreaming() = True Then
                '            pCamera(2).StoppingStream() 'StoppingStream()
                '        End If
                '    End If
                '    If pCamera(3).m_bConnected Then
                '        If pCamera(3).IsStreaming() = True Then
                '            pCamera(3).StoppingStream() 'StoppingStream()
                '        End If
                '    End If
                'End If

                For i As Integer = 0 To 3
                    dInspOffsetX(i) = 0.0
                    dRcpOffsetX(i) = 0.0
                    dInspOffsetY(i) = 0.0
                    dRcpOffsetY(i) = 0.0
                    dInspAngle(i) = 0.0
                    dRcpAngle(i) = 0.0
                Next

                ' Glass 유/무 확인 후 Trimming 시작.
                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) Then
                    modVision.GetGlassCenter(m_nLine, Panel.p1, pCurRecipe, pCurSystemParam)
                End If

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) Then
                    modVision.GetGlassCenter(m_nLine, Panel.p2, pCurRecipe, pCurSystemParam)
                End If

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) Then
                    modVision.GetGlassCenter(m_nLine, Panel.p3, pCurRecipe, pCurSystemParam)
                End If

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) Then
                    modVision.GetGlassCenter(m_nLine, Panel.p4, pCurRecipe, pCurSystemParam)
                End If

                nCuttingCnt = 0

                m_nSeqIndex = 110

            Case 110    '이거를 꼭 해줘야 하나.. 한 번 불러오면 끝인건데...

				' plc 얼라인 보정값 송부
                Select Case m_nLine
                    Case 0
                        pLDLT.SetPreAlignData(0, 0,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p1).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p1).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p1).dAngle)

                        pLDLT.SetPreAlignData(0, 1,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p2).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p2).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p2).dAngle)

                        pLDLT.SetPreAlignData(0, 2,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p3).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p3).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p3).dAngle)

                        pLDLT.SetPreAlignData(0, 3,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p4).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p4).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p4).dAngle)
                    Case 1
                        pLDLT.SetPreAlignData(1, 0,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p1).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p1).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p1).dAngle)

                        pLDLT.SetPreAlignData(1, 1,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p2).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p2).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p2).dAngle)

                        pLDLT.SetPreAlignData(1, 2,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p3).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p3).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p3).dAngle)

                        pLDLT.SetPreAlignData(1, 3,
                        (pCurRecipe.AlignResult(m_nLine, Panel.p4).dMarkDestPositionX - (pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine))),
                        (pCurRecipe.AlignResult(m_nLine, Panel.p4).dMarkDestPositionY - (pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))),
                        pCurRecipe.AlignResult(m_nLine, Panel.p4).dAngle)


                End Select

                m_nSeqIndex = 115

            Case 115
                ' Laser Req 받고 Trimming 시작.
                If pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p1) = True Or _
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p2) = True Or _
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p3) = True Or _
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p4) = True Then

                    'GYN - 20170315 - T/T Trimming Total
                    modSequence.GetTactTime(pTimeTac(m_nLine).dStart_Time, pTimeTac(m_nLine).dTmpTrimmingTime, 0)
                    pTimeTac(m_nLine).bTrimmingTime = True

                    'GYN - 20170315 - T/T StageCuttingPosComplete
                    modSequence.GetTactTime(pTimeTac(m_nLine).dPLC_StageCuttingPosComplete, pTimeTac(m_nLine).dPLC_StageCuttingPosCompleteTemp, pTimeTac(m_nLine).dPC_VisionAlign4Temp)
                    modPub.TacLog(m_nLine, "[PLC] StageCuttingPosComplete:: " & pTimeTac(m_nLine).dPLC_StageCuttingPosComplete.ToString)

                    If pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p1) = True And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) Then
                        modVision.GetGlassCenter(m_nLine, Panel.p1, pCurRecipe, pCurSystemParam)
                        bTrimmingAble(0) = True
                    End If

                    If pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p2) = True And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) Then
                        modVision.GetGlassCenter(m_nLine, Panel.p2, pCurRecipe, pCurSystemParam)
                        bTrimmingAble(1) = True
                    End If

                    If pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p3) = True And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) Then
                        modVision.GetGlassCenter(m_nLine, Panel.p3, pCurRecipe, pCurSystemParam)
                        bTrimmingAble(2) = True
                    End If

                    If pLDLT.PLC_Infomation.bLaserMarkingRequest(m_nLine, Panel.p4) = True And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) Then
                        modVision.GetGlassCenter(m_nLine, Panel.p4, pCurRecipe, pCurSystemParam)
                        bTrimmingAble(3) = True
                    End If

                    m_nSeqIndex = 120

                End If

            Case 120

                If IsSleepTime(pCurSystemParam.nTrimmingDelay) = True Then

                    modPub.TacLog(m_nLine, "[PC] TrimmingDelay ::" & pCurSystemParam.nTrimmingDelay.ToString)

                    Select Case m_nLine
                        Case 0
                            If bTrimmingAble(0) Then    '2->1
                                pScanner(1).RTC6SetMatrix(90)
                                dRcpOffsetX(0) = pCurRecipe.RecipeMarkingData(m_nLine, 0).dOffsetX
                                dRcpOffsetY(0) = pCurRecipe.RecipeMarkingData(m_nLine, 0).dOffsetY
                                dRcpAngle(0) = pCurRecipe.RecipeMarkingData(m_nLine, 0).dOffsetAngle
                                dInspOffsetX(0) = (pCurRecipe.AlignResult(m_nLine, 0).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))
                                dInspOffsetY(0) = (pCurRecipe.AlignResult(m_nLine, 0).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(0) = pCurRecipe.AlignResult(m_nLine, 0).dAngle

                                modRecipe.ExecuteMarking(1, dInspOffsetX(0) + dRcpOffsetX(0), _
                                                             dInspOffsetY(0) + dRcpOffsetY(0), _
                                                             dInspAngle(0) + dRcpAngle(0), _
                                                             pCurRecipe.RecipeMarkingData(m_nLine, 0), pCurRecipe.PenData, True)
                            End If

                            If bTrimmingAble(1) Then    '1->2
                                pScanner(0).RTC6SetMatrix(90)
                                dRcpOffsetX(1) = pCurRecipe.RecipeMarkingData(m_nLine, 1).dOffsetX
                                dRcpOffsetY(1) = pCurRecipe.RecipeMarkingData(m_nLine, 1).dOffsetY
                                dRcpAngle(1) = pCurRecipe.RecipeMarkingData(m_nLine, 1).dOffsetAngle
                                dInspOffsetX(1) = (pCurRecipe.AlignResult(m_nLine, 1).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))
                                dInspOffsetY(1) = (pCurRecipe.AlignResult(m_nLine, 1).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(1) = pCurRecipe.AlignResult(m_nLine, 1).dAngle

                                modRecipe.ExecuteMarking(0, dInspOffsetX(1) + dRcpOffsetX(1), _
                                                            dInspOffsetY(1) + dRcpOffsetY(1), _
                                                            dInspAngle(1) + dRcpAngle(1), _
                                                            pCurRecipe.RecipeMarkingData(m_nLine, 1), pCurRecipe.PenData, True)
                            End If

                            If bTrimmingAble(2) Then    '4->3
                                pScanner(3).RTC6SetMatrix(90)
                                dRcpOffsetX(2) = pCurRecipe.RecipeMarkingData(m_nLine, 2).dOffsetX
                                dRcpOffsetY(2) = pCurRecipe.RecipeMarkingData(m_nLine, 2).dOffsetY
                                dRcpAngle(2) = pCurRecipe.RecipeMarkingData(m_nLine, 2).dOffsetAngle
                                dInspOffsetX(2) = (pCurRecipe.AlignResult(m_nLine, 2).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))
                                dInspOffsetY(2) = (pCurRecipe.AlignResult(m_nLine, 2).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(2) = pCurRecipe.AlignResult(m_nLine, 2).dAngle

                                modRecipe.ExecuteMarking(3, dInspOffsetX(2) + dRcpOffsetX(2), _
                                                           dInspOffsetY(2) + dRcpOffsetY(2), _
                                                           dInspAngle(2) + dRcpAngle(2), _
                                                           pCurRecipe.RecipeMarkingData(m_nLine, 2), pCurRecipe.PenData, True)
                            End If
                            If bTrimmingAble(3) Then    '3->4
                                pScanner(2).RTC6SetMatrix(90)
                                dRcpOffsetX(3) = pCurRecipe.RecipeMarkingData(m_nLine, 3).dOffsetX
                                dRcpOffsetY(3) = pCurRecipe.RecipeMarkingData(m_nLine, 3).dOffsetY
                                dRcpAngle(3) = pCurRecipe.RecipeMarkingData(m_nLine, 3).dOffsetAngle
                                dInspOffsetX(3) = (pCurRecipe.AlignResult(m_nLine, 3).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine))
                                dInspOffsetY(3) = (pCurRecipe.AlignResult(m_nLine, 3).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(3) = pCurRecipe.AlignResult(m_nLine, 3).dAngle

                                modRecipe.ExecuteMarking(2, dInspOffsetX(3) + dRcpOffsetX(3), _
                                                           dInspOffsetY(3) + dRcpOffsetY(3), _
                                                           dInspAngle(3) + dRcpAngle(3), _
                                                           pCurRecipe.RecipeMarkingData(m_nLine, 3), pCurRecipe.PenData, True)
                            End If

                        Case 1  'B라인

                            If bTrimmingAble(0) Then    'B1 <-> L1
                                pScanner(0).RTC6SetMatrix(90)
                                dRcpOffsetX(0) = pCurRecipe.RecipeMarkingData(m_nLine, 0).dOffsetX
                                dRcpOffsetY(0) = pCurRecipe.RecipeMarkingData(m_nLine, 0).dOffsetY
                                dRcpAngle(0) = pCurRecipe.RecipeMarkingData(m_nLine, 0).dOffsetAngle
                                dInspOffsetX(0) = (pCurRecipe.AlignResult(m_nLine, 0).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine)) * -1
                                dInspOffsetY(0) = (pCurRecipe.AlignResult(m_nLine, 0).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(0) = pCurRecipe.AlignResult(m_nLine, 0).dAngle

                                modRecipe.ExecuteMarking(0, dInspOffsetX(0) + dRcpOffsetX(0), _
                                                           dInspOffsetY(0) + dRcpOffsetY(0), _
                                                           dInspAngle(0) + dRcpAngle(0), _
                                                           pCurRecipe.RecipeMarkingData(m_nLine, 0), pCurRecipe.PenData, True)
                            End If

                            If bTrimmingAble(1) Then     'B2 <-> L3
                                'pScanner(1).RTC6SetMatrix(90)   '1->2
                                pScanner(1).RTC6SetMatrix(270)
                                dRcpOffsetX(1) = pCurRecipe.RecipeMarkingData(m_nLine, 1).dOffsetX
                                dRcpOffsetY(1) = pCurRecipe.RecipeMarkingData(m_nLine, 1).dOffsetY
                                dRcpAngle(1) = pCurRecipe.RecipeMarkingData(m_nLine, 1).dOffsetAngle
                                dInspOffsetX(1) = (pCurRecipe.AlignResult(m_nLine, 1).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine)) * -1
                                dInspOffsetY(1) = (pCurRecipe.AlignResult(m_nLine, 1).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(1) = pCurRecipe.AlignResult(m_nLine, 1).dAngle

                                modRecipe.ExecuteMarking(1, dInspOffsetX(1) + dRcpOffsetX(1), _
                                                           dInspOffsetY(1) + dRcpOffsetY(1), _
                                                           dInspAngle(1) + dRcpAngle(1), _
                                                           pCurRecipe.RecipeMarkingData(m_nLine, 1), pCurRecipe.PenData, True)
                            End If

                            If bTrimmingAble(2) Then 'B3 <-> L2
                                pScanner(2).RTC6SetMatrix(90)   '2->1
                                dRcpOffsetX(2) = pCurRecipe.RecipeMarkingData(m_nLine, 2).dOffsetX
                                dRcpOffsetY(2) = pCurRecipe.RecipeMarkingData(m_nLine, 2).dOffsetY
                                dRcpAngle(2) = pCurRecipe.RecipeMarkingData(m_nLine, 2).dOffsetAngle
                                dInspOffsetX(2) = (pCurRecipe.AlignResult(m_nLine, 2).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine)) * -1
                                dInspOffsetY(2) = (pCurRecipe.AlignResult(m_nLine, 2).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(2) = pCurRecipe.AlignResult(m_nLine, 2).dAngle

                                modRecipe.ExecuteMarking(2, dInspOffsetX(2) + dRcpOffsetX(2), _
                                                           dInspOffsetY(2) + dRcpOffsetY(2), _
                                                           dInspAngle(2) + dRcpAngle(2), _
                                                           pCurRecipe.RecipeMarkingData(m_nLine, 2), pCurRecipe.PenData, True)
                            End If

                            If bTrimmingAble(3) Then 'B4 <-> L4
                                pScanner(3).RTC6SetMatrix(90)
                                dRcpOffsetX(3) = pCurRecipe.RecipeMarkingData(m_nLine, 3).dOffsetX
                                dRcpOffsetY(3) = pCurRecipe.RecipeMarkingData(m_nLine, 3).dOffsetY
                                dRcpAngle(3) = pCurRecipe.RecipeMarkingData(m_nLine, 3).dOffsetAngle
                                dInspOffsetX(3) = (pCurRecipe.AlignResult(m_nLine, 3).dMarkDestPositionY - pLDLT.PLC_Infomation.dTrimmingPosY(m_nLine)) * -1
                                dInspOffsetY(3) = (pCurRecipe.AlignResult(m_nLine, 3).dMarkDestPositionX - pLDLT.PLC_Infomation.dTrimmingPosX(m_nLine)) * -1
                                dInspAngle(3) = pCurRecipe.AlignResult(m_nLine, 3).dAngle

                                modRecipe.ExecuteMarking(3, dInspOffsetX(3) + dRcpOffsetX(3), _
                                                           dInspOffsetY(3) + dRcpOffsetY(3), _
                                                           dInspAngle(3) + dRcpAngle(3), _
                                                           pCurRecipe.RecipeMarkingData(m_nLine, 3), pCurRecipe.PenData, True)
                            End If

                    End Select

                    m_nSeqIndex = 130

                End If

            Case 130
                '이건 Scanner bAbleWork 신호를 기다리기위한 부분임. 변경하면 안됨.
                If IsSleepTime(2000) = True Then
                    m_nSeqIndex = 140
                End If

            Case 140
                If pScanner(0).pStatus.bAbleWork And pScanner(1).pStatus.bAbleWork And pScanner(2).pStatus.bAbleWork And pScanner(3).pStatus.bAbleWork Then
                    'If IsSleepTime(50) = True Then
                    If IsSleepTime(10) = True Then  'Tack 줄일려면 낮추자.
                        m_nSeqIndex = 150
                    End If
                ElseIf pLDLT.PLC_Infomation.bLaserPassMode(0) = False Or pLDLT.PLC_Infomation.bLaserPassMode(1) = False Then
                    If pScanner(2).pStatus.bAbleWork And pScanner(3).pStatus.bAbleWork Then
                        If IsSleepTime(10) = True Then  'Tack 줄일려면 낮추자.
                            m_nSeqIndex = 150
                        End If
                    End If
                ElseIf pLDLT.PLC_Infomation.bLaserPassMode(2) = False Or pLDLT.PLC_Infomation.bLaserPassMode(3) = False Then
                    If pScanner(0).pStatus.bAbleWork And pScanner(1).pStatus.bAbleWork Then
                        If IsSleepTime(10) = True Then  'Tack 줄일려면 낮추자.
                            m_nSeqIndex = 150
                        End If
                    End If
                End If



            Case 150
                'bRet = False

                If m_nLine = LINE.A Then
                    pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_A_TRIMMING_COMP, True)
                    modPub.MelsecLog("Trimming A SetBit : " & clsLDLT.BIT.WB_A_TRIMMING_COMP)
                ElseIf m_nLine = LINE.B Then
                    pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_B_TRIMMING_COMP, True)
                    modPub.MelsecLog("Trimming B SetBit : " & clsLDLT.BIT.WB_B_TRIMMING_COMP)
                End If

                '20181108 tac time 감소 작업
                '20181108 스캐너 busy 신호 A,B Line 나눠져 있어서 통합 사용
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_A_1, False)
                pLDLT.PC_Infomation.bLaserBusy_1(LINE.A) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_A_2, False)
                pLDLT.PC_Infomation.bLaserBusy_2(LINE.A) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_A_3, False)
                pLDLT.PC_Infomation.bLaserBusy_3(LINE.A) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_A_4, False)
                pLDLT.PC_Infomation.bLaserBusy_4(LINE.A) = False

                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_B_1, False)
                pLDLT.PC_Infomation.bLaserBusy_1(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_B_2, False)
                pLDLT.PC_Infomation.bLaserBusy_2(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_B_3, False)
                pLDLT.PC_Infomation.bLaserBusy_3(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LASER_BUSY_B_4, False)
                pLDLT.PC_Infomation.bLaserBusy_4(LINE.B) = False
                modPub.MelsecLog("Trimming A,B Laser Busy All ReSetBit")

                'Tact Time Check.
                modSequence.GetTactTime(pTimeTac(m_nLine).dTrimmingTime, pTimeTac(m_nLine).dTmpTrimmingTime, pTimeTac(m_nLine).dStart_Time)
                pTimeTac(m_nLine).bTrimmingTime = False
                TacLog(m_nLine, "[TOTAL] TrimmingComplete:: " & pTimeTac(m_nLine).dTrimmingTime)

                'GYN - 20170315 - T/T CuttingComplete
                modSequence.GetTactTime(pTimeTac(m_nLine).dPC_CuttingComplete, pTimeTac(m_nLine).dPC_CuttingCompleteTemp, pTimeTac(m_nLine).dPLC_StageCuttingPosCompleteTemp)
                modPub.TacLog(m_nLine, "[PC] TrimmingComplete:: " & pTimeTac(m_nLine).dPC_CuttingComplete.ToString)

                'm_nSeqIndex = 160
                m_nSeqIndex = 155

            Case 155

                If pLDLT.PC_Infomation.bTrimmingComp(m_nLine) = False Then
                    If m_nLine = LINE.A Then
                        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_A_TRIMMING_COMP, True)
                        pLDLT.PC_Infomation.bTrimmingComp(m_nLine) = True
                        modPub.MelsecLog("Trimming A SetBit : " & clsLDLT.BIT.WB_A_TRIMMING_COMP)
                    ElseIf m_nLine = LINE.B Then
                        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_B_TRIMMING_COMP, True)
                        modPub.MelsecLog("Trimming B SetBit : " & clsLDLT.BIT.WB_B_TRIMMING_COMP)
                        pLDLT.PC_Infomation.bTrimmingComp(m_nLine) = True
                    End If
                Else
                    m_nSeqIndex = 160
                End If

            Case 160

                If pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p1) = False And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p2) = False And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p3) = False And pLDLT.PLC_Infomation.bGlassExist(m_nLine, Panel.p4) = False Then
                    m_nSeqIndex = 1
                    m_nMainSeqIndex = 0
                End If
                'If IsSleepTime(1000) = True Then

                '    m_nSeqIndex = 1
                '    m_nMainSeqIndex = 0

                'End If

        End Select

        If m_nSeqIndex <> nSeqIndex Then

            nSeqIndex = m_nSeqIndex
            SequenceLog(m_nLine, "Trimming Seq ::" & m_nSeqIndex)

        End If

    End Sub

    Public Sub ResetAlignBit()
        Select Case m_nLine
            Case 0 ' A line
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_1, False)
                pLDLT.PC_Infomation.bAlignOK1(LINE.A) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_2, False)
                pLDLT.PC_Infomation.bAlignOK2(LINE.A) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_3, False)
                pLDLT.PC_Infomation.bAlignOK3(LINE.A) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_OK_4, False)
                pLDLT.PC_Infomation.bAlignOK4(LINE.A) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_1, False)
                pLDLT.PC_Infomation.bAlignNG1(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_2, False)
                pLDLT.PC_Infomation.bAlignNG2(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_3, False)
                pLDLT.PC_Infomation.bAlignNG3(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_4, False)
                pLDLT.PC_Infomation.bAlignNG4(LINE.B) = False

                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_A_TRIMMING_COMP, False)
                pLDLT.PC_Infomation.bTrimmingComp(LINE.A) = False

            Case 1 ' B line
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_1, False)
                pLDLT.PC_Infomation.bAlignOK1(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_2, False)
                pLDLT.PC_Infomation.bAlignOK2(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_3, False)
                pLDLT.PC_Infomation.bAlignOK3(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_OK_4, False)
                pLDLT.PC_Infomation.bAlignOK4(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_1, False)
                pLDLT.PC_Infomation.bAlignNG1(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_2, False)
                pLDLT.PC_Infomation.bAlignNG2(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_3, False)
                pLDLT.PC_Infomation.bAlignNG3(LINE.B) = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_4, False)
                pLDLT.PC_Infomation.bAlignNG4(LINE.B) = False

                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_B_TRIMMING_COMP, False)
                pLDLT.PC_Infomation.bTrimmingComp(LINE.B) = False
        End Select
    End Sub

    Public Sub ResetParam()
        pCurRecipe.AlignResult(m_nLine, 0).bGetMark1_OK = False
        pCurRecipe.AlignResult(m_nLine, 1).bGetMark1_OK = False
        pCurRecipe.AlignResult(m_nLine, 2).bGetMark1_OK = False
        pCurRecipe.AlignResult(m_nLine, 3).bGetMark1_OK = False

        pCurRecipe.AlignResult(m_nLine, 0).bGetMark2_OK = False
        pCurRecipe.AlignResult(m_nLine, 1).bGetMark2_OK = False
        pCurRecipe.AlignResult(m_nLine, 2).bGetMark2_OK = False
        pCurRecipe.AlignResult(m_nLine, 3).bGetMark2_OK = False

        bTrimmingAble(0) = False
        bTrimmingAble(1) = False
        bTrimmingAble(2) = False
        bTrimmingAble(3) = False

        bGetAlignComplete(0) = False
        bGetAlignComplete(1) = False
        bGetAlignComplete(2) = False
        bGetAlignComplete(3) = False
        bGetAlignComplete(4) = False
        bGetAlignComplete(5) = False
        bGetAlignComplete(6) = False
        bGetAlignComplete(7) = False

        bManualAlignMark(0) = False
        bManualAlignMark(1) = False
        bManualAlignMark(2) = False
        bManualAlignMark(3) = False
        bManualAlignMark(4) = False
        bManualAlignMark(5) = False
        bManualAlignMark(6) = False
        bManualAlignMark(7) = False

        bManualAlignMark_Get(0) = False
        bManualAlignMark_Get(1) = False
        bManualAlignMark_Get(2) = False
        bManualAlignMark_Get(3) = False
        bManualAlignMark_Get(4) = False
        bManualAlignMark_Get(5) = False
        bManualAlignMark_Get(6) = False
        bManualAlignMark_Get(7) = False

        nCurRetryCnt(0) = 0
        nCurRetryCnt(1) = 0
        nCurRetryCnt(2) = 0
        nCurRetryCnt(3) = 0
        nCurRetryCnt(4) = 0
        nCurRetryCnt(5) = 0
        nCurRetryCnt(6) = 0
        nCurRetryCnt(7) = 0

        If bManualAlignPopUp = True Then
            bManualAlignPopUp = False
            'frmMSG.Hide()
        End If
        bUseManualAlign = False
        bManualAlignMode = False
        m_bLightOnOff = False

        tmpStrImage(0) = ""
        tmpStrImage(1) = ""
        tmpStrImage(2) = ""
        tmpStrImage(3) = ""
        tmpStrImage(4) = ""
        tmpStrImage(5) = ""
        tmpStrImage(6) = ""
        tmpStrImage(7) = ""

        bDistanceError = False
        bThetaError1 = False
        bThetaError2 = False
        bThetaError3 = False
        bThetaError4 = False
        bMarkUseError = False  '20170810 YDY SUBMARK

        'AlarmSeq.bDistanceError(m_nLine) = False

        '20170810 YDY SUBMARK
        For i As Integer = 0 To 7
            For j As Integer = 0 To 2
                bFirstRetry(i, j) = False
            Next
        Next
        For i As Integer = 0 To 7
            For j As Integer = 0 To 2
                bMarkUse(i, j) = False
            Next
        Next
        For i As Integer = 0 To 7
            For j As Integer = 0 To 2
                bMarkUseNot(i, j) = False
            Next
        Next

        'pMF_Result(m_nLine).Init()
'20180723
        For nPanel As Integer = 0 To Panel.p4
            For nMark As Integer = 0 To 1
                pMF_Result(m_nLine, nPanel, nMark).Init()
            Next
        Next

    End Sub

    Private Sub SendAlignResult(ByVal ipIndex As Integer)
        Select Case m_nLine
            Case LINE.A
                Select Case ipIndex '측정 위치 개념으로 OK / NG를 보낸다.
                    Case 0
                        'If pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = True Then
                        If pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_1, False)
                            pLDLT.PC_Infomation.bAlignNG1(LINE.A) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG1(LINE.A) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_1, True)
                                pLDLT.PC_Infomation.bAlignNG1(LINE.A) = True
                            End If
                        End If
                    Case 1
                        'If pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = True Then
                        If pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_2, False)
                            pLDLT.PC_Infomation.bAlignNG2(LINE.A) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG2(LINE.A) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_2, True)
                                pLDLT.PC_Infomation.bAlignNG2(LINE.A) = True
                            End If
                        End If
                    Case 2
                        'If pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = True Then
                        If pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_3, False)
                            pLDLT.PC_Infomation.bAlignNG3(LINE.A) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG3(LINE.A) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_3, True)
                                pLDLT.PC_Infomation.bAlignNG3(LINE.A) = True
                            End If
                        End If
                    Case 3
                        'If pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = True Then
                        If pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_4, False)
                            pLDLT.PC_Infomation.bAlignNG4(LINE.A) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG4(LINE.A) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_A_NG_4, True)
                                pLDLT.PC_Infomation.bAlignNG4(LINE.A) = True
                            End If
                        End If
                End Select
            Case LINE.B
                Select Case ipIndex
                    Case Panel.p1
                        If pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark1_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_1, False)
                            pLDLT.PC_Infomation.bAlignNG1(LINE.B) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG1(LINE.B) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_1, True)
                                pLDLT.PC_Infomation.bAlignNG1(LINE.B) = True
                            End If
                        End If
                    Case Panel.p2
                        If pCurRecipe.AlignResult(m_nLine, Panel.p1).bGetMark2_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p2).bGetMark2_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_2, False)
                            pLDLT.PC_Infomation.bAlignNG2(LINE.B) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG2(LINE.B) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_2, True)
                                pLDLT.PC_Infomation.bAlignNG2(LINE.B) = True
                            End If
                        End If
                    Case Panel.p3
                        If pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark1_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark1_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_3, False)
                            pLDLT.PC_Infomation.bAlignNG3(LINE.B) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG3(LINE.B) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_3, True)
                                pLDLT.PC_Infomation.bAlignNG3(LINE.B) = True
                            End If
                        End If
                    Case Panel.p4
                        If pCurRecipe.AlignResult(m_nLine, Panel.p3).bGetMark2_OK = True And pCurRecipe.AlignResult(m_nLine, Panel.p4).bGetMark2_OK = True Then
                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_4, False)
                            pLDLT.PC_Infomation.bAlignNG4(LINE.B) = False
                        Else
                            If pLDLT.PC_Infomation.bAlignNG4(LINE.B) = False Then
                                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_ALIGN_B_NG_4, True)
                                pLDLT.PC_Infomation.bAlignNG4(LINE.B) = True
                            End If
                        End If
                End Select

        End Select
       
    End Sub

    Private Sub ChangeMMF_Model(ByVal ipIndex As Integer, ByVal ipMMF_FilePath As String)
        On Error GoTo SysErr

        '#If SIMUL <> 1 Then
        '        pMilInterface.LoadAlignModelTemplate(ipIndex, ipMMF_FilePath)

        '        If Matrox.MatroxImagingLibrary.MIL.M_NULL <> pMilInterface.MilModResult(ipIndex) Then
        '            Matrox.MatroxImagingLibrary.MIL.MmodFree(pMilInterface.MilModResult(ipIndex))
        '        End If
        '        Matrox.MatroxImagingLibrary.MIL.MmodAllocResult(pMilInterface.MilSystem, Matrox.MatroxImagingLibrary.MIL.M_DEFAULT, pMilInterface.MilModResult(ipIndex))
        '#End If

        Exit Sub
SysErr:

    End Sub

    'GYN - 마크간의 거리 값이 일정한지에 대하여 확인하기 위한 함수임.
    '1.마크간 거리가 65mm라면 들어오는 판넬의 마크가 65mm가 맞는지 확인용 함수.
    '2.혹여, 마크 오인식으로 인한 판넬 불량을 막기 위하여 확인 하는 함수.
    '  (마크를 오인식 할 경우 Mark간 거리 값이 다를테니)
    Private Sub AlignMarkDistance(ByVal ipPanel As Panel)

        Dim nDir As Integer = 0

        Select Case m_nLine
            Case LINE.A
                nDir = 1
            Case LINE.B
                nDir = -1
        End Select

        dTmpAlignPosX_Mark1 = pCurRecipe.dStageAlignMark1PosX(m_nLine, ipPanel) - pCurRecipe.AlignResult(m_nLine, ipPanel).dMark1DifferencePositionX
        dTmpAlignPosY_Mark1 = pCurRecipe.dStageAlignMark1PosY(m_nLine, ipPanel) + pCurRecipe.AlignResult(m_nLine, ipPanel).dMark1DifferencePositionY * nDir
        dTmpAlignPosX_Mark2 = pCurRecipe.dStageAlignMark2PosX(m_nLine, ipPanel) - pCurRecipe.AlignResult(m_nLine, ipPanel).dMark2DifferencePositionX
        dTmpAlignPosY_Mark2 = pCurRecipe.dStageAlignMark2PosY(m_nLine, ipPanel) + pCurRecipe.AlignResult(m_nLine, ipPanel).dMark2DifferencePositionY * nDir

        'GYN - 0.3보다 작아야 함. (차이값이)
        dTmpDistance(ipPanel) = Point2PointDistant(dTmpAlignPosX_Mark1, dTmpAlignPosY_Mark1, dTmpAlignPosX_Mark2, dTmpAlignPosY_Mark2)

        SequenceLog(m_nLine, "Panel" & (ipPanel + 1).ToString & " :" & dTmpDistance(ipPanel).ToString)
        '20190807 Distance Display
        dMarkDistance(m_nLine, ipPanel) = dTmpDistance(ipPanel)

    End Sub
    '20170810 YDY 서브 마크
    Private Sub AlignSubMark(ByVal ipLine As Integer, ByVal ipMark As Integer)

        Dim nPanel As Integer
        Dim nMarkType As Integer
        Dim nCamIndex As Integer
        Dim nAlignCompIndex As Integer



        Select Case ipMark
            Case 0
                nPanel = Panel.p1
                nMarkType = AlignMarkNumber.Mark1
                nCamIndex = nChCamera1
                nAlignCompIndex = AlignMark.Panel1_Mark1
            Case 1
                nPanel = Panel.p2
                nMarkType = AlignMarkNumber.Mark1
                nCamIndex = nChCamera2
                nAlignCompIndex = AlignMark.Panel2_Mark1
            Case 2
                nPanel = Panel.p1
                nMarkType = AlignMarkNumber.Mark2
                nCamIndex = nChCamera1
                nAlignCompIndex = AlignMark.Panel1_Mark2
            Case 3
                nPanel = Panel.p2
                nMarkType = AlignMarkNumber.Mark2
                nCamIndex = nChCamera2
                nAlignCompIndex = AlignMark.Panel2_Mark2
            Case 4
                nPanel = Panel.p3
                nMarkType = AlignMarkNumber.Mark1
                nCamIndex = nChCamera1
                nAlignCompIndex = AlignMark.Panel3_Mark1
            Case 5
                nPanel = Panel.p4
                nMarkType = AlignMarkNumber.Mark1
                nCamIndex = nChCamera2
                nAlignCompIndex = AlignMark.Panel4_Mark1
            Case 6
                nPanel = Panel.p3
                nMarkType = AlignMarkNumber.Mark2
                nCamIndex = nChCamera1
                nAlignCompIndex = AlignMark.Panel3_Mark2
            Case 7
                nPanel = Panel.p4
                nMarkType = AlignMarkNumber.Mark2
                nCamIndex = nChCamera2
                nAlignCompIndex = AlignMark.Panel4_Mark2
        End Select

        'Do
        If pRcpMark_Data(ipLine, nPanel, nMarkType, 0).bMark = False And
            pRcpMark_Data(ipLine, nPanel, nMarkType, 1).bMark = False And
            pRcpMark_Data(ipLine, nPanel, nMarkType, 2).bMark = False Then

            bMarkUseError = True
            m_nSeqIndex = 40

            Return
        End If

        ' Sbs_20180810 Retry 방법 변경
        ' 1, 2, 3 마크 3개를 모두 보는것을 1회로 하는 방법에서 마크1->Retry1회, 마크2->Retry2회, 마크3->Retry3회 로 변경(LGD요청사항)
        If pRcpMark_Data(ipLine, nPanel, nMarkType, 0).bMark = True And nCurRetryCnt(nAlignCompIndex) = 0 Then
            bGetAlignComplete(nAlignCompIndex) = modVision.FindModel(nCamIndex, pMF_Result(ipLine, nPanel, nMarkType), nSavePath, ipLine, nPanel, nMarkType, 0)
            If bGetAlignComplete(nAlignCompIndex) = True Then Return
        End If
        If pRcpMark_Data(ipLine, nPanel, nMarkType, 1).bMark = True And nCurRetryCnt(nAlignCompIndex) = 1 Then
            bGetAlignComplete(nAlignCompIndex) = modVision.FindModel(nCamIndex, pMF_Result(ipLine, nPanel, nMarkType), nSavePath, ipLine, nPanel, nMarkType, 1)
            If bGetAlignComplete(nAlignCompIndex) = True Then Return
        End If

        If pRcpMark_Data(ipLine, nPanel, nMarkType, 2).bMark = True And nCurRetryCnt(nAlignCompIndex) = 2 Then
            bGetAlignComplete(nAlignCompIndex) = modVision.FindModel(nCamIndex, pMF_Result(ipLine, nPanel, nMarkType), nSavePath, ipLine, nPanel, nMarkType, 2)
            If bGetAlignComplete(nAlignCompIndex) = True Then Return
        End If
        'Loop

    End Sub

    '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
    Function CheckMarkPrePosSame(ByVal nLine As Integer, ByVal nPanel As Integer, ByVal nMark As Integer, ByVal dMarkPosX As Double, ByVal dMarkPosY As Double, ByVal bGetAlignComplete As Boolean)

        If pdPrePanelMark(nLine, nPanel, nMark, 0) = dMarkPosX And pdPrePanelMark(nLine, nPanel, nMark, 1) = dMarkPosY And bGetAlignComplete = True Then
            modPub.TestLog("pdPrePanelMark(" & nLine & ", " & nPanel & ", " & nMark & ", 0) : " & pdPrePanelMark(nLine, nPanel, nMark, 0))
            modPub.TestLog("pdPrePanelMark(" & nLine & ", " & nPanel & ", " & nMark & ", 1) : " & pdPrePanelMark(nLine, nPanel, nMark, 1))

            modPub.TestLog("dMarkPosX : " & dMarkPosX)
            modPub.TestLog("dMarkPosY : " & dMarkPosY)

            pdPrePanelMark(nLine, nPanel, nMark, 0) = dMarkPosX
            pdPrePanelMark(nLine, nPanel, nMark, 1) = dMarkPosY

            Return True
        Else

            If bGetAlignComplete = False Then
                pdPrePanelMark(nLine, nPanel, nMark, 0) = 10000
                pdPrePanelMark(nLine, nPanel, nMark, 1) = 10000
            Else
                pdPrePanelMark(nLine, nPanel, nMark, 0) = dMarkPosX
                pdPrePanelMark(nLine, nPanel, nMark, 1) = dMarkPosY
            End If

            Return False
        End If


        'If pdPrePanelMark(nLine, nPanel, nMark, 0) = dMarkPosX And pdPrePanelMark(nLine, nPanel, nMark, 1) = dMarkPosY Then
        '    modPub.TestLog("pdPrePanelMark(" & nLine & ", " & nPanel & ", " & nMark & ", 0) : " & pdPrePanelMark(nLine, nPanel, nMark, 0))
        '    modPub.TestLog("pdPrePanelMark(" & nLine & ", " & nPanel & ", " & nMark & ", 1) : " & pdPrePanelMark(nLine, nPanel, nMark, 1))

        '    modPub.TestLog("dMarkPosX : " & dMarkPosX)
        '    modPub.TestLog("dMarkPosY : " & dMarkPosY)

        '    If bGetAlignComplete = False Then
        '        pdPrePanelMark(nLine, nPanel, nMark, 0) = 10000
        '        pdPrePanelMark(nLine, nPanel, nMark, 1) = 10000
        '    Else
        '        pdPrePanelMark(nLine, nPanel, nMark, 0) = dMarkPosX
        '        pdPrePanelMark(nLine, nPanel, nMark, 1) = dMarkPosY
        '    End If

        '    Return True
        'Else
        '    If bGetAlignComplete = False Then
        '        pdPrePanelMark(nLine, nPanel, nMark, 0) = 10000
        '        pdPrePanelMark(nLine, nPanel, nMark, 1) = 10000
        '    Else
        '        pdPrePanelMark(nLine, nPanel, nMark, 0) = dMarkPosX
        '        pdPrePanelMark(nLine, nPanel, nMark, 1) = dMarkPosY
        '    End If

        '    Return False
        'End If

    End Function

    'Private Sub AlignSubMark(ByVal ipMark As Integer)

    '    Select Case ipMark

    '        Case 0
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 0).bMark = True Then
    '                If bFirstRetry(0, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel1_Mark1) = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 0).nSubMark
    '                    bFirstRetry(0, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 1).bMark = True Then
    '                If bFirstRetry(0, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel1_Mark1) = pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 1).nSubMark
    '                    bFirstRetry(0, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 2).bMark = True Then
    '                If bFirstRetry(0, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel1_Mark1) = pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 2).nSubMark
    '                    bFirstRetry(0, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark1, 2).bMark = False Then
    '                bMarkUseError = True
    '                m_nSeqIndex = 40
    '            End If
    '        Case 1
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 0).bMark = True Then
    '                If bFirstRetry(1, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel2_Mark1) = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 0).nSubMark
    '                    bFirstRetry(1, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 1).bMark = True Then
    '                If bFirstRetry(1, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel2_Mark1) = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 1).nSubMark
    '                    bFirstRetry(1, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 2).bMark = True Then
    '                If bFirstRetry(1, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel2_Mark1) = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 2).nSubMark
    '                    bFirstRetry(1, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark1, 2).bMark = False Then
    '                bDistanceError = True
    '                m_nSeqIndex = 40
    '            End If
    '        Case 2
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 0).bMark = True Then
    '                If bFirstRetry(2, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel1_Mark2) = pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 0).nSubMark
    '                    bFirstRetry(2, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 1).bMark = True Then
    '                If bFirstRetry(2, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel1_Mark2) = pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 1).nSubMark
    '                    bFirstRetry(2, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 2).bMark = True Then
    '                If bFirstRetry(2, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel1_Mark2) = pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 2).nSubMark
    '                    bFirstRetry(2, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p1, AlignMarkNumber.Mark2, 2).bMark = False Then
    '                bMarkUseError = True
    '                m_nSeqIndex = 40
    '            End If
    '        Case 3
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 0).bMark = True Then
    '                If bFirstRetry(3, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel2_Mark2) = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 0).nSubMark
    '                    bFirstRetry(3, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 1).bMark = True Then
    '                If bFirstRetry(3, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel2_Mark2) = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 1).nSubMark
    '                    bFirstRetry(3, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 2).bMark = True Then
    '                If bFirstRetry(3, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel2_Mark2) = pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 2).nSubMark
    '                    bFirstRetry(3, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p2, AlignMarkNumber.Mark2, 2).bMark = False Then
    '                bMarkUseError = True
    '                m_nSeqIndex = 40
    '            End If
    '        Case 4
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 0).bMark = True Then
    '                If bFirstRetry(4, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel3_Mark1) = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 0).nSubMark
    '                    bFirstRetry(4, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 1).bMark = True Then
    '                If bFirstRetry(4, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel3_Mark1) = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 1).nSubMark
    '                    bFirstRetry(4, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 2).bMark = True Then
    '                If bFirstRetry(4, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel3_Mark1) = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 2).nSubMark
    '                    bFirstRetry(4, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark1, 2).bMark = False Then
    '                bMarkUseError = True
    '                m_nSeqIndex = 40
    '            End If
    '        Case 5
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 0).bMark = True Then
    '                If bFirstRetry(5, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel4_Mark1) = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 0).nSubMark
    '                    bFirstRetry(5, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 1).bMark = True Then
    '                If bFirstRetry(5, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel4_Mark1) = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 1).nSubMark
    '                    bFirstRetry(5, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 2).bMark = True Then
    '                If bFirstRetry(5, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel4_Mark1) = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 2).nSubMark
    '                    bFirstRetry(5, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark1, 2).bMark = False Then
    '                bMarkUseError = True
    '                m_nSeqIndex = 40
    '            End If
    '        Case 6
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 0).bMark = True Then
    '                If bFirstRetry(6, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel3_Mark2) = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 0).nSubMark
    '                    bFirstRetry(6, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 1).bMark = True Then
    '                If bFirstRetry(6, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel3_Mark2) = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 1).nSubMark
    '                    bFirstRetry(6, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 2).bMark = True Then
    '                If bFirstRetry(6, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel3_Mark2) = pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 2).nSubMark
    '                    bFirstRetry(6, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p3, AlignMarkNumber.Mark2, 2).bMark = False Then
    '                bMarkUseError = True
    '                m_nSeqIndex = 40
    '            End If
    '        Case 7
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 0).bMark = True Then
    '                If bFirstRetry(7, 0) = False Then
    '                    nAlignSubMark(AlignMark.Panel4_Mark2) = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 0).nSubMark
    '                    bFirstRetry(7, 0) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 1).bMark = True Then
    '                If bFirstRetry(7, 1) = False Then
    '                    nAlignSubMark(AlignMark.Panel4_Mark2) = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 1).nSubMark
    '                    bFirstRetry(7, 1) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 2).bMark = True Then
    '                If bFirstRetry(7, 2) = False Then
    '                    nAlignSubMark(AlignMark.Panel4_Mark2) = pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 2).nSubMark
    '                    bFirstRetry(7, 2) = True
    '                    Return
    '                End If
    '            End If
    '            If pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 0).bMark = False And pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 1).bMark = False And pRcpMark_Data(m_nLine, Panel.p4, AlignMarkNumber.Mark2, 2).bMark = False Then
    '                bMarkUseError = True
    '                m_nSeqIndex = 40
    '            End If

    '    End Select
    'End Sub
End Class
