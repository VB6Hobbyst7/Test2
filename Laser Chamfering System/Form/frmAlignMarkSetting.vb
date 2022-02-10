Imports Matrox.MatroxImagingLibrary

Public Class frmAlignMarkSetting

    Private mAlignMarkWnd As AlignMarkWnd '= Nothing
    Private m_nCamera As Integer = 0

    Dim RectSizeWnd As New Rectangle()
    Dim ImageSizeX As Integer = 0, ImageSizeY As Integer = 0
    Public bRefPoint As Boolean
    Public bMask As Boolean
    Public CheckCenter As Boolean = False


    Private Sub frmAlignMarkSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        '아무것도 안해도 되나? 

        cbMaskSize.SelectedIndex = 5

    End Sub

    Public Sub ShowDisplay(ByVal nCam As Integer)   'Image가 넘어가야 할듯..
        On Error GoTo SysErr

        m_nCamera = nCam
        SetDisplayWnd(nCam, pbMark)

        Exit Sub
SysErr:

    End Sub

    Public Sub fnAllocMark()

        Dim ptCross As Point
        Dim ptStart As Point
        ptCross.X = 300
        ptCross.Y = 300

        ptStart.X = 50
        ptStart.Y = 50

#If SIMUL <> 1 Then
        mAlignMarkWnd.AllocMarkImage(pMilInterface.MilSystem, pMilInterface.dispImageChild(m_nCamera), ptCross, ptStart)
#End If

    End Sub

    Public Sub fnShowMark(ByVal strImage As String)

#If SIMUL <> 1 Then
        mAlignMarkWnd.ShowMarkImage(strImage, pMilInterface.dispImageChild(m_nCamera))
#End If
        'Dim nImageSizeX As Integer = 0, nImageSizeY As Integer = 0
        'MIL.MbufInquire(mAlignMarkWnd.m_DispImage, MIL.M_SIZE_X, ImageSizeX)
        'MIL.MbufInquire(mAlignMarkWnd.m_DispImage, MIL.M_SIZE_Y, ImageSizeY)

        ''Zoom 기능 구현을 위하여.
        'Dim zoomX As Double = CDbl(RectSizeWnd.Width) / CDbl(nImageSizeX)
        'Dim zoomY As Double = CDbl(RectSizeWnd.Height) / CDbl(nImageSizeY)

        'fnZoom(zoomX, zoomY)

    End Sub

    Public Sub fnZoom(ByVal dZoomX As Double, ByVal dZoomY As Double)

        mAlignMarkWnd.SetZoomFactor(dZoomX, dZoomY)

    End Sub


    Private Sub SetDisplayWnd(ByVal nCamera As Integer, ByVal Display As System.Windows.Forms.PictureBox)

        RectSizeWnd.X = 0
        RectSizeWnd.Y = 0

        RectSizeWnd.Width = Display.Width
        RectSizeWnd.Height = Display.Height

        If mAlignMarkWnd IsNot Nothing Then
            mAlignMarkWnd.Close()
            mAlignMarkWnd.Dispose()
            mAlignMarkWnd = Nothing
        End If
        If mAlignMarkWnd IsNot Nothing Then
            mAlignMarkWnd.Close()
        End If

#If SIMUL <> 1 Then
        mAlignMarkWnd = New AlignMarkWnd(RectSizeWnd, Me.Handle, pMilInterface.MilSystem, pMilInterface.dispImageChild(nCamera))

        Display.Controls.Clear()
        Display.Controls.Add(mAlignMarkWnd)

        MIL.MbufInquire(pMilInterface.dispImageChild(nCamera), MIL.M_SIZE_X, ImageSizeX)
        MIL.MbufInquire(pMilInterface.dispImageChild(nCamera), MIL.M_SIZE_Y, ImageSizeY)

        Dim zoomX As Double = CDbl(RectSizeWnd.Width) / CDbl(ImageSizeX)
        Dim zoomY As Double = CDbl(RectSizeWnd.Height) / CDbl(ImageSizeY)
        mAlignMarkWnd.SetZoomFactor(zoomX, zoomY)

        mAlignMarkWnd.Show()
#End If

    End Sub

    Private Sub rbCenterPoint_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbCenterPoint.CheckedChanged

        modPub.SystemLog("frmAlignMarkSetting -- btnCenterPoint Check Click")

        bRefPoint = True
        bMask = False
        chkCenter.Enabled = True


    End Sub

    Private Sub rbMaskSetting_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbMaskSetting.CheckedChanged
        Masking.Checked = True
        MaskingSpeed.SelectedIndex = 2
        bRefPoint = False
        bMask = True

    End Sub

    Private Sub BtnSetting_Click(sender As System.Object, e As System.EventArgs) Handles BtnSetting.Click

        modPub.SystemLog("frmAlignMarkSetting -- btnSetting Click")
        mAlignMarkWnd.SaveMarkFile("C:\Vision Temp\MaskTemp")

        CheckCenter = False
        chkCenter.Enabled = False
        Close()

    End Sub

    Private Sub BtnCancle_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancle.Click

        Close()

    End Sub

    Private Sub btnZoom_Click(sender As System.Object, e As System.EventArgs) Handles btnZoom.Click

        fnZoom(2.3, 2.3)

    End Sub


    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("ALIGNMARKSETTING")

            .rbCenterPoint.Text = My.Resources.setLan.ResourceManager.GetObject("CentralPointSetting")
            .rbMaskSetting.Text = My.Resources.setLan.ResourceManager.GetObject("MaskProcessing")
            .Label4.Text = My.Resources.setLan.ResourceManager.GetObject("MaskSizeSetting")
            .btnZoom.Text = My.Resources.setLan.ResourceManager.GetObject("Zoom")

            .BtnSetting.Text = My.Resources.setLan.ResourceManager.GetObject("SettingCheck")
            .BtnCancle.Text = My.Resources.setLan.ResourceManager.GetObject("SettingCancel")
            

        End With

    End Sub

    ' 20180308 ksy 마크 중점 자동 찾기
    Private Sub btnDetectCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetectCenter.Click
        mAlignMarkWnd.AutoDetectMarkCenter()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim colData As Collection
        Dim dlg As New OpenFileDialog

        colData = New Collection

        dlg.Filter = "BMP File|*.bmp"


        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then

            mAlignMarkWnd.ImportExternalImage(dlg.FileName)

        End If
    End Sub

    Private Sub chkCenter_Tick(sender As System.Object, e As System.EventArgs) Handles chkCenter.Tick
        If CheckCenter = True Then
            BtnSetting.Enabled = True

        End If
    End Sub
End Class