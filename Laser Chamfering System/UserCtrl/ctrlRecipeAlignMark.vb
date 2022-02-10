Public Class ctrlRecipeAlignMark

    Public m_iLine As Integer
    Public m_iPanel As Integer
    Private m_iAlignMarkUseNo As Integer    'Align Mark 사용하고자 하는 번호
    Public m_ctrlAlignMark(1, 2) As ctrlAlignMarkSetting        ' 1st, 2nd mark : 1, 2, 3

    'Public Sub New(ByVal nLine As Integer, ByVal nPanel As Integer, ByVal nMark As Integer)
    Public Sub New(ByVal nLine As Integer, ByVal nPanel As Integer)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        m_iLine = nLine
        m_iPanel = nPanel
        For nMark As Integer = 0 To 1           ' ' 첫 마크 / 두번째 마크
            For index = 0 To 2
                m_ctrlAlignMark(nMark, index) = New ctrlAlignMarkSetting(m_iLine, m_iPanel)
                m_ctrlAlignMark(nMark, index).Height = 300
                m_ctrlAlignMark(nMark, index).Location = New System.Drawing.Point(0, nMark * m_ctrlAlignMark(0, index).Height)
                'm_ctrlAlignMark(nMark, index).Location = New System.Drawing.Point(0, 0)
                tabMarks.TabPages(index).Controls.Add(m_ctrlAlignMark(nMark, index))

                m_ctrlAlignMark(nMark, index).m_iIndex = index
                m_ctrlAlignMark(nMark, index).m_iMark = nMark

                m_ctrlAlignMark(nMark, index).Visible = True

            Next
        Next

        SetSelectedMark(0)

        'm_ctrlAlignMark(0, 0).Focus()

    End Sub


    Private Sub ctrlRecipeAlignMark_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        SetSelectedMark(0)

    End Sub

    Private Sub tabMarks_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tabMarks.SelectedIndexChanged

        'Dim strFilePath As String = ""
        'Dim strFilePath_A As String = ""
        'Dim strFilePath_B As String = ""

        'strFilePath = modPub.GetFileFolder(pCurSystemParam.strLastModelFilePath, 0)
        'strFilePath = strFilePath & "\Align Data"

        'If System.IO.Directory.Exists(strFilePath) = False Then
        '    System.IO.Directory.CreateDirectory(strFilePath)
        'End If

        'Dim nCam As Integer
        'Select Case m_iLine
        '    Case 0
        '        If m_iPanel = 0 Or m_iPanel = 2 Then
        '            nCam = 0
        '        Else
        '            nCam = 1
        '        End If
        '    Case 1
        '        If m_iPanel = 0 Or m_iPanel = 2 Then
        '            nCam = 2
        '        Else
        '            nCam = 3
        '        End If
        'End Select

        'Dim strPathDel As String = ""
        'Dim strLine(1) As String
        'strLine(0) = "A"
        'strLine(1) = "B"

        'strFilePath_A = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (0 + 1).ToString & "_" & (tabMarks.SelectedIndex + 1).ToString & ".MMF"
        'strFilePath_B = strFilePath & "\" & strLine(m_iLine) & "_Panel" & (m_iPanel + 1).ToString & "_Mark" & (1 + 1).ToString & "_" & (tabMarks.SelectedIndex + 1).ToString & ".MMF"

        'pMilInterface.LoadAlignModelTemplate(m_iPanel, strFilePath_A)
        'pMilInterface.LoadAlignModelTemplate(m_iPanel, strFilePath_B)
        AlignMarkLoad()
        SetSelectedMark(tabMarks.SelectedIndex)


    End Sub

    Public Sub SetSelectedMark(ByVal nSelTabpage As Integer)

        'SetManualVisionMode 초기화
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam1).SetManualVisionMode(0)
        frmVision.m_ctrlOneVision(m_iLine, CAM.Cam2).SetManualVisionMode(0)


        'frmRecipe.m_CurAlignMarkSetting(0) = Me.m_ctrlAlignMark(0, nSelTabpage)
        'frmRecipe.m_CurAlignMarkSetting(1) = Me.m_ctrlAlignMark(1, nSelTabpage)

   
        'frmRecipe.m_CurAlignMarkSetting(0).UpdateData(False)
        'frmRecipe.m_CurAlignMarkSetting(1).UpdateData(False)

    End Sub
    Public Function AlignMarkLoad() As Boolean
        m_iPanel = frmRecipe.m_ctrlRcpAlign(m_iLine).tabPanel.SelectedIndex
        m_iAlignMarkUseNo = frmRecipe.m_ctrlRcpAlign(m_iLine).m_ctrlMarks(m_iPanel).tabMarks.SelectedIndex
        For m_iAlignMarkNo As Integer = 0 To 1
            frmRecipe.m_ctrlRcpAlign(m_iLine).m_ctrlMarks(m_iPanel).m_ctrlAlignMark(m_iAlignMarkNo, m_iAlignMarkUseNo).UpdateData(False)
        Next
        Return True
    End Function

    Public Sub LanChange(ByVal StrCulture As String)

        Me.Text = StrCulture

        With Me

            .tpMark1_1.Text = My.Resources.setLan.ResourceManager.GetObject("Mark1")
            .tpMark1_2.Text = My.Resources.setLan.ResourceManager.GetObject("Mark2")
            .tpMark1_3.Text = My.Resources.setLan.ResourceManager.GetObject("Mark3")
            
        End With

    End Sub
End Class
