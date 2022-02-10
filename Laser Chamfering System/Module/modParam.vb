Module modParam

    Structure SystemParameter
        Dim strSystemRootPath As String
        Dim strSystemLogPath As String
        Dim strAlignImagePath() As String
        Dim strScannerSettingPath As String
        Dim strLastModelFilePath As String
        'GYN - 2017.04.01 - Pen DATA - Recipe 100개에 대한 정보 저장 Path
        Dim strRecipePenDataFile As String
        'GYN - 2017.04.12 - DigitalIO File
        Dim strDigitalXFile As String
        Dim strDigitalYFile As String

        'CHY - 2017.08.19 - PLC Bit Data File
        Dim strPCBitFile As String
        Dim strPLCBitFile As String
        'CHY - 2017.11.02 - Word Data File
        Dim strPCWordFile As String
        Dim strPLCWordFile As String

        Dim strModelList() As String

        Dim strScannerCorFilePath() As String
        Dim strScannerHexFilePath() As String
        Dim nScannerScanScale() As Integer

        Dim dVisionLaserOffsetX(,) As Double       ' index : Line, Laser
        Dim dVisionLaserOffsetY(,) As Double

        Dim nPortLaser() As Integer
        Dim nPortChiller() As Integer
        Dim nPortLight As Integer
        Dim nPortPowerMeter() As Integer
        Dim nPortPowerMeterStage As Integer
        Dim nPortDustCollecter() As Integer
        Dim nPortDustInverter() As Integer
        Dim nPortDisplace As Integer

        Dim strChillerWaterSetDay() As String
        Dim nChillerWaterDay() As Integer
        Dim strChillerFilterSetDay() As String
        Dim nChillerFilterDay() As Integer

        Dim nScanHalfPulseWith() As Integer
        Dim nScanPulseWidth1() As Integer
        Dim nScanPulseWidth2() As Integer
        Dim nScanLaserOnDelay() As Integer
        Dim nScanLaserOffDelay() As Integer
        Dim nScanJumpDelay() As Integer
        Dim nScanMarkDelay() As Integer
        Dim nScanPolygonDelay() As Integer
        Dim nScanJumpSpeed() As Integer
        Dim nScanMarkSpeed() As Integer


        Dim nPowerMeterTime As Integer
        Dim nTrimmingDelay As Integer
        Dim nVisionAlignDelay As Integer
        Dim nVisionAlignRetryDelay As Integer

        Dim nDustTimer As Integer  '분단위

        Dim nScanMarkSpdLimt As Integer
        Dim nScanJumpSpdLimt As Integer
        Dim nImageSaveDay As Integer
        Dim nLogSaveDay As Integer

        Dim dVisionScaleX(,) As Double      ' line, camera
        Dim dVisionScaleY(,) As Double      ' line, camera
        Dim dVisionTheta(,) As Double       ' line, camera

        Dim nSystem As Integer
        Dim strVersion As String
        'GYN - 2017.03.14 - 조명ON/OFF Add
        Dim nLightUse As Integer

        'GYN - 2017.04.01 - Pen Data
        Dim TotalCnt() As Integer      'Total Cnt (MarkPenData Cnt)
        Dim LaserPower(,) As Double     'RecipeNum, Laser Cnt
        Dim RecipePen() As MarkPenData

        'GYN - 2017.04.12 - I/O Board List 생성
        Dim nTotalCntDigitalIOX As Integer
        Dim strDigitalIOFile As String

		'2017.04.25 - 변위센서 by Song
        Dim dDisplacePosX() As Double
        Dim dDisplacePosY() As Double

        Dim dLaserPower() As Double

        Dim nLaserPowerMaxLimit As Integer
        Dim nLaserPowerMinLimit As Integer

        Dim btnCameraAUse As Integer
        Dim btnCameraBUse As Integer
        '20200317 카메라 사용모드
        Dim btnCameraUseMode() As Integer
        Dim btnCameraUseMode_A1 As Integer
        Dim btnCameraUseMode_A2 As Integer
        Dim btnCameraUseMode_B1 As Integer
        Dim btnCameraUseMode_B2 As Integer



        Public Sub Init()
            ReDim strChillerWaterSetDay(3)
            ReDim strAlignImagePath(1)  ' a, b line
            ReDim nChillerWaterDay(3)
            ReDim strChillerFilterSetDay(3)
            ReDim nChillerFilterDay(3)
            ReDim dVisionLaserOffsetX(1, 3)         ' index : Line, Laser
            ReDim dVisionLaserOffsetY(1, 3)         'As Double
            ReDim nPortPowerMeter(4)
            ReDim nPortDustCollecter(1)
            ReDim nPortDustInverter(1)
            ReDim nPortLaser(3)
            ReDim nPortChiller(3)
            ReDim dVisionScaleX(1, 1)           ' line, cam index
            ReDim dVisionScaleY(1, 1)
            ReDim dVisionTheta(1, 1)
			ReDim dDisplacePosX(3)
            ReDim dDisplacePosY(3)
            ReDim dLaserPower(3)

            ReDim nScanHalfPulseWith(3)
            ReDim nScanPulseWidth1(3)
            ReDim nScanPulseWidth2(3)
            ReDim nScanLaserOnDelay(3)
            ReDim nScanLaserOffDelay(3)
            ReDim nScanJumpDelay(3)
            ReDim nScanMarkDelay(3)
            ReDim nScanPolygonDelay(3)
            ReDim nScanJumpSpeed(3)
            ReDim nScanMarkSpeed(3)

            ReDim strScannerHexFilePath(3)
            ReDim strScannerCorFilePath(3)
            ReDim nScannerScanScale(3)
            '20200317 카메라 사용모드
            ReDim btnCameraUseMode(3)
        End Sub
    End Structure

    Public pCurSystemParam As SystemParameter
    Public pSetSystemParam As SystemParameter

    Structure DigitalIOParameter

        Dim nBoardCnt As Integer
        Dim nTotalCnt As Integer
        Dim strIONo(,) As String
        Dim strIODescription(,) As String

        Public Sub Init()

            ReDim strIONo(nBoardCnt, nTotalCnt)
            ReDim strIODescription(nBoardCnt, nTotalCnt)

        End Sub

    End Structure

    '20171102 Bit Data
    'Public mPCBit_BoardCnt As Integer = 0
    'Public mPLCBit_BoardCnt As Integer = 0
    'Public mPCWord_BoardCnt As Integer = 0
    'Public mPLCWord_BoardCnt As Integer = 0

    'Public pCurDigitalIOParamX As DigitalIOParameter
    'Public pCurDigitalIOParamY As DigitalIOParameter

    'Public pCurPCBitData As DigitalIOParameter
    'Public pCurPLCBitData As DigitalIOParameter

    'Public pCurPCWordData As DigitalIOParameter
    'Public pCurPLCWordData As DigitalIOParameter

    Public Sub Init()
        pCurSystemParam.Init()
        pSetSystemParam.Init()
    End Sub

    '20161028 JCM EDIT TEST
    'Public dTrimmingPosX_A As Double = 648.372
    'Public dTrimmingPosY_A As Double = 771.14

    'Public dTrimmingPosX_B As Double = 668.543
    'Public dTrimmingPosY_B As Double = 768.408


    'CHY - 2017.08.17 - PC Bit Data
    'Public Function LoadPCBit(ByVal strFilePath As String, ByRef ipParam As DigitalIOParameter) As Boolean
    '    ipParam.nBoardCnt = ReadIni("DATA", "PCBIT_CNT", 0, strFilePath)
    '    ipParam.nTotalCnt = ReadIni("DATA", "BIT_CNT", 32, strFilePath)
    '    ipParam.Init()

    '    For i As Integer = 0 To ipParam.nBoardCnt
    '        For j As Integer = 0 To ipParam.nTotalCnt

    '            ipParam.strIONo(i, j) = ReadIni("PCBIT_" & i, "BIT_NO_" & j, "PC_BitNo", strFilePath)
    '            ipParam.strIODescription(i, j) = ReadIni("PCBIT_" & i, "BIT_DESCRIPTION_" & j, "Description", strFilePath)

    '        Next
    '    Next
    'End Function



    'CHY - 2017.08.17 - PLC Bit Data
    'Public Function LoadPLCBit(ByVal strFilePath As String, ByRef ipParam As DigitalIOParameter) As Boolean
    '    ipParam.nBoardCnt = ReadIni("DATA", "PLCBIT_CNT", 0, strFilePath)
    '    ipParam.nTotalCnt = ReadIni("DATA", "BIT_CNT", 32, strFilePath)
    '    ipParam.Init()

    '    For i As Integer = 0 To ipParam.nBoardCnt
    '        For j As Integer = 0 To ipParam.nTotalCnt

    '            ipParam.strIONo(i, j) = ReadIni("PLCBIT_" & i, "BIT_NO_" & j, "PLC_BitNo", strFilePath)
    '            ipParam.strIODescription(i, j) = ReadIni("PLCBIT_" & i, "BIT_DESCRIPTION_" & j, "Description", strFilePath)

    '        Next
    '    Next
    'End Function




    Public Function LoadDigitalIOX(ByVal strFilePath As String, ByRef ipParam As DigitalIOParameter) As Boolean

        ipParam.nBoardCnt = ReadIni("DATA", "BOARD_CNT", 0, strFilePath)
        ipParam.nTotalCnt = ReadIni("DATA", "IO_CNT", 32, strFilePath)
        ipParam.Init()

        'ReDim ipParam.strIONo(ipParam.nBoardCnt, ipParam.nTotalCnt)
        'ReDim ipParam.strIODescription(ipParam.nBoardCnt, ipParam.nTotalCnt)

        For i As Integer = 0 To ipParam.nBoardCnt
            For j As Integer = 0 To ipParam.nTotalCnt

                ipParam.strIONo(i, j) = ReadIni("BOARD_" & i, "IO_NO_" & j, "IONo_X", strFilePath)
                ipParam.strIODescription(i, j) = ReadIni("BOARD_" & i, "IO_DESCRIPTION_" & j, "Description", strFilePath)

            Next
        Next

    End Function


    Public Function LoadDigitalIOY(ByVal strFilePath As String, ByRef ipParam As DigitalIOParameter) As Boolean

        ipParam.nBoardCnt = ReadIni("DATA", "BOARD_CNT", 0, strFilePath)
        ipParam.nTotalCnt = ReadIni("DATA", "IO_CNT", 32, strFilePath)
        ipParam.Init()

        'ReDim ipParam.strIONo(ipParam.nBoardCnt, ipParam.nTotalCnt)
        'ReDim ipParam.strIODescription(ipParam.nBoardCnt, ipParam.nTotalCnt)

        For i As Integer = 0 To ipParam.nBoardCnt
            For j As Integer = 0 To ipParam.nTotalCnt

                ipParam.strIONo(i, j) = ReadIni("BOARD_" & i, "IO_NO_" & j, "IONo_Y", strFilePath)
                ipParam.strIODescription(i, j) = ReadIni("BOARD_" & i, "IO_DESCRIPTION_" & j, "Description", strFilePath)

            Next
        Next

    End Function

    Public Function LoadParam(ByVal strFilePath As String, ByRef ipSystemParam As SystemParameter) As Boolean
        On Error GoTo SysErr
        Dim nLine As Integer = 0
        Dim str(1) As String

        ReDim ipSystemParam.strModelList(99)
        ipSystemParam.strVersion = ReadIni("FILE_PATH", "PROGRAM_VERSION", "", strFilePath)
        ipSystemParam.strSystemRootPath = ReadIni("FILE_PATH", "SYSTEM_PATH", "C:\Chamfering System", strFilePath)
        ipSystemParam.strSystemLogPath = ReadIni("FILE_PATH", "SYSTEM_LOG_PATH", "C:\Chamfering System\Log", strFilePath)
        ipSystemParam.strAlignImagePath(LINE.A) = ReadIni("FILE_PATH", "A_LINE_ALIGN", "C:\Chamfering System\Image\A Line Align", strFilePath)
        ipSystemParam.strAlignImagePath(LINE.B) = ReadIni("FILE_PATH", "B_LINE_ALIGN", "C:\Chamfering System\Image\B Line Align", strFilePath)
        ipSystemParam.strScannerSettingPath = ReadIni("FILE_PATH", "SCANNER_SETTING_PATH", "C:\Chamfering System\Setting\Scanner", strFilePath)
        ipSystemParam.strRecipePenDataFile = ReadIni("FILE_PATH", "PEN_DATA_FILE", "C:\Chamfering System\Recipe\DEFAULT.ini", strFilePath)
        ipSystemParam.strDigitalXFile = ReadIni("FILE_PATH", "LASER_IO_X", "C:\Chamfering System\Setting\LaserIO\LaserIOX.ini", strFilePath)
        ipSystemParam.strDigitalYFile = ReadIni("FILE_PATH", "LASER_IO_Y", "C:\Chamfering System\Setting\LaserIO\LaserIOY.ini", strFilePath)
        ipSystemParam.strPCBitFile = ReadIni("FILE_PATH", "PCBITData", "C:\Chamfering System\Setting\PLCBitData\PCBIT.ini", strFilePath)
        ipSystemParam.strPLCBitFile = ReadIni("FILE_PATH", "PLCBITData", "C:\Chamfering System\Setting\PLCBitData\PLCBIT.ini", strFilePath)
        ipSystemParam.strPCWordFile = ReadIni("FILE_PATH", "PCWORDData", "C:\Chamfering System\Setting\PLCBitData\PCWORD.ini", strFilePath)
        ipSystemParam.strPLCWordFile = ReadIni("FILE_PATH", "PLCWORDData", "C:\Chamfering System\Setting\PLCBitData\PLCWORD.ini", strFilePath)

        For i = 0 To 3
            ipSystemParam.strScannerCorFilePath(i) = ReadIni("SCANNER_INFO", "SCANNER_COR_FILE_PATH" & (i + 1).ToString, "C:\Chamfering System\Setting\Scanner\20161005_TEMP_B1_REVERSE.ct5", strFilePath)
            ipSystemParam.strScannerHexFilePath(i) = ReadIni("SCANNER_INFO", "SCANNER_HEX_FILE_PATH" & (i + 1).ToString, "C:\Chamfering System\Setting\Scanner", strFilePath)
            ipSystemParam.nScannerScanScale(i) = CInt(ReadIni("SCANNER_INFO", "SCANNER_SCAN_SCALE" & (i + 1).ToString, "1000", strFilePath))
        Next

        str(0) = "A"
        str(1) = "B"

        For nLine = 0 To 1
            For i = 0 To 3
                ipSystemParam.dVisionLaserOffsetX(nLine, i) = CDbl(ReadIni("SYSTEM_OFFSET", str(nLine) & "_LINE_VISION_LASER_OFFSET" & (i + 1).ToString() & "_X", "0.001", strFilePath))
                ipSystemParam.dVisionLaserOffsetY(nLine, i) = CDbl(ReadIni("SYSTEM_OFFSET", str(nLine) & "_LINE_VISION_LASER_OFFSET" & (i + 1).ToString() & "_Y", "0.001", strFilePath))
            Next
        Next

        For i = 0 To 3
            ipSystemParam.nPortLaser(i) = CInt(ReadIni("SYSTEM_PORT", "LASER_" & (i + 1).ToString, (3 + i).ToString, strFilePath))
            ipSystemParam.nPortPowerMeter(i) = CInt(ReadIni("SYSTEM_PORT", "POWER_METER_" & (i + 1).ToString, (11 + i).ToString, strFilePath))
            ipSystemParam.nPortChiller(i) = CInt(ReadIni("SYSTEM_PORT", "CHILLER_" & (i + 1).ToString, (7 + i).ToString, strFilePath))
        Next

        ipSystemParam.nPortPowerMeter(4) = CInt(ReadIni("SYSTEM_PORT", "POWER_METER_STAGE", "17", strFilePath))
        ipSystemParam.nPortLight = CInt(ReadIni("SYSTEM_PORT", "LIGHT", "18", strFilePath))
        ipSystemParam.nPortDisplace = CInt(ReadIni("SYSTEM_PORT", "DISPLACE", "11", strFilePath))

        For i = 0 To 1
            ipSystemParam.nPortDustCollecter(i) = CInt(ReadIni("SYSTEM_PORT", "DUST_COLLECTER_" & (1 + i).ToString, (11 + i * 2).ToString, strFilePath))
            ipSystemParam.nPortDustInverter(i) = CInt(ReadIni("SYSTEM_PORT", "DUST_INVERTER_" & (1 + i).ToString, (12 + i * 2).ToString, strFilePath))
        Next

        For i = 0 To 3
            ipSystemParam.strChillerWaterSetDay(i) = ReadIni("LASER_SET", "LASER_CHILLER_WATER_SET_DAY_" & (i + 1).ToString, "1900-05-01", strFilePath)
            ipSystemParam.nChillerWaterDay(i) = CInt(ReadIni("LASER_SET", "LASER_CHILLER_WATER_SET_" & (i + 1).ToString, "90", strFilePath))
            ipSystemParam.strChillerFilterSetDay(i) = ReadIni("LASER_SET", "LASER_CHILLER_FILTER_SET_DAY_" & (i + 1).ToString, "1900-05-01", strFilePath)
            ipSystemParam.nChillerFilterDay(i) = CInt(ReadIni("LASER_SET", "LASER_CHILLER_FILTER_SET_" & (i + 1).ToString, "90", strFilePath))
        Next

        For i = 0 To 3
            ipSystemParam.nScanHalfPulseWith(i) = CInt(ReadIni("SCANNER_SET", "HALF_PULSE_PERIOD_" & (i + 1).ToString, "100", strFilePath))
            ipSystemParam.nScanPulseWidth1(i) = CInt(ReadIni("SCANNER_SET", "PULSE_WIDTH1_" & (i + 1).ToString, "50", strFilePath))
            ipSystemParam.nScanPulseWidth2(i) = CInt(ReadIni("SCANNER_SET", "PULSE_WIDTH2_" & (i + 1).ToString, "50", strFilePath))
            ipSystemParam.nScanLaserOnDelay(i) = CInt(ReadIni("SCANNER_SET", "LASER_ON_DELAY_" & (i + 1).ToString, "150", strFilePath))
            ipSystemParam.nScanLaserOffDelay(i) = CInt(ReadIni("SCANNER_SET", "LASER_OFF_DELAY_" & (i + 1).ToString, "300", strFilePath))
            ipSystemParam.nScanJumpSpeed(i) = CInt(ReadIni("SCANNER_SET", "JUMP_SPEED_" & (i + 1).ToString, "300", strFilePath))
            ipSystemParam.nScanMarkSpeed(i) = CInt(ReadIni("SCANNER_SET", "MARK_SPEED_" & (i + 1).ToString, "300", strFilePath))
            ipSystemParam.nScanJumpDelay(i) = CInt(ReadIni("SCANNER_SET", "JUMP_DELAY_" & (i + 1).ToString, "250", strFilePath))
            ipSystemParam.nScanMarkDelay(i) = CInt(ReadIni("SCANNER_SET", "MARK_DELAY_" & (i + 1).ToString, "250", strFilePath))
            ipSystemParam.nScanPolygonDelay(i) = CInt(ReadIni("SCANNER_SET", "POLYGON_DELAY_" & (i + 1).ToString, "100", strFilePath))
        Next

        ipSystemParam.nPowerMeterTime = CInt(ReadIni("SYSTEM_DELAY", "POWERMETER_TIME", "60000", strFilePath))
        ipSystemParam.nTrimmingDelay = CInt(ReadIni("SYSTEM_DELAY", "TRIMMING_DELAY", "100", strFilePath))
        ipSystemParam.nVisionAlignDelay = CInt(ReadIni("SYSTEM_DELAY", "ALIGN_DELAY", "100", strFilePath))
        ipSystemParam.nVisionAlignRetryDelay = CInt(ReadIni("SYSTEM_DELAY", "ALIGN_RETRY_DELAY", "100", strFilePath))

        ipSystemParam.nScanMarkSpdLimt = CInt(ReadIni("SYSTEM_ETC", "SCANNER_MARK_SPEED_LIMIT", "50", strFilePath))
        ipSystemParam.nScanJumpSpdLimt = CInt(ReadIni("SYSTEM_ETC", "SCANNER_JUMP_SPEED_LIMIT", "50", strFilePath))
        ipSystemParam.nLogSaveDay = CInt(ReadIni("SYSTEM_ETC", "SYSTEM_LOG_SAVE_DAY", "30", strFilePath))
        ipSystemParam.nImageSaveDay = CInt(ReadIni("SYSTEM_ETC", "SYSTEM_IMAGE_SAVE_DAY", "10", strFilePath))

        '20190807 Laser Power Limit
        ipSystemParam.nLaserPowerMaxLimit = CInt(ReadIni("SYSTEM_ETC", "LASER_POWER_MAX_LIMIT", "100", strFilePath))
        ipSystemParam.nLaserPowerMinLimit = CInt(ReadIni("SYSTEM_ETC", "LASER_POWER_MIN_LIMIT", "0", strFilePath))

        ipSystemParam.nDustTimer = CInt(ReadIni("SYSTEM_ETC", "DUST_TIMER", "10", strFilePath))

        ipSystemParam.strLastModelFilePath = ReadIni("SYSTEM_ETC", "LAST_MODEL", "C:\Chamfering System\Recipe\Default\HPK_Recipe_Dealut.ini", strFilePath)
        ipSystemParam.nSystem = CInt(ReadIni("SYSTEM_ETC", "SYSTEM", "0", strFilePath))

        'GYN - 2017.03.14 - 조명ON/OFF Add
        ipSystemParam.nLightUse = CInt(ReadIni("SYSTEM_ETC", "LIGHT_USE", "1", strFilePath))
        '카메라 사용 여부
        ipSystemParam.btnCameraAUse = CInt(ReadIni("CAMERA_USE_INFO", "CameraALINE_Use", "1", strFilePath))
        ipSystemParam.btnCameraBUse = CInt(ReadIni("CAMERA_USE_INFO", "CameraBLINE_Use", "1", strFilePath))
        '20200317 카메라 사용 모드
        For i As Integer = 0 To 3
            ipSystemParam.btnCameraUseMode(i) = CInt(ReadIni("CAMERA_USE_INFO", "Camera #" & i + 1, "1", strFilePath))
        Next
        ipSystemParam.btnCameraUseMode_A1 = CInt(ReadIni("CAMERA_USE_INFO", "Camera #" & 1, "1", strFilePath))
        ipSystemParam.btnCameraUseMode_A2 = CInt(ReadIni("CAMERA_USE_INFO", "Camera #" & 1, "1", strFilePath))
        ipSystemParam.btnCameraUseMode_B1 = CInt(ReadIni("CAMERA_USE_INFO", "Camera #" & 1, "1", strFilePath))
        ipSystemParam.btnCameraUseMode_B2 = CInt(ReadIni("CAMERA_USE_INFO", "Camera #" & 1, "1", strFilePath))

        For nLine = 0 To 1
            For i As Integer = 0 To 1
                ipSystemParam.dVisionScaleX(nLine, i) = CDbl(ReadIni("VISION", "SCALE_X_" & str(nLine) & (i + 1).ToString, "0.002365", strFilePath))
                ipSystemParam.dVisionScaleY(nLine, i) = CDbl(ReadIni("VISION", "SCALE_Y_" & str(nLine) & (i + 1).ToString, "0.002365", strFilePath))
                ipSystemParam.dVisionTheta(nLine, i) = CDbl(ReadIni("VISION", "ANGLE_" & str(nLine) & (i + 1).ToString, "0.025", strFilePath))
            Next
        Next

        For i As Integer = 0 To 3
            ipSystemParam.dLaserPower(i) = CDbl(ReadIni("LASER_POWER", "LASER_" & (i + 1).ToString, "0", strFilePath))
        Next

        'GYN - 2017.04.01 - 여기서 PEN DATA 전체를 100개를 한 번에 읽어와서 가지고 있자. LaserPower 4ea MarkData (4set * 15) = 60 
        ''20160922 JCM EDIT 100개를 한번에? 
        'ReDim ipSystemParam.RecipePen(1499) '4 * 15 * 100 = 
        ReDim ipSystemParam.RecipePen(100)
        ReDim ipSystemParam.TotalCnt(100)
        ReDim ipSystemParam.LaserPower(100, 4)

        For i As Integer = 0 To 99

            ReDim ipSystemParam.RecipePen(i).MarkSpeed(14)
            ReDim ipSystemParam.RecipePen(i).JumpSpeed(14)
            ReDim ipSystemParam.RecipePen(i).Repeat(14)
            ReDim ipSystemParam.RecipePen(i).MarkMode(14)

            ipSystemParam.TotalCnt(i) = CInt(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "TOTAL_COUNT", 0, ipSystemParam.strRecipePenDataFile))

            ipSystemParam.LaserPower(i, 0) = CDbl(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (1).ToString, 0, ipSystemParam.strRecipePenDataFile))
            ipSystemParam.LaserPower(i, 1) = CDbl(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (2).ToString, 0, ipSystemParam.strRecipePenDataFile))
            ipSystemParam.LaserPower(i, 2) = CDbl(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (3).ToString, 0, ipSystemParam.strRecipePenDataFile))
            ipSystemParam.LaserPower(i, 3) = CDbl(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (4).ToString, 0, ipSystemParam.strRecipePenDataFile))

            For j As Integer = 0 To 14
                ipSystemParam.RecipePen(i).MarkSpeed(j) = CInt(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "MARK_SPEED_" & (j + 1).ToString, 0, ipSystemParam.strRecipePenDataFile))
                ipSystemParam.RecipePen(i).JumpSpeed(j) = CInt(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "JUMP_SPEED_" & (j + 1).ToString, 0, ipSystemParam.strRecipePenDataFile))
                ipSystemParam.RecipePen(i).Repeat(j) = CInt(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "MARK_REPEAT_" & (j + 1).ToString, 0, ipSystemParam.strRecipePenDataFile))
                ipSystemParam.RecipePen(i).MarkMode(j) = CInt(ReadIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "MARK_MODE_" & (j + 1).ToString, 0, ipSystemParam.strRecipePenDataFile))
            Next
        Next

        For i As Integer = 0 To 3
            ipSystemParam.dDisplacePosX(i) = CInt(ReadIni("DISPLACE POS", (i + 1).ToString & "POS X", 6, strFilePath))
            ipSystemParam.dDisplacePosY(i) = CInt(ReadIni("DISPLACE POS", (i + 1).ToString & "POS Y", 6, strFilePath))
            'WriteIni("DISPLACE POS", (i + 1).ToString & "POS Y", ipSystemParam.dDisplacePosY, strFilePath)
        Next


        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Public Function SaveParam(ByVal strFilePath As String, ByRef ipSystemParam As SystemParameter) As Boolean
        On Error GoTo SysErr
        Dim strTemp As String
        Dim str(1) As String

        str(0) = "A"
        str(1) = "B"

        WriteIni("FILE_PATH", "SYSTEM_PATH", ipSystemParam.strSystemRootPath, strFilePath)
        WriteIni("FILE_PATH", "SYSTEM_LOG_PATH", ipSystemParam.strSystemLogPath, strFilePath)
        WriteIni("FILE_PATH", "A_LINE_ALIGN", ipSystemParam.strAlignImagePath(LINE.A), strFilePath)
        WriteIni("FILE_PATH", "B_LINE_ALIGN", ipSystemParam.strAlignImagePath(LINE.B), strFilePath)
        WriteIni("FILE_PATH", "SCANNER_SETTING_PATH", ipSystemParam.strScannerSettingPath, strFilePath)
        WriteIni("FILE_PATH", "PEN_DATA_FILE", ipSystemParam.strRecipePenDataFile, strFilePath)
        WriteIni("FILE_PATH", "LASER_IO_X", ipSystemParam.strDigitalXFile, strFilePath)
        WriteIni("FILE_PATH", "LASER_IO_Y", ipSystemParam.strDigitalYFile, strFilePath)
        WriteIni("FILE_PATH", "PCBITData", ipSystemParam.strPCBitFile, strFilePath)
        WriteIni("FILE_PATH", "PLCBITData", ipSystemParam.strPLCBitFile, strFilePath)
        WriteIni("FILE_PATH", "PCWORDData", ipSystemParam.strPCWordFile, strFilePath)
        WriteIni("FILE_PATH", "PLCWORDData", ipSystemParam.strPLCWordFile, strFilePath)

        For i = 0 To 3
            WriteIni("SCANNER_INFO", "SCANNER_COR_FILE_PATH" & (i + 1).ToString, ipSystemParam.strScannerCorFilePath(i), strFilePath)
            WriteIni("SCANNER_INFO", "SCANNER_HEX_FILE_PATH" & (i + 1).ToString, ipSystemParam.strScannerHexFilePath(i), strFilePath)
            WriteIni("SCANNER_INFO", "SCANNER_SCAN_SCALE" & (i + 1).ToString, ipSystemParam.nScannerScanScale(i), strFilePath)
        Next

        For nLine = 0 To 1
            For i = 0 To 3
                strTemp = str(nLine) & "_LINE_VISION_LASER_OFFSET" & (i + 1).ToString & "_X"
                WriteIni("SYSTEM_OFFSET", strTemp, ipSystemParam.dVisionLaserOffsetX(nLine, i), strFilePath)
                strTemp = str(nLine) & "_LINE_VISION_LASER_OFFSET" & (i + 1).ToString & "_Y"
                WriteIni("SYSTEM_OFFSET", strTemp, ipSystemParam.dVisionLaserOffsetY(nLine, i), strFilePath)
            Next
        Next

        For i = 0 To 3
            WriteIni("SYSTEM_PORT", "LASER_" & (i + 1).ToString, ipSystemParam.nPortLaser(i), strFilePath)
            WriteIni("SYSTEM_PORT", "POWER_METER_" & (i + 1).ToString, ipSystemParam.nPortPowerMeter(i), strFilePath)
            WriteIni("SYSTEM_PORT", "CHILLER_" & (1 + i).ToString, ipSystemParam.nPortChiller(i), strFilePath)
        Next
        WriteIni("SYSTEM_PORT", "POWER_METER_STAGE", ipSystemParam.nPortPowerMeter(4), strFilePath)

        WriteIni("SYSTEM_PORT", "LIGHT", ipSystemParam.nPortLight, strFilePath)
        WriteIni("SYSTEM_PORT", "DISPLACE", ipSystemParam.nPortDisplace, strFilePath)


        For i = 0 To 1
            WriteIni("SYSTEM_PORT", "DUST_COLLECTER_" & (1 + i).ToString, ipSystemParam.nPortDustCollecter(i), strFilePath)
            WriteIni("SYSTEM_PORT", "DUST_INVERTER_" & (1 + i).ToString, ipSystemParam.nPortDustInverter(i), strFilePath)
        Next

        For i = 0 To 3
            WriteIni("LASER_SET", "LASER_CHILLER_WATER_SET_DAY_" & (i + 1).ToString, ipSystemParam.strChillerWaterSetDay(i), strFilePath)
            WriteIni("LASER_SET", "LASER_CHILLER_WATER_SET_  " & (i + 1).ToString, ipSystemParam.nChillerWaterDay(i), strFilePath)
            WriteIni("LASER_SET", "LASER_CHILLER_FILTER_SET_DAY_" & (i + 1).ToString, ipSystemParam.strChillerFilterSetDay(i), strFilePath)
            WriteIni("LASER_SET", "LASER_CHILLER_FILTER_SET_" & (i + 1).ToString, ipSystemParam.nChillerFilterDay(i), strFilePath)
        Next

        For i = 0 To 3
            WriteIni("SCANNER_SET", "HALF_PULSE_PERIOD_" & (i + 1).ToString, ipSystemParam.nScanHalfPulseWith(i), strFilePath)
            WriteIni("SCANNER_SET", "PULSE_WIDTH1_" & (i + 1).ToString, ipSystemParam.nScanPulseWidth1(i), strFilePath)
            WriteIni("SCANNER_SET", "PULSE_WIDTH2_" & (i + 1).ToString, ipSystemParam.nScanPulseWidth2(i), strFilePath)
            WriteIni("SCANNER_SET", "LASER_ON_DELAY_" & (i + 1).ToString, ipSystemParam.nScanLaserOnDelay(i), strFilePath)
            WriteIni("SCANNER_SET", "LASER_OFF_DELAY_" & (i + 1).ToString, ipSystemParam.nScanLaserOffDelay(i), strFilePath)
            WriteIni("SCANNER_SET", "JUMP_SPEED_" & (i + 1).ToString, ipSystemParam.nScanJumpSpeed(i), strFilePath)
            WriteIni("SCANNER_SET", "MARK_SPEED_" & (i + 1).ToString, ipSystemParam.nScanMarkSpeed(i), strFilePath)
            WriteIni("SCANNER_SET", "JUMP_DELAY_" & (i + 1).ToString, ipSystemParam.nScanJumpDelay(i), strFilePath)
            WriteIni("SCANNER_SET", "MARK_DELAY_" & (i + 1).ToString, ipSystemParam.nScanMarkDelay(i), strFilePath)
            WriteIni("SCANNER_SET", "POLYGON_DELAY_" & (i + 1).ToString, ipSystemParam.nScanPolygonDelay(i), strFilePath)
        Next

        WriteIni("SYSTEM_DELAY", "TRIMMING_DELAY", ipSystemParam.nTrimmingDelay, strFilePath)
        WriteIni("SYSTEM_DELAY", "POWERMETER_TIME", ipSystemParam.nPowerMeterTime, strFilePath)
        WriteIni("SYSTEM_DELAY", "ALIGN_DELAY", ipSystemParam.nVisionAlignDelay, strFilePath)
        WriteIni("SYSTEM_DELAY", "ALIGN_RETRY_DELAY", ipSystemParam.nVisionAlignRetryDelay, strFilePath)

        WriteIni("SYSTEM_ETC", "SCANNER_MARK_SPEED_LIMIT", ipSystemParam.nScanMarkSpdLimt, strFilePath)
        WriteIni("SYSTEM_ETC", "SCANNER_JUMP_SPEED_LIMIT", ipSystemParam.nScanJumpSpdLimt, strFilePath)
        WriteIni("SYSTEM_ETC", "SYSTEM_LOG_SAVE_DAY", ipSystemParam.nLogSaveDay, strFilePath)
        WriteIni("SYSTEM_ETC", "SYSTEM_IMAGE_SAVE_DAY", ipSystemParam.nImageSaveDay, strFilePath)

        '20190807 Laser Power Limit
        WriteIni("SYSTEM_ETC", "LASER_POWER_MAX_LIMIT", ipSystemParam.nLaserPowerMaxLimit, strFilePath)
        WriteIni("SYSTEM_ETC", "LASER_POWER_MIN_LIMIT", ipSystemParam.nLaserPowerMinLimit, strFilePath)

        WriteIni("SYSTEM_ETC", "DUST_TIMER", ipSystemParam.nDustTimer, strFilePath)

        WriteIni("SYSTEM_ETC", "LAST_MODEL", ipSystemParam.strLastModelFilePath, strFilePath)
        WriteIni("SYSTEM_ETC", "SYSTEM", ipSystemParam.nSystem, strFilePath)

        'GYN - 2017.03.14 - 조명ON/OFF Add
        WriteIni("SYSTEM_ETC", "LIGHT_USE", ipSystemParam.nLightUse, strFilePath)

        WriteIni("CAMERA_USE_INFO", "CameraALINE_Use", ipSystemParam.btnCameraAUse, strFilePath)
        WriteIni("CAMERA_USE_INFO", "CameraBLINE_Use", ipSystemParam.btnCameraBUse, strFilePath)

        '20200317 카메라 사용 모드
        For i As Integer = 0 To 3
            WriteIni("CAMERA_USE_INFO", "Camera #" & i + 1, ipSystemParam.btnCameraUseMode(i), strFilePath)
        Next

        For nLine = 0 To 1
            For i As Integer = 0 To 1
                WriteIni("VISION", "SCALE_X_" & str(nLine) & (i + 1).ToString, ipSystemParam.dVisionScaleX(nLine, i), strFilePath)
                WriteIni("VISION", "SCALE_Y_" & str(nLine) & (i + 1).ToString, ipSystemParam.dVisionScaleY(nLine, i), strFilePath)
                WriteIni("VISION", "ANGLE_" & str(nLine) & (i + 1).ToString, ipSystemParam.dVisionTheta(nLine, i), strFilePath)
            Next
        Next


        For i As Integer = 0 To 3
            WriteIni("LASER_POWER", "LASER_" & (i + 1).ToString, ipSystemParam.dLaserPower(i), strFilePath)
        Next


        'GYN - 2017.04.01 - 여기서 PEN DATA 전체를 100개를 한 번에 읽어와서 가지고 있자. LaserPower 4ea MarkData (4set * 15) = 60 
        For i As Integer = 0 To 99

            WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "TOTAL_COUNT", ipSystemParam.TotalCnt(i), ipSystemParam.strRecipePenDataFile)

            WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (1).ToString, ipSystemParam.LaserPower(i, 0), ipSystemParam.strRecipePenDataFile)
            WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (2).ToString, ipSystemParam.LaserPower(i, 1), ipSystemParam.strRecipePenDataFile)
            WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (3).ToString, ipSystemParam.LaserPower(i, 2), ipSystemParam.strRecipePenDataFile)
            WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "LASER_POWER_" & (4).ToString, ipSystemParam.LaserPower(i, 3), ipSystemParam.strRecipePenDataFile)

            For j As Integer = 0 To 14

                WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "MARK_SPEED_" & (j + 1).ToString, ipSystemParam.RecipePen(i).MarkSpeed(j), ipSystemParam.strRecipePenDataFile)
                WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "JUMP_SPEED_" & (j + 1).ToString, ipSystemParam.RecipePen(i).JumpSpeed(j), ipSystemParam.strRecipePenDataFile)
                WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "MARK_REPEAT_" & (j + 1).ToString, ipSystemParam.RecipePen(i).Repeat(j), ipSystemParam.strRecipePenDataFile)
                WriteIni("RECIPE_PEN_DATA_" & (i + 1).ToString, "MARK_MODE_" & (j + 1).ToString, ipSystemParam.RecipePen(i).MarkMode(j), ipSystemParam.strRecipePenDataFile)

            Next
        Next

        'For i As Integer = 0 To 3
        '    WriteIni("DISPLACE POS", (i + 1).ToString & "POS X", ipSystemParam.dDisplacePosX, strFilePath)
        '    WriteIni("DISPLACE POS", (i + 1).ToString & "POS Y", ipSystemParam.dDisplacePosY, strFilePath)
        'Next

        Return True
        Exit Function
SysErr:
        Return False
    End Function


    'GYN - PEN DATA 저장 시 100개를 전부 저장할려니 너무 느려지니깐.. 쫌만 던지자.
    Public Function SavePenDataParam(ByVal strFilePath As String, ByVal nRecipeNum As Integer, ByRef ipSystemParam As SystemParameter) As Boolean

        On Error GoTo SysErr

        'GYN - 2017.04.01 - 여기서 PEN DATA 전체를 100개를 한 번에 읽어와서 가지고 있자. LaserPower 4ea MarkData (4set * 15) = 60 
        WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "TOTAL_COUNT", ipSystemParam.TotalCnt(nRecipeNum - 1), ipSystemParam.strRecipePenDataFile)

        WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "LASER_POWER_" & (1).ToString, ipSystemParam.LaserPower(nRecipeNum - 1, 0), ipSystemParam.strRecipePenDataFile)
        WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "LASER_POWER_" & (2).ToString, ipSystemParam.LaserPower(nRecipeNum - 1, 1), ipSystemParam.strRecipePenDataFile)
        WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "LASER_POWER_" & (3).ToString, ipSystemParam.LaserPower(nRecipeNum - 1, 2), ipSystemParam.strRecipePenDataFile)
        WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "LASER_POWER_" & (4).ToString, ipSystemParam.LaserPower(nRecipeNum - 1, 3), ipSystemParam.strRecipePenDataFile)

        For j As Integer = 0 To 14

            WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "MARK_SPEED_" & (j + 1).ToString, ipSystemParam.RecipePen(nRecipeNum - 1).MarkSpeed(j), ipSystemParam.strRecipePenDataFile)
            WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "JUMP_SPEED_" & (j + 1).ToString, ipSystemParam.RecipePen(nRecipeNum - 1).JumpSpeed(j), ipSystemParam.strRecipePenDataFile)
            WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "MARK_REPEAT_" & (j + 1).ToString, ipSystemParam.RecipePen(nRecipeNum - 1).Repeat(j), ipSystemParam.strRecipePenDataFile)
            WriteIni("RECIPE_PEN_DATA_" & (nRecipeNum).ToString, "MARK_MODE_" & (j + 1).ToString, ipSystemParam.RecipePen(nRecipeNum - 1).MarkMode(j), ipSystemParam.strRecipePenDataFile)

        Next

        'GYN 2017.04.01 - RMS TEST
        pLDLT.SetRecipePenData(pCurSystemParam.RecipePen, nRecipeNum)

        System.Threading.Thread.Sleep(500)



        Return True
        Exit Function
SysErr:
        Return False

    End Function

End Module
