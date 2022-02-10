Public Class frmDigitalIO

    Private Sub frmDigitalIO_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

#If SIMUL <> 1 Then
        Initialize_DIO()
        SubOpenDevice()
#End If

    End Sub

    Private Sub Initialize_DIO()
        ' Confirm Library initialized.
        If AxlIsOpened = False Then
            ' Library initialize
            If AxlOpenNoReset(7) <> AXT_RT_SUCCESS Then
                MsgBox("Library initialized failed." & vbCrLf, MsgBoxStyle.Critical)
                End
            End If
        End If

    End Sub

    Private Sub SubOpenDevice()
        Dim lBoardNo As Integer
        Dim lModulePos As Integer
        Dim lModuleCnt As Integer
        Dim lModuleID As Integer
        Dim i1 As Short

        If AxlIsOpened Then
            cobModule.ResumeLayout()

            AxdInfoGetModuleCount(lModuleCnt)
            For i1 = 0 To lModuleCnt - 1

                ' Get information(Board No, Module Pos, Module ID) of that module.
                AxdInfoGetModule(i1, lBoardNo, lModulePos, lModuleID)

                Select Case lModuleID
                    Case AXT_SIO_DI32
                        'cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DI32")
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DI32")
                    Case AXT_SIO_RDI32
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDI32")
                    Case AXT_SIO_DI32_P
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DI32_P")
                    Case AXT_SIO_RDI32RTEX
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDI32RTEX")
                    Case AXT_SIO_RDI16MLII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDI16MLII")
                    Case AXT_SIO_RDI32PMLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDI32PMLIII")
                    Case AXT_SIO_RDI32MSMLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDI32MSMLIII")
                    Case AXT_SIO_RDI32MLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDI32MLIII")
                    Case AXT_SIO_DO32T
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DO32T")
                    Case AXT_SIO_DO32P
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DO32P")
                    Case AXT_SIO_RDO32
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDO32")
                    Case AXT_SIO_DO32T_P
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DO32T_P")
                    Case AXT_SIO_RDO32RTEX
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDO32RTEX")
                    Case AXT_SIO_RDO16BMLII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDO16BMLII")
                    Case AXT_SIO_RDO16AMLII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDO16AMLII")
                    Case AXT_SIO_RDO32PMLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDO32PMLIII")
                    Case AXT_SIO_RDO32AMSMLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDO32AMSMLIII")
                    Case AXT_SIO_RDO32MLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDO32MLIII")
                    Case AXT_SIO_RDB32MLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDB32MLIII")
                    Case AXT_SIO_RDB32PMLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDB32PMLIII")
                    Case AXT_SIO_RDB96MLII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDB96MLII")
                    Case AXT_SIO_RDB128MLII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDB128MLII")
                    Case AXT_SIO_DB32P
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DB32P")
                    Case AXT_SIO_RDB32T
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDB32T")
                    Case AXT_SIO_DB32T
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_DB32T")
                    Case AXT_SIO_UNDEFINEMLIII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_UNDEFINEMLIII")
                    Case AXT_SIO_RSIMPLEIOMLII
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RSIMPLEIOMLII")
                    Case AXT_SIO_RDB32RTEX
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDB32RTEX")
                    Case AXT_SIO_RDB128MLIIIAI
                        cobModule.Items.Add("[BD No:" & lBoardNo.ToString("D2") & " - MD No:" & i1.ToString("D2") & "]" & "SIO_RDB128MLIIIAI")

                End Select
            Next

            cobModule.SelectedIndex = 0
        End If

    End Sub

    'UPGRADE_WARNING: Form 이벤트 frmDigitalIO.Unload에 새 동작이 있습니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2065"'
    Private Sub frmDigitalIO_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        If AxlIsOpened Then
            ' Library close
            AxlClose()
        End If

    End Sub

    Private Function SubHiByte(ByRef wParam As Integer) As Byte
        SubHiByte = Int(wParam / &H100S)

    End Function

    Private Function SubLoByte(ByRef wParam As Integer) As Byte
        Dim nHiByte As Short

        nHiByte = Int(wParam / &H100S)
        SubLoByte = wParam - (nHiByte * &H100S)

        If SubLoByte > &H7FFS Then SubLoByte = SubLoByte - &H100S

    End Function

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub cmdListClear_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        List1.Items.Clear()
    End Sub


    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Dim i1 As Integer
        Dim lModuleNo As Integer
        Dim lBoardNo As Integer
        Dim lModulePos As Integer
        Dim lModuleID As Integer
        Dim lValue As Integer

        If AxlIsOpened Then

            lModuleNo = cobModule.SelectedIndex
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID

                Case AXT_SIO_DI32, AXT_SIO_RDI32, AXT_SIO_DI32_P, AXT_SIO_RDI32RTEX, AXT_SIO_RDI32MLIII, AXT_SIO_RDI32MSMLIII, AXT_SIO_RDI32PMLIII, AXT_SIO_RDI16MLII
                    For i1 = 0 To 15
                        ' INPUTOUTPUT (00bit ~ 15bit) Verify input
                        AxdiReadInportBit(lModuleNo, i1, lValue)
                        If lValue Then
                            'chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            'chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If

                        ' INPUTOUTPUT (150bit ~ 31bit) Verify input
                        AxdiReadInportBit(lModuleNo, i1 + 16, lValue)
                        If lValue Then
                            'chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            'chk2ndWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If
                    Next

                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDO32, AXT_SIO_DO32T_P, AXT_SIO_RDO32RTEX, AXT_SIO_RDO16AMLII, AXT_SIO_RDO16BMLII, AXT_SIO_RDO32MLIII, AXT_SIO_RDO32AMSMLIII, AXT_SIO_RDO32PMLIII
                    For i1 = 0 To 15
                        ' INPUTOUTPUT (00bit ~ 15bit) Verify input
                        AxdiReadInportBit(lModuleNo, i1, lValue)

                        If lValue Then
                            'chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Checked
                        Else
                            'chk1stWord(i1).CheckState = System.Windows.Forms.CheckState.Unchecked
                        End If
                    Next
            End Select
        End If

    End Sub

    'UPGRADE_WARNING: 폼이 초기화될 때 chkInterrupt.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub chkInterrupt_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkInterrupt.CheckStateChanged
        Dim lModuleNo As Integer
        Dim lBoardNo As Integer
        Dim lModulePos As Integer
        Dim lModuleID As Integer

        Dim szInterruptSelect As String
        Dim sInterruptEnable As String
        Dim sInterruptDisable As String
        Dim sInterruptFail As String

        szInterruptSelect = "※Please set edge"
        sInterruptEnable = "Enable Interrupt button is 'activated' "
        sInterruptDisable = "Enable Interrupt button is 'deactivated' "
        sInterruptFail = "Enable Interrupt button can not be used "

        If AxlIsOpened Then
            lModuleNo = cobModule.SelectedIndex
            ' Retun base board number and module position of specific module number
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID
                Case AXT_SIO_DI32, AXT_SIO_DB32P, AXT_SIO_DB32T, AXT_SIO_DI32_P, AXT_SIO_RDI32, AXT_SIO_RDB32T
                    If chkInterrupt.Checked Then
                        AxlInterruptEnable()
                        '                        AxdiInterruptSetModule(lModuleNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, 0, 0)

                        ' Allow interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 1)

                        List1.Items.Add(sInterruptEnable)
                        List1.Items.Add(szInterruptSelect)
                        List1.SelectedIndex = List1.Items.Count - 1
                    Else
                        ' Prohibit interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 0)
                        AxlInterruptDisable()

                        chkRising.Checked = 0
                        chkRising.Checked = 0

                        List1.Items.Add(sInterruptDisable)
                        List1.SelectedIndex = List1.Items.Count - 1
                    End If

                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDI32
                    List1.Items.Add(sInterruptFail)
                    List1.SelectedIndex = List1.Items.Count - 1
            End Select
        End If
    End Sub

    'UPGRADE_WARNING: 폼이 초기화될 때 chkRising.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub chkRising_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkRising.CheckStateChanged
        Dim lModuleNo As Integer
        Dim lBoardNo As Integer
        Dim lModulePos As Integer
        Dim lModuleID As Integer

        Dim sStartMsg As String
        Dim sEndMsg As String
        Dim sErrMsg As String
        Dim sinterruptErrMsg As String

        sStartMsg = "'Start' Rising Edge detection"
        sEndMsg = "'Exit' Rising Edge detection"
        sErrMsg = "Can not use Rising Edge detection"
        sinterruptErrMsg = "Please enable interrupt button first."

        ' If library is initialized
        If AxlIsOpened Then

            lModuleNo = cobModule.SelectedIndex
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID
                Case AXT_SIO_DI32
                    If chkRising.CheckState Then
                        If chkInterrupt.CheckState Then
                            ' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, UP_EDGE, &HFFFFFFFF)

                            List1.Items.Add(sStartMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        Else
                            List1.Items.Add(sErrMsg)

                            chkRising.CheckState = System.Windows.Forms.CheckState.Unchecked

                            List1.Items.Add(sinterruptErrMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    Else
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, UP_EDGE, &H0)
                        AxdiInterruptEdgeSetWord(lModuleNo, 1, UP_EDGE, &H0)

                        'If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
                        If List1.Text <> sErrMsg Then
                            List1.Items.Add(sEndMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    End If
                Case AXT_SIO_DB32P, AXT_SIO_DB32T, AXT_SIO_RDB32T

                    If chkRising.CheckState Then
                        If chkInterrupt.CheckState Then
                            ' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, UP_EDGE, &HFFFFFFFF)

                            List1.Items.Add(sStartMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        Else


                            List1.Items.Add(sErrMsg)

                            chkRising.CheckState = System.Windows.Forms.CheckState.Unchecked

                            List1.Items.Add(sinterruptErrMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    Else
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, UP_EDGE, &H0)

                        'If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
                        If List1.Text <> sErrMsg Then
                            List1.Items.Add(sEndMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    End If
                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_DO32T_P, AXT_SIO_RDO32
                    List1.Items.Add(sinterruptErrMsg)
                    List1.SelectedIndex = List1.Items.Count - 1

            End Select
        End If
    End Sub

    'UPGRADE_WARNING: 폼이 초기화될 때 chkFalling.CheckStateChanged 이벤트가 발생합니다. 자세한 내용은 다음을 참조하십시오: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
    Private Sub chkFalling_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkFalling.CheckStateChanged

        Dim lModuleNo As Integer
        Dim lBoardNo As Integer
        Dim lModulePos As Integer
        Dim lModuleID As Integer
        Dim sStartMsg As String
        Dim sEndMsg As String
        Dim sErrMsg As String
        Dim sinterruptErrMsg As String

        sStartMsg = "'Start' Falling Edge detection"
        sEndMsg = "'Exit' Falling Edge detection"
        sErrMsg = "Can not use Falling Edge detection"
        sinterruptErrMsg = "Please enable interrupt button first."


        ' If library is initialized
        If AxlIsOpened Then

            lModuleNo = cobModule.SelectedIndex
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID
                Case AXT_SIO_DI32

                    If chkFalling.CheckState Then
                        If chkInterrupt.CheckState Then
                            ' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, DOWN_EDGE, &HFFFFFFFF)

                            List1.Items.Add(sStartMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        Else
                            List1.Items.Add(sErrMsg)

                            chkFalling.CheckState = System.Windows.Forms.CheckState.Unchecked

                            List1.Items.Add(sinterruptErrMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    Else
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, DOWN_EDGE, &H0)
                        AxdiInterruptEdgeSetWord(lModuleNo, 1, DOWN_EDGE, &H0)

                        'If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
                        If List1.Text <> sErrMsg Then
                            List1.Items.Add(sEndMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    End If
                Case AXT_SIO_DB32P, AXT_SIO_DB32T

                    If chkFalling.CheckState Then
                        If chkInterrupt.CheckState Then
                            ' Set Interrupt Edge
                            AxdiInterruptEdgeSetDword(lModuleNo, 0, DOWN_EDGE, &HFFFFFFFF)

                            List1.Items.Add(sStartMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        Else

                            List1.Items.Add(sErrMsg)

                            chkFalling.CheckState = System.Windows.Forms.CheckState.Unchecked

                            List1.Items.Add(sinterruptErrMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    Else
                        ' Set Interrupt Edge
                        AxdiInterruptEdgeSetWord(lModuleNo, 0, DOWN_EDGE, &H0)

                        'If VB6.GetItemString(List1, List1.Items.Count - 1) <> sErrMsg Then
                        If List1.Text <> sErrMsg Then
                            List1.Items.Add(sEndMsg)
                            List1.SelectedIndex = List1.Items.Count - 1
                        End If
                    End If

                Case AXT_SIO_DO32P, AXT_SIO_DO32T
                    List1.Items.Add(sinterruptErrMsg)
                    List1.SelectedIndex = List1.Items.Count - 1
            End Select
        End If
    End Sub
    Private Sub chkInterrupt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInterrupt.CheckedChanged
        Dim lModuleNo As Long
        Dim lBoardNo As Long
        Dim lModulePos As Long
        Dim lModuleID As Long

        Dim szInterruptSelect As String
        Dim sInterruptEnable As String
        Dim sInterruptDisable As String
        Dim sInterruptFail As String

        szInterruptSelect = "※Please set edge"
        sInterruptEnable = "Enable Interrupt button is 'activated' "
        sInterruptDisable = "Enable Interrupt button is 'deactivated' "
        sInterruptFail = "Enable Interrupt button can not be used "

        If AxlIsOpened Then
            lModuleNo = cobModule.SelectedIndex
            ' Retun base board number and module position of specific module number
            '            AxtMsg.Message1 = WM_AXL_INTERRUPT
            AxdInfoGetModule(lModuleNo, lBoardNo, lModulePos, lModuleID)
            Select Case lModuleID

                Case AXT_SIO_DI32, _
                     AXT_SIO_DB32P, AXT_SIO_DB32T

                    If chkInterrupt.Checked Then
                        AxlInterruptEnable()
                        '                        AxdiInterruptSetModule(lModuleNo, AxtMsg.hWnd, WM_AXL_INTERRUPT, 0, 0)

                        ' Allow interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 1)

                        List1.Items.Add(sInterruptEnable)
                        List1.Items.Add(szInterruptSelect)
                        List1.SelectedIndex = List1.Items.Count - 1
                    Else
                        ' Prohibit interrupt of specific module
                        AxdiInterruptSetModuleEnable(lModuleNo, 0)
                        AxlInterruptDisable()

                        chkRising.Checked = 0
                        chkFalling.Checked = 0

                        List1.Items.Add(sInterruptDisable)
                        List1.SelectedIndex = List1.Items.Count - 1
                    End If

                Case AXT_SIO_DO32P, AXT_SIO_DO32T, AXT_SIO_RDI32
                    List1.Items.Add(sInterruptFail)
                    List1.SelectedIndex = List1.Items.Count - 1
            End Select
        End If
    End Sub
    Private Sub AxtMsg_OnMessage1(ByVal sender As System.Object, ByVal e As AxAXTMESSENGERLib._DAxtMessengerEvents_OnMessage1Event)
        Dim nBoardNo As Long
        Dim nModuleNo As Long
        Dim nModulePos As Long
        Dim lValue, lChkBit As Long
        Dim i1 As Integer

        nBoardNo = Int(e.wParam / &H100)
        nModulePos = e.wParam - (Int(e.wParam / &H100) * &H100)
        AxdInfoGetModuleNo(nBoardNo, nModulePos, nModuleNo)

        AxdoReadOutportDword(nModuleNo, 0, lValue)
        For i1 = 0 To 31
            If Int(e.lParam / 2 ^ i1) And &H1 Then
                '해당모듈의 해당 오프셋의 비트값을 읽어온다.
                lChkBit = Int(lValue / (2 ^ i1)) And &H1

                If lChkBit Then
                    List1.Items.Add("Interrupt set bit " + " ☞  &H" + Hex(i1) + "    [▲Rising]")
                Else
                    List1.Items.Add("Interrupt set bit " + " ☞  &H" + Hex(i1) + "    [▼Falling]")
                End If

                List1.SelectedIndex = List1.Items.Count() - 1

            End If
        Next
    End Sub

    Private Sub chkRising_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRising.CheckedChanged

    End Sub

    Public Sub frmShow()

        Me.Show()

    End Sub

    Private Sub cmdClose_Click_1(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click

        Me.Hide()
        'Close()

    End Sub
End Class