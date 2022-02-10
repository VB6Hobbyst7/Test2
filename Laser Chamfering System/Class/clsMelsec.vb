Imports System.Threading

Public Class clsMelsec
    'Type 2 function library
    Private Declare Function mdopen Lib "MDFUNC32.DLL" (ByVal Chan As Short, ByVal Mode As Short, ByRef Path As Integer) As Short
    Private Declare Function mdclose Lib "MDFUNC32.DLL" (ByVal Path As Integer) As Short
    Private Declare Function mdsend Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByVal Devtyp As Short, ByVal Devno As Short, ByRef Size_Renamed As Short, ByRef Buf As Short) As Short
    Private Declare Function mdreceive Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByVal Devtyp As Short, ByVal Devno As Short, ByRef Size_Renamed As Short, ByRef Buf As Short) As Short
    Private Declare Function mddevset Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByVal Devtyp As Short, ByVal Devno As Short) As Short
    Private Declare Function mddevrst Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByVal Devtyp As Short, ByVal Devno As Short) As Short
    Private Declare Function mdrandw Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByRef dev As Short, ByRef Buf As Short, ByVal bufsiz As Short) As Short
    Private Declare Function mdrandr Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByRef dev As Short, ByRef Buf As Short, ByVal bufsiz As Short) As Short
    Private Declare Function mdcontrol Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByVal Buf As Short) As Short
    Private Declare Function mdtyperead Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal Stno As Short, ByRef Buf As Short) As Short

    Private Declare Function mdsendex Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal netno As Integer, ByVal Stno As Integer, ByVal Devtyp As Integer, ByVal Devno As Integer, ByRef Size_Renamed As Integer, ByRef Buf As Integer) As Integer
    Private Declare Function mdreceiveex Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal netno As Integer, ByVal Stno As Integer, ByVal Devtyp As Integer, ByVal Devno As Integer, ByRef Size_Renamed As Integer, ByRef Buf As Integer) As Integer
    Private Declare Function mddevsetex Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal netno As Integer, ByVal Stno As Integer, ByVal Devtyp As Integer, ByVal Devno As Integer) As Integer
    Private Declare Function mddevrstex Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal netno As Integer, ByVal Stno As Integer, ByVal Devtyp As Integer, ByVal Devno As Integer) As Integer
    Private Declare Function mdrandwex Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal netno As Integer, ByVal Stno As Integer, ByRef dev As Integer, ByRef Buf As Integer, ByVal bufsiz As Integer) As Integer
    Private Declare Function mdrandrex Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal netno As Integer, ByVal Stno As Integer, ByRef dev As Integer, ByRef Buf As Integer, ByVal bufsiz As Integer) As Integer
    Private Declare Function mdwaitbdevent Lib "MDFUNC32.DLL" (ByVal Path As Integer, ByVal eventno As Short, ByRef timeout As Integer, ByRef signaledno As Short, ByVal details As Short) As Integer

    Private ThreadMelsec As Thread
    Private bThreadRunningMelsec As Boolean
    Private nKillThreadMelsec As Integer

    Private ThreadMelsecStatus As Thread
    Private bThreadRunningMelsecStatus As Boolean
    Private nKillThreadMelsecStatus As Integer

    Declare Function SetSystemTime Lib "kernel32" Alias "SetSystemTime" (ByRef IpSystemTime As SYSTEMTIME) As Integer

    Public Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
    End Structure

    Private Const Melsec_CHANNEL_NO As Short = 151
    Private Const Melsec_MODE As Short = -1
    Private Const Melsec_NetworkNO As Short = 2
    Private Const Melsec_StationNO As Short = 255 '2
    Private Const Melsec_DevType As Short = 23

    Private Const DevX As Short = 1
    Private Const DevY As Short = 2

    Private Const DevB As Short = 23
    Private Const DevW As Short = 24

    Private isMelsecOpenOk As Boolean

    Public pPath As Integer

    Public pPLC_Bit(15, 15) As Integer
    '20160822 이근욱S 수정 - 무언정지 관련, PLC 통신 로그 남기기
    'Public pPLC_Bit_Old(15, 15) As Short
    Public pPC_Bit(15, 15) As Integer
    '20160822 이근욱S 수정 - 무언정지 관련, PLC 통신 로그 남기기
    'Public pPC_Bit_Old(15, 15) As Short

    Public pPLC_Word() As Short
    Public pPC_Word() As Short

    Public pbConnect As Boolean
    Public bChangeBit As Boolean = False
    ' 20161003 pcw
    Public m_bPlcAlive As Boolean

    Private qCmd As New Queue

    '20160826 LKU

    Private lockCmd As New Object

    '20160827 YDY
    Private tmpPc_Outstring() As String = {}
    Private tmpPLC_Outstring() As String = {}
    Private tmpPc_OutData() As Integer

    'GYN - 
    Public bRMSDATAChange As Boolean = False

    Public Const PLC_WW_FIRST_ADDR = &H6100
    Public Const PLC_RW_FIRST_ADDR = &H5100

    'Customize 필요
    Public Enum BIT
        'PC -> PLC
        'B5400
        WB_PC_AUTO_STATUS_A = &H5400
        'WB_PC_MANUAL_STATUS_A = &H5401
        WB_PC_AUTO_STATUS_B = &H5401
        'WB_PC_MANUAL_STATUS_B = &H5403
        'WB_TIME_SYNC_COMPLETE = &H2F0  <- 추가 될 수도 있음.
		WB_LOGIN_TECH = &H5409
        WB_PC_4ALIGN_STATUS = &H540A

        '20181208 Admin Login
        WB_LOGIN_ADMIN = &H540B

        WB_PC_RESET_ALARM = &H540D
        WB_PC_LIGHT_ALARM = &H540E
        WB_PC_HEAVY_ALARM = &H540F

        'B8410
        WB_LASER_BUSY_A_1 = &H5410      'WB_LASER_BUSY_1 = &H250
        WB_LASER_BUSY_A_2 = &H5411      'WB_LASER_BUSY_2 = &H251
        WB_LASER_BUSY_A_3 = &H5412      'WB_LASER_BUSY_3 = &H252
        WB_LASER_BUSY_A_4 = &H5413      'WB_LASER_BUSY_4 = &H253

        WB_ALIGN_A_OK_1 = &H5414         'WB_ALIGN_A_OK_1 = &H212
        WB_ALIGN_A_OK_2 = &H5415         'WB_ALIGN_A_NG_1 = &H213
        WB_ALIGN_A_OK_3 = &H5416         'WB_ALIGN_A_OK_2 = &H215
        WB_ALIGN_A_OK_4 = &H5417         'WB_ALIGN_A_NG_2 = &H216

        WB_ALIGN_A_NG_1 = &H5418         'WB_ALIGN_A_OK_3 = &H222
        WB_ALIGN_A_NG_2 = &H5419         'WB_ALIGN_A_NG_3 = &H223
        WB_ALIGN_A_NG_3 = &H541A         'WB_ALIGN_A_OK_4 = &H225
        WB_ALIGN_A_NG_4 = &H541B         'WB_ALIGN_A_NG_4 = &H226

        WB_A_TRIMMING_COMP = &H541C      'WB_A_TRIMMING_COMP = &H25B

        WB_MARK_DISTANCE_A = &H541D       '20181015 RYO Distance Alarm Bit

        WB_MOVE_REQUEST_STAGE_A_X = &H5420   'WB_MOVE_REQUEST_STAGE_A_X = &H270
        WB_MOVE_REQUEST_STAGE_A_Y = &H5421   'WB_MOVE_REQUEST_STAGE_A_Y = &H271
        'Add - GYN
        WB_MOVE_REQUEST_CAMERA_A_Z = &H5422  'WB_MOVE_REQUEST_CAMERA_A_Z = &H272

        'GYN -> 파워메타 B라인에 있어서 여기는 막음.
        'WB_MOVE_POWER_MEASURE_REQUEST_LASER1 = &H5434            'WB_MOVE_POWER_MEASURE_REQUEST_LASER1 = &H260
        'WB_MOVE_POWER_MEASURE_REQUEST_LASER2 = &H5435            'WB_MOVE_POWER_MEASURE_REQUEST_LASER2 = &H261
        'WB_MOVE_POWER_MEASURE_REQUEST_LASER3 = &H5436           'WB_MOVE_POWER_MEASURE_REQUEST_LASER3 = &H262
        'WB_MOVE_POWER_MEASURE_REQUEST_LASER4 = &H5437           'WB_MOVE_POWER_MEASURE_REQUEST_LASER4 = &H263
        'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER1 = &H5438       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER1 = &H264
        'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER2 = &H5439       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER2 = &H265
        'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER3 = &H543A       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER3 = &H266
        'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER4 = &H543B       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER4 = &H267
        'WB_POWER_MEASURE_COMPLETE = &H543C                       'WB_POWER_MEASURE_COMPLETE = &H268
        

        WB_LASER_BUSY_B_1 = &H5460      'WB_LASER_BUSY_1 = &H250
        WB_LASER_BUSY_B_2 = &H5461      'WB_LASER_BUSY_2 = &H251
        WB_LASER_BUSY_B_3 = &H5462      'WB_LASER_BUSY_3 = &H252
        WB_LASER_BUSY_B_4 = &H5463      'WB_LASER_BUSY_4 = &H253

        WB_ALIGN_B_OK_1 = &H5464
        WB_ALIGN_B_OK_2 = &H5465
        WB_ALIGN_B_OK_3 = &H5466
        WB_ALIGN_B_OK_4 = &H5467

        WB_ALIGN_B_NG_1 = &H5468
        WB_ALIGN_B_NG_2 = &H5469
        WB_ALIGN_B_NG_3 = &H546A
        WB_ALIGN_B_NG_4 = &H546B

        WB_B_TRIMMING_COMP = &H546C

        WB_MARK_DISTANCE_B = &H546D     '20181015 RYO Distance Alarm Bit

        WB_MOVE_REQUEST_STAGE_B_X = &H5470
        WB_MOVE_REQUEST_STAGE_B_Y = &H5471
        '품질 팝업 RYO
        WB_Quality_Check = &H54FF
        'GYN - ADD
        WB_MOVE_REQUEST_CAMERA_B_Z = &H5472

        WB_MOVE_POWER_MEASURE_REQUEST_LASER1 = &H5484            'WB_MOVE_POWER_MEASURE_REQUEST_LASER1 = &H260
        WB_MOVE_POWER_MEASURE_REQUEST_LASER2 = &H5485            'WB_MOVE_POWER_MEASURE_REQUEST_LASER2 = &H261
        WB_MOVE_POWER_MEASURE_REQUEST_LASER3 = &H5486           'WB_MOVE_POWER_MEASURE_REQUEST_LASER3 = &H262
        WB_MOVE_POWER_MEASURE_REQUEST_LASER4 = &H5487           'WB_MOVE_POWER_MEASURE_REQUEST_LASER4 = &H263

        WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER1 = &H5488       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER1 = &H264
        WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER2 = &H5489       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER2 = &H265
        WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER3 = &H548A       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER3 = &H266
        WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER4 = &H548B       'WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER4 = &H267

        WB_POWER_MEASURE_COMPLETE = &H548C                       'WB_POWER_MEASURE_COMPLETE = &H268

        'Add - GYN
        WB_MOVE_REQUEST_SCANNER1_Z = &H54B0  'WB_MOVE_REQUEST_SCANNER1_Z = &H273
        WB_MOVE_REQUEST_SCANNER2_Z = &H54B1  'WB_MOVE_REQUEST_SCANNER2_Z = &H274
        WB_MOVE_REQUEST_SCANNER3_Z = &H54B2  'WB_MOVE_REQUEST_SCANNER3_Z = &H275
        WB_MOVE_REQUEST_SCANNER4_Z = &H54B3  'WB_MOVE_REQUEST_SCANNER4_Z = &H276

        '20190729 레이저 상태 비트 추가
        WB_LASER1_ON = &H54C0
        WB_LASER1_MODE = &H54C1
        WB_LASER1_SHUTTER = &H54C2

        WB_LASER2_ON = &H54C3
        WB_LASER2_MODE = &H54C4
        WB_LASER2_SHUTTER = &H54C5

        WB_LASER3_ON = &H54C6
        WB_LASER3_MODE = &H54C7
        WB_LASER3_SHUTTER = &H54C8

        WB_LASER4_ON = &H54C9
        WB_LASER4_MODE = &H54CA
        WB_LASER4_SHUTTER = &H54CB

        WB_RECIPE_CHANGE_REPORT = &H54F0
        WB_RECIPE_COPY_REPORT = &H54F1
        WB_RECIPE_DELETE_REPORT = &H54F2
        WB_RECIPE_SAVE_REPORT = &H54F3

        

        '=========================================================================

        'PLC -> PC================================================================
        RB_PLC_AUTO_STATUS_A = &H5100
        RB_PLC_MANUAL_STATUS_A = &H5101
        RB_PLC_AUTO_STATUS_B = &H5102
        RB_PLC_MANUAL_STATUS_B = &H5103
        'RB_PLC_AlignTest_Mode = &H5104 '얼라인모드 추가

        RB_PLC_MANUAL_PC_CONTROL = &H510B
        RB_TIME_SYNC_REQUEST = &H510C
        RB_PLC_RESET_ALARM = &H510D
        RB_PLC_LIGHT_ALARM = &H510E
        RB_PLC_HEAVY_ALARM = &H510F

        RB_PLC_EXIST_A_1 = &H5110
        RB_PLC_EXIST_A_2 = &H5111
        RB_PLC_EXIST_A_3 = &H5112
        RB_PLC_EXIST_A_4 = &H5113

        RB_ALIGN_A_1_REQUEST = &H5114
        RB_ALIGN_A_2_REQUEST = &H5115
        RB_ALIGN_A_3_REQUEST = &H5116
        RB_ALIGN_A_4_REQUEST = &H5117

        RB_LASER_MARKING_START_A_1 = &H511C
        RB_LASER_MARKING_START_A_2 = &H511D
        RB_LASER_MARKING_START_A_3 = &H511E
        RB_LASER_MARKING_START_A_4 = &H511F

        RB_STAGE_MOVE_COMPLETE_REPORT_A_X = &H5120
        RB_STAGE_MOVE_COMPLETE_REPORT_A_Y = &H5121
        RB_CAMERA_MOVE_COMPLETE_REPORT_A_Z = &H5122

        RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_A_X = &H5130
        RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_A_Y = &H5131
        RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_A_X = &H5132
        RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_A_Y = &H5133

        'RB_LASER_POWER_MEASURE_MODE_LASER1 = &H5134
        'RB_LASER_POWER_MEASURE_MODE_LASER2 = &H5135
        'RB_LASER_POWER_MEASURE_MODE_LASER3 = &H5136
        'RB_LASER_POWER_MEASURE_MODE_LASER4 = &H5137
        'RB_LASER_POWER_MEASURE_MODE_TOP_LASER1 = &H5138
        'RB_LASER_POWER_MEASURE_MODE_TOP_LASER2 = &H5139
        'RB_LASER_POWER_MEASURE_MODE_TOP_LASER3 = &H513A
        'RB_LASER_POWER_MEASURE_MODE_TOP_LASER4 = &H513B

        RB_PLC_EXIST_B_1 = &H5160
        RB_PLC_EXIST_B_2 = &H5161
        RB_PLC_EXIST_B_3 = &H5162
        RB_PLC_EXIST_B_4 = &H5163

        RB_ALIGN_B_1_REQUEST = &H5164
        RB_ALIGN_B_2_REQUEST = &H5165
        RB_ALIGN_B_3_REQUEST = &H5166
        RB_ALIGN_B_4_REQUEST = &H5167

        RB_LASER_MARKING_START_B_1 = &H516C
        RB_LASER_MARKING_START_B_2 = &H516D
        RB_LASER_MARKING_START_B_3 = &H516E
        RB_LASER_MARKING_START_B_4 = &H516F

        RB_STAGE_MOVE_COMPLETE_REPORT_B_X = &H5170
        RB_STAGE_MOVE_COMPLETE_REPORT_B_Y = &H5171
        RB_CAMERA_MOVE_COMPLETE_REPORT_B_Z = &H5172

        RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_B_X = &H5180
        RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_B_Y = &H5181
        RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_B_X = &H5182
        RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_B_Y = &H5183

        RB_LASER_POWER_MEASURE_MODE_LASER1 = &H5184
        RB_LASER_POWER_MEASURE_MODE_LASER2 = &H5185
        RB_LASER_POWER_MEASURE_MODE_LASER3 = &H5186
        RB_LASER_POWER_MEASURE_MODE_LASER4 = &H5187

        RB_LASER_POWER_MEASURE_MODE_TOP_LASER1 = &H5188
        RB_LASER_POWER_MEASURE_MODE_TOP_LASER2 = &H5189
        RB_LASER_POWER_MEASURE_MODE_TOP_LASER3 = &H518A
        RB_LASER_POWER_MEASURE_MODE_TOP_LASER4 = &H518B

        'GYN - ADD
        RB_SCANNER_MOVE_COMPLETE_REPORT_Z1 = &H51B0
        RB_SCANNER_MOVE_COMPLETE_REPORT_Z2 = &H51B1
        RB_SCANNER_MOVE_COMPLETE_REPORT_Z3 = &H51B2
        RB_SCANNER_MOVE_COMPLETE_REPORT_Z4 = &H51B3

        '20180411 chy displace send
        RB_DISPLACE_SEND_A = &H51C0
        RB_DISPLACE_SEND_B = &H51C1

        '20181010 RYO Laser 사용 미사용
        RB_Laser1_PassMode = &H51D0
        RB_Laser2_PassMode = &H51D1
        RB_Laser3_PassMode = &H51D2
        RB_Laser4_PassMode = &H51D3

        RB_RECIPE_CHANGE_REQUEST = &H51F0
        RB_RECIPE_COPY_REQUEST = &H51F1
        RB_RECIPE_DELETE_REQUEST = &H51F2
        RB_RECIPE_SAVE_COPY_REQUEST = &H51F3
        '=========================================================================

    End Enum

    Public Enum RWORD
        'PLC->PC
        RW_PC_ALIVE = &H0   '5100

        RW_STAGE_A_X_ALIGN_1_POSITION1 = &H10
        RW_STAGE_A_X_ALIGN_1_POSITION2 = &H11
        RW_STAGE_A_Y_ALIGN_1_POSITION1 = &H12
        RW_STAGE_A_Y_ALIGN_1_POSITION2 = &H13

        RW_STAGE_A_X_ALIGN_2_POSITION1 = &H14
        RW_STAGE_A_X_ALIGN_2_POSITION2 = &H15
        RW_STAGE_A_Y_ALIGN_2_POSITION1 = &H16
        RW_STAGE_A_Y_ALIGN_2_POSITION2 = &H17

        RW_STAGE_A_X_ALIGN_3_POSITION1 = &H18
        RW_STAGE_A_X_ALIGN_3_POSITION2 = &H19
        RW_STAGE_A_Y_ALIGN_3_POSITION1 = &H1A
        RW_STAGE_A_Y_ALIGN_3_POSITION2 = &H1B

        RW_STAGE_A_X_ALIGN_4_POSITION1 = &H1C
        RW_STAGE_A_X_ALIGN_4_POSITION2 = &H1D
        RW_STAGE_A_Y_ALIGN_4_POSITION1 = &H1E
        RW_STAGE_A_Y_ALIGN_4_POSITION2 = &H1F

        RW_STAGE_A_X_TRIMMING_POSITION1 = &H20
        RW_STAGE_A_X_TRIMMING_POSITION2 = &H21
        RW_STAGE_A_Y_TRIMMING_POSITION1 = &H22
        RW_STAGE_A_Y_TRIMMING_POSITION2 = &H23

        RW_STAGE_A_X_CURRENT_POSITION1 = &H40
        RW_STAGE_A_X_CURRENT_POSITION2 = &H41
        RW_STAGE_A_Y_CURRENT_POSITION1 = &H42
        RW_STAGE_A_Y_CURRENT_POSITION2 = &H43

        RW_STAGE_A_CAMERA_Z_CURRENT_POSITION1 = &H44
        RW_STAGE_A_CAMERA_Z_CURRENT_POSITION2 = &H45

        RW_STAGE_B_X_ALIGN_1_POSITION1 = &H70
        RW_STAGE_B_X_ALIGN_1_POSITION2 = &H71
        RW_STAGE_B_Y_ALIGN_1_POSITION1 = &H72
        RW_STAGE_B_Y_ALIGN_1_POSITION2 = &H73

        RW_STAGE_B_X_ALIGN_2_POSITION1 = &H74
        RW_STAGE_B_X_ALIGN_2_POSITION2 = &H75
        RW_STAGE_B_Y_ALIGN_2_POSITION1 = &H76
        RW_STAGE_B_Y_ALIGN_2_POSITION2 = &H77

        RW_STAGE_B_X_ALIGN_3_POSITION1 = &H78
        RW_STAGE_B_X_ALIGN_3_POSITION2 = &H79
        RW_STAGE_B_Y_ALIGN_3_POSITION1 = &H7A
        RW_STAGE_B_Y_ALIGN_3_POSITION2 = &H7B

        RW_STAGE_B_X_ALIGN_4_POSITION1 = &H7C
        RW_STAGE_B_X_ALIGN_4_POSITION2 = &H7D
        RW_STAGE_B_Y_ALIGN_4_POSITION1 = &H7E
        RW_STAGE_B_Y_ALIGN_4_POSITION2 = &H7F

        RW_STAGE_B_X_TRIMMING_POSITION1 = &H80
        RW_STAGE_B_X_TRIMMING_POSITION2 = &H81
        RW_STAGE_B_Y_TRIMMING_POSITION1 = &H82
        RW_STAGE_B_Y_TRIMMING_POSITION2 = &H83

        RW_STAGE_B_X_CURRENT_POSITION1 = &HA0
        RW_STAGE_B_X_CURRENT_POSITION2 = &HA1
        RW_STAGE_B_Y_CURRENT_POSITION1 = &HA2
        RW_STAGE_B_Y_CURRENT_POSITION2 = &HA3

        RW_STAGE_B_CAMERA_Z_CURRENT_POSITION1 = &HA4
        RW_STAGE_B_CAMERA_Z_CURRENT_POSITION2 = &HA5

        RW_STAGE_SCANNER1_Z_CURRENT_POSITION1 = &HD0
        RW_STAGE_SCANNER1_Z_CURRENT_POSITION2 = &HD1
        RW_STAGE_SCANNER2_Z_CURRENT_POSITION1 = &HD2
        RW_STAGE_SCANNER2_Z_CURRENT_POSITION2 = &HD3
        RW_STAGE_SCANNER3_Z_CURRENT_POSITION1 = &HD4
        RW_STAGE_SCANNER3_Z_CURRENT_POSITION2 = &HD5
        RW_STAGE_SCANNER4_Z_CURRENT_POSITION1 = &HD6
        RW_STAGE_SCANNER4_Z_CURRENT_POSITION2 = &HD7

        RW_TIME_DATA_YEAR = &HF0
        RW_TIME_DATA_MONTH = &HF1
        RW_TIME_DATA_DAY = &HF2
        RW_TIME_DATA_HOUR = &HF3
        RW_TIME_DATA_MINUTE = &HF4
        RW_TIME_DATA_SECOND = &HF5

        RW_COPY_RECIPE_NUMBER = &H100
        RW_COPY_RECIPE_NAME0 = &H102
        RW_COPY_RECIPE_NAME1 = &H103
        RW_COPY_RECIPE_NAME2 = &H104
        RW_COPY_RECIPE_NAME3 = &H105
        RW_COPY_RECIPE_NAME4 = &H106
        RW_COPY_RECIPE_NAME5 = &H107
        RW_COPY_RECIPE_NAME6 = &H108
        RW_COPY_RECIPE_NAME7 = &H109
        RW_COPY_RECIPE_NAME8 = &H10A
        RW_COPY_RECIPE_NAME9 = &H10B

        RW_RECIPE_NUMBER = &H110
        RW_CURRENT_RECIPE_NAME0 = &H112
        RW_CURRENT_RECIPE_NAME1 = &H113
        RW_CURRENT_RECIPE_NAME2 = &H114
        RW_CURRENT_RECIPE_NAME3 = &H115
        RW_CURRENT_RECIPE_NAME4 = &H116
        RW_CURRENT_RECIPE_NAME5 = &H117
        RW_CURRENT_RECIPE_NAME6 = &H118
        RW_CURRENT_RECIPE_NAME7 = &H119
        RW_CURRENT_RECIPE_NAME8 = &H11A
        RW_CURRENT_RECIPE_NAME9 = &H11B

        'GYN - RMS DATA!


        ' 20160928 ubslhi - 사용안함
        '========================================
        'W330_ALIGN_MEASURE_OFFSET_X = 816
        'W331_ALIGN_MEASURE_OFFSET_Y = 817
        '========================================

    End Enum

    Public Enum WWORD
        'PC -> PLC
        WW_PC_ALIVE = &H0

        WW_STAGE_A_X_MOVING_POSITION1 = &H20
        WW_STAGE_A_X_MOVING_POSITION2 = &H21
        WW_STAGE_A_Y_MOVING_POSITION1 = &H22
        WW_STAGE_A_Y_MOVING_POSITION2 = &H23
        WW_STAGE_A_CAMERA_Z_POSITION1 = &H24
        WW_STAGE_A_CAMERA_Z_POSITION2 = &H25

        WW_STAGE_B_X_MOVING_POSITION1 = &H70
        WW_STAGE_B_X_MOVING_POSITION2 = &H71
        WW_STAGE_B_Y_MOVING_POSITION1 = &H72
        WW_STAGE_B_Y_MOVING_POSITION2 = &H73
        WW_STAGE_B_CAMERA_Z_POSITION1 = &H74
        WW_STAGE_B_CAMERA_Z_POSITION2 = &H75

        WW_STAGE_SCANNER1_Z_POSITION1 = &HB0
        WW_STAGE_SCANNER1_Z_POSITION2 = &HB1
        WW_STAGE_SCANNER2_Z_POSITION1 = &HB2
        WW_STAGE_SCANNER2_Z_POSITION2 = &HB3
        WW_STAGE_SCANNER3_Z_POSITION1 = &HB4
        WW_STAGE_SCANNER3_Z_POSITION2 = &HB5
        WW_STAGE_SCANNER4_Z_POSITION1 = &HB6
        WW_STAGE_SCANNER4_Z_POSITION2 = &HB7

        '20180411 chy displace send
        WW_DISPLACE_SEND_A1 = &HC0
        WW_DISPLACE_SEND_A2 = &HC1
        WW_DISPLACE_SEND_B1 = &HC2
        WW_DISPLACE_SEND_B2 = &HC3

        WW_RECIPE_NUMBER = &H110
        WW_CURRENT_RECIPE_NAME0 = &H112
        WW_CURRENT_RECIPE_NAME1 = &H113
        WW_CURRENT_RECIPE_NAME2 = &H114
        WW_CURRENT_RECIPE_NAME3 = &H115
        WW_CURRENT_RECIPE_NAME4 = &H116
        WW_CURRENT_RECIPE_NAME5 = &H117
        WW_CURRENT_RECIPE_NAME6 = &H118
        WW_CURRENT_RECIPE_NAME7 = &H119
        WW_CURRENT_RECIPE_NAME8 = &H11A
        WW_CURRENT_RECIPE_NAME9 = &H11B

        '---------------------------------
        WW_STAGE_A_STAGE1_OFFSETX_POSITION1 = &H124
        WW_STAGE_A_STAGE1_OFFSETX_POSITION2 = &H125
        WW_STAGE_A_STAGE1_OFFSETY_POSITION1 = &H126
        WW_STAGE_A_STAGE1_OFFSETY_POSITION2 = &H127
        WW_STAGE_A_STAGE1_OFFSETT_POSITION1 = &H128
        WW_STAGE_A_STAGE1_OFFSETT_POSITION2 = &H129

        WW_STAGE_A_STAGE2_OFFSETX_POSITION1 = &H134
        WW_STAGE_A_STAGE2_OFFSETX_POSITION2 = &H135
        WW_STAGE_A_STAGE2_OFFSETY_POSITION1 = &H136
        WW_STAGE_A_STAGE2_OFFSETY_POSITION2 = &H137
        WW_STAGE_A_STAGE2_OFFSETT_POSITION1 = &H138
        WW_STAGE_A_STAGE2_OFFSETT_POSITION2 = &H139

        WW_STAGE_A_STAGE3_OFFSETX_POSITION1 = &H144
        WW_STAGE_A_STAGE3_OFFSETX_POSITION2 = &H145
        WW_STAGE_A_STAGE3_OFFSETY_POSITION1 = &H146
        WW_STAGE_A_STAGE3_OFFSETY_POSITION2 = &H147
        WW_STAGE_A_STAGE3_OFFSETT_POSITION1 = &H148
        WW_STAGE_A_STAGE3_OFFSETT_POSITION2 = &H149

        WW_STAGE_A_STAGE4_OFFSETX_POSITION1 = &H154
        WW_STAGE_A_STAGE4_OFFSETX_POSITION2 = &H155
        WW_STAGE_A_STAGE4_OFFSETY_POSITION1 = &H156
        WW_STAGE_A_STAGE4_OFFSETY_POSITION2 = &H157
        WW_STAGE_A_STAGE4_OFFSETT_POSITION1 = &H158
        WW_STAGE_A_STAGE4_OFFSETT_POSITION2 = &H159

        WW_STAGE_B_STAGE1_OFFSETX_POSITION1 = &H164
        WW_STAGE_B_STAGE1_OFFSETX_POSITION2 = &H165
        WW_STAGE_B_STAGE1_OFFSETY_POSITION1 = &H166
        WW_STAGE_B_STAGE1_OFFSETY_POSITION2 = &H167
        WW_STAGE_B_STAGE1_OFFSETT_POSITION1 = &H168
        WW_STAGE_B_STAGE1_OFFSETT_POSITION2 = &H169

        WW_STAGE_B_STAGE2_OFFSETX_POSITION1 = &H174
        WW_STAGE_B_STAGE2_OFFSETX_POSITION2 = &H175
        WW_STAGE_B_STAGE2_OFFSETY_POSITION1 = &H176
        WW_STAGE_B_STAGE2_OFFSETY_POSITION2 = &H177
        WW_STAGE_B_STAGE2_OFFSETT_POSITION1 = &H178
        WW_STAGE_B_STAGE2_OFFSETT_POSITION2 = &H179

        WW_STAGE_B_STAGE3_OFFSETX_POSITION1 = &H184
        WW_STAGE_B_STAGE3_OFFSETX_POSITION2 = &H185
        WW_STAGE_B_STAGE3_OFFSETY_POSITION1 = &H186
        WW_STAGE_B_STAGE3_OFFSETY_POSITION2 = &H187
        WW_STAGE_B_STAGE3_OFFSETT_POSITION1 = &H188
        WW_STAGE_B_STAGE3_OFFSETT_POSITION2 = &H189

        WW_STAGE_B_STAGE4_OFFSETX_POSITION1 = &H194
        WW_STAGE_B_STAGE4_OFFSETX_POSITION2 = &H195
        WW_STAGE_B_STAGE4_OFFSETY_POSITION1 = &H196
        WW_STAGE_B_STAGE4_OFFSETY_POSITION2 = &H197
        WW_STAGE_B_STAGE4_OFFSETT_POSITION1 = &H198
        WW_STAGE_B_STAGE4_OFFSETT_POSITION2 = &H199

        'WW_A1_MARKING_ALLIGNOFFSET_X_1 = &H30
        'WW_A1_MARKING_ALLIGNOFFSET_Y_1 = &H31
        'WW_A1_MARKING_ALLIGNTHETA = &H32
        'WW_A2_MARKING_ALLIGNOFFSET_X_1 = &H33
        'WW_A2_MARKING_ALLIGNOFFSET_Y_1 = &H34
        'WW_A2_MARKING_ALLIGNTHETA = &H35
        'WW_A3_MARKING_ALLIGNOFFSET_X_1 = &H36
        'WW_A3_MARKING_ALLIGNOFFSET_Y_1 = &H37
        'WW_A3_MARKING_ALLIGNTHETA = &H38
        'WW_A4_MARKING_ALLIGNOFFSET_X_1 = &H39
        'WW_A4_MARKING_ALLIGNOFFSET_Y_1 = &H3A
        'WW_A4_MARKING_ALLIGNTHETA = &H3B
        ''W240
        'WW_B1_MARKING_ALLIGNOFFSET_X_1 = &H40
        'WW_B1_MARKING_ALLIGNOFFSET_Y_1 = &H41
        'WW_B1_MARKING_ALLIGNTHETA = &H42
        'WW_B2_MARKING_ALLIGNOFFSET_X_1 = &H43
        'WW_B2_MARKING_ALLIGNOFFSET_Y_1 = &H44
        'WW_B2_MARKING_ALLIGNTHETA = &H45
        'WW_B3_MARKING_ALLIGNOFFSET_X_1 = &H46
        'WW_B3_MARKING_ALLIGNOFFSET_Y_1 = &H47
        'WW_B3_MARKING_ALLIGNTHETA = &H48
        'WW_B4_MARKING_ALLIGNOFFSET_X_1 = &H49
        'WW_B4_MARKING_ALLIGNOFFSET_Y_1 = &H4A
        'WW_B4_MARKING_ALLIGNTHETA = &H4B
        ''W250
        'WW_LASER_STAGE_POWER1 = &H50
        'WW_LASER_STAGE_POWER2 = &H51
        'WW_LASER_STAGE_POWER3 = &H52
        'WW_LASER_STAGE_POWER4 = &H53

        'W11200 - VN_APD
        WW_LASER_UPPER_MAX_POWER_1 = &H6200
        WW_LASER_BOTTOM_MAX_POWER_1 = &H6201
        WW_SCAN_SPEED_1 = &H6202
        WW_LASER_CNT_1 = &H6203
        'WW_LASER_ED_1 = &H24
        'WW_LASER_TEMP_1 = &H25
        'WW_LASER_PROCESS_POWER_1 = &H26

        'W11210 - VN_APD
        WW_LASER_UPPER_MAX_POWER_2 = &H6210
        WW_LASER_BOTTOM_MAX_POWER_2 = &H6211
        WW_SCAN_SPEED_2 = &H6212
        WW_LASER_CNT_2 = &H6213
        'WW_LASER_ED_2 = &H64
        'WW_LASER_TEMP_2 = &H65
        'WW_LASER_PROCESS_POWER_2 = &H66

        'W11220 - VN_APD
        WW_LASER_UPPER_MAX_POWER_3 = &H6220
        WW_LASER_BOTTOM_MAX_POWER_3 = &H6221
        WW_SCAN_SPEED_3 = &H6222
        WW_LASER_CNT_3 = &H6223
        'WW_LASER_ED_3 = &HA4
        'WW_LASER_TEMP_3 = &HA5
        'WW_LASER_PROCESS_POWER_3 = &HA6

        'W11230 - VN_APD
        WW_LASER_UPPER_MAX_POWER_4 = &H6230
        WW_LASER_BOTTOM_MAX_POWER_4 = &H6231
        WW_SCAN_SPEED_4 = &H6232
        WW_LASER_CNT_4 = &H6233
        'WW_LASER_ED_4 = &HB4
        'WW_LASER_TEMP_4 = &HB5
        'WW_LASER_PROCESS_POWER_4 = &HB6

    End Enum

    ''''''
    ReadOnly Property ThreadRunning() As Boolean
        Get
            Return bThreadRunningMelsec
        End Get
    End Property

    Function StartMelsec() As Boolean
        On Error GoTo SysErr
        If isMelsecOpenOk = False Then
            If Melsec_Open() = True Then

                ThreadMelsec = New Thread(AddressOf MelsecThreadSub)
                nKillThreadMelsec = 0
                ThreadMelsec.SetApartmentState(ApartmentState.MTA)
                ThreadMelsec.Priority = ThreadPriority.Normal
                ThreadMelsec.Start()

                ThreadMelsecStatus = New Thread(AddressOf MelsecThreadStatusSub)
                nKillThreadMelsecStatus = 0
                ThreadMelsecStatus.SetApartmentState(ApartmentState.MTA)
                ThreadMelsecStatus.Priority = ThreadPriority.Normal
                ThreadMelsecStatus.Start()

                pbConnect = True
                Return True
            Else
                pbConnect = False
                Return False
            End If
        ElseIf isMelsecOpenOk = True Then
            ThreadMelsec = New Thread(AddressOf MelsecThreadSub)
            nKillThreadMelsec = 0
            ThreadMelsec.SetApartmentState(ApartmentState.MTA)
            ThreadMelsec.Priority = ThreadPriority.Normal

            ThreadMelsecStatus = New Thread(AddressOf MelsecThreadStatusSub)
            nKillThreadMelsecStatus = 0
            ThreadMelsecStatus.SetApartmentState(ApartmentState.MTA)
            ThreadMelsecStatus.Priority = ThreadPriority.Normal
            ThreadMelsecStatus.Start()

            ThreadMelsec.Start()
            Return True
        End If

        Exit Function
SysErr:
        Return False
    End Function

    Public Function EndMelsec() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThreadMelsec, 1)
        Threading.Thread.Sleep(100)
        If bThreadRunningMelsec = True Then
            ThreadMelsec.Join(1000)
        End If

        Interlocked.Exchange(nKillThreadMelsecStatus, 1)
        Threading.Thread.Sleep(100)
        If bThreadRunningMelsecStatus = True Then
            ThreadMelsecStatus.Join(1000)
        End If

        If Melsec_Close() = True Then
            ThreadMelsec = Nothing
            ThreadMelsecStatus = Nothing
            pbConnect = False
            Return True
        End If

        Return False
        Exit Function
SysErr:
        Return False
    End Function

    Function Melsec_Open() As Boolean
        On Error GoTo SysErr
        Dim Ret As Short 'return value

        Ret = mdopen(Melsec_CHANNEL_NO, Melsec_MODE, pPath)

        If (Ret <> 0) And (Ret <> 66) Then
            isMelsecOpenOk = False
            Return False
        Else
            isMelsecOpenOk = True
            Return True
        End If

        Exit Function
SysErr:
        Return False
    End Function

    Function Melsec_Close() As Short
        On Error GoTo SysErr
        Dim Ret As Short 'return value

        Ret = mdclose(pPath)
        isMelsecOpenOk = False
        If (Ret <> 0) Then
        End If
        Melsec_Close = Ret

        Exit Function
SysErr:
        Melsec_Close = False
    End Function

    Sub Close()
        On Error GoTo SysErr

        If Not (ThreadMelsec Is Nothing) Then
            ThreadMelsec.Join(10000)
        End If

        If isMelsecOpenOk = False Then
            Call Finalize()
        ElseIf isMelsecOpenOk = True Then
            If Melsec_Close() = True Then
                Call Finalize()
            End If
        End If

        Exit Sub
SysErr:

    End Sub

    Sub MelsecThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String = ""
        Dim strSendCmd() As String = {}

        While nKillThreadMelsec = 0
            bThreadRunningMelsec = True
            SyncLock lockCmd
                If qCmd.Count <> 0 Then
                    strCmd = qCmd.Dequeue
                    strSendCmd = Split(strCmd, ",")
                    'If strSendCmd(0) = "BIT" Then
                    '    Set_Bit(CInt(strSendCmd(1)))
                    'ElseIf strSendCmd(0) = "RESET" Then
                    '    Reset_Bit(CInt(strSendCmd(1)))
                    'Else
                    If strSendCmd(0) = "WORD" Then
                        SetWord(CInt(strSendCmd(1)), CInt(strSendCmd(2)))
                    End If
                    Thread.Sleep(50)
                End If
            End SyncLock

            Select Case nStatus
                Case 0
                    If ReadBit(BIT.WB_PC_AUTO_STATUS_A, 256, pPC_Bit) = True Then
                        GetPC_BitData()
                    End If
                    nStatus = 1
                Case 1
                    If ReadWord(PLC_WW_FIRST_ADDR, 256, pPC_Word) = True Then
                        GetPC_WordData()
                    End If
                    nStatus = 2
                Case 2
                    If ReadBit(BIT.RB_PLC_AUTO_STATUS_A, 256, pPLC_Bit) = True Then
                        GetPLC_BitData()
                    End If
                    nStatus = 3
                Case 3
                    'If ReadWord(PLC_RW_FIRST_ADDR, 256, pPLC_Word) = True Then
                    If ReadWord(PLC_RW_FIRST_ADDR, 288, pPLC_Word) = True Then
                        GetPLC_WordData()
                    End If
                    nStatus = 0
            End Select

            Thread.Sleep(50) 'sbs 100->50

        End While

        bThreadRunningMelsec = False
        Exit Sub
SysErr:
        bThreadRunningMelsec = False

    End Sub

    Dim nStatus As Integer = 0

    Sub MelsecThreadStatusSub()
        On Error GoTo SysErr

        While nKillThreadMelsecStatus = 0
            bThreadRunningMelsecStatus = True

            If PLC_Infomation.bStageManualControl = True Then
                'If pPLC_Word(RWORD.RW_STAGE_A_X_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_A_X_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_A_X_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_A_X_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageX(LINE.A) = True And PLC_Infomation.bMoveCompleteStageX(LINE.A) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_A_X)
                    'PC_Infomation.nTargetPosX(0) = PLC_Infomation.nCurPosX(LINE.A)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_A_Y_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_A_Y_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_A_Y_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_A_Y_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageY(LINE.A) = True And PLC_Infomation.bMoveCompleteStageY(LINE.A) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_A_Y)
                    'PC_Infomation.nTargetPosY(0) = PLC_Infomation.nCurPosY(LINE.A)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_B_X_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_B_X_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_B_X_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_B_X_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageX(LINE.B) = True And PLC_Infomation.bMoveCompleteStageX(LINE.B) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_B_X)
                    'PC_Infomation.nTargetPosX(1) = PLC_Infomation.nCurPosX(LINE.B)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_B_Y_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_B_Y_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_B_Y_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_B_Y_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageY(LINE.B) = True And PLC_Infomation.bMoveCompleteStageY(LINE.B) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_B_Y)
                    'PC_Infomation.nTargetPosY(1) = PLC_Infomation.nCurPosY(LINE.B)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER1_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER1_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER1_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER1_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_1 = True And PLC_Infomation.bMoveCompleteScannerZ(0) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_SCANNER1_Z)
                    'PC_Infomation.nTargetPosScannerZ1 = PLC_Infomation.nCurPosScannerZ(0)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER2_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER2_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER2_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER2_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_2 = True And PLC_Infomation.bMoveCompleteScannerZ(1) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_SCANNER2_Z)
                    'PC_Infomation.nTargetPosScannerZ2 = PLC_Infomation.nCurPosScannerZ(1)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER3_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER3_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER3_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER3_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_3 = True And PLC_Infomation.bMoveCompleteScannerZ(2) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_SCANNER3_Z)
                    'PC_Infomation.nTargetPosScannerZ3 = PLC_Infomation.nCurPosScannerZ(2)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER4_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER4_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER4_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER4_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_4 = True And PLC_Infomation.bMoveCompleteScannerZ(3) = True Then
                    Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_SCANNER4_Z)
                    'PC_Infomation.nTargetPosScannerZ4 = PLC_Infomation.nCurPosScannerZ(3)
                End If
                'End If

                '카메라는 각 라인별 2개이나 각 라인별 1개의 메모리맵만 있음 이게 맞음 축은 하나임
                If pPC_Word(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION1) = pPLC_Word(WWORD.WW_STAGE_A_CAMERA_Z_POSITION1) And pPC_Word(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION2) = pPLC_Word(WWORD.WW_STAGE_A_CAMERA_Z_POSITION2) Then
                    If PC_Infomation.bMoveRequestCameraZ(LINE.A) = True And PLC_Infomation.bMoveCompleteCameraZ1(LINE.A) = True Then
                        Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_CAMERA_A_Z)
                    End If
                End If

                If pPC_Word(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION1) = pPLC_Word(WWORD.WW_STAGE_B_CAMERA_Z_POSITION1) And pPC_Word(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION2) = pPLC_Word(WWORD.WW_STAGE_B_CAMERA_Z_POSITION2) Then
                    If PC_Infomation.bMoveRequestCameraZ(LINE.B) = True And PLC_Infomation.bMoveCompleteCameraZ1(LINE.B) = True Then
                        Reset_Bit(clsMelsec.BIT.WB_MOVE_REQUEST_CAMERA_B_Z)
                    End If
                End If

            End If

            '2017.01.09 - PC AliveBit 송부.
            AliveBit()

            'If PLC_Infomation.bPLC_ResetAlarm = True Then

            '    If PC_Infomation.bPC_LightAlarm = True Then
            '        Reset_Bit(BIT.WB_PC_LIGHT_ALARM)
            '    End If

            '    If PC_Infomation.bPC_HeavyAlarm = True Then
            '        Reset_Bit(BIT.WB_PC_HEAVY_ALARM)
            '    End If

            'End If

            Thread.Sleep(500) '1000 -> 500

        End While

        bThreadRunningMelsecStatus = False
        Exit Sub
SysErr:
        bThreadRunningMelsecStatus = False

    End Sub

    Function ClearWord(ByVal ipStartAddress As Integer, ByVal Size As Integer) As Boolean
        Dim nRet As Short
        Dim nTmpBuf(15) As Short

        nTmpBuf(0) = 0
        nRet = mdsend(pPath, Melsec_StationNO, DevW, ipStartAddress, Size, nTmpBuf(0))
        If nRet = 0 Then
            ClearWord = True
        Else
            ClearWord = False
        End If

    End Function

    Private Function SetWord(ByVal ipAddr As Integer, ByVal ipValue As Short) As Boolean
        Dim nRet As Short

        nRet = mdsend(pPath, Melsec_StationNO, DevW, ipAddr, 2, ipValue)
        If nRet = 0 Then
            'modPub.MelsecLog("SetWord : " & ipAddr.ToString & ", " & ipValue.ToString)
            SetWord = True
        Else
            'modPub.MelsecLog("SetWord Error : " & ipAddr.ToString & ", " & ipValue.ToString & ", " & nRet.ToString)
            SetWord = False
        End If

    End Function

    Private Function ReadWord(ByVal StartAddress As Integer, ByVal GetAddressSize As Integer, ByRef GetBuf() As Short) As Boolean
        On Error GoTo SysErr
        Dim nReadBuf() As Short = {}

        If isMelsecOpenOk = False Then
            ReadWord = False
            Exit Function
        End If

        If Read_Melsec(DevW, StartAddress, GetAddressSize, nReadBuf) = True Then
            GetBuf = nReadBuf
            ReadWord = True
        Else
            ReadWord = False
        End If

        Exit Function
SysErr:
        ReadWord = False
    End Function

    Function Read_Melsec(ByVal nDevType As Short, ByVal nDevNo As Short, ByVal nBufByteSize As Short, ByRef nRetBuf() As Short) As Boolean
        Dim nRet As Short
        Dim nTmpBuf() As Short

        Erase nTmpBuf
        ReDim nTmpBuf(nBufByteSize - 1)

        nRet = mdreceive(pPath, Melsec_StationNO, nDevType, nDevNo, nBufByteSize * 2, nTmpBuf(0))
        'mdreceiveex
        'nRet = mdreceiveex(pPath, Melsec_NetworkNO, Melsec_StationNO, nDevType, nDevNo, nBufByteSize * 2, nTmpBuf(0))
        If nRet = 0 Then
            nRetBuf = nTmpBuf
            Read_Melsec = True
        Else
            Read_Melsec = False
        End If

    End Function

    'Private Function Reset_Bit(ByVal nDevNo As BIT) As Boolean
    Public Function Reset_Bit(ByVal nDevNo As BIT) As Boolean
        On Error GoTo SysErr

        'If Comm.WaitForSingleObject(m_hMutex, 1000) <> Comm.WAIT_OBJECT_0 Then
        '    Return False
        'End If

        Dim nRtn As Short
        nRtn = mddevrst(pPath, Melsec_StationNO, DevB, nDevNo)

        If nRtn = 0 Then
            nRtn = mddevrst(pPath, Melsec_StationNO, DevB, nDevNo)
        End If

        If nRtn = 0 Then
            Reset_Bit = True
        Else
            Reset_Bit = False
        End If

        'Comm.ReleaseMutex(m_hMutex)

        Exit Function
SysErr:
        'modPub.MelsecLog("Reset Error : " & nRtn.ToString)
        Reset_Bit = False
    End Function


    'Private Function Set_Bit(ByVal nDevNo As BIT) As Boolean
    Public Function Set_Bit(ByVal nDevNo As BIT) As Boolean
        On Error GoTo SysErr

        'If Comm.WaitForSingleObject(m_hMutex, 1000) <> Comm.WAIT_OBJECT_0 Then
        '    Return False
        'End If

        Dim nRtn As Short
        nRtn = mddevset(pPath, Melsec_StationNO, DevB, nDevNo)

        If nRtn = 0 Then
            nRtn = mddevset(pPath, Melsec_StationNO, DevB, nDevNo)
            'modPub.MelsecLog("SetBit : " & nDevNo)
        End If

        If nRtn = 0 Then
            Set_Bit = True
        Else
            Set_Bit = False
        End If

        'Comm.ReleaseMutex(m_hMutex)

        Exit Function
SysErr:
        modPub.MelsecLog("Set Error : " & nRtn.ToString)
        Set_Bit = False
    End Function
    'Private Function ReadBit(ByVal StartAddress As BIT, ByVal GetAddressSize As Integer, ByRef GetBuf(,) As Short) As Boolean
    Public Function ReadBit(ByVal StartAddress As BIT, ByVal GetAddressSize As Integer, ByRef GetBuf(,) As Integer) As Boolean
        On Error GoTo SysErr
        Dim nReadBuf() As Short = {}
        Dim i, j As Integer

        If isMelsecOpenOk = False Then
            ReadBit = False
            Exit Function
        End If

        If Read_Melsec(DevB, StartAddress, GetAddressSize, nReadBuf) = True Then
            For i = 0 To 15
                For j = 0 To 15
                    GetBuf(j, i) = IIf(nReadBuf(j) And 2 ^ i, 1, 0)
                Next
            Next
            nReadBuf = Nothing
            ReadBit = True
        Else
            nReadBuf = Nothing
            ReadBit = False
        End If

        Exit Function
SysErr:
        ReadBit = False
    End Function

    Function SendDataBit(ByVal nDevNo As BIT) As Boolean
        On Error GoTo SysErr
        Dim tmpCmd As String = ""

        tmpCmd = "BIT" & "," & CInt(nDevNo).ToString

        SyncLock lockCmd
            qCmd.Enqueue(tmpCmd)
        End SyncLock

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Function SendDataResetBit(ByVal nDevNo As BIT) As Boolean
        On Error GoTo SysErr
        Dim tmpCmd As String = ""

        tmpCmd = "RESET" & "," & CInt(nDevNo).ToString

        SyncLock lockCmd
            qCmd.Enqueue(tmpCmd)
        End SyncLock

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Function SendDataWord(ByVal nDevNo As Integer, ByVal nData As Double) As Boolean
        On Error GoTo SysErr
        Dim tmpCmd As String = ""


        tmpCmd = "WORD" & "," & CInt(nDevNo).ToString & "," & nData

        SyncLock lockCmd
            qCmd.Enqueue(tmpCmd)
        End SyncLock

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Function SendDataWord_TEST(ByVal nDevNo As Integer, ByVal strData As String) As Boolean
        On Error GoTo SysErr
        Dim tmpCmd As String = ""
        Dim tmpAsc As String = strData

        SetWord(nDevNo, CInt(strData))

        'tmpCmd = "WORD" & "," & CInt(nDevNo).ToString & "," & tmpAsc
        'SyncLock lockCmd
        'qCmd.Enqueue(tmpCmd)
        'End SyncLock

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Function SendDataBCRWord(ByVal nDevNo As Integer, ByVal strData As String) As Boolean
        On Error GoTo SysErr
        Dim tmpCmd As String = ""

        Dim nRet As Integer = 0
        tmpCmd = "WORD" & "," & CInt(nDevNo).ToString & "," & strData

        SyncLock lockCmd
            qCmd.Enqueue(tmpCmd)
        End SyncLock
        'Dim ipValue As Integer = 0

        'ipValue = CInt(strData)

        'nRet = mdsend(pPath, Melsec_StationNO, DevW, nDevNo, 2, ipValue)
        'If nRet = 0 Then
        '    modPub.MelsecLog("SetWord : " & nDevNo.ToString & ", " & ipValue.ToString)
        '    'SetWord = True
        'Else
        '    modPub.MelsecLog("SetWord Error : " & nDevNo.ToString & ", " & ipValue.ToString & ", " & nRet.ToString)
        '    'SetWord = False
        'End If

        Return True
        Exit Function
SysErr:
        Return False
    End Function


    Function ConvertWordDataToStageData(ByVal ipWord1 As Short, ByVal ipWord2 As Short) As Integer
        On Error GoTo SysErr
        Dim strHex1 As String = Hex(ipWord1)
        Dim strHex2 As String = Hex(ipWord2)
        Dim tmpStr As String = ""
        Dim nRtnValue As Integer = 0

        If strHex1.Length >= 4 Then
            strHex1 = strHex1.Substring(strHex1.Length - 4, 4)
        Else
            If strHex1.Length = 3 Then
                strHex1 = "0" & strHex1
            End If
            If strHex1.Length = 2 Then
                strHex1 = "00" & strHex1
            End If
            '20181108 오타 수정
            'If strHex1.Length = 2 Then
            If strHex1.Length = 1 Then
                strHex1 = "000" & strHex1
            End If
        End If

        If strHex2.Length > 4 Then
            strHex2 = strHex2.Substring(strHex2.Length - 4, 4)
        End If
        If strHex2 = "FFFF" Then
            tmpStr = strHex1
            nRtnValue = CInt("&H" & tmpStr) - 65536
        ElseIf strHex2 = "0" Then
            tmpStr = strHex1
            nRtnValue = CInt("&H" & tmpStr)
        Else
            tmpStr = strHex2 & strHex1
            nRtnValue = Val("&H" & tmpStr)
            '  nRtnValue = Val("&H" & tmpStr)
        End If

        Return nRtnValue
        Exit Function
SysErr:
        Return -9999
    End Function


    Function ConvertWordDataToStageData(ByVal ipWord1 As Short) As Integer
        On Error GoTo SysErr
        Dim strHex1 As String = Hex(ipWord1)
        Dim strHex2 As String = Hex(ipWord1 + 1)
        Dim tmpStr As String = ""
        Dim nRtnValue As Integer = 0

        If strHex1.Length >= 4 Then
            strHex1 = strHex1.Substring(strHex1.Length - 4, 4)
        Else
            If strHex1.Length = 3 Then
                strHex1 = "0" & strHex1
            End If
            If strHex1.Length = 2 Then
                strHex1 = "00" & strHex1
            End If
            '20181108 오타 수정
            'If strHex1.Length = 2 Then
            If strHex1.Length = 1 Then
                strHex1 = "000" & strHex1
            End If
        End If

        If strHex2.Length > 4 Then
            strHex2 = strHex2.Substring(strHex2.Length - 4, 4)
        End If
        If strHex2 = "FFFF" Then
            tmpStr = strHex1
            nRtnValue = CInt("&H" & tmpStr) - 65536
        ElseIf strHex2 = "0" Then
            tmpStr = strHex1
            nRtnValue = CInt("&H" & tmpStr)
        Else
            tmpStr = strHex2 & strHex1
            nRtnValue = Val("&H" & tmpStr)
            '  nRtnValue = Val("&H" & tmpStr)
        End If

        Return nRtnValue
        Exit Function
SysErr:
        Return -9999
    End Function


    Function ConvertStageDataToWordData(ByVal ipValue As Integer, ByRef ipWord1 As Short, ByRef ipWord2 As Short) As Boolean
        On Error GoTo SysErr
        Dim strValue As String = Hex(ipValue)
        Dim tmpArrStr() As String = {}
        Dim tmpStr As String = ""
        Dim nRtnValue As Integer = 0
        Dim tmp1 As Integer = 0
        Dim tmp2 As Integer = 0

        If strValue.Length >= 4 Then
            tmpStr = strValue.Substring(strValue.Length - 4, 4)
            tmp1 = Val("&H" & tmpStr)
            If strValue.Length <= 8 Then
                tmpStr = strValue.Substring(0, strValue.Length - 4)
                If tmpStr = "" Then
                    tmp2 = "0"
                ElseIf tmpStr = "FFFF" Then
                    tmp2 = CInt("&H" & tmpStr) - 65536
                Else
                    tmp2 = Val("&H" & tmpStr)
                End If
            End If
        Else
            tmp1 = Val("&H" & strValue)
            tmp2 = "0"
        End If

        If tmp1 > 32767 Then
            tmp1 = tmp1 - 65536
        End If
        If tmp2 > 32767 Then
            tmp2 = tmp2 - 65536
        End If

        ipWord1 = tmp1
        ipWord2 = tmp2
        Return True
        Exit Function
SysErr:
        'MsgBox(Err.Description)
        Return -9999
    End Function

    Function APD_Data(ByVal ipValue As Integer, ByRef ipWord1 As Short, ByRef ipWord2 As Short) As Boolean
        On Error GoTo SysErr
        Dim strValue As String = Hex(ipValue)
        Dim tmpArrStr() As String = {}
        Dim tmpStr As String = ""
        Dim nRtnValue As Integer = 0
        Dim tmp1 As Integer = 0
        Dim tmp2 As Integer = 0

        If strValue.Length >= 4 Then
            tmpStr = strValue.Substring(strValue.Length - 4, 4)
            tmp1 = Val("&H" & tmpStr)
            If strValue.Length <= 8 Then
                tmpStr = strValue.Substring(0, strValue.Length - 4)
                If tmpStr = "" Then
                    tmp2 = "0"
                ElseIf tmpStr = "FFFF" Then
                    tmp2 = CInt("&H" & tmpStr) - 65536
                Else
                    tmp2 = Val("&H" & tmpStr)
                End If
            End If
        Else
            tmp1 = Val("&H" & strValue)
            tmp2 = "0"
        End If

        If tmp1 > 32767 Then
            tmp1 = tmp1 - 65536
        End If
        If tmp2 > 32767 Then
            tmp2 = tmp2 - 65536
        End If

        ipWord1 = tmp1
        ipWord2 = tmp2
        Return True
        Exit Function
SysErr:
        'MsgBox(Err.Description)
        Return -9999
    End Function










    'BCR DATA
    Function ConvertBCRDataToWordData(ByVal ipValue As String, ByRef ipWord1 As Short, ByRef ipWord2 As Short) As Boolean
        On Error GoTo SysErr
        Dim strValue As String = ipValue ' Hex(ipValue)
        Dim tmpArrStr() As String = {}
        Dim tmpStr As String = ""
        Dim nRtnValue As Integer = 0
        Dim tmp1 As Integer = 0
        Dim tmp2 As Integer = 0

        If strValue.Length >= 4 Then
            tmpStr = strValue.Substring(strValue.Length - 4, 4)
            tmp1 = Val("&H" & tmpStr)
            If strValue.Length <= 8 Then
                tmpStr = strValue.Substring(0, strValue.Length - 4)
                If tmpStr = "" Then
                    tmp2 = "0"
                ElseIf tmpStr = "FFFF" Then
                    tmp2 = CInt("&H" & tmpStr) - 65536
                Else
                    tmp2 = Val("&H" & tmpStr)
                End If
            End If
        Else
            tmp1 = Val("&H" & strValue)
            tmp2 = "0"
        End If

        If tmp1 > 32767 Then
            tmp1 = tmp1 - 65536
        End If
        If tmp2 > 32767 Then
            tmp2 = tmp2 - 65536
        End If

        ipWord1 = tmp1
        ipWord2 = tmp2
        Return True
        Exit Function
SysErr:
        'MsgBox(Err.Description)
        Return -9999
    End Function

    Structure PLC_INFO

        Dim bPLC_AutoMode() As Boolean                      'A:B5100, B:B5102
        Dim bPLC_ManualMode() As Boolean                    'A:B5101, B:B5103

        Dim bPLC_AlignCheckMode As Boolean                  'B5104 얼라인 체크 모드 추가

        Dim bStageManualControl As Boolean                  'B510B
        Dim bSyncTimeReq As Boolean                         'B510C
        Dim bPLC_ResetAlarm As Boolean                      'B510D
        Dim bPLC_LightAlarm As Boolean                      'B510E
        Dim bPLC_HeavyAlarm As Boolean                      'B510F

        Dim bGlassExist(,) As Boolean                       'A:B5110,B5111,B5112,B5113, B:B5160,B5161,B5162,B5163
        Dim bAlignRequest(,) As Boolean                     'A:B5114,B5115,B5116,B5117, B:B5164,B5165,B5166,B5167
        Dim bLaserMarkingRequest(,) As Boolean              'A:B511C,B511D,B511E,B511F, B:B516C,B516D,B516E,B516F

        Dim bMoveCompleteStageX() As Boolean                'A:B5120, B:B5170
        Dim bMoveCompleteStageY() As Boolean                'A:B5121, B:B5171
        Dim bMoveCompleteCameraZ1() As Boolean              'A:B5122, B:B5173
        Dim bMoveCompleteCameraZ2() As Boolean              'A:B5122, B:B5173
        
        Dim bMoveCompleteMainStageGlassInPosX() As Boolean  'A:B5130, B:B5180
        Dim bMoveCompleteMainStageGlassInPosY() As Boolean  'A:B5131, B:B5181
        Dim bMoveCompleteMainStageGlassOutPosX() As Boolean 'A:B5132, B:B5182
        Dim bMoveCompleteMainStageGlassOutPosY() As Boolean 'A:B5133, B:B5183

        Dim bLaserPowerMoveComplete_1 As Boolean            'B5184
        Dim bLaserPowerMoveComplete_2 As Boolean            'B5185
        Dim bLaserPowerMoveComplete_3 As Boolean            'B5186
        Dim bLaserPowerMoveComplete_4 As Boolean            'B5187   
        Dim bLaserPowerMoveComplete_Top_1 As Boolean        'B5188
        Dim bLaserPowerMoveComplete_Top_2 As Boolean        'B5189
        Dim bLaserPowerMoveComplete_Top_3 As Boolean        'B518A
        Dim bLaserPowerMoveComplete_Top_4 As Boolean        'B518B

        'Dim bLaserPowerMeasureComplete As Boolean           

        Dim bMoveCompleteScannerZ() As Boolean              'B51B0, B51B1, B51B2, B51B3

        '20180411 chy displace
        'B51C0, B51C1
        Dim bDisplaceSend() As Boolean
        'B51D0 ~ 3 RYO Laser 사용/미사용
        Dim bLaserPassMode() As Boolean

        Dim bRecipeChangeReq As Boolean                     'B51F0
        Dim bRecipeCopyReq As Boolean                       'B51F1
        Dim bRecipeDeleteReq As Boolean                     'B51F2
        Dim bRecipeSaveCopyReq As Boolean                   'B51F3

        'Word Start
        '20161109 JCM EDIT
        'A:W5110~W511F, B:W5170~W517F
        Dim nAlignPosX(,) As Integer
        Dim nAlignPosY(,) As Integer

        Dim nTrimmingPosX() As Integer                      'A:W5120,W5121, B:W5180,W5181
        Dim nTrimmingPosY() As Integer                      'A:W5122,W5123, B:W5182,W5183

        Dim nCurPosX() As Integer                           'A:W5140,W5141, B:W5140,W5141
        Dim nCurPosY() As Integer                           'A:W5142,W5143, B:W5142,W5143
        Dim nCurPosCameraZ1() As Integer                    'A:W5144,W5145, B:W5144,W5145
        Dim nCurPosCameraZ2() As Integer                    'A:W5144,W5145, B:W5144,W5145

        Dim nCurPosScannerZ() As Integer                    'W:51D0,W:51D1,W:51D2,W:51D3,W:51D4,W:51D5,W:51D6,W:51D7

        Dim nTimeData_Year As Short                         'W:51F0
        Dim nTimeData_Month As Short                        'W:51F1
        Dim nTimeData_Day As Short                          'W:51F2
        Dim nTimeData_Hour As Short                         'W:51F3
        Dim nTimeData_Minute As Short                       'W:51F4
        Dim nTimeData_Second As Short                       'W:51F5

        Dim nCopyRecipeNo As Integer
        Dim nRecipeNo As Integer
        Dim strCopyModelName As String
        Dim strModelName As String

        Dim nRMSData() As Integer       'RMS Data

        'Dim nTacTime() As Integer
        'Dim nBCR_A_DATA() As Integer
        'Dim nBCR_B_DATA() As Integer
        'Word End
        'Dim APD_A_DATA() As Integer
        'Dim APD_B_DATA() As Integer

        Public Sub Init()

            ReDim bPLC_AutoMode(1)
            ReDim bPLC_ManualMode(1)

            ReDim bGlassExist(1, 3)             '
            ReDim bAlignRequest(1, 3)           ' a, b line  
            ReDim bLaserMarkingRequest(1, 3)    ' a, b line    glass 1,2,3,4
            
            ReDim bMoveCompleteStageX(1)
            ReDim bMoveCompleteStageY(1)
            ReDim bMoveCompleteCameraZ1(1)       ' a, b line   camera 1, 2
            ReDim bMoveCompleteCameraZ2(1)       ' a, b line   camera 1, 2

            ReDim bLaserPassMode(3)            'Laser Pass 51D0

            ReDim bMoveCompleteMainStageGlassInPosX(1)
            ReDim bMoveCompleteMainStageGlassInPosY(1)
            ReDim bMoveCompleteMainStageGlassOutPosX(1)
            ReDim bMoveCompleteMainStageGlassOutPosY(1)
            ReDim bMoveCompleteScannerZ(3)
            ReDim bDisplaceSend(1)
            'Bit End

            'Word Start
            
            ReDim nAlignPosX(1, 3)
            ReDim nAlignPosY(1, 3)

            ReDim nCurPosX(1)
            ReDim nCurPosY(1)
            ReDim nTrimmingPosX(1)
            ReDim nTrimmingPosY(1)

            ReDim nCurPosCameraZ1(1)
            ReDim nCurPosCameraZ2(1)
            ReDim nCurPosScannerZ(3)

            'ReDim nTacTime(1)
            'ReDim APD_A_DATA(8)
            'ReDim APD_B_DATA(8)

            ReDim nRMSData(64)


        End Sub
    End Structure

    Structure PC_INFO
        'Bit Start
        Dim bPC_AutoMode() As Boolean                       'A:B5400, B:B5401
        'Dim bPC_ManualMode() As Boolean
        '20181208 Admin Login
        Dim bPC_AdminLogin As Boolean                       'B540B

        Dim bPC_ResetAlarm As Boolean                       'B540D
        Dim bPC_LightAlarm As Boolean                       'B540E
        Dim bPC_HeavyAlarm As Boolean                       'B540F

        Dim bLaserBusy_1() As Boolean                       'A:B5410, B:B5460
        Dim bLaserBusy_2() As Boolean                       'A:B5411, B:B5461
        Dim bLaserBusy_3() As Boolean                       'A:B5412, B:B5462
        Dim bLaserBusy_4() As Boolean                       'A:B5413, B:B5463

        Dim bAlignOK1() As Boolean                          'A:B5414, B:B5464
        Dim bAlignOK2() As Boolean                          'A:B5415, B:B5465
        Dim bAlignOK3() As Boolean                          'A:B5416, B:B5466
        Dim bAlignOK4() As Boolean                          'A:B5417, B:B5467

        Dim bAlignNG1() As Boolean                          'A:B5418, B:B5468
        Dim bAlignNG2() As Boolean                          'A:B5419, B:B5469
        Dim bAlignNG3() As Boolean                          'A:B541A, B:B546A
        Dim bAlignNG4() As Boolean                          'A:B541B, B:B546B

        Dim bTrimmingComp() As Boolean                      'A:B541C, B:B546C

        Dim bMarkDistace()

        Dim bMoveRequestStageX() As Boolean                 'A:B5420, B:B5470
        Dim bMoveRequestStageY() As Boolean                 'A:B5421, B:B5471
        Dim bMoveRequestCameraZ() As Boolean                'A:B5422, B:B5472

        Dim bLaserPowerMoveRequest_1 As Boolean             'B5484
        Dim bLaserPowerMoveRequest_2 As Boolean             'B5485
        Dim bLaserPowerMoveRequest_3 As Boolean             'B5486
        Dim bLaserPowerMoveRequest_4 As Boolean             'B5487

        Dim bLaserPowerMoveRequest_Top_1 As Boolean         'B5488
        Dim bLaserPowerMoveRequest_Top_2 As Boolean         'B5489
        Dim bLaserPowerMoveRequest_Top_3 As Boolean         'B548A
        Dim bLaserPowerMoveRequest_Top_4 As Boolean         'B548B

        Dim bLaserPowerMeasureComplete As Boolean           'B548C

        Dim bMoveRequestScanner_1 As Boolean                'B54B0
        Dim bMoveRequestScanner_2 As Boolean                'B54B1
        Dim bMoveRequestScanner_3 As Boolean                'B54B2
        Dim bMoveRequestScanner_4 As Boolean                'B54B3

        Dim bLaserOn() As Boolean
        Dim bLaserMode() As Boolean
        Dim bLaserShutter() As Boolean

        Dim bRecipeChangeReport As Boolean                  'B54F0
        Dim bRecipeSaveReport As Boolean                    'B54F1
        Dim bRecipeDeleteReport As Boolean                  'B54F2
        Dim bRecipeSaveCopyReport As Boolean                'B54F3

        '미사용
        'Dim bPC_RMSDataChange As Boolean

        'Dim bAlignAble() As Boolean

        'Dim bAlignForcedOK1() As Boolean
        'Dim bAlignForcedOK2() As Boolean
        'Dim bAlignForcedOK3() As Boolean
        'Dim bAlignForcedOK4() As Boolean

        'Dim bAlignComp1() As Boolean
        'Dim bAlignComp2() As Boolean
        'Dim bAlignComp3() As Boolean
        'Dim bAlignComp4() As Boolean

        'Dim bManualAlign() As Boolean
        'Dim bAlign_Distance_Error() As Boolean

        'Dim bDustCollecterAlarmReport As Boolean
        ''B290
        'Dim bLaser1OnReport As Boolean
        'Dim bLaser1OffReport As Boolean
        'Dim bLaser1ShutterOpenReport As Boolean
        'Dim bLaser1ShutterCloseReport As Boolean
        'Dim bLaser2OnReport As Boolean
        'Dim bLaser2OffReport As Boolean
        'Dim bLaser2ShutterOpenReport As Boolean
        'Dim bLaser2ShutterCloseReport As Boolean
        'Dim bLaser3OnReport As Boolean
        'Dim bLaser3OffReport As Boolean
        'Dim bLaser3ShutterOpenReport As Boolean
        'Dim bLaser3ShutterCloseReport As Boolean
        'Dim bLaser4OnReport As Boolean
        'Dim bLaser4OffReport As Boolean
        'Dim bLaser4ShutterOpenReport As Boolean
        'Dim bLaser4ShutterCloseReport As Boolean
        'Dim bLaserAlarmReport As Boolean
        ''B3C0 BCR
        ''Dim bBCRStartReport() As Boolean                    'A:B2C0, B:B2C1
        ''Dim bBCRCompReq() As Boolean                        'A:B2C2, B:B2C3
        ''B2E0

        ''B2F0
        'Dim bTimeSync As Boolean                            'B2F0
        'Bit End

        'Word Start
        Dim nPC_Alive As Integer                            'W6100

        Dim nTargetPosX() As Integer                        'A:W6120,W6121, B:W6170,W6171
        Dim nTargetPosY() As Integer                        'A:W6122,W6123, B:W6172,W6173
        Dim nTargetPosCameraZ1() As Integer                 'A:W6124,W6125, B:W6174,W6175
        Dim nTargetPosCameraZ2() As Integer                 'A:W6124,W6125, B:W6174,W6175

        Dim nTargetPosScannerZ1 As Integer                  'W61B0,W61B1
        Dim nTargetPosScannerZ2 As Integer                  'W61B2,W61B3
        Dim nTargetPosScannerZ3 As Integer                  'W61B4,W61B5
        Dim nTargetPosScannerZ4 As Integer                  'W61B6,W61B7

        Dim nPC_LightAlarm As Integer
        Dim nPC_HeavyAlarm As Integer
        Dim nTrimmingPosX() As Integer
        Dim nTrimmingPosY() As Integer


      






        Public Sub Init()
            ' a, b line
            ReDim bPC_AutoMode(1)
            'ReDim bPC_ManualMode(1)
            ReDim bLaserBusy_1(1)
            ReDim bLaserBusy_2(1)
            ReDim bLaserBusy_3(1)
            ReDim bLaserBusy_4(1)
            ReDim bAlignOK1(1)
            ReDim bAlignOK2(1)
            ReDim bAlignOK3(1)
            ReDim bAlignOK4(1)
            ReDim bAlignNG1(1)
            ReDim bAlignNG2(1)
            ReDim bAlignNG3(1)
            ReDim bAlignNG4(1)
            ReDim bTrimmingComp(1)
            ReDim bMoveRequestStageX(1)
            ReDim bMoveRequestStageY(1)
            ReDim bMoveRequestCameraZ(1)
            ReDim bMarkDistace(1)
			ReDim bLaserOn(3)
            ReDim bLaserMode(3)
            ReDim bLaserShutter(3)
            'ReDim bAlignAble(1)
            'ReDim bAlignForcedOK1(1)
            'ReDim bAlignForcedOK2(1)
            'ReDim bAlignForcedOK3(1)
            'ReDim bAlignForcedOK4(1)
            'ReDim bAlignComp1(1)
            'ReDim bAlignComp2(1)
            'ReDim bAlignComp3(1)
            'ReDim bAlignComp4(1)
            'ReDim bManualAlign(1)
            'ReDim bAlign_Distance_Error(1)
            ReDim nTrimmingPosX(1)
            ReDim nTrimmingPosY(1)
            ReDim nTargetPosX(1)
            ReDim nTargetPosY(1)
            ReDim nTargetPosCameraZ1(1)
            ReDim nTargetPosCameraZ2(1)
        End Sub

    End Structure

    Public PLC_Infomation As PLC_INFO
    Public PC_Infomation As PC_INFO

    Public Sub Init()
        PLC_Infomation.Init()
        PC_Infomation.Init()
    End Sub

    Private Sub GetPC_BitData()
        On Error GoTo SysErr
        PC_Infomation.bPC_AutoMode(LINE.A) = IIf(pPC_Bit(0, 0) = 1, True, False)
        'PC_Infomation.bPC_ManualMode(LINE.A) = IIf(pPC_Bit(0, 1) = 1, True, False)
        PC_Infomation.bPC_AutoMode(LINE.B) = IIf(pPC_Bit(0, 1) = 1, True, False)

        'PC_Infomation.bPC_ManualMode(LINE.B) = IIf(pPC_Bit(0, 3) = 1, True, False)
        '20181208 admin login
        PC_Infomation.bPC_AdminLogin = IIf(pPC_Bit(0, 11) = 1, True, False)

        PC_Infomation.bPC_ResetAlarm = IIf(pPC_Bit(0, 13) = 1, True, False)
        PC_Infomation.bPC_LightAlarm = IIf(pPC_Bit(0, 14) = 1, True, False)
        PC_Infomation.bPC_HeavyAlarm = IIf(pPC_Bit(0, 15) = 1, True, False)

        PC_Infomation.bLaserBusy_1(LINE.A) = IIf(pPC_Bit(1, 0) = 1, True, False)
        PC_Infomation.bLaserBusy_2(LINE.A) = IIf(pPC_Bit(1, 1) = 1, True, False)
        PC_Infomation.bLaserBusy_3(LINE.A) = IIf(pPC_Bit(1, 2) = 1, True, False)
        PC_Infomation.bLaserBusy_4(LINE.A) = IIf(pPC_Bit(1, 3) = 1, True, False)

        PC_Infomation.bAlignOK1(LINE.A) = IIf(pPC_Bit(1, 4) = 1, True, False)
        PC_Infomation.bAlignOK2(LINE.A) = IIf(pPC_Bit(1, 5) = 1, True, False)
        PC_Infomation.bAlignOK3(LINE.A) = IIf(pPC_Bit(1, 6) = 1, True, False)
        PC_Infomation.bAlignOK4(LINE.A) = IIf(pPC_Bit(1, 7) = 1, True, False)

        PC_Infomation.bAlignNG1(LINE.A) = IIf(pPC_Bit(1, 8) = 1, True, False)
        PC_Infomation.bAlignNG2(LINE.A) = IIf(pPC_Bit(1, 9) = 1, True, False)
        PC_Infomation.bAlignNG3(LINE.A) = IIf(pPC_Bit(1, 10) = 1, True, False)
        PC_Infomation.bAlignNG4(LINE.A) = IIf(pPC_Bit(1, 11) = 1, True, False)

        PC_Infomation.bTrimmingComp(LINE.A) = IIf(pPC_Bit(1, 12) = 1, True, False)

        PC_Infomation.bMarkDistace(LINE.A) = IIf(pPC_Bit(1, 13) = 1, True, False)

        PC_Infomation.bMoveRequestStageX(LINE.A) = IIf(pPC_Bit(2, 0) = 1, True, False)
        PC_Infomation.bMoveRequestStageY(LINE.A) = IIf(pPC_Bit(2, 1) = 1, True, False)
        PC_Infomation.bMoveRequestCameraZ(LINE.A) = IIf(pPC_Bit(2, 2) = 1, True, False)

        PC_Infomation.bLaserBusy_1(LINE.B) = IIf(pPC_Bit(6, 0) = 1, True, False)
        PC_Infomation.bLaserBusy_2(LINE.B) = IIf(pPC_Bit(6, 1) = 1, True, False)
        PC_Infomation.bLaserBusy_3(LINE.B) = IIf(pPC_Bit(6, 2) = 1, True, False)
        PC_Infomation.bLaserBusy_4(LINE.B) = IIf(pPC_Bit(6, 3) = 1, True, False)

        PC_Infomation.bAlignOK1(LINE.B) = IIf(pPC_Bit(6, 4) = 1, True, False)
        PC_Infomation.bAlignOK2(LINE.B) = IIf(pPC_Bit(6, 5) = 1, True, False)
        PC_Infomation.bAlignOK3(LINE.B) = IIf(pPC_Bit(6, 6) = 1, True, False)
        PC_Infomation.bAlignOK4(LINE.B) = IIf(pPC_Bit(6, 7) = 1, True, False)

        PC_Infomation.bAlignNG1(LINE.B) = IIf(pPC_Bit(6, 8) = 1, True, False)
        PC_Infomation.bAlignNG2(LINE.B) = IIf(pPC_Bit(6, 9) = 1, True, False)
        PC_Infomation.bAlignNG3(LINE.B) = IIf(pPC_Bit(6, 10) = 1, True, False)
        PC_Infomation.bAlignNG4(LINE.B) = IIf(pPC_Bit(6, 11) = 1, True, False)

        PC_Infomation.bTrimmingComp(LINE.B) = IIf(pPC_Bit(6, 12) = 1, True, False)

        PC_Infomation.bMarkDistace(LINE.B) = IIf(pPC_Bit(6, 13) = 1, True, False)

        PC_Infomation.bMoveRequestStageX(LINE.B) = IIf(pPC_Bit(7, 0) = 1, True, False)
        PC_Infomation.bMoveRequestStageY(LINE.B) = IIf(pPC_Bit(7, 1) = 1, True, False)
        PC_Infomation.bMoveRequestCameraZ(LINE.B) = IIf(pPC_Bit(7, 2) = 1, True, False)

        PC_Infomation.bLaserPowerMoveRequest_1 = IIf(pPC_Bit(8, 4) = 1, True, False)
        PC_Infomation.bLaserPowerMoveRequest_2 = IIf(pPC_Bit(8, 5) = 1, True, False)
        PC_Infomation.bLaserPowerMoveRequest_3 = IIf(pPC_Bit(8, 6) = 1, True, False)
        PC_Infomation.bLaserPowerMoveRequest_4 = IIf(pPC_Bit(8, 7) = 1, True, False)

        PC_Infomation.bLaserPowerMoveRequest_Top_1 = IIf(pPC_Bit(8, 8) = 1, True, False)
        PC_Infomation.bLaserPowerMoveRequest_Top_2 = IIf(pPC_Bit(8, 9) = 1, True, False)
        PC_Infomation.bLaserPowerMoveRequest_Top_3 = IIf(pPC_Bit(8, 10) = 1, True, False)
        PC_Infomation.bLaserPowerMoveRequest_Top_4 = IIf(pPC_Bit(8, 11) = 1, True, False)

        PC_Infomation.bLaserPowerMeasureComplete = IIf(pPC_Bit(8, 12) = 1, True, False)

        PC_Infomation.bMoveRequestScanner_1 = IIf(pPC_Bit(11, 0) = 1, True, False)
        PC_Infomation.bMoveRequestScanner_2 = IIf(pPC_Bit(11, 1) = 1, True, False)
        PC_Infomation.bMoveRequestScanner_3 = IIf(pPC_Bit(11, 2) = 1, True, False)
        PC_Infomation.bMoveRequestScanner_4 = IIf(pPC_Bit(11, 3) = 1, True, False)

        '20190729 레이저 비트 추가
        PC_Infomation.bLaserOn(0) = IIf(pPC_Bit(12, 0) = 1, True, False)
        PC_Infomation.bLaserMode(0) = IIf(pPC_Bit(12, 1) = 1, True, False)
        PC_Infomation.bLaserShutter(0) = IIf(pPC_Bit(12, 2) = 1, True, False)

        PC_Infomation.bLaserOn(1) = IIf(pPC_Bit(12, 3) = 1, True, False)
        PC_Infomation.bLaserMode(1) = IIf(pPC_Bit(12, 4) = 1, True, False)
        PC_Infomation.bLaserShutter(1) = IIf(pPC_Bit(12, 5) = 1, True, False)

		PC_Infomation.bLaserOn(2) = IIf(pPC_Bit(12, 6) = 1, True, False)
        PC_Infomation.bLaserMode(2) = IIf(pPC_Bit(12, 7) = 1, True, False)
        PC_Infomation.bLaserShutter(2) = IIf(pPC_Bit(12, 8) = 1, True, False)

        PC_Infomation.bLaserOn(3) = IIf(pPC_Bit(12, 9) = 1, True, False)
        PC_Infomation.bLaserMode(3) = IIf(pPC_Bit(12, 10) = 1, True, False)
        PC_Infomation.bLaserShutter(3) = IIf(pPC_Bit(12, 11) = 1, True, False)

        PC_Infomation.bRecipeChangeReport = IIf(pPC_Bit(15, 0) = 1, True, False)
        PC_Infomation.bRecipeSaveReport = IIf(pPC_Bit(15, 1) = 1, True, False)
        PC_Infomation.bRecipeDeleteReport = IIf(pPC_Bit(15, 2) = 1, True, False)
        PC_Infomation.bRecipeSaveCopyReport = IIf(pPC_Bit(15, 3) = 1, True, False)

        '미사용
        'PC_Infomation.bAlignAble(LINE.A) = IIf(pPC_Bit(1, 0) = 1, True, False)
        'PC_Infomation.bAlignForcedOK1(LINE.A) = IIf(pPC_Bit(1, 4) = 1, True, False)
        'PC_Infomation.bAlignForcedOK2(LINE.A) = IIf(pPC_Bit(1, 7) = 1, True, False)
        'PC_Infomation.bAlignForcedOK3(LINE.A) = IIf(pPC_Bit(2, 4) = 1, True, False)
        'PC_Infomation.bAlignForcedOK4(LINE.A) = IIf(pPC_Bit(2, 7) = 1, True, False)

        'PC_Infomation.bManualAlign(LINE.A) = IIf(pPC_Bit(2, 0) = 1, True, False)
        'PC_Infomation.bAlign_Distance_Error(LINE.A) = IIf(pPC_Bit(2, 1) = 1, True, False)

        'PC_Infomation.bAlignAble(LINE.B) = IIf(pPC_Bit(3, 0) = 1, True, False)
        'PC_Infomation.bAlignForcedOK1(LINE.B) = IIf(pPC_Bit(3, 4) = 1, True, False)
        'PC_Infomation.bAlignForcedOK2(LINE.B) = IIf(pPC_Bit(3, 7) = 1, True, False)
        'PC_Infomation.bAlignForcedOK3(LINE.B) = IIf(pPC_Bit(4, 4) = 1, True, False)
        'PC_Infomation.bAlignForcedOK4(LINE.B) = IIf(pPC_Bit(4, 7) = 1, True, False)
        'PC_Infomation.bManualAlign(LINE.B) = IIf(pPC_Bit(4, 0) = 1, True, False)

        'PC_Infomation.bAlign_Distance_Error(LINE.B) = IIf(pPC_Bit(4, 1) = 1, True, False)

        'PC_Infomation.bAlignComp1(LINE.A) = IIf(pPC_Bit(1, 8) = 1, True, False)
        'PC_Infomation.bAlignComp2(LINE.A) = IIf(pPC_Bit(1, 9) = 1, True, False)
        'PC_Infomation.bAlignComp3(LINE.A) = IIf(pPC_Bit(1, 10) = 1, True, False)
        'PC_Infomation.bAlignComp4(LINE.A) = IIf(pPC_Bit(1, 11) = 1, True, False)
        'PC_Infomation.bAlignComp1(LINE.B) = IIf(pPC_Bit(3, 8) = 1, True, False)
        'PC_Infomation.bAlignComp2(LINE.B) = IIf(pPC_Bit(3, 9) = 1, True, False)
        'PC_Infomation.bAlignComp3(LINE.B) = IIf(pPC_Bit(3, 10) = 1, True, False)
        'PC_Infomation.bAlignComp4(LINE.B) = IIf(pPC_Bit(3, 11) = 1, True, False)

        'PC_Infomation.bDustCollecterAlarmReport = IIf(pPC_Bit(8, 15) = 1, True, False)
        'PC_Infomation.bLaserAlarmReport = IIf(pPC_Bit(9, 15) = 1, True, False)

        'PC_Infomation.bLaser1OnReport = IIf(pPC_Bit(9, 0) = 1, True, False)
        'PC_Infomation.bLaser1OffReport = IIf(pPC_Bit(9, 1) = 1, True, False)
        'PC_Infomation.bLaser1ShutterOpenReport = IIf(pPC_Bit(9, 2) = 1, True, False)
        'PC_Infomation.bLaser1ShutterCloseReport = IIf(pPC_Bit(9, 3) = 1, True, False)

        'PC_Infomation.bLaser2OnReport = IIf(pPC_Bit(9, 4) = 1, True, False)
        'PC_Infomation.bLaser2OffReport = IIf(pPC_Bit(9, 5) = 1, True, False)
        'PC_Infomation.bLaser2ShutterOpenReport = IIf(pPC_Bit(9, 6) = 1, True, False)
        'PC_Infomation.bLaser2ShutterCloseReport = IIf(pPC_Bit(9, 7) = 1, True, False)

        'PC_Infomation.bLaser3OnReport = IIf(pPC_Bit(10, 0) = 1, True, False)
        'PC_Infomation.bLaser3OffReport = IIf(pPC_Bit(10, 1) = 1, True, False)
        'PC_Infomation.bLaser3ShutterOpenReport = IIf(pPC_Bit(10, 2) = 1, True, False)
        'PC_Infomation.bLaser3ShutterCloseReport = IIf(pPC_Bit(10, 3) = 1, True, False)

        'PC_Infomation.bLaser4OnReport = IIf(pPC_Bit(10, 4) = 1, True, False)
        'PC_Infomation.bLaser4OffReport = IIf(pPC_Bit(10, 5) = 1, True, False)
        'PC_Infomation.bLaser4ShutterOpenReport = IIf(pPC_Bit(10, 6) = 1, True, False)
        'PC_Infomation.bLaser4ShutterCloseReport = IIf(pPC_Bit(10, 7) = 1, True, False)

        'PC_Infomation.bTimeSync = IIf(pPC_Bit(15, 0) = 1, True, False)

        ''20160822 이근욱S 수정 - 무언정지 관련, PLC 통신 로그 남기기
        'For i As Integer = 0 To 15
        '    For j As Integer = 0 To 15
        '        If pPC_Bit_Old(i, j) <> pPC_Bit(i, j) Then
        '            modPub.MelsecLog("Get PC : (" & i.ToString & ", " & j.ToString & "), " & pPC_Bit(i, j).ToString)
        '            pPC_Bit_Old(i, j) = pPC_Bit(i, j)
        '        End If
        '    Next
        'Next

        Exit Sub
SysErr:

    End Sub

    Private Sub GetPC_WordData()
        On Error GoTo SysErr

        Dim StrTemp() As String = {}
        Dim StrTemp2() As String = {}
        Dim OutString As String = ""

        PC_Infomation.nPC_Alive = CInt(pPC_Word(clsMelsec.WWORD.WW_PC_ALIVE))
        'PC_Infomation.nPC_LightAlarm = CInt(pPC_Word(clsMelsec.WWORD.WW_PC_LIGHT_ALARM))
        'PC_Infomation.nPC_HeavyAlarm = CInt(pPC_Word(clsMelsec.WWORD.WW_PC_HEAVY_ALARM))

        'PC_Infomation.nTrimmingPosX(0) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_A_MARKING_ALLIGNOFFSET_X_1), pPC_Word(clsMelsec.WWORD.WW_A_MARKING_ALLIGNOFFSET_X_2))
        'PC_Infomation.nTrimmingPosY(0) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_A_MARKING_ALLIGNOFFSET_Y_1), pPC_Word(clsMelsec.WWORD.WW_A_MARKING_ALLIGNOFFSET_Y_2))
        'PC_Infomation.nTrimmingPosX(1) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_B_MARKING_ALLIGNOFFSET_X_1), pPC_Word(clsMelsec.WWORD.WW_B_MARKING_ALLIGNOFFSET_X_2))
        'PC_Infomation.nTrimmingPosY(1) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_B_MARKING_ALLIGNOFFSET_Y_1), pPC_Word(clsMelsec.WWORD.WW_B_MARKING_ALLIGNOFFSET_Y_2))

        PC_Infomation.nTargetPosX(LINE.A) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_A_X_MOVING_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_A_X_MOVING_POSITION2))
        PC_Infomation.nTargetPosY(LINE.A) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_A_Y_MOVING_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_A_Y_MOVING_POSITION2))
        PC_Infomation.nTargetPosCameraZ1(LINE.A) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_A_CAMERA_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_A_CAMERA_Z_POSITION2))
        PC_Infomation.nTargetPosCameraZ2(LINE.A) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_A_CAMERA_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_A_CAMERA_Z_POSITION2))
        
        PC_Infomation.nTargetPosX(LINE.B) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_B_X_MOVING_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_B_X_MOVING_POSITION2))
        PC_Infomation.nTargetPosY(LINE.B) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_B_Y_MOVING_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_B_Y_MOVING_POSITION2))
        PC_Infomation.nTargetPosCameraZ1(LINE.B) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_B_CAMERA_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_B_CAMERA_Z_POSITION2))
        PC_Infomation.nTargetPosCameraZ2(LINE.B) = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_B_CAMERA_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_B_CAMERA_Z_POSITION2))

        PC_Infomation.nTargetPosScannerZ1 = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER1_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER1_Z_POSITION2))
        PC_Infomation.nTargetPosScannerZ2 = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER2_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER2_Z_POSITION2))
        PC_Infomation.nTargetPosScannerZ3 = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER3_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER3_Z_POSITION2))
        PC_Infomation.nTargetPosScannerZ4 = ConvertWordDataToStageData(pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER4_Z_POSITION1), pPC_Word(clsMelsec.WWORD.WW_STAGE_SCANNER4_Z_POSITION2))

        Exit Sub
SysErr:

    End Sub

    Public Sub GetPLC_BitData()
        On Error GoTo SysErr

        PLC_Infomation.bPLC_AutoMode(LINE.A) = IIf(pPLC_Bit(0, 0) = 1, True, False)
        PLC_Infomation.bPLC_ManualMode(LINE.A) = IIf(pPLC_Bit(0, 1) = 1, True, False)
        PLC_Infomation.bPLC_AutoMode(LINE.B) = IIf(pPLC_Bit(0, 2) = 1, True, False)
        PLC_Infomation.bPLC_ManualMode(LINE.B) = IIf(pPLC_Bit(0, 3) = 1, True, False)

        PLC_Infomation.bPLC_AlignCheckMode = IIf(pPLC_Bit(0, 4) = 1, True, False) '얼라인 테스트 모드

        PLC_Infomation.bStageManualControl = IIf(pPLC_Bit(0, 11) = 1, True, False)  'B
        PLC_Infomation.bSyncTimeReq = IIf(pPLC_Bit(0, 12) = 1, True, False)
        PLC_Infomation.bPLC_ResetAlarm = IIf(pPLC_Bit(0, 13) = 1, True, False)
        PLC_Infomation.bPLC_LightAlarm = IIf(pPLC_Bit(0, 14) = 1, True, False)
        PLC_Infomation.bPLC_HeavyAlarm = IIf(pPLC_Bit(0, 15) = 1, True, False)

        PLC_Infomation.bGlassExist(LINE.A, 0) = IIf(pPLC_Bit(1, 0) = 1, True, False)
        PLC_Infomation.bGlassExist(LINE.A, 1) = IIf(pPLC_Bit(1, 1) = 1, True, False)
        PLC_Infomation.bGlassExist(LINE.A, 2) = IIf(pPLC_Bit(1, 2) = 1, True, False)
        PLC_Infomation.bGlassExist(LINE.A, 3) = IIf(pPLC_Bit(1, 3) = 1, True, False)

        PLC_Infomation.bAlignRequest(LINE.A, 0) = IIf(pPLC_Bit(1, 4) = 1, True, False)
        PLC_Infomation.bAlignRequest(LINE.A, 1) = IIf(pPLC_Bit(1, 5) = 1, True, False)
        PLC_Infomation.bAlignRequest(LINE.A, 2) = IIf(pPLC_Bit(1, 6) = 1, True, False)
        PLC_Infomation.bAlignRequest(LINE.A, 3) = IIf(pPLC_Bit(1, 7) = 1, True, False)

        PLC_Infomation.bLaserMarkingRequest(LINE.A, 0) = IIf(pPLC_Bit(1, 12) = 1, True, False)
        PLC_Infomation.bLaserMarkingRequest(LINE.A, 1) = IIf(pPLC_Bit(1, 13) = 1, True, False)
        PLC_Infomation.bLaserMarkingRequest(LINE.A, 2) = IIf(pPLC_Bit(1, 14) = 1, True, False)
        PLC_Infomation.bLaserMarkingRequest(LINE.A, 3) = IIf(pPLC_Bit(1, 15) = 1, True, False)

        PLC_Infomation.bMoveCompleteStageX(LINE.A) = IIf(pPLC_Bit(2, 0) = 1, True, False)
        PLC_Infomation.bMoveCompleteStageY(LINE.A) = IIf(pPLC_Bit(2, 1) = 1, True, False)
        PLC_Infomation.bMoveCompleteCameraZ1(LINE.A) = IIf(pPLC_Bit(2, 3) = 1, True, False)
        PLC_Infomation.bMoveCompleteCameraZ2(LINE.A) = IIf(pPLC_Bit(2, 3) = 1, True, False)

        PLC_Infomation.bMoveCompleteMainStageGlassInPosX(LINE.A) = IIf(pPLC_Bit(3, 0) = 1, True, False)
        PLC_Infomation.bMoveCompleteMainStageGlassInPosY(LINE.A) = IIf(pPLC_Bit(3, 1) = 1, True, False)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosX(LINE.A) = IIf(pPLC_Bit(3, 2) = 1, True, False)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosY(LINE.A) = IIf(pPLC_Bit(3, 3) = 1, True, False)

        PLC_Infomation.bGlassExist(LINE.B, 0) = IIf(pPLC_Bit(6, 0) = 1, True, False)
        PLC_Infomation.bGlassExist(LINE.B, 1) = IIf(pPLC_Bit(6, 1) = 1, True, False)
        PLC_Infomation.bGlassExist(LINE.B, 2) = IIf(pPLC_Bit(6, 2) = 1, True, False)
        PLC_Infomation.bGlassExist(LINE.B, 3) = IIf(pPLC_Bit(6, 3) = 1, True, False)

        PLC_Infomation.bAlignRequest(LINE.B, 0) = IIf(pPLC_Bit(6, 4) = 1, True, False)
        PLC_Infomation.bAlignRequest(LINE.B, 1) = IIf(pPLC_Bit(6, 5) = 1, True, False)
        PLC_Infomation.bAlignRequest(LINE.B, 2) = IIf(pPLC_Bit(6, 6) = 1, True, False)
        PLC_Infomation.bAlignRequest(LINE.B, 3) = IIf(pPLC_Bit(6, 7) = 1, True, False)

        PLC_Infomation.bLaserMarkingRequest(LINE.B, 0) = IIf(pPLC_Bit(6, 12) = 1, True, False)
        PLC_Infomation.bLaserMarkingRequest(LINE.B, 1) = IIf(pPLC_Bit(6, 13) = 1, True, False)
        PLC_Infomation.bLaserMarkingRequest(LINE.B, 2) = IIf(pPLC_Bit(6, 14) = 1, True, False)
        PLC_Infomation.bLaserMarkingRequest(LINE.B, 3) = IIf(pPLC_Bit(6, 15) = 1, True, False)

        PLC_Infomation.bMoveCompleteStageX(LINE.B) = IIf(pPLC_Bit(7, 0) = 1, True, False)
        PLC_Infomation.bMoveCompleteStageY(LINE.B) = IIf(pPLC_Bit(7, 1) = 1, True, False)
        PLC_Infomation.bMoveCompleteCameraZ1(LINE.B) = IIf(pPLC_Bit(7, 2) = 1, True, False)
        PLC_Infomation.bMoveCompleteCameraZ2(LINE.B) = IIf(pPLC_Bit(7, 2) = 1, True, False)

        PLC_Infomation.bMoveCompleteMainStageGlassInPosX(LINE.B) = IIf(pPLC_Bit(8, 0) = 1, True, False)
        PLC_Infomation.bMoveCompleteMainStageGlassInPosY(LINE.B) = IIf(pPLC_Bit(8, 1) = 1, True, False)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosX(LINE.B) = IIf(pPLC_Bit(8, 2) = 1, True, False)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosY(LINE.B) = IIf(pPLC_Bit(8, 3) = 1, True, False)

        PLC_Infomation.bLaserPowerMoveComplete_1 = IIf(pPLC_Bit(8, 4) = 1, True, False)
        PLC_Infomation.bLaserPowerMoveComplete_2 = IIf(pPLC_Bit(8, 5) = 1, True, False)
        PLC_Infomation.bLaserPowerMoveComplete_3 = IIf(pPLC_Bit(8, 6) = 1, True, False)
        PLC_Infomation.bLaserPowerMoveComplete_4 = IIf(pPLC_Bit(8, 7) = 1, True, False)

        PLC_Infomation.bLaserPowerMoveComplete_Top_1 = IIf(pPLC_Bit(8, 8) = 1, True, False)
        PLC_Infomation.bLaserPowerMoveComplete_Top_2 = IIf(pPLC_Bit(8, 9) = 1, True, False)
        PLC_Infomation.bLaserPowerMoveComplete_Top_3 = IIf(pPLC_Bit(8, 10) = 1, True, False)
        PLC_Infomation.bLaserPowerMoveComplete_Top_4 = IIf(pPLC_Bit(8, 11) = 1, True, False)

        PLC_Infomation.bMoveCompleteScannerZ(0) = IIf(pPLC_Bit(11, 0) = 1, True, False)
        PLC_Infomation.bMoveCompleteScannerZ(1) = IIf(pPLC_Bit(11, 1) = 1, True, False)
        PLC_Infomation.bMoveCompleteScannerZ(2) = IIf(pPLC_Bit(11, 2) = 1, True, False)
        PLC_Infomation.bMoveCompleteScannerZ(3) = IIf(pPLC_Bit(11, 3) = 1, True, False)

        '20180411 chy displace
        PLC_Infomation.bDisplaceSend(0) = IIf(pPLC_Bit(12, 0) = 1, True, False)
        PLC_Infomation.bDisplaceSend(1) = IIf(pPLC_Bit(12, 1) = 1, True, False)

        '20181010 RYO LaserPassMode
        PLC_Infomation.bLaserPassMode(0) = IIf(pPLC_Bit(13, 0) = 1, True, False) 'Laser1
        PLC_Infomation.bLaserPassMode(1) = IIf(pPLC_Bit(13, 1) = 1, True, False) 'Laser2
        PLC_Infomation.bLaserPassMode(2) = IIf(pPLC_Bit(13, 2) = 1, True, False) 'Laser3
        PLC_Infomation.bLaserPassMode(3) = IIf(pPLC_Bit(13, 3) = 1, True, False) 'Laser4


        PLC_Infomation.bRecipeChangeReq = IIf(pPLC_Bit(15, 0) = 1, True, False)
        PLC_Infomation.bRecipeCopyReq = IIf(pPLC_Bit(15, 1) = 1, True, False)
        PLC_Infomation.bRecipeDeleteReq = IIf(pPLC_Bit(15, 2) = 1, True, False)
        PLC_Infomation.bRecipeSaveCopyReq = IIf(pPLC_Bit(15, 3) = 1, True, False)

        

        ''20160822 이근욱S 수정 - 무언정지 관련, PLC 통신 로그 남기기
        'For i As Integer = 0 To 15
        '    For j As Integer = 0 To 15
        '        If pPLC_Bit_Old(i, j) <> pPLC_Bit(i, j) Then
        '            modPub.MelsecLog("Get PLC : (" & i.ToString & ", " & j.ToString & "), " & pPLC_Bit(i, j).ToString)
        '            pPLC_Bit_Old(i, j) = pPLC_Bit(i, j)
        '        End If
        '    Next
        'Next

        Exit Sub
SysErr:

    End Sub

    Private Sub GetPLC_WordData()
        On Error GoTo SysErr

        Dim StrTemp() As String = {}
        Dim StrTemp2() As String = {}
        Dim OutString As String = ""

        PLC_Infomation.nTrimmingPosX(LINE.A) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_X_TRIMMING_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_X_TRIMMING_POSITION2))
        PLC_Infomation.nTrimmingPosY(LINE.A) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_Y_TRIMMING_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_Y_TRIMMING_POSITION2))

        PLC_Infomation.nCurPosX(LINE.A) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_X_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_X_CURRENT_POSITION2))
        PLC_Infomation.nCurPosY(LINE.A) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_Y_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_Y_CURRENT_POSITION2))
        PLC_Infomation.nCurPosCameraZ1(LINE.A) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION2))
        PLC_Infomation.nCurPosCameraZ2(LINE.A) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION2))

        PLC_Infomation.nAlignPosX(LINE.A, 0) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_1_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_1_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.A, 0) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_1_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_1_POSITION2))
        PLC_Infomation.nAlignPosX(LINE.A, 1) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_2_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_2_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.A, 1) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_2_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_2_POSITION2))
        PLC_Infomation.nAlignPosX(LINE.A, 2) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_3_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_3_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.A, 2) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_3_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_3_POSITION2))
        PLC_Infomation.nAlignPosX(LINE.A, 3) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_4_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_X_ALIGN_4_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.A, 3) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_4_POSITION1), pPLC_Word(RWORD.RW_STAGE_A_Y_ALIGN_4_POSITION2))

        PLC_Infomation.nTrimmingPosX(LINE.B) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_X_TRIMMING_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_X_TRIMMING_POSITION2))
        PLC_Infomation.nTrimmingPosY(LINE.B) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_Y_TRIMMING_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_Y_TRIMMING_POSITION2))

        PLC_Infomation.nCurPosX(LINE.B) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_X_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_X_CURRENT_POSITION2))
        PLC_Infomation.nCurPosY(LINE.B) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_Y_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_Y_CURRENT_POSITION2))
        PLC_Infomation.nCurPosCameraZ1(LINE.B) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION2))
        PLC_Infomation.nCurPosCameraZ2(LINE.B) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION2))

        PLC_Infomation.nAlignPosX(LINE.B, 0) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_1_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_1_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.B, 0) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_1_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_1_POSITION2))
        PLC_Infomation.nAlignPosX(LINE.B, 1) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_2_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_2_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.B, 1) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_2_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_2_POSITION2))
        PLC_Infomation.nAlignPosX(LINE.B, 2) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_3_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_3_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.B, 2) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_3_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_3_POSITION2))
        PLC_Infomation.nAlignPosX(LINE.B, 3) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_4_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_X_ALIGN_4_POSITION2))
        PLC_Infomation.nAlignPosY(LINE.B, 3) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_4_POSITION1), pPLC_Word(RWORD.RW_STAGE_B_Y_ALIGN_4_POSITION2))

        PLC_Infomation.nCurPosScannerZ(0) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_SCANNER1_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_SCANNER1_Z_CURRENT_POSITION2))
        PLC_Infomation.nCurPosScannerZ(1) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_SCANNER2_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_SCANNER2_Z_CURRENT_POSITION2))
        PLC_Infomation.nCurPosScannerZ(2) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_SCANNER3_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_SCANNER3_Z_CURRENT_POSITION2))
        PLC_Infomation.nCurPosScannerZ(3) = ConvertWordDataToStageData(pPLC_Word(RWORD.RW_STAGE_SCANNER4_Z_CURRENT_POSITION1), pPLC_Word(RWORD.RW_STAGE_SCANNER4_Z_CURRENT_POSITION2))


        PLC_Infomation.nCopyRecipeNo = pPLC_Word(RWORD.RW_COPY_RECIPE_NUMBER)
        PLC_Infomation.nRecipeNo = CInt(pPLC_Word(RWORD.RW_RECIPE_NUMBER))

        ReDim StrTemp(9)
        ReDim StrTemp2(9)

        'GYN - Recipe 변경 및 생성 Bit 받은 후 구동 되게 조건 걸어서 진행.
        If bModelRecipe = True Then
            For i As Integer = 0 To StrTemp.Length - 1
                StrTemp2(i) = Hex(pPLC_Word(RWORD.RW_CURRENT_RECIPE_NAME0 + i))
            Next
            If ConvertAscToWord(StrTemp2, OutString) = True Then
                PLC_Infomation.strModelName = Trim(OutString)
            End If
            bModelRecipe = False
        End If

        PLC_Infomation.nTimeData_Year = pPLC_Word(RWORD.RW_TIME_DATA_YEAR)
        PLC_Infomation.nTimeData_Month = pPLC_Word(RWORD.RW_TIME_DATA_MONTH)
        PLC_Infomation.nTimeData_Day = pPLC_Word(RWORD.RW_TIME_DATA_DAY)
        PLC_Infomation.nTimeData_Hour = pPLC_Word(RWORD.RW_TIME_DATA_HOUR)
        PLC_Infomation.nTimeData_Minute = pPLC_Word(RWORD.RW_TIME_DATA_MINUTE)
        PLC_Infomation.nTimeData_Second = pPLC_Word(RWORD.RW_TIME_DATA_SECOND)

        Exit Sub
SysErr:

    End Sub

    Public Function MoveStage(ByVal nLine As Integer, ByVal nAxis As Integer, ByVal ipPosition As Double)
        On Error GoTo SysErr
        Dim tmpWord1 As Short = 0
        Dim tmpWord2 As Short = 0
        Dim tmpMovePos As Integer = ipPosition  '* 1000
        pMelsec.ConvertStageDataToWordData(tmpMovePos, tmpWord1, tmpWord2)

        Dim nAddr(2) As Integer
        Dim nXAddr As Integer
        Dim bXReqAddr As BIT

        ' WW_STAGE_A_X_MOVING_POSITION1 = &H80
        'GYN - TEST (수정한 부분)

        If nLine = 0 Then

            Select Case nAxis
                Case 0
                    bXReqAddr = clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_A_X
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_X_MOVING_POSITION1
                Case 1
                    bXReqAddr = clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_A_Y
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_Y_MOVING_POSITION1
                Case 2
                    bXReqAddr = clsMelsec.BIT.WB_MOVE_REQUEST_CAMERA_A_Z
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_CAMERA_Z_POSITION1
            End Select
        Else
            Select Case nAxis
                Case 0
                    bXReqAddr = clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_B_X
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_X_MOVING_POSITION1
                Case 1
                    bXReqAddr = clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_B_Y
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_Y_MOVING_POSITION1
                Case 2
                    bXReqAddr = clsMelsec.BIT.WB_MOVE_REQUEST_CAMERA_B_Z
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_CAMERA_Z_POSITION1
            End Select
        End If

        nAddr(0) = nXAddr '+ (nAxis * 2) + (nLine * &H10)
        nAddr(1) = nXAddr + 1 ' (nAxis * 2) + (nLine * &H10) + 1
        nAddr(2) = bXReqAddr '+ nAxis + (nLine * &H10)
        pMelsec.SendDataWord(nAddr(0), tmpWord1)
        pMelsec.SendDataWord(nAddr(1), tmpWord2)

        For i As Integer = 0 To 300 '500->300
            Thread.Sleep(1)
        Next
        
        pMelsec.Set_Bit(nAddr(2))

        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Public Function StopStage(ByVal nLine As Integer, ByVal nAxis As Integer) As Boolean
        On Error GoTo SysErr

        Dim nDevNo As BIT = clsMelsec.BIT.WB_MOVE_REQUEST_STAGE_A_X + nAxis + (nLine * &H10)

        StopStage = Reset_Bit(nDevNo)

        Exit Function
SysErr:
        Return False
    End Function

    Public Function StopScannerZ(ByVal nIndex As Integer) As Boolean
        On Error GoTo SysErr

        Dim nDevNo As BIT = clsMelsec.BIT.WB_MOVE_REQUEST_SCANNER1_Z + nIndex

        StopScannerZ = Reset_Bit(nDevNo)

        Exit Function
SysErr:
        Return False
    End Function

    Public Function StopAll() As Boolean
        On Error GoTo SysErr

        For nAxis As Integer = Axis.x To Axis.cam_z
            StopStage(LINE.A, nAxis)
            StopStage(LINE.B, nAxis)
        Next
        For nScanner As Integer = 0 To 3
            StopScannerZ(nScanner)
        Next
        Exit Function
SysErr:
        Return False
    End Function


    Public Function MoveScannerZ(ByVal nIndex As Integer, ByVal ipPosition As Double)
        On Error GoTo SysErr
        Dim tmpWord1 As Short = 0
        Dim tmpWord2 As Short = 0
        Dim tmpMovePos As Integer = ipPosition
        pMelsec.ConvertStageDataToWordData(tmpMovePos, tmpWord1, tmpWord2)

        Dim nAddr(2) As Integer
        Dim nZAddr As Integer
        Dim ReqAddr As BIT = clsMelsec.BIT.WB_MOVE_REQUEST_SCANNER1_Z

        nZAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_SCANNER1_Z_POSITION1

        nAddr(0) = nZAddr + (nIndex * 2)
        nAddr(1) = nZAddr + (nIndex * 2) + 1
        nAddr(2) = ReqAddr + nIndex
        pMelsec.SendDataWord(nAddr(0), tmpWord1)
        pMelsec.SendDataWord(nAddr(1), tmpWord2)
        pMelsec.Set_Bit(nAddr(2))

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    '    Public Function SetStageMarkingPos(ByVal nLine As Integer, ByVal nAxis As Integer, ByVal ipPosition As Double)
    '        On Error GoTo SysErr
    '        Dim tmpWord1 As Short = 0
    '        Dim tmpWord2 As Short = 0
    '        Dim tmpMovePos As Integer = ipPosition * 1000

    '        pMelsec.ConvertStageDataToWordData(tmpMovePos, tmpWord1, tmpWord2)

    '        Dim nAddr As Integer
    '        If nLine = LINE.A Then
    '            If nAxis = Axis.x Then
    '                nAddr = WWORD.WW_A_MARKING_ALLIGNOFFSET_X_1
    '            ElseIf nAxis = Axis.y Then
    '                nAddr = WWORD.WW_A_MARKING_ALLIGNOFFSET_Y_1
    '            End If
    '        ElseIf nLine = LINE.B Then
    '            If nAxis = Axis.x Then
    '                nAddr = WWORD.WW_B_MARKING_ALLIGNOFFSET_X_1
    '            ElseIf nAxis = Axis.y Then
    '                nAddr = WWORD.WW_B_MARKING_ALLIGNOFFSET_Y_1
    '            End If
    '        End If

    '        pMelsec.SendDataWord(nAddr, tmpWord1)
    '        pMelsec.SendDataWord(nAddr + 1, tmpWord2)

    '        Return True
    '        Exit Function
    'SysErr:
    '        Return False
    '    End Function


    Function SetBCRData(ByVal iLine As Integer, ByVal strBcr As String) As Boolean
        On Error GoTo SysErr

        Dim tmpCmd() As String = {}
        Dim ntmpFirstCmd() As Integer = {}
        Dim ntmpSecondCmd() As Integer = {}
        Dim pPC_StrTemp As String = ""

        ConvertWordToAsc(strBcr, tmpPc_Outstring)

        'Select Case iLine

        '    Case 0
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_1), tmpPc_Outstring(0))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_2), tmpPc_Outstring(1))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_3), tmpPc_Outstring(2))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_4), tmpPc_Outstring(3))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_5), tmpPc_Outstring(4))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_6), tmpPc_Outstring(5))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_7), tmpPc_Outstring(6))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_8), tmpPc_Outstring(7))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_9), tmpPc_Outstring(8))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_10), tmpPc_Outstring(9))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_11), tmpPc_Outstring(10))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_12), tmpPc_Outstring(11))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_13), tmpPc_Outstring(12))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_14), tmpPc_Outstring(13))
        '        System.Threading.Thread.Sleep(1)

        '        Dim j As Integer = 0
        '        For i As Integer = 0 To 13
        '            If pMelsec.PLC_Infomation.nBCR_A_DATA(i) <> 0 Then
        '                j = 0
        '                Continue For
        '            Else
        '                If j = 10 Then
        '                    Return False
        '                End If

        '                System.Threading.Thread.Sleep(1)
        '                j = j + 1
        '            End If
        '        Next

        '    Case 1
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_1), tmpPc_Outstring(0))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_2), tmpPc_Outstring(1))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_3), tmpPc_Outstring(2))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_4), tmpPc_Outstring(3))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_5), tmpPc_Outstring(4))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_6), tmpPc_Outstring(5))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_7), tmpPc_Outstring(6))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_8), tmpPc_Outstring(7))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_9), tmpPc_Outstring(8))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_10), tmpPc_Outstring(9))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_11), tmpPc_Outstring(10))
        '        System.Threading.Thread.Sleep(1)
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_12), tmpPc_Outstring(11))
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_13), tmpPc_Outstring(12))
        '        pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_14), tmpPc_Outstring(13))

        '        Dim j As Integer = 0
        '        For i As Integer = 0 To 13
        '            If pMelsec.PLC_Infomation.nBCR_B_DATA(i) <> 0 Then
        '                j = 0
        '                Continue For
        '            Else
        '                If j = 10 Then
        '                    Return False
        '                End If

        '                System.Threading.Thread.Sleep(1)
        '                j = j + 1

        '            End If

        '        Next

        'End Select

        Return True
        Exit Function

SysErr:
        Return False

    End Function
    Function ReSetBCRData_A() As Boolean
        On Error GoTo SysErr

        Dim tmpCmd() As String = {}
        Dim ntmpFirstCmd() As Integer = {}
        Dim ntmpSecondCmd() As Integer = {}
        Dim pPC_StrTemp As String = ""

        'ConvertWordToAsc(strBcr, tmpPc_Outstring)

        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_1), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_2), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_3), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_4), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_5), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_6), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_7), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_8), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_9), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_10), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_11), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_12), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_13), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_14), 0)

        Return True
        Exit Function

SysErr:
        Return False

    End Function
    Function ReSetBCRData_B() As Boolean
        On Error GoTo SysErr

        Dim tmpCmd() As String = {}
        Dim ntmpFirstCmd() As Integer = {}
        Dim ntmpSecondCmd() As Integer = {}
        Dim pPC_StrTemp As String = ""

        'ConvertWordToAsc(strBcr, tmpPc_Outstring)

        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_1), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_2), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_3), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_4), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_5), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_6), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_7), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_8), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_9), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_10), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_11), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_12), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_13), 0)
        'pMelsec.SendDataWord_TEST(CInt(PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_B_DATA_14), 0)

        Return True
        Exit Function

SysErr:
        Return False

    End Function
    '20160827 YDY

    '    Function SetModelName(ByVal IpString As String) As Boolean
    '        On Error GoTo SysErr
    '        Dim tmpCmd As String = ""
    '        Dim pPC_StrTemp As String = ""

    '        'ConvertWordToAsc(IpString, tmpPc_Outstring)

    '        'pMelsec.SendDataWord(clsMelsec.WWORD.W2E2_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(0)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2E3_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(1)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2E4_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(2)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2E5_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(3)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2E6_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(4)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2E7_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(5)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2E8_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(6)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2E9_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(7)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2EA_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(8)))
    '        'pMelsec.SendDataWord(clsMelsec.WORD.W2EB_CURRENT_RECIPE_NAME, Val("&H" & tmpPc_Outstring(9)))

    '        Return True
    '        Exit Function
    'SysErr:
    '        Return False
    '    End Function

    'Private Function ConvertAscToWord(ByVal outStrData() As String, ByRef OutString As String) As Boolean
    Public Function ConvertAscToWord(ByVal outStrData() As String, ByRef OutString As String) As Boolean
        On Error GoTo SysErr

        Dim cTmp() As String = {}
        Dim cTmp_sub() As String = {}
        Dim value() As Integer = {}
        Dim value_sub() As Integer = {}
        Dim toword() As Char = {}
        Dim toword_sub() As Char = {}
        Dim total() As Char = {}
        Dim tmpStr As String = ""

        ReDim cTmp(outStrData.Length - 1)
        ReDim cTmp_sub(outStrData.Length - 1)
        ReDim value(outStrData.Length - 1)
        ReDim toword(outStrData.Length - 1)
        ReDim value_sub(outStrData.Length - 1)
        ReDim toword_sub(outStrData.Length - 1)
        ReDim total(outStrData.Length - 1)

        For i As Integer = 0 To outStrData.Length - 1

            cTmp(i) = outStrData(i).Substring(0, 2)
            value(i) = Val("&h" & cTmp(i))
            toword(i) = Chr(value(i))
        Next

        For j As Integer = 0 To outStrData.Length - 1
            cTmp_sub(j) = outStrData(j).Substring(2, 2)
            value_sub(j) = Val("&h" & cTmp_sub(j))
            toword_sub(j) = Chr(value_sub(j))
        Next

        For l As Integer = 0 To toword.Length - 1
            tmpStr = tmpStr & toword_sub(l) & toword(l)
        Next

        OutString = tmpStr
        Return True
        Exit Function
SysErr:
        Return False

    End Function

    Public Function ConvertIntToWord(ByVal outStrData() As String, ByRef FirstOut() As Integer, ByRef SecondOut() As Integer) As Boolean
        On Error GoTo SysErr

        Dim cTmp() As Char = {}
        Dim cTmp_sub() As Char = {}
        Dim value() As Integer = {}
        Dim value_sub() As Integer = {}
        Dim ntmp As Integer = 0
        Dim ntmp2 As Integer = 0


        ReDim value(outStrData.Length - 1)
        ReDim cTmp(outStrData.Length - 1)
        ReDim cTmp_sub(outStrData.Length - 1)
        ReDim value_sub(outStrData.Length - 1)
        ReDim FirstOut(outStrData.Length - 1)
        ReDim SecondOut(outStrData.Length - 1)

        For i As Integer = 0 To outStrData.Length - 1
         
            value(i) = outStrData(i).Substring(0, 2)

        Next

        For j As Integer = 0 To outStrData.Length - 1
        
            value_sub(j) = outStrData(j).Substring(2, 2)

        Next

        ReDim FirstOut(value.Length - 1)
        ReDim SecondOut(value_sub.Length - 1)
        FirstOut = value_sub
        SecondOut = value
        'OutString = tmpStr


        Return True
        Exit Function
SysErr:
        Return False

    End Function




    Public Function ConvertWordToAsc(ByVal ipStrWord As String, ByRef outStrData() As String) As Boolean
        On Error GoTo SysErr
        Dim cTmp() As Char = {} '임시 배열공간 만들고 
        Dim str(CInt((ipStrWord.Length - 1) / 2)) As String ' E1-20160524 스트링 문자열로 변환 시킨후 13/2  
        Dim nCnt As Integer = 0

        ReDim cTmp(ipStrWord.Length - 1) '초기화 배열안에 E1-20160524의길이 -1 

        For i As Integer = 0 To ipStrWord.Length - 1 ' 0~13
            cTmp(i) = ipStrWord.Chars(i) ' cTmp(0)=IP(0)
        Next

        For j As Integer = 0 To cTmp.Length - 1 Step 2
            If j + 1 > cTmp.Length - 1 Then
                str(nCnt) = Val("&H" & "20" & Hex(AscW(cTmp(j))).ToString)
            Else
                str(nCnt) = Val("&H" & Hex(AscW(cTmp(j + 1))).ToString & Hex(AscW(cTmp(j))).ToString)
            End If
            nCnt = nCnt + 1
        Next

        ReDim outStrData(str.Length - 1)

        outStrData = str

        Return True
        Exit Function
SysErr:
        Return False
    End Function
    Public Function ConvertWordToInt(ByVal ipStrWord As String, ByRef outStrData() As String) As Boolean
        On Error GoTo SysErr


        Dim cTmp() As Char = {}
        '임시 배열공간 만들고 
        Dim str(CInt((ipStrWord.Length - 1) / 2)) As String ' E1-20160524 스트링 문자열로 변환 시킨후 13/2  
        Dim nCnt As Integer = 0
   

        ReDim cTmp(ipStrWord.Length - 1) '초기화 배열안에 E1-20160524의길이 -1 

        For i As Integer = 0 To ipStrWord.Length - 1 ' 0~13
            cTmp(i) = ipStrWord.Chars(i) ' cTmp(0)=IP(0)
        Next

        For j As Integer = 0 To cTmp.Length - 1 Step 2
            If j + 1 > cTmp.Length - 1 Then
                str(nCnt) = "20" & Hex(AscW(cTmp(j))).ToString

                If str(nCnt) = Nothing Then
                    str(nCnt) = "00"
                End If
            Else
                str(nCnt) = Hex(AscW(cTmp(j + 1))).ToString & Hex(AscW(cTmp(j))).ToString
             
            End If
            nCnt = nCnt + 1
          
        Next


        ReDim outStrData(str.Length - 1)



        outStrData = str

        If str(nCnt) = Nothing Then
            str(nCnt) = "0000"
        End If

        Return True
        Exit Function
SysErr:
        Return False
    End Function
    '    Public Function ConvertWordToInt_Test(ByVal ipStrWord As String, ByRef outStrData() As String) As Boolean
    '        On Error GoTo SysErr


    '        Dim cTmp() As Char = {}
    '        '임시 배열공간 만들고 
    '        Dim str(CInt((ipStrWord.Length - 1) / 2)) As String ' E1-20160524 스트링 문자열로 변환 시킨후 13/2  
    '        Dim nCnt As Integer = 0


    '        ReDim cTmp(ipStrWord.Length - 1) '초기화 배열안에 E1-20160524의길이 -1 

    '        For i As Integer = 0 To ipStrWord.Length - 1 ' 0~13
    '            cTmp(i) = ipStrWord(i) ' cTmp(0)=IP(0)
    '        Next





    '        For j As Integer = 0 To cTmp.Length - 1 Step 2
    '            If j + 1 > cTmp.Length - 1 Then
    '                str(nCnt) = "20" & cTmp(j).ToString

    '                If str(nCnt) = Nothing Then
    '                    str(nCnt) = "00"
    '                End If
    '            Else
    '                str(nCnt) = cTmp(j + 1).ToString & cTmp(j).ToString

    '            End If
    '            nCnt = nCnt + 1

    '        Next


    '        ReDim outStrData(str.Length - 1)



    '        outStrData = str

    '        If str(nCnt) = Nothing Then
    '            str(nCnt) = "0000"
    '        End If

    '        Return True
    '        Exit Function
    'SysErr:
    '        Return False
    '    End Function


    '20160906 JCM
    Function ResetMoveBit() As Boolean
        On Error GoTo SysErr
        Reset_Bit(BIT.WB_MOVE_REQUEST_STAGE_A_X)
        Reset_Bit(BIT.WB_MOVE_REQUEST_STAGE_A_Y)
        Reset_Bit(BIT.WB_MOVE_REQUEST_CAMERA_A_Z)
        Reset_Bit(BIT.WB_A_TRIMMING_COMP)

        Reset_Bit(BIT.WB_MOVE_REQUEST_STAGE_B_X)
        Reset_Bit(BIT.WB_MOVE_REQUEST_STAGE_B_Y)
        Reset_Bit(BIT.WB_MOVE_REQUEST_CAMERA_B_Z)
        Reset_Bit(BIT.WB_B_TRIMMING_COMP)

        Reset_Bit(BIT.WB_MOVE_REQUEST_SCANNER1_Z)
        Reset_Bit(BIT.WB_MOVE_REQUEST_SCANNER2_Z)
        Reset_Bit(BIT.WB_MOVE_REQUEST_SCANNER3_Z)
        Reset_Bit(BIT.WB_MOVE_REQUEST_SCANNER4_Z)

        Reset_Bit(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER1)
        Reset_Bit(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER2)
        Reset_Bit(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER3)
        Reset_Bit(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER4)

        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_X_MOVING_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_X_MOVING_POSITION2, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_Y_MOVING_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_Y_MOVING_POSITION2, 0)

        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_CAMERA_Z_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_CAMERA_Z_POSITION2, 0)

        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_X_MOVING_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_X_MOVING_POSITION2, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_Y_MOVING_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_Y_MOVING_POSITION2, 0)

        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_CAMERA_Z_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_CAMERA_Z_POSITION2, 0)

        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER1_Z_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER1_Z_POSITION2, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER2_Z_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER2_Z_POSITION2, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER3_Z_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER3_Z_POSITION2, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER4_Z_POSITION1, 0)
        pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER4_Z_POSITION2, 0)

        Return True
        Exit Function
SysErr:
        Return False
    End Function

   

    Function AliveBit() As Boolean

        'PC_Infomation.nPC_Alive = CInt(pPC_Word(clsMelsec.WWORD.WW_PC_ALIVE))

        If PC_Infomation.nPC_Alive = 0 Then

            SendDataWord_TEST(WWORD.WW_PC_ALIVE + PLC_WW_FIRST_ADDR, 1)

        Else

            SendDataWord_TEST(WWORD.WW_PC_ALIVE + PLC_WW_FIRST_ADDR, 0)

        End If


    End Function

    Function Test() As Boolean

        'Dim StrTemp As String = ""
        'StrTemp = "ABCDEF"

        'Dim tmpWord1 As Short = 0
        'Dim tmpWord2 As Short = 0

        'pMelsec.ConvertBCRDataToWordData(StrTemp, tmpWord1, tmpWord2)

        'Dim nAddr(2) As Integer
        'Dim nXAddr As Integer

        'nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_BCR_A_DATA_1
        'nAddr(0) = nXAddr '+ (nAxis * 2) + (nLine * &H10)
        'nAddr(1) = nXAddr + 1 ' (nAxis * 2) + (nLine * &H10) + 1

        'pMelsec.SendDataWord(nAddr(0), tmpWord1)
        'pMelsec.SendDataWord(nAddr(1), tmpWord2)

        'Dim nRet As Integer = 0

        'nRet = mdsend(pPath, Melsec_StationNO, DevW, nAddr(0), 2, tmpWord1)
        'If nRet = 0 Then
        '    modPub.MelsecLog("SetWord : " & nAddr(0).ToString & ", " & tmpWord1.ToString)

        'Else
        ' modPub.MelsecLog("SetWord Error : " & ipAddr.ToString & ", " & ipValue.ToString & ", " & nRet.ToString)
        'SetWord = False
        'End If

    End Function

    '2016116 JCM EDIT
    Function SetAllRecipePenData(ByVal RecipePenData As Object) As Boolean
        On Error GoTo SysErr
        Dim tmpStrAddress As String = ""
        Dim tmpStrCount As Integer = 4  '0
        Dim tmpStart As Integer = 16

        '20160922 JCM EDIT
        For i As Integer = 0 To 100 'RecipePenData.Length - 1

            'Laser Power1 - W1604
            tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData.LaserPower(i, 0))
            tmpStrCount = tmpStrCount + 1

            'Laser Power2 - W1605
            tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData.LaserPower(i, 1))
            tmpStrCount = tmpStrCount + 1

            'Laser Power3 - W1606
            tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData.LaserPower(i, 2))
            tmpStrCount = tmpStrCount + 1

            'Laser Power4 - W1607
            tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData.LaserPower(i, 3))
            tmpStrCount = tmpStrCount + 1

            For j As Integer = 0 To 14

                tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData(i).MarkSpeed(j))
                tmpStrCount = tmpStrCount + 1
                tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData(i).JumpSpeed(j))
                tmpStrCount = tmpStrCount + 1
                tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData(i).Repeat(j))
                tmpStrCount = tmpStrCount + 1
                tmpStrAddress = Hex(tmpStart) & tmpStrCount.ToString("D2")
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress), RecipePenData(i).MarkMode(j))
                tmpStrCount = tmpStrCount + 1

            Next

            tmpStart = tmpStart + 1

        Next

        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Function SetRecipePenData(ByVal CurRecipe As Object, ByVal ipRecipeNum As Integer, Optional ByVal bReset As Boolean = False) As Boolean
        On Error GoTo SysErr
        Dim tmpStrAddress As String = ""
        Dim tmpAPDStrAddress As String = ""
        'Dim tmpStrCount As Integer = 4
        Dim tmpStrCount As String = ""
        Dim tmpStart As Integer = 25344   '6300
        Dim tmpAPDStart As Integer = 25120 ' 6220

        'RYO
        Dim i As Integer = 0
        Dim SubStart As Integer = 0
        Dim dPower As Double = 0.0

        tmpStart = tmpStart + 2
        tmpStrAddress = Hex(tmpStart)
        If bReset = True Then
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        ElseIf bReset = False Then
            For i = 0 To 3

                Select Case i
                    Case 0 'Laser 2
                        dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 1).ToString)
                        'pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower) 'A1 : B2 - Laser 2
                        'pMelsec.SendDataWord(Val("&H" & 6352), dPower) '귀찮으니 하드코딩 하자 B2
                    Case 1 'Laser 1
                        tmpStrAddress = tmpStrAddress + 10
                        dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 0).ToString)
                        'pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower) 'A2 : B1 - Laser 1
                        'pMelsec.SendDataWord(Val("&H" & 6342), dPower)
                    Case 2 'Laser 4
                        tmpStrAddress = tmpStrAddress + 10
                        dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 3).ToString)
                        'pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower) 'A3 : B4 - Laser 4
                        'pMelsec.SendDataWord(Val("&H" & 6372), dPower)
                    Case 3 'Laser 3
                        tmpStrAddress = tmpStrAddress + 10
                        dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 2).ToString)
                        'pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower) 'A4 : B3 - Laser 3
                        'pMelsec.SendDataWord(Val("&H" & 6362), dPower)
                End Select
            Next
        End If

        'tmpStart = tmpStart + 2
        'For j = 0 To 8
        '    tmpStrAddress = Hex(tmpStart)
        '    If bReset = True Then
        '        pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        '    ElseIf bReset = False Then
        '        tmpStrAddress = tmpStrAddress + j * 10 '위치가 10단위로 증가한다. ex)6300 -> 6310 -> 6320
        '        pMelsec.SendDataWord(Val("&H" & tmpStrAddress), CurRecipe(ipRecipeNum - 1).MarkSpeed(j))
        '    End If
        '    tmpStart = tmpStart + 2
        '    tmpStrAddress = Hex(tmpStart)
        '    If bReset = True Then
        '        pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        '    ElseIf bReset = False Then
        '        tmpStrAddress = tmpStrAddress + j * 10
        '        pMelsec.SendDataWord(Val("&H" & tmpStrAddress), CurRecipe(ipRecipeNum - 1).Repeat(j))
        '    End If
        'Next


        'Recipe별 Start 변수 ex) RecipeNum:1 -> 시작번지 1600 번대.
        'tmpStart = tmpStart + -1
        'tmpStrAddress = Hex(tmpStart)
        'If bReset = True Then
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        'ElseIf bReset = False Then
        '    dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 0).ToString)
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower)
        'End If

        'tmpStart = tmpStart + 1
        'tmpStrAddress = Hex(tmpStart)
        'If bReset = True Then
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        'ElseIf bReset = False Then
        '    dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 1).ToString)
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower)
        'End If

        'tmpStart = tmpStart + 1
        'tmpStrAddress = Hex(tmpStart)
        'If bReset = True Then
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        'ElseIf bReset = False Then
        '    dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 2).ToString)
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower)
        'End If

        'tmpStart = tmpStart + 1
        'tmpStrAddress = Hex(tmpStart)
        'If bReset = True Then
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        'ElseIf bReset = False Then
        '    dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 3).ToString)
        '    pMelsec.SendDataWord(Val("&H" & tmpStrAddress), dPower)
        'End If
        tmpStart = tmpStart + 1
        tmpStrAddress = Hex(tmpStart)
        If bReset = True Then '6303 Pan Number 하드코딩 가즈아아아아
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress), 0)
        ElseIf bReset = False Then
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 0), ipRecipeNum)
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 10), ipRecipeNum)
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 20), ipRecipeNum)
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 30), ipRecipeNum)
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 40), ipRecipeNum)
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 50), ipRecipeNum)
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 60), ipRecipeNum)
            pMelsec.SendDataWord(Val("&H" & tmpStrAddress + 70), ipRecipeNum)
        End If

        'Panel Data 전달: Total 전달 예정.
        '이거 14로 한 이유?
        'For j As Integer = 0 To 14
        For j As Integer = 0 To 7
            Dim PenNumber As Integer = 0 '펜 데이터는 한개만 사용하기 때문에 그것만 불러오자!
            tmpStart = 25347
            tmpStrAddress = Hex(tmpStart)
            SubStart = 10 * j '10씩 증가
            tmpAPDStart = 25121 '6222
            tmpAPDStrAddress = Hex(tmpAPDStart)

            'XX08 * 4 상승
            tmpStart = tmpStart + 1
            tmpStrAddress = Hex(tmpStart)
            tmpAPDStart = tmpAPDStart + 1
            tmpAPDStrAddress = Hex(tmpAPDStart)
            If bReset = True Then '6304 MarkSpeed
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress + SubStart), 0)
                pMelsec.SendDataWord(Val("&H" & tmpAPDStrAddress + SubStart), 0)
            ElseIf bReset = False Then
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).MarkSpeed(PenNumber))
                pMelsec.SendDataWord(Val("&H" & tmpAPDStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).MarkSpeed(PenNumber))
            End If

            tmpStart = tmpStart + 1
            tmpStrAddress = Hex(tmpStart)
            If bReset = True Then '6305 JumpSpeed
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress + SubStart), 0)
            ElseIf bReset = False Then
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).JumpSpeed(PenNumber))
            End If

            tmpStart = tmpStart + 1
            tmpStrAddress = Hex(tmpStart)
            tmpAPDStart = tmpAPDStart + 1
            tmpAPDStrAddress = Hex(tmpAPDStart)
            If bReset = True Then '6306 Repeat
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress + SubStart), 0)
                pMelsec.SendDataWord(Val("&H" & tmpAPDStrAddress + SubStart), 0)
            ElseIf bReset = False Then
                pMelsec.SendDataWord(Val("&H" & tmpStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).Repeat(PenNumber))
                pMelsec.SendDataWord(Val("&H" & tmpAPDStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).Repeat(PenNumber))
            End If
        Next

        Return True
        Exit Function
SysErr:
        Return False
    End Function


    Public Function APD_DATA(ByVal nLine As Integer, ByVal nAxis As Integer, ByVal ipPosition As Double)
        On Error GoTo SysErr
        'Dim tmpWord1 As Short = 0
        'Dim tmpWord2 As Short = 0
        'Dim tmpMovePos As Integer = ipPosition * 1000
        'pMelsec.ConvertStageDataToWordData(tmpMovePos, tmpWord1, tmpWord2)

        'Dim nAddr(2) As Integer
        'Dim nXAddr As Integer
        'Dim bXReqAddr As BIT

        ' WW_STAGE_A_X_MOVING_POSITION1 = &H80
        'GYN - TEST (수정한 부분)
        'If nLine = 0 Then
        '    Select Case nAxis
        '        Case 0
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A1_MARKING_ALLIGNOFFSET_X_1
        '        Case 1
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A1_MARKING_ALLIGNOFFSET_Y_1
        '        Case 2
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A2_MARKING_ALLIGNOFFSET_X_1
        '        Case 3
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A2_MARKING_ALLIGNOFFSET_Y_1
        '        Case 4
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A3_MARKING_ALLIGNOFFSET_X_1
        '        Case 5
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A3_MARKING_ALLIGNOFFSET_Y_1
        '        Case 6
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A4_MARKING_ALLIGNOFFSET_X_1
        '        Case 7
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_A4_MARKING_ALLIGNOFFSET_Y_1
        '    End Select

        'ElseIf nLine = 1 Then
        '    Select Case nAxis
        '        Case 0
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B1_MARKING_ALLIGNOFFSET_X_1
        '        Case 1
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B1_MARKING_ALLIGNOFFSET_Y_1
        '        Case 2
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B2_MARKING_ALLIGNOFFSET_X_1
        '        Case 3
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B2_MARKING_ALLIGNOFFSET_Y_1
        '        Case 4
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B3_MARKING_ALLIGNOFFSET_X_1
        '        Case 5
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B3_MARKING_ALLIGNOFFSET_Y_1
        '        Case 6
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B4_MARKING_ALLIGNOFFSET_X_1
        '        Case 7
        '            nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_B4_MARKING_ALLIGNOFFSET_Y_1
        '    End Select
        'End If

        'nAddr(0) = nXAddr '+ (nAxis * 2) + (nLine * &H10)
        'nAddr(1) = nXAddr + 1 ' (nAxis * 2) + (nLine * &H10) + 1

        'pMelsec.SendDataWord(nAddr(0), tmpWord1)
        'pMelsec.SendDataWord(nAddr(1), tmpWord2)

        'For i As Integer = 0 To 500
        '    Thread.Sleep(1)
        'Next

        Return True

        Exit Function
SysErr:
        Return False
    End Function

    '20180411 chy Displace PLC Send
    Public Function DisplacePLCSend(ByVal strtemp As String, ByVal nLine As Integer)
        On Error GoTo SysErr
        Dim tmpWord1 As Short = 0
        Dim tmpWord2 As Short = 0
        Dim tmpDispalcePos As Integer
        tmpDispalcePos = CInt(strtemp * 10000)
        Select Case nLine
            Case 0
                pMelsec.ConvertStageDataToWordData(tmpDispalcePos, tmpWord1, tmpWord2)
                pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_A1, tmpWord1)
                pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_A2, tmpWord2)
            Case 1
                pMelsec.ConvertStageDataToWordData(tmpDispalcePos, tmpWord1, tmpWord2)
                pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_B1, tmpWord1)
                pMelsec.SendDataWord(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_B2, tmpWord2)
        End Select

SysErr:
        Return False
    End Function

    'bsseo pre-align
    Function SetPreAlignData(ByVal nLine As Integer, ByVal nChuck As Integer, ByVal posX As Double, ByVal posY As Double, ByVal posT As Double) As Boolean
        On Error GoTo SysErr

        Dim tmpWordX1 As Short = 0
        Dim tmpWordX2 As Short = 0
        Dim tmpWordY1 As Short = 0
        Dim tmpWordY2 As Short = 0
        Dim tmpWordT1 As Short = 0
        Dim tmpWordT2 As Short = 0

        Dim tmpXPos As Integer = posX * 1000
        Dim tmpYPos As Integer = posY * 1000
        Dim tmpTPos As Integer = posT * 1000

        pMelsec.ConvertStageDataToWordData(tmpXPos, tmpWordX1, tmpWordX2)
        pMelsec.ConvertStageDataToWordData(tmpYPos, tmpWordY1, tmpWordY2)
        pMelsec.ConvertStageDataToWordData(tmpTPos, tmpWordT1, tmpWordT2)

        Dim nAddrX(1) As Integer
        Dim nAddrY(1) As Integer
        Dim nAddrT(1) As Integer
        Dim nAddr As Integer

        Dim nXAddr As Integer
        'Dim bUReqAddr As BIT

        Dim nYAddr As Integer
        'Dim bVReqAddr As BIT

        Dim nTAddr As Integer
        'Dim bWReqAddr As BIT

        If nLine = 0 Then

            Select Case nChuck

                Case 0
                    'bUReqAddr = clsMelsec.BIT.WB_PRE_ALIGN_A_DATA_WRITE
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE1_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE1_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE1_OFFSETT_POSITION1
                Case 1
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE2_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE2_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE2_OFFSETT_POSITION1
                Case 2
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE3_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE3_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE3_OFFSETT_POSITION1
                Case 3
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE4_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE4_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_A_STAGE4_OFFSETT_POSITION1

            End Select

        Else

            Select Case nChuck
                Case 0
                    'bUReqAddr = clsMelsec.BIT.WB_PRE_ALIGN_B_DATA_WRITE
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE1_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE1_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE1_OFFSETT_POSITION1
                Case 1
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE2_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE2_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE2_OFFSETT_POSITION1
                Case 2
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE3_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE3_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE3_OFFSETT_POSITION1
                Case 3
                    nXAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE3_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE3_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + clsMelsec.WWORD.WW_STAGE_B_STAGE3_OFFSETT_POSITION1

            End Select

        End If

        nAddrX(0) = nXAddr
        nAddrX(1) = nXAddr + 1
        nAddrY(0) = nYAddr
        nAddrY(1) = nYAddr + 1
        nAddrT(0) = nTAddr
        nAddrT(1) = nTAddr + 1

        'nAddr = bXReqAddr

        pMelsec.SendDataWord_TEST(nAddrX(0), tmpWordX1)
        Thread.Sleep(1)
        pMelsec.SendDataWord_TEST(nAddrX(1), tmpWordX2)
        Thread.Sleep(1)
        pMelsec.SendDataWord_TEST(nAddrY(0), tmpWordY1)
        Thread.Sleep(1)
        pMelsec.SendDataWord_TEST(nAddrY(1), tmpWordY2)
        Thread.Sleep(1)
        pMelsec.SendDataWord_TEST(nAddrT(0), tmpWordT1)
        Thread.Sleep(1)
        pMelsec.SendDataWord_TEST(nAddrT(1), tmpWordT2)
        Thread.Sleep(1)

        'pMelsec.SendDataWord(nAddrU(0), tmpWordU1)
        'pMelsec.SendDataWord(nAddrU(1), tmpWordU2)
        'pMelsec.SendDataWord(nAddrV(0), tmpWordV1)
        'pMelsec.SendDataWord(nAddrV(1), tmpWordV2)
        'pMelsec.SendDataWord(nAddrW(0), tmpWordW1)
        'pMelsec.SendDataWord(nAddrW(1), tmpWordW2)

        For i As Integer = 0 To 10 ' 500
            Thread.Sleep(1)
        Next

        'modPub.TestLog("Line:" & nLine.ToString() & ",CHUCK:" & nChuck.ToString() & ",DATA U:" & tmpWordU1.ToString() & "," & tmpWordU2.ToString())
        'modPub.TestLog("Line:" & nLine.ToString() & ",CHUCK:" & nChuck.ToString() & ",DATA V:" & tmpWordV1.ToString() & "," & tmpWordV2.ToString())
        'modPub.TestLog("Line:" & nLine.ToString() & ",CHUCK:" & nChuck.ToString() & ",DATA W:" & tmpWordW1.ToString() & "," & tmpWordW2.ToString())


        'pMelsec.Set_Bit(nAddr) 'Align Data Write 완료 신호 ON

        Return True

        Exit Function
SysErr:
        Return False
    End Function

End Class




