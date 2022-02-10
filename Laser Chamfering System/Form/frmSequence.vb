Public Class frmSequence
    Dim strRtn As String = ""
    Public bDrawManualAlign As Boolean = False

    Dim nSequenceIndex(1) As Integer
    Dim tmpAlignRetry(1) As Integer
    Dim tmpCurAlignRetry(1) As Integer
    Dim nExSequenceIndex(1) As Integer
    Dim bStop(1) As Boolean
    Public nManualAlign(1) As Integer
    Public bManualAlign(1, 3, 1)            ' line, glass, mark
    Public bManualAlignGet(1, 3, 1)            ' line, glass, mark
    Dim nCheckGlassRetry(1) As Integer
    Dim nCurGlassRetry(1) As Integer
    Dim bMoveStartPos(1) As Boolean
    Dim bMoveGlassOutPos(1) As Boolean

    Dim dAlignDistance_A As Double = 0

    'Public pManaulAlignPopUp_A = False
    'Public pManaulAlignPopUp_B = False

    Private Sub frmSequence_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        tmSequence.Enabled = False
    End Sub

    Private Sub frmSequence_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tmSequence.Enabled = True
    End Sub

    Public pbManualAlign_A As Boolean = False
    Public pbManualAlign_B As Boolean = False


    Private Sub tmSequence_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmSequence.Tick
        On Error GoTo SysErr

        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then

            If Seq(LINE.A).m_bSet = False Then
                If Seq(LINE.B).bUseManualAlign = False Then
                    If Seq(LINE.A).bManualAlignMode = True Then
                        If Seq(LINE.A).bManualAlignPopUp = False And Seq(LINE.B).bManualAlignPopUp = False Then
                            Seq(LINE.A).bManualAlignPopUp = True
                            pbManualAlign_A = True
                            frmMSG.ShowMsg("A Line Manual Align", "Move to Manual Alignment Mode?", False, 2)
                        End If
                    End If
                End If
            End If

            If Seq(LINE.B).m_bSet = False Then
                If Seq(LINE.A).bUseManualAlign = False Then
                    If Seq(LINE.B).bManualAlignMode = True And Seq(LINE.A).bManualAlignMode = False Then
                        If Seq(LINE.A).bManualAlignPopUp = False And Seq(LINE.B).bManualAlignPopUp = False Then
                            Seq(LINE.B).bManualAlignPopUp = True
                            pbManualAlign_B = True
                            frmMSG.ShowMsg("B Line Manual Align", "Move to Manual Alignment Mode?", False, 2)
                        End If
                    End If
                End If
            End If

        End If

        If Seq(LINE.A).m_bSet = False And Seq(LINE.B).m_bSet = False Then
            CacheMemoryResetTime()
        End If

        'SBS_20180730 팝업 알람도 안뜨고, Light Alarm도 안뜨고 쩝.. Light Alarm을 띄울려고 수정한것 같아서 이방향으로 수정
        'If Seq(LINE.A).bDistanceError = True Then
        '    frmMSG.ShowMsg("A Line Mark Distance Error", "A라인 운전 정지 후 재 시작 바랍니다.", False, 3)
        '    'Seq(LINE.A).bDistanceError = False
        'End If

        'If Seq(LINE.B).bDistanceError = True Then
        '    frmMSG.ShowMsg("B Line Mark Distance Error", "B라인 운전 정지 후 재 시작 바랍니다.", False, 3)
        '    'Seq(LINE.B).bDistanceError = False
        'End If

        If Seq(LINE.A).bMarkUseError = True Then
            frmMSG.ShowMsg("A Line Mark Error", "3개 마크중 하나의 마크를 사용해주세요.", False, 3)
            'Seq(LINE.A).bDistanceError = False
        End If

        If Seq(LINE.B).bMarkUseError = True Then
            frmMSG.ShowMsg("B Line Mark Error", "3개 마크중 하나의 마크를 사용해주세요.", False, 3)
            'Seq(LINE.B).bDistanceError = False
        End If

        If Seq(LINE.A).bThetaError1 = True Then
            frmMSG.ShowMsg("A Line Panel 1번 Theta Error", "A라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.A).bDistanceError = False
        End If
        If Seq(LINE.A).bThetaError2 = True Then
            frmMSG.ShowMsg("A Line Panel 2번 Theta Error", "A라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.A).bDistanceError = False
        End If
        If Seq(LINE.A).bThetaError3 = True Then
            frmMSG.ShowMsg("A Line Panel 3번 Theta Error", "B라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.B).bDistanceError = False
        End If
        If Seq(LINE.A).bThetaError4 = True Then
            frmMSG.ShowMsg("A Line Panel 4번 Theta Error", "B라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.B).bDistanceError = False
        End If
        If Seq(LINE.B).bThetaError1 = True Then
            frmMSG.ShowMsg("B Line Panel 1번 Theta Error", "A라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.A).bDistanceError = False
        End If
        If Seq(LINE.B).bThetaError2 = True Then
            frmMSG.ShowMsg("B Line Panel 2번 Theta Error", "A라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.A).bDistanceError = False
        End If
        If Seq(LINE.B).bThetaError3 = True Then
            frmMSG.ShowMsg("B Line Panel 3번 Theta Error", "B라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.B).bDistanceError = False
        End If
        If Seq(LINE.B).bThetaError4 = True Then
            frmMSG.ShowMsg("B Line Panel 4번 Theta Error", "B라인 운전 정지 후 재 시작 바랍니다.", False, 3)
            'Seq(LINE.B).bDistanceError = False
        End If


        lblStatusLine_A.Text = Seq(LINE.A).GetStatus().ToString
        lblStatusLine_B.Text = Seq(LINE.B).GetStatus().ToString

        SetBackGroundColor(lblCheckGlass_A1, pLDLT.PLC_Infomation.bGlassExist(LINE.A, 0))                     'Check Glass A
        SetBackGroundColor(lblCheckGlass_A2, pLDLT.PLC_Infomation.bGlassExist(LINE.A, 1))
        SetBackGroundColor(lblCheckGlass_A3, pLDLT.PLC_Infomation.bGlassExist(LINE.A, 2))
        SetBackGroundColor(lblCheckGlass_A4, pLDLT.PLC_Infomation.bGlassExist(LINE.A, 3))

        SetBackGroundColor(lblAlignRequest_A1, pLDLT.PLC_Infomation.bAlignRequest(LINE.A, 0))                 'Align Request A
        SetBackGroundColor(lblAlignRequest_A2, pLDLT.PLC_Infomation.bAlignRequest(LINE.A, 1))
        SetBackGroundColor(lblAlignRequest_A3, pLDLT.PLC_Infomation.bAlignRequest(LINE.A, 2))
        SetBackGroundColor(lblAlignRequest_A4, pLDLT.PLC_Infomation.bAlignRequest(LINE.A, 3))

        SetBackGroundColor(lblCheckAlign_A1, pLDLT.PC_Infomation.bAlignOK1(LINE.A))                   'Align A OK
        SetBackGroundColor(lblCheckAlign_A2, pLDLT.PC_Infomation.bAlignOK2(LINE.A))
        SetBackGroundColor(lblCheckAlign_A3, pLDLT.PC_Infomation.bAlignOK3(LINE.A))
        SetBackGroundColor(lblCheckAlign_A4, pLDLT.PC_Infomation.bAlignOK4(LINE.A))

        SetBackGroundColor(lblCheckAlign_A1, pLDLT.PC_Infomation.bAlignNG1(LINE.A), 1)                   'Align A NG
        SetBackGroundColor(lblCheckAlign_A2, pLDLT.PC_Infomation.bAlignNG2(LINE.A), 1)
        SetBackGroundColor(lblCheckAlign_A3, pLDLT.PC_Infomation.bAlignNG3(LINE.A), 1)
        SetBackGroundColor(lblCheckAlign_A4, pLDLT.PC_Infomation.bAlignNG4(LINE.A), 1)

        SetBackGroundColor(lblLaserStartRequest_L1_A, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.A, 0))                   'Laser Start Request A
        SetBackGroundColor(lblLaserStartRequest_L2_A, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.A, 1))
        SetBackGroundColor(lblLaserStartRequest_L3_A, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.A, 2))
        SetBackGroundColor(lblLaserStartRequest_L4_A, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.A, 3))

        SetBackGroundColor(lblTrimmingComplete_A_PC, pLDLT.PC_Infomation.bTrimmingComp(LINE.A))                     'A Line Trimming Complete

        SetBackGroundColor(lblCheckGlass_B1, pLDLT.PLC_Infomation.bGlassExist(LINE.B, 0))                     'Check Glass B
        SetBackGroundColor(lblCheckGlass_B2, pLDLT.PLC_Infomation.bGlassExist(LINE.B, 1))
        SetBackGroundColor(lblCheckGlass_B3, pLDLT.PLC_Infomation.bGlassExist(LINE.B, 2))
        SetBackGroundColor(lblCheckGlass_B4, pLDLT.PLC_Infomation.bGlassExist(LINE.B, 3))

        SetBackGroundColor(lblAlignRequest_B1, pLDLT.PLC_Infomation.bAlignRequest(LINE.B, 0))                 'Align Request B
        SetBackGroundColor(lblAlignRequest_B2, pLDLT.PLC_Infomation.bAlignRequest(LINE.B, 1))
        SetBackGroundColor(lblAlignRequest_B3, pLDLT.PLC_Infomation.bAlignRequest(LINE.B, 2))
        SetBackGroundColor(lblAlignRequest_B4, pLDLT.PLC_Infomation.bAlignRequest(LINE.B, 3))

        SetBackGroundColor(lblCheckAlign_B1, pLDLT.PC_Infomation.bAlignOK1(LINE.B))                   'Align B OK
        SetBackGroundColor(lblCheckAlign_B2, pLDLT.PC_Infomation.bAlignOK2(LINE.B))
        SetBackGroundColor(lblCheckAlign_B3, pLDLT.PC_Infomation.bAlignOK3(LINE.B))
        SetBackGroundColor(lblCheckAlign_B4, pLDLT.PC_Infomation.bAlignOK4(LINE.B))

        SetBackGroundColor(lblCheckAlign_B1, pLDLT.PC_Infomation.bAlignNG1(LINE.B), 1)                   'Align B NG
        SetBackGroundColor(lblCheckAlign_B2, pLDLT.PC_Infomation.bAlignNG2(LINE.B), 1)
        SetBackGroundColor(lblCheckAlign_B3, pLDLT.PC_Infomation.bAlignNG3(LINE.B), 1)
        SetBackGroundColor(lblCheckAlign_B4, pLDLT.PC_Infomation.bAlignNG4(LINE.B), 1)


        SetBackGroundColor(lblLaserStartRequest_L1_B, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.B, 0))                   'Laser Start Request B
        SetBackGroundColor(lblLaserStartRequest_L2_B, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.B, 1))
        SetBackGroundColor(lblLaserStartRequest_L3_B, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.B, 2))
        SetBackGroundColor(lblLaserStartRequest_L4_B, pLDLT.PLC_Infomation.bLaserMarkingRequest(LINE.B, 3))

        SetBackGroundColor(lblTrimmingComplete_B_PC, pLDLT.PC_Infomation.bTrimmingComp(LINE.B))                     'B Line Trimming Complete

        '------------------------------------------------------------------------------------------------
        'sbs_20180809 측정지연 알람 발생으로 인해 frmTopMenu Timer에서 여기 Timer로 옮김
        'Auto Mode, Manual Mode 의 변수 Bit를 CMelsce에서 기존 100ms마다 호출되는데
        'frmTopMenu도 동일하게 100ms이기 때문에 시간차로 인해 bAutoLock_A, bAutoLock_B 변수가 잘못 셋팅되어
        'Seq가 Start되지 못하는 경우가 발생 이로 인해 Time Tick이 빠른 여기로 옮김

        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.A) = True Then
            If frmTopMenu.bAutoLock_A = False Then
                frmTopMenu.bAutoLock_A = True

                btnStart_A.BackColor = Color.Lime
                btnStop_A.BackColor = Color.White

                frmTopMenu.lblAuto_Manual_A.Text = "A - Auto Mode"
                frmTopMenu.lblAuto_Manual_A.BackColor = Color.Lime
                ' UnlockProgram(False)
                pLDLT.ResetMoveBit()

                'GYN - LogIn 완료 후 동작되도록 수정
                If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
                    Seq(LINE.A).StartSeq()
                End If

            End If

        Else

            If frmTopMenu.bAutoLock_A = True Then
                frmTopMenu.bAutoLock_A = False

                btnStart_A.BackColor = Color.White
                btnStop_A.BackColor = Color.Red

                frmTopMenu.lblAuto_Manual_A.Text = "A - Manual Mode"
                frmTopMenu.lblAuto_Manual_A.BackColor = Color.Yellow
                pLDLT.ResetMoveBit()

                Seq(LINE.A).StopSeq()

            End If

        End If

        If pLDLT.PLC_Infomation.bPLC_AutoMode(LINE.B) = True Then
            If frmTopMenu.bAutoLock_B = False Then
                frmTopMenu.bAutoLock_B = True

                btnStart_B.BackColor = Color.Lime
                btnStop_B.BackColor = Color.White
                frmTopMenu.lblAuto_Manual_B.Text = "B - Auto Mode"
                frmTopMenu.lblAuto_Manual_B.BackColor = Color.Lime
                ' UnlockProgram(False)
                pLDLT.ResetMoveBit()

                'GYN - LogIn 완료 후 동작되도록 수정
                If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
                    Seq(LINE.B).StartSeq()
                End If

            End If

        Else

            If frmTopMenu.bAutoLock_B = True Then
                frmTopMenu.bAutoLock_B = False

                btnStart_B.BackColor = Color.White
                btnStop_B.BackColor = Color.Red
                frmTopMenu.lblAuto_Manual_B.Text = "B - Manual Mode"
                frmTopMenu.lblAuto_Manual_B.BackColor = Color.Yellow
                pLDLT.ResetMoveBit()
                Seq(LINE.B).StopSeq()

            End If

        End If
        '------------------------------------------------------------------------------------------------

        Exit Sub
SysErr:
        '20160727 JCM 

    End Sub

    Private Sub SetBackGroundColor(ByRef form As Label, ByVal On_Off As Boolean, Optional ByVal division As Integer = 0)
        If On_Off Then
            Select Case division
                Case 0
                    form.BackColor = Color.Lime
                Case 1
                    form.BackColor = Color.Red
                Case 2
                    form.BackColor = Color.DarkOrange
            End Select
        Else
            form.BackColor = Color.Silver
        End If
    End Sub
    
    Private Sub SetOnOffText(ByRef form As Label, ByVal isOn As Boolean)
        If isOn Then
            form.Text = "ON"
        Else
            form.Text = "OFF"
        End If
    End Sub



    Private Sub LoadPictureBoxImage(ByVal ipPictureBox As PictureBox, ByVal ipImagePath As String)
        On Error GoTo SysErr

        If Not ipPictureBox.Image Is Nothing Then
            ipPictureBox.Image.Dispose()
        End If

        ipPictureBox.Load(ipImagePath)

        Exit Sub
SysErr:
    End Sub

    Private Sub UpdateUI_MarkingStatus(ByVal isOk As Boolean, ByVal nLine As Integer, ByVal nPanel As Integer)
        LoadPictureBoxImage(frmSeqVision.ctrlVision(nLine, nPanel).picMark1, pCurSystemParam.strSystemRootPath & "\StartAlign.jpg")
        frmSeqVision.ctrlVision(nLine, nPanel).lblScoreMark1.ForeColor = Color.Gray
        frmSeqVision.ctrlVision(nLine, nPanel).lblScoreMark1.Text = "--"
        frmSeqVision.ctrlVision(nLine, nPanel).lblDiffPosX_Mark1.Text = "Position X : 000.000"
        frmSeqVision.ctrlVision(nLine, nPanel).lblDiffPosY_Mark1.Text = "Position Y : 000.000"
        frmSeqVision.ctrlVision(nLine, nPanel).lblOK_Mark1.ForeColor = Color.Gray
        frmSeqVision.ctrlVision(nLine, nPanel).lblOK_Mark1.Text = "--"

        LoadPictureBoxImage(frmSeqVision.ctrlVision(nLine, nPanel).picMark2, pCurSystemParam.strSystemRootPath & "\StartAlign.jpg")
        frmSeqVision.ctrlVision(nLine, nPanel).lblScoreMark2.ForeColor = Color.Gray
        frmSeqVision.ctrlVision(nLine, nPanel).lblScoreMark2.Text = "--"
        frmSeqVision.ctrlVision(nLine, nPanel).lblDiffPosX_Mark2.Text = "Position X : 000.000"
        frmSeqVision.ctrlVision(nLine, nPanel).lblDiffPosY_Mark2.Text = "Position Y : 000.000"
        frmSeqVision.ctrlVision(nLine, nPanel).lblOK_Mark2.ForeColor = Color.Gray
        frmSeqVision.ctrlVision(nLine, nPanel).lblOK_Mark2.Text = "--"
        frmSeqVision.ctrlVision(nLine, nPanel).lblDistance.Text = "Distance : 000.000"
    End Sub

    Private Sub btnStart_A_Click(sender As System.Object, e As System.EventArgs) Handles btnStart_A.Click
        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
#If HEAD_2 Then
            BcrSeq(LINE.A).StartSeq()
#End If
            Seq(LINE.A).StartSeq()
            modPub.SystemLog("btnStart_A_Click")
        End If
    End Sub

    Private Sub btnStop_A_Click(sender As System.Object, e As System.EventArgs) Handles btnStop_A.Click
        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
#If HEAD_2 Then
            BcrSeq(LINE.A).StopSeq()
#End If
            Seq(LINE.A).StopSeq()
            modPub.SystemLog("btnStop_A_Click")
        End If
    End Sub

    Private Sub btnStart_B_Click(sender As System.Object, e As System.EventArgs) Handles btnStart_B.Click
        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
#If HEAD_2 Then
            BcrSeq(LINE.B).StartSeq()
#End If
            Seq(LINE.B).StartSeq()
            modPub.SystemLog("btnStart_B_Click")
        End If
    End Sub

    Private Sub btnStop_B_Click(sender As System.Object, e As System.EventArgs) Handles btnStop_B.Click
        'GYN - LogIn 완료 후 동작되도록 수정
        If bLogInUser = True Or bLogInTech = True Or bLogInAdmin = True Then
#If HEAD_2 Then
            BcrSeq(LINE.B).StopSeq()
#End If
            Seq(LINE.B).StopSeq()
            modPub.SystemLog("btnStop_B_Click")
        End If
    End Sub

Public Sub New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

    End Sub

    Public Function StartSequence(ByVal nLine As Integer) As Boolean
        On Error GoTo SysErr
        Seq(nLine).StartSeq()
#If HEAD_2 Then
        BcrSeq(nLine).StartSeq()
#End If
        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Public Function StopSequence(ByVal nLine As Integer) As Boolean
        On Error GoTo SysErr
        Seq(nLine).StopSeq()
#If HEAD_2 Then
        BcrSeq(nLine).StopSeq()
#End If
        Return True
        Exit Function
SysErr:
        Return False
    End Function


    Private Sub Label30_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub Label66_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub Label65_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Public Top_Power As Boolean = False
    Private Sub BtnTopPower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTopPower.Click
        Top_Power = True
        PowerMeterLogLoad(0)
    End Sub

    Private Sub btnStagePower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStagePower.Click
        Top_Power = False
        PowerMeterLogLoad(0)
    End Sub
    Private Function CacheMemoryResetTime() As Boolean
        Dim dateMemoryResetToday As Date
        Dim dateMemoryResetAdddays As Date
        Dim strFileName As String = ""
        dateMemoryResetToday = Format(CDate(Date.Today), "yyyy-MM-dd")
        dateMemoryResetAdddays = Format(CDate(Now.AddDays(1)), "yyyy-MM-dd")
        If dateMemoryResetToday = dateMemoryResetAdddays Then
            strFileName = "C:\Chamfering System\Memory\DynCache.exe"

            'Me.Cursor = New Cursor(OpenFileDialog1.OpenFile())
            Process.Start(strFileName)
        End If
    End Function

    'Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
    '    CacheMemoryResetTime()
    'End Sub
    Private Sub BtnTest_Click(sender As System.Object, e As System.EventArgs) Handles BtnTest.Click

    End Sub

    Private Sub lblTrimmingComplete_A_PC_Click(sender As System.Object, e As System.EventArgs) Handles lblTrimmingComplete_A_PC.Click

        Dim nRet As Integer = -1
        'nRet = MsgBox("Cutting Complete A Bit, Reset?", MsgBoxStyle.YesNo, "Reset Bit")
        nRet = MsgBox("Cutting Complete A Bit, set?", MsgBoxStyle.YesNo, "set Bit")
        If nRet = 7 Then
            Return
        End If

        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_A_TRIMMING_COMP, True)
        modPub.SystemLog("[Manual] Cutting Complete A Bit, set")
        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_A_TRIMMING_COMP, False)
        'modPub.SystemLog("[Manual] Cutting Complete A Bit, Reset")
    End Sub

    Private Sub lblTrimmingComplete_B_PC_Click(sender As System.Object, e As System.EventArgs) Handles lblTrimmingComplete_B_PC.Click

        Dim nRet As Integer = -1
        'nRet = MsgBox("Cutting Complete B Bit, Reset?", MsgBoxStyle.YesNo, "Reset Bit")
        nRet = MsgBox("Cutting Complete B Bit, set?", MsgBoxStyle.YesNo, "set Bit")
        If nRet = 7 Then
            Return
        End If
        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_B_TRIMMING_COMP, True)
        modPub.SystemLog("[Manual] Cutting Complete B Bit, set")
        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_B_TRIMMING_COMP, False)
    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .GroupBox3.Text = My.Resources.setLan.ResourceManager.GetObject("GlassAlignandTrimmingALine")
            .GroupBox4.Text = My.Resources.setLan.ResourceManager.GetObject("GlassAlignandTrimmingBLine")

            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("AlignTacs")
            .Label3.Text = My.Resources.setLan.ResourceManager.GetObject("TrimmingTacs")
            .Label4.Text = My.Resources.setLan.ResourceManager.GetObject("AlignTacs")

            .Label2.Text = My.Resources.setLan.ResourceManager.GetObject("TrimmingTacs")
            .btnStart_A.Text = My.Resources.setLan.ResourceManager.GetObject("RUNA")
            .btnStop_A.Text = My.Resources.setLan.ResourceManager.GetObject("STOPA")
            .btnStart_B.Text = My.Resources.setLan.ResourceManager.GetObject("RUNB")
            .btnStop_B.Text = My.Resources.setLan.ResourceManager.GetObject("STOPB")

            .lblCheckGlass_A1.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassA1PLCB310")
            .lblCheckGlass_A2.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassA2PLCB311")
            .lblCheckGlass_A3.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassA3PLCB312")
            .lblCheckGlass_A4.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassA4PLCB313")

            .lblCheckGlass_B1.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassB1PLCB330")
            .lblCheckGlass_B2.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassB2PLCB331")
            .lblCheckGlass_B3.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassB3PLCB332")
            .lblCheckGlass_B4.Text = My.Resources.setLan.ResourceManager.GetObject("CheckGlassB4PLCB333")

            .lblCheckAlign_A1.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA1Check")
            .lblCheckAlign_A2.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA2Check")
            .lblCheckAlign_A3.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA3Check")
            .lblCheckAlign_A4.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA4Check")

            .lblCheckAlign_B1.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB1Check")
            .lblCheckAlign_B2.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB2Check")
            .lblCheckAlign_B3.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB3Check")
            .lblCheckAlign_B4.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB4Check")

            .lblAlignRequest_A1.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA1RequsetPLCB320")
            .lblAlignRequest_A2.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA2RequsetPLCB321")
            .lblAlignRequest_A3.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA3RequsetPLCB322")
            .lblAlignRequest_A4.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA4RequsetPLCB323")

            .lblAlignRequest_B1.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB1RequsetPLCB340")
            .lblAlignRequest_B2.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB2RequsetPLCB341")
            .lblAlignRequest_B3.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB3RequsetPLCB342")
            .lblAlignRequest_B4.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB4RequsetPLCB343")

            .lblAlignComp_A1.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA1Comp")
            .lblAlignComp_A2.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA2Comp")
            .lblAlignComp_A3.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA3Comp")
            .lblAlignComp_A4.Text = My.Resources.setLan.ResourceManager.GetObject("AlignA4Comp")

            .lblAlignComp_B1.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB1Comp")
            .lblAlignComp_B2.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB2Comp")
            .lblAlignComp_B3.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB3Comp")
            .lblAlignComp_B4.Text = My.Resources.setLan.ResourceManager.GetObject("AlignB4Comp")

            .lblLaserStartRequest_L1_A.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL1RequestB350")
            .lblLaserStartRequest_L2_A.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL2RequestB351")
            .lblLaserStartRequest_L3_A.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL3RequestB352")
            .lblLaserStartRequest_L4_A.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL4RequestB353")

            .lblLaserStartRequest_L1_B.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL1RequestB354")
            .lblLaserStartRequest_L2_B.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL2RequestB355")
            .lblLaserStartRequest_L3_B.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL3RequestB356")
            .lblLaserStartRequest_L4_B.Text = My.Resources.setLan.ResourceManager.GetObject("LaserStartL4RequestB357")

            .lblTrimmingComplete_A_PC.Text = My.Resources.setLan.ResourceManager.GetObject("TrimmingCompleteA")
            .lblTrimmingComplete_B_PC.Text = My.Resources.setLan.ResourceManager.GetObject("TrimmingCompleteB")

            .gbPowerMeterLog.Text = My.Resources.setLan.ResourceManager.GetObject("PowerMeterLog")
            .Label30.Text = My.Resources.setLan.ResourceManager.GetObject("PowerMeter")
            .Label31.Text = My.Resources.setLan.ResourceManager.GetObject("Time")
            .BtnTopPower.Text = My.Resources.setLan.ResourceManager.GetObject("TopPower")
            .Label16.Text = My.Resources.setLan.ResourceManager.GetObject("Time")
            .btnStagePower.Text = My.Resources.setLan.ResourceManager.GetObject("StagePower")
            .Label53.Text = My.Resources.setLan.ResourceManager.GetObject("CurrentPower")
            .Label51.Text = My.Resources.setLan.ResourceManager.GetObject("CurrentPower")
            .Label33.Text = My.Resources.setLan.ResourceManager.GetObject("CurrentPower")
            .Label52.Text = My.Resources.setLan.ResourceManager.GetObject("CurrentPower")
            .Label29.Text = My.Resources.setLan.ResourceManager.GetObject("Mode")
            .Label17.Text = My.Resources.setLan.ResourceManager.GetObject("Mode")

        End With

    End Sub

End Class