Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Matrox.MatroxImagingLibrary
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Class LiveImageWnd
    Inherits MilImageWnd
    Private m_iCamNo As Integer
    Private m_fPixelRes As Single

    Private m_ptPrePos As Point
    Private m_bMeasureStart As Boolean = False

    Private m_MilSearchResut As MIL_ID = MIL.M_NULL

    Private XPosition_old As Double = 0.0
    Private YPosition_old As Double = 0.0
    Private oldResult As Integer = 0

    'object LockThis = new object();

    Public Sub New(ByVal rect As Rectangle, ByVal pParentWnd As IntPtr, ByVal MilSystem As MIL_ID, ByVal dispImage As MIL_ID, ByVal MilSearchResut As MIL_ID)
        MyBase.New(rect, pParentWnd, MilSystem, dispImage)
        m_iCamNo = 0

        m_fPixelRes = PIXEL_RESOLUTION 
        m_ptPrePos.X = -1
        m_ptPrePos.Y = -1

        Me.Left = 0
        Me.Top = 0
        Me.Width = rect.Width
        Me.Height = rect.Height
        Me.Dock = System.Windows.Forms.DockStyle.Fill

        m_MilSearchResut = MilSearchResut

        InitComponent()
    End Sub

    Private Sub InitComponent()
        Me.SuspendLayout()
        ' 
        ' LiveImageWnd

        'Me.BackColor = System.Drawing.Color.White
        'Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        'Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        'Me.Name = "MilImageWnd"
        'AddHandler Me.Load, New System.EventHandler(AddressOf Me.MilImageWnd_Load)
        'AddHandler Me.FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.MilImageWnd_FormClosed)
        'Me.ResumeLayout(False)

        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Name = "LiveImageWnd"
        'Me.Paint += New System.Windows.Forms.PaintEventHandler(AddressOf Me.LiveImageWnd_Paint)
        ' Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(AddressOf Me.LiveImageWnd_FormClosing)
        '    Me.MouseUp += New System.Windows.Forms.MouseEventHandler(AddressOf Me.LiveImageWnd_MouseUp)
        '    Me.MouseDown += New System.Windows.Forms.MouseEventHandler(AddressOf Me.LiveImageWnd_MouseDown)
        '    Me.MouseMove += New System.Windows.Forms.MouseEventHandler(AddressOf Me.LiveImageWnd_MouseMove)
        Me.ResumeLayout(False)

    End Sub

    Public Overrides Function Init() As Boolean
        If False = MyBase.Init() Then
            Return False
        End If

        DrawCenterLine()
        DrawROIRect()
        '20151013 usbpdj live창 얼라인 마크 영역 표시
        Return True
    End Function

    Public Shadows Function ChangeDisplayImage(ByVal image As MIL_ID) As MIL_ID
        Dim imageOld As MIL_ID = MyBase.ChangeDisplayImage(image)

        'DrawCenterLine()
        'DrawROIRect()

        Return imageOld
    End Function

    Public Shadows Sub SetZoomFactor(ByVal dFactor_X As Double, ByVal dFactor_Y As Double)
        MyBase.SetZoomFactor(dFactor_X, dFactor_Y)
        MyBase.ClearOverlayBuffer()

        DrawCenterLine()
        DrawROIRect()
        '20151013 usbpdj live창 얼라인 마크 영역 표시
    End Sub


    Private Sub DrawCenterLine()
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim RedPen As New Pen(Color.Red, 2.0F / CSng(m_dZoomFactor_X))

        Dim pHStartPt As New PointF(0, m_lImageY / 2)
        Dim pHEndPt As New PointF(m_lImageX - 1, m_lImageY / 2)
        Dim pVStartPt As New PointF(m_lImageX / 2, 0)
        Dim pVEndPt As New PointF(m_lImageX / 2, m_lImageY - 1)

        graphics__1.DrawLine(RedPen, pHStartPt, pHEndPt)
        graphics__1.DrawLine(RedPen, pVStartPt, pVEndPt)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

    End Sub

    Private Sub DrawMeasureLine(ByVal point As Point)
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MyBase.ClearOverlayBuffer()

        Dim ptReleased As New PointF()
        ptReleased.X = CSng(point.X) / CSng(m_dZoomFactor_X) + CSng(m_dZoomOffsetX)
        ptReleased.Y = CSng(point.Y) / CSng(m_dZoomFactor_Y) + CSng(m_dZoomOffsetY)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim RedPen As New Pen(Color.Red, 2.0F / CSng(m_dZoomFactor_X))

        Dim pt1OrthogonalStart As New PointF(0, 0)
        Dim pt1OrthgonalEnd As New PointF(0, 0)
        Dim pt2OrthogonalStart As New PointF(0, 0)
        Dim pt2OrthgonalEnd As New PointF(0, 0)

        Dim fGuideSize As Single = 10.0F / CSng(m_dZoomFactor_X)
        fGuideSize *= fGuideSize
        Dim fMovingX As Single = ptReleased.X - m_ptPrePos.X
        Dim fMovingY As Single = ptReleased.Y - m_ptPrePos.Y

        'GYN
        'If 0 = DirectCast(m_iCamNo, 0) OrElse 1 = DirectCast(m_iCamNo, 1) Then
        '    m_fPixelRes = CSng(_CAMERA.PIXEL_RESOLUTION_EDGE)
        'Else
        '    m_fPixelRes = CSng(_CAMERA.PIXEL_RESOLUTION_CUTTING)
        'End If

        Dim fDistance As Single = CSng(Math.Sqrt(fMovingX * fMovingX + fMovingY * fMovingY)) * m_fPixelRes

        If fMovingY = 0 Then
            pt1OrthogonalStart.X = m_ptPrePos.X
            pt1OrthogonalStart.Y = CSng(Math.Sqrt(fGuideSize)) + m_ptPrePos.Y
            pt1OrthgonalEnd.X = m_ptPrePos.X
            pt1OrthgonalEnd.Y = CSng(-Math.Sqrt(fGuideSize)) + m_ptPrePos.Y

            pt2OrthogonalStart.X = ptReleased.X
            pt2OrthogonalStart.Y = CSng(Math.Sqrt(fGuideSize)) + ptReleased.Y
            pt2OrthgonalEnd.X = ptReleased.X
            pt2OrthgonalEnd.Y = CSng(-Math.Sqrt(fGuideSize)) + ptReleased.Y
        Else
            Dim fSlope As Single = -fMovingX / fMovingY
            Dim fTemp As Single = fGuideSize / (fSlope * fSlope + 1)

            pt1OrthogonalStart.X = CSng(Math.Sqrt(fTemp)) + m_ptPrePos.X
            pt1OrthogonalStart.Y = fSlope * (pt1OrthogonalStart.X - m_ptPrePos.X) + m_ptPrePos.Y
            pt1OrthgonalEnd.X = CSng(-Math.Sqrt(fTemp)) + m_ptPrePos.X
            pt1OrthgonalEnd.Y = fSlope * (pt1OrthgonalEnd.X - m_ptPrePos.X) + m_ptPrePos.Y

            pt2OrthogonalStart.X = CSng(Math.Sqrt(fTemp)) + ptReleased.X
            pt2OrthogonalStart.Y = fSlope * (pt2OrthogonalStart.X - ptReleased.X) + ptReleased.Y
            pt2OrthgonalEnd.X = CSng(-Math.Sqrt(fTemp)) + ptReleased.X
            pt2OrthgonalEnd.Y = fSlope * (pt2OrthgonalEnd.X - ptReleased.X) + ptReleased.Y
        End If
        graphics__1.DrawLine(RedPen, pt1OrthogonalStart, pt1OrthgonalEnd)
        graphics__1.DrawLine(RedPen, m_ptPrePos, ptReleased)
        graphics__1.DrawLine(RedPen, pt2OrthogonalStart, pt2OrthgonalEnd)

        ' 선폭 측정 결과 표시
        Dim fontFam As New FontFamily("Arial")
        Dim font As New Font(fontFam, 20.0F / CSng(m_dZoomFactor_X))

        Dim fX As Single = (CSng(m_lImageX) / 2.0F - Me.Width / 2.0F / CSng(m_dZoomFactor_X))
        Dim fY As Single = (CSng(m_lImageY) / 2.0F - Me.Height / 2.0F / CSng(m_dZoomFactor_Y))
        If fX < 0.0F Then
            fX = 0.0F
        End If
        If fY < 0.0F Then
            fY = 0.0F
        End If

        Dim fWidth As Single = 350.0F / CSng(m_dZoomFactor_X)
        Dim fHeight As Single = 50.0F / CSng(m_dZoomFactor_Y)
        Dim rectF As New RectangleF(fX, fY, fWidth, fHeight)

        Dim formStr As New StringFormat()
        formStr.Alignment = StringAlignment.Near
        Dim brushWhite As New SolidBrush(Color.Red)

        Dim strTemp As [String] = String.Format("{0:f3} mm]", fDistance)

        graphics__1.DrawString(strTemp, font, brushWhite, rectF, formStr)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

        DrawCenterLine()
    End Sub

    Private Sub DrawROIRect()
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        Dim limageX As Integer = m_lImageX / 2
        Dim limageY As Integer = m_lImageY / 2

        Dim rect As New Rectangle(limageX - 800 \ 2, limageY - 800 \ 2, 800, 800)

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim RedPen As New Pen(Color.Green, 2.0F / CSng(m_dZoomFactor_X))
        graphics__1.DrawRectangle(RedPen, rect.Left, rect.Top, rect.Width, rect.Height)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)
    End Sub


    Private Sub DrawMark()
        If m_MilSearchResut = MIL.M_NULL Then
            Return
        End If

        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        Dim NumResults As Integer = 0
        MIL.MmodGetResult(m_MilSearchResut, MIL.M_DEFAULT, MIL.M_NUMBER + MIL.M_TYPE_MIL_INT, NumResults)

        Dim Score As Double = 0.0
        Dim XPosition As Double = 0.0
        Dim YPosition As Double = 0.0

        If NumResults = 1 Then
            MIL.MmodGetResult(m_MilSearchResut, MIL.M_DEFAULT, MIL.M_POSITION_X, XPosition)
            MIL.MmodGetResult(m_MilSearchResut, MIL.M_DEFAULT, MIL.M_POSITION_Y, YPosition)
            MIL.MmodGetResult(m_MilSearchResut, MIL.M_DEFAULT, MIL.M_SCORE, Score)
            XPosition += ((m_lImageX - 800) \ 2)
            YPosition += ((m_lImageY - 800) \ 2)
            If XPosition <> XPosition_old OrElse YPosition <> YPosition_old Then
                MyBase.ClearOverlayBuffer()

                MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
                Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))
                graphics__1.SmoothingMode = SmoothingMode.HighQuality

                DrawCenterLine()
                DrawROIRect()
                '20151013 usbpdj live창 얼라인 마크 영역 표시
                XPosition_old = XPosition
                YPosition_old = YPosition
                Dim pen As New Pen(Color.GreenYellow, 2.0F / CSng(m_dZoomFactor_X))

                graphics__1.DrawLine(pen, CSng(XPosition) - 30.0F, CSng(YPosition), CSng(XPosition) + 30.0F, CSng(YPosition))
                graphics__1.DrawLine(pen, CSng(XPosition), CSng(YPosition) - 30.0F, CSng(XPosition), CSng(YPosition) + 30.0F)

                Dim fontFam As New FontFamily("Arial")
                Dim font As New Font(fontFam, 12.0F / CSng(m_dZoomFactor_X))

                Dim msg As String = ""
                msg = String.Format("Search Poistion X: {0:f4}, Y: {0:f4}", XPosition, YPosition)
                graphics__1.DrawString(msg, font, New SolidBrush(Color.GreenYellow), New PointF(10.0F, 10.0F))
                msg = String.Format("Search Score: {0:f4}", Score)
                graphics__1.DrawString(msg, font, New SolidBrush(Color.GreenYellow), New PointF(10.0F, 40.0F))

                MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
                MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

            End If
        Else
            If oldResult <> NumResults Then
                MyBase.ClearOverlayBuffer()

                DrawCenterLine()
                DrawROIRect()
                '20151013 usbpdj live창 얼라인 마크 영역 표시
                oldResult = NumResults
            End If
        End If


    End Sub

    Public Sub SetCamNo(ByVal iNo As Integer)
        m_iCamNo = iNo
    End Sub

    Private Sub LiveImageWnd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        RealaesDisplay()
    End Sub

    'Private Sub LiveImageWnd_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If MouseButtons.Right = e.Button Then
    '        Dim iOffsetX As Integer = CInt(Math.Truncate(CDbl(e.X) / m_dZoomFactor_X - CDbl(m_lImageX) / 2.0 + m_dZoomOffsetX))
    '        Dim iOffsetY As Integer = CInt(Math.Truncate(CDbl(m_lImageY) / 2.0 - CDbl(e.Y) / m_dZoomFactor_Y - m_dZoomOffsetY))

    '        Utility.SendMessage(m_pParentWnd, Def.U_MSG_MOUSE_RBTN_DOWN, m_iCamNo, Utility.MakeLParam(iOffsetX, iOffsetY))
    '    Else
    '        m_ptPrePos.X = CInt(Math.Truncate(e.X / CSng(m_dZoomFactor_X) + CSng(m_dZoomOffsetX)))
    '        m_ptPrePos.Y = CInt(Math.Truncate(e.Y / CSng(m_dZoomFactor_Y) + CSng(m_dZoomOffsetY)))
    '        m_bMeasureStart = True
    '    End If
    'End Sub

    Private Sub LiveImageWnd_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If m_bMeasureStart Then
            DrawMeasureLine(New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub LiveImageWnd_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        m_bMeasureStart = False
        MyBase.ClearOverlayBuffer()
        DrawCenterLine()
    End Sub

    Private Sub LiveImageWnd_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) 'Handles Me.Paint

        DrawMark()
    End Sub
End Class
