Module modRecipe

    Structure RecipeParam
        Dim strRecipeName As String
        Dim nRecipeNumber As Integer
        Dim strTmpRecipePath As String
        Dim strMarkRecipeFile(,) As String
        Dim strMultiFirstMarkRecipeFile(,) As String
        Dim strMultiSecondMarkRecipeFile(,) As String
        Dim nAtt_Laser() As Integer
        Dim nFreq_Laser() As Integer

        Dim RecipeMarkingData(,) As MarkingData
        Dim RecipeMultiFirstMarkingData(,) As MarkingData
        Dim RecipeMultiSecondMarkingData(,) As MarkingData
        Dim bLoadMarkingData As Boolean
        Dim bMultiCutting As Boolean

        Dim dCenterX As Double
        Dim dCenterY As Double

        ' index : 2 Line
        Dim dStageAlignMark1PosX(,) As Double
        Dim dStageAlignMark1PosY(,) As Double
        Dim dStageAlignMark2PosX(,) As Double
        Dim dStageAlignMark2PosY(,) As Double

        Dim nAlignLight(,) As Integer   '박스 조명
        Dim nAlignLight2(,) As Integer  '동축 조명
        Dim nAlignLight_mark2(,) As Integer   '박스 조명
        Dim nAlignLight2_mark2(,) As Integer  '동축 조명

        Dim AlignResult(,) As AfterAlignData    ' line, panel
        '20160819 
        Dim dAlignDistance As Double
        Dim dAlignErrorRange As Double
        Dim dThetaLimit_1 As Double
        Dim dThetaLimit_2 As Double
        Dim dThetaLimit_3 As Double
        Dim dThetaLimit_4 As Double
        Dim PenData As MarkPenData
        Dim nAlignRetry As Integer

        Dim nSystem As Integer
        '20180306 chy 정도 위치 spec
        Dim strMarkingNum() As String

        Public Sub Init()
            ReDim nAtt_Laser(3)
            ReDim nFreq_Laser(3)

            ReDim RecipeMarkingData(1, 3)
            ReDim RecipeMultiFirstMarkingData(1, 3)
            ReDim RecipeMultiSecondMarkingData(1, 3)
            ReDim strMarkRecipeFile(1, 3)
            ReDim strMultiFirstMarkRecipeFile(1, 3)
            ReDim strMultiSecondMarkRecipeFile(1, 3)
            ReDim dStageAlignMark1PosX(1, 3)   ' lineA, lineB
            ReDim dStageAlignMark1PosY(1, 3)
            ReDim dStageAlignMark2PosX(1, 3)
            ReDim dStageAlignMark2PosY(1, 3)
            ReDim nAlignLight(1, 3)           ' Line, Light
            ReDim nAlignLight2(1, 3)           ' Line, Light
            ReDim nAlignLight_mark2(1, 3)    '박스 조명
            ReDim nAlignLight2_mark2(1, 3)   '동축 조명

            ReDim AlignResult(1, 3)           ' Line, glass
        End Sub

    End Structure

    Structure MarkingData
        Dim nIndexCnt As Integer
        Dim nTotalCmdCnt As Integer
        Dim dOffsetX As Double
        Dim dOffsetY As Double
        Dim dOffsetAngle As Double
        Dim Data() As MarkIndexData
        Dim nPen As Integer
        Dim ExecuteData As MarkIndexData
        Dim dV_LinePosX1 As Double
        Dim dV_LinePosX2 As Double
        Dim dV_LinePosY As Double
        Dim dV_LineMarkSpd As Double
        Dim nV_LineRepeat As Integer
        Dim bV_LineFirst As Boolean
    End Structure

    Structure MarkIndexData
        Dim nGroupX() As Integer
        Dim nGroupY() As Integer
        Dim nCmdCnt As Integer
        Dim dPosX() As Double
        Dim dPosY() As Double
        Dim dAngle() As Double
        Dim strCommand() As String
    End Structure

    Structure MarkPenData
        Dim Count As Integer
        Dim MarkSpeed() As Double
        Dim JumpSpeed() As Double
        Dim MarkMode() As Integer
        Dim Repeat() As Integer
    End Structure

    Structure AfterAlignData
        Dim bGetMark1_OK As Boolean
        Dim bGetMark2_OK As Boolean
        Dim dMark1DifferencePositionX As Double
        Dim dMark1DifferencePositionY As Double
        Dim dMark2DifferencePositionX As Double
        Dim dMark2DifferencePositionY As Double
        Dim dOffsetX As Double
        Dim dOffsetY As Double
        Dim dAngle As Double
        Dim dMarkDestPositionX As Double
        Dim dMarkDestPositionY As Double
    End Structure
    Structure DisplaceData

        'Public pnSelectPosition As Integer = 
        Dim pbSelectposition() As Boolean
        Dim pdValueX() As Double
        Dim pdValueY() As Double
        Dim pdIndex() As String
        Dim pnMaxCnt As Integer
        Dim pnLine As Integer
        Dim pbRead As Boolean
        Dim dGridviewVal() As Double
        Dim maxcnt As Integer
        Dim SelectIndex As Integer
        Dim DataGridIndex() As String
        Dim DataGridValue() As String
        Dim m_lblValueMax() As Double
        Dim m_lblValueMin() As Double
        Dim m_lblValueAvg() As Double
        Dim m_bline As Integer
    End Structure

    Public Const SCANNER_PROGRAM_PATH As String = "C:\Chamfering System\Setting\Scanner\"

    Public pCurRecipe As RecipeParam
    Public pSetRecipe As RecipeParam
    Public pDisplaceData As DisplaceData
    Public tmpEditMarkData As MarkingData
    Public nCurEditMarkData As Integer = 0

    Public dMarkDistance(1, 3) As Double


    Public Sub Init()
        pCurRecipe.Init()
        pSetRecipe.Init()
    End Sub

    Public Function LoadRecipe(ByVal strFilePath As String, ByRef ipRecipe As RecipeParam) As Boolean
        Try
            Dim str(2) As String

            ipRecipe.strRecipeName = ReadIni("MODEL_NAME", "FILE", "HPK_DEFAULT", strFilePath)
            ipRecipe.nRecipeNumber = ReadIni("MODEL_NAME", "NUMBER", "1", strFilePath)

            ipRecipe.bMultiCutting = ReadIni("CUTTING", "MULTICUTTING", "0", strFilePath)
            ipRecipe.nSystem = CInt(ReadIni("SYSTEM_ETC", "SYSTEM", "0", strFilePath))
            str(0) = "A"
            str(1) = "B"

            For i = 0 To 3
                ipRecipe.nAtt_Laser(i) = CInt(ReadIni("LASER_INFO", "ATTENUATION_LASER_" & (i + 1).ToString, "50", strFilePath))
                ipRecipe.nFreq_Laser(i) = CInt(ReadIni("LASER_INFO", "FREQUENCY_LASER_" & (i + 1).ToString, "500", strFilePath))
            Next
            ipRecipe.PenData.Count = CInt(ReadIni("MARK_PEN", "TOTAL_COUNT", "1", strFilePath))

            ReDim ipRecipe.PenData.JumpSpeed(ipRecipe.PenData.Count - 1)
            ReDim ipRecipe.PenData.MarkSpeed(ipRecipe.PenData.Count - 1)
            ReDim ipRecipe.PenData.MarkMode(ipRecipe.PenData.Count - 1)
            ReDim ipRecipe.PenData.Repeat(ipRecipe.PenData.Count - 1)

            For i As Integer = 0 To ipRecipe.PenData.Count - 1
                ipRecipe.PenData.JumpSpeed(i) = CDbl(ReadIni("MARK_PEN", "JUMP_SPEED_" & (i + 1).ToString, "100", strFilePath))
                ipRecipe.PenData.MarkSpeed(i) = CDbl(ReadIni("MARK_PEN", "MARK_SPEED_" & (i + 1).ToString, "100", strFilePath))
                ipRecipe.PenData.MarkMode(i) = CInt(ReadIni("MARK_PEN", "MARK_MODE_" & (i + 1).ToString, "1", strFilePath))
                ipRecipe.PenData.Repeat(i) = CInt(ReadIni("MARK_PEN", "MARK_REPEAT_" & (i + 1).ToString, "1", strFilePath))
            Next

            ipRecipe.dCenterX = ReadIni("ALIGN_INFO", "ALIGN_CENTER_X", "0", strFilePath)
            ipRecipe.dCenterY = ReadIni("ALIGN_INFO", "ALIGN_CENTER_Y", "0", strFilePath)


            ipRecipe.dThetaLimit_1 = ReadIni("ALIGN_INFO", "THETA_LIMIT_1", "0", strFilePath)
            ipRecipe.dThetaLimit_2 = ReadIni("ALIGN_INFO", "THETA_LIMIT_2", "0", strFilePath)
            ipRecipe.dThetaLimit_3 = ReadIni("ALIGN_INFO", "THETA_LIMIT_3", "0", strFilePath)
            ipRecipe.dThetaLimit_4 = ReadIni("ALIGN_INFO", "THETA_LIMIT_4", "0", strFilePath)
            ipRecipe.nAlignRetry = ReadIni("ALIGN_INFO", "ALIGN_RETRY", "0", strFilePath)
            ipRecipe.dAlignDistance = ReadIni("ALIGN_INFO", "ALIGN_DISTANCE", "0", strFilePath)
            ipRecipe.dAlignErrorRange = ReadIni("ALIGN_INFO", "ALIGN_ERROR_RANGE", "0", strFilePath)

            For nLine = LINE.A To LINE.B
                For i = 0 To 3

                    ipRecipe.strMarkRecipeFile(nLine, i) = ReadIni("MARK_INFO", "FILE_" & str(nLine) & (i + 1).ToString, "C:\Chamfering System\Recipe\D154_MARK_INFO.ini", strFilePath)
                    ipRecipe.bLoadMarkingData = LoadMarkingData(ipRecipe.strMarkRecipeFile(nLine, i), ipRecipe.RecipeMarkingData(nLine, i))



#If HEAD_2 Then
                      If ipRecipe.bMultiCutting = True Then
                        ipRecipe.strMultiFirstMarkRecipeFile(nLine, 0) = ReadIni("MARK_INFO", "FIRST_FILE_" & str(nLine) & (1).ToString, "C:\Chamfering System\Recipe\D154_MARK_INFO.ini", strFilePath)
                        ipRecipe.strMultiSecondMarkRecipeFile(nLine, 0) = ReadIni("MARK_INFO", "SECOND_FILE_" & str(nLine) & (1).ToString, "C:\Chamfering System\Recipe\D154_MARK_INFO.ini", strFilePath)
                        ipRecipe.strMultiFirstMarkRecipeFile(nLine, 1) = ReadIni("MARK_INFO", "FIRST_FILE_" & str(nLine) & (2).ToString, "C:\Chamfering System\Recipe\D154_MARK_INFO.ini", strFilePath)
                        ipRecipe.strMultiSecondMarkRecipeFile(nLine, 1) = ReadIni("MARK_INFO", "SECOND_FILE_" & str(nLine) & (2).ToString, "C:\Chamfering System\Recipe\D154_MARK_INFO.ini", strFilePath)
                        End If
#End If
                    If ipRecipe.bMultiCutting = True Then
                        ipRecipe.strMultiFirstMarkRecipeFile(nLine, i) = ReadIni("MARK_INFO", "FIRST_FILE_" & str(nLine) & (i + 1).ToString, "C:\Chamfering System\Recipe\D154_MARK_INFO.ini", strFilePath)
                        ipRecipe.strMultiSecondMarkRecipeFile(nLine, i) = ReadIni("MARK_INFO", "SECOND_FILE_" & str(nLine) & (i + 1).ToString, "C:\Chamfering System\Recipe\D154_MARK_INFO.ini", strFilePath)
                        LoadMarkingData(ipRecipe.strMultiFirstMarkRecipeFile(nLine, i), ipRecipe.RecipeMultiFirstMarkingData(nLine, i))
                        LoadMarkingData(ipRecipe.strMultiSecondMarkRecipeFile(nLine, i), ipRecipe.RecipeMultiSecondMarkingData(nLine, i))
                    End If

                    str(2) = str(nLine) & "_MARK_OFFSET_" & "X" & (i + 1).ToString
                    ipRecipe.RecipeMarkingData(nLine, i).dOffsetX = CDbl(ReadIni("MARK_OFFSET_INFO", str(2), "0", strFilePath))
                    str(2) = str(nLine) & "_MARK_OFFSET_" & "Y" & (i + 1).ToString
                    ipRecipe.RecipeMarkingData(nLine, i).dOffsetY = CDbl(ReadIni("MARK_OFFSET_INFO", str(2), "0", strFilePath))
                    str(2) = str(nLine) & "_MARK_OFFSET_" & "ANGLE" & (i + 1).ToString
                    ipRecipe.RecipeMarkingData(nLine, i).dOffsetAngle = CDbl(ReadIni("MARK_OFFSET_INFO", str(2), "0", strFilePath))
                    ' lignt
                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT_" & (i + 1).ToString
                    ipRecipe.nAlignLight(nLine, i) = CInt(ReadIni("ALIGN_INFO", str(2), "10", strFilePath))

                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT2_" & (i + 1).ToString
                    ipRecipe.nAlignLight2(nLine, i) = CInt(ReadIni("ALIGN_INFO", str(2), "10", strFilePath))

                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT_MARK2_" & (i + 1).ToString
                    ipRecipe.nAlignLight_mark2(nLine, i) = CInt(ReadIni("ALIGN_INFO", str(2), "10", strFilePath))

                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT2_MARK2_" & (i + 1).ToString
                    ipRecipe.nAlignLight2_mark2(nLine, i) = CInt(ReadIni("ALIGN_INFO", str(2), "10", strFilePath))
                    ' 
                    ' 
                    For j = 0 To 1      '첫번째 마크, 두번째 마크
                        For k = 0 To 2
                            str(2) = str(nLine) & "_ALIGN_MARK_CNT_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nSubMark = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)
                            pRcpMark_Data_Tmp(nLine, i, j, k).nSubMark = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)
                            ' line, panel, mark 순서, 갯수
                            str(2) = str(nLine) & "_ALIGN_SEARCH_OFFSET_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchOffsetX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_SearchOffsetX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_SEARCH_OFFSET_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchOffsetY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_SearchOffsetY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_SEARCH_SIZE_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchSizeX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_SearchSizeX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_SEARCH_SIZE_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchSizeY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_SearchSizeY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_MODEL_OFFSET_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelOffsetX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_ModelOffsetX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_MODEL_OFFSET_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelOffsetY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_ModelOffsetY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_MODEL_SIZE_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelSizeX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_ModelSizeX = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_MODEL_SIZE_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelSizeY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_ModelSizeY = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_ACCEPTANCE_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_Acceptance = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_Acceptance = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_CERTAINTY_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).nAlignMark_Certainty = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))
                            pRcpMark_Data_Tmp(nLine, i, j, k).nAlignMark_Certainty = CInt(ReadIni("ALIGN_INFO", str(2), "0", strFilePath))

                            str(2) = str(nLine) & "_ALIGN_MARK_IMAGE_NAME_BMP_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).strAlignMarkImageBMP_FileName = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)
                            pRcpMark_Data_Tmp(nLine, i, j, k).strAlignMarkImageBMP_FileName = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MARK_IMAGE_NAME_MMF_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).strAlignMarkImageMMF_FileName = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)
                            pRcpMark_Data_Tmp(nLine, i, j, k).strAlignMarkImageMMF_FileName = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MARK_USE_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            pRcpMark_Data(nLine, i, j, k).bMark = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)
                            pRcpMark_Data_Tmp(nLine, i, j, k).bMark = ReadIni("ALIGN_INFO", str(2), "0", strFilePath)
                        Next
                    Next
                Next
            Next

            '20180306 chy 정도 위치 spec
            ReDim ipRecipe.strMarkingNum(ipRecipe.RecipeMarkingData(0, 0).nTotalCmdCnt)

            For nCnt As Integer = 0 To ipRecipe.RecipeMarkingData(0, 0).nTotalCmdCnt
                ipRecipe.strMarkingNum(nCnt) = ReadIni("MARKING_INFO", "MARK" & (nCnt + 1).ToString, "", strFilePath)
            Next

            LoadRecipe = True

        Catch ex As Exception
            MsgBox(ex.Message & "at " & "LoadRecipe")
            'LoadRecipe = False
        End Try

    End Function

    Public Function SaveRecipe(ByVal strFilePath As String, ByRef ipRecipe As RecipeParam) As Boolean
        Try
            Dim str(2) As String

            WriteIni("MODEL_NAME", "FILE", ipRecipe.strRecipeName, strFilePath)
            WriteIni("MODEL_NAME", "NUMBER", ipRecipe.nRecipeNumber, strFilePath)
            WriteIni("CUTTING", "MULTICUTTING", CInt(ipRecipe.bMultiCutting), strFilePath)
            WriteIni("SYSTEM_ETC", "SYSTEM", ipRecipe.nSystem, strFilePath)

            str(0) = "A"
            str(1) = "B"

            For i = 0 To 3
                WriteIni("LASER_INFO", "ATTENUATION_LASER_" & (i + 1).ToString, ipRecipe.nAtt_Laser(i), strFilePath)
                WriteIni("LASER_INFO", "FREQUENCY_LASER_" & (i + 1).ToString, ipRecipe.nFreq_Laser(i), strFilePath)
            Next

            WriteIni("MARK_PEN", "TOTAL_COUNT", ipRecipe.PenData.Count, strFilePath)

            For i As Integer = 0 To ipRecipe.PenData.Count - 1
                WriteIni("MARK_PEN", "JUMP_SPEED_" & (i + 1).ToString, ipRecipe.PenData.JumpSpeed(i), strFilePath)
                WriteIni("MARK_PEN", "MARK_SPEED_" & (i + 1).ToString, ipRecipe.PenData.MarkSpeed(i), strFilePath)
                WriteIni("MARK_PEN", "MARK_MODE_" & (i + 1).ToString, ipRecipe.PenData.MarkMode(i), strFilePath)
                WriteIni("MARK_PEN", "MARK_REPEAT_" & (i + 1).ToString, ipRecipe.PenData.Repeat(i), strFilePath)
            Next

            WriteIni("ALIGN_INFO", "ALIGN_CENTER_X", ipRecipe.dCenterX, strFilePath)
            WriteIni("ALIGN_INFO", "ALIGN_CENTER_Y", ipRecipe.dCenterY, strFilePath)
            WriteIni("ALIGN_INFO", "THETA_LIMIT_1", ipRecipe.dThetaLimit_1, strFilePath)
            WriteIni("ALIGN_INFO", "THETA_LIMIT_2", ipRecipe.dThetaLimit_2, strFilePath)
            WriteIni("ALIGN_INFO", "THETA_LIMIT_3", ipRecipe.dThetaLimit_1, strFilePath)
            WriteIni("ALIGN_INFO", "THETA_LIMIT_4", ipRecipe.dThetaLimit_2, strFilePath)
            WriteIni("ALIGN_INFO", "ALIGN_RETRY", ipRecipe.nAlignRetry, strFilePath)
            WriteIni("ALIGN_INFO", "ALIGN_DISTANCE", ipRecipe.dAlignDistance, strFilePath)
            WriteIni("ALIGN_INFO", "ALIGN_ERROR_RANGE", ipRecipe.dAlignErrorRange, strFilePath)

            For nLine = LINE.A To LINE.B
                For i = 0 To 3
                    WriteIni("MARK_INFO", "FILE_" & str(nLine) & (i + 1).ToString, ipRecipe.strMarkRecipeFile(nLine, i), strFilePath)
                    str(2) = str(nLine) & "_MARK_OFFSET_" & "X" & (i + 1).ToString
                    WriteIni("MARK_OFFSET_INFO", str(2), ipRecipe.RecipeMarkingData(nLine, i).dOffsetX, strFilePath)
                    str(2) = str(nLine) & "_MARK_OFFSET_" & "Y" & (i + 1).ToString
                    WriteIni("MARK_OFFSET_INFO", str(2), ipRecipe.RecipeMarkingData(nLine, i).dOffsetY, strFilePath)
                    str(2) = str(nLine) & "_MARK_OFFSET_" & "ANGLE" & (i + 1).ToString
                    WriteIni("MARK_OFFSET_INFO", str(2), ipRecipe.RecipeMarkingData(nLine, i).dOffsetAngle, strFilePath)
                    ' lignt
                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT_" & (i + 1).ToString
                    WriteIni("ALIGN_INFO", str(2), ipRecipe.nAlignLight(nLine, i), strFilePath)

                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT2_" & (i + 1).ToString
                    WriteIni("ALIGN_INFO", str(2), ipRecipe.nAlignLight2(nLine, i), strFilePath)

                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT_MARK2_" & (i + 1).ToString
                    WriteIni("ALIGN_INFO", str(2), ipRecipe.nAlignLight_mark2(nLine, i), strFilePath)

                    str(2) = str(nLine) & "_ALIGN_VISION_LIGHT2_MARK2_" & (i + 1).ToString
                    WriteIni("ALIGN_INFO", str(2), ipRecipe.nAlignLight2_mark2(nLine, i), strFilePath)


                    ' 
                    For j = 0 To 1      '첫번째 마크, 두번째 마크
                        For k = 0 To 2
                            ' line, panel, mark 순서, 갯수
                            str(2) = str(nLine) & "_ALIGN_MARK_CNT_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nSubMark, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_SEARCH_OFFSET_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchOffsetX, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_SEARCH_OFFSET_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchOffsetY, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_SEARCH_SIZE_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchSizeX, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_SEARCH_SIZE_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchSizeY, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MODEL_OFFSET_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelOffsetX, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MODEL_OFFSET_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelOffsetY, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MODEL_SIZE_X_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelSizeX, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MODEL_SIZE_Y_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelSizeY, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_ACCEPTANCE_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_Acceptance, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_CERTAINTY_PANEL" & (i + 1).ToString & "_MARK" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).nAlignMark_Certainty, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MARK_IMAGE_NAME_BMP_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).strAlignMarkImageBMP_FileName, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MARK_IMAGE_NAME_MMF_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).strAlignMarkImageMMF_FileName, strFilePath)

                            str(2) = str(nLine) & "_ALIGN_MARK_USE_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                            WriteIni("ALIGN_INFO", str(2), pRcpMark_Data(nLine, i, j, k).bMark, strFilePath)

                        Next
                    Next
                Next
            Next
            '20180306 chy 정도 위치 spec
            For nCnt As Integer = 0 To frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.RowCount - 1
                WriteIni("MARKING_INFO", "MARK" & (nCnt + 1).ToString, frmRecipe.m_ctrlRcpMarkEditor.dgvMarkData.Rows(nCnt).Cells(0).Value.ToString, strFilePath)
            Next

        Catch ex As Exception
            MsgBox(Err.Description & " at " & "Save Recipe")
        End Try
    End Function


    Public Function SaveModelInfo(ByVal strFilePath As String) As Boolean
        On Error GoTo SysErr

        Dim str(2) As String
        Dim strTemp As String
        str(0) = "A"
        str(1) = "B"


        For nLine = 0 To 1
            For i = 0 To 3
                For j = 0 To 1      '첫번째 마크, 두번째 마크
                    For k = 0 To 2
                        strTemp = str(nLine) & "_ALIGN_MARK_CNT_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nSubMark, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_SEARCH_OFFSET_X_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchOffsetX.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_SEARCH_OFFSET_Y_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchOffsetY.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_SEARCH_SIZE_X_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchSizeX.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_SEARCH_SIZE_Y_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_SearchSizeY.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_MODEL_OFFSET_X_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelOffsetX.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_MODEL_OFFSET_Y_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelOffsetY.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_MODEL_SIZE_X_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelSizeX.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_MODEL_SIZE_Y_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_ModelSizeY.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_ACCEPTANCE_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_Acceptance.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_CERTAINTY_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).nAlignMark_Certainty.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_MARK_IMAGE_NAME_BMP_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).strAlignMarkImageBMP_FileName.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_MARK_IMAGE_NAME_MMF_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).strAlignMarkImageMMF_FileName.ToString, strFilePath)

                        strTemp = str(nLine) & "_ALIGN_MARK_USE_PANEL" & (i + 1).ToString & "_Mark" & (j + 1).ToString & "_L" & (k + 1).ToString
                        WriteIni("ALIGN_INFO", strTemp, pRcpMark_Data(nLine, i, j, k).bMark, strFilePath)
                    Next
                Next
            Next
        Next


        Return True
        Exit Function
SysErr:
        Dim strTmp As String = Err.Description
        MsgBox(strTmp)
        Return False
    End Function



    Public Function LoadMarkingData(ByVal strFilePath As String, ByRef MarkData As MarkingData)
        On Error GoTo SysErr
        Dim tmpStr As String = ""
        Dim tmpArrStr() As String = {}
        Dim strSelMode As String = ""
        Dim nTmpTotalCmdCnt As Integer = 0

        MarkData.bV_LineFirst = CInt(modPub.ReadIni("MARK_VLINEDATA_INFO", "VLINE_MARK_FIRST", 0, strFilePath))
        MarkData.dV_LinePosX1 = CDbl(modPub.ReadIni("MARK_VLINEDATA_INFO", "VLINE_POSITION_X1", 0, strFilePath))
        MarkData.dV_LinePosX2 = CDbl(modPub.ReadIni("MARK_VLINEDATA_INFO", "VLINE_POSITION_X2", 0, strFilePath))
        MarkData.dV_LinePosY = CDbl(modPub.ReadIni("MARK_VLINEDATA_INFO", "VLINE_POSITION_Y", 0, strFilePath))
        MarkData.dV_LineMarkSpd = CDbl(modPub.ReadIni("MARK_VLINEDATA_INFO", "VLINE_MARK_SPEED", 0, strFilePath))
        MarkData.nV_LineRepeat = CInt(modPub.ReadIni("MARK_VLINEDATA_INFO", "VLINE_MARK_COUNT", 0, strFilePath))

        strSelMode = "MARK_DATA"

        tmpStr = modPub.ReadIni(strSelMode, "PEN", 0, strFilePath)
        MarkData.nPen = CInt(tmpStr)

        tmpStr = modPub.ReadIni(strSelMode, "INDEX_COUNT", 0, strFilePath)
        MarkData.nIndexCnt = CInt(tmpStr)

        tmpStr = modPub.ReadIni(strSelMode, "TOTAL_COMMAND_COUNT", 0, strFilePath)
        MarkData.nTotalCmdCnt = CInt(tmpStr)

        ReDim MarkData.ExecuteData.nGroupX(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.ExecuteData.nGroupY(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.ExecuteData.strCommand(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.ExecuteData.dPosX(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.ExecuteData.dPosY(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.ExecuteData.dAngle(MarkData.nTotalCmdCnt - 1)

        ReDim MarkData.Data(MarkData.nIndexCnt - 1)
        ReDim MarkData.Data(MarkData.nIndexCnt - 1).nGroupX(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.Data(MarkData.nIndexCnt - 1).nGroupY(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.Data(MarkData.nIndexCnt - 1).strCommand(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.Data(MarkData.nIndexCnt - 1).dPosX(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.Data(MarkData.nIndexCnt - 1).dPosY(MarkData.nTotalCmdCnt - 1)
        ReDim MarkData.Data(MarkData.nIndexCnt - 1).dAngle(MarkData.nTotalCmdCnt - 1)

        For i As Integer = 0 To MarkData.nIndexCnt - 1

            For j As Integer = 0 To MarkData.nTotalCmdCnt - 1
                'tmpStr = modPub.ReadIni(strSelMode, (j + 1).ToString, "", strFilePath)
                tmpStr = modPub.ReadIni(strSelMode, (j).ToString, "", strFilePath)
                tmpArrStr = Split(tmpStr, ",")
                'tmpArrStr = Split(tmpStr, ",")
                If tmpArrStr.Length = 6 Then
                    MarkData.ExecuteData.nGroupX(nTmpTotalCmdCnt) = CInt(tmpArrStr(0))
                    MarkData.ExecuteData.nGroupY(nTmpTotalCmdCnt) = CInt(tmpArrStr(1))
                    MarkData.ExecuteData.strCommand(nTmpTotalCmdCnt) = tmpArrStr(2)
                    MarkData.ExecuteData.dPosX(nTmpTotalCmdCnt) = CDbl(tmpArrStr(3))
                    MarkData.ExecuteData.dPosY(nTmpTotalCmdCnt) = CDbl(tmpArrStr(4))
                    MarkData.ExecuteData.dAngle(nTmpTotalCmdCnt) = CDbl(tmpArrStr(5))

                    MarkData.Data(i).nGroupX(j) = CInt(tmpArrStr(0))
                    MarkData.Data(i).nGroupY(j) = CInt(tmpArrStr(1))
                    MarkData.Data(i).strCommand(j) = tmpArrStr(2)
                    MarkData.Data(i).dPosX(j) = CDbl(tmpArrStr(3))
                    MarkData.Data(i).dPosY(j) = CDbl(tmpArrStr(4))
                    MarkData.Data(i).dAngle(j) = CDbl(tmpArrStr(5))

                    nTmpTotalCmdCnt = nTmpTotalCmdCnt + 1
                Else
                    Return False
                    Exit Function
                End If
            Next

        Next

        'For i As Integer = 0 To MarkData.nIndexCnt - 1
        '    tmpStr = modPub.ReadIni(strSelMode, "0_" & i.ToString, 0, strFilePath)
        '    MarkData.Data(i).nCmdCnt = CInt(tmpStr)
        '    ReDim MarkData.Data(i).strCommand(MarkData.Data(i).nCmdCnt - 1)
        '    ReDim MarkData.Data(i).dPosX(MarkData.Data(i).nCmdCnt - 1)
        '    ReDim MarkData.Data(i).dPosY(MarkData.Data(i).nCmdCnt - 1)
        '    ReDim MarkData.Data(i).dAngle(MarkData.Data(i).nCmdCnt - 1)

        '    For j As Integer = 0 To MarkData.Data(i).nCmdCnt - 1
        '        tmpStr = modPub.ReadIni(strSelMode, (j + 1).ToString & "_" & i.ToString, "", strFilePath)
        '        tmpArrStr = Split(tmpStr, ",")
        '        If tmpArrStr.Length = 4 Then
        '            MarkData.ExecuteData.strCommand(nTmpTotalCmdCnt) = tmpArrStr(0)
        '            MarkData.ExecuteData.dPosX(nTmpTotalCmdCnt) = CDbl(tmpArrStr(1))
        '            MarkData.ExecuteData.dPosY(nTmpTotalCmdCnt) = CDbl(tmpArrStr(2))
        '            MarkData.ExecuteData.dAngle(nTmpTotalCmdCnt) = CDbl(tmpArrStr(3))
        '            MarkData.Data(i).strCommand(j) = tmpArrStr(0)
        '            MarkData.Data(i).dPosX(j) = CDbl(tmpArrStr(1))
        '            MarkData.Data(i).dPosY(j) = CDbl(tmpArrStr(2))
        '            MarkData.Data(i).dAngle(j) = CDbl(tmpArrStr(3))
        '            nTmpTotalCmdCnt = nTmpTotalCmdCnt + 1
        '        Else
        '            Return False
        '            Exit Function
        '        End If
        '    Next
        'Next

        Return True
        Exit Function
SysErr:
        Return False

    End Function

    Public Function ExecuteMarking(ByVal nIndex As Integer, ByVal dOffsetX As Double, ByVal dOffsetY As Double, ByVal dAngle As Double, _
                                   ByVal MarkData As MarkingData, ByVal Pen As MarkPenData, ByVal bLine_1 As Boolean) As Boolean
        On Error GoTo SysErr

        Dim nScale As Double = 1000
        Dim tmpMarkSpeed As Integer = 0
        Dim tmpJumpSpeed As Integer = 0
        Dim nDir As Integer = 1 ' 반복 설정 후에 처리
        Dim nCnt As Integer = 0
        '20160824 JCM
        Dim cmd As String = ""
        Dim posX As Double = 0
        Dim posY As Double = 0
        Dim radius As Double = 0
        Dim posPreX As Double = 0
        Dim posPreY As Double = 0
        Dim centerX As Double = 0
        Dim centerY As Double = 0
        Dim angle As Double = 0

        Dim offsetX As Double = dOffsetX * nScale
        Dim offsetY As Double = dOffsetY * nScale
        Dim offsetAngle As Double = dAngle

        pScanner(nIndex).RTC6MarkListStart()

        If MarkData.nV_LineRepeat > 0 Then
            If MarkData.bV_LineFirst = True Then
                pScanner(nIndex).RTC6MarkSpeedSet(MarkData.dV_LineMarkSpd)
                For k As Integer = 0 To MarkData.nV_LineRepeat - 1
                    pScanner(nIndex).RTC6JumpABSAdd(MarkData.dV_LinePosX1 * nScale, MarkData.dV_LinePosY * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
                    pScanner(nIndex).RTC6MarkABSAdd(MarkData.dV_LinePosX2 * nScale, MarkData.dV_LinePosY * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
                Next
            End If
        End If

        If bLine_1 = True Then
            '' A1, B1 Check Point Add
            If MarkData.dV_LinePosX1 < MarkData.dV_LinePosX2 Then
                'Scanner.RTC4JumpABSAdd((MarkData.dV_LinePosX1 + 0.25) * nScale, (MarkData.dV_LinePosY + 0.08) * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
                'Scanner.RTC4MarkABSAdd((MarkData.dV_LinePosX1 + 0.3) * nScale, (MarkData.dV_LinePosY + 0.08) * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
            Else
                'Scanner.RTC4JumpABSAdd((MarkData.dV_LinePosX2 + 0.25) * nScale, (MarkData.dV_LinePosY + 0.08) * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
                'Scanner.RTC4MarkABSAdd((MarkData.dV_LinePosX2 + 0.3) * nScale, (MarkData.dV_LinePosY + 0.08) * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
            End If
        End If

        pScanner(nIndex).RTC6JumpSpeedSet(Pen.JumpSpeed(MarkData.nPen - 1))
        pScanner(nIndex).RTC6MarkSpeedSet(Pen.MarkSpeed(MarkData.nPen - 1))

        Select Case Pen.MarkMode(MarkData.nPen - 1)

            Case 1
                For i As Integer = 0 To Pen.Repeat(MarkData.nPen - 1) - 1
                    nCnt = 0
                    For j As Integer = 0 To MarkData.nTotalCmdCnt - 1
                        cmd = MarkData.ExecuteData.strCommand(nCnt)
                        posX = MarkData.ExecuteData.dPosX(nCnt) * nScale  ' 가공 끝점
                        posY = MarkData.ExecuteData.dPosY(nCnt) * nScale  ' 가공 끝점
                        radius = MarkData.ExecuteData.dAngle(nCnt) * nScale        ' 임시로 Recipe 각도값을 반지름 길이로 사용한다
                        posPreX = 0
                        posPreY = 0


                        If 0 < nCnt Then
                            posPreX = MarkData.ExecuteData.dPosX(nCnt - 1) * nScale  ' 가공 시작점
                            posPreY = MarkData.ExecuteData.dPosY(nCnt - 1) * nScale  ' 가공 시작점
                        End If

                        If nCnt = 0 Then
                            If Not cmd = "JA" Then
                                ' 시작이 JA가 아닌 경우, 처음에 (0, 0)으로 JA를 넣어준다
                                pScanner(nIndex).RTC6JumpABSAdd(0.0, 0.0, offsetX, offsetY, offsetAngle)
                            End If
                        End If

                        If nCnt = MarkData.ExecuteData.nCmdCnt - 1 Then
                            If cmd = "JA" Then
                                ' 끝이 JA인 경우, Pass 한다
                                Continue For
                            End If
                        End If

                        Select Case cmd
                            Case "JA"
                                pScanner(nIndex).RTC6JumpABSAdd(posX, posY, offsetX, offsetY, offsetAngle)
                            Case "MA"
                                pScanner(nIndex).RTC6MarkABSAdd(posX, posY, offsetX, offsetY, offsetAngle)
                            Case "AA"
                                If CalcRotationCenter(posPreX, posPreY, posX, posY, radius, centerX, centerY, angle) Then
                                    pScanner(nIndex).RTC6ArcABSAdd(centerX, centerY, angle, offsetX, offsetY, offsetAngle)
                                End If
                        End Select
                        nCnt = nCnt + 1
                    Next
                Next

            Case 2
                For i As Integer = 0 To Pen.Repeat(MarkData.nPen - 1) - 1
                    nCnt = MarkData.nTotalCmdCnt - 1
                    For j As Integer = 0 To MarkData.nTotalCmdCnt - 1
                        cmd = MarkData.ExecuteData.strCommand(nCnt)
                        posX = MarkData.ExecuteData.dPosX(nCnt) * nScale  ' 가공 끝점
                        posY = MarkData.ExecuteData.dPosY(nCnt) * nScale  ' 가공 끝점
                        radius = MarkData.ExecuteData.dAngle(nCnt) * nScale        ' 임시로 Recipe 각도값을 반지름 길이로 사용한다
                        posPreX = 0
                        posPreY = 0

                        If 0 < nCnt Then
                            posPreX = MarkData.ExecuteData.dPosX(nCnt - 1) * nScale  ' 가공 끝점
                            posPreY = MarkData.ExecuteData.dPosY(nCnt - 1) * nScale  ' 가공 끝점
                        End If

                        If nCnt = MarkData.nTotalCmdCnt - 1 Then
                            If cmd = "MA" Or cmd = "AA" Then
                                '가공 시작점으로 Jump 하는 Cmd를 추가해준다
                                pScanner(nIndex).RTC6JumpABSAdd(posX, posY, offsetX, offsetY, offsetAngle)
                            End If
                        End If

                        If nCnt = 0 Then
                            If cmd = "JA" Then
                                ' 끝이 JA인 경우, Pass 한다
                                Continue For
                            End If
                        End If

                        Select Case cmd
                            Case "JA"
                                pScanner(nIndex).RTC6JumpABSAdd(posPreX, posPreY, offsetX, offsetY, offsetAngle)
                            Case "MA"
                                pScanner(nIndex).RTC6MarkABSAdd(posPreX, posPreY, offsetX, offsetY, offsetAngle)
                            Case "AA"
                                If CalcRotationCenter(posX, posY, posPreX, posPreY, -radius, centerX, centerY, angle) Then
                                    pScanner(nIndex).RTC6ArcABSAdd(centerX, centerY, angle, offsetX, offsetY, offsetAngle)
                                End If
                        End Select
                        nCnt = nCnt - 1
                    Next
                Next

            Case 3
                nDir = 1
                nCnt = 0
                For i As Integer = 0 To Pen.Repeat(MarkData.nPen - 1) - 1
                    If nDir = 1 Then
                        '정방향
                        For j As Integer = 0 To MarkData.nTotalCmdCnt - 1

                            cmd = MarkData.ExecuteData.strCommand(nCnt)
                            posX = MarkData.ExecuteData.dPosX(nCnt) * nScale  ' 가공 끝점
                            posY = MarkData.ExecuteData.dPosY(nCnt) * nScale  ' 가공 끝점
                            radius = MarkData.ExecuteData.dAngle(nCnt) * nScale        ' 임시로 Recipe 각도값을 반지름 길이로 사용한다
                            posPreX = 0
                            posPreY = 0
                            If 0 < nCnt Then
                                posPreX = MarkData.ExecuteData.dPosX(nCnt - 1) * nScale  ' 가공 시작점
                                posPreY = MarkData.ExecuteData.dPosY(nCnt - 1) * nScale  ' 가공 시작점
                            End If

                            If nCnt = 0 Then
                                If Not cmd = "JA" Then
                                    ' 시작이 JA가 아닌 경우, 처음에 (0, 0)으로 JA를 넣어준다
                                    pScanner(nIndex).RTC6JumpABSAdd(0.0, 0.0, offsetX, offsetY, offsetAngle)
                                End If

                                If 0 < j Then
                                    If cmd = "JA" Then
                                        ' 반복 정주행 시, 시작점이 JA인 경우, Pass 한다
                                        Continue For
                                    End If
                                End If
                            End If

                            If nCnt = MarkData.nTotalCmdCnt - 1 Then
                                If cmd = "JA" Then
                                    ' 끝이 JA인 경우, Pass 한다
                                    Continue For
                                End If
                            End If

                            Select Case cmd
                                Case "JA"
                                    pScanner(nIndex).RTC6JumpABSAdd(posX, posY, offsetX, offsetY, offsetAngle)
                                Case "MA"
                                    pScanner(nIndex).RTC6MarkABSAdd(posX, posY, offsetX, offsetY, offsetAngle)
                                    ' pScanner(nIndex).RTC6_CrossShot_Seq(posX, posY, offsetX, offsetY, offsetAngle, 1000)
                                Case "AA"
                                    If CalcRotationCenter(posPreX, posPreY, posX, posY, radius, centerX, centerY, angle) Then
                                        pScanner(nIndex).RTC6ArcABSAdd(centerX, centerY, angle, offsetX, offsetY, offsetAngle)
                                        'pScanner(nIndex).RTC6_CrossShot_Seq(posX, posY, offsetX, offsetY, offsetAngle, 1000)
                                    End If
                            End Select
                            nCnt = nCnt + 1
                        Next
                        nDir = 2    '정방향 -> 역방향
                        nCnt = MarkData.nTotalCmdCnt - 1

                    ElseIf nDir = 2 Then
                        For j As Integer = 0 To MarkData.nTotalCmdCnt - 1
                            cmd = MarkData.ExecuteData.strCommand(nCnt)
                            posX = MarkData.ExecuteData.dPosX(nCnt) * nScale  ' 가공 끝점
                            posY = MarkData.ExecuteData.dPosY(nCnt) * nScale  ' 가공 끝점
                            radius = MarkData.ExecuteData.dAngle(nCnt) * nScale        ' 임시로 Recipe 각도값을 반지름 길이로 사용한다
                            posPreX = 0
                            posPreY = 0

                            If 0 < nCnt Then
                                posPreX = MarkData.ExecuteData.dPosX(nCnt - 1) * nScale  ' 가공 끝점
                                posPreY = MarkData.ExecuteData.dPosY(nCnt - 1) * nScale  ' 가공 끝점
                            End If

                            If nCnt = MarkData.nTotalCmdCnt - 1 Then
                                If cmd = "MA" Or cmd = "AA" Then
                                    '가공 시작점으로 Jump 하는 Cmd를 추가해준다
                                    pScanner(nIndex).RTC6JumpABSAdd(posX, posY, offsetX, offsetY, offsetAngle)
                                End If
                            End If

                            If nCnt = 0 Then
                                If cmd = "JA" Then
                                    ' 끝이 JA인 경우, Pass 한다
                                    Continue For
                                End If
                            End If

                            Select Case cmd
                                Case "JA"
                                    pScanner(nIndex).RTC6JumpABSAdd(posPreX, posPreY, offsetX, offsetY, offsetAngle)
                                Case "MA"
                                    pScanner(nIndex).RTC6MarkABSAdd(posPreX, posPreY, offsetX, offsetY, offsetAngle)
                                    ' pScanner(nIndex).RTC6_CrossShot_Seq(posPreX, posPreY, offsetX, offsetY, offsetAngle, 1000)
                                Case "AA"
                                    If CalcRotationCenter(posX, posY, posPreX, posPreY, -radius, centerX, centerY, angle) Then
                                        pScanner(nIndex).RTC6ArcABSAdd(centerX, centerY, angle, offsetX, offsetY, offsetAngle)
                                        'pScanner(nIndex).RTC6_CrossShot_Seq(posX, posY, offsetX, offsetY, offsetAngle, 1000)
                                    End If
                            End Select
                            nCnt = nCnt - 1
                        Next
                        nCnt = 0
                        nDir = 1    '역방향 -> 정방향
                    End If
                Next

        End Select

        If MarkData.nV_LineRepeat > 0 Then
            If MarkData.bV_LineFirst = False Then
                pScanner(nIndex).RTC6MarkSpeedSet(MarkData.dV_LineMarkSpd)
                For k As Integer = 0 To MarkData.nV_LineRepeat - 1
                    pScanner(nIndex).RTC6JumpABSAdd(MarkData.dV_LinePosX1 * nScale, MarkData.dV_LinePosY * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
                    pScanner(nIndex).RTC6MarkABSAdd(MarkData.dV_LinePosX2 * nScale, MarkData.dV_LinePosY * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
                Next
                pScanner(nIndex).RTC6JumpABSAdd(MarkData.ExecuteData.dPosX(0) * nScale, MarkData.ExecuteData.dPosY(0) * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
            ElseIf MarkData.bV_LineFirst = True Then
                pScanner(nIndex).RTC6JumpABSAdd(MarkData.dV_LinePosX1 * nScale, MarkData.dV_LinePosY * nScale, dOffsetX * nScale, dOffsetY * nScale, dAngle)
            End If
        End If

        pScanner(nIndex).RTC6MarkListEnd()
        Return True
        Exit Function
SysErr:
        Dim strErrMsg As String = Err.Description
        Return False
    End Function

    '이동 시작점 P1(X1, Y1), P2(X2, Y2)의 좌표와 회전반경 R값을 알고 있을 때 회전 중심점 P0(X0, Y0)와 각도 Angle 값을 계산하는 함수
    Public Function CalcRotationCenter(ByVal startX As Double, ByVal startY As Double, ByVal endX As Double, ByVal endY As Double, ByVal radius As Double, _
                                       ByRef centerX As Double, ByRef centerY As Double, ByRef angle As Double) As Boolean
        If startX = endX And endX = endY Then
            Return False
        End If

        If radius = 0 Then
            Return False
        End If

        Dim dist As Double = Math.Sqrt(Math.Pow(startX - endX, 2.0) + Math.Pow(startY - endY, 2.0))
        Dim middleX As Double = (startX + endX) / 2.0
        Dim middleY As Double = (startY + endY) / 2.0

        '시작점과 끝점 사이의 거리는 원의 지름보다 작아야 한다
        If Math.Abs(radius * 2.0) < dist Then
            Return False
        End If

        If 0 < radius Then
            '시계 방향 회전 시
            centerX = middleX + Math.Sqrt(Math.Pow(radius, 2.0) - Math.Pow(dist / 2.0, 2.0)) * (endY - startY) / dist
            centerY = middleY - Math.Sqrt(Math.Pow(radius, 2.0) - Math.Pow(dist / 2.0, 2.0)) * (endX - startX) / dist
        Else
            '반시계 방향 회전 시
            centerX = middleX - Math.Sqrt(Math.Pow(radius, 2.0) - Math.Pow(dist / 2.0, 2.0)) * (endY - startY) / dist
            centerY = middleY + Math.Sqrt(Math.Pow(radius, 2.0) - Math.Pow(dist / 2.0, 2.0)) * (endX - startX) / dist
        End If

        angle = (Math.Atan2(startY - centerY, startX - centerX) - Math.Atan2(endY - centerY, endX - centerX)) * 180.0 / Math.PI

        If 0 < radius Then
            '시계 방향 회전 시
            If angle < 0 Then
                angle = angle + 360.0
            End If
        Else
            '반시계 방향 회전 시
            If 0 < angle Then
                angle = angle - 360.0
            End If
        End If

        Return True
    End Function

    '20160828 JCM
    Public Function RefreshRecipeList(ByVal ipRecipeFolderPath As String, ByRef strRecipeList() As String) As Boolean
        On Error GoTo SysErr
        Dim strTempRecipeList() As String = {}
        Dim strTemp() As String = {}
        Dim nTmpModelNum() As String = {}

        Dim strTempOutRecipeList(99) As String
        Dim nRecipeListCnt As Integer = 0
        ReDim strRecipeList(99)

        For k As Integer = 0 To 99
            strRecipeList(k) = ""
        Next

        strTempRecipeList = System.IO.Directory.GetDirectories(ipRecipeFolderPath)

        For i As Integer = 0 To strTempRecipeList.Length - 1
            If strTempRecipeList(i).Contains("~") = True Then
                strTempOutRecipeList(nRecipeListCnt) = strTempRecipeList(i)
                nRecipeListCnt = nRecipeListCnt + 1
            End If
        Next

        ReDim nTmpModelNum(nRecipeListCnt - 1)

        For j As Integer = 0 To strTempOutRecipeList.Length - 1
            If j < nRecipeListCnt Then
                strTemp = Split(modPub.GetFileName(strTempOutRecipeList(j), 0), "~")
                nTmpModelNum(j) = strTemp(0)
                strRecipeList(nTmpModelNum(j) - 1) = strTemp(1)
            End If
        Next


        Return True
SysErr:
        Return False
    End Function

    Public Function CreateRecipe(ByVal ipRecipeFolderPath As String, ByVal IpRecipeNum As Integer, ByVal IpRecipeName As String) As Boolean
        On Error GoTo SysErr
        Dim tmpStrModelPath As String = ""
        Dim tmpStrAlignData() As String = {}
        Dim tmpStrMarkName As String = ""
        Dim tmpStrAlignName As String = ""

        Dim tmpStrMarkData() As String = {}

        If System.IO.Directory.Exists(ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName) = True Then
            System.IO.Directory.Delete(ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName, True)
        End If
        System.IO.Directory.CreateDirectory(ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName)
        System.IO.Directory.CreateDirectory(ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName & "\Align Data")
        System.IO.Directory.CreateDirectory(ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName & "\Mark Data")

        tmpStrModelPath = ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName

        System.IO.File.Copy(ipRecipeFolderPath & "\Default_Test\Default_Test.ini", tmpStrModelPath & "\" & IpRecipeName & ".ini")

        tmpStrAlignData = System.IO.Directory.GetFiles(pCurSystemParam.strSystemRootPath & "\Recipe\Default_Test\Align Data")
        tmpStrMarkData = System.IO.Directory.GetFiles(pCurSystemParam.strSystemRootPath & "\Recipe\Default_Test\Mark Data")

        For i As Integer = 0 To tmpStrAlignData.Length - 1
            tmpStrAlignName = modPub.GetFileName(tmpStrAlignData(i), True)
            System.IO.File.Copy(tmpStrAlignData(i), tmpStrModelPath & "\Align Data\" & tmpStrAlignName)
        Next

        For j As Integer = 0 To tmpStrMarkData.Length - 1
            tmpStrMarkName = modPub.GetFileName(tmpStrMarkData(j), True)
            System.IO.File.Copy(tmpStrMarkData(j), tmpStrModelPath & "\Mark Data\" & tmpStrMarkName)
        Next

        SetRecipeIni(IpRecipeNum, IpRecipeName, tmpStrModelPath)

        RefreshRecipeList(pCurSystemParam.strSystemRootPath & "\Recipe", pCurSystemParam.strModelList)

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Public Function CopyRecipe(ByVal ipRecipeFolderPath As String, ByVal IpSourceRecipeNum As Integer, ByVal IpSourceRecipeName As String, ByVal IpDestRecipeNum As Integer, ByVal IpDestRecipeName As String) As Boolean
        On Error GoTo SysErr
        Dim tmpStrSourceModelPath As String = ""
        Dim tmpStrDestModelPath As String = ""
        Dim tmpStrAlignData() As String = {}
        Dim tmpStrMarkName As String = ""
        Dim tmpStrAlignName As String = ""

        Dim tmpStrMarkData() As String = {}

        If System.IO.Directory.Exists(ipRecipeFolderPath & "\" & IpDestRecipeNum.ToString & "~" & IpDestRecipeName) = True Then
            System.IO.Directory.Delete(ipRecipeFolderPath & "\" & IpDestRecipeNum.ToString & "~" & IpDestRecipeName, True)
        End If

        System.IO.Directory.CreateDirectory(ipRecipeFolderPath & "\" & IpDestRecipeNum.ToString & "~" & IpDestRecipeName)
        System.IO.Directory.CreateDirectory(ipRecipeFolderPath & "\" & IpDestRecipeNum.ToString & "~" & IpDestRecipeName & "\Align Data")
        System.IO.Directory.CreateDirectory(ipRecipeFolderPath & "\" & IpDestRecipeNum.ToString & "~" & IpDestRecipeName & "\Mark Data")

        tmpStrSourceModelPath = ipRecipeFolderPath & "\" & IpSourceRecipeNum.ToString & "~" & IpSourceRecipeName
        tmpStrDestModelPath = ipRecipeFolderPath & "\" & IpDestRecipeNum.ToString & "~" & IpDestRecipeName

        System.IO.File.Copy(tmpStrSourceModelPath & "\" & IpSourceRecipeName & ".ini", tmpStrDestModelPath & "\" & IpDestRecipeName & ".ini")

        tmpStrAlignData = System.IO.Directory.GetFiles(tmpStrSourceModelPath & "\Align Data")
        tmpStrMarkData = System.IO.Directory.GetFiles(tmpStrSourceModelPath & "\Mark Data")

        For i As Integer = 0 To tmpStrAlignData.Length - 1
            tmpStrAlignName = modPub.GetFileName(tmpStrAlignData(i), True)
            System.IO.File.Copy(tmpStrAlignData(i), tmpStrDestModelPath & "\Align Data\" & tmpStrAlignName)
        Next

        For j As Integer = 0 To tmpStrMarkData.Length - 1
            tmpStrMarkName = modPub.GetFileName(tmpStrMarkData(j), True)
            System.IO.File.Copy(tmpStrMarkData(j), tmpStrDestModelPath & "\Mark Data\" & tmpStrMarkName)
        Next

        SetRecipeIni(IpDestRecipeNum, IpDestRecipeName, tmpStrDestModelPath)

        RefreshRecipeList(pCurSystemParam.strSystemRootPath & "\Recipe", pCurSystemParam.strModelList)

        Return True
        Exit Function
SysErr:
        Return False
    End Function

    Public Function RenameRecipe(ByVal ipCurrentRecipeFilePath As String, ByVal ipRecipeFolder As String, ByVal ipChangeRecipeNumber As Integer, ByVal ipChangeRecipeName As String, ByVal ipCurRecipe As RecipeParam)
        On Error GoTo SysErr

        Dim tmpStrSourceModelPath As String = ""
        Dim tmpStrDestModelPath As String = ""

        tmpStrSourceModelPath = ipCurrentRecipeFilePath '& "\" & pMelsec.PLC_Infomation.nRecipeNo.ToString & "~" & pMelsec.PLC_Infomation.strModelName
        tmpStrDestModelPath = ipRecipeFolder & "\" & ipChangeRecipeNumber.ToString & "~" & ipChangeRecipeName & "\" & ipChangeRecipeNumber.ToString & "~" & ipChangeRecipeName & ".ini"

        System.IO.File.Copy(tmpStrSourceModelPath & "\" & ipRecipeFolder & ".ini", tmpStrDestModelPath & "\" & ipChangeRecipeName & ".ini")

        System.IO.Directory.Delete(tmpStrSourceModelPath & "\" & ipRecipeFolder & ".ini", True)

        SetRecipeIni(ipChangeRecipeNumber, ipChangeRecipeName, tmpStrDestModelPath)

        RefreshRecipeList(pCurSystemParam.strSystemRootPath & "\Recipe", pCurSystemParam.strModelList)

        'Dim tmpRecipeMoveFilePath As String = ""

        'If System.IO.Directory.Exists(ipCurRecipe.strTmpRecipePath) = True Then

        '    System.IO.File.Copy(ipCurrentRecipeFilePath & "\" & ipRecipeFolder & ".ini", ipChangeRecipeNumber & "\" & ipChangeRecipeName & ".ini")

        '    tmpRecipeMoveFilePath = ipRecipeFolder & "\" & ipChangeRecipeNumber & "~" & ipChangeRecipeName & "\" & ipChangeRecipeName & ".ini"

        '    System.IO.File.Move(ipCurrentRecipeFilePath, "C:\Temp.ini")
        '    System.IO.Directory.Move(ipCurRecipe.strTmpRecipePath, ipRecipeFolder & "\" & ipChangeRecipeNumber & "~" & ipChangeRecipeName)
        '    System.IO.File.Move("C:\Temp.ini", tmpRecipeMoveFilePath)

        '    SetRecipeIni(ipChangeRecipeNumber, ipChangeRecipeName, ipRecipeFolder & "\" & ipChangeRecipeNumber & "~" & ipChangeRecipeName)
        '    System.IO.Directory.Delete(ipCurRecipe.strTmpRecipePath, True)

        '    RefreshRecipeList(pCurSystemParam.strSystemRootPath & "\Recipe", pCurSystemParam.strModelList)
        'End If

        Return True
SysErr:
        Return False
    End Function


    Public Function DeleteRecipe(ByVal ipRecipeFolderPath As String, ByVal IpRecipeNum As Integer, ByVal IpRecipeName As String) As Boolean
        On Error GoTo SysErr
        If System.IO.Directory.Exists(ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName) = True Then
            System.IO.Directory.Delete(ipRecipeFolderPath & "\" & IpRecipeNum.ToString & "~" & IpRecipeName, True)
        End If

        RefreshRecipeList(pCurSystemParam.strSystemRootPath & "\Recipe", pCurSystemParam.strModelList)

        ' SaveParam(pStrTmpSystemRoot, pSetSystemParam)

        Return True
SysErr:
        Return False
    End Function

    Private Function SetRecipeIni(ByVal ipRecipeNum As String, ByVal ipRecipeName As String, ByVal ipRecipeFilePath As String)
        On Error GoTo SysErr

        WriteIni("MODEL_NAME", "FILE", ipRecipeName, ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MODEL_NAME", "NUMBER", ipRecipeNum, ipRecipeFilePath & "\" & ipRecipeName & ".ini")
#If HEAD_2 Then
        WriteIni("MARK_INFO", "FILE_A1", ipRecipeFilePath & "\Mark Data\MARK_INFO_A1.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_A2", ipRecipeFilePath & "\Mark Data\MARK_INFO_A2.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_B1", ipRecipeFilePath & "\Mark Data\MARK_INFO_B1.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_B2", ipRecipeFilePath & "\Mark Data\MARK_INFO_B2.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini") 

#Else
        WriteIni("MARK_INFO", "FILE_A1", ipRecipeFilePath & "\Mark Data\MARK_INFO_A1.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_A2", ipRecipeFilePath & "\Mark Data\MARK_INFO_A2.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_A3", ipRecipeFilePath & "\Mark Data\MARK_INFO_A3.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_A4", ipRecipeFilePath & "\Mark Data\MARK_INFO_A4.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_B1", ipRecipeFilePath & "\Mark Data\MARK_INFO_B1.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_B2", ipRecipeFilePath & "\Mark Data\MARK_INFO_B2.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_B3", ipRecipeFilePath & "\Mark Data\MARK_INFO_B3.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("MARK_INFO", "FILE_B4", ipRecipeFilePath & "\Mark Data\MARK_INFO_B4.ini", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
#End If
       

#If HEAD_2 Then
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
#Else
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel1_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel2_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel3_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel3_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel3_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel3_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel3_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel3_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel3_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel3_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel3_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel3_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel3_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel3_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel4_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK1_L1", ipRecipeFilePath & "\Align Data\A_Panel4_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel4_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK1_L2", ipRecipeFilePath & "\Align Data\A_Panel4_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel4_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK1_L3", ipRecipeFilePath & "\Align Data\A_Panel4_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel4_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK2_L1", ipRecipeFilePath & "\Align Data\A_Panel4_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel4_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK2_L2", ipRecipeFilePath & "\Align Data\A_Panel4_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel4_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "A_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK2_L3", ipRecipeFilePath & "\Align Data\A_Panel4_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

#End If
        
#If HEAD_2 Then
        'B
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
#Else
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL1_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel1_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL2_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel2_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel3_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel3_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel3_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel3_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel3_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel3_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel3_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel3_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel3_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel3_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL3_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel3_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL3_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel3_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")

        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel4_Mark1_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK1_L1", ipRecipeFilePath & "\Align Data\B_Panel4_Mark1_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel4_Mark1_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK1_L2", ipRecipeFilePath & "\Align Data\B_Panel4_Mark1_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel4_Mark1_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK1_L3", ipRecipeFilePath & "\Align Data\B_Panel4_Mark1_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel4_Mark2_1.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK2_L1", ipRecipeFilePath & "\Align Data\B_Panel4_Mark2_1.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel4_Mark2_2.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK2_L2", ipRecipeFilePath & "\Align Data\B_Panel4_Mark2_2.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_BMP_PANEL4_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel4_Mark2_3.bmp", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
        WriteIni("ALIGN_INFO", "B_ALIGN_MARK_IMAGE_NAME_MMF_PANEL4_MARK2_L3", ipRecipeFilePath & "\Align Data\B_Panel4_Mark2_3.mmf", ipRecipeFilePath & "\" & ipRecipeName & ".ini")
#End If
        Return True
SysErr:
        Return False
    End Function

    Public Function Displace_Data_Read(ByVal nLine As Integer)


        pDisplaceData.m_bline = nLine

        pDisplaceData.maxcnt = frmSetting.m_ctrlSetting_Displace.m_ctrlLine(nLine, frmSetting.m_ctrlSetting_Displace.tabPanel.SelectedIndex).GridListView.RowCount

        pDisplaceData.pnMaxCnt = pDisplaceData.maxcnt

        ReDim pDisplaceData.pdValueX(pDisplaceData.pnMaxCnt - 1)
        ReDim pDisplaceData.pdValueY(pDisplaceData.pnMaxCnt - 1)
        ReDim pDisplaceData.pdIndex(pDisplaceData.pnMaxCnt - 1)
        ReDim pDisplaceData.dGridviewVal(pDisplaceData.pnMaxCnt - 1)
        ReDim pDisplaceData.DataGridIndex(pDisplaceData.pnMaxCnt - 1)
        ReDim pDisplaceData.DataGridValue(pDisplaceData.pnMaxCnt - 1)
        ReDim pDisplaceData.m_lblValueMax(3)
        ReDim pDisplaceData.m_lblValueMin(3)
        ReDim pDisplaceData.m_lblValueAvg(3)

        For i As Integer = 0 To pDisplaceData.pnMaxCnt - 1
            pDisplaceData.pdIndex(i) = frmSetting.m_ctrlSetting_Displace.m_ctrlLine(nLine, frmSetting.m_ctrlSetting_Displace.tabPanel.SelectedIndex).GridListView.Rows(i).Cells(0).Value()
            pDisplaceData.pdValueX(i) = frmSetting.m_ctrlSetting_Displace.m_ctrlLine(nLine, frmSetting.m_ctrlSetting_Displace.tabPanel.SelectedIndex).GridListView.Rows(i).Cells(1).Value()
            pDisplaceData.pdValueY(i) = frmSetting.m_ctrlSetting_Displace.m_ctrlLine(nLine, frmSetting.m_ctrlSetting_Displace.tabPanel.SelectedIndex).GridListView.Rows(i).Cells(2).Value()
        Next

        Return True
    End Function
End Module
