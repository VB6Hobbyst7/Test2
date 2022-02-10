﻿Public Class ctrlSettingPlcInterface
    Dim bUsePC As Boolean = False

    Public m_ctrlPcBitdata As New ctrlPcBitdata
    Public m_ctrlPlcBitdata As New ctrlPlcBitdata


    Private Sub ctrlSettingPlcInterface_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        m_ctrlPlcBitdata.Location = New System.Drawing.Point(0, btnPLC_Data.Bottom)
        m_ctrlPlcBitdata.Visible = True

        m_ctrlPcBitdata.Location = New System.Drawing.Point(0, btnPLC_Data.Bottom)
        m_ctrlPcBitdata.Visible = False

        Me.Controls.Add(m_ctrlPlcBitdata)
        Me.Controls.Add(m_ctrlPcBitdata)

    End Sub


    Private Sub btnPLC_Data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPLC_Data.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnPLC_Data_Click")
        m_ctrlPcBitdata.Visible = False
        m_ctrlPlcBitdata.Visible = True
        btnPC_Data.BackColor = Color.WhiteSmoke
        btnPLC_Data.BackColor = Color.Lime
        bUsePC = False
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnPLC_Data_Click")
    End Sub

    Private Sub btnPC_Data_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPC_Data.Click
        On Error GoTo SysErr
        modPub.SystemLog("frmSetting - btnPC_Data_Click")
        m_ctrlPlcBitdata.Visible = False
        m_ctrlPcBitdata.Visible = True
        btnPC_Data.BackColor = Color.Lime
        btnPLC_Data.BackColor = Color.WhiteSmoke
        bUsePC = True
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnPC_Data_Click")
    End Sub

    Private Sub btnSetBitData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetBitData.Click
        On Error GoTo SysErr
        If bUsePC = False Then Exit Sub
        modPub.SystemLog("frmSetting - btnSetBitData_Click")
        Dim tmpValue As Integer = 0
        Dim tmpArrStr() As String = {}
        Dim tmpStr As String = ""
        tmpArrStr = Split(txtBitName.Text, "B")
        tmpStr = tmpArrStr(1)
        tmpValue = Val("&H" & tmpStr)
        pMXComponent.WriteBitByAddress(tmpValue, True)
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnSetBitData_Click")
    End Sub

    Private Sub btnResetBitData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetBitData.Click
        On Error GoTo SysErr
        If bUsePC = False Then Exit Sub
        modPub.SystemLog("frmSetting - btnResetBitData_Click")
        Dim tmpValue As Integer = 0
        Dim tmpArrStr() As String = {}
        Dim tmpStr As String = ""
        tmpArrStr = Split(txtBitName.Text, "B")
        tmpStr = tmpArrStr(1)
        tmpValue = Val("&H" & tmpStr)
        pMXComponent.WriteBitByAddress(tmpValue, False)
        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmSetting -- btnResetBitData_Click")
    End Sub

End Class
