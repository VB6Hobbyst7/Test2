Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports Matrox.MatroxImagingLibrary
Imports System.Drawing
Imports System.Windows.Forms


Class MilImageWnd
    Inherits Form
    Protected m_pParentWnd As IntPtr
    Public m_MilSystem As MIL_ID

    'Private m_DispImage As MIL_ID
    Public m_DispImage As MIL_ID

    Public MilDisplay As MIL_ID
    Protected m_dZoomFactor_X As Double
    Protected m_dZoomFactor_Y As Double
    Protected m_dZoomOffsetX As Double
    Protected m_dZoomOffsetY As Double

    Protected MilOverlayImage As MIL_ID
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
        MilDisplay = MIL.M_NULL
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
        MIL.MdispAlloc(m_MilSystem, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, MilDisplay)

        If MIL.M_NULL = MilDisplay Then
            MessageBox.Show("CMilImageWnd Display Allocation Failed.")
            Return False
        End If

        Return True
    End Function

    Private Sub InitComponent()
        Me.SuspendLayout()
        ' 
        ' MilImageWnd
        ' 
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MilImageWnd"
        AddHandler Me.Load, New System.EventHandler(AddressOf Me.MilImageWnd_Load)
        AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.MilImageWnd_FormClosed)
        Me.ResumeLayout(False)

    End Sub

    Private Function SelectDisplayWindow() As Boolean
        '20210223 - GYN : 여기 인터락 우선 해제.
        'If MIL.M_WINDOWED <> MIL.MdispInquire(MilDisplay, MIL.M_DISPLAY_MODE, MIL.M_NULL) Then
        '    MessageBox.Show("This example does not run in dual screen mode.")
        '    MIL.MdispFree(MilDisplay)
        '    MilDisplay = MIL.M_NULL
        '    Return False
        'End If

        MIL.MdispControl(MilDisplay, MIL.M_WINDOW_SCROLLBAR, MIL.M_DISABLE)
        MIL.MdispZoom(MilDisplay, m_dZoomFactor_X, m_dZoomFactor_Y)
        m_dZoomOffsetX = (CDbl(m_lImageX) - CDbl(m_Rect.Width) / m_dZoomFactor_X) / 2.0
        m_dZoomOffsetY = (CDbl(m_lImageY) - CDbl(m_Rect.Height) / m_dZoomFactor_Y) / 2.0
        MIL.MdispPan(MilDisplay, m_dZoomOffsetX, m_dZoomOffsetY)
        MIL.MdispSelectWindow(MilDisplay, m_DispImage, Me.Handle)
        'MdispSelectWindow :  MIL이 제공하는 tool에 디스플레이
        Return True
    End Function

    Public Overridable Function Init() As Boolean
        SetOverlayEnable(True)
        Return True
    End Function

    Public Sub RealaesDisplay()
        MIL.MdispFree(MilDisplay)
    End Sub

    Public Function ChangeDisplayImage(ByVal image As MIL_ID) As MIL_ID
        ClearOverlayBuffer()
        SetOverlayEnable(False)

        If MIL.M_NULL = MilDisplay OrElse MIL.M_NULL = image Then
            Return MIL.M_NULL
        End If

        '            MIL_INT imageOld = MIL.MdispInquire(MilDisplay, MIL.M_SELECTED, MIL.M_NULL);

        '	        if(image != imageOld)
        If True Then
            MIL.MdispSelect(MilDisplay, MIL.M_NULL)
            MIL.MdispSelect(MilDisplay, image)
            m_DispImage = image
            MIL.MdispSelectWindow(MilDisplay, image, Me.Handle)
            imagepro.GetImageSize(image, m_lImageX, m_lImageY)
        End If

        SetOverlayEnable(True)

        Return image
    End Function

    Public Sub SetZoomFactor(ByVal dFactor_X As Double, ByVal dFactor_Y As Double)
        m_dZoomFactor_X = dFactor_X
        m_dZoomFactor_Y = dFactor_Y

        If MIL.M_NULL <> MilDisplay Then
            MIL.MdispZoom(MilDisplay, m_dZoomFactor_X, m_dZoomFactor_Y)

            m_dZoomOffsetX = (CDbl(m_lImageX) - CDbl(m_Rect.Width) / m_dZoomFactor_X) / 2.0
            m_dZoomOffsetY = (CDbl(m_lImageY) - CDbl(m_Rect.Height) / m_dZoomFactor_Y) / 2.0
            MIL.MdispPan(MilDisplay, m_dZoomOffsetX, m_dZoomOffsetY)
        End If
    End Sub

    Public Sub SetOverlayEnable(ByVal bEnable As Boolean)
        If MIL.M_NULL = MilDisplay OrElse MIL.M_NULL = m_DispImage OrElse m_bOverlayInitialized Then
            Return
        End If

        Dim MilWindowed As MIL_ID
        MilWindowed = MIL.MdispInquire(MilDisplay, MIL.M_DISPLAY_MODE, MIL.M_NULL)

        '20210223 - GYN : 여기 인터락 우선 해제.
        'If MIL.M_WINDOWED <> MIL.MdispInquire(MilDisplay, MIL.M_DISPLAY_MODE, MIL.M_NULL) Then
        '    'Return
        '    MilWindowed = MilWindowed
        'End If

        If bEnable Then
            MIL.MdispControl(MilDisplay, MIL.M_WINDOW_OVR_WRITE, MIL.M_ENABLE)
            MIL.MdispInquire(MilDisplay, MIL.M_WINDOW_OVR_BUF_ID, MilOverlayImage)
            MIL.MdispInquire(MilDisplay, MIL.M_TRANSPARENT_COLOR, TransparentColor)
            MIL.MdispControl(MilDisplay, MIL.M_WINDOW_OVR_SHOW, MIL.M_ENABLE)

            m_bOverlayInitialized = True
        Else
            ClearOverlayBuffer()
            MIL.MdispControl(MilDisplay, MIL.M_WINDOW_OVR_SHOW, MIL.M_DISABLE)
            MIL.MdispControl(MilDisplay, MIL.M_WINDOW_OVR_WRITE, MIL.M_DISABLE)

            m_bOverlayInitialized = False
        End If
    End Sub

    Public Sub ClearOverlayBuffer()
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufClear(MilOverlayImage, TransparentColor)
    End Sub

    Private Sub MilImageWnd_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        MIL.MdispFree(MilDisplay)
        MilDisplay = MIL.M_NULL
    End Sub

    Private Sub MilImageWnd_Load(ByVal sender As Object, ByVal e As EventArgs)
        AllocMilDisplay()
        SelectDisplayWindow()
        Init()
    End Sub


End Class
