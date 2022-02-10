Imports System.Threading

Public Class clsDustCollector
    Private CommPort As New Comm()
    Private qCmd As New Queue
    Private ThreadDustCollector As Thread
    Private bThreadRunningDustCollector As Boolean
    Private nKillThreadDustCollector As Integer
    Private nDustCollectorIndex As Integer = 0
    Public m_iCh As Integer = 0
    Private crc_table() As Byte = {&H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, _
                                &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, _
                                &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, _
                                &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, _
                                &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, _
                                &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, _
                                &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, _
                                &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, _
                                &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, _
                                &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, _
                                &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, _
                                &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, _
                                &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC0, &HC1, &H1, _
                                &HC3, &H3, &H2, &HC2, &HC6, &H6, &H7, &HC7, &H5, &HC5, &HC4, &H4, &HCC, &HC, &HD, &HCD, &HF, &HCF, &HCE, &HE, _
                                &HA, &HCA, &HCB, &HB, &HC9, &H9, &H8, &HC8, &HD8, &H18, &H19, &HD9, &H1B, &HDB, &HDA, &H1A, &H1E, &HDE, &HDF, &H1F, _
                                &HDD, &H1D, &H1C, &HDC, &H14, &HD4, &HD5, &H15, &HD7, &H17, &H16, &HD6, &HD2, &H12, &H13, &HD3, &H11, &HD1, &HD0, &H10, _
                                &HF0, &H30, &H31, &HF1, &H33, &HF3, &HF2, &H32, &H36, &HF6, &HF7, &H37, &HF5, &H35, &H34, &HF4, &H3C, &HFC, &HFD, &H3D, _
                                &HFF, &H3F, &H3E, &HFE, &HFA, &H3A, &H3B, &HFB, &H39, &HF9, &HF8, &H38, &H28, &HE8, &HE9, &H29, &HEB, &H2B, &H2A, &HEA, _
                                &HEE, &H2E, &H2F, &HEF, &H2D, &HED, &HEC, &H2C, &HE4, &H24, &H25, &HE5, &H27, &HE7, &HE6, &H26, &H22, &HE2, &HE3, &H23, _
                                &HE1, &H21, &H20, &HE0, &HA0, &H60, &H61, &HA1, &H63, &HA3, &HA2, &H62, &H66, &HA6, &HA7, &H67, &HA5, &H65, &H64, &HA4, _
                                &H6C, &HAC, &HAD, &H6D, &HAF, &H6F, &H6E, &HAE, &HAA, &H6A, &H6B, &HAB, &H69, &HA9, &HA8, &H68, &H78, &HB8, &HB9, &H79, _
                                &HBB, &H7B, &H7A, &HBA, &HBE, &H7E, &H7F, &HBF, &H7D, &HBD, &HBC, &H7C, &HB4, &H74, &H75, &HB5, &H77, &HB7, &HB6, &H76, _
                                &H72, &HB2, &HB3, &H73, &HB1, &H71, &H70, &HB0, &H50, &H90, &H91, &H51, &H93, &H53, &H52, &H92, &H96, &H56, &H57, &H97, _
                                &H55, &H95, &H94, &H54, &H9C, &H5C, &H5D, &H9D, &H5F, &H9F, &H9E, &H5E, &H5A, &H9A, &H9B, &H5B, &H99, &H59, &H58, &H98, _
                                &H88, &H48, &H49, &H89, &H4B, &H8B, &H8A, &H4A, &H4E, &H8E, &H8F, &H4F, &H8D, &H4D, &H4C, &H8C, &H44, &H84, &H85, &H45, _
                                &H87, &H47, &H46, &H86, &H82, &H42, &H43, &H83, &H41, &H81, &H80, &H40}

    Structure DustCollectorStatus
        Dim DiffPress As Double
        Dim DrivingTime As Double
        Dim Current As Double
        Dim Power As Double
        Dim Fan As Double
        Dim Pulse As Double
        Dim ManPulse As Double
        Dim Inverter As Double
        Dim InverterPer As Double
        Dim AlarmLog As Double
        Dim RunFlag As Double
        Dim SolFlag As Double
        Dim AlarmBuzzerFlag As Double
        Dim AlarmCode As Double
    End Structure

    Public Status As DustCollectorStatus

    Enum RUNFLAG
        STOPON
        RUN
        NOTTING
    End Enum

    ReadOnly Property ThreadRunning() As Boolean
        Get
            Return bThreadRunningDustCollector
        End Get
    End Property


    ReadOnly Property IsOpen() As Boolean
        Get
            Return CommPort.IsOpen
        End Get
    End Property


    Public Function crc16(ByVal modbusframe() As Byte, ByVal Length As Integer) As Integer
        Dim i As Integer
        Dim index As Integer
        Dim crc_Low As Integer = &HFF
        Dim crc_High As Integer = &HFF

        For i = 0 To Length - 1
            index = crc_High Xor modbusframe(i)
            crc_High = crc_Low Xor crc_table(index)
            crc_Low = CByte(crc_table(index + 256))
        Next i

        Return crc_High * 256 + crc_Low
    End Function

    Private Function CalcStrCRC16$(ByVal tmpstr$)
        Dim tmp(200) As Byte
        Dim tmplen%, i%
        Dim tmpcrc&

        tmplen = Len(tmpstr) \ 2

        For i = 0 To tmplen
            tmp(i) = Val("&H" & Mid(tmpstr, i * 2 + 1, 2))
        Next

        tmpcrc = crc16(tmp, tmplen)

        If tmpcrc <= &HF Then
            CalcStrCRC16 = "000" & Hex(tmpcrc)
        ElseIf tmpcrc <= &HFF Then
            CalcStrCRC16 = "00" & Hex(tmpcrc)
        ElseIf tmpcrc <= &HFFF Then
            CalcStrCRC16 = "0" & Hex(tmpcrc)
        Else
            CalcStrCRC16 = Hex(tmpcrc)
        End If

    End Function

    Private Function CalcCRC16(ByVal bt() As Byte) As Byte()
        Dim strTmp As String = ""
        Dim btTmp(bt.Length - 1) As Byte

        For i As Integer = 0 To bt.Length - 3
            If Hex(bt(i)).Length = 1 Then
                strTmp += "0" & Hex(bt(i))
            Else
                strTmp += Hex(bt(i))
            End If
        Next
        strTmp = CalcStrCRC16(strTmp)
        bt(bt.Length - 2) = Convert.ToInt16(strTmp.Substring(0, 2), 16)
        bt(bt.Length - 1) = Convert.ToInt16(strTmp.Substring(2, 2), 16)

        For i As Integer = 0 To bt.Length - 1
            btTmp(i) = bt(i)
        Next
        CalcCRC16 = btTmp

    End Function

    Public Function StartThread() As Boolean
        On Error GoTo SysErr

        ThreadDustCollector = New Thread(AddressOf ThreadSub)
        nKillThreadDustCollector = 0
        ThreadDustCollector.SetApartmentState(ApartmentState.MTA)
        ThreadDustCollector.Priority = ThreadPriority.Lowest
        ThreadDustCollector.Start()
        StartThread = True

        Exit Function
SysErr:
        StartThread = False
    End Function

    Public Function EndThread() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThreadDustCollector, 1)
        If bThreadRunningDustCollector = True Then
            ThreadDustCollector.Join()
        End If

        ClosePort()

        ThreadDustCollector = Nothing

        EndThread = True

        Exit Function
SysErr:
        EndThread = False
    End Function

    Sub ThreadSub()
        On Error GoTo SysErr
        Dim btCmd() As Byte
        Dim strArr(43) As String
        Dim strTmp As String
        Dim dTmp As Double
        Dim strTmp2 As String
        Dim strRtn As String
        Dim btRtn() As Byte


        While nKillThreadDustCollector = 0
            bThreadRunningDustCollector = True

            If qCmd.Count >= 1 Then
                For i = 0 To qCmd.Count - 1
                    btCmd = qCmd.Dequeue
                    CommPort.Write(btCmd)
                    Thread.Sleep(50)
                Next i
            Else
                If GetDustCollectorStatus() = True Then
                    Thread.Sleep(50) '꼭
                    btRtn = RcvByte()
                    If btRtn.Length >= 43 Then '길이가 43안되서 오는경우가 있음
                        Status.DiffPress = btRtn(3).ToString & btRtn(4).ToString
                        Status.DrivingTime = btRtn(5).ToString & btRtn(6).ToString & btRtn(7).ToString & btRtn(8).ToString
                        Status.Current = btRtn(9).ToString & btRtn(10).ToString
                        Status.Power = btRtn(11).ToString & btRtn(12).ToString
                        Status.Fan = btRtn(13).ToString & btRtn(14).ToString
                        Status.Pulse = btRtn(15).ToString & btRtn(16).ToString
                        Status.ManPulse = btRtn(17).ToString & btRtn(18).ToString
                        Status.InverterPer = Convert.ToInt16(btRtn(19).ToString, 16)
                        Status.Inverter = Convert.ToInt16(btRtn(20).ToString, 16)
                        'alarmlog 는 monitor 용으로 적합치 않다. (단순한 히스토리)
                        'Status.AlarmLog = Convert.ToInt16(btRtn(21).ToString & btRtn(22).ToString & btRtn(23).ToString & btRtn(24).ToString & _
                        '                                btRtn(25).ToString & btRtn(26).ToString & btRtn(27).ToString & btRtn(28).ToString & _
                        '                                btRtn(29).ToString & btRtn(30).ToString & btRtn(31).ToString & btRtn(32).ToString, 16)

                        Status.RunFlag = btRtn(33).ToString & btRtn(34).ToString   '1 = 운전중 ,  2 = 정지중
                        Status.SolFlag = btRtn(35).ToString & btRtn(36).ToString
                        Status.AlarmCode = btRtn(39).ToString & btRtn(40).ToString   '  0 = no alarm , else = alarm

                       
                    End If
                End If

            End If

            Thread.Sleep(100)   '60 -> 100
        End While

        bThreadRunningDustCollector = False
        Exit Sub
SysErr:
        Dim str As String
        bThreadRunningDustCollector = False
        modPub.ErrorLog("Dust :: " & Err.Description)
        str = Err.Description
    End Sub

    Private Sub RcvStringCalc(ByRef btRtn() As Byte)
        On Error GoTo SysErr

        btRtn(0) = RcvString()
        btRtn(1) = RcvString()
        btRtn(2) = RcvString()
        For j As Integer = 3 To btRtn(2)
            btRtn(j) = RcvString()
        Next
        'RcvStringCalc = btRtn

        Exit Sub
SysErr:
        Dim str As String
        str = Err.Description
        btRtn = btRtn
    End Sub

    Public Function RcvString(Optional ByVal nTimeoutSec As Integer = 1) As String
        Dim rtnString As String
        Dim nTimeoutCnt As Integer

        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10
        For i As Integer = 0 To nTimeoutCnt
            Try
                'While (CommPort.Read(1) <> -1)
                '    'rtnString = rtnString & Chr(CommPort.InputStream(0))
                '    rtnString = rtnString & (CommPort.InputStream(0))
                '    'If InStr(rtnString, vbCr) <> 0 Then
                '    If InStr(rtnString, "") <> 0 Then
                '        ' rtnString = rtnString.Remove(rtnString.Length - 1)
                '        RcvString = rtnString
                '        Exit Function
                '    ElseIf CStr(rtnString) = 0 Then
                '        RcvString = rtnString
                '        Exit Function
                '    End If
                '    Application.DoEvents()
                'End While
                While (CommPort.Read(1) <> -1)
                    rtnString = rtnString & (CommPort.InputStream(0))
                    If InStr(rtnString, "") <> 0 Then
                        ' rtnString = rtnString.Remove(rtnString.Length - 1)
                        RcvString = rtnString
                        Exit Function
                    ElseIf CStr(rtnString) = 0 Then
                        RcvString = rtnString
                        Exit Function
                    End If
                    'Application.DoEvents()
                End While
            Catch
                System.Threading.Thread.Sleep(100)
                'Application.DoEvents()
            End Try
        Next i
        RcvString = "TMO"

    End Function

    Public Function RcvByte(Optional ByVal nTimeoutSec As Integer = 2) As Byte()
        Dim rtnString As String
        Dim rtnBt() As Byte
        Dim nTimeoutCnt As Integer


        rtnString = ""
        nTimeoutCnt = nTimeoutSec * 10
        For i As Integer = 0 To nTimeoutCnt
            Try
                While (CommPort.ReadEx(0) <> -1)

                    rtnBt = CommPort.InputStream
                    RcvByte = rtnBt
                    ' RcvString = rtnBt(0)
                    Exit Function
                    'Application.DoEvents()
                End While
            Catch
                System.Threading.Thread.Sleep(10)
                'Application.DoEvents()
            End Try
        Next i
        RcvByte = Nothing
    End Function

    Public Function OpenPort(ByVal ipPortNum As Integer) As Boolean
        On Error GoTo SysErr
        If CommPort.IsOpen = True Then
            CommPort.Close()
        End If
        CommPort.Open(ipPortNum, 9600, 8, Comm.DataParity.Parity_None, Comm.DataStopBit.StopBit_1, 4096)
        OpenPort = True

        Exit Function
SysErr:
        OpenPort = False
        ' pErrMsg = Err.Description
    End Function

    Function ClosePort() As Boolean
        On Error GoTo SysErr

        If CommPort.IsOpen = True Then
            CommPort.Close()
        End If
        ClosePort = True

        Exit Function
SysErr:
        ClosePort = False
        ' pErrMsg = Err.Description
    End Function


    Public Function BinArr(ByVal strRtn As String) As Byte()
        On Error GoTo SysErr
        Dim btTmp(7) As Byte
        Dim nTmp As Integer

        For i As Integer = 0 To btTmp.Length - 1

            nTmp = (strRtn And (2 ^ i)) = (2 ^ i)
            If nTmp = -1 Then nTmp = 1
            btTmp(i) = nTmp.ToString
        Next

        BinArr = btTmp
        Exit Function
SysErr:

    End Function

    Public Function GetDustCollectorStatus() As Boolean
        On Error GoTo SysErr
        'Dim bt() As Byte = {2, 4, 16, 0, 0, 20, 244, 246}
        Dim bt(7) As Byte
        bt(0) = Val("&H02")
        bt(1) = Val("&H04")
        bt(2) = Val("&H10")
        bt(3) = Val("&H00")
        bt(4) = Val("&H00")
        bt(5) = Val("&H14")
        bt(6) = 0
        bt(7) = 0
        bt = CalcCRC16(bt)
        CommPort.Write(bt)
        Return True
        Exit Function
SysErr:
        Return False
    End Function

    'Public Sub RunDustCollector()
    '    Dim bt(10) As Byte
    '    bt(0) = Val("&H02")
    '    bt(1) = Val("&H10")
    '    bt(2) = Val("&H10")
    '    bt(3) = Val("&H54")
    '    bt(4) = Val("&H00")
    '    bt(5) = Val("&H01")
    '    bt(6) = Val("&H02")
    '    bt(7) = Val("&H00")
    '    bt(8) = Val("&H01")
    '    bt(9) = 0
    '    bt(10) = 0
    '    bt = CalcCRC16(bt)
    '    qCmd.Enqueue(bt)
    'End Sub
End Class
