Public Class frmMarkDataEditer
    Dim nCurSelIndex As Integer = 0
    Public nDirX As Integer = -1
    Public nDirY As Integer = 1
    Public pStrCurEditMarkData As String = ""

    Private Sub frmMarkDataEditer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo SysErr
        DrawData.Scale = 3
        DrawData.OffX = 0
        DrawData.OffY = 0
        DrawData.CenterX = 300
        DrawData.CenterY = 300
        DrawData.SizeX = 600
        DrawData.SizeY = 600
        DrawData.CrossSize = 1

        Select Case pCurSystemParam.nSystem
            Case 0
                chkInverse.Checked = False
                lblStatus.Text = "Front"
                chkInverse.Text = "Front"
                lblX_Minus.Text = "X-"
                lblX_Plus.Text = "X+"
                nDirX = 1
                chkTopBottom.Checked = False
                lblStatusY.Text = "Top"
                chkTopBottom.Text = "Top"
                lblY_Minus.Text = "Y-"
                lblY_Plus.Text = "Y+"
                nDirY = 1
            Case 1
                chkInverse.Checked = True
                lblStatus.Text = "Back"
                chkInverse.Text = "Back"
                lblX_Minus.Text = "X+"
                lblX_Plus.Text = "X-"
                nDirX = -1
                chkTopBottom.Checked = False
                lblStatusY.Text = "Top"
                chkTopBottom.Text = "Top"
                lblY_Minus.Text = "Y-"
                lblY_Plus.Text = "Y+"
                nDirY = 1
            Case 2
                chkInverse.Checked = False
                lblStatus.Text = "Front"
                chkInverse.Text = "Front"
                lblX_Minus.Text = "X+" '"X+"
                lblX_Plus.Text = "X-" '"X-"
                nDirX = -1  '1
                chkTopBottom.Checked = True
                lblStatusY.Text = "Bottom"
                chkTopBottom.Text = "Bottom"
                lblY_Minus.Text = "Y+"
                lblY_Plus.Text = "Y-"
                nDirY = -1

            Case 3
                chkInverse.Checked = False
                lblStatus.Text = "Front"
                chkInverse.Text = "Front"
                lblX_Minus.Text = "X-"
                lblX_Plus.Text = "X+"
                nDirX = 1
                chkTopBottom.Checked = True
                lblStatusY.Text = "Bottom"
                chkTopBottom.Text = "Bottom"
                lblY_Minus.Text = "Y+"
                lblY_Plus.Text = "Y-"
                nDirY = -1
        End Select

        bmBack = New Bitmap(DrawData.SizeX, DrawData.SizeY)
        grBack = Graphics.FromImage(bmBack)
        InitData()
        Exit Sub
SysErr:

    End Sub
    Public Function DrawMarkingData() As Boolean

        DrawData.Scale = 3
        DrawData.OffX = 0
        DrawData.OffY = 0
        DrawData.CenterX = 300
        DrawData.CenterY = 300
        DrawData.SizeX = 600
        DrawData.SizeY = 600
        DrawData.CrossSize = 1

        Select Case pCurRecipe.nSystem
            Case 0
                chkInverse.Checked = False
                lblStatus.Text = "Front"
                chkInverse.Text = "Front"
                lblX_Minus.Text = "X-"
                lblX_Plus.Text = "X+"
                nDirX = -1
                chkTopBottom.Checked = False
                lblStatusY.Text = "Top"
                chkTopBottom.Text = "Top"
                lblY_Minus.Text = "Y-"
                lblY_Plus.Text = "Y+"
                nDirY = 1
            Case 1
                chkInverse.Checked = True
                lblStatus.Text = "Back"
                chkInverse.Text = "Back"
                lblX_Minus.Text = "X+"
                lblX_Plus.Text = "X-"
                nDirX = -1
                chkTopBottom.Checked = False
                lblStatusY.Text = "Top"
                chkTopBottom.Text = "Top"
                lblY_Minus.Text = "Y-"
                lblY_Plus.Text = "Y+"
                nDirY = 1
            Case 2
                chkInverse.Checked = False
                lblStatus.Text = "Front"
                chkInverse.Text = "Front"
                lblX_Minus.Text = "X+" '"X-"
                lblX_Plus.Text = "X-" '"X+"
                nDirX = -1  '1
                chkTopBottom.Checked = True
                lblStatusY.Text = "Bottom"
                chkTopBottom.Text = "Bottom"
                lblY_Minus.Text = "Y+"
                lblY_Plus.Text = "Y-"
                nDirY = -1

            Case 3
                chkInverse.Checked = False
                lblStatus.Text = "Front"
                chkInverse.Text = "Front"
                lblX_Minus.Text = "X-"
                lblX_Plus.Text = "X+"
                nDirX = 1
                chkTopBottom.Checked = True
                lblStatusY.Text = "Bottom"
                chkTopBottom.Text = "Bottom"
                lblY_Minus.Text = "Y+"
                lblY_Plus.Text = "Y-"
                nDirY = -1

        End Select

        bmBack = New Bitmap(DrawData.SizeX, DrawData.SizeY)
        grBack = Graphics.FromImage(bmBack)


    End Function
    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
        On Error GoTo SysErr
        If DrawData.Scale >= 200 Then
            DrawData.Scale = 200
        Else
            DrawData.Scale = DrawData.Scale + 1
        End If
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub WheelZoom(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles MyBase.MouseWheel
        On Error GoTo SysErr

        If e.Delta > 0 Then
            If DrawData.Scale >= 200 Then
                DrawData.Scale = 200
            Else
                DrawData.Scale = DrawData.Scale + 1
            End If
        ElseIf e.Delta < 0 Then
            If DrawData.Scale <= 3 Then
                DrawData.Scale = 3
            Else
                DrawData.Scale = DrawData.Scale - 1
            End If
        End If
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom.Click
        On Error GoTo SysErr
        DrawData.Scale = 3
        DrawMarkData()

        Exit Sub
SysErr:

    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        On Error GoTo SysErr
        If DrawData.Scale <= 3 Then
            DrawData.Scale = 3
        Else
            DrawData.Scale = DrawData.Scale - 1
        End If
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnRightX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightX.Click
        On Error GoTo SysErr
        DrawData.OffX = DrawData.OffX + numOffset.Value
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnLeftX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftX.Click
        On Error GoTo SysErr
        DrawData.OffX = DrawData.OffX - numOffset.Value
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCenter.Click
        On Error GoTo SysErr
        DrawData.OffX = 0
        DrawData.OffY = 0
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnUPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUPY.Click
        On Error GoTo SysErr
        DrawData.OffY = DrawData.OffY + numOffset.Value
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnDnY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDnY.Click
        On Error GoTo SysErr
        DrawData.OffY = DrawData.OffY - numOffset.Value
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub numPointSize_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPointSize.ValueChanged
        On Error GoTo SysErr
        DrawData.CrossSize = numPointSize.Value
        DrawMarkData()
        Exit Sub
SysErr:

    End Sub

    Private Sub chkInverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInverse.Click
        On Error GoTo SysErr
        If chkInverse.Checked = True Then
            lblStatus.Text = "Back"
            chkInverse.Text = "Back"
            lblX_Minus.Text = "X+"
            lblX_Plus.Text = "X-"

            nDirX = -1
        ElseIf chkInverse.Checked = False Then
            lblStatus.Text = "Front"
            chkInverse.Text = "Front"
            lblX_Minus.Text = "X-"
            lblX_Plus.Text = "X+"
            nDirX = 1
        End If

        DrawMarkData()

        Exit Sub
SysErr:

    End Sub

    Private Sub chkTopBottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTopBottom.Click
        On Error GoTo SysErr
        If chkTopBottom.Checked = True Then
            lblStatusY.Text = "Bottom"
            chkTopBottom.Text = "Bottom"
            lblY_Minus.Text = "Y+"
            lblY_Plus.Text = "Y-"
            nDirY = -1
        ElseIf chkTopBottom.Checked = False Then
            lblStatusY.Text = "TOP"
            chkTopBottom.Text = "TOP"
            lblY_Minus.Text = "Y-"
            lblY_Plus.Text = "Y+"
            nDirY = 1
        End If
        DrawMarkData()

        Exit Sub
SysErr:

    End Sub

    Public Sub DrawMarkData(Optional ByVal bDrawRect As Boolean = False)
        On Error GoTo SysErr

        Dim tmpPosX As Double
        Dim tmpPosY As Double
        Dim tmpExPosX As Double
        Dim tmpExPosY As Double

        Dim tmpChangePosX As Double
        Dim tmpChangePosY As Double
        Dim tmpChangeExPosX As Double
        Dim tmpChangeExPosY As Double

        '20160907 JCM
        Dim dRectGab As Double = 0

        grBack.Clear(Color.Black)

        'For i As Integer = 0 To frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.RowCount - 1
        For i As Integer = 0 To frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.RowCount - 1
            tmpPosX = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(5).Value
            tmpPosY = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(6).Value

            tmpChangePosX = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(12).Value
            tmpChangePosY = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(13).Value
            If i = 0 Then
                tmpExPosX = 0
                tmpExPosY = 0
                tmpChangeExPosX = 0
                tmpChangeExPosY = 0
            Else
                tmpExPosX = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i - 1).Cells(5).Value
                tmpExPosY = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i - 1).Cells(6).Value
                tmpChangeExPosX = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i - 1).Cells(12).Value
                tmpChangeExPosY = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i - 1).Cells(13).Value
            End If
            Select Case frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(4).Value

                Case "MA"
                    DrawLine(grBack, tmpChangeExPosX * nDirX, tmpChangeExPosY * nDirY, tmpChangePosX * nDirX, tmpChangePosY * nDirY, Pens.Aqua)
                    DrawLine(grBack, tmpExPosX * nDirX, tmpExPosY * nDirY, tmpPosX * nDirX, tmpPosY * nDirY, Pens.Red)
                Case "AA"
                    '20160707 이근욱S 수정 - Arc 좌표 계산 방식 변경
                    Dim centerX As Double = 0
                    Dim centerY As Double = 0
                    Dim angle As Double = 0
                    Dim tmpRadius As Double = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(14).Value
                    Dim tmpRadius_Ori As Double = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(7).Value

                    If CalcRotationCenter(tmpChangeExPosX * nDirX, tmpChangeExPosY * nDirY, tmpChangePosX * nDirX, tmpChangePosY * nDirY, tmpRadius * nDirX, centerX, centerY, angle) = True Then
                        DrawArcCnR(grBack, tmpChangeExPosX * nDirX, tmpChangeExPosY * nDirY, centerX, centerY, 0, angle, Pens.Aqua)
                    End If

                    If CalcRotationCenter(tmpExPosX * nDirX, tmpExPosY * nDirY, tmpPosX * nDirX, tmpPosY * nDirY, tmpRadius_Ori * nDirX, centerX, centerY, angle) = True Then
                        DrawArcCnR(grBack, tmpExPosX * nDirX, tmpExPosY * nDirY, centerX, centerY, 0, angle, Pens.Red)
                    End If

                    '여기 우선 막자..
                    'DrawArcCnR(grBack, tmpExPosX * nDirX, tmpExPosY * nDirY, tmpPosX * nDirX, tmpPosY * nDirY, 0, frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(i).Cells(6).Value * nDirX, Pens.Red)
            End Select
        Next

        If frmRecipe.m_ctrlRcpMarkEditor.numV_LineRepeat.Value > 0 Then
            DrawLine(grBack, frmRecipe.m_ctrlRcpMarkEditor.numV_LineX1.Value * nDirX, frmRecipe.m_ctrlRcpMarkEditor.numV_LineY.Value * nDirY, frmRecipe.m_ctrlRcpMarkEditor.numV_LineX2.Value * nDirX, frmRecipe.m_ctrlRcpMarkEditor.numV_LineY.Value * nDirY, Pens.Red)
        End If

        If bDrawRect = True Then
            DrawLine(grBack, frmRecipe.m_ctrlRcpMarkEditor.pnMinPosX * nDirX - dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMinPosY * nDirY - dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMaxPosX * nDirX + dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMinPosY * nDirY - dRectGab, Pens.Lime)
            DrawLine(grBack, frmRecipe.m_ctrlRcpMarkEditor.pnMaxPosX * nDirX + dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMinPosY * nDirY - dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMaxPosX * nDirX + dRectGab, frmRecipe.pnMaxPosY * nDirY + dRectGab, Pens.Lime)
            DrawLine(grBack, frmRecipe.m_ctrlRcpMarkEditor.pnMaxPosX * nDirX + dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMaxPosY * nDirY + dRectGab, frmRecipe.pnMinPosX * nDirX - dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMaxPosY * nDirY + dRectGab, Pens.Lime)
            DrawLine(grBack, frmRecipe.m_ctrlRcpMarkEditor.pnMinPosX * nDirX - dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMaxPosY * nDirY + dRectGab, frmRecipe.pnMinPosX * nDirX - dRectGab, frmRecipe.m_ctrlRcpMarkEditor.pnMinPosY * nDirY - dRectGab, Pens.Lime)
        End If

        pbPreview.Image = bmBack
        pbPreview.Update()
        Exit Sub
SysErr:

    End Sub

    Public Sub DrawSelectData(ByVal nSelectIndex As Integer)
        On Error GoTo SysErr
        Dim tmpPosX As Double
        Dim tmpPosY As Double
        Dim tmpExPosX As Double
        Dim tmpExPosY As Double

        DrawMarkData()

        tmpPosX = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(nSelectIndex).Cells(12).Value
        tmpPosY = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(nSelectIndex).Cells(13).Value

        If nSelectIndex = 0 Then
            tmpExPosX = 0
            tmpExPosY = 0
        Else
            tmpExPosX = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(nSelectIndex - 1).Cells(12).Value
            tmpExPosY = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(nSelectIndex - 1).Cells(13).Value
        End If

        DrawLine(grBack, (tmpPosX - DrawData.CrossSize) * nDirX, tmpPosY * nDirY, (tmpPosX + DrawData.CrossSize) * nDirX, tmpPosY * nDirY, Pens.Lime)
        DrawLine(grBack, tmpPosX * nDirX, (tmpPosY - DrawData.CrossSize) * nDirY, tmpPosX * nDirX, (tmpPosY + DrawData.CrossSize) * nDirY, Pens.Lime)


        Select Case frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(nSelectIndex).Cells(4).Value
            Case "JA"
                DrawLine(grBack, tmpPosX * nDirX, tmpPosY * nDirY, tmpExPosX * nDirX, tmpExPosY * nDirY, Pens.White)

            Case "MA"
                DrawLine(grBack, tmpPosX * nDirX, tmpPosY * nDirY, tmpExPosX * nDirX, tmpExPosY * nDirY, Pens.Yellow)

            Case "AA"
                Dim dist As Double
                Dim nAng As Integer
                Dim rtnx, rtny As Double

                '20160707 이근욱S 수정 - Arc 좌표 계산 방식 변경
                Dim centerX As Double = 0
                Dim centerY As Double = 0
                Dim angle As Double = 0
                Dim tmpRadius As Double = frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(nSelectIndex).Cells(14).Value

                If CalcRotationCenter(tmpExPosX * nDirX, tmpExPosY * nDirY, tmpPosX * nDirX, tmpPosY * nDirY, tmpRadius * nDirX, centerX, centerY, angle) Then
                    DrawArcCnR(grBack, tmpExPosX * nDirX, tmpExPosY * nDirY, centerX, centerY, 0, angle, Pens.Yellow)

                    '원호를 그려준다
                    Dim angleReverse As Double = 0
                    If 0 < angle Then
                        angleReverse = angle - 360.0
                    Else
                        angleReverse = angle + 360.0
                    End If
                    DrawArcCnR(grBack, tmpExPosX * nDirX, tmpExPosY * nDirY, centerX, centerY, 0, angleReverse, Pens.Gray)

                    '회전 중심 표시
                    DrawLine(grBack, centerX - DrawData.CrossSize / 5.0, centerY, centerX + DrawData.CrossSize / 5.0, centerY, Pens.Gray)
                    DrawLine(grBack, centerX, centerY - DrawData.CrossSize / 5.0, centerX, centerY + DrawData.CrossSize / 5.0, Pens.Gray)
                End If

                If frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.RowCount - 1 > nSelectIndex Then
                    '20160707 이근욱S 수정 - Arc 좌표 계산 방식 변경
                    DrawLine(grBack, (tmpPosX - DrawData.CrossSize) * nDirX, tmpPosY * nDirY, (tmpPosX + DrawData.CrossSize) * nDirX, tmpPosY * nDirY, Pens.Lime)
                    DrawLine(grBack, tmpPosX * nDirX, (tmpPosY - DrawData.CrossSize) * nDirY, tmpPosX * nDirX, (tmpPosY + DrawData.CrossSize) * nDirY, Pens.Lime)

                End If

        End Select

        pbPreview.Image = bmBack
        pbPreview.Update()
        Exit Sub
SysErr:

    End Sub

    Public Sub InitData()
        On Error GoTo SysErr
#If HEAD_2 Then
        frmSequence_2Head.Visible = False
        frmSetting_BCR.Visible = False
#Else
        frmSequence.Visible = False
        frmSetting.Visible = False
#End If

        frmRecipe.m_ctrlRcpMarkEditor.InputData()
        frmRecipe.m_bEnableBlack = False

        DrawData.OffX = 0
        DrawData.OffY = 0

        DrawMarkData()
        dgvPenData.RowCount = pCurRecipe.PenData.Count
        For i As Integer = 1 To pCurRecipe.PenData.Count
            dgvPenData.Rows(i - 1).Cells(0).Value = i
            dgvPenData.Rows(i - 1).Cells(1).Value = pCurRecipe.PenData.MarkSpeed(i - 1)
            dgvPenData.Rows(i - 1).Cells(2).Value = pCurRecipe.PenData.JumpSpeed(i - 1)
            dgvPenData.Rows(i - 1).Cells(3).Value = pCurRecipe.PenData.Repeat(i - 1)
            If pCurRecipe.PenData.MarkMode(i - 1) = 1 Then
                dgvPenData.Rows(i - 1).Cells(4).Value = "CW"
            ElseIf pCurRecipe.PenData.MarkMode(i - 1) = 2 Then
                dgvPenData.Rows(i - 1).Cells(4).Value = "CCW"
            ElseIf pCurRecipe.PenData.MarkMode(i - 1) = 3 Then
                dgvPenData.Rows(i - 1).Cells(4).Value = "Mode3"
            End If
        Next
        BlackBox(False)
        Exit Sub
SysErr:
        'MsgBox(Err.Description)

    End Sub

    Private Sub pbPreview_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbPreview.MouseDown
        btnZoom.Focus()
        nTmpX = ((DrawData.CenterX - e.X) + (DrawData.OffX * DrawData.Scale))
        nTmpY = ((e.Y - DrawData.CenterY) + (DrawData.OffY * DrawData.Scale))
    End Sub

    Private Sub pbPreview_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbPreview.MouseMove
        Me.Focus()

        If e.Button = Windows.Forms.MouseButtons.Left Then
            DrawData.OffX = ((DrawData.CenterX - e.X - nTmpX) / DrawData.Scale) * -1
            DrawData.OffY = ((e.Y - DrawData.CenterY - nTmpY) / DrawData.Scale) * -1
            nTmpLastX = DrawData.OffX
            nTmpLastY = DrawData.OffY
            DrawMarkData()
        End If

    End Sub

    Dim nTmpX As Integer
    Dim nTmpY As Integer
    Dim nTmpLastX As Integer
    Dim nTmpLastY As Integer

    Dim nRectStartX As Integer
    Dim nRectStartY As Integer


    Private Sub dgvPenData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPenData.CellClick
        On Error GoTo SysErr
        nCurSelIndex = e.RowIndex

        For i As Integer = 0 To dgvPenData.RowCount - 1
            For j As Integer = 0 To 4
                If i = nCurSelIndex Then
                    dgvPenData.Rows(i).Cells(j).Style.BackColor = Color.LightGreen
                Else
                    dgvPenData.Rows(i).Cells(j).Style.BackColor = Color.White
                End If
            Next
        Next

        txtPenNumver.Text = dgvPenData.Rows(nCurSelIndex).Cells(0).Value
        numMarkSpd.Value = dgvPenData.Rows(nCurSelIndex).Cells(1).Value
        numJumpSpd.Value = dgvPenData.Rows(nCurSelIndex).Cells(2).Value
        numMarkRepeat.Value = dgvPenData.Rows(nCurSelIndex).Cells(3).Value
        cbMarkMode.Text = dgvPenData.Rows(nCurSelIndex).Cells(4).Value
        Exit Sub
SysErr:
    End Sub

    Private Sub btnPenDataApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPenDataApply.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmMarkDataEditer -- btnPenDataApply_Click")
        'GYN - 인터락 추가.
        If numMarkSpd.Value = 0 Or numJumpSpd.Value = 0 Then
            Return
        End If
        modPub.SystemLog("------------------Pen Data Apply-------------------")
        modPub.SystemLog("Mark Speed : " & pSetRecipe.PenData.MarkSpeed(nCurSelIndex) & "-> " & numMarkSpd.Value)
        modPub.SystemLog("Jump Speed : " & pSetRecipe.PenData.JumpSpeed(nCurSelIndex) & "-> " & numJumpSpd.Value)
        modPub.SystemLog("Repeat : " & pSetRecipe.PenData.Repeat(nCurSelIndex) & "-> " & numMarkRepeat.Value)
        modPub.SystemLog("Mode : " & dgvPenData.Rows(nCurSelIndex).Cells(4).Value & "-> " & cbMarkMode.Text)

        pSetRecipe.PenData.MarkSpeed(nCurSelIndex) = numMarkSpd.Value
        pSetRecipe.PenData.JumpSpeed(nCurSelIndex) = numJumpSpd.Value
        pSetRecipe.PenData.Repeat(nCurSelIndex) = numMarkRepeat.Value

        If cbMarkMode.Text = "CW" Then
            pSetRecipe.PenData.MarkMode(nCurSelIndex) = 1
        ElseIf cbMarkMode.Text = "CCW" Then
            pSetRecipe.PenData.MarkMode(nCurSelIndex) = 2
        ElseIf cbMarkMode.Text = "Mode3" Then
            pSetRecipe.PenData.MarkMode(nCurSelIndex) = 3
        End If

        dgvPenData.Rows(nCurSelIndex).Cells(1).Value = numMarkSpd.Value
        dgvPenData.Rows(nCurSelIndex).Cells(2).Value = numJumpSpd.Value
        dgvPenData.Rows(nCurSelIndex).Cells(3).Value = numMarkRepeat.Value
        dgvPenData.Rows(nCurSelIndex).Cells(4).Value = cbMarkMode.Text

        Exit Sub
SysErr:
    End Sub

    Private Sub numMarkSpd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numMarkSpd.ValueChanged, numMarkSpd.Click
        On Error GoTo SysErr

        frmRecipe.pbResetBlackBoxCnt = True

        If numMarkSpd.Value < pCurSystemParam.nScanMarkSpdLimt Then
            numMarkSpd.Value = pCurSystemParam.nScanMarkSpdLimt
        End If

        Exit Sub
SysErr:
    End Sub

    Private Sub numJumpSpd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numJumpSpd.ValueChanged, numJumpSpd.Click
        On Error GoTo SysErr

        frmRecipe.pbResetBlackBoxCnt = True

        If numJumpSpd.Value < pCurSystemParam.nScanJumpSpdLimt Then
            numJumpSpd.Value = pCurSystemParam.nScanJumpSpdLimt
        End If

        Exit Sub
SysErr:
    End Sub

    Private Sub numMarkRepeat_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numMarkRepeat.Click
        On Error GoTo SysErr

        Exit Sub
SysErr:
    End Sub

    Public Sub BlackBox(ByVal bEnable As Boolean)
        On Error GoTo SysErr
        If bEnable = True Then
            frmRecipe.gbRecipeChoice.BackColor = Color.Red
            For i As Integer = 1 To pCurRecipe.PenData.Count
                dgvPenData.Rows(i - 1).Cells(0).Value = i
                dgvPenData.Rows(i - 1).Cells(1).Value = pCurRecipe.PenData.MarkSpeed(i - 1)
                dgvPenData.Rows(i - 1).Cells(2).Value = pCurRecipe.PenData.JumpSpeed(i - 1)
                dgvPenData.Rows(i - 1).Cells(3).Value = pCurRecipe.PenData.Repeat(i - 1)
                If pCurRecipe.PenData.MarkMode(i - 1) = 1 Then
                    dgvPenData.Rows(i - 1).Cells(4).Value = "CW"
                ElseIf pCurRecipe.PenData.MarkMode(i - 1) = 2 Then
                    dgvPenData.Rows(i - 1).Cells(4).Value = "CCW"
                ElseIf pCurRecipe.PenData.MarkMode(i - 1) = 3 Then
                    dgvPenData.Rows(i - 1).Cells(4).Value = "Mode3"
                End If
            Next

            '초기화
            txtPenNumver.Text = (nCurSelIndex + 1)
            numMarkSpd.Value = pCurRecipe.PenData.MarkSpeed(nCurSelIndex)
            numJumpSpd.Value = pCurRecipe.PenData.JumpSpeed(nCurSelIndex)
            numMarkRepeat.Value = pCurRecipe.PenData.Repeat(nCurSelIndex)
            If pCurRecipe.PenData.MarkMode(nCurSelIndex) = 1 Then
                cbMarkMode.Text = "CW"
            ElseIf pCurRecipe.PenData.MarkMode(nCurSelIndex) = 2 Then
                cbMarkMode.Text = "CCW"
            ElseIf pCurRecipe.PenData.MarkMode(nCurSelIndex) = 3 Then
                cbMarkMode.Text = "Mode3"
            End If

            frmRecipe.m_ctrlRcpMarkEditor.btnSaveMarkData.Enabled = True
            btnPenDataApply.Enabled = True

        ElseIf bEnable = False Then
            frmRecipe.gbRecipeChoice.BackColor = Color.White
            For i As Integer = 1 To pCurRecipe.PenData.Count
                dgvPenData.Rows(i - 1).Cells(0).Value = i
                dgvPenData.Rows(i - 1).Cells(1).Value = 100
                dgvPenData.Rows(i - 1).Cells(2).Value = 500
                dgvPenData.Rows(i - 1).Cells(3).Value = 40
                dgvPenData.Rows(i - 1).Cells(4).Value = "CW"
            Next

            '초기화
            txtPenNumver.Text = (nCurSelIndex + 1)
            numMarkSpd.Value = 100
            numJumpSpd.Value = 500
            numMarkRepeat.Value = 40
            cbMarkMode.Text = "CW"

            frmRecipe.m_ctrlRcpMarkEditor.btnSaveMarkData.Enabled = False
            btnPenDataApply.Enabled = False
        End If
        Exit Sub
SysErr:

    End Sub

  
    Private Sub pbPreview_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbPreview.Click
        Dim dposx As Double
        Dim dposy As Double
        If e.Button = Windows.Forms.MouseButtons.Right Then
            dposx = e.X - 300
            dposy = e.Y - 300
        End If

    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .GroupBox1.Text = My.Resources.setLan.ResourceManager.GetObject("MarkDataPreview")

            .GroupBox2.Text = My.Resources.setLan.ResourceManager.GetObject("PenDataEditer")
            .GroupBox3.Text = My.Resources.setLan.ResourceManager.GetObject("PenDataView")
            .btnPenDataApply.Text = My.Resources.setLan.ResourceManager.GetObject("Apply")
            .Label7.Text = My.Resources.setLan.ResourceManager.GetObject("PenNumber")

            .Label6.Text = My.Resources.setLan.ResourceManager.GetObject("MarkSpeed")
            .Label3.Text = My.Resources.setLan.ResourceManager.GetObject("JumpSpeed")
            .Label2.Text = My.Resources.setLan.ResourceManager.GetObject("Repeat")
            .Label6.Text = My.Resources.setLan.ResourceManager.GetObject("MarkSpeed")

        End With

    End Sub
End Class