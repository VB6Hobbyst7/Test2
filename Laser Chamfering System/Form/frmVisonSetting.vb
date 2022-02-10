Public Class frmVisonSetting

    Dim tmpDistace_Vision As Double = 0
    Dim tmpDistace_Stage As Double = 0
    Dim tmpScale As Double = 0
    Dim tmpAngle As Double = 0

    Dim OriStagePosX_A1 As Double = 0
    Dim OriStagePosY_A1 As Double = 0
    Dim OriStagePosX_A2 As Double = 0
    Dim OriStagePosY_A2 As Double = 0

    Dim OriStagePosX_B1 As Double = 0
    Dim OriStagePosY_B1 As Double = 0
    Dim OriStagePosX_B2 As Double = 0
    Dim OriStagePosY_B2 As Double = 0

    Dim DestStagePosX_A1 As Double = 0
    Dim DestStagePosY_A1 As Double = 0
    Dim DestStagePosX_A2 As Double = 0
    Dim DestStagePosY_A2 As Double = 0

    Dim DestStagePosX_B1 As Double = 0
    Dim DestStagePosY_B1 As Double = 0
    Dim DestStagePosX_B2 As Double = 0
    Dim DestStagePosY_B2 As Double = 0


    Private Sub frmVisonSetting_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error GoTo SysErr
        pbSettingVision = False
        Exit Sub
SysErr:

    End Sub

    Private Sub frmVisonSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo SysErr
        numVisoinScaleX_A1.Value = pCurSystemParam.dVisionScaleX(LINE.A, 0)
        numVisoinScaleY_A1.Value = pCurSystemParam.dVisionScaleY(LINE.A, 0)

        numVisoinScaleX_A2.Value = pCurSystemParam.dVisionScaleX(LINE.A, 1)
        numVisoinScaleY_A2.Value = pCurSystemParam.dVisionScaleY(LINE.A, 1)

        numVisoinAngle_A1.Value = pCurSystemParam.dVisionTheta(LINE.A, 0)
        numVisoinAngle_A2.Value = pCurSystemParam.dVisionTheta(LINE.A, 1)

        numVisoinScaleX_B1.Value = pCurSystemParam.dVisionScaleX(LINE.B, 0)
        numVisoinScaleY_B1.Value = pCurSystemParam.dVisionScaleY(LINE.B, 0)

        numVisoinScaleX_B2.Value = pCurSystemParam.dVisionScaleX(LINE.B, 1)
        numVisoinScaleY_B2.Value = pCurSystemParam.dVisionScaleY(LINE.B, 1)

        numVisoinAngle_B1.Value = pCurSystemParam.dVisionTheta(LINE.B, 0)
        numVisoinAngle_B2.Value = pCurSystemParam.dVisionTheta(LINE.B, 1)

        pbSettingVision = True
        Exit Sub
SysErr:

    End Sub

    Private Sub btnVisionSet_A1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionSet_A1.Click
        On Error GoTo SysErr
        pSetSystemParam.dVisionScaleX(LINE.A, 0) = numVisoinScaleX_A1.Value
        pSetSystemParam.dVisionScaleY(LINE.A, 0) = numVisoinScaleY_A1.Value
        pSetSystemParam.dVisionTheta(LINE.A, 0) = numVisoinAngle_A1.Value

        Exit Sub
SysErr:
    End Sub

    Private Sub btnVisionSetClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionSetClose.Click
        On Error GoTo SysErr
        Me.Close()
        Exit Sub
SysErr:

    End Sub

    Private Sub btnVisionSetApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionSetApply.Click
        On Error GoTo SysErr
        pCurSystemParam.dVisionScaleX(LINE.A, 0) = pSetSystemParam.dVisionScaleX(LINE.A, 0)
        pCurSystemParam.dVisionScaleY(LINE.A, 0) = pSetSystemParam.dVisionScaleY(LINE.A, 0)

        pCurSystemParam.dVisionScaleX(LINE.A, 1) = pSetSystemParam.dVisionScaleX(LINE.A, 1)
        pCurSystemParam.dVisionScaleY(LINE.A, 1) = pSetSystemParam.dVisionScaleY(LINE.A, 1)

        pCurSystemParam.dVisionScaleX(LINE.B, 0) = pSetSystemParam.dVisionScaleX(LINE.B, 0)
        pCurSystemParam.dVisionScaleY(LINE.B, 0) = pSetSystemParam.dVisionScaleY(LINE.B, 0)

        pCurSystemParam.dVisionScaleX(LINE.B, 1) = pSetSystemParam.dVisionScaleX(LINE.B, 1)
        pCurSystemParam.dVisionScaleY(LINE.B, 1) = pSetSystemParam.dVisionScaleY(LINE.B, 1)

        pCurSystemParam.dVisionTheta(LINE.A, 0) = pSetSystemParam.dVisionTheta(LINE.A, 0)
        pCurSystemParam.dVisionTheta(LINE.A, 1) = pSetSystemParam.dVisionTheta(LINE.A, 1)
        pCurSystemParam.dVisionTheta(LINE.B, 1) = pSetSystemParam.dVisionTheta(LINE.B, 1)
        pCurSystemParam.dVisionTheta(LINE.B, 1) = pSetSystemParam.dVisionTheta(LINE.B, 1)

        lBoxVisionSetting.Items.Clear()
        Exit Sub
SysErr:

    End Sub

End Class