Module modSequence

    Structure SequenceTimeTac
        Dim dStart_Time As Double

        Dim dTotal_Time As Double
        Dim dTmpTotal_Time As Double
        Dim bTotal_Time As Boolean

        Dim dAlignTime As Double
        Dim dTmpAlignTime As Double
        Dim bAlignTime As Boolean

        Dim dTrimmingTime As Double
        Dim dTmpTrimmingTime As Double
        Dim bTrimmingTime As Boolean

        'GYN - 2017.03.22 Add
        Dim dPLC_StageLoadingPosComplete As Double
        Dim dPLC_GlassCheck As Double

        Dim dPLC_StageVisionPos1 As Double
        Dim bPLC_StageVisionPos1 As Boolean

        Dim dPC_VisionAlign1 As Double

        'Dim dPC_VisionAlign1Mark1 As Double
        'Dim dPC_VisionAlign2Mark1 As Double
        Dim dPLC_StageVisionPos2 As Double
        Dim bPLC_StageVisionPos2 As Boolean

        Dim dPC_VisionAlign2 As Double
        'Dim dPC_VisionAlign1Mark2 As Double
        'Dim dPC_VisionAlign2Mark2 As Double
        Dim dPLC_StageVisionPos3 As Double
        Dim bPLC_StageVisionPos3 As Boolean

        Dim dPC_VisionAlign3 As Double
        'Dim dPC_VisionAlign3Mark1 As Double
        'Dim dPC_VisionAlign4Mark1 As Double
        Dim dPLC_StageVisionPos4 As Double
        Dim bPLC_StageVisionPos4 As Boolean

        Dim dPC_VisionAlign4 As Double
        'Dim dPC_VisionAlign3Mark2 As Double
        'Dim dPC_VisionAlign4Mark2 As Double

        Dim dPLC_StageCuttingPosComplete As Double
        'Dim dPLC_CuttingRequest1 As Double
        'Dim dPLC_CuttingRequest2 As Double
        'Dim dPLC_CuttingRequest3 As Double
        'Dim dPLC_CuttingRequest4 As Double
        Dim dPC_CuttingComplete As Double
        Dim dPLC_StageUnLoadingPosComplete As Double

        Dim dPLC_StageLoadingPosCompleteTemp As Double
        Dim dPLC_GlassCheckTemp As Double
        Dim dPLC_StageVisionPos1Temp As Double
        Dim dPC_VisionAlign1Temp As Double
        Dim dPC_VisionAlign1Mark1Temp As Double
        Dim dPC_VisionAlign2Mark1Temp As Double
        Dim dPLC_StageVisionPos2Temp As Double
        Dim dPC_VisionAlign2Temp As Double
        Dim dPC_VisionAlign1Mark2Temp As Double
        Dim dPC_VisionAlign2Mark2Temp As Double
        Dim dPLC_StageVisionPos3Temp As Double
        Dim dPC_VisionAlign3Temp As Double
        Dim dPC_VisionAlign3Mark1Temp As Double
        Dim dPC_VisionAlign4Mark1Temp As Double
        Dim dPLC_StageVisionPos4Temp As Double
        Dim dPC_VisionAlign4Temp As Double
        Dim dPC_VisionAlign3Mark2Temp As Double
        Dim dPC_VisionAlign4Mark2Temp As Double
        Dim dPLC_StageCuttingPosCompleteTemp As Double
        Dim dPLC_CuttingRequest1Temp As Double
        Dim dPLC_CuttingRequest2Temp As Double
        Dim dPLC_CuttingRequest3Temp As Double
        Dim dPLC_CuttingRequest4Temp As Double
        Dim dPC_CuttingCompleteTemp As Double
        Dim dPLC_StageUnLoadingPosCompleteTemp As Double

    End Structure

    Public Enum MODE
        Manual
        Auto
    End Enum

    Public Seq(1) As clsSequence_New
    Public nMode(1) As Integer
    Public pTimeTac(0 To 1) As SequenceTimeTac

    Public OperationSeq As clsOperationSequence
    Public AlarmSeq As clsAlarmMonitoringSequence

    Public bAlarmSeq As Boolean = False



    Public Sub Initialize()

        For i = 0 To 1
            Seq(i) = New clsSequence_New(MDI_MAIN)
            Seq(i).Initialize(i)
        Next

        OperationSeq = New clsOperationSequence()
        OperationSeq.StartOperation()

        '1013여기 알람시퀀스 시작
        AlarmSeq = New clsAlarmMonitoringSequence()
        AlarmSeq.StartAlarmSequence()

    End Sub

    Public Function GetTactTime(ByRef CurTime As Double, ByRef dTempTime As Double, ByVal ExTime As Double) As Boolean
        On Error GoTo SysErr
        dTempTime = Math.Abs((My.Computer.Clock.TickCount / (10 ^ 3)))
        CurTime = Math.Abs(Math.Round((dTempTime - ExTime), 3))
        Return True
        Exit Function
SysErr:
        Return False
    End Function

End Module

