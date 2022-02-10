Public Class frmAutoFocus
    Dim m_Index As Integer
    Dim m_Line As Integer
    Private Sub btnScanner1_Click(sender As System.Object, e As System.EventArgs) Handles btnScanner1.Click
        btnScanner1.BackColor = Color.Lime
        btnScanner2.BackColor = Color.White
        btnScanner3.BackColor = Color.White
        btnScanner4.BackColor = Color.White
        m_Index = 0
    End Sub

    Private Sub btnScanner2_Click(sender As System.Object, e As System.EventArgs) Handles btnScanner2.Click
        btnScanner1.BackColor = Color.White
        btnScanner2.BackColor = Color.Lime
        btnScanner3.BackColor = Color.White
        btnScanner4.BackColor = Color.White
        m_Index = 1
    End Sub

    Private Sub btnScanner3_Click(sender As System.Object, e As System.EventArgs) Handles btnScanner3.Click
        btnScanner1.BackColor = Color.White
        btnScanner2.BackColor = Color.White
        btnScanner3.BackColor = Color.Lime
        btnScanner4.BackColor = Color.White
        m_Index = 2
    End Sub

    Private Sub btnScanner4_Click(sender As System.Object, e As System.EventArgs) Handles btnScanner4.Click
        btnScanner1.BackColor = Color.White
        btnScanner2.BackColor = Color.White
        btnScanner3.BackColor = Color.White
        btnScanner4.BackColor = Color.Lime
        m_Index = 3
    End Sub

    Private Sub btnSeqStop_Click(sender As System.Object, e As System.EventArgs) Handles btnSeqStop.Click
        btnSeqStart.BackColor = Color.White
        btnSeqStop.BackColor = Color.Lime

        pLDLT.StopStage(m_Line, Axis.x)
        pLDLT.StopStage(m_Line, Axis.y)
        For nScanner As Integer = 0 To 3
            pLDLT.StopScannerZ(nScanner)
        Next
        nfocusseq = 0
    End Sub

    Private Sub btnSeqStart_Click(sender As System.Object, e As System.EventArgs) Handles btnSeqStart.Click
        btnSeqStart.BackColor = Color.Lime
        btnSeqStop.BackColor = Color.White

        pScanNum = m_Index

        pbLine = m_Line
        pbStageX = numStageX.Value
        pbStageY = numStageY.Value
        pbScannerZ = numScannerZ.Value
        pbRepeat = numRepeat.Value
        pbPitch = numPitch.Value
        nfocusseq = 1
    End Sub

    Private Sub btnLineA_Click(sender As System.Object, e As System.EventArgs) Handles btnLineA.Click
        btnLineA.BackColor = Color.Lime
        btnLineB.BackColor = Color.White
        m_Line = LINE.A
    End Sub

    Private Sub btnLineB_Click(sender As System.Object, e As System.EventArgs) Handles btnLineB.Click
        btnLineA.BackColor = Color.White
        btnLineB.BackColor = Color.Lime
        m_Line = LINE.B
    End Sub

    Private Sub chkMarkLineAxis_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMarkLineAxis.CheckedChanged
        If chkMarkLineAxis.Checked = True Then
            chkMarkLineAxis.Text = "Stage Axis X"
            pbLineAxis = True
        ElseIf chkMarkLineAxis.Checked = False Then
            chkMarkLineAxis.Text = "Stage Axis Y"
            pbLineAxis = False
        End If
    End Sub

    Private Sub chkScannerZup_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkScannerZup.CheckedChanged
        If chkScannerZup.Checked = True Then
            chkScannerZup.Text = "Scanner Axis Z +"
            pbScannerZup = True
        ElseIf chkScannerZup.Checked = False Then
            chkScannerZup.Text = "Scanner Axis Z -"
            pbScannerZup = False
        End If
    End Sub

    Private Sub chkStageLineAxis_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStageLineAxis.CheckedChanged
        If chkStageLineAxis.Checked = True Then
            chkStageLineAxis.Text = "Stage Axis +"
            pbStageup = True
        ElseIf chkStageLineAxis.Checked = False Then
            chkStageLineAxis.Text = "Stage Axis -"
            pbStageup = False
        End If
    End Sub
End Class