Module modPub
    Public pStrTmpSystemRoot As String = GetSetting("LASER_CHAMFERING", "SYSTEM", "FILE_PATH", "C:\Chamfering System\DEFAULT.ini")
    Public pStrTmpSystemLaser As String = GetSetting("LASER_CHAMFERING", "SYSTEM", "FILE_PATH", "C:\Chamfering System\Recipe\DEFAULT.ini") 'RYO

    Public pLight As New clsLVSCN40X
    Public pCPU_Status As New clsStatus_CPU
    'Public pScanner1 As New clsScanner
    ' Public pScanner2 As New clsScanner

    'Public pScanner(0 To 3) As clsRTC6
    Public pScanner(0 To 3) As clsRTC6
    'Public pScannerThread As clsRTC6Thread
    Public pScannerThread As clsRTC6Thread

    Public pLaser(0 To 3) As clsLaser
    'Public pLaser(0 To 3) As clsModigm

    Public pCamera(3) As Camera

    Public pChiller(3) As clsChiller
    Public pChillerThread As clsChillerThread
    Public pLog As New clsLog
    Public pMelsec As New clsMelsec
    Public pMXComponent As New MxComponent
    Public pLDLT As New clsLDLT
    Public pDisplace As New clsDisplace
    Public pDisplaceThread As clsDisplaceThread
    Public pDisplacePlcThread As clsDisplacePlcThread

    Public pPowerMeter(0 To 4) As clsPowerMeter
    Public pPowerMeterThread As clsPowerMeterThread
    'Public pPowerMeterStage As New clsPowerMeter

    Public pDustCollector(0 To 1) As clsDustCollector
    'Public pAlarm As New clsAlarmMonitoringSequence  'Alarm Merge 'sbs
    Public pDustInverter(0 To 1) As clsLS_Inverter

    Public pMil As New MilImageProcessor

    Public pnVisionCenterX As Integer = 670
    Public pnVisionCenterY As Integer = 520

    'Public pnUseVisionCh As Integer = 0

    Public pnLightCh(1, 1) As Integer       ' line, camera
    Public pnVisionLightA2 As Integer = 4
    Public pnVisionLightB1 As Integer = 2
    Public pnVisionLightB2 As Integer = 1

    'GYN - Mark 그리는 용도 사용.
    Public bmBack As Bitmap
    Public grBack As Graphics
    Public DrawData As tagDraw


    'GYN - Align1, 2 그리는 용도
    Public bmBackAlign1 As Bitmap
    Public grBackAlign1 As Graphics
    Public bmBackAlign2 As Bitmap
    Public grBackAlign2 As Graphics
    Public DrawDataAlign1 As tagDraw
    Public DrawDataAlign2 As tagDraw


    ''20160826 JCM
    Public pbSettingVision As Boolean = False
    Public pnVisionSetArea As Integer = 9999

    'GYN - Add
    Public pMouseMove As Boolean = False

    'song - 20170917-전역으로 쓰려고 위치변경
    Public pbMsgUp As Boolean = False  'Alarm Merge

    'GYN - Add Laser Flag
    Public pbLaserOn As Boolean = False
    Public pbLaserOff As Boolean = False

    '변위센서 자동 시퀀스 - by Song
    Public pnSelectPosition As Integer = 4
    Public pbSelectposition() As Boolean
    Public pdValueX() As Double
    Public pdValueY() As Double
    Public pdIndex() As String
    Public pnMaxCnt As Integer
    Public pnLine As Integer
    Public pbRead As Boolean
    Public m_DirDisplaceRcp As String = "C:\Chamfering System\Setting\Displace\DisplaceRcp.ini"
    Public m_DirDisplaceDatasavePath As String = "C:\Chamfering System\Setting\Displace\DisplaceData.ini"
    Public DisplaceDataRead As Boolean = False
    Public DisplaceDataReadok As Boolean = False
    Public DisplaceMeasureEnd As Boolean = False
    Public dp_strLine As String = "A"
    Public m_strMsg As String

    'Auto Focus Seq
    Public nfocusseq As Integer = 0
    Public pScanPosZ As Double = 0   '스캐너 작업 위치
    Public pScanNum As Integer = 0   '스캐너 z축 넘버
    Public pbLine As Integer = 0
    Public pbStageX As Double = 0.0
    Public pbStageY As Double = 0.0
    Public pbScannerZ As Double = 0.0
    Public pbRepeat As Integer = 0
    Public pbLineAxis As Boolean = True   'true = X축 false = Y축
    Public pbScannerZup As Boolean = True  'true = + false = -
    Public pbStageup As Boolean = True  'true = + false = -
    Public pbPitch As Double = 0.0

    Public Structure Position
        Dim x As Double
        Dim y As Double
    End Structure

    Structure tagDraw
        Dim OffX As Integer
        Dim OffY As Integer
        Dim Scale As Double
        Dim CenterX As Integer
        Dim CenterY As Integer
        Dim SizeX As Integer
        Dim SizeY As Integer
        Dim CrossSize As Double
    End Structure



    Public Enum Axis
        x = 0
        y = 1
        cam_z = 2
    End Enum

    Public Enum LINE
        A = 0
        B = 1
    End Enum

    Public Enum Panel
        p1 = 0
        p2
        p3
        p4
    End Enum

    '20161108 JCM
    Enum AlignMark          'Panel과 같은 개념이지만.. 쫌 다른? 판넬과 마크를 동시 구분하기위해 씀.
        Panel1_Mark1 = 0
        Panel1_Mark2 = 1
        Panel2_Mark1 = 2
        Panel2_Mark2 = 3
        Panel3_Mark1 = 4
        Panel3_Mark2 = 5
        Panel4_Mark1 = 6
        Panel4_Mark2 = 7
    End Enum

    Public Enum AlignMarkNumber
        Mark1 = 0
        Mark2 = 1
    End Enum

    'LASER <-> SCANNER 매칭하여 사용 할 것.!
    Public Enum RTC6_NO
        RTC6_NO_1 = 1
        RTC6_NO_2 = 2
        RTC6_NO_3 = 3
        RTC6_NO_4 = 4
    End Enum

    Public Enum CrossLineAutoseq
        SEQ_STOP = 0
        SEQ_INIT
        SEQ_MOVETOSTAGE
        SEQ_LASERSHOT
        SEQ_MOVETOVISION
    End Enum

    Public Enum CrossLineMode
        MODE_MANUAL = 0
        MODE_AUTO
    End Enum

    '20161122 GYN - Login 기능 추가
    Public bLogInUser As Boolean = False
    Public bLogInTech As Boolean = False
    Public bLogInAdmin As Boolean = False
    Public bModelRecipe As Boolean = False


    '20170523 GYN - 
    Public bLangeChange As Boolean = False

    '20170607 GYN - Align Pass
    Public bAlignPass As Boolean = False


#Region "INI functions"
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileInt Lib "kernel32.dll" Alias "GetPrivateProfileIntA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal nDefault As Integer, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function FlushPrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As Integer, ByVal lpKeyName As Integer, ByVal lpString As Integer, ByVal lpFileName As String) As Integer


    Public Function IsAllInit()
        Dim bInit As Boolean = True

        For i = 0 To 3
            'bInit = pLaser(i).bConnect(i)
            bInit = pLaser(i).m_bLaserInit
            If bInit = False Then
                Return bInit
            End If

            bInit = pScanner(i).pStatus.bInit
            If bInit = False Then
                Return bInit
            End If

            bInit = pChiller(i).ChillerComm.IsOpen
            If bInit = False Then
                Return bInit
            End If

            bInit = pCamera(i).m_bConnected
            If bInit = False Then
                Return bInit
            End If
            'bInit = pPowerMeter(i).PowerMeterStatus.bConnect
            'If bInit = False Then
            '    Return bInit
            'End If
        Next

        'bInit = pPowerMeter(4).PowerMeterStatus.bConnect
        bInit = pDustCollector(0).IsOpen()
        'bInit = pDustCollector(1).IsOpen()

        bInit = pLight.IsOpen()

        bInit = pLDLT.pbConnect

        Return bInit

    End Function

    Public Sub Init()

        For i As Integer = 0 To 3
            pScanner(i) = New clsRTC6()
            pScanner(i).m_iIndex = i

            pLaser(i) = New clsLaser()
            pLaser(i).m_iIndex = i
            'pLaser(i) = New clsModigm()
            'pLaser(i).m_iIndex = i

            pPowerMeter(i) = New clsPowerMeter()
            pPowerMeter(i).m_iIndex = i

            pChiller(i) = New clsChiller()
            pChiller(i).m_iIndex = i

            pCamera(i) = New Camera
            'pCamera(i).m_iIndex = i

        Next

        pScanner(0).SetRTC6Num(RTC6_NO.RTC6_NO_1)
        pScanner(1).SetRTC6Num(RTC6_NO.RTC6_NO_2)
        pScanner(2).SetRTC6Num(RTC6_NO.RTC6_NO_3)
        pScanner(3).SetRTC6Num(RTC6_NO.RTC6_NO_4)

        pPowerMeter(4) = New clsPowerMeter()
        pPowerMeter(4).m_iIndex = 4

        pPowerMeterThread = New clsPowerMeterThread
        pPowerMeterThread.StartPowerMeter()

        pChillerThread = New clsChillerThread
        pChillerThread.StartChiller()

        pScannerThread = New clsRTC6Thread
        pScannerThread.StartScanner()

        pDisplaceThread = New clsDisplaceThread
        pDisplaceThread.StartDisplace()

        pDisplacePlcThread = New clsDisplacePlcThread
        pDisplacePlcThread.StartDisplacePlc()

        For i = 0 To 1
            pDustCollector(i) = New clsDustCollector()
            pDustCollector(i).m_iCh = i + 1
        Next

        pLDLT.StartMXComponent()
    End Sub

    Public Function GetString(ByVal ipSection As String, ByVal ipKey As String, ByVal ipDefault As String, ByVal ipFilename As String) As String
        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(256)

        GetString = ""

        Try
            intCharCount = GetPrivateProfileString(ipSection, ipKey, ipDefault, objResult, objResult.Capacity, ipFilename)

            If intCharCount > 0 Then
                GetString = Left(objResult.ToString, intCharCount)
            End If

        Catch ex As Exception
            GetString = ""
        End Try

        objResult = Nothing
    End Function

    Public Sub WriteString(ByVal ipSection As String, ByVal ipKey As String, ByVal ipValue As String, ByVal ipFilename As String)
        WritePrivateProfileString(ipSection, ipKey, ipValue, ipFilename)
        FlushPrivateProfileString(0, 0, 0, ipFilename)

    End Sub

    Public Function ReadIni(ByVal strSection As String, ByVal strKey As String, ByVal strDefault As String, ByVal strFileName As String) As String
        On Error GoTo SysErr
        Dim strResult As String

        strResult = GetString(strSection, strKey, strDefault, strFileName)
        ReadIni = IIf(strResult Is Nothing, strDefault, strResult)

        Exit Function
SysErr:
        ReadIni = ""
    End Function
    Public Sub WriteIni(ByVal strSection As String, ByVal strKey As String, ByVal strValue As String, ByVal strFileName As String)
        On Error GoTo SysErr

        WriteString(strSection, strKey, strValue, strFileName)

        Exit Sub
SysErr:
    End Sub
#End Region

    Public Sub ConvertPicPosToField(ByVal ipX As Double, ByVal ipY As Double, ByRef rtnX As Double, ByRef rtnY As Double)
        On Error GoTo SysErr

        Dim tmpX, tmpY As Double

        rtnX = ((ipX - DrawData.CenterX) / DrawData.Scale) + DrawData.OffX
        rtnY = ((DrawData.SizeY - ipY - DrawData.CenterY) / DrawData.Scale) + DrawData.OffY

        Exit Sub
SysErr:
        Dim strErr As String = Err.Description
    End Sub

    Public Sub ConvertFieldToPicPos(ByVal ipX As Double, ByVal ipY As Double, ByRef rtnX As Double, ByRef rtnY As Double)
        On Error GoTo SysErr

        Dim tmpX, tmpY As Double

        tmpX = (ipX + DrawData.OffX) * DrawData.Scale
        tmpY = (ipY + DrawData.OffY) * DrawData.Scale
        rtnX = DrawData.CenterX + tmpX
        rtnY = DrawData.CenterY - tmpY

        Exit Sub
SysErr:
        Dim strErr As String = Err.Description
    End Sub

    Public Sub DrawRect(ByVal ipGr As Graphics, ByVal ipX1 As Double, ByVal ipY1 As Double, ByVal ipX2 As Double, ByVal ipY2 As Double, ByVal ipPen As Pen, Optional ByVal bClr As Boolean = False)
        On Error GoTo SysErr
        Dim tmpWidth, tmpHeight As Integer
        Dim picX, picY, picX2, picY2 As Integer

        ConvertFieldToPicPos(ipX1, ipY1, picX, picY)
        ConvertFieldToPicPos(ipX2, ipY2, picX2, picY2)

        If picX2 > picX Then
            tmpWidth = CInt(picX2 - picX)
        Else
            tmpWidth = CInt(picX - picX2)
        End If
        If picY2 > picY Then
            tmpHeight = CInt(picY2 - picY)
        Else
            tmpHeight = CInt(picY - picY2)
        End If

        ipGr.DrawRectangle(ipPen, picX - tmpWidth, picY - tmpHeight, tmpWidth * 2, tmpHeight * 2)

        Exit Sub
SysErr:
    End Sub

    Public Sub DrawLine(ByVal ipGr As Graphics, ByVal ipX1 As Double, ByVal ipY1 As Double, ByVal ipX2 As Double, ByVal ipY2 As Double, ByVal ipPen As Pen, Optional ByVal bClr As Boolean = False)
        On Error GoTo SysErr
        Dim picX, picY, picX2, picY2 As Integer
        Dim First As Point
        Dim Second As Point

        ConvertFieldToPicPos(ipX1, ipY1, picX, picY)
        ConvertFieldToPicPos(ipX2, ipY2, picX2, picY2)
        First = New Point(picX, picY)
        Second = New Point(picX2, picY2)

        ipGr.DrawLine(ipPen, First, Second)

        First = Nothing
        Second = Nothing
        Exit Sub
SysErr:

    End Sub

    Public Sub DrawArc(ByVal ipGr As Graphics, ByVal ipX As Integer, ByVal ipY As Integer, ByVal ipWidth As Integer, ByVal ipdeg1 As Single, ByVal ipdeg2 As Single, ByVal ipPen As Pen, Optional ByVal bClr As Boolean = False)
        On Error GoTo SysErr

        Dim picX, picY, picX2, picY2 As Integer
        ConvertFieldToPicPos(ipX, ipY, picX, picY)
        ConvertFieldToPicPos(ipWidth, ipWidth, picX2, picY2)

        picX2 = Math.Abs(picX - picX2) * 2
        picX = picX - (picX2 / 2)
        picY = picY - (picX2 / 2)
        If picX2 = 0 Then picX2 = 1
        If picX2 < 0 Then picX2 = picX2 * -1

        ipGr.DrawArc(ipPen, picX, picY, picX2, picX2, ipdeg1, ipdeg2)

        Exit Sub
SysErr:
    End Sub
    Public Sub DrawArcCnR(ByVal ipGr As Graphics, ByVal ipEx As Double, ByVal ipEy As Double, ByVal ipCX As Double, ByVal ipCY As Double, ByVal ipdeg1 As Single, ByVal ipdeg2 As Single, ByVal ipPen As Pen, Optional ByVal bClr As Boolean = False)
        On Error GoTo SysErr

        Dim picX, picY, picX2, picY2 As Single
        Dim dist As Single
        Dim diffx, diffy As Single
        ConvertFieldToPicPos(ipCX, ipCY, picX, picY)
        ConvertFieldToPicPos(ipEx, ipEy, picX2, picY2)
        dist = Point2PointDistant(picX, picY, picX2, picY2)
        Dim An As Single
        diffx = picX2 - picX
        diffy = picY2 - picY
        An = Math.Atan2(diffy, diffx) * 180.0 / Math.PI

        ipGr.DrawArc(ipPen, picX - dist, picY - dist, dist * 2, dist * 2, An, ipdeg2)

        Exit Sub
SysErr:
    End Sub


    Public Function MeasureAngle(ByVal ipPosX1 As Double, ByVal ipPosY1 As Double, ByVal ipPosX2 As Double, ByVal ipPosY2 As Double) As Double

        Dim tmpAngle As Double
        Dim tmpAnglePosX As Double = ipPosX2
        Dim tmpAnglePosY As Double = ipPosY1

        If ipPosY1 = ipPosY2 Then
            tmpAngle = 0
            Return tmpAngle
        Else
            tmpAngle = Math.Atan2(ipPosY1 - ipPosY2, ipPosX2 - ipPosX1) * 180 / Math.PI
        End If

        If tmpAngle < 0 Then
            tmpAngle += 360
        End If

        Return tmpAngle

        Exit Function

    End Function

    Public Function GetCircleDegreePos(ByVal ipRadius As Double, ByVal ipCircleCenterX As Double, ByVal ipCircleCenterY As Double, ByVal ipAngle As Double, _
                                     ByRef OutPosX As Double, ByRef OutPosY As Double) As Boolean
        On Error GoTo SysErr


        Dim tmpRad As Double = ipAngle - 180 * (Math.PI / 180)
        OutPosX = Math.Cos(tmpRad) * ipRadius + ipCircleCenterX
        OutPosY = Math.Sin(tmpRad) * ipRadius + ipCircleCenterY

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Function AdjustAngle(ByRef PosX As Double, ByRef PosY As Double, ByVal ipAngle As Double) As Boolean
        On Error GoTo SysErr
        Dim tmpAngle As Double = ipAngle
        Dim tmpPosX As Double = PosX
        Dim tmpPosY As Double = PosY

        tmpAngle = ipAngle * Math.PI / 180

        PosX = CDbl(tmpPosX * Math.Cos(tmpAngle) - tmpPosY * Math.Sin(tmpAngle))
        PosY = CDbl(tmpPosY * Math.Cos(tmpAngle) + tmpPosX * Math.Sin(tmpAngle))

        Return True
        Exit Function
SysErr:

        Return False
    End Function

    Public Function MeasureAngleDeg(ByVal ipPosX1 As Double, ByVal ipPosY1 As Double, ByVal ipPosX2 As Double, ByVal ipPosY2 As Double) As Double
        On Error GoTo SysErr
        Dim tmpAngle As Double
        Dim tmpAnglePosX As Double = ipPosX2
        Dim tmpAnglePosY As Double = ipPosY1
        Dim tmpPosX As Double = ipPosX2 - ipPosX1
        Dim tmpPosY As Double = ipPosY2 - ipPosY1

        If ipPosY1 = ipPosY2 Then
            tmpAngle = 0
            Return tmpAngle
        Else
            If (tmpPosX > tmpPosY) Then
                tmpAngle = Math.Atan2(tmpPosY, tmpPosX) * 180 / Math.PI
            Else
                tmpAngle = Math.Atan2(tmpPosX, tmpPosY) * 180 / Math.PI
            End If
        End If

        MeasureAngleDeg = -Math.Round(tmpAngle, 3)

        Exit Function
SysErr:
        MeasureAngleDeg = 0
    End Function

    Public Sub SystemLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "System")

        frmLog.lBoxLog.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & "  :  " & strContext)

        Exit Sub
SysErr:

    End Sub

    Public Sub SequenceLog(ByVal nLine As String, ByVal strContext As String)
        On Error GoTo SysErr

        If nLine = LINE.A Then

            pLog.LogWrite(strContext, "Sequence_A")

        ElseIf nLine = LINE.B Then

            pLog.LogWrite(strContext, "Sequence_B")

        End If

        Exit Sub
SysErr:

    End Sub

    Public Sub PowerMeterLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "PowerMeter")

        Exit Sub
SysErr:

    End Sub
    Public Sub ErrorLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Error")

        Exit Sub
SysErr:
    End Sub

    Public Sub WarningLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Warning")

        Exit Sub
SysErr:
    End Sub

    Public Sub AlignDataLog(ByVal nLine As Integer, ByVal nPanel As Integer, ByVal strContext As String)
        On Error GoTo SysErr

        If nLine = LINE.A Then
            Select Case nPanel
                Case 0
                    pLog.LogWrite(strContext, "AlignData\A1")
                Case 1
                    pLog.LogWrite(strContext, "AlignData\A2")
                Case 2
                    pLog.LogWrite(strContext, "AlignData\A3")
                Case 3
                    pLog.LogWrite(strContext, "AlignData\A4")
            End Select
        ElseIf nLine = LINE.B Then
            Select Case nPanel
                Case 0
                    pLog.LogWrite(strContext, "AlignData\B1")
                Case 1
                    pLog.LogWrite(strContext, "AlignData\B2")
                Case 2
                    pLog.LogWrite(strContext, "AlignData\B3")
                Case 3
                    pLog.LogWrite(strContext, "AlignData\B4")
            End Select
        End If

        Exit Sub
SysErr:

    End Sub

    Public Sub TacLog(ByVal nLine As String, ByVal strContext As String)
        On Error GoTo SysErr

        If nLine = LINE.A Then

            pLog.LogWrite(strContext, "Tac_A")

        ElseIf nLine = LINE.B Then

            pLog.LogWrite(strContext, "Tac_B")

        End If

        Exit Sub
SysErr:

    End Sub

    Public Sub TacLog_A(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Tac_A")

        Exit Sub
SysErr:

    End Sub

    Public Sub TacLog_B(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Tac_B")

        Exit Sub
SysErr:

    End Sub

    Public Sub ParamLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Param")

        Exit Sub
SysErr:

    End Sub

    Public Sub MelsecLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Melsec")

        Exit Sub
SysErr:

    End Sub

    Public Sub TestLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Test")

        Exit Sub
SysErr:

    End Sub

    Public Sub AlignSubMarkLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "AlignSubMarkLog")

        Exit Sub
SysErr:

    End Sub
    Public Sub MarkDataChangeLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "MarkDataChangeLog")

        frmMarkChangeMSG.listChangeData.Items.Add(Format(Now, "yyyy-MM-dd HH:mm:ss") & "  :  " & strContext)
        Exit Sub
SysErr:

    End Sub

    '20180801 알람로그 추가
    Public Sub AlramLog(ByVal strContext As String)
        On Error GoTo SysErr

        pLog.LogWrite(strContext, "Alram")

        Exit Sub
SysErr:

    End Sub

    Public Function GetFileFolder(ByVal ipStrFile As String, ByVal ipNum As Integer) As String
        On Error GoTo SysErr
        Dim tmpArrStr() As String = {}
        Dim tmpOutPath As String = ""

        tmpArrStr = Split(ipStrFile, "\")

        If tmpArrStr.Length - 2 - ipNum < 0 Then
            Return ""
            Exit Function
        Else
            For i As Integer = 0 To tmpArrStr.Length - 2 - ipNum
                If i = 0 Then
                    tmpOutPath = tmpOutPath & tmpArrStr(i)
                Else
                    tmpOutPath = tmpOutPath & "\" & tmpArrStr(i)
                End If
            Next
        End If


        Return tmpOutPath

        Exit Function
SysErr:

    End Function

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

End Module
