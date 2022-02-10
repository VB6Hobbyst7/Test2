Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports System.Threading
Imports Matrox.MatroxImagingLibrary
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Imports System.Net
'Imports Recipe

Class MilInterface
    Inherits MIL
    Private LockThis As New Object()

    Private GrabImage As MIL_ID
    Private iNum As Integer
    Private bUse As Boolean
    Public CheckCam(3) As Boolean

    Public MilApplication As MIL_ID ' Application identifier
    Public MilSystem As MIL_ID      ' System identifier
    Public MilSearchContext As MIL_ID(,,,) = New MIL_ID(1, 3, 1, 2) {} '20180115 Mark Merge
    Public MilRecipeContext As MIL_ID(,,,) = New MIL_ID(1, 3, 1, 2) {} '20180821 sbs
    Public MilModResult As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    Private m_bModelLoaded As Boolean
    Private NumberOfDigitizer As Long   ' Number of digitizers available on the system  - Camera Number
    Public MilDigitizer As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {} ' Digitizer identifier - Camera Number
    Private MilImageDisp As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    Public DigSizeX As Integer() = New Integer(_CAMERA.DIGITIZER_NUM - 1) {}    ' Digitizer input width
    Public DigSizeY As Integer() = New Integer(_CAMERA.DIGITIZER_NUM - 1) {}    ' Digitizer input heigh
    Private Band As Integer() = New Integer(_CAMERA.DIGITIZER_NUM - 1) {}
    Private m_iGrabMode As Integer() = New Integer(_CAMERA.DIGITIZER_NUM - 1) {}
    Private m_bIsCuttingMilDestroyed As Boolean

    Private m_lWhiteBalanceCoeff As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}
    Private m_lBayerPattern As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    Public MilGrabImage As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}
    ' Public AlignImage As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    '실제 구동중 사용하는 Image ID
    Public dispImage As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}
    Public dispImageChild As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    Public MarkImage As MIL_ID() = New MIL_ID(2) {} 'Mark

    'OverlayImage
    Public MilOverlayImage As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    Public MilDisplay As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    'Private m_MilProcImage As MIL_ID() = New MIL_ID(_CAMERA.DIGITIZER_NUM - 1) {}

    Private hUserData As GCHandle() = New GCHandle(_CAMERA.DIGITIZER_NUM - 1) {}

    Public Structure _HOOKDATA

        Public iCamNo As Integer
        Public IDispImage As MIL_ID
        Public bColor As Boolean
        Public lWhiteBalance As Integer
        Public lBayerPattern As Integer
        Public lCnt As Integer

    End Structure

    Dim m_HookData(3) As _HOOKDATA

    Public Sub New()
        MilApplication = M_NULL
        m_bIsCuttingMilDestroyed = False

        MilSystem = M_NULL
        m_bModelLoaded = False

        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            'MilSearchContext(i) = M_NULL
            '20180115 Mark Merge
            For nLine = 0 To 1
                For nPanel = 0 To 3
                    For nMark = 0 To 1
                        For nSubMark = 0 To 2
                            MilSearchContext(nLine, nPanel, nMark, nSubMark) = M_NULL
                            'MilModResult(nLine, nPanel, nMark, nSubMark) = M_NULL
                        Next
                    Next
                Next
            Next
            MilModResult(i) = M_NULL

            MilDigitizer(i) = M_NULL
            DigSizeX(i) = 0
            DigSizeY(i) = 0
            Band(i) = 0

            MilGrabImage(i) = M_NULL
            'AlignImage(i) = M_NULL
            dispImage(i) = M_NULL
            dispImageChild(i) = M_NULL

            MilOverlayImage(i) = M_NULL

            m_iGrabMode(i) = _CAMERA.CONTINUOUS_GRAB_MODE

            m_lWhiteBalanceCoeff(i) = M_NULL
            m_lBayerPattern(i) = M_NULL

            ' m_ExtGrabImageSet(i) = New EdgeImageSet(_CAMERA.EXT_GRAB_BUF_SIZE - 1) {}
            'm_MilProcImage(i) = New MIL_ID(_CAMERA.PROC_BUF_SIZE - 1) {}
            'For k As Integer = 0 To _CAMERA.PROC_BUF_SIZE - 1
            '    m_MilProcImage(i)(k) = M_NULL
            'Next

            'For k As Integer = 0 To _CAMERA.EXT_GRAB_BUF_SIZE - 1
            'm_ExtGrabImageSet(i)(k) = New EdgeImageSet()
            'Next

            m_HookData(i) = New _HOOKDATA()
        Next

        MarkImage(0) = M_NULL
        MarkImage(1) = M_NULL

        Init()
    End Sub

    Public Function Init() As Boolean
        Dim lMilApp As MIL_ID = M_NULL
        MappInquire(M_CURRENT_APPLICATION, lMilApp)

        If M_NULL = lMilApp Then
            MappAlloc(M_DEFAULT, MilApplication)
        Else
            MilApplication = M_NULL
        End If

        Dim lDevNum As MIL_ID = M_DEV0

        MappControl(M_ERROR, M_PRINT_DISABLE)

#If _SIMULATION Then
			Dim lMilSys As MIL_ID = MsysAlloc(M_SYSTEM_HOST, M_DEFAULT, M_DEFAULT, MilSystem)
#Else
        Dim lMilSys As MIL_ID = MsysAlloc(M_SYSTEM_GIGE_VISION, M_DEFAULT, M_DEFAULT, MilSystem)
        'Dim lMilSys As MIL_ID = MsysAlloc(M_SYSTEM_HOST, M_DEFAULT, M_DEFAULT, MilSystem)
#End If

        'if(M_NULL == lMilSys)
        '{
        'MessageBox.Show("시스템에 Solios보드가 설치되어 있지 않습니다. Virtual Host로 설정합니다.");
        'AfxMessageBox(_T("시스템에 Solios보드가 설치되어 있지 않습니다. Virtual Host로 설정합니다."));
        'MsysAlloc(M_SYSTEM_HOST, M_DEFAULT, M_DEFAULT, ref MilSystem);
        '}

        'MappControl(M_ERROR, M_PRINT_ENABLE);

        MsysInquire(MilSystem, M_DIGITIZER_NUM, NumberOfDigitizer)

        'For i As Integer = 0 To 1   '_CAMERA.DIGITIZER_NUM - 1
        Dim nCameraInit As Integer = 0
        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            If 0 < NumberOfDigitizer Then
                '20200317 카메라 사용 모드
                If pCurSystemParam.btnCameraUseMode(i) = 1 Then
                    Dim strDcfPath As String = _PATH.CONFIG_CAMERA_DCF_EXT
                    'MIL_ID lDevNum = M_NULL;
                    Dim lRet As MIL_ID = M_NULL

                    Select Case i
                        Case 0
                            'lDevNum = M_DEV3
                            lDevNum = M_DEV0
                            nCameraInit = nCameraInit + 1
                            'strDcfPath = _PATH.CONFIG_CAMERA_DCF_MONO
                            Exit Select
                        Case 1
                            If nCameraInit = 0 Then
                                lDevNum = M_DEV0
                            Else
                                lDevNum = M_DEV1
                            End If
                            nCameraInit = nCameraInit + 1
                            'lDevNum = M_DEV1
                            'strDcfPath = _PATH.CONFIG_CAMERA_DCF_MONO
                            Exit Select
                        Case 2
                            If nCameraInit = 0 Then
                                lDevNum = M_DEV0
                            ElseIf nCameraInit = 1 Then
                                lDevNum = M_DEV1
                            Else
                                lDevNum = M_DEV2
                            End If
                            nCameraInit = nCameraInit + 1
                            'lDevNum = M_DEV2
                            'strDcfPath = _PATH.CONFIG_CAMERA_DCF_COLOR
                            Exit Select
                        Case 3
                            If nCameraInit = 0 Then
                                lDevNum = M_DEV0
                            ElseIf nCameraInit = 1 Then
                                lDevNum = M_DEV1
                            ElseIf nCameraInit = 2 Then
                                lDevNum = M_DEV2
                            Else
                                lDevNum = M_DEV3
                            End If
                            'lDevNum = M_DEV3
                            'strDcfPath = _PATH.CONFIG_CAMERA_DCF_COLOR
                            Exit Select
                        Case Else
                            lDevNum = M_DEV0
                            Exit Select
                    End Select

                    '카메라 할당
                    lRet = MdigAlloc(MilSystem, lDevNum, "M_DEFAULT", M_DEFAULT, MilDigitizer(i))
                    'Digitizer 카메라 지칭


                    If M_NULL = lRet Then
                        'Dim strMsg As String
                        ' strMsg = String.Format("이더넷 카메라 {0:d}번 연결에 실패 하였습니다.", i + 1)
                        'MessageBox.Show(strMsg)
                        'Return False
                    End If
                    GigeParamSet(i)
                    MdigControl(MilDigitizer(i), M_GRAB_ABORT, M_DEFAULT)
                    MdigControl(MilDigitizer(i), M_GRAB_MODE, M_ASYNCHRONOUS)

                    DigSizeX(i) = MdigInquire(MilDigitizer(i), M_SIZE_X)
                    DigSizeY(i) = MdigInquire(MilDigitizer(i), M_SIZE_Y)
                    'MdigInquire(MilDigitizer(i), M_GRAB_EXPOSURE_TIME + M_TIMER1, dVal)
                    Band(i) = MdigInquire(MilDigitizer(i), M_SIZE_BAND)
                Else
                    frmMSG.ShowMsg("카메라 미사용", "Camera #" & i + 1 & " 미사용 모드입니다.", False, 1)
                    DigSizeX(i) = _CAMERA.PXL_TOT_INSP_X
                    DigSizeY(i) = _CAMERA.PXL_TOT_INSP_Y
                    Band(i) = 1
                End If

            Else
                DigSizeX(i) = _CAMERA.PXL_TOT_INSP_X
                DigSizeY(i) = _CAMERA.PXL_TOT_INSP_Y
                Band(i) = 1
            End If
        Next

        'For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
        '    'if(Data.m_SysRcp.m_rcpMCType.m_uiCamType == (uint)Def.TYPE_CAM_COLOR)
        '    '컷팅 카메라
        '    If i > _CAMERA.EDGE_CAMERA_2 Then
        '        Band(i) = 3
        '        MbufAlloc1d(MilSystem, 3, 32 + M_FLOAT, M_ARRAY, m_lWhiteBalanceCoeff(i))

        '        Dim fCoeff As Single() = New Single(2) {}

        '        'Select Case i
        '        '    Case CInt(_CAMERA.EDGE_CAMERA_1)
        '        '        fCoeff(0) = 1.2871F
        '        '        fCoeff(1) = 0.85782F
        '        '        fCoeff(2) = 1.36681F
        '        '        Exit Select
        '        '    Case CInt(_CAMERA.EDGE_CAMERA_2)
        '        '        fCoeff(0) = 1.23474F
        '        '        fCoeff(1) = 0.87508F
        '        '        fCoeff(2) = 1.30961F
        '        '        Exit Select
        '        '    Case CInt(_CAMERA.LASER_CAMERA_1)
        '        '        fCoeff(0) = 1.23474F
        '        '        fCoeff(1) = 0.87508F
        '        '        fCoeff(2) = 1.30961F
        '        '        Exit Select
        '        '    Case CInt(_CAMERA.LASER_CAMERA_2)
        '        '        fCoeff(0) = 1.23474F
        '        '        fCoeff(1) = 0.87508F
        '        '        fCoeff(2) = 1.30961F
        '        '        Exit Select
        '        '    Case Else

        '        '        Exit Select
        '        'End Select

        '        fCoeff(0) = 1.2871F
        '        fCoeff(1) = 0.85782F
        '        fCoeff(2) = 1.36681F

        '        MbufPut(m_lWhiteBalanceCoeff(i), fCoeff)
        '        m_lBayerPattern(i) = M_BAYER_RG
        '    Else
        '        Band(i) = 1
        '        m_lWhiteBalanceCoeff(i) = M_NULL
        '        m_lBayerPattern(i) = M_NULL

        '        'MdispAlloc(MilSystem, M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, ref MilDisplay[i]);
        '    End If
        'Next

        InitImageBuffer()

        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            LoadAlignModelTemplate(i, _PATH.RECIPE_MODEL_ALIGN_MARK_DEFULT)
            If M_NULL <> MilModResult(i) Then
                MmodFree(MilModResult(i))
            End If
            MmodAllocResult(MilSystem, M_DEFAULT, MilModResult(i))
        Next

        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            'SetExternalTriggerMode(i, False)
            GrabStart(i, True)
        Next

        'MdigGrabContinuous(MilDigitizer[2], dispImage[2]);

        Return True
    End Function

    '20180115 Mark Merge
    Public Function LoadAlignModelTemplate_Total(ByVal nLine As Integer, ByVal nPanel As Integer, ByVal nMark As Integer, ByVal nSubMark As Integer, ByVal szModelName As String) As Boolean
        If Not File.Exists(szModelName) Then
            Dim strMsg As String
            strMsg = String.Format("{0:s} 파일을 찾을 수 없습니다.", szModelName)
            'Log.TextLog(_Log.LOG_TYPE_MAIN, strMsg)
            Return False
        End If

        'MilSearchContext(nLine, nPanel, nMark, nSubMark)
        If M_NULL <> MilSearchContext(nLine, nPanel, nMark, nSubMark) Then
            MmodFree(MilSearchContext(nLine, nPanel, nMark, nSubMark))
            MilSearchContext(nLine, nPanel, nMark, nSubMark) = M_NULL
        End If

        If M_NULL = MmodRestore(szModelName, MilSystem, M_DEFAULT, MilSearchContext(nLine, nPanel, nMark, nSubMark)) Then
            m_bModelLoaded = False
            Return False
        Else
            MmodControl(MilSearchContext(nLine, nPanel, nMark, nSubMark), M_DEFAULT, M_POLARITY, M_SAME_OR_REVERSE)
            MmodPreprocess(MilSearchContext(nLine, nPanel, nMark, nSubMark), M_DEFAULT)
            m_bModelLoaded = True
            Return True
        End If
    End Function

    Public Sub GigeParamSet(ByVal iCameraIndex As Integer)
        'Dim strSize_X As String = "Maximum"
        'Dim strSize_Y As String = "Maximum"
        'Dim strPixelFormat As String = "Mono8"



        'Select Case iCameraIndex
        '    Case 0
        '        strPixelFormat = "Mono8"
        '        Exit Select
        '    Case 1
        '        strPixelFormat = "Mono8"
        '        Exit Select
        '    Case 2
        '        strPixelFormat = "BayerBG8"
        '        Exit Select
        '    Case 3
        '        strPixelFormat = "BayerBG8"
        '        Exit Select
        '    Case Else
        '        strPixelFormat = "Mono8"
        '        Exit Select
        'End Select

        'MdigControl(MilDigitizer(iCameraIndex), M_GRAB_EXPOSURE_TIME + M_TIMER1, 10000)

        'MdigControlFeature(MilDigitizer(iCameraIndex), M_MAX, "Width", M_TYPE_MIL_INT, strSize_X)
        'MdigControlFeature(MilDigitizer(iCameraIndex), M_MAX, "Height", M_TYPE_MIL_INT, strSize_Y)
        'MdigControlFeature(MilDigitizer(iCameraIndex), M_MAX, "PixelFormat", M_TYPE_STRING_ENUMERATION, strPixelFormat)
    End Sub


    Public Sub ReInit()
        DestroyMil()
        Init()
    End Sub

    Public Sub DisplayZoom(ByVal iCamNo As Integer, ByVal dZoomX As Double, ByVal dZoomY As Double)
        MIL.MdispZoom(MilDisplay(iCamNo), dZoomX, dZoomY)
    End Sub

    Public Sub SetGrabMode(ByVal iCamNo As Integer, ByVal iCameraMode As Integer)
        m_iGrabMode(iCamNo) = iCameraMode
    End Sub

    Public Function GetGrabMode(ByVal iCamNo As Integer) As Integer
        Return m_iGrabMode(iCamNo)
    End Function

    Public Sub IsCuttingMilDestroyed(ByVal bYes As Boolean)
        m_bIsCuttingMilDestroyed = bYes
    End Sub


    Public Function LoadAlignModelTemplate(ByVal iIndex As Integer, ByVal szModelName As String) As Boolean
        'If Not File.Exists(szModelName) Then
        '    Dim strMsg As String
        '    strMsg = String.Format("{0:s} 파일을 찾을 수 없습니다.", szModelName)
        '    'Log.TextLog(_Log.LOG_TYPE_MAIN, strMsg)
        '    Return False
        'End If

        'If M_NULL <> MilSearchContext(iIndex) Then
        '    MmodFree(MilSearchContext(iIndex))
        '    MilSearchContext(iIndex) = M_NULL
        'End If

        'If M_NULL = MmodRestore(szModelName, MilSystem, M_DEFAULT, MilSearchContext(iIndex)) Then
        '    m_bModelLoaded = False
        '    Return False
        'Else
        '    MmodControl(MilSearchContext(iIndex), M_DEFAULT, M_POLARITY, M_SAME_OR_REVERSE)
        '    MmodPreprocess(MilSearchContext(iIndex), M_DEFAULT)
        '    m_bModelLoaded = True

        '    Return True
        'End If
    End Function

    Public Function InitImageBuffer() As Boolean
        Dim iImage As Integer
        Dim BufferAttributes As Long

        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            Dim CamNum As Integer = i
            '20200317 카메라 사용 모드
            If pCurSystemParam.btnCameraUseMode(i) = 1 Then
                If 0 < NumberOfDigitizer Then
                    BufferAttributes = M_IMAGE + M_GRAB + M_PROC

                    'iImage = MbufAllocColor(MilSystem, 1, DigSizeX(CamNum), DigSizeY(CamNum), M_DEF_IMAGE_TYPE, BufferAttributes, _
                    ' MilGrabImage(CamNum))
                    'If M_NULL = iImage Then
                    '    Return False
                    'End If

                    'For j As Integer = 0 To _CAMERA.PROC_BUF_SIZE - 1
                    '    iImage = MbufAllocColor(MilSystem, Band(i), DigSizeX(CamNum), DigSizeY(CamNum), M_DEF_IMAGE_TYPE, BufferAttributes, _
                    '     m_MilProcImage(CamNum)(j))
                    '    If M_NULL = iImage Then
                    '        Return False
                    '    End If
                    'Next

                    'For j As Integer = 0 To _CAMERA.EXT_GRAB_BUF_SIZE - 1
                    '    'm_ExtGrabImageSet(CamNum)(j) = New EdgeImageSet()
                    '    iImage = MbufAllocColor(MilSystem, Band(i), DigSizeX(CamNum), DigSizeY(CamNum), M_DEF_IMAGE_TYPE, BufferAttributes, _
                    '     m_ExtGrabImageSet(CamNum)(j).GrabImage)
                    '    If M_NULL = m_ExtGrabImageSet(CamNum)(j).GrabImage Then
                    '        Return False
                    '    End If

                    'Next
                End If

                BufferAttributes = M_IMAGE + M_PROC + M_DISP + M_GRAB

                'Grab용으로 사용하자.! 칼라 -> 흑백 으로~
                iImage = MbufAllocColor(MilSystem, 1, DigSizeX(CamNum), DigSizeY(CamNum), 8 + MIL.M_UNSIGNED, BufferAttributes, _
                     MilGrabImage(CamNum))
                If M_NULL = iImage Then
                    Return False
                End If

                iImage = MbufAllocColor(MilSystem, Band(CamNum), DigSizeX(CamNum), DigSizeY(CamNum), 8 + MIL.M_UNSIGNED, BufferAttributes, _
                 dispImageChild(CamNum))
                If M_NULL = iImage Then
                    Return False
                End If

                'iImage = MbufAllocColor(MilSystem, Band(CamNum), DigSizeX(CamNum), DigSizeY(CamNum), 8 + MIL.M_UNSIGNED + M_UNSIGNED, BufferAttributes, _
                ' dispImage(CamNum))
                'BufferAttributes = M_IMAGE + M_DISP + M_GRAB
                iImage = MbufAllocColor(MilSystem, Band(CamNum), DigSizeX(CamNum), DigSizeY(CamNum), 8 + MIL.M_UNSIGNED, BufferAttributes, _
                 dispImage(CamNum))
                If M_NULL = iImage Then
                    Return False
                End If

                'MilOverlayImage
                iImage = MbufAllocColor(MilSystem, Band(CamNum), DigSizeX(CamNum), DigSizeY(CamNum), 8 + MIL.M_UNSIGNED, BufferAttributes, _
                 MilOverlayImage(CamNum))
                If M_NULL = iImage Then
                    Return False
                End If

                FOVBufChild(CamNum, dispImage(CamNum), dispImageChild(CamNum), _CAMERA.PXL_CHILD_INSP_X, _CAMERA.PXL_CHILD_INSP_Y)
            End If
        Next

        'MarkImage
        iImage = MbufAllocColor(MilSystem, Band(0), DigSizeX(0), DigSizeY(0), 8 + MIL.M_UNSIGNED, BufferAttributes, _
         MarkImage(0))
        If M_NULL = iImage Then
            Return False
        End If

        iImage = MbufAllocColor(MilSystem, Band(1), DigSizeX(1), DigSizeY(1), 8 + MIL.M_UNSIGNED, BufferAttributes, _
         MarkImage(1))
        If M_NULL = iImage Then
            Return False
        End If

        Return True
    End Function

    Public Sub DestroyImageBuffer()
        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            Dim iCamNo As Integer = i

            If M_NULL <> MarkImage(0) Then
                MbufFree(MarkImage(0))
                MarkImage(0) = M_NULL
            End If

            If M_NULL <> MarkImage(1) Then
                MbufFree(MarkImage(1))
                MarkImage(1) = M_NULL
            End If

            If M_NULL <> dispImageChild(iCamNo) Then
                MbufFree(dispImageChild(iCamNo))
                dispImageChild(iCamNo) = M_NULL
            End If

            If M_NULL <> dispImage(iCamNo) Then
                MbufFree(dispImage(iCamNo))
                dispImage(iCamNo) = M_NULL
            End If

            'MilOverlayImage
            If M_NULL <> MilOverlayImage(iCamNo) Then
                MbufFree(MilOverlayImage(iCamNo))
                MilOverlayImage(iCamNo) = M_NULL
            End If

            'If M_NULL <> AlignImage(iCamNo) Then
            '    MbufFree(AlignImage(iCamNo))
            '    AlignImage(iCamNo) = M_NULL
            'End If

            If M_NULL <> MilGrabImage(iCamNo) Then
                MbufFree(MilGrabImage(iCamNo))
                MilGrabImage(iCamNo) = M_NULL
            End If

            'For j As Integer = 0 To _CAMERA.PROC_BUF_SIZE - 1
            '    If m_MilProcImage(iCamNo)(j) <> M_NULL Then
            '        MbufFree(m_MilProcImage(iCamNo)(j))
            '    End If

            '    m_MilProcImage(iCamNo)(j) = M_NULL
            'Next

            'For j As Integer = 0 To _CAMERA.EXT_GRAB_BUF_SIZE - 1
            '    m_ExtGrabImageSet(iCamNo)(j).Reset()
            '    MbufFree(m_ExtGrabImageSet(iCamNo)(j).GrabImage)
            '    m_ExtGrabImageSet(iCamNo)(j).GrabImage = M_NULL
            'Next
        Next
    End Sub

    Public Sub DestroyMil()
        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            GrabStart(i, False)
        Next

        Thread.Sleep(100)
        DestroyImageBuffer()

        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            If M_NULL <> m_lWhiteBalanceCoeff(i) Then
                MbufFree(m_lWhiteBalanceCoeff(i))
                m_lWhiteBalanceCoeff(i) = M_NULL
            End If
            m_lBayerPattern(i) = M_NULL

            If M_NULL <> MilModResult(i) Then
                MmodFree(MilModResult(i))
                MilModResult(i) = M_NULL
            End If
            For nLine = 0 To 1
                For nPanel = 0 To 3
                    For nMark = 0 To 1
                        For nSubMark = 0 To 2
                            'If M_NULL <> MilModResult(nLine, nPanel, nMark, nSubMark) Then
                            '    MmodFree(MilModResult(nLine, nPanel, nMark, nSubMark))
                            '    MilModResult(nLine, nPanel, nMark, nSubMark) = M_NULL
                            'End If
                            If M_NULL <> MilSearchContext(nLine, nPanel, nMark, nSubMark) Then
                                MmodFree(MilSearchContext(nLine, nPanel, nMark, nSubMark))
                                MilSearchContext(nLine, nPanel, nMark, nSubMark) = M_NULL
                            End If

                            If M_NULL <> MilRecipeContext(nLine, nPanel, nMark, nSubMark) Then
                                MmodFree(MilRecipeContext(nLine, nPanel, nMark, nSubMark))
                                MilRecipeContext(nLine, nPanel, nMark, nSubMark) = M_NULL
                            End If
                        Next
                    Next
                Next
            Next
        Next


        m_bModelLoaded = False


        For i As Integer = 0 To _CAMERA.DIGITIZER_NUM - 1
            If 0 < NumberOfDigitizer Then
                If M_NULL <> MilDigitizer(i) Then
                    MdigFree(MilDigitizer(i))
                    MilDigitizer(i) = M_NULL
                End If
            End If

            If M_NULL <> MilDisplay(i) Then
                MdispFree(MilDisplay(i))
                MilDisplay(i) = M_NULL
            End If
        Next



        If M_NULL <> MilSystem Then
            MsysFree(MilSystem)
            MilSystem = M_NULL
        End If

        If M_NULL <> MilApplication Then
            MappFree(MilApplication)
            MilApplication = M_NULL
        End If
    End Sub

    Public Function Grab(ByVal iCamNo As Integer, ByRef image As MIL_ID, ByVal bHighQuality As Boolean) As Boolean
        '=true
        'return true;


        If Not CheckValidCamNo(iCamNo) Then
            Return False
        End If

        If 0 < NumberOfDigitizer Then
            'GrabStart(iCamNo,false);
            'Sleep(50);

            'MdigGrab(MilDigitizer[iCamNo],grabImage[iCamNo]);
            'MdigGrabWait(MilDigitizer[iCamNo],M_GRAB_END);

            If 3 = Band(iCamNo) Then
                If bHighQuality Then
                    MbufCopy(dispImage(iCamNo), image)
                Else
                    MbufCopy(dispImage(iCamNo), image)
                End If
            Else
                MbufCopy(dispImage(iCamNo), image)

                'GrabStart(iCamNo,true);
            End If
        End If

        Return True
    End Function

    Public Function FOVBufChild(ByVal iCamNo As Integer, ByVal srcBuf As MIL_ID, ByRef ChildBuf As MIL_ID, ByVal XSize As Integer, ByVal YSize As Integer) As Boolean
        If M_NULL <> ChildBuf Then
            MbufFree(ChildBuf)
            ChildBuf = M_NULL
        End If

        Dim XMargin As Integer = DigSizeX(iCamNo) - XSize
        Dim YMargin As Integer = DigSizeY(iCamNo) - YSize

        If XMargin < 0 OrElse YMargin < 0 Then
            Return False
        End If

        If M_NULL = MbufChild2d(srcBuf, XMargin \ 2, YMargin \ 2, XSize, YSize, ChildBuf) Then
            Return False
        Else
            Return True
        End If
    End Function

    Shared bInProgress As Boolean() = {False, False, False, False}
    Private ProcessingFunctionPtr As MIL_DIG_HOOK_FUNCTION_PTR() = New MIL_DIG_HOOK_FUNCTION_PTR(_CAMERA.DIGITIZER_NUM - 1) {}


    Public Function GrabStart(ByVal iCamNo As Integer, ByVal bStart As Boolean) As Boolean
        If Not CheckValidCamNo(iCamNo) Then
            Return False
        End If
        If M_NULL = MilDigitizer(iCamNo) Then
            Return False
        End If

        Thread.Sleep(100)
        If bStart Then
            MdigGrabContinuous(MilDigitizer(iCamNo), dispImage(iCamNo))
            pCamera(iCamNo).m_strCam = "Cam" & iCamNo + 1
            pCamera(iCamNo).m_iIndex = iCamNo
            pCamera(iCamNo).m_bConnected = True
        Else
            MdigHalt(MilDigitizer(iCamNo))
        End If

        'If bStart AndAlso Not bInProgress(iCamNo) Then
        '    'm_HookData(iCamNo).iCamNo = iCamNo
        '    'm_HookData(iCamNo).IDispImage = dispImage(iCamNo)
        '    'm_HookData(iCamNo).bColor = If((3 = Band(iCamNo)), True, False)
        '    'm_HookData(iCamNo).lWhiteBalance = m_lWhiteBalanceCoeff(iCamNo)
        '    'm_HookData(iCamNo).lBayerPattern = m_lBayerPattern(iCamNo)
        '    'm_HookData(iCamNo).lCnt = 0
        '    ' 초기화
        '    'hUserData(iCamNo) = GCHandle.Alloc(m_HookData(iCamNo))
        '    ProcessingFunctionPtr(iCamNo) = New MIL_DIG_HOOK_FUNCTION_PTR(AddressOf GrabProcessingFunction)

        '    MdigProcess(MilDigitizer(iCamNo), m_MilProcImage(iCamNo), _CAMERA.PROC_BUF_SIZE, M_START, M_DEFAULT, ProcessingFunctionPtr(iCamNo), GCHandle.ToIntPtr(hUserData(iCamNo)))
        '    bInProgress(iCamNo) = True
        'ElseIf Not bStart AndAlso bInProgress(iCamNo) Then
        '    Dim lOperationFlag As Int32
        '    If _CAMERA.CONTINUOUS_GRAB_MODE = GetGrabMode(iCamNo) Then
        '        ' Continuous Mode -> External Trigger Mode 전환 순간 Queud Grab 이 한번 더 들어오는 것을 막는다 
        '        lOperationFlag = M_STOP + M_WAIT
        '    Else
        '        ' External Trigger Mode의 경우 M_WAIT 옵션을 주면 스레드가 Freeze 된다
        '        lOperationFlag = M_STOP
        '    End If

        '    MdigProcess(MilDigitizer(iCamNo), m_MilProcImage(iCamNo), _CAMERA.PROC_BUF_SIZE, lOperationFlag, M_DEFAULT, ProcessingFunctionPtr(iCamNo), GCHandle.ToIntPtr(hUserData(iCamNo)))
        '    bInProgress(iCamNo) = False
        'End If

        'm_HookData(iCamNo).iCamNo = iCamNo
        'm_HookData(iCamNo).IDispImage = dispImage(iCamNo)
        'm_HookData(iCamNo).bColor = If((3 = Band(iCamNo)), True, False)
        'm_HookData(iCamNo).lWhiteBalance = m_lWhiteBalanceCoeff(iCamNo)
        'm_HookData(iCamNo).lBayerPattern = m_lBayerPattern(iCamNo)
        'm_HookData(iCamNo).lCnt = 0
        '' 초기화
        'hUserData(iCamNo) = GCHandle.Alloc(m_HookData(iCamNo))
        'ProcessingFunctionPtr(iCamNo) = New MIL_DIG_HOOK_FUNCTION_PTR(AddressOf GrabProcessingFunction)
        ''MdigProcess(MilDigitizer(iCamNo), dispImage(iCamNo), _CAMERA.GRAB_BUFFER_SIZE, M_START, M_DEFAULT, ProcessingFunctionPtr(iCamNo), hUserData(iCamNo)))

        'MdigProcess(MilDigitizer(iCamNo), dispImage(iCamNo), _CAMERA.GRAB_BUFFER_SIZE, M_START, M_DEFAULT, ProcessingFunctionPtr(iCamNo), GCHandle.ToIntPtr(hUserData(iCamNo)))
        'bInProgress(iCamNo) = True
        'ProcessingFunctionPtr(iCamNo) = New MIL_DIG_HOOK_FUNCTION_PTR(AddressOf GrabProcessingFunction)
        Return True
    End Function

    Public Function CheckGrabRun(ByVal iCamNo As Integer) As Boolean
        If M_YES = MdigInquire(MilDigitizer(iCamNo), M_GRAB_IN_PROGRESS, M_NULL) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckValidCamNo(ByVal iCamNo As Integer) As Boolean
        If iCamNo < 0 OrElse _CAMERA.DIGITIZER_NUM <= iCamNo Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub SetExternalTriggerMode(ByVal iCamNo As Integer, ByVal bYes As Boolean)
        If Not CheckValidCamNo(iCamNo) Then
            Return
        End If
        If M_NULL = MilDigitizer(iCamNo) Then
            Return
        End If

        'SYSRCP(pSysRcp);

        GrabStart(iCamNo, False)

        Dim lTriggerPortNo As Long = 0

        'Select Case iCamNo
        '    Case _CAMERA.EDGE_CAMERA_1
        '        lTriggerPortNo = M_HARDWARE_PORT8
        '        Exit Select
        '    Case _CAMERA.EDGE_CAMERA_2
        '        lTriggerPortNo = M_HARDWARE_PORT2
        '        Exit Select
        '    Case Else
        '        Exit Select
        'End Select

        MdigControl(MilDigitizer(iCamNo), M_GRAB_ABORT, M_DEFAULT)

        ResetImageSet(iCamNo)

        If bYes Then
            MdigControl(MilDigitizer(iCamNo), M_GRAB_TRIGGER, M_ENABLE)
            'rising time으로 하면 처음에 두번 들어오는 경우가 있음.???
            'MdigControl(MilDigitizer(iCamNo), M_GRAB_TRIGGER_MODE, M_EDGE_FALLING)
            'MdigControl(MilDigitizer(iCamNo), M_GRAB_TRIGGER_ACTIVATION, M_EDGE_FALLING)    'MIL 10.0
            'MdigControl(MilDigitizer[iCamNo],M_GRAB_TRIGGER_MODE,M_EDGE_RISING);           'MIL 9.0
            MdigControl(MilDigitizer(iCamNo), M_GRAB_TRIGGER_MODE, M_EDGE_RISING)           'MIL 9.0
            MdigControl(MilDigitizer(iCamNo), M_GRAB_EXPOSURE + M_TIMER1, M_ENABLE)

            'MdigControl(MilDigitizer[iCamNo], M_GRAB_EXPOSURE_SOURCE + M_TIMER1,lTriggerPortNo);
            MdigControl(MilDigitizer(iCamNo), M_GRAB_EXPOSURE_TIME + M_TIMER1, 10000)
            ' 단위는 ns (최소 50ns이상)
            MdigControl(MilDigitizer(iCamNo), M_GRAB_EXPOSURE_TIME_DELAY + M_TIMER1, 100)
            ' 단위는 ns (최소 50ns이상)
            MdigControl(MilDigitizer(iCamNo), M_GRAB_TIMEOUT, M_INFINITE)


            SetGrabMode(iCamNo, _CAMERA.EXTERNAL_TRIG_GRAB_MODE)
        Else
            MdigControl(MilDigitizer(iCamNo), M_GRAB_TRIGGER, M_DISABLE)
            MdigControl(MilDigitizer(iCamNo), M_GRAB_EXPOSURE_SOURCE + M_TIMER1, M_CONTINUOUS)
            MdigControl(MilDigitizer(iCamNo), M_GRAB_EXPOSURE_TIME + M_TIMER1, 10000)
            ' 단위는 ns (최소 50ns이상)
            MdigControl(MilDigitizer(iCamNo), M_GRAB_EXPOSURE_TIME_DELAY + M_TIMER1, 100)
            ' 단위는 ns (최소 50ns이상)
            'MdigControl(MilDigitizer[iCamNo], M_GRAB_TIMEOUT, M_DEFAULT);
            MdigControl(MilDigitizer(iCamNo), M_GRAB_TIMEOUT, M_INFINITE)

            SetGrabMode(iCamNo, _CAMERA.CONTINUOUS_GRAB_MODE)

        End If

    End Sub


    Private Function GrabProcessingFunction(ByVal HookType As MIL_INT, ByVal HookId As MIL_ID, ByVal HookDataPtr As IntPtr) As MIL_INT
        Try
            If Not IntPtr.Zero.Equals(HookDataPtr) Then
                Dim ModifiedBufferId As MIL_ID = MIL.M_NULL
                'Dim hUserData As GCHandle = GCHandle.FromIntPtr(HookDataPtr)
                'Dim UserData As _HOOKDATA = TryCast(hUserData.Target, _HOOKDATA)

                'Dim hUserData As GCHandle = GCHandle.FromIntPtr(HookDataPtr)
                'Dim UserData As _HOOKDATA = DirectCast(hUserData, _HOOKDATA)


                MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ModifiedBufferId) '캡처된 버퍼 아이디를 검색


                MbufCopy(ModifiedBufferId, m_HookData(0).IDispImage)
                'If UserData.bColor Then
                '    If _CAMERA.EXTERNAL_TRIG_GRAB_MODE = GetGrabMode(UserData.iCamNo) Then
                '        'Display용()
                '        m_imagePro.BayerConvert(ModifiedBufferId, UserData.IDispImage,UserData.lWhiteBalance,UserData.lBayerPattern);	
                '        m_imagePro.CopyImage(ModifiedBufferId, UserData.IDispImage)

                '        'Edge(Detection용)
                '        Dim iEmptyIndex As Integer = FindEmptyImageSetIndex(UserData.iCamNo, False)

                '        m_imagePro.CopyImage(UserData.IDispImage, m_ExtGrabImageSet(UserData.iCamNo)(iEmptyIndex).GrabImage)
                '        m_ExtGrabImageSet(UserData.iCamNo)(iEmptyIndex).iNum = CInt(UserData.lCnt)
                '        'image Set Num에 넣어줄것
                '        m_ExtGrabImageSet(UserData.iCamNo)(iEmptyIndex).bUse = True
                '        UserData.lCnt += 1
                '    Else
                '        m_imagePro.CopyImage(ModifiedBufferId, UserData.IDispImage)
                '    End If
                'Else
                '    If _CAMERA.EXTERNAL_TRIG_GRAB_MODE = GetGrabMode(UserData.iCamNo) Then
                '        'Display용()
                '        m_imagePro.CopyImage(ModifiedBufferId, UserData.IDispImage)

                '        Dim iEmptyIndex As Integer = FindEmptyImageSetIndex(UserData.iCamNo, False)
                '        m_imagePro.CopyImage(ModifiedBufferId, m_ExtGrabImageSet(UserData.iCamNo)(iEmptyIndex).GrabImage)
                '        m_ExtGrabImageSet(UserData.iCamNo)(iEmptyIndex).iNum = CInt(UserData.lCnt)
                '        'image Set Num에 넣어줄것
                '        m_ExtGrabImageSet(UserData.iCamNo)(iEmptyIndex).bUse = True
                '        UserData.lCnt += 1
                '    Else
                '        Display용()
                '        m_imagePro.CopyImage(ModifiedBufferId, UserData.IDispImage)
                '    End If
                'End If
            End If

        Catch generatedExceptionName As Exception
        End Try

        Return 0
    End Function

    Public Sub ResetImageSet(ByVal iCamNo As Integer)
        If Not CheckValidCamNo(iCamNo) Then
            Return
        End If

        'For i As Integer = 0 To _CAMERA.EXT_GRAB_BUF_SIZE - 1
        '    m_ExtGrabImageSet(iCamNo)(i).bUse = False
        '    m_ExtGrabImageSet(iCamNo)(i).iNum = -1

        '    If M_NULL <> m_ExtGrabImageSet(iCamNo)(i).GrabImage Then
        '        m_imagePro.ClearImage(m_ExtGrabImageSet(iCamNo)(i).GrabImage)
        '    End If
        'Next

    End Sub



    Public Function GetSizeOfExtGrabImage(ByVal iCamNo As Integer) As Integer
        Dim i As Integer = 0
        Dim iSumCam As Integer = 0

        If Not CheckValidCamNo(iCamNo) Then
            Return 0
        End If

        'For i = 0 To _CAMERA.EXT_GRAB_BUF_SIZE - 1
        '    If m_ExtGrabImageSet(iCamNo)(i).bUse = True Then
        '        iSumCam += 1
        '    End If
        'Next
        Return iSumCam

    End Function


    Shared FindUnprocessed_iIndex As Integer() = New Integer(_CAMERA.DIGITIZER_NUM - 1) {}
    Shared FindEmpty_iIndex As Integer() = New Integer(_CAMERA.DIGITIZER_NUM - 1) {}

    Public Function FindUnprocessedImageSetIndex(ByVal iCamNo As Integer, ByVal bReset As Boolean) As Integer
        '=false
        Dim i As Integer = 0


        If Not CheckValidCamNo(iCamNo) Then
            Return 0
        End If

        If bReset = True Then
            FindUnprocessed_iIndex(iCamNo) = 0
            Return 0
        End If

        For i = FindUnprocessed_iIndex(iCamNo) To _CAMERA.EXT_GRAB_BUF_SIZE - 1
            '먼저 이전index 이후부터 검색 (FIFO를 위해)
            'If m_ExtGrabImageSet(iCamNo)(i).bUse = True Then
            '    FindUnprocessed_iIndex(iCamNo) = i
            '    Return FindUnprocessed_iIndex(iCamNo)
            'End If
        Next

        For i = 0 To FindUnprocessed_iIndex(iCamNo) - 1
            '없으면 처음부터 검색
            'If m_ExtGrabImageSet(iCamNo)(i).bUse = True Then
            '    FindUnprocessed_iIndex(iCamNo) = i
            '    Return FindUnprocessed_iIndex(iCamNo)
            'End If
        Next

        Return 0
    End Function

    Public Function FindEmptyImageSetIndex(ByVal iCamNo As Integer, ByVal bReset As Boolean) As Integer
        '=false
        Dim i As Integer = 0
        'static int iIndex[DIGITIZER_NUM]={0,0};

        If Not CheckValidCamNo(iCamNo) Then
            Return 0
        End If

        If bReset = True Then
            FindEmpty_iIndex(iCamNo) = 0
            Return 0
        End If

        'For i = FindEmpty_iIndex(iCamNo) To _CAMERA.EXT_GRAB_BUF_SIZE - 1
        '    '20개
        '    If m_ExtGrabImageSet(iCamNo)(i).bUse = False Then
        '        FindEmpty_iIndex(iCamNo) = i
        '        Return FindEmpty_iIndex(iCamNo)
        '    End If
        'Next
        'For i = 0 To FindEmpty_iIndex(iCamNo) - 1
        '    If m_ExtGrabImageSet(iCamNo)(i).bUse = False Then
        '        FindEmpty_iIndex(iCamNo) = i
        '        Return FindEmpty_iIndex(iCamNo)
        '    End If
        'Next

        Return 0

    End Function
    Public Sub CheckIP()
        Dim IP As String
        Dim Header As System.Net.IPHostEntry = Nothing
        Header = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        For index = 0 To 3
            CheckCam(index) = False
        Next

        For index = 0 To Header.AddressList.Length - 1
            IP = Header.AddressList.GetValue(index).ToString
            Thread.Sleep(50)
            If IP = "170.254.100.111" Then
                CheckCam(0) = True
                'pCamera(0).m_bConnected = True
            End If
            If IP = "168.254.100.122" Then
                CheckCam(1) = True
                'pCamera(1).m_bConnected = True
            End If
            If IP = "167.254.100.133" Then
                CheckCam(2) = True
                'pCamera(2).m_bConnected = True
            End If
            If IP = "166.254.100.144" Then
                CheckCam(3) = True
                'pCamera(3).m_bConnected = True
            End If
        Next
    End Sub

End Class
