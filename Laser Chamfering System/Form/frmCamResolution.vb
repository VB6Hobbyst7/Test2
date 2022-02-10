Imports Matrox.MatroxImagingLibrary

' 호출방법
'Dim frm As frmCamResolution
'frm = New frmCamResolution
'frm.SetMILID(m_MilSystem, -1)      ' 두번째 인자에 실제 해당 카메라의 DispImage MIL_ID입력
'frm.Show()
'


Public Class frmCamResolution

    Private Enum LINEPOS
        TOP = 0
        BOTTOM
        LEFT
        RIGHT
    End Enum

    Private Structure LINESTRUCT
        Dim pt1 As Point
        Dim pt2 As Point

        Sub SetPos(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
            pt1.X = x1
            pt1.Y = y1

            pt2.X = x2
            pt2.Y = y2
        End Sub
    End Structure

    Private m_MilSystem As MIL_ID
    Private m_MilDisp As MIL_ID
    Private m_MilDispImg As MIL_ID

    Private m_MilOverlay As MIL_ID

    Private m_nCamIndex As Integer

    Private m_LinePos(4) As LINESTRUCT
    Private m_CamX As Integer
    Private m_CamY As Integer

    Private m_nMoveSize(2) As Integer


    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Protected Overrides Sub Finalize()
        ' ##############################################
        ' Finalize가 정확히 폼이 닫힐 때 동작하지않고 =Nothing 대입시 실행되는듯함.
        ' FormClosed()의 루틴 실행되도록 할것.(단 이때 Modeless일 경우 화면이 가려져도 발생될 수 있음.(디버깅시에 브레이크 포인트 들어갈때 발생했음)
        'If (m_MilDispImg <> MIL.M_NULL) Then
        '    MIL.MbufFree(m_MilDispImg)              ' m_DispImg는 실제 소스에서는 Free하면 안됨################################
        'End If

        If (m_MilDisp <> MIL.M_NULL) Then
            MIL.MdispFree(m_MilDisp)
            m_MilDisp = MIL.M_NULL
        End If

        MyBase.Finalize()
    End Sub

    Private Sub frmCamResolution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'm_LinePos(LINEPOS.TOP).SetPos(0, 0, 0, 0)
        'm_LinePos(LINEPOS.BOTTOM).SetPos(0, 0, 0, 0)
        'm_LinePos(LINEPOS.LEFT).SetPos(0, 0, 0, 0)
        'm_LinePos(LINEPOS.RIGHT).SetPos(0, 0, 0, 0)
        'm_MilDisp = MIL.M_NULL

        
        m_nMoveSize(0) = 10
        m_nMoveSize(1) = 10

        btnSizeLR.Text = CStr(m_nMoveSize(0))
        btnSizeUD.Text = CStr(m_nMoveSize(1))






    End Sub

    Private Sub frmCamResolution_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If (m_MilDisp <> MIL.M_NULL) Then
            MIL.MdispFree(m_MilDisp)
            m_MilDisp = MIL.M_NULL
        End If
    End Sub

    Public Sub SetMILID(ByVal MilSys As MIL_ID, ByVal CamIndex As Integer)

        m_MilSystem = MilSys
        m_nCamIndex = CamIndex


        ChangeCam(CamIndex)

    End Sub

    Public Sub ChangeCam(ByVal CamIndex As Integer)
#If SIMUL <> 1 Then
        'If m_MilDisp <> MIL.M_NULL Then
        '    MIL.MdispFree(m_MilDisp)
        'End If


        '20210223 - GYN : 여기 인터락 우선 해제.
        'If m_MilDisp = MIL.M_NULL Then
        '    MIL.MdispAlloc(m_MilSystem, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, m_MilDisp)
        'End If

        If MIL.M_NULL = m_MilDisp Then
            MessageBox.Show("CMilImageWnd Display Allocation Failed.")
            Exit Sub
        End If


        '///////////////////////////////////////////////////////////////
        ' 테스트용. 실제 루틴에서는 TRUE조건 삭제할것
        'If MilDispImg = -1 Then
        '    MIL.MbufRestore("C:\\c2.jpg", m_MilSystem, m_MilDispImg)

        '    'MIL.MdispSelect(m_MilDisp, m_MilDispImg)
        'ElseIf MilDispImg = 0 Or MilDispImg = 1 Or MilDispImg = 2 Or MilDispImg = 3 Then
        '    '
        'Else
        '    m_MilDispImg = MilDispImg
        'End If
        'm_MilDispImg = MilDispImg


        m_MilDispImg = pMilInterface.dispImage(CamIndex)


        If m_MilDispImg <> MIL.M_NULL Then
            m_CamX = MIL.MbufInquire(m_MilDispImg, MIL.M_SIZE_X)
            m_CamY = MIL.MbufInquire(m_MilDispImg, MIL.M_SIZE_Y)
        End If

        m_LinePos(LINEPOS.TOP).SetPos(0, 100, m_CamX, 100)
        m_LinePos(LINEPOS.BOTTOM).SetPos(0, m_CamY - 100, m_CamX, m_CamY - 100)
        m_LinePos(LINEPOS.LEFT).SetPos(100, 0, 100, m_CamY)
        m_LinePos(LINEPOS.RIGHT).SetPos(m_CamX - 100, 0, m_CamX - 100, m_CamY)



        MIL.MdispSelectWindow(m_MilDisp, m_MilDispImg, pnlCam.Handle)


        m_MilOverlay = MIL.MdispInquire(m_MilDisp, MIL.M_OVERLAY_ID)





        DrawLines()




        Dim nLine As Integer
        Dim nCamID As Integer

        If m_nCamIndex < 2 Then
            nLine = LINE.A
        Else
            nLine = LINE.B
        End If

        nCamID = m_nCamIndex Mod 2




        txtResX.Text = CStr(pCurSystemParam.dVisionScaleX(nLine, nCamID))
        txtResY.Text = CStr(pCurSystemParam.dVisionScaleY(nLine, nCamID))
#End If
    End Sub


    Private Sub DrawLines()
        Dim i As Integer
        Dim str As String

        MIL.MdispControl(m_MilDisp, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT)

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_GREEN)

        For i = 0 To 3
            MIL.MgraLine(MIL.M_DEFAULT, m_MilOverlay, m_LinePos(i).pt1.X, m_LinePos(i).pt1.Y, m_LinePos(i).pt2.X, m_LinePos(i).pt2.Y)
        Next

        MIL.MgraColor(MIL.M_DEFAULT, MIL.M_COLOR_YELLOW)

        str = "X Pixel : " + CStr(m_LinePos(LINEPOS.RIGHT).pt1.X - m_LinePos(LINEPOS.LEFT).pt1.X + 1)
        MIL.MgraText(MIL.M_DEFAULT, m_MilOverlay, 20, 20, str)


        str = "Y Pixel : " + CStr(m_LinePos(LINEPOS.BOTTOM).pt1.Y - m_LinePos(LINEPOS.TOP).pt1.Y + 1)
        MIL.MgraText(MIL.M_DEFAULT, m_MilOverlay, 20, 40, str)

    End Sub

    ' #####################################################
    ' 이 루틴은 테스트용도로만 사용할것.
    ' 실제 m_MilDispImg 해제하면 안됨.
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dlg As New OpenFileDialog



        dlg.Filter = "All Image Files|*.*|JPEG File|*.jpg|BMP File|*.bmp"


        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If (m_MilDispImg <> MIL.M_NULL) Then
                MIL.MbufFree(m_MilDispImg)
            End If


            MIL.MbufRestore(dlg.FileName, m_MilSystem, m_MilDispImg)
            MIL.MdispSelectWindow(m_MilDisp, m_MilDispImg, pnlCam.Handle)


            If m_MilDispImg <> MIL.M_NULL Then
                m_CamX = MIL.MbufInquire(m_MilDispImg, MIL.M_SIZE_X)
                m_CamY = MIL.MbufInquire(m_MilDispImg, MIL.M_SIZE_Y)
            End If

        End If
    End Sub


    Private Sub btnSizeLR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSizeLR.Click
        If m_nMoveSize(0) = 1 Then
            m_nMoveSize(0) = 5
        ElseIf m_nMoveSize(0) = 5 Then
            m_nMoveSize(0) = 10
        ElseIf m_nMoveSize(0) = 10 Then
            m_nMoveSize(0) = 50
        ElseIf m_nMoveSize(0) = 50 Then
            m_nMoveSize(0) = 100
        ElseIf m_nMoveSize(0) = 100 Then
            m_nMoveSize(0) = 1
        End If

        btnSizeLR.Text = CStr(m_nMoveSize(0))

    End Sub

    Private Sub btnSizeUD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSizeUD.Click
        If m_nMoveSize(1) = 1 Then
            m_nMoveSize(1) = 5
        ElseIf m_nMoveSize(1) = 5 Then
            m_nMoveSize(1) = 10
        ElseIf m_nMoveSize(1) = 10 Then
            m_nMoveSize(1) = 50
        ElseIf m_nMoveSize(1) = 50 Then
            m_nMoveSize(1) = 100
        ElseIf m_nMoveSize(1) = 100 Then
            m_nMoveSize(1) = 1
        End If

        btnSizeUD.Text = CStr(m_nMoveSize(1))
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        Dim nIndex As Integer
        Dim nAmount As Integer

        If rdoLeft.Checked = True Then
            ' 왼쪽 직선 이동
            nIndex = LINEPOS.LEFT
        Else
            ' 오른쪽 직선 이동
            nIndex = LINEPOS.RIGHT
        End If

        nAmount = CInt(btnSizeLR.Text)

        m_LinePos(nIndex).pt1.X = m_LinePos(nIndex).pt1.X - nAmount

        If m_LinePos(nIndex).pt1.X < 0 Then
            m_LinePos(nIndex).pt1.X = 0
        End If

        m_LinePos(nIndex).pt2.X = m_LinePos(nIndex).pt1.X

        DrawLines()
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        Dim nIndex As Integer
        Dim nAmount As Integer

        If rdoLeft.Checked = True Then
            ' 왼쪽 직선 이동
            nIndex = LINEPOS.LEFT
        Else
            ' 오른쪽 직선 이동
            nIndex = LINEPOS.RIGHT
        End If

        nAmount = CInt(btnSizeLR.Text)

        m_LinePos(nIndex).pt1.X = m_LinePos(nIndex).pt1.X + nAmount

        If m_LinePos(nIndex).pt1.X > m_CamX - 1 Then
            m_LinePos(nIndex).pt1.X = m_CamX - 1
        End If

        m_LinePos(nIndex).pt2.X = m_LinePos(nIndex).pt1.X

        DrawLines()
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim nIndex As Integer
        Dim nAmount As Integer

        If rdoTop.Checked = True Then
            ' 위쪽 직선 이동
            nIndex = LINEPOS.TOP
        Else
            ' 아래쪽 직선 이동
            nIndex = LINEPOS.BOTTOM
        End If

        nAmount = CInt(btnSizeUD.Text)

        m_LinePos(nIndex).pt1.Y = m_LinePos(nIndex).pt1.Y - nAmount

        If m_LinePos(nIndex).pt1.Y < 0 Then
            m_LinePos(nIndex).pt1.Y = 0
        End If

        m_LinePos(nIndex).pt2.Y = m_LinePos(nIndex).pt1.Y

        DrawLines()
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim nIndex As Integer
        Dim nAmount As Integer

        If rdoTop.Checked = True Then
            ' 위쪽 직선 이동
            nIndex = LINEPOS.TOP
        Else
            ' 아래쪽 직선 이동
            nIndex = LINEPOS.BOTTOM
        End If

        nAmount = CInt(btnSizeUD.Text)

        m_LinePos(nIndex).pt1.Y = m_LinePos(nIndex).pt1.Y + nAmount

        If m_LinePos(nIndex).pt1.Y > m_CamY - 1 Then
            m_LinePos(nIndex).pt1.Y = m_CamY - 1
        End If

        m_LinePos(nIndex).pt2.Y = m_LinePos(nIndex).pt1.Y

        DrawLines()
    End Sub



    Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
        Dim dResX As Double
        Dim dResY As Double

        If Trim(txtObjX.Text) = "" Or IsNumeric(txtObjX.Text) = False Then
            MsgBox("Put number in Object X ")
            Exit Sub
        End If

        If Trim(txtObjY.Text) = "" Or IsNumeric(txtObjY.Text) = False Then
            MsgBox("Put number in Object Y ")
            Exit Sub
        End If


        dResX = CDbl(txtObjX.Text) / CDbl(m_LinePos(LINEPOS.RIGHT).pt1.X - m_LinePos(LINEPOS.LEFT).pt1.X + 1)
        dResY = CDbl(txtObjY.Text) / CDbl(m_LinePos(LINEPOS.BOTTOM).pt1.Y - m_LinePos(LINEPOS.TOP).pt1.Y + 1)

        txtResX.Text = CStr(dResX)
        txtResY.Text = CStr(dResY)


    End Sub

    Private Sub rdoCam1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCam1.CheckedChanged
        If m_MilSystem = MIL.M_NULL Then
            Exit Sub
        End If

        If rdoCam1.Checked = True Then
            ChangeCam(0)
        End If

    End Sub

    Private Sub rdoCam2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCam2.CheckedChanged
        If m_MilSystem = MIL.M_NULL Then
            Exit Sub
        End If

        If rdoCam2.Checked = True Then
            ChangeCam(1)
        End If
    End Sub

    Private Sub rdoCam3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCam3.CheckedChanged
        If m_MilSystem = MIL.M_NULL Then
            Exit Sub
        End If

        If rdoCam3.Checked = True Then
            ChangeCam(2)
        End If
    End Sub

    Private Sub rdoCam4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCam4.CheckedChanged
        If m_MilSystem = MIL.M_NULL Then
            Exit Sub
        End If

        If rdoCam4.Checked = True Then
            ChangeCam(3)
        End If
    End Sub



    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        On Error GoTo SysErr

        Dim nLine As Integer
        Dim nCamID As Integer

        If m_nCamIndex < 2 Then
            nLine = LINE.A
        Else
            nLine = LINE.B
        End If

        nCamID = m_nCamIndex Mod 2



        pSetSystemParam.dVisionScaleX(nLine, nCamID) = CDbl(txtResX.Text)
        pSetSystemParam.dVisionScaleY(nLine, nCamID) = CDbl(txtResY.Text)

        pCurSystemParam.dVisionScaleX(nLine, nCamID) = pSetSystemParam.dVisionScaleX(nLine, nCamID)
        pCurSystemParam.dVisionScaleY(nLine, nCamID) = pSetSystemParam.dVisionScaleY(nLine, nCamID)

        modParam.SaveParam(pStrTmpSystemRoot, pSetSystemParam)


        Exit Sub
SysErr:

    End Sub
End Class