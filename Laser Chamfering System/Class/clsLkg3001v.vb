Imports System.Threading
Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsDisplace
    Public Comm1 As New Comm
    Dim ErrorMsg As String = ""
    Dim ETX As String = vbCr 'vbCrLf  // kswoo 이구간 확인 필요함.. C++ 에서는 CR 구문인데 vbCrLf 요거는 CR + LF 라 엔터라는데 검증시 확인 필요
    Dim tmp As String = ""
    Private qCmd As New Queue
    Public m_IsStopping As Boolean

    Public m_isRcvComplete As Boolean = False

    Public rtnStr As String

    Public btRtn() As Byte
    Dim strRtn As String

    Public nReadSeq As Integer 'Thread Data 읽어오는 순서 변수.

    Private m_Thread As Threading.Thread

    Public Enum SetCmd
        SET_MODE_COM = 0
        SET_MODE_SETTING
        SET_ZERO_POINT
        SET_ZERO_RELEASE
        SET_CMD_MAX
    End Enum

    Public Enum GetCmd
        GET_VALUE = 0
    End Enum

    Dim SetCmdMsg() As String = {"Q0", "R0", "V0", "W0"}
    Dim GetCmdMsg() As String = {"M0"}

#Region "Connect"

    Function Connect(ByVal PortNum As Integer) As Boolean
        On Error GoTo SysErr
        If Comm1.IsOpen = True Then
            Comm1.Close()
        End If
        Comm1.Open(PortNum, 9600, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 1024)
        ErrorMsg = ""
        Return True
        Exit Function
SysErr:

        ErrorMsg = ErrorMsg & "Connect Error" & "," & Err.Description
        Return False
    End Function

    Function DisConnect() As Boolean
        On Error GoTo SysErr
        If Comm1.IsOpen = True Then
            Comm1.Close()
        End If

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Disconnect Error" & ","
        Return False
    End Function

    Function ClosePort() As Boolean
        On Error GoTo SysErr

        If Comm1.IsOpen = True Then
            Comm1.Close()
        End If
        ClosePort = True

        Exit Function
SysErr:
        ClosePort = False
        ' pErrMsg = Err.Description
    End Function

    ReadOnly Property IsOpen() As Boolean
        Get
            Return Comm1.IsOpen
        End Get
    End Property

#End Region

#Region "Command"
    Function SendCmd(ByVal cmd As SetCmd) As Boolean
        On Error GoTo SysErr
        Dim SendMsg As String = ""
        Dim nOn As Integer = -9999

        SendMsg = SetCmdMsg(cmd) & ETX

        'modPub.TestLog(m_strLine & CInt(4).ToString & "_OffsetY : " & dInspOffsetY(3).ToString)
        'modPub.TestLog("Set Msg" & (cmd).ToString & "-" & SendMsg)

        m_isRcvComplete = False
        Comm1.Write(SendMsg)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send Set Error" & ","
        Return False
    End Function

    Function SendCmd(ByVal cmd As GetCmd) As Boolean
        On Error GoTo SysErr
        Dim SendMsg As String = ""
        Dim nOn As Integer = -9999

        SendMsg = GetCmdMsg(cmd) & ETX

        'modPub.TestLog(m_strLine & CInt(4).ToString & "_OffsetY : " & dInspOffsetY(3).ToString)
        modPub.TestLog("Get Msg" & (cmd).ToString & "-" & SendMsg)

        m_isRcvComplete = False
        Comm1.Write(SendMsg)

        tmp$ = ""

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send Get Error" & ","
        Return False
    End Function

#End Region
#Region "Thread"
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

        btRtn = RcvByte()

        If btRtn.Length > 0 Then
            ParseReceived()
        End If

        System.Threading.Thread.Sleep(100)
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
                While (Comm1.ReadEx(0) <> -1)
                    rtnBt = Comm1.InputStream

                    RcvByte = rtnBt

                    Exit Function

                End While
            Catch
                System.Threading.Thread.Sleep(200)

            End Try
        Next i
        RcvByte = Nothing
    End Function

    Public Sub ParseReceived()
        Dim oEncoder As Encoding = Encoding.ASCII

        If btRtn.Length < 2 Then
            Return
        Else
            rtnStr = oEncoder.GetString(btRtn)
            m_isRcvComplete = True
        End If

    End Sub


    Private Function RcvString(Optional ByVal nTimeoutSec As Integer = 2) As String
        Dim rtnString As String
        'Dim rtnEtx As String
        Dim nRtn As Integer
        Dim nTimeoutCnt As Integer
        Dim nCount As Integer = 0

        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10

        For i As Integer = 0 To nTimeoutCnt
            Try
                While (Comm1.Read(1) <> -1)
                    rtnString = rtnString & Chr(Comm1.InputStream(0))

                    nRtn = rtnString.IndexOf("!!")

                    If rtnString.IndexOf(ETX) = False Then
                        Return rtnString
                    End If

                End While
            Catch
                System.Threading.Thread.Sleep(10)
            End Try

        Next i

        Return "TimeOutError"

    End Function

End Class