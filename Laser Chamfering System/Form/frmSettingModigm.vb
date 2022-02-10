Imports System.ComponentModel
Imports Modigm.Client.Library
Imports Modigm.Client.Wrapper

Public Class frmSettingModigm

    Public m_iIndex As Integer = 0
    Public Delegate Sub ReturnValues(notificationID As Integer, values As Object())
    Private pModigmClientWrapper As ModigmClientWrapper

    Private pModigmClientWrapper2 As ModigmClientWrapper

    Private pModigmClientWrapper3 As ModigmClientWrapper

    Private pModigmClientWrapper4 As ModigmClientWrapper

    Private SubID As Integer


    Public Sub frmSettingModigm()

    End Sub

    Public Sub FormSetting()

    End Sub


    Private Sub frmSettingModigm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        gbLaserSet.Text = "Laser #" & (Me.TabIndex + 1).ToString()

    End Sub

    Private Sub CreateDLLInstance()
        If pModigmClientWrapper Is Nothing Then
            pModigmClientWrapper = New ModigmClientWrapper(Me)
            pModigmClientWrapper.m_Client.m_callBackHandler = AddressOf UpdateCallBack
            pModigmClientWrapper.m_Client.m_connectionStatusCallBackHandler = AddressOf ConnectionStatusUpdateCallBack

            'pModigmClientWrapper2 = New ModigmClientWrapper(Me)

            'pModigmClientWrapper3 = New ModigmClientWrapper(Me)

            'pModigmClientWrapper4 = New ModigmClientWrapper(Me)

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If pModigmClientWrapper Is Nothing Then CreateDLLInstance()
        pModigmClientWrapper.Connect(TextBox1.Text, CheckBox1.Checked, TextBox2.Text, TextBox3.Text)

    End Sub

    '서버에서 보내진 Notification이 있을 경우 호출되는 콜백
    Private Function UpdateCallBack(syncObject As Object, id As Object, callback As Object, dataType As Type, dataObject As Object, timeStamp As Date) As Boolean
        Dim data(1) As Object
        Dim param(1) As Object

        data(0) = dataObject
        data(1) = TimeZoneInfo.ConvertTimeFromUtc(timeStamp, TimeZoneInfo.Local)

        param(0) = id
        param(1) = data

        'CreatSubsription()에서 등록된 subscription id에 해당하는 콜백 호출 
        syncObject.BeginInvoke(callback, param)
        Return True
    End Function

    Private Sub ConnectionStatusUpdateCallBack(status As ConnectionStatusType, timeStamp As DateTime)
        ToolStripStatusLabel1.Text = status.ToString() + "(" + TimeZoneInfo.ConvertTimeFromUtc(timeStamp, TimeZoneInfo.Local) + ")"
    End Sub

    'CreateSubscription()에 등록될 callback
    Private Sub TestCallback(notificationID As Integer, values As Object())
        Dim id As Integer
        Dim value As Object
        Dim timestamp As DateTime

        id = notificationID
        value = values(0)
        timestamp = values(1)

        TextBox5.Text = value.ToString()
        TextBox6.Text = timestamp.ToString("yyyy-MM-dd HH:mm:ss:ffff")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If pModigmClientWrapper Is Nothing Then CreateDLLInstance()

        If SubID > 0 Then
            pModigmClientWrapper.RemoveSubscription(SubID)
            TextBox5.Text = vbNullString
        End If

        Dim callback As ReturnValues
        callback = AddressOf TestCallback

        'Subscription 등록 반한되는 subscription ID로 내부적으로 subscription정보와 callback이 등록된다.
        SubID = pModigmClientWrapper.CreateSubscription(TextBox4.Text, Modigm.Client.Library.DataMonitoringMode.OnChangeReporting, 500, CType(callback, Object))
  
    End Sub

    Public Sub ShowFrm()
        On Error GoTo SysErr

        Me.Show()

        Exit Sub
SysErr:

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click

        Me.Hide()
        'Close()

    End Sub

End Class