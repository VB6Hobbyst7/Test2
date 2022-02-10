Public Class ctrlSelection

    Private Sub ctrlSelection_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        rdoSel1.Checked = True

        If Me.Tag = "Laser" Then
            rdoSel1.Text = "Laser #1"
            rdoSel2.Text = "Laser #2"
            rdoSel3.Text = "Laser #3"
            rdoSel4.Text = "Laser #4"
        ElseIf Me.Tag = "Scanner" Then
            rdoSel1.Text = "Scanner #1"
            rdoSel2.Text = "Scanner #2"
            rdoSel3.Text = "Scanner #3"
            rdoSel4.Text = "Scanner #4"
        End If

    End Sub

    Private Sub rdoSel1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoSel1.CheckedChanged
        If rdoSel1.Checked Then
            SelectCtrl(0)

            rdoSel1.BackColor = Color.Lime
            rdoSel2.BackColor = Color.White
            rdoSel3.BackColor = Color.White
            rdoSel4.BackColor = Color.White

        End If
    End Sub

    Private Sub rdoSel2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoSel2.CheckedChanged
        If rdoSel2.Checked Then
            SelectCtrl(1)

            rdoSel1.BackColor = Color.White
            rdoSel2.BackColor = Color.Lime
            rdoSel3.BackColor = Color.White
            rdoSel4.BackColor = Color.White
        End If
    End Sub

    Private Sub rdoSel3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoSel3.CheckedChanged
        If rdoSel3.Checked Then
            SelectCtrl(2)

            rdoSel1.BackColor = Color.White
            rdoSel2.BackColor = Color.White
            rdoSel3.BackColor = Color.Lime
            rdoSel4.BackColor = Color.White
        End If
    End Sub

    Private Sub rdoSel4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoSel4.CheckedChanged
        If rdoSel4.Checked Then
            SelectCtrl(3)

            rdoSel1.BackColor = Color.White
            rdoSel2.BackColor = Color.White
            rdoSel3.BackColor = Color.White
            rdoSel4.BackColor = Color.Lime
        End If
    End Sub

    Public Sub SelectCtrl(ByVal nIndex As Integer)

        If Me.Tag = "LINE" Then
            For i = 0 To 1
                If i = nIndex Then
                    frmRecipe.m_ctrlRcpAlign(i).Visible = True
                ElseIf frmRecipe.m_ctrlRcpAlign(i) IsNot Nothing Then
                    frmRecipe.m_ctrlRcpAlign(i).Visible = False
                End If
            Next
        End If

#If HEAD_2 Then
        If Me.Tag = "Laser" Then
            For i = 0 To 1
                If i = nIndex Then
                    frmSetting_BCR.m_ctrlSetting_Laser(i).Visible = True
                Else
                    frmSetting_BCR.m_ctrlSetting_Laser(i).Visible = False
                End If
            Next
        ElseIf Me.Tag = "Scanner" Then
            For i = 0 To 1
                If i = nIndex Then
                    frmSetting_BCR.m_ctrlSetting_Scanner(i).Visible = True
                Else
                    frmSetting_BCR.m_ctrlSetting_Scanner(i).Visible = False
                End If
            Next
        End If
#Else
        If Me.Tag = "Laser" Then
            For i = 0 To 3
                If i = nIndex Then
                    frmSetting.m_ctrlSetting_Laser(i).Visible = True
                Else
                    frmSetting.m_ctrlSetting_Laser(i).Visible = False
                End If
            Next
        ElseIf Me.Tag = "Scanner" Then
            For i = 0 To 3
                If i = nIndex Then
                    frmSetting.m_ctrlSetting_Scanner(i).Visible = True

                    frmSetting.m_ctrlSetting_Scanner(i).numHalfPulsePeriod.Value = pCurSystemParam.nScanHalfPulseWith(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numPulseWidth1.Value = pCurSystemParam.nScanPulseWidth1(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numPulseWidth1.Value = pCurSystemParam.nScanPulseWidth2(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numScanLaserOnDelay.Value = pCurSystemParam.nScanLaserOnDelay(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numScanLaserOffDelay.Value = pCurSystemParam.nScanLaserOffDelay(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numScanJumpSPD.Value = pCurSystemParam.nScanJumpSpeed(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numScanMarkSPD.Value = pCurSystemParam.nScanMarkSpeed(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numScanJumpDelay.Value = pCurSystemParam.nScanJumpDelay(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numScanMarkDelay.Value = pCurSystemParam.nScanMarkDelay(i)
                    frmSetting.m_ctrlSetting_Scanner(i).numScanPolygonDelay.Value = pCurSystemParam.nScanPolygonDelay(i)

                Else
                    frmSetting.m_ctrlSetting_Scanner(i).Visible = False
                End If
            Next
        End If


#End If

    End Sub

End Class
