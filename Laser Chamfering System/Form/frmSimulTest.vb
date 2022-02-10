#If SIMUL <> 1 Then
Imports Matrox.MatroxImagingLibrary
#End If

Public Class frmSimulTest
    Private m_iLine As Integer = 0


    Private Sub FindModel(ByVal nPanel As Integer, ByVal nMark As Integer)
        Dim strData As String
        Dim strLine(1) As String
        Dim str1 As String = ""
        Dim str2 As String = ""

        strLine(0) = "A"
        strLine(1) = "B"

        Select Case nMark
            Case 1
                'LoadImageFile(txtImg1.Text)
                modVision.FindModel(nPanel, pMF_Result(m_iLine, nPanel, nMark))
                strData = "Score : " & pMF_Result(m_iLine, nPanel, nMark).Score.ToString & vbCrLf
                strData = strData & "PositionDiffX : " & pMF_Result(m_iLine, nPanel, nMark).PositionDiffX.ToString & vbCrLf
                strData = strData & "PositionDiffY : " & pMF_Result(m_iLine, nPanel, nMark).positionDiffY.ToString & vbCrLf


                If pMF_Result(m_iLine, nPanel, nMark).bFindSuccess Then
                    pCurRecipe.AlignResult(m_iLine, nPanel).bGetMark1_OK = True
                    pCurRecipe.AlignResult(m_iLine, nPanel).dMark1DifferencePositionX = Math.Round((pMF_Result(m_iLine, nPanel, nMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, nMark) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, nMark)) - pMF_Result(m_iLine, nPanel, nMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, nMark) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, nMark))), 3)
                    pCurRecipe.AlignResult(m_iLine, nPanel).dMark1DifferencePositionY = Math.Round((pMF_Result(m_iLine, nPanel, nMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, nMark) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, nMark)) + pMF_Result(m_iLine, nPanel, nMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, nMark) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, nMark))), 3)
                End If
                ' FileCopy("C:\TEMP.jpg", pCurSystemParam.strAlignImagePath(m_iLine) & "\OK\" & Format(Now, "yyyy-MM-dd") & "\" & strLine(m_iLine) & (nPanel + 1).ToString & "_Mark" & (nMark + 1).ToString & Format(Now, "_HH_mm_ss") & ".jpg")


                If pCurRecipe.AlignResult(m_iLine, nPanel).bGetMark1_OK = True Then
                    str1 = "OK" & vbCrLf
                Else
                    str1 = "NG" & vbCrLf
                End If
                str1 = strData & str1 & pCurRecipe.AlignResult(m_iLine, nPanel).dMark1DifferencePositionX.ToString & vbCrLf & pCurRecipe.AlignResult(m_iLine, nPanel).dMark1DifferencePositionY.ToString & vbCrLf
            Case 2
                'LoadImageFile(txtImg2.Text)
                modVision.FindModel(nPanel, pMF_Result(m_iLine, nPanel, nMark))
                strData = ""
                strData = "Score : " & pMF_Result(m_iLine, nPanel, nMark).Score.ToString & vbCrLf
                strData = strData & "PositionDiffX : " & pMF_Result(m_iLine, nPanel, nMark).PositionDiffX.ToString & vbCrLf
                strData = strData & "PositionDiffY : " & pMF_Result(m_iLine, nPanel, nMark).positionDiffY.ToString & vbCrLf
                nMark = 1
                If pMF_Result(m_iLine, nPanel, nMark).bFindSuccess Then
                    pCurRecipe.AlignResult(m_iLine, nPanel).bGetMark2_OK = True
                    pCurRecipe.AlignResult(m_iLine, nPanel).dMark2DifferencePositionX = Math.Round((pMF_Result(m_iLine, nPanel, nMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, nMark) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, nMark)) - pMF_Result(m_iLine, nPanel, nMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, nMark) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, nMark))), 3)
                    pCurRecipe.AlignResult(m_iLine, nPanel).dMark2DifferencePositionY = Math.Round((pMF_Result(m_iLine, nPanel, nMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, nMark) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, nMark)) + pMF_Result(m_iLine, nPanel, nMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, nMark) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, nMark))), 3)
                End If

                If pCurRecipe.AlignResult(m_iLine, nPanel).bGetMark2_OK = True Then
                    str2 = "OK" & vbCrLf
                Else
                    str2 = "NG" & vbCrLf
                End If
                str2 = strData & vbCrLf & str2 & vbCrLf & pCurRecipe.AlignResult(m_iLine, nPanel).dMark2DifferencePositionX.ToString & vbCrLf & pCurRecipe.AlignResult(m_iLine, nPanel).dMark2DifferencePositionY.ToString & vbCrLf

        End Select

        txtData.Clear()

        txtData.Text = str1 & str2


    End Sub

    Private Sub btnGrab1_Click(sender As System.Object, e As System.EventArgs) Handles btnGrab1.Click

        FindModel(Panel.p1, 1)

    End Sub


    Private Sub btnGrab2_Click(sender As System.Object, e As System.EventArgs) Handles btnGrab2.Click

        FindModel(1, 1)

    End Sub

    Private Sub btnGrab3_Click(sender As System.Object, e As System.EventArgs) Handles btnGrab3.Click
        FindModel(2, 1)

    End Sub

    Private Sub btnGrab4_Click(sender As System.Object, e As System.EventArgs) Handles btnGrab4.Click
        FindModel(3, 1)
    End Sub


    Private Sub rdoLineA_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoLineA.CheckedChanged
        If rdoLineA.Checked = True Then
            m_iLine = LINE.A
        Else
            m_iLine = LINE.B
        End If
    End Sub

    Private Sub rdoLineB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoLineB.CheckedChanged
        If rdoLineB.Checked = True Then
            m_iLine = LINE.B
        Else
            m_iLine = LINE.A
        End If
    End Sub

    Private Sub btnImgLoad1_Click(sender As System.Object, e As System.EventArgs) Handles btnImgLoad1.Click
        LoadImageFile(m_iLine, 0)
    End Sub

    Private Sub btnImgLoad2_Click(sender As System.Object, e As System.EventArgs) Handles btnImgLoad2.Click
        LoadImageFile(m_iLine, 1)
    End Sub

    Private Sub LoadImageFile(ByVal nLine As Integer, ByVal nMark As Integer)

        Dim OpenFile As New OpenFileDialog
        Dim strPath As String = ""
        Dim tmpStr() As String = {}

        OpenFile.InitialDirectory = pCurRecipe.strTmpRecipePath & "\" & pCurRecipe.strRecipeName & "\Mark Data"

        OpenFile.Filter = "bmp files (*.bmp)|*.bmp|All files (*.*)|*.*"
        OpenFile.ShowDialog()
        strPath = OpenFile.FileName
        If strPath = "" Then Exit Sub
        OpenFile.Dispose()

        'New연산자 해제
        OpenFile = Nothing

        If nMark = 0 Then
            txtImg1.Text = strPath  'tmpStr(tmpStr.Length - 1)
        End If
        If nMark = 1 Then
            txtImg2.Text = strPath  'tmpStr(tmpStr.Length - 1)
        End If



    End Sub


    Public Sub LoadImageFile(ByVal strPath As String)
        Try
#If SIMUL <> 1 Then
            Dim roi_mark_area As MIL_ID

            Dim nIndex As Integer = 0

            roi_mark_area = pMilInterface.dispImage(nIndex)
            'roi_mark_area = pMilInterface.AlignImage(nIndex) '     dispImage(nIndex)

            pMilProcessor.LoadImage(strPath, modVision.pMilInterface.dispImage(nIndex), pMilInterface.MilSystem)
#End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub CalcMarkingPos(ByVal nPanel As Integer)
        'CalcMarkingDataPosition
        'CalcMarkingDataPosition(pCurRecipe, pSetSystemParam, True)
        modVision.GetGlassCenter(m_iLine, nPanel, pCurRecipe, pSetSystemParam)

        Dim str As String
        str = "MarkDestPositionX : " & pCurRecipe.AlignResult(m_iLine, nPanel).dMarkDestPositionX.ToString & vbCrLf
        str = str & "MarkDestPositionY : " & pCurRecipe.AlignResult(m_iLine, nPanel).dMarkDestPositionY.ToString & vbCrLf
        str = str & "OffsetX : " & pCurRecipe.AlignResult(m_iLine, nPanel).dOffsetX.ToString & vbCrLf
        str = str & "OffsetY : " & pCurRecipe.AlignResult(m_iLine, nPanel).dOffsetY.ToString & vbCrLf

        txtMarkingPos.Clear()
        txtMarkingPos.Text = str

    End Sub



    Private Sub btnCalcMarkingPos1_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcMarkingPos1.Click
        CalcMarkingPos(Panel.p1)
    End Sub

    Private Sub btnCalcMarkingPos2_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcMarkingPos2.Click
        CalcMarkingPos(Panel.p2)

    End Sub

    Private Sub btnCalcMarkingPos3_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcMarkingPos3.Click
        CalcMarkingPos(Panel.p3)

    End Sub

    Private Sub btnCalcMarkingPos4_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcMarkingPos4.Click
        CalcMarkingPos(Panel.p4)

    End Sub


    '20161008 JCM Edit
    Dim tmpDiffX_1 As Double = 0
    Dim tmpDiffY_1 As Double = 0
    Dim tmpDiffX_2 As Double = 0
    Dim tmpDiffY_2 As Double = 0
    Dim tmpMoveValue As Double = 0
    Dim tmpDistance As Double = 0
    Dim tmpScale As Double = 0
    Dim tmpAngle As Double = 0

    Dim chkInput(60) As CheckBox
    Dim chkOutput(16) As CheckBox

   

    Public Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        For i = 0 To 60
            chkInput(i) = New CheckBox
            chkInput(i).Size = New System.Drawing.Size(260, 20)
            pnlInput.Controls.Add(chkInput(i))

            AddHandler chkInput(i).CheckedChanged, AddressOf chkInput_CheckedChanged

            ' chkOutput(i) = New CheckBox
            'pnlOutput.Controls.Add(chkOutput(i))
        Next

        chkInput(0).Text = "RB_PLC_AUTO_STATUS_A = &H301"
        chkInput(1).Text = "RB_PLC_MANUAL_STATUS_A = &H301"
        chkInput(2).Text = "RB_PLC_AUTO_STATUS_B = &H302"
        chkInput(3).Text = "RB_PLC_MANUAL_STATUS_B = &H303"

        chkInput(4).Text = "RB_PLC_MANUAL_PC_CONTROL = &H304"

        chkInput(5).Text = "RB_PLC_STAGE_USEABLE_A = &H305"
        chkInput(6).Text = "RB_PLC_STAGE_USEABLE_B = &H306"

        chkInput(7).Text = "RB_PLC_LIGHT_ALARM = &H30E"
        chkInput(8).Text = "RB_PLC_HEAVY_ALARM = &H30F"

        chkInput(9).Text = "RB_PLC_EXIST_A_1 = &H310"
        chkInput(10).Text = "RB_PLC_EXIST_A_2 = &H311"
        chkInput(11).Text = "RB_PLC_EXIST_A_3 = &H312"
        chkInput(12).Text = "RB_PLC_EXIST_A_4 = &H313"

        chkInput(13).Text = "RB_ALIGN_A_1_REQUEST = &H320"
        chkInput(14).Text = "RB_ALIGN_A_2_REQUEST = &H321"
        chkInput(15).Text = "RB_ALIGN_A_3_REQUEST = &H322"
        chkInput(16).Text = "RB_ALIGN_A_4_REQUEST = &H323"

        chkInput(17).Text = "RB_PLC_EXIST_B_1 = &H330"
        chkInput(18).Text = "RB_PLC_EXIST_B_2 = &H331"
        chkInput(19).Text = "RB_PLC_EXIST_B_3 = &H332"
        chkInput(20).Text = "RB_PLC_EXIST_B_4 = &H333"

        chkInput(21).Text = "RB_ALIGN_B_1_REQUEST = &H340"
        chkInput(22).Text = "RB_ALIGN_B_2_REQUEST = &H341"
        chkInput(23).Text = "RB_ALIGN_B_3_REQUEST = &H342"
        chkInput(24).Text = "RB_ALIGN_B_4_REQUEST = &H343"

        chkInput(25).Text = "RB_LASER_MARKING_START_A_1 = &H350"  'GYN - Trimming
        chkInput(26).Text = "RB_LASER_MARKING_START_A_2 = &H351"
        chkInput(27).Text = "RB_LASER_MARKING_START_A_3 = &H352"
        chkInput(28).Text = "RB_LASER_MARKING_START_A_4 = &H353"

        chkInput(29).Text = "RB_LASER_MARKING_START_B_1 = &H354"
        chkInput(30).Text = "RB_LASER_MARKING_START_B_2 = &H355"
        chkInput(31).Text = "RB_LASER_MARKING_START_B_3 = &H356"
        chkInput(32).Text = "RB_LASER_MARKING_START_B_4 = &H357"

        chkInput(33).Text = "RB_LASER_POWER_MEASURE_MODE_LASER1 = &H360"
        chkInput(34).Text = "RB_LASER_POWER_MEASURE_MODE_LASER2 = &H361"
        chkInput(35).Text = "RB_LASER_POWER_MEASURE_MODE_LASER3 = &H362"
        chkInput(36).Text = "RB_LASER_POWER_MEASURE_MODE_LASER4 = &H363"

        chkInput(37).Text = "RB_LASER_PASS_MODE_LASER1 = &H370"
        chkInput(38).Text = "RB_LASER_PASS_MODE_LASER2 = &H371"
        chkInput(38).Text = "RB_LASER_PASS_MODE_LASER3 = &H372"
        chkInput(40).Text = "RB_LASER_PASS_MODE_LASER4 = &H373"

        chkInput(41).Text = "RB_STAGE_A_X_MOVE_COMPLETE_REPORT = &H380"
        chkInput(42).Text = "RB_STAGE_A_Y_MOVE_COMPLETE_REPORT = &H381"
        chkInput(43).Text = "RB_CAMERA_Z1_A_MOVE_COMPLETE_REPORT = &H382"
        chkInput(44).Text = "RB_CAMERA_Z2_A_MOVE_COMPLETE_REPORT = &H383"

        chkInput(45).Text = "RB_STAGE_B_X_MOVE_COMPLETE_REPORT = &H390"
        chkInput(46).Text = "RB_STAGE_B_Y_MOVE_COMPLETE_REPORT = &H391"
        chkInput(47).Text = "RB_CAMERA_Z1_B_MOVE_COMPLETE_REPORT = &H392"
        chkInput(48).Text = "RB_CAMERA_Z2_B_MOVE_COMPLETE_REPORT = &H393"

        chkInput(49).Text = "RB_SCANNER_Z1_MOVE_COMPLETE_REPORT = &H384"
        chkInput(50).Text = "RB_SCANNER_Z2_MOVE_COMPLETE_REPORT = &H385"
        chkInput(51).Text = "RB_SCANNER_Z3_MOVE_COMPLETE_REPORT = &H386"
        chkInput(52).Text = "RB_SCANNER_Z4_MOVE_COMPLETE_REPORT = &H387"

        chkInput(53).Text = "RB_LASER_A_STAGE_HOME_X = &H3A0"
        chkInput(54).Text = "RB_LASER_A_STAGE_HOME_Y= &H3A1"
        chkInput(55).Text = "RB_LASER_B_STAGE_HOME_X = &H3A2"
        chkInput(56).Text = "RB_LASER_B_STAGE_HOME_Y = &H3A3"

        chkInput(57).Text = "RB_RECIPE_CHANGE_REQUEST = &H3E0"
        chkInput(58).Text = "RB_RECIPE_COPY_REQUEST = &H3E1"
        chkInput(59).Text = "RB_RECIPE_SAVE_COPY_REQUEST = &H3E2"

        chkInput(60).Text = "RB_TIME_SYNC_REQUEST = &H3F0"



    End Sub


    Public Sub chkInput_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim chkIn As CheckBox = sender
        If chkIn.Checked Then


            Select Case chkIn.Text

                Case "RB_PLC_AUTO_STATUS_A = &H300"
                    pLDLT.PLC_Infomation.bPLC_AutoMode(m_iLine) = True
                    pLDLT.PLC_Infomation.bPLC_ManualMode(m_iLine) = False
                Case "RB_PLC_MANUAL_STATUS_A = &H301"
                    pLDLT.PLC_Infomation.bPLC_ManualMode(m_iLine) = True
                    pLDLT.PLC_Infomation.bPLC_AutoMode(m_iLine) = False
                Case "RB_PLC_AUTO_STATUS_B = &H302"
                    pLDLT.PLC_Infomation.bPLC_AutoMode(m_iLine) = True
                    pLDLT.PLC_Infomation.bPLC_ManualMode(m_iLine) = False
                Case "RB_PLC_MANUAL_STATUS_B = &H303"
                    pLDLT.PLC_Infomation.bPLC_ManualMode(m_iLine) = True
                    pLDLT.PLC_Infomation.bPLC_AutoMode(m_iLine) = False
                Case "RB_PLC_MANUAL_PC_CONTROL = &H304"
                    pLDLT.PLC_Infomation.bStageManualControl = True
               
                    'B30A_PLC_ALIVE = 778       ' 20160928 ubslhi - 사용안함
                Case "RB_PLC_LIGHT_ALARM = &H30E"
                    pLDLT.PLC_Infomation.bPLC_LightAlarm = True
                Case "RB_PLC_HEAVY_ALARM = &H30F"
                    pLDLT.PLC_Infomation.bPLC_HeavyAlarm = True
                Case "RB_PLC_EXIST_A_1 = &H310"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 0) = True
                Case "RB_PLC_EXIST_A_2 = &H311"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 1) = True
                Case "RB_PLC_EXIST_A_3 = &H312"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 2) = True
                Case "RB_PLC_EXIST_A_4 = &H313"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 3) = True

                Case "RB_ALIGN_A_1_REQUEST = &H320"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 0) = True
                Case "RB_ALIGN_A_2_REQUEST = &H321"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 0) = True
                Case "RB_ALIGN_A_3_REQUEST = &H322"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 0) = True
                Case "RB_ALIGN_A_4_REQUEST = &H323"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 0) = True

                Case "RB_PLC_EXIST_B_1 = &H330"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 0) = True
                Case "RB_PLC_EXIST_B_2 = &H331"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 1) = True
                Case "RB_PLC_EXIST_B_3 = &H332"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 2) = True
                Case "RB_PLC_EXIST_B_4 = &H333"
                    pLDLT.PLC_Infomation.bGlassExist(m_iLine, 3) = True

                Case "RB_ALIGN_B_1_REQUEST = &H340"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 0) = True
                Case "RB_ALIGN_B_2_REQUEST = &H341"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 1) = True
                Case "RB_ALIGN_B_3_REQUEST = &H342"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 2) = True
                Case "RB_ALIGN_B_4_REQUEST = &H343"
                    pLDLT.PLC_Infomation.bAlignRequest(m_iLine, 3) = True

                Case "RB_LASER_MARKING_START_A_1 = &H350  'GYN - Trimming"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 0) = True
                Case "RB_LASER_MARKING_START_A_2 = &H351"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 1) = True
                Case "RB_LASER_MARKING_START_A_3 = &H352"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 2) = True
                Case "RB_LASER_MARKING_START_A_4 = &H353"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 3) = True

                Case "RB_LASER_MARKING_START_B_1 = &H354"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 0) = True
                Case "RB_LASER_MARKING_START_B_2 = &H355"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 1) = True
                Case "RB_LASER_MARKING_START_B_3 = &H356"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 2) = True
                Case "RB_LASER_MARKING_START_B_4 = &H357"
                    pLDLT.PLC_Infomation.bLaserMarkingRequest(m_iLine, 3) = True

                Case "RB_STAGE_A_X_MOVE_COMPLETE_REPORT = &H380"
                    pLDLT.PLC_Infomation.bMoveCompleteStageX(m_iLine) = True
                Case "RB_STAGE_A_Y_MOVE_COMPLETE_REPORT = &H381"
                    pLDLT.PLC_Infomation.bMoveCompleteStageY(m_iLine) = True
                Case "RB_CAMERA_Z1_A_MOVE_COMPLETE_REPORT = &H382"
                    pLDLT.PLC_Infomation.bMoveCompleteCameraZ1(m_iLine) = True
                Case "RB_CAMERA_Z2_A_MOVE_COMPLETE_REPORT = &H383"
                    pLDLT.PLC_Infomation.bMoveCompleteCameraZ2(m_iLine) = True

                Case "RB_STAGE_B_X_MOVE_COMPLETE_REPORT = &H390"
                    pLDLT.PLC_Infomation.bMoveCompleteStageX(m_iLine) = True
                Case "RB_STAGE_B_Y_MOVE_COMPLETE_REPORT = &H391"
                    pLDLT.PLC_Infomation.bMoveCompleteStageY(m_iLine) = True
                Case "RB_CAMERA_Z1_B_MOVE_COMPLETE_REPORT = &H392"
                    pLDLT.PLC_Infomation.bMoveCompleteCameraZ1(m_iLine) = True
                Case "RB_CAMERA_Z2_B_MOVE_COMPLETE_REPORT = &H393"
                    pLDLT.PLC_Infomation.bMoveCompleteCameraZ2(m_iLine) = True

                Case "RB_SCANNER_Z1_MOVE_COMPLETE_REPORT = &H384"
                    pLDLT.PLC_Infomation.bMoveCompleteScannerZ(0) = True
                Case "RB_SCANNER_Z2_MOVE_COMPLETE_REPORT = &H385"
                    pLDLT.PLC_Infomation.bMoveCompleteScannerZ(1) = True
                Case "RB_SCANNER_Z3_MOVE_COMPLETE_REPORT = &H386"
                    pLDLT.PLC_Infomation.bMoveCompleteScannerZ(2) = True
                Case "RB_SCANNER_Z4_MOVE_COMPLETE_REPORT = &H387"
                    pLDLT.PLC_Infomation.bMoveCompleteScannerZ(3) = True

               
                Case "RB_RECIPE_CHANGE_REQUEST = &H3E0"
                    pLDLT.PLC_Infomation.bRecipeChangeReq = True

                Case "RB_RECIPE_COPY_REQUEST = &H3E1"
                    pLDLT.PLC_Infomation.bRecipeCopyReq = True

                Case "RB_RECIPE_SAVE_COPY_REQUEST = &H3E2"
                    pLDLT.PLC_Infomation.bRecipeSaveCopyReq = True

                Case "RB_TIME_SYNC_REQUEST = &H3F0"
                    pLDLT.PLC_Infomation.bSyncTimeReq = True

            End Select


        End If
    End Sub
    Private Sub chkLine_Click(sender As System.Object, e As System.EventArgs) Handles chkLine.Click
        If chkLine.Checked = True Then
            chkLine.Text = "B Line"
        ElseIf chkLine.Checked = False Then
            chkLine.Text = "A Line"
        End If
    End Sub

    Private Sub btnFindModel_1_Click(sender As System.Object, e As System.EventArgs) Handles btnFindModel_1.Click

        lboxGetVisionData.Items.Clear()
#If SIMUL <> 1 Then
        pMilProcessor.CopyImage(pMilInterface.dispImage(numCamera.Value - 1), pMilInterface.dispImageChild(numCamera.Value - 1))

        FindModel(numCamera.Value - 1, 1)
#End If
        tmpDiffX_1 = 0 'pMF_Result(m_iLine).PositionDiffX
        tmpDiffY_1 = 0 'pMF_Result(m_iLine).positionDiffY

        lboxGetVisionData.Items.Add("PositionDiffX : " & tmpDiffX_1.ToString)
        lboxGetVisionData.Items.Add("PositionDiffY : " & tmpDiffY_1.ToString)

    End Sub

    Private Sub btnMoveStageX_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveStageX.Click
        Dim nLine As Integer = 0

        If chkLine.Checked = True Then
            nLine = LINE.B
            tmpMoveValue = pLDLT.PLC_Infomation.dCurPosX(1)
        Else
            chkLine.Checked = False
            nLine = LINE.A
            tmpMoveValue = pLDLT.PLC_Infomation.dCurPosX(0)
        End If
        tmpMoveValue = tmpMoveValue + (numStageMove.Value * 1000)

        pLDLT.MoveStage(nLine, Axis.x, tmpMoveValue)

    End Sub

    Private Sub btnFindModel_2_Click(sender As System.Object, e As System.EventArgs) Handles btnFindModel_2.Click
        FindModel(numCamera.Value - 1, 1)

        tmpDiffX_2 = 0 'pMF_Result(m_iLine).PositionDiffX
        tmpDiffY_2 = 0 'pMF_Result(m_iLine).positionDiffY

        lboxGetVisionData.Items.Add("PositionDiffX : " & tmpDiffX_2.ToString)
        lboxGetVisionData.Items.Add("PositionDiffY : " & tmpDiffY_2.ToString)

    End Sub

    Private Sub btnCalVisionValue_Click(sender As System.Object, e As System.EventArgs) Handles btnCalVisionValue.Click

        tmpDistance = Math.Sqrt((tmpDiffX_2 - tmpDiffX_1) ^ 2 + (tmpDiffY_2 - tmpDiffY_1) ^ 2)
        lboxGetVisionData.Items.Add("Pixel Distance : " & Math.Round(tmpDistance, 3).ToString)

        tmpAngle = Math.Atan2((tmpDiffY_2 - tmpDiffY_1), (tmpDiffX_2 - tmpDiffX_1))
        tmpAngle = tmpAngle * 180 / Math.PI
        lboxGetVisionData.Items.Add("Angle : " & Math.Round(tmpAngle, 9).ToString)

        tmpScale = numStageMove.Value / tmpDistance
        lboxGetVisionData.Items.Add("Scale : " & Math.Round(tmpScale, 9).ToString)

    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FindModel(1, 2)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FindModel(Panel.p1, 2)
    End Sub
End Class