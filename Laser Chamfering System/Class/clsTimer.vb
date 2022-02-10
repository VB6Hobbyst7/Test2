Public Class clsTimer
    Private m_nStartTick As Integer
    Private m_bStarted As Boolean = False

    Public Sub Reset()
        m_nStartTick = 0
        m_bStarted = False
    End Sub

    Public Function IsTimeOut(ByVal nIntervalMil As Integer) As Boolean
        If m_bStarted = False Then
            m_bStarted = True
            m_nStartTick = My.Computer.Clock.TickCount
        Else
            If (My.Computer.Clock.TickCount - m_nStartTick) > nIntervalMil Then
                m_nStartTick = 0
                m_bStarted = False
                Return True
            End If
        End If

        Return False
    End Function
End Class
