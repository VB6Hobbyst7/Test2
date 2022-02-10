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

    Public m_iDrawingMode As DrawingMode
    Public m_iCurPanel As Integer

    ' drawing and measuring
    Private m_bMouseDown As Boolean
    Private m_bRoiMode As Boolean
    Private m_ptStart As Point
    Private m_ptEnd As Point

    ' camera
    Private m_iCameraNo As Integer
    Private m_fPixelRes As Single

    Private m_ptPrePos As Point

    Private m_MilSearchResut As MIL_ID = MIL.M_NULL

    Private XPosition_old As Double = 0.0
    Private YPosition_old As Double = 0.0
    Private oldResult As Integer = 0


    'GYN - 2017.03.26
    Private m_iLine As Integer              'Line 정보
    Private m_iPanel As Integer             'Panel 정보
    Private m_iAlignMarkNo As Integer       'Align Mark1 or Align Mark2
    Private m_iAlignMarkUseNo As Integer    'Align Mark 사용하고자 하는 번호

    Public m_pVisionMode As VisionMode

    Enum VisionMode
        None = 0
        Measure = 1
        Set_Align_Area = 2
        Set_Align_Mark = 3
        Manual_Align = 4
        Set_Mark_Ref_Point = 5
    End Enum

    Public Sub New(ByVal rect As Rectangle, ByVal pParentWnd As IntPtr, ByVal MilSystem As MIL_ID, ByVal dispImage As MIL_ID, ByVal MilSearchResut As MIL_ID)
        MyBase.New(rect, pParentWnd, MilSystem, dispImage)
        m_iCameraNo = 0

        m_fPixelRes = _CAMERA.PIXEL_RESOLUTION
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

        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Name = "LiveImageWnd"

        Me.ResumeLayout(False)

    End Sub

    Public Overrides Function Init() As Boolean
        If False = MyBase.Init() Then
            Return False
        End If

        DrawCenterLine()

        Return True
    End Function

    Public Shadows Function ChangeDisplayImage(ByVal image As MIL_ID) As MIL_ID

        Dim imageOld As MIL_ID = MyBase.ChangeDisplayImage(image)

        Return imageOld
    End Function

    Public Shadows Sub SetZoomFactor(ByVal dFactor_X As Double, ByVal dFactor_Y As Double)
        MyBase.SetZoomFactor(dFactor_X, dFactor_Y)
        MyBase.ClearOverlayBuffer()

        DrawCenterLine()
        
    End Sub

    Public Sub DrawRect(ByVal ipPosX As Integer, ByVal ipPosY As Integer, ByVal ipSizeX As Integer, ByVal ipSizeY As Integer, _
                         ByVal ipColor As Color)
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim ColorPen As New Pen(ipColor, 2.0F / CSng(m_dZoomFactor_X))

        graphics__1.DrawRectangle(ColorPen, ipPosX, ipPosY, ipSizeX, ipSizeY)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

        'New연산자 해제
        ColorPen.Dispose()
        ColorPen = Nothing

    End Sub

    Private Sub DrawCross(ByVal ipPosX As Integer, ByVal ipPosY As Integer, ByVal ipSize As Integer)
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim BluePen As New Pen(Color.Blue, 2.0F / CSng(m_dZoomFactor_X))

        Dim pHStartPt As New PointF(ipPosX - ipSize / 2, ipPosY)
        Dim pHEndPt As New PointF(ipPosX + ipSize / 2, ipPosY)
        Dim pVStartPt As New PointF(ipPosX, ipPosY - ipSize / 2)
        Dim pVEndPt As New PointF(ipPosX, ipPosY + ipSize / 2)

        graphics__1.DrawLine(BluePen, pHStartPt, pHEndPt)
        graphics__1.DrawLine(BluePen, pVStartPt, pVEndPt)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

        'New연산자 해제
        BluePen.Dispose()
        BluePen = Nothing
        pHStartPt = Nothing
        pHEndPt = Nothing
        pVStartPt = Nothing
        pVEndPt = Nothing

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

        'New연산자 해제
        RedPen.Dispose()
        RedPen = Nothing
        pHStartPt = Nothing
        pHEndPt = Nothing
        pVStartPt = Nothing
        pVEndPt = Nothing

    End Sub


    Private Sub DrawLine()
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim RedPen As New Pen(Color.Red, 2.0F / CSng(m_dZoomFactor_X))

        'Dim pHStartPt As New PointF(0, m_lImageY / 2)
        'Dim pHEndPt As New PointF(m_lImageX - 1, m_lImageY / 2)
        'Dim pVStartPt As New PointF(m_lImageX / 2, 0)
        'Dim pVEndPt As New PointF(m_lImageX / 2, m_lImageY - 1)

        graphics__1.DrawLine(RedPen, m_ptStart, m_ptEnd)
        ' graphics__1.DrawLine(RedPen, pVStartPt, pVEndPt)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

        'New연산자 해제
        RedPen.Dispose()
        RedPen = Nothing

    End Sub


    Private Sub DrawMeasureLine(ByVal point As Point, ByVal prepoint As Point)
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MyBase.ClearOverlayBuffer()

        Dim ptReleased As New PointF()
        'ptReleased.X = CSng(point.X) / CSng(m_dZoomFactor_X) + CSng(m_dZoomOffsetX)
        'ptReleased.Y = CSng(point.Y) / CSng(m_dZoomFactor_Y) + CSng(m_dZoomOffsetY)
        ptReleased.X = CSng(point.X)
        ptReleased.Y = CSng(point.Y)

        m_ptPrePos.X = CSng(prepoint.X)
        m_ptPrePos.Y = CSng(prepoint.Y)

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

        'New연산자 해제
        RedPen.Dispose()
        RedPen = Nothing
        ptReleased = Nothing
        pt1OrthogonalStart = Nothing
        pt1OrthgonalEnd = Nothing
        pt2OrthogonalStart = Nothing
        pt2OrthgonalEnd = Nothing
        fontFam = Nothing
        font = Nothing
        rectF = Nothing
        formStr = Nothing
        brushWhite = Nothing

    End Sub


    Public Sub DrawROIRect(ByVal ipOffsetX As Integer, ByVal ipOffsetY As Integer, ByVal ipSizeX As Integer, ByVal ipSizeY As Integer)
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        Dim rect As New Rectangle(ipOffsetX, ipOffsetY, ipSizeX, ipSizeY)

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim RedPen As New Pen(Color.Green, 2.0F / CSng(m_dZoomFactor_X))
        graphics__1.DrawRectangle(RedPen, rect.Left, rect.Top, rect.Width, rect.Height)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

        'New연산자 해제
        rect = Nothing

        RedPen.Dispose()
        RedPen = Nothing

    End Sub



    Private Sub DrawROIRect(ByVal rect As Rectangle)
        If MIL.M_NULL = MilOverlayImage OrElse MIL.M_NULL = TransparentColor Then
            Return
        End If

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_ALLOC, MIL.M_DEFAULT)
        Dim graphics__1 As Graphics = Graphics.FromHdc(MIL.MbufInquire(MilOverlayImage, MIL.M_WINDOW_DC, MIL.M_NULL))

        graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim RedPen As New Pen(Color.Green, 2.0F / CSng(m_dZoomFactor_X))
        graphics__1.DrawRectangle(RedPen, rect.Left, rect.Top, rect.Width, rect.Height)

        MIL.MbufControl(MilOverlayImage, MIL.M_WINDOW_DC_FREE, MIL.M_DEFAULT)
        MIL.MbufControl(MilOverlayImage, MIL.M_MODIFIED, MIL.M_DEFAULT)

        'New연산자 해제

        RedPen.Dispose()
        RedPen = Nothing

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

                pen.Dispose()
                pen = Nothing
                fontFam = Nothing
                font = Nothing

            End If
        Else
            If oldResult <> NumResults Then
                MyBase.ClearOverlayBuffer()

                DrawCenterLine()

                '20151013 usbpdj live창 얼라인 마크 영역 표시
                oldResult = NumResults
            End If
        End If


    End Sub

    Public Sub SetCameraNo(ByVal iNo As Integer)
        m_iCameraNo = iNo
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



    Private Sub LiveImageWnd_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) 'Handles Me.Paint
        DrawMark()
    End Sub

    Dim tmpPosX As Integer
    Dim tmpPosY As Integer
    Dim tmpSizeX As Integer
    Dim tmpSizeY As Integer

    Private Sub LiveImageWnd_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        'If m_iDrawingMode = DrawingMode.MODE_SEARCHAREA Or m_iDrawingMode = DrawingMode.MODE_MODELAREA Or m_iDrawingMode = DrawingMode.MODE_MEASURE Or frmSequence.nManualAlign_A = 1 Or frmSequence.nManualAlign_B = 1 Then
        'If m_iDrawingMode = DrawingMode.MODE_SEARCHAREA Or m_iDrawingMode = DrawingMode.MODE_MODELAREA Or m_iDrawingMode = DrawingMode.MODE_MEASURE Then
        m_ptStart.X = e.X / CSng(m_dZoomFactor_X)
        m_ptStart.Y = e.Y / CSng(m_dZoomFactor_Y)

        Select Case m_pVisionMode
            Case VisionMode.Manual_Align, VisionMode.Measure, VisionMode.Set_Align_Area, VisionMode.Set_Align_Mark, VisionMode.Set_Mark_Ref_Point
                m_bMouseDown = True
        End Select
    End Sub

    Private Sub LiveImageWnd_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If m_bMouseDown = True Then
            MyBase.ClearOverlayBuffer()

            m_ptEnd.X = e.X / CSng(m_dZoomFactor_X)
            m_ptEnd.Y = e.Y / CSng(m_dZoomFactor_Y)

            Select Case m_pVisionMode
                Case VisionMode.Measure
                    'DrawLine()
                    DrawMeasureLine(m_ptStart, m_ptEnd)

                Case VisionMode.Set_Align_Area
                    GetRectPosition(m_ptStart.X, m_ptStart.Y, m_ptEnd.X, m_ptEnd.Y, tmpPosX, tmpPosY, tmpSizeX, tmpSizeY)
                    DrawRect(tmpPosX, tmpPosY, tmpSizeX, tmpSizeY, Color.YellowGreen)

                Case VisionMode.Set_Align_Mark
                    GetRectPosition(m_ptStart.X, m_ptStart.Y, m_ptEnd.X, m_ptEnd.Y, tmpPosX, tmpPosY, tmpSizeX, tmpSizeY)
                    DrawRect(tmpPosX, tmpPosY, tmpSizeX, tmpSizeY, Color.Lime)

                Case VisionMode.Manual_Align
                    DrawCross(m_ptEnd.X, m_ptEnd.Y, 100)

                Case VisionMode.Set_Mark_Ref_Point
                    DrawCross(m_ptEnd.X, m_ptEnd.Y, 50)

            End Select
        End If
    End Sub

    Private Sub LiveImageWnd_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        Try
            m_ptEnd.X = e.X / CSng(m_dZoomFactor_X)
            m_ptEnd.Y = e.Y / CSng(m_dZoomFactor_Y)

            If e.Button = Windows.Forms.MouseButtons.Right Then
                Dim dCenterX As Double = m_lImageX / 2.0
                Dim dCenterY As Double = m_lImageY / 2.0

                Dim dClickX As Double = e.X / m_dZoomFactor_X
                Dim dClickY As Double = e.Y / m_dZoomFactor_Y

                Dim dTargetX As Double = 0.0
                Dim dTargetY As Double = 0.0

                If (m_iCameraNo = 0 Or m_iCameraNo = 1) Then
                    dTargetX = (dClickX - dCenterX) * pCurSystemParam.dVisionScaleX(LINE.A, m_iCameraNo) * -1
                    dTargetY = (dClickY - dCenterY) * pCurSystemParam.dVisionScaleY(LINE.A, m_iCameraNo)

                    pLDLT.MoveStage(0, Axis.x, (pLDLT.PLC_Infomation.dCurPosX(0) + dTargetX) * 1000)
                    pLDLT.MoveStage(0, Axis.y, (pLDLT.PLC_Infomation.dCurPosY(0) + dTargetY) * 1000)
                Else
                    modVision.AdjustCameraFactor((dClickX - dCenterX) * -1, (dClickY - dCenterY) * -1, pCurSystemParam.dVisionScaleX(LINE.B, m_iCameraNo - 2), pCurSystemParam.dVisionScaleY(LINE.B, m_iCameraNo - 2), pCurSystemParam.dVisionTheta(LINE.B, m_iCameraNo - 2), _
                                                   dTargetX, dTargetY)

                    'dTargetX = (dClickX - dCenterX) * pCurSystemParam.dVisionScaleX(LINE.B, m_iCameraNo) * 1000 * -1
                    'dTargetY = (dClickY - dCenterY) * pCurSystemParam.dVisionScaleY(LINE.B, m_iCameraNo) * 1000 * -1
                    'dTargetX = (dClickX - dCenterX) * _CAMERA.PIXEL_RESOLUTION * 1000 * -1
                    'dTargetY = (dClickY - dCenterY) * _CAMERA.PIXEL_RESOLUTION * 1000 * -1

                    pLDLT.MoveStage(1, Axis.x, (pLDLT.PLC_Infomation.dCurPosX(1) + dTargetX) * 1000)
                    pLDLT.MoveStage(1, Axis.y, (pLDLT.PLC_Infomation.dCurPosY(1) + dTargetY) * 1000)
                End If
            Else
                If m_bMouseDown = True Then
                    MyBase.ClearOverlayBuffer()

                    m_ptEnd.X = e.X / CSng(m_dZoomFactor_X)
                    m_ptEnd.Y = e.Y / CSng(m_dZoomFactor_Y)

                    Select Case m_pVisionMode
                        Case VisionMode.Measure
                            DrawLine()

                        Case VisionMode.Set_Align_Area
                            GetRectPosition(m_ptStart.X, m_ptStart.Y, m_ptEnd.X, m_ptEnd.Y, tmpPosX, tmpPosY, tmpSizeX, tmpSizeY)
                            DrawRect(tmpPosX, tmpPosY, tmpSizeX, tmpSizeY, Color.YellowGreen)
                            'pnVisionSetArea = AlignMark.Panel1_Mark1 + (m_nLine * 10)

                            InputSearchArea(pnVisionSetArea)

                            modVision.GetVisionInfomation(m_iLine, m_iPanel, m_iAlignMarkNo, m_iAlignMarkUseNo)

                            Select Case pnVisionSetArea

                                Case 0, 2, 4, 6, 10, 12, 14, 16
                                    'frmRecipe.m_CurAlignMarkSetting(0).UpdateRectInfo(m_ptStart, m_ptEnd)
                                    frmRecipe.m_ctrlRcpAlign(m_iLine).m_ctrlMarks(m_iPanel).m_ctrlAlignMark(m_iAlignMarkNo, m_iAlignMarkUseNo).UpdateRectInfo(m_ptStart, m_ptEnd)

                                Case 1, 3, 5, 7, 11, 13, 15, 17
                                    'frmRecipe.m_CurAlignMarkSetting(1).UpdateRectInfo(m_ptStart, m_ptEnd)
                                    frmRecipe.m_ctrlRcpAlign(m_iLine).m_ctrlMarks(m_iPanel).m_ctrlAlignMark(m_iAlignMarkNo, m_iAlignMarkUseNo).UpdateRectInfo(m_ptStart, m_ptEnd)

                            End Select

                        Case VisionMode.Set_Align_Mark
                            GetRectPosition(m_ptStart.X, m_ptStart.Y, m_ptEnd.X, m_ptEnd.Y, tmpPosX, tmpPosY, tmpSizeX, tmpSizeY)
                            DrawRect(tmpPosX, tmpPosY, tmpSizeX, tmpSizeY, Color.Lime)

                            'GYN - 우선 1번 마크에만 Offset 적용하자..근데 이걸 여기서 해야돼?
                            InputMarkArea(pnVisionSetArea, 0)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            modVision.GetVisionInfomation(m_iLine, m_iPanel, m_iAlignMarkNo, m_iAlignMarkUseNo)

                            Select Case pnVisionSetArea

                                Case 0, 2, 4, 6, 10, 12, 14, 16
                                    'frmRecipe.m_CurAlignMarkSetting(0).UpdateRectInfo(m_ptStart, m_ptEnd)
                                    frmRecipe.m_ctrlRcpAlign(m_iLine).m_ctrlMarks(m_iPanel).m_ctrlAlignMark(m_iAlignMarkNo, m_iAlignMarkUseNo).UpdateRectInfo(m_ptStart, m_ptEnd)


                                Case 1, 3, 5, 7, 11, 13, 15, 17
                                    'frmRecipe.m_CurAlignMarkSetting(1).UpdateRectInfo(m_ptStart, m_ptEnd)
                                    frmRecipe.m_ctrlRcpAlign(m_iLine).m_ctrlMarks(m_iPanel).m_ctrlAlignMark(m_iAlignMarkNo, m_iAlignMarkUseNo).UpdateRectInfo(m_ptStart, m_ptEnd)


                            End Select

                        Case VisionMode.Manual_Align

                            Dim nGlass As Integer = 0
                            Dim dTmpPosX As Double = 0
                            Dim dTmpPosY As Double = 0

                            dTmpPosX = e.X / CSng(m_dZoomFactor_X)
                            dTmpPosY = e.Y / CSng(m_dZoomFactor_Y)

                            DrawCross(dTmpPosX, dTmpPosY, 100)

                            'dTmpPosX = dTmpPosX - CDbl(m_lImageX / 2.0)
                            'dTmpPosY = CDbl(m_lImageY / 2.0) - dTmpPosY

                            dTmpPosX = dTmpPosX - CDbl(m_lImageX / 2.0)
                            dTmpPosY = dTmpPosY - CDbl(m_lImageY / 2.0)
#If HEAD_2 Then
                            If Seq(0).bManualAlignMode = True And frmSequence_2Head.pbManualAlign_A = True Then
#Else
                            If Seq(0).bManualAlignMode = True And frmSequence.pbManualAlign_A = True Then
#End If
                                'If Seq(0).bManualAlignMode = True And frmSequence.pbManualAlign_A = True Then
                                Select Case Seq(0).nManualAlingIndex
                                    Case 0
                                        nGlass = 0
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 0), pCurSystemParam.dVisionScaleY(LINE.A, 0), pCurSystemParam.dVisionTheta(LINE.A, 0), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionY)
                                    Case 1
                                        nGlass = 0
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 0), pCurSystemParam.dVisionScaleY(LINE.A, 0), pCurSystemParam.dVisionTheta(LINE.A, 0), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionY)
                                    Case 2
                                        nGlass = 1
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 1), pCurSystemParam.dVisionScaleY(LINE.A, 1), pCurSystemParam.dVisionTheta(LINE.A, 1), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionY)
                                    Case 3
                                        nGlass = 1
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 1), pCurSystemParam.dVisionScaleY(LINE.A, 1), pCurSystemParam.dVisionTheta(LINE.A, 1), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionY)
                                    Case 4
                                        nGlass = 2
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 0), pCurSystemParam.dVisionScaleY(LINE.A, 0), pCurSystemParam.dVisionTheta(LINE.A, 0), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionY)
                                    Case 5
                                        nGlass = 2
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 0), pCurSystemParam.dVisionScaleY(LINE.A, 0), pCurSystemParam.dVisionTheta(LINE.A, 0), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionY)
                                    Case 6
                                        nGlass = 3
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 1), pCurSystemParam.dVisionScaleY(LINE.A, 1), pCurSystemParam.dVisionTheta(LINE.A, 1), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark1DifferencePositionY)
                                    Case 7
                                        nGlass = 3
                                        pCurRecipe.AlignResult(LINE.A, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.A, 1), pCurSystemParam.dVisionScaleY(LINE.A, 1), pCurSystemParam.dVisionTheta(LINE.A, 1), _
                                                                       pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.A, nGlass).dMark2DifferencePositionY)
                                End Select

#If HEAD_2 Then
                            ElseIf Seq(1).bManualAlignMode = True And frmSequence_2Head.pbManualAlign_B = True Then
#Else
                            ElseIf Seq(1).bManualAlignMode = True And frmSequence.pbManualAlign_B = True Then
#End If
                                'ElseIf Seq(1).bManualAlignMode = True And frmSequence.pbManualAlign_B = True Then
                                Select Case Seq(1).nManualAlingIndex
                                    Case 0
                                        nGlass = 0
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 0), pCurSystemParam.dVisionScaleY(LINE.B, 0), pCurSystemParam.dVisionTheta(LINE.B, 0), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionY)
                                    Case 1
                                        nGlass = 0
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 0), pCurSystemParam.dVisionScaleY(LINE.B, 0), pCurSystemParam.dVisionTheta(LINE.B, 0), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionY)
                                    Case 2
                                        nGlass = 1
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 1), pCurSystemParam.dVisionScaleY(LINE.B, 1), pCurSystemParam.dVisionTheta(LINE.B, 1), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionY)
                                    Case 3
                                        nGlass = 1
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 1), pCurSystemParam.dVisionScaleY(LINE.B, 1), pCurSystemParam.dVisionTheta(LINE.B, 1), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionY)
                                    Case 4
                                        nGlass = 2
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 0), pCurSystemParam.dVisionScaleY(LINE.B, 0), pCurSystemParam.dVisionTheta(LINE.B, 0), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionY)
                                    Case 5
                                        nGlass = 2
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 0), pCurSystemParam.dVisionScaleY(LINE.B, 0), pCurSystemParam.dVisionTheta(LINE.B, 0), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionY)
                                    Case 6
                                        nGlass = 3
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark1_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 1), pCurSystemParam.dVisionScaleY(LINE.B, 1), pCurSystemParam.dVisionTheta(LINE.B, 1), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark1DifferencePositionY)
                                    Case 7
                                        nGlass = 3
                                        pCurRecipe.AlignResult(LINE.B, nGlass).bGetMark2_OK = True
                                        modVision.AdjustCameraFactor(dTmpPosX, dTmpPosY, pCurSystemParam.dVisionScaleX(LINE.B, 1), pCurSystemParam.dVisionScaleY(LINE.B, 1), pCurSystemParam.dVisionTheta(LINE.B, 1), _
                                                                       pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionX, pCurRecipe.AlignResult(LINE.B, nGlass).dMark2DifferencePositionY)
                                End Select

                            End If

                            'Case VisionMode.Set_Mark_Ref_Point

                            '    Dim nGlass As Integer = 0
                            '    Dim dTmpPosX As Double = 0
                            '    Dim dTmpPosY As Double = 0

                            '    dTmpPosX = e.X / CSng(m_dZoomFactor_X)
                            '    dTmpPosY = e.Y / CSng(m_dZoomFactor_Y)

                            '    DrawCross(dTmpPosX, dTmpPosY, 50)

                            '    'dTmpPosX() '= dTmpPosX - CDbl(m_lImageX / 2.0)
                            '    'dTmpPosY() '= dTmpPosY - CDbl(m_lImageY / 2.0)

                            '    Select Case m_iCameraNo

                            '        Case 0
                            '            frmRecipe.m_CurAlignMarkSetting(0).UpdateClossInfo(dTmpPosX, dTmpPosY)

                            '        Case 1
                            '            frmRecipe.m_CurAlignMarkSetting(1).UpdateClossInfo(dTmpPosX, dTmpPosY)

                            'End Select


                    End Select
                End If
            End If

            m_bMouseDown = False

        Catch ex As Exception
            MsgBox(ex.Message & Me.ToString & "LiveImageWnd_MouseUp")
        End Try

    End Sub

    Private Sub GetRectPosition(ByVal ipPosX1 As Integer, ByVal ipPosY1 As Integer, ByVal ipPosX2 As Integer, ByVal ipPosY2 As Integer, _
                                ByRef outPosX As Integer, ByRef outPosY As Integer, ByRef outSizeX As Integer, ByRef outSizeY As Integer)
        If ipPosX1 > ipPosX2 Then
            outPosX = ipPosX2
            outSizeX = ipPosX1 - ipPosX2
        Else
            outPosX = ipPosX1
            outSizeX = ipPosX2 - ipPosX1
        End If

        If ipPosY1 > ipPosY2 Then
            outPosY = ipPosY2
            outSizeY = ipPosY1 - ipPosY2
        Else
            outPosY = ipPosY1
            outSizeY = ipPosY2 - ipPosY1
        End If
    End Sub

    Private Sub InputSearchArea(ByVal ipIndex As Integer)
        Select Case ipIndex
            Case 0 'LineA , Glass 1 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 1 'LineA , Glass 1 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 2 'LineA , Glass 2 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 3 'LineA , Glass 2 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 4 'LineA , Glass 3 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 5 'LineA , Glass 3 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 6 'LineA , Glass 4 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 7 'LineA , Glass 4 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.A, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 10 'LineB , Glass 1 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 11 'LineB , Glass 1 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p1, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 12 'LineB , Glass 2 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 13 'LineB , Glass 2 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p2, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 14 'LineB , Glass 3 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 15 'LineB , Glass 3 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p3, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 16 'LineB , Glass 4 , Mark 1
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark1, i).nAlignMark_SearchSizeY = tmpSizeY
                Next

            Case 17 'LineB , Glass 4 , Mark 2
                For i As Integer = 0 To 2
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetX = tmpPosX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchOffsetY = tmpPosY
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeX = tmpSizeX
                    pRcpMark_Data_Tmp(LINE.B, Panel.p4, AlignMarkNumber.Mark2, i).nAlignMark_SearchSizeY = tmpSizeY
                Next
        End Select

    End Sub

    Private Sub InputMarkArea(ByVal ipIndex As Integer, ByVal nListNumber As Integer)
        Select Case ipIndex
            Case 0 'LineA , Glass 1 , Mark 1
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 1 'LineA , Glass 1 , Mark 2
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 2 'LineA , Glass 2 , Mark 1
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 3 'LineA , Glass 2 , Mark 2
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 4 'LineA , Glass 3 , Mark 1
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 5 'LineA , Glass 3 , Mark 2
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 6 'LineA , Glass 4 , Mark 1
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 7 'LineA , Glass 4 , Mark 2
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.A, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 10 'LineB , Glass 1 , Mark 1
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 11 'LineB , Glass 1 , Mark 2
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p1, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 12 'LineB , Glass 2 , Mark 1
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 13 'LineB , Glass 2 , Mark 2
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p2, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 14 'LineB , Glass 3 , Mark 1
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 15 'LineB , Glass 3 , Mark 2
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p3, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 16 'LineB , Glass 4 , Mark 1
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark1, nListNumber).nAlignMark_ModelSizeY = tmpSizeY

            Case 17 'LineB , Glass 4 , Mark 2
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetX = tmpPosX
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelOffsetY = tmpPosY
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeX = tmpSizeX
                pRcpMark_Data(LINE.B, Panel.p4, AlignMarkNumber.Mark2, nListNumber).nAlignMark_ModelSizeY = tmpSizeY
        End Select

    End Sub
End Class
