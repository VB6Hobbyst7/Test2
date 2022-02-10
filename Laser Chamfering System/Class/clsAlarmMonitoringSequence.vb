Imports System.Threading
Public Class clsAlarmMonitoringSequence
    Public nAlarmSeqIndex As Integer = 0

    Private ThreadAlarm As Thread
    Public bThreadRunningAlarm As Boolean
    Private nKillThreadAlarm As Integer 'Alarm Merge
    Dim bRead As Boolean

    Public bAlarm As Boolean
    Public nAlarm(40) As Integer

    Public nAlarmCurrent(20) As Integer 'Alarm Merge
    Public bDistanceError(1) As Boolean 'Alarm Merge
    Public pbMsgUp As Boolean = True 'Alarm Merge
    Private ErrorMsg As String = "" 'Alarm Merge

    'UserAlarmD154
    'Public bMarkPosition(1, 1) As Boolean
    'Public bChillerTemp(1) As Boolean
    'Public bLaserConnect(1) As Boolean
    'Public bPulseMode(1) As Boolean
    'Public bLaserShutterUse(1) As Boolean
    'Public bLaserPower(1) As Boolean

    Private _AlarmData As _tagAlarm

    Public bAutoStatus As Boolean
    Public bMarkPosError(3) As Boolean '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
    '20190808 Laser Power Limit
    Public bLaserPowerLimit(3) As Boolean

    Dim nChiller_ERROR_LEVEL_WARNING() As Integer
    Dim nChiller_ERROR_LEVEL_ERROR() As Integer
    Dim nChiller_ERROR_HIGH_WARNING_TEMP() As Integer 
    Dim nChiller_ERROR_HIGH_ERROR_TEMP() As Integer 
    Dim nChiller_ERROR_LOW_WARNING_TEMP() As Integer
    Dim nChiller_ERROR_LOW_ERROR_TEMP() As Integer
    Dim nChiller_ERROR_FLOW_ERROR() As Integer

    Dim CHILLER_WAIT_COUNT As Integer = 150 '약 10초

    ' Sbs_20190503 운전중 집진기가 10초 이상 Stop 상태가 지속되면 Heavy 알람 울리게 한다
    Public bDustStopStatus As Boolean = False

  

    ReadOnly Property ThreadRunningAlarm() As Boolean
        Get
            Return bThreadRunningAlarm
        End Get
    End Property

    Function StartAlarmSequence() As Boolean
        On Error GoTo SysErr
        ThreadAlarm = New Thread(AddressOf AlarmSequence)
        nKillThreadAlarm = 0 'Alarm Merge
        ThreadAlarm.SetApartmentState(ApartmentState.MTA)
        ThreadAlarm.Priority = ThreadPriority.Lowest
        ThreadAlarm.Start()
        StartAlarmSequence = True
        '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
        bMarkPosError(0) = False
        bMarkPosError(1) = False
        bMarkPosError(2) = False
        bMarkPosError(3) = False

        bAutoStatus = False

        ReDim nChiller_ERROR_LEVEL_WARNING(3)
        ReDim nChiller_ERROR_LEVEL_ERROR(3)
        ReDim nChiller_ERROR_HIGH_WARNING_TEMP(3)
        ReDim nChiller_ERROR_HIGH_ERROR_TEMP(3)
        ReDim nChiller_ERROR_LOW_WARNING_TEMP(3)
        ReDim nChiller_ERROR_LOW_ERROR_TEMP(3)
        ReDim nChiller_ERROR_FLOW_ERROR(3)



        For i As Integer = 0 To 3
            nChiller_ERROR_LEVEL_WARNING(i) = 0
            nChiller_ERROR_LEVEL_ERROR(i) = 0
            nChiller_ERROR_HIGH_WARNING_TEMP(i) = 0
            nChiller_ERROR_HIGH_ERROR_TEMP(i) = 0
            nChiller_ERROR_LOW_WARNING_TEMP(i) = 0
            nChiller_ERROR_LOW_ERROR_TEMP(i) = 0
            nChiller_ERROR_FLOW_ERROR(i) = 0
        Next

        CHILLER_WAIT_COUNT = 45

        Exit Function
SysErr:
        StartAlarmSequence = False
    End Function

    Function EndAlarmSeq() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThreadAlarm, 1) 'Alarm Merge
        If bThreadRunningAlarm = True Then
            ThreadAlarm.Join(1000)
        End If

        ThreadAlarm = Nothing
        Return True
        Exit Function
SysErr:
        EndAlarmSeq = False
        ' ErrorMsg = ErrorMsg & "End Power Meter Thread Error" & ","
    End Function

    Sub AlarmSequence()
        On Error GoTo SysErr
        While nKillThreadAlarm = 0 'Alarm Merge
            AlarmInit() '알람 배열 부분 초기화
            If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = True Or pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = True Then
                'diviceCheck()   '20171130 시퀀스 테스트
            End If
'카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
            'CheckMarkPosError()
            'LaserError() 'Alarm Merge
            ChillerError() 'Alarm Merge()
            'MarkDistance()
            'UserAlarmD818()
            'UserAlarmD154()
            Thread.Sleep(50)

        End While

        bThreadRunningAlarm = False
        Exit Sub
SysErr:
        bThreadRunningAlarm = False
        ErrorMsg = ErrorMsg & "AlarmSeq Thread Error" & ","
    End Sub

    '카메라 영상 문제 : 이전 판넬 찍은 사진이 그대로 남아 현재 판넬 위치를 잘 못 가르키는 문제에 대한 방어 코드
    Sub CheckMarkPosError()
        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = True Then
            If bMarkPosError(0) = True Then
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CAMERA_OFF)
                pbMsgUp = False

                bMarkPosError(0) = False
            End If

            If bMarkPosError(1) = True Then
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CAMERA_OFF + 1)
                pbMsgUp = False
                bMarkPosError(1) = False
            End If
        End If

        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = True Then
            If bMarkPosError(2) = True Then
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CAMERA_OFF + 2)
                pbMsgUp = False

                bMarkPosError(2) = False
            End If

            If bMarkPosError(3) = True Then
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CAMERA_OFF + 3)
                pbMsgUp = False

                bMarkPosError(3) = False
            End If
        End If
    End Sub

 'Alarm Merge
    Public Sub SetAlarmCurrent(ByVal nAlarmCode As Integer)

        'nAlarmCurrent = nAlarm

        For i As Integer = 0 To 20

            If nAlarmCurrent(i) = 0 Then

                nAlarmCurrent(i) = nAlarmCode
                Exit For
            End If

        Next

    End Sub

    Sub Close()
        If Not (ThreadAlarm Is Nothing) Then
            ThreadAlarm.Join(10000)
        End If

        Call Finalize()

    End Sub

    Public Sub AlarmCodeCheck(ByVal nAlarmCode As Integer)

        modAlarmTable.GetAlarm(nAlarmCode, _AlarmData)

        For j As Integer = 0 To 20
            If (nAlarm(j) = nAlarmCode) Then '이 알람이 있을때 이 메소드를 타지 않는다.
                Exit Sub
            End If

            If (nAlarm(j) = 0) Then
                nAlarm(j) = nAlarmCode '1~4번 레이저 알람
                Exit Sub
            End If

        Next

    End Sub

 'Alarm Merge
    Public Sub diviceCheck()

        If bAlarmSeq = False Then

            For i = 0 To 3
                '20181119 Laser Pass Mode
                If pLDLT.PLC_Infomation.bLaserPassMode(i) = True Then 'Laser Pass Mode

                    If pLaser(i).pLaserStatus.bConnect = False Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_LASER_1 + i)
                        pbMsgUp = False
                    End If

                    '코일런트 레이저 모드 확인
                    If pLaser(i).pLaserStatus.strPulsemode <> "2" Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LASER_MODE)
                        pbMsgUp = False
                    End If

                    '코일런트 레이저 on/off 확인
                    If pLaser(i).pLaserStatus.strState <> "1" Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LASER_OFF)
                        pbMsgUp = False
                    End If

                    '코일런트 레이저 Shutter 확인
                    If pLaser(i).pLaserStatus.strShutterState <> "1" Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LASER_1_SHUTTER_CLOSE + i)
                        pbMsgUp = False
                    End If

                    If pScanner(i).pStatus.bInit = False Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_SCANNER_1 + i)
                        pbMsgUp = False
                    End If

                    If pChiller(i).ChillerComm.IsOpen = False Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CHILLER_1 + i)
                        pbMsgUp = False
                    End If

                    If bLaserPowerLimit(i) = True Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LASER_POWER_SETTING_LIMIT + i)
                        pbMsgUp = False
                    End If

                    If pLaser(i).pLaserStatus.bTimeOutError = True Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LASER_COMM_ERROR + i)
                        pbMsgUp = False
                    End If

                End If

                If pPowerMeter(i).PowerMeterStatus.bConnect = False Then
                    bAlarm = True
                    AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_POWERMETER_1 + i)
                    pbMsgUp = False
                End If


                'If pCamera(i).m_bConnected = False Then
                    'bAlarm = True
                    'AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_1 + i)
                    'pbMsgUp = False
                'End If
            Next

#If SIMUL <> 1 Then

            pMilInterface.CheckIP()

            '카메라 사용여부 체크후, 알람 체크
            '20200317 카메라 사용모드
            For i As Integer = 0 To 3
                If pCurSystemParam.btnCameraUseMode(i) = 1 Then
                    If pMilInterface.CheckCam(i) = False Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_1 + i)
                        pbMsgUp = False
                    End If
                End If
            Next
            'If pCurSystemParam.btnCameraAUse = 1 Then
            '    ' If pCamera(0).m_bConnected = False Then
            '    If pMilInterface.CheckCam(0) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_1)
            '        pbMsgUp = False
            '    End If
            '    'If pCamera(1).m_bConnected = False Then
            '    If pMilInterface.CheckCam(1) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_2)
            '        pbMsgUp = False
            '    End If
            'ElseIf pCurSystemParam.btnCameraAUse = 0 And pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = True Then
            '    'If pCamera(0).m_bConnected = False Then
            '    If pMilInterface.CheckCam(0) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_1)
            '        pbMsgUp = False
            '    End If
            '    'If pCamera(1).m_bConnected = False Then
            '    If pMilInterface.CheckCam(1) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_2)
            '        pbMsgUp = False
            '    End If

            'End If
            'If pCurSystemParam.btnCameraBUse = 1 Then
            '    'If pCamera(2).m_bConnected = False Then
            '    If pMilInterface.CheckCam(2) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_3)
            '        pbMsgUp = False
            '    End If
            '    'If pCamera(3).m_bConnected = False Then
            '    If pMilInterface.CheckCam(3) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_4)
            '        pbMsgUp = False
            '    End If
            'ElseIf pCurSystemParam.btnCameraBUse = 0 And pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = True Then
            '    'If pCamera(2).m_bConnected = False Then
            '    If pMilInterface.CheckCam(2) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_3)
            '        pbMsgUp = False
            '    End If
            '    'If pCamera(3).m_bConnected = False Then
            '    If pMilInterface.CheckCam(3) = False Then
            '        bAlarm = True
            '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_CAMERA_4)
            '        pbMsgUp = False
            '    End If
            'End If
#End If

            If pPowerMeter(4).PowerMeterStatus.bConnect = False Then '파워메터 스테이지
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_POWERMETER_STAGE)
                pbMsgUp = False
            End If

            If pDustCollector(0).IsOpen = False Then
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_DUSTCOLLECTOR)
                pbMsgUp = False
            End If

            ' Sbs_20190503 운전중 집진기가 10초 이상 Stop 상태가 지속되면 Heavy 알람 울리게 한다
            If pDustCollector(0).IsOpen = True Then
                If CInt(pDustCollector(0).Status.RunFlag) = clsDustCollector.RUNFLAG.STOPON Then
                    bDustStopStatus = True
                Else
                    bDustStopStatus = False
                    m_nStartTick(3) = 0
                    m_bStarted(3) = False
                End If

                If bDustStopStatus = True Then
                    If IsSleepTime(10000, 3) = True Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DUSTCOLLECTOR_STOP)
                        pbMsgUp = False
                    End If
                End If
            End If

            'If pDustCollector(1).IsOpen = False Then
            '    bAlarm = True
            '    For j As Integer = 0 To 20
            '        If (nAlarm(j) = modAlarmTable.iAlarmCode.ERROR_CONNECT_DUSTCOLLECTOR_INVERTOR) Then
            '            Exit For
            '        End If
            '        If (nAlarm(j) = 0) Then
            '            nAlarm(j) = modAlarmTable.iAlarmCode.ERROR_CONNECT_DUSTCOLLECTOR_INVERTOR '집진기 인버터 알람
            '            Exit For
            '        End If
            '    Next
            '    pbMsgUp = False
            'End If

            If pLight.IsOpen = False Then
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_LIGHT)
                pbMsgUp = False
            End If

            If pLDLT.pbConnect = False Then
                bAlarm = True
                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_MELSEC)
                pbMsgUp = False
            End If

            If bAlarmSeq = False Then
                bAlarmSeq = True
            End If
        End If
    End Sub
 'Alarm Merge
    'Public Sub alarmTest()
    '    For j As Integer = 0 To 20
    '        If nAlarmCurrent(j) > 0 Then
    '            For i As Integer = 0 To 20
    '                If (nAlarm(i) = nAlarmCurrent(j)) Then
    '                    Exit For
    '                End If

    '                If (nAlarm(i) = 0) Then
    '                    nAlarm(i) = nAlarmCurrent(j)
    '                    bAlarm = True
    '                    bAlarmSeq = True
    '                    nAlarmCurrent(j) = 0
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Next
    '    pbMsgUp = False
    'End Sub
    'Alarm Merge
    Enum LaserErrCode
        ERROR_HEAD_INT_FAULT = 1
        ERROR_EXT_INT_FAULT = 2
        ERROR_INT0_INT_FAULT = 4
        ERROR_BUS_COMMUNICATION_FAULT = 5
        ERROR_STATE_MACHINE_TIMEOUT_FAULT = 6
        ERROR_SYS_CONF_NOT_PARSED_FAULT = 7
        ERROR_SYS_CONF_NOT_VERIFIED_FAULT = 8
        ERROR_SYS_SEQUENCE_NOT_PARSED_FAULT = 9
        ERROR_SHG_TEMP_FAULT = 10
        ERROR_THG_TEMP_FAULT = 11
        ERROR_DIODE1_TEMP_FAULT = 13
        ERROR_DIODE2_TEMP_FAULT = 14
        ERROR_DIODE3_TEMP_FAULT = 15
        ERROR_BASEPLATE1_TEMP_FAULT = 16
        ERROR_BASEPLATE2_TEMP_FAULT = 17
        ERROR_SPE_INT_FAULT = 18
        '20190807 GUI 1.9 New Alarm
        ERROR_DIODE1_FIBERBROKEN_FAULT = 20
        ERROR_DIODE2_FIBERBROKEN_FAULT = 21
        ERROR_DIODE3_FIBERBROKEN_FAULT = 22

        ERROR_DIODE1_INITIALIZATION_FAULT = 42
        ERROR_DIODE2_INITIALIZATION_FAULT = 43
        ERROR_DIODE3_INITIALIZATION_FAULT = 44
        ERROR_SHUTTER_INITIALZATION_FAULT = 45
        ERROR_SEEDER_OPENCOMPORT_FAULT = 46
        ERROR_SEEDER_INITIALIZATION_FAULT = 47
        ERROR_RECIRCULATOR_INITIALIZATION_FAULT = 48
        ERROR_WATER_FLOW_LOW_FAULT = 50
        ERROR_WATER_FLOW_HIGH_FAULT = 51
        ERROR_WATER_TEMPERATURE_LOW_FAULT = 52
        ERROR_WATER_TEMPERATURE_HIGH_FAULT = 53
        ERROR_WATER_FLOW_INITIALIZATION_FAULT = 58
        ERROR_THREAD_EXCEPTION_FAULT = 60
        '20190807 GUI 1.9 New Alarm
        ERROR_SYS_SEQUENCE_NOT_LOADED_FAULT = 61

        ERROR_SEQUENCE_EXCUTION_ERROR = 62
        '20190807 GUI 1.9 New Alarm
        ERROR_SYS_SEQUENCE_WRONG_INDEXING_FAULT = 63
        ERROR_SYS_SEQUENCE_WRONG_COMMAND = 64
        ERROR_SYS_SEQUENCE_FILE_MISSING = 65
        ERROR_SYS_SEQUENCE_NO_VALID_STEPS_DETECTED = 66

        ERROR_HEAD_HUMIDITY_1_VERY_HIGH_FAULT = 71
        ERROR_HEAD_HUMIDITY_2_VERY_HIGH_FAULT = 72
        ERROR_HEAD_HUMIDITY_3_VERY_HIGH_FAULT = 73
        ERROR_HUMIDITY1_INITIALIZATION_FAULT = 74
        ERROR_HUMIDITY2_INITIALIZATION_FAULT = 75
        ERROR_HUMIDITY3_INITIALIZATION_FAULT = 76
        ERROR_PD1_INITIALIZATION_FAULT = 77
        ERROR_PD2_INITIALIZATION_FAULT = 78
        ERROR_PD3_INITIALIZATION_FAULT = 79
        ERROR_PD4_INITIALIZATION_FAULT = 80
        ERROR_PD5_INITIALIZATION_FAULT = 81
        ERROR_PD6_INITIALIZATION_FAULT = 82
        ERROR_PD7_INITIALIZATION_FAULT = 83
        ERROR_PD8_INITIALIZATION_FAULT = 84
        ERROR_PD9_INITIALIZATION_FAULT = 85
        ERROR_PD10_INITIALIZATION_FAULT = 86
        ERROR_PD11_INITIALIZATION_FAULT = 87
        ERROR_PD12_INITIALIZATION_FAULT = 88
        ERROR_PD13_INITIALIZATION_FAULT = 89
        ERROR_PD14_INITIALIZATION_FAULT = 90
        ERROR_ATTENUATOR_INITIALIZATION_FAULT = 95
        ERROR_SHG_INITIALIZATION_FAULT = 96
        ERROR_THG_INITIALIZATION_FAULT = 97
        ERROR_SHG_SERVO_STUCK_FAULT = 105
        ERROR_SHG_LOW_DRIVE_FAULT = 106
        ERROR_SHG_MAX_TEMP_DIFF_FAULT = 107
        ERROR_THG_SERVO_STUCK_FAULT = 110
        ERROR_THG_LOW_DRIVE_FAULT = 111
        ERROR_THG_MAX_TEMP_DIFF_FAULT = 112
        ERROR_DIODEDRIVER_START_FAULT = 120
        ERROR_EMERGENCYSTOP_FAULT = 121
        ERROR_SHUTTER_HIGHTEMP_FAULT = 122
        ERROR_WATCHDOG_TIMEOUT_FAULT = 123
        '20190807 GUI 1.9 New Alarm
        ERROR_HEAD_DEWPOINT_1_VERY_HIGH_FAULT = 126
        ERROR_HEAD_DEWPOINT_2_VERY_HIGH_FAULT = 127
        ERROR_HEAD_DEWPOINT_3_VERY_HIGH_FAULT = 128

        ERROR_THREAD_STALLED_FAULT = 300
        ERROR_HEARTBEAT_FAULT = 301
        ERROR_FPGA_READ_FAULT = 302
        ERROR_FPGA_INSTALLED_FAULT = 303
        ERROR_POST_FAULT = 304
        ERROR_FPGA_WRITE_FAULT = 305
        ERROR_HEAD_HUMIDITY_0_WARNING = 504
        ERROR_HEAD_HUMIDITY_1_WARNING = 505
        ERROR_HEAD_HUMIDITY_2_WARNING = 506
        ERROR_HEAD_HUMIDITY_3_WARNING = 507
        ERROR_WATER_FLOW_LOW_WARNING = 510
        ERROR_WATER_FLOW_HIGH_WARNING = 511
        ERROR_WATER_TEMPERATURE_LOW_WARNING = 512
        ERROR_WATER_TEMPERATURE_HIGH_WARNING = 513
        '20190807 GUI 1.9 New Alarm
        ERROR_HEAD_DEWPOINT_1_WARNING = 516
        ERROR_HEAD_DEWPOINT_2_WARNING = 517
        ERROR_HEAD_DEWPOINT_3_WARNING = 518

        ERROR_SHG_LOW_DRIVE_WARNING = 523
        ERROR_THG_LOW_DRIVE_WARNING = 524
        ERROR_AMPCURRENT_OUTOFRANGE_WARNIN = 525
        ERROR_SEEDER_AUTHENTICATION_WARNING = 526
        ERROR_SEEDER_COMMUNICATION_WARNING = 527
        ERROR_ATTENUATOR_SETPOWER_WARNING1 = 528
        ERROR_ATTENUATOR_SETPOWER_WARNING2 = 529
        '20190718 레이저 warning 알람 추가 - heavy 알람으로 적용
        ERROR_PUMP_DIODE_D1_SERVICE_REQUIRED_WARNING = 532
        ERROR_PUMP_DIODE_D2_SERVICE_REQUIRED_WARNING = 533
        ERROR_PUMP_DIODE_D3_SERVICE_REQUIRED_WARNING = 534
        '20190807 GUI 1.9 New Alarm
        ERROR_DIODE1_EMLOS_WARNING = 537
        ERROR_DIODE2_EMLOS_WARNING = 538
        ERROR_DIODE3_EMLOS_WARNING = 539

        ERROR_MAINTENANCE_REQUIRED_WARNING = 540
        ERROR_BOOTLOADER_VERSION_WARNING = 800
        ERROR_IMAGE_VERSION_WARNING = 801
        ERROR_OS_VERSION_WARNING = 802
        ERROR_THREAD_STALLED_WARNING = 803
        ERROR_CPU_TEMPERATURE_WARNING = 804
        ERROR_RTC_BATTERY_WARNING = 805

    End Enum

 'Alarm Merge
    Public Sub LaserError()

        For i = 0 To 3
            If pLaser(i).pLaserStatus.bConnect = True Then
                If pLDLT.PLC_Infomation.bLaserPassMode(i) = True Then 'Laser Pass Mode 
                    '코일런트 레이저 모드 확인
                    If pLaser(i).pLaserStatus.strPulsemode <> "2" And pLaser(i).pLaserStatus.strPulsemode <> "" Then
                        bAlarm = True
                        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LASER_MODE)
                        pbMsgUp = False
                    End If
                    If pLaser(i).pLaserStatus.strAreAnyFaultsActive <> "SYSTEM OK" And pLaser(i).pLaserStatus.strAreAnyFaultsActive <> "" And pLaser(i).pLaserStatus.strAreAnyFaultsActive <> "TimeOutError" Then
                        If IsSleepTime(10000, 0) = True Then

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEAD_INT_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_INT_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_EXT_INT_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_EXT_INT_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_BUS_COMMUNICATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_BUS_COMMUNICATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_STATE_MACHINE_TIMEOUT_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_STATE_MACHINE_TIMEOUT_FAULT + i)
                                pbMsgUp = False
                            End If


                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_CONF_NOT_PARSED_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_CONF_NOT_PARSED_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_CONF_NOT_VERIFIED_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_CONF_NOT_VERIFIED_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_SEQUENCE_NOT_PARSED_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_SEQUENCE_NOT_PARSED_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SHG_TEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHG_TEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_THG_TEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THG_TEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE1_TEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE1_TEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE2_TEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE2_TEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE3_TEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE3_TEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_BASEPLATE1_TEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_BASEPLATE1_TEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_BASEPLATE2_TEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_BASEPLATE2_TEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SPE_INT_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SPE_INT_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE1_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE1_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE2_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE2_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE3_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE3_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SHUTTER_INITIALZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHUTTER_INITIALZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SEEDER_OPENCOMPORT_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SEEDER_OPENCOMPORT_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SEEDER_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SEEDER_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_RECIRCULATOR_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_RECIRCULATOR_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_WATER_FLOW_LOW_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_FLOW_LOW_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_WATER_FLOW_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_FLOW_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_WATER_TEMPERATURE_LOW_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_TEMPERATURE_LOW_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_WATER_TEMPERATURE_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_TEMPERATURE_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_WATER_FLOW_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_FLOW_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_THREAD_EXCEPTION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THREAD_EXCEPTION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SEQUENCE_EXCUTION_ERROR Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SEQUENCE_EXCUTION + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEAD_HUMIDITY_1_VERY_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_HUMIDITY_1_VERY_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEAD_HUMIDITY_2_VERY_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_HUMIDITY_2_VERY_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEAD_HUMIDITY_3_VERY_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_HUMIDITY_3_VERY_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HUMIDITY1_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HUMIDITY1_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HUMIDITY2_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HUMIDITY2_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HUMIDITY3_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HUMIDITY3_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD1_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD1_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD2_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD2_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD3_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD3_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD4_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD4_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD5_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD5_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD6_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD6_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD7_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD7_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD8_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD8_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD9_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD9_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD10_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD10_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD11_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD11_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD12_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD12_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD13_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD13_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_PD14_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_PD14_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_ATTENUATOR_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_ATTENUATOR_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SHG_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHG_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_THG_INITIALIZATION_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THG_INITIALIZATION_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SHG_SERVO_STUCK_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHG_SERVO_STUCK_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SHG_LOW_DRIVE_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHG_LOW_DRIVE_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SHG_MAX_TEMP_DIFF_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHG_MAX_TEMP_DIFF_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_THG_SERVO_STUCK_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THG_SERVO_STUCK_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_THG_LOW_DRIVE_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THG_LOW_DRIVE_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_THG_MAX_TEMP_DIFF_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THG_MAX_TEMP_DIFF_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODEDRIVER_START_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODEDRIVER_START_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_EMERGENCYSTOP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_EMERGENCYSTOP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SHUTTER_HIGHTEMP_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHUTTER_HIGHTEMP_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_WATCHDOG_TIMEOUT_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATCHDOG_TIMEOUT_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_THREAD_STALLED_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THREAD_STALLED_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEARTBEAT_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEARTBEAT_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_FPGA_READ_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_FPGA_READ_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_FPGA_INSTALLED_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_FPGA_INSTALLED_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_POST_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_POST_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_FPGA_WRITE_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_FPGA_WRITE_FAULT + i)
                                pbMsgUp = False
                            End If

                            '20190807 GUI 1.9 New Alarm
                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE1_FIBERBROKEN_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE1_FIBERBROKEN_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE2_FIBERBROKEN_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE2_FIBERBROKEN_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_DIODE3_FIBERBROKEN_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE3_FIBERBROKEN_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_SEQUENCE_NOT_LOADED_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_SEQUENCE_NOT_LOADED_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_SEQUENCE_WRONG_INDEXING_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_SEQUENCE_WRONG_INDEXING_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_SEQUENCE_WRONG_COMMAND Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_SEQUENCE_WRONG_COMMAND + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_SEQUENCE_FILE_MISSING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_SEQUENCE_FILE_MISSING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_SYS_SEQUENCE_NO_VALID_STEPS_DETECTED Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SYS_SEQUENCE_NO_VALID_STEPS_DETECTED + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEAD_DEWPOINT_1_VERY_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_DEWPOINT_1_VERY_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEAD_DEWPOINT_2_VERY_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_DEWPOINT_2_VERY_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strAreAnyFaultsActive = LaserErrCode.ERROR_HEAD_DEWPOINT_3_VERY_HIGH_FAULT Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_DEWPOINT_3_VERY_HIGH_FAULT + i)
                                pbMsgUp = False
                            End If

                        End If
                    End If
                    If pLaser(i).pLaserStatus.strWarningsActive <> "SYSTEM OK" And pLaser(i).pLaserStatus.strWarningsActive <> "" And pLaser(i).pLaserStatus.strWarningsActive <> "TimeOutError" Then
                        If IsSleepTime(10000, 1) = True Then

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_HEAD_HUMIDITY_0_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_HUMIDITY_0_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_HEAD_HUMIDITY_1_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_HUMIDITY_1_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_HEAD_HUMIDITY_2_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_HUMIDITY_2_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_HEAD_HUMIDITY_3_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_HUMIDITY_3_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_WATER_FLOW_LOW_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_FLOW_LOW_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_WATER_FLOW_HIGH_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_FLOW_HIGH_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_WATER_TEMPERATURE_HIGH_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_WATER_TEMPERATURE_HIGH_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_SHG_LOW_DRIVE_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SHG_LOW_DRIVE_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_THG_LOW_DRIVE_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THG_LOW_DRIVE_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_AMPCURRENT_OUTOFRANGE_WARNIN Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_AMPCURRENT_OUTOFRANGE_WARNIN + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_SEEDER_AUTHENTICATION_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SEEDER_AUTHENTICATION_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_SEEDER_COMMUNICATION_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_SEEDER_COMMUNICATION_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_ATTENUATOR_SETPOWER_WARNING1 Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_ATTENUATOR_SETPOWER_WARNING1 + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_ATTENUATOR_SETPOWER_WARNING2 Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_ATTENUATOR_SETPOWER_WARNING2 + i)
                                pbMsgUp = False
                            End If

                            '20190718 레이저 warning 알람 추가 - heavy 알람으로 적용
                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_PUMP_DIODE_D1_SERVICE_REQUIRED_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE_D1_SERVICE + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_PUMP_DIODE_D2_SERVICE_REQUIRED_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE_D2_SERVICE + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_PUMP_DIODE_D3_SERVICE_REQUIRED_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE_D3_SERVICE + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_MAINTENANCE_REQUIRED_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_MAINTENANCE_REQUIRED + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_BOOTLOADER_VERSION_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_BOOTLOADER_VERSION_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_IMAGE_VERSION_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_IMAGE_VERSION_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_OS_VERSION_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_OS_VERSION_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_THREAD_STALLED_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_THREAD_STALLED_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_CPU_TEMPERATURE_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CPU_TEMPERATURE_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_RTC_BATTERY_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_RTC_BATTERY_WARNING + i)
                                pbMsgUp = False
                            End If

                            '20190807 GUI 1.9 New Alarm
                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_HEAD_DEWPOINT_1_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_DEWPOINT_1_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_HEAD_DEWPOINT_2_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_DEWPOINT_2_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_HEAD_DEWPOINT_3_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HEAD_DEWPOINT_3_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_DIODE1_EMLOS_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE1_EMLOS_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_DIODE2_EMLOS_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE2_EMLOS_WARNING + i)
                                pbMsgUp = False
                            End If

                            If pLaser(i).pLaserStatus.strWarningsActive = LaserErrCode.ERROR_DIODE3_EMLOS_WARNING Then
                                bAlarm = True
                                AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_DIODE3_EMLOS_WARNING + i)
                                pbMsgUp = False
                            End If

                        End If
                    End If
                End If
            End If
        Next
 
        If bAlarmSeq = False Then
            bAlarmSeq = True
        End If
    End Sub


    'Alarm Merge
    Public Sub ChillerError()
        Dim ChillerErrCode_LEVEL_WARNING = "1000000"
        Dim ChillerErrCode_LEVEL_ERROR = "0100000"
        Dim ChillerErrCode_HIGH_WARNING_TEMP = "0010000"
        Dim ChillerErrCode_HIGH_ERROR_TEMP = "0001000"
        Dim ChillerErrCode_LOW_WARNING_TEMP = "0000100"
        Dim ChillerErrCode_LOW_ERROR_TEMP = "0000010"
        Dim ChillerErrCode_FLOW_ERROR = "0000001"

        'Next
        For i = 0 To 3
            '20181119 Laser Pass Mode 수정
            If pChiller(i).ChillerComm.IsOpen = True Then
                If pLDLT.PLC_Infomation.bLaserPassMode(i) = True Then 'Laser Pass Mode
                    'If pChiller(i).m_Status.strErrCode <> "0000000" And pChiller(i).m_Status.strErrCode <> "" Then
                    If pChiller(i).m_Status.strErrCode <> "0000000" Then
                        'If IsSleepTime(10000, 2) = True Then

                        If pChiller(i).m_Status.strErrCode = ChillerErrCode_LEVEL_WARNING Then
                            bAlarm = True
                            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LEVEL_WARNING + i)
                            pbMsgUp = False
                        End If

                        If pChiller(i).m_Status.strErrCode = ChillerErrCode_LEVEL_ERROR Then
                            bAlarm = True
                            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LEVEL_ERROR + i)
                            pbMsgUp = False
                        End If

                        If pChiller(i).m_Status.strErrCode = ChillerErrCode_HIGH_WARNING_TEMP Then
                            bAlarm = True
                            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HIGH_WARNING_TEMP + i)
                            AlramLog("칠러 온도 :" + pChiller(i).m_Status.strCurTemp) '20181224 - 칠러 온도 표시
                            pbMsgUp = False
                        End If

                        If pChiller(i).m_Status.strErrCode = ChillerErrCode_HIGH_ERROR_TEMP Then
                            bAlarm = True
                            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_HIGH_ERROR_TEMP + i)
                            AlramLog("칠러 온도 :" + pChiller(i).m_Status.strCurTemp) '20181224 - 칠러 온도 표시
                            pbMsgUp = False
                        End If

                        If pChiller(i).m_Status.strErrCode = ChillerErrCode_LOW_WARNING_TEMP Then
                            bAlarm = True
                            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LOW_WARNING_TEMP + i)
                            AlramLog("칠러 온도 :" + pChiller(i).m_Status.strCurTemp) '20181224 - 칠러 온도 표시
                            pbMsgUp = False
                        End If

                        If pChiller(i).m_Status.strErrCode = ChillerErrCode_LOW_ERROR_TEMP Then
                            bAlarm = True
                            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LOW_ERROR_TEMP + i)
                            AlramLog("칠러 온도 :" + pChiller(i).m_Status.strCurTemp) '20181224 - 칠러 온도 표시
                            pbMsgUp = False
                        End If

                        If pChiller(i).m_Status.strErrCode = ChillerErrCode_FLOW_ERROR Then
                            bAlarm = True
                            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_FLOW_ERROR + i)
                            pbMsgUp = False
                        End If
                        'End If
                    Else
                        m_bStarted(2) = False
                    End If
                End If
            End If

        Next

        If bAlarmSeq = False Then
            bAlarmSeq = True
        End If
    End Sub
 'Alarm Merge
    Public Sub MarkDistance()

        If bDistanceError(LINE.A) = True Then
            bAlarm = True
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MARK_DISTANCE_A, True)
            pLDLT.PC_Infomation.bMarkDistace(LINE.A) = True
            'bDistanceError(LINE.A) = False
            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_MARK_DIST_A)
            pbMsgUp = False
        End If

        If bDistanceError(LINE.B) = True Then
            bAlarm = True
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MARK_DISTANCE_B, True)
            pLDLT.PC_Infomation.bMarkDistace(LINE.B) = True
            'bDistanceError(LINE.B) = False
            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_MARK_DIST_B)
            pbMsgUp = False
        End If

        If bAlarmSeq = False Then
            bAlarmSeq = True
        End If
    End Sub

    Public Sub AlarmInit()
        ReDim iAlertCode(20)

        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = True Or pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = True Then
            bAutoStatus = True
        ElseIf pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = False And pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = False Then
            bAutoStatus = False
            'AlarmSeq.bDistanceError(0) = False
            'AlarmSeq.bDistanceError(1) = False
        End If

        If bAutoStatus = False Then
            For i As Integer = 0 To 20
                nAlarmCheck(i) = 0 'frmAlarm if 구문 배열 초기화
                nAlarm(i) = 0 '실제 알람코드 배열 초기화
                iAlertCode(i) = 0 'ShowAlarmMsg 배열 초기화
            Next
            bAlarm = False
            bAutoStatus = True

        ElseIf bAutoStatus = True Then
            For j As Integer = 0 To 20
                nAlarmCheck(j) = 0
                nAlarm(j) = 0
                iAlertCode(j) = 0
            Next
            bAlarm = False
            bAutoStatus = False
        End If

        'UserAlarmD154
        'For index As Integer = 0 To 1
        '    For Panel As Integer = 0 To 1
        '        bMarkPosition(index, Panel) = False
        '    Next
        '    bChillerTemp(index) = False
        '    bLaserConnect(index) = False
        '    bPulseMode(index) = False
        '    bLaserShutterUse(index) = False
        '    bLaserPower(index) = False
        'Next
        bAlarmSeq = False
    End Sub

    'inti
    Public Sub UserAlarmD818()
        'For i As Integer = 0 To 3
        '    If LaserInitAlarm(i) = True Then
        '        If pLaser(i).pLaserStatus.bConnect = False Then

        '            bAlarm = True
        '            AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_CONNECT_LASER_1 + i)
        '            pbMsgUp = False

        '        End If
        '    End If

        'Next
        'For i As Integer = 0 To 3
        '    If pLaser(i).pLaserStatus.bTimeOutError = True Then
        '        bAlarm = True
        '        AlarmCodeCheck(modAlarmTable.iAlarmCode.ERROR_LASER_COMM_ERROR + i)
        '        pbMsgUp = False
        '    End If
        'Next
        
       
    End Sub
    '칠러 카운트 변수 초기화
    Public Sub InitCountChiller()
        For i As Integer = 0 To 3
            nChiller_ERROR_LEVEL_WARNING(i) = 0
            nChiller_ERROR_LEVEL_ERROR(i) = 0
            nChiller_ERROR_HIGH_WARNING_TEMP(i) = 0
            nChiller_ERROR_HIGH_ERROR_TEMP(i) = 0
            nChiller_ERROR_LOW_WARNING_TEMP(i) = 0
            nChiller_ERROR_LOW_ERROR_TEMP(i) = 0
            nChiller_ERROR_FLOW_ERROR(i) = 0
        Next
    End Sub

    ' Sbs_20190503 운전중 집진기가 10초 이상 Stop 상태가 지속되면 Heavy 알람 울리게 한다(2->3)
    '0 : Laser Fault, 1 : Laser warning, 2 :chiller, 3 : DustCollector
    Private m_nStartTick(3) As Integer
    Private m_bStarted(3) As Boolean

    Private Function IsSleepTime(ByVal nIntervalMil As Integer, ByVal divice As Integer) As Boolean
        If m_bStarted(divice) = False Then
            m_bStarted(divice) = True
            m_nStartTick(divice) = My.Computer.Clock.TickCount
        Else
            If (My.Computer.Clock.TickCount - m_nStartTick(divice)) > nIntervalMil Then
                m_nStartTick(divice) = 0
                m_bStarted(divice) = False
                Return True
            End If
        End If

        Return False
    End Function
End Class
