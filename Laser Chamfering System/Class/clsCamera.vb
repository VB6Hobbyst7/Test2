Imports Matrox.MatroxImagingLibrary
Imports System.Threading

Public Class Camera
    Inherits MIL

    Private Const CAMERA_CONFIG_DIR As String = "C:\Chamfering System\Setting\Vision\"

    Public m_iIndex As Integer = 0
    Public m_strCam As String = ""
    Public m_bConnected = False

    Private bStartCam As Boolean = False
    Public mThread As Thread = Nothing
    Private mIsStopping As Boolean = False
    Private mStep As Integer = 1

    Public Sub GrabtoDisplay(ByRef iCam As Object)
#If SIMUL <> 1 Then
        MbufPut(pMilInterface.dispImage(m_iIndex), iCam)
#End If
    End Sub
End Class