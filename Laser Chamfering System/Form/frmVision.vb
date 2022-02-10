Public Class frmVision

    Public m_ctrlOneVision(1, 1) As ctrlOneVision       ' line, cam

    Private m_nLine As Integer
    Private m_nCamera As Integer


    Private Sub frmVision_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmVision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            For nLine = LINE.A To LINE.B
                For i = CAM.Cam1 To CAM.Cam2
                    m_ctrlOneVision(nLine, i) = New ctrlOneVision
                    m_ctrlOneVision(nLine, i).m_iLine = nLine
                    m_ctrlOneVision(nLine, i).m_iIndex = i

                    m_ctrlOneVision(nLine, i).Visible = False

                    m_ctrlOneVision(nLine, i).Location = New System.Drawing.Point(0, gbVisionChoice.Bottom + 2)
                    Me.Controls.Add(m_ctrlOneVision(nLine, i))

                    m_ctrlOneVision(nLine, i).Init()

                Next
            Next

            m_ctrlOneVision(0, 0).m_iLightCh = LIGHT_CH.LIGHT_CH_1
            m_ctrlOneVision(0, 1).m_iLightCh = LIGHT_CH.LIGHT_CH_2
            m_ctrlOneVision(1, 0).m_iLightCh = LIGHT_CH.LIGHT_CH_3
            m_ctrlOneVision(1, 1).m_iLightCh = LIGHT_CH.LIGHT_CH_4

            SelectVision(LINE.A, CAM.Cam1)

            Dim nVal As Integer = 0
            pLight.GetLight(1, nVal)

        Catch ex As Exception
            modPub.ErrorLog(Err.Description & " - frmVision -- frmVision_Load")
            MsgBox(ex.Message & "at " & Me.ToString)
        End Try
    End Sub


    Public Sub SelectVision(ByVal nLine As Integer, ByVal nCam As Integer)
        Try
            m_nLine = nLine
            m_nCamera = nCam

#If HEAD_2 Then
            If frmSequence_2Head.nManualAlign(0) = 1 Or frmSequence_2Head.nManualAlign(1) = 1 Then Exit Sub
#Else
            If frmSequence.nManualAlign(0) = 1 Or frmSequence.nManualAlign(1) = 1 Then Exit Sub
#End If
            'If frmSequence.nManualAlign(0) = 1 Or frmSequence.nManualAlign(1) = 1 Then Exit Sub

            modPub.SystemLog("frmVision -- btnVisionA2_Click")

            ' button change
            btnVisionA1.BackColor = Color.WhiteSmoke
            btnVisionA2.BackColor = Color.WhiteSmoke
            btnVisionB1.BackColor = Color.WhiteSmoke
            btnVisionB2.BackColor = Color.WhiteSmoke

            ' button selection change
            Dim btn As Button = Nothing
            If nLine = LINE.A Then
                If nCam = CAM.Cam1 Then
                    btn = btnVisionA1
                Else
                    btn = btnVisionA2
                End If
            ElseIf nLine = LINE.B Then
                If nCam = CAM.Cam1 Then
                    btn = btnVisionB1
                Else
                    btn = btnVisionB2
                End If
            End If

            btn.BackColor = Color.Lime

            ' view 변경
            For i = LINE.A To LINE.B
                For j = CAM.Cam1 To CAM.Cam2
                    If i = nLine And j = nCam Then
                        m_ctrlOneVision(i, j).Visible = True
                    Else
                        m_ctrlOneVision(i, j).Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            modPub.ErrorLog(Err.Description & " - frmVision -- SelectVision")
            MsgBox(ex.Message & "at " & Me.ToString)
        End Try

    End Sub


    Private Sub btnVisionA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionA1.Click
        SelectVision(LINE.A, CAM.Cam1)

        Dim nVal As Integer = 0
        pLight.GetLight(1, nVal)

    End Sub

    Private Sub btnVisionA2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionA2.Click
        SelectVision(LINE.A, CAM.Cam2)

        Dim nVal As Integer = 0
        pLight.GetLight(2, nVal)
    End Sub

    Private Sub btnVisionB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionB1.Click
        SelectVision(LINE.B, CAM.Cam1)

        Dim nVal As Integer = 0
        pLight.GetLight(3, nVal)

    End Sub

    Private Sub btnVisionB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionB2.Click
        SelectVision(LINE.B, CAM.Cam2)

        Dim nVal As Integer = 0
        pLight.GetLight(4, nVal)

    End Sub

   

    Private Sub btnManualAlignOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualAlignOK.Click
        On Error GoTo SysErr

        If Seq(LINE.A).bUseManualAlign = True And Seq(LINE.B).bUseManualAlign = False Then
            If Seq(0).bManualAlignMode = True Then
#If HEAD_2 Then
                frmSequence_2Head.pbManualAlign_A = False
#Else
                frmSequence.pbManualAlign_A = False
#End If
                'frmSequence.pbManualAlign_A = False
                Seq(0).bManualAlignMark_Get(Seq(0).nManualAlingIndex) = True
                Seq(0).bManualAlignMode = False
                Seq(LINE.A).bUseManualAlign = False
                Seq(LINE.A).bManualAlignPopUp = False
            End If
        End If

        If Seq(LINE.A).bUseManualAlign = False And Seq(LINE.B).bUseManualAlign = True Then
            If Seq(1).bManualAlignMode = True Then
#If HEAD_2 Then
                frmSequence_2Head.pbManualAlign_B = False
#Else
                frmSequence.pbManualAlign_B = False
#End If
                'frmSequence.pbManualAlign_B = False
                Seq(1).bManualAlignMark_Get(Seq(1).nManualAlingIndex) = True
                Seq(1).bManualAlignMode = False
                Seq(LINE.B).bUseManualAlign = False
                Seq(LINE.B).bManualAlignPopUp = False
            End If
        End If

        MainAndCameraOff()
        Exit Sub
SysErr:

    End Sub

    Dim m_nZoom As Integer

    Private Sub btnManualZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualZoom.Click

        m_nZoom = m_nZoom + 1

        ManualZoom_ORI(m_nZoom)

    End Sub

    Private Sub ManualZoom_ORI(ByVal nVisionCh As Integer)

#If SIMUL <> 1 Then
        Select Case nVisionCh
            Case 0
                m_ctrlOneVision(m_nLine, m_nCamera).LiveZoom(0.5, 0.5)

            Case 1
                m_ctrlOneVision(m_nLine, m_nCamera).LiveZoom(2, 2)

            Case 2
                m_ctrlOneVision(m_nLine, m_nCamera).LiveZoom(3, 3)

            Case 3
                m_ctrlOneVision(m_nLine, m_nCamera).LiveZoom(4, 4)

            Case 4
                m_ctrlOneVision(m_nLine, m_nCamera).LiveZoom(5, 5)
        End Select
#End If
        'bZoom = False
        Exit Sub
SysErr:

    End Sub

    Private Sub btnManualZoom_ORI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnManualZoom_ORI.Click

        '0.5 Ori....
        m_ctrlOneVision(m_nLine, m_nCamera).LiveZoom(0.5, 0.5)

        m_nZoom = 0
        'On Error GoTo SysErr
        '        If frmSequence.nManualAlign_A = 1 Or frmSequence.nManualAlign_B = 1 Then
        '            If bZoom = True Then
        '                ManualZoom_ORI(pnUseVisionCh)
        '            End If
        '            bZoom = False
        '        End If
        '        Exit Sub
        'SysErr:

    End Sub


    

    Private Sub btnManualAlignNG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualAlignNG.Click

    End Sub

    Private Sub btnHalt_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub gbMotion_Enter(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnLive_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub gbLightCh1_Enter(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lBoxResult_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbVisionChoice.Text = My.Resources.setLan.ResourceManager.GetObject("SelectVision")

            .btnVisionA1.Text = My.Resources.setLan.ResourceManager.GetObject("LineACamera1")
            .btnVisionA2.Text = My.Resources.setLan.ResourceManager.GetObject("LineACamera2")
            .btnVisionB1.Text = My.Resources.setLan.ResourceManager.GetObject("LineBCamera1")
            .btnVisionB2.Text = My.Resources.setLan.ResourceManager.GetObject("LineBCamera2")

            .btnManualAlignOK.Text = My.Resources.setLan.ResourceManager.GetObject("ManualAlignOK")
            .btnManualAlignNG.Text = My.Resources.setLan.ResourceManager.GetObject("ManualAlignNG")
            .btnManualZoom.Text = My.Resources.setLan.ResourceManager.GetObject("Zoom")

        End With

        For nLine = LINE.A To LINE.B
            For i = CAM.Cam1 To CAM.Cam2
                m_ctrlOneVision(nLine, i).LanChange(StrCulture)
            Next
        Next

    End Sub
    Private Function MainAndCameraOff() As Boolean

        frmInit.Visible = False
        frmSeqVision.Visible = True
        Me.Visible = False
        frmSequence.Visible = True
        frmSetting.Visible = False
        frmRecipe.Visible = False


    End Function


End Class