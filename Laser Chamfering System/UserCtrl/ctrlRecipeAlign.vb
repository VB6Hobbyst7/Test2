Public Class ctrlRecipeAlign
    Public m_ctrlMarks(3) As ctrlRecipeAlignMark
    Public m_iLine As Integer
    'GYN - 2017.03.26           'Line 정보
    Private m_iPanel As Integer             'Panel 정보
    Private m_iAlignMarkNo As Integer       'Align Mark1 or Align Mark2
    Private m_iAlignMarkUseNo As Integer
    Public Sub New(ByVal nLine As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.
        m_iLine = nLine
        For p = 0 To 3

            m_ctrlMarks(p) = New ctrlRecipeAlignMark(m_iLine, p)
            tabPanel.TabPages(p).Controls.Add(m_ctrlMarks(p))

            m_ctrlMarks(p).Visible = True
        Next

    End Sub

    Private Sub ctrlRecipeAlign_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If bLogInUser = True Or bLogInTech = True Then
            gbAlignLightSet.Enabled = False
            gbAlignDistace.Enabled = False
        ElseIf bLogInAdmin = True Then
            gbAlignLightSet.Enabled = True
            gbAlignDistace.Enabled = True
        End If
        Dim nCamIndex As Integer

        If tabPanel.SelectedIndex = 0 Or tabPanel.SelectedIndex = 2 Then
            nCamIndex = 0
        Else
            nCamIndex = 1
        End If

        'Data 뿌리기.
        'numAlignLight_1.Value = pCurRecipe.nAlignLight(m_iLine, 0)
        'numAlignLight_2.Value = pCurRecipe.nAlignLight(m_iLine, 1)
        'numAlignLight_3.Value = pCurRecipe.nAlignLight(m_iLine, 2)
        'numAlignLight_4.Value = pCurRecipe.nAlignLight(m_iLine, 3)

        'numAlignLight_5.Value = pCurRecipe.nAlignLight2(m_iLine, 0)
        'numAlignLight_6.Value = pCurRecipe.nAlignLight2(m_iLine, 1)
        'numAlignLight_7.Value = pCurRecipe.nAlignLight2(m_iLine, 2)
        'numAlignLight_8.Value = pCurRecipe.nAlignLight2(m_iLine, 3)

        numAlignRetry.Value = pCurRecipe.nAlignRetry
        numAlignDistance.Value = pCurRecipe.dAlignDistance
        numAlignErrorRange.Value = pCurRecipe.dAlignErrorRange
        numAlignCenterX.Value = pCurRecipe.dCenterX
        numAlignCenterY.Value = pCurRecipe.dCenterY
        'SetManualVisionMode 초기화
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(0)
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(0)

        'frmRecipe.m_CurAlignMarkSetting(0).UpdateData(False)
        'frmRecipe.m_CurAlignMarkSetting(1).UpdateData(False)

        frmVision.SelectVision(m_iLine, nCamIndex)

        'UpdateTabPage(0)

    End Sub



#Region "Align"
    '    Private Sub btnAlignRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignRetry.Click
    '        On Error GoTo SysErr
    '        modPub.SystemLog("frmRecipe -- btnAlignRetry_Click")
    '        pSetRecipe.nAlignRetry = numAlignRetry.Value
    '        Exit Sub
    'SysErr:
    '        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnAlignRetry_Click")
    '    End Sub



    '    Private Sub btnAlignLightSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignLightSet.Click
    '        On Error GoTo SysErr
    '        modPub.SystemLog("frmRecipe -- btnAlignLightSet_Click")

    '        pSetRecipe.nAlignLight(m_iLine, 0) = numAlignLight_1.Value
    '        pSetRecipe.nAlignLight(m_iLine, 1) = numAlignLight_2.Value
    '        pSetRecipe.nAlignLight(m_iLine, 2) = numAlignLight_3.Value
    '        pSetRecipe.nAlignLight(m_iLine, 3) = numAlignLight_4.Value

    '        Exit Sub
    'SysErr:
    '        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnAlignLightSet_Click")
    '    End Sub

    '    Private Sub btnAlignDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignDistance.Click
    '        On Error GoTo SysErr

    '        modPub.SystemLog("frmRecipe -- btnAlignDistance_Click")

    '        pSetRecipe.AlignDistance = numAlignDistance.Value
    '        pSetRecipe.AlignErrorRange = numAlignErrorRange.Value
    '        Exit Sub
    'SysErr:
    '        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnAlignDistance_Click")
    '    End Sub
#End Region


    Private Sub tabPanel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tabPanel.SelectedIndexChanged

        UpdateTabPage(tabPanel.SelectedIndex)

    End Sub



    'Private Sub UpdateTabPage(ByVal SelectedIndex As Integer)
    Public Sub UpdateTabPage(ByVal SelectedIndex As Integer)

        Dim nCamIndex As Integer
        If SelectedIndex = 0 Or SelectedIndex = 2 Then
            nCamIndex = 0
        Else
            nCamIndex = 1
        End If

        'SetManualVisionMode 초기화
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(0)
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(0)

        'frmRecipe.m_CurAlignMarkSetting(0).UpdateData(False)
        'frmRecipe.m_CurAlignMarkSetting(1).UpdateData(False)

        frmVision.SelectVision(m_iLine, nCamIndex)

        numAlignRetry.Value = pCurRecipe.nAlignRetry
        numAlignDistance.Value = pCurRecipe.dAlignDistance
        numAlignErrorRange.Value = pCurRecipe.dAlignErrorRange
        frmRecipe.m_ctrlRcpAlign(m_iLine).m_ctrlMarks(m_iPanel).AlignMarkLoad()

    End Sub

    '    Private Sub btnAlignVisionParam_Click(sender As System.Object, e As System.EventArgs) Handles btnAlignVisionParam.Click
    '        On Error GoTo SysErr

    '        modPub.SystemLog("frmRecipe - btnAlignVisionParam_Click")
    '        frmVisionLightParam.Show()

    '        Exit Sub
    'SysErr:
    '        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnAlignLightSet_Click")
    '    End Sub

    Private Sub btnAlignRetry_Click(sender As System.Object, e As System.EventArgs) Handles btnAlignRetry.Click

        modPub.SystemLog("ctrlRecipeAlign -- btnAlignRetry Click")

        pSetRecipe.nAlignRetry = numAlignRetry.Value

        pCurRecipe = pSetRecipe

        For i = 0 To 1
            modSequence.Seq(i).nRetryCnt = pSetRecipe.nAlignRetry
        Next

        modRecipe.SaveRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe)

    End Sub

    Private Sub btnAlignDistance_Click(sender As System.Object, e As System.EventArgs) Handles btnAlignDistance.Click

        modPub.SystemLog("ctrlRecipeAlign -- btnAlignDistance Click")

        pSetRecipe.dAlignDistance = numAlignDistance.Value
        pSetRecipe.dAlignErrorRange = numAlignErrorRange.Value

        pCurRecipe = pSetRecipe

        modRecipe.SaveRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe)

    End Sub

    Private Sub btnAlignVisionParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignVisionParam.Click
        frmVisionLightParam.Show()
    End Sub


    Private Sub btnAlignCenterX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignCenterX.Click

        modPub.SystemLog("ctrlRecipeAlign -- btnAlignCenterX Click")

        pSetRecipe.dCenterX = numAlignCenterX.Value

        pCurRecipe = pSetRecipe

        modRecipe.SaveRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe)
    End Sub

    Private Sub btnAlignCenterY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignCenterY.Click

        modPub.SystemLog("ctrlRecipeAlign -- btnAlignCenterY Click")

        pSetRecipe.dCenterY = numAlignCenterY.Value

        pCurRecipe = pSetRecipe

        modRecipe.SaveRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe)
    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbAlign.Text = My.Resources.setLan.ResourceManager.GetObject("Align")
            .gbAlignLightSet.Text = My.Resources.setLan.ResourceManager.GetObject("Lightbrightnesssetting")
            .btnAlignVisionParam.Text = My.Resources.setLan.ResourceManager.GetObject("Lightbrightnesssetting")
            .gbAlignDistace.Text = My.Resources.setLan.ResourceManager.GetObject("alignsettingunitmm")
            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("tryagain")
            .Label35.Text = My.Resources.setLan.ResourceManager.GetObject("Markdistance")
            .Label34.Text = My.Resources.setLan.ResourceManager.GetObject("Markdistancemistake")
            .btnAlignRetry.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .btnAlignDistance.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .Label4.Text = My.Resources.setLan.ResourceManager.GetObject("Panelsettingposset")
            .btnAlignCenterX.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")
            .btnAlignCenterY.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")

            .tabPagePanel1.Text = My.Resources.setLan.ResourceManager.GetObject("Panel1")
            .tabPagePanel2.Text = My.Resources.setLan.ResourceManager.GetObject("Panel2")
            .tabPagePanel3.Text = My.Resources.setLan.ResourceManager.GetObject("Panel3")
            .tabPagePanel4.Text = My.Resources.setLan.ResourceManager.GetObject("Panel4")
           
        End With

        For i As Integer = 0 To 3

            m_ctrlMarks(i).LanChange(StrCulture)

        Next

    End Sub

    Private Sub btnMatch_Click(sender As System.Object, e As System.EventArgs) Handles btnMatch.Click
        AlignMatchLoad(0)
        frmSubMark.Show()
    End Sub


End Class
