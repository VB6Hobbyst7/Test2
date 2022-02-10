Public Class ctrlRecipeMarking

    Public m_iLine As Integer

    Private Sub SelectMarkData(ByVal nMark As Integer)
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe - btnMarkDataPath_A1_Click")
        Dim OpenFile As New OpenFileDialog
        Dim strPath As String = ""
        Dim tmpStr() As String = {}

        OpenFile.InitialDirectory = pCurRecipe.strTmpRecipePath & "\" & pCurRecipe.strRecipeName & "\Mark Data"

        OpenFile.Filter = "ini files (*.ini)|*.ini|All files (*.*)|*.*"
        OpenFile.ShowDialog()
        strPath = OpenFile.FileName
        If strPath = "" Then Exit Sub
        pSetRecipe.strMarkRecipeFile(m_iLine, nMark) = strPath
        tmpStr = Split(strPath, "\")

        Dim txtBox As New TextBox
        If nMark = 0 Then
            txtBox = txtMarkData_1
        ElseIf nMark = 1 Then
            txtBox = txtMarkData_2
        ElseIf nMark = 2 Then
            txtBox = txtMarkData_3
        ElseIf nMark = 3 Then
            txtBox = txtMarkData_4
        End If

        txtBox.Text = tmpStr(tmpStr.Length - 1)
        OpenFile.Dispose()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnMarkDataPath_A1_Click")

    End Sub


    Public Sub SelectModelList(ByVal ipModelNumber As Integer)
        On Error GoTo SysErr
        For i As Integer = 0 To 99
            dgvRecipe.Rows(i).Cells(0).Value = i + 1
            dgvRecipe.Rows(i).Cells(1).Value = pCurSystemParam.strModelList(i)
            If i = ipModelNumber - 1 Then
                dgvRecipe.Rows(i).Cells(0).Style.BackColor = Color.Lime
                dgvRecipe.Rows(i).Cells(1).Style.BackColor = Color.Lime
            Else
                dgvRecipe.Rows(i).Cells(0).Style.BackColor = Color.White
                dgvRecipe.Rows(i).Cells(1).Style.BackColor = Color.White
            End If
        Next
        Exit Sub
SysErr:

    End Sub


    Private Sub btnMarkDataPath_1_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataPath_1.Click
        modPub.SystemLog("ctrlRecipeMarking -- btnMarkDataPath 1 Click")
        SelectMarkData(0)
    End Sub

    Private Sub btnMarkDataPath_2_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataPath_2.Click
        modPub.SystemLog("ctrlRecipeMarking -- btnMarkDataPath 2 Click")
        SelectMarkData(1)
    End Sub

    Private Sub btnMarkDataPath_3_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataPath_3.Click
        modPub.SystemLog("ctrlRecipeMarking -- btnMarkDataPath 3 Click")
        SelectMarkData(2)
    End Sub

    Private Sub btnMarkDataPath_4_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataPath_4.Click
        modPub.SystemLog("ctrlRecipeMarking -- btnMarkDataPath 4 Click")
        SelectMarkData(3)
    End Sub

    'Private Sub EditMarkData(ByVal nMarkNo As Integer)
    Public Sub EditMarkData(ByVal nMarkNo As Integer)
        Try
            '20161003 JCM
            frmMarkDataEditer.pStrCurEditMarkData = pCurRecipe.strMarkRecipeFile(m_iLine, nMarkNo)
            frmMarkDataEditer.lblMarkDataName.Text = pCurRecipe.strMarkRecipeFile(m_iLine, nMarkNo)
            frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex = nMarkNo
            modRecipe.LoadMarkingData(pCurRecipe.strMarkRecipeFile(Me.m_iLine, nMarkNo), tmpEditMarkData)
            frmMarkDataEditer.InitData()

            frmRecipe.m_ctrlRcpMarkEditor.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message & "at " & Me.ToString)
        End Try

    End Sub


    Private Sub btnMarkDataEdit_1_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataEdit_1.Click
        frmRecipe.m_iSelectedCmd = 2
        frmRecipe.m_iMarkNum = 0
        frmRecipe.LoadCtrl()
        EditMarkData(0)
    End Sub


    Private Sub btnMarkDataEdit_2_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataEdit_2.Click
        frmRecipe.m_iSelectedCmd = 2
        frmRecipe.m_iMarkNum = 1
        frmRecipe.LoadCtrl()
        EditMarkData(1)

    End Sub

    Private Sub btnMarkDataEdit_3_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataEdit_3.Click
        frmRecipe.m_iSelectedCmd = 2
        frmRecipe.m_iMarkNum = 2
        frmRecipe.LoadCtrl()
        EditMarkData(2)

    End Sub

    Private Sub btnMarkDataEdit_4_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkDataEdit_4.Click
        frmRecipe.m_iSelectedCmd = 2
        frmRecipe.m_iMarkNum = 3
        frmRecipe.LoadCtrl()
        EditMarkData(3)

    End Sub

    Private Sub ctrlRecipeMarking_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        RecipeMarkingLoad()

        'dgvRecipe.RowCount = pCurSystemParam.strModelList.Length
        'For i As Integer = 0 To pCurSystemParam.strModelList.Length - 1
        '    dgvRecipe.Rows(i).Cells(0).Value = i + 1
        '    dgvRecipe.Rows(i).Cells(1).Value = pCurSystemParam.strModelList(i)
        'Next

        'Me.SelectModelList(pCurRecipe.nRecipeNumber)

        'txtMarkData_1.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 0)
        'txtMarkData_2.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 1)
        'txtMarkData_3.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 2)
        'txtMarkData_4.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 3)

        'numScanOffsetX_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetX
        'numScanOffsetY_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetY
        'numScanAngle_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetAngle

        'numScanOffsetX_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetX
        'numScanOffsetY_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetY
        'numScanAngle_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetAngle

        'numScanOffsetX_3.Value = pCurRecipe.RecipeMarkingData(m_iLine, 2).dOffsetX
        'numScanOffsetY_3.Value = pCurRecipe.RecipeMarkingData(m_iLine, 2).dOffsetY
        'numScanAngle_3.Value = pCurRecipe.RecipeMarkingData(m_iLine, 2).dOffsetAngle

        'numScanOffsetX_4.Value = pCurRecipe.RecipeMarkingData(m_iLine, 3).dOffsetX
        'numScanOffsetY_4.Value = pCurRecipe.RecipeMarkingData(m_iLine, 3).dOffsetY
        'numScanAngle_4.Value = pCurRecipe.RecipeMarkingData(m_iLine, 3).dOffsetAngle

    End Sub


    Private Sub btnRecipenameLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecipenameLoad.Click
        RefreshRecipeList(pCurSystemParam.strSystemRootPath & "\Recipe", pCurSystemParam.strModelList)

		'Add
		dgvRecipe.RowCount = pCurSystemParam.strModelList.Length
        For i As Integer = 0 To pCurSystemParam.strModelList.Length - 1
            dgvRecipe.Rows(i).Cells(0).Value = i + 1
            dgvRecipe.Rows(i).Cells(1).Value = pCurSystemParam.strModelList(i)
        Next

        Me.SelectModelList(pCurRecipe.nRecipeNumber)
    End Sub

    Public Function RecipeMarkingLoad() As Boolean

		'Add
        modRecipe.RefreshRecipeList(pSetSystemParam.strSystemRootPath & "\Recipe", pCurSystemParam.strModelList)
        
		dgvRecipe.RowCount = pCurSystemParam.strModelList.Length
        For i As Integer = 0 To pCurSystemParam.strModelList.Length - 1
            dgvRecipe.Rows(i).Cells(0).Value = i + 1
            dgvRecipe.Rows(i).Cells(1).Value = pCurSystemParam.strModelList(i)
        Next

        Me.SelectModelList(pCurRecipe.nRecipeNumber)

        txtMarkData_1.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 0)
        txtMarkData_2.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 1)
        txtMarkData_3.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 2)
        txtMarkData_4.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 3)

        numScanOffsetX_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetX
        numScanOffsetY_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetY
        numScanAngle_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetAngle

        numScanOffsetX_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetX
        numScanOffsetY_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetY
        numScanAngle_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetAngle

        numScanOffsetX_3.Value = pCurRecipe.RecipeMarkingData(m_iLine, 2).dOffsetX
        numScanOffsetY_3.Value = pCurRecipe.RecipeMarkingData(m_iLine, 2).dOffsetY
        numScanAngle_3.Value = pCurRecipe.RecipeMarkingData(m_iLine, 2).dOffsetAngle

        numScanOffsetX_4.Value = pCurRecipe.RecipeMarkingData(m_iLine, 3).dOffsetX
        numScanOffsetY_4.Value = pCurRecipe.RecipeMarkingData(m_iLine, 3).dOffsetY
        numScanAngle_4.Value = pCurRecipe.RecipeMarkingData(m_iLine, 3).dOffsetAngle

        'If pCurRecipe.bMultiCutting = True Then
        '    TabMarking.SelectedTab = TabPage2
        '    TabPage2.Enabled = True
        '    TabPage1.Enabled = False
        'ElseIf pCurRecipe.bMultiCutting = False Then
        '    TabMarking.SelectedTab = TabPage1
        '    TabPage2.Enabled = False
        '    TabPage1.Enabled = True
        'End If
        'dgvRecipe.RowCount = pCurSystemParam.strModelList.Length
        'dgvMultiRecipe.RowCount = pCurSystemParam.strModelList.Length

        'For i As Integer = 0 To pCurSystemParam.strModelList.Length - 1
        '    dgvMultiRecipe.Rows(i).Cells(0).Value = i + 1
        '    dgvMultiRecipe.Rows(i).Cells(1).Value = pCurSystemParam.strModelList(i)
        '    dgvRecipe.Rows(i).Cells(0).Value = i + 1
        '    dgvRecipe.Rows(i).Cells(1).Value = pCurSystemParam.strModelList(i)
        'Next

        'Me.SelectModelList(pCurRecipe.nRecipeNumber)

        'txtMarkData_1.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 0)
        'txtMarkData_2.Text = pCurRecipe.strMarkRecipeFile(m_iLine, 1)

        'numScanOffsetX_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetX
        'numScanOffsetY_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetY
        'numScanAngle_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetAngle

        'numScanOffsetX_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetX
        'numScanOffsetY_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetY
        'numScanAngle_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetAngle

        'numThetaLimit1.Value = pCurRecipe.dThetaLimit_1
        'numThetaLimit2.Value = pCurRecipe.dThetaLimit_2

        'txtMultiMarkData_1_1.Text = pCurRecipe.strMultiFirstMarkRecipeFile(m_iLine, 0)
        'txtMultiMarkData_1_2.Text = pCurRecipe.strMultiSecondMarkRecipeFile(m_iLine, 0)

        'txtMultiMarkData_2_1.Text = pCurRecipe.strMultiFirstMarkRecipeFile(m_iLine, 1)
        'txtMultiMarkData_2_2.Text = pCurRecipe.strMultiSecondMarkRecipeFile(m_iLine, 1)

        'numMultiScanOffsetX_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetX
        'numMultiScanOffsetY_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetY
        'numMultiScanAngle_1.Value = pCurRecipe.RecipeMarkingData(m_iLine, 0).dOffsetAngle

        'numMultiScanOffsetX_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetX
        'numMultiScanOffsetY_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetY
        'numMultiScanAngle_2.Value = pCurRecipe.RecipeMarkingData(m_iLine, 1).dOffsetAngle

        'nummultiThetaLimit1.Value = pCurRecipe.dThetaLimit_1
        'nummultiThetaLimit2.Value = pCurRecipe.dThetaLimit_2

    End Function

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbMarking.Text = My.Resources.setLan.ResourceManager.GetObject("Marking")
            .gbMarkData.Text = My.Resources.setLan.ResourceManager.GetObject("MarkData")

            .lblNormal1.Text = My.Resources.setLan.ResourceManager.GetObject("Data1")
            .lblNormal2.Text = My.Resources.setLan.ResourceManager.GetObject("Data2")
            .lblNormal3.Text = My.Resources.setLan.ResourceManager.GetObject("Data3")
            .lblNormal4.Text = My.Resources.setLan.ResourceManager.GetObject("Data4")
            .btnMarkDataPath_1.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .btnMarkDataPath_2.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .btnMarkDataPath_3.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")
            .btnMarkDataPath_4.Text = My.Resources.setLan.ResourceManager.GetObject("Select1")

            .btnMarkDataEdit_1.Text = My.Resources.setLan.ResourceManager.GetObject("Edit")
            .btnMarkDataEdit_2.Text = My.Resources.setLan.ResourceManager.GetObject("Edit")
            .btnMarkDataEdit_3.Text = My.Resources.setLan.ResourceManager.GetObject("Edit")
            .btnMarkDataEdit_4.Text = My.Resources.setLan.ResourceManager.GetObject("Edit")

            .gbScannerOffset.Text = My.Resources.setLan.ResourceManager.GetObject("ScannerOffsetParameter")

            .gbMarkingOffset_1.Text = My.Resources.setLan.ResourceManager.GetObject("Scanner1")
            .Label2.Text = My.Resources.setLan.ResourceManager.GetObject("Angle")
            .Label36.Text = My.Resources.setLan.ResourceManager.GetObject("Degree")
            .gbMarkingOffset_2.Text = My.Resources.setLan.ResourceManager.GetObject("Scanner2")
            .Label9.Text = My.Resources.setLan.ResourceManager.GetObject("Angle")
            .Label8.Text = My.Resources.setLan.ResourceManager.GetObject("Degree")
            .gbMarkingOffset_3.Text = My.Resources.setLan.ResourceManager.GetObject("Scanner3")
            .Label26.Text = My.Resources.setLan.ResourceManager.GetObject("Angle")
            .Label19.Text = My.Resources.setLan.ResourceManager.GetObject("Degree")
            .gbMarkingOffset_4.Text = My.Resources.setLan.ResourceManager.GetObject("Scanner4")
            .Label64.Text = My.Resources.setLan.ResourceManager.GetObject("Angle")
            .Label54.Text = My.Resources.setLan.ResourceManager.GetObject("Degree")

            .gbLaserParam.Text = My.Resources.setLan.ResourceManager.GetObject("LaserParameter")

            .Label88.Text = My.Resources.setLan.ResourceManager.GetObject("Attenuation")
            .Label80.Text = My.Resources.setLan.ResourceManager.GetObject("Attenuation")
            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("Attenuation")
            .Label6.Text = My.Resources.setLan.ResourceManager.GetObject("Attenuation")

            .Label89.Text = My.Resources.setLan.ResourceManager.GetObject("Frequencykhz")
            .Label81.Text = My.Resources.setLan.ResourceManager.GetObject("Frequencykhz")
            .Label5.Text = My.Resources.setLan.ResourceManager.GetObject("Frequencykhz")
            .Label7.Text = My.Resources.setLan.ResourceManager.GetObject("Frequencykhz")

            .btnRecipenameLoad.Text = My.Resources.setLan.ResourceManager.GetObject("RecipeNameLoad")
           
        End With

    End Sub

End Class
