Public Class Form1

    Dim mCamLiveWnd(1) As LiveImageWnd '= Nothing

    Dim dAlignX(0 To 1) As Double
    Dim dAlignY(0 To 1) As Double


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For i = 0 To 1 Step 1
            mCamLiveWnd(i) = Nothing
        Next

        Display_CheckedChanged(0, Panel_Display)
        Display_CheckedChanged(1, Panel_Display2)


        'Dim strImg As String
        'strImg = "C:\\111.bmp"
        'pMilProcessor.LoadImage(strImg, pMilInterface.dispImage(2), pMilInterface.MilSystem)

        ' panel_Display
        'Me.Panel_Display.BackColor = System.Drawing.Color.Gray
        'Me.Panel_Display.Location = New System.Drawing.Point(10, 13)
        'Me.Panel_Display.Name = "panel_Display"
        'Me.Panel_Display.Size = New System.Drawing.Size(830, 650)
        'Me.Panel_Display.TabIndex = 2
        'Me.Panel_Display.Paint += New System.Windows.Forms.PaintEventHandler(Me.panel_Display_Paint)



    End Sub

    Sub Display_CheckedChanged(ByVal nCam As Integer, ByVal Display As System.Windows.Forms.Panel)

        Dim RectSizeWnd As New Rectangle()

        RectSizeWnd.X = 0
        RectSizeWnd.Y = 0
        'RectSizeWnd.Width = Panel_Display.Width
        'RectSizeWnd.Height = Panel_Display.Height

        RectSizeWnd.Width = Display.Width
        RectSizeWnd.Height = Display.Height

        If mCamLiveWnd(nCam) IsNot Nothing Then
            mCamLiveWnd(nCam).Close()
            mCamLiveWnd(nCam).Dispose()
            mCamLiveWnd = Nothing
        End If
        If mCamLiveWnd(nCam) IsNot Nothing Then
            mCamLiveWnd(nCam).Close()
        End If
        mCamLiveWnd(nCam) = New LiveImageWnd(RectSizeWnd, Me.Handle, pMilInterface.MilSystem, pMilInterface.dispImage(nCam), pMilInterface.MilModResult(nCam))
        'mCamLiveWnd.SetCamNo(CInt(UMACCoord.Cut1))
        mCamLiveWnd(nCam).SetCamNo(nCam)

        'Panel_Display.Controls.Clear()
        'Panel_Display.Controls.Add(mCamLiveWnd(nCam))
        Display.Controls.Clear()
        Display.Controls.Add(mCamLiveWnd(nCam))

        Dim zoomX As Double = CDbl(Display.Width) / CDbl(pMilInterface.DigSizeX(nCam))
        Dim zoomY As Double = CDbl(Display.Height) / CDbl(pMilInterface.DigSizeY(nCam))
        mCamLiveWnd(nCam).SetZoomFactor(zoomX, zoomY)

        mCamLiveWnd(nCam).Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click 'Init

        pCamera.Connecting()
        pCamera.Configuring()
        pCamera.StartingStream()
        pCamera.Streaming()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strImg As String
        strImg = "C:\\111.bmp"
        pMilProcessor.LoadImage(strImg, pMilInterface.dispImage(0), pMilInterface.MilSystem)

        mCamLiveWnd(0).ChangeDisplayImage(pMilInterface.dispImage(0))
        mCamLiveWnd(0).Show()
    End Sub

    Private Sub btMarkFind1_Click(sender As System.Object, e As System.EventArgs) Handles btMarkFind1.Click

        Dim roi_mark_area As MIL_ID
        Dim dPxlOffsetX As Double
        Dim dPxlOffsetY As Double
        Dim dT As Double
        Dim dScore As Double

        roi_mark_area = pMilInterface.dispImage(0)




        pMilProcessor.FindAlignMark(roi_mark_area, pMilInterface.MilSearchContext(0), pMilInterface.MilModResult(0), dPxlOffsetX, dPxlOffsetY, dT, dScore)

        dAlignX(0) = dPxlOffsetX
        dAlignY(0) = dPxlOffsetY


        TextAlignX1.Text = dPxlOffsetX
        TextAlignY1.Text = dPxlOffsetY
        TextAlignT1.Text = dT
        TextAlignScore1.Text = dScore

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Dim strImg As String
        strImg = "C:\\222.bmp"
        pMilProcessor.LoadImage(strImg, pMilInterface.dispImage(1), pMilInterface.MilSystem)

        mCamLiveWnd(1).ChangeDisplayImage(pMilInterface.dispImage(1))
        mCamLiveWnd(1).Show()

    End Sub

    Private Sub btMarkFind2_Click(sender As System.Object, e As System.EventArgs) Handles btMarkFind2.Click

        Dim roi_mark_area As MIL_ID
        Dim dPxlOffsetX As Double
        Dim dPxlOffsetY As Double
        Dim dT As Double
        Dim dScore As Double

        roi_mark_area = pMilInterface.dispImage(1)

        pMilProcessor.FindAlignMark(roi_mark_area, pMilInterface.MilSearchContext(1), pMilInterface.MilModResult(1), dPxlOffsetX, dPxlOffsetY, dT, dScore)

        dAlignX(1) = dPxlOffsetX
        dAlignY(1) = dPxlOffsetY

        TextAlignX2.Text = dPxlOffsetX
        TextAlignY2.Text = dPxlOffsetY
        TextAlignT2.Text = dT
        TextAlignScore2.Text = dScore

    End Sub


End Class
