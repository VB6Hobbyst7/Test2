Public Class ctlUseLightTimeData

    Private Sub ctlUseLightTimeData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim readArr As New ArrayList
        Dim h As Double = 0
        Dim m As Double = 0
        Dim s As Double = 0
        Dim hh As String = ""
        Dim mm As String = ""
        Dim ss As String = ""
        Dim ssArr(2) As String

        Dim startTime As Date
        Dim clickUseLight As TimeSpan

        For i = 0 To 7
            readArr.Add(ReadIni("LIGHT_LIFT_TIME", "CHANNEL" & (i + 1), "-1", "C:\Chamfering System\DEFAULT.ini"))

            startTime = pLight.tStartCurrentTime(i + 1)

            If "#12:00:00 AM#" <> startTime And pLight.ctlLightVal(i + 1) <> 0 Then
                clickUseLight = Date.Now.Subtract(startTime)
                readArr(i) = clickUseLight.TotalSeconds + Double.Parse(readArr(i))
            End If

            h = (Double.Parse(readArr(i)) \ 3600)
            m = ((Double.Parse(readArr(i)) Mod 3600) \ 60)
            s = ((Double.Parse(readArr(i)) Mod 3600) Mod 60)

            If h < 10 Then
                hh = "0" & h
            Else
                hh = h
            End If

            If m < 10 Then
                mm = "0" & m
            Else
                mm = m
            End If

            If s < 10 Then
                ss = "0" & s
            Else
                ss = s
            End If

            ssArr = Split(ss, ".")

            readArr(i) = hh & ":" & mm & ":" & ssArr(0)
        Next

            Channel1.Text = readArr(0)
            Channel2.Text = readArr(1)
            Channel3.Text = readArr(2)
            Channel4.Text = readArr(3)
            Channel5.Text = readArr(4)
            Channel6.Text = readArr(5)
            Channel7.Text = readArr(6)
            Channel8.Text = readArr(7)
    End Sub
End Class