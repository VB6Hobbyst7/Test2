Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Matrox.MatroxImagingLibrary
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Brush
Imports System
Imports System.Attribute
Imports System.Runtime.InteropServices

Class AlignMarkWnd
    Inherits Form

    <DllImport("user32")> _
    Public Shared Function GetCursorPos(ByRef pt As HPOINT) As Int32
    End Function

    <DllImport("user32")> _
    Public Shared Function SetCursorPos(x As Int32, y As Int32) As Int32
    End Function

    <DllImport("user32")> _
    Public Shared Function DestroyIcon(ByVal handle As IntPtr) As Boolean
    End Function

    Public Structure HPOINT
        Public x As Int32
        Public y As Int32
    End Structure

    Dim HPos As HPOINT

    Protected m_pParentWnd As IntPtr
    Public m_MilSystem As MIL_ID
    Public m_MilDisplay As MIL_ID
    Public m_DispImage As MIL_ID

    Public m_MarkImage As MIL_ID

    Protected MilOverlayImage As MIL_ID
    Protected MilMaskImage As MIL_ID
    Protected MilModelFinder As MIL_ID

    Protected m_dZoomFactor_X As Double
    Protected m_dZoomFactor_Y As Double
    Protected m_dZoomOffsetX As Double
    Protected m_dZoomOffsetY As Double
    Protected TransparentColor As Long

    Protected m_bOverlayInitialized As Boolean

    Private m_Rect As Rectangle

    Protected m_lImageX As Int32
    Protected m_lImageY As Int32

    Private imagepro As New MilImageProcessor()

    Public Sub New()
        Me.TopLevel = False
    End Sub

    Public Sub New(ByVal rect As Rectangle, ByVal pParentWnd As IntPtr, ByVal MilSystem As MIL_ID, ByVal dispImage As MIL_ID)
        InitComponent()

        m_pParentWnd = pParentWnd
        m_MilSystem = MilSystem
        m_DispImage = dispImage
        m_MilDisplay = MIL.M_NULL
        m_Rect = rect
        m_dZoomFactor_X = 1.0
        m_dZoomFactor_Y = 1.0
        Me.TopLevel = False

        Me.Top = 0
        Me.Left = 0
        Me.Width = m_Rect.Width
        Me.Height = m_Rect.Height

        imagepro.GetImageSize(dispImage, m_lImageX, m_lImageY)

        ClientSize = New Size(rect.Width, rect.Height)

    End Sub

    Private Function AllocMilDisplay() As Boolean
        MIL.MdispAlloc(m_MilSystem, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, m_MilDisplay)

        If MIL.M_NULL = m_MilDisplay Then
            MessageBox.Show("CMilImageWnd Display Allocation Failed.")
            Return False
        End If

        Return True
    End Function

    Private Sub InitComponent()
        Me.SuspendLayout()
        ' 
        ' AlignMarkWnd
        ' 
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AlignMarkWnd"
        AddHandler Me.Load, New System.EventHandler(AddressOf Me.AlignMarkWnd_Load)
        AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.AlignMarkWnd_FormClosed)
        Me.ResumeLayout(False)
    End Sub

    Private Function SelectDisplayWindow() As Boolean
        'If MIL.M_WINDOWED <> MIL.MdispInquire(m_MilDisplay, MIL.M_DISPLAY_MODE, MIL.M_NULL) Then
        '    MessageBox.Show("This example does not run in dual screen mode.")
        '    MIL.MdispFree(m_MilDisplay)
        '    m_MilDisplay = MIL.M_NULL
        '    Return False
        'End If

        MIL.MdispControl(m_MilDisplay, MIL.M_WINDOW_SCROLLBAR, MIL.M_DISABLE)
        MIL.MdispZoom(m_MilDisplay, m_dZoomFactor_X, m_dZoomFactor_Y)
        m_dZoomOffsetX = (CDbl(m_lImageX) - CDbl(m_Rect.Width) / m_dZoomFactor_X) / 2.0
        m_dZoomOffsetY = (CDbl(m_lImageY) - CDbl(m_Rect.Height) / m_dZoomFactor_Y) / 2.0
        MIL.MdispPan(m_MilDisplay, m_dZoomOffsetX, m_dZoomOffsetY)
        MIL.MdispSelectWindow(m_MilDisplay, m_DispImage, Me.Handle)

        Return True
    End Function

    Public Overridable Function Init() As Boolean
        SetOverlayEnable(True)
        Return True
    End Function

    Public Sub RealaesDisplay()
        MIL.MdispFree(m_MilDisplay)
    End Sub

    Public Function ChangeDisplayImage(ByVal image As MIL_ID) As MIL_ID
        ClearOverlayBuffer()
        SetOverlayEnable(False)

        If MIL.M_NULL = m_MilDisplay OrElse MIL.M_NULL = image Then
            Return MIL.M_NULL
        End If

        '            MIL_INT imageOld = MIL.MdispInquire(MilDisplay, MIL.M_SELECTED, MIL.M_NULL);

        '	        if(image != imageOld)
        If True Then
            MIL.MdispSelect(m_MilDisplay, MIL.M_NULL)
            MIL.MdispSelect(m_MilDisplay, image)
            m_DispImage = image
            MIL.MdispSelectWindow(m_MilDisplay, image, Me.Handle)
            imagepro.GetImageSize(image, m_lImageX, m_lImageY)
        End If

        SetOverlayEnable(True)

        Return image
    End Function

    Public Sub SetZoomFactor(ByVal dFactor_X As Double, ByVal dFactor_Y As Double)
        m_dZoomFactor_X = dFactor_X
        m_dZoomFactor_Y = dFactor_Y

        If MIL.M_NULL <> m_MilDisplay Then
            MIL.MdispZoom(m_MilDisplay, m_dZoomFactor_X, m_dZoomFactor_Y)

            m_dZoomOffsetX = (CDbl(m_lImageX) - CDbl(m_Rect.Width) / m_dZoomFactor_X) / 2.0
            m_dZoomOffsetY = (CDbl(m_lImageY) - CDbl(m_Rect.Height) / m_dZoomFactor_Y) / 2.0
            MIL.MdispPan(m_MilDisplay, m_dZoomOffsetX, m_dZoomOffsetY)
        End If
    End Sub

    Public Sub SetOverlayEnable(ByVal bEnable As Boolean)
        If MIL.M_NULL = m_MilDisplay OrElse MIL.M_NULL = m_DispImage OrElse m_bOverlayInitialized Then
            Return
        End If

        '20210223 - GYN : 여기 인터락 우선 해제.
        'If MIL.M_WINDOWED <> MIL.MdispInquire(m_MilDisplay, MIL.M_DISPLAY_MODE, MIL.M_NULL) Then
        '    Return
        'End If

        If bEnable Then
            MIL.MdispControl(m_MilDisplay, MIL.M_WINDOW_OVR_WRITE, MIL.M_ENABLE)
            MIL.MdispInquire(m_MilDisplay, MIL.M_WINDOW_OVR_BUF_ID, MilOverlayImage)
            MIL.MdispInquire(m_MilDisplay, MIL.M_TRANSPARENT_COLOR, TransparentColor)
            MIL.MdispControl(m_MilDisplay, MIL.M_WINDOW_OVR_SHOW, MIL.M_ENABLE)

            m_bOverlayInitialized = True
        Else
            ClearOverlayBuffer()
            MIL.MdispControl(m_MilDisplay, MIL.M_WINDOW_OVR_SHOW, MIL.M_DISABLE)
            MIL.MdispControl(m_MilDisplay, MIL.M_WINDOW_OVR_WRITE, MIL.M_DISABLE)

            m_bOverlayInitialized = False
        End If
    End Sub

    Public Sub ClearOverlayBuffer()
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufClear(MilOverlayImage, TransparentColor)
    End Sub

    Private Sub AlignMarkWnd_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        MIL.MdispFree(m_MilDisplay)
        m_MilDisplay = MIL.M_NULL
    End Sub

    Private Sub AlignMarkWnd_Load(ByVal sender As Object, ByVal e As EventArgs)
        AllocMilDisplay()
        SelectDisplayWindow()
        Init()

        Me.KeyPreview = True
    End Sub

    Private m_szImage As Size
    Private m_ptRef As Point
    Private m_ptDefaultRefPos As Point

    Public Sub AllocMarkImage(ByVal MilSystem As MIL_ID, ByVal milMarkImage As MIL_ID, ByVal ptRefPos As Point, ByVal ptMarkStart As Point)

        If (m_MilDisplay <> MIL.M_NULL) Then
            MIL.MbufFree(m_MilDisplay)
        End If

        If (m_MarkImage <> MIL.M_NULL) Then
            MIL.MbufFree(m_MarkImage)
        End If

        If (MilMaskImage <> MIL.M_NULL) Then
            MIL.MbufFree(MilMaskImage)
        End If

        If (MilModelFinder <> MIL.M_NULL) Then
            MIL.MbufFree(MilModelFinder)
        End If

        Dim SizeX As Integer = 0
        Dim SizeY As Integer = 0

        MIL.MbufInquire(milMarkImage, MIL.M_SIZE_X, SizeX)
        MIL.MbufInquire(milMarkImage, MIL.M_SIZE_Y, SizeY)

        m_ptRef.X = ptRefPos.X
        m_ptRef.Y = ptRefPos.Y

        MIL.MbufAlloc2d(m_MilSystem, SizeX, SizeY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC, m_MarkImage)
        MIL.MbufClear(m_MarkImage, 0)

        MIL.MbufAlloc2d(m_MilSystem, SizeX, SizeY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC, MilMaskImage)
        MIL.MbufClear(MilMaskImage, 0)

        ChangeDisplayImage(m_MarkImage)

        MIL.MdispInquire(m_MilDisplay, MIL.M_OVERLAY_ID, MilOverlayImage)
        MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY, MIL.M_ENABLE)
        MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)

        MIL.MbufCopy(milMarkImage, m_MarkImage)

        MIL.MmodAlloc(m_MilSystem, MIL.M_GEOMETRIC, MIL.M_DEFAULT, MilModelFinder)
        MIL.MmodDefine(MilModelFinder, MIL.M_IMAGE, m_MarkImage, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT)

        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_NUMBER, 1)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SPEED, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SMOOTHNESS, 100)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_DETAIL_LEVEL, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_SCALE_MIN_FACTOR, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_SCALE_MAX_FACTOR, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_TIMEOUT, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SMOOTHNESS, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_X, ptRefPos.X)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_Y, ptRefPos.Y)

        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SCORE, 90)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SCORE_TARGET, 80)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_CONTEXT_CONVERT, 95)

        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_SEARCH_ANGLE_RANGE, MIL.M_DISABLE)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SEARCH_ANGLE_RANGE, MIL.M_DISABLE)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_SEARCH_SCALE_RANGE, MIL.M_DISABLE)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SEARCH_SCALE_RANGE, MIL.M_DISABLE)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_POLARITY, MIL.M_SAME)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_ACCURACY, MIL.M_DEFAULT)   '90
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_ACCEPTANCE, 90)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_CERTAINTY, 95)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_ACCEPTANCE_TARGET, 60)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_CERTAINTY_TARGET, 90)

        'GYN - 2017.04.13
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SEARCH_ANGLE_DELTA_POS, 0)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SEARCH_ANGLE_DELTA_NEG, 0)

        m_ptDefaultRefPos = ptRefPos

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_BLUE)
        MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, ptRefPos.X - 50, ptRefPos.Y, ptRefPos.X + 50, ptRefPos.Y)
        MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, ptRefPos.X, ptRefPos.Y - 50, ptRefPos.X, ptRefPos.Y + 50)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
        MIL.MgraFontScale(MIL.M_DEFAULT, 1, 1)

    End Sub


    Public Sub LoadMarkImage(ByVal milMarkImage As MIL_ID, ByVal ptRefPos As Point, ByVal szImage As Size)

        If (m_MilDisplay <> MIL.M_NULL) Then
            MIL.MbufFree(m_MilDisplay)
        End If

        If (m_DispImage <> MIL.M_NULL) Then
            MIL.MbufFree(m_DispImage)
        End If

        If (MilMaskImage <> MIL.M_NULL) Then
            MIL.MbufFree(MilMaskImage)
        End If

        If (MilModelFinder <> MIL.M_NULL) Then
            MIL.MbufFree(MilModelFinder)
        End If

        m_ptRef.X = ptRefPos.X
        m_ptRef.Y = ptRefPos.Y

        MIL.MbufAlloc2d(m_MilSystem, szImage.Width, szImage.Height, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC, m_DispImage)
        MIL.MbufClear(m_DispImage, 0)

        MIL.MbufAlloc2d(m_MilSystem, szImage.Width, szImage.Height, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC, MilMaskImage)
        MIL.MbufClear(MilMaskImage, 0)

        'MdispAlloc(m_MilSystem, 0, M_DEF_DISPLAY_FORMAT, M_WINDOWED, &MilDisplay);
        'MdispSelectWindow(MilDisplay, MilImage, m_hWnd);
        ChangeDisplayImage(m_DispImage)

        MIL.MdispInquire(m_MilDisplay, MIL.M_OVERLAY_ID, MilOverlayImage)
        MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY, MIL.M_ENABLE)
        MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)

        MIL.MbufCopy(milMarkImage, m_DispImage)

        MIL.MmodAlloc(m_MilSystem, MIL.M_GEOMETRIC, MIL.M_DEFAULT, MilModelFinder)
        MIL.MmodDefine(MilModelFinder, MIL.M_IMAGE, m_DispImage, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_NUMBER, 1)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SPEED, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_DETAIL_LEVEL, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_SCALE_MIN_FACTOR, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_SCALE_MAX_FACTOR, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_TIMEOUT, MIL.M_DEFAULT)
        'MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SMOOTHNESS, MIL.M_DEFAULT)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SMOOTHNESS, 100)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SCORE, 90)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_SCORE_TARGET, 80)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_ACCURACY, 90)
        MIL.MmodControl(MilModelFinder, MIL.M_CONTEXT, MIL.M_CONTEXT_CONVERT, 95)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_X, ptRefPos.X)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_Y, ptRefPos.Y)

        MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_IMAGE, MIL.M_DEFAULT, MIL.M_DEFAULT)
        'm_ptDefaultRefPos = ptRefPos

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
        MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_DONT_CARES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_BLUE)
        MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, ptRefPos.X - 50, ptRefPos.Y, ptRefPos.X + 50, ptRefPos.Y)
        MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, ptRefPos.X, ptRefPos.Y - 50, ptRefPos.X, ptRefPos.Y + 50)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
        MIL.MgraFontScale(MIL.M_DEFAULT, 1, 1)

        MIL.MgraText(MIL.M_DEFAULT, MilOverlayImage, 10, 10, "- X:" & ptRefPos.X & ", Y:" & ptRefPos.Y)
        MIL.MgraText(MIL.M_DEFAULT, MilOverlayImage, 10, 30, "- Width:" & m_szImage.Width & ", Height:" & m_szImage.Height)

    End Sub

    Public Sub SetRefPos(ByVal ptPos As Point)

        MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)

        m_ptRef = ptPos

        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_X, m_ptRef.X)
        MIL.MmodControl(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_Y, m_ptRef.Y)

        MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_IMAGE, MIL.M_DEFAULT, MIL.M_DEFAULT)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
        MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_DONT_CARES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_BLUE)
        MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, m_ptRef.X - 150, m_ptRef.Y, m_ptRef.X + 150, m_ptRef.Y)
        MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, m_ptRef.X, m_ptRef.Y - 150, m_ptRef.X, m_ptRef.Y + 150)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
        MIL.MgraFontScale(MIL.M_DEFAULT, 0.5, 0.5)
        MIL.MgraText(MIL.M_DEFAULT, MilOverlayImage, 10, 10, "- X:" & m_ptRef.X & ", Y:" & m_ptRef.Y)
        'MIL.MgraText(MIL.M_DEFAULT, MilOverlayImage, 10, 30, "- Width:" & m_szImage.Width & ", Height:" & m_szImage.Height)

    End Sub

    Public Sub ShowMarkImage(ByVal csMark As String, ByVal milMarkImage As MIL_ID)

        If (m_MilDisplay <> MIL.M_NULL) Then
            MIL.MbufFree(m_MilDisplay)
        End If

        If (m_MarkImage <> MIL.M_NULL) Then
            MIL.MbufFree(m_MarkImage)
        End If

        If (MilMaskImage <> MIL.M_NULL) Then
            MIL.MbufFree(MilMaskImage)
        End If

        If (MilModelFinder <> MIL.M_NULL) Then
            MIL.MbufFree(MilModelFinder)
        End If


        'MIL.MbufDiskInquire(csMark & ".BMP", MIL.M_SIZE_X, m_szImage.Width)
        'MIL.MbufDiskInquire(csMark & ".BMP", MIL.M_SIZE_Y, m_szImage.Height)

        Dim SizeX As Integer = 0
        Dim SizeY As Integer = 0
        MIL.MbufInquire(milMarkImage, MIL.M_SIZE_X, SizeX)
        MIL.MbufInquire(milMarkImage, MIL.M_SIZE_Y, SizeY)

        MIL.MbufAlloc2d(m_MilSystem, SizeX, SizeY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_DISP + MIL.M_PROC, m_MarkImage)
        MIL.MbufClear(m_MarkImage, 0)

        MIL.MbufAlloc2d(m_MilSystem, SizeX, SizeY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC, MilMaskImage)
        MIL.MbufClear(MilMaskImage, 0)

        ChangeDisplayImage(m_MarkImage)

        MIL.MdispInquire(m_MilDisplay, MIL.M_OVERLAY_ID, MilOverlayImage)
        MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY, MIL.M_ENABLE)
        MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)

        MIL.MbufCopy(milMarkImage, m_MarkImage)

        'MIL.MbufLoad(csMark & ".bmp", m_MarkImage)
        'ChangeDisplayImage(m_MarkImage)

        'MIL.MdispInquire(m_MilDisplay, MIL.M_OVERLAY_ID, MilOverlayImage)
        'MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY, MIL.M_ENABLE)
        'MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)

        MIL.MmodRestore(csMark & ".mmf", m_MilSystem, MIL.M_DEFAULT, MilModelFinder)

        'MIL.MmodInquire(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_X, m_ptRef.X)
        'MIL.MmodInquire(MilModelFinder, MIL.M_DEFAULT, MIL.M_REFERENCE_Y, m_ptRef.Y)

        'MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
        'MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_DONT_CARES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        'MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
        'MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        'MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_BLUE)
        'MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, m_ptRef.X - 150, m_ptRef.Y, m_ptRef.X + 150, m_ptRef.Y)
        'MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, m_ptRef.X, m_ptRef.Y - 150, m_ptRef.X, m_ptRef.Y + 150)

    End Sub


    Public Sub SaveMarkFile(ByVal csPath As String)

        Dim csMMF As String = ""
        Dim csBMP As String = ""

        csMMF = csPath + ".mmf"
        MIL.MmodSave(csMMF, MilModelFinder, MIL.M_DEFAULT)

        csBMP = csPath + ".bmp"
        MIL.MbufExport(csBMP, MIL.M_BMP, m_MarkImage)

    End Sub


    Private bMaskJob As Boolean
    Private bRemoveJob As Boolean

    Private Sub AlignMarkWnd_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        Dim pPoint As Point

        pPoint.X = e.X / m_dZoomFactor_X
        pPoint.Y = e.Y / m_dZoomFactor_Y

        If frmAlignMarkSetting.bRefPoint = True Then

            SetRefPos(pPoint)
            frmAlignMarkSetting.CheckCenter = True

        ElseIf frmAlignMarkSetting.bMask = True Then

            If e.Button = Windows.Forms.MouseButtons.Right Then

                bMaskJob = False
                bRemoveJob = True

            ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

                bMaskJob = True
                bRemoveJob = False

            End If


        End If

    End Sub
    Public Sub FillRectangle(
                            Brush As Brush,
                            rect As Rectangle
                            )
    End Sub


    Private Sub AlignMarkWnd_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        Me.Focus()

        DrawMarkMask(e.X, e.Y)

    End Sub

    Private Sub AlignMarkWnd_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        DrawMarkMask(e.X, e.Y)

        bMaskJob = False
        bRemoveJob = False

    End Sub


    ' 20180308 ksy 마크 중점 자동 찾기
    Public Sub AutoDetectMarkCenter()
        Dim clsDetect As clsVisionFindMarkCenter
        Dim ptFind As Point
        clsDetect = New clsVisionFindMarkCenter(m_MilSystem, m_DispImage)


        If clsDetect.FindMarkCenterWithMIL(MilOverlayImage, ptFind.X, ptFind.Y) = 1 Then
            'SetRefPos(ptFind)
            MIL.MdispControl(m_MilDisplay, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)

            m_ptRef = ptFind



            MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_BLUE)
            MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, m_ptRef.X - 150, m_ptRef.Y, m_ptRef.X + 150, m_ptRef.Y)
            MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, m_ptRef.X, m_ptRef.Y - 150, m_ptRef.X, m_ptRef.Y + 150)

            MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
            MIL.MgraFontScale(MIL.M_DEFAULT, 0.5, 0.5)
            MIL.MgraText(MIL.M_DEFAULT, MilOverlayImage, 10, 10, "- X:" & m_ptRef.X & ", Y:" & m_ptRef.Y)
            'MIL.MgraText(MIL.M_DEFAULT, MilOverlayImage, 10, 30, "- Width:" & m_szImage.Width & ", Height:" & m_szImage.Height)



            For i = 0 To 3
                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
                MIL.MgraLine(MIL.M_DEFAULT, MilOverlayImage, clsDetect.m_lpResultLine(i).x1, clsDetect.m_lpResultLine(i).y1, clsDetect.m_lpResultLine(i).x2, clsDetect.m_lpResultLine(i).y2)
            Next

            For i = 0 To 3
                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
                MIL.MgraDot(MIL.M_DEFAULT, MilOverlayImage, clsDetect.m_lpdResultCross(i).x1, clsDetect.m_lpdResultCross(i).y1)
            Next
        Else
            MsgBox("Auto detect failed!")
        End If




    End Sub



    ' 20180308 ksy 임시 테스트용
    Public Sub ImportExternalImage(ByVal file As String)

        'If (m_DispImage <> MIL.M_NULL) Then
        '    MIL.MbufFree(m_DispImage)
        'End If
        Dim x As MIL_INT, y As MIL_INT

        MIL.MbufImport(file, MIL.M_BMP, MIL.M_RESTORE, m_MilSystem, m_DispImage)
        MIL.MbufInquire(m_DispImage, MIL.M_SIZE_X, x)
        MIL.MbufInquire(m_DispImage, MIL.M_SIZE_Y, y)

        MIL.MdispSelectWindow(m_MilDisplay, m_DispImage, Me.Handle)
        imagepro.GetImageSize(m_DispImage, x, y)

        MIL.MdispInquire(m_MilDisplay, MIL.M_OVERLAY_ID, MilOverlayImage)

    End Sub

    Dim grpMouse As Graphics

    Private Sub DrawMarkMask(ByVal ptMouseX As Integer, ByVal ptMouseY As Integer)
        On Error GoTo SysErr

        Dim ptStartPos As Point
        Dim ptEndPos As Point
        Dim nDonCareSize As Integer = 5

        Dim XSize As Integer
        Dim YSize As Integer

        nDonCareSize = CInt(frmAlignMarkSetting.cbMaskSize.Text)

        ptStartPos.X = (ptMouseX / m_dZoomFactor_X) - nDonCareSize
        ptStartPos.Y = (ptMouseY / m_dZoomFactor_Y) - nDonCareSize
        ptEndPos.X = (ptStartPos.X) + (nDonCareSize * 2)
        ptEndPos.Y = (ptStartPos.Y) + (nDonCareSize * 2)

        XSize = Math.Round(CDbl(m_dZoomFactor_X * (nDonCareSize * 2))) + 2
        YSize = Math.Round(CDbl(m_dZoomFactor_Y * (nDonCareSize * 2))) + 2

        If frmAlignMarkSetting.bMask = True Then
            Dim bmpCur As New Bitmap(XSize, YSize)

            grpMouse = Graphics.FromImage(bmpCur)
            grpMouse.FillRectangle(Brushes.LimeGreen, 0, 0, XSize, YSize)

            Dim bmpPtr As IntPtr = bmpCur.GetHicon
            Dim icoHandle As Icon = System.Drawing.Icon.FromHandle(bmpPtr)

            Me.Cursor = New Cursor(icoHandle.Handle)

            If frmAlignMarkSetting.bMask = True And bMaskJob = True Then

                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_WHITE)
                MIL.MgraRectFill(MIL.M_DEFAULT, MilMaskImage, ptStartPos.X, ptStartPos.Y, ptEndPos.X, ptEndPos.Y)

                MIL.MmodMask(MilModelFinder, MIL.M_DEFAULT, MilMaskImage, MIL.M_DONT_CARES, MIL.M_DEFAULT)

                MIL.MgraRectFill(MIL.M_DEFAULT, MilOverlayImage, ptStartPos.X, ptStartPos.Y, ptEndPos.X, ptEndPos.Y)

                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
                MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_DONT_CARES, MIL.M_DEFAULT, MIL.M_DEFAULT)

                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
                MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

            ElseIf frmAlignMarkSetting.bMask = True And bRemoveJob = True Then

                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_BLACK)
                MIL.MgraRectFill(MIL.M_DEFAULT, MilMaskImage, ptStartPos.X, ptStartPos.Y, ptEndPos.X, ptEndPos.Y)

                MIL.MmodMask(MilModelFinder, MIL.M_DEFAULT, MilMaskImage, MIL.M_DONT_CARES, MIL.M_DEFAULT)

                MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_IMAGE, MIL.M_DEFAULT, MIL.M_DEFAULT)

                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)
                MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_DONT_CARES, MIL.M_DEFAULT, MIL.M_DEFAULT)

                MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_RED)
                MIL.MmodDraw(MIL.M_DEFAULT, MilModelFinder, MilOverlayImage, MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

            End If

            DestroyIcon(bmpPtr)
            icoHandle.Dispose()
            bmpCur.Dispose()
            grpMouse.Dispose()
        Else
            Me.Cursor = Cursors.Default
        End If

        Return
SysErr:
        modPub.ErrorLog(Err.Description & " - Mark mask edit error")
    End Sub

    Private Sub AlignMarkWnd_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim nMouseSpeed As Integer = 1
        nMouseSpeed = CInt(frmAlignMarkSetting.MaskingSpeed.Text)

        If frmAlignMarkSetting.Masking.Checked = True Then
            If e.Control = True Then
                GetCursorPos(HPos)
                bRemoveJob = False
                Select Case e.KeyCode
                    Case Keys.Up
                        bMaskJob = True
                        SetCursorPos(HPos.x, HPos.y - nMouseSpeed)
                    Case Keys.Down
                        bMaskJob = True
                        SetCursorPos(HPos.x, HPos.y + nMouseSpeed)
                    Case Keys.Left
                        bMaskJob = True
                        SetCursorPos(HPos.x - nMouseSpeed, HPos.y)
                    Case Keys.Right
                        bMaskJob = True
                        SetCursorPos(HPos.x + nMouseSpeed, HPos.y)
                End Select

            End If
        End If
        If frmAlignMarkSetting.MaskingDel.Checked = True Then
            If e.Control = True Then
                GetCursorPos(HPos)
                bMaskJob = False
                Select Case e.KeyCode
                    Case Keys.Up
                        bRemoveJob = True
                        SetCursorPos(HPos.x, HPos.y - nMouseSpeed)
                    Case Keys.Down
                        bRemoveJob = True
                        SetCursorPos(HPos.x, HPos.y + nMouseSpeed)
                    Case Keys.Left
                        bRemoveJob = True
                        SetCursorPos(HPos.x - nMouseSpeed, HPos.y)
                    Case Keys.Right                       
                        bRemoveJob = True
                        SetCursorPos(HPos.x + nMouseSpeed, HPos.y)
                End Select
            End If
        End If
    End Sub

    Private Sub AlignMarkWnd_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If bMaskJob = True Then
            bMaskJob = False
        End If

        If bRemoveJob = True Then
            bRemoveJob = False
        End If
    End Sub
End Class
