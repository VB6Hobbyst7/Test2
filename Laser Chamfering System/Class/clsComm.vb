' Copyright (c) Microsoft Corporation. All rights reserved.
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Public Class Comm

    ' 필요한 클래스 변수와 해당 초기 값을 선언합니다.		
    Private mhRS As Integer = -1   ' 통신 포트에 대한 핸들입니다.									
    Private miPort As Integer = 1   ' 기본값은 COM1입니다.	
    Private miTimeout As Integer = 70   ' 시간 제한(ms)입니다.
    Private miBaudRate As Integer = 9600
    Private meParity As DataParity = 0
    Private meStopBit As DataStopBit = 0
    Private miDataBit As Integer = 8
    Private miBufferSize As Integer = 512   ' 기본 버퍼 크기를 512바이트로 지정합니다.
    Private mabtRxBuf As Byte()   ' 버퍼를 받습니다.	
    Private meMode As Mode  ' 클래스 작업 모드입니다.	
    Private mbWaitOnRead As Boolean
    Private mbWaitOnWrite As Boolean
    Private mbWriteErr As Boolean
    Private muOverlapped As OVERLAPPED
    Private muOverlappedW As OVERLAPPED
    Private muOverlappedE As OVERLAPPED
    Private mabtTmpTxBuf As Byte()  ' 비동기 Tx에서 사용되는 임시 버퍼입니다.
    Private moThreadTx As Thread
    Private moThreadRx As Thread
    Private miTmpBytes2Read As Integer
    Private meMask As EventMasks

#Region "열거형"

    ' 이 열거형은 데이터 패리티 값을 제공합니다.
    Public Enum DataParity
        Parity_None = 0
        Pariti_Odd
        Parity_Even
        Parity_Mark
    End Enum

    ' 이 열거형은 데이터 정지 비트 값을 제공합니다.
    ' 1부터 시작하도록 설정되므로 
    ' 열거형 값이 실제 값과 일치하게 됩니다.
    Public Enum DataStopBit
        StopBit_1 = 1
        StopBit_2
    End Enum

    ' 이 열거형에는 다양한 버퍼를 지우는 데 사용되는 값이 들어 있습니다.
    Private Enum PurgeBuffers
        RXAbort = &H2
        RXClear = &H8
        TxAbort = &H1
        TxClear = &H4
    End Enum

    ' 이 열거형은 통신 포트로 전송되는 줄에 대한 값을 제공합니다.
    Private Enum Lines
        SetRts = 3
        ClearRts = 4
        SetDtr = 5
        ClearDtr = 6
        ResetDev = 7   '	 가능한 경우 장치를 다시 설정합니다.
        SetBreak = 8   '	 장치 구분선을 설정합니다.
        ClearBreak = 9   '	 장치 구분선을 지웁니다.
    End Enum
    ' 주로 모뎀과 통신하고 있으므로
    ' 이 열거형은 모뎀 상태에 대한 값을 제공합니다.
    ' Flags() 특성은 값의 비트 조합을 허용하도록 
    ' 설정됩니다.
    <Flags()> Public Enum ModemStatusBits
        ClearToSendOn = &H10
        DataSetReadyOn = &H20
        RingIndicatorOn = &H40
        CarrierDetect = &H80
    End Enum

    ' 이 열거형은 작업 모드에 대한 값을 제공합니다.
    Public Enum Mode
        NonOverlapped
        Overlapped
    End Enum

    ' 이 열거형은 사용되는 통신 마스크에 대한 값을 제공합니다.
    ' Flags() 특성은 값의 비트 조합을 허용하도록 
    ' 설정됩니다.
    <Flags()> Public Enum EventMasks
        RxChar = &H1
        RXFlag = &H2
        TxBufferEmpty = &H4
        ClearToSend = &H8
        DataSetReady = &H10
        ReceiveLine = &H20
        Break = &H40
        StatusError = &H80
        Ring = &H100
    End Enum
#End Region

#Region "구조체"
    ' 다음은 Windows API 호출에서 사용되는 DCB 구조체입니다.
    <StructLayout(LayoutKind.Sequential, Pack:=1)> Private Structure DCB
        Public DCBlength As Integer
        Public BaudRate As Integer
        Public Bits1 As Integer
        Public wReserved As Int16
        Public XonLim As Int16
        Public XoffLim As Int16
        Public ByteSize As Byte
        Public Parity As Byte
        Public StopBits As Byte
        Public XonChar As Byte
        Public XoffChar As Byte
        Public ErrorChar As Byte
        Public EofChar As Byte
        Public EvtChar As Byte
        Public wReserved2 As Int16
    End Structure

    ' 다음은 Windows API 호출에서 사용되는 CommTimeOuts 구조체입니다.
    <StructLayout(LayoutKind.Sequential, Pack:=1)> Private Structure COMMTIMEOUTS
        Public ReadIntervalTimeout As Integer
        Public ReadTotalTimeoutMultiplier As Integer
        Public ReadTotalTimeoutConstant As Integer
        Public WriteTotalTimeoutMultiplier As Integer
        Public WriteTotalTimeoutConstant As Integer
    End Structure

    ' 다음은 Windows API 호출에서 사용되는 CommConfig 구조체입니다.
    <StructLayout(LayoutKind.Sequential, Pack:=1)> Private Structure COMMCONFIG
        Public dwSize As Integer
        Public wVersion As Int16
        Public wReserved As Int16
        Public dcbx As DCB
        Public dwProviderSubType As Integer
        Public dwProviderOffset As Integer
        Public dwProviderSize As Integer
        Public wcProviderData As Byte
    End Structure

    ' 다음은 Windows API 호출에서 사용되는 OverLapped 구조체입니다.
    <StructLayout(LayoutKind.Sequential, Pack:=1)> Public Structure OVERLAPPED
        Public Internal As Integer
        Public InternalHigh As Integer
        Public Offset As Integer
        Public OffsetHigh As Integer
        Public hEvent As Integer
    End Structure
#End Region

#Region "예외"

    ' 이 클래스는 사용자 지정 채널 예외를 정의합니다.
    ' 이 예외는 NACK이 발생할 때 발생합니다.
    Public Class CIOChannelException : Inherits ApplicationException
        Sub New(ByVal Message As String)
            MyBase.New(Message)
        End Sub
        Sub New(ByVal Message As String, ByVal InnerException As Exception)
            MyBase.New(Message, InnerException)
        End Sub
    End Class

    ' 이 클래스는 사용자 지정 시간 제한 예외를 정의합니다.
    Public Class IOTimeoutException : Inherits CIOChannelException
        Sub New(ByVal Message As String)
            MyBase.New(Message)
        End Sub
        Sub New(ByVal Message As String, ByVal InnerException As Exception)
            MyBase.New(Message, InnerException)
        End Sub
    End Class

#End Region

#Region "이벤트"
    ' 다음 이벤트를 통해 이 클래스를 사용하는 프로그램이 
    ' 통신 포트 이벤트에 반응할 수 있습니다.
    Public Event DataReceived(ByVal Source As Comm, ByVal DataBuffer() As Byte)
    Public Event TxCompleted(ByVal Source As Comm)
    Public Event CommEvent(ByVal Source As Comm, ByVal Mask As EventMasks)
#End Region

#Region "상수"
    ' 다음 상수는 코드를 보다 읽기 쉽게 만드는 데 사용됩니다.
    Private Const PURGE_RXABORT As Integer = &H2
    Private Const PURGE_RXCLEAR As Integer = &H8
    Private Const PURGE_TXABORT As Integer = &H1
    Private Const PURGE_TXCLEAR As Integer = &H4
    Private Const GENERIC_READ As Integer = &H80000000
    Private Const GENERIC_WRITE As Integer = &H40000000
    Private Const OPEN_EXISTING As Integer = 3
    Private Const INVALID_HANDLE_VALUE As Integer = -1
    Private Const IO_BUFFER_SIZE As Integer = 1024
    Private Const FILE_FLAG_OVERLAPPED As Integer = &H40000000
    Private Const ERROR_IO_PENDING As Integer = 997
    'Private Const WAIT_OBJECT_0 As Integer = 0
    Public Const WAIT_OBJECT_0 As Integer = 0
    Private Const ERROR_IO_INCOMPLETE As Integer = 996
    Private Const WAIT_TIMEOUT As Integer = &H102&
    Private Const INFINITE As Integer = &HFFFFFFFF


#End Region

#Region "속성"

    ' 이 속성은 BaudRate를 가져오거나 설정합니다.
    Public Property BaudRate() As Integer
        Get
            Return miBaudRate
        End Get
        Set(ByVal Value As Integer)
            miBaudRate = Value
        End Set
    End Property

    ' 이 속성은 BufferSize를 가져오거나 설정합니다.
    Public Property BufferSize() As Integer
        Get
            Return miBufferSize
        End Get
        Set(ByVal Value As Integer)
            miBufferSize = Value
        End Set
    End Property

    ' 이 속성은 DataBit를 가져오거나 설정합니다.
    Public Property DataBit() As Integer
        Get
            Return miDataBit
        End Get
        Set(ByVal Value As Integer)
            miDataBit = Value
        End Set
    End Property

    ' 이 쓰기 전용 속성은 DTR 줄을 설정하거나 다시 설정합니다.
    Public WriteOnly Property Dtr() As Boolean
        Set(ByVal Value As Boolean)
            If Not mhRS = -1 Then
                If Value Then
                    EscapeCommFunction(mhRS, Lines.SetDtr)
                Else
                    EscapeCommFunction(mhRS, Lines.ClearDtr)
                End If
            End If
        End Set
    End Property

    ' 이 읽기 전용 속성은 통신 포트로 들어오는 입력을 나타내는 
    ' 바이트 배열을 반환합니다.
    Overridable ReadOnly Property InputStream() As Byte()
        Get
            Return mabtRxBuf
        End Get
    End Property

    'New연산자 해제
    Dim m_pstrTemp As String = ""

    ' 이 읽기 전용 속성은 통신 포트로 들어오는 데이터를 나타내는 
    ' 문자열을 반환합니다.
    Overridable ReadOnly Property InputStreamString() As String
        'GYN - New 연산자 버그 수정.
        Get
            Dim oEncoder As New System.Text.ASCIIEncoding()
            'New연산자 해제
            m_pstrTemp = oEncoder.GetString(Me.InputStream)
            'Return oEncoder.GetString(Me.InputStream)
            oEncoder = Nothing
            Return m_pstrTemp

        End Get
    End Property

    ' 이 속성은 통신 포트의 열린 상태를 반환합니다.
    ReadOnly Property IsOpen() As Boolean
        Get
            Return CBool(mhRS <> -1)
        End Get
    End Property

    ' 이 읽기 전용 속성은 모뎀의 상태를 반환합니다.
    Public ReadOnly Property ModemStatus() As ModemStatusBits
        Get
            If mhRS = -1 Then
                Throw New ApplicationException("Please initialize and open " + _
                    "port before using this method")
            Else
                ' 모뎀 상태를 검색합니다.
                Dim lpModemStatus As Integer
                If Not GetCommModemStatus(mhRS, lpModemStatus) Then
                    Throw New ApplicationException("Unable to get modem status")
                Else
                    Return CType(lpModemStatus, ModemStatusBits)
                End If
            End If
        End Get
    End Property

    ' 이 속성은 패러티를 가져오거나 설정합니다.
    Public Property Parity() As DataParity
        Get
            Return meParity
        End Get
        Set(ByVal Value As DataParity)
            meParity = Value
        End Set
    End Property

    ' 이 속성은 포트를 가져오거나 설정합니다.
    Public Property Port() As Integer
        Get
            Return miPort
        End Get
        Set(ByVal Value As Integer)
            miPort = Value
        End Set
    End Property

    ' 이 쓰기 전용 속성은 RTS 줄을 설정하거나 다시 설정합니다.
    Public WriteOnly Property Rts() As Boolean
        Set(ByVal Value As Boolean)
            If Not mhRS = -1 Then
                If Value Then
                    EscapeCommFunction(mhRS, Lines.SetRts)
                Else
                    EscapeCommFunction(mhRS, Lines.ClearRts)
                End If
            End If
        End Set
    End Property

    ' 이 속성은 정지 비트를 가져오거나 설정합니다.
    Public Property StopBit() As DataStopBit
        Get
            Return meStopBit
        End Get
        Set(ByVal Value As DataStopBit)
            meStopBit = Value
        End Set
    End Property

    ' 이 속성은 시간 제한을 가져오거나 설정합니다.
    Public Overridable Property Timeout() As Integer
        Get
            Return miTimeout
        End Get
        Set(ByVal Value As Integer)
            miTimeout = CInt(IIf(Value = 0, 500, Value))
            ' 포트가 열려 있으면 즉시 업데이트합니다.
            pSetTimeout()
        End Set
    End Property

    ' 이 속성은 작업 모드를 가져오거나, 겹쳐진 모드 또는 겹쳐지지 않은
    ' 모드로 작업 모드를 설정합니다.
    Public Property WorkingMode() As Mode
        Get
            Return meMode
        End Get
        Set(ByVal Value As Mode)
            meMode = Value
        End Set
    End Property

#End Region

#Region "Win32API"
    ' 다음 함수는 통신 포트와 통신하는 데 필요한 
    ' 필수 Win32 함수입니다.

    <DllImport("kernel32.dll")> Private Shared Function BuildCommDCB( _
        ByVal lpDef As String, ByRef lpDCB As DCB) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function ClearCommError( _
        ByVal hFile As Integer, ByVal lpErrors As Integer, _
        ByVal l As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function CloseHandle( _
        ByVal hObject As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function CreateEvent( _
        ByVal lpEventAttributes As Integer, ByVal bManualReset As Integer, _
        ByVal bInitialState As Integer, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpName As String) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function CreateFile( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpFileName As String, _
        ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, _
        ByVal lpSecurityAttributes As Integer, _
        ByVal dwCreationDisposition As Integer, _
        ByVal dwFlagsAndAttributes As Integer, _
        ByVal hTemplateFile As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function EscapeCommFunction( _
        ByVal hFile As Integer, ByVal ifunc As Long) As Boolean
    End Function

    <DllImport("kernel32.dll")> Private Shared Function FormatMessage( _
        ByVal dwFlags As Integer, ByVal lpSource As Integer, _
        ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal lpBuffer As String, _
        ByVal nSize As Integer, ByVal Arguments As Integer) As Integer
    End Function

    Private Declare Function FormatMessage Lib "kernel32" Alias _
     "FormatMessageA" (ByVal dwFlags As Integer, ByVal lpSource As Integer, _
     ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, _
     ByVal lpBuffer As StringBuilder, ByVal nSize As Integer, _
     ByVal Arguments As Integer) As Integer

    <DllImport("kernel32.dll")> Public Shared Function GetCommModemStatus( _
        ByVal hFile As Integer, ByRef lpModemStatus As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")> Private Shared Function GetCommState( _
        ByVal hCommDev As Integer, ByRef lpDCB As DCB) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function GetCommTimeouts( _
        ByVal hFile As Integer, ByRef lpCommTimeouts As COMMTIMEOUTS) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function GetLastError() As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function GetOverlappedResult( _
        ByVal hFile As Integer, ByRef lpOverlapped As OVERLAPPED, _
        ByRef lpNumberOfBytesTransferred As Integer, _
        ByVal bWait As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function PurgeComm( _
        ByVal hFile As Integer, ByVal dwFlags As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function ReadFile( _
        ByVal hFile As Integer, ByVal Buffer As Byte(), _
        ByVal nNumberOfBytesToRead As Integer, _
        ByRef lpNumberOfBytesRead As Integer, _
        ByRef lpOverlapped As OVERLAPPED) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function SetCommTimeouts( _
        ByVal hFile As Integer, ByRef lpCommTimeouts As COMMTIMEOUTS) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function SetCommState( _
        ByVal hCommDev As Integer, ByRef lpDCB As DCB) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function SetupComm( _
        ByVal hFile As Integer, ByVal dwInQueue As Integer, _
        ByVal dwOutQueue As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function SetCommMask( _
        ByVal hFile As Integer, ByVal lpEvtMask As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Private Shared Function WaitCommEvent( _
        ByVal hFile As Integer, ByRef Mask As EventMasks, _
        ByRef lpOverlap As OVERLAPPED) As Integer
    End Function

    '<DllImport("kernel32.dll")> Private Shared Function WaitForSingleObject( _
    <DllImport("kernel32.dll")> Public Shared Function WaitForSingleObject( _
        ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> Public Shared Function ReleaseMutex( _
        ByVal hHandle As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")> Private Shared Function WriteFile( _
        ByVal hFile As Integer, ByVal Buffer As Byte(), _
        ByVal nNumberOfBytesToWrite As Integer, _
        ByRef lpNumberOfBytesWritten As Integer, _
        ByRef lpOverlapped As OVERLAPPED) As Integer
    End Function

#End Region

#Region "메서드"

    ' 이 서브루틴은 스레드를 호출하여 비동기 읽기를 수행합니다.
    ' 이 루틴은 직접 호출하지 말고 
    ' 클래스를 통해 사용해야 합니다.
    Public Sub R()
        Dim iRet As Integer = Read(miTmpBytes2Read)
    End Sub

    ' 이 서브루틴은 스레드를 호출하여 비동기 쓰기를 수행합니다.
    ' 이 루틴은 직접 호출하지 말고 
    ' 클래스를 통해 사용해야 합니다.
    Public Sub W()
        Write(mabtTmpTxBuf)
    End Sub

    ' 이 서브루틴은 다른 스레드를 사용하여 통신 포트에서 읽기를 수행합니다.
    ' 완료되면 RxCompleted가 발생합니다. 이 서브루틴은 정수를 읽습니다.
    Public Overloads Sub AsyncRead(ByVal Bytes2Read As Integer)
        If meMode <> Mode.Overlapped Then Throw New ApplicationException( _
            "Async Methods allowed only when WorkingMode=Overlapped")
        miTmpBytes2Read = Bytes2Read
        moThreadTx = New Thread(AddressOf R)
        moThreadTx.Start()
    End Sub

    ' 이 서브루틴은 다른 스레드를 사용하여 통신 포트에서 쓰기를 수행합니다.
    ' 완료되면 TxCompleted가 발생합니다. 이 서브루틴은 바이트 배열을 씁니다.
    Public Overloads Sub AsyncWrite(ByVal Buffer() As Byte)
        If meMode <> Mode.Overlapped Then Throw New ApplicationException( _
            "Async Methods allowed only when WorkingMode=Overlapped")
        If mbWaitOnWrite = True Then Throw New ApplicationException( _
            "Unable to send message because of pending transmission.")
        mabtTmpTxBuf = Buffer
        moThreadTx = New Thread(AddressOf W)
        moThreadTx.Start()
    End Sub

    ' 이 서브루틴은 다른 스레드를 사용하여 통신 포트에서 쓰기를 수행합니다.
    ' 완료되면 TxCompleted가 발생합니다. 이 서브루틴은 문자열을 씁니다.
    Public Overloads Sub AsyncWrite(ByVal Buffer As String)

        Dim oEncoder As New System.Text.ASCIIEncoding()

        Dim aByte() As Byte = oEncoder.GetBytes(Buffer)
        Me.AsyncWrite(aByte)
        'New연산자 해제
        oEncoder = Nothing
        aByte = Nothing

    End Sub

    ' 이 함수는 ModemStatusBits를 사용하고 
    ' 모뎀이 활성 상태인지 여부를 나타내는 부울 값을 반환합니다.
    Public Function CheckLineStatus(ByVal Line As ModemStatusBits) As Boolean
        Return Convert.ToBoolean(ModemStatus And Line)
    End Function

    ' 이 서브루틴은 입력 버퍼를 지웁니다.
    Public Sub ClearInputBuffer()
        If Not mhRS = -1 Then
            PurgeComm(mhRS, PURGE_RXCLEAR)
        End If
    End Sub

    ' 이 서브루틴은 통신 포트를 닫습니다.
    Public Sub Close()
        If mhRS <> -1 Then
            CloseHandle(mhRS)
            mhRS = -1
        End If
    End Sub

    ' 이 서브루틴은 통신 포트를 열고 초기화합니다.
    Public Overloads Sub Open()
        ' DCB 블록을 가져와 현재 데이터로 업데이트합니다.
        Dim uDcb As DCB, iRc As Integer
        ' 작업 모드를 설정합니다.
        Dim iMode As Integer = Convert.ToInt32(IIf(meMode = Mode.Overlapped, _
            FILE_FLAG_OVERLAPPED, 0))
        ' 통신 포트를 초기화합니다.
        If miPort > 0 Then
            Try
                ' COM 포트 스트림 핸들을 만듭니다.
                ' COM 포트 10번이상 사용할경우 앞에 \\.\을 
                mhRS = CreateFile("\\.\COM" & miPort.ToString, _
                                 GENERIC_READ Or GENERIC_WRITE, 0, 0, _
                                OPEN_EXISTING, iMode, 0)
                If mhRS <> -1 Then
                    ' 모든 통신 오류를 지웁니다.
                    Dim lpErrCode As Integer
                    iRc = ClearCommError(mhRS, lpErrCode, 0&)
                    ' I/O 버퍼를 지웁니다.
                    iRc = PurgeComm(mhRS, PurgeBuffers.RXClear Or _
                        PurgeBuffers.TxClear)
                    ' COM 설정을 가져옵니다.
                    iRc = GetCommState(mhRS, uDcb)
                    ' COM 설정을 업데이트합니다.
                    Dim sParity As String = "NOEM"
                    sParity = sParity.Substring(meParity, 1)
                    ' DCB 상태를 설정합니다.
                    Dim sDCBState As String = String.Format( _
                        "baud={0} parity={1} data={2} stop={3}", _
                        miBaudRate, sParity, miDataBit, CInt(meStopBit))
                    iRc = BuildCommDCB(sDCBState, uDcb)
                    iRc = SetCommState(mhRS, uDcb)
                    If iRc = 0 Then
                        Dim sErrTxt As String = pErr2Text(GetLastError())
                        Throw New CIOChannelException( _
                            "Unable to set COM state0" & sErrTxt)
                    End If
                    ' 버퍼(Rx,Tx)를 설정합니다.
                    iRc = SetupComm(mhRS, miBufferSize, miBufferSize)
                    ' 시간 제한을 설정합니다.
                    pSetTimeout()
                Else
                    ' 초기화 문제를 발생시킵니다.
                    Throw New CIOChannelException( _
                        "Unable to open COM" & miPort.ToString)
                End If
            Catch Ex As Exception
                ' 일반 오류입니다.
                Throw New CIOChannelException(Ex.Message, Ex)
            End Try
        Else
            ' 포트가 정의되어 있지 않으므로 열 수 없습니다.
            Throw New ApplicationException("COM Port not defined, " + _
                "use Port property to set it before invoking InitPort")
        End If
    End Sub

    ' 이 서브루틴은 통신 포트를 열고 초기화합니다.
    ' 이 서브루틴은 매개 변수를 지원하기 위해 오버로드됩니다.
    Public Overloads Sub Open(ByVal Port As Integer, _
        ByVal BaudRate As Integer, ByVal DataBit As Integer, _
        ByVal Parity As DataParity, ByVal StopBit As DataStopBit, _
        ByVal BufferSize As Integer)

        Me.Port = Port
        Me.BaudRate = BaudRate
        Me.DataBit = DataBit
        Me.Parity = Parity
        Me.StopBit = StopBit
        Me.BufferSize = BufferSize
        Open()
    End Sub

    ' 이 함수는 API 오류 코드를 텍스트로 변환합니다.
    Private Function pErr2Text(ByVal lCode As Integer) As String

        Dim strTemp As String = ""
        Dim sRtrnCode As New StringBuilder(256)
        Dim lRet As Integer

        lRet = FormatMessage(&H1000, 0, lCode, 0, sRtrnCode, 256, 0)
        If lRet > 0 Then
            'New연산자 해제
            strTemp = sRtrnCode.ToString
            sRtrnCode = Nothing
            Return strTemp
        Else
            'New연산자 해제
            sRtrnCode = Nothing
            Return "Error not found."

        End If

    End Function

    ' 이 서브루틴은 겹쳐진 읽기를 처리합니다.
    Private Sub pHandleOverlappedRead(ByVal Bytes2Read As Integer)
        Dim iReadChars, iRc, iRes, iLastErr As Integer
        muOverlapped.hEvent = CreateEvent(Nothing, 1, 0, Nothing)
        If muOverlapped.hEvent = 0 Then
            ' 이벤트를 만들 수 없습니다.
            Throw New ApplicationException( _
                "Error creating event for overlapped read.")
        Else
            ' 겹쳐진 읽기입니다.
            If mbWaitOnRead = False Then
                ReDim mabtRxBuf(Bytes2Read - 1)
                iRc = ReadFile(mhRS, mabtRxBuf, Bytes2Read, _
                    iReadChars, muOverlapped)
                If iRc = 0 Then
                    iLastErr = GetLastError()
                    If iLastErr <> ERROR_IO_PENDING Then
                        Throw New ArgumentException("Overlapped Read Error: " & _
                            pErr2Text(iLastErr))
                    Else
                        ' 플래그를 설정합니다.
                        mbWaitOnRead = True
                    End If
                Else
                    ' 읽기가 완료되었습니다.
                    RaiseEvent DataReceived(Me, mabtRxBuf)
                End If
            End If
        End If
        ' 작업이 완료될 때까지 기다립니다.
        If mbWaitOnRead Then
            iRes = WaitForSingleObject(muOverlapped.hEvent, miTimeout)
            Select Case iRes
                Case WAIT_OBJECT_0
                    ' 개체 신호를 받았습니다. 작업이 완료되었습니다.
                    If GetOverlappedResult(mhRS, muOverlapped, _
                        iReadChars, 0) = 0 Then

                        ' 작업 오류입니다.
                        iLastErr = GetLastError()
                        If iLastErr = ERROR_IO_INCOMPLETE Then
                            Throw New ApplicationException( _
                                "Read operation incomplete")
                        Else
                            Throw New ApplicationException( _
                                "Read operation error " & iLastErr.ToString)
                        End If
                    Else
                        ' 작업이 완료되었습니다.
                        RaiseEvent DataReceived(Me, mabtRxBuf)
                        mbWaitOnRead = False
                    End If
                Case WAIT_TIMEOUT
                    Throw New IOTimeoutException("Timeout error")
                Case Else
                    Throw New ApplicationException("Overlapped read error")
            End Select
        End If
    End Sub

    ' 이 서브루틴은 겹쳐진 쓰기를 처리합니다.
    Private Function pHandleOverlappedWrite(ByVal Buffer() As Byte) As Boolean
        Dim iBytesWritten, iRc, iLastErr, iRes As Integer, bErr As Boolean
        muOverlappedW.hEvent = CreateEvent(Nothing, 1, 0, Nothing)
        If muOverlappedW.hEvent = 0 Then
            ' 이벤트를 만들 수 없습니다.
            Throw New ApplicationException( _
                "Error creating event for overlapped write.")
        Else
            ' 겹쳐진 쓰기입니다.
            PurgeComm(mhRS, PURGE_RXCLEAR Or PURGE_TXCLEAR)
            mbWaitOnRead = True
            iRc = WriteFile(mhRS, Buffer, Buffer.Length, _
                iBytesWritten, muOverlappedW)
            If iRc = 0 Then
                iLastErr = GetLastError()
                If iLastErr <> ERROR_IO_PENDING Then
                    Throw New ArgumentException("Overlapped Read Error: " & _
                        pErr2Text(iLastErr))
                Else
                    ' 쓰기가 대기 중입니다.
                    iRes = WaitForSingleObject(muOverlappedW.hEvent, INFINITE)
                    Select Case iRes
                        Case WAIT_OBJECT_0
                            ' 개체 신호를 받았습니다. 작업이 완료되었습니다.
                            If GetOverlappedResult(mhRS, muOverlappedW, _
                                iBytesWritten, 0) = 0 Then

                                bErr = True
                            Else
                                ' Async tx가 완료되었음을 알립니다. 스레드가 중지됩니다.
                                mbWaitOnRead = False
                                RaiseEvent TxCompleted(Me)
                            End If
                    End Select
                End If
            Else
                ' 대기 작업이 즉시 완료되었습니다.
                bErr = False
            End If
        End If
        CloseHandle(muOverlappedW.hEvent)
        Return bErr
    End Function

    ' 이 서브루틴은 통신 포트 시간 제한을 설정합니다.
    Private Sub pSetTimeout()
        Dim uCtm As COMMTIMEOUTS
        ' 통신 시간 제한을 설정합니다.
        If mhRS = -1 Then
            Exit Sub
        Else
            ' 즉시 설정을 변경합니다.
            With uCtm
                .ReadIntervalTimeout = 0
                .ReadTotalTimeoutMultiplier = 0
                .ReadTotalTimeoutConstant = miTimeout
                .WriteTotalTimeoutMultiplier = 10
                .WriteTotalTimeoutConstant = 100
            End With
            SetCommTimeouts(mhRS, uCtm)
        End If
    End Sub

    ' 이 함수는 통신 포트에서 읽는 바이트 수를 지정하는 
    ' 정수를 반환합니다. 이 함수에는 읽을 바이트 수를 지정하는 
    ' 매개 변수가 사용됩니다.
    Public Function Read(ByVal Bytes2Read As Integer) As Integer
        Dim iReadChars, iRc As Integer

        ' 읽을 바이트(Bytes2Read)가 지정되어 있지 않으면 버퍼 크기를 사용합니다.
        If Bytes2Read = 0 Then Bytes2Read = miBufferSize
        If mhRS = -1 Then
            Throw New ApplicationException( _
                "Please initialize and open port before using this method")
        Else
            ' 포트에서 바이트를 가져옵니다.
            Try
                ' 버퍼를 지웁니다.
                'PurgeComm(mhRS, PURGE_RXCLEAR Or PURGE_TXCLEAR)
                ' 겹쳐진 작업에 대한 이벤트를 만듭니다.
                If meMode = Mode.Overlapped Then
                    pHandleOverlappedRead(Bytes2Read)
                Else
                    ' 겹쳐지지 않은 모드입니다.
                    ReDim mabtRxBuf(Bytes2Read - 1)
                    iRc = ReadFile(mhRS, mabtRxBuf, Bytes2Read, iReadChars, Nothing)
                    If iRc = 0 Then
                        ' 읽기 오류입니다.
                        Throw New ApplicationException( _
                            "ReadFile error " & iRc.ToString)
                    Else
                        ' 시간 제한을 처리하거나 입력 문자를 반환합니다.
                        If iReadChars < Bytes2Read Then
                            Throw New IOTimeoutException("Timeout error")
                        Else
                            mbWaitOnRead = True
                            Return (iReadChars)
                        End If
                    End If
                End If
            Catch Ex As Exception
                ' 다른 일반 오류입니다.
                Throw New ApplicationException("Read Error: " & Ex.Message, Ex)
            End Try
        End If
    End Function
    
    ' 이 함수는 통신 포트에서 읽는 바이트 수를 지정하는 
    ' 정수를 반환합니다. 이 함수에는 읽을 바이트 수를 지정하는 
    ' 매개 변수가 사용됩니다.
    ' 20141031 lsuny
    Public Function ReadEx(ByVal Bytes2Read As Integer) As Integer
        Dim iReadChars, iRc As Integer

        ' 읽을 바이트(Bytes2Read)가 지정되어 있지 않으면 버퍼 크기를 사용합니다.
        If Bytes2Read = 0 Then Bytes2Read = miBufferSize
        If mhRS = -1 Then
            Throw New ApplicationException( _
                "Please initialize and open port before using this method")
        Else
            ' 포트에서 바이트를 가져옵니다.
            Try
                ' 버퍼를 지웁니다.
                'PurgeComm(mhRS, PURGE_RXCLEAR Or PURGE_TXCLEAR)
                ' 겹쳐진 작업에 대한 이벤트를 만듭니다.
                If meMode = Mode.Overlapped Then
                    pHandleOverlappedRead(Bytes2Read)
                Else
                    ' 겹쳐지지 않은 모드입니다.
                    Dim tmpRxBuf(Bytes2Read - 1) As Byte
                    iRc = ReadFile(mhRS, tmpRxBuf, Bytes2Read, iReadChars, Nothing)
                    ReDim mabtRxBuf(iReadChars - 1)
                    For i As Integer = 0 To mabtRxBuf.Length - 1
                        mabtRxBuf(i) = tmpRxBuf(i)
                    Next

                    If iRc = 0 Then
                        ' 읽기 오류입니다.
                        Throw New ApplicationException( _
                            "ReadFile error " & iRc.ToString)
                    Else
                        ' 시간 제한을 처리하거나 입력 문자를 반환합니다.
                        'If iReadChars < Bytes2Read Then
                        '    Throw New IOTimeoutException("Timeout error")
                        'Else
                        mbWaitOnRead = True
                        Return (iReadChars)
                        'End If
                    End If
                End If
            Catch Ex As Exception
                ' 다른 일반 오류입니다.
                Throw New ApplicationException("Read Error: " & Ex.Message, Ex)
            End Try
        End If
    End Function


    ' 이 서브루틴은 전달된 바이트 배열을
    ' 통신 포트에 씁니다.
    Public Overloads Sub Write(ByVal Buffer As Byte())
        Dim iBytesWritten, iRc As Integer

        If mhRS = -1 Then
            Throw New ApplicationException( _
                "Please initialize and open port before using this method")
        Else
            ' 데이터를 COM 포트로 전송합니다.
            Try
                If meMode = Mode.Overlapped Then
                    ' 겹쳐진 쓰기입니다.
                    If pHandleOverlappedWrite(Buffer) Then
                        Throw New ApplicationException( _
                            "Error in overllapped write")
                    End If
                Else
                    ' IO 버퍼를 지웁니다.
                    PurgeComm(mhRS, PURGE_RXCLEAR Or PURGE_TXCLEAR)
                    iRc = WriteFile(mhRS, Buffer, Buffer.Length, _
                        iBytesWritten, Nothing)
                    If iRc = 0 Then
                        Throw New ApplicationException( _
                            "Write Error - Bytes Written " & _
                            iBytesWritten.ToString & " of " & _
                            Buffer.Length.ToString)
                    End If
                End If
            Catch Ex As Exception
                Throw
            End Try
        End If
    End Sub

    ' 이 서브루틴은 전달된 문자열을 
    ' 통신 포트에 씁니다.
    Public Overloads Sub Write(ByVal Buffer As String)
        Dim oEncoder As New System.Text.ASCIIEncoding()
        Dim aByte() As Byte = oEncoder.GetBytes(Buffer)
        Me.Write(aByte)

        'New연산자 해제
        oEncoder = Nothing
        aByte = Nothing

    End Sub

    Public Overloads Sub WriteChiller(ByVal Buffer As String)

        Dim aByte() As Byte = {}
        ReDim aByte(Buffer.Length - 1)
        
        aByte(0) = "&H" & Buffer.Substring(0, 2)
        aByte(1) = "&H" & Buffer.Substring(2, 2)
        aByte(2) = "&H" & Buffer.Substring(4, 2)
        aByte(3) = "&H" & Buffer.Substring(6, 2)
        aByte(4) = "&H" & Buffer.Substring(8, 2)
        aByte(5) = "&H" & Buffer.Substring(10, 2)

        Me.Write(aByte)

        'New연산자 해제
        aByte = Nothing

    End Sub

#End Region


End Class



