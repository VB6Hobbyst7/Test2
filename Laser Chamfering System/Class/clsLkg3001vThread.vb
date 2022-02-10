Imports System.Threading
Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsDisplaceThread


    Dim tmpMsg As String = ""
    Dim tmpSplit() As String = {}

    Public UseChiller As Boolean
    Public pnDisplaceSleepCnt As Integer

    Public m_IsStopping As Boolean
    Public DisplaceComm As New Comm

    Dim ErrorMsg As String = ""
    Dim ETX As String = vbCr
    Dim btRtn() As Byte
    Dim m_TimeCheck As New clsTimer

#Region "Thread"
    Private ThreadDisplace As Thread
    Private bThreadRunningDisplace As Boolean
    Private nKillThread As Integer
    Private qDisplaceCmd As New Queue
    Dim bRead As Boolean

    ReadOnly Property ThreadRunningDisplace() As Boolean
        Get
            Return bThreadRunningDisplace
        End Get
    End Property

    Function StartDisplace() As Boolean
        On Error GoTo SysErr

        ThreadDisplace = New Thread(AddressOf DisplaceStatusThreadSub)
        nKillThread = 0
        ThreadDisplace.SetApartmentState(ApartmentState.MTA)
        ThreadDisplace.Priority = ThreadPriority.Lowest
        ThreadDisplace.Start()
        m_IsStopping = False
        StartDisplace = True


        Exit Function
SysErr:
        StartDisplace = False

    End Function

    Function EndDisplace() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThread, 1)
        If bThreadRunningDisplace = True Then
            ThreadDisplace.Join(1000)
        End If

        ThreadDisplace = Nothing
        Return True
        Exit Function
SysErr:
        EndDisplace = False
    End Function

    Dim m_nSeqindex As Integer = 0

    Sub DisplaceStatusThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String

        While nKillThread = 0


            If pDisplace.Comm1.IsOpen = True Then
                pDisplace.threadFunc()
            End If

            System.Threading.Thread.Sleep(300)
            'Loop
        End While

        bThreadRunningDisplace = False

        Exit Sub
SysErr:
        bThreadRunningDisplace = False
        'ErrorMsg = ErrorMsg & "Power Meter Status Thread Error" & ","
    End Sub

    Sub Close()

        If Not (ThreadDisplace Is Nothing) Then
            ThreadDisplace.Join(10000)
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

    Public Sub ResetDisplace()

        For i As Integer = 0 To 3
            pnDisplaceSleepCnt = 0
            'pnDisplaceIndex(i) = 0
        Next



    End Sub
  
    Public Function RcvByte(Optional ByVal nTimeoutSec As Integer = 2) As Byte()
        Dim rtnString As String
        Dim rtnBt() As Byte
        Dim nTimeoutCnt As Integer

        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10
        For i As Integer = 0 To nTimeoutCnt
            Try
                While (DisplaceComm.ReadEx(0) <> -1)

                    rtnBt = DisplaceComm.InputStream
                    RcvByte = rtnBt
                    Exit Function
                End While
            Catch
                System.Threading.Thread.Sleep(400)
            End Try
        Next i
        RcvByte = Nothing
    End Function

    Public Sub ParseReceived()
        If btRtn.Length < 2 Then
            Return
        End If
        If btRtn(0) = btRtn(1) = &H32 Then
            Dim strStatus As String = btRtn(2)
            Dim str As String = ""
            Dim oEncoder As Encoding = Encoding.ASCII
            Dim TempByte() As Byte

            ReDim TempByte(btRtn.Length - 1)

        End If
    End Sub
End Class


