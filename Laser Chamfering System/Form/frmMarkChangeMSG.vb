Public Class frmMarkChangeMSG

   
    Public m_ctrlMarkRcp As New ctrlRecipeMarkEditor

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tmpdata As String = ""
        Dim tmpline As String = ""
        Dim ntmplaseindex As Integer = frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex + 1

        '확인만 하고 닫자.
        'If pCurRecipe.bMultiCutting = True Then
        '    SaveMarkData(pCurRecipe.strMultiFirstMarkRecipeFile(frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine, frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex), pCurRecipe.RecipeMultiFirstMarkingData(frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine, frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex))
        '    SaveMarkData(pCurRecipe.strMultiSecondMarkRecipeFile(frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine, frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex), pCurRecipe.RecipeMultiSecondMarkingData(frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine, frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex))
        'Else
        '    SaveMarkData(pCurRecipe.strMarkRecipeFile(frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine, frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex), pCurRecipe.RecipeMarkingData(frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine, frmRecipe.m_ctrlRcpMarkEditor.m_iSelLaserIndex))
        'End If

        If frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine = 0 Then

            tmpline = "LINE A"

        ElseIf frmRecipe.m_ctrlRcpMarkEditor.m_iSelLine = 1 Then

            tmpline = "LINE B"

        End If

        If listChangeData.Items.Count > 0 Then
            For i As Integer = 0 To listChangeData.Items.Count - 1
                tmpdata = tmpline & ntmplaseindex & "::" & listChangeData.Items(i)
                modPub.MarkDataChangeLog(tmpdata)
            Next
        End If

        Me.Visible = False
    End Sub

  

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("MarkDataChange")
            .btnCancel.Text = My.Resources.setLan.ResourceManager.GetObject("Cancel")
            .btnSave.Text = My.Resources.setLan.ResourceManager.GetObject("Save")

        End With

    End Sub

End Class