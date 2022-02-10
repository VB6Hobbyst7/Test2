﻿Imports System.Threading

Public Class clsLDLT


    Private ThreadMXComponent As Thread
    Private bThreadRunningMXComponent As Boolean
    Private nKillThreadMXComponent As Integer

    Private ThreadMXComponentStatus As Thread
    Private bThreadRunningMXComponentStatus As Boolean
    Private nKillThreadMXComponentStatus As Integer

    Private qCmd As New Queue
    Private lockCmd As New Object
    '20211220_Large Diameter(대구경) LT PLC기반  
    Public Const PLC_WW_FIRST_ADDR = &H11000
    Public Const PLC_RW_FIRST_ADDR = &H10000

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
        WB_MOVE_REQUEST_SCANNER3_Z = &H54B1  'WB_MOVE_REQUEST_SCANNER3_Z = &H275
        WB_MOVE_REQUEST_SCANNER2_Z = &H54B2  'WB_MOVE_REQUEST_SCANNER2_Z = &H274
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

        RW_STAGE_A_X_ALIGN_1_POSITION1 = &H110
        RW_STAGE_A_X_ALIGN_1_POSITION2 = &H111
        RW_STAGE_A_Y_ALIGN_1_POSITION1 = &H112
        RW_STAGE_A_Y_ALIGN_1_POSITION2 = &H113

        RW_STAGE_A_X_ALIGN_2_POSITION1 = &H114
        RW_STAGE_A_X_ALIGN_2_POSITION2 = &H115
        RW_STAGE_A_Y_ALIGN_2_POSITION1 = &H116
        RW_STAGE_A_Y_ALIGN_2_POSITION2 = &H117

        RW_STAGE_A_X_ALIGN_3_POSITION1 = &H118
        RW_STAGE_A_X_ALIGN_3_POSITION2 = &H119
        RW_STAGE_A_Y_ALIGN_3_POSITION1 = &H11A
        RW_STAGE_A_Y_ALIGN_3_POSITION2 = &H11B

        RW_STAGE_A_X_ALIGN_4_POSITION1 = &H11C
        RW_STAGE_A_X_ALIGN_4_POSITION2 = &H11D
        RW_STAGE_A_Y_ALIGN_4_POSITION1 = &H11E
        RW_STAGE_A_Y_ALIGN_4_POSITION2 = &H11F

        RW_STAGE_A_X_TRIMMING_POSITION1 = &H120
        RW_STAGE_A_X_TRIMMING_POSITION2 = &H121
        RW_STAGE_A_Y_TRIMMING_POSITION1 = &H122
        RW_STAGE_A_Y_TRIMMING_POSITION2 = &H123

        RW_STAGE_A_X_CURRENT_POSITION1 = &H140
        RW_STAGE_A_X_CURRENT_POSITION2 = &H141
        RW_STAGE_A_Y_CURRENT_POSITION1 = &H142
        RW_STAGE_A_Y_CURRENT_POSITION2 = &H143

        RW_STAGE_A_CAMERA_Z_CURRENT_POSITION1 = &H144
        RW_STAGE_A_CAMERA_Z_CURRENT_POSITION2 = &H145

        RW_STAGE_B_X_ALIGN_1_POSITION1 = &H170
        RW_STAGE_B_X_ALIGN_1_POSITION2 = &H171
        RW_STAGE_B_Y_ALIGN_1_POSITION1 = &H172
        RW_STAGE_B_Y_ALIGN_1_POSITION2 = &H173

        RW_STAGE_B_X_ALIGN_2_POSITION1 = &H174
        RW_STAGE_B_X_ALIGN_2_POSITION2 = &H175
        RW_STAGE_B_Y_ALIGN_2_POSITION1 = &H176
        RW_STAGE_B_Y_ALIGN_2_POSITION2 = &H177

        RW_STAGE_B_X_ALIGN_3_POSITION1 = &H178
        RW_STAGE_B_X_ALIGN_3_POSITION2 = &H179
        RW_STAGE_B_Y_ALIGN_3_POSITION1 = &H17A
        RW_STAGE_B_Y_ALIGN_3_POSITION2 = &H17B

        RW_STAGE_B_X_ALIGN_4_POSITION1 = &H17C
        RW_STAGE_B_X_ALIGN_4_POSITION2 = &H17D
        RW_STAGE_B_Y_ALIGN_4_POSITION1 = &H17E
        RW_STAGE_B_Y_ALIGN_4_POSITION2 = &H17F

        RW_STAGE_B_X_TRIMMING_POSITION1 = &H180
        RW_STAGE_B_X_TRIMMING_POSITION2 = &H181
        RW_STAGE_B_Y_TRIMMING_POSITION1 = &H182
        RW_STAGE_B_Y_TRIMMING_POSITION2 = &H183

        RW_STAGE_B_X_CURRENT_POSITION1 = &H1A0
        RW_STAGE_B_X_CURRENT_POSITION2 = &H1A1
        RW_STAGE_B_Y_CURRENT_POSITION1 = &H1A2
        RW_STAGE_B_Y_CURRENT_POSITION2 = &H1A3

        RW_STAGE_B_CAMERA_Z_CURRENT_POSITION1 = &H1A4
        RW_STAGE_B_CAMERA_Z_CURRENT_POSITION2 = &H1A5

        RW_STAGE_SCANNER1_Z_CURRENT_POSITION1 = &H1D0
        RW_STAGE_SCANNER1_Z_CURRENT_POSITION2 = &H1D1
        RW_STAGE_SCANNER2_Z_CURRENT_POSITION1 = &H1D2
        RW_STAGE_SCANNER2_Z_CURRENT_POSITION2 = &H1D3
        RW_STAGE_SCANNER3_Z_CURRENT_POSITION1 = &H1D4
        RW_STAGE_SCANNER3_Z_CURRENT_POSITION2 = &H1D5
        RW_STAGE_SCANNER4_Z_CURRENT_POSITION1 = &H1D6
        RW_STAGE_SCANNER4_Z_CURRENT_POSITION2 = &H1D7

        RW_TIME_DATA_YEAR = &H1F0
        RW_TIME_DATA_MONTH = &H1F1
        RW_TIME_DATA_DAY = &H1F2
        RW_TIME_DATA_HOUR = &H1F3
        RW_TIME_DATA_MINUTE = &H1F4
        RW_TIME_DATA_SECOND = &H1F5

        RW_COPY_RECIPE_NUMBER = &H200
        RW_COPY_RECIPE_NAME0 = &H202
        RW_COPY_RECIPE_NAME1 = &H203
        RW_COPY_RECIPE_NAME2 = &H204
        RW_COPY_RECIPE_NAME3 = &H205
        RW_COPY_RECIPE_NAME4 = &H206
        RW_COPY_RECIPE_NAME5 = &H207
        RW_COPY_RECIPE_NAME6 = &H208
        RW_COPY_RECIPE_NAME7 = &H209
        RW_COPY_RECIPE_NAME8 = &H20A
        RW_COPY_RECIPE_NAME9 = &H20B

        RW_RECIPE_NUMBER = &H210
        RW_CURRENT_RECIPE_NAME0 = &H212
        RW_CURRENT_RECIPE_NAME1 = &H213
        RW_CURRENT_RECIPE_NAME2 = &H214
        RW_CURRENT_RECIPE_NAME3 = &H215
        RW_CURRENT_RECIPE_NAME4 = &H216
        RW_CURRENT_RECIPE_NAME5 = &H217
        RW_CURRENT_RECIPE_NAME6 = &H218
        RW_CURRENT_RECIPE_NAME7 = &H219
        RW_CURRENT_RECIPE_NAME8 = &H21A
        RW_CURRENT_RECIPE_NAME9 = &H21B

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

        WW_STAGE_A_X_MOVING_POSITION1 = &H120
        WW_STAGE_A_X_MOVING_POSITION2 = &H121
        WW_STAGE_A_Y_MOVING_POSITION1 = &H122
        WW_STAGE_A_Y_MOVING_POSITION2 = &H123
        WW_STAGE_A_CAMERA_Z_POSITION1 = &H124
        WW_STAGE_A_CAMERA_Z_POSITION2 = &H125

        WW_STAGE_B_X_MOVING_POSITION1 = &H170
        WW_STAGE_B_X_MOVING_POSITION2 = &H171
        WW_STAGE_B_Y_MOVING_POSITION1 = &H172
        WW_STAGE_B_Y_MOVING_POSITION2 = &H173
        WW_STAGE_B_CAMERA_Z_POSITION1 = &H174
        WW_STAGE_B_CAMERA_Z_POSITION2 = &H175

        WW_STAGE_SCANNER1_Z_POSITION1 = &H1B0
        WW_STAGE_SCANNER1_Z_POSITION2 = &H1B1
        WW_STAGE_SCANNER3_Z_POSITION1 = &H1B2
        WW_STAGE_SCANNER3_Z_POSITION2 = &H1B3
        WW_STAGE_SCANNER2_Z_POSITION1 = &H1B4
        WW_STAGE_SCANNER2_Z_POSITION2 = &H1B5
        WW_STAGE_SCANNER4_Z_POSITION1 = &H1B6
        WW_STAGE_SCANNER4_Z_POSITION2 = &H1B7

        '20180411 chy displace send
        WW_DISPLACE_SEND_A1 = &H1C0
        WW_DISPLACE_SEND_A2 = &H1C1
        WW_DISPLACE_SEND_B1 = &H1C2
        WW_DISPLACE_SEND_B2 = &H1C3

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
        Dim dAlignPosX(,) As Double
        Dim dAlignPosY(,) As Double

        Dim dTrimmingPosX() As Double                      'A:W5120,W5121, B:W5180,W5181
        Dim dTrimmingPosY() As Double                      'A:W5122,W5123, B:W5182,W5183

        Dim dCurPosX() As Double                           'A:W5140,W5141, B:W5140,W5141
        Dim dCurPosY() As Double                           'A:W5142,W5143, B:W5142,W5143
        Dim dCurPosCameraZ1() As Double                    'A:W5144,W5145, B:W5144,W5145
        Dim dCurPosCameraZ2() As Double                    'A:W5144,W5145, B:W5144,W5145

        Dim dCurPosScannerZ() As Double                    'W:51D0,W:51D1,W:51D2,W:51D3,W:51D4,W:51D5,W:51D6,W:51D7

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

            ReDim dAlignPosX(1, 3)
            ReDim dAlignPosY(1, 3)

            ReDim dCurPosX(1)
            ReDim dCurPosY(1)
            ReDim dTrimmingPosX(1)
            ReDim dTrimmingPosY(1)

            ReDim dCurPosCameraZ1(1)
            ReDim dCurPosCameraZ2(1)
            ReDim dCurPosScannerZ(3)

            'ReDim nTacTime(1)
            'ReDim APD_A_DATA(8)
            'ReDim APD_B_DATA(8)

            ReDim nRMSData(64)
        End Sub
    End Structure
    Public pbConnect As Boolean
    Private isMXComponentOpenOk As Boolean
    Public bChangeBit As Boolean = False

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

    Public bRMSDATAChange As Boolean = False

    Public Sub Init()
        PLC_Infomation.Init()
        PC_Infomation.Init()
    End Sub

    Function StartMXComponent() As Boolean
        On Error GoTo SysErr
        If isMXComponentOpenOk = False Then
            pMXComponent.Initializing("D:\\MxComponent_main.csv")
            If pMXComponent.Open(1) = True Then

                ThreadMXComponent = New Thread(AddressOf MXComponetThreadSub)
                nKillThreadMXComponent = 0
                ThreadMXComponent.SetApartmentState(ApartmentState.MTA)
                ThreadMXComponent.Priority = ThreadPriority.Normal
                ThreadMXComponent.IsBackground = True
                ThreadMXComponent.Start()

                ThreadMXComponentStatus = New Thread(AddressOf MXComponentThreadStatusSub)
                nKillThreadMXComponentStatus = 0
                ThreadMXComponentStatus.SetApartmentState(ApartmentState.MTA)
                ThreadMXComponentStatus.Priority = ThreadPriority.Normal
                ThreadMXComponentStatus.IsBackground = True
                ThreadMXComponentStatus.Start()

                pbConnect = True
                Return True
            Else
                pbConnect = False
                Return False
            End If
        ElseIf isMXComponentOpenOk = True Then
            ThreadMXComponent = New Thread(AddressOf MXComponetThreadSub)
            nKillThreadMXComponent = 0
            ThreadMXComponent.SetApartmentState(ApartmentState.MTA)
            ThreadMXComponent.Priority = ThreadPriority.Normal

            ThreadMXComponentStatus = New Thread(AddressOf MXComponentThreadStatusSub)
            nKillThreadMXComponentStatus = 0
            ThreadMXComponentStatus.SetApartmentState(ApartmentState.MTA)
            ThreadMXComponentStatus.Priority = ThreadPriority.Normal
            ThreadMXComponentStatus.Start()

            ThreadMXComponent.Start()
            Return True
        End If

        Exit Function
SysErr:
        Return False
    End Function

    Public Function EndMXComponent() As Boolean
        On Error GoTo SysErr

        Interlocked.Exchange(nKillThreadMXComponent, 1)
        Threading.Thread.Sleep(100)
        If bThreadRunningMXComponent = True Then
            ThreadMXComponent.Join(1000)
        End If

        Interlocked.Exchange(nKillThreadMXComponentStatus, 1)
        Threading.Thread.Sleep(100)
        If bThreadRunningMXComponentStatus = True Then
            ThreadMXComponentStatus.Join(1000)
        End If

        If pMXComponent.Close() = True Then
            ThreadMXComponent = Nothing
            ThreadMXComponentStatus = Nothing
            pbConnect = False
            Return True
        End If

        Return False
        Exit Function
SysErr:
        Return False
    End Function

    Sub MXComponetThreadSub()
        On Error GoTo SysErr
        Dim strCmd As String = ""
        Dim strSendCmd() As String = {}

        While nKillThreadMXComponent = 0
            bThreadRunningMXComponent = True
            SyncLock lockCmd
                If qCmd.Count <> 0 Then
                    strCmd = qCmd.Dequeue
                    strSendCmd = Split(strCmd, ",")
                    'If strSendCmd(0) = "WORD" Then
                    '    SetWord(CInt(strSendCmd(1)), CInt(strSendCmd(2)))
                    'End If
                    Thread.Sleep(50)
                End If
            End SyncLock

            Select Case nStatus
                Case 0
                    'If ReadBit(BIT.WB_PC_AUTO_STATUS_A, 256, pPC_Bit) = True Then
                    'GetPC_BitData()
                    'End If
                    nStatus = 1
                Case 1
                    'If ReadWord(PLC_WW_FIRST_ADDR, 256, pPC_Word) = True Then
                    'GetPC_WordData()
                    'End If
                    nStatus = 2
                Case 2
                    'If ReadBit(BIT.RB_PLC_AUTO_STATUS_A, 256, pPLC_Bit) = True Then
                    GetPLC_BitData()
                    ' End If
                    nStatus = 3
                Case 3
                    'If ReadWord(PLC_RW_FIRST_ADDR, 256, pPLC_Word) = True Then
                    'If ReadWord(PLC_RW_FIRST_ADDR, 288, pPLC_Word) = True Then
                    GetPLC_WordData()
                    ' End If
                    nStatus = 0
            End Select

            Thread.Sleep(50) 'sbs 100->50

        End While

        bThreadRunningMXComponent = False
        Exit Sub
SysErr:
        bThreadRunningMXComponent = False

    End Sub

    Dim nStatus As Integer = 0

    Sub MXComponentThreadStatusSub()
        On Error GoTo SysErr

        While nKillThreadMXComponentStatus = 0
            bThreadRunningMXComponentStatus = True

            If PLC_Infomation.bStageManualControl = True Then
                'If pPLC_Word(RWORD.RW_STAGE_A_X_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_A_X_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_A_X_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_A_X_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageX(LINE.A) = True And PLC_Infomation.bMoveCompleteStageX(LINE.A) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_A_X, False)
                    'PC_Infomation.nTargetPosX(0) = PLC_Infomation.nCurPosX(LINE.A)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_A_Y_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_A_Y_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_A_Y_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_A_Y_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageY(LINE.A) = True And PLC_Infomation.bMoveCompleteStageY(LINE.A) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_A_Y, False)
                    'PC_Infomation.nTargetPosY(0) = PLC_Infomation.nCurPosY(LINE.A)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_B_X_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_B_X_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_B_X_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_B_X_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageX(LINE.B) = True And PLC_Infomation.bMoveCompleteStageX(LINE.B) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_B_X, False)
                    'PC_Infomation.nTargetPosX(1) = PLC_Infomation.nCurPosX(LINE.B)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_B_Y_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_B_Y_MOVING_POSITION1) And pPLC_Word(RWORD.RW_STAGE_B_Y_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_B_Y_MOVING_POSITION2) Then
                If PC_Infomation.bMoveRequestStageY(LINE.B) = True And PLC_Infomation.bMoveCompleteStageY(LINE.B) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_B_Y, False)
                    'PC_Infomation.nTargetPosY(1) = PLC_Infomation.nCurPosY(LINE.B)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER1_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER1_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER1_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER1_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_1 = True And PLC_Infomation.bMoveCompleteScannerZ(0) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER1_Z, False)
                    'PC_Infomation.nTargetPosScannerZ1 = PLC_Infomation.nCurPosScannerZ(0)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER2_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER2_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER2_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER2_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_2 = True And PLC_Infomation.bMoveCompleteScannerZ(1) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER2_Z, False)
                    'PC_Infomation.nTargetPosScannerZ2 = PLC_Infomation.nCurPosScannerZ(1)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER3_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER3_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER3_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER3_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_3 = True And PLC_Infomation.bMoveCompleteScannerZ(2) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER3_Z, False)
                    'PC_Infomation.nTargetPosScannerZ3 = PLC_Infomation.nCurPosScannerZ(2)
                End If
                'End If

                'If pPLC_Word(RWORD.RW_STAGE_SCANNER4_Z_CURRENT_POSITION1) = pPC_Word(WWORD.WW_STAGE_SCANNER4_Z_POSITION1) And pPLC_Word(RWORD.RW_STAGE_SCANNER4_Z_CURRENT_POSITION2) = pPC_Word(WWORD.WW_STAGE_SCANNER4_Z_POSITION2) Then
                If PC_Infomation.bMoveRequestScanner_4 = True And PLC_Infomation.bMoveCompleteScannerZ(3) = True Then
                    pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER4_Z, False)
                    'PC_Infomation.nTargetPosScannerZ4 = PLC_Infomation.nCurPosScannerZ(3)
                End If
                'End If

                '카메라는 각 라인별 2개이나 각 라인별 1개의 메모리맵만 있음 이게 맞음 축은 하나임
                If PLC_Infomation.dCurPosCameraZ1(LINE.A) = PC_Infomation.nTargetPosCameraZ1(LINE.A) Then
                    If PC_Infomation.bMoveRequestCameraZ(LINE.A) = True And PLC_Infomation.bMoveCompleteCameraZ1(LINE.A) = True Then
                        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_CAMERA_A_Z, False)
                    End If
                End If
                If PLC_Infomation.dCurPosCameraZ1(LINE.B) = PC_Infomation.nTargetPosCameraZ1(LINE.B) Then
                    If PC_Infomation.bMoveRequestCameraZ(LINE.B) = True And PLC_Infomation.bMoveCompleteCameraZ1(LINE.B) = True Then
                        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_CAMERA_B_Z, False)
                    End If
                End If

            End If

            '2017.01.09 - PC AliveBit 송부.
            AliveBit()

            Thread.Sleep(500) '1000 -> 500

        End While

        bThreadRunningMXComponentStatus = False
        Exit Sub
SysErr:
        bThreadRunningMXComponentStatus = False

    End Sub


    Function ResetMoveBit() As Boolean
        On Error GoTo SysErr

        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_A_X, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_A_Y, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_CAMERA_A_Z, False)
        pMXComponent.WriteBitByAddress(BIT.WB_A_TRIMMING_COMP, False)
        pLDLT.PC_Infomation.bTrimmingComp(LINE.A) = False
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_B_X, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_STAGE_B_Y, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_CAMERA_B_Z, False)
        pMXComponent.WriteBitByAddress(BIT.WB_B_TRIMMING_COMP, False)
        pLDLT.PC_Infomation.bTrimmingComp(LINE.B) = False
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER1_Z, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER2_Z, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER3_Z, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_REQUEST_SCANNER4_Z, False)

        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER1, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER2, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER3, False)
        pMXComponent.WriteBitByAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER4, False)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_X_MOVING_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_X_MOVING_POSITION2, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_Y_MOVING_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_Y_MOVING_POSITION2, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_CAMERA_Z_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_CAMERA_Z_POSITION2, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_X_MOVING_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_X_MOVING_POSITION2, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_Y_MOVING_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_Y_MOVING_POSITION2, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_CAMERA_Z_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_CAMERA_Z_POSITION2, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_CAMERA_Z_POSITION1, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER1_Z_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER1_Z_POSITION2, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER2_Z_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER2_Z_POSITION2, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER3_Z_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER3_Z_POSITION2, 0)

        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER4_Z_POSITION1, 0)
        pMXComponent.WriteWordShortByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER4_Z_POSITION2, 0)

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Private Sub GetPC_BitData()
        On Error GoTo SysErr
        Dim bRet As Boolean = False

        'lWriteBits = pMXComponent.GetWriteBits()

        'PC_Infomation.bPC_AutoMode(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_PC_AUTO_STATUS_A, bRet)
        'PC_Infomation.bPC_AutoMode(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_PC_AUTO_STATUS_B, bRet)

        ''20181208 admin login
        'PC_Infomation.bPC_AdminLogin = pMXComponent.WriteBitReadAddress(BIT.WB_LOGIN_ADMIN, bRet)

        'PC_Infomation.bPC_ResetAlarm = pMXComponent.WriteBitReadAddress(BIT.WB_PC_RESET_ALARM, bRet)
        'PC_Infomation.bPC_LightAlarm = pMXComponent.WriteBitReadAddress(BIT.WB_PC_LIGHT_ALARM, bRet)
        'PC_Infomation.bPC_HeavyAlarm = pMXComponent.WriteBitReadAddress(BIT.WB_PC_HEAVY_ALARM, bRet)

        'PC_Infomation.bLaserBusy_1(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_A_1, bRet)
        'PC_Infomation.bLaserBusy_2(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_A_2, bRet)
        'PC_Infomation.bLaserBusy_3(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_A_3, bRet)
        'PC_Infomation.bLaserBusy_4(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_A_4, bRet)

        'PC_Infomation.bAlignOK1(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_OK_1, bRet)
        'PC_Infomation.bAlignOK2(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_OK_2, bRet)
        'PC_Infomation.bAlignOK3(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_OK_3, bRet)
        'PC_Infomation.bAlignOK4(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_OK_4, bRet)

        'PC_Infomation.bAlignNG1(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_NG_1, bRet)
        'PC_Infomation.bAlignNG2(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_NG_2, bRet)
        'PC_Infomation.bAlignNG3(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_NG_3, bRet)
        'PC_Infomation.bAlignNG4(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_A_NG_4, bRet)

        'PC_Infomation.bTrimmingComp(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_A_TRIMMING_COMP, bRet)
        'PC_Infomation.bMarkDistace(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_MARK_DISTANCE_A, bRet)

        'PC_Infomation.bMoveRequestStageX(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_STAGE_A_X, bRet)
        'PC_Infomation.bMoveRequestStageY(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_STAGE_A_Y, bRet)
        'PC_Infomation.bMoveRequestCameraZ(LINE.A) = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_CAMERA_A_Z, bRet)

        'PC_Infomation.bLaserBusy_1(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_B_1, bRet)
        'PC_Infomation.bLaserBusy_2(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_B_2, bRet)
        'PC_Infomation.bLaserBusy_3(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_B_3, bRet)
        'PC_Infomation.bLaserBusy_4(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER_BUSY_B_4, bRet)

        'PC_Infomation.bAlignOK1(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_OK_1, bRet)
        'PC_Infomation.bAlignOK2(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_OK_2, bRet)
        'PC_Infomation.bAlignOK3(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_OK_3, bRet)
        'PC_Infomation.bAlignOK4(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_OK_4, bRet)

        'PC_Infomation.bAlignNG1(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_NG_1, bRet)
        'PC_Infomation.bAlignNG2(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_NG_2, bRet)
        'PC_Infomation.bAlignNG3(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_NG_3, bRet)
        'PC_Infomation.bAlignNG4(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_ALIGN_B_NG_4, bRet)

        'PC_Infomation.bTrimmingComp(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_B_TRIMMING_COMP, bRet)
        'PC_Infomation.bMarkDistace(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_MARK_DISTANCE_B, bRet)

        'PC_Infomation.bMoveRequestStageX(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_STAGE_B_X, bRet)
        'PC_Infomation.bMoveRequestStageY(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_STAGE_B_Y, bRet)
        'PC_Infomation.bMoveRequestCameraZ(LINE.B) = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_CAMERA_B_Z, bRet)

        'PC_Infomation.bLaserPowerMoveRequest_1 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER1, bRet)
        'PC_Infomation.bLaserPowerMoveRequest_2 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER2, bRet)
        'PC_Infomation.bLaserPowerMoveRequest_3 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER3, bRet)
        'PC_Infomation.bLaserPowerMoveRequest_4 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_REQUEST_LASER4, bRet)

        'PC_Infomation.bLaserPowerMoveRequest_Top_1 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER1, bRet)
        'PC_Infomation.bLaserPowerMoveRequest_Top_2 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER2, bRet)
        'PC_Infomation.bLaserPowerMoveRequest_Top_3 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER3, bRet)
        'PC_Infomation.bLaserPowerMoveRequest_Top_4 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_POWER_MEASURE_TOP_REQUEST_LASER4, bRet)

        'PC_Infomation.bLaserPowerMeasureComplete = pMXComponent.WriteBitReadAddress(BIT.WB_POWER_MEASURE_COMPLETE, bRet)

        'PC_Infomation.bMoveRequestScanner_1 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_SCANNER1_Z, bRet)
        'PC_Infomation.bMoveRequestScanner_2 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_SCANNER2_Z, bRet)
        'PC_Infomation.bMoveRequestScanner_3 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_SCANNER3_Z, bRet)
        'PC_Infomation.bMoveRequestScanner_4 = pMXComponent.WriteBitReadAddress(BIT.WB_MOVE_REQUEST_SCANNER4_Z, bRet)

        ''20190729 레이저 비트 추가
        'PC_Infomation.bLaserOn(0) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER1_ON, bRet)
        'PC_Infomation.bLaserMode(0) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER1_MODE, bRet)
        'PC_Infomation.bLaserShutter(0) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER1_SHUTTER, bRet)

        'PC_Infomation.bLaserOn(1) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER2_ON, bRet)
        'PC_Infomation.bLaserMode(1) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER2_MODE, bRet)
        'PC_Infomation.bLaserShutter(1) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER2_SHUTTER, bRet)

        'PC_Infomation.bLaserOn(2) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER3_ON, bRet)
        'PC_Infomation.bLaserMode(2) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER3_MODE, bRet)
        'PC_Infomation.bLaserShutter(2) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER3_SHUTTER, bRet)

        'PC_Infomation.bLaserOn(3) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER4_ON, bRet)
        'PC_Infomation.bLaserMode(3) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER4_MODE, bRet)
        'PC_Infomation.bLaserShutter(3) = pMXComponent.WriteBitReadAddress(BIT.WB_LASER4_SHUTTER, bRet)

        'PC_Infomation.bRecipeChangeReport = pMXComponent.WriteBitReadAddress(BIT.WB_RECIPE_CHANGE_REPORT, bRet)
        'PC_Infomation.bRecipeSaveReport = pMXComponent.WriteBitReadAddress(BIT.WB_RECIPE_COPY_REPORT, bRet)
        'PC_Infomation.bRecipeDeleteReport = pMXComponent.WriteBitReadAddress(BIT.WB_RECIPE_DELETE_REPORT, bRet)
        'PC_Infomation.bRecipeSaveCopyReport = pMXComponent.WriteBitReadAddress(BIT.WB_RECIPE_SAVE_REPORT, bRet)

        Exit Sub
SysErr:

    End Sub

    Private Sub GetPC_WordData()
        On Error GoTo SysErr

        Dim StrTemp() As String = {}
        Dim StrTemp2() As String = {}
        Dim OutString As String = ""
        Dim nShortData1 As Short = 0
        Dim nShortData2 As Short = 0

        'pMXComponent.ReadWordShortByAddress(WWORD.WW_PC_ALIVE + PLC_WW_FIRST_ADDR, CInt(PC_Infomation.nPC_Alive))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_A_X_MOVING_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosX(LINE.A))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_A_Y_MOVING_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosY(LINE.A))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_A_CAMERA_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosCameraZ1(LINE.A))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_A_CAMERA_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosCameraZ2(LINE.A))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_B_X_MOVING_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosX(LINE.B))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_B_Y_MOVING_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosY(LINE.B))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_B_CAMERA_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosCameraZ1(LINE.B))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_B_CAMERA_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosCameraZ2(LINE.B))
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_SCANNER1_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosScannerZ1)
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_SCANNER2_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosScannerZ2)
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_SCANNER3_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosScannerZ3)
        'pMXComponent.ReadWordIntegerByAddress(WWORD.WW_STAGE_SCANNER4_Z_POSITION1 + PLC_WW_FIRST_ADDR, PC_Infomation.nTargetPosScannerZ4)

        Exit Sub
SysErr:

    End Sub

    Public Sub GetPLC_BitData()
        On Error GoTo SysErr
        Dim bRet As Boolean = False

        PLC_Infomation.bPLC_AutoMode(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_AUTO_STATUS_A, bRet)
        PLC_Infomation.bPLC_ManualMode(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_MANUAL_STATUS_A, bRet)
        PLC_Infomation.bPLC_AutoMode(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_AUTO_STATUS_B, bRet)
        PLC_Infomation.bPLC_ManualMode(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_MANUAL_STATUS_B, bRet)

        'PLC_Infomation.bPLC_AlignCheckMode = pMXComponent.ReadBit(BIT.RB_PLC_AlignTest_Mode , bRet)

        PLC_Infomation.bStageManualControl = pMXComponent.ReadBitByAddress(BIT.RB_PLC_MANUAL_PC_CONTROL, bRet)
        PLC_Infomation.bSyncTimeReq = pMXComponent.ReadBitByAddress(BIT.RB_TIME_SYNC_REQUEST, bRet)
        PLC_Infomation.bPLC_ResetAlarm = pMXComponent.ReadBitByAddress(BIT.RB_PLC_RESET_ALARM, bRet)
        PLC_Infomation.bPLC_LightAlarm = pMXComponent.ReadBitByAddress(BIT.RB_PLC_LIGHT_ALARM, bRet)
        PLC_Infomation.bPLC_HeavyAlarm = pMXComponent.ReadBitByAddress(BIT.RB_PLC_HEAVY_ALARM, bRet)

        PLC_Infomation.bGlassExist(LINE.A, 0) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_A_1, bRet)
        PLC_Infomation.bGlassExist(LINE.A, 1) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_A_2, bRet)
        PLC_Infomation.bGlassExist(LINE.A, 2) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_A_3, bRet)
        PLC_Infomation.bGlassExist(LINE.A, 3) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_A_4, bRet)

        PLC_Infomation.bAlignRequest(LINE.A, 0) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_A_1_REQUEST, bRet)
        PLC_Infomation.bAlignRequest(LINE.A, 1) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_A_2_REQUEST, bRet)
        PLC_Infomation.bAlignRequest(LINE.A, 2) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_A_3_REQUEST, bRet)
        PLC_Infomation.bAlignRequest(LINE.A, 3) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_A_4_REQUEST, bRet)

        PLC_Infomation.bLaserMarkingRequest(LINE.A, 0) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_A_1, bRet)
        PLC_Infomation.bLaserMarkingRequest(LINE.A, 1) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_A_2, bRet)
        PLC_Infomation.bLaserMarkingRequest(LINE.A, 2) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_A_3, bRet)
        PLC_Infomation.bLaserMarkingRequest(LINE.A, 3) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_A_4, bRet)

        PLC_Infomation.bMoveCompleteStageX(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_STAGE_MOVE_COMPLETE_REPORT_A_X, bRet)
        PLC_Infomation.bMoveCompleteStageY(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_STAGE_MOVE_COMPLETE_REPORT_A_Y, bRet)
        PLC_Infomation.bMoveCompleteCameraZ1(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_CAMERA_MOVE_COMPLETE_REPORT_A_Z, bRet)
        'PLC_Infomation.bMoveCompleteCameraZ2(LINE.A) = pMXComponent.ReadBit(BIT.RB_PLC_AUTO_STATUS_B, bRet)

        PLC_Infomation.bMoveCompleteMainStageGlassInPosX(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_A_X, bRet)
        PLC_Infomation.bMoveCompleteMainStageGlassInPosY(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_A_Y, bRet)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosX(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_A_X, bRet)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosY(LINE.A) = pMXComponent.ReadBitByAddress(BIT.RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_A_Y, bRet)

        PLC_Infomation.bGlassExist(LINE.B, 0) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_B_1, bRet)
        PLC_Infomation.bGlassExist(LINE.B, 1) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_B_2, bRet)
        PLC_Infomation.bGlassExist(LINE.B, 2) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_B_3, bRet)
        PLC_Infomation.bGlassExist(LINE.B, 3) = pMXComponent.ReadBitByAddress(BIT.RB_PLC_EXIST_B_4, bRet)

        PLC_Infomation.bAlignRequest(LINE.B, 0) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_B_1_REQUEST, bRet)
        PLC_Infomation.bAlignRequest(LINE.B, 1) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_B_2_REQUEST, bRet)
        PLC_Infomation.bAlignRequest(LINE.B, 2) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_B_3_REQUEST, bRet)
        PLC_Infomation.bAlignRequest(LINE.B, 3) = pMXComponent.ReadBitByAddress(BIT.RB_ALIGN_B_4_REQUEST, bRet)

        PLC_Infomation.bLaserMarkingRequest(LINE.B, 0) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_B_1, bRet)
        PLC_Infomation.bLaserMarkingRequest(LINE.B, 1) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_B_2, bRet)
        PLC_Infomation.bLaserMarkingRequest(LINE.B, 2) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_B_3, bRet)
        PLC_Infomation.bLaserMarkingRequest(LINE.B, 3) = pMXComponent.ReadBitByAddress(BIT.RB_LASER_MARKING_START_B_4, bRet)

        PLC_Infomation.bMoveCompleteStageX(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_STAGE_MOVE_COMPLETE_REPORT_B_X, bRet)
        PLC_Infomation.bMoveCompleteStageY(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_STAGE_MOVE_COMPLETE_REPORT_B_Y, bRet)
        PLC_Infomation.bMoveCompleteCameraZ1(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_CAMERA_MOVE_COMPLETE_REPORT_B_Z, bRet)
        'PLC_Infomation.bMoveCompleteCameraZ2(LINE.B) = pMXComponent.ReadBit(BIT.RB_PLC_AUTO_STATUS_B, bRet)

        PLC_Infomation.bMoveCompleteMainStageGlassInPosX(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_B_X, bRet)
        PLC_Infomation.bMoveCompleteMainStageGlassInPosY(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_LOADING_STAGE_MOVE_COMPLETE_REPORT_B_Y, bRet)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosX(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_B_X, bRet)
        PLC_Infomation.bMoveCompleteMainStageGlassOutPosY(LINE.B) = pMXComponent.ReadBitByAddress(BIT.RB_UNLOADING_STAGE_MOVE_COMPLETE_REPORT_B_Y, bRet)

        PLC_Infomation.bLaserPowerMoveComplete_1 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_LASER1, bRet)
        PLC_Infomation.bLaserPowerMoveComplete_2 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_LASER2, bRet)
        PLC_Infomation.bLaserPowerMoveComplete_3 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_LASER3, bRet)
        PLC_Infomation.bLaserPowerMoveComplete_4 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_LASER4, bRet)

        PLC_Infomation.bLaserPowerMoveComplete_Top_1 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_TOP_LASER1, bRet)
        PLC_Infomation.bLaserPowerMoveComplete_Top_2 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_TOP_LASER2, bRet)
        PLC_Infomation.bLaserPowerMoveComplete_Top_3 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_TOP_LASER3, bRet)
        PLC_Infomation.bLaserPowerMoveComplete_Top_4 = pMXComponent.ReadBitByAddress(BIT.RB_LASER_POWER_MEASURE_MODE_TOP_LASER4, bRet)

        PLC_Infomation.bMoveCompleteScannerZ(0) = pMXComponent.ReadBitByAddress(BIT.RB_SCANNER_MOVE_COMPLETE_REPORT_Z1, bRet)
        PLC_Infomation.bMoveCompleteScannerZ(1) = pMXComponent.ReadBitByAddress(BIT.RB_SCANNER_MOVE_COMPLETE_REPORT_Z2, bRet)
        PLC_Infomation.bMoveCompleteScannerZ(2) = pMXComponent.ReadBitByAddress(BIT.RB_SCANNER_MOVE_COMPLETE_REPORT_Z3, bRet)
        PLC_Infomation.bMoveCompleteScannerZ(3) = pMXComponent.ReadBitByAddress(BIT.RB_SCANNER_MOVE_COMPLETE_REPORT_Z4, bRet)

        '20180411 chy displace
        PLC_Infomation.bDisplaceSend(0) = pMXComponent.ReadBitByAddress(BIT.RB_DISPLACE_SEND_A, bRet)
        PLC_Infomation.bDisplaceSend(1) = pMXComponent.ReadBitByAddress(BIT.RB_DISPLACE_SEND_B, bRet)

        '20181010 RYO LaserPassMode
        PLC_Infomation.bLaserPassMode(0) = pMXComponent.ReadBitByAddress(BIT.RB_Laser1_PassMode, bRet)
        PLC_Infomation.bLaserPassMode(1) = pMXComponent.ReadBitByAddress(BIT.RB_Laser2_PassMode, bRet)
        PLC_Infomation.bLaserPassMode(2) = pMXComponent.ReadBitByAddress(BIT.RB_Laser3_PassMode, bRet)
        PLC_Infomation.bLaserPassMode(3) = pMXComponent.ReadBitByAddress(BIT.RB_Laser4_PassMode, bRet)


        PLC_Infomation.bRecipeChangeReq = pMXComponent.ReadBitByAddress(BIT.RB_RECIPE_CHANGE_REQUEST, bRet)
        PLC_Infomation.bRecipeCopyReq = pMXComponent.ReadBitByAddress(BIT.RB_RECIPE_COPY_REQUEST, bRet)
        PLC_Infomation.bRecipeDeleteReq = pMXComponent.ReadBitByAddress(BIT.RB_RECIPE_DELETE_REQUEST, bRet)
        PLC_Infomation.bRecipeSaveCopyReq = pMXComponent.ReadBitByAddress(BIT.RB_RECIPE_SAVE_COPY_REQUEST, bRet)

        Exit Sub
SysErr:

    End Sub

    Private Sub GetPLC_WordData()
        On Error GoTo SysErr

        Dim StrTemp() As String = {}
        Dim StrTemp2() As String = {}
        Dim OutString As String = ""

        Dim nShortData1 As Short = 0
        Dim nShortData2 As Short = 0

        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_X_TRIMMING_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dTrimmingPosX(LINE.A))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_Y_TRIMMING_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dTrimmingPosY(LINE.A))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_X_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosX(LINE.A))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_Y_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosY(LINE.A))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosCameraZ1(LINE.A))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_CAMERA_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosCameraZ2(LINE.A))

        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_X_ALIGN_1_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.A, 0))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_Y_ALIGN_1_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.A, 0))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_X_ALIGN_2_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.A, 1))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_Y_ALIGN_2_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.A, 1))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_X_ALIGN_3_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.A, 2))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_Y_ALIGN_3_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.A, 2))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_X_ALIGN_4_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.A, 3))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_A_Y_ALIGN_4_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.A, 3))

        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_X_TRIMMING_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dTrimmingPosX(LINE.B))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_Y_TRIMMING_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dTrimmingPosY(LINE.B))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_X_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosX(LINE.B))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_Y_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosY(LINE.B))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosCameraZ1(LINE.B))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_CAMERA_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosCameraZ2(LINE.B))

        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_X_ALIGN_1_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.B, 0))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_Y_ALIGN_1_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.B, 0))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_X_ALIGN_2_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.B, 1))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_Y_ALIGN_2_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.B, 1))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_X_ALIGN_3_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.B, 2))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_Y_ALIGN_3_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.B, 2))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_X_ALIGN_4_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosX(LINE.B, 3))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_B_Y_ALIGN_4_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dAlignPosY(LINE.B, 3))

        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_SCANNER1_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosScannerZ(0))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_SCANNER2_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosScannerZ(1))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_SCANNER3_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosScannerZ(2))
        pMXComponent.ReadWordDoubleByAddress(RWORD.RW_STAGE_SCANNER4_Z_CURRENT_POSITION1 + PLC_RW_FIRST_ADDR, PLC_Infomation.dCurPosScannerZ(3))

        pMXComponent.ReadWordShortByAddress(RWORD.RW_COPY_RECIPE_NUMBER + PLC_RW_FIRST_ADDR, PLC_Infomation.nCopyRecipeNo)
        pMXComponent.ReadWordShortByAddress(RWORD.RW_RECIPE_NUMBER + PLC_RW_FIRST_ADDR, PLC_Infomation.nRecipeNo)

        ReDim StrTemp(9)
        ReDim StrTemp2(9)

        'GYN - Recipe 변경 및 생성 Bit 받은 후 구동 되게 조건 걸어서 진행.
        If bModelRecipe = True Then
            For i As Integer = 0 To StrTemp.Length - 1
                pMXComponent.ReadWordShortByAddress(RWORD.RW_CURRENT_RECIPE_NAME0 + i + PLC_RW_FIRST_ADDR, nShortData1)
                StrTemp2(i) = Hex(nShortData1)
            Next
            If ConvertAscToWord(StrTemp2, OutString) = True Then
                PLC_Infomation.strModelName = Trim(OutString)
            End If
            bModelRecipe = False
        End If

        pMXComponent.ReadWordShortByAddress(RWORD.RW_TIME_DATA_YEAR + PLC_RW_FIRST_ADDR, PLC_Infomation.nTimeData_Year)
        pMXComponent.ReadWordShortByAddress(RWORD.RW_TIME_DATA_MONTH + PLC_RW_FIRST_ADDR, PLC_Infomation.nTimeData_Month)
        pMXComponent.ReadWordShortByAddress(RWORD.RW_TIME_DATA_DAY + PLC_RW_FIRST_ADDR, PLC_Infomation.nTimeData_Day)
        pMXComponent.ReadWordShortByAddress(RWORD.RW_TIME_DATA_HOUR + PLC_RW_FIRST_ADDR, PLC_Infomation.nTimeData_Hour)
        pMXComponent.ReadWordShortByAddress(RWORD.RW_TIME_DATA_MINUTE + PLC_RW_FIRST_ADDR, PLC_Infomation.nTimeData_Minute)
        pMXComponent.ReadWordShortByAddress(RWORD.RW_TIME_DATA_SECOND + PLC_RW_FIRST_ADDR, PLC_Infomation.nTimeData_Second)

        Exit Sub
SysErr:

    End Sub

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


    Function AliveBit() As Boolean
        'Alive 확인 
        If PC_Infomation.nPC_Alive = 0 Then

            pMXComponent.WriteWordShortByAddress(WWORD.WW_PC_ALIVE + PLC_WW_FIRST_ADDR, 1)
            PC_Infomation.nPC_Alive = 1
        Else
            pMXComponent.WriteWordShortByAddress(WWORD.WW_PC_ALIVE + PLC_WW_FIRST_ADDR, 0)
            PC_Infomation.nPC_Alive = 0
        End If


    End Function


    Public Function MoveStage(ByVal nLine As Integer, ByVal nAxis As Integer, ByVal ipPosition As Double)
        On Error GoTo SysErr
        Dim tmpWord1 As Short = 0
        Dim tmpWord2 As Short = 0
        Dim tmpMovePos As Integer = ipPosition  '* 1000

        ConvertStageDataToWordData(tmpMovePos, tmpWord1, tmpWord2)

        Dim nAddr(2) As Integer
        Dim nXAddr As Integer
        Dim bXReqAddr As BIT

        ' WW_STAGE_A_X_MOVING_POSITION1 = &H80
        'GYN - TEST (수정한 부분)

        If nLine = 0 Then

            Select Case nAxis
                Case 0
                    bXReqAddr = BIT.WB_MOVE_REQUEST_STAGE_A_X
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_X_MOVING_POSITION1
                Case 1
                    bXReqAddr = BIT.WB_MOVE_REQUEST_STAGE_A_Y
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_Y_MOVING_POSITION1
                Case 2
                    bXReqAddr = BIT.WB_MOVE_REQUEST_CAMERA_A_Z
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_CAMERA_Z_POSITION1
            End Select
        Else
            Select Case nAxis
                Case 0
                    bXReqAddr = BIT.WB_MOVE_REQUEST_STAGE_B_X
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_X_MOVING_POSITION1
                Case 1
                    bXReqAddr = BIT.WB_MOVE_REQUEST_STAGE_B_Y
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_Y_MOVING_POSITION1
                Case 2
                    bXReqAddr = BIT.WB_MOVE_REQUEST_CAMERA_B_Z
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_CAMERA_Z_POSITION1
            End Select
        End If

        nAddr(0) = nXAddr '+ (nAxis * 2) + (nLine * &H10)
        nAddr(1) = nXAddr + 1 ' (nAxis * 2) + (nLine * &H10) + 1
        nAddr(2) = bXReqAddr '+ nAxis + (nLine * &H10)
        pMXComponent.WriteWordIntegerByAddress(nAddr(0), tmpWord1)
        pMXComponent.WriteWordIntegerByAddress(nAddr(1), tmpWord2)

        Thread.Sleep(100)
        pMXComponent.WriteBitByAddress(nAddr(2), True)


        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Public Function StopStage(ByVal nLine As Integer, ByVal nAxis As Integer) As Boolean
        On Error GoTo SysErr

        Dim nDevNo As BIT

        If nLine = 0 Then

            Select Case nAxis
                Case 0
                    nDevNo = BIT.WB_MOVE_REQUEST_STAGE_A_X
                Case 1
                    nDevNo = BIT.WB_MOVE_REQUEST_STAGE_A_Y
            End Select
        Else
            Select Case nAxis
                Case 0
                    nDevNo = BIT.WB_MOVE_REQUEST_STAGE_B_X
                Case 1
                    nDevNo = BIT.WB_MOVE_REQUEST_STAGE_B_Y
            End Select
        End If

        pMXComponent.WriteBitByAddress(nDevNo, False)

        Exit Function
SysErr:
        Return False
    End Function

    Public Function StopScannerZ(ByVal nIndex As Integer) As Boolean
        On Error GoTo SysErr

        Dim nDevNo As BIT


        Select Case nIndex
            Case 0
                nDevNo = BIT.WB_MOVE_REQUEST_SCANNER1_Z
            Case 1
                nDevNo = BIT.WB_MOVE_REQUEST_SCANNER2_Z
            Case 2
                nDevNo = BIT.WB_MOVE_REQUEST_SCANNER3_Z
            Case 3
                nDevNo = BIT.WB_MOVE_REQUEST_SCANNER4_Z
        End Select


        pMXComponent.WriteBitByAddress(nDevNo, False)

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
        ConvertStageDataToWordData(tmpMovePos, tmpWord1, tmpWord2)

        Dim nAddr(2) As Integer
        Dim nZAddr As Integer
        Dim ReqAddr As BIT

        Select Case nIndex
            Case 0
                ReqAddr = BIT.WB_MOVE_REQUEST_SCANNER1_Z
                nZAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER1_Z_POSITION1
            Case 1
                ReqAddr = BIT.WB_MOVE_REQUEST_SCANNER2_Z
                nZAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER2_Z_POSITION1
            Case 2
                ReqAddr = BIT.WB_MOVE_REQUEST_SCANNER3_Z
                nZAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER3_Z_POSITION1
            Case 3
                ReqAddr = BIT.WB_MOVE_REQUEST_SCANNER4_Z
                nZAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_SCANNER4_Z_POSITION1
        End Select
       

        nAddr(0) = nZAddr
        nAddr(1) = nZAddr + 1
        nAddr(2) = ReqAddr
        pMXComponent.WriteWordIntegerByAddress(nAddr(0), tmpWord1)
        pMXComponent.WriteWordIntegerByAddress(nAddr(1), tmpWord2)
        Thread.Sleep(100)

        pMXComponent.WriteBitByAddress(nAddr(2), True)

        Return True
        Exit Function
SysErr:
        Return False
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

    '20180411 chy Displace PLC Send
    Public Function DisplacePLCSend(ByVal strtemp As String, ByVal nLine As Integer)
        On Error GoTo SysErr
        Dim tmpWord1 As Short = 0
        Dim tmpWord2 As Short = 0
        Dim tmpDispalcePos As Integer
        tmpDispalcePos = CInt(strtemp * 10000)
        Select Case nLine
            Case 0
                ConvertStageDataToWordData(tmpDispalcePos, tmpWord1, tmpWord2)
                pMXComponent.WriteWordIntegerByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_A1, tmpWord1)
                pMXComponent.WriteWordIntegerByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_A2, tmpWord2)
            Case 1
                ConvertStageDataToWordData(tmpDispalcePos, tmpWord1, tmpWord2)
                pMXComponent.WriteWordIntegerByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_B1, tmpWord1)
                pMXComponent.WriteWordIntegerByAddress(PLC_WW_FIRST_ADDR + WWORD.WW_DISPLACE_SEND_B2, tmpWord2)
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

        ConvertStageDataToWordData(tmpXPos, tmpWordX1, tmpWordX2)
        ConvertStageDataToWordData(tmpYPos, tmpWordY1, tmpWordY2)
        ConvertStageDataToWordData(tmpTPos, tmpWordT1, tmpWordT2)

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

                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE1_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE1_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE1_OFFSETT_POSITION1
                Case 1
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE2_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE2_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE2_OFFSETT_POSITION1
                Case 2
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE3_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE3_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE3_OFFSETT_POSITION1
                Case 3
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE4_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE4_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_A_STAGE4_OFFSETT_POSITION1

            End Select

        Else

            Select Case nChuck
                Case 0

                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE1_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE1_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE1_OFFSETT_POSITION1
                Case 1
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE2_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE2_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE2_OFFSETT_POSITION1
                Case 2
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE3_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE3_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE3_OFFSETT_POSITION1
                Case 3
                    nXAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE3_OFFSETX_POSITION1
                    nYAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE3_OFFSETY_POSITION1
                    nTAddr = PLC_WW_FIRST_ADDR + WWORD.WW_STAGE_B_STAGE3_OFFSETT_POSITION1

            End Select

        End If

        nAddrX(0) = nXAddr
        nAddrX(1) = nXAddr + 1
        nAddrY(0) = nYAddr
        nAddrY(1) = nYAddr + 1
        nAddrT(0) = nTAddr
        nAddrT(1) = nTAddr + 1

        'nAddr = bXReqAddr

        pMXComponent.WriteWordIntegerByAddress(nAddrX(0), tmpWordX1)
        Thread.Sleep(1)
        pMXComponent.WriteWordIntegerByAddress(nAddrX(1), tmpWordX2)
        Thread.Sleep(1)
        pMXComponent.WriteWordIntegerByAddress(nAddrY(0), tmpWordY1)
        Thread.Sleep(1)
        pMXComponent.WriteWordIntegerByAddress(nAddrY(1), tmpWordY2)
        Thread.Sleep(1)
        pMXComponent.WriteWordIntegerByAddress(nAddrT(0), tmpWordT1)
        Thread.Sleep(1)
        pMXComponent.WriteWordIntegerByAddress(nAddrT(1), tmpWordT2)
        Thread.Sleep(1)


        For i As Integer = 0 To 10 ' 500
            Thread.Sleep(1)
        Next

        'modPub.TestLog("Line:" & nLine.ToString() & ",CHUCK:" & nChuck.ToString() & ",DATA U:" & tmpWordU1.ToString() & "," & tmpWordU2.ToString())
        'modPub.TestLog("Line:" & nLine.ToString() & ",CHUCK:" & nChuck.ToString() & ",DATA V:" & tmpWordV1.ToString() & "," & tmpWordV2.ToString())
        'modPub.TestLog("Line:" & nLine.ToString() & ",CHUCK:" & nChuck.ToString() & ",DATA W:" & tmpWordW1.ToString() & "," & tmpWordW2.ToString())


        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Function SetRecipePenData(ByVal CurRecipe As Object, ByVal ipRecipeNum As Integer, Optional ByVal bReset As Boolean = False) As Boolean
        On Error GoTo SysErr
        'Dim tmpStrAddress As String = ""
        'Dim tmpAPDStrAddress As String = ""
        ''Dim tmpStrCount As Integer = 4
        'Dim tmpStrCount As String = ""
        'Dim tmpStart As Integer = 25344   '6300
        'Dim tmpAPDStart As Integer = 25120 ' 6220

        ''RYO
        'Dim i As Integer = 0
        'Dim SubStart As Integer = 0
        'Dim dPower As Double = 0.0

        'tmpStart = tmpStart + 2
        'tmpStrAddress = Hex(tmpStart)
        'If bReset = True Then
        '    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress), 0)
        'ElseIf bReset = False Then
        '    For i = 0 To 3

        '        Select Case i
        '            Case 0 'Laser 2
        '                dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 1).ToString)
        '            Case 1 'Laser 1
        '                tmpStrAddress = tmpStrAddress + 10
        '                dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 0).ToString)
        '            Case 2 'Laser 4
        '                tmpStrAddress = tmpStrAddress + 10
        '                dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 3).ToString)
        '            Case 3 'Laser 3
        '                tmpStrAddress = tmpStrAddress + 10
        '                dPower = CDbl(pCurSystemParam.LaserPower(ipRecipeNum - 1, 2).ToString)
        '        End Select
        '    Next
        'End If

        'tmpStart = tmpStart + 1
        'tmpStrAddress = Hex(tmpStart)
        ''20211229
        ''If bReset = True Then '6303 Pan Number 하드코딩 가즈아아아아
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress), 0)
        ''ElseIf bReset = False Then
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 0), ipRecipeNum)
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 10), ipRecipeNum)
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 20), ipRecipeNum)
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 30), ipRecipeNum)
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 40), ipRecipeNum)
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 50), ipRecipeNum)
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 60), ipRecipeNum)
        ''    pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + 70), ipRecipeNum)
        ''End If

        ''Panel Data 전달: Total 전달 예정.
        ''이거 14로 한 이유?
        ''For j As Integer = 0 To 14
        'For j As Integer = 0 To 7
        '    Dim PenNumber As Integer = 0 '펜 데이터는 한개만 사용하기 때문에 그것만 불러오자!
        '    tmpStart = 25347
        '    tmpStrAddress = Hex(tmpStart)
        '    SubStart = 10 * j '10씩 증가
        '    tmpAPDStart = 25121 '6222
        '    tmpAPDStrAddress = Hex(tmpAPDStart)

        '    'XX08 * 4 상승
        '    tmpStart = tmpStart + 1
        '    tmpStrAddress = Hex(tmpStart)
        '    tmpAPDStart = tmpAPDStart + 1
        '    tmpAPDStrAddress = Hex(tmpAPDStart)
        '    If bReset = True Then '6304 MarkSpeed
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + SubStart), 0)
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpAPDStrAddress + SubStart), 0)
        '    ElseIf bReset = False Then
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).MarkSpeed(PenNumber))
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpAPDStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).MarkSpeed(PenNumber))
        '    End If

        '    tmpStart = tmpStart + 1
        '    tmpStrAddress = Hex(tmpStart)
        '    If bReset = True Then '6305 JumpSpeed
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + SubStart), 0)
        '    ElseIf bReset = False Then
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).JumpSpeed(PenNumber))
        '    End If

        '    tmpStart = tmpStart + 1
        '    tmpStrAddress = Hex(tmpStart)
        '    tmpAPDStart = tmpAPDStart + 1
        '    tmpAPDStrAddress = Hex(tmpAPDStart)
        '    If bReset = True Then '6306 Repeat
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + SubStart), 0)
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpAPDStrAddress + SubStart), 0)
        '    ElseIf bReset = False Then
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).Repeat(PenNumber))
        '        pMXComponent.WriteWordIntegerByAddress(Val("&H" & tmpAPDStrAddress + SubStart), CurRecipe(ipRecipeNum - 1).Repeat(PenNumber))
        '    End If
        'Next

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Public Function Test(ByVal nIndex As Integer) As Boolean
        On Error GoTo SysErr


        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_4ALIGN_STATUS, False)

        Exit Function
SysErr:
        Return False
    End Function
    Private m_nStartTick As Integer
    Private m_bStarted As Boolean = False
    Private Function IsSleepTime(ByVal nIntervalMil As Integer) As Boolean
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

End Class
