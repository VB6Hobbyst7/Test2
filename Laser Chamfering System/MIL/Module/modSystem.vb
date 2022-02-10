Imports System.Runtime.InteropServices

Module modSystem

    Public pMilInterface As New MilInterface
    Public pMilProcessor As New MilImageProcessor
    Public pCamera As New Camera

    'Public mCamLiveWnd As New LiveImageWnd

    Public Structure _CAMERA
        Public Const LASER_CAMERA_1 As Integer = 2
        Public Const LASER_CAMERA_2 As Integer = 3

        Public Const EDGE_CAMERA_1 As Integer = 0
        Public Const EDGE_CAMERA_2 As Integer = 1

        Public Const INSP_CAMERA_1 As Integer = 0
        Public Const INSP_CAMERA_2 As Integer = 1
        Public Const INSP_CAMERA_MARK As Integer = 2

        Public Const CHANELNUM As Integer = 1 '3
        Public Const SHARED_SYSTEM_NUM As Integer = 1
        Public Const MIL_SYSTEM_NUM As Integer = 1
        Public Const DIGITIZER_NUM As Integer = 3 '4
        Public Const GRAB_BUFFER_SIZE As Integer = 20
        Public Const PROC_BUF_SIZE As Integer = 7
        Public Const EXT_GRAB_BUF_SIZE As Integer = 7
        Public Const PXL_TOT_INSP_X As Integer = 1360   '1626
        Public Const PXL_TOT_INSP_Y As Integer = 1040   '1236
        Public Const PXL_CHILD_INSP_X As Integer = 800
        Public Const PXL_CHILD_INSP_Y As Integer = 800
        Public Const BOUNDARY_LINE_WIDTH As Integer = 15
        Public Const PXL_CHILD_CUTTING_INSP_X As Integer = 500
        Public Const PXL_CHILD_CUTTING_INSP_Y As Integer = 500

        Public Const INTERNAL_TRIG As Integer = 0
        Public Const EXTERNAL_TRIG As Integer = 1

        Public Const CONTINUOUS_GRAB_MODE As Integer = 0
        Public Const EXTERNAL_TRIG_GRAB_MODE As Integer = 1

        Public Const PIXEL_RESOLUTION_EDGE As Double = 0.0044
        Public Const PIXEL_RESOLUTION_CUTTING As Double = 0.00293
    End Structure

    Public Structure _PATH
        Const EQP_NAME As String = "NarrowBezelLaserCutting"

#If _SIMULATION Then
	Public Const MAIN_DRIVE As String = "C:\"
	Public Const LOG_DRIVE As String = "C:\"
#Else
        Public Const MAIN_DRIVE As String = "D:\"
        Public Const LOG_DRIVE As String = "D:\"
#End If

        'EQP
        Public Const CONFIG_ALARM_LIST As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\ALARM_LIST\Define.csv"
        '?대뜑 ?섏젙
        Public Const CONFIG_ALARM_DESCRIPTION As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\ALARM_LIST\Description.ini"
        '?대뜑 ?섏젙
        Public Const CONFIG_CAMERA_DCF As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCamera.dcf"
        Public Const CONFIG_CAMERA_DCF_EXT As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCameraExt.dcf"

        Public Const CONFIG_CAMERA_DCF_MONO As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCamera_AC1600_20GC.dcf"
        Public Const CONFIG_CAMERA_DCF_COLOR As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCamera_AC1600_20GM.dcf"

        Public Const CONFIG_MACHINE_TYPE As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\MachineType.ini"
        Public Const CONFIG_SYSTEM As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\System.ini"
        '?대뜑 ?섏젙
        'RECIPE - D:\\ULTRA_CUTTING\\RECIPE\\

        Public Const RECIPE_MODEL As String = MAIN_DRIVE + EQP_NAME + "\RECIPE\MODEL\"
        '?대뜑 ?섏젙
        Public Const RECIPE_ALIGN_MARK_PATH As String = "ALIGN_MARK\"
        Public Const ALIGN_MARK_CUTTING_FILENAME_CAM1 As String = "CuttingTable_Cam1.mmf"
        Public Const ALIGN_MARK_CUTTING_FILENAME_CAM2 As String = "CuttingTable_Cam2.mmf"
        Public Const ALIGN_MARK_EDGE_FILENAME_CAM1 As String = "EdgeTable_Cam1.mmf"
        Public Const ALIGN_MARK_EDGE_FILENAME_CAM2 As String = "EdgeTable_Cam2.mmf"
        'Public Const RECIPE_MODEL_ALIGN_MARK_DEFULT As String = RECIPE_MODEL + "1\" + RECIPE_ALIGN_MARK_PATH + ALIGN_MARK_EDGE_FILENAME_CAM1
        Public Const RECIPE_MODEL_ALIGN_MARK_DEFULT As String = "C:\Trmming_Mark1.mmf"


        Public Const EDGE_DETECT_RCP_PATH As String = "EDGE_DETECT\"
        Public Const EDGE_DETECT_RCP_NAME As String = "EdgeDetectRecipe.ini"
        Public Const POL_DETECT_RCP_NAME As String = "PolDetectRecipe.ini"

        Public Const AXIS_RCP_PATH As String = "AXIS_TEACHING\"
        Public Const COORD_CONV_DATA_PATH As String = "RCP_COORD_DATA\"

        Public Const COORD_CONV_DATA_NAME As String = "CoordConvData.ini"
        Public Const COORD_CONV_OPTIC_OFFSET_FILE As String = "CoordConvOpticOffset.ini"

        Public Const LASERRCP_PATH As String = "LASER_OFFSET\"
        '?대뜑 ?섏젙
        Public Const RECIPE_LASER_FREQ As String = MAIN_DRIVE + EQP_NAME + "\RECIPE\LASER\"
        Public Const RECIPE_SYSLASER As String = MAIN_DRIVE + EQP_NAME + "\RECIPE\LASER\LASER\LASER.ini"
        Public Const RECIPE_SYSLASER_3D As String = MAIN_DRIVE + EQP_NAME + "\RECIPE\LASER\LASER_3D\LASER_3D.ini"
        Public Const RECIPE_SYSLASER_3D_IN_ONE As String = MAIN_DRIVE + EQP_NAME + "\RECIPE\LASER\LASER_3D_IN_ONE\LASER_3D_IN_ONE.ini"

        Public Const CUTTING_FILE_NAME As String = "CUTTING_TABLE.INI"

        Public Const LOG_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\"
        Public Const LOG_MACHINE_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\MACHINE\"

        Public Const LOG_LASER_MEASURE_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\LASER_MEASURE\"

        Public Const LOG_MACHINE_BACKUP_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\MACHINE\BACKUP\"

        Public Const LOG_CUTTING_DATA_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\CUTTING_DATA\"
        Public Const LOG_INSPECTION_IMAGE_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\IMAGE\INSPECTION\"
        Public Const LOG_ALIGN_IMAGE_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\IMAGE\ALIGN\"
        Public Const LOG_LASER_START_END_IMAGE_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\IMAGE\LASER_START_END\"

        Public Const LOG_BACKUP_IMAGE_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\BACKUP_IMAGE\"
        Public Const LOG_BACKUP_INSPECTION_FAIL_IMAGE_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\BACKUP_IMAGE_FAIL\"

        Public Const LOG_TIME_PROCESS_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\TIME_PROCESS\"
        Public Const LOG_CUTTING_PROCESS_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\LOG_PROCESS\"
        Public Const LOG_ALARM_PROCESS_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\ALARM_PROCESS\"
        Public Const LOG_LASERSTATUS_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\LASER_STATUS\"
        Public Const LOG_DELETE_FILE As String = LOG_DRIVE + EQP_NAME + "\LOG\DELETE_FILE\"
        Public Const LOG_RECIPE_PROCESS_PATH As String = LOG_DRIVE + EQP_NAME + "\LOG\RECIPE_PROCESS\"

        Public Const LOG_ALARM_HISTORY_FILE As String = "Alarm History.csv"
        Public Const LOG_ALARM_HISTORY_FILE_RESET As String = "Alarm History Reset.csv"

        'Backup
        Public Const BACKUP_PATH As String = LOG_DRIVE + EQP_NAME + "\BACKUP\"
        Public Const BACKUP_DELETE_PATH As String = LOG_DRIVE + EQP_NAME + "\BACKUP\EQP\"
        Public Const MODEL_RECIPE_BACKUP_PATH As String = MAIN_DRIVE + EQP_NAME + "\LOG\MODEL_RECIPE_BACKUP\"

        Public Const ALARM_RELEASE_TIME As String = "AlarmReleaseTime.ini"

        '신규 모델 추가 관련 수정
        Public Const TEMP_CUTTING_POS_OFFSET_PATH As String = "TEMP_CUTTING_POS_OFFSET\"
        Public Const TEMP_CUTTING_POS_OFFSET1_NAME As String = "TEMP_CUTTING_POS_OFFSET1.ini"
        Public Const TEMP_CUTTING_POS_OFFSET2_NAME As String = "TEMP_CUTTING_POS_OFFSET2.ini"

        Public Const EQP_RECIPE_PROCESS_PATH As String = MAIN_DRIVE + "\RECIPE_PROCESS\"

        '?좉퇋 紐⑤뜽 異붽? 愿???섏젙
        Public Const EQP_SIGNAL_FILTER_DATA_PATH As String = "SIGNAL_FILTER_DATA\"
        Public Const EQP_SIGNAL_FILTER_DATA_NAME As String = "SIGNAL_FILTER_DATA.ini"



        'Temporary Fail log Image
        Public Const ALIGN_FAIL_IMAGE_NAME_EDGE_MARK1 As String = "EDGE_MARK_LEFT_FAIL.BMP"
        Public Const ALIGN_FAIL_IMAGE_NAME_EDGE_MARK2 As String = "EDGE_MARK_RIGHT_FAIL.BMP"
        Public Const ALIGN_FAIL_IMAGE_NAME_CUT1_MARK1 As String = "CUT1_MARK_LEFT_FAIL.BMP"
        Public Const ALIGN_FAIL_IMAGE_NAME_CUT1_MARK2 As String = "CUT1_MARK_RIGHT_FAIL.BMP"
        Public Const ALIGN_FAIL_IMAGE_NAME_CUT2_MARK1 As String = "CUT2_MARK_LEFT_FAIL.BMP"
        Public Const ALIGN_FAIL_IMAGE_NAME_CUT2_MARK2 As String = "CUT2_MARK_RIGHT_FAIL.BMP"

        Public Const POL_FPR_FAIL_IMAGE_NAME_EDGE1_START As String = "EDGE_POL_FPR_START_FAIL.BMP"
        Public Const POL_FPR_FAIL_IMAGE_NAME_EDGE1_END As String = "EDGE_POL_FPR_END_FAIL.BMP"
        Public Const POL_FPR_FAIL_IMAGE_NAME_CUT1_START As String = "CUT1_POL_FPR_START_FAIL.BMP"
        Public Const POL_FPR_FAIL_IMAGE_NAME_CUT1_END As String = "CUT1_POL_FPR_END_FAIL.BMP"
        Public Const POL_FPR_FAIL_IMAGE_NAME_CUT2_START As String = "CUT2_POL_FPR_START_FAIL.BMP"
        Public Const POL_FPR_FAIL_IMAGE_NAME_CUT2_END As String = "CUT2_POL_FPR_END_FAIL.BMP"

    End Structure

    'Const DLL_NAME As String = "MyGigEDLL.dll"

    '<DllImport(DLL_NAME)> _
    'Public Sub SetPvBuffer(ByVal aBuffer As PvBuffer)
    'End Sub


    '<DllImport(DLL_NAME)> _
    'Public Function GetDataPointer() As ULong
    'End Function

End Module
