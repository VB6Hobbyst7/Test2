Imports Matrox.MatroxImagingLibrary

Public Class clsVisionFindMarkCenter
    Inherits MIL

    Private m_MilSystem As MIL_ID
    Private m_imgTarget As MIL_ID
    Private m_MilDisp As MIL_ID     ' 테스트용


    Public m_lpResultLine(3) As LinePoint
    Public m_lpdResultCross(3) As LinePointD

    Structure LinePoint
        Dim x1 As Integer
        Dim y1 As Integer
        Dim x2 As Integer
        Dim y2 As Integer
    End Structure

    Structure LinePointD
        Dim x1 As Double
        Dim y1 As Double
        Dim x2 As Double
        Dim y2 As Double
    End Structure





    Public Sub New(ByVal MilSystem As MIL_ID, ByVal imgTarget As MIL_ID)
        m_MilSystem = MilSystem
        m_imgTarget = imgTarget

    End Sub

    ' 테스트용 
    Public Sub New(ByVal MilSystem As MIL_ID, ByVal MilDisp As MIL_ID, ByVal imgTarget As MIL_ID)
        m_MilSystem = MilSystem
        m_imgTarget = imgTarget
        m_MilDisp = MilDisp

    End Sub


    Private Function GetSimEquation(ByVal ln1 As LinePoint, ByVal ln2 As LinePoint, ByRef lnResult As LinePointD) As Boolean
        Dim a1 As Double, b1 As Double, a2 As Double, b2 As Double

        Dim nAdd As Integer = CDbl(ln1.y2)

        ln1.y1 = nAdd - ln1.y1
        ln1.y2 = nAdd - ln1.y2

        ln2.y1 = nAdd - ln2.y1
        ln2.y2 = nAdd - ln2.y2

        ' ln1의 1차방정식
        If ln1.x2 - ln1.x1 = 0 Or ln1.y2 - ln1.y1 = 0 Then
            ' 수직/수평선
            a1 = 0
            b1 = 0
        Else
            a1 = CDbl(ln1.y2 - ln1.y1) / CDbl(ln1.x2 - ln1.x1)      ' 기울기
            b1 = -a1 * CDbl(ln1.x1) + CDbl(ln1.y1)                  ' y절편
        End If


        ' ln2의 1차방정식
        If ln2.x2 - ln2.x1 = 0 Or ln2.y2 - ln2.y1 = 0 Then
            a2 = 0
            b2 = 0
        Else
            a2 = CDbl(ln2.y2 - ln2.y1) / CDbl(ln2.x2 - ln2.x1)      ' 기울기
            b2 = -a2 * CDbl(ln2.x1) + CDbl(ln2.y1)                  ' y절편
        End If


        ' 두 방정식의 연립방정식 해
        If (a1 = 0 And ln1.y1 <> ln1.y2) And (a2 = 0 And ln2.x1 <> ln2.x2) Then
            ' ln1이 수직선, ln2가 수평선
            lnResult.x1 = CDbl(ln1.x1)
            lnResult.y1 = CDbl(nAdd) - CDbl(ln2.y1)
        ElseIf (a1 = 0 And ln1.x1 <> ln1.x2) And (a2 = 0 And ln2.y1 <> ln2.y2) Then
            ' ln1이 수평선, ln2가 수직선
            lnResult.x1 = CDbl(ln2.x1)
            lnResult.y1 = CDbl(nAdd) - CDbl(ln1.y1)
        ElseIf a1 = 0 And ln1.y1 <> ln1.y2 Then
            ' ln1이 수직선, ln2는 기울기를 가진 직선
            lnResult.x1 = CDbl(ln1.x1)
            lnResult.y1 = CDbl(nAdd) - CDbl(a2 * lnResult.x1 + b2)
        ElseIf a1 = 0 And ln1.x1 <> ln1.x2 Then
            ' ln1이 수평선, ln2는 기울기를 가진 직선
            lnResult.x1 = (CDbl(ln1.y1) - b2) / a2
            lnResult.y1 = CDbl(nAdd) - CDbl(ln1.y1)
        ElseIf a2 = 0 And ln2.y1 <> ln2.y2 Then
            ' ln1은 기울기를 가진 직선, ln2는 수직선
            lnResult.x1 = CDbl(ln2.x1)
            lnResult.y1 = CDbl(nAdd) - (lnResult.x1 * a1 + b1)
        ElseIf a2 = 0 And ln2.x1 <> ln2.x2 Then
            ' ln1은 기울기를 가진 직선, ln2는 수평선
            lnResult.x1 = (CDbl(ln2.y1) - b1) / a1
            lnResult.y1 = CDbl(nAdd) - CDbl(ln2.y1)
        ElseIf a1 <> 0 And a2 <> 0 And a1 <> a2 Then
            ' 둘다 기울기를 가진 직선
            lnResult.x1 = (b2 - b1) / (a1 - a2)
            lnResult.y1 = CDbl(nAdd) - CDbl(lnResult.x1 * a1 + b1)
        Else
            ' 그외 기울기가 동일한 경우는 해 없음
            Return False
        End If

        Return True


    End Function


    Private Function GetSimEquationD(ByVal ln1 As LinePointD, ByVal ln2 As LinePointD, ByRef lnResult As LinePointD) As Boolean
        Dim a1 As Double, b1 As Double, a2 As Double, b2 As Double

        Dim dAdd As Double = ln1.y2

        ln1.y1 = dAdd - ln1.y1
        ln1.y2 = dAdd - ln1.y2

        ln2.y1 = dAdd - ln2.y1
        ln2.y2 = dAdd - ln2.y2

        ' ln1의 1차방정식
        If ln1.x2 - ln1.x1 = 0 Or ln1.y2 - ln1.y1 = 0 Then
            ' 수직/수평선
            a1 = 0
            b1 = 0
        Else
            a1 = ln1.y2 - ln1.y1 / ln1.x2 - ln1.x1      ' 기울기
            b1 = -a1 * ln1.x1 + ln1.y1                  ' y절편
        End If


        ' ln2의 1차방정식
        If ln2.x2 - ln2.x1 = 0 Or ln2.y2 - ln2.y1 = 0 Then
            a2 = 0
            b2 = 0
        Else
            a2 = ln2.y2 - ln2.y1 / ln2.x2 - ln2.x1      ' 기울기
            b2 = -a2 * ln2.x1 + ln2.y1                  ' y절편
        End If


        ' 두 방정식의 연립방정식 해
        If (a1 = 0 And ln1.y1 <> ln1.y2) And (a2 = 0 And ln2.x1 <> ln2.x2) Then
            ' ln1이 수직선, ln2가 수평선
            lnResult.x1 = ln1.x1
            lnResult.y1 = dAdd - ln2.y1
        ElseIf (a1 = 0 And ln1.x1 <> ln1.x2) And (a2 = 0 And ln2.y1 <> ln2.y2) Then
            ' ln1이 수평선, ln2가 수직선
            lnResult.x1 = ln2.x1
            lnResult.y1 = dAdd - ln1.y1
        ElseIf a1 = 0 And ln1.y1 <> ln1.y2 Then
            ' ln1이 수직선, ln2는 기울기를 가진 직선
            lnResult.x1 = ln1.x1
            lnResult.y1 = dAdd - CDbl(a2 * lnResult.x1 + b2)
        ElseIf a1 = 0 And ln1.x1 <> ln1.x2 Then
            ' ln1이 수평선, ln2는 기울기를 가진 직선
            lnResult.x1 = (CDbl(ln1.y1) - b2) / a2
            lnResult.y1 = dAdd - ln1.y1
        ElseIf a2 = 0 And ln2.y1 <> ln2.y2 Then
            ' ln1은 기울기를 가진 직선, ln2는 수직선
            lnResult.x1 = ln2.x1
            lnResult.y1 = dAdd - (lnResult.x1 * a1 + b1)
        ElseIf a2 = 0 And ln2.x1 <> ln2.x2 Then
            ' ln1은 기울기를 가진 직선, ln2는 수평선
            lnResult.x1 = (CDbl(ln2.y1) - b1) / a1
            lnResult.y1 = dAdd - ln2.y1
        ElseIf a1 <> 0 And a2 <> 0 And a1 <> a2 Then
            ' 둘다 기울기를 가진 직선
            lnResult.x1 = (b2 - b1) / (a1 - a2)
            lnResult.y1 = dAdd - CDbl(lnResult.x1 * a1 + b1)
        Else
            ' 그외 기울기가 동일한 경우는 해 없음
            Return False
        End If

        Return True


    End Function


    '
    ' Return
    '   1           성공
    '   0           이미지 세팅안됨
    '   -1          왼쪽 수직선 검출불가
    '   -2          오른쪽 수직선 검출불가
    '   -3          위쪽 수평선 검출불가
    '   -4          아래쪽 수평선 검출불가
    '   -5          두 수직/수평선이 동일하거나 검출실패(값이 0)
    '   -6          좌상 교차점 찾기 실패
    '   -7          우상 교차점 찾기 실패
    '   -8          좌하 교차점 찾기 실패
    '   -9          우하 교차점 찾기 실패
    '   -10         교차점 4개의 무게중심(마크 센터) 찾기 실패
    Public Function FindMarkCenter(ByRef CenterX As Integer, ByRef CenterY As Integer) As Integer
        Dim i As Integer
        Dim nFindROIStart As Integer = 1
        Dim nFindROIEnd As Integer = 0
        Dim mdBinThreshold As Double = 0.0
        Dim nCorrectLineCount As Integer = 10
        Dim MilBufBin As MIL_ID
        Dim nSizeX As MIL_INT = 0, nSizeY As MIL_INT = 0
        Dim nReturn As Integer = 1

        If m_imgTarget = MIL.M_NULL Then
            Return 0
        End If

        On Error GoTo FinalProcess


        MIL.MbufInquire(m_imgTarget, MIL.M_SIZE_X, nSizeX)
        MIL.MbufInquire(m_imgTarget, MIL.M_SIZE_Y, nSizeY)



        ' /////////////////////////////////////////////
        ' 히스토그램 분석
        Dim HistResult As MIL_ID
        Dim HistValues(256) As MIL_INT
        Dim nMaxHist As MIL_INT = 0
        Dim nMaxHistIndex As Integer = 0
        Dim nHighLightCount As Integer = 0
        Dim nConvexValue As Integer = 0

        MIL.MimAllocResult(m_MilSystem, 256, MIL.M_HIST_LIST, HistResult)
        MIL.MimHistogram(m_imgTarget, HistResult)
        MIL.MimGetResult(HistResult, MIL.M_VALUE, HistValues)
        MIL.MimFree(HistResult)


        nHighLightCount = CInt(CDbl(nSizeX * nSizeY) * 0.01)
        nConvexValue = CInt(CDbl(nSizeX * nSizeY) * 0.0017)


        For i = 255 To 0 Step -1
            If HistValues(i) > nHighLightCount Then
                nMaxHistIndex = i
                Exit For
            End If
        Next


        For i = nMaxHistIndex To 0 Step -1
            If HistValues(i) < nConvexValue And HistValues(i - 1) < nConvexValue And HistValues(i - 2) < nConvexValue Then
                mdBinThreshold = i - 10     ' 형변환 int->MIL_DOUBLE 어떻게??
                Exit For
            End If
        Next



        ' /////////////////////////////////////////////
        ' ROI 영역 설정
        Dim nHalfLen = CInt(IIf(nSizeX > nSizeY, nSizeY / 2, nSizeX / 2))
        nFindROIEnd = nHalfLen - CInt(nHalfLen / 6)




        ' /////////////////////////////////////////////
        ' 이미지 이진화
        MIL.MbufAlloc2d(m_MilSystem, nSizeX, nSizeY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_PROC + MIL.M_DISP, MilBufBin)

        'MIL.MimBinarize(m_imgTarget, MilBufBin, MIL.M_FIXED + MIL.M_GREATER_OR_EQUAL, mdBinThreshold, MIL.M_NULL)   ' M_FIXED 없음. 찾아야 함
        MIL.MimBinarize(m_imgTarget, MilBufBin, &H50 + MIL.M_GREATER_OR_EQUAL, mdBinThreshold, MIL.M_NULL)
        MIL.MimDilate(MilBufBin, MilBufBin, 1, MIL.M_BINARY)
        MIL.MimErode(MilBufBin, MilBufBin, 1, MIL.M_BINARY)

        MIL.MimDilate(MilBufBin, MilBufBin, 12, MIL.M_BINARY)
        MIL.MimErode(MilBufBin, MilBufBin, 12, MIL.M_BINARY)







        ' /////////////////////////////////////////////
        ' Convolve 외곽선 찾기
        Dim MilKernel As MIL_ID
        Dim KernelData = {{1, 2, 1}, {2, 4, 2}, {1, 2, 1}}


        ' Kernel 크기 3x3x8
        MIL.MbufAlloc2d(m_MilSystem, 3, 3, 8 + MIL.M_UNSIGNED, MIL.M_KERNEL, MilKernel)
        MIL.MbufPut(MilKernel, KernelData)

        MIL.MimConvolve(MilBufBin, MilBufBin, MIL.M_EDGE_DETECT)



        ' /////////////////////////////////////////////
        ' 선 찾기
        Dim pt(4) As LinePoint
        Dim x As Integer, y As Integer, cnt As Integer
        Dim cVal() As Byte = {0}, cValBuf() As Byte = {0}, cValBuf2() As Byte = {0}
        Dim bCorrect As Boolean = False

        ' 수직선 왼쪽
        For y = nFindROIStart To nFindROIEnd - 1
            For x = 0 To nSizeX - 1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        cVal(0) = 0

                        MIL.MbufGet2d(MilBufBin, x, y + cnt, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x - 1, y + cnt, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False

                        End If
                    Next

                    If bCorrect Then
                        pt(0).x1 = x
                        pt(0).y1 = y

                        y = nSizeY
                        Exit For
                    End If

                    Exit For
                End If

            Next
        Next


        If bCorrect = False Then
            nReturn = -1
            GoTo FinalProcess
        End If


        For y = nSizeY - (nFindROIStart + 1) To nSizeY - (nFindROIEnd + 1) + 1 Step -1
            For x = 0 To nSizeX - 1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        MIL.MbufGet2d(MilBufBin, x, y - cnt, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x - 1, y - cnt, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False
                        End If
                    Next

                    If bCorrect Then
                        pt(0).x2 = x
                        pt(0).y2 = y

                        y = 0

                        Exit For
                    End If

                    Exit For

                End If
            Next
        Next

        If bCorrect = False Then
            nReturn = -1
            GoTo FinalProcess
        End If




        ' 수직선 오른쪽
        For y = nFindROIStart To nFindROIEnd - 1
            For x = nSizeX - 2 To 1 Step -1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        cVal(0) = 0

                        MIL.MbufGet2d(MilBufBin, x, y + cnt, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x + 1, y + cnt, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False

                        End If
                    Next

                    If bCorrect Then
                        pt(1).x1 = x
                        pt(1).y1 = y

                        y = nSizeY
                        Exit For
                    End If

                    Exit For
                End If

            Next
        Next


        If bCorrect = False Then
            nReturn = -2
            GoTo FinalProcess
        End If


        For y = nSizeY - (nFindROIStart + 1) To nSizeY - (nFindROIEnd + 1) + 1 Step -1
            For x = nSizeX - 2 To 1 Step -1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        MIL.MbufGet2d(MilBufBin, x, y - cnt, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x + 1, y - cnt, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False
                        End If
                    Next

                    If bCorrect Then
                        pt(1).x2 = x
                        pt(1).y2 = y

                        y = 0

                        Exit For
                    End If

                    Exit For

                End If
            Next
        Next

        If bCorrect = False Then
            nReturn = -2
            GoTo FinalProcess
        End If




        ' 수평선 위쪽
        For x = nFindROIStart To nFindROIEnd - 1
            For y = 0 To nSizeX - 1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        cVal(0) = 0

                        MIL.MbufGet2d(MilBufBin, x + cnt, y, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x + cnt, y - 1, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False

                        End If
                    Next

                    If bCorrect Then
                        pt(2).x1 = x
                        pt(2).y1 = y

                        x = nSizeX
                        Exit For
                    End If

                    Exit For
                End If

            Next
        Next


        If bCorrect = False Then
            nReturn = -3
            GoTo FinalProcess
        End If


        For x = nSizeX - (nFindROIStart + 1) To nSizeX - (nFindROIEnd + 1) + 1 Step -1
            For y = 0 To nSizeY - 1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        MIL.MbufGet2d(MilBufBin, x - cnt, y, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x - cnt, y - 1, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False
                        End If
                    Next

                    If bCorrect Then
                        pt(2).x2 = x
                        pt(2).y2 = y

                        x = 0

                        Exit For
                    End If

                    Exit For

                End If
            Next
        Next

        If bCorrect = False Then
            nReturn = -3
            GoTo FinalProcess
        End If




        ' 수평선 아래쪽
        For x = nFindROIStart To nFindROIEnd - 1
            For y = nSizeY - 2 To 1 Step -1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        cVal(0) = 0

                        MIL.MbufGet2d(MilBufBin, x + cnt, y, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x + cnt, y + 1, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False

                        End If
                    Next

                    If bCorrect Then
                        pt(3).x1 = x
                        pt(3).y1 = y

                        x = nSizeX
                        Exit For
                    End If

                    Exit For
                End If

            Next
        Next


        If bCorrect = False Then
            nReturn = -4
            GoTo FinalProcess
        End If


        For x = nSizeX - (nFindROIStart + 1) To nSizeX - (nFindROIEnd + 1) + 1 Step -1
            For y = nSizeY - 2 To 1 Step -1
                MIL.MbufGet2d(MilBufBin, x, y, 1, 1, cVal)

                If cVal(0) <> 0 Then
                    bCorrect = False

                    For cnt = 1 To nCorrectLineCount
                        MIL.MbufGet2d(MilBufBin, x - cnt, y, 1, 1, cVal)
                        MIL.MbufGet2d(MilBufBin, x - cnt, y + 1, 1, 1, cValBuf)

                        If cVal(0) <> 0 And cValBuf(0) = 0 Then
                            bCorrect = True
                        Else
                            bCorrect = False
                        End If
                    Next

                    If bCorrect Then
                        pt(3).x2 = x
                        pt(3).y2 = y

                        x = 0

                        Exit For
                    End If

                    Exit For

                End If
            Next
        Next

        If bCorrect = False Then
            nReturn = -4
            GoTo FinalProcess
        End If


        If pt(0).x1 = pt(1).x2 Or pt(2).y1 = pt(3).y1 Then
            nReturn = -5
            GoTo FinalProcess
        End If





        ' ///////////////////////////////////////////////
        ' 교차점 구하기
        Dim lnResult(4) As LinePointD

        If GetSimEquation(pt(0), pt(2), lnResult(0)) = False Then
            nReturn = -6
            GoTo FinalProcess
        End If

        If GetSimEquation(pt(1), pt(2), lnResult(1)) = False Then
            nReturn = -7
            GoTo FinalProcess
        End If

        If GetSimEquation(pt(0), pt(3), lnResult(2)) = False Then
            nReturn = -8
            GoTo FinalProcess
        End If

        If GetSimEquation(pt(1), pt(3), lnResult(3)) = False Then
            nReturn = -9
            GoTo FinalProcess
        End If





        ' /////////////////////////////////////////////////
        ' 4개 교차점의 무게중심 찾기
        Dim ptCross(2) As LinePoint
        Dim ptCrossResult As LinePointD

        ptCross(0).x1 = CInt(lnResult(0).x1)
        ptCross(0).y1 = CInt(lnResult(0).y1)

        ptCross(0).x2 = CInt(lnResult(3).x1)
        ptCross(0).y2 = CInt(lnResult(3).y1)


        ptCross(1).x1 = CInt(lnResult(1).x1)
        ptCross(1).y1 = CInt(lnResult(1).y1)

        ptCross(1).x2 = CInt(lnResult(2).x1)
        ptCross(1).y2 = CInt(lnResult(2).y1)

        If GetSimEquation(ptCross(0), ptCross(1), ptCrossResult) = False Then
            nReturn = -10
            GoTo FinalProcess
        End If


        CenterX = ptCrossResult.x1
        CenterY = ptCrossResult.y1

FinalProcess:
        MIL.MbufFree(MilKernel)
        MIL.MbufFree(MilBufBin)

        Return nReturn

    End Function


    '
    ' Return
    '   1           성공
    '   0           이미지 세팅안됨
    '   -1          위쪽 수직선 2개 Point 검출불가
   
    Public Function FindMarkCenterWithMIL(ByRef MilOverlayImage As MIL_ID, ByRef CenterX As Integer, ByRef CenterY As Integer) As Integer
        Dim i As Integer
        Dim nSizeX As MIL_INT = 0, nSizeY As MIL_INT = 0
        Dim MilMarker As MIL_ID
        Dim nFoundNum As Integer
        Dim nReturn As Integer = 1
        Dim dFoundX(1) As Double, dFoundY(1) As Double
        Dim nSearchRange As Integer = 20

        Dim ptdFound(3) As LinePointD       ' 0:수직좌, 1:수직우, 2:수평상, 3:수평하

        If m_imgTarget = MIL.M_NULL Then
            Return 0
        End If

        On Error GoTo FinalProcess


        MIL.MbufInquire(m_imgTarget, MIL.M_SIZE_X, nSizeX)
        MIL.MbufInquire(m_imgTarget, MIL.M_SIZE_Y, nSizeY)


        MilMarker = MmeasAllocMarker(m_MilSystem, M_EDGE, M_DEFAULT, M_NULL)

        MmeasSetMarker(MilMarker, M_POLARITY, M_ANY, M_DEFAULT)

        MmeasSetMarker(MilMarker, M_SUB_REGIONS_NUMBER, M_DEFAULT, M_NULL)
        MmeasSetMarker(MilMarker, M_NUMBER, 2, M_NULL)
        MmeasSetMarker(MilMarker, &H15400, M_DEFAULT, M_NULL)       ' M_EDGEVALUE_MIN

        ' 위쪽 수직선 두포인트
        For i = 1 To 2
            MmeasSetMarker(MilMarker, M_ORIENTATION, M_VERTICAL, M_DEFAULT)
            MmeasSetMarker(MilMarker, M_BOX_CENTER, CInt(nSizeX / 2), (nSearchRange * i) + 2)

            MmeasSetMarker(MilMarker, M_BOX_SIZE, 200, nSearchRange * 2)
            MmeasSetMarker(MilMarker, M_BOX_ANGLE, 0, M_NULL)


            MmeasFindMarker(M_DEFAULT, m_imgTarget, MilMarker, M_DEFAULT)


            MmeasGetResult(MilMarker, M_NUMBER + M_TYPE_MIL_INT, nFoundNum)

            If nFoundNum = 2 Then

                MmeasGetResult(MilMarker, M_POSITION, dFoundX, dFoundY)

                ptdFound(0).x1 = dFoundX(0)
                ptdFound(0).y1 = dFoundY(0)

                ptdFound(1).x1 = dFoundX(1)
                ptdFound(1).y1 = dFoundY(1)

                Exit For
            End If
        Next

        If nFoundNum <> 2 Then
            Return -1
        End If




        ' 아래쪽 수직선 두포인트
        For i = 1 To 2
            MmeasSetMarker(MilMarker, M_ORIENTATION, M_VERTICAL, M_DEFAULT)
            MmeasSetMarker(MilMarker, M_BOX_CENTER, CInt(nSizeX / 2), nSizeY - (nSearchRange * i) - 2)

            MmeasSetMarker(MilMarker, M_BOX_SIZE, 200, nSearchRange * 2)
            MmeasSetMarker(MilMarker, M_BOX_ANGLE, 0, M_NULL)


            MmeasFindMarker(M_DEFAULT, m_imgTarget, MilMarker, M_DEFAULT)


            MmeasGetResult(MilMarker, M_NUMBER + M_TYPE_MIL_INT, nFoundNum)

            If nFoundNum = 2 Then

                MmeasGetResult(MilMarker, M_POSITION, dFoundX, dFoundY)

                ptdFound(0).x2 = dFoundX(0)
                ptdFound(0).y2 = dFoundY(0)

                ptdFound(1).x2 = dFoundX(1)
                ptdFound(1).y2 = dFoundY(1)

                Exit For
            End If
        Next

        If nFoundNum <> 2 Then
            Return -1
        End If



        ' 왼쪽 수평선 두포인트
        For i = 1 To 2
            MmeasSetMarker(MilMarker, M_ORIENTATION, M_HORIZONTAL, M_DEFAULT)
            MmeasSetMarker(MilMarker, M_BOX_CENTER, (nSearchRange * i) + 2, CInt(nSizeY / 2))

            MmeasSetMarker(MilMarker, M_BOX_SIZE, nSearchRange * 2, 200)
            MmeasSetMarker(MilMarker, M_BOX_ANGLE, 0, M_NULL)


            MmeasFindMarker(M_DEFAULT, m_imgTarget, MilMarker, M_DEFAULT)


            MmeasGetResult(MilMarker, M_NUMBER + M_TYPE_MIL_INT, nFoundNum)

            If nFoundNum = 2 Then

                MmeasGetResult(MilMarker, M_POSITION, dFoundX, dFoundY)

                ptdFound(2).x1 = dFoundX(0)
                ptdFound(2).y1 = dFoundY(0)

                ptdFound(3).x1 = dFoundX(1)
                ptdFound(3).y1 = dFoundY(1)

                Exit For
            End If
        Next

        If nFoundNum <> 2 Then
            Return -1
        End If

        ' 오른쪽 수평선 두포인트
        For i = 1 To 2
            MmeasSetMarker(MilMarker, M_ORIENTATION, M_HORIZONTAL, M_DEFAULT)
            MmeasSetMarker(MilMarker, M_BOX_CENTER, nSizeX - (nSearchRange * i) - 2, CInt(nSizeY / 2))

            MmeasSetMarker(MilMarker, M_BOX_SIZE, nSearchRange * 2, 200)
            MmeasSetMarker(MilMarker, M_BOX_ANGLE, 0, M_NULL)


            MmeasFindMarker(M_DEFAULT, m_imgTarget, MilMarker, M_DEFAULT)


            MmeasGetResult(MilMarker, M_NUMBER + M_TYPE_MIL_INT, nFoundNum)

            If nFoundNum = 2 Then

                MmeasGetResult(MilMarker, M_POSITION, dFoundX, dFoundY)

                ptdFound(2).x2 = dFoundX(0)
                ptdFound(2).y2 = dFoundY(0)

                ptdFound(3).x2 = dFoundX(1)
                ptdFound(3).y2 = dFoundY(1)

                Exit For
            End If
        Next

        If nFoundNum <> 2 Then
            Return -1
        End If










        ' ///////////////////////////////////////////////
        ' 교차점 구하기
        Dim lpLine(3) As LinePoint
        Dim lnResult(3) As LinePointD

        For i = 0 To 3
            lpLine(i).x1 = ptdFound(i).x1
            lpLine(i).x2 = ptdFound(i).x2
            lpLine(i).y1 = ptdFound(i).y1
            lpLine(i).y2 = ptdFound(i).y2
        Next

        If GetSimEquation(lpLine(0), lpLine(2), lnResult(0)) = False Then
            nReturn = -6
            GoTo FinalProcess
        End If

        If GetSimEquation(lpLine(1), lpLine(2), lnResult(1)) = False Then
            nReturn = -7
            GoTo FinalProcess
        End If

        If GetSimEquation(lpLine(0), lpLine(3), lnResult(2)) = False Then
            nReturn = -8
            GoTo FinalProcess
        End If

        If GetSimEquation(lpLine(1), lpLine(3), lnResult(3)) = False Then
            nReturn = -9
            GoTo FinalProcess
        End If



        


        ' /////////////////////////////////////////////////
        ' 4개 교차점의 무게중심 찾기
        Dim ptCross(2) As LinePoint
        Dim ptCrossResult As LinePointD

        ptCross(0).x1 = CInt(lnResult(0).x1)
        ptCross(0).y1 = CInt(lnResult(0).y1)

        ptCross(0).x2 = CInt(lnResult(3).x1)
        ptCross(0).y2 = CInt(lnResult(3).y1)


        ptCross(1).x1 = CInt(lnResult(1).x1)
        ptCross(1).y1 = CInt(lnResult(1).y1)

        ptCross(1).x2 = CInt(lnResult(2).x1)
        ptCross(1).y2 = CInt(lnResult(2).y1)

        If GetSimEquation(ptCross(0), ptCross(1), ptCrossResult) = False Then
            nReturn = -10
            GoTo FinalProcess
        End If




        CenterX = ptCrossResult.x1
        CenterY = ptCrossResult.y1

        m_lpResultLine = lpLine
        m_lpdResultCross = lnResult


FinalProcess:
        MmeasFree(MilMarker)

        Return nReturn

    End Function


End Class
