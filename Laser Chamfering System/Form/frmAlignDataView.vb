Public Class frmAlignDataView
    Public bLoadView As Boolean = False
    Private Sub frmAlarm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo SysErr

        DrawDataAlign1.Scale = 1
        DrawDataAlign1.OffX = 0
        DrawDataAlign1.OffY = 0
        DrawDataAlign1.CenterX = 1360 / 2
        DrawDataAlign1.CenterY = 1040 / 2
        DrawDataAlign1.SizeX = 1360
        DrawDataAlign1.SizeY = 1040
        DrawDataAlign1.CrossSize = 3

        DrawDataAlign2.Scale = 1
        DrawDataAlign2.OffX = 0
        DrawDataAlign2.OffY = 0
        DrawDataAlign2.CenterX = 680
        DrawDataAlign2.CenterY = 520
        DrawDataAlign2.SizeX = 1360
        DrawDataAlign2.SizeY = 1040
        DrawDataAlign2.CrossSize = 3

        bmBackAlign1 = New Bitmap(DrawDataAlign1.SizeX, DrawDataAlign1.SizeY)
        grBackAlign1 = Graphics.FromImage(bmBackAlign1)

        bmBackAlign2 = New Bitmap(DrawDataAlign2.SizeX, DrawDataAlign2.SizeY)
        grBackAlign2 = Graphics.FromImage(bmBackAlign2)

        grBackAlign1.Clear(Color.White)
        grBackAlign2.Clear(Color.White)

        DrawCrossLine()

        'DrawAlignMark(grBackAlign1, 100, 300)
        'DrawAlignMark(grBackAlign1, 105, 305)
        'DrawAlignMark(grBackAlign1, 107, 303)
        'DrawAlignMark(grBackAlign1, 103, 310)
        'DrawAlignMark(grBackAlign1, 110, 308)

        'DrawAlignMark(grBackAlign1, 500, 800)

        'DrawAlignMark(grBackAlign2, 100, 300)
        'DrawAlignMark(grBackAlign2, 105, 305)
        'DrawAlignMark(grBackAlign2, 107, 303)
        'DrawAlignMark(grBackAlign2, 103, 310)
        'DrawAlignMark(grBackAlign2, 110, 308)

        'DrawAlignMark(grBackAlign2, 488, 900)

        pbPreview1.Image = bmBackAlign1
        pbPreview1.Update()
        pbPreview2.Image = bmBackAlign2
        pbPreview2.Update()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmAlarm -- frmAlarm_Load")
    End Sub

    Private Sub frmAlarm_FormClosing(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        On Error GoTo SysErr

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmAlarm -- frmAlarm_Close")
    End Sub

    Public Function Init() As Boolean
        On Error GoTo SysErr

        Return True
        Exit Function
SysErr:
        Return False
    End Function


    Public Sub DrawCrossLine() 'Private Sub DrawCrossLine()

        Dim pPen = New Pen(Color.Red, 3)
        Dim First1 = New Point(680 / 4, 0 / 3.15)
        Dim Second1 = New Point(680 / 4, 1040 / 3.15)
        Dim First2 = New Point(0 / 4, 520 / 3.15)
        Dim Second2 = New Point(1360 / 4, 520 / 3.15)

        'DrawLine(grBackAlign1, 0, 0, DrawDataAlign1.SizeX, DrawDataAlign1.SizeY, Pens.Red)
        grBackAlign1.DrawLine(pPen, First1, Second1)
        grBackAlign2.DrawLine(pPen, First1, Second1)
        grBackAlign1.DrawLine(pPen, First2, Second2)
        grBackAlign2.DrawLine(pPen, First2, Second2)

        First1 = Nothing
        Second1 = Nothing
        First2 = Nothing
        Second2 = Nothing
        pPen = Nothing

    End Sub

    Private Sub DrawAlignMark(ByVal ipGr As Graphics, ByVal dX As Double, ByVal dY As Double, ByVal bOn As Boolean)

        Dim pPen As Pen = Nothing

        If bOn = True Then
            pPen = New Pen(Color.Black, 1)
        ElseIf bOn = False Then
            pPen = New Pen(Color.White, 1)
        End If

        Dim First1 = New Point(dX / 4, (dY - 50) / 3.15)
        Dim Second1 = New Point(dX / 4, (dY + 50) / 3.15)
        Dim First2 = New Point((dX - 50) / 4, dY / 3.15)
        Dim Second2 = New Point((dX + 50) / 4, dY / 3.15)

        ipGr.DrawLine(pPen, First1, Second1)
        ipGr.DrawLine(pPen, First2, Second2)

        First1 = Nothing
        Second1 = Nothing
        First2 = Nothing
        Second2 = Nothing
        pPen = Nothing

    End Sub


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo SysErr

        Me.Close()

        Exit Sub
SysErr:
    End Sub


    Private Function AddMarkData() As Boolean

        On Error GoTo SysErr
        Dim tmpCnt As Integer = 0
        Dim nTotalCnt As Integer = 0
        Dim strTemp As String = ""
        Dim tempArrStr1() As String = {}
        Dim tempArrStrMark() As String = {}
        Dim tempArrStrXY() As String = {}
        Dim nIndex As Integer = 0


        nTotalCnt = pLog.arrText.Count
        dgvMarkData.RowCount = (nTotalCnt / 2) + 1

        For i As Integer = 0 To nTotalCnt - 1

            strTemp = pLog.arrText(i)
            tempArrStr1 = Split(strTemp, "]")
            tempArrStrMark = Split(tempArrStr1(1), "::")
            'tempArrStrXY = Split(tempArrStr1(1), ",")
            tempArrStrXY = Split(tempArrStrMark(1), ",")

            If tempArrStrMark(0) = " MARK1" Then

                dgvMarkData.Rows(nIndex).Cells(0).Value = nIndex
                dgvMarkData.Rows(nIndex).Cells(1).Value = tempArrStrXY(0)
                dgvMarkData.Rows(nIndex).Cells(2).Value = tempArrStrXY(1)
                nIndex = nIndex + 1
            ElseIf tempArrStrMark(0) = " MARK2" Or nIndex > 0 Then
                dgvMarkData.Rows(nIndex - 1).Cells(3).Value = tempArrStrXY(0)
                dgvMarkData.Rows(nIndex - 1).Cells(4).Value = tempArrStrXY(1)
            End If
            
        Next

        If nTotalCnt > 0 Then
            dgvMarkData.Refresh()
        End If

        'For i As Integer = 0 To nTotalCnt - 1

        '    strTemp = pLog.arrText(i)
        '    tempArrStr1 = Split(strTemp, "]")
        '    tempArrStrMark = Split(tempArrStr1(1), "::")
        '    'tempArrStrXY = Split(tempArrStr1(1), ",")
        '    tempArrStrXY = Split(tempArrStrMark(1), ",")

        '    If tempArrStrMark(0) = " MARK2" Then
        '        'nIndex = nIndex + 1
        '        'dgvMarkData.Rows(i).Cells(0).Value = i
        '        dgvMarkData.Rows(i).Cells(3).Value = tempArrStrXY(0)
        '        dgvMarkData.Rows(i).Cells(4).Value = tempArrStrXY(1)
        '        'dgvMarkData.Rows(i).Cells(3).Value = i
        '        'dgvMarkData.Rows(i).Cells(4).Value = i
        '    End If

        'Next


        'For k As Integer = 0 To ipOriMarkData.nIndexCnt - 1
        '    For i As Integer = 0 To ipOriMarkData.Data(k).nCmdCnt - 1
        '        dgvMarkData.Rows(tmpCnt).Cells(1).Value = tmpCnt.ToString & "_" & k.ToString
        '        dgvMarkData.Rows(tmpCnt).Cells(2).Value = (k).ToString
        '        dgvMarkData.Rows(tmpCnt).Cells(3).Value = ipOriMarkData.Data(k).strCommand(i)
        '        dgvMarkData.Rows(tmpCnt).Cells(4).Value = ipOriMarkData.Data(k).dPosX(i)
        '        dgvMarkData.Rows(tmpCnt).Cells(5).Value = ipOriMarkData.Data(k).dPosY(i)
        '        dgvMarkData.Rows(tmpCnt).Cells(6).Value = ipOriMarkData.Data(k).dAngle(i)
        '        dgvMarkData.Rows(tmpCnt).Cells(7).Value = 0
        '        dgvMarkData.Rows(tmpCnt).Cells(8).Value = 0
        '        dgvMarkData.Rows(tmpCnt).Cells(9).Value = 0
        '        dgvMarkData.Rows(tmpCnt).Cells(11).Value = ipOriMarkData.Data(k).dPosX(i)
        '        dgvMarkData.Rows(tmpCnt).Cells(12).Value = ipOriMarkData.Data(k).dPosY(i)
        '        dgvMarkData.Rows(tmpCnt).Cells(13).Value = ipOriMarkData.Data(k).dAngle(i)

        '        dgvMarkData.Rows(tmpCnt).Cells(11).Style.BackColor = Color.White
        '        dgvMarkData.Rows(tmpCnt).Cells(12).Style.BackColor = Color.White
        '        dgvMarkData.Rows(tmpCnt).Cells(13).Style.BackColor = Color.White
        '        tmpCnt = tmpCnt + 1
        '    Next
        'Next

        Return True
        Exit Function
SysErr:
        Return False
    End Function



    Dim nLine As Integer = 0
    Private Sub RbtnLineA_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnLineA.CheckedChanged
        nLine = 0
        RbtnLineA.BackColor = Color.LimeGreen
        RbtnLineB.BackColor = Color.White

    End Sub

    Private Sub RbtnLineB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RbtnLineB.CheckedChanged
        nLine = 1
        RbtnLineA.BackColor = Color.White
        RbtnLineB.BackColor = Color.LimeGreen

    End Sub

    

    Private Sub BtnView_Click(sender As System.Object, e As System.EventArgs) Handles BtnView.Click

        AddMarkData()

    End Sub

    Private Sub btnPanel1_Click(sender As System.Object, e As System.EventArgs) Handles btnPanel1.Click

        If nLine = 0 Then
            'pLog.LogRead("AlignData\A1")
            AlignDataLoad(nLine, 0)
        ElseIf nLine = 1 Then
            'pLog.LogRead("AlignData\B1")
            AlignDataLoad(nLine, 0)
        End If
        btnPanel1.BackColor = Color.LimeGreen
        btnPanel2.BackColor = Color.White
        btnPanel3.BackColor = Color.White
        btnPanel4.BackColor = Color.White

    End Sub

    Private Sub btnPanel2_Click(sender As System.Object, e As System.EventArgs) Handles btnPanel2.Click

        If nLine = 0 Then
            'pLog.LogRead("AlignData\A2")
            AlignDataLoad(nLine, 1)
        ElseIf nLine = 1 Then
            'pLog.LogRead("AlignData\B2")
            AlignDataLoad(nLine, 1)
        End If

        btnPanel1.BackColor = Color.White
        btnPanel2.BackColor = Color.LimeGreen
        btnPanel3.BackColor = Color.White
        btnPanel4.BackColor = Color.White
    End Sub

    Private Sub btnPanel3_Click(sender As System.Object, e As System.EventArgs) Handles btnPanel3.Click

        If nLine = 0 Then
            'pLog.LogRead("AlignData\A3")
            AlignDataLoad(nLine, 2)
        ElseIf nLine = 1 Then
            'pLog.LogRead("AlignData\B3")
            AlignDataLoad(nLine, 2)
        End If

        btnPanel1.BackColor = Color.White
        btnPanel2.BackColor = Color.White
        btnPanel3.BackColor = Color.LimeGreen
        btnPanel4.BackColor = Color.White
    End Sub

    Private Sub btnPanel4_Click(sender As System.Object, e As System.EventArgs) Handles btnPanel4.Click

        If nLine = 0 Then
            'pLog.LogRead("AlignData\A4")
            AlignDataLoad(nLine, 3)
        ElseIf nLine = 1 Then
            'pLog.LogRead("AlignData\B4")
            AlignDataLoad(nLine, 3)
        End If

        btnPanel1.BackColor = Color.White
        btnPanel2.BackColor = Color.White
        btnPanel3.BackColor = Color.White
        btnPanel4.BackColor = Color.LimeGreen
    End Sub

    
    Private Sub dgvMarkData_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMarkData.CellClick

        Dim nCurSelIndex As Integer = 0
        Dim dMarkX1, dMarkX2, dMarkY1, dMarkY2 As Double

        nCurSelIndex = e.RowIndex

        If e.ColumnIndex = 5 Then   'Show

            dMarkX1 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(1).Value)
            dMarkY1 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(2).Value)
            dMarkX2 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(3).Value)
            dMarkY2 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(4).Value)

            DrawAlignMark(grBackAlign1, dMarkX1, dMarkY1, True)
            DrawAlignMark(grBackAlign2, dMarkX2, dMarkY2, True)

        End If

        If e.ColumnIndex = 6 Then   'Clear

            dMarkX1 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(1).Value)
            dMarkY1 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(2).Value)
            dMarkX2 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(3).Value)
            dMarkY2 = CDbl(dgvMarkData.Rows(nCurSelIndex).Cells(4).Value)

            DrawAlignMark(grBackAlign1, dMarkX1, dMarkY1, False)
            DrawAlignMark(grBackAlign2, dMarkX2, dMarkY2, False)

        End If

        pbPreview1.Image = bmBackAlign1
        pbPreview1.Update()
        pbPreview2.Image = bmBackAlign2
        pbPreview2.Update()

        

    End Sub

    Private Sub BtnAllClear_Click(sender As System.Object, e As System.EventArgs) Handles BtnAllClear.Click

        grBackAlign1.Clear(Color.White)
        grBackAlign2.Clear(Color.White)

        DrawCrossLine()

        pbPreview1.Image = bmBackAlign1
        pbPreview1.Update()
        pbPreview2.Image = bmBackAlign2
        pbPreview2.Update()

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .lblTitle.Text = My.Resources.setLan.ResourceManager.GetObject("AlignData")
            .btnOK.Text = My.Resources.setLan.ResourceManager.GetObject("Close")
            .RbtnLineA.Text = My.Resources.setLan.ResourceManager.GetObject("LineA")
            .RbtnLineB.Text = My.Resources.setLan.ResourceManager.GetObject("LineB")
            .btnPanel1.Text = My.Resources.setLan.ResourceManager.GetObject("Panel1")
            .btnPanel2.Text = My.Resources.setLan.ResourceManager.GetObject("Panel2")
            .btnPanel3.Text = My.Resources.setLan.ResourceManager.GetObject("Panel3")
            .btnPanel4.Text = My.Resources.setLan.ResourceManager.GetObject("Panel4")
            .BtnView.Text = My.Resources.setLan.ResourceManager.GetObject("View")
            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("Mark1")
            .Label2.Text = My.Resources.setLan.ResourceManager.GetObject("Mark2")
            .BtnAllClear.Text = My.Resources.setLan.ResourceManager.GetObject("AllClear")

        End With

    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe - btnMarkDataPath_A1_Click")
        Dim OpenFile As New OpenFileDialog
        Dim strPath As String = ""
        Dim tmpStr() As String = {}

        OpenFile.InitialDirectory = pCurRecipe.strTmpRecipePath & "\" & pCurRecipe.strRecipeName & "\Mark Data"

        'OpenFile.Filter = "log files (*.log)|*.ini|All files (*.*)|*.*"
        OpenFile.ShowDialog()
        strPath = OpenFile.FileName
        If strPath = "" Then Exit Sub
        'pSetRecipe.strMarkRecipeFile(m_iLine, nMark) = strPath
        tmpStr = Split(strPath, "\")
        bLoadView = True
        pLog.LogRead(tmpStr(3) & "\" & tmpStr(4) & "\" & tmpStr(5))


        OpenFile.Dispose()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnMarkDataPath_A1_Click")

    End Sub

    Private Sub AlignDataLoad(ByRef mLine As Integer, ByRef mPanel As Integer)
        On Error GoTo SysErr
        Dim strPath As String = "AlignData"
        Dim dateMemoryResetToday As String
        dateMemoryResetToday = Format(CDate(Date.Today), "yyyy-MM-dd")
        Select Case mLine
            Case 0
                Select Case mPanel
                    Case 0
                        bLoadView = True
                        pLog.LogRead(strPath & "\A1\" & dateMemoryResetToday & ".log")
                    Case 1
                        bLoadView = True
                        pLog.LogRead(strPath & "\A2\" & dateMemoryResetToday & ".log")
                    Case 2
                        bLoadView = True
                        pLog.LogRead(strPath & "\A3\" & dateMemoryResetToday & ".log")
                    Case 3
                        bLoadView = True
                        pLog.LogRead(strPath & "\A4\" & dateMemoryResetToday & ".log")
                End Select
            Case 1
                Select Case mPanel
                    Case 0
                        bLoadView = True
                        pLog.LogRead(strPath & "\B1\" & dateMemoryResetToday & ".log")
                    Case 1
                        bLoadView = True
                        pLog.LogRead(strPath & "\B2\" & dateMemoryResetToday & ".log")
                    Case 2
                        bLoadView = True
                        pLog.LogRead(strPath & "\B3\" & dateMemoryResetToday & ".log")
                    Case 3
                        bLoadView = True
                        pLog.LogRead(strPath & "\B4\" & dateMemoryResetToday & ".log")
                End Select
        End Select

SysErr:

    End Sub

    Private Sub btnAllView_Click(sender As System.Object, e As System.EventArgs) Handles btnAllView.Click
        On Error GoTo SysErr
        Dim dMarkX1, dMarkX2, dMarkY1, dMarkY2 As Double
        Dim nTotalCnt As Integer = 0


        nTotalCnt = pLog.arrText.Count / 2
        For i As Integer = 0 To nTotalCnt - 1

            dMarkX1 = CDbl(dgvMarkData.Rows(i).Cells(1).Value)
            dMarkY1 = CDbl(dgvMarkData.Rows(i).Cells(2).Value)
            dMarkX2 = CDbl(dgvMarkData.Rows(i).Cells(3).Value)
            dMarkY2 = CDbl(dgvMarkData.Rows(i).Cells(4).Value)

            DrawAlignMark(grBackAlign1, dMarkX1, dMarkY1, True)
            DrawAlignMark(grBackAlign2, dMarkX2, dMarkY2, True)
        Next

        pbPreview1.Image = bmBackAlign1
        pbPreview1.Update()
        pbPreview2.Image = bmBackAlign2
        pbPreview2.Update()

SysErr:

    End Sub
End Class