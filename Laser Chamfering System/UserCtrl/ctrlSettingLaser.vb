Public Class ctrlSettingLaser

    Public m_iIndex As Integer = 0
    Dim bDoubleClick_Stage_A As Boolean = False
    Dim bDoubleClick_Stage_B As Boolean = False
    Dim bDoubleClick_Top_A As Boolean = False
    Dim bDoubleClick_Top_B As Boolean = False

    Dim nPowerMetrIndex_A As Integer = 0
    Dim nPowerMeterSleepCnt_A As Integer = 0
    Dim bPowerMeter_Top_A As Boolean = False
    Dim bPowerMeterLaserOff_A As Boolean = False
    Public pbPowerMeterOn_A As Boolean = False

    Dim nPowerMetrIndex_B As Integer = 0
    Dim nPowerMeterSleepCnt_B As Integer = 0
    Dim bPowerMeter_Top_B As Boolean = False
    Dim bPowerMeterLaserOff_B As Boolean = False
    '20160727 JCM Edit Scanner2 파워 메터 레이저 온 확인 비트
    Public pbPowerMeterOn_B As Boolean = False

    Dim TmpSystemFilePath As String = GetSetting("LASER_CHAMFERING", "SYSTEM", "FILE_PATH", "C:\Chamfering System\DEFAULT.ini")


    Public Sub ctrlSettingLaser()

        For i As Integer = 0 To 3
            numChillerWater.Value = pCurSystemParam.nChillerWaterDay(i)
            numChillerFilter.Value = pCurSystemParam.nChillerFilterDay(i)
        Next


    End Sub

    Public Sub FormSetting()
        numChillerWater.Value = pCurSystemParam.nChillerWaterDay(m_iIndex)
        numChillerFilter.Value = pCurSystemParam.nChillerFilterDay(m_iIndex)
    End Sub

    
    Private Sub ctrlSettingLaser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gbLaserSet.Text = "Laser #" & (Me.TabIndex + 1).ToString()
        gbLaserChiller.Text = "Chiller #" & (Me.TabIndex + 1).ToString()

        If bLogInUser = True Or bLogInTech = True Then
            gbLaser1Trigger.Enabled = False
            gbLaser1RepetitionRate.Enabled = False
        ElseIf bLogInAdmin = True Then
            gbLaser1Trigger.Enabled = True
            gbLaser1RepetitionRate.Enabled = True
        End If

    End Sub



    Private Sub btnCooldown_Click(sender As System.Object, e As System.EventArgs)
        'Try
        '    modPub.SystemLog("frmSetting - btnCooldown1_Click")
        '    pLaser(m_iIndex).SetCoolingLaser(True)
        '    Exit Sub
        'Catch ex As Exception
        '    MsgBox(ex.Message())
        'End Try
    End Sub

    Private Sub btnHeating_Click(sender As System.Object, e As System.EventArgs)
        'Try
        '    modPub.SystemLog("frmSetting - btnHeating1_Click")
        '    pLaser(m_iIndex).SetCoolingLaser(False)
        '    Exit Sub
        'Catch ex As Exception
        '    MsgBox(ex.Message())
        'End Try
    End Sub

    Private Sub btnShutterOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnShutterOpen.Click
        Try
            modPub.SystemLog("frmSetting - btnShutterOpen1_Click")
            pLaser(m_iIndex).SetShutterOpen(True)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnShutterClose_Click(sender As System.Object, e As System.EventArgs) Handles btnShutterClose.Click
        Try
            modPub.SystemLog("frmSetting - btnShutterClose1_Click")
            pLaser(m_iIndex).SetShutterOpen(False)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnTriggerSet_Click(sender As System.Object, e As System.EventArgs) Handles btnTriggerSet.Click
        Dim nPulseModeIndex As Integer = 0
        Try
            modPub.SystemLog("frmSetting - btnTriggerSet1_Click")
            ' internal =0 , external =1

            If cbTriggermode.Text = "Internal" Then
                pLaser(m_iIndex).SetPulseMode(0)
            ElseIf cbTriggermode.Text = "External" Then
                pLaser(m_iIndex).SetPulseMode(1)
            ElseIf cbTriggermode.Text = "Internal & Gated" Then  '스캐너 제어 Part
                pLaser(m_iIndex).SetPulseMode(2)
            ElseIf cbTriggermode.Text = "External & Gated" Then
                pLaser(m_iIndex).SetPulseMode(3)
            End If

            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnAttenuationSet_Click(sender As System.Object, e As System.EventArgs) Handles btnAttenuationSet.Click
        Try
            modPub.SystemLog("frmSetting - btnAttenuationSet1_Click")
            pLaser(m_iIndex).SetAttenuationPower(numAttenuation.Value)
            modPub.ParamLog("Laser1 Attenuate Change :: " & numAttenuation.Value.ToString)
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnRepetitionRate_Click(sender As System.Object, e As System.EventArgs) Handles btnRepetitionRate.Click
        Try
            modPub.SystemLog("frmSetting - btnRepetitionRate1_Click")
            pLaser(m_iIndex).SetRepRateMaster(numRepetitionRate.Value)
            modPub.ParamLog("Laser1 Repetation Change :: " & numAttenuation.Value.ToString)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnClearFault_Click(sender As System.Object, e As System.EventArgs) Handles btnClearFault.Click
        Try
            modPub.SystemLog("frmSetting - btnClearFault1_Click")
            'pLaser(m_iIndex).SetLaserOn(True)
            pLaser(m_iIndex).FACK(1)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnChillerWaterSet_Click(sender As System.Object, e As System.EventArgs) Handles btnChillerWaterSet.Click
        Try
            modPub.SystemLog("frmSetting - btnChillerWaterSet1_Click")
            pCurSystemParam.nChillerWaterDay(0) = numChillerWater.Value
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnChillerWaterReset_Click(sender As System.Object, e As System.EventArgs) Handles btnChillerWaterReset.Click
        Try
            modPub.SystemLog("frmSetting - btnChillerWaterReset1_Click")
            pCurSystemParam.strChillerWaterSetDay(0) = Format(Now, "yyyy-MM-dd").ToString
            modPub.WriteIni("LASER_SET", "LASER_CHILLER_WATER_SET_DAY_1", pCurSystemParam.strChillerWaterSetDay(0), TmpSystemFilePath)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnChillerFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnChillerFilter.Click
        Try
            modPub.SystemLog("frmSetting - btnChillerFilter1_Click")
            pCurSystemParam.nChillerFilterDay(0) = numChillerWater.Value
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnChillerFilterReset_Click(sender As System.Object, e As System.EventArgs) Handles btnChillerFilterReset.Click
        Try
            modPub.SystemLog("frmSetting - btnChillerFilterReset1_Click")
            pCurSystemParam.strChillerFilterSetDay(0) = Format(Now, "yyyy-MM-dd").ToString
            modPub.WriteIni("LASER_SET", "LASER_CHILLER_FILTER_SET_DAY_1", pCurSystemParam.strChillerFilterSetDay(0), TmpSystemFilePath)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub


    Public Sub LaserStatus()

        Dim strTemp As String = ""
        Dim strLaserStateIndex As String = 0
        Try
            Dim tmpArrFault() As String = {}

            If pLaser(m_iIndex).pLaserStatus.bConnect = True Then

                If pLaser(m_iIndex).pLaserStatus.strShutterState = "1" Then
                    btnShutterOpen.BackColor = Color.Lime
                    btnShutterClose.BackColor = Color.White
                ElseIf pLaser(m_iIndex).pLaserStatus.strShutterState = "0" Then
                    btnShutterOpen.BackColor = Color.White
                    btnShutterClose.BackColor = Color.Red
                End If

                strTemp = LTrim(pLaser(m_iIndex).pLaserStatus.strPulsemode)

                strLaserStateIndex = strTemp
                Select Case strLaserStateIndex
                    Case "0"
                        strTemp = "Internal"
                    Case "1"
                        strTemp = "External"
                    Case "2"
                        strTemp = "Internal & Gated"
                    Case "3"
                        strTemp = "External & Gated"
                End Select

                lblTriggerMode.Text = strTemp.ToString    'pLaser(m_iIndex).pLaserStatus.strPulsemode '(PM)
                lblAttenuation.Text = pLaser(m_iIndex).pLaserStatus.strAttenuatorPower '(?PATT)
                lblRFPLevel.Text = pLaser(m_iIndex).pLaserStatus.strRFPercentLevel
                lblRepetitionRate.Text = pLaser(m_iIndex).pLaserStatus.strMasterRepRate

                If pLaser(m_iIndex).pLaserStatus.strKeySwitchOn = "1" Then
                    strTemp = "Key On"
                Else
                    strTemp = "Key Off"
                End If
                lblSwitchOn.Text = strTemp
                strTemp = "OFF"
                strLaserStateIndex = pLaser(m_iIndex).pLaserStatus.strState
                Select Case strLaserStateIndex
                    Case "0"
                        strTemp = "Ready"
                    Case "1"
                        strTemp = "On"
                    Case "2"
                        strTemp = "Falut"
                End Select
                lblLaserState.Text = strTemp

                lblPower.Text = pLaser(m_iIndex).pLaserStatus.strOutputPower
                lblTransMission.Text = pLaser(m_iIndex).pLaserStatus.strTransMission
                lblSHGTemp.Text = pLaser(m_iIndex).pLaserStatus.strSHGTemperature
                lblTHGTemp.Text = pLaser(m_iIndex).pLaserStatus.strTHGTemperature

                lbSystemFault.Items.Clear()

                If pLaser(m_iIndex).pLaserStatus.strAreAnyFaultsActive <> "" Then
                    tmpArrFault = Split(pLaser(m_iIndex).pLaserStatus.strAreAnyFaultsActive, "&")
                    For j As Integer = 0 To tmpArrFault.Length - 1
                        lbSystemFault.Items.Add(tmpArrFault(j))
                    Next
                End If

            End If

            lblChillerWater.Text = DateDiff("d", pCurSystemParam.strChillerWaterSetDay(m_iIndex), Format(Now, "yyyy-MM-dd")).ToString()
            lblChillerFilter.Text = DateDiff("d", pCurSystemParam.strChillerFilterSetDay(m_iIndex), Format(Now, "yyyy-MM-dd")).ToString()

            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        
    End Sub

    Private Sub btnRFPLevel_Click(sender As System.Object, e As System.EventArgs) Handles btnRFPLevel.Click
        Dim nRecipeNum As Integer = 0
        nRecipeNum = pCurRecipe.nRecipeNumber
        Try
            modPub.SystemLog("frmSetting - btnRFPLevel_Click")
            pLaser(m_iIndex).SetRFPercentLevel(numRFPLevel.Value)
            modPub.ParamLog("Laser RFPercentLevel Change :: " & numAttenuation.Value.ToString)
            '레이저 값을 PenData에 갱신 RYO
            If m_iIndex = 0 Then
                pSetSystemParam.LaserPower(nRecipeNum - 1, 0) = numRFPLevel.Value * 100
            ElseIf m_iIndex = 1 Then
                pSetSystemParam.LaserPower(nRecipeNum - 1, 1) = numRFPLevel.Value * 100
            ElseIf m_iIndex = 2 Then
                pSetSystemParam.LaserPower(nRecipeNum - 1, 2) = numRFPLevel.Value * 100
            ElseIf m_iIndex = 3 Then
                pSetSystemParam.LaserPower(nRecipeNum - 1, 3) = numRFPLevel.Value * 100
            End If

            pCurSystemParam = pSetSystemParam
            modParam.SavePenDataParam(pStrTmpSystemRoot, nRecipeNum, pSetSystemParam)
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Try
            modPub.SystemLog("frmSetting - btnStart_Click")
            pLaser(m_iIndex).SetLaserOn(True)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Try
            modPub.SystemLog("frmSetting - btnStop_Click")
            pLaser(m_iIndex).SetLaserOn(False)
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub btnTransMissionSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransMissionSet.Click
        'If frmSetting.m_ctrlSetting_Laser(0).Visible = True Then
        'pLaser(0).SetTransMission(numTransMission.Value)
        'End If
        Try
            modPub.SystemLog("frmSetting - btnTransMission_Click")
            pLaser(m_iIndex).SetTransMission(numTransMission.Value)
            modPub.ParamLog("Laser TransMission Change :: " & numTransMission.Value.ToString)
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub



    Private Sub btnPowerMeterTop_Click(sender As System.Object, e As System.EventArgs) Handles btnPowerMeterTop.Click
        modPub.SystemLog("ctrlSettingLaser -- 상부")

        pPowerMeterThread.pbPowerMeter_Top(m_iIndex) = True
        pPowerMeterThread.pnPowerMeterIndex(m_iIndex) = 1
        pPowerMeterThread.pbPowerMeterLaserOff(m_iIndex) = False
    End Sub

    Private Sub btnPowerMeterBottum_Click(sender As System.Object, e As System.EventArgs) Handles btnPowerMeterBottum.Click
        modPub.SystemLog("ctrlSettingLaser -- 하부")

        pPowerMeterThread.pbPowerMeter_Top(m_iIndex) = False
        pPowerMeterThread.pnPowerMeterIndex(m_iIndex) = 1
        pPowerMeterThread.pbPowerMeterLaserOff(m_iIndex) = False

        'pPowerMeterThread.nPowerMeterCheck = m_iIndex + 1
        'pPowerMeterThread.bPowerMeterCheckChange = True
        'pPowerMeterThread.pbPowerMeterLaserOff(m_iIndex) = False
    End Sub

    Private Sub btnPowerMeterOff_Click(sender As System.Object, e As System.EventArgs) Handles btnPowerMeterOff.Click
        'pPowerMeterThread.pbPowerMeter_Top(m_iIndex) = False
        pPowerMeterThread.bPowerMeterCheckChange = False
        pPowerMeterThread.pbPowerMeterLaserOff(m_iIndex) = True
        pPowerMeterThread.ResetPowerMeter()
    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            '.lblScanBit1.Text = My.Resources.setLan.ResourceManager.GetObject("Bitmm")

            '.lblScanAngle1.Text = My.Resources.setLan.ResourceManager.GetObject("Angle5")
            '.lblCor1.Text = My.Resources.setLan.ResourceManager.GetObject("CorrectionFile")
            '.btnCorLoad.Text = My.Resources.setLan.ResourceManager.GetObject("Load")
            '.btnInitScanner.Text = My.Resources.setLan.ResourceManager.GetObject("InitScanner1")

            '.gbScannerLaserParam.Text = My.Resources.setLan.ResourceManager.GetObject("ScannerLaserParameter")
            '.lblPw11.Text = My.Resources.setLan.ResourceManager.GetObject("PulseWidth1")
            '.lblPw21.Text = My.Resources.setLan.ResourceManager.GetObject("PulseWidth2")
            '.lblFreq1.Text = My.Resources.setLan.ResourceManager.GetObject("HalfPulsePeriod")

            '.lblOnD1.Text = My.Resources.setLan.ResourceManager.GetObject("LaserOnDelay")
            '.lblOffD1.Text = My.Resources.setLan.ResourceManager.GetObject("LaserOffDelay")
            '.gbScannerAxisParam.Text = My.Resources.setLan.ResourceManager.GetObject("ScannerAxisParameter")
            '.lblJumpS1.Text = My.Resources.setLan.ResourceManager.GetObject("JumpSpeed")

            '.lblMarkS1.Text = My.Resources.setLan.ResourceManager.GetObject("MarkSpeed")

            '.lblJumpD1.Text = My.Resources.setLan.ResourceManager.GetObject("JumpDelay")
            '.lblMarkD1.Text = My.Resources.setLan.ResourceManager.GetObject("MarkDelay")
            '.lblPolyD1.Text = My.Resources.setLan.ResourceManager.GetObject("PolygonDelay")
            '.gbScanStatus.Text = My.Resources.setLan.ResourceManager.GetObject("Statusmm")

            '.btnScanParamApply.Text = My.Resources.setLan.ResourceManager.GetObject("ApplyScannerParameter")

            '.optUsePowerMeter.Text = My.Resources.setLan.ResourceManager.GetObject("Powermetermanualuse")
            '.gbScannerSimpleMark.Text = My.Resources.setLan.ResourceManager.GetObject("SimpleLaserMarking")
            '.optMarkLine.Text = My.Resources.setLan.ResourceManager.GetObject("Line")
            '.chkMarkLineAxis.Text = My.Resources.setLan.ResourceManager.GetObject("AxisY")

            '.optMarkRect.Text = My.Resources.setLan.ResourceManager.GetObject("Rect")
            '.optMarkCircle.Text = My.Resources.setLan.ResourceManager.GetObject("Circle")

            '.lbl11.Text = My.Resources.setLan.ResourceManager.GetObject("Size")
            '.lbl12.Text = My.Resources.setLan.ResourceManager.GetObject("Repeat")

            '.btnMark.Text = My.Resources.setLan.ResourceManager.GetObject("Mark")

            '.gbScannerShotTest.Text = My.Resources.setLan.ResourceManager.GetObject("LaserShot")
            '.btnScanShotBurstOn.Text = My.Resources.setLan.ResourceManager.GetObject("On1")
            '.btnScanShotContinousOn.Text = My.Resources.setLan.ResourceManager.GetObject("Continous")
            '.btnScanShotOff.Text = My.Resources.setLan.ResourceManager.GetObject("Off")

        End With

    End Sub

End Class
