Imports System.Threading
Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsChiller
    Public m_iIndex As Integer = 0

    Public ChillerComm As New Comm
    Dim ErrorMsg As String = ""
    'Dim STX As String = &H02
    'Dim ETX As String = &H13
    Dim STX As String = 0 & Hex(2)
    Dim ETX As String = Hex(19)
    Dim CMD As String = Hex(48) & Hex(49)
    Dim LEN As String = Hex(49)

    Private qCmd As New Queue

    ' Dim m_nCh As Integer
    Public m_IsStopping As Boolean

    Dim btRtn() As Byte
    Dim strRtn As String

    Public nReadSeq As Integer 'Thread Data 읽어오는 순서 변수.
    Public bAlarm As Boolean = False
    Private m_Thread As Threading.Thread

    Structure ChillerData
        Public bRunning As Boolean
        'Dim nTargetTemp As Integer
        'Dim nLowWarnTemp As Integer
        'Dim nLowErrorTemp As Integer
        'Dim nHighWarnTemp As Integer
        'Dim nHighErrorTemp As Integer
        'Dim nCurTemp As Integer
        'Dim nErrCode As Integer
        Public strTargetTemp As String
        Public strLowWarnTemp As String
        Public strLowErrorTemp As String
        Public strHighWarnTemp As String
        Public strHighErrorTemp As String
        Public strCurTemp As String
        Public strErrCode As String
    End Structure


    Enum Status
        'RUN_STOP_STATUS = 1
        'TARGET_TEMP = 2
        'LOW_WARNING_TEMP = 3
        'LOW_ERROR_TEMP = 4
        'HIGH_WARNING_TEMP = 5
        'HIGH_ERROR_TEMP = 6
        'CURRENT_TEMP = 7
        'ERROR_CODE = 8
        
        RUN_STOP_STATUS = 49
        TARGET_TEMP = 50
        LOW_WARNING_TEMP = 51
        LOW_ERROR_TEMP = 52
        HIGH_WARNING_TEMP = 53
        HIGH_ERROR_TEMP = 54
        CURRENT_TEMP = 55
        ERROR_CODE = 56

    End Enum
    Public m_Status As ChillerData

    Public Sub Init(ByVal nPort As Integer)
        ReDim btRtn(128)
        If Connect(nPort) Then
            'GYN - 이건 아직 안도니깐 막아놓자.
            'StartThread()
        End If
    End Sub


#Region "Connect"
    Function Connect(ByVal PortNum As Integer) As Boolean
        On Error GoTo SysErr

        'For i As Integer = 0 To ChillerControllerComm.Length - 1
        '    If ChillerControllerComm(i).IsOpen = True Then
        '        ChillerControllerComm(i).Close()
        '    End If
        '    ChillerControllerComm(i).Open(PortNum, 19200, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 1024)
        '    ErrorMsg = ""
        'Next i

        If ChillerComm.IsOpen Then
            ChillerComm.Close()
        End If
        ChillerComm.Open(PortNum, 19200, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 1024)

        ErrorMsg = ""

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Connect Error" & "," & Err.Description
        Return False
    End Function

    Function DisConnect() As Boolean
        On Error GoTo SysErr

        'For i As Integer = 0 To ChillerControllerComm.Length - 1
        '    If ChillerControllerComm(i).IsOpen = True Then
        '        ChillerControllerComm(i).Close()
        '    End If

        'Next i
        If ChillerComm.IsOpen = True Then
            ChillerComm.Close()
        End If


        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Disconnect Error" & ","
        Return False
    End Function

    Sub Close()

        Call Finalize()

    End Sub

    Public Function StartThread() As Boolean
        On Error GoTo SysErr

        'm_Thread = New Thread(AddressOf threadFunc)
        'm_IsStopping = False
        'm_Thread.SetApartmentState(ApartmentState.MTA)
        'm_Thread.Priority = ThreadPriority.Lowest
        'm_Thread.Start()
        'StartThread = True

        'nReadSeq = 0

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


    Public Sub threadFunc()
        'Do
        If m_IsStopping Then
            Return
        End If
        Dim bRtn As Boolean = False

        If ChillerComm.IsOpen = True Then
            Select Case nReadSeq
                Case 0
                    bRtn = ReqStatus(Status.RUN_STOP_STATUS)
                    nReadSeq = 1
                Case 1
                    bRtn = ReqStatus(Status.CURRENT_TEMP)
                    nReadSeq = 2
                Case 2
                    bRtn = ReqStatus(Status.ERROR_CODE)
                    nReadSeq = 3
                Case 3
                    bRtn = ReqStatus(Status.TARGET_TEMP)
                    nReadSeq = 0
            End Select
        End If

        If bRtn = True Then

            'strRtn = RcvString()

            btRtn = RcvByte()

            If btRtn.Length > 0 Then
                ParseReceived()
            End If
        End If

        'System.Threading.Thread.Sleep(350)
        'Loop
    End Sub


#End Region

    Public Function RcvByte(Optional ByVal nTimeoutSec As Integer = 2) As Byte()
        Dim rtnString As String
        Dim rtnBt() As Byte
        Dim nTimeoutCnt As Integer

        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10
        For i As Integer = 0 To nTimeoutCnt
            Try
                While (ChillerComm.ReadEx(0) <> -1)

                    rtnBt = ChillerComm.InputStream
                    RcvByte = rtnBt
                    ' RcvString = rtnBt(0)
                    Exit Function
                    'Application.DoEvents()
                End While
            Catch
                System.Threading.Thread.Sleep(400)
                'Application.DoEvents()
            End Try
        Next i
        RcvByte = Nothing
    End Function

    Public Sub ParseReceived()
        If btRtn.Length < 2 Then
            Return
        End If
        If btRtn(0) = STX And btRtn(1) = &H32 Then
            Dim strStatus As String = btRtn(2)
            Dim str As String = ""
            Dim oEncoder As Encoding = Encoding.ASCII
            Dim TempByte() As Byte

            ReDim TempByte(btRtn.Length - 1)
            Select Case strStatus
                Case Status.RUN_STOP_STATUS
                    If btRtn(4) = 49 Then
                        m_Status.bRunning = True
                    Else
                        m_Status.bRunning = False
                    End If

                Case Status.TARGET_TEMP
                    TempByte = {btRtn(4), btRtn(5), btRtn(6), btRtn(7), btRtn(8)}
                    str = oEncoder.GetString(TempByte)
                    m_Status.strTargetTemp = str

                Case Status.LOW_WARNING_TEMP
                    TempByte = {btRtn(4), btRtn(5), btRtn(6), btRtn(7), btRtn(8)}
                    str = oEncoder.GetString(TempByte)
                    m_Status.strLowWarnTemp = str

                Case Status.LOW_ERROR_TEMP
                    TempByte = {btRtn(4), btRtn(5), btRtn(6), btRtn(7), btRtn(8)}
                    str = oEncoder.GetString(TempByte)
                    m_Status.strLowErrorTemp = str

                Case Status.HIGH_WARNING_TEMP
                    TempByte = {btRtn(4), btRtn(5), btRtn(6), btRtn(7), btRtn(8)}
                    str = oEncoder.GetString(TempByte)
                    m_Status.strHighWarnTemp = str

                Case Status.HIGH_ERROR_TEMP
                    TempByte = {btRtn(4), btRtn(5), btRtn(6), btRtn(7), btRtn(8)}
                    str = oEncoder.GetString(TempByte)
                    m_Status.strHighErrorTemp = str

                Case Status.CURRENT_TEMP
                    TempByte = {btRtn(5), btRtn(6), btRtn(7), btRtn(8)}
                    str = oEncoder.GetString(TempByte)
                    m_Status.strCurTemp = str

                Case Status.ERROR_CODE
                    TempByte = {btRtn(4), btRtn(5), btRtn(6), btRtn(7), btRtn(8), btRtn(9), btRtn(10)}
                    str = oEncoder.GetString(TempByte)
                    m_Status.strErrCode = str

                    If m_Status.strErrCode <> "0000000" Then
                        bAlarm = True
                    End If
            End Select
        End If
    End Sub


    Private Function RcvString(Optional ByVal nTimeoutSec As Integer = 2) As String
        Dim rtnString As String = ""
        'Dim rtnEtx As String
        Dim nRtn As Integer
        Dim nTimeoutCnt As Integer
        Dim nCount As Integer = 0

        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10

        For i As Integer = 0 To nTimeoutCnt
            Try
                While (ChillerComm.Read(1) <> -1)
                    rtnString = rtnString & Chr(ChillerComm.InputStream(0))

                    nRtn = rtnString.IndexOf("!!")

                    If rtnString.IndexOf(ETX) = False Then
                        Return rtnString
                    End If

                    'If InStr(rtnString, "!!") <> 0 Then
                    '    nCount = nCount + 1
                    '    rtnString = Replace(rtnString, vbCrLf, "!!")
                    '    If nCount > 1 Then
                    '        rtnString = rtnString.Remove(rtnString.Length - 1)
                    '        Return rtnString
                    '        Exit Function
                    '    End If
                    'End If

                End While
            Catch
                System.Threading.Thread.Sleep(10)
            End Try

        Next i

        Return "TimeOutError"

    End Function


#Region "Command"

    Function ReqStatus(ByVal nData As Integer) As Boolean
        On Error GoTo SysErr
        Dim SendMsg As String = ""

        SendMsg = STX & CMD & LEN & Hex(nData.ToString) & ETX 'STX(L)+COMMAND(11:sys run/stop)+LEN(1)+DATA(1:ON,0:off)+ETX(\r\n)
        'SendMsg = STX & "011" & nData.ToString & ETX      'STX(L)+COMMAND(11:sys run/stop)+LEN(1)+DATA(1:ON,0:off)+ETX(\r\n)
        ChillerComm.WriteChiller(SendMsg)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send ReqStatus" & ","
        Return False
    End Function


    Function ChillerOnOff(ByVal nChannel As Integer, ByVal bOn As Boolean) As Boolean       'chiller on/off설정, nchannel:chiller선택, bOn:on/off여부
        On Error GoTo SysErr
        Dim SendMsg As String = ""
        Dim nOn As Integer = -9999

        If bOn = True Then
            nOn = 1
        Else
            nOn = 0
        End If

        SendMsg = STX & "111" & nOn.ToString & ETX      'STX(L)+COMMAND(11:sys run/stop)+LEN(1)+DATA(1:ON,0:off)+ETX(\r\n)
        ChillerComm.Write(SendMsg)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send On/Off Error" & ","
        Return False
    End Function



    Function SetChillerTemperature(ByVal nChannel As Integer, ByVal dValue As Double) As Boolean       'chiller목표온도 설정, nchannel:chiller선택, nValue:온도설정값
        On Error GoTo SysErr
        Dim SendMsg As String = ""
        Dim str As String

        If dValue >= 0 Then
            str = String.Format("+{0:00.0}", dValue)
        Else
            str = String.Format("{0:00.0}", dValue)
        End If

        SendMsg = STX & "125" & str & ETX     'STX(L)+COMMAND(12:set target)+LEN(5)+DATA(ex.+05.5,-25.0)+ETX(\r\n)
        ChillerComm.Write(SendMsg)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send Value Error" & ","
        Return False
    End Function


    Function SetHighTemperature(ByVal nChannel As Integer, ByVal dValue As Double, ByVal isErorrSet As Boolean) As Boolean     '고온설정, nchannel:chiller선택, nValue:온도설정값, isErorrSet:Waring/Erorr설정 구분
        On Error GoTo SysErr
        Dim SendMsg As String = ""
        Dim command As String = ""

        Dim str As String

        If dValue >= 0 Then
            str = String.Format("+{0:00.0}", dValue)
        Else
            str = String.Format("{0:00.0}", dValue)
        End If

        If isErorrSet = True Then
            command = "16"      '16:set high error temp
        Else
            command = "15"      '15:set high warning temp
        End If

        SendMsg = STX & command & "5" & str & ETX     'STX(L)+COMMAND+LEN(5)+DATA(ex.+05.5,-25.0)+ETX(\r\n)
        ChillerComm.Write(SendMsg)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send Value Error" & ","
        Return False
    End Function


    Function SetLowTemperature(ByVal nChannel As Integer, ByVal dValue As Double, ByVal isErorrSet As Boolean) As Boolean     '저온설정, nchannel:chiller선택, nValue:온도설정값, isErorrSet:Waring/Erorr설정 구분
        On Error GoTo SysErr
        Dim SendMsg As String = ""
        Dim command As String = ""

        Dim str As String

        If dValue >= 0 Then
            str = String.Format("+{0:00.0}", dValue)
        Else
            str = String.Format("{0:00.0}", dValue)
        End If

        If isErorrSet = True Then
            command = "14"      '14:set low error temp
        ElseIf isErorrSet = False Then
            command = "13"      '13:set low warning temp
        End If
        SendMsg = STX & command & "5" & dValue.ToString() & ETX     'STX(L)+COMMAND+LEN(5)+DATA(ex.+05.5,-25.0)+ETX(\r\n)
        ChillerComm.Write(SendMsg)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send Value Error" & ","
        Return False
    End Function



#End Region

End Class
