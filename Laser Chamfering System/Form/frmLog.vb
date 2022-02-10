Public Class frmLog
    Private Sub lBoxLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lBoxLog.SelectedIndexChanged
        lBoxLog.TopIndex = lBoxLog.Items.Count - 1
    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbLog.Text = My.Resources.setLan.ResourceManager.GetObject("SystemLog")

        End With

    End Sub
End Class