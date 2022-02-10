#If SIMUL <> 1 Then
Imports GetCoreTempInfoNET
#End If

Public Class clsStatus_CPU
    Dim myProcess As Process
#If SIMUL <> 1 Then
    Dim CTInfo As CoreTempInfo
#End If
    Public bStart As Boolean = False
    Public nCoreTemperature() As Integer = {}
    Public nCoreLord() As Integer = {}
    Public nCoreCnt As Integer

    Function StartStatus() As Boolean
        On Error GoTo SysErr

        'myProcess = New Process()
        'myProcess.StartInfo.FileName = "C:\Chamfering System\ETC\CoreTemp32.exe"
        'myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
        'myProcess.Start()

#If SIMUL <> 1 Then
        CTInfo = New CoreTempInfo
#End If
        bStart = True
        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Function EndStatus() As Boolean
        On Error GoTo SysErr

        If Not myProcess.HasExited Then
            bStart = False
            'myProcess.Kill()
#If SIMUL <> 1 Then
            CTInfo = Nothing
#End If
        End If
        bStart = False


        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Function GetStauts() As Boolean
        On Error GoTo SysErr
        '#If SIMUL <> 1 Then
        '        If bStart = True Then
        '            CTInfo.GetData()
        '            ReDim nCoreTemperature(CTInfo.GetCoreCount)
        '            ReDim nCoreLord(CTInfo.GetCoreCount)

        '            For i As Integer = 0 To CTInfo.GetCoreCount
        '                nCoreTemperature(i) = CTInfo.GetTemp(i)
        '                nCoreLord(i) = CTInfo.GetCoreLoad(i)
        '                nCoreCnt = i
        '            Next
        '        End If
        '#End If
        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Sub Close()

        Call Finalize()

    End Sub

End Class
