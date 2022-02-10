Imports System.Threading
Imports System.Runtime.InteropServices

Public Class clsRTC6Thread

    Public bSeqRun() As Boolean
#Region "Parameter Set"
    Private m_iRTC6Num As Integer = 0 '설명: 스캐너 넘버 
    Private m_iTimeBase As Integer = 1 '설명 : TimeBase = 0 ( 1bit = 1 us [1Mhz]), TimeBase = 1 ( 1bit = 1/8 us [8Mhz])
    Private m_iLaserMod As Integer '설명 : CO2 Mode = 0, YAG Mode 1 = 1, YAG Mode 2 = 2, YAG Mode 3 = 3, Laser Mode = 4 
    Private m_iFirstPulseKill As Integer '설명 : 1bit = 1/8us
    Private m_iHalfPulsePeriod As Integer '설명 : 1bit = 1us or 1/8us
    Private m_iPulseWidth1 As Integer '설명 : 1bit = 1us or 1/8us
    Private m_iPulseWidth2 As Integer '설명 : 1bit = 1us or 1/8us
    Private m_dScanScale As Double = 1 '설명 : bit 당 이동거리 단위(um)
    Private m_dRtnScanScale As Double = 1 '설명 : bit 당 이동거리 단위(um)
    Private m_dJumpSpeed As Double '설명 : 단위 mm/s 범위 2 ~ 50000bit
    Private m_dMarkSpeed As Double '설명 : 단위 mm/s 범위 2 ~ 50000bit
    Private m_iLaserOnDelay As Integer  '설명 : 단위 1us , 범위 -8000us ~ 8000us
    Private m_iLaserOffDelay As Integer '설명 : 단위 1us , 범위 2us ~ 8000us
    Private m_iJumpDelay As Integer '설명 : bit 당 10us , 범위 0us ~ 32767bit
    Private m_iMarkDelay As Integer '설명 : bit 당 10us , 범위 0us ~ 32767bit
    Private m_iPolygonDelay As Integer '설명 : bit 당 10us , 범위 0us ~ 32767bit
    Private m_strCorrectionFilePath As String ' 
    Private m_strProgramFilePath As String

    Structure ScannerStatus
        Dim bInit As Boolean
        Dim bAbleWork As Boolean
        Dim bShot As Boolean
        Dim dPosX As Double
        Dim dPosY As Double
    End Structure

    Public pStatus As ScannerStatus
    Public m_iIndex As Integer = 0
    Private ThreadScanner As Thread
    Private bThreadRunningScanner As Boolean
    Private nKillThreadScanner As Integer
    Private nThreadIndex As Integer = 1

    Enum CalMatrix
        Five = 0
        Seven
        Nine
        Eleven
        Thirteen
        Fifteen
        SevenTeen
        NineTeen
    End Enum

#End Region

    Dim ErrorMsg As String = ""

#Region "Thread"

    ReadOnly Property ThreadRunningLaser() As Boolean
        Get
            Return bThreadRunningScanner
        End Get
    End Property

    Function StartScanner() As Boolean
        On Error GoTo SysErr

        ThreadScanner = New Thread(AddressOf ScannerStatusThreadSub)
        nKillThreadScanner = 0
        ThreadScanner.SetApartmentState(ApartmentState.MTA)
        ThreadScanner.Priority = ThreadPriority.Highest 'ThreadPriority.Normal
        ThreadScanner.Start()

        ReDim bSeqRun(3)

        bSeqRun(0) = True
        bSeqRun(1) = True
        bSeqRun(2) = True
        bSeqRun(3) = True

        StartScanner = True
        Exit Function
SysErr:
        pStatus.bInit = False
        StartScanner = False
        ErrorMsg = ErrorMsg & "Start Laser Status Thread Error" & ","
    End Function

    Function EndScanner() As Boolean
        On Error GoTo SysErr
        Interlocked.Exchange(nKillThreadScanner, 1)

        If bThreadRunningScanner = True Then
            ThreadScanner.Join(1000)   'ThreadScanner.Join(5000)
        End If

        ThreadScanner = Nothing
        pStatus.bInit = False

        Return True
        Exit Function
SysErr:
        EndScanner = False
        ErrorMsg = ErrorMsg & "End Laser Status Thread Error" & ","
    End Function


    Dim nSeqIndex As Integer = 0

    Sub ScannerStatusThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String

        While nKillThreadScanner = 0
            bThreadRunningScanner = True
            'pStatus.bAbleWork = RTC6Status(pStatus.dPosX, pStatus.dPosY)

            Select Case nSeqIndex
                Case 0
                    If pScanner(0).pStatus.bInit = True Then
                        If bSeqRun(0) = True Then
                            pScanner(0).ScannerStatusThreadSub()
                        End If

                    End If
                    nSeqIndex = 1
                Case 1
                    If pScanner(1).pStatus.bInit = True Then
                        If bSeqRun(0) = True Then
                            pScanner(1).ScannerStatusThreadSub()
                        End If
                    End If
                    nSeqIndex = 2
                Case 2
                    If pScanner(2).pStatus.bInit = True Then
                        If bSeqRun(2) = True Then
                            pScanner(2).ScannerStatusThreadSub()
                        End If
                    End If
                    nSeqIndex = 3
                Case 3
                    If pScanner(3).pStatus.bInit = True Then
                        If bSeqRun(3) = True Then
                            pScanner(3).ScannerStatusThreadSub()
                        End If
                    End If
                    nSeqIndex = 0
            End Select

            Thread.Sleep(100) '50 -> 100

        End While

        bThreadRunningScanner = False
        Exit Sub
SysErr:
        bThreadRunningScanner = False
        'ErrorMsg = ErrorMsg & "Laser Status Thread Error" & ","
    End Sub

    Sub Close()

        If Not (ThreadScanner Is Nothing) Then
            ThreadScanner.Join(10000)
        End If

        Call Finalize()

    End Sub

#End Region


End Class
