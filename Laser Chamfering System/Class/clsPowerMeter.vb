Imports System.Threading
Public Class clsPowerMeter
    Dim PowerMeterComm As New Comm
    Dim tmpMsg As String = ""
    Dim tmpSplit() As String = {}
    Public m_iIndex As Integer = 0

    Structure Status
        Dim nPort As Integer
        Dim bConnect As Boolean
        Dim ID As String
        Dim HandShaking As String
        Dim MeasureMode As String
        Dim SystemStatus As String
        Dim WaveLength As String
        Dim MinimumRange As String
        Dim MaximumRange As String
        Dim Power As String
    End Structure

    Enum WaveLength
        nm_355 = 355
        nm_532 = 532
        nm_1064 = 1064
    End Enum

    Public PowerMeterStatus As Status
    Public UsePowerMeter As Boolean

#Region "Thread"
    Private ThreadPowerMeter As Thread
    Private bThreadRunningPowerMeter As Boolean
    Private nKillThread As Integer
    Private qPowerMeterCmd As New Queue
    Dim bRead As Boolean

    ReadOnly Property ThreadRunningLaser() As Boolean
        Get
            Return bThreadRunningPowerMeter
        End Get
    End Property

    Function StartPowerMeter() As Boolean
        On Error GoTo SysErr

        'ThreadPowerMeter = New Thread(AddressOf PowerMeterStatusThreadSub)
        'nKillThread = 0
        'ThreadPowerMeter.SetApartmentState(ApartmentState.MTA)
        'ThreadPowerMeter.Priority = ThreadPriority.Lowest
        'ThreadPowerMeter.Start()
        StartPowerMeter = True

        UsePowerMeter = False

        Exit Function
SysErr:
        StartPowerMeter = False
        'ErrorMsg = ErrorMsg & "Start Power Meter Thread Error" & ","
    End Function

    Function EndPowerMeter() As Boolean
        On Error GoTo SysErr

        UsePowerMeter = False

        'Interlocked.Exchange(nKillThread, 1)
        'If bThreadRunningPowerMeter = True Then
        '    ThreadPowerMeter.Join(1000)
        'End If

        ThreadPowerMeter = Nothing
        Return True
        Exit Function
SysErr:
        EndPowerMeter = False
        ' ErrorMsg = ErrorMsg & "End Power Meter Thread Error" & ","
    End Function

    Sub SendCmdLaser(ByVal strMsg As String)
        On Error GoTo SysErr
        qPowerMeterCmd.Enqueue(strMsg)
        Exit Sub
SysErr:

    End Sub

    Function RequestCmdLaser(ByVal strMsg As String) As String
        On Error GoTo SysErr
        Dim strRtn As String = ""

        PowerMeterComm.Write(strMsg)
        strRtn = RcvString(1)

        Return strRtn
        Exit Function
SysErr:
        ' Return "E"
    End Function

    Sub PowerMeterStatusThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String
        'While nKillThread = 0

        If UsePowerMeter = True Then

            bThreadRunningPowerMeter = True
            If qPowerMeterCmd.Count >= 1 Then
                If qPowerMeterCmd.Count <> 0 Then
                    strCmd = qPowerMeterCmd.Dequeue
                    PowerMeterComm.Write(strCmd & vbCrLf)
                    Thread.Sleep(50)
                End If
            Else
                GetStatus(m_iIndex)
            End If

            'Thread.Sleep(1000)
            'Else
            'Thread.Sleep(10000)
        End If

        'End While

        'bThreadRunningPowerMeter = False
        Exit Sub
SysErr:
        bThreadRunningPowerMeter = False
        'ErrorMsg = ErrorMsg & "Power Meter Status Thread Error" & ","
    End Sub

    Sub GetStatus(ByRef nIndex As Integer)
        On Error GoTo SysErr
        '20161002 JCM Test

        'bRead = True

        If bRead = True Then
            Exit Sub
        End If
        bRead = True

        'PowerMeterStatus.Power = RequestCmdLaser("*CVU")

        tmpMsg = RequestCmdLaser("*CVU")

        If InStr(tmpMsg, "ACK") <> 0 Then
            tmpSplit = Split(tmpMsg, ",")
            PowerMeterStatus.Power = tmpSplit(1)
        Else
            PowerMeterStatus.Power = ""
        End If

        bRead = False

        Exit Sub
SysErr:
        bRead = False
    End Sub

#End Region

#Region "Connect"
    Function Connect(ByVal PortNum As Integer, ByVal BaudRate As Integer) As Boolean
        On Error GoTo SysErr
        If PowerMeterComm.IsOpen = True Then
            PowerMeterComm.Close()
        End If
        PowerMeterComm.Open(PortNum, BaudRate, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 1024)
        If PowerMeterComm.IsOpen = True Then
            PowerMeterStatus.bConnect = StartPowerMeter()
            Return True
        Else
            Return False
        End If
        Exit Function
SysErr:

        ' ErrorMsg = ErrorMsg & "Laser Connect Error" & "," & Err.Description
        Return False
    End Function

    Function DisConnect() As Boolean
        On Error GoTo SysErr
        If PowerMeterComm.IsOpen = True Then
            PowerMeterComm.Close()
        End If
        PowerMeterStatus.bConnect = False
        Return True
        Exit Function
SysErr:
        'ErrorMsg = ErrorMsg & "Laser Disconnect Error" & ","
        Return False
    End Function

    Sub Close()

        If Not (ThreadPowerMeter Is Nothing) Then
            ThreadPowerMeter.Join(10000)
        End If

        Call Finalize()

    End Sub
#End Region

#Region "Command"
    Function Reset() As Boolean
        On Error GoTo SysErr

        SendCmdLaser("*RST")

        Return True
        Exit Function
SysErr:

        Return False
    End Function

    Function SetWaveLenth(ByVal nWave As WaveLength) As Boolean
        On Error GoTo SysErr
        Dim tmpValue As Integer = nWave

        Dim waveLength As String = tmpValue.ToString("D5")

        PowerMeterComm.Write("*PWC" & waveLength)

        'SendCmdLaser("*PWC" & waveLength)

        Return True
SysErr:
        Return False
    End Function

    Function SetZero() As Boolean
        On Error GoTo SysErr

        SendCmdLaser("SOU")

        Return True
SysErr:
        Return False
    End Function

    Function EnergyMode(ByVal bOn As Boolean) As Boolean
        On Error GoTo SysErr
        Dim tmpCmd As String = ""
        If bOn = True Then
            tmpCmd = "*CMW"
        Else
            tmpCmd = "*CMX"
        End If

        SendCmdLaser(tmpCmd)
        Return True
SysErr:
        Return False
    End Function
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
                While (PowerMeterComm.Read(1) <> -1)
                    rtnString = rtnString & Chr(PowerMeterComm.InputStream(0))
                    If InStr(rtnString, vbCrLf) <> 0 Then
                        nCount = nCount + 1
                        rtnString = Replace(rtnString, vbCrLf, ",")
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
