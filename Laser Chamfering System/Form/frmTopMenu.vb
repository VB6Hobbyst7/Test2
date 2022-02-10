Public Class frmTopMenu
    Dim bPC_Control As Boolean = False

    Dim nTmCnt As Integer = 0
    Dim nBlackBoxCnt As Integer = 0
    Dim disfirstconnect As Boolean = True
    Dim distempstr As String

    Public bAutoLock_A As Boolean = False
    Public bAutoLock_B As Boolean = False

    Private Sub frmTopMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error GoTo SysErr
        modPub.SystemLog("frmTopMenu -- frmTopMenu_FormClosing")
        tmTopeMenu.Enabled = False
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- frmTopMenu_FormClosing")
    End Sub

    Private Sub frmTopMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo SysErr
        modPub.SystemLog("frmTopMenu -- frmTopMenu_Load")
        lbAccount.Text = modParam.pCurSystemParam.strVersion
        tmTopeMenu.Enabled = True

        BtnKorea.BackColor = Color.LimeGreen
        BtnEng.BackColor = Color.LightGray
        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_4ALIGN_STATUS, False)
		'시뮬에서는 로그인 없다
#If SIMUL = 1 Then
        bLogInUser = False
        bLogInTech = False
        bLogInAdmin = True
#End If
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- frmTopMenu_Load")
    End Sub



    Private Sub btnInit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInit.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmTopMenu -- btnInit_Click")

        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = False And bLogInTech = False And bLogInAdmin = False Then
            frmMSG.ShowMsg("LogIn Error", "LogIn이 필요합니다.", False, 1)
            modPub.SystemLog("frmTopMenu -- btnInit_Click - LogIn Error")
            Return
        End If

        frmInit.Visible = True
		frmSeqVision.Visible = False
        frmVision.Visible = False
        frmMarkDataEditer.Visible = False


        btnInit.BackColor = Color.Lime
        btnMain.BackColor = Color.White
        btnRecipe.BackColor = Color.White
        btnSetting.BackColor = Color.White

        frmSetting.FormSetting()
        frmSetting.tmSetting.Enabled = False
       
        frmMarkDataEditer.BlackBox(False)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- btnInit_Click")
    End Sub

    Private Sub btnMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMain.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmTopMenu -- btnMain_Click")

        frmInit.Visible = False
        frmSeqVision.Visible = True
        frmVision.Visible = False
        frmSequence.Visible = True
        frmSetting.Visible = False
        frmRecipe.Visible = False

        btnInit.BackColor = Color.White
        btnMain.BackColor = Color.Lime
        btnRecipe.BackColor = Color.White
        btnSetting.BackColor = Color.White

        frmSetting.FormSetting()
        frmSetting.tmSetting.Enabled = False

        frmMarkDataEditer.BlackBox(False)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- btnMain_Click")
    End Sub

    Private Sub btnRecipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecipe.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmTopMenu -- btnRecipe_Click")

        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = False And bLogInTech = False And bLogInAdmin = False Then
            frmMSG.ShowMsg("LogIn Error", "LogIn이 필요합니다.", False, 1)
            modPub.SystemLog("frmTopMenu -- btnInit_Click - LogIn Error")
            Return
        End If

#If HEAD_2 Then
        frmInit_2Head.Visible = False
        frmSetting_BCR.Visible = False
#Else
        frmInit.Visible = False
        frmSetting.Visible = False
#End If
        'frmSeqVision_2Head.Visible = False

        frmRecipe.Visible = True
        frmVision.Visible = False
        ' 화면전환 아되는거 수정 ZYX
        frmSeqVision.Visible = False
#If HEAD_2 Then
        frmSequence_2Head.Visible = False
#Else
        frmSequence.Visible = False
#End If
        'frmSequence.Visible = False

        frmMarkDataEditer.Visible = True
        'frmRecipe.m_ctrlRcpMarkEditor.Visible = True

        'frmRecipe.gbAlign.Visible = True
        'frmRecipe.gbEditMark.Visible = False
        'frmRecipe.gbMarking.Visible = False
        'frmRecipe.btnMarking.BackColor = Color.White
        'frmRecipe.btnAlign.BackColor = Color.Lime

        btnInit.BackColor = Color.White
        btnMain.BackColor = Color.White
        btnRecipe.BackColor = Color.Lime
        btnSetting.BackColor = Color.White

#If HEAD_2 Then
        frmSetting_BCR.FormSetting()
#Else
        frmSetting.FormSetting()
#End If
        frmSetting.tmSetting.Enabled = False
        frmRecipe.m_iSelectedCmd = 0
        frmRecipe.LoadCtrl()

        frmMarkDataEditer.BlackBox(False)

        '20170630 CHY - 버튼 인터락
        'frmRecipe.RecipeButtonInterLock()
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- btnRecipe_Click")

    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmTopMenu -- btnSetting_Click")




        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = False And bLogInTech = False And bLogInAdmin = False Then
            frmMSG.ShowMsg("LogIn Error", "LogIn이 필요합니다.", False, 1)
            modPub.SystemLog("frmTopMenu -- btnInit_Click - LogIn Error")
            Return
        End If
        '20181022 Pc 제어권을 얻었을때만 크로스라인 작동하게 수정
        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            frmSetting.m_ctrlSetting_SysParam.btnMoveToLaserA.Enabled = True
            frmSetting.m_ctrlSetting_SysParam.btnMoveToLaserB.Enabled = True
            frmSetting.m_ctrlSetting_SysParam.BtnSeqAStart.Enabled = True
            frmSetting.m_ctrlSetting_SysParam.BtnSeqBStart.Enabled = True
        Else
            frmSetting.m_ctrlSetting_SysParam.btnMoveToLaserA.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnMoveToLaserB.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnLaserShotA.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnLaserShotB.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnMoveToVisionA.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnMoveToVisionB.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnPosCalculA.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnPosCalculB.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnOffsetSetA.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.btnOffsetSetB.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.BtnSeqAStart.Enabled = False
            frmSetting.m_ctrlSetting_SysParam.BtnSeqBStart.Enabled = False
        End If
        
#If HEAD_2 Then
        frmInit_2Head.Visible = False
		frmSeqVision_2Head.Visible = False
#Else
        frmInit.Visible = False
		frmSeqVision.Visible = False
#End If
        frmVision.Visible = True
#If HEAD_2 Then
        frmSequence_2Head.Visible = False
        frmSetting_BCR.Visible = True
#Else
        frmSequence.Visible = False
        frmSetting.Visible = True
#End If
        'frmSequence.Visible = False
        frmRecipe.Visible = False

        btnInit.BackColor = Color.White
        btnMain.BackColor = Color.White
        btnRecipe.BackColor = Color.White
        btnSetting.BackColor = Color.Lime


#If HEAD_2 Then
        frmSetting_BCR.FormSetting()
        frmSetting_BCR.SelectSettingGroup(0)
#Else
        frmSetting.FormSetting()
        frmSetting.tmSetting.Enabled = True
        frmSetting.SelectSettingGroup(0)
#End If

        frmMarkDataEditer.BlackBox(False)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- btnSetting_Click")
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmTopMenu -- btnExit_Click")

        Call Finalize()

        MDI_MAIN.Close()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- btnExit_Click")
    End Sub

    Private Sub PC_Status()
        On Error GoTo SysErr
        If pCPU_Status.GetStauts() = True Then
            For i As Integer = 0 To pCPU_Status.nCoreTemperature.Length - 1
                If i = 0 Then
                    If pCPU_Status.nCoreTemperature(0) < 50 Then
                        lblCurCpuTemp_1.BackColor = Color.Lime
                    ElseIf 50 < pCPU_Status.nCoreTemperature(0) < 70 Then
                        lblCurCpuTemp_1.BackColor = Color.Orange
                    ElseIf 70 < pCPU_Status.nCoreTemperature(0) Then
                        lblCurCpuTemp_1.BackColor = Color.Red
                    End If
                    lblCurCpuTemp_1.Text = pCPU_Status.nCoreTemperature(0)
                ElseIf i = 1 Then
                    If pCPU_Status.nCoreTemperature(1) < 50 Then
                        lblCurCpuTemp_2.BackColor = Color.Lime
                    ElseIf 50 < pCPU_Status.nCoreTemperature(1) < 70 Then
                        lblCurCpuTemp_2.BackColor = Color.Orange
                    ElseIf 70 < pCPU_Status.nCoreTemperature(1) Then
                        lblCurCpuTemp_2.BackColor = Color.Red
                    End If
                    lblCurCpuTemp_2.Text = pCPU_Status.nCoreTemperature(1)
                ElseIf i = 2 Then
                    If pCPU_Status.nCoreTemperature(2) < 50 Then
                        lblCurCpuTemp_3.BackColor = Color.Lime
                    ElseIf 50 < pCPU_Status.nCoreTemperature(2) < 70 Then
                        lblCurCpuTemp_3.BackColor = Color.Orange
                    ElseIf 70 < pCPU_Status.nCoreTemperature(2) Then
                        lblCurCpuTemp_3.BackColor = Color.Red
                    End If
                    lblCurCpuTemp_3.Text = pCPU_Status.nCoreTemperature(2)
                ElseIf i = 3 Then
                    If pCPU_Status.nCoreTemperature(3) < 50 Then
                        lblCurCpuTemp_4.BackColor = Color.Lime
                    ElseIf 50 < pCPU_Status.nCoreTemperature(3) < 70 Then
                        lblCurCpuTemp_4.BackColor = Color.Orange
                    ElseIf 70 < pCPU_Status.nCoreTemperature(3) Then
                        lblCurCpuTemp_4.BackColor = Color.Red
                    End If
                    lblCurCpuTemp_4.Text = pCPU_Status.nCoreTemperature(3)
                End If
            Next
        End If
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- PC_Status")

    End Sub

    Private m_nStartTick(1) As Integer
    Private m_bStarted(1) As Boolean

    
    Private Function IsSleepTime(ByVal nLine As Integer, ByVal nIntervalMil As Integer) As Boolean
        If m_bStarted(nLine) = False Then
            m_bStarted(nLine) = True
            m_nStartTick(nLine) = My.Computer.Clock.TickCount
        Else
            If (My.Computer.Clock.TickCount - m_nStartTick(nLine)) > nIntervalMil Then
                m_nStartTick(nLine) = 0
                m_bStarted(nLine) = False
                Return True
            End If
        End If

        Return False
    End Function

    Dim bRecipeCopyBusy As Boolean = False
    Dim bAcceptCopy As Boolean = False
    Dim bRecipeChangeBusy As Boolean = False
    Dim bAcceptChange As Boolean = False
    Dim bRecipeSaveBusy As Boolean = False
    Dim bAcceptSave As Boolean = False
    Dim bRecipeDeleteBusy As Boolean = False
    Dim bAcceptDelete As Boolean = False

    Private Sub tmTopeMenu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmTopeMenu.Tick
        On Error GoTo SysErr

        Static bRun As Boolean = False
        If bRun = True Then Exit Sub
        bRun = True

        RecipeCheck()

        If bLogInUser = True Then
            lbAccount.Text = "User"
        ElseIf bLogInTech = True Then
            lbAccount.Text = "Tech"
        ElseIf bLogInAdmin = True Then
            lbAccount.Text = "Admin"
        Else
            lbAccount.Text = "로그인을 해주세요"
        End If

        If System.IO.Directory.Exists(pCurSystemParam.strAlignImagePath(LINE.A) & "\OK\" & Format(Now, "yyyy-MM-dd")) = False Then
            System.IO.Directory.CreateDirectory(pCurSystemParam.strAlignImagePath(LINE.A) & "\OK\" & Format(Now, "yyyy-MM-dd"))
        End If

        If System.IO.Directory.Exists(pCurSystemParam.strAlignImagePath(LINE.A) & "\NG\" & Format(Now, "yyyy-MM-dd")) = False Then
            System.IO.Directory.CreateDirectory(pCurSystemParam.strAlignImagePath(LINE.A) & "\NG\" & Format(Now, "yyyy-MM-dd"))
        End If

        If System.IO.Directory.Exists(pCurSystemParam.strAlignImagePath(LINE.B) & "\OK\" & Format(Now, "yyyy-MM-dd")) = False Then
            System.IO.Directory.CreateDirectory(pCurSystemParam.strAlignImagePath(LINE.B) & "\OK\" & Format(Now, "yyyy-MM-dd"))
        End If

        If System.IO.Directory.Exists(pCurSystemParam.strAlignImagePath(LINE.B) & "\NG\" & Format(Now, "yyyy-MM-dd")) = False Then
            System.IO.Directory.CreateDirectory(pCurSystemParam.strAlignImagePath(LINE.B) & "\NG\" & Format(Now, "yyyy-MM-dd"))
        End If

        If pLDLT.PLC_Infomation.bPLC_AlignCheckMode = True Then
            lblSystemStatus.ForeColor = Color.Red
            lblSystemStatus.BackColor = Color.Yellow
            lblSystemStatus.Text = "Align Mode 작동 중!!!!"
        Else
            If IsAllInit() = True Then
                lblSystemStatus.ForeColor = Color.Lime
                lblSystemStatus.BackColor = Color.Black
                lblSystemStatus.Text = "System Ready to Work"
            Else
                lblSystemStatus.ForeColor = Color.Red
                lblSystemStatus.BackColor = Color.Black
                lblSystemStatus.Text = "System need to Init"
            End If
        End If

        lblCurDate.Text = Format(Now, "yyyy-MM-dd")
        lblCurTime.Text = Format(Now, "HH:mm:ss")

        If pCPU_Status.bStart = True Then
            PC_Status()
        End If

        CheckLogCnt(500)



        If pLDLT.PLC_Infomation.bStageManualControl = True Then
            If bPC_Control = False Then
                lblMoveStage_A.Text = "PC Control Stage"
                lblMoveStage_A.BackColor = Color.Orange
                pLDLT.ResetMoveBit()
            End If
            bPC_Control = True
        ElseIf pLDLT.PLC_Infomation.bStageManualControl = False Then
            If bPC_Control = True Then
                lblMoveStage_A.Text = "PLC Control Stage"
                lblMoveStage_A.BackColor = Color.Lime
                pLDLT.ResetMoveBit()
            End If
            bPC_Control = False
        End If

        If frmRecipe.m_bEnableBlack = True Then
            BlackBoxCnt(nBlackBoxCnt, nTmCnt, tmTopeMenu.Interval, frmRecipe.pbResetBlackBoxCnt)
        End If

        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = True Then
            If bAutoLock_A = False Then
                bAutoLock_A = True

                frmSequence.btnStart_A.BackColor = Color.Lime
                frmSequence.btnStop_A.BackColor = Color.White

                lblAuto_Manual_A.Text = "A - Auto Mode"
                lblAuto_Manual_A.BackColor = Color.Lime
                ' UnlockProgram(False)
                pLDLT.ResetMoveBit()

                'GYN - LogIn 완료 후 동작되도록 수정
                If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
                    Seq(LINE.A).StartSeq()
                End If

            End If

        Else

            If bAutoLock_A = True Then
                bAutoLock_A = False

                frmSequence.btnStart_A.BackColor = Color.White
                frmSequence.btnStop_A.BackColor = Color.Red

                lblAuto_Manual_A.Text = "A - Manual Mode"
                lblAuto_Manual_A.BackColor = Color.Yellow
                pLDLT.ResetMoveBit()

                Seq(LINE.A).StopSeq()

            End If

        End If

        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = True Then
            If bAutoLock_B = False Then
                bAutoLock_B = True

                frmSequence.btnStart_B.BackColor = Color.Lime
                frmSequence.btnStop_B.BackColor = Color.White
                lblAuto_Manual_B.Text = "B - Auto Mode"
                lblAuto_Manual_B.BackColor = Color.Lime
                ' UnlockProgram(False)
                pLDLT.ResetMoveBit()

                'GYN - LogIn 완료 후 동작되도록 수정
                If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
                    Seq(LINE.B).StartSeq()
                End If

            End If

        Else

            If bAutoLock_B = True Then
                bAutoLock_B = False

                frmSequence.btnStart_B.BackColor = Color.White
                frmSequence.btnStop_B.BackColor = Color.Red
                lblAuto_Manual_B.Text = "B - Manual Mode"
                lblAuto_Manual_B.BackColor = Color.Yellow
                pLDLT.ResetMoveBit()
                Seq(LINE.B).StopSeq()

            End If

        End If


        '조명 관련 TEST
        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = False And pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = False Then
            'If pCurSystemParam.nLightUse = 1 Then

            '    'GYN - 2017.03.14 운전정지 시 -> 조명 밝기 1분 지나면 끄도록 설정
            '    'GYN - 마우스 움직임이 없이.. 1분이 지나면 꺼지도록 설정.
            '    If IsSleepTime(1, 300000) Then   '60000 : 1분, 300000 : 5분 ,600000 : 10분

            '        pLight.SetLight(1, 0)
            '        pLight.SetLight(2, 0)
            '        pLight.SetLight(3, 0)
            '        pLight.SetLight(4, 0)
            '        pLight.SetLight(5, 0)
            '        pLight.SetLight(6, 0)
            '        pLight.SetLight(7, 0)
            '        pLight.SetLight(8, 0)

            '        m_nStartTick(1) = 0
            '        m_bStarted(1) = False
            '    End If

            'End If

#If SIMUL <> 1 Then
            btnExit.Enabled = True
            frmRecipe.btnSaveRecipe.Enabled = True
#End If

        ElseIf pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = True Or pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = True Then
            'frmRecipe.m_ctrlRcpMarkEditor.btnSaveMarkData.Enabled = False
            pPowerMeterThread.ResetPowerMeter()
#If SIMUL <> 1 Then
            btnExit.Enabled = False
            frmRecipe.btnSaveRecipe.Enabled = False
#End If
        End If


        If pLDLT.PLC_Infomation.bMoveCompleteStageX(LINE.A) = True Then
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MOVE_REQUEST_STAGE_A_X, False)
        End If

        If pLDLT.PLC_Infomation.bMoveCompleteStageX(LINE.B) = True Then
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MOVE_REQUEST_STAGE_B_X, False)
        End If

        If pLDLT.PLC_Infomation.bMoveCompleteStageY(LINE.A) = True Then
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MOVE_REQUEST_STAGE_A_Y, False)
        End If

        If pLDLT.PLC_Infomation.bMoveCompleteStageY(LINE.B) = True Then
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MOVE_REQUEST_STAGE_B_Y, False)
        End If

        'pMouseMove = False

        'mouse_event(&H8 Or &H10, 0, 0, 0, 0)
        'GYN - 2017.03.14 - 조명값 '0'으로 변경
        '화이트 조명으로 진행 시 한곳에서 오래동안 빛을 발하면 제품에 손상된다는...
        '그래서 조명 끝다.
        '* 조명이 잘 안꺼지면 Sleep을 늘려보고...
        '* 조명이 잘 꺼지면 Sleep을 줄이는 걸로.
        '* 화이트 조명만 끄면 되니깐... 박스 조명만 꺼볼까? IR은 말고?

        CheckLogCnt(500)

        Dim tmpStart As Integer = 0
        If pLDLT.bRMSDATAChange = True Then

            If pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 0) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 0) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '파일 변수에 저장
            End If

            tmpStart = tmpStart + 1
            If pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 1) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 1) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '파일 변수에 저장
            End If

            tmpStart = tmpStart + 1
            If pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 1) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 1) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '파일 변수에 저장
            End If

            tmpStart = tmpStart + 1
            If pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 1) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                pCurSystemParam.LaserPower(pCurRecipe.nRecipeNumber - 1, 1) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '파일 변수에 저장
            End If

            tmpStart = tmpStart + 1
            For i As Integer = 0 To 14

                If pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).MarkSpeed(i) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                    pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).MarkSpeed(i) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '파일 변수에 저장
                    pSetRecipe.PenData.MarkSpeed(i - 1) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '실제 프로그램에 적용
                End If

                tmpStart = tmpStart + 1
                If pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).JumpSpeed(i) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                    pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).JumpSpeed(i) = pLDLT.PLC_Infomation.nRMSData(tmpStart)
                    pSetRecipe.PenData.JumpSpeed(i - 1) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '실제 프로그램에 적용
                End If

                tmpStart = tmpStart + 1
                If pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).Repeat(i) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                    pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).Repeat(i) = pLDLT.PLC_Infomation.nRMSData(tmpStart)
                    pSetRecipe.PenData.Repeat(i - 1) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '실제 프로그램에 적용
                End If

                tmpStart = tmpStart + 1
                If pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).MarkMode(i) <> pLDLT.PLC_Infomation.nRMSData(tmpStart) Then
                    pCurSystemParam.RecipePen(pCurRecipe.nRecipeNumber - 1).MarkMode(i) = pLDLT.PLC_Infomation.nRMSData(tmpStart)
                    pSetRecipe.PenData.MarkMode(i - 1) = pLDLT.PLC_Infomation.nRMSData(tmpStart) '실제 프로그램에 적용
                End If


            Next

            pLDLT.bRMSDATAChange = False

            'Recipe Save 버튼을 누르게 해야 하나 여기서-? 흠...
            '버튼 보다.. Save Recipe....

            'TEST 끝나고 해야징. 우선 막고 ~ ! 
            'pCurRecipe = pSetRecipe
            'If modRecipe.SaveRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe) = True Then
            'End If

        End If


        ' LGD 요청사항 삭제(김영수 주임) DispalcePLCSend()

        '2 Align Start Bit set
        'pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_4ALIGN_STATUS, False)

        For i As Integer = 0 To 3
            If modPub.bLogInAdmin = True Then
                frmSetting.m_ctrlSetting_Scanner(i).btnScanShotContinousOn.Enabled = True
                frmSetting.m_ctrlSetting_Scanner(i).btnScanShotBurstOn.Enabled = True
            Else
                frmSetting.m_ctrlSetting_Scanner(i).btnScanShotContinousOn.Enabled = False
                frmSetting.m_ctrlSetting_Scanner(i).btnScanShotBurstOn.Enabled = False
            End If
        Next

        bRun = False
        Exit Sub
SysErr:
        bRun = False
        modPub.ErrorLog(Err.Description & " - frmTopMenu -- tmTopeMenu_Tick")
    End Sub

    Dim nDustIndex(1) As Integer
    Dim nDustCnt(1) As Integer
    Dim nCurDustTime As Integer = 0
    Dim nExDustTime As Integer = 0
    Dim bDustCheckStop As Boolean = False
    Dim bDustCheckRun As Boolean = False

   

    Private Sub CheckLogCnt(ByVal nMaxListCount As Integer)
        On Error GoTo SysErr
        Dim CurLogCount As Integer = frmLog.lBoxLog.Items.Count

        If CurLogCount > nMaxListCount Then
            For i As Integer = 0 To CurLogCount - nMaxListCount - 1
                frmLog.lBoxLog.Items.RemoveAt(0)
            Next
        End If

        Exit Sub
SysErr:

    End Sub

    Private Sub BlackBoxCnt(ByRef nCnt As Integer, ByRef nInterValCnt As Integer, ByVal nInterval As Integer, ByRef bReset As Boolean)
        On Error GoTo SysErr
        If bReset = True Then
            nInterValCnt = 0
            nCnt = 0
            bReset = False
        Else
            nInterValCnt = nInterValCnt + 1
            If nInterval * nInterValCnt >= 1000 Then
                frmRecipe.lblHidden.Text = nCnt.ToString
                nInterValCnt = 0
                nCnt = nCnt + 1
                If nCnt >= 60 Then
                    bReset = False
                    frmRecipe.lblHidden.Text = ""
                    frmRecipe.m_bEnableBlack = False
                    frmMarkDataEditer.BlackBox(False)
                End If
            End If
        End If
        Exit Sub
SysErr:

    End Sub

    Public Sub UnlockProgram(ByVal bUnlock As Boolean)
        On Error GoTo SysErr

        btnExit.Enabled = bUnlock

        'frmInit.btnInitAll.Enabled = bUnlock
        'frmInit.btnInitStop.Enabled = bUnlock
        'frmInit.btnInitDustCollecter.Enabled = bUnlock
        'frmInit.btnInitLaser1.Enabled = bUnlock
        'frmInit.btnInitLaser2.Enabled = bUnlock
        'frmInit.btnInitLight.Enabled = bUnlock
        'frmInit.btnInitPLC.Enabled = bUnlock
        'frmInit.btnInitScanner1.Enabled = bUnlock
        'frmInit.btnInitScanner2.Enabled = bUnlock
        'frmInit.btnInitVisionLineA1.Enabled = bUnlock
        'frmInit.btnInitVisionLineA2.Enabled = bUnlock
        'frmInit.btnInitVisionLineB1.Enabled = bUnlock
        'frmInit.btnInitVisionLineB2.Enabled = bUnlock
        'frmInit.btnPowerMeter_1.Enabled = bUnlock
        'frmInit.btnPowerMeter_2.Enabled = bUnlock
        'frmInit.btnPowerMeter_Stage.Enabled = bUnlock

        'frmVision.gbMotion.Enabled = bUnlock
        'frmVision.gbBinarize.Enabled = bUnlock
        ''frmVision.gbLightCh1.Enabled = bUnlock

        'frmRecipe.gbAlignA1_M1_L1.Enabled = bUnlock
        'frmRecipe.gbAlignA1_M1_L2.Enabled = bUnlock
        'frmRecipe.gbAlignA1_M1_L3.Enabled = bUnlock
        'frmRecipe.gbAlignA1_M2_L1.Enabled = bUnlock
        'frmRecipe.gbAlignA1_M2_L2.Enabled = bUnlock
        'frmRecipe.gbAlignA1_M2_L3.Enabled = bUnlock

        'frmRecipe.gbAlignA2_M1_L1.Enabled = bUnlock
        'frmRecipe.gbAlignA2_M1_L2.Enabled = bUnlock
        'frmRecipe.gbAlignA2_M1_L3.Enabled = bUnlock
        'frmRecipe.gbAlignA2_M2_L1.Enabled = bUnlock
        'frmRecipe.gbAlignA2_M2_L2.Enabled = bUnlock
        'frmRecipe.gbAlignA2_M2_L3.Enabled = bUnlock

        'frmRecipe.gbAlignB1_M1_L1.Enabled = bUnlock
        'frmRecipe.gbAlignB1_M1_L2.Enabled = bUnlock
        'frmRecipe.gbAlignB1_M1_L3.Enabled = bUnlock
        'frmRecipe.gbAlignB1_M2_L1.Enabled = bUnlock
        'frmRecipe.gbAlignB1_M2_L2.Enabled = bUnlock
        'frmRecipe.gbAlignB1_M2_L3.Enabled = bUnlock

        'frmRecipe.gbAlignB2_M1_L1.Enabled = bUnlock
        'frmRecipe.gbAlignB2_M1_L2.Enabled = bUnlock
        'frmRecipe.gbAlignB2_M1_L3.Enabled = bUnlock
        'frmRecipe.gbAlignB2_M2_L1.Enabled = bUnlock
        'frmRecipe.gbAlignB2_M2_L2.Enabled = bUnlock
        'frmRecipe.gbAlignB2_M2_L3.Enabled = bUnlock


        'frmRecipe.btnApplyRecipe.Enabled = bUnlock
        'frmRecipe.btnSaveRecipe.Enabled = bUnlock

        'frmSetting.gbSystem.Enabled = bUnlock
        'frmSetting.gbLaser.Enabled = bUnlock
        'frmSetting.gbScanner.Enabled = bUnlock
        'frmSetting.gbCalibration.Enabled = bUnlock

        'frmSetting.btnSetBitData.Enabled = bUnlock
        'frmSetting.btnResetBitData.Enabled = bUnlock

        Exit Sub
SysErr:

    End Sub

    Dim nCntRecipeName As Integer = 0
    Dim nCntRecipeNumber As Integer = 0


    Private Sub RecipeCheck()
        On Error GoTo SysErr

        Dim StrTemp() As String = {}
        Dim StrTemp2() As String = {}
        Dim OutString As String = ""
        Dim OldRecipePath As String = ""
        Dim nShort As Short
        ReDim StrTemp(9)
        ReDim StrTemp2(9)

        Dim nRecipeNo As Integer = 0
        
        If pLDLT.pbConnect = True Then

            If bAutoLock_A = False And bAutoLock_B = False Then

                'GYN - TEST
                If pCurRecipe.strRecipeName <> pLDLT.PLC_Infomation.strModelName Then
                    If nCntRecipeName > 100 Then   '59 Then
                        If frmMSG.pbMsgUp = False Then
                            nCntRecipeName = 0
                            frmMSG.ShowMsg("Model Recipe Error", "Model Name is Not Match", True, 0)
                        End If
                    End If
                    nCntRecipeName = nCntRecipeName + 1
                Else
                    nCntRecipeName = 0
                End If

                If pCurRecipe.nRecipeNumber <> pLDLT.PLC_Infomation.nRecipeNo Then
                    If frmMSG.pbMsgUp = False Then
                        If nCntRecipeNumber > 100 Then   '59 Then
                            nCntRecipeNumber = 0
                            frmMSG.ShowMsg("Model Recipe Error", "Model Number is Not Match", True, 0)
                        End If
                    End If
                    nCntRecipeNumber = nCntRecipeNumber + 1
                Else
                    nCntRecipeNumber = 0
                    lblModelNum.Text = pCurRecipe.nRecipeNumber.ToString
                End If

            End If

            '레시피 변경
            If pLDLT.PLC_Infomation.bRecipeChangeReq = True Then

                pLDLT.bChangeBit = True

                System.Threading.Thread.Sleep(500)


                nRecipeNo = CInt(pLDLT.PLC_Infomation.nCopyRecipeNo)

                For i As Integer = 0 To StrTemp.Length - 1
                    pMXComponent.ReadWordIntegerByAddress(clsLDLT.RWORD.RW_COPY_RECIPE_NAME0 + i, nShort)
                    StrTemp2(i) = Hex(nShort)
                Next

                If pLDLT.ConvertAscToWord(StrTemp2, OutString) = True Then
                    pLDLT.PLC_Infomation.strModelName = Trim(OutString)
                End If

                If bRecipeChangeBusy = False And bAcceptChange = False Then

                    pSetSystemParam.strLastModelFilePath = pCurSystemParam.strSystemRootPath & "\Recipe\" & nRecipeNo _
                     & "~" & pLDLT.PLC_Infomation.strModelName & "\" & pLDLT.PLC_Infomation.strModelName & ".ini"

                    '레시피 불러오기
                    If modRecipe.LoadRecipe(pSetSystemParam.strLastModelFilePath, pSetRecipe) = True Then
                        pCurRecipe = pSetRecipe
                        pCurSystemParam.strLastModelFilePath = pSetSystemParam.strLastModelFilePath
                        WriteIni("SYSTEM_ETC", "LAST_MODEL", pCurSystemParam.strLastModelFilePath, pStrTmpSystemRoot)
                        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_RECIPE_CHANGE_REPORT, True)

                        frmSequence.txtRecipeName.Text = pCurRecipe.strRecipeName

                        'frmSequence.txtRecipeName.Text = pCurRecipe.strRecipeName
                        bAcceptChange = True
                    End If

                End If
            End If

            'If pLDLT.PLC_Infomation.bRecipeChangeReq = False And pLDLT.PC_Infomation.bRecipeChangeReport = True Then
            If pLDLT.PLC_Infomation.bRecipeChangeReq = False And bAcceptChange = True Then
                bRecipeChangeBusy = False
                bAcceptChange = False
                pLDLT.bChangeBit = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_RECIPE_CHANGE_REPORT, False)
            End If

            '레시피 복사
            If pLDLT.PLC_Infomation.bRecipeCopyReq = True Then

                System.Threading.Thread.Sleep(500)

                For i As Integer = 0 To StrTemp.Length - 1
                    pMXComponent.ReadWordIntegerByAddress(clsLDLT.RWORD.RW_CURRENT_RECIPE_NAME0 + i, nShort)
                    StrTemp2(i) = Hex(nShort)
                Next

                If pLDLT.ConvertAscToWord(StrTemp2, OutString) = True Then
                    pLDLT.PLC_Infomation.strModelName = Trim(OutString)
                End If


                If bRecipeCopyBusy = False And bAcceptCopy = False Then
                    bRecipeCopyBusy = True
                    bAcceptCopy = True

                    '레시피 복사
                    If modRecipe.CopyRecipe(pCurSystemParam.strSystemRootPath & "\Recipe\", pLDLT.PLC_Infomation.nRecipeNo, pLDLT.PLC_Infomation.strModelName, _
                                          pLDLT.PLC_Infomation.nCopyRecipeNo, pLDLT.PLC_Infomation.strModelName) = True Then

                        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_RECIPE_COPY_REPORT, True)

                        bAcceptCopy = False
                        bRecipeCopyBusy = False

                    Else
                        '20180308 chy 잘못 복사된 폴더 삭제
                        DeleteRecipe(pCurSystemParam.strSystemRootPath & "\Recipe\", pLDLT.PLC_Infomation.nCopyRecipeNo, pLDLT.PLC_Infomation.strCopyModelName)
                        bAcceptCopy = False
                        bRecipeCopyBusy = False


                    End If
                End If
            End If

            If pLDLT.PLC_Infomation.bRecipeCopyReq = False And bAcceptCopy = True Then
                bRecipeCopyBusy = False
                bAcceptCopy = False
                pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_RECIPE_COPY_REPORT, False)
            End If


            '레시피 이름 변경
            If pLDLT.PLC_Infomation.bRecipeSaveCopyReq = True Then

                System.Threading.Thread.Sleep(500)

                For j As Integer = 0 To StrTemp.Length - 1
                    pMXComponent.ReadWordIntegerByAddress(clsLDLT.RWORD.RW_COPY_RECIPE_NAME0 + j, nShort)
                    StrTemp(j) = Hex(nShort)
                Next

                If pLDLT.ConvertAscToWord(StrTemp, OutString) = True Then
                    pLDLT.PLC_Infomation.strCopyModelName = Trim(OutString)
                End If

                '20170510 파일 이름 불러오기--------------------by chy
                Dim strDir As String
                Dim strOldRecipeName As String = ""
                Dim MidStartNum As Integer = 0
                strDir = Dir(pCurSystemParam.strSystemRootPath & "\Recipe\" & pLDLT.PLC_Infomation.nCopyRecipeNo & "~" & "*", vbDirectory)
                If pLDLT.PLC_Infomation.nCopyRecipeNo < 10 Then
                    MidStartNum = 3
                Else
                    MidStartNum = 4
                End If
                strOldRecipeName = Mid(strDir, MidStartNum)

                '레시피 이름 변경시 같은 이름으로 변경을 시도하면 시퀀스 종료
                If strOldRecipeName = pLDLT.PLC_Infomation.strCopyModelName Then
                    Exit Sub
                End If

                If bRecipeSaveBusy = False And bAcceptSave = False Then

                    bRecipeSaveBusy = True
                    bAcceptSave = True

                    OldRecipePath = pCurSystemParam.strSystemRootPath & "\Recipe\" & pLDLT.PLC_Infomation.nCopyRecipeNo & "~" & strOldRecipeName

                    '레시피 복사
                    If modRecipe.CopyRecipe(pCurSystemParam.strSystemRootPath & "\Recipe\", pLDLT.PLC_Infomation.nCopyRecipeNo, strOldRecipeName, _
                                          pLDLT.PLC_Infomation.nCopyRecipeNo, pLDLT.PLC_Infomation.strCopyModelName) = True Then

                        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_RECIPE_SAVE_REPORT, True)
                        frmSequence.txtRecipeName.Text = pCurRecipe.strRecipeName
                        bAcceptSave = False
                        bRecipeSaveBusy = False

                        '20170510 불필요 주석 처리 --- by chy
                        'GYN - 이거 우선 막아야 한다...기존 레시피 삭제.
                        System.IO.Directory.Delete(OldRecipePath, True)

                        'End If
                        '20180308 chy 현재 사용중인 레시피 이름 변경시 레시피 업데이트
                        If pLDLT.PLC_Infomation.nCopyRecipeNo = pLDLT.PLC_Infomation.nRecipeNo Then
                            System.Threading.Thread.Sleep(500)

                            nRecipeNo = pLDLT.PLC_Infomation.nCopyRecipeNo

                            For i As Integer = 0 To StrTemp.Length - 1
                                pMXComponent.ReadWordIntegerByAddress(clsLDLT.RWORD.RW_COPY_RECIPE_NAME0 + i, nShort)
                                StrTemp2(i) = Hex(nShort)
                            Next

                            If pLDLT.ConvertAscToWord(StrTemp2, OutString) = True Then
                                pLDLT.PLC_Infomation.strModelName = Trim(OutString)
                            End If

                            If bRecipeChangeBusy = False And bAcceptChange = False Then

                                pSetSystemParam.strLastModelFilePath = pCurSystemParam.strSystemRootPath & "\Recipe\" & nRecipeNo _
                                 & "~" & pLDLT.PLC_Infomation.strModelName & "\" & pLDLT.PLC_Infomation.strModelName & ".ini"

                                '레시피 불러오기
                                If modRecipe.LoadRecipe(pSetSystemParam.strLastModelFilePath, pSetRecipe) = True Then
                                    pCurRecipe = pSetRecipe
                                    pCurSystemParam.strLastModelFilePath = pSetSystemParam.strLastModelFilePath
                                    WriteIni("SYSTEM_ETC", "LAST_MODEL", pCurSystemParam.strLastModelFilePath, pStrTmpSystemRoot)
                                    frmSequence.txtRecipeName.Text = pCurRecipe.strRecipeName
                                End If

                            End If
                        End If
                    Else
                        '20180308 chy 잘못 복사된 폴더 삭제
                        DeleteRecipe(pCurSystemParam.strSystemRootPath & "\Recipe\", pLDLT.PLC_Infomation.nCopyRecipeNo, pLDLT.PLC_Infomation.strCopyModelName)
                        bAcceptSave = False
                        bRecipeSaveBusy = False
                    End If
                End If
            End If

            'If pLDLT.PLC_Infomation.bRecipeSaveCopyReq = False Then
            '    bRecipeSaveBusy = False
            '    bAcceptSave = False
            '    pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_RECIPE_SAVE_REPORT, False)
            'End If


            '레시피 삭제
            If pLDLT.PLC_Infomation.bRecipeDeleteReq = True Then

                System.Threading.Thread.Sleep(1000)

                If bRecipeDeleteBusy = False And bAcceptDelete = False Then
                    bRecipeDeleteBusy = True
                    bAcceptDelete = True

                    For j As Integer = 0 To StrTemp.Length - 1
                        pMXComponent.ReadWordIntegerByAddress(clsLDLT.RWORD.RW_COPY_RECIPE_NAME0 + j, nShort)
                        StrTemp(j) = Hex(nShort)
                    Next
                    If pLDLT.ConvertAscToWord(StrTemp, OutString) = True Then
                        pLDLT.PLC_Infomation.strCopyModelName = Trim(OutString)
                    End If

                    '레시피 삭제
                    If DeleteRecipe(pCurSystemParam.strSystemRootPath & "\Recipe\", pLDLT.PLC_Infomation.nCopyRecipeNo, pLDLT.PLC_Infomation.strCopyModelName) = True Then

                        bRecipeDeleteBusy = False
                        bAcceptDelete = False

                    End If
                End If
            End If

        End If

        Exit Sub
SysErr:

    End Sub


 
    Private Sub btnLogIn_Click(sender As System.Object, e As System.EventArgs) Handles btnLogIn.Click

        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = False And pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = False Then

            bLogInUser = False
            bLogInTech = False
            bLogInAdmin = False
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LOGIN_ADMIN, False)
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_LOGIN_TECH, False)
            frmLogIn.Show()

        End If

    End Sub

    Dim StrCulture As String = My.Application.UICulture.Name

    Private Sub BtnKorea_Click(sender As System.Object, e As System.EventArgs) Handles BtnKorea.Click

        BtnKorea.BackColor = Color.LimeGreen
        BtnEng.BackColor = Color.LightGray
        BtnVietnam.BackColor = Color.LightGray

        StrCulture = ""
        Lan_Change(StrCulture)

    End Sub

    Private Sub BtnEng_Click(sender As System.Object, e As System.EventArgs) Handles BtnEng.Click

        BtnKorea.BackColor = Color.LightGray
        BtnEng.BackColor = Color.LimeGreen
        BtnVietnam.BackColor = Color.LightGray

        StrCulture = "en"
        Lan_Change(StrCulture)

    End Sub

    Private Sub BtnVietnam_Click(sender As System.Object, e As System.EventArgs) Handles BtnVietnam.Click

        BtnKorea.BackColor = Color.LightGray
        BtnEng.BackColor = Color.LightGray
        BtnVietnam.BackColor = Color.LimeGreen

        StrCulture = "vi"
        Lan_Change(StrCulture)

    End Sub

    Private Sub Lan_Change(ByVal Culture As String) 'UI언어를바꾼다
        If Culture = "" Then
            Culture = "ko-KR"
        End If

        My.Application.ChangeUICulture(Culture)
        Me.Text = Culture

        Call Form_Label2()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = StrCulture
        'Call Form_Label2()
    End Sub

    Private Sub Form_Label2()
        With Me

            .btnLogIn.Text = My.Resources.setLan.ResourceManager.GetObject("LogIn")
            .lblTitle.Text = My.Resources.setLan.ResourceManager.GetObject("Chamfering_System")
            '.lblVersion.Text = My.Resources.setLan.ResourceManager.GetObject("Ver")
            .lblSystemStatus.Text = My.Resources.setLan.ResourceManager.GetObject("System_need_to_Init")
            .lblAuto_Manual_A.Text = My.Resources.setLan.ResourceManager.GetObject("PLC_A_Manual")
            .lblAuto_Manual_B.Text = My.Resources.setLan.ResourceManager.GetObject("PLC_B_Manual")
            .lblMoveStage_A.Text = My.Resources.setLan.ResourceManager.GetObject("PLC_Control_Stage")
            .btnInit.Text = My.Resources.setLan.ResourceManager.GetObject("Init")
            .btnMain.Text = My.Resources.setLan.ResourceManager.GetObject("Main")
            .btnRecipe.Text = My.Resources.setLan.ResourceManager.GetObject("Recipe")
            .btnSetting.Text = My.Resources.setLan.ResourceManager.GetObject("Setting")
            .btnExit.Text = My.Resources.setLan.ResourceManager.GetObject("SWExit")

        End With

        'Form
        frmSetting.LanChange(StrCulture)
        frmRecipe.LanChange(StrCulture)

        frmInit.LanChange(StrCulture)
        frmAlarm.LanChange(StrCulture)
        frmAlignDataView.LanChange(StrCulture)
        frmAlignMarkSetting.LanChange(StrCulture)
        frmInit.LanChange(StrCulture)
        frmLog.LanChange(StrCulture)
        frmLogIn.LanChange(StrCulture)
        frmMachine.LanChange(StrCulture)
        frmMarkChangeMSG.LanChange(StrCulture)
        frmMarkDataEditer.LanChange(StrCulture)
        frmMSG.LanChange(StrCulture)
        frmSequence.LanChange(StrCulture)
        frmSeqVision.LanChange(StrCulture)
        frmVision.LanChange(StrCulture)
        frmVisionLightParam.LanChange(StrCulture)

        'frmSettingModigm.LanChange(StrCulture)
        'frmVisonSetting.LanChange(StrCulture)
        'frmDigitalIO.LanChange(StrCulture)
        'frmRunStatus.LanChange(StrCulture)

        'UserCtrl


    End Sub


    
End Class