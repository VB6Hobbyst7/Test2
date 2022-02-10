Imports System.IO
Imports System.Threading

Public Class ctrlSettingCalib

#Region "Calibration"

    Structure CalDataPos
        Dim PosX As Double
        Dim PosY As Double
        Dim DrawPosX As Integer
        Dim DrawPosY As Integer
        Dim RealPosX As Double
        Dim RealPosY As Double
        Dim ScanPosX As Integer
        Dim ScanPosY As Integer
        Dim bGetCalPos As Boolean
    End Structure

    Dim CalBitmap As Bitmap
    Dim ImgCal As Image
    Dim grpCal As Graphics
    Dim CalData() As CalDataPos
    Dim nCurIndex As Integer = 0
    Dim m_iSelectedScanner As Integer = 0
    Dim m_iSelectedLaser As Integer = 0
    Dim m_iSelectedLine As Integer = 0

    Private Sub ctrlSettingCalib_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
 
        If bLogInUser = True Or bLogInTech = True Then
            gbCalibration.Enabled = False

        ElseIf bLogInAdmin = True Then

            gbCalibration.Enabled = True
        End If



    End Sub

    Private Sub BtnSelScanner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelScanner.Click
        On Error GoTo SysErr

        modPub.SystemLog("frmSetting - chkScanner_CheckedChanged")

        m_iSelectedScanner = m_iSelectedScanner + 1

        If m_iSelectedScanner > 3 Then
            m_iSelectedScanner = 0
        End If

        BtnSelScanner.Text = "Scanner#" + (m_iSelectedScanner + 1).ToString()


        Exit Sub
SysErr:

    End Sub


    Private Sub chkLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLine.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - chkScanner_CheckedChanged")
        If chkLine.Checked = True Then
            chkLine.Text = "Line B"
            m_iSelectedLine = LINE.B
        ElseIf chkLine.Checked = False Then
            chkLine.Text = "Line A"
            m_iSelectedLine = LINE.A
        End If
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- chkScanner_CheckedChanged")
    End Sub

    Private Sub btnOldCTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOldCTB.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnOldCTB_Click")
        Dim OpenFile As New OpenFileDialog
        Dim strPath As String = ""
        Dim tmpStr() As String = {}

        OpenFile.InitialDirectory = "C:\Chamfering System\Setting\Calibration"
        OpenFile.Filter = "ctb files (*.ctb)|*.ctb|All files (*.*)|*.*"
        OpenFile.ShowDialog()
        strPath = OpenFile.FileName
        If strPath = "" Then Exit Sub

        'pScanner(m_iSelectedScanner).SetCorrectionFilePath(strPath)
        'pScanner(m_iSelectedScanner).RTC6Init()

        tmpStr = Split(strPath, "\")
        txtCalCTB.Text = tmpStr(tmpStr.Length - 1)
        OpenFile.Dispose()
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnOldCTB_Click")

    End Sub

    Private Sub btnSetCalMarkSpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCalMarkSpd.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnSetCalMarkSpd_Click")

        pScanner(m_iSelectedScanner).SetMarkSpeed(numCalMarkSpd.Value)
        pScanner(m_iSelectedScanner).RTC6ParamApply()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSetCalMarkSpd_Click")

    End Sub


    Private Sub btnMatrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatrixPlus.Click, btnMatrixMinus.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnMatrix_Click")
        Select Case sender.tag
            Case "-"
                If numCalValue.Value - 2 < 5 Then
                    numCalValue.Value = 5
                Else
                    numCalValue.Value = numCalValue.Value - 2
                End If

            Case "+"
                If numCalValue.Value + 2 > 19 Then
                    numCalValue.Value = 19
                Else
                    numCalValue.Value = numCalValue.Value + 2
                End If
        End Select

        ReDim CalData((numCalValue.Value * numCalValue.Value) - 1)

        DrawCalSqt(picCalPosition, CalBitmap, ImgCal, grpCal, 5, CalData, True)
        GridCalPosSet(CalDataGrid, numCalValue.Value, 1000, numCalMarkSize.Value, CalData)

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnMatrix_Click")
    End Sub

    Private Sub picCalPosition_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        On Error GoTo SysErr
        Dim tmpCheck As Double = 0
        If e.Button = Windows.Forms.MouseButtons.Left Then
            tmpCheck = Math.Abs(CalData(0).DrawPosX - CalData(1).DrawPosX) / 2
            DrawCalSqt(picCalPosition, CalBitmap, ImgCal, grpCal, 5, CalData, False)

            For i As Integer = 0 To CalData.Length - 1
                If Math.Abs(CalData(i).DrawPosX - e.X) < tmpCheck And Math.Abs(CalData(i).DrawPosY - e.Y) < tmpCheck Then
                    mItemRealPosX.Text = "X : " & CalData(i).RealPosX.ToString
                    mItemRealPosY.Text = "Y : " & CalData(i).RealPosY.ToString
                    ctxtMenu.Show(CInt(CalData(i).DrawPosX) + picCalPosition.Location.X + Me.Location.X + 20, CInt(CalData(i).DrawPosY) + picCalPosition.Location.Y * 2 + Me.Location.Y)
                    grpCal.DrawArc(Pens.Blue, CInt(CalData(i).DrawPosX) - 5, CInt(CalData(i).DrawPosY) - 5, 10, 10, 0, 360)
                    picCalPosition.Image = ImgCal
                    nCurIndex = i
                    Exit For
                End If
            Next
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- picCalPosition_MouseUp")
    End Sub

    Private Sub mItemGetPos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mItemGetPos.Click
        On Error GoTo SysErr
        If chkLine.Checked = False Then
            CalData(nCurIndex).RealPosX = pLDLT.PLC_Infomation.dCurPosX(LINE.A)
            CalData(nCurIndex).RealPosY = pLDLT.PLC_Infomation.dCurPosY(LINE.A)
            'Line A 의 현재 위치 저장
        ElseIf chkLine.Checked = True Then
            CalData(nCurIndex).RealPosX = pLDLT.PLC_Infomation.dCurPosX(LINE.B)
            CalData(nCurIndex).RealPosY = pLDLT.PLC_Infomation.dCurPosY(LINE.B) * -1
            'Line B의 현재 위치 저장
        End If

        grpCal.DrawArc(Pens.Lime, CInt(CalData(nCurIndex).DrawPosX) - 5, CInt(CalData(nCurIndex).DrawPosY) - 5, 10, 10, 0, 360)
        picCalPosition.Image = ImgCal
        CalData(nCurIndex).bGetCalPos = True
        CalDataGridSet(CalData, numCalValue.Value, CalDataGrid)
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- mItemGetPos_Click")
    End Sub

    Private Sub btnCalMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalMark.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnCalMark_Click")

        pScanner(m_iSelectedScanner).RTC6_CAL(numCalMarkSize.Value, numCalMarkGab.Value, numCalValue.Value, 1)
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnCalMark_Click")
    End Sub

    Private Sub btnSaveCalData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCalData.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnSaveCalData_Click")
        Dim SaveFile As New SaveFileDialog
        Dim strNewCTB() As String = {}
        SaveFile.InitialDirectory = "C:\Chamfering System\Setting\Calibration"
        SaveFile.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
        SaveFile.ShowDialog()

        If SaveFile.FileName = "" Then Exit Sub

        If System.IO.File.Exists("C:\Chamfering System\Setting\Calibration\" & txtCalCTB.Text) = False Then Exit Sub

        txtCalDataPath.Text = SaveFile.FileName

        strNewCTB = Split(txtCalDataPath.Text, ".")

        SaveDataFile(SaveFile.FileName, numCalMarkSize.Value, numCalValue.Value, txtCalCTB.Text, strNewCTB(0) & ".ctb", CalData)


        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSaveCalData_Click")
    End Sub

    Private Sub GridCalPosSet(ByRef ipGrid As DataGridView, ByVal ipCount As Integer, ByVal ipBitPerMM As Integer, ByVal ipMarkingBitSize As Integer, ByRef ipData() As CalDataPos)
        On Error GoTo SysErr
        Dim nCnt As Integer = ipCount
        Dim nStartPosX As Integer = 0
        Dim nStartPosY As Integer = 0
        Dim dRealStartPosX As Double = 0
        Dim dRealStartPosY As Double = 0

        Dim tmpPosX As Double = 0
        Dim tmpPosY As Double = 0

        Dim nCnt_X As Integer = 0
        Dim nCnt_Y As Integer = 0

        Dim tmpInterval As Integer = 0
        Dim tmpRealInterval As Double = 0
        Dim nDirXY As Integer = 1

        ipGrid.Rows.Clear()
        ipGrid.Columns.Clear()

        ipGrid.RowCount = nCnt * 2
        ipGrid.ColumnCount = nCnt + 1

        ipGrid.Rows(1).Cells(0).ReadOnly = True

        For i As Integer = 1 To nCnt
            ipGrid.Columns(i).HeaderText = i.ToString
        Next

        nCnt = 1

        For i As Integer = 0 To CalDataGrid.RowCount - 1 Step 2
            ipGrid.Rows(i).Cells(0).Value = (nCnt).ToString & "_X"
            ipGrid.Rows(i + 1).Cells(0).Value = (nCnt).ToString & "_Y"
            nCnt = nCnt + 1
        Next

        tmpInterval = (ipMarkingBitSize / (ipCount - 1))
        tmpRealInterval = tmpInterval * ipBitPerMM / 1000
        nStartPosX = -tmpInterval * (ipCount - 1) / 2
        nStartPosY = tmpInterval * (ipCount - 1) / 2
        dRealStartPosX = nStartPosX * ipBitPerMM / 1000
        dRealStartPosY = nStartPosY * ipBitPerMM / 1000

        nCnt = 0
        For i As Integer = 0 To ipCount - 1
            For j As Integer = 0 To ipCount - 1
                ipData(nCnt).RealPosX = dRealStartPosX + tmpRealInterval * j
                ipData(nCnt).RealPosY = dRealStartPosY - tmpRealInterval * i
                ipData(nCnt).ScanPosX = nStartPosX + tmpInterval * j
                ipData(nCnt).ScanPosY = nStartPosY - tmpInterval * i
                nCnt = nCnt + 1
            Next
        Next

        CalDataGridSet(ipData, ipCount, ipGrid)

        Exit Sub
SysErr:
        Dim str As String = Err.Description
    End Sub

    Private Sub DrawCalSqt(ByRef ipPictrueBox As PictureBox, ByRef ipBitmap As Bitmap, ByRef ipImage As Image, ByRef ipGraphic As Graphics, ByVal ipGab As Integer, _
                       ByRef ipData() As CalDataPos, ByVal ClearDisp As Boolean)
        On Error GoTo SysErr
        Dim nCnt As Integer = 0
        Dim tmpArr() As Integer = {}
        Dim tmpValue As Double = 0

        ipBitmap = New Bitmap(ipPictrueBox.Width, ipPictrueBox.Height)
        ipImage = ipBitmap
        ipGraphic = Graphics.FromImage(ipImage)

        If numCalValue.Value < 5 Then
            nCnt = 5 - 1
        Else
            nCnt = numCalValue.Value - 1
        End If

        tmpValue = (ipPictrueBox.Width - (ipGab * 4)) / nCnt


        ReDim tmpArr(nCnt)

        For i As Integer = 0 To tmpArr.Length - 1
            tmpArr(i) = i * tmpValue + (ipGab * 2)
        Next


        For i As Integer = 0 To tmpArr.Length - 1
            ipGraphic.DrawLine(Pens.Silver, tmpArr(i), ipGab, tmpArr(i), ipPictrueBox.Width - 5)
            ipGraphic.DrawLine(Pens.Silver, ipGab, tmpArr(i), ipPictrueBox.Height - 5, tmpArr(i))
        Next

        ipGraphic.DrawLine(Pens.Red, CInt(ipPictrueBox.Width / 2) - ipGab, CInt(ipPictrueBox.Height / 2), CInt(ipPictrueBox.Width / 2) + ipGab, CInt(ipPictrueBox.Height / 2))
        ipGraphic.DrawLine(Pens.Red, CInt(ipPictrueBox.Width / 2), CInt(ipPictrueBox.Height / 2) - ipGab, CInt(ipPictrueBox.Width / 2), CInt(ipPictrueBox.Height / 2) + ipGab)

        ipPictrueBox.Image = ipImage

        nCnt = 0

        For i As Integer = 0 To tmpArr.Length - 1
            For j As Integer = 0 To tmpArr.Length - 1
                ipData(nCnt).PosX = i + 1
                ipData(nCnt).PosY = j + 1
                ipData(nCnt).DrawPosX = tmpArr(j)
                ipData(nCnt).DrawPosY = tmpArr(i)
                If ClearDisp = False Then
                    If ipData(nCnt).bGetCalPos = True Then
                        ipGraphic.DrawArc(Pens.Lime, CInt(ipData(nCnt).DrawPosX) - 5, CInt(ipData(nCnt).DrawPosY) - 5, 10, 10, 0, 360)
                    End If
                End If
                nCnt = nCnt + 1
            Next
        Next

        Exit Sub
SysErr:
        Dim str As String = Err.Description
    End Sub

    Private Function CalDataGridSet(ByVal ipData() As CalDataPos, ByVal ipCount As Integer, ByRef ipDataGrid As DataGridView)
        On Error GoTo SysErr
        Dim nDirXY As Integer = 1
        Dim nCnt_X As Integer = 0
        Dim nCnt_Y As Integer = 0

        For i As Integer = 0 To ipCount + ipCount - 1
            For j As Integer = 0 To ipCount - 1
                If nDirXY = 1 Then
                    ipDataGrid.Rows(i).Cells(j + 1).Value = ipData(nCnt_X).RealPosX
                    nCnt_X = nCnt_X + 1
                ElseIf nDirXY = -1 Then
                    ipDataGrid.Rows(i).Cells(j + 1).Value = ipData(nCnt_Y).RealPosY
                    nCnt_Y = nCnt_Y + 1
                End If
            Next
            nDirXY = nDirXY * -1
        Next
        Return True
SysErr:
        Return False
    End Function

    Private Function SaveDataFile(ByVal Filename As String, ByVal BitSize As Integer, ByVal ipCount As Integer, ByVal ipOldCTB As String, ByVal ipNewCTB As String, ByVal ipData() As CalDataPos)
        Dim SaveFile As New StreamWriter(Filename, False)
        Dim nInterval As Integer = 0
        Dim tmpString As String = ""
        Dim nTmp As Integer = 0
        Dim nCnt_Array As Integer = 0

        SaveFile.Write("Limits" + vbCrLf)

        SaveFile.Write("FitOrder = 4" + vbCrLf)
        SaveFile.Write("NewCal = " + CStr(1000) + vbCrLf)
        SaveFile.Write(vbCrLf)
        SaveFile.Write("OldCTBFile = " + ipOldCTB + vbCrLf)
        SaveFile.Write("NewCTBFile = " & ipNewCTB + vbCrLf)
        SaveFile.Write(vbCrLf)
        SaveFile.Write("//RTC-X [Bit] RTC-Y [Bit] REAL-X [mm] REAL-Y [mm] " + vbCrLf)
        SaveFile.Write(vbCrLf)

        Dim StartPosXbit As Integer = -BitSize / 2
        Dim StartPosYbit As Integer = BitSize / 2
        nInterval = BitSize / (ipCount - 1)

        Dim TmpPosX As Double = 0
        Dim TmpPosY As Double = 0
        Dim TmpBitX As Double = 0
        Dim TmpBitY As Double = 0
        Dim TmpCenterPosX As Double = ipData((ipData.Length - 1) / 2).RealPosX
        Dim TmpCenterPosY As Double = ipData((ipData.Length - 1) / 2).RealPosY

        For i As Integer = 0 To ipCount - 1
            For j As Integer = 0 To ipCount - 1
                TmpPosX = ipData(nCnt_Array).RealPosX
                TmpPosY = ipData(nCnt_Array).RealPosY
                TmpBitX = StartPosXbit + (nInterval * j)
                TmpBitY = StartPosYbit - (nInterval * i)

                tmpString = TmpBitX.ToString & " " & TmpBitY.ToString & " " & (TmpPosX - TmpCenterPosX).ToString & " " & (TmpPosY - TmpCenterPosY).ToString & vbCrLf
                nCnt_Array = nCnt_Array + 1
                SaveFile.Write(tmpString)
            Next
            SaveFile.Write(vbCrLf)
        Next
        SaveFile.Close()
        Return True

    End Function

#End Region
    '20161003 JCM EDIT
    Private Sub picCalPosition_MouseUp1(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles picCalPosition.MouseUp
        On Error GoTo SysErr
        Dim tmpCheck As Double = 0
        If e.Button = Windows.Forms.MouseButtons.Left Then
            tmpCheck = Math.Abs(CalData(0).DrawPosX - CalData(1).DrawPosX) / 2
            DrawCalSqt(picCalPosition, CalBitmap, ImgCal, grpCal, 5, CalData, False)

            For i As Integer = 0 To CalData.Length - 1
                If Math.Abs(CalData(i).DrawPosX - e.X) < tmpCheck And Math.Abs(CalData(i).DrawPosY - e.Y) < tmpCheck Then
                    mItemRealPosX.Text = "X : " & CalData(i).RealPosX.ToString
                    mItemRealPosY.Text = "Y : " & CalData(i).RealPosY.ToString
                    'ctxtMenu.Show(CInt(CalData(i).DrawPosX) + picCalPosition.Location.X + Me.Location.X + 20, CInt(CalData(i).DrawPosY) + picCalPosition.Location.Y * 2 + Me.Location.Y)
                    ctxtMenu.Show(CInt(CalData(i).DrawPosX) + picCalPosition.Location.X + Me.Location.X + 1220, CInt(CalData(i).DrawPosY) + picCalPosition.Location.Y * 2 + Me.Location.Y)
                    grpCal.DrawArc(Pens.Blue, CInt(CalData(i).DrawPosX) - 5, CInt(CalData(i).DrawPosY) - 5, 10, 10, 0, 360)
                    picCalPosition.Image = ImgCal
                    nCurIndex = i
                    Exit For
                End If
            Next
        End If

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- picCalPosition_MouseUp")
    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbCalibration.Text = My.Resources.setLan.ResourceManager.GetObject("Calibration")
            .gbSelectScanner.Text = My.Resources.setLan.ResourceManager.GetObject("SelectScanner")
            .BtnSelScanner.Text = My.Resources.setLan.ResourceManager.GetObject("Scanner1")
            .chkLine.Text = My.Resources.setLan.ResourceManager.GetObject("LINEA")
            .gbCTB.Text = My.Resources.setLan.ResourceManager.GetObject("CTBFileLoad")
            .btnOldCTB.Text = My.Resources.setLan.ResourceManager.GetObject("Load")
            .gbCalMarkSPD.Text = My.Resources.setLan.ResourceManager.GetObject("MarkSpeedSetbit")
            .btnSetCalMarkSpd.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .gbMatrix.Text = My.Resources.setLan.ResourceManager.GetObject("MatrixSet")
            .gbClaMarkInfo.Text = My.Resources.setLan.ResourceManager.GetObject("CalibrationMarkingInfo")
            .lblSize.Text = My.Resources.setLan.ResourceManager.GetObject("Size")
            .lblGab.Text = My.Resources.setLan.ResourceManager.GetObject("Gap")
            .lbl100.Text = My.Resources.setLan.ResourceManager.GetObject("bit")
            .lbl101.Text = My.Resources.setLan.ResourceManager.GetObject("bit")
            .gbCalMark.Text = My.Resources.setLan.ResourceManager.GetObject("CalibrationMarking")
            .btnCalMark.Text = My.Resources.setLan.ResourceManager.GetObject("MarkingStart")
            .gbCalData.Text = My.Resources.setLan.ResourceManager.GetObject("DataFileSave")
            .btnSaveCalData.Text = My.Resources.setLan.ResourceManager.GetObject("Save")
            .gbCalPosition.Text = My.Resources.setLan.ResourceManager.GetObject("PositionData")

        End With

    End Sub


End Class
