Public Class frmSeqVision

#If HEAD_2 Then
    Public ctrlVision(0 To 1, 0 To 1) As ctrlSeqVision
#Else
    Public ctrlVision(0 To 1, 0 To 3) As ctrlSeqVision
#End If

    Private Sub tmrScannerTac_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScannerTac.Tick
        On Error GoTo SysErr

        Static bRun As Boolean = False

        If bRun = True Then Exit Sub
        bRun = True

        'A Line Align Tac
#If HEAD_2 Then
        frmSequence_2Head.lblALineAlignTac.Text = pTimeTac(LINE.A).dAlignTime.ToString
#Else
        frmSequence.lblALineAlignTac.Text = pTimeTac(LINE.A).dAlignTime.ToString
#End If
        'frmSequence.lblALineAlignTac.Text = pTimeTac(LINE.A).dAlignTime.ToString

        ''B Line Align Tac
#If HEAD_2 Then
        frmSequence_2Head.lblBLineAlignTac.Text = pTimeTac(LINE.B).dAlignTime.ToString
#Else
        frmSequence.lblBLineAlignTac.Text = pTimeTac(LINE.B).dAlignTime.ToString
#End If
        'frmSequence.lblBLineAlignTac.Text = pTimeTac(LINE.B).dAlignTime.ToString

        ''A Line Trimming Tac
#If HEAD_2 Then
        frmSequence_2Head.lblALineTac.Text = pTimeTac(LINE.A).dTrimmingTime.ToString
#Else
        frmSequence.lblALineTac.Text = pTimeTac(LINE.A).dTrimmingTime.ToString
#End If
        'frmSequence.lblALineTac.Text = pTimeTac(LINE.A).dTrimmingTime.ToString

        ''B Line Trimming Tac
#If HEAD_2 Then
        frmSequence_2Head.lblBLineTac.Text = pTimeTac(LINE.B).dTrimmingTime.ToString
#Else
        frmSequence.lblBLineTac.Text = pTimeTac(LINE.B).dTrimmingTime.ToString
#End If
        'frmSequence.lblBLineTac.Text = pTimeTac(LINE.B).dTrimmingTime.ToString

        bRun = False '?

        Exit Sub
SysErr:
        bRun = False
    End Sub

    Private Sub frmSeqVision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If HEAD_2 Then
        ReDim ctrlVision(0, 1)
        ReDim ctrlVision(1, 1)

        For nLine As Integer = 0 To 1
            For i As Integer = 0 To 1
#Else
        ReDim ctrlVision(0, 3)
        ReDim ctrlVision(1, 3)

        For nLine As Integer = 0 To 1
            For i As Integer = 0 To 3
#End If
                ctrlVision(nLine, i) = New ctrlSeqVision    '(nLine, i)
                ctrlVision(nLine, i).m_iPanel = i
                Select Case i
                    Case 0
                        ctrlVision(nLine, i).Location = New System.Drawing.Point(5, 20)
                    Case 1
                        ctrlVision(nLine, i).Location = New System.Drawing.Point(346, 20)
                    Case 2
                        ctrlVision(nLine, i).Location = New System.Drawing.Point(5, 230)
                    Case 3
                        ctrlVision(nLine, i).Location = New System.Drawing.Point(346, 230)
                End Select

                Select Case nLine
                    Case 0
                        Me.gbLineA.Controls.Add(ctrlVision(nLine, i))
                    Case 1
                        Me.gbLineB.Controls.Add(ctrlVision(nLine, i))
                End Select
                ctrlVision(nLine, i).Visible = True
            Next
        Next

        tmrScannerTac.Enabled = True
    End Sub

    Public Sub ResetStatus(ByVal nLine As Integer, ByVal nPanel As Integer)
        ctrlVision(nLine, nPanel).lblScoreMark1.Text = "Score : 0"
        ctrlVision(nLine, nPanel).lblDiffPosX_Mark1.Text = "X : 0"
        ctrlVision(nLine, nPanel).lblDiffPosY_Mark1.Text = "Y : 0"
        ctrlVision(nLine, nPanel).lblOK_Mark1.Text = "-"
        ctrlVision(nLine, nPanel).picMark1.Image.Dispose()

        ctrlVision(nLine, nPanel).lblScoreMark2.Text = "Score : 0"
        ctrlVision(nLine, nPanel).lblDiffPosX_Mark2.Text = "X : 0"
        ctrlVision(nLine, nPanel).lblDiffPosY_Mark2.Text = "Y : 0"
        ctrlVision(nLine, nPanel).lblOK_Mark2.Text = "-"
        ctrlVision(nLine, nPanel).lblDistance.Text = "Distance : 0"
        ctrlVision(nLine, nPanel).picMark2.Image.Dispose()
    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbLineA.Text = My.Resources.setLan.ResourceManager.GetObject("LINEA")
            .gbLineB.Text = My.Resources.setLan.ResourceManager.GetObject("LINEB")
            
        End With

    End Sub
End Class