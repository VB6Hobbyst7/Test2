Imports System.IO
Imports System.Threading

Public Class frmSetting

#If HEAD_2 Then
    Public m_ctrlSetting_SysParam As New ctrlSettingSysParam_2Head
    Public m_ctrlSetting_Calib As New ctrlSettingCalib_2Head
    Public m_ctrlSelBarLaser As New ctrlSelection_2Head
    Public m_ctrlSelBarScanner As New ctrlSelection_2Head
#Else
    Public m_ctrlSetting_SysParam As New ctrlSettingSysParam
    Public m_ctrlSetting_Calib As New ctrlSettingCalib
    Public m_ctrlSelBarLaser As New ctrlSelection
    Public m_ctrlSelBarScanner As New ctrlSelection
#End If

    Public m_ctrlSetting_Scanner(0 To 3) As ctrlSettingScanner
    'Public m_ctrlSetting_Laser(0 To 3) As ctrlSettingLaserTRUMF
    Public m_ctrlSetting_Laser(0 To 3) As ctrlSettingLaser
    Public m_ctrlSetting_PlcInterface As New ctrlSettingPlcInterface
    Public m_ctrlPLCBit As New ctrlPLCBit
    Public m_ctrlSetting_Displace As New ctrlDisplace

    Public m_gbSysParam As New GroupBox
    Public m_gbScanner As New GroupBox
    Public m_gbLaser As New GroupBox
    Public m_gbPlcInterface As New GroupBox
    Public m_gbCalib As New GroupBox
    Public m_gbDisplace As New GroupBox
    Public m_gbLaserIO As New GroupBox



    Dim nLaserIndex1 As Integer = 0
    Dim nLaserIndex2 As Integer = 0
    '   Dim nScannerIndex1 As Integer = 0
    ' Dim nScannerIndex2 As Integer = 0

    Dim nPowerMetrIndex_A As Integer = 0
    Dim nPowerMeterSleepCnt_A As Integer = 0
    Dim bPowerMeter_Top_A As Boolean = False
    Dim bPowerMeterLaserOff_A As Boolean = False
    '20160727 JCM Edit Scanner1 파워 메터 레이저 온 확인 비트
    Public pbPowerMeterOn_A As Boolean = False

    Dim nPowerMetrIndex_B As Integer = 0
    Dim nPowerMeterSleepCnt_B As Integer = 0
    Dim bPowerMeter_Top_B As Boolean = False
    Dim bPowerMeterLaserOff_B As Boolean = False
    '20160727 JCM Edit Scanner2 파워 메터 레이저 온 확인 비트
    Public pbPowerMeterOn_B As Boolean = False
    Public bDisplaceVisibleOld As Boolean = False
    Public bIOVisibleOld As Boolean = False
    'CHY - 2017.08.17 - PLC Bit Data
    Public bPLCBitVisibleOld As Boolean = False
    Public bLaserVisibleOld(0 To 3) As Boolean

    Dim TmpSystemFilePath As String = GetSetting("LASER_CHAMFERING", "SYSTEM", "FILE_PATH", "C:\Chamfering System\DEFAULT.ini")


    '20160907 JCM
    Private qCmd As New Queue
    Private ThreadDelete As Thread
    Private bThreadRunning As Boolean
    Private nKillThread As Integer



    '    Function StartThreadDelete() As Boolean
    '        On Error GoTo SysErr
    '        ThreadDelete = New Thread(AddressOf DeleteThreadSub)
    '        nKillThread = 0
    '        ThreadDelete.SetApartmentState(ApartmentState.MTA)
    '        ThreadDelete.Priority = ThreadPriority.Lowest
    '        ThreadDelete.Start()
    '        Return True

    '        Exit Function
    'SysErr:
    '        Return False
    '    End Function

    '    Public Function EndThreadDelete() As Boolean
    '        On Error GoTo SysErr

    '        Interlocked.Exchange(nKillThread, 1)

    '        Threading.Thread.Sleep(100)

    '        If bThreadRunning = True Then
    '            ThreadDelete.Join(1000)
    '        End If

    '        ThreadDelete = Nothing

    '        Return True
    '        Exit Function
    'SysErr:
    '        Return False
    '    End Function

    '    Sub DeleteThreadSub()
    '        On Error GoTo SysErr
    '        Dim strDirectory As String = ""
    '        Dim strFiles() As String = {}

    '        While nKillThread = 0
    '            bThreadRunning = True
    '            If qCmd.Count >= 1 Then
    '                For i = 0 To qCmd.Count - 1
    '                    If qCmd.Count <> 0 Then
    '                        strDirectory = qCmd.Dequeue
    '                        strFiles = System.IO.Directory.GetFiles(strDirectory)
    '                        For j As Integer = 0 To strFiles.Length - 1
    '                            System.IO.File.Delete(strFiles(j))
    '                        Next
    '                        System.IO.Directory.Delete(strDirectory)
    '                    End If
    '                Next i
    '            End If
    '        End While

    '        bThreadRunning = False
    '        Exit Sub
    'SysErr:
    '        bThreadRunning = False

    '    End Sub


    Private Sub frmSetting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting -- frmSetting_FormClosing")
        'EndThreadDelete()
        tmSetting.Enabled = False
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- frmSetting_FormClosing")
    End Sub

    Private Sub frmSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo SysErr



        Dim nGroupTopPos As Integer = gbSettingChoice.Bottom + 2

        m_gbSysParam.Location = New System.Drawing.Point(0, nGroupTopPos)
        m_gbLaser.Location = New System.Drawing.Point(0, nGroupTopPos)
        m_gbScanner.Location = New System.Drawing.Point(0, nGroupTopPos)
        m_gbCalib.Location = New System.Drawing.Point(0, nGroupTopPos)
        m_gbPlcInterface.Location = New System.Drawing.Point(0, nGroupTopPos)
        m_gbDisplace.Location = New System.Drawing.Point(0, nGroupTopPos)
        m_gbLaserIO.Location = New System.Drawing.Point(0, nGroupTopPos)

        m_gbSysParam.Size = New System.Drawing.Size(Me.Width -2, me.Height - nGroupTopPos)
        m_gbLaser.Size = New System.Drawing.Size(Me.Width - 2, Me.Height - nGroupTopPos)
        m_gbScanner.Size = New System.Drawing.Size(Me.Width - 2, Me.Height - nGroupTopPos)
        m_gbCalib.Size = New System.Drawing.Size(Me.Width - 2, Me.Height - nGroupTopPos)
        m_gbPlcInterface.Size = New System.Drawing.Size(Me.Width - 2, Me.Height - nGroupTopPos)
        m_gbDisplace.Size = New System.Drawing.Size(Me.Width - 2, Me.Height - nGroupTopPos)
        m_gbLaserIO.Size = New System.Drawing.Size(Me.Width - 2, Me.Height - nGroupTopPos)

        m_ctrlSelBarLaser.Tag = "Laser"

        m_ctrlSelBarScanner.Tag = "Scanner"

        m_gbLaser.Controls.Add(m_ctrlSelBarLaser)
        m_gbScanner.Controls.Add(m_ctrlSelBarScanner)

        m_gbSysParam.Visible = False
        m_gbLaser.Visible = False
        m_gbScanner.Visible = False
        m_gbCalib.Visible = False
        m_gbPlcInterface.Visible = False
        m_gbDisplace.Visible = False
        m_gbLaserIO.Visible = False

        Me.Controls.Add(m_gbSysParam)
        Me.Controls.Add(m_gbLaser)
        Me.Controls.Add(m_gbScanner)
        Me.Controls.Add(m_gbCalib)
        Me.Controls.Add(m_gbPlcInterface)
        Me.Controls.Add(m_gbDisplace)
        Me.Controls.Add(m_gbLaserIO)

        ' sysparam
        m_gbSysParam.Controls.Add(m_ctrlSetting_SysParam)
        'm_gbPlcInterface.Controls.Add(m_ctrlSetting_PlcInterface)
        m_gbPlcInterface.Controls.Add(m_ctrlPLCBit)
        m_gbCalib.Controls.Add(m_ctrlSetting_Calib)
        m_gbDisplace.Controls.Add(m_ctrlSetting_Displace)

        For i As Integer = 0 To 3
            m_ctrlSetting_Scanner(i) = New ctrlSettingScanner(i)
            m_ctrlSetting_Scanner(i).Location = New System.Drawing.Point(30, 60)
            m_ctrlSetting_Scanner(i).Size = New System.Drawing.Size(gbSettingChoice.Width, Me.Bottom - gbSettingChoice.Bottom - 30)
            Me.m_gbScanner.Controls.Add(m_ctrlSetting_Scanner(i))

            'm_ctrlSetting_Laser(i) = New ctrlSettingLaserTRUMF
            m_ctrlSetting_Laser(i) = New ctrlSettingLaser
            m_ctrlSetting_Laser(i).TabIndex = i
            m_ctrlSetting_Laser(i).Location = New System.Drawing.Point(2, 60)
            m_ctrlSetting_Laser(i).Size = New System.Drawing.Size(gbSettingChoice.Width, Me.Bottom - gbSettingChoice.Bottom - 30)
            m_ctrlSetting_Laser(i).m_iIndex = i
            Me.m_gbLaser.Controls.Add(m_ctrlSetting_Laser(i))

        Next

        modPub.SystemLog("frmSetting -- frmSetting_Load")
  
        'StartThreadDelete()
        tmSetting.Enabled = True

        m_ctrlSetting_SysParam.FormSetting()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- frmSetting_Load")
    End Sub

    Private Sub btnSettingChoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemParam.Click, btnLaser.Click, btnScanner.Click, btnCal.Click, btnPLC.Click, btnDisplace.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmSetting -- btnSettingChoice Click")

        m_gbSysParam.Visible = False
        m_gbLaser.Visible = False
        m_gbScanner.Visible = False
        m_gbCalib.Visible = False
        m_gbPlcInterface.Visible = False
        m_gbDisplace.Visible = False
        m_gbLaserIO.Visible = False

        btnSystemParam.BackColor = Color.White
        btnLaser.BackColor = Color.White
        btnScanner.BackColor = Color.White
        btnCal.BackColor = Color.White
        btnPLC.BackColor = Color.White
        btnDisplace.BackColor = Color.White
        BtnLaserIO.BackColor = Color.White

        SelectSettingGroup(sender.tag)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSettingChoice_Click")

    End Sub


    'Private Sub SelectSettingGroup(ByVal nIndex As Integer)
    Public Sub SelectSettingGroup(ByVal nIndex As Integer)
        On Error GoTo SysErr

        Select Case nIndex
            Case 0
                modPub.SystemLog("frmSetting - SelectSettingGroup : btnSystemParam_Click")
                m_gbSysParam.Visible = True
                btnSystemParam.BackColor = Color.Lime
                btnLaser.BackColor = Color.White
                btnScanner.BackColor = Color.White
                btnCal.BackColor = Color.White
                btnPLC.BackColor = Color.White
                btnDisplace.BackColor = Color.White
                BtnLaserIO.BackColor = Color.White
                m_ctrlSetting_SysParam.FormSetting()
            Case 1
                modPub.SystemLog("frmSetting - SelectSettingGroup : btnLaser_Click")
                m_gbLaser.Visible = True
                btnSystemParam.BackColor = Color.White
                btnLaser.BackColor = Color.Lime
                btnScanner.BackColor = Color.White
                btnCal.BackColor = Color.White
                btnPLC.BackColor = Color.White

            Case 2
                modPub.SystemLog("frmSetting - SelectSettingGroup : btnScanner_Click")
                m_gbScanner.Visible = True
                btnSystemParam.BackColor = Color.White
                btnLaser.BackColor = Color.White
                btnScanner.BackColor = Color.Lime
                btnCal.BackColor = Color.White
                btnPLC.BackColor = Color.White

            Case 3
                modPub.SystemLog("frmSetting - SelectSettingGroup : btnCal_Click")
                m_gbCalib.Visible = True
                btnSystemParam.BackColor = Color.White
                btnLaser.BackColor = Color.White
                btnScanner.BackColor = Color.White
                btnCal.BackColor = Color.Lime
                btnPLC.BackColor = Color.White

            Case 4
                modPub.SystemLog("frmSetting - SelectSettingGroup : btnETC_Click")
                m_gbPlcInterface.Visible = True
                btnSystemParam.BackColor = Color.White
                btnLaser.BackColor = Color.White
                btnScanner.BackColor = Color.White
                btnCal.BackColor = Color.White
                btnPLC.BackColor = Color.Lime

            Case 5
                modPub.SystemLog("frmSetting - SelectSettingGroup : btnDisplace_Click")
                m_gbDisplace.Visible = True
                btnDisplace.BackColor = Color.Lime

            Case 6
                m_gbLaserIO.Visible = True
                BtnLaserIO.BackColor = Color.Lime

        End Select

        m_ctrlSetting_SysParam.FormSetting()

        Exit Sub
SysErr:

    End Sub


    Dim tmpLaserPosX As Double
    Dim tmpLaserPosY As Double
    Dim tmpVisionPosX As Double
    Dim tmpVisionPosY As Double
    Dim tmpMovePosX As Double
    Dim tmpMovePosY As Double
    Dim bSystemShot(7) As Boolean
    Dim nLaserStatus As Integer = 0

    Private Sub tmSetting_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmSetting.Tick
        On Error GoTo SysErr

        For i = 0 To 3
            'GYN - LaserStatus() 우선 막음.
            If m_ctrlSetting_Laser(i).Visible Then
                m_ctrlSetting_Laser(i).LaserStatus()
            End If
            If m_ctrlSetting_Scanner(i).Visible Then
                m_ctrlSetting_Scanner(i).ScannerStatus()
            End If
        Next

        For i = 0 To 1
            If CInt(pDustCollector(i).Status.RunFlag) = clsDustCollector.RUNFLAG.RUN Then
                m_ctrlSetting_SysParam.btnDustCollectorRun.Text = "STOP"
            ElseIf CInt(pDustCollector(i).Status.RunFlag) = clsDustCollector.RUNFLAG.STOPON Then
                m_ctrlSetting_SysParam.btnDustCollectorRun.Text = "RUN"
            End If
        Next

#If SIMUL <> 1 Then
        AutoAndMenualInterlock()
#End If
	
		If m_gbDisplace.Visible <> bDisplaceVisibleOld Then
            If m_gbDisplace.Visible = True Then
                m_ctrlSetting_Displace.tmDisplace.Enabled = True
            Else
                m_ctrlSetting_Displace.tmDisplace.Enabled = False
            End If

            bDisplaceVisibleOld = m_gbDisplace.Visible

        End If

        'If m_gbLaserIO.Visible <> bIOVisibleOld Then
        '    If m_gbLaserIO.Visible = True Then
        '        m_ctrlSetting_LaserIO.Timer1.Enabled = True
        '    Else
        '        m_ctrlSetting_LaserIO.Timer1.Enabled = False
        '    End If

        '    bIOVisibleOld = m_gbLaserIO.Visible

        'End If
        'CHY - 2017.08.17 - PLC Bit Timer
        If m_gbPlcInterface.Visible <> bPLCBitVisibleOld Then
            If m_gbPlcInterface.Visible = True Then
                m_ctrlPLCBit.Timer1.Enabled = True
            Else
                m_ctrlPLCBit.Timer1.Enabled = False
            End If

            bPLCBitVisibleOld = m_gbPlcInterface.Visible

        End If



        'Me.TimerLaser.Enabled = True
        'For i = 0 To 3
        '    'If m_gbLaser.Visible <> bLaserVisibleOld(i) Then
        '    If m_ctrlSetting_Laser(i).Visible <> bLaserVisibleOld(i) Then
        '        If m_gbLaser.Visible = True Then
        '            If m_ctrlSetting_Laser(i).Visible = True Then
        '                m_ctrlSetting_Laser(i).TimerLaser.Enabled = True
        '            Else
        '                m_ctrlSetting_Laser(i).TimerLaser.Enabled = False
        '            End If

        '        Else
        '            If m_ctrlSetting_Laser(i).Visible = False Then
        '                m_ctrlSetting_Laser(i).TimerLaser.Enabled = False
        '            End If

        '        End If

        '        bLaserVisibleOld(i) = m_gbLaser.Visible

        '    End If
        'Next


        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- tmSetting_Tick")
    End Sub


    Private Sub DeleteOldLog()
        On Error GoTo SysErr

        pLog.OldFileDelete("Error", pCurSystemParam.nLogSaveDay)
        pLog.OldFileDelete("Param", pCurSystemParam.nLogSaveDay)
        pLog.OldFileDelete("Sequence_A", pCurSystemParam.nLogSaveDay)
        pLog.OldFileDelete("Sequence_B", pCurSystemParam.nLogSaveDay)
        pLog.OldFileDelete("System", pCurSystemParam.nLogSaveDay)
        pLog.OldFileDelete("Tac_A", pCurSystemParam.nLogSaveDay)
        pLog.OldFileDelete("Tac_B", pCurSystemParam.nLogSaveDay)
        pLog.OldFileDelete("PowerMeter", pCurSystemParam.nLogSaveDay)
        Exit Sub
SysErr:

    End Sub

    '    Private Sub DeleteOldImage()
    '        On Error GoTo SysErr
    '        Dim Image_A_OK() As String = {}
    '        Dim Image_A_NG() As String = {}
    '        Dim Image_B_OK() As String = {}
    '        Dim Image_B_NG() As String = {}

    '        Image_A_OK = System.IO.Directory.GetDirectories(pCurSystemParam.strAlignImagePath(LINE.A) & "\OK")
    '        Image_A_NG = System.IO.Directory.GetDirectories(pCurSystemParam.strAlignImagePath(LINE.A) & "\NG")
    '        Image_B_OK = System.IO.Directory.GetDirectories(pCurSystemParam.strAlignImagePath(LINE.B) & "\OK")
    '        Image_B_NG = System.IO.Directory.GetDirectories(pCurSystemParam.strAlignImagePath(LINE.B) & "\NG")

    '        DeleteImage(Image_A_OK)
    '        DeleteImage(Image_A_NG)
    '        DeleteImage(Image_B_OK)
    '        DeleteImage(Image_B_NG)

    '        Exit Sub
    'SysErr:

    '    End Sub

    '    Private Sub DeleteImage(ByVal ImageDirectories() As String)
    '        On Error GoTo SysErr
    '        Dim nTmpDiff As Integer = 0
    '        Dim strTempCurDay As String = ""
    '        Dim strTmp() As String = {}
    '        Dim strFileTmp() As String = {}

    '        For i As Integer = 0 To ImageDirectories.Length - 1
    '            strTmp = Split(ImageDirectories(i), "\")
    '            strTempCurDay = strTmp(strTmp.Length - 1)
    '            nTmpDiff = DateDiff("d", strTempCurDay, Format(Now, "yyyy-MM-dd"))
    '            If nTmpDiff > pCurSystemParam.nImageSaveDay Then
    '                qCmd.Enqueue(ImageDirectories(i))
    '            End If
    '        Next

    '        Exit Sub
    'SysErr:
    '    End Sub

    Private Function AutoAndMenualInterlock() As Boolean
        'GYN - 확인 할 것

#If SIMUL <> 1 Then
        'GYN - TEST
        'If pLDLT.PLC_Infomation.bPLC_ManualMode(LINE.A) = True And pLDLT.PLC_Infomation.bPLC_ManualMode(LINE.B) = True Then
        '    For i As Integer = 0 To 3
        '        'GYN - LaserStatus() 우선 막음.
        '        'm_ctrlSetting_Laser(i).gbLaser1Heater.Enabled = True
        '        m_ctrlSetting_Laser(i).gbLaserSet.Enabled = True
        '        m_ctrlSetting_Scanner(i).gbScannerAxisParam.Enabled = True
        '        m_ctrlSetting_Scanner(i).gbScannerLaserParam.Enabled = True
        '        m_ctrlSetting_Scanner(i).gbScannerSimpleMark.Enabled = True
        '        m_ctrlSetting_Scanner(i).gbScannerShotTest.Enabled = True
        '        m_ctrlSetting_Scanner(i).optUsePowerMeter.Enabled = True
        '    Next
        '    m_ctrlSetting_SysParam.gbSystemOffsetA.Enabled = True
        '    m_ctrlSetting_SysParam.gbSystemOffsetB.Enabled = True
        'ElseIf pLDLT.PLC_Infomation.bPLC_ManualMode(LINE.A) = False Or pLDLT.PLC_Infomation.bPLC_ManualMode(LINE.B) = False Then
        '    For i As Integer = 0 To 3
        '        'GYN - LaserStatus() 우선 막음.
        '        'm_ctrlSetting_Laser(i).gbLaser1Heater.Enabled = False
        '        m_ctrlSetting_Laser(i).gbLaserSet.Enabled = False
        '        m_ctrlSetting_Scanner(i).gbScannerAxisParam.Enabled = False
        '        m_ctrlSetting_Scanner(i).gbScannerLaserParam.Enabled = False
        '        m_ctrlSetting_Scanner(i).gbScannerSimpleMark.Enabled = False
        '        m_ctrlSetting_Scanner(i).gbScannerShotTest.Enabled = False
        '        m_ctrlSetting_Scanner(i).optUsePowerMeter.Enabled = False
        '    Next
        '    m_ctrlSetting_SysParam.gbSystemOffsetA.Enabled = False
        '    m_ctrlSetting_SysParam.gbSystemOffsetB.Enabled = False
        'End If
#End If

    End Function

    Public Sub FormSetting()
        On Error GoTo SysErr
        Dim tmpPath() As String = {}
        Exit Sub
SysErr:

    End Sub

    Private Sub BtnLaserIO_Click(sender As System.Object, e As System.EventArgs) Handles BtnLaserIO.Click

        On Error GoTo SysErr

        m_gbSysParam.Visible = False
        m_gbLaser.Visible = False
        m_gbScanner.Visible = False
        m_gbCalib.Visible = False
        m_gbPlcInterface.Visible = False
        m_gbDisplace.Visible = False
        m_gbLaserIO.Visible = False

        btnSystemParam.BackColor = Color.White
        btnLaser.BackColor = Color.White
        btnScanner.BackColor = Color.White
        btnCal.BackColor = Color.White
        btnPLC.BackColor = Color.White
        btnDisplace.BackColor = Color.White
        BtnLaserIO.BackColor = Color.White

        SelectSettingGroup(sender.tag)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSettingChoice_Click")

    End Sub

    Private Sub btnIO_Click(sender As System.Object, e As System.EventArgs) Handles btnIO.Click

        frmDigitalIO.frmShow()

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbSettingChoice.Text = My.Resources.setLan.ResourceManager.GetObject("SettingChoice")
            .btnSystemParam.Text = My.Resources.setLan.ResourceManager.GetObject("SystemParam")
            .btnLaser.Text = My.Resources.setLan.ResourceManager.GetObject("Laser")
            .btnScanner.Text = My.Resources.setLan.ResourceManager.GetObject("Scanner")
            .btnCal.Text = My.Resources.setLan.ResourceManager.GetObject("Calibration")
            .btnPLC.Text = My.Resources.setLan.ResourceManager.GetObject("PLCInterface")
            .btnDisplace.Text = My.Resources.setLan.ResourceManager.GetObject("Displace")
            
        End With

        m_ctrlSetting_SysParam.LanChange(StrCulture)
        m_ctrlSetting_Calib.LanChange(StrCulture)
        m_ctrlSetting_Displace.LanChange(StrCulture)

        'm_ctrlSetting_PlcInterface.LanChange(StrCulture)
        'm_ctrlSetting_LaserIO.LanChange(StrCulture)
        'm_ctrlSelBarLaser.LanChange(StrCulture)
        'm_ctrlSelBarScanner.LanChange(StrCulture)

        For i As Integer = 0 To 3

            m_ctrlSetting_Scanner(i).LanChange(StrCulture)
            m_ctrlSetting_Laser(i).LanChange(StrCulture)

        Next

    End Sub

End Class