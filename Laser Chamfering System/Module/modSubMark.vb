Imports System.IO
Module modSubMark
    Public nMark1_AlignCnt(,) As Integer
    Public nMark2_AlignCnt(,) As Integer
    Public nMark3_AlignCnt(,) As Integer



    Public strRootPath As String '= "C:\Chamfering System\Log\AlignSubMarkLog\"
    Dim strLastFileName As String = ""
    Public Sub AlignMatchLoad(ByVal intKeepDate As Integer)
        Dim strCurrnetLogFile As String
        Dim strFile() As String
        Dim strFileName() As String

        Dim strlog As String = ".log"
        strRootPath = pCurSystemParam.strSystemLogPath & "\AlignSubMarkLog\"

        If System.IO.Directory.Exists(strRootPath) = False Then
            System.IO.Directory.CreateDirectory(strRootPath)
        End If

        strFile = System.IO.Directory.GetFiles(strRootPath)

        ReDim strFileName(strFile.Length - 1)
        For i As Integer = 0 To strFile.Length - 1
            strFileName(i) = GetFileName(strFile(i), True)
        Next

        ReDim nMark1_AlignCnt(7, 1)
        ReDim nMark2_AlignCnt(7, 1)
        ReDim nMark3_AlignCnt(7, 1)

        Try
            strCurrnetLogFile = Format(CDate(Now.AddDays(-intKeepDate)), "yyyy-MM-dd")
            strLastFileName = strRootPath & strCurrnetLogFile & strlog

            AlignMatchLog(strLastFileName)

        Catch ex As Exception
        End Try

    End Sub


    Public Function GetFileName(ByVal ipStrFile As String, Optional ByVal bGetFileFormat As Boolean = False) As String
        On Error GoTo SysErr
        Dim tmpArrStr() As String = {}
        Dim tmpOutPath As String = ""

        tmpArrStr = Split(ipStrFile, "\")
        tmpOutPath = tmpArrStr(tmpArrStr.Length - 1)
        If bGetFileFormat = False Then
            tmpArrStr = Split(tmpOutPath, ".")
            tmpOutPath = tmpArrStr(0)
        End If

        Return tmpOutPath

        Exit Function
SysErr:

    End Function

    Dim LogFilePath As String = ""

    Public Function AlignMatchLog(ByVal ipFilePath As String)
        Dim LoadData_Log As New StreamReader(ipFilePath)
        Dim tmpStrData As String = ""
        Dim strMark1_ExMark1 As String = "0"
        Dim strMark1_ExMark2 As String = "1"
        Dim strMark1_ExMark3 As String = "2"



        Dim ipCmd3 As String = "_"
        Dim strLine() As String


        Dim tmpStrAddress As String = ""

        Do While LoadData_Log.EndOfStream = False
            tmpStrData = LoadData_Log.ReadLine()
            If tmpStrData.Contains("A") Then
                For i As Integer = 0 To 3
                    For j As Integer = 0 To 1
                        If tmpStrData.Contains("A" & (i + 1) & "_Mark" & (j + 1)) = True Then
                            strLine = Split(tmpStrData, ipCmd3)

                            If strMark1_ExMark1 = strLine(2) Then
                                nMark1_AlignCnt(i, j) = nMark1_AlignCnt(i, j) + 1
                            ElseIf strMark1_ExMark2 = strLine(2) Then
                                nMark2_AlignCnt(i, j) = nMark2_AlignCnt(i, j) + 1
                            ElseIf strMark1_ExMark3 = strLine(2) Then
                                nMark3_AlignCnt(i, j) = nMark3_AlignCnt(i, j) + 1
                            End If

                        End If
                    Next
                Next
                If tmpStrData.Contains("B") Then
                    For i As Integer = 4 To 7
                        For j As Integer = 0 To 1
                            If tmpStrData.Contains("B" & (i - 3) & "_Mark" & (j + 1)) = True Then
                                strLine = Split(tmpStrData, ipCmd3)

                                If strMark1_ExMark1 = strLine(2) Then
                                    nMark1_AlignCnt(i, j) = nMark1_AlignCnt(i, j) + 1
                                ElseIf strMark1_ExMark2 = strLine(2) Then
                                    nMark2_AlignCnt(i, j) = nMark2_AlignCnt(i, j) + 1
                                ElseIf strMark1_ExMark3 = strLine(2) Then
                                    nMark3_AlignCnt(i, j) = nMark3_AlignCnt(i, j) + 1
                                End If

                            End If
                        Next
                    Next
                End If
            End If

            'If tmpStrData.Contains("A1_Mark1") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)

            '    If strMark1_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(0, 0) = nMark1_AlignCnt(0, 0) + 1
            '    ElseIf strMark1_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(0, 0) = nMark2_AlignCnt(0, 0) + 1
            '    ElseIf strMark1_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(0, 0) = nMark3_AlignCnt(0, 0) + 1
            '    End If

            'ElseIf tmpStrData.Contains("A2_Mark1") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)
            '    If strMark1_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(1, 0) = nMark1_AlignCnt(1, 0) + 1
            '    ElseIf strMark1_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(1, 0) = nMark2_AlignCnt(1, 0) + 1
            '    ElseIf strMark1_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(1, 0) = nMark3_AlignCnt(1, 0) + 1
            '    End If

            'ElseIf tmpStrData.Contains("A1_Mark2") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)
            '    If strMark2_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(0, 1) = nMark1_AlignCnt(0, 1) + 1
            '    ElseIf strMark2_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(0, 1) = nMark2_AlignCnt(0, 1) + 1
            '    ElseIf strMark2_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(0, 1) = nMark3_AlignCnt(0, 1) + 1
            '    End If


            'ElseIf tmpStrData.Contains("A2_Mark2") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)
            '    If strMark2_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(1, 1) = nMark1_AlignCnt(1, 1) + 1
            '    ElseIf strMark2_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(1, 1) = nMark2_AlignCnt(1, 1) + 1
            '    ElseIf strMark2_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(1, 1) = nMark3_AlignCnt(1, 1) + 1
            '    End If


            'ElseIf tmpStrData.Contains("A3_Mark1") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)
            '    If strMark1_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(2, 0) = nMark1_AlignCnt(2, 0) + 1
            '    ElseIf strMark1_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(2, 0) = nMark2_AlignCnt(2, 0) + 1
            '    ElseIf strMark1_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(2, 0) = nMark3_AlignCnt(2, 0) + 1
            '    End If

            'ElseIf tmpStrData.Contains("A4_Mark1") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)
            '    If strMark1_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(3, 0) = nMark1_AlignCnt(3, 0) + 1
            '    ElseIf strMark1_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(3, 0) = nMark2_AlignCnt(3, 0) + 1
            '    ElseIf strMark1_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(3, 0) = nMark3_AlignCnt(3, 0) + 1
            '    End If

            'ElseIf tmpStrData.Contains("A3_Mark2") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)
            '    If strMark2_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(2, 1) = nMark1_AlignCnt(2, 1) + 1
            '    ElseIf strMark2_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(2, 1) = nMark2_AlignCnt(2, 1) + 1
            '    ElseIf strMark2_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(2, 1) = nMark3_AlignCnt(2, 1) + 1
            '    End If

            'ElseIf tmpStrData.Contains("A4_Mark2") = True Then
            '    strLine = Split(tmpStrData, ipCmd3)
            '    If strMark2_ExMark1 = strLine(2) Then
            '        nMark1_AlignCnt(3, 1) = nMark1_AlignCnt(3, 1) + 1
            '    ElseIf strMark2_ExMark2 = strLine(2) Then
            '        nMark2_AlignCnt(3, 1) = nMark2_AlignCnt(3, 1) + 1
            '    ElseIf strMark2_ExMark3 = strLine(2) Then
            '        nMark3_AlignCnt(3, 1) = nMark3_AlignCnt(3, 1) + 1
            '    End If

            'End If



        Loop

        'New연산자 해제
        LoadData_Log = Nothing
        Return True

    End Function
End Module
