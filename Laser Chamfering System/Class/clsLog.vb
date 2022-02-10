Imports System.Threading.Thread
Imports System
Imports System.IO
Imports System.Collections

Public Class clsLog

    Public strRootPath As String '= "C:\Chamfering System\Log\"

    Private pbLogEnd As Boolean = False
    Private pcLogData As New Collection
    Private ptLogWrite As Threading.Thread

    Public Sub New()
        'Call subLogWrite("Log Start!!!")
        ptLogWrite = New Threading.Thread(AddressOf ThreadLogWrite)
        ptLogWrite.Start()
    End Sub

    Public Sub Close()
        'Call subLogWrite("Log End!!")

        pbLogEnd = True

        If Not (ptLogWrite Is Nothing) Then
            ptLogWrite.Join(10000)
        End If

        Call Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub LogWrite(ByVal strLog As String, Optional ByVal strPathName As String = "")
        pcLogData.Add(strLog & "||" & strPathName)
    End Sub

    Private Sub ThreadLogWrite()
        Dim strLogWrite() As String

        While pbLogEnd = False
            Try
                If pcLogData.Count > 0 Then
                    strLogWrite = Split(pcLogData(1).ToString, "||")
                    subLogWrite(strLogWrite(0), strLogWrite(1))

                    pcLogData.Remove(1)
                End If

            Catch ex As Exception
            End Try

            Sleep(50)
        End While

    End Sub

    Private Sub subLogWrite(ByVal strRealLog As String, Optional ByVal strRealPathName As String = "")
        Dim strRealFileName As String
        Dim nMillisecond As Integer = 0
        strRootPath = pCurSystemParam.strSystemLogPath & "\"

        Try

            If strRealPathName = "" Then
                'strRealLog = "[" & Format(Now.ToString("D3"), "yyyy-MM-dd HH:mm:ss") & " " & Format(Now.Millisecond) & "] " & strRealLog & vbCrLf
                nMillisecond = Format(Now.Millisecond)
                strRealLog = "[" & Format(Now.ToString("D3"), "yyyy-MM-dd HH:mm:ss") & " " & nMillisecond.ToString("D3") & "] " & strRealLog & vbCrLf
                strRealPathName = strRootPath
            Else
                'strRealLog = "[" & Format(Now, "HH:mm:ss") & " " & Format(Now.Millisecond) & "] " & strRealLog & vbCrLf
                nMillisecond = Format(Now.Millisecond)
                strRealLog = "[" & Format(Now, "HH:mm:ss") & " " & nMillisecond.ToString("D3") & "] " & strRealLog & vbCrLf
                strRealPathName = strRootPath & strRealPathName & "\"
            End If

            If System.IO.Directory.Exists(strRealPathName) = False Then
                System.IO.Directory.CreateDirectory(strRealPathName)
            End If

            strRealFileName = Format(Now, "yyyy-MM-dd") & ".log"

            System.IO.File.AppendAllText(strRealPathName & strRealFileName, strRealLog, System.Text.Encoding.Default)

        Catch ex As Exception
        End Try
    End Sub

    Public arrText As New ArrayList()

    Public Sub LogRead(Optional ByVal strRealPathName As String = "")
        Dim strRealFileName As String = ""
        Dim strLoadFileName As String = ""
        strRootPath = pCurSystemParam.strSystemLogPath & "\"

        strLoadFileName = strRootPath & strRealPathName
        strRealPathName = strRootPath & strRealPathName & "\"


        If frmAlignDataView.bLoadView = False Then
            strRealFileName = Format(Now, "yyyy-MM-dd") & ".log"
            strRealFileName = strRealPathName & strRealFileName

            'If System.IO.Directory.Exists(strRealFileName) = False Then
            If System.IO.File.Exists(strRealFileName) = False Then
                'System.IO.Directory.CreateDirectory(strRealFileName)
                Return
            End If
        Else
            If System.IO.File.Exists(strLoadFileName) = False Then
                'System.IO.Directory.CreateDirectory(strRealFileName)
                Return
            End If
        End If

        Dim objLoader As New StreamReader(strLoadFileName)
        Dim sLine As String = ""

        arrText.Clear()
        If frmAlignDataView.bLoadView = False Then
            Dim objReader As New StreamReader(strRealFileName)
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    arrText.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objReader.Close()
        Else
            Do
                sLine = objLoader.ReadLine()
                If Not sLine Is Nothing Then
                    arrText.Add(sLine)
                End If
            Loop Until sLine Is Nothing
            objLoader.Close()
        End If
        'For Each sLine In arrText
        '    Console.WriteLine(sLine)
        'Next
        'Console.ReadLine()



    End Sub

    Public Sub OldFileDelete(ByVal strPath As String, ByVal intKeepDate As Integer)
        Dim strDelFile As String
        Dim MyFile As String = ""
        Dim strFile() As String
        'Dim strFileName As String = ""
        Dim strFileName() As String
        Dim strLastFileName As String = ""
        Dim strlog As String = ".log"
        strRootPath = pCurSystemParam.strSystemLogPath & "\"

        strFile = System.IO.Directory.GetFiles(strRootPath & strPath)
        ReDim strFileName(strFile.Length - 1)
        For i As Integer = 0 To strFile.Length - 1
            strFileName(i) = modPub.GetFileName(strFile(i), True)
        Next
        Try
            strDelFile = Format(CDate(Now.AddDays(-intKeepDate)), "yyyy-MM-dd")

            If strPath = "" Then
                MyFile = Dir(strRootPath, FileAttribute.Directory)
                Do While MyFile <> ""
                    If Mid(MyFile, 1, 10) <= strDelFile Then
                        System.IO.File.Delete(strRootPath & MyFile)
                    End If
                    MyFile = Dir()
                Loop
            Else
                strLastFileName = strDelFile & strlog
                MyFile = Dir(strRootPath & strPath, FileAttribute.Directory)
                'Do While strLastFileName = strDelFile & strlog 'MyFile <> ""
                For j As Integer = 0 To strFileName.Length - 1
                    If Mid(strFileName(j), 1, 10) <= strDelFile Then
                        'System.IO.Directory.Delete(strRootPath & strPath & MyFile, True)
                        System.IO.File.Delete(strRootPath & strPath & "\" & strFileName(j))
                        strLastFileName = modPub.GetFileName(strFile(j), True)
                    End If
                Next
                'MyFile = Dir()
                'Loop
            End If

        Catch ex As Exception
        End Try
    End Sub
End Class
