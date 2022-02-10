Module modAlarmTable

    Public Structure _tagAlarm

        Dim strType As String
        Dim iAlarmNo As Integer
        Dim iAlarmCode As Integer
        Dim strAlarmName As String
        Dim strAlarmDescript As String
        Dim strAlarmType As String

    End Structure

    '20180501 chy
    Public LaserInitAlarm() As Boolean
    Sub New()
        ReDim LaserInitAlarm(3)
        LaserInitAlarm(0) = False
        LaserInitAlarm(1) = False
        LaserInitAlarm(2) = False
        LaserInitAlarm(3) = False
    End Sub
    Enum iAlarmCode
        ERROR_MARK_DIST_A = 1
        ERROR_MARK_DIST_B = 2

        ERROR_LASER_1_OFF = 3
        ERROR_LASER_2_OFF = 4
        ERROR_LASER_3_OFF = 5
        ERROR_LASER_4_OFF = 6

        ERROR_CONNECT_LASER_1 = 7
        ERROR_CONNECT_LASER_2 = 8
        ERROR_CONNECT_LASER_3 = 9
        ERROR_CONNECT_LASER_4 = 10

        ERROR_CONNECT_POWERMETER_1 = 11
        ERROR_CONNECT_POWERMETER_2 = 12
        ERROR_CONNECT_POWERMETER_3 = 13
        ERROR_CONNECT_POWERMETER_4 = 14

        ERROR_CONNECT_SCANNER_1 = 15
        ERROR_CONNECT_SCANNER_2 = 16
        ERROR_CONNECT_SCANNER_3 = 17
        ERROR_CONNECT_SCANNER_4 = 18

        ERROR_CONNECT_CHILLER_1 = 19
        ERROR_CONNECT_CHILLER_2 = 20
        ERROR_CONNECT_CHILLER_3 = 21
        ERROR_CONNECT_CHILLER_4 = 22

        ERROR_CONNECT_CAMERA_1 = 23
        ERROR_CONNECT_CAMERA_2 = 24
        ERROR_CONNECT_CAMERA_3 = 25
        ERROR_CONNECT_CAMERA_4 = 26

        ERROR_CONNECT_POWERMETER_STAGE = 27
        ERROR_CONNECT_DUSTCOLLECTOR = 28
        ERROR_CONNECT_DUSTCOLLECTOR_INVERTOR = 29
        ERROR_CONNECT_LIGHT = 30
        ERROR_CONNECT_MELSEC = 31

        ERROR_CONNECT_IO = 32

        ERROR_LASER_OFF = 33
        ERROR_LASER_MODE = 34
        ERROR_LASER_1_SHUTTER_CLOSE = 35
        ERROR_LASER_2_SHUTTER_CLOSE = 36
        ERROR_LASER_3_SHUTTER_CLOSE = 37
        ERROR_LASER_4_SHUTTER_CLOSE = 38
        ''Alarm Merge
        ''Laser ErrCode
        ERROR_HEAD_INT_FAULT = 39
        ERROR_EXT_INT_FAULT = 43
        ERROR_INT0_INT_FAULT = 47
        ERROR_BUS_COMMUNICATION_FAULT = 51
        ERROR_STATE_MACHINE_TIMEOUT_FAULT = 55
        ERROR_SYS_CONF_NOT_PARSED_FAULT = 59
        ERROR_SYS_CONF_NOT_VERIFIED_FAULT = 63
        ERROR_SYS_SEQUENCE_NOT_PARSED_FAULT = 67
        ERROR_SHG_TEMP_FAULT = 71
        ERROR_THG_TEMP_FAULT = 75
        ERROR_DIODE1_TEMP_FAULT = 79
        ERROR_DIODE2_TEMP_FAULT = 83
        ERROR_DIODE3_TEMP_FAULT = 87
        ERROR_BASEPLATE1_TEMP_FAULT = 91
        ERROR_BASEPLATE2_TEMP_FAULT = 95
        ERROR_SPE_INT_FAULT = 99
        ERROR_DIODE1_INITIALIZATION_FAULT = 103
        ERROR_DIODE2_INITIALIZATION_FAULT = 107
        ERROR_DIODE3_INITIALIZATION_FAULT = 111
        ERROR_SHUTTER_INITIALZATION_FAULT = 115
        ERROR_SEEDER_OPENCOMPORT_FAULT = 119
        ERROR_SEEDER_INITIALIZATION_FAULT = 123
        ERROR_RECIRCULATOR_INITIALIZATION_FAULT = 127
        ERROR_WATER_FLOW_LOW_FAULT = 131
        ERROR_WATER_FLOW_HIGH_FAULT = 135
        ERROR_WATER_TEMPERATURE_LOW_FAULT = 139
        ERROR_WATER_TEMPERATURE_HIGH_FAULT = 143
        ERROR_WATER_FLOW_INITIALIZATION_FAULT = 147
        ERROR_THREAD_EXCEPTION_FAULT = 151
        ERROR_HEAD_HUMIDITY_1_VERY_HIGH_FAULT = 155
        ERROR_HEAD_HUMIDITY_2_VERY_HIGH_FAULT = 159
        ERROR_HEAD_HUMIDITY_3_VERY_HIGH_FAULT = 163
        ERROR_HUMIDITY1_INITIALIZATION_FAULT = 167
        ERROR_HUMIDITY2_INITIALIZATION_FAULT = 171
        ERROR_HUMIDITY3_INITIALIZATION_FAULT = 175
        ERROR_PD1_INITIALIZATION_FAULT = 179
        ERROR_PD2_INITIALIZATION_FAULT = 183
        ERROR_PD3_INITIALIZATION_FAULT = 187
        ERROR_PD4_INITIALIZATION_FAULT = 191
        ERROR_PD5_INITIALIZATION_FAULT = 195
        ERROR_PD6_INITIALIZATION_FAULT = 199
        ERROR_PD7_INITIALIZATION_FAULT = 203
        ERROR_PD8_INITIALIZATION_FAULT = 207
        ERROR_PD9_INITIALIZATION_FAULT = 211
        ERROR_PD10_INITIALIZATION_FAULT = 215
        ERROR_PD11_INITIALIZATION_FAULT = 219
        ERROR_PD12_INITIALIZATION_FAULT = 223
        ERROR_PD13_INITIALIZATION_FAULT = 227
        ERROR_PD14_INITIALIZATION_FAULT = 231
        ERROR_ATTENUATOR_INITIALIZATION_FAULT = 235
        ERROR_SHG_INITIALIZATION_FAULT = 239
        ERROR_THG_INITIALIZATION_FAULT = 243
        ERROR_SHG_SERVO_STUCK_FAULT = 247
        ERROR_SHG_LOW_DRIVE_FAULT = 251
        ERROR_SHG_MAX_TEMP_DIFF_FAULT = 255
        ERROR_THG_SERVO_STUCK_FAULT = 259
        ERROR_THG_LOW_DRIVE_FAULT = 263
        ERROR_THG_MAX_TEMP_DIFF_FAULT = 267
        ERROR_DIODEDRIVER_START_FAULT = 271
        ERROR_EMERGENCYSTOP_FAULT = 275
        ERROR_SHUTTER_HIGHTEMP_FAULT = 279
        ERROR_WATCHDOG_TIMEOUT_FAULT = 283
        ERROR_THREAD_STALLED_FAULT = 287
        ERROR_HEARTBEAT_FAULT = 291
        ERROR_FPGA_READ_FAULT = 295
        ERROR_FPGA_INSTALLED_FAULT = 299
        ERROR_POST_FAULT = 303
        ERROR_FPGA_WRITE_FAULT = 307
        ERROR_HEAD_HUMIDITY_0_WARNING = 311
        ERROR_HEAD_HUMIDITY_1_WARNING = 315
        ERROR_HEAD_HUMIDITY_2_WARNING = 319
        ERROR_HEAD_HUMIDITY_3_WARNING = 323
        ERROR_WATER_FLOW_LOW_WARNING = 327
        ERROR_WATER_FLOW_HIGH_WARNING = 331
        ERROR_WATER_TEMPERATURE_LOW_WARNING = 335
        ERROR_WATER_TEMPERATURE_HIGH_WARNING = 339
        ERROR_SHG_LOW_DRIVE_WARNING = 343
        ERROR_THG_LOW_DRIVE_WARNING = 347
        ERROR_AMPCURRENT_OUTOFRANGE_WARNIN = 351
        ERROR_SEEDER_AUTHENTICATION_WARNING = 355
        ERROR_SEEDER_COMMUNICATION_WARNING = 359
        ERROR_ATTENUATOR_SETPOWER_WARNING1 = 363
        ERROR_ATTENUATOR_SETPOWER_WARNING2 = 367
        ERROR_BOOTLOADER_VERSION_WARNING = 371
        ERROR_IMAGE_VERSION_WARNING = 375
        ERROR_OS_VERSION_WARNING = 379
        ERROR_THREAD_STALLED_WARNING = 383
        ERROR_CPU_TEMPERATURE_WARNING = 387
        ERROR_RTC_BATTERY_WARNING = 391


        'Chiller ErrCode
        ERROR_LEVEL_WARNING = 395
        ERROR_LEVEL_ERROR = 399
        ERROR_HIGH_WARNING_TEMP = 403
        ERROR_HIGH_ERROR_TEMP = 407
        ERROR_LOW_WARNING_TEMP = 411
        ERROR_LOW_ERROR_TEMP = 415
        ERROR_FLOW_ERROR = 419

        'Laser Pass Mode 
        ERROR_PULSEMODE_CHECK = 423
        ERROR_CAMERA_OFF = 427

        'Chiller Temp
        ERROR_CHILLER_TEMP = 431

        'Laser Alarm add
        ERROR_SEQUENCE_EXCUTION = 439

        'Laser Diode Service warning
        ERROR_DIODE_D1_SERVICE = 443
        ERROR_DIODE_D2_SERVICE = 447
        ERROR_DIODE_D3_SERVICE = 451
        ERROR_MAINTENANCE_REQUIRED = 455

        '20190807 GUI 1.9 New Alarm
        ERROR_DIODE1_FIBERBROKEN_FAULT = 459
        ERROR_DIODE2_FIBERBROKEN_FAULT = 463
        ERROR_DIODE3_FIBERBROKEN_FAULT = 467
        ERROR_SYS_SEQUENCE_NOT_LOADED_FAULT = 471
        ERROR_SYS_SEQUENCE_WRONG_INDEXING_FAULT = 475
        ERROR_SYS_SEQUENCE_WRONG_COMMAND = 479
        ERROR_SYS_SEQUENCE_FILE_MISSING = 483
        ERROR_SYS_SEQUENCE_NO_VALID_STEPS_DETECTED = 487
        ERROR_HEAD_DEWPOINT_1_VERY_HIGH_FAULT = 491
        ERROR_HEAD_DEWPOINT_2_VERY_HIGH_FAULT = 495
        ERROR_HEAD_DEWPOINT_3_VERY_HIGH_FAULT = 499
        ERROR_HEAD_DEWPOINT_1_WARNING = 503
        ERROR_HEAD_DEWPOINT_2_WARNING = 507
        ERROR_HEAD_DEWPOINT_3_WARNING = 511
        ERROR_DIODE1_EMLOS_WARNING = 515
        ERROR_DIODE2_EMLOS_WARNING = 519
        ERROR_DIODE3_EMLOS_WARNING = 523
        '20190807 Laser Power Limit
        ERROR_LASER_POWER_SETTING_LIMIT = 527
        ' Sbs_20190503 운전중 집진기가 10초 이상 Stop 상태가 지속되면 Heavy 알람 울리게 한다
        ERROR_DUSTCOLLECTOR_STOP = 531
        ERROR_LASER_COMM_ERROR = 532
    End Enum
    Public iAlarmTotalCnt As Integer = 0
    Public _tAlarm() As _tagAlarm
    Public bAlarmLight = False
    Dim strFilePath As String = ""

    Public nAlarmCheck(20) As Integer
    Public iAlertCode() As Integer
    Public nCount As Integer = 0
    

    'Alarm 발생 유/무관련 Flag
    Public bAlarmUse As Boolean = False

    'ini파일로 Data 읽어드리자.
    Public Function LoadAlarmFile() As Boolean

        '이거 우선? 하드코딩으로 넣어놓자.
        strFilePath = "C:\Chamfering System\Setting\AlarmList\DEFAULT.ini"

        iAlarmTotalCnt = ReadIni("TOTAL_COUNT_INFO", "TOTAL_COUNT", 0, strFilePath)

        '알람List Total Cnt를 넣어준다.
        ReDim _tAlarm(iAlarmTotalCnt)

        For i As Integer = 0 To iAlarmTotalCnt
            _tAlarm(i).strType = ReadIni("ALARM_LIST_INFO_" & i, "TYPE", "PC", strFilePath)
            _tAlarm(i).iAlarmNo = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_NO", 0, strFilePath)
            _tAlarm(i).iAlarmCode = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_CODE", 0, strFilePath)
            _tAlarm(i).strAlarmName = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_NAME", "NONE", strFilePath)
            _tAlarm(i).strAlarmDescript = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_DESCRIPT", "NONE", strFilePath)
            _tAlarm(i).strAlarmType = ReadIni("ALARM_LIST_INFO_" & i, "ALARM_TYPE", "NONE", strFilePath)
        Next

    End Function

    Public Function SaveAlarmFile() As Boolean

        '이거 우선? 하드코딩으로 넣어놓자.
        strFilePath = "C:\Chamfering System\Setting\AlarmList\DEFAULT.ini"

        WriteIni("TOTAL_COUNT_INFO", "TOTAL_COUNT", iAlarmTotalCnt, strFilePath)

        '알람List Total Cnt를 넣어준다.
        ReDim _tAlarm(iAlarmTotalCnt)

        For i As Integer = 0 To iAlarmTotalCnt
            WriteIni("ALARM_LIST_INFO_" & i, "TYPE", _tAlarm(i).strType, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_NO", _tAlarm(i).iAlarmNo, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_CODE", _tAlarm(i).iAlarmCode, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_NAME", _tAlarm(i).strAlarmName, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_DESCRIPT", _tAlarm(i).strAlarmDescript, strFilePath)
            WriteIni("ALARM_LIST_INFO_" & i, "ALARM_TYPE", _tAlarm(i).strAlarmType, strFilePath)
        Next

    End Function

    Public Function GetAlarm(ByRef iAlarmCode As Integer, ByRef _Alarm As _tagAlarm) As Boolean

        For i As Integer = 0 To iAlarmTotalCnt

            If iAlarmCode = _tAlarm(i).iAlarmCode Then

                _Alarm = _tAlarm(i)

            End If

        Next

    End Function

End Module
