Public Class frmRunStatus
    Dim strVersion As String
    Private Sub frmRunStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            MsgBox("프로그램이 이미 실행중입니다.!!!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
            End
        End If
#If SIMUL <> 1 Then
        LoadParam("C:\Chamfering System\DEFAULT.ini")
        lblVersion.Text = strVersion
#Else
        lblVersion.Text = "Simulation MODE!!!!!!!"
#End If
    End Sub
    Public Function LoadParam(ByVal strFilePath As String) As Boolean
        strVersion = ReadIni("FILE_PATH", "PROGRAM_VERSION", "", strFilePath)
    End Function

End Class