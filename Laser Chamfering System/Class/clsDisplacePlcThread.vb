Imports System.Threading
Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsDisplacePlcThread
    Public m_IsStopping As Boolean

#Region "Thread"
    Private ThreadDisplacePlc As Thread
    Private bThreadRunningDisplacePlc As Boolean
    Private nKillThread As Integer
    Private qDisplaceCmd As New Queue
    Dim bRead As Boolean

    Dim disFirstConnectA As Boolean = True
    Dim disFirstConnectB As Boolean = True

    Dim distempstr As String

    Public bDisplaceConnect As Boolean = False

    ReadOnly Property ThreadRunningDisplacePlc() As Boolean
        Get
            Return bThreadRunningDisplacePlc
        End Get
    End Property

    Function StartDisplacePlc() As Boolean
        On Error GoTo SysErr

        ThreadDisplacePlc = New Thread(AddressOf DisplacePlcStatusThreadSub)
        nKillThread = 0
        ThreadDisplacePlc.SetApartmentState(ApartmentState.MTA)
        ThreadDisplacePlc.Priority = ThreadPriority.Lowest
        ThreadDisplacePlc.Start()
        m_IsStopping = False
        StartDisplacePlc = True


        Exit Function
SysErr:
        StartDisplacePlc = False

    End Function

    Function EndDisplacePlc() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThread, 1)
        If bThreadRunningDisplacePlc = True Then
            ThreadDisplacePlc.Join(1000)
        End If

        ThreadDisplacePlc = Nothing
        Return True
        Exit Function
SysErr:
        EndDisplacePlc = False
    End Function

    Dim m_nSeqindex As Integer = 0

    Sub DisplacePlcStatusThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String

        While nKillThread = 0

            DispalcePLCSend()

            System.Threading.Thread.Sleep(100)
            'Loop
        End While

        bThreadRunningDisplacePlc = False

        Exit Sub
SysErr:
        bThreadRunningDisplacePlc = False
        'ErrorMsg = ErrorMsg & "Power Meter Status Thread Error" & ","
    End Sub

    Sub Close()

        If Not (ThreadDisplacePlc Is Nothing) Then
            ThreadDisplacePlc.Join(10000)
        End If

        Call Finalize()

    End Sub
#End Region

    Private Sub DispalcePLCSend()
        If bDisplaceConnect = True Then
            If pLDLT.PLC_Infomation.bDisplaceSend(LINE.A) = True Then
                If disFirstConnectA = True Then
                    pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_COM)
                    pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_SETTING)
                    'pDisplace.SendCmd(clsDisplace.SetCmd.SET_ZERO_POINT)
                    System.Threading.Thread.Sleep(200)
                    disFirstConnectA = False
                End If
                Dim isOk As Boolean = False
                isOk = pDisplace.SendCmd(clsDisplace.GetCmd.GET_VALUE)

                If isOk = False Then
                    MsgBox("변위센서 통신을 연결해주세요", MsgBoxStyle.OkOnly, "Displace")
                    '연결안됨 메세지 출력
                Else
                    For i As Integer = 0 To 500
                        System.Threading.Thread.Sleep(1)
                    Next
                    distempstr = Mid(pDisplace.rtnStr, 4, 8)
                    If distempstr = "-FFFFFFF" Then
                        distempstr = "-99.9999"
                    End If
                    pLDLT.DisplacePLCSend(distempstr, 0)
                End If
            ElseIf pLDLT.PLC_Infomation.bDisplaceSend(LINE.A) = False Then
                disFirstConnectA = True
            End If

            If pLDLT.PLC_Infomation.bDisplaceSend(LINE.B) = True Then
                If disFirstConnectB = True Then
                    pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_COM)
                    pDisplace.SendCmd(clsDisplace.SetCmd.SET_MODE_SETTING)
                    'pDisplace.SendCmd(clsDisplace.SetCmd.SET_ZERO_POINT)
                    System.Threading.Thread.Sleep(200)
                    disFirstConnectB = False
                End If
                Dim isOk As Boolean = False
                isOk = pDisplace.SendCmd(clsDisplace.GetCmd.GET_VALUE)

                If isOk = False Then
                    MsgBox("변위센서 통신을 연결해주세요", MsgBoxStyle.OkOnly, "Displace")
                    '연결안됨 메세지 출력
                Else
                    For i As Integer = 0 To 500
                        System.Threading.Thread.Sleep(1)
                    Next

                    distempstr = Mid(pDisplace.rtnStr, 13, 8)
                    If distempstr = "-FFFFFFF" Then
                        distempstr = "-99.9999"
                    End If
                    pLDLT.DisplacePLCSend(distempstr, 1)
                End If
            ElseIf pLDLT.PLC_Infomation.bDisplaceSend(LINE.B) = False Then
                disFirstConnectB = True
            End If

        End If

    End Sub

End Class
