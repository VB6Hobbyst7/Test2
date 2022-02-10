Public Class ctrlPlcBitdata
    Dim bUsePC As Boolean = False


    Public Sub UpdatePLC2PC_Bit()
        On Error GoTo SysErr
        lblPLC_B300.BackColor = IIf(pMelsec.pPLC_Bit(0, 0) = 0, Color.White, Color.Lime)
        lblPLC_B301.BackColor = IIf(pMelsec.pPLC_Bit(0, 1) = 0, Color.White, Color.Lime)
        lblPLC_B302.BackColor = IIf(pMelsec.pPLC_Bit(0, 2) = 0, Color.White, Color.Lime)
        lblPLC_B303.BackColor = IIf(pMelsec.pPLC_Bit(0, 3) = 0, Color.White, Color.Lime)
        lblPLC_B304.BackColor = IIf(pMelsec.pPLC_Bit(0, 4) = 0, Color.White, Color.Lime)
        lblPLC_B305.BackColor = IIf(pMelsec.pPLC_Bit(0, 5) = 0, Color.White, Color.Lime)
        lblPLC_B30E.BackColor = IIf(pMelsec.pPLC_Bit(0, 14) = 0, Color.White, Color.Lime)
        lblPLC_B30F.BackColor = IIf(pMelsec.pPLC_Bit(0, 15) = 0, Color.White, Color.Lime)
        lblPLC_B310.BackColor = IIf(pMelsec.pPLC_Bit(1, 0) = 0, Color.White, Color.Lime)
        lblPLC_B311.BackColor = IIf(pMelsec.pPLC_Bit(1, 1) = 0, Color.White, Color.Lime)
        lblPLC_B320.BackColor = IIf(pMelsec.pPLC_Bit(2, 0) = 0, Color.White, Color.Lime)
        lblPLC_B321.BackColor = IIf(pMelsec.pPLC_Bit(2, 1) = 0, Color.White, Color.Lime)
        lblPLC_B322.BackColor = IIf(pMelsec.pPLC_Bit(2, 2) = 0, Color.White, Color.Lime)
        lblPLC_B328.BackColor = IIf(pMelsec.pPLC_Bit(2, 8) = 0, Color.White, Color.Lime)
        lblPLC_B329.BackColor = IIf(pMelsec.pPLC_Bit(2, 9) = 0, Color.White, Color.Lime)
        lblPLC_B32A.BackColor = IIf(pMelsec.pPLC_Bit(2, 10) = 0, Color.White, Color.Lime)
        lblPLC_B32B.BackColor = IIf(pMelsec.pPLC_Bit(2, 11) = 0, Color.White, Color.Lime)
        lblPLC_B32C.BackColor = IIf(pMelsec.pPLC_Bit(2, 12) = 0, Color.White, Color.Lime)
        lblPLC_B32D.BackColor = IIf(pMelsec.pPLC_Bit(2, 13) = 0, Color.White, Color.Lime)
        lblPLC_B32E.BackColor = IIf(pMelsec.pPLC_Bit(2, 14) = 0, Color.White, Color.Lime)
        lblPLC_B32F.BackColor = IIf(pMelsec.pPLC_Bit(2, 15) = 0, Color.White, Color.Lime)
        lblPLC_B330.BackColor = IIf(pMelsec.pPLC_Bit(3, 0) = 0, Color.White, Color.Lime)
        lblPLC_B331.BackColor = IIf(pMelsec.pPLC_Bit(3, 1) = 0, Color.White, Color.Lime)
        lblPLC_B340.BackColor = IIf(pMelsec.pPLC_Bit(4, 0) = 0, Color.White, Color.Lime)
        lblPLC_B341.BackColor = IIf(pMelsec.pPLC_Bit(4, 1) = 0, Color.White, Color.Lime)
        lblPLC_B342.BackColor = IIf(pMelsec.pPLC_Bit(4, 2) = 0, Color.White, Color.Lime)
        lblPLC_B348.BackColor = IIf(pMelsec.pPLC_Bit(4, 8) = 0, Color.White, Color.Lime)
        lblPLC_B349.BackColor = IIf(pMelsec.pPLC_Bit(4, 9) = 0, Color.White, Color.Lime)
        lblPLC_B34A.BackColor = IIf(pMelsec.pPLC_Bit(4, 10) = 0, Color.White, Color.Lime)
        lblPLC_B34B.BackColor = IIf(pMelsec.pPLC_Bit(4, 11) = 0, Color.White, Color.Lime)
        lblPLC_B34E.BackColor = IIf(pMelsec.pPLC_Bit(4, 14) = 0, Color.White, Color.Lime)
        lblPLC_B34F.BackColor = IIf(pMelsec.pPLC_Bit(4, 15) = 0, Color.White, Color.Lime)
        lblPLC_B350.BackColor = IIf(pMelsec.pPLC_Bit(5, 0) = 0, Color.White, Color.Lime)
        lblPLC_B351.BackColor = IIf(pMelsec.pPLC_Bit(5, 1) = 0, Color.White, Color.Lime)
        lblPLC_B352.BackColor = IIf(pMelsec.pPLC_Bit(5, 2) = 0, Color.White, Color.Lime)
        lblPLC_B353.BackColor = IIf(pMelsec.pPLC_Bit(5, 3) = 0, Color.White, Color.Lime)
        lblPLC_B354.BackColor = IIf(pMelsec.pPLC_Bit(5, 4) = 0, Color.White, Color.Lime)
        lblPLC_B355.BackColor = IIf(pMelsec.pPLC_Bit(5, 5) = 0, Color.White, Color.Lime)
        lblPLC_B356.BackColor = IIf(pMelsec.pPLC_Bit(5, 6) = 0, Color.White, Color.Lime)
        lblPLC_B357.BackColor = IIf(pMelsec.pPLC_Bit(5, 7) = 0, Color.White, Color.Lime)
        lblPLC_B360.BackColor = IIf(pMelsec.pPLC_Bit(6, 0) = 0, Color.White, Color.Lime)
        lblPLC_B361.BackColor = IIf(pMelsec.pPLC_Bit(6, 1) = 0, Color.White, Color.Lime)
        lblPLC_B362.BackColor = IIf(pMelsec.pPLC_Bit(6, 2) = 0, Color.White, Color.Lime)
        lblPLC_B363.BackColor = IIf(pMelsec.pPLC_Bit(6, 3) = 0, Color.White, Color.Lime)
        lblPLC_B364.BackColor = IIf(pMelsec.pPLC_Bit(6, 4) = 0, Color.White, Color.Lime)
        lblPLC_B365.BackColor = IIf(pMelsec.pPLC_Bit(6, 5) = 0, Color.White, Color.Lime)
        lblPLC_B366.BackColor = IIf(pMelsec.pPLC_Bit(6, 6) = 0, Color.White, Color.Lime)
        lblPLC_B367.BackColor = IIf(pMelsec.pPLC_Bit(6, 7) = 0, Color.White, Color.Lime)
        lblPLC_B370.BackColor = IIf(pMelsec.pPLC_Bit(7, 0) = 0, Color.White, Color.Lime)
        lblPLC_B371.BackColor = IIf(pMelsec.pPLC_Bit(7, 1) = 0, Color.White, Color.Lime)
        lblPLC_B390.BackColor = IIf(pMelsec.pPLC_Bit(9, 0) = 0, Color.White, Color.Lime)
        lblPLC_B391.BackColor = IIf(pMelsec.pPLC_Bit(9, 1) = 0, Color.White, Color.Lime)
        lblPLC_B3A0.BackColor = IIf(pMelsec.pPLC_Bit(10, 0) = 0, Color.White, Color.Lime)
        lblPLC_B3A1.BackColor = IIf(pMelsec.pPLC_Bit(10, 1) = 0, Color.White, Color.Lime)
        lblPLC_B3E0.BackColor = IIf(pMelsec.pPLC_Bit(14, 0) = 0, Color.White, Color.Lime)
        lblPLC_B3F0.BackColor = IIf(pMelsec.pPLC_Bit(15, 0) = 0, Color.White, Color.Lime)
        Exit Sub
SysErr:


    End Sub

    Private Sub lblPLC_PC_BXXX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPLC_B300.Click, lblPLC_B301.Click, lblPLC_B302.Click, lblPLC_B303.Click, lblPLC_B304.Click, _
        lblPLC_B305.Click, lblPLC_B30E.Click, lblPLC_B30F.Click, lblPLC_B310.Click, lblPLC_B311.Click, lblPLC_B320.Click, lblPLC_B321.Click, lblPLC_B322.Click, lblPLC_B328.Click, _
        lblPLC_B329.Click, lblPLC_B32A.Click, lblPLC_B32B.Click, lblPLC_B32C.Click, lblPLC_B32D.Click, lblPLC_B32E.Click, lblPLC_B32F.Click, lblPLC_B330.Click, lblPLC_B331.Click, _
        lblPLC_B340.Click, lblPLC_B341.Click, lblPLC_B342.Click, lblPLC_B348.Click, lblPLC_B349.Click, lblPLC_B34A.Click, lblPLC_B34B.Click, lblPLC_B34E.Click, lblPLC_B34F.Click, _
        lblPLC_B350.Click, lblPLC_B351.Click, lblPLC_B352.Click, lblPLC_B353.Click, lblPLC_B354.Click, lblPLC_B355.Click, lblPLC_B356.Click, lblPLC_B357.Click, lblPLC_B360.Click, _
        lblPLC_B361.Click, lblPLC_B362.Click, lblPLC_B363.Click, lblPLC_B364.Click, lblPLC_B365.Click, lblPLC_B366.Click, lblPLC_B367.Click, lblPLC_B370.Click, lblPLC_B371.Click, _
        lblPLC_B390.Click, lblPLC_B391.Click, lblPLC_B3A0.Click, lblPLC_B3A1.Click, lblPLC_B3E0.Click, lblPLC_B3F0.Click
        On Error GoTo SysErr

#If HEAD_2 Then
        frmSetting_BCR.m_ctrlSetting_PlcInterface.txtBitName.Text = sender.tag
#Else
        frmSetting.m_ctrlSetting_PlcInterface.txtBitName.Text = sender.tag
#End If

        Exit Sub
SysErr:

    End Sub
End Class
