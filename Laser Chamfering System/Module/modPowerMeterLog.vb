Imports System.IO
Module modPowerMeterLog

    Public strPowerMeter1 As String = String.Empty
    Public strPowerMeter2 As String = String.Empty
    Public strPowerMeter3 As String = String.Empty
    Public strPowerMeter4 As String = String.Empty
    Public strStageTime1 As String = ""
    Public strStageTime2 As String = ""
    Public strStageTime3 As String = ""
    Public strStageTime4 As String = ""

    Public strRootPath As String ' = "C:\Chamfering System\Log\PowerMeter\"
    Dim strLastFileName As String = ""
    Public Sub PowerMeterLogLoad(ByVal intKeepDate As Integer)
        Dim strCurrnetLogFile As String
        Dim strFile() As String
        Dim strFileName() As String

        Dim strlog As String = ".log"
        strRootPath = pCurSystemParam.strSystemLogPath & "\PowerMeter\"

        If System.IO.Directory.Exists(strRootPath) = False Then
            System.IO.Directory.CreateDirectory(strRootPath)
        End If

        strFile = System.IO.Directory.GetFiles(strRootPath)

        ReDim strFileName(strFile.Length - 1)
        For i As Integer = 0 To strFile.Length - 1
            strFileName(i) = GetFileName(strFile(i), True)
        Next

        Try
            strCurrnetLogFile = Format(CDate(Now.AddDays(-intKeepDate)), "yyyy-MM-dd")
            strLastFileName = strRootPath & strCurrnetLogFile & strlog


            If frmSequence.Top_Power = True Then
                PowerMeterTopLog(strLastFileName)
            Else
                PowerMeterStageLog(strLastFileName)
            End If

        Catch ex As Exception
        End Try

    End Sub


    Public Function GetFileName(ByVal ipStrFile As String, Optional ByVal bGetFileFormat As Boolean = False) As String
        On Error GoTo SysErr
        Dim tmpArrStr() As String = {}
        Dim tmpOutPath As String = ""

        tmpArrStr = Split(ipStrFile, "\")
        tmpOutPath = tmpArrStr(tmpArrStr.Length - 1)
        If bGetFileFormat = False Then
            tmpArrStr = Split(tmpOutPath, ".")
            tmpOutPath = tmpArrStr(0)
        End If

        Return tmpOutPath

        Exit Function
SysErr:

    End Function

    Dim LogFilePath As String = ""

    '20190823 joo
    Private Function PowerMeterTop_New(ByVal ipFilePath As String)

        Dim strFilePath As String

        Dim strPowerMeterTop1 As String = 0
        Dim strPowerMeterTop2 As String = 0
        Dim strPowerMeterTop3 As String = 0
        Dim strPowerMeterTop4 As String = 0

        strFilePath = ipFilePath


        strPowerMeterTop1 = ReadIni("LASER_LAST_POWER", "LASER_TOP_1", -1, strFilePath)
        strPowerMeterTop2 = ReadIni("LASER_LAST_POWER", "LASER_TOP_2", -1, strFilePath)
        strPowerMeterTop3 = ReadIni("LASER_LAST_POWER", "LASER_TOP_3", -1, strFilePath)
        strPowerMeterTop4 = ReadIni("LASER_LAST_POWER", "LASER_TOP_4", -1, strFilePath)

        ' Laser Top1
        'RMS
        pMelsec.SendDataWord(Val("&H" & 6310), strPowerMeterTop1 * 100) 'A2
        pMelsec.SendDataWord(Val("&H" & 6340), strPowerMeterTop1 * 100) 'B1

        'APD
        pMelsec.SendDataWord(Val("&H" & 6230), strPowerMeterTop1 * 100) 'A2
        pMelsec.SendDataWord(Val("&H" & 6260), strPowerMeterTop1 * 100) 'B1

        ' Laser Top2
        'RMS
        pMelsec.SendDataWord(Val("&H" & 6300), strPowerMeterTop2 * 100) 'A1
        pMelsec.SendDataWord(Val("&H" & 6350), strPowerMeterTop2 * 100) 'B2
        'APD
        pMelsec.SendDataWord(Val("&H" & 6220), strPowerMeterTop2 * 100) 'A1
        pMelsec.SendDataWord(Val("&H" & 6270), strPowerMeterTop2 * 100) 'B2

        ' Laser Top3
        'RMS
        pMelsec.SendDataWord(Val("&H" & 6330), strPowerMeterTop3 * 100) 'A4
        pMelsec.SendDataWord(Val("&H" & 6360), strPowerMeterTop3 * 100) 'B3
        'APD
        pMelsec.SendDataWord(Val("&H" & 6250), strPowerMeterTop3 * 100) 'A4
        pMelsec.SendDataWord(Val("&H" & 6280), strPowerMeterTop3 * 100) 'B3

        ' Laser Top4
        'RMS
        pMelsec.SendDataWord(Val("&H" & 6320), strPowerMeterTop4 * 100) 'A3
        pMelsec.SendDataWord(Val("&H" & 6370), strPowerMeterTop4 * 100) 'B4
        'APD
        pMelsec.SendDataWord(Val("&H" & 6240), strPowerMeterTop4 * 100) 'A3
        pMelsec.SendDataWord(Val("&H" & 6290), strPowerMeterTop4 * 100) 'B4

        Return True
    End Function

    '20190823 joo
    Private Function PowerMeterStage_New(ByVal ipFilePath As String)

        'Dim strFilePath As String

        'Dim strPowerMeterStage1 As String = 0
        'Dim strPowerMeterStage2 As String = 0
        'Dim strPowerMeterStage3 As String = 0
        'Dim strPowerMeterStage4 As String = 0

        'strFilePath = ipFilePath

        'strPowerMeterStage1 = ReadIni("LASER_LAST_POWER", "LASER_STATE_1", -1, strFilePath)
        'strPowerMeterStage2 = ReadIni("LASER_LAST_POWER", "LASER_STATE_2", -1, strFilePath)
        'strPowerMeterStage3 = ReadIni("LASER_LAST_POWER", "LASER_STATE_3", -1, strFilePath)
        'strPowerMeterStage4 = ReadIni("LASER_LAST_POWER", "LASER_STATE_4", -1, strFilePath)

        '' Laser Top1
        ''RMS
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6311), strPowerMeterStage1 * 100) 'A2
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6341), strPowerMeterStage1 * 100) 'B1

        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6312), strPowerMeterStage1 * 100) 'A2
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6342), strPowerMeterStage1 * 100) 'B1

        ''APD
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6231), strPowerMeterStage1 * 100) 'A2
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6261), strPowerMeterStage1 * 100) 'B1


        '' Laser Top2
        ''RMS
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6301), strPowerMeterStage2 * 100) 'A1
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6351), strPowerMeterStage2 * 100) 'B2

        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6302), strPowerMeterStage2 * 100) 'A1
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6352), strPowerMeterStage2 * 100) 'B2
        ''APD
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6221), strPowerMeterStage2 * 100) 'A1
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6271), strPowerMeterStage2 * 100) 'B2

        '' Laser Top3
        ''RMS
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6331), strPowerMeterStage3 * 100) 'A4
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6361), strPowerMeterStage3 * 100) 'B3

        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6332), strPowerMeterStage3 * 100) 'A4
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6362), strPowerMeterStage3 * 100) 'B3

        ''APD
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6251), strPowerMeterStage3 * 100) 'A4
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6281), strPowerMeterStage3 * 100) 'B3

        '' Laser Top4
        ''RMS
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6321), strPowerMeterStage4 * 100) 'A3
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6371), strPowerMeterStage4 * 100) 'B4

        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6322), strPowerMeterStage4 * 100) 'A3
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6372), strPowerMeterStage4 * 100) 'B4

        ''APD
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6241), strPowerMeterStage4 * 100) 'A3
        'pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6291), strPowerMeterStage4 * 100) 'B4

        Return True
    End Function

    Private Function PowerMeterTopLog(ByVal ipFilePath As String)
        Dim LoadData_Log As New StreamReader(ipFilePath)
        Dim tmpStrData As String = ""
        Dim strExGlass1 As String = "PowerMeter1 Top"
        Dim strExGlass2 As String = "PowerMeter2 Top"
        Dim strExGlass3 As String = "PowerMeter3 Top"
        Dim strExGlass4 As String = "PowerMeter4 Top"
        Dim ipCmd As String = "["
        Dim ipCmd2 As String = "]"
        Dim ipCmd3 As String = "::"
        Dim strLine() As String
        Dim strPowerMeter1 As String = 0
        Dim strPowerMeter2 As String = 0
        Dim strPowerMeter3 As String = 0
        Dim strPowerMeter4 As String = 0
        Dim strTopTime1 As String = ""
        Dim strTopTime2 As String = ""
        Dim strTopTime3 As String = ""
        Dim strTopTime4 As String = ""
        Dim strTime(1) As String



        Do While LoadData_Log.EndOfStream = False
            tmpStrData = LoadData_Log.ReadLine()

            If tmpStrData.Contains("PowerMeter1 Top") = True Then
                If strExGlass1 = "PowerMeter1 Top" Then
                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)

                    strLine = Split(tmpStrData, ipCmd3)

                    strTopTime1 = strTime(0)
                    strPowerMeter1 = strLine(1)

                    frmSequence.lblPowerMeterTop1.Text = strPowerMeter1
                    frmSequence.lblTopTime1.Text = strTopTime1

                    '20190729
                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6310), strPowerMeter1 * 100) 'A2
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6340), strPowerMeter1 * 100) 'B1

                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6230), strPowerMeter1 * 100) 'A2
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6260), strPowerMeter1 * 100) 'B1

                    'frmSequence.lblPowerMeterTop1.Text = strPowerMeter1
                    'frmSequence.lblTopTime1.Text = strTopTime1
                End If

            ElseIf tmpStrData.Contains("PowerMeter2 Top") = True Then
                If strExGlass2 = "PowerMeter2 Top" Then

                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)

                    strLine = Split(tmpStrData, ipCmd3)

                    strTopTime2 = strTime(0)
                    strPowerMeter2 = strLine(1)

                    frmSequence.lblPowerMeterTop2.Text = strPowerMeter2
                    frmSequence.lblTopTime2.Text = strTopTime2

                    '20190729
                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6300), strPowerMeter2 * 100) 'A1
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6350), strPowerMeter2 * 100) 'B2
                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6220), strPowerMeter2 * 100) 'A1
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6270), strPowerMeter2 * 100) 'B2

                    'frmSequence.lblPowerMeterTop2.Text = strPowerMeter2
                    'frmSequence.lblTopTime2.Text = strTopTime2
                End If

            ElseIf tmpStrData.Contains("PowerMeter3 Top") = True Then
                If strExGlass3 = "PowerMeter3 Top" Then

                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)

                    strLine = Split(tmpStrData, ipCmd3)

                    strTopTime3 = strTime(0)
                    strPowerMeter3 = strLine(1)

                    frmSequence.lblPowerMeterTop3.Text = strPowerMeter3
                    frmSequence.lblTopTime3.Text = strTopTime3

                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6330), strPowerMeter3 * 100) 'A4
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6360), strPowerMeter3 * 100) 'B3
                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6250), strPowerMeter3 * 100) 'A4
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6280), strPowerMeter3 * 100) 'B3

                    'frmSequence.lblPowerMeterTop3.Text = strPowerMeter3
                    'frmSequence.lblTopTime3.Text = strTopTime3
                End If

            ElseIf tmpStrData.Contains("PowerMeter4 Top") = True Then
                If strExGlass4 = "PowerMeter4 Top" Then

                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)

                    strLine = Split(tmpStrData, ipCmd3)

                    strTopTime4 = strTime(0)
                    strPowerMeter4 = strLine(1)

                    frmSequence.lblPowerMeterTop4.Text = strPowerMeter4
                    frmSequence.lblTopTime4.Text = strTopTime4

                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6320), strPowerMeter4 * 100) 'A3
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6370), strPowerMeter4 * 100) 'B4
                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6240), strPowerMeter4 * 100) 'A3
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6290), strPowerMeter4 * 100) 'B4

                    'frmSequence.lblPowerMeterTop4.Text = strPowerMeter4
                    'frmSequence.lblTopTime4.Text = strTopTime4

                End If

            End If
        Loop

        'New연산자 해제
        LoadData_Log = Nothing

        Return True
    End Function

    Public Function PowerMeterStageLog(ByVal ipFilePath As String)
        Dim LoadData_Log As New StreamReader(ipFilePath)
        Dim tmpStrData As String = ""
        Dim strExGlass1 As String = "PowerMeter1 Stage"
        Dim strExGlass2 As String = "PowerMeter2 Stage"
        Dim strExGlass3 As String = "PowerMeter3 Stage"
        Dim strExGlass4 As String = "PowerMeter4 Stage"
        Dim ipCmd As String = "["
        Dim ipCmd2 As String = "]"
        Dim ipCmd3 As String = "::"
        Dim strLine() As String

        Dim strTime() As String
        Dim tmpStrAddress As String = ""

        Do While LoadData_Log.EndOfStream = False
            tmpStrData = LoadData_Log.ReadLine()

            If tmpStrData.Contains("PowerMeter1 Stage") = True Then
                If strExGlass1 = "PowerMeter1 Stage" Then

                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)


                    strLine = Split(tmpStrData, ipCmd3)

                    strStageTime1 = strTime(0)
                    strPowerMeter1 = strLine(1)

                    frmSequence.lblPowerMeterStage1.Text = strPowerMeter1
                    frmSequence.lblStageTime1.Text = strStageTime1

                    tmpStrAddress = Hex(592)
                    '20190729
                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6311), strPowerMeter1 * 100) 'A2
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6341), strPowerMeter1 * 100) 'B1

                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6312), strPowerMeter1 * 100) 'A2
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6342), strPowerMeter1 * 100) 'B1

                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6231), strPowerMeter1 * 100) 'A2
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6261), strPowerMeter1 * 100) 'B1

                    'frmSequence.lblPowerMeterStage1.Text = strPowerMeter1
                    'frmSequence.lblStageTime1.Text = strStageTime1

                End If

            ElseIf tmpStrData.Contains("PowerMeter2 Stage") = True Then
                If strExGlass2 = "PowerMeter2 Stage" Then

                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)


                    strLine = Split(tmpStrData, ipCmd3)

                    strStageTime2 = strTime(0)
                    strPowerMeter2 = strLine(1)

                    frmSequence.lblPowerMeterStage2.Text = strPowerMeter2
                    frmSequence.lblStageTime2.Text = strStageTime2

                    tmpStrAddress = Hex(593)
                    'pMelsec.SendDataWord(Val("&H" & tmpStrAddress), strPowerMeter1)
                    '20190729
                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6301), strPowerMeter2 * 100) 'A1
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6351), strPowerMeter2 * 100) 'B2

                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6302), strPowerMeter2 * 100) 'A1
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6352), strPowerMeter2 * 100) 'B2
                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6221), strPowerMeter2 * 100) 'A1
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6271), strPowerMeter2 * 100) 'B2

                    'frmSequence.lblPowerMeterStage2.Text = strPowerMeter2
                    'frmSequence.lblStageTime2.Text = strStageTime2
                End If

            ElseIf tmpStrData.Contains("PowerMeter3 Stage") = True Then
                If strExGlass3 = "PowerMeter3 Stage" Then

                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)


                    strLine = Split(tmpStrData, ipCmd3)

                    strStageTime3 = strTime(0)
                    strPowerMeter3 = strLine(1)

                    frmSequence.lblPowerMeterStage3.Text = strPowerMeter3
                    frmSequence.lblStageTime3.Text = strStageTime3

                    'tmpStrAddress = Hex(594)
                    'pMelsec.SendDataWord(Val("&H" & tmpStrAddress), strPowerMeter1)
                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6331), strPowerMeter3 * 100) 'A4
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6361), strPowerMeter3 * 100) 'B3

                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6332), strPowerMeter3 * 100) 'A4
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6362), strPowerMeter3 * 100) 'B3

                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6251), strPowerMeter3 * 100) 'A4
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6281), strPowerMeter3 * 100) 'B3


                End If

            ElseIf tmpStrData.Contains("PowerMeter4 Stage") = True Then
                If strExGlass4 = "PowerMeter4 Stage" Then

                    strTime = Split(tmpStrData, ipCmd)
                    strTime = Split(strTime(1), ipCmd2)


                    strLine = Split(tmpStrData, ipCmd3)

                    strStageTime4 = strTime(0)
                    strPowerMeter4 = strLine(1)

                    frmSequence.lblPowerMeterStage4.Text = strPowerMeter4
                    frmSequence.lblStageTime4.Text = strStageTime4

                    'RMS
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6321), strPowerMeter4 * 100) 'A3
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6371), strPowerMeter4 * 100) 'B4
                    '추가2018.09.12
                    '원영식 선임의 요청 레이저 % 게이지가 아니라 W(와트)값 요청
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6322), strPowerMeter4 * 100) 'A3
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6372), strPowerMeter4 * 100) 'B4

                    'APD
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6241), strPowerMeter4 * 100) 'A3
                    pMXComponent.WriteWordIntegerByAddress(Val("&H" & 6291), strPowerMeter4 * 100) 'B4

                End If

            End If
        Loop

        'New연산자 해제
        LoadData_Log = Nothing
        Return True

    End Function

    Public Sub PowerMeterRMSLoad(ByVal intKeepDate As Integer)
        '20190822 joo
        '마지막 파워 데이터 저장 경로 
        Dim strFilePath As String
        strFilePath = "C:\Chamfering System\DEFAULT.ini"

        PowerMeterTop_New(strFilePath)
        PowerMeterStage_New(strFilePath)
        '            PowerMeterTopLog(strLastFileName)
        '            PowerMeterStageLog(strLastFileName)

    End Sub


    '    Public Sub PowerMeterRMSLoad(ByVal intKeepDate As Integer)
    '        Dim strCurrnetLogFile As String
    '        Dim strFile() As String
    '        Dim strFileName() As String
    '
    '        Dim strlog As String = ".log"
    '
    '        If System.IO.Directory.Exists(strRootPath) = False Then
    '            System.IO.Directory.CreateDirectory(strRootPath)
    '        End If
    '
    '        strFile = System.IO.Directory.GetFiles(strRootPath)
    '
    '        ReDim strFileName(strFile.Length - 1)
    '        For i As Integer = 0 To strFile.Length - 1
    '            strFileName(i) = GetFileName(strFile(i), True)
    '        Next
    '
    '        Try
    '            strCurrnetLogFile = Format(CDate(Now.AddDays(-intKeepDate)), "yyyy-MM-dd")
    '            strLastFileName = strRootPath & strCurrnetLogFile & strlog
    '
    '            PowerMeterTopLog(strLastFileName)
    '            PowerMeterStageLog(strLastFileName)
    '
    '        Catch ex As Exception
    '        End Try
    '
    '    End Sub

End Module
