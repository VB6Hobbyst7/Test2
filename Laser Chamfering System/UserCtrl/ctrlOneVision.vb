Imports System.Runtime.InteropServices

#If SIMUL <> 1 Then
Imports Matrox.MatroxImagingLibrary
#End If

Public Class ctrlOneVision
    Public m_iLine As Integer       ' 0, 1      a, b line
    Public m_iIndex As Integer      ' 0, 1      2 cam
    Public m_iCameraNo As Integer

    ' MIL
    Private mCamLiveWnd As LiveImageWnd '= Nothing

    'Public mCamLiveWnd As LiveImageWnd '= Nothing

    Private m_bMeasureMode As Boolean  ' 마우스drag로 measure 측정 중인가?
    Public m_iLightCh As Integer = 0

    Public bAlignSearchAreaSet As Boolean = False
    Public bAlignMarkSetArea As Boolean = False


    'Public bMark1 As Boolean = False
    'Public bMark2 As Boolean = False
    Public nDisplayFirstPosX As Integer = 0
    Public nDisplayFirstPosY As Integer = 0
    Public nDisplaySecondPosX As Integer = 0
    Public nDisplaySecondPosY As Integer = 0

    Dim bMeasureMode As Boolean = False
    Dim bMouseDown As Boolean = False
    Dim tmpMovePosX As Double = 0
    Dim tmpMovePosY As Double = 0

    Dim tmpSize As Double = 0
    Dim tmpLinePos As Integer = 0
    Dim bArrVisionCross(5) As Boolean

    Dim bZoom As Boolean = False
    Dim nManualZoomOffsetX As Integer = 0
    Dim nManualZoomOffsetY As Integer = 0



    Public Sub SetLightChannel(ByVal ch As Integer)
        m_iLightCh = ch
    End Sub

    Public Sub SetDrawingMode(ByVal nDrawingMode As Integer)
        mCamLiveWnd.m_iDrawingMode = nDrawingMode
    End Sub

    Private Sub DrawCross(ByVal bDraw As Boolean)
        modPub.SystemLog("frmVision -- btnCross_Click")

#If SIMUL <> 1 Then

        'pMilProcessor.DrawCross(pMilInterface.dispImage,  

        'If bArrVisionCross(0) = True Then
        '    ClearDisplay(pnlDisplay, MGraphicContext_A1, Color.Orange, False)
        '    bArrVisionCross(0) = False
        'ElseIf bArrVisionCross(0) = False Then
        '    ClearDisplay(pnlDisplay, MGraphicContext_A1, Color.Orange)
        '    bArrVisionCross(0) = True
        'End If

#End If

        Exit Sub
    End Sub

    Public Sub SetManualVisionMode(ByVal nMode As Integer)
        On Error GoTo SysErr
        mCamLiveWnd.m_pVisionMode = nMode 
        Exit Sub
SysErr:

    End Sub


    Private Sub btnMeasure_Click(sender As System.Object, e As System.EventArgs) Handles btnMeasure.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmVision -- btnMeasure_Click")

        SetManualVisionMode(1)

        'Dim bResult As Boolean = False
        'Dim nMark As Integer = 0

        'Select Case m_iCameraNo

        '    Case 0, 2
        '        nMark = 0
        '    Case 1, 3
        '        nMark = 1
        'End Select

        'bResult = modVision.FindModel(m_iCameraNo, pMF_Result, 99, m_iLine, 0, nMark)

        'If bResult = True Then
        '    MsgBox(pMF_Result.Score)

        'End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmVision -- btnMeasure_Click")

    End Sub

    Private Sub btnAllStop_Click(sender As System.Object, e As System.EventArgs) Handles btnAllStop.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmVision - btnAllStop_Click")

        pLDLT.StopAll()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmVision -- btnAllStop_Click")

    End Sub

    Private Sub btnMovePosX_Click(sender As System.Object, e As System.EventArgs) Handles btnMovePosX.Click

        pLDLT.MoveStage(m_iLine, Axis.x, numMovePosX.Value * 1000)

    End Sub

    Private Sub btnMovePosY_Click(sender As System.Object, e As System.EventArgs) Handles btnMovePosY.Click

        pLDLT.MoveStage(m_iLine, Axis.y, numMovePosY.Value * 1000)

    End Sub

    Private Sub btnMoveCameraPosZ_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveCameraPosZ.Click

        Dim nAxis As Integer = Axis.cam_z

        pLDLT.MoveStage(m_iLine, nAxis, numMoveCameraPosZ.Value * 1000)

    End Sub


    Private Sub btnMoveScannerPosZ_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveScannerPosZ.Click
        Try

            If cmbLaser.SelectedIndex < 0 Then
                Return
            End If

            pLDLT.MoveScannerZ(cmbLaser.SelectedIndex, numMoveScannerPosZ.Value * 1000)

        Catch ex As Exception
            Throw New ApplicationException("Error: " & ex.Message, ex)
        End Try

    End Sub


    Private Sub btnStopPosX_Click(sender As System.Object, e As System.EventArgs) Handles btnStopPosX.Click
        pLDLT.StopStage(m_iLine, Axis.x)
    End Sub

    Private Sub btnStopPosY_Click(sender As System.Object, e As System.EventArgs) Handles btnStopPosY.Click
        pLDLT.StopStage(m_iLine, Axis.y)
    End Sub

    Private Sub btnStopCameraPosZ_Click(sender As System.Object, e As System.EventArgs) Handles btnStopCameraPosZ.Click
        Dim nZAxis As Integer = Axis.cam_z
        
        pLDLT.StopStage(m_iLine, nZAxis)
    End Sub

    Private Sub btnStopScannerPosZ_Click(sender As System.Object, e As System.EventArgs) Handles btnStopScannerPosZ.Click
        For nScanner As Integer = 0 To 3
            pLDLT.StopScannerZ(nScanner)
        Next
    End Sub

    Private Sub chkBinarize_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBinarize.CheckedChanged

    End Sub

    Private Sub ctrlOneVision_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        If bLogInUser = True Or bLogInTech = True Then
            gbMotion.Enabled = False
        ElseIf bLogInAdmin = True Then
            gbMotion.Enabled = True
        End If

#If SIMUL <> 1 Then
        pnlDisplay.Width = pMilInterface.DigSizeX(0) / 2
        pnlDisplay.Height = pMilInterface.DigSizeY(0) / 2

        SetDisplayWnd(m_iCameraNo, pnlDisplay)

        'BtnImgSave.Visible = False
        'BtnImgLoad.Visible = False

#End If

        ' 20180320 ksy

        If modPub.bLogInAdmin Then
            btnMeasureRes.Visible = True
        Else
            btnMeasureRes.Visible = False
        End If

    End Sub

    Public Sub Init()
        ' camera no
        If m_iLine = LINE.A Then
            If m_iIndex = 0 Then
                m_iCameraNo = _CAMERA.A_CAMERA_1
            ElseIf m_iIndex = 1 Then
                m_iCameraNo = _CAMERA.A_CAMERA_2
            End If
        ElseIf m_iLine = LINE.B Then
            If m_iIndex = 0 Then
                m_iCameraNo = _CAMERA.B_CAMERA_1
            ElseIf m_iIndex = 1 Then
                m_iCameraNo = _CAMERA.B_CAMERA_2
            End If
        End If

        SetLightChannel(pnLightCh(m_iLine, m_iLightCh))

    End Sub


    Private Sub ctrlOneVision_VisibleChanged(sender As Object, e As System.EventArgs) Handles MyBase.VisibleChanged
        If Visible Then

            If pLight.IsOpen() = True Then

                pLight.GetLight(0, 0)

                Select Case m_iLightCh
                    Case 1
                        numLight.Value = pLight.m_nLightVal(0)
                        tbLight.Value = pLight.m_nLightVal(0)
                        numLight2.Value = pLight.m_nLightVal(4)
                        tbLight2.Value = pLight.m_nLightVal(4)

                    Case 2
                        numLight.Value = pLight.m_nLightVal(1)
                        tbLight.Value = pLight.m_nLightVal(1)
                        numLight2.Value = pLight.m_nLightVal(5)
                        tbLight2.Value = pLight.m_nLightVal(5)

                    Case 3
                        numLight.Value = pLight.m_nLightVal(2)
                        tbLight.Value = pLight.m_nLightVal(2)
                        numLight2.Value = pLight.m_nLightVal(6)
                        tbLight2.Value = pLight.m_nLightVal(6)

                    Case 4
                        numLight.Value = pLight.m_nLightVal(3)
                        tbLight.Value = pLight.m_nLightVal(3)
                        numLight2.Value = pLight.m_nLightVal(7)
                        tbLight2.Value = pLight.m_nLightVal(7)

                End Select

            End If

#If SIMUL <> 1 Then
            'labelExposureTime.Text = pCamera(m_iCameraNo).getExposureTimeSec().ToString
#End If
           
        Else

            End If

    End Sub


    Private Sub numLight_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numLight.ValueChanged
        On Error GoTo SysErr

        pLight.SetLight(m_iLightCh, numLight.Value)
        pLight.ctlLightVal(m_iLightCh) = numLight.Value
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmVision -- numLight_ValueChanged")
    End Sub

    Private Sub numLight2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numLight2.ValueChanged
        On Error GoTo SysErr

        pLight.SetLight(m_iLightCh + 4, numLight2.Value)
        pLight.ctlLightVal(m_iLightCh + 4) = numLight2.Value
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmVision -- numLight2_ValueChanged")
    End Sub

    Private Sub tbLight_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLight.Scroll
        On Error GoTo SysErr
        numLight.Value = tbLight.Value
        pLight.ctlLightVal(m_iLightCh) = tbLight.Value
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmVision -- tbLight_Scroll")
    End Sub

    Private Sub tbLight2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLight2.Scroll
        On Error GoTo SysErr
        numLight2.Value = tbLight2.Value
        pLight.ctlLightVal(m_iLightCh + 4) = tbLight2.Value
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmVision -- tbLight2_Scroll")
    End Sub


    Private Sub btnCross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCross.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmVision -- btnCross_Click")

#If SIMUL <> 1 Then

        Dim zoomX As Double = CDbl(RectSizeWnd.Width) / CDbl(pMilInterface.DigSizeX(m_iCameraNo))
        Dim zoomY As Double = CDbl(RectSizeWnd.Height) / CDbl(pMilInterface.DigSizeY(m_iCameraNo))
        mCamLiveWnd.SetZoomFactor(zoomX, zoomY)
#End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmVision -- btnCross_Click")

    End Sub



    Dim nTmpPosX As Integer = 0
    Dim nTmpPosY As Integer = 0

    Dim tmpAlignSearchStartPosX As Integer = 0
    Dim tmpAlignSearchStartPosY As Integer = 0
    Dim tmpAlignSearchEndPosX As Integer = 0
    Dim tmpAlignSearchEndPosY As Integer = 0

    Dim tmpAlignMarkStartPosX As Integer = 0
    Dim tmpAlignMarkStartPosY As Integer = 0
    Dim tmpAlignMarkEndPosX As Integer = 0
    Dim tmpAlignMarkEndPosY As Integer = 0

    Private Sub DisplayMouseDown(ByVal ipMousePosX As Integer, ByVal ipMousePosY As Integer)
        On Error GoTo SysErr

#If HEAD_2 Then
        If bAlignSearchAreaSet = True Or bAlignMarkSetArea = True Or bMeasureMode = True Or frmSequence_2Head.nManualAlign(0) = 1 Or frmSequence_2Head.nManualAlign(1) = 1 Then
            nDisplayFirstPosX = ipMousePosX
            nDisplayFirstPosY = ipMousePosY
            bMouseDown = True
        End If
#Else
        If bAlignSearchAreaSet = True Or bAlignMarkSetArea = True Or bMeasureMode = True Or frmSequence.nManualAlign(0) = 1 Or frmSequence.nManualAlign(1) = 1 Then
            nDisplayFirstPosX = ipMousePosX
            nDisplayFirstPosY = ipMousePosY
            bMouseDown = True
        End If
#End If

        Exit Sub
SysErr:

    End Sub

    Private Sub SetAlignSearchArea(ByRef ipAlignMarkData As AlignData, Optional ByVal bSetSearchArea As Boolean = True)
        On Error GoTo SysErr
        If bSetSearchArea = True Then
            SetVisionPositionData(tmpAlignSearchStartPosX, tmpAlignSearchEndPosX, ipAlignMarkData.nAlignMark_SearchOffsetX, _
                                  ipAlignMarkData.nAlignMark_SearchSizeX)
            SetVisionPositionData(tmpAlignSearchStartPosY, tmpAlignSearchEndPosY, ipAlignMarkData.nAlignMark_SearchOffsetY, _
                                  ipAlignMarkData.nAlignMark_SearchSizeY)
        ElseIf bSetSearchArea = False Then
            SetVisionPositionData(tmpAlignMarkStartPosX, tmpAlignMarkEndPosX, ipAlignMarkData.nAlignMark_ModelOffsetX, _
                                  ipAlignMarkData.nAlignMark_ModelSizeX)
            SetVisionPositionData(tmpAlignMarkStartPosY, tmpAlignMarkEndPosY, ipAlignMarkData.nAlignMark_ModelOffsetY, _
                                  ipAlignMarkData.nAlignMark_ModelSizeY)
        End If
  

        Exit Sub
SysErr:

    End Sub

    Private Sub SetVisionPositionData(ByVal ipPos1 As Integer, ByVal ipPos2 As Integer, ByRef Offset As Integer, ByRef Size As Integer)
        On Error GoTo SysErr
        If ipPos1 <= ipPos2 Then
            Offset = ipPos1
            Size = ipPos2 - ipPos1
        Else
            Offset = ipPos2
            Size = ipPos1 - ipPos2
        End If
        Exit Sub
SysErr:

    End Sub

    Private Sub SetMarkSize(ByRef ipSizeX As Integer, ByRef ipSizeY As Integer)
        On Error GoTo SysErr
        'If pVisionMarkNum = AlignMarkNum.A1_L1_M1 Then
        '    ipSizeX = pMark1_Data_A1_L1.nAlignMark_ModelSizeX
        '    ipSizeY = pMark1_Data_A1_L1.nAlignMark_ModelSizeY
        'ElseIf pVisionMarkNum = AlignMarkNum.A1_L2_M1 Then
        '    ipSizeX = pMark1_Data_A1_L2.nAlignMark_ModelSizeX
        '    ipSizeY = pMark1_Data_A1_L2.nAlignMark_ModelSizeY
  
        'End If
        Exit Sub
SysErr:

    End Sub

    Private Sub DrawAlignMarkRectPosition(ByVal ipCenterPosX As Integer, ByVal ipCenterPosY As Integer, ByVal ipSizeX As Integer, ByVal ipSizeY As Integer, _
                                          ByRef outFirstPosX As Integer, ByRef outFirstPosY As Integer, ByRef outSecPosX As Integer, ByRef outSecPosY As Integer)
        On Error GoTo SysErr

        If ipCenterPosX - (ipSizeX / 2) < 1 Then
            outFirstPosX = 0
        Else
            outFirstPosX = ipCenterPosX - (ipSizeX / 2)
        End If

        If ipCenterPosY - (ipSizeY / 2) < 1 Then
            outFirstPosY = 0
        Else
            outFirstPosY = ipCenterPosY - (ipSizeY / 2)
        End If

        If ipCenterPosX + (ipSizeX / 2) > 1340 Then
            outFirstPosX = 1340 - ipSizeX
            outSecPosX = 1340
        Else
            outSecPosX = ipCenterPosX + (ipSizeX / 2)
        End If

        If ipCenterPosY + (ipSizeY / 2) > 1040 Then
            outFirstPosY = 1040 - ipSizeY
            outSecPosY = 1040
        Else
            outSecPosY = ipCenterPosY + (ipSizeY / 2)
        End If

        If outFirstPosX = 0 Then
            outSecPosX = ipSizeX
        End If

        If outFirstPosY = 0 Then
            outSecPosY = ipSizeY
        End If

        Exit Sub
SysErr:

    End Sub

    Private RectSizeWnd As New Rectangle()

    Sub SetDisplayWnd(ByVal nCamera As Integer, ByVal Display As System.Windows.Forms.Panel)

        RectSizeWnd.X = 0
        RectSizeWnd.Y = 0

        RectSizeWnd.Width = Display.Width
        RectSizeWnd.Height = Display.Height

        If mCamLiveWnd IsNot Nothing Then
            mCamLiveWnd.Close()
            mCamLiveWnd.Dispose()
            mCamLiveWnd = Nothing
        End If
        If mCamLiveWnd IsNot Nothing Then
            mCamLiveWnd.Close()
        End If
#If SIMUL <> 1 Then
        mCamLiveWnd = New LiveImageWnd(RectSizeWnd, Me.Handle, pMilInterface.MilSystem, pMilInterface.dispImage(nCamera), pMilInterface.MilModResult(nCamera))
        mCamLiveWnd.SetCameraNo(nCamera)

        Display.Controls.Clear()
        Display.Controls.Add(mCamLiveWnd)

        Dim zoomX As Double = CDbl(RectSizeWnd.Width) / CDbl(pMilInterface.DigSizeX(nCamera))
        Dim zoomY As Double = CDbl(RectSizeWnd.Height) / CDbl(pMilInterface.DigSizeY(nCamera))
        mCamLiveWnd.SetZoomFactor(zoomX, zoomY)

        mCamLiveWnd.Show()
#End If

    End Sub

    Public Sub LoadImageFile(ByVal strPath As String)
        Try
#If SIMUL <> 1 Then
            Dim roi_mark_area As MIL_ID

            Dim nMilIndex As Integer = 1
            nMilIndex = m_iIndex + m_iLine * 2

            nMilIndex = 1

            'roi_mark_area = pMilInterface.dispImage(nMilIndex)
            roi_mark_area = pMilInterface.dispImageChild(nMilIndex) '     dispImage(nMilIndex)

            'pMilProcessor(nMilIndex).LoadImage(strPath, modVision.pMilInterface(nMilIndex).dispImage(nMilIndex), pMilInterface(nMilIndex).MilSystem)
            pMilProcessor.LoadImage(strPath, modVision.pMilInterface.dispImage(nMilIndex), pMilInterface.MilSystem)
#End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub DrawROIRect(nX, nY, nW, nH)

#If SIMUL <> 1 Then
        mCamLiveWnd.DrawROIRect(nX, nY, nW, nH)
#End If

    End Sub

    Public Sub DrawMarkRect(nX, nY, nW, nH)

#If SIMUL <> 1 Then
        mCamLiveWnd.DrawRect(nX, nY, nW, nH, Color.Lime)
#End If

    End Sub

    Private Sub BtnImgSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnImgSave.Click

        Dim tmpSavePath As String = ""
#If SIMUL <> 1 Then
        tmpSavePath = "D:\\TestImage" & CInt(m_iCameraNo) & ".jpg"
        'pMilProcessor.SaveImage(pMilInterface.dispImage(m_iCameraNo), MIL.M_BMP, 1, tmpSavePath)
        pMilProcessor.SaveImage(pMilInterface.dispImage(m_iCameraNo), MIL.M_JPEG_LOSSY, 5, tmpSavePath)
#End If

    End Sub

    Private Sub BtnImgLoad_Click(sender As System.Object, e As System.EventArgs) Handles BtnImgLoad.Click

        modPub.SystemLog("frmRecipe - btnMarkDataPath_A1_Click")
        Dim OpenFile As New OpenFileDialog
        Dim strPath As String = ""
        Dim tmpStr() As String = {}

        'OpenFile.InitialDirectory = pCurRecipe.strTmpRecipePath & "\" & pCurRecipe.strRecipeName & "\Mark Data"

        OpenFile.Filter = "Bmp files (*.Bmp)|*.Bmp|All files (*.*)|*.*"
        OpenFile.ShowDialog()
        strPath = OpenFile.FileName
        If strPath = "" Then Exit Sub

        OpenFile.Dispose()

#If SIMUL <> 1 Then
        pMilProcessor.LoadImage(strPath, pMilInterface.dispImage(m_iCameraNo), pMilInterface.MilSystem)
        mCamLiveWnd.ChangeDisplayImage(pMilInterface.dispImage(m_iCameraNo))
#End If

        'New연산자 해제
        OpenFile = Nothing

    End Sub

    Public Sub LiveZoom(ByVal dZoomX As Double, ByVal dZoomY As Double)

#If SIMUL <> 1 Then
        mCamLiveWnd.SetZoomFactor(dZoomX, dZoomY)
#End If

    End Sub

    Private Sub BtnTest_Click(sender As System.Object, e As System.EventArgs) Handles BtnTest.Click


        Dim m_ptStart As Point
        Dim m_ptEnd As Point

        m_ptStart.X = 10
        m_ptStart.Y = 9
        m_ptEnd.X = 8
        m_ptEnd.Y = 7

        'frmRecipe.m_CurAlignMarkSetting(0).UpdateRectInfo(m_ptStart, m_ptEnd)


    End Sub

    Private Sub btnExposureTime_Click(sender As System.Object, e As System.EventArgs) Handles btnExposureTime.Click

        Dim dValue As Double = 0.0

        dValue = NumExposureTime.Value

#If SIMUL <> 1 Then
        'pCamera(m_iCameraNo).setExposureTime(dValue)
#End If

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbBinarize.Text = My.Resources.setLan.ResourceManager.GetObject("BINARIZE")
            .chkBinarize.Text = My.Resources.setLan.ResourceManager.GetObject("UseBinarize")
            .btnBinarize.Text = My.Resources.setLan.ResourceManager.GetObject("Set")
            .btnMeasure.Text = My.Resources.setLan.ResourceManager.GetObject("Measure")
            .gbLightCh1.Text = My.Resources.setLan.ResourceManager.GetObject("BoxLight")
            .GroupBox1.Text = My.Resources.setLan.ResourceManager.GetObject("SpotLight")
            .gbMotion.Text = My.Resources.setLan.ResourceManager.GetObject("MotionABSMOVE")
            .btnMovePosX.Text = My.Resources.setLan.ResourceManager.GetObject("Move")
            .btnMovePosY.Text = My.Resources.setLan.ResourceManager.GetObject("Move")
            .btnStopPosX.Text = My.Resources.setLan.ResourceManager.GetObject("Stop1")
            .btnStopPosY.Text = My.Resources.setLan.ResourceManager.GetObject("Stop1")
            .lblStageVision.Text = My.Resources.setLan.ResourceManager.GetObject("VisionZmm")
            .lblStageLaser.Text = My.Resources.setLan.ResourceManager.GetObject("LaserZmm")
            .btnMoveCameraPosZ.Text = My.Resources.setLan.ResourceManager.GetObject("Move")
            .btnMoveScannerPosZ.Text = My.Resources.setLan.ResourceManager.GetObject("Move")
            .btnStopCameraPosZ.Text = My.Resources.setLan.ResourceManager.GetObject("Stop1")
            .btnStopScannerPosZ.Text = My.Resources.setLan.ResourceManager.GetObject("Stop1")
            .btnAllStop.Text = My.Resources.setLan.ResourceManager.GetObject("StopAll")
            .BtnImgSave.Text = My.Resources.setLan.ResourceManager.GetObject("ImageSave")
            .BtnImgLoad.Text = My.Resources.setLan.ResourceManager.GetObject("ImageLoad")
            .BtnTest.Text = My.Resources.setLan.ResourceManager.GetObject("Test")

        End With

    End Sub

    Private m_MarkData As AlignData

    Public Sub DrawROI(ByVal nLine As Integer, ByVal nIndex As Integer)

        Dim nPanel As Integer = 0
        Dim nMark As Integer = 0
        Dim nInd As Integer = 0

        Dim nRecX As Integer = 0
        Dim nRecY As Integer = 0
        Dim nRecWidth As Integer = 0
        Dim nRecHeight As Integer = 0

        Select Case nLine
            Case 0
                Select Case nIndex
                    Case 0  'A라인 1번 판넬 1번 마크
                        nRecX = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 0, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'A라인 1번 판넬 2번 마크
                        nRecX = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 0, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 2  'A라인 2번 판넬 1번 마크
                        nRecX = pRcpMark_Data(0, 1, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 1, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 1, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 1, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 3  'A라인 2번 판넬 2번 마크
                        nRecX = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 1, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 4  'A라인 3번 판넬 1번 마크
                        nRecX = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 2, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 5  'A라인 3번 판넬 2번 마크
                        nRecX = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 2, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 6  'A라인 4번 판넬 1번 마크
                        nRecX = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 3, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 7  'A라인 4번 판넬 2번 마크
                        nRecX = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(0, 3, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

            Case 1
                Select Case nIndex
                    Case 0  'A라인 1번 판넬 1번 마크
                        nRecX = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 0, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'A라인 1번 판넬 2번 마크
                        nRecX = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 0, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 2  'A라인 2번 판넬 1번 마크
                        nRecX = pRcpMark_Data(1, 1, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 1, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 1, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 1, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 3  'A라인 2번 판넬 2번 마크
                        nRecX = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 1, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 4  'A라인 3번 판넬 1번 마크
                        nRecX = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 2, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 5  'A라인 3번 판넬 2번 마크
                        nRecX = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 2, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 6  'A라인 4번 판넬 1번 마크
                        nRecX = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 3, 0, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 7  'A라인 4번 판넬 2번 마크
                        nRecX = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchOffsetX
                        nRecY = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchOffsetY
                        nRecWidth = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchSizeX
                        nRecHeight = pRcpMark_Data(1, 3, 1, 0).nAlignMark_SearchSizeY
                        DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select
        End Select
    End Sub

    Private Sub btnMeasureRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMeasureRes.Click
        Dim frm As frmCamResolution
        frm = New frmCamResolution

#If SIMUL <> 1 Then
        frm.SetMILID(pMilInterface.MilSystem, m_iCameraNo)
#End If
        frm.Show()
    End Sub

    <DllImport("user32.dll")> _
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    End Function

    Private Sub Use_Light_Time_Click(sender As System.Object, e As System.EventArgs) Handles Use_Light_Time.Click
        Dim hw1 As Integer = FindWindow(Nothing, "Use Light Time Data")
        Dim form As New ctlUseLightTimeData

        If hw1 = 0 Then
            form.Show()
        End If
    End Sub
End Class

