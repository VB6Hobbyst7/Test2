#If SIMUL <> 1 Then
Imports Matrox.MatroxImagingLibrary
#End If

Public Class ctrlAlignMarkSetting

    Public m_iLine As Integer = 0
    Public m_iPanel As Integer = 0      ' 4개의 panel에 대해
    Public m_iMark As Integer = 0      ' 1st mark, 2nd mark
    Public m_iIndex As Integer = 0      ' mark 갯수만큼  0, 1, 2

    '카메라 정보를 가지고.. 마크1 인지 마크2 인지 구분 짓자.
    'Public m_iCamera As Integer = 0         'Camera1, 2, 3, 4 (A1, A2, B1, B2)
    '이거.. 하자.
    Public m_iPanelMark As Integer = 0  'Panel And mark Num 0,1,2,3,4,5,6,7 || 0번이 1번판넬 1번 마크, 1번이 1번판넬 2번마크 ...

    Private m_MarkData As AlignData

    'Image용 FileStream
    Dim fs As System.IO.FileStream

    Dim bmakeRoi As Boolean = False
    Dim bsaveRoi As Boolean = False
    Dim bmakeModel As Boolean = False
    Dim bsetModel As Boolean = False
    Dim brefpPoint As Boolean = False
    Dim bmakeApply As Boolean = False

    'GYN 이미지 처리 부분 수정 Part
    'Public pbPaint As PictureBox
    Public bMap As Bitmap
    Public grpTools As Graphics

    Private Sub InitImage()

        'PictureBox 초기화
        'pbPaint = New PictureBox
        'pbPaint.Size = New Size(Me.Width, Me.Height)
        'pbPaint .Location = New Point(0,0)

        '그림판 생성
        bMap = New Bitmap(picModel.Width, picModel.Height)
        '그림판 동기화
        grpTools = Graphics.FromImage(bMap)

        '컨트롤 추가 
        'Control.Add(pbPaint)

    End Sub

    ' 이미지 그리기
    Private Sub AddImage(bmp As Bitmap, pos As Point, color As Color, size As Size)

        ' 투명 컬러 지정
        bmp.MakeTransparent(color)
        ' size 입력이 없을 시 bitmap 참고
        If size = Nothing Then
            size.Width = picModel.Width
            size.Height = picModel.Height
        End If
        ' bmp를 그림판에 그림
        grpTools.DrawImage(bmp, pos.X, pos.Y, size.Width, size.Height)

    End Sub

    ' Frame 이미지 출력
    Private Sub DrawFenceSPT(ByVal strName As String)
#If SIMUL <> 1 Then



        grpTools.Clear(Color.White)

        Dim TempPoint As Point
        Dim MarkCenterFrist As Point
        Dim MarkCenterSecond As Point
        TempPoint.X = 0
        TempPoint.Y = 0

        ' 이미지 그리기~
        AddImage(New Bitmap(strName), TempPoint, Color.Transparent, New Size(0, 0))

        Dim dCenterPosX As Double = 0
        Dim dCenterPosY As Double = 0


        MIL.MmodRestore(m_MarkData.strAlignMarkImageMMF_FileName, pMilInterface.MilSystem, MIL.M_DEFAULT, pMilInterface.MilRecipeContext(m_iLine, m_iPanel, m_iMark, m_iIndex))

        MIL.MmodInquire(pMilInterface.MilRecipeContext(m_iLine, m_iPanel, m_iMark, m_iIndex), MIL.M_DEFAULT, MIL.M_REFERENCE_X, dCenterPosX)
        MIL.MmodInquire(pMilInterface.MilRecipeContext(m_iLine, m_iPanel, m_iMark, m_iIndex), MIL.M_DEFAULT, MIL.M_REFERENCE_Y, dCenterPosY)

        ' 마크 설정 사이즈
        Dim nMarkPlcSizeX As Double = 0
        Dim nMarkPlcSizeY As Double = 0

        MIL.MmodInquire(pMilInterface.MilRecipeContext(m_iLine, m_iPanel, m_iMark, m_iIndex), MIL.M_DEFAULT, MIL.M_ALLOC_SIZE_X, nMarkPlcSizeX)
        MIL.MmodInquire(pMilInterface.MilRecipeContext(m_iLine, m_iPanel, m_iMark, m_iIndex), MIL.M_DEFAULT, MIL.M_ALLOC_SIZE_Y, nMarkPlcSizeY)

        ' UI상 마크 View 사이즈
        Dim nUIMarkPlcSizeX As Double = picModel.Width
        Dim nUIMarkPlcSizeY As Double = picModel.Height

        dCenterPosX = dCenterPosX * (nUIMarkPlcSizeX / nMarkPlcSizeX)
        dCenterPosY = dCenterPosY * (nUIMarkPlcSizeY / nMarkPlcSizeY)

        MarkCenterFrist.X = dCenterPosX - 20
        MarkCenterFrist.Y = dCenterPosY

        MarkCenterSecond.X = dCenterPosX + 20
        MarkCenterSecond.Y = dCenterPosY

        AddLine2(Color.Blue, MarkCenterFrist, MarkCenterSecond) ' 가로 

        MarkCenterFrist.X = dCenterPosX
        MarkCenterFrist.Y = dCenterPosY - 20

        MarkCenterSecond.X = dCenterPosX
        MarkCenterSecond.Y = dCenterPosY + 20

        AddLine2(Color.Blue, MarkCenterFrist, MarkCenterSecond) ' 세로




        ' 비트맵 삽입
        picModel.Image = bMap
        picModel.Update()
#End If
    End Sub

    Private Sub AddLine(ByVal color As Color, ByVal First As PointF, ByVal Second As PointF)

        'Dim BluePen As New Pen(Color.Blue, 2.0F)
        Dim BluePen As New Pen(color, 2.0F)
        'First = New Point(First.X, First.Y)
        'Second = New Point(Second.X, Second.Y)
        grpTools.DrawLine(BluePen, First, Second)

        'New연산자 해제
        BluePen.Dispose()
        BluePen = Nothing

    End Sub

    Private Sub AddLine2(ByVal color As Color, ByVal First As PointF, ByVal Second As PointF)

        Dim BluePen As New Pen(color, 1.0F)
        grpTools.DrawLine(BluePen, First, Second)

        'New연산자 해제
        BluePen.Dispose()
        BluePen = Nothing

    End Sub



    Public Sub New(ByVal nLine As Integer, ByVal nPanel As Integer)

        InitializeComponent()

        '라인, 판넬, 마크, 갯수 정의를 여기서 내려줘야 하네.
        m_iLine = nLine
        m_iPanel = nPanel

    End Sub

    Private Sub ctrlAlignMarkSetting_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        SetDisplayWnd(m_iMark, picModel)

        InitImage()

        UpdateData(False)

    End Sub


    'Private Sub UpdateData(ByVal bUpdate As Boolean)
    Public Sub UpdateData(ByVal bUpdate As Boolean)
        On Error GoTo SysErr

        modRecipe.LoadRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe)

        If bUpdate Then

        Else
            m_MarkData = pRcpMark_Data(m_iLine, m_iPanel, m_iMark, m_iIndex)

            lblStartX.Text = m_MarkData.nAlignMark_SearchOffsetX
            lblStartY.Text = m_MarkData.nAlignMark_SearchOffsetY
            numSizeX.Text = m_MarkData.nAlignMark_SearchSizeX
            numSizeY.Text = m_MarkData.nAlignMark_SearchSizeY
            lblModel_OffsetX.Text = m_MarkData.nAlignMark_ModelOffsetX
            lblModel_OffsetY.Text = m_MarkData.nAlignMark_ModelOffsetY
            numModelSizeX.Text = m_MarkData.nAlignMark_ModelSizeX
            numModelSizeY.Text = m_MarkData.nAlignMark_ModelSizeY
            numAcceptM.Value = m_MarkData.nAlignMark_Acceptance
            numCertM.Value = m_MarkData.nAlignMark_Certainty
            chkMarkUse.Checked = m_MarkData.bMark
            numCnt.Value = m_MarkData.nSubMark

            Dim nCam As Integer
            Select Case m_iLine

                Case 0
                    If m_iPanel = 0 Or m_iPanel = 2 Then
                        nCam = 0
                    Else
                        nCam = 1
                    End If

                Case 1
                    If m_iPanel = 0 Or m_iPanel = 2 Then
                        nCam = 2
                    Else
                        nCam = 3
                    End If

            End Select

#If SIMUL <> 1 Then


#End If
            DrawFenceSPT(m_MarkData.strAlignMarkImageBMP_FileName)
            lblREFX.Text = m_nRefX
            lblREFY.Text = m_nRefY

        End If

        Exit Sub
SysErr:
        Dim strEr As String = Err.Description
    End Sub



    Private Sub btnToM_Click(sender As System.Object, e As System.EventArgs) Handles btnToM.Click
        On Error GoTo SysErr

        'MoveToAlignMarkPos()

        Exit Sub
SysErr:
        modPub.ErrorLog(Err.Description & " - frmRecipe -- btnToM1_A1M1_List1_Click")

    End Sub



    Private Sub MoveToAlignMarkPos()
        On Error GoTo SysErr
        Dim tmpMovePosX As Double = pLDLT.PLC_Infomation.dCurPosX(m_iLine)
        Dim tmpMovePosY As Double = pLDLT.PLC_Infomation.dCurPosY(m_iLine)


        If m_iLine = LINE.A Then
            tmpMovePosX = (pMF_Result(m_iLine, m_iPanel, m_iMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, m_iPanel) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)) - pMF_Result(m_iLine, m_iPanel, m_iMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, m_iPanel) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)))
            tmpMovePosY = (pMF_Result(m_iLine, m_iPanel, m_iMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, m_iPanel) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)) + pMF_Result(m_iLine, m_iPanel, m_iMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, m_iPanel) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)))
            tmpMovePosX = pLDLT.PLC_Infomation.dCurPosX(m_iLine) - tmpMovePosX
            tmpMovePosY = pLDLT.PLC_Infomation.dCurPosY(m_iLine) + tmpMovePosY
        ElseIf m_iLine = LINE.B Then
            tmpMovePosX = (pMF_Result(m_iLine, m_iPanel, m_iMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, m_iPanel) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)) - pMF_Result(m_iLine, m_iPanel, m_iMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, m_iPanel) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)))
            tmpMovePosY = (pMF_Result(m_iLine, m_iPanel, m_iMark).PositionDiffX * pCurSystemParam.dVisionScaleX(m_iLine, m_iPanel) * Math.Sin(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)) + pMF_Result(m_iLine, m_iPanel, m_iMark).positionDiffY * pCurSystemParam.dVisionScaleY(m_iLine, m_iPanel) * Math.Cos(pCurSystemParam.dVisionTheta(m_iLine, m_iPanel)))
            tmpMovePosX = pLDLT.PLC_Infomation.dCurPosX(m_iLine) - tmpMovePosX
            tmpMovePosY = pLDLT.PLC_Infomation.dCurPosY(m_iLine) - tmpMovePosY
        End If

        pLDLT.MoveStage(m_iLine, Axis.x, tmpMovePosX)
        pLDLT.MoveStage(m_iLine, Axis.y, tmpMovePosY)

        Exit Sub
SysErr:
    End Sub

    Private Sub ModelApply()

        Dim strFilePath As String = ""
        Dim strReturn As String = ""
        Dim strPathDel As String = ""
        Dim strLine(1) As String
        strLine(0) = "A"
        strLine(1) = "B"
        Dim nCam As Integer = 0

        Select Case m_iLine
            Case 0
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 0
                Else
                    nCam = 1
                End If
            Case 1
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 2
                Else
                    nCam = 3
                End If
        End Select

        strFilePath = modPub.GetFileFolder(pCurSystemParam.strLastModelFilePath, 0)

        strFilePath = strFilePath & "\Align Data"

        If System.IO.Directory.Exists(strFilePath) = False Then
            System.IO.Directory.CreateDirectory(strFilePath)
        End If

        strPathDel = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".MMF"
        System.IO.File.Delete(strPathDel)

#If SIMUL <> 1 Then
        If bsetModel = True Then
            ' Save Model
            m_MarkData.strAlignMarkImageBMP_FileName = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".bmp"
            pMilProcessor.SaveImage(pMilInterface.dispImageChild(nCam), MIL.M_BMP, 1, m_MarkData.strAlignMarkImageBMP_FileName)

            m_MarkData.strAlignMarkImageMMF_FileName = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".mmf"
            FileCopy("C:\Vision Temp\MaskTemp.mmf", m_MarkData.strAlignMarkImageMMF_FileName)

            DrawFenceSPT(m_MarkData.strAlignMarkImageBMP_FileName)
            pCurMark_Data = m_MarkData

        ElseIf bsetModel = False Then

            m_MarkData.strAlignMarkImageMMF_FileName = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".mmf"
            FileCopy("C:\Vision Temp\MaskTemp.mmf", m_MarkData.strAlignMarkImageMMF_FileName)

            DrawFenceSPT(m_MarkData.strAlignMarkImageBMP_FileName)
            pCurMark_Data = m_MarkData

        End If

#End If

        '밑에꺼 우선 막자.
        '        Dim strFilePath As String = ""
        '        Dim strReturn As String = ""

        '        strFilePath = modPub.GetFileFolder(pCurSystemParam.strLastModelFilePath, 0)

        '        strFilePath = strFilePath & "\Align Data"

        '        If System.IO.Directory.Exists(strFilePath) = False Then
        '            System.IO.Directory.CreateDirectory(strFilePath)
        '        End If

        '        ' Save Model
        '        Dim rect As Rectangle
        '        rect.X = m_MarkData.nAlignMark_ModelOffsetX
        '        rect.Y = m_MarkData.nAlignMark_ModelOffsetY
        '        rect.Width = m_MarkData.nAlignMark_ModelSizeX
        '        rect.Height = m_MarkData.nAlignMark_ModelSizeY

        '        Dim nCam As Integer
        '        Select Case m_iLine
        '            Case 0
        '                If m_iPanel = 0 Or m_iPanel = 2 Then
        '                    nCam = 0
        '                Else
        '                    nCam = 1
        '                End If
        '            Case 1
        '                If m_iPanel = 0 Or m_iPanel = 2 Then
        '                    nCam = 2
        '                Else
        '                    nCam = 3
        '                End If
        '        End Select

        '        Dim strPathDel As String = ""
        '        Dim strLine(1) As String
        '        'Dim strPathDel As String = ""
        '        strLine(0) = "A"
        '        strLine(1) = "B"

        '        strPathDel = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".MMF"
        '        System.IO.File.Delete(strPathDel)

        '#If SIMUL <> 1 Then
        '        pMilProcessor.GetROIImage(pMilInterface.dispImage(nCam), pMilInterface.dispImageChild(nCam), rect)

        '        If pMilInterface.MilSearchContext(nCam) <> MIL.M_NULL Then
        '            MIL.MmodFree(pMilInterface.MilSearchContext(nCam))
        '            pMilInterface.MilSearchContext(nCam) = MIL.M_NULL
        '        End If

        '        MIL.MmodAlloc(pMilInterface.MilSystem, MIL.M_GEOMETRIC, MIL.M_DEFAULT, pMilInterface.MilSearchContext(nCam))

        '        ' Define the models.
        '        For i = 0 To NUMBER_OF_MODELS - 1
        '            MIL.MmodDefine(pMilInterface.MilSearchContext(nCam), MIL.M_IMAGE, pMilInterface.dispImageChild(nCam), MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT, MIL.M_DEFAULT)
        '        Next i

        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_NUMBER, 1)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_CONTEXT, MIL.M_SPEED, SINGLE_MODEL_SEARCH_SPEED)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_CONTEXT, MIL.M_SMOOTHNESS, 100) '75
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_ACCEPTANCE, m_MarkData.nAlignMark_Acceptance)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_CERTAINTY, m_MarkData.nAlignMark_Certainty)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_ACCEPTANCE_TARGET, 60)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_CERTAINTY_TARGET, 90)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_ACCURACY, MIL.M_DEFAULT)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_DETAIL_LEVEL, MIL.M_DEFAULT)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_SCALE_MIN_FACTOR, MIL.M_DEFAULT)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_SCALE_MAX_FACTOR, MIL.M_DEFAULT)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_TIMEOUT, MIL.M_DEFAULT)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_REFERENCE_X, m_nRefX)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_REFERENCE_Y, m_nRefY)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_SEARCH_ANGLE_RANGE, MIL.M_DISABLE)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_SEARCH_SCALE_RANGE, MIL.M_DISABLE)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT, MIL.M_POLARITY, MIL.M_SAME)
        '        MIL.MmodControl(pMilInterface.MilSearchContext(nCam), MIL.M_CONTEXT, MIL.M_SEARCH_ANGLE_RANGE, MIL.M_DISABLE)
        '        'MIL.MmodDraw(MIL.M_DEFAULT, pMilInterface.MilSearchContext(nCam), pMilInterface.MilOverlayImage(nCam), MIL.M_DRAW_EDGES, MIL.M_DEFAULT, MIL.M_DEFAULT)

        '        ' Save Model
        '        m_MarkData.strAlignMarkImageBMP_FileName = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".bmp"
        '        pMilProcessor.SaveImage(pMilInterface.dispImageChild(nCam), MIL.M_BMP, 1, m_MarkData.strAlignMarkImageBMP_FileName)

        '        m_MarkData.strAlignMarkImageMMF_FileName = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".MMF"
        '        MIL.MmodSave(m_MarkData.strAlignMarkImageMMF_FileName, pMilInterface.MilSearchContext(nCam), MIL.M_DEFAULT)

        '        DrawFenceSPT(m_MarkData.strAlignMarkImageBMP_FileName)
        '        pCurMark_Data = m_MarkData

        '#End If
    End Sub


    Private Sub btnSetRoi_Click(sender As System.Object, e As System.EventArgs) Handles btnSetRoi.Click

        modPub.SystemLog("ctrlAlignMarkSetting -- btnSetROI Click")

        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(0)
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(0)

        'Dim rcRoi As Rectangle
        Dim nRecX As Integer = 0
        Dim nRecY As Integer = 0
        Dim nRecWidth As Integer = 0
        Dim nRecHeight As Integer = 0

        lblStartX.Text = lblTLX.Text
        lblStartY.Text = lblTLY.Text
        numSizeX.Value = Math.Abs(CInt(lblRBX.Text) - CInt(lblTLX.Text))
        numSizeY.Value = Math.Abs(CInt(lblRBY.Text) - CInt(lblTLY.Text))

        nRecX = CInt(lblStartX.Text)
        nRecY = CInt(lblStartY.Text)
        nRecWidth = numSizeX.Value
        nRecHeight = numSizeY.Value

        m_MarkData.nAlignMark_SearchOffsetX = nRecX
        m_MarkData.nAlignMark_SearchOffsetY = nRecY
        m_MarkData.nAlignMark_SearchSizeX = nRecWidth
        m_MarkData.nAlignMark_SearchSizeY = nRecHeight


        For iLine As Integer = LINE.A To LINE.B
            For iPanel As Integer = Panel.p1 To Panel.p4
                For iMark As Integer = AlignMarkNumber.Mark1 To AlignMarkNumber.Mark2
                    For iSubMark As Integer = 0 To 1
                        pRcpMark_Data(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchOffsetX = pRcpMark_Data_Tmp(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchOffsetX ' = pRcpMark_Data_Tmp(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchOffsetX = pRcpMark_Data(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchOffsetX
                        pRcpMark_Data(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchOffsetY = pRcpMark_Data_Tmp(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchOffsetY
                        pRcpMark_Data(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchSizeX = pRcpMark_Data_Tmp(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchSizeX
                        pRcpMark_Data(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchSizeY = pRcpMark_Data_Tmp(iLine, iPanel, iMark, iSubMark).nAlignMark_SearchSizeY

                    Next
                Next
            Next
        Next

        modRecipe.SaveModelInfo(pCurSystemParam.strLastModelFilePath)
        bsaveRoi = True
        MarkStack()

    End Sub


    Private Sub btnModelApply_Click(sender As System.Object, e As System.EventArgs) Handles btnModelApply.Click

        modPub.SystemLog("ctrlAlignMarkSetting -- btnModelApply Click")

        Try

            Dim nRet As Integer = -1
            nRet = MsgBox("신규 모델을 등록 하시겠습니까?", MsgBoxStyle.YesNo, "신규 등록")

            If nRet = 7 Then
                Return
            End If

            m_MarkData.nAlignMark_SearchOffsetX = CInt(lblStartX.Text)
            m_MarkData.nAlignMark_SearchOffsetY = CInt(lblStartY.Text)
            m_MarkData.nAlignMark_SearchSizeX = numSizeX.Value
            m_MarkData.nAlignMark_SearchSizeY = numSizeY.Value

            m_MarkData.nAlignMark_ModelOffsetX = CInt(lblModel_OffsetX.Text)
            m_MarkData.nAlignMark_ModelOffsetY = CInt(lblModel_OffsetY.Text)
            m_MarkData.nAlignMark_ModelSizeX = numModelSizeX.Value
            m_MarkData.nAlignMark_ModelSizeY = numModelSizeY.Value

            m_MarkData.nAlignMark_Acceptance = numAcceptM.Value
            m_MarkData.nAlignMark_Certainty = numCertM.Value

            '이거는 모델 등록인데.. 확인 후 진행하자.
            ModelApply()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        bmakeApply = True
        MarkStack()
    End Sub

     Private Sub btnModelCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnModelCheck.Click
        'findmodel
        Dim bFindResult As Boolean

        Dim nRec As Rectangle

        nRec.X = m_MarkData.nAlignMark_SearchOffsetX
        nRec.Y = m_MarkData.nAlignMark_SearchOffsetY
        nRec.Width = m_MarkData.nAlignMark_SearchSizeX
        nRec.Height = m_MarkData.nAlignMark_SearchSizeY

        Dim nCam As Integer
        Select Case m_iLine

            Case 0
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 0
                    frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawROIRect(nRec.X, nRec.Y, nRec.Width, nRec.Height)
                Else
                    nCam = 1
                    frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawROIRect(nRec.X, nRec.Y, nRec.Width, nRec.Height)
                End If

            Case 1
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 2
                    frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawROIRect(nRec.X, nRec.Y, nRec.Width, nRec.Height)
                Else
                    nCam = 3
                    frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawROIRect(nRec.X, nRec.Y, nRec.Width, nRec.Height)
                End If

        End Select

        'Change MMF
#If SIMUL <> 1 Then
        'pMilInterface.LoadAlignModelTemplate(nCam, pRcpMark_Data(m_iLine, m_iPanel, m_iMark, m_iIndex).strAlignMarkImageMMF_FileName)
        pMilInterface.LoadAlignModelTemplate_Total(m_iLine, m_iPanel, m_iMark, m_iIndex, pRcpMark_Data(m_iLine, m_iPanel, m_iMark, m_iIndex).strAlignMarkImageMMF_FileName)

        If MIL.M_NULL <> pMilInterface.MilModResult(nCam) Then
            MIL.MmodFree(pMilInterface.MilModResult(nCam))
            pMilInterface.MilModResult(nCam) = MIL.M_NULL
        End If

        MIL.MmodAllocResult(pMilInterface.MilSystem, Matrox.MatroxImagingLibrary.MIL.M_DEFAULT, pMilInterface.MilModResult(nCam))
        bFindResult = modVision.FindModel(nCam, pMF_Result(m_iLine, m_iPanel, m_iMark), 99, m_iLine, m_iPanel, m_iMark)
#End If

        If bFindResult = True Then

            lblOK.Text = "OK"
            lblOK.ForeColor = Color.Lime
            lblScore.Text = Math.Round(CDbl(pMF_Result(m_iLine, m_iPanel, m_iMark).Score), 2)
            lblPosX.Text = Math.Round(CDbl(pMF_Result(m_iLine, m_iPanel, m_iMark).PositionDiffX), 3)
            lblPosY.Text = Math.Round(CDbl(pMF_Result(m_iLine, m_iPanel, m_iMark).positionDiffY), 3)

        Else

            lblOK.Text = "NG"
            lblOK.ForeColor = Color.Crimson
            lblScore.Text = "--"
            lblPosX.Text = "--"
            lblPosY.Text = "--"
        End If
    End Sub

    Dim m_strImagePath As String = ""

    Private Sub btnModelSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModelSetting.Click

        modPub.SystemLog("ctrlAlignMarkSetting -- btnMarkSet Click")

        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(0)
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(0)

        lblModel_OffsetX.Text = lblTLX.Text
        lblModel_OffsetY.Text = lblTLY.Text
        numModelSizeX.Value = Math.Abs(CInt(lblRBX.Text) - CInt(lblTLX.Text))
        numModelSizeY.Value = Math.Abs(CInt(lblRBY.Text) - CInt(lblTLY.Text))

        'Dim rcRoi As Rectangle
        Dim nRecX As Integer = 0
        Dim nRecY As Integer = 0
        Dim nRecWidth As Integer = 0
        Dim nRecHeight As Integer = 0

        nRecX = CInt(lblTLX.Text)
        nRecY = CInt(lblTLY.Text)
        nRecWidth = Math.Abs(CInt(lblRBX.Text) - CInt(lblTLX.Text))
        nRecHeight = Math.Abs(CInt(lblRBY.Text) - CInt(lblTLY.Text))

        m_MarkData.nAlignMark_ModelOffsetX = CInt(lblModel_OffsetX.Text)
        m_MarkData.nAlignMark_ModelOffsetY = CInt(lblModel_OffsetY.Text)
        m_MarkData.nAlignMark_ModelSizeX = numModelSizeX.Value
        m_MarkData.nAlignMark_ModelSizeY = numModelSizeY.Value

        m_MarkData.nAlignMark_Acceptance = numAcceptM.Value
        m_MarkData.nAlignMark_Certainty = numCertM.Value
        '이거는 모델 등록인데.. 확인 후 진행하자.
        'ModelApply()

        Dim strFilePath As String = ""
        Dim strReturn As String = ""

        strFilePath = modPub.GetFileFolder(pCurSystemParam.strLastModelFilePath, 0)

        strFilePath = strFilePath & "\Align Data"

        If System.IO.Directory.Exists(strFilePath) = False Then
            System.IO.Directory.CreateDirectory(strFilePath)
        End If

        ' Save Model
        Dim rect As Rectangle
        rect.X = m_MarkData.nAlignMark_ModelOffsetX
        rect.Y = m_MarkData.nAlignMark_ModelOffsetY
        rect.Width = m_MarkData.nAlignMark_ModelSizeX
        rect.Height = m_MarkData.nAlignMark_ModelSizeY

        Dim nCam As Integer
        Select Case m_iLine
            Case 0
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 0
                Else
                    nCam = 1
                End If
            Case 1
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 2
                Else
                    nCam = 3
                End If
        End Select


#If SIMUL <> 1 Then
        pMilProcessor.GetROIImage(pMilInterface.dispImage(nCam), pMilInterface.dispImageChild(nCam), rect)

        ' Save Model
        m_strImagePath = "C:\Vision Temp\MarkTemp.Bmp"
        pMilProcessor.SaveImage(pMilInterface.dispImageChild(nCam), MIL.M_BMP, 1, m_strImagePath)
#End If
        'fs = New System.IO.FileStream(strPath, IO.FileMode.Open, IO.FileAccess.Read)
        'picModel.Image = System.Drawing.Image.FromStream(fs)
        'fs.Close()

        'DrawFenceSPT(m_MarkData.strAlignMarkImageBMP_FileName)
        DrawFenceSPT(m_strImagePath)

        bsetModel = True
        MarkStack()
    End Sub


    Private Sub chkMarkUse_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMarkUse.CheckedChanged
        modPub.SystemLog("frmRecipe -- btnAccCerSet_B2M1L3_Click")
        If chkMarkUse.Checked = True Then
            chkMarkUse.Text = "Use"
        Else
            chkMarkUse.Text = "Not Use"
        End If
        m_MarkData.bMark = chkMarkUse.Checked
        pRcpMark_Data(m_iLine, m_iPanel, m_iMark, m_iIndex).bMark = m_MarkData.bMark
        Exit Sub

    End Sub

   

    Private Sub ctrlAlignMarkSetting_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        'If Visible = True Then
        Dim nLine As Integer = m_iLine
        Dim nPanel As Integer = m_iPanel
        'End If
        lblOK.Text = nLine.ToString & "-" & nPanel.ToString

    End Sub

    Public Sub UpdateRectInfo(ByVal ptStart As Point, ByVal ptEnd As Point)

        lblTLX.Text = ptStart.X.ToString
        lblTLY.Text = ptStart.Y.ToString
        lblRBX.Text = ptEnd.X.ToString
        lblRBY.Text = ptEnd.Y.ToString

        'lblTLX.Refresh()
        'lblTLY.Refresh()
        'lblRBX.Refresh()
        'lblRBY.Refresh()

        'lblTLX.Update()
        'lblTLY.Update()
        'lblRBX.Update()
        'lblRBY.Update()

        'Me.Refresh()



    End Sub

    Dim m_nRefX As Integer
    Dim m_nRefY As Integer

    Public Sub UpdateClossInfo(ByVal nX As Integer, ByVal nY As Integer)

        m_nRefX = nX
        m_nRefY = nY

        lblREFX.Text = nX.ToString
        lblREFY.Text = nY.ToString

    End Sub

    Private Sub Save_Click(sender As System.Object, e As System.EventArgs) Handles Save.Click

        modPub.SystemLog("ctrlAlignMarkSetting -- btnModelSave Click")

        m_MarkData.nAlignMark_SearchOffsetX = CInt(lblStartX.Text)
        m_MarkData.nAlignMark_SearchOffsetY = CInt(lblStartY.Text)
        m_MarkData.nAlignMark_SearchSizeX = numSizeX.Value
        m_MarkData.nAlignMark_SearchSizeY = numSizeY.Value

        m_MarkData.nAlignMark_ModelOffsetX = CInt(lblModel_OffsetX.Text)
        m_MarkData.nAlignMark_ModelOffsetY = CInt(lblModel_OffsetY.Text)
        m_MarkData.nAlignMark_ModelSizeX = numModelSizeX.Value
        m_MarkData.nAlignMark_ModelSizeY = numModelSizeY.Value

        m_MarkData.nAlignMark_Acceptance = numAcceptM.Value
        m_MarkData.nAlignMark_Certainty = numCertM.Value

        pCurMark_Data = m_MarkData

        pRcpMark_Data(m_iLine, m_iPanel, m_iMark, m_iIndex) = pCurMark_Data

        modRecipe.SaveModelInfo(pCurSystemParam.strLastModelFilePath)

        'bmakeRoi = False
        'bsaveRoi = False
        'bmakeModel = False
        bsetModel = False
        brefpPoint = False
        bmakeApply = False

        'Save 누르고 왜 전부 disable 시키는거야?
        'btnSetRoi.Enabled = True
        'BtnDrowMODEL.Enabled = True
        'btnModelSetting.Enabled = False
        'ChkRefPoint.Enabled = False
        btnModelSetting.Enabled = False
        btnModelApply.Enabled = False
        'Save.Enabled = False

        SystemLog("Mark save Complete")

    End Sub


    Private Sub BtnDrowROI_Click(sender As System.Object, e As System.EventArgs) Handles BtnDrowROI.Click

        modPub.SystemLog("ctrlAlignMarkSetting -- btnDrowROI Click")

        'Dim rcRoi As Rectangle
        Dim nRecX As Integer = 0
        Dim nRecY As Integer = 0
        Dim nRecWidth As Integer = 0
        Dim nRecHeight As Integer = 0

        nRecX = m_MarkData.nAlignMark_SearchOffsetX
        nRecY = m_MarkData.nAlignMark_SearchOffsetY
        nRecWidth = m_MarkData.nAlignMark_SearchSizeX
        nRecHeight = m_MarkData.nAlignMark_SearchSizeY

        Select Case m_iPanel    '1,2,3,4척 구분.

            Case 0  'Panel1

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel1_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel1_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

            Case 1  'Panel2

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel2_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel2_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

            Case 2  'Panel3

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel3_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel3_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

            Case 3  'Panel4

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel4_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(2)
                        pnVisionSetArea = AlignMark.Panel4_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawROIRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

        End Select

        lblTLX.Text = nRecX
        lblTLY.Text = nRecY
        lblRBX.Text = nRecWidth + nRecX
        lblRBY.Text = nRecHeight + nRecY

        MarkStack()

        modVision.SetVisionInfomation(m_iLine, m_iPanel, m_iMark, m_iIndex)

    End Sub

    Private Sub BtnDrowMODEL_Click(sender As System.Object, e As System.EventArgs) Handles BtnDrowMODEL.Click

        modPub.SystemLog("ctrlAlignMarkSetting -- btnMarkArea Click")

        'Dim rcRoi As Rectangle
        Dim nRecX As Integer = 0
        Dim nRecY As Integer = 0
        Dim nRecWidth As Integer = 0
        Dim nRecHeight As Integer = 0

        nRecX = m_MarkData.nAlignMark_ModelOffsetX
        nRecY = m_MarkData.nAlignMark_ModelOffsetY
        nRecWidth = m_MarkData.nAlignMark_ModelSizeX
        nRecHeight = m_MarkData.nAlignMark_ModelSizeY

        Select Case m_iPanel    '1,2,3,4척 구분.

            Case 0  'Panel1

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel1_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel1_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

            Case 1  'Panel2

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel2_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel2_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

            Case 2  'Panel3

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel3_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam1)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel3_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

            Case 3  'Panel4

                Select Case m_iMark
                    Case 0  'Mark 1
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel4_Mark1 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                    Case 1  'Mark 2
                        frmVision.SelectVision(m_iLine, CAM.Cam2)   'A라인 1번카메라  'A척 1번마크
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(3)
                        pnVisionSetArea = AlignMark.Panel4_Mark2 + (m_iLine * 10)
                        'Mark Num가 Camera Num가 됨.
                        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).DrawMarkRect(nRecX, nRecY, nRecWidth, nRecHeight)
                End Select

        End Select

        lblTLX.Text = nRecX
        lblTLY.Text = nRecY
        lblRBX.Text = nRecWidth + nRecX
        lblRBY.Text = nRecHeight + nRecY

        bmakeModel = True
        MarkStack()

        modVision.SetVisionInfomation(m_iLine, m_iPanel, m_iMark, m_iIndex)
     
    End Sub

    Dim m_RectSizeWnd As New Rectangle()

    Sub SetDisplayWnd(ByVal nMark As Integer, ByVal Display As System.Windows.Forms.PictureBox)

        Dim RectSizeWnd As New Rectangle()

        RectSizeWnd.X = 0
        RectSizeWnd.Y = 0

        RectSizeWnd.Width = Display.Width
        RectSizeWnd.Height = Display.Height

        m_RectSizeWnd = RectSizeWnd

        '        If mCamLiveWnd IsNot Nothing Then
        '            mCamLiveWnd.Close()
        '            mCamLiveWnd.Dispose()
        '            mCamLiveWnd = Nothing
        '        End If
        '        If mCamLiveWnd IsNot Nothing Then
        '            mCamLiveWnd.Close()
        '        End If

        '#If SIMUL <> 1 Then
        '        mCamLiveWnd = New LiveImageWnd(RectSizeWnd, Me.Handle, pMilInterface.MilSystem, pMilInterface.MarkImage(nMark), pMilInterface.MilModResult(nMark))
        '        mCamLiveWnd.SetCameraNo(nMark)  'Mark Number로 대체.

        '        Display.Controls.Clear()
        '        Display.Controls.Add(mCamLiveWnd)

        '        'Mark Size를 가져와서 뿌려줘야함..
        '        Dim zoomX As Double = CDbl(RectSizeWnd.Width) / CDbl(m_MarkData.nAlignMark_ModelSizeX)
        '        Dim zoomY As Double = CDbl(RectSizeWnd.Height) / CDbl(m_MarkData.nAlignMark_ModelSizeY)
        '        mCamLiveWnd.SetZoomFactor(zoomX, zoomY)

        '        mCamLiveWnd.Show()
        '#End If

    End Sub

    Dim nRefX As Integer
    Dim nRefY As Integer
    Dim bRefPoint As Boolean

    Private Sub ChkRefPoint_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkRefPoint.CheckedChanged

        'VisionMode.Set_Mark_Ref_Point

        If ChkRefPoint.CheckState = CheckState.Checked Then

            bRefPoint = True

        Else

            bRefPoint = False

        End If
        brefpPoint = True
        MarkStack()
      

    End Sub


    Private Sub DrawCross(ByVal ipPosX As Integer, ByVal ipPosY As Integer, ByVal ipSize As Integer)
        
        'Dim graphics__1 As Graphics = Graphics.FromImage(picModel.Image) 'FromHdc(hdc:=picModel)    ', M_WINDOW_DC, NULL)
        'graphics__1.SmoothingMode = SmoothingMode.HighQuality

        Dim BluePen As New Pen(Color.Blue, 2.0F)

        Dim pHStartPt As New PointF(ipPosX - ipSize / 2, ipPosY)
        Dim pHEndPt As New PointF(ipPosX + ipSize / 2, ipPosY)
        Dim pVStartPt As New PointF(ipPosX, ipPosY - ipSize / 2)
        Dim pVEndPt As New PointF(ipPosX, ipPosY + ipSize / 2)

        'graphics__1.DrawLine(BluePen, pHStartPt, pHEndPt)
        'graphics__1.DrawLine(BluePen, pVStartPt, pVEndPt)

    End Sub


    Private Sub BtnCopy_Click(sender As System.Object, e As System.EventArgs) Handles BtnCopy.Click

        pCurMark_Data = pRcpMark_Data(m_iLine, m_iPanel, m_iMark, 0)

    End Sub

    Private Sub BtnAcceptSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcceptSave.Click

        Dim strFilePath As String = ""
        Dim strFilePath_Mark As String = ""
        Dim strLine(1) As String
        strLine(0) = "A"
        strLine(1) = "B"

        modRecipe.LoadRecipe(pCurSystemParam.strLastModelFilePath, pSetRecipe)

        strFilePath = modPub.GetFileFolder(pCurSystemParam.strLastModelFilePath, 0)
        strFilePath = strFilePath & "\Align Data"
        strFilePath_Mark = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (m_iMark + 1).ToString & "_" & (m_iIndex + 1).ToString & ".MMF"

        Dim nCam As Integer
        Select Case m_iLine
            Case 0
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 0
                Else
                    nCam = 1
                End If
            Case 1
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 2
                Else
                    nCam = 3
                End If
        End Select

#If SIMUL <> 1 Then
        'pMilInterface.LoadAlignModelTemplate(m_iPanel, strFilePath_Mark)m_iLine, m_iPanel, m_iMark, m_iIndex
        'pMilInterface.LoadAlignModelTemplate(nCam, strFilePath_Mark)
        pMilInterface.LoadAlignModelTemplate_Total(m_iLine, m_iPanel, m_iMark, m_iIndex, strFilePath_Mark)
#End If

        m_MarkData.nAlignMark_Acceptance = numAcceptM.Value
        m_MarkData.nAlignMark_Certainty = numCertM.Value
        pRcpMark_Data(m_iLine, m_iPanel, m_iMark, m_iIndex).nAlignMark_Acceptance = numAcceptM.Value
        pRcpMark_Data(m_iLine, m_iPanel, m_iMark, m_iIndex).nAlignMark_Certainty = numCertM.Value
        modRecipe.SaveModelInfo(pCurSystemParam.strLastModelFilePath)

#If SIMUL <> 1 Then
        MIL.MmodControl(pMilInterface.MilSearchContext(m_iLine, m_iPanel, m_iMark, m_iIndex), MIL.M_DEFAULT, MIL.M_ACCEPTANCE, m_MarkData.nAlignMark_Acceptance)
        MIL.MmodControl(pMilInterface.MilSearchContext(m_iLine, m_iPanel, m_iMark, m_iIndex), MIL.M_DEFAULT, MIL.M_CERTAINTY, m_MarkData.nAlignMark_Certainty)
        MIL.MmodSave(m_MarkData.strAlignMarkImageMMF_FileName, pMilInterface.MilSearchContext(m_iLine, m_iPanel, m_iMark, m_iIndex), MIL.M_DEFAULT)
#End If

    End Sub
    Private Function MarkStack() As Boolean
        On Error GoTo SysErr

        'If bsaveRoi = True Then
        '    BtnDrowMODEL.Enabled = True
        'End If

        If bmakeModel = True Then
            btnModelSetting.Enabled = True
        End If

        If bsetModel = True Then
            'btnModelApply.Enabled = True
        End If

        If brefpPoint = True Then
            btnModelApply.Enabled = True
        End If

        If bmakeApply = True Then
            Save.Enabled = True
        End If

SysErr:
    End Function

    Private m_bMouseDown As Boolean
    Private m_ptStart As Point
    Private m_ptEnd As Point

    Private ipPosX As Integer
    Private ipPosY As Integer
    Private ipSize As Integer

    'Public dOffsetX As Double
    'Public dOffsetY As Double

    Private Sub picModel_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles picModel.MouseDown

        If bRefPoint = True Then

            Dim dOffsetX As Double
            Dim dOffsetY As Double

            dOffsetX = m_RectSizeWnd.Width / m_MarkData.nAlignMark_ModelSizeX
            dOffsetY = m_RectSizeWnd.Height / m_MarkData.nAlignMark_ModelSizeY

            m_ptStart.X = e.X * CSng(dOffsetX)
            m_ptStart.Y = e.Y * CSng(dOffsetY)

            m_bMouseDown = True

        End If


    End Sub

    Private Sub picModel_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles picModel.MouseMove

        If m_bMouseDown = True Then


            Dim dOffsetX As Double
            Dim dOffsetY As Double

            dOffsetX = m_RectSizeWnd.Width / m_MarkData.nAlignMark_ModelSizeX
            dOffsetY = m_RectSizeWnd.Height / m_MarkData.nAlignMark_ModelSizeY

            m_ptEnd.X = e.X * CSng(dOffsetX)
            m_ptEnd.Y = e.Y * CSng(dOffsetY)

            ipPosX = m_ptEnd.X
            ipPosY = m_ptEnd.Y
            ipSize = 20

        End If

    End Sub

    Private Sub picModel_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles picModel.MouseUp

        Dim nGlass As Integer = 0
        Dim dTmpPosX As Double = 0
        Dim dTmpPosY As Double = 0

        Dim dOffsetX As Double
        Dim dOffsetY As Double

        Dim BluePen As New Pen(Color.Blue, 2.0F)

        Dim pHStartPt As PointF
        Dim pHEndPt As PointF
        Dim pVStartPt As PointF
        Dim pVEndPt As PointF

        If m_bMouseDown = True Then

            If bRefPoint = True Then

                grpTools.Clear(Color.Transparent)

                dOffsetX = m_RectSizeWnd.Width / m_MarkData.nAlignMark_ModelSizeX
                dOffsetY = m_RectSizeWnd.Height / m_MarkData.nAlignMark_ModelSizeY

                dTmpPosX = e.X / CSng(dOffsetX)
                dTmpPosY = e.Y / CSng(dOffsetY)

                ipPosX = e.X 'dTmpPosX
                ipPosY = e.Y 'dTmpPosY
                ipSize = 20

                UpdateClossInfo(dTmpPosX, dTmpPosY)

                If bmakeModel = True Then
                    DrawFenceSPT(m_strImagePath)
                Else
                    DrawFenceSPT(m_MarkData.strAlignMarkImageBMP_FileName)
                End If

                pHStartPt = New PointF(ipPosX - ipSize / 2, ipPosY)
                pHEndPt = New PointF(ipPosX + ipSize / 2, ipPosY)
                pVStartPt = New PointF(ipPosX, ipPosY - ipSize / 2)
                pVEndPt = New PointF(ipPosX, ipPosY + ipSize / 2)

                AddLine(Color.Blue, pHStartPt, pHEndPt)
                AddLine(Color.Blue, pVStartPt, pVEndPt)

                picModel.Image = bMap
                picModel.Update()

                m_bMouseDown = False

            End If

        End If

        'New연산자 해제
        BluePen = Nothing

    End Sub

    Private Sub picModel_DoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles picModel.MouseDoubleClick

        Dim strImage As String = ""
        'Dim StrTemp() As String
        Dim nCam As Integer = 0

        Select Case m_iLine

            Case 0
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 0
                Else
                    nCam = 1
                End If

            Case 1
                If m_iPanel = 0 Or m_iPanel = 2 Then
                    nCam = 2
                Else
                    nCam = 3
                End If

        End Select

        If bsetModel = True Then

            frmAlignMarkSetting.Show()
            frmAlignMarkSetting.ShowDisplay(nCam)
            frmAlignMarkSetting.fnAllocMark()

            brefpPoint = True
            'bsetModel = False
            MarkStack()

        ElseIf bsetModel = False Then

            '우선 막아.!
            '            strImage = m_MarkData.strAlignMarkImageMMF_FileName
            '            StrTemp = Split(strImage, ".")
            '            strImage = StrTemp(0) '(StrTemp.Length - 1)

            '#If SIMUL <> 1 Then
            '            MIL.MbufLoad(m_MarkData.strAlignMarkImageBMP_FileName, pMilInterface.dispImageChild(nCam))
            '#End If
            '            ''기존 Model을 Load 하자.
            '            frmAlignMarkSetting.Show()
            '            frmAlignMarkSetting.ShowDisplay(nCam)
            '            frmAlignMarkSetting.fnShowMark(strImage)

        End If

    End Sub

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .BtnDrowROI.Text = My.Resources.setLan.ResourceManager.GetObject("ROIArea")

            .btnSetRoi.Text = My.Resources.setLan.ResourceManager.GetObject("ROISave")
            .BtnDrowMODEL.Text = My.Resources.setLan.ResourceManager.GetObject("MarkArea")
            .btnModelSetting.Text = My.Resources.setLan.ResourceManager.GetObject("MakrSave")
            .Label3.Text = My.Resources.setLan.ResourceManager.GetObject("doubleclickaftersetmark")

            .btnModelApply.Text = My.Resources.setLan.ResourceManager.GetObject("ModelApply")
            .Save.Text = My.Resources.setLan.ResourceManager.GetObject("ModelSave")
            .Label1.Text = My.Resources.setLan.ResourceManager.GetObject("TLxy")
            .Label2.Text = My.Resources.setLan.ResourceManager.GetObject("RBxy")

            .GroupBox14.Text = My.Resources.setLan.ResourceManager.GetObject("ROIInformation")
            .Label158.Text = My.Resources.setLan.ResourceManager.GetObject("StartX")
            .Label159.Text = My.Resources.setLan.ResourceManager.GetObject("StartY")
            .Label156.Text = My.Resources.setLan.ResourceManager.GetObject("SizeX")

            .Label157.Text = My.Resources.setLan.ResourceManager.GetObject("SizeY")

            .Label5.Text = My.Resources.setLan.ResourceManager.GetObject("Refxy")
            .ChkRefPoint.Text = My.Resources.setLan.ResourceManager.GetObject("RefPoint")
            .GroupBox1.Text = My.Resources.setLan.ResourceManager.GetObject("ModelInformation")
            .Label163.Text = My.Resources.setLan.ResourceManager.GetObject("OffsetX")

            .Label167.Text = My.Resources.setLan.ResourceManager.GetObject("OffsetY")

            .Label160.Text = My.Resources.setLan.ResourceManager.GetObject("SizeX")
            .Label162.Text = My.Resources.setLan.ResourceManager.GetObject("SizeY")
            .Label169.Text = My.Resources.setLan.ResourceManager.GetObject("matchingrate")
            .Label168.Text = My.Resources.setLan.ResourceManager.GetObject("matchingrateformal")

            .BtnAcceptSave.Text = My.Resources.setLan.ResourceManager.GetObject("Save")
            .chkMarkUse.Text = My.Resources.setLan.ResourceManager.GetObject("Use")

            .BtnCopy.Text = My.Resources.setLan.ResourceManager.GetObject("Copy")
            .Label161.Text = My.Resources.setLan.ResourceManager.GetObject("result")

            .Label166.Text = My.Resources.setLan.ResourceManager.GetObject("Score")

            .Label165.Text = My.Resources.setLan.ResourceManager.GetObject("PosX")
            .Label164.Text = My.Resources.setLan.ResourceManager.GetObject("PosY")
            .btnModelCheck.Text = My.Resources.setLan.ResourceManager.GetObject("Verify")
            .btnToM.Text = My.Resources.setLan.ResourceManager.GetObject("GoMark")

        End With

    End Sub

    Private Sub numCnt_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numCnt.ValueChanged
        m_MarkData.nSubMark = numCnt.Value
    End Sub
End Class
