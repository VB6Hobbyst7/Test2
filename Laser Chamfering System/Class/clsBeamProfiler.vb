Imports System.Threading
Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsBeamProfiler

    Dim BeamProfilerComm As New Comm
    Dim ErrorMsg As String = ""
    Dim STX As String = Asc(2)  '":"
    Dim ETX As String = Asc(3)   'vbCrLf
    Public m_nLightVal(8) As Integer

#Region "Connect"
    Function Connect(ByVal PortNum As Integer) As Boolean
        On Error GoTo SysErr
        If BeamProfilerComm.IsOpen = True Then
            BeamProfilerComm.Close()
        End If

        BeamProfilerComm.Open(PortNum, 9600, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 1024)

        ErrorMsg = ""
        Return True
        Exit Function
SysErr:

        ErrorMsg = ErrorMsg & "Connect Error" & "," & Err.Description
        Return False
    End Function

    Function DisConnect() As Boolean
        On Error GoTo SysErr
        If BeamProfilerComm.IsOpen = True Then
            BeamProfilerComm.Close()
        End If

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Disconnect Error" & ","
        Return False
    End Function


    ReadOnly Property IsOpen() As Boolean
        Get
            Return BeamProfilerComm.IsOpen
        End Get
    End Property

#End Region


#Region "Thread"
    Private ThreadBeamProfiler As Thread
    Private bThreadRunningBeamProfiler As Boolean
    Private nKillThread As Integer
    Private qBeamProfilerCmd As New Queue
    Dim bRead As Boolean

    ReadOnly Property ThreadRunningBeamProfiler() As Boolean
        Get
            Return bThreadRunningBeamProfiler
        End Get
    End Property

    Function StartBeamProfiler() As Boolean
        On Error GoTo SysErr

        ThreadBeamProfiler = New Thread(AddressOf BeamProfilerStatusThreadSub)
        nKillThread = 0
        ThreadBeamProfiler.SetApartmentState(ApartmentState.MTA)
        ThreadBeamProfiler.Priority = ThreadPriority.Lowest
        ThreadBeamProfiler.Start()

        StartBeamProfiler = True
        Return True
        Exit Function
SysErr:
        StartBeamProfiler = False
        ErrorMsg = ErrorMsg & "StartBeamProfiler Thread Error" & ","
    End Function

    Function EndBeamProfiler() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThread, 1)
        If bThreadRunningBeamProfiler = True Then
            ThreadBeamProfiler.Join(1000)
        End If

        ThreadBeamProfiler = Nothing
        Return True
        Exit Function
SysErr:
        EndBeamProfiler = False
        ErrorMsg = ErrorMsg & "EndBeamProfiler Thread Error" & ","
    End Function

    Private nSeqIndex As Integer = 0
    Sub BeamProfilerStatusThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String

        While nKillThread = 0

            bThreadRunningBeamProfiler = True

            Select Case nSeqIndex
                Case 0

                    nSeqIndex = 1
                Case 1


                    nSeqIndex = 2
                Case 2


                    nSeqIndex = 3
                Case 3


                    nSeqIndex = 4
                Case 4


                    nSeqIndex = 0
            End Select

            Thread.Sleep(50)

        End While

        bThreadRunningBeamProfiler = False
        Exit Sub
SysErr:
        bThreadRunningBeamProfiler = False
        ErrorMsg = ErrorMsg & "BeamProfiler Status Thread Error" & ","
    End Sub

    Sub Close()

        If Not (ThreadBeamProfiler Is Nothing) Then
            ThreadBeamProfiler.Join(10000)
        End If

        Call Finalize()

    End Sub
#End Region

    Function RcvString(ByVal ipCount As Integer, Optional ByVal nTimeoutSec As Integer = 2) As String
        Dim rtnString As String
        Dim nTimeoutCnt As Integer
        Dim nCount As Integer = 0

        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10
        nTimeoutCnt = 10

        For i As Integer = 0 To nTimeoutCnt
            Try
                While (BeamProfilerComm.Read(1) <> -1)
                    rtnString = rtnString & Chr(BeamProfilerComm.InputStream(0))
                    If InStr(rtnString, ETX) <> 0 Then
                        nCount = nCount + 1
                        'rtnString = Replace(rtnString, 0x03, ",")
                        rtnString = Replace(rtnString, ETX, STX)
                        If nCount > ipCount Then
                            rtnString = rtnString.Remove(rtnString.Length - 1)
                            Return rtnString
                            Exit Function
                        End If
                    End If
                    System.Threading.Thread.Sleep(50)
                End While
            Catch
                System.Threading.Thread.Sleep(100)
            End Try
        Next i

        Return "TimeOutError"

    End Function

End Class

