#If SIMUL <> 1 Then
Imports Matrox.MatroxImagingLibrary
#End If

Module modVision

    Public Enum DrawingMode
        None = 0
        MODE_MEASURE = 1
        MODE_SEARCHAREA = 2
        MODE_MODELAREA = 3
    End Enum


    Public Structure InspParam
        Dim bEnabled As Boolean
        Dim Mark1AxisPos As Position
        Dim Mark2AxisPos As Position
        Dim MarkData As AlignData
    End Structure

    Structure tagModelResult
        Dim bFindSuccess As Boolean
        Dim Count As Integer
        Dim PositionX As Double
        Dim PositionY As Double
        Dim Angle As Double
        Dim Scale As Double
        Dim Score As Double
        Dim PositionDiffX As Double
        Dim positionDiffY As Double
        Dim BoxX1 As Integer
        Dim BoxY1 As Integer
        Dim BoxX2 As Integer
        Dim BoxY2 As Integer
        Public Sub Init()
            bFindSuccess = False
            Count = 0
            PositionX = 0
            PositionY = 0
            Angle = 0
            Scale = 0
            Score = 0
            PositionDiffX = 0
            positionDiffY = 0
            BoxX1 = 0
            BoxY1 = 0
            BoxX2 = 0
            BoxY2 = 0
        End Sub
    End Structure

    Enum CAM
        Cam1 = 0
        Cam2 = 1
    End Enum

    Enum LIGHT_CH
        LIGHT_CH_1 = 1
        LIGHT_CH_2 = 2
        LIGHT_CH_3 = 3
        LIGHT_CH_4 = 4
    End Enum


    'GYN - 2017.03.26
    Private m_iLine As Integer              'Line 정보
    Private m_iPanel As Integer             'Panel 정보
    Private m_iAlignMarkNo As Integer       'Align Mark1 or Align Mark2
    Private m_iAlignMarkUseNo As Integer    'Align Mark 사용하고자 하는 번호
    'GYN - ADD
    Public Sub SetVisionInfomation(ByVal iLine As Integer, ByVal iPanel As Integer, ByVal iMarkNo As Integer, ByVal iMarkUseNo As Integer)

        m_iLine = iLine
        m_iPanel = iPanel
        m_iAlignMarkNo = iMarkNo
        m_iAlignMarkUseNo = iMarkUseNo

    End Sub

    Public Sub GetVisionInfomation(ByRef iLine As Integer, ByRef iPanel As Integer, ByRef iMarkNo As Integer, ByRef iMarkUseNo As Integer)

        iLine = m_iLine
        iPanel = m_iPanel
        iMarkNo = m_iAlignMarkNo
        iMarkUseNo = m_iAlignMarkUseNo

    End Sub


#If SIMUL <> 1 Then
    Public pMilInterface As MilInterface
    Public pMilProcessor As MilImageProcessor
#End If

    Public strCamIP() As String = New String(3) {"170.254.100.11", "168.254.100.12", "167.254.100.13", "166.254.100.14"}
    'Public mCamLiveWnd As New LiveImageWnd

    Public Structure _CAMERA
        Public Const A_CAMERA_1 As Integer = 0
        Public Const A_CAMERA_2 As Integer = 1

        Public Const B_CAMERA_1 As Integer = 2
        Public Const B_CAMERA_2 As Integer = 3

        'Public Const INSP_CAMERA_1 As Integer = 0
        'Public Const INSP_CAMERA_2 As Integer = 1
        'Public Const INSP_CAMERA_MARK As Integer = 2

        Public Const CHANELNUM As Integer = 1 '3
        Public Const SHARED_SYSTEM_NUM As Integer = 1
        Public Const MIL_SYSTEM_NUM As Integer = 1
        Public Const DIGITIZER_NUM As Integer = 4 '3 '4
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

        ' 디폴트 값은 Sentech STC-CLC152A 카메라(1X) 기준. 단위는 [um/PXL]
        'Public Const PIXEL_RESOLUTION As Double = 0.00465F
        Public Const PIXEL_RESOLUTION As Double = 0.0022F

        Public Const FOV_X As Double = 3.0 '[mm]
        Public Const FOV_Y As Double = 2.2 '[mm]

        ' Public Const PIXEL_RESOLUTION_EDGE As Double = 0.0044
        'Public Const PIXEL_RESOLUTION_CUTTING As Double = 0.00293
    End Structure

    Public Structure _PATH
        Const EQP_NAME As String = "NarrowBezelLaserCutting"
        Public Const MAIN_DRIVE As String = "D:\"
        Public Const LOG_DRIVE As String = "D:\"
        Public Const CONFIG_CAMERA_DCF As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCamera.dcf"
        Public Const CONFIG_CAMERA_DCF_EXT As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCameraExt.dcf"
        Public Const CONFIG_CAMERA_DCF_MONO As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCamera_AC1600_20GC.dcf"
        Public Const CONFIG_CAMERA_DCF_COLOR As String = MAIN_DRIVE + EQP_NAME + "\CONFIG\CAMERA_DCF\PolCuttingCamera_AC1600_20GM.dcf"
        Public Const RECIPE_MODEL_ALIGN_MARK_DEFULT As String = "C:\Chamfering System\Setting\Vision\Trimming_Mark1.mmf"

        '20161103 JCM EDIT
        'Public Const RECIPE_MODEL_ALIGN_MARK1_A_LINE As String = "C:\Chamfering System\Setting\Vision\Trimming_Mark1_TriAngle_A.mmf"
        'Public Const RECIPE_MODEL_ALIGN_MARK2_A_LINE As String = "C:\Chamfering System\Setting\Vision\Trimming_Mark2_TriAngle_A.mmf"
        'Public Const RECIPE_MODEL_ALIGN_MARK1_B_LINE As String = "C:\Chamfering System\Setting\Vision\Trimming_Mark1_TriAngle_B.mmf"
        'Public Const RECIPE_MODEL_ALIGN_MARK2_B_LINE As String = "C:\Chamfering System\Setting\Vision\Trimming_Mark2_TriAngle_B.mmf"
    End Structure
    Public RECIPE_MODEL_ALIGN_MARK1_A_LINE As String = ""   'pRcpMark_Data(0, 0, 0, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK2_A_LINE As String = ""   'pRcpMark_Data(0, 0, 1, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK1_B_LINE As String = ""   'pRcpMark_Data(1, 0, 0, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK2_B_LINE As String = ""   'pRcpMark_Data(1, 0, 0, 0).strAlignMarkImageMMF_FileName

    Public RECIPE_MODEL_ALIGN_MARK1_A_LINE_1 As String = ""   'pRcpMark_Data(0, 0, 0, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK2_A_LINE_1 As String = ""   'pRcpMark_Data(0, 0, 1, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK1_B_LINE_1 As String = ""   'pRcpMark_Data(1, 0, 0, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK2_B_LINE_1 As String = ""   'pRcpMark_Data(1, 0, 0, 0).strAlignMarkImageMMF_FileName

    Public RECIPE_MODEL_ALIGN_MARK1_A_LINE_2 As String = ""   'pRcpMark_Data(0, 0, 0, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK2_A_LINE_2 As String = ""   'pRcpMark_Data(0, 0, 1, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK1_B_LINE_2 As String = ""   'pRcpMark_Data(1, 0, 0, 0).strAlignMarkImageMMF_FileName
    Public RECIPE_MODEL_ALIGN_MARK2_B_LINE_2 As String = ""   'pRcpMark_Data(1, 0, 0, 0).strAlignMarkImageMMF_FileName


    Public Structure AlignData
        Dim bMark As Boolean
        Dim nSubMark As Integer
        Dim nAlignMark_SearchOffsetX As Integer
        Dim nAlignMark_SearchOffsetY As Integer
        Dim nAlignMark_SearchSizeX As Integer
        Dim nAlignMark_SearchSizeY As Integer
        Dim nAlignMark_ModelOffsetX As Integer
        Dim nAlignMark_ModelOffsetY As Integer
        Dim nAlignMark_ModelSizeX As Integer
        Dim nAlignMark_ModelSizeY As Integer
        Dim nAlignMark_Acceptance As Integer
        Dim nAlignMark_Certainty As Integer
        Dim nAlignMark_OriginPosX As Integer
        Dim nAlignMark_OriginPosY As Integer
        Dim dAlignMark_Result_Acceptance As Double
        Dim strAlignMarkImageBMP_FileName As String
        Dim strAlignMarkImageMMF_FileName As String
        Dim strAlignMarkImageBMP_Mask_FileName As String
        Dim strAlignMarkImageMMF_Mask_FileName As String

        Public Sub Init()
            strAlignMarkImageBMP_FileName = ""
            strAlignMarkImageMMF_FileName = ""
            strAlignMarkImageBMP_Mask_FileName = ""
            strAlignMarkImageMMF_Mask_FileName = ""
        End Sub

    End Structure

    Public Const NUMBER_OF_MODELS = 1
#If SIMUL <> 1 Then
    Public Const SINGLE_MODEL_SEARCH_SPEED As Integer = MIL.M_MEDIUM  'MIL.M_VERY_HIGH
#End If
    'Public pVisionMarkNum As AlignMarkNum
    'Public pCurMark_Data As AlignData
    Public pRcpMark_Data(1, 3, 1, 2) As AlignData       ' line, panel, mark 순서, 갯수
    Public pRcpMark_Data_Tmp(1, 3, 1, 2) As AlignData       ' line, panel, mark 순서, 갯수
    Public pCurMark_Data As AlignData
    Public pCurMark_Data_1 As AlignData
    Public pCurMark_Data_2 As AlignData

    Public pCurSeqMark_Data(1) As AlignData


    Public pMF_Result(1, 3, 1) As tagModelResult



    Public Sub Init()
        On Error GoTo syserr
        pCurMark_Data.Init()
        pCurMark_Data_1.Init()
        pCurMark_Data_2.Init()
        pCurSeqMark_Data(0).Init()
        pCurSeqMark_Data(1).Init()

        'For l = 0 To 1
        '    For p = 0 To 3
        '        For m = 0 To 1
        '            For c = 0 To 2
        '                pRcpMark_Data(l, p, m, c).Init()
        '            Next
        '        Next
        '    Next
        'Next

        RECIPE_MODEL_ALIGN_MARK1_A_LINE = pRcpMark_Data(0, 0, 0, 0).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK2_A_LINE = pRcpMark_Data(0, 0, 1, 0).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK1_B_LINE = pRcpMark_Data(1, 0, 0, 0).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK2_B_LINE = pRcpMark_Data(1, 0, 1, 0).strAlignMarkImageMMF_FileName

        RECIPE_MODEL_ALIGN_MARK1_A_LINE_1 = pRcpMark_Data(0, 0, 0, 1).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK2_A_LINE_1 = pRcpMark_Data(0, 0, 1, 1).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK1_B_LINE_1 = pRcpMark_Data(1, 0, 0, 1).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK2_B_LINE_1 = pRcpMark_Data(1, 0, 1, 1).strAlignMarkImageMMF_FileName

        RECIPE_MODEL_ALIGN_MARK1_A_LINE_2 = pRcpMark_Data(0, 0, 0, 2).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK2_A_LINE_2 = pRcpMark_Data(0, 0, 1, 2).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK1_B_LINE_2 = pRcpMark_Data(1, 0, 0, 2).strAlignMarkImageMMF_FileName
        RECIPE_MODEL_ALIGN_MARK2_B_LINE_2 = pRcpMark_Data(1, 0, 1, 2).strAlignMarkImageMMF_FileName

#If SIMUL <> 1 Then
        pMilInterface = New MilInterface
        pMilProcessor = New MilImageProcessor

        'For nCamera = 0 To 3
        '    pCamera(nCamera) = New Camera
        '    pCamera(nCamera).m_strCam = "Cam" & nCamera + 1
        '    pCamera(nCamera).m_iIndex = nCamera

        '    'GYN - TEST (우선 막고 진행)
        '    pCamera(nCamera).Connecting()

        '    If pCamera(nCamera).m_bConnected Then
        '        pCamera(nCamera).Configuring()
        '    End If

        '    ' streaming은 view form이 로도된 후에...
        '    pCamera(nCamera).StartingStream()
        '    pCamera(nCamera).Streaming()
        'Next

#End If
        Exit Sub
syserr:
        MsgBox(Err.Description & "modVision::init()")
    End Sub

    Public Sub Finalize()
        On Error GoTo syserr
#If SIMUL <> 1 Then

        pMilInterface.DestroyMil()
        pMilInterface = Nothing

#End If
        Exit Sub
syserr:
        MsgBox(Err.Description & "modVision::Finalize()")
    End Sub


#If SIMUL <> 1 Then

    Public Function SaveModel(ByVal ipModelFinder As Object, ByVal ipImageBuf As MIL_ID, ByVal ipImageBufSave As MIL_ID, ByVal ipMGraphic As Object, _
                              ByVal ipFilePath As String, ByRef ipAlignData As AlignData) As String
        On Error GoTo syserr
        'Dim tmpOffX As Integer
        'Dim tmpOffY As Integer

        'For i% = 0 To ipModelFinder.Models.Count - 1
        '    ipModelFinder.Models.Remove(i% + 1)
        'Next i%

        'tmpOffX = ipAlignData.nAlignMark_ModelOffsetX - ipAlignData.nAlignMark_SearchOffsetX
        'tmpOffY = ipAlignData.nAlignMark_ModelOffsetY - ipAlignData.nAlignMark_SearchOffsetY

        'ipModelFinder.Image = ipImageBuf
        'ipModelFinder.ModelFinderType = MIL.ModelFinder.ModModelFinderTypeConstants.modGeometric
        'ipModelFinder.Models.TotalNumberOfOccurrences = 1
        'ipModelFinder.Models.SmoothnessLevel = 50.1
        'ipModelFinder.Models.DetailLevel = Matrox.ActiveMIL.ModelFinder.ModMediumHighConstants.modMedium                              '결과 표현 분해능
        'ipModelFinder.Models.Speed = Matrox.ActiveMIL.ModelFinder.ModMediumHighConstants.modMedium                                    '검색 속도
        'ipModelFinder.Models.Accuracy = Matrox.ActiveMIL.ModelFinder.ModMediumHighConstants.modMedium                                 '검색 분해능
        'ipModelFinder.Models.SearchAngleEnabled = True
        'ipModelFinder.Models.SearchScaleEnabled = True
        'ipModelFinder.Models.SharedEdges = False
        'ipModelFinder.Models.Timeout = 2000

        'ipModelFinder.Models.AddImageModel(ipImageBuf, tmpOffX, tmpOffY, ipAlignData.nAlignMark_ModelSizeX, ipAlignData.nAlignMark_ModelSizeY)

        '' 모델 이미지 bmp저장
        'If ipImageBufSave.IsAllocated = True Then
        '    ipImageBufSave.Free()
        'End If

        'ipImageBufSave.SizeX = ipAlignData.nAlignMark_ModelSizeX
        'ipImageBufSave.SizeY = ipAlignData.nAlignMark_ModelSizeY

        'ipImageBufSave.Allocate()
        'ipImageBufSave.CopyRegion(ipImageBuf, Matrox.ActiveMIL.ImBandConstants.imAllBands, tmpOffX, tmpOffY, _
        '                          Matrox.ActiveMIL.ImBandConstants.imAllBands, 0, 0, ipAlignData.nAlignMark_ModelSizeX, ipAlignData.nAlignMark_ModelSizeY)

        'Select Case ipAlignData.MarkNum
        '    Case AlignMarkNum.A1_L1_M1
        '        ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark1_A1_L1_M1" & ".bmp"
        '        ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark1_A1_L1_M1" & ".mmf"
        '    Case AlignMarkNum.A1_L1_M2
        '        ipAlignData.strAlignMarkImageBMP_FileName = ipFilePath & "\" & "Mark2_A1_L1_M2" & ".bmp"
        '        ipAlignData.strAlignMarkImageMMF_FileName = ipFilePath & "\" & "Mark2_A1_L1_M2" & ".mmf"
        '       ...


        'End Select
        'ipImageBufSave.Save(ipAlignData.strAlignMarkImageBMP_FileName)

        'ipModelFinder.Models(1).NumberOfOccurrences = 1 ' Matrox.ActiveMIL.ModelFinder.ModAllConstants.modAll                  '찾을 대상체의 갯수를 여기서 설정 / Default = 1 주의!!!!
        'ipModelFinder.Models(1).Acceptance = ipAlignData.nAlignMark_Acceptance
        'ipModelFinder.Models(1).Certainty = ipAlignData.nAlignMark_Certainty

        ''20160620 이근욱S 수정 - Align Mark 찾기 조건에 AcceptanceTarget = 60, CertaintyTarget = 90 추가
        'ipModelFinder.Models(1).AcceptanceTarget = 60.0
        'ipModelFinder.Models(1).CertaintyTarget = 90.0

        'ipModelFinder.Models(1).Angle.Value = 0 ' set_GeoPara.cDOF_Angle                                    '검색 시작 각도
        'ipModelFinder.Models(1).Angle.NegativeDelta = 10 'set_GeoPara.cDOF_AngleNegative                    '검색 범위 -
        'ipModelFinder.Models(1).Angle.PositiveDelta = 10 ' set_GeoPara.cDOF_AnglePositive                    '검색 범위 +
        'ipModelFinder.Models(1).Scale.Minimum = 1 - (50 / 100) 'set_GeoPara.cDOF_ScaleMinimum                           '검색 대상 인식 최소 Scale
        'ipModelFinder.Models(1).Scale.Maximum = 1 + (50 / 100) 'set_GeoPara.cDOF_ScaleMaximum                           '검색 대상 인식 최대 Scale

        'ipModelFinder.Models.Item(1) '
        'ipModelFinder.Save(ipAlignData.strAlignMarkImageMMF_FileName)
        'ipModelFinder.Preprocess()
        'System.Threading.Thread.Sleep(100)
        'ipModelFinder.Find()
        'If ipModelFinder.Results.Count = 0 Then
        '    SaveModel = "Model Find Failed!"
        'Else
        '    Dim ResultIndex As Integer
        '    For ResultIndex = 1 To ipModelFinder.Results.Count

        '        With ipModelFinder.Results.Item(ResultIndex)
        '            pMF_Result.Score = Math.Round(.Score, 3)
        '            pMF_Result.Scale = .Scale
        '            pMF_Result.PositionX = ipAlignData.nAlignMark_SearchOffsetX + Math.Round(.PositionX)
        '            pMF_Result.PositionY = ipAlignData.nAlignMark_SearchOffsetY + Math.Round(.PositionY)
        '            pMF_Result.Angle = .Angle
        '            ipAlignData.nAlignMark_OriginPosX = pMF_Result.PositionX
        '            ipAlignData.nAlignMark_OriginPosY = pMF_Result.PositionY
        '            pMF_Result.PositionDiffX = 0
        '            pMF_Result.positionDiffY = 0
        '            CrossDraw(ipMGraphic, pMF_Result.PositionX, pMF_Result.PositionY, 15, 15, Color.Yellow)
        '        End With
        '    Next ResultIndex
        '    SaveModel = ""
        'End If


        'Exit Function
syserr:
        SaveModel = Err.Description
    End Function
#End If

    Public Function AdjustModel(ByVal ipModelFinder As Object, ByRef ipAlignData As AlignData) As String
        On Error GoTo syserr
        ipModelFinder.Models(1).NumberOfOccurrences = 1 ' Matrox.ActiveMIL.ModelFinder.ModAllConstants.modAll                  '찾을 대상체의 갯수를 여기서 설정 / Default = 1 주의!!!!
        ipModelFinder.Models(1).Acceptance = ipAlignData.nAlignMark_Acceptance - 20 'set_GeoPara.cAcceptance
        ipModelFinder.Models(1).Certainty = ipAlignData.nAlignMark_Certainty - 20 'set_GeoPara.cCertainty
        ipModelFinder.Models(1).Angle.Value = 0 ' set_GeoPara.cDOF_Angle                                    '검색 시작 각도
        ipModelFinder.Models(1).Angle.NegativeDelta = 15 'set_GeoPara.cDOF_AngleNegative                    '검색 범위 -
        ipModelFinder.Models(1).Angle.PositiveDelta = 15 ' set_GeoPara.cDOF_AnglePositive                    '검색 범위 +
        ipModelFinder.Models(1).Scale.Minimum = 1 - (50 / 100) 'set_GeoPara.cDOF_ScaleMinimum                           '검색 대상 인식 최소 Scale
        ipModelFinder.Models(1).Scale.Maximum = 1 + (50 / 100) 'set_GeoPara.cDOF_ScaleMaximum                           '검색 대상 인식 최대 Scale
#If SIMUL <> 1 Then

        'ipModelFinder.Models(1).Polarity = Matrox.ActiveMIL.ModelFinder.ModPolarityConstants.modSame
#End If

        ipModelFinder.Models.Item(1) '
        AdjustModel = ""
        Exit Function
syserr:
        AdjustModel = Err.Description
    End Function

    '#If SIMUL <> 1 Then
    '    Public Function FindModel(ByVal nCameraNumber As Integer, ByVal ipModelFinder As Object, ByVal ipBuf As Object, ByVal ipBufChd As Object, _
    '                                ByVal ipMGraphic As Object, ByRef ipAlignData As AlignData, Optional ByVal bovr As Boolean = True) As String
    '        On Error GoTo SysErr
    '        Dim strRtn As String

    '        If ipBufChd.IsAllocated = True Then
    '            ipBufChd.Free()
    '        End If

    '        ipBufChd.ChildRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '        ipBufChd.ChildRegion.OffsetX = ipAlignData.nAlignMark_SearchOffsetX
    '        ipBufChd.ChildRegion.OffsetY = ipAlignData.nAlignMark_SearchOffsetY
    '        ipBufChd.ChildRegion.SizeX = ipAlignData.nAlignMark_SearchSizeX
    '        ipBufChd.ChildRegion.SizeY = ipAlignData.nAlignMark_SearchSizeY
    '        ipBufChd.Allocate()
    '        ipBufChd.FileFormat = Matrox.ActiveMIL.ImFileFormatConstants.imJPEGLossyFileFormat

    '        ipBufChd.save("C:\TEMP.jpg")

    '        For i% = 0 To ipModelFinder.Models.Count - 1
    '            ipModelFinder.Models.Remove(i% + 1)
    '        Next i%

    '        ipModelFinder.Load(ipAlignData.strAlignMarkImageMMF_FileName)



    '        strRtn = AdjustModel(ipModelFinder, ipAlignData)
    '        If strRtn <> "" Then
    '            FindModel = strRtn
    '            GoTo OutSub
    '        End If

    '        ipModelFinder.Image = ipBufChd
    '        ipModelFinder.Preprocess()
    '        ipModelFinder.Find()

    '        If ipModelFinder.Results.Count = 0 Then
    '            FindModel = "Model Find Failed!"
    '            GoTo OutSub
    '        End If

    '        Dim ResultIndex As Integer
    '        For ResultIndex = 1 To ipModelFinder.Results.Count
    '            With ipModelFinder.Results.Item(ResultIndex)
    '                pMF_Result.Score = Math.Round(.Score, 3)
    '                pMF_Result.Scale = Math.Round(.Scale, 3)
    '                pMF_Result.Angle = Math.Round(.Angle, 5)
    '                pMF_Result.PositionX = ipAlignData.nAlignMark_SearchOffsetX + Math.Round(.PositionX)
    '                pMF_Result.PositionY = ipAlignData.nAlignMark_SearchOffsetY + Math.Round(.PositionY)
    '                pMF_Result.PositionDiffX = ipAlignData.nAlignMark_OriginPosX - pMF_Result.PositionX
    '                pMF_Result.positionDiffY = ipAlignData.nAlignMark_OriginPosY - pMF_Result.PositionY
    '                pMF_Result.BoxX1 = pMF_Result.PositionX - (ipAlignData.nAlignMark_ModelSizeX / 2)
    '                pMF_Result.BoxY1 = pMF_Result.PositionY - (ipAlignData.nAlignMark_ModelSizeY / 2)
    '                pMF_Result.BoxX2 = pMF_Result.PositionX + (ipAlignData.nAlignMark_ModelSizeX / 2)
    '                pMF_Result.BoxY2 = pMF_Result.PositionY + (ipAlignData.nAlignMark_ModelSizeY / 2)

    '                If bovr = True Then
    '                    CrossDraw(ipMGraphic, pMF_Result.PositionX, pMF_Result.PositionY, 15, 15, Color.Yellow)
    '                    RectangleDraw(ipMGraphic, pMF_Result.BoxX1, pMF_Result.BoxY1, pMF_Result.BoxX2, pMF_Result.BoxY2, Color.Yellow)

    '                    Select Case nCameraNumber
    '                        Case 1
    '                            ipMGraphic.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            ipMGraphic.ForegroundColor = Color.Lime
    '                            ipMGraphic.FontScaleX = 3
    '                            ipMGraphic.FontScaleY = 3
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 100
    '                            ipMGraphic.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_A1, 3).ToString)
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 150
    '                            ipMGraphic.Text("Position Y : " & Math.Round(((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_A1) * -1, 3).ToString)
    '                            RectangleDraw(ipMGraphic, ipAlignData.nAlignMark_SearchOffsetX, ipAlignData.nAlignMark_SearchOffsetY, _
    '                                          ipAlignData.nAlignMark_SearchOffsetX + ipAlignData.nAlignMark_SearchSizeX, ipAlignData.nAlignMark_SearchOffsetY + ipAlignData.nAlignMark_SearchSizeY, Color.Red)

    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            frmVision.MGraphicContext_MMF_A.BackgroundColor = Color.White
    '                            frmVision.MGraphicContext_MMF_A.ForegroundColor = Color.Lime
    '                            frmVision.MGraphicContext_MMF_A.FontScaleX = 3
    '                            frmVision.MGraphicContext_MMF_A.FontScaleY = 3
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                frmVision.MGraphicContext_MMF_A.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                frmVision.MGraphicContext_MMF_A.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetY = 100
    '                            frmVision.MGraphicContext_MMF_A.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_A1, 3).ToString)
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetY = 150
    '                            frmVision.MGraphicContext_MMF_A.Text("Position Y : " & Math.Round(((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_A1) * -1, 3).ToString)

    '                            CrossDraw(frmVision.MGraphicContext_MMF_A, Math.Round(.PositionX), Math.Round(.PositionY), 15, 15, Color.Yellow)
    '                            RectangleDraw(frmVision.MGraphicContext_MMF_A, pMF_Result.BoxX1 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY1 - ipAlignData.nAlignMark_SearchOffsetY, pMF_Result.BoxX2 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY2 - ipAlignData.nAlignMark_SearchOffsetY, Color.Yellow)


    '                        Case 2
    '                            ipMGraphic.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            ipMGraphic.ForegroundColor = Color.Lime
    '                            ipMGraphic.FontScaleX = 3
    '                            ipMGraphic.FontScaleY = 3
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 100
    '                            ipMGraphic.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_A2, 3).ToString)
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 150
    '                            ipMGraphic.Text("Position Y : " & Math.Round((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_A2, 3).ToString)
    '                            RectangleDraw(ipMGraphic, ipAlignData.nAlignMark_SearchOffsetX, ipAlignData.nAlignMark_SearchOffsetY, _
    '                                          ipAlignData.nAlignMark_SearchOffsetX + ipAlignData.nAlignMark_SearchSizeX, ipAlignData.nAlignMark_SearchOffsetY + ipAlignData.nAlignMark_SearchSizeY, Color.Red)

    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            frmVision.MGraphicContext_MMF_A.BackgroundColor = Color.White
    '                            frmVision.MGraphicContext_MMF_A.ForegroundColor = Color.Lime
    '                            frmVision.MGraphicContext_MMF_A.FontScaleX = 3
    '                            frmVision.MGraphicContext_MMF_A.FontScaleY = 3
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                frmVision.MGraphicContext_MMF_A.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                frmVision.MGraphicContext_MMF_A.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetY = 100
    '                            frmVision.MGraphicContext_MMF_A.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_A2, 3).ToString)
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_A.DrawingRegion.OffsetY = 150
    '                            frmVision.MGraphicContext_MMF_A.Text("Position Y : " & Math.Round((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_A2, 3).ToString)

    '                            CrossDraw(frmVision.MGraphicContext_MMF_A, Math.Round(.PositionX), Math.Round(.PositionY), 15, 15, Color.Yellow)
    '                            RectangleDraw(frmVision.MGraphicContext_MMF_A, pMF_Result.BoxX1 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY1 - ipAlignData.nAlignMark_SearchOffsetY, pMF_Result.BoxX2 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY2 - ipAlignData.nAlignMark_SearchOffsetY, Color.Yellow)

    '                        Case 3
    '                            ipMGraphic.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            ipMGraphic.ForegroundColor = Color.Lime
    '                            ipMGraphic.FontScaleX = 3
    '                            ipMGraphic.FontScaleY = 3
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 100
    '                            ipMGraphic.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_B1, 3).ToString)
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 150
    '                            ipMGraphic.Text("Position Y : " & Math.Round((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_B1, 3).ToString)
    '                            RectangleDraw(ipMGraphic, ipAlignData.nAlignMark_SearchOffsetX, ipAlignData.nAlignMark_SearchOffsetY, _
    '                                          ipAlignData.nAlignMark_SearchOffsetX + ipAlignData.nAlignMark_SearchSizeX, ipAlignData.nAlignMark_SearchOffsetY + ipAlignData.nAlignMark_SearchSizeY, Color.Red)

    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            frmVision.MGraphicContext_MMF_B.BackgroundColor = Color.White
    '                            frmVision.MGraphicContext_MMF_B.ForegroundColor = Color.Lime
    '                            frmVision.MGraphicContext_MMF_B.FontScaleX = 3
    '                            frmVision.MGraphicContext_MMF_B.FontScaleY = 3
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                frmVision.MGraphicContext_MMF_B.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                frmVision.MGraphicContext_MMF_B.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetY = 100
    '                            frmVision.MGraphicContext_MMF_B.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_B1, 3).ToString)
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetY = 150
    '                            frmVision.MGraphicContext_MMF_B.Text("Position Y : " & Math.Round((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_B1, 3).ToString)

    '                            CrossDraw(frmVision.MGraphicContext_MMF_B, Math.Round(.PositionX), Math.Round(.PositionY), 15, 15, Color.Yellow)
    '                            RectangleDraw(frmVision.MGraphicContext_MMF_B, pMF_Result.BoxX1 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY1 - ipAlignData.nAlignMark_SearchOffsetY, pMF_Result.BoxX2 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY2 - ipAlignData.nAlignMark_SearchOffsetY, Color.Yellow)

    '                        Case 4
    '                            ipMGraphic.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            ipMGraphic.ForegroundColor = Color.Lime
    '                            ipMGraphic.FontScaleX = 3
    '                            ipMGraphic.FontScaleY = 3
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                ipMGraphic.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 100
    '                            ipMGraphic.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_B2, 3).ToString)
    '                            ipMGraphic.DrawingRegion.SizeX = 500
    '                            ipMGraphic.DrawingRegion.SizeY = 100
    '                            ipMGraphic.DrawingRegion.OffsetX = 50
    '                            ipMGraphic.DrawingRegion.OffsetY = 150
    '                            ipMGraphic.Text("Position Y : " & Math.Round((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_B2, 3).ToString)
    '                            RectangleDraw(ipMGraphic, ipAlignData.nAlignMark_SearchOffsetX, ipAlignData.nAlignMark_SearchOffsetY, _
    '                                          ipAlignData.nAlignMark_SearchOffsetX + ipAlignData.nAlignMark_SearchSizeX, ipAlignData.nAlignMark_SearchOffsetY + ipAlignData.nAlignMark_SearchSizeY, Color.Red)

    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
    '                            frmVision.MGraphicContext_MMF_B.BackgroundColor = Color.White
    '                            frmVision.MGraphicContext_MMF_B.ForegroundColor = Color.Lime
    '                            frmVision.MGraphicContext_MMF_B.FontScaleX = 3
    '                            frmVision.MGraphicContext_MMF_B.FontScaleY = 3
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetY = 50

    '                            If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '                                frmVision.MGraphicContext_MMF_B.Text("Score : " & pMF_Result.Score & " % :: " & "NG")
    '                            Else
    '                                frmVision.MGraphicContext_MMF_B.Text("Score : " & pMF_Result.Score & " % :: " & "OK")
    '                            End If

    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetY = 100
    '                            frmVision.MGraphicContext_MMF_B.Text("Position X : " & Math.Round((pMF_Result.PositionX - 670) * pCurSystemParam.dVisionScaleX_B2, 3).ToString)
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeX = 500
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.SizeY = 100
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetX = 50
    '                            frmVision.MGraphicContext_MMF_B.DrawingRegion.OffsetY = 150
    '                            frmVision.MGraphicContext_MMF_B.Text("Position Y : " & Math.Round((pMF_Result.PositionY - 520) * pCurSystemParam.dVisionScaleY_B2, 3).ToString)

    '                            CrossDraw(frmVision.MGraphicContext_MMF_B, Math.Round(.PositionX), Math.Round(.PositionY), 15, 15, Color.Yellow)
    '                            RectangleDraw(frmVision.MGraphicContext_MMF_B, pMF_Result.BoxX1 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY1 - ipAlignData.nAlignMark_SearchOffsetY, pMF_Result.BoxX2 - ipAlignData.nAlignMark_SearchOffsetX, pMF_Result.BoxY2 - ipAlignData.nAlignMark_SearchOffsetY, Color.Yellow)

    '                    End Select

    '                End If
    '            End With
    '        Next ResultIndex

    '        ipBufChd.save("C:\TEMP.jpg")

    '        If pMF_Result.Score < ipAlignData.nAlignMark_Acceptance Then
    '            FindModel = "Model Find Failed!"
    '            GoTo OutSub
    '        End If

    '        If ipBufChd.IsAllocated = True Then
    '            ipBufChd.Free()
    '        End If

    '        FindModel = "OK"
    '        Exit Function
    'SysErr:
    '        If ipBufChd.IsAllocated = True Then
    '            ipBufChd.Free()
    '        End If

    '        FindModel = Err.Description
    'OutSub:

    '        If ipBufChd.IsAllocated = True Then
    '            ipBufChd.Free()
    '        End If

    '    End Function
    '#End If

    '#If SIMUL <> 1 Then

    '    Public Function SaveMaskMMF(ByVal ModelFineder As Object, ByVal OriMarkImageBuf As Object, ByVal SaveMarkImageBuf As Object, _
    '                               ByVal strOriMarkFilePath As String, ByVal strSaveMaskMarkFilePath As String, _
    '                               ByVal OffsetX As Integer, ByVal OffsetY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As Boolean
    '        On Error GoTo SysErr
    '        ModelFineder.Load(strOriMarkFilePath)
    '        OriMarkImageBuf.Load(strOriMarkFilePath, False)
    '        If SaveMarkImageBuf.IsAllocated = True Then
    '            SaveMarkImageBuf.Free()
    '        End If
    '        SaveMarkImageBuf.SizeX = ModelFineder.Models.Item(1).ImageDefinition.SizeX
    '        SaveMarkImageBuf.SizeY = ModelFineder.Models.Item(1).ImageDefinition.SizeY
    '        SaveMarkImageBuf.Allocate()
    '        SaveMarkImageBuf.Clear()
    '        SaveMarkImageBuf.CopyRegion(OriMarkImageBuf, Matrox.ActiveMIL.ImBandConstants.imAllBands, _
    '                                    OffsetX, OffsetY, Matrox.ActiveMIL.ImBandConstants.imAllBands, OffsetX, OffsetY, SizeX, SizeY)
    '        SaveMarkImageBuf.Save(strSaveMaskMarkFilePath)
    '        Return True
    '        Exit Function
    'SysErr:
    '        Return False
    '    End Function
    '#End If

    Structure tagBlobData
        Dim Area As Double
        Dim BoxCenterX As Double
        Dim BoxCenterY As Double
        Dim BoxOffX As Double
        Dim BoxOffY As Double
        Dim BoxSizeX As Double
        Dim BoxSizeY As Double
        Dim CenterGX As Double
        Dim CenterGY As Double
        Dim XmaxAtYmax As Double
        Dim XminAtYmin As Double
        Dim YmaxAtXmin As Double
        Dim YminAtXmax As Double
        Dim Ymax As Double
        Dim Ymin As Double
        Dim Xmax As Double
        Dim Xmin As Double
    End Structure

    Structure tagBlobResult
        Dim nTotalBlobCnt As Integer
        Dim BlobData() As tagBlobData
    End Structure

    Public rtnBlobResult As tagBlobResult

    Public Sub MakeChildBuf(ByVal ipParentBuf As Object, ByVal ipChildBuf As Object, _
                ByVal ipOffX As Integer, ByVal ipOffY As Integer, ByVal ipWidth As Integer, ByVal ipHeight As Integer)
        On Error GoTo SysErr

        If ipOffX < 0 Then ipOffX = 0
        If ipOffY < 0 Then ipOffY = 0
        If ipWidth > ipParentBuf.SizeX Then ipWidth = ipParentBuf.SizeX
        If ipHeight > ipParentBuf.SizeY Then ipHeight = ipParentBuf.SizeY

        If ipChildBuf.IsAllocated = True Then
            ipChildBuf.Free()
        End If

        ipChildBuf.ParentImage = ipParentBuf

#If SIMUL <> 1 Then
        ' ipChildBuf.ChildRegion.Mode = roiOffsetSize
#End If

        ipChildBuf.ChildRegion.OffsetX = ipOffX
        ipChildBuf.ChildRegion.OffsetY = ipOffY
        ipChildBuf.ChildRegion.SizeX = ipWidth
        ipChildBuf.ChildRegion.SizeY = ipHeight

        If ipChildBuf.IsAllocated = False Then
            ipChildBuf.Allocate()
        End If

        Exit Sub
SysErr:
        MsgBox(Err.Description)
    End Sub

    '#If SIMUL <> 1 Then

    '    Public Function Blob_Search(ByVal ipBufMain As Object, ByRef ipBufMainChild As Object, _
    '            ByVal ipBlobCtl As Object, ByVal ipImgProcess As Object, _
    '            ByVal ipGraphicContext As Object, ByVal ipOptBinCond As ImpConditionConstants, ByVal BinarizeValue As Long, _
    '             ByVal ipBlobLow As Double, ByVal ipBlobHigh As Double, ByVal bBlack As Boolean, _
    '            ByVal ipOffX As Integer, ByVal ipOffY As Integer, ByVal ipWidth As Integer, ByVal ipHeight As Integer) As Boolean
    '        On Error GoTo SysErr
    '        Dim nTotalBlobs As Long
    '        Dim idx As Long

    '        MakeChildBuf(ipBufMain, ipBufMainChild, ipOffX, ipOffY, ipWidth, ipHeight)

    '        ipBlobCtl.Image = ipBufMainChild

    '        ipImgProcess.Source1 = ipBufMainChild
    '        ipImgProcess.Destination1 = ipBufMainChild

    '        ipImgProcess.Binarize(ipOptBinCond, BinarizeValue)
    '        ipImgProcess.Open(1, Matrox.ActiveMIL.ImageProcessing.ImpProcessingModeConstants.impGrayscale)
    '        ipImgProcess.Close(1, Matrox.ActiveMIL.ImageProcessing.ImpProcessingModeConstants.impGrayscale)

    '        ipBlobCtl.IdentifierBlobType = blobIndividual
    '        ipBlobCtl.IdentifierPixelType = blobGrayscale
    '        ipBlobCtl.Lattice = blob8Connected
    '        ipBlobCtl.NumberOfFeretAngles = 8

    '        If bBlack = True Then
    '            ipBlobCtl.ForegroundPixelValue = blobZero
    '        Else
    '            ipBlobCtl.ForegroundPixelValue = blobNonZero
    '        End If

    '        ipBlobCtl.PixelAspectRatio = 1

    '        ipBlobCtl.FeatureList.Area = True : ipBlobCtl.Calculate()
    '        ipBlobCtl.FeatureList.Box.All = True : ipBlobCtl.Calculate()
    '        ipBlobCtl.FeatureList.CenterOfGravity.All = True : ipBlobCtl.Calculate()
    '        ipBlobCtl.FeatureList.Compactness = True : ipBlobCtl.Calculate()

    '        ipBlobCtl.SortingKeys.Add(Matrox.ActiveMIL.BlobAnalysis.BlobFeatureConstants.blobArea, Matrox.ActiveMIL.BlobAnalysis.BlobOrderingConstants.blobDecreasing, Matrox.ActiveMIL.BlobAnalysis.BlobPriorityConstants.blobPriority1) : ipBlobCtl.Calculate()
    '        ipBlobCtl.SortingKeys.Add(Matrox.ActiveMIL.BlobAnalysis.BlobFeatureConstants.blobCenterOfGravityX, Matrox.ActiveMIL.BlobAnalysis.BlobOrderingConstants.blobIncreasing, Matrox.ActiveMIL.BlobAnalysis.BlobPriorityConstants.blobPriority2) : ipBlobCtl.Calculate()
    '        ipBlobCtl.SortingKeys.Add(Matrox.ActiveMIL.BlobAnalysis.BlobFeatureConstants.blobCenterOfGravityY, Matrox.ActiveMIL.BlobAnalysis.BlobOrderingConstants.blobIncreasing, Matrox.ActiveMIL.BlobAnalysis.BlobPriorityConstants.blobPriority3) : ipBlobCtl.Calculate()

    '        idx& = ipBlobCtl.Filters.Add(blobInclude, blobArea, blobInRange, ipBlobLow, ipBlobHigh) : ipBlobCtl.Calculate()
    '        ipBlobCtl.ApplyFilter(idx&, False) : ipBlobCtl.Calculate()

    '        nTotalBlobs = ipBlobCtl.Results.Count

    '        If nTotalBlobs = 0 Then
    '            Blob_Search = False
    '            rtnBlobResult.nTotalBlobCnt = nTotalBlobs
    '            ipBlobCtl.SortingKeys.Remove(3)
    '            ipBlobCtl.SortingKeys.Remove(2)
    '            ipBlobCtl.SortingKeys.Remove(1)
    '            ipBlobCtl.Filters.Remove(1)

    '            Exit Function
    '        End If

    '        rtnBlobResult.nTotalBlobCnt = nTotalBlobs
    '        ReDim rtnBlobResult.BlobData(nTotalBlobs - 1)
    '        For i As Integer = 0 To nTotalBlobs - 1
    '            rtnBlobResult.BlobData(i).Area = ipBlobCtl.Results(i + 1).Area
    '            rtnBlobResult.BlobData(i).BoxOffX = ipOffX + ipBlobCtl.Results(i + 1).BoxXMinimum
    '            rtnBlobResult.BlobData(i).BoxOffY = ipOffY + ipBlobCtl.Results(i + 1).BoxYMinimum
    '            rtnBlobResult.BlobData(i).BoxSizeX = ipBlobCtl.Results(i + 1).BoxXMaximum - ipBlobCtl.Results(i + 1).BoxXMinimum
    '            rtnBlobResult.BlobData(i).BoxSizeY = ipBlobCtl.Results(i + 1).BoxYMaximum - ipBlobCtl.Results(i + 1).BoxYMinimum
    '            rtnBlobResult.BlobData(i).BoxCenterX = rtnBlobResult.BlobData(i).BoxOffX + (rtnBlobResult.BlobData(i).BoxSizeX / 2)
    '            rtnBlobResult.BlobData(i).BoxCenterY = rtnBlobResult.BlobData(i).BoxOffY + (rtnBlobResult.BlobData(i).BoxSizeY / 2)
    '            rtnBlobResult.BlobData(i).CenterGX = ipOffX + ipBlobCtl.Results(i + 1).CenterOfGravityX
    '            rtnBlobResult.BlobData(i).CenterGY = ipOffY + ipBlobCtl.Results(i + 1).CenterOfGravityY
    '            rtnBlobResult.BlobData(i).XmaxAtYmax = ipOffX + ipBlobCtl.Results(i + 1).ContactPointXMaximumAtYMaximum
    '            rtnBlobResult.BlobData(i).XminAtYmin = ipOffX + ipBlobCtl.Results(i + 1).ContactPointXMinimumAtYMinimum
    '            rtnBlobResult.BlobData(i).YmaxAtXmin = ipOffY + ipBlobCtl.Results(i + 1).ContactPointYMaximumAtXMinimum
    '            rtnBlobResult.BlobData(i).YminAtXmax = ipOffY + ipBlobCtl.Results(i + 1).ContactPointYMinimumAtXMaximum
    '            rtnBlobResult.BlobData(i).Xmax = ipOffX + ipBlobCtl.Results(i + 1).BoxXMaximum
    '            rtnBlobResult.BlobData(i).Xmin = ipOffX + ipBlobCtl.Results(i + 1).BoxXMinimum
    '            rtnBlobResult.BlobData(i).Ymax = ipOffY + ipBlobCtl.Results(i + 1).BoxYMaximum
    '            rtnBlobResult.BlobData(i).Ymin = ipOffY + ipBlobCtl.Results(i + 1).BoxYMinimum
    '        Next i

    '        If nTotalBlobs <> 0 Then
    '            Blob_Search = True
    '        Else
    '            Blob_Search = False
    '        End If

    '        ipBlobCtl.SortingKeys.Remove(3)
    '        ipBlobCtl.SortingKeys.Remove(2)
    '        ipBlobCtl.SortingKeys.Remove(1)
    '        ipBlobCtl.Filters.Remove(1)
    '        Exit Function

    'SysErr:

    '        For i As Integer = ipBlobCtl.SortingKeys.Count To 1 Step -1
    '            ipBlobCtl.SortingKeys.Remove(i)
    '        Next i
    '        For i As Integer = ipBlobCtl.Filters.Count To 1 Step -1
    '            ipBlobCtl.Filters.Remove(i)
    '        Next i
    '        '   MsgBox(Err.Description)

    '        Blob_Search = False
    '    End Function
    '#End If

    Public Function Slope(ByVal X1 As Double, ByVal Y1 As Double, ByVal X2 As Double, ByVal Y2 As Double) As Double
        On Error GoTo SysErr

        Dim SlopeXY As Double

        If X1 = X2 Then
            SlopeXY = 0
        Else
            SlopeXY = (Y2 - Y1) / (X2 - X1)
        End If

        Return SlopeXY

        Exit Function
SysErr:

    End Function

    Public Sub GetLineValue(ByVal ipImgBuf As Object, ByVal ipStartX As Integer, ByVal ipStartY As Integer, ByVal ipEndX As Integer, ByVal ipEndY As Integer, _
                         ByRef IpImgArr() As Byte)
        On Error GoTo SysErr

        Dim ArraySize As Double
        'If ipEndY > 1039 Then
        '    ipEndY = 1000
        'End If

        'If ipEndX > 1339 Then
        '    ipEndX = 1300
        'End If
        ArraySize = ipImgBuf.GetLine(System.DBNull.Value, ipStartX, ipStartY, ipEndX, ipEndY)
        ReDim IpImgArr(ArraySize)
        ipImgBuf.GetLine(IpImgArr, ipStartX, ipStartY, ipEndX, ipEndY)

        Exit Sub
SysErr:
        'MsgBox(Err.Description)

    End Sub

    Public Function GetLineCrossPoint(ByRef CrossPosX As Integer, ByRef CrossPosY As Integer, ByVal PosX1 As Integer, ByVal PosY1 As Integer, ByVal PosX2 As Integer, ByVal PosY2 As Integer, _
                                  ByVal PosX3 As Integer, ByVal PosY3 As Integer, ByVal PosX4 As Integer, ByVal PosY4 As Integer) As Boolean
        On Error GoTo SysErr
        Dim tmpSlope1 As Double = 0
        Dim tmpSlope2 As Double = 0
        Dim tmpValue1 As Double = 0
        Dim tmpValue2 As Double = 0

        tmpSlope1 = Slope(PosX1, PosY1, PosX2, PosY2)
        tmpSlope2 = Slope(PosX3, PosY3, PosX4, PosY4)

        tmpValue1 = PosY1 - tmpSlope1 * PosX1
        tmpValue2 = PosY3 - tmpSlope2 * PosX3

        If tmpSlope1 <> tmpSlope2 Then
            CrossPosX = (tmpValue2 - tmpValue1) / (tmpSlope1 - tmpSlope2)
        End If
        If tmpSlope2 = 0 Then
            CrossPosX = PosX3
        End If
        CrossPosY = tmpSlope1 * CrossPosX + tmpValue1
        If tmpSlope1 = 0 Then
            CrossPosY = PosY1
        End If

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Public Sub LineDraw(ByVal GraphicContext As Object, ByVal ipStartX As Integer, ByVal ipStartY As Integer, ByVal ipEndX As Integer, _
                             ByVal ipEndY As Integer, ByVal c As Color)
        On Error GoTo SysErr

        GraphicContext.ForegroundColor = c
#If SIMUL <> 1 Then
        'GraphicContext.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
#End If
        GraphicContext.DrawingRegion.StartX = ipStartX
        GraphicContext.DrawingRegion.StartY = ipStartY
        GraphicContext.DrawingRegion.EndX = ipEndX
        GraphicContext.DrawingRegion.EndY = ipEndY
        GraphicContext.LineSegment()

        GraphicContext.DrawingRegion.StartX = ipStartX + 1
        GraphicContext.DrawingRegion.StartY = ipStartY
        GraphicContext.DrawingRegion.EndX = ipEndX + 1
        GraphicContext.DrawingRegion.EndY = ipEndY
        GraphicContext.LineSegment()

        GraphicContext.DrawingRegion.StartX = ipStartX
        GraphicContext.DrawingRegion.StartY = ipStartY + 1
        GraphicContext.DrawingRegion.EndX = ipEndX
        GraphicContext.DrawingRegion.EndY = ipEndY + 1
        GraphicContext.LineSegment()

        Exit Sub
SysErr:
    End Sub

    Public Sub RectangleDraw(ByVal GraphicContext As Object, ByVal ipStartX As Integer, ByVal ipStartY As Integer, ByVal ipEndX As Integer, _
                             ByVal ipEndY As Integer, ByVal c As Color)
        On Error GoTo SysErr

        GraphicContext.ForegroundColor = c
#If SIMUL <> 1 Then
        'GraphicContext.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiOffsetSize
#End If
        GraphicContext.DrawingRegion.StartX = ipStartX
        GraphicContext.DrawingRegion.StartY = ipStartY
        GraphicContext.DrawingRegion.EndX = ipEndX
        GraphicContext.DrawingRegion.EndY = ipEndY
        GraphicContext.Rectangle()
        GraphicContext.DrawingRegion.StartX = ipStartX + 1
        GraphicContext.DrawingRegion.StartY = ipStartY + 1
        GraphicContext.DrawingRegion.EndX = ipEndX + 1
        GraphicContext.DrawingRegion.EndY = ipEndY + 1
        GraphicContext.Rectangle()

        Exit Sub
SysErr:

    End Sub

    Public Sub CircleDraw(ByVal GraphicContext As Object, ByVal ipCenterX As Integer, ByVal ipCenterY As Integer, ByVal ipSizeX As Integer, _
                             ByVal ipSizeY As Integer, ByVal c As Color)

        On Error GoTo SysErr

        GraphicContext.ForegroundColor = c
#If SIMUL <> 1 Then
        ' GraphicContext.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiCenterSize
#End If
        GraphicContext.DrawingRegion.SizeX = ipSizeX
        GraphicContext.DrawingRegion.SizeY = ipSizeY
        GraphicContext.DrawingRegion.CenterX = ipCenterX
        GraphicContext.DrawingRegion.CenterY = ipCenterY
        GraphicContext.Arc()
        GraphicContext.DrawingRegion.SizeX = ipSizeX
        GraphicContext.DrawingRegion.SizeY = ipSizeY
        GraphicContext.DrawingRegion.CenterX = ipCenterX + 1
        GraphicContext.DrawingRegion.CenterY = ipCenterY
        GraphicContext.Arc()
        GraphicContext.DrawingRegion.SizeX = ipSizeX
        GraphicContext.DrawingRegion.SizeY = ipSizeY
        GraphicContext.DrawingRegion.CenterX = ipCenterX
        GraphicContext.DrawingRegion.CenterY = ipCenterY + 1
        GraphicContext.Arc()

        Exit Sub
SysErr:

    End Sub

    Public Sub CrossDraw(ByVal GraphicContext As Object, ByVal ipStartX As Integer, ByVal ipStartY As Integer, ByVal ipSizeX As Integer, _
                             ByVal ipSizeY As Integer, ByVal c As Color)
        On Error GoTo SysErr

        GraphicContext.Width = 3
        GraphicContext.ForegroundColor = c
#If SIMUL <> 1 Then
        ' GraphicContext.DrawingRegion.Mode = Matrox.ActiveMIL.RoiModeConstants.roiCenterSize
#End If
        GraphicContext.DrawingRegion.SizeX = ipSizeX
        GraphicContext.DrawingRegion.SizeY = ipSizeY
        GraphicContext.DrawingRegion.CenterX = ipStartX
        GraphicContext.DrawingRegion.CenterY = ipStartY
        GraphicContext.Cross()

        GraphicContext.DrawingRegion.SizeX = ipSizeX
        GraphicContext.DrawingRegion.SizeY = ipSizeY
        GraphicContext.DrawingRegion.CenterX = ipStartX + 1
        GraphicContext.DrawingRegion.CenterY = ipStartY + 1
        GraphicContext.Cross()

        Exit Sub
SysErr:

    End Sub

    Public Sub ClearDisplay(ByVal ipDisp As Object, ByVal GraphicContext As Object, ByVal ipColor As Color, Optional ByVal ipCross As Boolean = True)
        On Error GoTo SysErr

        ipDisp.ClearOverlay()
        If ipCross = True Then
            CrossDraw(GraphicContext, ipDisp.SizeX, ipDisp.SizeY, ipDisp.SizeX * 2, ipDisp.SizeY * 2, ipColor)
        End If

        Exit Sub
SysErr:
    End Sub

    Public Function Point2PointDistant(ByVal ipX1 As Double, ByVal ipY1 As Double, ByVal ipX2 As Double, ByVal ipY2 As Double) As Double
        On Error GoTo SysErr

        Dim nDistant As Double = 0

        nDistant = Math.Sqrt((ipX2 - ipX1) ^ 2 + (ipY2 - ipY1) ^ 2)

        Return nDistant

        Exit Function
SysErr:

    End Function

    '    Public Function FindModel(ByVal nCamera As Integer, ByRef MResult As tagModelResult, Optional ByVal nSavePath As Integer = 99) As Boolean
    '#If SIMUL <> 1 Then

    '        Dim bResult As Boolean = False
    '        Dim roi_mark_area As MIL_ID
    '        Dim dPxlOffsetX As Double
    '        Dim dPxlOffsetY As Double
    '        Dim dT As Double
    '        Dim dScore As Double
    '        Dim tmpSavePath As String = ""

    '        Dim rcRoi As Rectangle

    '        Select Case nSavePath
    '            Case 0
    '                rcRoi.X = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchSizeY
    '            Case 1
    '                rcRoi.X = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchSizeY
    '            Case 2
    '                rcRoi.X = pRcpMark_Data(0, 1, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 1, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 1, 0, 0).nAlignMark_SearchSizeY
    '            Case 3
    '                rcRoi.X = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchSizeY
    '            Case 4
    '                rcRoi.X = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchSizeY
    '            Case 5
    '                rcRoi.X = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchSizeY
    '            Case 6
    '                rcRoi.X = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchSizeY
    '            Case 7
    '                rcRoi.X = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchSizeY
    '            Case 10
    '                rcRoi.X = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchSizeY
    '            Case 11
    '                rcRoi.X = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchSizeY
    '            Case 12
    '                rcRoi.X = pRcpMark_Data(1, 1, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 1, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 1, 0, 0).nAlignMark_SearchSizeY
    '            Case 13
    '                rcRoi.X = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchSizeY
    '            Case 14
    '                rcRoi.X = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchSizeY
    '            Case 15
    '                rcRoi.X = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchSizeY
    '            Case 16
    '                rcRoi.X = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchSizeY
    '            Case 17
    '                rcRoi.X = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
    '                rcRoi.Y = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchOffsetY
    '                rcRoi.Width = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchSizeX
    '                rcRoi.Height = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchSizeY
    '        End Select

    '        'GYN - 2016.12.06 - 현재 디폴트 ROI 영역.
    '        rcRoi.X = 300
    '        rcRoi.Y = 100
    '        rcRoi.Width = 860
    '        rcRoi.Height = 840

    '        MResult.Init()

    '        pMilProcessor.GetROIImage(pMilInterface.dispImage(nCamera), pMilInterface.dispImageChild(nCamera), rcRoi)
    '        roi_mark_area = pMilInterface.dispImageChild(nCamera)

    '        bResult = pMilProcessor.FindAlignMark(roi_mark_area, pMilInterface.MilSearchContext(nCamera), pMilInterface.MilModResult(nCamera), dPxlOffsetX, dPxlOffsetY, dT, dScore)

    '        Select Case nSavePath
    '            Case 0
    '                tmpSavePath = "C:\Vision Temp\A1_Mark1.bmp"
    '            Case 1
    '                tmpSavePath = "C:\Vision Temp\A1_Mark2.bmp"
    '            Case 2
    '                tmpSavePath = "C:\Vision Temp\A2_Mark1.bmp"
    '            Case 3
    '                tmpSavePath = "C:\Vision Temp\A2_Mark2.bmp"
    '            Case 4
    '                tmpSavePath = "C:\Vision Temp\A3_Mark1.bmp"
    '            Case 5
    '                tmpSavePath = "C:\Vision Temp\A3_Mark2.bmp"
    '            Case 6
    '                tmpSavePath = "C:\Vision Temp\A4_Mark1.bmp"
    '            Case 7
    '                tmpSavePath = "C:\Vision Temp\A4_Mark2.bmp"
    '            Case 10
    '                tmpSavePath = "C:\Vision Temp\B1_Mark1.bmp"
    '            Case 11
    '                tmpSavePath = "C:\Vision Temp\B1_Mark2.bmp"
    '            Case 12
    '                tmpSavePath = "C:\Vision Temp\B2_Mark1.bmp"
    '            Case 13
    '                tmpSavePath = "C:\Vision Temp\B2_Mark2.bmp"
    '            Case 14
    '                tmpSavePath = "C:\Vision Temp\B3_Mark1.bmp"
    '            Case 15
    '                tmpSavePath = "C:\Vision Temp\B3_Mark2.bmp"
    '            Case 16
    '                tmpSavePath = "C:\Vision Temp\B4_Mark1.bmp"
    '            Case 17
    '                tmpSavePath = "C:\Vision Temp\B4_Mark2.bmp"
    '        End Select

    '        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
    '        MIL.MgraFontScale(MIL.M_DEFAULT, 1, 1)
    '        MIL.MgraText(MIL.M_DEFAULT, pMilInterface.MilOverlayImage(nCamera), 10, 10, "X:" & dPxlOffsetX & "," & "Y:" & dPxlOffsetY)
    '        MIL.MgraText(MIL.M_DEFAULT, pMilInterface.MilOverlayImage(nCamera), 10, 30, "Score:" & dScore)

    '        If nSavePath <> 99 Then
    '            'If System.IO.File.Exists(tmpSavePath) = True Then
    '            '    System.IO.File.Delete(tmpSavePath)
    '            'End If
    '            pMilProcessor.SaveImage(pMilInterface.dispImageChild(nCamera), MIL.M_BMP, 1, tmpSavePath)
    '        End If

    '        MIL.MbufFree(roi_mark_area)

    '        If bResult <> True Then
    '            Return False
    '        End If

    '        Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0
    '        pMilProcessor.GetImageSize(pMilInterface.dispImage(nCamera), lSizeX, lSizeY)

    '        '20161031 JCM 수정 , 기존 A4 수정 방법 과 동일 하게 수정
    '        'dPxlOffsetX = (dPxlOffsetX + rcRoi.X) - CDbl(lSizeX) / 2.0 ' 기존
    '        'dPxlOffsetY = CDbl(lSizeY / 2.0) - (dPxlOffsetY + rcRoi.Y)

    '        '20161031 JCM 수정 , 기존 A4 수정 방법 과 동일 하게 수정
    '        dPxlOffsetX = (dPxlOffsetX + rcRoi.X) - CDbl(lSizeX / 2.0) ' 수정
    '        dPxlOffsetY = (dPxlOffsetY + rcRoi.Y) - CDbl(lSizeY / 2.0)
    '        'dTmpPosX = dTmpPosX - CDbl(m_lImageX / 2.0)
    '        'dTmpPosY = dTmpPosY - CDbl(m_lImageY / 2.0)

    '        MResult.bFindSuccess = True
    '        MResult.PositionDiffX = dPxlOffsetX
    '        MResult.positionDiffY = dPxlOffsetY
    '        MResult.Score = dScore


    '#End If
    '        Return True
    '    End Function

    '파라메터 추가본 FindModel
    '20180115 Mark Merge
    Public Function FindModel(ByVal nCamera As Integer, ByRef MResult As tagModelResult, Optional ByVal nSavePath As Integer = 99, _
                              Optional ByVal nLine As Integer = 0, Optional ByVal nPanel As Integer = 0, Optional ByVal nMark As Integer = 0, Optional ByVal nSubMark As Integer = 0) As Boolean
#If SIMUL <> 1 Then

        Dim bResult As Boolean = False
        Dim roi_mark_area As MIL_ID
        Dim dPxlOffsetX As Double
        Dim dPxlOffsetY As Double
        Dim dT As Double
        Dim dScore As Double
        Dim tmpSavePath As String = ""

        'GYN - 2017.06.07 - 얼라인 로그 남기기.
        Dim strAlignLog As String = ""

        Dim rcRoi As Rectangle

        rcRoi.X = pRcpMark_Data(nLine, nPanel, nMark, nSubMark).nAlignMark_SearchOffsetX     ' line, panel, mark 순서, 갯수 'pCurMark_Data.nAlignMark_SearchOffsetX
        rcRoi.Y = pRcpMark_Data(nLine, nPanel, nMark, nSubMark).nAlignMark_SearchOffsetY
        rcRoi.Width = pRcpMark_Data(nLine, nPanel, nMark, nSubMark).nAlignMark_SearchSizeX
        rcRoi.Height = pRcpMark_Data(nLine, nPanel, nMark, nSubMark).nAlignMark_SearchSizeY

        'GYN - 2016.12.06 - 현재 디폴트 ROI 영역.
        'rcRoi.X = 300
        'rcRoi.Y = 100
        'rcRoi.Width = 860
        'rcRoi.Height = 840

        MResult.Init()

        If rcRoi.Width <= 0 Or rcRoi.Height <= 0 Then
            modPub.ErrorLog(Err.Description & "ROI Area Error")
            Return False
        End If

        pMilProcessor.GetROIImage(pMilInterface.dispImage(nCamera), pMilInterface.dispImageChild(nCamera), rcRoi)
        roi_mark_area = pMilInterface.dispImageChild(nCamera)

        If Matrox.MatroxImagingLibrary.MIL.M_NULL <> pMilInterface.MilModResult(nCamera) Then
            Matrox.MatroxImagingLibrary.MIL.MmodFree(pMilInterface.MilModResult(nCamera))
        End If
        Matrox.MatroxImagingLibrary.MIL.MmodAllocResult(pMilInterface.MilSystem, Matrox.MatroxImagingLibrary.MIL.M_DEFAULT, pMilInterface.MilModResult(nCamera))

        bResult = pMilProcessor.FindAlignMark(roi_mark_area, pMilInterface.MilSearchContext(nLine, nPanel, nMark, nSubMark), pMilInterface.MilModResult(nCamera), dPxlOffsetX, dPxlOffsetY, dT, dScore)

        '20170721 chy mark 매칭률 90% 이상만 ture
        'If dScore >= pCurMark_Data.nAlignMark_Acceptance Then
        If dScore >= pRcpMark_Data(nLine, nPanel, nMark, 0).nAlignMark_Acceptance Then
            'If dScore >= 90 Then
            bResult = True
        Else
            bResult = False
        End If

        'tmpSavePath << 이거 되면 하자.
        Dim strLine(1) As String

        strLine(0) = "A"
        strLine(1) = "B"

        tmpSavePath = "C:\Vision Temp\" & strLine(nLine) & nPanel + 1 & "_Mark" & nMark + 1 & ".bmp"

        Select Case nSavePath
            Case 0
                tmpSavePath = "C:\Vision Temp\A1_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p1, strAlignLog)
            Case 1
                tmpSavePath = "C:\Vision Temp\A1_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p1, strAlignLog)
            Case 2
                tmpSavePath = "C:\Vision Temp\A2_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p2, strAlignLog)
            Case 3
                tmpSavePath = "C:\Vision Temp\A2_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p2, strAlignLog)
            Case 4
                tmpSavePath = "C:\Vision Temp\A3_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p3, strAlignLog)
            Case 5
                tmpSavePath = "C:\Vision Temp\A3_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p3, strAlignLog)
            Case 6
                tmpSavePath = "C:\Vision Temp\A4_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p4, strAlignLog)
            Case 7
                tmpSavePath = "C:\Vision Temp\A4_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p4, strAlignLog)
            Case 10
                tmpSavePath = "C:\Vision Temp\B1_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p1, strAlignLog)
            Case 11
                tmpSavePath = "C:\Vision Temp\B1_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p1, strAlignLog)
            Case 12
                tmpSavePath = "C:\Vision Temp\B2_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p2, strAlignLog)
            Case 13
                tmpSavePath = "C:\Vision Temp\B2_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p2, strAlignLog)
            Case 14
                tmpSavePath = "C:\Vision Temp\B3_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p3, strAlignLog)
            Case 15
                tmpSavePath = "C:\Vision Temp\B3_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p3, strAlignLog)
            Case 16
                tmpSavePath = "C:\Vision Temp\B4_Mark1.bmp"
                strAlignLog = "MARK1:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p4, strAlignLog)
            Case 17
                tmpSavePath = "C:\Vision Temp\B4_Mark2.bmp"
                strAlignLog = "MARK2:: " & dPxlOffsetX.ToString & ", " & dPxlOffsetY.ToString
                AlignDataLog(nLine, Panel.p4, strAlignLog)
        End Select

        'If nSavePath <> 99 Then
        'If System.IO.File.Exists(tmpSavePath) = True Then
        '    System.IO.File.Delete(tmpSavePath)
        'End If
        'pMilProcessor.SaveImage(pMilInterface.dispImageChild(nCamera), MIL.M_BMP, 1, tmpSavePath)
        'pMilProcessor.SaveImage(pMilInterface.dispImageChild(nCamera), MIL.M_JPEG_LOSSY, 5, tmpSavePath)
        pMilProcessor.SaveImage(roi_mark_area, MIL.M_JPEG_LOSSY, 5, tmpSavePath)
        'End If

        MIL.MbufFree(roi_mark_area)

        If dScore = 0 Then
            Return False
        End If

        Dim lSizeX As Int32 = 0, lSizeY As Int32 = 0
        pMilProcessor.GetImageSize(pMilInterface.dispImage(nCamera), lSizeX, lSizeY)

        '20161031 JCM 수정 , 기존 A4 수정 방법 과 동일 하게 수정
        'dPxlOffsetX = (dPxlOffsetX + rcRoi.X) - CDbl(lSizeX) / 2.0 ' 기존
        'dPxlOffsetY = CDbl(lSizeY / 2.0) - (dPxlOffsetY + rcRoi.Y)

        '20161031 JCM 수정 , 기존 A4 수정 방법 과 동일 하게 수정
        dPxlOffsetX = (dPxlOffsetX + rcRoi.X) - CDbl(lSizeX / 2.0) '수정
        dPxlOffsetY = (dPxlOffsetY + rcRoi.Y) - CDbl(lSizeY / 2.0)
        'dTmpPosX = dTmpPosX - CDbl(m_lImageX / 2.0)
        'dTmpPosY = dTmpPosY - CDbl(m_lImageY / 2.0)


        MResult.PositionDiffX = dPxlOffsetX
        MResult.positionDiffY = dPxlOffsetY
        MResult.Score = dScore

        If bResult <> True Then
            Return False
        End If

        MResult.bFindSuccess = True
        'If pMF_Result.Score < pCurMark_Data.nAlignMark_Acceptance Then
        '    MResult.Score = dScore
        'Else
        '    MResult.Score = dScore
        'End If


#End If
        Return True
    End Function

    'Public Sub GetGlassCenter(ByVal nLine As Integer, ByVal nGlass As Integer, ByRef RecipeData As RecipeParam, ByVal SystemParam As SystemParameter, _
    '                           Optional ByVal bOnlyLaser1 As Boolean = False, Optional ByVal bOnlyLaser2 As Boolean = False)
    '이놈은 들어가서 설명. ㅋ
    Public Sub GetGlassCenter(ByVal nLine As Integer, ByVal nGlass As Integer, ByRef RecipeData As RecipeParam, ByVal SystemParam As SystemParameter)
        On Error GoTo SysErr

        Dim tmpAnglePosX1 As Double
        Dim tmpAnglePosY1 As Double
        Dim tmpAnglePosX2 As Double
        Dim tmpAnglePosY2 As Double
        Dim tmpGlassCenterX As Double
        Dim tmpGlassCenterY As Double
        Dim tmpLaserOffsetX As Double
        Dim tmpLaserOffsetY As Double
        Dim tmpOutAngle As Double
        Dim tmpGlassCenterX2 As Double
        Dim tmpGlassCenterY2 As Double
        Dim tmpScannerNum As Integer
        Dim tmpDir As Integer = 1

        ' glss center
        tmpGlassCenterX2 = RecipeData.dCenterX
        tmpGlassCenterY2 = RecipeData.dCenterY

        Select Case nGlass
            Case 0
                If nLine = 0 Then
                    'tmpScannerNum = 1
                    tmpScannerNum = 0
                ElseIf nLine = 1 Then
                    tmpScannerNum = 0
                End If
            Case 1
                If nLine = 0 Then
                    'tmpScannerNum = 0
                    tmpScannerNum = 1
                ElseIf nLine = 1 Then
                    tmpScannerNum = 1
                End If
            Case 2
                If nLine = 0 Then
                    'tmpScannerNum = 3
                    tmpScannerNum = 2
                ElseIf nLine = 1 Then
                    tmpScannerNum = 2
                End If
            Case 3
                If nLine = 0 Then
                    'tmpScannerNum = 2
                    tmpScannerNum = 3
                ElseIf nLine = 1 Then
                    tmpScannerNum = 3
                End If
        End Select

        Select Case nLine
            Case 0
                tmpDir = 1
            Case 1
                tmpDir = -1
        End Select

        tmpLaserOffsetX = SystemParam.dVisionLaserOffsetX(nLine, tmpScannerNum)
        tmpLaserOffsetY = SystemParam.dVisionLaserOffsetY(nLine, tmpScannerNum)

        'tmpGlassCenterX2 = 36.47
        'tmpGlassCenterY2 = 67.68

        tmpAnglePosX1 = RecipeData.dStageAlignMark1PosX(nLine, nGlass)  '측정 위치
        tmpAnglePosY1 = RecipeData.dStageAlignMark1PosY(nLine, nGlass)  '측정 위치
        tmpAnglePosX1 = tmpAnglePosX1 - RecipeData.AlignResult(nLine, nGlass).dMark1DifferencePositionX '측정위치 - 카메라 앵글 틀어짐 계산값
        tmpAnglePosY1 = tmpAnglePosY1 + (RecipeData.AlignResult(nLine, nGlass).dMark1DifferencePositionY * tmpDir)  '측정위치 - 카메라 앵글 틀어짐 계산값

        tmpAnglePosX2 = RecipeData.dStageAlignMark2PosX(nLine, nGlass)
        tmpAnglePosY2 = RecipeData.dStageAlignMark2PosY(nLine, nGlass)
        tmpAnglePosX2 = tmpAnglePosX2 - RecipeData.AlignResult(nLine, nGlass).dMark2DifferencePositionX
        tmpAnglePosY2 = tmpAnglePosY2 + (RecipeData.AlignResult(nLine, nGlass).dMark2DifferencePositionY * tmpDir)

        If nLine = 1 Then
            tmpOutAngle = MeasureAngleDeg(tmpAnglePosY2, tmpAnglePosX2, tmpAnglePosY1, tmpAnglePosX1)
            If Not tmpOutAngle = 0.0 Then
                tmpOutAngle = tmpOutAngle - 90.0
            End If
        ElseIf nLine = 0 Then
            tmpOutAngle = MeasureAngleDeg(tmpAnglePosY1, tmpAnglePosX1, tmpAnglePosY2, tmpAnglePosX2)
        End If

        RecipeData.AlignResult(nLine, nGlass).dAngle = tmpOutAngle
        AdjustAngle(tmpGlassCenterX2, tmpGlassCenterY2, tmpOutAngle)

        If nLine = 1 Then
            RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionX = tmpAnglePosX2 + tmpLaserOffsetX - tmpGlassCenterY2
            RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionY = tmpAnglePosY2 + tmpLaserOffsetY + (tmpGlassCenterX2 * tmpDir)

            modPub.TestLog("LineB_Panel" & nGlass + 1 & "_dMarkDestPositionX : " & RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionX.ToString)
            modPub.TestLog("LineB_Panel" & nGlass + 1 & "_dMarkDestPositionY : " & RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionY.ToString)

        ElseIf nLine = 0 Then
            RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionX = tmpAnglePosX1 + tmpLaserOffsetX - tmpGlassCenterY2
            RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionY = tmpAnglePosY1 + tmpLaserOffsetY + (tmpGlassCenterX2 * tmpDir)

            modPub.TestLog("LineA_Panel" & nGlass + 1 & "_dMarkDestPositionX : " & RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionX.ToString)
            modPub.TestLog("LineA_Panel" & nGlass + 1 & "_dMarkDestPositionY : " & RecipeData.AlignResult(nLine, nGlass).dMarkDestPositionY.ToString)

        End If

        Exit Sub
SysErr:
        Dim tmpstrTest As String = MsgBox(Err.Description)

    End Sub

    'Camera 틀어진 값을 보상한 후 Pixel이 위치한 거리 값을 빼기 위한 함수.
    Public Function AdjustCameraFactor(ByVal ipPosX As Double, ByVal ipPosY As Double, ByVal ipVisionScaleX As Double, ByVal ipVisionScaleY As Double, ByVal ipVisionAngle As Double, _
                                       ByRef outPosX As Double, ByRef outPosY As Double) As Boolean
        On Error GoTo SysErr

        outPosX = Math.Round((ipPosX * ipVisionScaleX * Math.Cos(ipVisionAngle) - ipPosY * ipVisionScaleY * Math.Sin(ipVisionAngle)), 3)
        outPosY = Math.Round((ipPosX * ipVisionScaleX * Math.Sin(ipVisionAngle) + ipPosY * ipVisionScaleY * Math.Cos(ipVisionAngle)), 3)

        'pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionX = Math.Round((pMF_Result.PositionDiffX * pCurSystemParam.dVisionScaleX(LINE.A, 1) * Math.Cos(pCurSystemParam.dVisionTheta(LINE.A, 1)) - pMF_Result.positionDiffY * pCurSystemParam.dVisionScaleY(LINE.A, 1) * Math.Sin(pCurSystemParam.dVisionTheta(LINE.A, 1))), 3)
        'pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionY = Math.Round((pMF_Result.PositionDiffX * pCurSystemParam.dVisionScaleX(LINE.A, 1) * Math.Sin(pCurSystemParam.dVisionTheta(LINE.A, 1)) + pMF_Result.positionDiffY * pCurSystemParam.dVisionScaleY(LINE.A, 1) * Math.Cos(pCurSystemParam.dVisionTheta(LINE.A, 1))), 3)

        Return True
SysErr:
        Return False
    End Function

End Module
