Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports System.Threading
Imports Microsoft.Win32
Imports System.Security.Permissions

Class Utility
    Private Shared LockThis As New Object()

    <DllImport("user32.dll")> _
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInt32, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function


    Public Shared Sub SendMsg(ByVal nWindowName As String, ByVal nMSGEvent As UInteger, ByVal WParam As Integer, ByVal LParam As Integer)
        Dim hWnd As Integer = CInt(FindWindow(Nothing, nWindowName))

        If hWnd > 0 Then
            SendMessage(hWnd, nMSGEvent, WParam, LParam)
        End If
    End Sub

    Public Shared Function Get_CenterPos(ByVal nSrcPos As Integer, ByVal nSrcWidth As Integer, ByVal nDstWidth As Integer) As Integer
        Return nSrcPos + CInt((nSrcWidth - nDstWidth) \ 2)
    End Function

    Public Shared Sub Get_CenterPos(ByVal nSizeX As Integer, ByVal nSizeY As Integer, ByRef rtnX As Integer, ByRef rtnY As Integer)
        Dim ScreenX As Integer, ScreenY As Integer

        ScreenX = SystemInformation.VirtualScreen.Width
        ScreenY = SystemInformation.VirtualScreen.Height

        rtnX = CInt((ScreenX \ 2) - (nSizeX \ 2))
        rtnY = CInt((ScreenY \ 2) - (nSizeY \ 2))
    End Sub

    Public Shared Function FormSearch(ByVal nWindowName As String) As Integer
        Dim iRet As Integer = 0
        Try
            'return FindWindow(null, nWindowName);
            iRet = FindWindow(Nothing, nWindowName)
        Catch generatedExceptionName As Exception
            iRet = 0
        End Try

        Return iRet
    End Function

    Public Shared Function SearchProcess(ByVal nProcessName As String) As Boolean
        Dim p As Process() = Process.GetProcessesByName(nProcessName)
        If p.GetLength(0) > 0 Then
            Return True
        End If

        Return False
    End Function
    Public Shared Sub KillProcess(ByVal nProcessName As String)
        For Each proc As Process In Process.GetProcesses()
            If proc.ProcessName.StartsWith(nProcessName) Then
                proc.Kill()
            End If
        Next
    End Sub

    Public Shared Function GetReleaseDate() As String
        Dim FileName As String = Application.ExecutablePath

        Dim time As DateTime = File.GetLastWriteTime(FileName)

        Dim rtnData As String = ""
        rtnData = String.Format("{0:0000}. {1:00}. {2:00}", time.Year, time.Month, time.Day)

        Return rtnData
    End Function

    Public Shared Sub FolderEditCheck(ByVal nPath As String)
        SyncLock LockThis

            Dim dir As New DirectoryInfo(nPath)

            If Not dir.Exists Then
                Createfolder(nPath)
            End If

            'New연산자 해제
            dir = Nothing

        End SyncLock
    End Sub

    Public Shared Sub Createfolder(ByVal nPath As String)
        SyncLock LockThis
            Try
                Dim strSplitPath As String() = nPath.Split("\"c)
                Dim strsumPath As String = ""

                For i As Integer = 0 To strSplitPath.Length - 1
                    strsumPath += strSplitPath(i)
                    strsumPath += "\"

                    Dim dir As New DirectoryInfo(strsumPath)

                    If Not dir.Exists Then
                        dir.Create()
                    End If

                    'New연산자 해제
                    dir = Nothing

                Next

            Catch ex As Exception
            End Try
        End SyncLock
    End Sub

    Public Shared Function NowFolderPath() As String
        Dim curPath As String = Application.ExecutablePath
        Dim len As Integer = curPath.LastIndexOf("\")
        curPath = curPath.Substring(0, len + 1)

        Return curPath
    End Function

    Public Shared Sub CopyFolder(ByVal SrcFolder As String, ByVal DstFolder As String)
        Try
            If Not Directory.Exists(DstFolder) Then
                Directory.CreateDirectory(DstFolder)

                Dim files As String() = Directory.GetFiles(SrcFolder)
                Dim folders As String() = Directory.GetDirectories(SrcFolder)

                For Each file__1 As String In files
                    Dim name As String = Path.GetFileName(file__1)
                    Dim dest As String = Path.Combine(DstFolder, name)
                    File.Copy(file__1, dest, True)
                Next

                For Each folder As String In folders
                    Dim name As String = Path.GetFileName(folder)
                    Dim dest As String = Path.Combine(DstFolder, name)
                    CopyFolder(folder, dest)
                Next

            End If

        Catch e As Exception
        End Try
    End Sub

    Public Shared Function SearchFileName(ByVal strFolder As String, ByVal strSearchName As String) As String
        Try
            If Directory.Exists(strFolder) Then
                Dim files As String() = Directory.GetFiles(strFolder)
                Dim folders As String() = Directory.GetDirectories(strFolder)

                For Each file As String In files
                    Dim name As String = Path.GetFileName(file)
                    If name.Contains(strSearchName) Then
                        Return String.Format("{0:s}\{1:s}", strFolder, name)
                    End If
                Next

                For Each folder As String In folders
                    Dim name As String = Path.GetFileName(folder)
                    Dim FullName As String = strFolder & "\" & name

                    SearchFileName(FullName, strSearchName)
                Next
            End If


            Return ""
        Catch e As Exception
            Return ""
        End Try
    End Function

    Public Shared Function MoveFile(ByVal SrcFolder As String, ByVal DstFolder As String) As Boolean
        Try
            CopyFolder(SrcFolder, DstFolder)
            Directory.Delete(SrcFolder)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Get_UseHDDSpace(ByVal nDrive As String) As Single
        Dim drive As New DriveInfo(nDrive)

        Dim totalSize As Long = drive.TotalSize \ 1024 \ 1024
        Dim FreeSize As Long = drive.TotalFreeSpace \ 1024 \ 1024

        Dim tmpFreeSpaceRate As Single = CSng(CSng(FreeSize) / CSng(totalSize)) * 100.0F

        'New연산자 해제
        drive = Nothing

        Return tmpFreeSpaceRate
    End Function



    Public Shared Sub StdDev(ByVal nValue As Single(), ByRef rtnAvg As Single, ByRef rtnStdDev As Single)

        Dim dSum As Single = 0.0F
        Dim iCount As Integer = nValue.Length

        Dim Result_Avg As Single = 0.0F
        Dim Result_StdDev As Single = 0.0F

        For i As Integer = 0 To iCount - 1
            dSum += nValue(i)
        Next

        Result_Avg = CSng(dSum / iCount)

        dSum = 0.0F

        For i As Integer = 0 To iCount - 1
            dSum += Math.Abs(nValue(i) - Result_Avg)
        Next

        Result_StdDev = CSng(dSum / iCount)

        rtnAvg = Result_Avg
        rtnStdDev = Result_StdDev
    End Sub

    Public Shared Sub StdDev(ByVal nValue As Byte(), ByRef rtnAvg As Single, ByRef rtnStdDev As Single)

        Dim dSum As Single = 0.0F
        Dim iCount As Integer = nValue.Length

        Dim Result_Avg As Single = 0.0F
        Dim Result_StdDev As Single = 0.0F

        For i As Integer = 0 To iCount - 1
            dSum += nValue(i)
        Next

        Result_Avg = CSng(dSum / iCount)

        dSum = 0.0F

        For i As Integer = 0 To iCount - 1
            dSum += Math.Abs(nValue(i) - Result_Avg)
        Next

        Result_StdDev = CSng(dSum / iCount)

        rtnAvg = Result_Avg
        rtnStdDev = Result_StdDev
    End Sub

    Public Shared Function Get_MaxValue(ByVal nValue As Single()) As Single
        Dim iCount As Integer = nValue.Length
        Dim fValue As Single = 0.0F

        For i As Integer = 0 To iCount - 1
            If nValue(i) > fValue Then
                fValue = nValue(i)
            End If
        Next

        Return fValue
    End Function

    Public Shared Function Get_MinValue(ByVal nValue As Single()) As Single
        Dim iCount As Integer = nValue.Length
        Dim fValue As Single = 0.0F

        For i As Integer = 0 To iCount - 1
            If nValue(i) > fValue Then
                fValue = nValue(i)
            End If
        Next

        For i As Integer = 0 To iCount - 1
            If nValue(i) < fValue Then
                fValue = nValue(i)
            End If
        Next

        Return fValue
    End Function

    Public Shared Function Max(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim rtnData As Integer = 0
        rtnData = If((a > b), a, b)

        Return rtnData
    End Function

    Public Shared Function Max(ByVal a As Double, ByVal b As Double) As Double
        Dim rtnData As Double = 0
        rtnData = If((a > b), a, b)

        Return rtnData
    End Function

    Public Shared Function Min(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim rtnData As Integer = 0
        rtnData = If((a > b), b, a)

        Return rtnData
    End Function

    Public Shared Function Min(ByVal a As Double, ByVal b As Double) As Double
        Dim rtnData As Double = 0
        rtnData = If((a > b), b, a)

        Return rtnData
    End Function

    Public Shared Function HexToBin(ByVal nHexData As String, ByVal nBinCount As Integer) As String

        Dim iDec As Integer = 0
        Dim InputData As Integer = 0
        Dim processA As Integer = 0
        Dim sData As String = ""
        Dim sum As String = ""
        Dim Msum As String = ""

        Try
            iDec = Convert.ToInt16(nHexData, 16)
            InputData = iDec

            If iDec <> 0 Then
                While InputData > 1
                    processA = CInt(InputData Mod 2)
                    InputData = CInt(InputData \ 2)
                    sData = processA.ToString()
                    sum = sData & sum
                End While
            Else
                sum = "0"
            End If

            sData = InputData.ToString()
            sum = sData & sum

            Msum = sum

            If Msum.Length < nBinCount Then
                For i As Integer = 0 To (nBinCount - Msum.Length) - 1
                    sum = "0" & sum
                Next
            End If

            Msum = sum
        Catch e As Exception
            sum = ""
            For i As Integer = 0 To nBinCount - 1
                sum = "0" & sum

            Next
        End Try

        Return Msum

    End Function


    Public Shared Sub WaitSecs(ByVal Milisecond As Integer)
        Dim startTime As Integer = Environment.TickCount
        Dim endTime As Integer = Environment.TickCount

        Do
            Thread.Sleep(10)
            Application.DoEvents()

            endTime = Environment.TickCount
        Loop While Math.Abs(endTime - startTime) < Milisecond
    End Sub

    Public Shared Sub WriteRegistry(ByVal nKey As String, ByVal nValue As String)
        Dim RegRoot As String = "Software\PRI\Setting"

        Try
            Dim myKey As Microsoft.Win32.RegistryKey
            myKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegRoot)
            myKey.SetValue(nKey, nValue.Trim())

        Catch ex As Exception
        End Try

    End Sub

    Public Shared Function ReadRegistry(ByVal nKey As String) As String
        Dim RegRoot As String = "Software\PRI\Setting"
        Dim strRtn As String = ""

        Try
            Dim myKey As Microsoft.Win32.RegistryKey
            myKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegRoot)

            If myKey IsNot Nothing Then
                strRtn = Convert.ToString(myKey.GetValue(nKey))
            End If

        Catch ex As Exception
        End Try

        If strRtn.Length = 0 Then
            strRtn = "0"
        End If

        Return strRtn
    End Function

    Public Shared Function [CInt](ByVal strValue As String) As Integer
        Dim rtnData As Integer = 0

        Try
            rtnData = Convert.ToInt32(strValue)
        Catch ex As Exception
            rtnData = 0
        End Try

        Return rtnData
    End Function

    Public Shared Function [CLng](ByVal strValue As String) As Long
        Dim rtnData As Long = 0

        Try
            rtnData = Convert.ToInt64(strValue)
        Catch ex As Exception
            rtnData = 0
        End Try

        Return rtnData
    End Function

    Public Shared Function [CBool](ByVal strValue As String) As Boolean
        If strValue = "1" Then
            Return True
        End If

        Return False
    End Function

    Public Shared Function [CDbl](ByVal strValue As String) As Double
        Dim rtnData As Double = 0

        Try
            rtnData = Convert.ToDouble(strValue)
        Catch ex As Exception
            rtnData = 0
        End Try

        Return rtnData
    End Function

    Public Shared Function CFloat(ByVal strValue As String) As Single
        Dim rtnData As Double = 0

        Try
            rtnData = CSng(Convert.ToDouble(strValue))
        Catch ex As Exception
            rtnData = 0
        End Try

        Return CSng(rtnData)
    End Function

    Public Shared Function GetDirectoryFromPath(ByVal sFilePath As [String]) As [String]
        Dim sFileFolder As [String] = ""

        Dim N As Integer = sFilePath.LastIndexOf("\"c)
        If N <= sFilePath.Length AndAlso N >= 0 Then
            sFileFolder = sFilePath.Substring(0, N)
        End If

        Return sFileFolder
    End Function

    Public Shared Function CheckInside(ByVal value As Double, ByVal dlimit1 As Double, ByVal dlimit2 As Double) As Boolean
        Return ((dlimit1 <= value AndAlso value <= dlimit2) OrElse (dlimit2 <= value AndAlso value <= dlimit1))
    End Function

    Public Shared Function HalfRaise(ByVal value As Double) As Integer
        Dim val As Integer = CInt(Math.Truncate(value))
        Dim margin As Double = value - CDbl(val)

        If value > 0 Then
            If (margin >= 0.5) Then
                Return val + 1
            Else
                Return val
            End If
        Else
            If (margin >= -0.5) Then
                Return val
            Else
                Return val - 1
            End If
        End If
    End Function

    Public Shared Function MakeLParam(ByVal LoWord As Integer, ByVal HiWord As Integer) As Integer
        Return CInt((HiWord << 16) Or (LoWord And &HFFFF))
    End Function

    Public Shared Sub DivideLParam(ByVal Data As Integer, ByRef LoWord As Integer, ByRef HiWord As Integer)
        LoWord = CShort(Data And &HFFFF)
        HiWord = Data >> 16
    End Sub

    Public Shared Function GetGridData(ByVal Grid As Object) As String
        If Grid IsNot Nothing Then
            Return Grid.ToString()
        Else
            Return ""
        End If
    End Function

    Public Shared Function GetDateTiem() As String
        Return String.Format("{0:d4}/{1:d2}/{2:d2} {3:d2}:{4:d2}:{5:d2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, _
         DateTime.Now.Second)
    End Function

    Public Shared Function Encoding_Ch(ByVal chstring As String) As String

        Dim strTemp As String = ""
        Dim Utf As Encoding = Encoding.UTF8
        Dim unicode As Encoding = Encoding.Unicode
        ' 문자열을 유니코드바이트 배열로 전환
        Dim unicodeBytes As Byte() = unicode.GetBytes(chstring)
        ' 유니코드 바이트 배열을 UTF바이트 배열로 변환 
        Dim utfBytes As Byte() = Encoding.Convert(unicode, Utf, unicodeBytes)
        Dim utfChars As Char() = New Char(Utf.GetCharCount(utfBytes, 0, utfBytes.Length) - 1) {}
        ' uft 바이틀 배열을 문자 배열로 전환
        Utf.GetChars(utfBytes, 0, utfBytes.Length, utfChars, 0)
        Dim utfString As New String(utfChars)

        'New연산자 해제
        strTemp = utfString

        utfString = Nothing
        utfChars = Nothing

        Return strTemp

        '문자 배열을 문자열로 전환 
        'Return utfString

    End Function

End Class

