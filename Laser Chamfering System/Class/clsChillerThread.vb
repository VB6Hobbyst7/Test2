
Imports System.Threading
Imports System.Text
Imports Microsoft.VisualBasic
Public Class clsChillerThread


    Dim tmpMsg As String = ""
    Dim tmpSplit() As String = {}

    Public UseChiller As Boolean

    '20160727 JCM Edit Scanner1 파워 메터 레이저 온 확인 비트
    Public pnChillerSleepCnt(3) As Integer
    Public pnChillerIndex As Integer

    Public nChillerCheckIndex As Integer = 0
    Public nChillerCheck As Integer = 0
    Public bChillerCheckChange As Boolean = False
    Public m_IsStopping As Boolean
    Public ChillerComm As New Comm

    Dim ErrorMsg As String = ""
    'Dim STX As String = &H02
    'Dim ETX As String = &H13
    Dim STX As String = 0 & Hex(2)
    Dim ETX As String = Hex(19)
    Dim CMD As String = Hex(48) & Hex(49)
    Dim LEN As String = Hex(49)
    Dim btRtn() As Byte
    Public m_Status As ChillerData
    Dim m_TimeCheck As New clsTimer

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


#Region "Thread"
    Private ThreadChiller As Thread
    Private bThreadRunningChiller As Boolean
    Private nKillThread As Integer
    Private qChillerrCmd As New Queue
    Dim bRead As Boolean

    ReadOnly Property ThreadRunningChiller() As Boolean
        Get
            Return bThreadRunningChiller
        End Get
    End Property

    Function StartChiller() As Boolean
        On Error GoTo SysErr

        ThreadChiller = New Thread(AddressOf ChillerStatusThreadSub)
        nKillThread = 0
        ThreadChiller.SetApartmentState(ApartmentState.MTA)
        ThreadChiller.Priority = ThreadPriority.Lowest
        ThreadChiller.Start()
        m_IsStopping = False
        StartChiller = True

        UseChiller = False

        Exit Function
SysErr:
        StartChiller = False
        'ErrorMsg = ErrorMsg & "Start Power Meter Thread Error" & ","
    End Function

    Function EndChiller() As Boolean
        On Error GoTo SysErr

        UseChiller = False

        Interlocked.Exchange(nKillThread, 1)
        If bThreadRunningChiller = True Then
            ThreadChiller.Join(1000)
        End If

        ThreadChiller = Nothing
        Return True
        Exit Function
SysErr:
        EndChiller = False
        ' ErrorMsg = ErrorMsg & "End Power Meter Thread Error" & ","
    End Function

    Dim m_nSeqindex As Integer = 0

    Sub ChillerStatusThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String

        While nKillThread = 0
            'Do
            Select Case m_nSeqindex
                Case 0
                    If pChiller(0).ChillerComm.IsOpen = True Then
                        pChiller(0).threadFunc()
                    End If
                    m_nSeqindex = 1

                Case 1
                    If pChiller(1).ChillerComm.IsOpen = True Then
                        pChiller(1).threadFunc()
                    End If
                    m_nSeqindex = 2
                Case 2
                    If pChiller(2).ChillerComm.IsOpen = True Then
                        pChiller(2).threadFunc()
                    End If
                    m_nSeqindex = 3
                Case 3
                    If pChiller(3).ChillerComm.IsOpen = True Then
                        pChiller(3).threadFunc()
                    End If
                    m_nSeqindex = 0
            End Select

            System.Threading.Thread.Sleep(500)
            'Loop
        End While

        bThreadRunningChiller = False

        Exit Sub
SysErr:
        bThreadRunningChiller = False
        'ErrorMsg = ErrorMsg & "Power Meter Status Thread Error" & ","
    End Sub

    Sub Close()

        If Not (ThreadChiller Is Nothing) Then
            ThreadChiller.Join(10000)
        End If

        Call Finalize()

    End Sub
#End Region


    Private m_nStartTick As Integer
    Private m_bStarted As Boolean = False

    Private Function IsWaitTime(ByVal nIntervalMil As Integer) As Boolean       '이걸로 1분 기다리기 할까?
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

    Public Sub ResetChiller()

        For i As Integer = 0 To 3
            pnChillerSleepCnt(i) = 0
            'pnChillerIndex(i) = 0
        Next



    End Sub
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
            End Select
        End If
    End Sub
End Class


