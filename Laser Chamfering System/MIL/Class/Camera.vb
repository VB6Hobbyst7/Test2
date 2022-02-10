Imports Matrox.MatroxImagingLibrary

Imports PvDotNet
Imports PvGUIDotNet

Imports PvDotNet.PvImage

Imports System.Threading

Public Class Camera
    Inherits MIL
    Private strCam As String = "CAM_1"
    Private bStartCam As Boolean = False

    Private mDevice As PvDevice = New PvDevice
    Private mStream As PvStream = New PvStream
    Private mPipeline As PvPipeline = Nothing

    Private mThread As Thread = Nothing
    Private mIsStopping As Boolean = False
    Private mStep As Integer = 1

    Private mBuffer As PvDotNet.PvBuffer = Nothing

    Private mStCamera As New MyGigEDLL.bufferCvt

    'Friend WithEvents browser As PvGUIDotNet.PvGenBrowserControl

    ' State machine Step 1
    ' Connecting:
    ' 1. User selects the device
    ' 2. Device is connected
    ' 3. Stream is opened
    ' 4. Pipeline finally created (requires opened stream)
    Public Function Connecting() As Boolean

        'Dim lForm As PvDeviceFinderForm = New PvDeviceFinderForm
        'If lForm.ShowDialog() = DialogResult.OK Then

        Try
            '' Connect device
            'mDevice.Connect(lForm.Selected)
            ''mDevice.Connect(lForm.Set)
            '' Open stream
            'mStream.Open(lForm.Selected.IPAddress)

            'mDevice.Connect("CAM_1")
            mDevice.Connect(strCam)

            Dim info As PvDeviceInfo
            Dim sys As PvSystem = New PvSystem
            Dim interf As PvInterface

            sys.Find()
            For x As Integer = 0 To sys.InterfaceCount - 1
                interf = sys.GetInterface(x)
                For y As Integer = 0 To interf.DeviceCount - 1
                    info = interf.GetDeviceInfo(y)
                    If info IsNot Nothing Then

                        If info.UserDefinedName = strCam Then
                            mStream.Open(info.IPAddress)
                            ' Negotiate packete size
                            mDevice.NegotiatePacketSize()
                            ' Set stream destination to our stream object
                            mDevice.SetStreamDestination(mStream.LocalIPAddress, mStream.LocalPort)
                        End If
                    End If
                Next
            Next

            ' Set stream parameters/statistics on browser
            'browser.GenParameterArray = mStream.Parameters

            ' Create pipeline
            mPipeline = New PvPipeline(mStream)

            Return True

        Catch ex As PvException

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Close()
            Return False

        End Try

    End Function

    ' State machine step 2
    ' Configuring:
    ' 1. Negotiating ideal packet size
    ' 2. Setting stream destination on the device (to our PvStream)
    ' 3. Read payload size of the device
    ' 4. Configure pipeline: buffer size and buffer count
    Public Function Configuring() As Boolean

        Try
            ' Negotiate packet size. Failure means default value as configured on   ' the device is used.
            mDevice.NegotiatePacketSize()

        Catch ex As PvException

            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try

        ' Set stream destination
        mDevice.SetStreamDestination(mStream.LocalIPAddress, mStream.LocalPort)

        ' Read payload size, pre-allocate buffers of the pipeline
        Dim lPayloadSize As Int64 = mDevice.GenParameters.GetIntegerValue("PayloadSize")
        mPipeline.BufferSize = CType(lPayloadSize, UInt32)

        ' Set buffer count. Use more buffers (at expense of using more memory) to 
        ' eleminate missing block IDs
        mPipeline.BufferCount = 16

        Return True

    End Function

    ' State machine step 3
    ' Starting stream
    ' 1. Start the pipeline
    ' 2. Start the display thread
    ' 3. Set TLParamsLocked parameter of the device to 1
    ' 4. Execute the AcquisitionStart command on the device
    Public Sub StartingStream()

        ' Start (arm) the pipeline
        mPipeline.Start()

        ' Start display thread
        mThread = New Thread(AddressOf Me.ThreadProc)
        Dim lParameters As Object() = {Me}
        mIsStopping = False
        mThread.Start(lParameters)

        ' Set TLParamsLocked to 1
        mDevice.GenParameters.SetIntegerValue("TLParamsLocked", 1)

        ' Start acquisition on the device
        mDevice.GenParameters.ExecuteCommand("AcquisitionStart")

    End Sub

    ' State machine step 4
    ' Streaming:
    ' Here everything is handled through the display thread to free-up the 
    ' UI and keep the application responsive. State machine resumes when
    ' the Stop button is clicked.
    Public Function Streaming() As Boolean

        Dim bResult As Boolean

        bResult = bStartCam '쓰레드 돌때 변수 하나 받아서 처리하자. (쓰레드 상태 변수)

        If bResult = True Then
            Return True
        Else
            Return False
        End If

    End Function

    ' State machine step 5
    ' Stopping stream:
    ' 1. Execute the AcquisitionStop command on the device
    ' 2. Release TLParamsLocked parameter on the device (set it to 0)
    ' 3. Stop the display thread
    ' 4. Stop the pipeline
    Public Sub StoppingStream()

        ' Stop acquisition
        mDevice.GenParameters.ExecuteCommand("AcquisitionStop")

        ' Release TLParamsLocked
        mDevice.GenParameters.SetIntegerValue("TLParamsLocked", 0)

        ' Stop display thread
        mIsStopping = True
        mThread.Join()
        mThread = Nothing

        ' Stop the pipeline
        mPipeline.Stop()

    End Sub

    ' State machine step 6
    ' Disconnecting
    ' 1. Closing stream
    ' 2. Disconnect device
    Public Sub Disconnecting()

        ' Close stream
        mStream.Close()

        ' Disconnect device
        mDevice.Disconnect()

    End Sub

    ' Display thread:
    ' Until requested to exit, simply pumps buffers out of the pipeline
    ' and sends them to the display.
    Public Sub ThreadProc(ByVal aParameters As Object)

        Dim lParameters As Object() = CType(aParameters, Object())
        'Dim lMe As MainForm = CType(lParameters(0), MainForm)
        Dim lMe As Camera = CType(lParameters(0), Camera)

        Dim lBuffer As PvBuffer = Nothing



        Do

            If lMe.mIsStopping Then

                ' Signaled to terminate thread, return
                Return

            End If

            ' Retrieve next buffer from acquisition pipeline
            Dim lResult As PvResult = lMe.mPipeline.RetrieveNextBuffer(lBuffer)
            If lResult.IsOK Then

                ' Operation result of buffer is OK, display
                If lBuffer.OperationResult.IsOK Then

                    ' //////////////////////////////////////////////////////////////
                    ' Typically do your image processing/handling here
                    ' //////////////////////////////////////////////////////////////
                    mBuffer = lBuffer

                    ' Display image
                    'lMe.displayControl.Disp lay(lBuffer)
                    Dim tmpArr(mBuffer.Image.ImageSize - 1) As Byte
                    
                    mStCamera.SetPvBuffer(mBuffer)

                    Dim w As Integer = mBuffer.Image.Width   '1360
                    Dim h As Integer = mBuffer.Image.Height  '1040
                    mStCamera.GetBuffer(tmpArr, w - 1, h - 1)

                    'GYN - 2016.09.26
                    '여기서 Mil Buffer로 옮기면 끝이네..
                    MbufPut(pMilInterface.dispImage(0), tmpArr)
                    
                End If

                ' We got a buffer (good or not) we must release it back
                lMe.mPipeline.ReleaseBuffer(lBuffer)

            End If

        Loop

    End Sub

    Public Sub GrabtoDisplay(ByRef iCam As Object)
        'MbufPut(pMilInterface.dispImage(iCam), mBuffer.Image)
        MbufPut(pMilInterface.dispImage(0), iCam)

    End Sub

End Class