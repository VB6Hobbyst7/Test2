Public Class frmVisionLightParam

    Public m_iLine As Integer

    Private Sub btnAlignLightSet_Click(sender As System.Object, e As System.EventArgs) Handles btnAlignLightSet.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe - btnAlignLightSet_Click")

        pSetRecipe.nAlignLight(m_iLine, 0) = numAlignLight_1.Value
        pSetRecipe.nAlignLight(m_iLine, 1) = numAlignLight_2.Value
        pSetRecipe.nAlignLight(m_iLine, 2) = numAlignLight_3.Value
        pSetRecipe.nAlignLight(m_iLine, 3) = numAlignLight_4.Value

        pSetRecipe.nAlignLight2(m_iLine, 0) = numAlignLight_5.Value
        pSetRecipe.nAlignLight2(m_iLine, 1) = numAlignLight_6.Value
        pSetRecipe.nAlignLight2(m_iLine, 2) = numAlignLight_7.Value
        pSetRecipe.nAlignLight2(m_iLine, 3) = numAlignLight_8.Value
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnAlignLightSet_Click")
    End Sub

    Private Sub btnAlignLight_mark2_Set_Click(sender As System.Object, e As System.EventArgs) Handles btnAlignLight_mark2_Set.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe - btnAlignLight_mark2_Set_Click")

        pSetRecipe.nAlignLight_mark2(m_iLine, 0) = numAlignLight_Mark2_1.Value
        pSetRecipe.nAlignLight_mark2(m_iLine, 1) = numAlignLight_Mark2_2.Value
        pSetRecipe.nAlignLight_mark2(m_iLine, 2) = numAlignLight_Mark2_3.Value
        pSetRecipe.nAlignLight_mark2(m_iLine, 3) = numAlignLight_Mark2_4.Value

        pSetRecipe.nAlignLight2_mark2(m_iLine, 0) = numAlignLight_Mark2_5.Value
        pSetRecipe.nAlignLight2_mark2(m_iLine, 1) = numAlignLight_Mark2_6.Value
        pSetRecipe.nAlignLight2_mark2(m_iLine, 2) = numAlignLight_Mark2_7.Value
        pSetRecipe.nAlignLight2_mark2(m_iLine, 3) = numAlignLight_Mark2_8.Value
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnAlignLight_mark2_Set_Click")
    End Sub

    Private Sub btnVisionLightParamSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionLightParamSave.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmRecipe - btnVisionLightParamSave_Click")
        pCurRecipe = pSetRecipe
        modRecipe.SaveRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe)
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnVisionLightParamSave_Click")
    End Sub

    Public Sub frmVisionLightParam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        numAlignLight_1.Value = pCurRecipe.nAlignLight(m_iLine, 0)
        numAlignLight_2.Value = pCurRecipe.nAlignLight(m_iLine, 1)
        numAlignLight_3.Value = pCurRecipe.nAlignLight(m_iLine, 2)
        numAlignLight_4.Value = pCurRecipe.nAlignLight(m_iLine, 3)

        numAlignLight_5.Value = pCurRecipe.nAlignLight2(m_iLine, 0)
        numAlignLight_6.Value = pCurRecipe.nAlignLight2(m_iLine, 1)
        numAlignLight_7.Value = pCurRecipe.nAlignLight2(m_iLine, 2)
        numAlignLight_8.Value = pCurRecipe.nAlignLight2(m_iLine, 3)

        numAlignLight_Mark2_1.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 0)
        numAlignLight_Mark2_2.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 1)
        numAlignLight_Mark2_3.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 2)
        numAlignLight_Mark2_4.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 3)

        numAlignLight_Mark2_5.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 0)
        numAlignLight_Mark2_6.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 1)
        numAlignLight_Mark2_7.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 2)
        numAlignLight_Mark2_8.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 3)

    End Sub

   Private Sub btnAline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAline.Click
        m_iLine = 0
        btnAline.BackColor = Color.Lime
        btnBline.BackColor = Color.White
        numAlignLight_1.Value = pCurRecipe.nAlignLight(m_iLine, 0)
        numAlignLight_2.Value = pCurRecipe.nAlignLight(m_iLine, 1)
        numAlignLight_3.Value = pCurRecipe.nAlignLight(m_iLine, 2)
        numAlignLight_4.Value = pCurRecipe.nAlignLight(m_iLine, 3)

        numAlignLight_5.Value = pCurRecipe.nAlignLight2(m_iLine, 0)
        numAlignLight_6.Value = pCurRecipe.nAlignLight2(m_iLine, 1)
        numAlignLight_7.Value = pCurRecipe.nAlignLight2(m_iLine, 2)
        numAlignLight_8.Value = pCurRecipe.nAlignLight2(m_iLine, 3)

        numAlignLight_Mark2_1.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 0)
        numAlignLight_Mark2_2.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 1)
        numAlignLight_Mark2_3.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 2)
        numAlignLight_Mark2_4.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 3)

        numAlignLight_Mark2_5.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 0)
        numAlignLight_Mark2_6.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 1)
        numAlignLight_Mark2_7.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 2)
        numAlignLight_Mark2_8.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 3)
    End Sub

    Private Sub btnBline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBline.Click
        m_iLine = 1
        btnAline.BackColor = Color.White
        btnBline.BackColor = Color.Lime
        numAlignLight_1.Value = pCurRecipe.nAlignLight(m_iLine, 0)
        numAlignLight_2.Value = pCurRecipe.nAlignLight(m_iLine, 1)
        numAlignLight_3.Value = pCurRecipe.nAlignLight(m_iLine, 2)
        numAlignLight_4.Value = pCurRecipe.nAlignLight(m_iLine, 3)

        numAlignLight_5.Value = pCurRecipe.nAlignLight2(m_iLine, 0)
        numAlignLight_6.Value = pCurRecipe.nAlignLight2(m_iLine, 1)
        numAlignLight_7.Value = pCurRecipe.nAlignLight2(m_iLine, 2)
        numAlignLight_8.Value = pCurRecipe.nAlignLight2(m_iLine, 3)

        numAlignLight_Mark2_1.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 0)
        numAlignLight_Mark2_2.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 1)
        numAlignLight_Mark2_3.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 2)
        numAlignLight_Mark2_4.Value = pCurRecipe.nAlignLight_mark2(m_iLine, 3)

        numAlignLight_Mark2_5.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 0)
        numAlignLight_Mark2_6.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 1)
        numAlignLight_Mark2_7.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 2)
        numAlignLight_Mark2_8.Value = pCurRecipe.nAlignLight2_mark2(m_iLine, 3)
    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .btnAline.Text = My.Resources.setLan.ResourceManager.GetObject("ALine")

            .btnBline.Text = My.Resources.setLan.ResourceManager.GetObject("BLine")
            .gbAlignLightSet.Text = My.Resources.setLan.ResourceManager.GetObject("LightSet")
            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("MSPOS1Lightbrightness")
            .Label6.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle1")

            .Label8.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle2")
            .Label7.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle3")
            .Label9.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle4")
            .Label2.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX1")

            .Label3.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX2")
            .Label4.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX3")
            .Label5.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX4")
            .Label10.Text = My.Resources.setLan.ResourceManager.GetObject("MSPOS2Lightbrightness")

            .Label14.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle1")

            .Label12.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle2")
            .Label13.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle3")
            .Label11.Text = My.Resources.setLan.ResourceManager.GetObject("thesameaxle4")
            .Label18.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX1")

            .Label17.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX2")

            .Label16.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX3")
            .Label15.Text = My.Resources.setLan.ResourceManager.GetObject("IRBOX4")
            .btnVisionLightParamSave.Text = My.Resources.setLan.ResourceManager.GetObject("Save")
            .btnAlignLightSet.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")

            .btnAlignLight_mark2_Set.Text = My.Resources.setLan.ResourceManager.GetObject("Set0")

        End With

    End Sub

End Class