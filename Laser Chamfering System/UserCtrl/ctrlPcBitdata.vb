Public Class ctrlPcBitdata
    Dim bUsePC As Boolean = False

    Public Sub UpdatePC2PLC_Bit()
        On Error GoTo SysErr
        lblPC_B200.BackColor = IIf(pMelsec.pPC_Bit(0, 0) = 0, Color.White, Color.Lime)
        lblPC_B201.BackColor = IIf(pMelsec.pPC_Bit(0, 1) = 0, Color.White, Color.Lime)
        lblPC_B20E.BackColor = IIf(pMelsec.pPC_Bit(0, 14) = 0, Color.White, Color.Lime)
        lblPC_B20F.BackColor = IIf(pMelsec.pPC_Bit(0, 15) = 0, Color.White, Color.Lime)
        lblPC_B210.BackColor = IIf(pMelsec.pPC_Bit(1, 0) = 0, Color.White, Color.Lime)
        lblPC_B212.BackColor = IIf(pMelsec.pPC_Bit(1, 2) = 0, Color.White, Color.Lime)
        lblPC_B213.BackColor = IIf(pMelsec.pPC_Bit(1, 3) = 0, Color.White, Color.Lime)
        lblPC_B214.BackColor = IIf(pMelsec.pPC_Bit(1, 4) = 0, Color.White, Color.Lime)
        lblPC_B215.BackColor = IIf(pMelsec.pPC_Bit(1, 5) = 0, Color.White, Color.Lime)
        lblPC_B218.BackColor = IIf(pMelsec.pPC_Bit(1, 8) = 0, Color.White, Color.Lime)
        lblPC_B219.BackColor = IIf(pMelsec.pPC_Bit(1, 9) = 0, Color.White, Color.Lime)
        lblPC_B21A.BackColor = IIf(pMelsec.pPC_Bit(1, 10) = 0, Color.White, Color.Lime)
        lblPC_B222.BackColor = IIf(pMelsec.pPC_Bit(2, 2) = 0, Color.White, Color.Lime)
        lblPC_B223.BackColor = IIf(pMelsec.pPC_Bit(2, 3) = 0, Color.White, Color.Lime)
        lblPC_B224.BackColor = IIf(pMelsec.pPC_Bit(2, 4) = 0, Color.White, Color.Lime)
        lblPC_B230.BackColor = IIf(pMelsec.pPC_Bit(3, 0) = 0, Color.White, Color.Lime)
        lblPC_B232.BackColor = IIf(pMelsec.pPC_Bit(3, 2) = 0, Color.White, Color.Lime)
        lblPC_B233.BackColor = IIf(pMelsec.pPC_Bit(3, 3) = 0, Color.White, Color.Lime)
        lblPC_B234.BackColor = IIf(pMelsec.pPC_Bit(3, 4) = 0, Color.White, Color.Lime)
        lblPC_B235.BackColor = IIf(pMelsec.pPC_Bit(3, 5) = 0, Color.White, Color.Lime)
        lblPC_B238.BackColor = IIf(pMelsec.pPC_Bit(3, 8) = 0, Color.White, Color.Lime)
        lblPC_B239.BackColor = IIf(pMelsec.pPC_Bit(3, 9) = 0, Color.White, Color.Lime)
        lblPC_B23A.BackColor = IIf(pMelsec.pPC_Bit(3, 10) = 0, Color.White, Color.Lime)
        lblPC_B242.BackColor = IIf(pMelsec.pPC_Bit(4, 2) = 0, Color.White, Color.Lime)
        lblPC_B243.BackColor = IIf(pMelsec.pPC_Bit(4, 3) = 0, Color.White, Color.Lime)
        lblPC_B244.BackColor = IIf(pMelsec.pPC_Bit(4, 4) = 0, Color.White, Color.Lime)
        lblPC_B250.BackColor = IIf(pMelsec.pPC_Bit(5, 0) = 0, Color.White, Color.Lime)
        lblPC_B251.BackColor = IIf(pMelsec.pPC_Bit(5, 1) = 0, Color.White, Color.Lime)
        lblPC_B254.BackColor = IIf(pMelsec.pPC_Bit(5, 4) = 0, Color.White, Color.Lime)
        lblPC_B255.BackColor = IIf(pMelsec.pPC_Bit(5, 5) = 0, Color.White, Color.Lime)
        lblPC_B256.BackColor = IIf(pMelsec.pPC_Bit(5, 6) = 0, Color.White, Color.Lime)
        lblPC_B257.BackColor = IIf(pMelsec.pPC_Bit(5, 7) = 0, Color.White, Color.Lime)
        lblPC_B260.BackColor = IIf(pMelsec.pPC_Bit(6, 0) = 0, Color.White, Color.Lime)
        lblPC_B262.BackColor = IIf(pMelsec.pPC_Bit(6, 2) = 0, Color.White, Color.Lime)
        lblPC_B263.BackColor = IIf(pMelsec.pPC_Bit(6, 3) = 0, Color.White, Color.Lime)
        lblPC_B264.BackColor = IIf(pMelsec.pPC_Bit(6, 4) = 0, Color.White, Color.Lime)
        lblPC_B265.BackColor = IIf(pMelsec.pPC_Bit(6, 5) = 0, Color.White, Color.Lime)
        lblPC_B266.BackColor = IIf(pMelsec.pPC_Bit(6, 6) = 0, Color.White, Color.Lime)
        lblPC_B267.BackColor = IIf(pMelsec.pPC_Bit(6, 7) = 0, Color.White, Color.Lime)
        lblPC_B27F.BackColor = IIf(pMelsec.pPC_Bit(7, 15) = 0, Color.White, Color.Lime)
        lblPC_B280.BackColor = IIf(pMelsec.pPC_Bit(8, 0) = 0, Color.White, Color.Lime)
        lblPC_B281.BackColor = IIf(pMelsec.pPC_Bit(8, 1) = 0, Color.White, Color.Lime)
        lblPC_B28F.BackColor = IIf(pMelsec.pPC_Bit(8, 15) = 0, Color.White, Color.Lime)
        lblPC_B290.BackColor = IIf(pMelsec.pPC_Bit(9, 0) = 0, Color.White, Color.Lime)
        lblPC_B291.BackColor = IIf(pMelsec.pPC_Bit(9, 1) = 0, Color.White, Color.Lime)
        lblPC_B292.BackColor = IIf(pMelsec.pPC_Bit(9, 2) = 0, Color.White, Color.Lime)
        lblPC_B293.BackColor = IIf(pMelsec.pPC_Bit(9, 3) = 0, Color.White, Color.Lime)
        lblPC_B2A0.BackColor = IIf(pMelsec.pPC_Bit(10, 0) = 0, Color.White, Color.Lime)
        lblPC_B2A1.BackColor = IIf(pMelsec.pPC_Bit(10, 1) = 0, Color.White, Color.Lime)
        lblPC_B2A2.BackColor = IIf(pMelsec.pPC_Bit(10, 2) = 0, Color.White, Color.Lime)
        lblPC_B2A3.BackColor = IIf(pMelsec.pPC_Bit(10, 3) = 0, Color.White, Color.Lime)
        lblPC_B2E0.BackColor = IIf(pMelsec.pPC_Bit(14, 0) = 0, Color.White, Color.Lime)
        lblPC_B2F0.BackColor = IIf(pMelsec.pPC_Bit(15, 0) = 0, Color.White, Color.Lime)
        Exit Sub
SysErr:

    End Sub


    Private Sub lblPLC_PC_BXXX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
 _
 _
 _
 _
 _
         lblPC_B2F0.Click, _
        lblPC_B200.Click, lblPC_B201.Click, lblPC_B20E.Click, lblPC_B20F.Click, lblPC_B210.Click, lblPC_B212.Click, lblPC_B213.Click, lblPC_B214.Click, lblPC_B218.Click, lblPC_B219.Click, _
        lblPC_B21A.Click, lblPC_B222.Click, lblPC_B223.Click, lblPC_B224.Click, lblPC_B230.Click, lblPC_B232.Click, lblPC_B233.Click, lblPC_B234.Click, lblPC_B238.Click, lblPC_B239.Click, _
        lblPC_B23A.Click, lblPC_B242.Click, lblPC_B243.Click, lblPC_B244.Click, lblPC_B250.Click, lblPC_B251.Click, lblPC_B254.Click, lblPC_B255.Click, lblPC_B256.Click, lblPC_B257.Click, _
        lblPC_B260.Click, lblPC_B262.Click, lblPC_B263.Click, lblPC_B264.Click, lblPC_B265.Click, lblPC_B266.Click, lblPC_B267.Click, lblPC_B27F.Click, lblPC_B280.Click, lblPC_B281.Click, _
        lblPC_B28F.Click, lblPC_B290.Click, lblPC_B291.Click, lblPC_B292.Click, lblPC_B293.Click, lblPC_B2A0.Click, lblPC_B2A1.Click, lblPC_B2A2.Click, lblPC_B2A3.Click, lblPC_B2E0.Click, _
        lblPC_B215.Click, lblPC_B235.Click

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
