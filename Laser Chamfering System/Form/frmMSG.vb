Public Class frmMSG
    Public pbMsgUp As Boolean = False
    Private nMSGMode As Integer = 0

    Public Sub ShowMsg(ByVal ipMsg As String, ByVal ipText As String, ByVal isError As Boolean, ByVal nMode As Integer)
        On Error GoTo SysErr
        lblMsg.Text = ipMsg
        lblText.Text = ipText
        If isError = True Then
            lblTitle.Text = "ERROR"
            lblTitle.BackColor = Color.Pink
            Me.BackColor = Color.White
        Else
            lblTitle.Text = "MESSAGE"
            lblTitle.BackColor = Color.Lime
            Me.BackColor = Color.White
        End If

        nMSGMode = nMode

        pbMsgUp = True
        Me.Show()

        Exit Sub
SysErr:

    End Sub
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo SysErr

        Select Case nMSGMode
            Case 0  'Model Change
            Case 1  'Error OK/NG Meg
            Case 2  'Menual Align
                If Seq(0).bManualAlignPopUp = True Then
                    frmSeqVision.Visible = False
                    frmInit.Visible = False
                    frmVision.Visible = True
                    frmRecipe.Visible = False
                    Select Case Seq(0).nManualAlingIndex
                        Case 0, 1, 4, 5  '0,1 -> 
                            frmVision.SelectVision(LINE.A, CAM.Cam1)
                            frmVision.m_ctrlOneVision(LINE.A, CAM.Cam1).SetManualVisionMode(4)
                            frmVision.m_ctrlOneVision(LINE.A, CAM.Cam1).DrawROI(LINE.A, Seq(0).nManualAlingIndex)
                        Case 2, 3, 6, 7
                            frmVision.SelectVision(LINE.A, CAM.Cam2)
                            frmVision.m_ctrlOneVision(LINE.A, CAM.Cam2).SetManualVisionMode(4)
                            frmVision.m_ctrlOneVision(LINE.A, CAM.Cam2).DrawROI(LINE.A, Seq(0).nManualAlingIndex)
                    End Select
                    Seq(LINE.A).bUseManualAlign = True

                ElseIf Seq(1).bManualAlignPopUp = True Then
                    frmSeqVision.Visible = False
                    frmInit.Visible = False
                    frmVision.Visible = True
                    frmRecipe.Visible = False
                    Select Case Seq(1).nManualAlingIndex
                        Case 0, 1, 4, 5
                            frmVision.SelectVision(LINE.B, CAM.Cam1)
                            frmVision.m_ctrlOneVision(LINE.B, CAM.Cam1).SetManualVisionMode(4)
                            frmVision.m_ctrlOneVision(LINE.B, CAM.Cam1).DrawROI(LINE.B, Seq(1).nManualAlingIndex)

                        Case 2, 3, 6, 7
                            frmVision.SelectVision(LINE.B, CAM.Cam2)
                            frmVision.m_ctrlOneVision(LINE.B, CAM.Cam2).SetManualVisionMode(4)
                            frmVision.m_ctrlOneVision(LINE.B, CAM.Cam2).DrawROI(LINE.B, Seq(1).nManualAlingIndex)
                    End Select
                    Seq(LINE.B).bUseManualAlign = True

                End If
            Case 3  'Mark Dis Error

                Seq(LINE.A).bDistanceError = False
                Seq(LINE.B).bDistanceError = False
                Seq(LINE.A).bMarkUseError = False
                Seq(LINE.B).bMarkUseError = False

        End Select

        pbMsgUp = False
        Me.Hide()
        Exit Sub
SysErr:
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        On Error GoTo SysErr

        Select nMSGMode
            Case 0  'Model Change
            Case 1  'Error OK/NG Meg
            Case 2  'Menual Align
                Seq(0).bManualAlignMode = False
                Seq(1).bManualAlignMode = False
                Seq(LINE.A).bManualAlignPopUp = False
                Seq(LINE.B).bManualAlignPopUp = False
                Seq(LINE.A).m_bLightOnOff = False
                Seq(LINE.B).m_bLightOnOff = False
            Case 3  'Mark Dis Error
        End Select

        pbMsgUp = False
        Me.Hide()

        Exit Sub
SysErr:
    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .lblTitle.Text = My.Resources.setLan.ResourceManager.GetObject("Message")

            .lblMsg.Text = My.Resources.setLan.ResourceManager.GetObject("System")
            .lblText.Text = My.Resources.setLan.ResourceManager.GetObject("ERROR0")
            .btnOK.Text = My.Resources.setLan.ResourceManager.GetObject("OK")
            .btnCancel.Text = My.Resources.setLan.ResourceManager.GetObject("Cancel")
        End With

    End Sub

    
End Class