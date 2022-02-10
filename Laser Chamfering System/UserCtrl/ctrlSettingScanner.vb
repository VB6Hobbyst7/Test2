Public Class ctrlSettingScanner

    Public m_iIndex As Integer  ' scanner index
    '20160918 pcw
    Dim nSelectedScanner As Integer = 0

    Public OperationSeq As clsOperationSequence



    Public Sub New(ByVal nIndex As Integer)
        InitializeComponent()

        Dim tmpPath() As String = {}

        m_iIndex = nIndex

        numScanBit.Value = pCurSystemParam.nScannerScanScale(m_iIndex)
        tmpPath = Split(pCurSystemParam.strScannerCorFilePath(m_iIndex), "\")
        txtCorFile.Text = tmpPath(tmpPath.Length - 1)
        tmpPath = Split(pCurSystemParam.strScannerHexFilePath(m_iIndex), "\")

        numScanMarkSPD.Value = pCurSystemParam.nScanMarkSpeed(m_iIndex)
        numScanJumpSPD.Value = pCurSystemParam.nScanJumpSpeed(m_iIndex)

        ' system parameter
        numHalfPulsePeriod.Value = pCurSystemParam.nScanHalfPulseWith(m_iIndex)
        numPulseWidth1.Value = pCurSystemParam.nScanPulseWidth1(m_iIndex)
        numPulseWidth2.Value = pCurSystemParam.nScanPulseWidth2(m_iIndex)
        numScanLaserOnDelay.Value = pCurSystemParam.nScanLaserOnDelay(m_iIndex)
        numScanLaserOffDelay.Value = pCurSystemParam.nScanLaserOffDelay(m_iIndex)
        numScanJumpDelay.Value = pCurSystemParam.nScanJumpDelay(m_iIndex)
        numScanMarkDelay.Value = pCurSystemParam.nScanMarkDelay(m_iIndex)
        numScanPolygonDelay.Value = pCurSystemParam.nScanPolygonDelay(m_iIndex)

    End Sub


    Private Sub ctrlSettingScanner_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' lblScanner.Text = "Scanner #" & (m_iIndex + 1).ToString
        'FormSetting()
        If bLogInUser = True Or bLogInTech = True Then
            GroupBox1.Enabled = False
            gbScannerLaserParam.Enabled = False
            gbScannerAxisParam.Enabled = False
            gbScannerSimpleMark.Enabled = False
            gbScannerShotTest.Enabled = False
        ElseIf bLogInAdmin = True Then
            GroupBox1.Enabled = True
            gbScannerLaserParam.Enabled = True
            gbScannerAxisParam.Enabled = True
            gbScannerSimpleMark.Enabled = True
            gbScannerShotTest.Enabled = True
        End If
        btnInitScanner.Text = "Init Scanner #" & (m_iIndex + 1).ToString
    End Sub

    Private Sub btnInitScanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitScanner.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmSetting - btnInitScanner_Click")

        Dim bInitialized As Boolean = False


        pScannerThread.bSeqRun(0) = False
        pScannerThread.bSeqRun(1) = False
        pScannerThread.bSeqRun(2) = False
        pScannerThread.bSeqRun(3) = False


        pScanner(m_iIndex).SetCorrectionFilePath(pCurSystemParam.strScannerCorFilePath(m_iIndex))
        pScanner(m_iIndex).SetProgramFilePath(pCurSystemParam.strScannerHexFilePath(m_iIndex))

        bInitialized = pScanner(m_iIndex).RTC6Init()

        If bInitialized Then

            pScanner(m_iIndex).SetScanScale(1000 / numScanBit.Value)

            pScanner(m_iIndex).SetMarkSpeed(pCurSystemParam.nScanMarkSpeed(m_iIndex))
            pScanner(m_iIndex).SetJumpSpeed(pCurSystemParam.nScanJumpSpeed(m_iIndex))
            pScanner(m_iIndex).SetPulsePeriod(pCurSystemParam.nScanHalfPulseWith(m_iIndex))
            pScanner(m_iIndex).SetPulseWidth1(pCurSystemParam.nScanPulseWidth1(m_iIndex))
            pScanner(m_iIndex).SetPulseWidth2(pCurSystemParam.nScanPulseWidth2(m_iIndex))
            pScanner(m_iIndex).SetLaserOnDelay(pCurSystemParam.nScanLaserOnDelay(m_iIndex))
            pScanner(m_iIndex).SetLaserOffDelay(pCurSystemParam.nScanLaserOffDelay(m_iIndex))
            pScanner(m_iIndex).SetJumpDelay(pCurSystemParam.nScanJumpDelay(m_iIndex))
            pScanner(m_iIndex).SetMarkDelay(pCurSystemParam.nScanMarkDelay(m_iIndex))
            pScanner(m_iIndex).SetPolygonDelay(pCurSystemParam.nScanPolygonDelay(m_iIndex))

        End If

        pScanner(m_iIndex).RTC6SetMatrix(0)

        pScannerThread.bSeqRun(0) = True
        pScannerThread.bSeqRun(1) = True
        pScannerThread.bSeqRun(2) = True
        pScannerThread.bSeqRun(3) = True

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnInitScanner_Click")
    End Sub

    Private Sub btnCorLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorLoad.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnCorLoad_Click")
        Dim OpenFile As New OpenFileDialog
        Dim strPath As String = ""
        Dim tmpStr() As String = {}

        OpenFile.InitialDirectory = SCANNER_PROGRAM_PATH
        OpenFile.Filter = "ct5 files (*.ct5)|*.ct5|All files (*.*)|*.*"
        OpenFile.ShowDialog()
        strPath = OpenFile.FileName
        If strPath = "" Then Exit Sub
        pScanner(m_iIndex).SetCorrectionFilePath(strPath)

        tmpStr = Split(strPath, "\")
        txtCorFile.Text = tmpStr(tmpStr.Length - 1)
        OpenFile.Dispose()

        OpenFile = Nothing

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnCorLoad_Click")
    End Sub


    Private Sub btnScanParamApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanParamApply.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmSetting - btnScanParamApply_Click")

        ' recipe
        'pSetRecipe.strScannerCorFilePath(m_iIndex) = SCANNER_PROGRAM_PATH & txtCorFile.Text
        'pSetRecipe.strScannerHexFilePath(m_iIndex) = SCANNER_PROGRAM_PATH
        'pSetRecipe.nScannerScanScale(m_iIndex) = numScanBit.Value
        'pSetRecipe.PenData.MarkSpeed(m_iIndex) = numScanMarkSPD.Value
        'pSetRecipe.PenData.JumpSpeed(m_iIndex) = numScanJumpSPD.Value

        'pScanner(m_iIndex).SetScanScale(pSetRecipe.nScannerScanScale(m_iIndex))

        ' system parameter
        'pSetSystemParam.nScanHalfPulseWith = numHalfPulsePeriod.Value
        'pSetSystemParam.nScanPulseWidth = numPulseWidth1.Value
        'pSetSystemParam.nScanLaserOnDelay = numScanLaserOnDelay.Value
        'pSetSystemParam.nScanLaserOffDelay = numScanLaserOffDelay.Value
        'pSetSystemParam.nScanJumpDelay = numScanJumpDelay.Value
        'pSetSystemParam.nScanMarkDelay = numScanMarkDelay.Value
        'pSetSystemParam.nScanPolygonDelay = numScanPolygonDelay.Value

        '
        pScanner(m_iIndex).SetPulsePeriod(numHalfPulsePeriod.Value)
        pScanner(m_iIndex).SetPulseWidth1(numPulseWidth1.Value)
        pScanner(m_iIndex).SetPulseWidth2(numPulseWidth2.Value)
        pScanner(m_iIndex).SetLaserOnDelay(numScanLaserOnDelay.Value)
        pScanner(m_iIndex).SetLaserOffDelay(numScanLaserOffDelay.Value)
        pScanner(m_iIndex).SetJumpDelay(numScanJumpDelay.Value)
        pScanner(m_iIndex).SetMarkDelay(numScanMarkDelay.Value)
        pScanner(m_iIndex).SetPolygonDelay(numScanPolygonDelay.Value)
        pScanner(m_iIndex).SetMarkSpeed(numScanMarkSPD.Value)
        pScanner(m_iIndex).SetJumpSpeed(numScanJumpSPD.Value)

        pScanner(m_iIndex).RTC6ParamApply()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnScanParamApply_Click")
    End Sub

    Private Sub chkMarkLineAxis_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarkLineAxis.CheckedChanged
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - chkMarkLineAxis_CheckedChanged")
        If chkMarkLineAxis.Checked = True Then
            chkMarkLineAxis.Text = "Axis X"
        ElseIf chkMarkLineAxis.Checked = False Then
            chkMarkLineAxis.Text = "Axis Y"
        End If
        Exit Sub
SysErr:
    End Sub


    Private Sub btnMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMark.Click
        Try
            modPub.SystemLog("frmSetting - btnMark_Click")
            Dim nMarkSize As Integer = numMarkSize.Value

            'GYN - Scanner Move 0,0
            pScanner(m_iIndex).RTC6ABSMove(0, 0)

            If optMarkLine.Checked = True Then

                pScanner(m_iIndex).RTC6MarkLine(nMarkSize, 0, 0, numScanRepeat.Value, chkMarkLineAxis.Checked)

                'pScanner(m_iIndex).RTC6SetMatrix(90)
                'modRecipe.ExecuteMarking(m_iIndex, 0, 0, 0, pCurRecipe.RecipeMarkingData(0, m_iIndex), pCurRecipe.PenData, True)

            ElseIf optMarkRect.Checked = True Then

                pScanner(m_iIndex).RTC6MarkRect(nMarkSize, nMarkSize, 0, 0, numScanRepeat.Value)

            ElseIf optMarkCircle.Checked = True Then

                'pScanner(m_iIndex).RTC6MarkCircle(nMarkSize, 0, 0, numScanRepeat.Value)

                'If m_iIndex = 0 Then
                '    '    ' 지워야함 임시 20161008 JCM
                pScanner(m_iIndex).RTC6SetMatrix(270)
                'Else
                'pScanner(m_iIndex).RTC6SetMatrix(90)
                'End If
                'm_iIndex <-Scanner Bumber

                'LINE(A)
                'modRecipe.ExecuteMarking(m_iIndex, 0, 0, 0, pCurRecipe.RecipeMarkingData(0, m_iIndex), pCurRecipe.PenData, True)
                'Line B
                modRecipe.ExecuteMarking(m_iIndex, 0, 0, 0, pCurRecipe.RecipeMarkingData(1, m_iIndex), pCurRecipe.PenData, True)


            End If
        Catch ex As Exception
            MsgBox(ex.Message & "at " & Me.ToString)
        End Try

    End Sub

    Private Sub btnScanShotBurstOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanShotBurstOn.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnScanShotBurstOn_Click")

        'GYN - Scanner Move 0,0
        pScanner(m_iIndex).RTC6ABSMove(0, 0)

        If optUsePowerMeter.Checked = True Then
            pPowerMeter(m_iIndex).UsePowerMeter = True
            pPowerMeter(4).UsePowerMeter = True
        Else
            pPowerMeter(m_iIndex).UsePowerMeter = False
            pPowerMeter(4).UsePowerMeter = False
        End If

        pScanner(m_iIndex).RTC6LaserShotOnTime(numLaserOnTime.Value)
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnScanShotBurstOn_Click")
    End Sub

    Private Sub btnScanShotContinousOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanShotContinousOn.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnScanShotContinousOn_Click")

        'GYN - Scanner Move 0,0
        pScanner(m_iIndex).RTC6ABSMove(0, 0)

        If optUsePowerMeter.Checked = True Then
            pPowerMeter(m_iIndex).UsePowerMeter = True
            pPowerMeter(4).UsePowerMeter = True
        Else
            pPowerMeter(m_iIndex).UsePowerMeter = False
            pPowerMeter(4).UsePowerMeter = False
        End If

        System.Threading.Thread.Sleep(1000)

        pScanner(m_iIndex).RTC6LaserShotOn()
        'pScanner(m_iIndex).RTC6LaserShotOn()
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnScanShotContinousOn_Click")
    End Sub

    Private Sub btnScanShotOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScanShotOff.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnScanShotOff_Click")

        pPowerMeter(m_iIndex).UsePowerMeter = False
        pPowerMeter(4).UsePowerMeter = False

        pScanner(m_iIndex).RTC6LaserShotOff()
        pScanner(m_iIndex).RTC6StopAll()
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnScanShotOff_Click")
    End Sub



    Public Sub ScannerStatus()
        On Error GoTo SysErr

        If pScanner(m_iIndex).pStatus.bInit = True Then
            If pScanner(m_iIndex).pStatus.bAbleWork = True Then
                txtScanWork.Text = "Able to Work"
                txtScanWork.BackColor = Color.Lime
            ElseIf pScanner(m_iIndex).pStatus.bAbleWork = False Then
                txtScanWork.Text = "Now Working"
                txtScanWork.BackColor = Color.Red
            End If

            lblScanStatusX.Text = pScanner(m_iIndex).pStatus.dPosX
            lblScanStatusY.Text = pScanner(m_iIndex).pStatus.dPosY
        Else
            txtScanWork.BackColor = Color.Gray
        End If


        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- Timer_Laser1Status")
    End Sub


    Private Sub optUsePowerMeter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optUsePowerMeter.CheckedChanged

        If optUsePowerMeter.Checked = True Then
            optUsePowerMeter.BackColor = Color.LimeGreen
        Else
            optUsePowerMeter.BackColor = Color.White
        End If

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .lblScanBit1.Text = My.Resources.setLan.ResourceManager.GetObject("Bitmm")

            .lblScanAngle1.Text = My.Resources.setLan.ResourceManager.GetObject("Angle5")
            .lblCor1.Text = My.Resources.setLan.ResourceManager.GetObject("CorrectionFile")
            .btnCorLoad.Text = My.Resources.setLan.ResourceManager.GetObject("Load")
            .btnInitScanner.Text = My.Resources.setLan.ResourceManager.GetObject("InitScanner1")

            .gbScannerLaserParam.Text = My.Resources.setLan.ResourceManager.GetObject("ScannerLaserParameter")
            .lblPw11.Text = My.Resources.setLan.ResourceManager.GetObject("PulseWidth1")
            .lblPw21.Text = My.Resources.setLan.ResourceManager.GetObject("PulseWidth2")
            .lblFreq1.Text = My.Resources.setLan.ResourceManager.GetObject("HalfPulsePeriod")

            .lblOnD1.Text = My.Resources.setLan.ResourceManager.GetObject("LaserOnDelay")
            .lblOffD1.Text = My.Resources.setLan.ResourceManager.GetObject("LaserOffDelay")
            .gbScannerAxisParam.Text = My.Resources.setLan.ResourceManager.GetObject("ScannerAxisParameter")
            .lblJumpS1.Text = My.Resources.setLan.ResourceManager.GetObject("JumpSpeed")

            .lblMarkS1.Text = My.Resources.setLan.ResourceManager.GetObject("MarkSpeed")

            .lblJumpD1.Text = My.Resources.setLan.ResourceManager.GetObject("JumpDelay")
            .lblMarkD1.Text = My.Resources.setLan.ResourceManager.GetObject("MarkDelay")
            .lblPolyD1.Text = My.Resources.setLan.ResourceManager.GetObject("PolygonDelay")
            .gbScanStatus.Text = My.Resources.setLan.ResourceManager.GetObject("Statusmm")

            .btnScanParamApply.Text = My.Resources.setLan.ResourceManager.GetObject("ApplyScannerParameter")

            .optUsePowerMeter.Text = My.Resources.setLan.ResourceManager.GetObject("Powermetermanualuse")
            .gbScannerSimpleMark.Text = My.Resources.setLan.ResourceManager.GetObject("SimpleLaserMarking")
            .optMarkLine.Text = My.Resources.setLan.ResourceManager.GetObject("Line")
            .chkMarkLineAxis.Text = My.Resources.setLan.ResourceManager.GetObject("AxisY")

            .optMarkRect.Text = My.Resources.setLan.ResourceManager.GetObject("Rect")
            .optMarkCircle.Text = My.Resources.setLan.ResourceManager.GetObject("Circle")

            .lbl11.Text = My.Resources.setLan.ResourceManager.GetObject("Size")
            .lbl12.Text = My.Resources.setLan.ResourceManager.GetObject("Repeat")

            .btnMark.Text = My.Resources.setLan.ResourceManager.GetObject("Mark")

            .gbScannerShotTest.Text = My.Resources.setLan.ResourceManager.GetObject("LaserShot")
            .btnScanShotBurstOn.Text = My.Resources.setLan.ResourceManager.GetObject("On1")
            .btnScanShotContinousOn.Text = My.Resources.setLan.ResourceManager.GetObject("Continous")
            .btnScanShotOff.Text = My.Resources.setLan.ResourceManager.GetObject("Off")

        End With

    End Sub

    Private Sub btnScannerParamSave_Click(sender As System.Object, e As System.EventArgs) Handles btnScannerParamSave.Click

        modPub.SystemLog("ctrlSettingScanner -- btnScannerParamSave Click")

        pSetSystemParam.nScanPolygonDelay(m_iIndex) = numScanPolygonDelay.Value
        pSetSystemParam.nScanMarkDelay(m_iIndex) = numScanMarkDelay.Value
        pSetSystemParam.nScanJumpDelay(m_iIndex) = numScanJumpDelay.Value
        pSetSystemParam.nScanMarkSpeed(m_iIndex) = numScanMarkSPD.Value
        pSetSystemParam.nScanJumpSpeed(m_iIndex) = numScanJumpSPD.Value
        pSetSystemParam.nScanPulseWidth1(m_iIndex) = numPulseWidth1.Value
        pSetSystemParam.nScanPulseWidth2(m_iIndex) = numPulseWidth2.Value
        pSetSystemParam.nScanLaserOnDelay(m_iIndex) = numScanLaserOnDelay.Value
        pSetSystemParam.nScanLaserOffDelay(m_iIndex) = numScanLaserOffDelay.Value
        pSetSystemParam.nScanHalfPulseWith(m_iIndex) = numHalfPulsePeriod.Value

        modParam.SaveParam(pStrTmpSystemRoot, pSetSystemParam)

        pCurSystemParam = pSetSystemParam

    End Sub

    Private Sub btnMoveX_Click(sender As System.Object, e As System.EventArgs) Handles btnMoveX.Click

        Dim nScannerX As Integer = 0
        Dim nScannerY As Integer = 0

        nScannerX = NumX.Value
        nScannerY = NumY.Value

        nScannerX = nScannerX ' * pScanner(m_iIndex).GetScanScale()
        nScannerY = nScannerY ' * pScanner(m_iIndex).GetScanScale()

        pScanner(m_iIndex).RTC6ABSMove(nScannerX, nScannerY)
    End Sub

    Private Sub btnAutoSeq_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoSeq.Click
        frmAutoFocus.Show()
    End Sub

End Class
