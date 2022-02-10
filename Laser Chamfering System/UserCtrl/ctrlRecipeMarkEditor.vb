Public Class ctrlRecipeMarkEditor

    Public m_iSelLine As Integer
    Public m_iSelLaserIndex As Integer

    Dim nCurSelIndex As Integer = 0
    Public pnMinPosX As Double = 1000
    Public pnMinPosY As Double = 1000
    Public pnMaxPosX As Double = -1000
    Public pnMaxPosY As Double = -1000
    Public bSave As Boolean = False
    '20181207
    Dim tmpDir As Integer = 1

    'Mark Save InterLook
    Public bSaveMarkData As Boolean = False


    Public Function InputData() As Boolean
        On Error GoTo SysErr
        numGroupShowScale.Value = 4
        AddMarkData2Point(tmpEditMarkData)
        frmMarkDataEditer.DrawMarkData()
        Return True
        Exit Function
SysErr:
        Return False
    End Function


    Private Function AddMarkData2Point(ByVal ipOriMarkData As MarkingData) As Boolean
        On Error GoTo SysErr
        Dim tmpCnt As Integer = 0
        dgvMarkData.RowCount = ipOriMarkData.nTotalCmdCnt

        numCurrentPen.Value = ipOriMarkData.nPen
        pCurRecipe = pSetRecipe
        For k As Integer = 0 To ipOriMarkData.nIndexCnt - 1
            For i As Integer = 0 To ipOriMarkData.nTotalCmdCnt - 1            'Data(k).nCmdCnt - 1
                dgvMarkData.Rows(i).Cells(0).Value = pCurRecipe.strMarkingNum(i)  '20180306 chy 정도 위치 spec
                dgvMarkData.Rows(i).Cells(1).Value = i 'tmpCnt.ToString & "_" & k.ToString
                dgvMarkData.Rows(i).Cells(2).Value = ipOriMarkData.Data(k).nGroupX(i).ToString
                dgvMarkData.Rows(i).Cells(3).Value = ipOriMarkData.Data(k).nGroupY(i).ToString
                dgvMarkData.Rows(i).Cells(4).Value = ipOriMarkData.Data(k).strCommand(i)
                dgvMarkData.Rows(i).Cells(5).Value = ipOriMarkData.Data(k).dPosX(i)
                dgvMarkData.Rows(i).Cells(6).Value = ipOriMarkData.Data(k).dPosY(i)
                dgvMarkData.Rows(i).Cells(7).Value = ipOriMarkData.Data(k).dAngle(i)
                dgvMarkData.Rows(i).Cells(8).Value = 0
                dgvMarkData.Rows(i).Cells(9).Value = 0
                dgvMarkData.Rows(i).Cells(10).Value = 0
                dgvMarkData.Rows(i).Cells(12).Value = ipOriMarkData.Data(k).dPosX(i)
                dgvMarkData.Rows(i).Cells(13).Value = ipOriMarkData.Data(k).dPosY(i)
                dgvMarkData.Rows(i).Cells(14).Value = ipOriMarkData.Data(k).dAngle(i)

                dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.White
                dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.White
                dgvMarkData.Rows(i).Cells(14).Style.BackColor = Color.White
                'tmpCnt = tmpCnt + 1
            Next
        Next

        numV_LineX1.Value = ipOriMarkData.dV_LinePosX1
        numV_LineX2.Value = ipOriMarkData.dV_LinePosX2
        numV_LineY.Value = ipOriMarkData.dV_LinePosY
        numV_LineMarkSpeed.Value = ipOriMarkData.dV_LineMarkSpd
        numV_LineRepeat.Value = ipOriMarkData.nV_LineRepeat
        chkVline.Checked = ipOriMarkData.bV_LineFirst

        If ipOriMarkData.bV_LineFirst = True Then
            chkVline.Text = "First"
        Else
            chkVline.Text = "End"
        End If

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Private Sub btnSelectPen_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectPen.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe -- btnSelectPen_Click --- Pen : " & pSetRecipe.RecipeMarkingData(m_iSelLine, m_iSelLaserIndex).nPen & "-> " & numCurrentPen.Value)
        pSetRecipe.RecipeMarkingData(m_iSelLine, m_iSelLaserIndex).nPen = numCurrentPen.Value
        'Select Case nCurEditMarkData
        '    Case 1
        '    Case 2
        '        pSetRecipe.RecipeMarkingData_A2.nPen = numCurrentPen.Value
        '    Case 3
        '        pSetRecipe.RecipeMarkingData_B1.nPen = numCurrentPen.Value
        '    Case 4
        '        pSetRecipe.RecipeMarkingData_B2.nPen = numCurrentPen.Value
        'End Select
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnSelectPen_Click")

    End Sub

    Private Sub btnGroupApply_Click(sender As System.Object, e As System.EventArgs) Handles btnGroupApply.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe -- btnGroupApply_Click")
        Dim nStartIndex As Integer = 0


        If numCurrentGroup.Value = 0 Then
            Return
        End If


        'Group X 
        For i As Integer = 0 To tmpEditMarkData.nTotalCmdCnt - 1
            If dgvMarkData.Rows(i).Cells(2).Value = numCurrentGroup.Value Then

                If numGroupPosition_X.Value <> 0 Then

                    dgvMarkData.Rows(i).Cells(8).Value = CDbl(dgvMarkData.Rows(i).Cells(8).Value) + numGroupPosition_X.Value
                    dgvMarkData.Rows(i).Cells(12).Value = CDbl(dgvMarkData.Rows(i).Cells(5).Value) + CDbl(dgvMarkData.Rows(i).Cells(8).Value)
                    If dgvMarkData.Rows(i).Cells(5).Value <> dgvMarkData.Rows(i).Cells(12).Value Then
                        dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.Yellow
                    ElseIf dgvMarkData.Rows(i).Cells(5).Value = dgvMarkData.Rows(i).Cells(12).Value Then
                        dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.White
                    End If

                End If

                If numGroupPosition_Y.Value <> 0 Then

                    dgvMarkData.Rows(i).Cells(9).Value = CDbl(dgvMarkData.Rows(i).Cells(9).Value) + numGroupPosition_Y.Value
                    dgvMarkData.Rows(i).Cells(13).Value = CDbl(dgvMarkData.Rows(i).Cells(6).Value) + CDbl(dgvMarkData.Rows(i).Cells(9).Value)
                    If dgvMarkData.Rows(i).Cells(6).Value <> dgvMarkData.Rows(i).Cells(13).Value Then
                        dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.YellowGreen
                    ElseIf dgvMarkData.Rows(i).Cells(6).Value = dgvMarkData.Rows(i).Cells(13).Value Then
                        dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.White
                    End If

                End If

            End If
        Next

        numGroupPosition_X.Value = 0
        numGroupPosition_Y.Value = 0
        numGroupAngle.Value = 0

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnGroupApply_Click")

    End Sub

    Private Sub btnGroupShow_Click(sender As System.Object, e As System.EventArgs) Handles btnGroupShow.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe -- btnGroupShow_Click")

        pnMinPosX = 1000
        pnMinPosY = 1000
        pnMaxPosX = -1000
        pnMaxPosY = -1000

        If (tmpEditMarkData.Data(numCurrentGroup.Value).strCommand(0) = "AA" And numCurrentGroup.Value > 0) Or tmpEditMarkData.Data(numCurrentGroup.Value).nCmdCnt = 1 Then
            GetMinMaxPicPosition(tmpEditMarkData.Data(numCurrentGroup.Value - 1).dPosX(tmpEditMarkData.Data(numCurrentGroup.Value - 1).nCmdCnt - 1), tmpEditMarkData.Data(numCurrentGroup.Value - 1).dPosY(tmpEditMarkData.Data(numCurrentGroup.Value - 1).nCmdCnt - 1), _
                                 pnMinPosX, pnMinPosY, pnMaxPosX, pnMaxPosY)
        End If

        For i As Integer = 0 To tmpEditMarkData.Data(numCurrentGroup.Value).nCmdCnt - 1
            GetMinMaxPicPosition(tmpEditMarkData.Data(numCurrentGroup.Value).dPosX(i), tmpEditMarkData.Data(numCurrentGroup.Value).dPosY(i), _
                                 pnMinPosX, pnMinPosY, pnMaxPosX, pnMaxPosY)
        Next
        DrawData.OffX = 0
        DrawData.OffY = 0
        DrawData.Scale = numGroupShowScale.Value

        If frmMarkDataEditer.chkInverse.Checked = True Then
            DrawData.OffX = DrawData.OffX + (pnMinPosX + pnMaxPosX) / 2
        Else
            DrawData.OffX = DrawData.OffX - (pnMinPosX + pnMaxPosX) / 2
        End If


        If frmMarkDataEditer.chkTopBottom.Checked = True Then
            DrawData.OffY = DrawData.OffY + (pnMinPosY + pnMaxPosY) / 2
        Else
            DrawData.OffY = DrawData.OffY - (pnMinPosY + pnMaxPosY) / 2
        End If

        frmMarkDataEditer.DrawMarkData(True)
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnGroupShow_Click")

    End Sub

    Private Sub GetMinMaxPicPosition(ByVal dTargetPosX As Double, ByVal dTargetPosY As Double, _
                                 ByRef outMinPosX As Double, ByRef outMinPosY As Double, ByRef outMaxPosX As Double, ByRef outMaxPosY As Double)
        On Error GoTo SysErr
        If dTargetPosX < outMinPosX Then
            outMinPosX = dTargetPosX
        End If

        If dTargetPosY < outMinPosY Then
            outMinPosY = dTargetPosY
        End If

        If dTargetPosX > outMaxPosX Then
            outMaxPosX = dTargetPosX
        End If

        If dTargetPosY > outMaxPosY Then
            outMaxPosY = dTargetPosY
        End If

        Exit Sub
SysErr:

    End Sub



    Private Sub btnSaveMarkData_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveMarkData.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe -- btnSaveMarkData_Click")

        frmMarkChangeMSG.Show()
        AddMarkDataPoint_Current(tmpEditMarkData)

        '여기서 저장 하지 말자.
        'SaveMarkData(pCurRecipe.strMarkRecipeFile(m_iSelLine, m_iSelLaserIndex), pCurRecipe.RecipeMarkingData(m_iSelLine, m_iSelLaserIndex))

        'DATA
        bSaveMarkData = True

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnSaveMarkData_Click")

    End Sub



    Private Sub ctrlRecipeMarkEditor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If pCurSystemParam.nSystem = 0 Then
            optSystemMode_Normal.Checked = True
        ElseIf pCurSystemParam.nSystem = 1 Then
            optSystemMode_Mode1.Checked = True
        ElseIf pCurSystemParam.nSystem = 2 Then
            optSystemMode_Mode2.Checked = True
        End If
    End Sub


    Private Sub optSystemMode_Normal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo SysErr
        If optSystemMode_Normal.Checked = True Then
            frmMarkDataEditer.chkInverse.Checked = False
            frmMarkDataEditer.lblStatus.Text = "Front"
            frmMarkDataEditer.chkInverse.Text = "Front"
            frmMarkDataEditer.lblX_Minus.Text = "X-"
            frmMarkDataEditer.lblX_Plus.Text = "X+"
            frmMarkDataEditer.nDirX = 1
            frmMarkDataEditer.chkTopBottom.Checked = True
            frmMarkDataEditer.lblStatusY.Text = "Top"
            frmMarkDataEditer.chkTopBottom.Text = "Top"
            frmMarkDataEditer.lblY_Minus.Text = "Y-"
            frmMarkDataEditer.lblY_Plus.Text = "Y+"
            frmMarkDataEditer.nDirY = 1
            pSetSystemParam.nSystem = 0
        ElseIf optSystemMode_Mode1.Checked = True Then
            frmMarkDataEditer.chkInverse.Checked = True
            frmMarkDataEditer.lblStatus.Text = "Back"
            frmMarkDataEditer.chkInverse.Text = "Back"
            frmMarkDataEditer.lblX_Minus.Text = "X+"
            frmMarkDataEditer.lblX_Plus.Text = "X-"
            frmMarkDataEditer.nDirX = -1
            frmMarkDataEditer.chkTopBottom.Checked = False
            frmMarkDataEditer.lblStatusY.Text = "Top"
            frmMarkDataEditer.chkTopBottom.Text = "Top"
            frmMarkDataEditer.lblY_Minus.Text = "Y-"
            frmMarkDataEditer.lblY_Plus.Text = "Y+"
            frmMarkDataEditer.nDirY = 1
            pSetSystemParam.nSystem = 1
        ElseIf optSystemMode_Mode2.Checked = True Then
            frmMarkDataEditer.chkInverse.Checked = False
            frmMarkDataEditer.lblStatus.Text = "Front"
            frmMarkDataEditer.chkInverse.Text = "Front"
            frmMarkDataEditer.lblX_Minus.Text = "X-"
            frmMarkDataEditer.lblX_Plus.Text = "X+"
            frmMarkDataEditer.nDirX = 1
            frmMarkDataEditer.chkTopBottom.Checked = True
            frmMarkDataEditer.lblStatusY.Text = "Bottom"
            frmMarkDataEditer.chkTopBottom.Text = "Bottom"
            frmMarkDataEditer.lblY_Minus.Text = "Y+"
            frmMarkDataEditer.lblY_Plus.Text = "Y-"
            frmMarkDataEditer.nDirY = -1
            pSetSystemParam.nSystem = 2
        End If

        frmMarkDataEditer.DrawMarkData()
        pCurSystemParam.nSystem = pSetSystemParam.nSystem

        Exit Sub
SysErr:

    End Sub

    Dim nCurRow As Integer = 0
    Dim nCurCol As Integer = 0

    Private Sub dgvMarkData_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMarkData.CellClick
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe -- dgvMarkData_CellClick")
        nCurSelIndex = e.RowIndex

        nCurRow = e.RowIndex
        nCurCol = e.ColumnIndex

        Dim dData As Double = 0.0
        Dim strTemp As String = ""


        If e.ColumnIndex = 11 Then

            If IsNumeric(dgvMarkData.Rows(nCurSelIndex).Cells(8).Value) = False Then
                frmMSG.ShowMsg("Data Input Error", nCurSelIndex.ToString & " : OffsetX value is not number", False, 1)
                Exit Sub
            End If
            If IsNumeric(dgvMarkData.Rows(nCurSelIndex).Cells(9).Value) = False Then
                frmMSG.ShowMsg("Data Input Error", nCurSelIndex.ToString & " : OffsetY value is not number", False, 1)
                Exit Sub
            End If
            If IsNumeric(dgvMarkData.Rows(nCurSelIndex).Cells(10).Value) = False Then
                frmMSG.ShowMsg("Data Input Error", nCurSelIndex.ToString & " : OffsetAngle value is not number", False, 1)
                Exit Sub
            End If

            'GYN - 입력 Data Limit Check +3mm ~ -3mm 벗어나면 입력 안되게 설정.
            '20181207 손승민 주임 요청 user,tech Limit 0.05mm이상이면 0.05mm 적용 admin no Limit
            If IsMinMaxValue(dgvMarkData.Rows(nCurSelIndex).Cells(8).Value) = False Then
                frmMSG.ShowMsg("Data Input Limit", " : OffsetX value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
                dgvMarkData.Rows(nCurSelIndex).Cells(12).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(5).Value) + (0.05 * tmpDir)
            Else
                dgvMarkData.Rows(nCurSelIndex).Cells(12).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(5).Value) + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(8).Value)
            End If

            If IsMinMaxValue(dgvMarkData.Rows(nCurSelIndex).Cells(9).Value) = False Then

                frmMSG.ShowMsg("Data Input Limit", " : OffsetY value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
                dgvMarkData.Rows(nCurSelIndex).Cells(13).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(6).Value) + (0.05 * tmpDir)
            Else
                dgvMarkData.Rows(nCurSelIndex).Cells(13).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(6).Value) + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(9).Value)
            End If

            If modPub.bLogInAdmin = True Then
                If IsMinMaxValue(dgvMarkData.Rows(nCurSelIndex).Cells(10).Value) = False Then

                    frmMSG.ShowMsg("Data Input Limit", " : Offset Angle value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
                    dgvMarkData.Rows(nCurSelIndex).Cells(14).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(7).Value) + (0.05 * tmpDir)
                Else
                    dgvMarkData.Rows(nCurSelIndex).Cells(14).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(7).Value) + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(10).Value)
                End If
            Else
                If dgvMarkData.Rows(nCurSelIndex).Cells(10).Value <> 0 Then
                    frmMSG.ShowMsg("No Access Authority", "Admin Login Please", False, 1)
                End If
            End If


            'If IsMinMaxValue(dgvMarkData.Rows(nCurSelIndex).Cells(8).Value) = False Then

            '    frmMSG.ShowMsg("Data Input Limit", " : OffsetX value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
            '    Exit Sub

            'End If

            'If IsMinMaxValue(dgvMarkData.Rows(nCurSelIndex).Cells(9).Value) = False Then

            '    frmMSG.ShowMsg("Data Input Limit", " : OffsetY value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
            '    Exit Sub

            'End If

            'If IsMinMaxValue(dgvMarkData.Rows(nCurSelIndex).Cells(10).Value) = False Then

            '    frmMSG.ShowMsg("Data Input Limit", " : Offset Angle value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
            '    Exit Sub

            'End If

            'dgvMarkData.Rows(nCurSelIndex).Cells(12).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(5).Value) + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(8).Value)
            'dgvMarkData.Rows(nCurSelIndex).Cells(13).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(6).Value) + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(9).Value)
            'dgvMarkData.Rows(nCurSelIndex).Cells(14).Value = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(7).Value) + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(10).Value)

            'dgvMarkData.Rows(nCurSelIndex).Cells(5).Value = 0.0
            'dgvMarkData.Rows(nCurSelIndex).Cells(6).Value = 0.0
            'dgvMarkData.Rows(nCurSelIndex).Cells(7).Value = 0.0
        End If

        If e.ColumnIndex = 15 Then
            DrawData.OffX = 0
            DrawData.OffY = 0
            DrawData.Scale = numGroupShowScale.Value
            If frmMarkDataEditer.chkInverse.Checked = True Then
                DrawData.OffX = DrawData.OffX + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(12).Value)
            Else
                DrawData.OffX = DrawData.OffX - CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(12).Value)
            End If

            If frmMarkDataEditer.chkTopBottom.Checked = True Then
                DrawData.OffY = DrawData.OffY + CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(13).Value)
            Else
                DrawData.OffY = DrawData.OffY - CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(13).Value)
            End If

        End If

        For i As Integer = 0 To dgvMarkData.RowCount - 1
            If dgvMarkData.Rows(nCurSelIndex).Cells(5).Value <> dgvMarkData.Rows(nCurSelIndex).Cells(12).Value Then
                dgvMarkData.Rows(nCurSelIndex).Cells(12).Style.BackColor = Color.Yellow
            ElseIf dgvMarkData.Rows(nCurSelIndex).Cells(5).Value = dgvMarkData.Rows(nCurSelIndex).Cells(12).Value Then
                dgvMarkData.Rows(nCurSelIndex).Cells(12).Style.BackColor = Color.White
            End If

            If dgvMarkData.Rows(nCurSelIndex).Cells(6).Value <> dgvMarkData.Rows(nCurSelIndex).Cells(13).Value Then
                dgvMarkData.Rows(nCurSelIndex).Cells(13).Style.BackColor = Color.YellowGreen
            ElseIf dgvMarkData.Rows(nCurSelIndex).Cells(6).Value = dgvMarkData.Rows(nCurSelIndex).Cells(13).Value Then
                dgvMarkData.Rows(nCurSelIndex).Cells(13).Style.BackColor = Color.White
            End If

            If dgvMarkData.Rows(nCurSelIndex).Cells(7).Value <> dgvMarkData.Rows(nCurSelIndex).Cells(14).Value Then
                dgvMarkData.Rows(nCurSelIndex).Cells(14).Style.BackColor = Color.Violet
            ElseIf dgvMarkData.Rows(nCurSelIndex).Cells(7).Value = dgvMarkData.Rows(nCurSelIndex).Cells(14).Value Then
                dgvMarkData.Rows(nCurSelIndex).Cells(14).Style.BackColor = Color.White
            End If

            For j As Integer = 0 To 9
                If i = nCurSelIndex Then
                    dgvMarkData.Rows(nCurSelIndex).Cells(j).Style.BackColor = Color.LightGreen
                Else
                    dgvMarkData.Rows(i).Cells(j).Style.BackColor = Color.White
                End If
            Next
        Next

        'dgvMarkData.Rows(nCurSelIndex).Cells(5).Value = 0
        'dgvMarkData.Rows(nCurSelIndex).Cells(6).Value = 0
        'dgvMarkData.Rows(nCurSelIndex).Cells(7).Value = 0

        frmMarkDataEditer.DrawSelectData(nCurSelIndex)
        Exit Sub
SysErr:

    End Sub
    Private Function AddMarkDataPoint_Current(ByVal ipOriMarkData As MarkingData) As Boolean
        On Error GoTo SysErr
        Dim tmpCnt As Integer = 0
        Dim strPos_Cnt As String = ""
        Dim strPos_X As String = ""
        Dim strPos_Y As String = ""
        Dim strPos_Angle As String = ""
        Dim strChange_X As String = ""
        Dim strChange_Y As String = ""
        Dim strChange_Angle As String = ""
        frmMarkChangeMSG.listChangeData.Items.Clear()
        For k As Integer = 0 To ipOriMarkData.nIndexCnt - 1
            'For i As Integer = 0 To ipOriMarkData.Data(k).nCmdCnt - 1
            For i As Integer = 0 To ipOriMarkData.nTotalCmdCnt - 1

                'strPos_Cnt = "[INDEX=" & tmpCnt.ToString & "_" & k.ToString & "]"
                strPos_Cnt = "[INDEX=" & i.ToString & "]" 'bsseo_0908 Index가 모두 0 으로 나오는 문제
                strPos_X = "[X=" & dgvMarkData.Rows(tmpCnt).Cells(5).Value & "->" & dgvMarkData.Rows(tmpCnt).Cells(12).Value & "]"
                strPos_Y = "[Y=" & dgvMarkData.Rows(tmpCnt).Cells(6).Value & "->" & dgvMarkData.Rows(tmpCnt).Cells(13).Value & "]"
                strPos_Angle = "[Angle=" & dgvMarkData.Rows(tmpCnt).Cells(7).Value & "->" & dgvMarkData.Rows(tmpCnt).Cells(14).Value & "]"
                strChange_X = "[Change_X=" & dgvMarkData.Rows(tmpCnt).Cells(8).Value & "]"
                strChange_Y = "[Change_Y=" & dgvMarkData.Rows(tmpCnt).Cells(9).Value & "]"
                strChange_Angle = "[Change_Angle=" & dgvMarkData.Rows(tmpCnt).Cells(10).Value & "]"

                If dgvMarkData.Rows(tmpCnt).Cells(5).Value <> dgvMarkData.Rows(tmpCnt).Cells(12).Value Then

                    frmMarkChangeMSG.listChangeData.Items.Add(strPos_Cnt)
                    frmMarkChangeMSG.listChangeData.Items.Add(strPos_X)
                    frmMarkChangeMSG.listChangeData.Items.Add(strChange_X)
                    frmMarkChangeMSG.listChangeData.Items.Add("")
                End If

                If dgvMarkData.Rows(tmpCnt).Cells(6).Value <> dgvMarkData.Rows(tmpCnt).Cells(13).Value Then

                    frmMarkChangeMSG.listChangeData.Items.Add(strPos_Cnt)
                    frmMarkChangeMSG.listChangeData.Items.Add(strPos_Y)
                    frmMarkChangeMSG.listChangeData.Items.Add(strChange_Y)
                    frmMarkChangeMSG.listChangeData.Items.Add("")

                End If

                If dgvMarkData.Rows(tmpCnt).Cells(7).Value <> dgvMarkData.Rows(tmpCnt).Cells(14).Value Then

                    frmMarkChangeMSG.listChangeData.Items.Add(strPos_Cnt)
                    frmMarkChangeMSG.listChangeData.Items.Add(strPos_Angle)
                    frmMarkChangeMSG.listChangeData.Items.Add(strChange_Angle)
                    frmMarkChangeMSG.listChangeData.Items.Add("")

                End If

                tmpCnt = tmpCnt + 1

            Next
        Next
        Return True
        Exit Function
SysErr:
        Return False
    End Function



    'Private Sub chkFB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFB.CheckedChanged
    '    If chkFB.Checked = True Then
    '        chkFB.Text = "상면"
    '        pCurRecipe.nSystem = 3
    '        frmMarkDataEditer.DrawMarkingData()

    '    ElseIf chkFB.Checked = False Then
    '        chkFB.Text = "배면"
    '        pCurRecipe.nSystem = 2
    '        frmMarkDataEditer.DrawMarkingData()
    '    End If
    'End Sub

    Function IsMinMaxValue(ByVal dData As Double) As Boolean
        On Error GoTo SysErr

        'If -3 > dData Or 3 < dData Then
        'If -10 > dData Or 10 < dData Then 'bsseo imsi
        '20181206 손승민 주임 요청 user,tech Limit 0.05mm, admin no Limit
        If bLogInUser = True Or bLogInTech = True Then
            If -0.05 > dData Then
                tmpDir = -1
                Return False
            ElseIf 0.05 < dData Then
                tmpDir = 1
                Return False
            Else
                Return True
            End If
        ElseIf bLogInAdmin = True Then
            Return True
        End If
        

        Exit Function
SysErr:

    End Function

    'Private Sub btnTotalApply_Click(sender As System.Object, e As System.EventArgs) Handles btnTotalApply.Click

    '    For i As Integer = 0 To tmpEditMarkData.nTotalCmdCnt - 1
    ''If dgvMarkData.Rows(i).Cells(2).Value = numCurrentGroup.Value Then

    ''If numTotalPosition_X.Value <> 0 Then

    '        dgvMarkData.Rows(i).Cells(8).Value = CDbl(dgvMarkData.Rows(i).Cells(8).Value) + numGroupPosition_X.Value
    '        dgvMarkData.Rows(i).Cells(12).Value = CDbl(dgvMarkData.Rows(i).Cells(5).Value) + CDbl(dgvMarkData.Rows(i).Cells(8).Value)
    '        If dgvMarkData.Rows(i).Cells(5).Value <> dgvMarkData.Rows(i).Cells(12).Value Then
    '            dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.Yellow
    '        ElseIf dgvMarkData.Rows(i).Cells(5).Value = dgvMarkData.Rows(i).Cells(12).Value Then
    '            dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.White
    '        End If

    ''End If

    '        If numTotalPosition_Y.Value <> 0 Then

    '            dgvMarkData.Rows(i).Cells(9).Value = CDbl(dgvMarkData.Rows(i).Cells(9).Value) + numGroupPosition_Y.Value
    '            dgvMarkData.Rows(i).Cells(13).Value = CDbl(dgvMarkData.Rows(i).Cells(6).Value) + CDbl(dgvMarkData.Rows(i).Cells(9).Value)
    '            If dgvMarkData.Rows(i).Cells(6).Value <> dgvMarkData.Rows(i).Cells(13).Value Then
    '                dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.YellowGreen
    '            ElseIf dgvMarkData.Rows(i).Cells(6).Value = dgvMarkData.Rows(i).Cells(13).Value Then
    '                dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.White
    '            End If

    '        End If

    ''End If
    '    Next

    '    numGroupPosition_X.Value = 0
    '    numGroupPosition_Y.Value = 0
    '    numGroupAngle.Value = 0

    'End Sub

    Private Sub btnTotalXApply_Click(sender As System.Object, e As System.EventArgs) Handles btnTotalXApply.Click

        For i As Integer = 0 To tmpEditMarkData.nTotalCmdCnt - 1

            If numTotalPosition_X.Value <> 0 Then

                dgvMarkData.Rows(i).Cells(8).Value = CDbl(dgvMarkData.Rows(i).Cells(8).Value) + numTotalPosition_X.Value
                dgvMarkData.Rows(i).Cells(12).Value = CDbl(dgvMarkData.Rows(i).Cells(5).Value) + CDbl(dgvMarkData.Rows(i).Cells(8).Value)
                If dgvMarkData.Rows(i).Cells(5).Value <> dgvMarkData.Rows(i).Cells(12).Value Then
                    dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.Yellow
                ElseIf dgvMarkData.Rows(i).Cells(5).Value = dgvMarkData.Rows(i).Cells(12).Value Then
                    dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.White
                End If

            End If

        Next

        numTotalPosition_X.Value = 0

    End Sub

    Private Sub btnTotalYApply_Click(sender As System.Object, e As System.EventArgs) Handles btnTotalYApply.Click

        For i As Integer = 0 To tmpEditMarkData.nTotalCmdCnt - 1

            If numTotalPosition_Y.Value <> 0 Then

                dgvMarkData.Rows(i).Cells(9).Value = CDbl(dgvMarkData.Rows(i).Cells(9).Value) + numTotalPosition_Y.Value
                dgvMarkData.Rows(i).Cells(13).Value = CDbl(dgvMarkData.Rows(i).Cells(6).Value) + CDbl(dgvMarkData.Rows(i).Cells(9).Value)
                If dgvMarkData.Rows(i).Cells(6).Value <> dgvMarkData.Rows(i).Cells(13).Value Then
                    dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.YellowGreen
                ElseIf dgvMarkData.Rows(i).Cells(6).Value = dgvMarkData.Rows(i).Cells(13).Value Then
                    dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.White
                End If

            End If

        Next

        numTotalPosition_Y.Value = 0

    End Sub

    Private Sub btnTotalRApply_Click(sender As System.Object, e As System.EventArgs) Handles btnTotalRApply.Click

        If modPub.bLogInAdmin = True Then
            For i As Integer = 0 To tmpEditMarkData.nTotalCmdCnt - 1

                If numTotalPosition_T.Value <> 0 Then

                    dgvMarkData.Rows(i).Cells(10).Value = CDbl(dgvMarkData.Rows(i).Cells(10).Value) + numTotalPosition_T.Value
                    dgvMarkData.Rows(i).Cells(14).Value = CDbl(dgvMarkData.Rows(i).Cells(7).Value) + CDbl(dgvMarkData.Rows(i).Cells(10).Value)
                    If dgvMarkData.Rows(i).Cells(7).Value <> dgvMarkData.Rows(i).Cells(14).Value Then
                        dgvMarkData.Rows(i).Cells(14).Style.BackColor = Color.Violet
                    ElseIf dgvMarkData.Rows(i).Cells(7).Value = dgvMarkData.Rows(i).Cells(14).Value Then
                        dgvMarkData.Rows(i).Cells(14).Style.BackColor = Color.White
                    End If

                End If

            Next
        Else
            If numTotalPosition_T.Value <> 0 Then
                frmMSG.ShowMsg("No Access Authority", "Admin Login Please", False, 1)
            End If
        End If
       

        numTotalPosition_T.Value = 0

    End Sub

    'Clipboard 기능 구현.
    Private Sub dgvMarkData_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dgvMarkData.KeyPress

        'nCurRow()
        'nCurCol()

        Dim Test As Integer = 0
        Dim strLength As String = "" & vbLf & ""    '지랄맞네.. 1:1로 매칭해서 마지막은 안들어가게 함.
        Test = AscW(e.KeyChar)

        If Test = 22 Then   '컨트롤 + V 넘버: 22

            Dim s As String = Clipboard.GetText()
            Dim lines As String() = s.Split(vbNewLine)
            'dgvMarkData.RowCount = lines.Count + 3

            If (dgvMarkData.RowCount - (nCurRow - 1)) < lines.Length Then
                Return
            End If

            Dim iRow As Int16 = nCurRow '0
            For Each line As String In lines
                Dim words As String() = line.Split(vbTab)
                If dgvMarkData.ColumnCount < words.Count + 3 Then
                    dgvMarkData.ColumnCount = words.Count + 4
                End If

                Dim iCol As Int16 = nCurCol '0
                For Each word As String In words
                    ' paste each word at cell
                    If strLength <> word Then
                        dgvMarkData.Item(iCol, iRow).Value = word
                        iCol += 1
                    End If
                Next
                iRow += 1
            Next

        End If

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbEditMark.Text = My.Resources.setLan.ResourceManager.GetObject("MarkDataEditer")
            .lblCurrentPen.Text = My.Resources.setLan.ResourceManager.GetObject("Pen")
            .btnSelectPen.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .gbGroupEditer.Text = My.Resources.setLan.ResourceManager.GetObject("GroupEditer")
            .GroupBox76.Text = My.Resources.setLan.ResourceManager.GetObject("Data")
            .lblGroupPosition_X.Text = My.Resources.setLan.ResourceManager.GetObject("OffsetX")
            .lblGroupPosition_Y.Text = My.Resources.setLan.ResourceManager.GetObject("OffsetY")
            .lblGroupAngle.Text = My.Resources.setLan.ResourceManager.GetObject("Angle")
            .Label487.Text = My.Resources.setLan.ResourceManager.GetObject("Group")
            .lblGroupShowScale.Text = My.Resources.setLan.ResourceManager.GetObject("ShowScale")
            .btnGroupApply.Text = My.Resources.setLan.ResourceManager.GetObject("Apply")
            .btnGroupShow.Text = My.Resources.setLan.ResourceManager.GetObject("Show")
            .gbVLine.Text = My.Resources.setLan.ResourceManager.GetObject("VLineData")
            .Label482.Text = My.Resources.setLan.ResourceManager.GetObject("X1")
            .Label486.Text = My.Resources.setLan.ResourceManager.GetObject("X2")
            .Label479.Text = My.Resources.setLan.ResourceManager.GetObject("Y")
            .Label459.Text = My.Resources.setLan.ResourceManager.GetObject("Speed")
            .Label422.Text = My.Resources.setLan.ResourceManager.GetObject("Repeat")
            .chkVline.Text = My.Resources.setLan.ResourceManager.GetObject("First")
            .btnApply.Text = My.Resources.setLan.ResourceManager.GetObject("ValueApplyApply")
            .btnShow.Text = My.Resources.setLan.ResourceManager.GetObject("ShowShow")
            .optSystemMode_Normal.Text = My.Resources.setLan.ResourceManager.GetObject("Normal")
            .optSystemMode_Mode1.Text = My.Resources.setLan.ResourceManager.GetObject("Mode1")
            .optSystemMode_Mode2.Text = My.Resources.setLan.ResourceManager.GetObject("Mode2")
            .btnSaveMarkData.Text = My.Resources.setLan.ResourceManager.GetObject("SaveMarkData")

        End With

    End Sub

    Private Sub btn_AllApply_Click(sender As System.Object, e As System.EventArgs) Handles btn_AllApply.Click
        For i As Integer = 0 To tmpEditMarkData.nTotalCmdCnt - 1

            '20181207 손승민 주임 요청 user,tech Limit 0.05mm이상이면 0.05mm 적용 admin no Limit
            If IsMinMaxValue(dgvMarkData.Rows(i).Cells(8).Value) = False Then
                frmMSG.ShowMsg("Data Input Limit", " : OffsetX value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
                dgvMarkData.Rows(i).Cells(12).Value = CDbl(dgvMarkData.Rows(i).Cells(5).Value) + (0.05 * tmpDir)
            Else
                dgvMarkData.Rows(i).Cells(12).Value = CDbl(dgvMarkData.Rows(i).Cells(5).Value) + CDbl(dgvMarkData.Rows(i).Cells(8).Value)
            End If

            If IsMinMaxValue(dgvMarkData.Rows(i).Cells(9).Value) = False Then

                frmMSG.ShowMsg("Data Input Limit", " : OffsetY value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
                dgvMarkData.Rows(i).Cells(13).Value = CDbl(dgvMarkData.Rows(i).Cells(6).Value) + (0.05 * tmpDir)
            Else
                dgvMarkData.Rows(i).Cells(13).Value = CDbl(dgvMarkData.Rows(i).Cells(6).Value) + CDbl(dgvMarkData.Rows(i).Cells(9).Value)
            End If

            If modPub.bLogInAdmin = True Then
                If IsMinMaxValue(dgvMarkData.Rows(i).Cells(10).Value) = False Then

                    frmMSG.ShowMsg("Data Input Limit", " : Offset Angle value is Limit. ( -0.05mm ~ +0.05mm)", False, 1)
                    dgvMarkData.Rows(i).Cells(14).Value = CDbl(dgvMarkData.Rows(i).Cells(7).Value) + (0.05 * tmpDir)
                Else
                    dgvMarkData.Rows(i).Cells(14).Value = CDbl(dgvMarkData.Rows(i).Cells(7).Value) + CDbl(dgvMarkData.Rows(i).Cells(10).Value)
                End If
            Else
                If dgvMarkData.Rows(nCurSelIndex).Cells(10).Value <> 0 Then
                    frmMSG.ShowMsg("No Access Authority", "Admin Login Please", False, 1)
                End If
            End If
          
            ''x
            'dgvMarkData.Rows(i).Cells(12).Value = CDbl(dgvMarkData.Rows(i).Cells(5).Value) + CDbl(dgvMarkData.Rows(i).Cells(8).Value)
            If dgvMarkData.Rows(i).Cells(5).Value <> dgvMarkData.Rows(i).Cells(12).Value Then
                dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.Yellow
            ElseIf dgvMarkData.Rows(i).Cells(5).Value = dgvMarkData.Rows(i).Cells(12).Value Then
                dgvMarkData.Rows(i).Cells(12).Style.BackColor = Color.White
            End If

            ''y
            'dgvMarkData.Rows(i).Cells(13).Value = CDbl(dgvMarkData.Rows(i).Cells(6).Value) + CDbl(dgvMarkData.Rows(i).Cells(9).Value)
            If dgvMarkData.Rows(i).Cells(6).Value <> dgvMarkData.Rows(i).Cells(13).Value Then
                dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.YellowGreen
            ElseIf dgvMarkData.Rows(i).Cells(6).Value = dgvMarkData.Rows(i).Cells(13).Value Then
                dgvMarkData.Rows(i).Cells(13).Style.BackColor = Color.White
            End If

            ''g
            'dgvMarkData.Rows(i).Cells(14).Value = CDbl(dgvMarkData.Rows(i).Cells(7).Value) + CDbl(dgvMarkData.Rows(i).Cells(10).Value)
            If dgvMarkData.Rows(i).Cells(7).Value <> dgvMarkData.Rows(i).Cells(14).Value Then
                dgvMarkData.Rows(i).Cells(14).Style.BackColor = Color.Violet
            ElseIf dgvMarkData.Rows(i).Cells(7).Value = dgvMarkData.Rows(i).Cells(14).Value Then
                dgvMarkData.Rows(i).Cells(14).Style.BackColor = Color.White
            End If



        Next

        numTotalPosition_T.Value = 0
        numTotalPosition_Y.Value = 0
        numTotalPosition_X.Value = 0
    End Sub
End Class
