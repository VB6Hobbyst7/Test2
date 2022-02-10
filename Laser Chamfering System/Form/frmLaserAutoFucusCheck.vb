Public Class frmLaserAutoFucusCheck
    Dim nSeqIndex As Integer = 0
    Dim bStop As Boolean = False

    Dim dStartPosX As Double = 0
    Dim dStartPosY As Double = 0
    Dim dStartPosZ As Double = 0

    Dim dStepX As Double = 0
    Dim dStepY As Double = 0
    Dim dStepZ As Double = 0

    Dim DestPosX As Double = 0
    Dim DestPosY As Double = 0
    Dim DestPosZ As Double = 0

    Dim nSetMoveCnt As Integer = 0
    Dim nCurMoveCnt As Integer = 0

    Private Sub tmAutoFocusCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmAutoFocusCheck.Tick
        On Error GoTo SysErr
        Static bRun As Boolean = False
        If bRun = True Then Exit Sub
        bRun = True
        If bStop = True Then
            nSeqIndex = 9999
        End If

        Select Case nSeqIndex

            Case 0

            Case 1

            Case 2

            Case 3

            Case 4

            Case 10


            Case 9999
                pScanner(0).RTC6LaserShotOff()
                pScanner(1).RTC6LaserShotOff()

        End Select

        bRun = False
        Exit Sub
SysErr:
        bRun = False
    End Sub
End Class