Public Class ctrlSeqVision

    Public m_iPanel As Integer

    'Public Sub New(ByVal nLine As Integer, ByVal nPanel As Integer)



    'End Sub

    Private Sub ctrlSeqVision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gbAlignGls.Text = "Glass #" & (Me.m_iPanel + 1).ToString()
    End Sub

    Public Sub ResetStatus()
        lblScoreMark1.Text = "Score : 0"
        lblDiffPosX_Mark1.Text = "X : 0"
        lblDiffPosY_Mark1.Text = "Y : 0"
        lblOK_Mark1.Text = "-"
        picMark1.Image.Dispose()

        lblScoreMark2.Text = "Score : 0"
        lblDiffPosX_Mark2.Text = "X : 0"
        lblDiffPosY_Mark2.Text = "Y : 0"
        lblOK_Mark2.Text = "-"
        lblDistance.Text = "Distance : 0"
        picMark2.Image.Dispose()
    End Sub

    Public Sub UpdateStatus(ByVal nMark As Integer, ByVal nLine As Integer, ByVal nCnt As Integer)
        Dim str(1) As String
        str(0) = "A"
        str(1) = "B"
        Select Case nMark
            Case 0
                lblScoreMark1.Text = "Score : " & Math.Round(pMF_Result(nLine, m_iPanel, nMark).Score, 3).ToString
                lblDiffPosX_Mark1.Text = "X : " & Math.Round(pMF_Result(nLine, m_iPanel, nMark).PositionDiffX, 3).ToString
                lblDiffPosY_Mark1.Text = "Y : " & Math.Round(pMF_Result(nLine, m_iPanel, nMark).positionDiffY, 3).ToString
                If pMF_Result(nLine, m_iPanel, nMark).bFindSuccess Then
                    lblOK_Mark1.ForeColor = Color.Lime
                    lblOK_Mark1.Text = "OK"
                Else
                    lblOK_Mark1.ForeColor = Color.Red
                    lblOK_Mark1.Text = "NG"
                End If

                lblMark1Cnt.Text = nCnt.ToString()
                LoadPictureBoxImage(picMark1, Seq(nLine).tmpStrImage(0 + (m_iPanel * 2)))

                ' LoadPictureBoxImage(picMark1, "C:\Vision Temp\" & str(nLine) & (m_iPanel + 1).ToString & "_Mark1.bmp")
            Case 1
                lblScoreMark2.Text = "Score : " & Math.Round(pMF_Result(nLine, m_iPanel, nMark).Score, 3).ToString
                lblDiffPosX_Mark2.Text = "X : " & Math.Round(pMF_Result(nLine, m_iPanel, nMark).PositionDiffX, 3).ToString
                lblDiffPosY_Mark2.Text = "Y : " & Math.Round(pMF_Result(nLine, m_iPanel, nMark).positionDiffY, 3).ToString
                lblDistance.Text = "Distance : " & Math.Round(dMarkDistance(nLine, m_iPanel), 3).ToString
                If pMF_Result(nLine, m_iPanel, nMark).bFindSuccess Then
                    lblOK_Mark2.ForeColor = Color.Lime
                    lblOK_Mark2.Text = "OK"
                Else
                    lblOK_Mark2.ForeColor = Color.Red
                    lblOK_Mark2.Text = "NG"
                End If

                lblMark2Cnt.Text = nCnt.ToString()
                LoadPictureBoxImage(picMark2, Seq(nLine).tmpStrImage(1 + (m_iPanel * 2)))

                'LoadPictureBoxImage(picMark2, "C:\Vision Temp\" & str(nLine) & (m_iPanel + 1).ToString & "_Mark2.bmp")
        End Select
    End Sub

    Private Sub LoadPictureBoxImage(ByVal ipPictureBox As PictureBox, ByVal ipImagePath As String)
        On Error GoTo SysErr
        If Not ipPictureBox.Image Is Nothing Then
            ipPictureBox.Image.Dispose()
        End If

        ipPictureBox.Load(ipImagePath)
        Exit Sub
SysErr:
    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .gbAlignGls.Text = My.Resources.setLan.ResourceManager.GetObject("Glass1")

            .lblScoreMark1.Text = My.Resources.setLan.ResourceManager.GetObject("Score00000")
            .lblScoreMark2.Text = My.Resources.setLan.ResourceManager.GetObject("Score00000")

            .lblOK_Mark1.Text = My.Resources.setLan.ResourceManager.GetObject("OK")
            .lblOK_Mark2.Text = My.Resources.setLan.ResourceManager.GetObject("OK")

        End With

    End Sub
End Class
