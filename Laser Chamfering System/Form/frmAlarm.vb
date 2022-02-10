Public Class frmAlarm
    'Public pbMsgUp As Boolean = False
    Private nMSGMode As Integer = 0
    Private iListRowCnt As Integer = 40
    Dim iAlertCode() As Integer
    Dim _AlarmData As _tagAlarm


    Private Sub frmAlarm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo SysErr

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmAlarm -- frmAlarm_Load")
    End Sub
    Private Sub frmAlarm_FormClosing(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        On Error GoTo SysErr
        TimerAlarm.Enabled = False
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmAlarm -- frmAlarm_Close")
    End Sub
    Public Function Init() As Boolean
        On Error GoTo SysErr

        ReDim iAlertCode(iListRowCnt)

        For i As Integer = 0 To iListRowCnt

            iAlertCode(i) = 0

        Next

        _AlarmData.strType = ""
        _AlarmData.iAlarmNo = 0
        _AlarmData.iAlarmCode = 0
        _AlarmData.strAlarmName = ""
        _AlarmData.strAlarmDescript = ""
        _AlarmData.strAlarmType = ""

        ResetGridAlarm()

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Public Sub ShowAlarmMsg(ByVal iAlarmCode As Integer)
        On Error GoTo SysErr
        If AlarmSeq.pbMsgUp = False Then
            modAlarmTable.GetAlarm(iAlarmCode, _AlarmData)

            For i As Integer = 0 To iListRowCnt
                'For i As Integer = 0 To bAlarmCount - 1

                If iAlertCode(i) <> iAlarmCode Then

                    If iAlertCode(i) = 0 Then

                        iAlertCode(i) = iAlarmCode
                        AddGridAlarm(i, _AlarmData)


                        If _AlarmData.strAlarmType = "LIGHT" Then

                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_LIGHT_ALARM, True)
                            pLDLT.PC_Infomation.bPC_LightAlarm = True

                        End If

                        If _AlarmData.strAlarmType = "HEAVY" Then

                            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_HEAVY_ALARM, True)
                            pLDLT.PC_Infomation.bPC_HeavyAlarm = True
                            bAlarmUse = True

                        End If
                        modPub.AlramLog("ALARM_NO : " & _AlarmData.iAlarmNo)
                        modPub.AlramLog("ALARM_NAME : " & _AlarmData.strAlarmName)
                        modPub.AlramLog("ALARM_DESCRIPT : " & _AlarmData.strAlarmDescript)
                        modPub.AlramLog("ALARM_TYPE : " & _AlarmData.strAlarmType)
                        modPub.AlramLog("-----------------------------------------------")

                        modPub.TestLog("Alarm popup Show")

                        'bAlarmUse = True 20190420 ydy
                        'bAlarmUse = False
                        Me.Show()

                        Exit Sub

                    End If

                End If

            Next

            pbMsgUp = False  'Alarm Merge
        End If
        'Me.Show()

        Exit Sub
SysErr:

    End Sub
    'Alarm Merge
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo SysErr

        AlarmClear()

        Exit Sub

SysErr:
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo SysErr

        ResetGridAlarm()

        ' pbMsgUp = True
        Me.Hide()

        Exit Sub
SysErr:
    End Sub

    Private Function AddGridAlarm(ByVal iNum As Integer, ByVal _AlarmData As _tagAlarm) As Boolean
        On Error GoTo SysErr

        Dim tmpCnt As Integer = 0
        Dim strAlarmCode As String

        dgvAlarmData.RowCount = iListRowCnt '고정  '_AlarmData.iTotalCount

        dgvAlarmData.Rows(iNum).Cells(0).Value = iNum + 1
        dgvAlarmData.Rows(iNum).Cells(1).Value = _AlarmData.iAlarmCode
        dgvAlarmData.Rows(iNum).Cells(2).Value = _AlarmData.strAlarmName
        dgvAlarmData.Rows(iNum).Cells(3).Value = _AlarmData.strAlarmDescript
        dgvAlarmData.Rows(iNum).Cells(4).Value = _AlarmData.strAlarmType

        For i As Integer = iNum + 1 To iListRowCnt

            dgvAlarmData.Rows(i).Cells(0).Value = i + 1
            dgvAlarmData.Rows(i).Cells(1).Value = ""
            dgvAlarmData.Rows(i).Cells(2).Value = ""
            dgvAlarmData.Rows(i).Cells(3).Value = ""
            dgvAlarmData.Rows(i).Cells(4).Value = ""

        Next

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Private Function ResetGridAlarm() As Boolean
        On Error GoTo SysErr
        Dim tmpCnt As Integer = 0
        Dim strTemp As String = ""

        dgvAlarmData.RowCount = iListRowCnt '고정  '_AlarmData.iTotalCount

        For i As Integer = 0 To dgvAlarmData.RowCount

            dgvAlarmData.Rows(i).Cells(0).Value = i + 1
            dgvAlarmData.Rows(i).Cells(1).Value = strTemp
            dgvAlarmData.Rows(i).Cells(2).Value = strTemp
            dgvAlarmData.Rows(i).Cells(3).Value = strTemp
            dgvAlarmData.Rows(i).Cells(4).Value = strTemp

        Next

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Private Function ClearAlarmCode(ByVal iCode As Integer) As Boolean

        Dim iAlarmCnt As Integer = 0

        For i As Integer = 0 To iListRowCnt

            If iAlertCode(i) = iCode Then

                iAlertCode(i) = 0

            End If

            If iAlertCode(i) <> iCode Then

                iAlarmCnt = iAlarmCnt + 1

            End If

        Next
    End Function
    'Alarm Merge
    Dim nAlarmCheck(40) As Integer
    Private Sub TimerAlarm_Tick(sender As System.Object, e As System.EventArgs) Handles TimerAlarm.Tick

        If bAlarmSeq = True Then

            If (AlarmSeq.bAlarm = True) Then

                For i As Integer = 0 To 20
                    If nAlarmCheck(i) <> AlarmSeq.nAlarm(i) Then
                        ShowAlarmMsg(AlarmSeq.nAlarm(i))
                        nAlarmCheck(i) = AlarmSeq.nAlarm(i)
                    End If
                Next

            End If

            'bAlarmSeq = False
            pbMsgUp = True

        End If

        For i As Integer = 0 To 20

            If iAlertCode(0) = 0 Then

                If pLDLT.PC_Infomation.bPC_LightAlarm = True Then
                    pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_LIGHT_ALARM, False)
                    pLDLT.PC_Infomation.bPC_LightAlarm = False
                End If

                If pLDLT.PC_Infomation.bPC_HeavyAlarm = True Then
                    pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_HEAVY_ALARM, False)
                    pLDLT.PC_Infomation.bPC_HeavyAlarm = False
                End If

            End If

        Next

        If pLDLT.PC_Infomation.bMarkDistace(LINE.A) = True Then
            System.Threading.Thread.Sleep(500)
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MARK_DISTANCE_A, False)
            pLDLT.PC_Infomation.bMarkDistace(LINE.A) = False
        End If

        If pLDLT.PC_Infomation.bMarkDistace(LINE.B) = True Then
            System.Threading.Thread.Sleep(500)
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MARK_DISTANCE_B, False)
            pLDLT.PC_Infomation.bMarkDistace(LINE.B) = False
        End If

        If pLDLT.PLC_Infomation.bPLC_ResetAlarm = True Then
            AlarmClear()
        End If

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .lblTitle.Text = My.Resources.setLan.ResourceManager.GetObject("Alarm")
            .btnOK.Text = My.Resources.setLan.ResourceManager.GetObject("ClearAlarmClose")

        End With

    End Sub

    Private Sub AlarmClear()
        On Error GoTo SysErr

        For i As Integer = 0 To iListRowCnt

            iAlertCode(i) = 0
            AlarmSeq.nAlarm(i) = 0
            ClearAlarmCode(i)
            nAlarmCheck(i) = 0
            bAlarmSeq = False
        Next

        ResetGridAlarm()
        'bAlarmCount = 0 'RYO 이게 모야?
        bAlarmSeq = False
        bAlarmUse = False
        pbMsgUp = True

        modPub.AlramLog("ALARM_CLEAR")
        modPub.AlramLog("-----------------------------------------------")

        For i As Integer = 0 To LINE.B
            If AlarmSeq.bDistanceError(i) = True Then
                AlarmSeq.bDistanceError(i) = False
            End If
        Next

        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MARK_DISTANCE_A, False)
        pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_MARK_DISTANCE_B, False)
        pLDLT.PC_Infomation.bMarkDistace(LINE.A) = False
        pLDLT.PC_Infomation.bMarkDistace(LINE.B) = False
        If pLDLT.PC_Infomation.bPC_LightAlarm = True Then
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_LIGHT_ALARM, False)
            pLDLT.PC_Infomation.bPC_LightAlarm = False
        End If

        If pLDLT.PC_Infomation.bPC_HeavyAlarm = True Then
            pMXComponent.WriteBitByAddress(clsLDLT.BIT.WB_PC_HEAVY_ALARM, False)
            pLDLT.PC_Infomation.bPC_HeavyAlarm = False
        End If

        Me.Hide()
        AlarmSeq.InitCountChiller()
        AlarmSeq.bAlarm = True


        Exit Sub

SysErr:
    End Sub

End Class