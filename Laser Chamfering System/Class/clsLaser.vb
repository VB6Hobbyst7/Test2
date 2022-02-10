Imports System.Threading


Public Class clsLaser
    WithEvents LaserComm As New Comm
    Public m_iIndex As Integer = 0
    Private m_strReceived As String

    Structure LaserData
        Dim bConnect As Boolean
        Dim bAbleToUse As Boolean
        Dim nPort As Integer
        Dim strBasePlate1Temp As String 'BT1
        Dim strBasePlate2Temp As String 'BT2
        Dim strBurst As String  'BURST
        Dim strDiodeD1ActualCurrent As String   'D1C
        Dim strDiodeD2ActualCurrent As String   'D2C
        Dim strDiodeD3ActualCurrent As String   'D3C
        Dim strDescriptionsOfActiveFaults As String 'DAF
        Dim strExternalModulation As String 'EM
        Dim strAreAnyFaultsActive As String 'F
        Dim strKeySwitchOn As String 'K
        Dim strLockOut As String 'LOCKOUT
        Dim strAttenuatorPower As String 'PATT
        Dim strPulsemode As String    'PM (triggerMode)
        Dim strOutputPower As String 'POUT
        Dim strRFPercentLevel As String 'RL
        Dim strMasterRepRate As String 'RRAMP
        Dim strMasterRepRateSet As String 'RRAMPSET
        Dim strShutterState As String 'String 'S
        Dim strSHGTemperature As String 'SHGT
        Dim strSHGTSetTemperature As String 'SHGTSET
        Dim strTHGTemperature As String 'THGT
        Dim strTHGTSetTemperature As String 'THGTSET
        Dim strWarningsActive As String 'W
        Dim strState As String '?STATE
        Dim strTransMission As String '?TATT
        Dim strLaser1TransMission As String '?TRANSM
        Dim strWaterFlow As String '?WF

        Dim bTimeOutError As Boolean

    End Structure

    Enum BaudRate
        n1200 = 1200
        n2400 = 2400
        n4800 = 4800
        n9600 = 9600
        n19200 = 19200
        n38400 = 38400
        n57600 = 57600
        n115200 = 115200
    End Enum

    Enum LaserState
        Laser_Boot = -1
        Laser_Ready = 0
        Laser_On = 1
        Laser_Fault = 2
    End Enum


    Enum PulseMode
        Continuous = 0
        Divided = 2
        DividedNGated = 3
    End Enum

    Enum tagLaserStatus
        ST_KeySwitchOn = 0 'K 
        ST_AreAnyFaultsActive = 1 'F
        ST_ShutterState = 2 'S
        ST_State = 3 'STATE
        ST_MasterRepRate = 4 'RRAMP
        ST_MasterRepRateSet = 5 'RRAMPSET
        ST_Pulsemode = 6 'PM (triggerMode)
        ST_RFPercentLevel = 7 'RL
        ST_OutputPower = 8 'POUT
        ST_AttenuatorPower = 9 'PATT
        ST_Transmission = 10 'TATT
        ST_SHGTemp = 11 'SHGT
        ST_THGTemp = 12 'THGT
        ST_Laser1_Transmission = 13


        ST_Burst  'BURST
        ST_DescriptionsOfActiveFaults 'DAF
        ST_ExternalModulation 'EM
        ST_WarningsActive = 14 'W 'Alarm Merge
        ST_WaterFlow = 15 'WF
        ST_LockOut 'LOCKOUT
    End Enum

    Enum FAULT
        Emission_Lamp_Fault = 1
        External_Interlock_Fault = 2
        PS_Cover_Interlock_Fault = 3
        Diode1_Temperature_Fault = 8
        Diode2_Temperature_Fault = 9
        Heatsink1_Temp_Fault = 11
        Heatsink2_Temp_Fault = 12
        Diode1_Over_Current_Fault = 16
        Diode2_Over_Current_Fault = 17
        Over_Current_Fault = 18
        Diode1_Under_Voltage_Fault = 19
        Diode2_Under_Voltage_Fault = 20
        Diode1_Over_Voltage_Fault = 21
        Diode2_Over_Voltage_Fault = 22
        Diode1_EEPROM_Fault = 25
        Diode2_EEPROM_Fault = 26
        Head_EEPROM_Fault = 27
        Power_Supply_EEPROM_Fault = 28
        PS_Head_Mismatch_Fault = 29
        Shutter_State_Mismatch_Fault = 31
        Head_Diode_Mismatch_Fault = 40
        Power_Supply_Type_Init_Fault = 45
        No_UART_Fault = 46
        No_Bootloader_Fault = 47
        Head_Communication_Fault = 48
        Harmonics_Communication_Fault = 52
        LBO_Fault = 53
        FPGA_Register_Fault = 54
        Head_EPROM_Fault = 55
        Software_Compatibility_Fault = 56
        FAB_Setting_Fault = 57
        Humidity_Fault = 58
        ThermaTrack_Stepper_Fault = 59
        Head_PSU_EPROM_Fault = 60
        High_Voltage_Fault = 61
        Seed_Laser_Fault = 62
        CAN_Fault = 63
    End Enum

    Public pLaserStatus As LaserData

    Private ErrorMsg As String = ""

    Private ThreadLaser As Thread
    Private bThreadRunningLaser As Boolean
    Private nKillThreadLaser As Integer
    Private nThreadIndex As tagLaserStatus
    Private CurCmdIndex As tagLaserStatus
    Private qLaserCmd As New Queue

    Private m_Thread As Threading.Thread
    Public m_IsStopping As Boolean

#Region "Laser Status Thread"

    Sub Close()

        If Not (ThreadLaser Is Nothing) Then
            ThreadLaser.Join(10000)
        End If

        Call Finalize()

    End Sub

    ReadOnly Property ThreadRunningLaser() As Boolean
        Get
            Return bThreadRunningLaser
        End Get
    End Property

    Function StartLaser() As Boolean
        On Error GoTo SysErr

        pLaserStatus.strPulsemode = ""
        pLaserStatus.strAttenuatorPower = ""
        pLaserStatus.strMasterRepRate = ""
        pLaserStatus.strOutputPower = ""
        pLaserStatus.strState = ""

        ThreadLaser = New Thread(AddressOf LaserStatusThreadSub)
        nKillThreadLaser = 0
        ThreadLaser.SetApartmentState(ApartmentState.MTA)
        ThreadLaser.Priority = ThreadPriority.Normal
        ThreadLaser.Start()
        'nThreadIndex = tagLaserStatus.ST_BasePlate1Temp
        nThreadIndex = tagLaserStatus.ST_KeySwitchOn
        StartLaser = True
        Exit Function
SysErr:
        StartLaser = False
        ErrorMsg = ErrorMsg & "Start Laser Status Thread Error" & ","
    End Function

    Function EndLaser() As Boolean
        On Error GoTo SysErr
        Interlocked.Exchange(nKillThreadLaser, 1)
        If bThreadRunningLaser = True Then
            ThreadLaser.Join(1000)
        End If
        ' DisConnect()

        ThreadLaser = Nothing
        Return True
        Exit Function
SysErr:
        EndLaser = False
        ErrorMsg = ErrorMsg & "End Laser Status Thread Error" & ","
    End Function


    Sub LaserStatusThreadSub()
        On Error GoTo SysErr

        Dim strCmd As String
        While nKillThreadLaser = 0
            bThreadRunningLaser = True

            If qLaserCmd.Count >= 1 Then
                For i = 0 To qLaserCmd.Count - 1
                    If bRead = False Then
                        strCmd = qLaserCmd.Dequeue
                        LaserComm.Write(strCmd & vbCrLf)
                        Thread.Sleep(100)
                    End If
                Next i
            Else
                LaserStatus()
            End If
            'LaserComm.AsyncRead(1024)
            'For i = 0 To 500
            '    Thread.Sleep(1)
            'Next

            Thread.Sleep(500)

        End While

        bThreadRunningLaser = False
        Exit Sub
SysErr:
        bThreadRunningLaser = False
        ErrorMsg = ErrorMsg & "Laser Status Thread Error" & ","
    End Sub

    Dim bRead As Boolean
    Dim bSendCmd As Boolean
    Dim tmpRtn As String
    Dim nLaserReceived As Integer = 0

    Sub LaserStatus()
        On Error GoTo SysErr

        If LaserComm.IsOpen = False Then
            Return
        End If

        'bRead = True

        Select Case nLaserReceived

            Case tagLaserStatus.ST_KeySwitchOn
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?K")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?K")
                        pLaserStatus.strKeySwitchOn = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_AreAnyFaultsActive
                    Else
                        pLaserStatus.strKeySwitchOn = m_strReceived 'RequestCmdLaser("?K")
                        nLaserReceived = tagLaserStatus.ST_AreAnyFaultsActive
                    End If
                End If
            Case tagLaserStatus.ST_AreAnyFaultsActive
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?F")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?F")
                        pLaserStatus.strAreAnyFaultsActive = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_ShutterState
                        If pLaserStatus.strAreAnyFaultsActive <> "SYSTEM OK" And pLaserStatus.strAreAnyFaultsActive <> "" Then
                            '20190719 알람 코드 확인
                            modPub.TestLog("Laser Fault Alarm Code : " & pLaserStatus.strAreAnyFaultsActive)
                        End If
                    Else
                        pLaserStatus.strAreAnyFaultsActive = m_strReceived  'RequestCmdLaser("?F")
                        nLaserReceived = tagLaserStatus.ST_ShutterState
                    End If
                End If
            Case tagLaserStatus.ST_ShutterState
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?S")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?S")
                        pLaserStatus.strShutterState = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_State
                    Else
                        pLaserStatus.strShutterState = m_strReceived ' RequestCmdLaser("?S")
                        nLaserReceived = tagLaserStatus.ST_State
                    End If
                End If
            Case tagLaserStatus.ST_State
                    If bRead = False Then
                    m_strReceived = RequestCmdLaser("?STATE")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?STATE")
                        pLaserStatus.strState = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_MasterRepRate
                    Else
                        pLaserStatus.strState = m_strReceived ' RequestCmdLaser("?STATE")
                        nLaserReceived = tagLaserStatus.ST_MasterRepRate
                    End If
                End If
            Case tagLaserStatus.ST_MasterRepRate
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?RR")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?RR")
                        pLaserStatus.strMasterRepRate = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_MasterRepRateSet
                    Else
                        pLaserStatus.strMasterRepRate = m_strReceived   'RequestCmdLaser("?RRAMP")
                        nLaserReceived = tagLaserStatus.ST_MasterRepRateSet
                    End If
                End If
            Case tagLaserStatus.ST_MasterRepRateSet
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?RRAMPSET")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?RRAMPSET")
                        pLaserStatus.strMasterRepRateSet = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_Pulsemode
                    Else
                        pLaserStatus.strMasterRepRateSet = m_strReceived    'RequestCmdLaser("?RRAMPSET")
                        nLaserReceived = tagLaserStatus.ST_Pulsemode
                    End If
                End If
            Case tagLaserStatus.ST_Pulsemode
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?PM")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?PM")
                        pLaserStatus.strPulsemode = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_RFPercentLevel
                    Else
                        pLaserStatus.strPulsemode = m_strReceived   'RequestCmdLaser("?PM")
                        nLaserReceived = tagLaserStatus.ST_RFPercentLevel
                    End If
                End If
            Case tagLaserStatus.ST_RFPercentLevel
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?RL")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?RL")
                        pLaserStatus.strRFPercentLevel = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_OutputPower
                    Else
                        pLaserStatus.strRFPercentLevel = m_strReceived  'RequestCmdLaser("?RL")
                        nLaserReceived = tagLaserStatus.ST_OutputPower
                    End If
                End If
            Case tagLaserStatus.ST_OutputPower
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?POUT")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?POUT")
                        pLaserStatus.strOutputPower = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_AttenuatorPower
                    Else
                        pLaserStatus.strOutputPower = m_strReceived 'RequestCmdLaser("?POUT")
                        nLaserReceived = tagLaserStatus.ST_AttenuatorPower
                    End If
                End If
            Case tagLaserStatus.ST_AttenuatorPower
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?PATT")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?PATT")
                        pLaserStatus.strAttenuatorPower = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_Transmission
                    Else
                        pLaserStatus.strAttenuatorPower = m_strReceived 'RequestCmdLaser("?PATT")
                        nLaserReceived = tagLaserStatus.ST_Transmission
                    End If
                End If
            Case tagLaserStatus.ST_Transmission
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?TATT")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?TATT")
                        pLaserStatus.strTransMission = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_SHGTemp
                    Else
                        pLaserStatus.strTransMission = m_strReceived    'RequestCmdLaser("?TATT")
                        nLaserReceived = tagLaserStatus.ST_SHGTemp
                    End If
                End If
            Case tagLaserStatus.ST_SHGTemp
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?SHGT")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?SHGT")
                        pLaserStatus.strSHGTemperature = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_THGTemp
                    Else
                        pLaserStatus.strSHGTemperature = m_strReceived  'RequestCmdLaser("?SHGT")
                        nLaserReceived = tagLaserStatus.ST_THGTemp
                    End If
                End If
            Case tagLaserStatus.ST_THGTemp
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?THGT")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?THGT")
                        pLaserStatus.strTHGTemperature = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_Laser1_Transmission
                    Else
                        pLaserStatus.strTHGTemperature = m_strReceived  'RequestCmdLaser("?THGT")
                        nLaserReceived = tagLaserStatus.ST_Laser1_Transmission
                    End If
                End If

 'Alarm Merge
            Case tagLaserStatus.ST_Laser1_Transmission
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?TRANSM")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?TRANSM")
                        pLaserStatus.strLaser1TransMission = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_WarningsActive
                    Else
                        pLaserStatus.strLaser1TransMission = m_strReceived    'RequestCmdLaser("?TATT")
                        'pLaserStatus.strTransMission = m_strReceived    'RequestCmdLaser("?TATT")
                        nLaserReceived = tagLaserStatus.ST_WarningsActive
                    End If
                End If

 'Alarm Merge
            Case tagLaserStatus.ST_WarningsActive
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?W")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?W")
                        pLaserStatus.strWarningsActive = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_WaterFlow
                        If pLaserStatus.strWarningsActive <> "SYSTEM OK" And pLaserStatus.strWarningsActive <> "" Then
                            '20190719 알람 코드 확인
                            modPub.TestLog("Laser Warning Alarm Code : " & pLaserStatus.strWarningsActive)
                        End If
                    Else
                        pLaserStatus.strWarningsActive = m_strReceived    'RequestCmdLaser("?TATT")
                        nLaserReceived = tagLaserStatus.ST_WaterFlow
                    End If
                End If

            Case tagLaserStatus.ST_WaterFlow
                If bRead = False Then
                    m_strReceived = RequestCmdLaser("?WF")
                    If InStr(m_strReceived, "?") <> 0 Then
                        tmpRtn = ParseReceived("?WF")
                        pLaserStatus.strWaterFlow = tmpRtn
                        nLaserReceived = tagLaserStatus.ST_KeySwitchOn
                    Else
                        pLaserStatus.strWaterFlow = m_strReceived    'RequestCmdLaser("?TATT")
                        nLaserReceived = tagLaserStatus.ST_KeySwitchOn
                    End If
                End If


        End Select
        Thread.Sleep(30)


        Exit Sub
SysErr:
        bRead = False
    End Sub
    Private Function ParseReceived(ByVal ipCmd As String) As String
        On Error GoTo SysErr
        Dim strLine() As String
        Dim strReturn As String = ""

        strLine = Split(m_strReceived, ipCmd)
        strReturn = strLine(1).Trim

        Return strReturn

   
        Exit Function
SysErr:
        ' Dim strErr As String = strLast(0).Trim

    End Function


    'Private Sub ParseReceived()
    '    On Error GoTo SysErr
    '    Dim strLine() As String
    '    strLine = m_strReceived.Split(",")
    '    Dim nCnt As Integer = 0


    'Dim strLast() As String
    ''     For i = 0 To strLine.Length - 1
    'Do While nCnt <> strLine.Length - 1

    '    strLast = strLine(nCnt).Split("=")

    'Select Case strLast(0).Trim
    '    Case "BT1"
    '        pLaserStatus.strBasePlate1Temp = strLast(1).Trim
    '    Case "BT2"
    '        pLaserStatus.strBasePlate2Temp = strLast(1).Trim
    '    Case "BURST"
    '        pLaserStatus.strBurst = strLast(1).Trim
    '    Case "D1C"
    '        pLaserStatus.strDiodeD1ActualCurrent = strLast(1).Trim
    '    Case "D2C"
    '        pLaserStatus.strDiodeD2ActualCurrent = strLast(1).Trim
    '    Case "D3C"
    '        pLaserStatus.strDiodeD3ActualCurrent = strLast(1).Trim
    '    Case "DAF"
    '        pLaserStatus.strDescriptionsOfActiveFaults = strLast(1).Trim
    '    Case "EM"
    '        pLaserStatus.strExternalModulation = strLast(1).Trim
    '    Case "F"
    '        pLaserStatus.strAreAnyFaultsActive = strLast(1).Trim
    '    Case "K"
    '        pLaserStatus.strKeySwitchOn = strLast(1).Trim
    '    Case "LOCKOUT"
    '        pLaserStatus.strLockOut = strLast(1).Trim
    '    Case "PATT"
    '        pLaserStatus.strAttenuatorPower = strLast(1).Trim
    '    Case "PM"
    '        pLaserStatus.strPulsemode = strLast(1).Trim
    '    Case "POT"
    '        pLaserStatus.strOutputPower = strLast(1).Trim
    '    Case "RL"
    '        pLaserStatus.strRFPercentLevel = strLast(1).Trim
    '    Case "RRAMP"
    '        pLaserStatus.strMasterRepRate = strLast(1).Trim
    '    Case "RRAMPSET"
    '        pLaserStatus.strMasterRepRateSet = strLast(1).Trim
    '    Case "S"
    '        pLaserStatus.strShutterState = strLast(1).Trim
    '    Case "SHGT"
    '        pLaserStatus.strSHGTemperature = strLast(1).Trim
    '    Case "SHGTSET"
    '        pLaserStatus.strSHGTSetTemperature = strLast(1).Trim
    '    Case "THGT"
    '        pLaserStatus.strTHGTemperature = strLast(1).Trim
    '    Case "THGTSET"
    '        pLaserStatus.strTHGTSetTemperature = strLast(1).Trim
    '    Case "W"
    '        pLaserStatus.strWarningsActive = strLast(1).Trim
    '    Case "STATE"
    '        pLaserStatus.strState = strLast(1).Trim
    'End Select
    '    nCnt = nCnt + 1
    'Loop
    ''Next

    '        Exit Sub
    'SysErr:
    '    'Dim strErr As String = strLast(0).Trim

    '    End Sub


#End Region

#Region "Connect"
    Function Connect(ByVal PortNum As Integer, ByVal BaudRate As BaudRate) As Boolean
        On Error GoTo SysErr

        Dim bStartLaser As Boolean = False

        EndLaser()
        If LaserComm.IsOpen = True Then
            LaserComm.Close()
        End If

        'LaserComm.WorkingMode = Comm.Mode.Overlapped
        LaserComm.Open(PortNum, BaudRate, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 2048)
        If LaserComm.IsOpen Then
            bStartLaser = StartLaser()
        End If

        'SetEchoMode(False)
        'SetLaserOn(True)
        'SetKeyOn(True)
        pLaserStatus.bConnect = True

        If LaserComm.IsOpen And bStartLaser = True Then
            InitHeartBeat(0)
        End If

        Return True
        Exit Function
SysErr:
        pLaserStatus.bConnect = False
        ErrorMsg = ErrorMsg & "Laser Connect Error" & ","
        Return False
    End Function

    Function DisConnect() As Boolean
        On Error GoTo SysErr
        If LaserComm.IsOpen = True Then
            EndLaser()
            LaserComm.Close()
        End If
        pLaserStatus.bConnect = False
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Laser Disconnect Error" & ","
        Return False
    End Function
#End Region

#Region "Set Command"

    ' communication ack and clear fault
    Function FACK(ByVal nVal As Integer) As Boolean
        On Error GoTo SysErr

        SendCmdLaser("FACK=" & nVal.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "FACK Error" & ","
        Return False
    End Function


    Function SetLaserOn(ByVal bLaserOn As Boolean) As Boolean
        On Error GoTo SysErr
        Dim strCmd As String = ""
        If bLaserOn = True Then
            strCmd = "START"
        ElseIf bLaserOn = False Then
            strCmd = "STOP"
        End If
        SendCmdLaser(strCmd)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Laser On Error" & ","
        Return False
    End Function

    'Function SetPulseMode(ByVal nMode As PulseMode) As Boolean  'Pulsemode
    Function SetPulseMode(ByVal nMode As Integer) As Boolean  'Pulsemode
        On Error GoTo SysErr

        SendCmdLaser("PM=" & nMode.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Pulse Mode Error" & ","
        Return False
    End Function


    Function SetExternalModulation(ByVal nMode As Integer) As Boolean  'ExternalModulation
        On Error GoTo SysErr

        SendCmdLaser("EM=" & nMode.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set External Modulation Error" & ","
        Return False
    End Function



    Function SetShutterOpen(ByVal bOpen As Boolean) As Boolean
        On Error GoTo SysErr
        Dim nMode As Integer = 0

        If bOpen = True Then
            nMode = 1
        ElseIf bOpen = False Then
            nMode = 0
        End If

        SendCmdLaser("S=" & nMode.ToString)

        Return True

        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Sutter Open Error" & ","
        Return False
    End Function


    Function SetBurstPulseValue(ByVal nValue As Integer) As Boolean
        On Error GoTo SysErr
        SendCmdLaser("BURST=" & nValue.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Burst Pulse Value Error" & ","
        Return False
    End Function


    Function SetAttenuationPower(ByVal nValue As Double) As Boolean
        On Error GoTo SysErr
        Dim tmpAtt As Integer = 0
        tmpAtt = nValue
        SendCmdLaser("PATT=" & tmpAtt.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Attenuation POwer Error" & ","
        Return False
    End Function

    Function SetTransMission(ByVal nValue As Double) As Boolean
        On Error GoTo SysErr
        Dim tmptAtt As Integer = 0
        tmptAtt = nValue
        SendCmdLaser("TATT=" & tmptAtt.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Attenuation POwer Error" & ","
        Return False
    End Function

    Function Laser1_SetTransMission(ByVal nValue As Double) As Boolean
        On Error GoTo SysErr
        Dim tmptAtt As Integer = 0
        tmptAtt = nValue
        SendCmdLaser("TRANSM=" & tmptAtt.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Attenuation POwer Error" & ","
        Return False
    End Function

    Function SetRFPercentLevel(ByVal nValue As Double) As Boolean
        On Error GoTo SysErr
        SendCmdLaser("RL=" & nValue.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set RF Percent Level Value Error" & ","
        Return False
    End Function

    Function SetMasterRepRate(ByVal nValue As Integer) As Boolean
        On Error GoTo SysErr
        SendCmdLaser("RRAMPSET=" & nValue.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set Master RepRate Value Error" & ","
        Return False
    End Function

    Function SetSHGTSetTemperature(ByVal nValue As Integer) As Boolean
        On Error GoTo SysErr
        SendCmdLaser("SHGTSET=" & nValue.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set SHGT Set Temperature Value Error" & ","
        Return False
    End Function

    Function SetTHGTSetTemperature(ByVal nValue As Integer) As Boolean
        On Error GoTo SysErr
        SendCmdLaser("THGTSET=" & nValue.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set THGT Set Temperature Value Error" & ","
        Return False
    End Function

    Function SetRepRateMaster(ByVal nValue As Integer) As Boolean
        On Error GoTo SysErr
        SendCmdLaser("RRAMPSET=" & nValue.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Set THGT Set Temperature Value Error" & ","
        Return False
    End Function

    Function InitHeartBeat(ByVal nValue As Integer) As Boolean
        On Error GoTo SysErr
        SendCmdLaser("HB=" & nValue.ToString)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Heart Beat Initialize Error" & ","
        Return False
    End Function

#End Region

    Sub SendCmdLaser(ByVal strMsg As String)
        On Error GoTo SysErr
        qLaserCmd.Enqueue(strMsg)
        Exit Sub
SysErr:

    End Sub

    '    Function RequestCmdLaser(ByVal strMsg As String) As String
    '        On Error GoTo SysErr
    '        Dim strRtn As String = ""

    '        LaserComm.Write(strMsg & vbCrLf)
    '        strRtn = RcvString(76, 10)
    '        Return strRtn
    '        Exit Function
    'SysErr:
    '        Return Err.Description
    '    End Function

    Function RequestCmdLaser(ByVal strMsg As String) As String
        On Error GoTo SysErr
        Dim strRtn As String = ""
        bRead = True
        LaserComm.Write(strMsg & vbCrLf)

        strRtn = RcvString(0)
        If strRtn = "TimeOutError" Then
            pLaserStatus.bTimeOutError = True
        Else
            pLaserStatus.bTimeOutError = False
        End If
        bRead = False
        Return strRtn
        Exit Function
SysErr:
        bRead = False
        Return Err.Description
    End Function




    Function RcvString(ByVal ipCount As Integer, Optional ByVal nTimeoutSec As Integer = 1) As String
        Dim rtnString As String
        Dim nTimeoutCnt As Integer
        Dim nCount As Integer = 0

        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10

        For i As Integer = 0 To nTimeoutCnt
            Try
                While (LaserComm.Read(1) <> -1)
                    rtnString = rtnString & Chr(LaserComm.InputStream(0))
                    'Return rtnString
                    If InStr(rtnString, vbCrLf) <> 0 Then
                        nCount = nCount + 1
                        rtnString = Replace(rtnString, vbCrLf, ",")
                        If nCount > ipCount Then
                            rtnString = rtnString.Remove(rtnString.Length - 1)
                            Return rtnString
                            Exit Function
                        End If
                    End If
                End While
            Catch
                System.Threading.Thread.Sleep(500)
            End Try
        Next i
        Return "TimeOutError"
    End Function

    Public Function StartThread() As Boolean
        On Error GoTo SysErr

        m_Thread = New Thread(AddressOf threadFunc)
        m_IsStopping = False
        m_Thread.SetApartmentState(ApartmentState.MTA)
        m_Thread.Priority = ThreadPriority.Lowest
        m_Thread.Start()
        StartThread = True

        Exit Function
SysErr:
        StartThread = False
    End Function

    Public Function EndThread() As Boolean
        On Error GoTo SysErr

        If m_IsStopping = True Then
            m_Thread.Join()
        End If

        DisConnect()

        m_Thread = Nothing

        EndThread = True

        Exit Function
SysErr:
        EndThread = False
    End Function

    Public m_iLaserIndex As Integer
    Public m_bLaserInit As Boolean

    Public Sub threadFunc()
        Do
            If m_IsStopping Then
                Return
            End If

            If LaserComm.IsOpen Then

                Select Case m_iLaserIndex
                    Case 0
                        m_bLaserInit = False
                        If (pLaserStatus.strState = "0") Then
                            SetLaserOn(True)
                            m_iLaserIndex = 1
                        Else
                            m_iLaserIndex = 1
                        End If
                    Case 1
                        If (pLaserStatus.strState = "1") Then
                            SetPulseMode(2)
                            System.Threading.Thread.Sleep(100)
                            SetTransMission(100)
                            System.Threading.Thread.Sleep(100)
                            Select Case m_iIndex
                                Case 0
                                    SetRFPercentLevel(74)
                                Case 1
                                    SetRFPercentLevel(58.5)
                                Case 2
                                    SetRFPercentLevel(69)
                                Case 3
                                    SetRFPercentLevel(59.3)
                            End Select
                            System.Threading.Thread.Sleep(100)
                            m_iLaserIndex = 2
                        End If
                    Case 2
                        Select Case m_iIndex
                            Case 0
                                If pLaserStatus.strRFPercentLevel = "74" Then
                                    m_iLaserIndex = 3
                                End If
                            Case 1
                                If pLaserStatus.strRFPercentLevel = "58.5" Then
                                    m_iLaserIndex = 3
                                End If
                            Case 2
                                If pLaserStatus.strRFPercentLevel = "69" Then
                                    m_iLaserIndex = 3
                                End If
                            Case 3
                                If pLaserStatus.strRFPercentLevel = "59.3" Then
                                    m_iLaserIndex = 3
                                End If
                        End Select
                    Case 3
                        Dim nTrans As Double = 0

                        nTrans = CDbl(pLaserStatus.strTransMission)

                        'If pLaserStatus.strTransMission = "100" Then
                        If nTrans < 101 And nTrans > 99 Then
                            m_iLaserIndex = 4
                        End If
                    Case 4
                        If pLaserStatus.strPulsemode = "2" Then
                            m_bLaserInit = True
                            EndThread()
                        End If
                End Select
            End If
            System.Threading.Thread.Sleep(100)
        Loop
    End Sub

End Class