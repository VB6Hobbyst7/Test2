Imports System.Threading
Imports System.Text
Imports Microsoft.VisualBasic

Public Class clsLVSCN40X
    Dim Comm1 As New Comm
    Dim ErrorMsg As String = ""
    'Dim STX As String = "L"
    Dim STX As String = ":"
    Dim ETX As String = vbCrLf
    Public m_nLightVal(8) As Integer
    Public ctlLightVal(8) As Integer
    'ReDim m_nLightVal(8)

#Region "Connect"
    Function Connect(ByVal PortNum As Integer) As Boolean
        On Error GoTo SysErr
        If Comm1.IsOpen = True Then
            Comm1.Close()
        End If
        Comm1.Open(PortNum, 19200, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 1024)
        'Comm1.Open(PortNum, 9600, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 1024)
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

    Sub Close()

        Call Finalize()

    End Sub

    ReadOnly Property IsOpen() As Boolean
        Get
            Return Comm1.IsOpen
        End Get
    End Property

#End Region

#Region "Command"
    Function LightOnOff(ByVal nChannel As Integer, ByVal bOn As Boolean) As Boolean
        On Error GoTo SysErr
        Dim SendMsg As String = ""
        Dim nOn As Integer = -9999

        If bOn = True Then
            nOn = 1
        ElseIf bOn = False Then
            nOn = 0
        End If

        SendMsg = STX & nChannel.ToString() & nOn.ToString & ETX
        Comm1.Write(SendMsg)
        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send On/Off Error" & ","
        Return False
    End Function

    Dim bLightLifeTimeCheck(8) As Boolean
    Public tStartCurrentTime(8) As Date
    Dim tEndCurrentTime(8) As Date
    Dim tCheckTime As TimeSpan         '시간계산하기위한 구조체
    Dim sTempString As String
    Dim sReadData As String         '저장된 조명 켜진시간 가져올 변수
    Dim sWriteData As String        '저장할 계산된 조명 켜진시간 저장 할 변수

    
    ' JYS 조명 수명 시간 계산 함수 
    ' Function CheckLightLifeTime(ByVal nChannel As Integer, ByVal nValue As Integer ) As Boolean
    '                                    해당 체널          ,         조명 값        
    Function CheckLightLifeTime(ByVal nChannel As Integer, ByVal nValue As Integer) As Boolean

        'JYS 조명 수명 계산 ( 조명값이 0이 아니면 켜진것으로 간주한다 )
        If nValue = 0 And bLightLifeTimeCheck(nChannel) = True Then
            '시간 체크 끝
            bLightLifeTimeCheck(nChannel) = False
            tEndCurrentTime(nChannel) = Date.Now         '조명 꺼진 시간 
            tCheckTime = tEndCurrentTime(nChannel).Subtract(tStartCurrentTime(nChannel)) '조명 켜진시간 계산
            sTempString = "CHANNEL" & nChannel
            sReadData = ReadIni("LIGHT_LIFT_TIME", sTempString, "-1", "C:\Chamfering System\DEFAULT.ini")  ' 저장된 값 조명 켜진시간 가져오기
            sWriteData = Double.Parse(sReadData) + tCheckTime.TotalSeconds
            WriteIni("LIGHT_LIFT_TIME", sTempString, sWriteData, "C:\Chamfering System\DEFAULT.ini")  '더한 값 저장

        ElseIf nValue <> 0 And bLightLifeTimeCheck(nChannel) = False Then
            '시간 체크 시작
            bLightLifeTimeCheck(nChannel) = True
            tStartCurrentTime(nChannel) = Date.Now       '시작 시간 체크시작
        End If


    End Function

    Function SetLight(ByVal nChannel As Integer, ByVal nValue As Integer) As Boolean
        On Error GoTo SysErr
        Dim SendMsg As String = ""

        'SendMsg = STX & nChannel.ToString() & nValue.ToString("D3") & ETX

        SendMsg = STX & "1" & nChannel.ToString() & nValue.ToString("D3") & ETX
        Comm1.Write(SendMsg)

        CheckLightLifeTime(nChannel, nValue)  'JYS 조명시간 체크 함수

        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send Value Error" & ","
        Return False
    End Function


    Dim btRtn() As Byte
    Dim strRtn As String

    Function GetLight(ByVal nChannel As Integer, ByRef nValue As Integer) As Boolean
        On Error GoTo SysErr
        Dim SendMsg As String = ""

        'SendMsg = STX & nChannel.ToString() & nValue.ToString("D3") & ETX

        'SendMsg = STX & "1" & nChannel.ToString() & nValue.ToString("D3") & ETX
        'SendMsg = STX & "1" & "R" & "U" & nValue.ToString("D3") & ETX
        SendMsg = STX & "1" & "R" & "U" & ETX
        Comm1.Write(SendMsg)

        System.Threading.Thread.Sleep(200)

        btRtn = RcvByte()

        If btRtn.Length > 0 Then
            ParseReceived()
        End If


        Return True
        Exit Function
SysErr:
        ErrorMsg = ErrorMsg & "Send Value Error" & ","
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
                While (Comm1.ReadEx(0) <> -1)

                    rtnBt = Comm1.InputStream
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

        'If btRtn(0) = STX And btRtn(1) = &H32 Then
        Dim strStatus As String = btRtn(2)
        Dim str As String = ""
        Dim oEncoder As Encoding = Encoding.ASCII
        Dim TempByte() As Byte

        ReDim TempByte(btRtn.Length - 1)


        TempByte = {btRtn(4), btRtn(5), btRtn(6)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(0) = CInt(str)

        TempByte = {btRtn(8), btRtn(9), btRtn(10)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(1) = CInt(str)

        TempByte = {btRtn(12), btRtn(13), btRtn(14)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(2) = CInt(str)

        TempByte = {btRtn(16), btRtn(17), btRtn(18)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(3) = CInt(str)

        TempByte = {btRtn(20), btRtn(21), btRtn(22)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(4) = CInt(str)

        TempByte = {btRtn(24), btRtn(25), btRtn(26)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(5) = CInt(str)

        TempByte = {btRtn(28), btRtn(29), btRtn(30)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(6) = CInt(str)

        TempByte = {btRtn(32), btRtn(33), btRtn(34)}
        str = oEncoder.GetString(TempByte)
        m_nLightVal(7) = CInt(str)

        TempByte = btRtn    '{btRtn(4), btRtn(5), btRtn(6)}
        str = oEncoder.GetString(TempByte)

    End Sub


#End Region

End Class
