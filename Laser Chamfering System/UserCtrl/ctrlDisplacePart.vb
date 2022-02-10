Public Class ctrlDisplacePart

    Public m_Line As Integer
    Public m_Panel As Integer
    Public m_nValue As Integer
    Public m_strTotalValueX(,) As String
    Public m_strTotalValueY(,) As String
    Public m_nTotalCnt() As Integer

    Enum Block
        BLOCK_NONE = -1
        BLOCK_SCRAP_L = 0
        BLOCK_SCRAP_T
        BLOCK_SCRAP_R
        BLOCK_MAIN
        BLOCK_SCRAP_MAX = BLOCK_MAIN
    End Enum

    Enum Side
        SIDE_X = 1
        SIDE_Y
        SIDE_MAX = SIDE_Y
    End Enum

    Public m_dBlockVal(,,) As Double

    Public m_strName(Block.BLOCK_SCRAP_MAX) As String
    Public m_nCntMax(Block.BLOCK_SCRAP_MAX) As Integer



    Public m_nSelBlock As Integer

    Public Sub New(ByVal nLine As Integer, ByVal nPanel As Integer)

        InitializeComponent()

        m_Line = nLine
        m_Panel = nPanel

        m_strName = {"LEFT", "TOP", "RIGHT", "MAIN"}

        m_nSelBlock = 0

        LblLine.Text = nLine.ToString()
        LblPanel.Text = nPanel.ToString()

        Timer1.Enabled = True

    End Sub

    Public Function SaveData1(ByVal nBlock As Integer) As Boolean
        On Error GoTo SysErr

        Dim np As Integer = 0
        Dim maxcnt As Integer = GridListView.Rows.Count

        If System.IO.File.Exists(m_DirDisplaceRcp) = False Then
            System.IO.Directory.CreateDirectory("C:\Chamfering System\Setting\Displace")
            System.IO.File.Create(m_DirDisplaceRcp)
        End If

        m_nCntMax(nBlock) = maxcnt

        For i As Integer = 0 To maxcnt - 1
            WriteIni(m_Line.ToString() & "-" & m_Panel.ToString(), m_strName(nBlock) & "_X" & i.ToString(), GridListView.Rows(i).Cells(Side.SIDE_X).Value(), m_DirDisplaceRcp)
            WriteIni(m_Line.ToString() & "-" & m_Panel.ToString(), m_strName(nBlock) & "_Y" & i.ToString(), GridListView.Rows(i).Cells(Side.SIDE_Y).Value(), m_DirDisplaceRcp)
        Next

        WriteIni(m_Line.ToString() & "-" & m_Panel.ToString(), m_strName(nBlock) & "_Max", maxcnt.ToString(), m_DirDisplaceRcp)

        Return True
SysErr:
    End Function

    Public Function ReadData1() As Boolean
        On Error GoTo SysErr

        If m_nSelBlock = Block.BLOCK_NONE Then
            MessageBox.Show("Block 을 선택 후 Read 바랍니다.", "알림")
            Return False
        End If

        Dim MaxCnt As Integer = 0

        ReDim m_nTotalCnt(3)

        For i As Integer = 0 To 3
            If pbSelectposition(i) = True Then
                Dim strtmp As String = ""
                strtmp = CInt(ReadIni(m_Line.ToString() & "-" & m_Panel.ToString(), m_strName(i) & "_Max", "20", m_DirDisplaceRcp))
                m_nTotalCnt(i) = CInt(strtmp)
                MaxCnt += CInt(strtmp)
            End If
        Next
        pnMaxCnt = MaxCnt

        ReDim m_dBlockVal(Block.BLOCK_SCRAP_MAX, Side.SIDE_MAX, MaxCnt)
        ReDim m_strTotalValueX(3, MaxCnt - 1)
        ReDim m_strTotalValueY(3, MaxCnt - 1)

        GridListView.RowCount = MaxCnt

        For i As Integer = 0 To 3
            For k As Integer = 0 To MaxCnt - 1
                m_strTotalValueX(i, k) = ReadIni(m_Line.ToString() & "-" & m_Panel.ToString(), m_strName(i) & "_X" & k.ToString(), "0", m_DirDisplaceRcp)
                m_strTotalValueY(i, k) = ReadIni(m_Line.ToString() & "-" & m_Panel.ToString(), m_strName(i) & "_Y" & k.ToString(), "0", m_DirDisplaceRcp)
            Next
        Next

        Dim ntmpCnt As Integer = 0
        For i As Integer = 0 To 3
            If pbSelectposition(i) = True Then
                For k As Integer = 0 To m_nTotalCnt(i) - 1
                    GridListView.Rows(ntmpCnt).Cells(0).Value() = m_strName(i)

                    GridListView.Rows(ntmpCnt).Cells(Side.SIDE_X).Value() = m_strTotalValueX(i, k)
                    m_dBlockVal(i, Side.SIDE_X, ntmpCnt) = m_strTotalValueX(i, k)

                    GridListView.Rows(ntmpCnt).Cells(Side.SIDE_Y).Value() = m_strTotalValueY(i, k)
                    m_dBlockVal(i, Side.SIDE_Y, ntmpCnt) = m_strTotalValueY(i, k)

                    ntmpCnt = ntmpCnt + 1
                Next
            End If
        Next
        Return True
SysErr:
        Return False
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRead.Click
        On Error GoTo SysErr
        ReadData1()
        pbRead = True
SysErr:

    End Sub

    Private Sub GridListView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridListView.CellContentClick
        On Error GoTo SysErr

        Dim CurRow As Integer = GridListView.CurrentCell.RowIndex
        Dim CurCol As Integer = GridListView.CurrentCell.ColumnIndex

        If CurCol > Side.SIDE_Y Then
            If m_Line = 0 Then
                GridListView.Rows(CurRow).Cells(Side.SIDE_X).Value() = (pLDLT.PLC_Infomation.dCurPosX(LINE.A)).ToString
                GridListView.Rows(CurRow).Cells(Side.SIDE_Y).Value() = (pLDLT.PLC_Infomation.dCurPosY(LINE.A)).ToString
            Else
                GridListView.Rows(CurRow).Cells(Side.SIDE_X).Value() = (pLDLT.PLC_Infomation.dCurPosX(LINE.B)).ToString
                GridListView.Rows(CurRow).Cells(Side.SIDE_Y).Value() = (pLDLT.PLC_Infomation.dCurPosY(LINE.B)).ToString
            End If
        End If
SysErr:

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim ntmpCheck As Integer = 0
        For i As Integer = 0 To 3
            If pbSelectposition(i) = True Then
                ntmpCheck = ntmpCheck + 1
            End If
        Next
        If pnSelectPosition > 3 Then
            frmMSG.ShowMsg("변위 센서 자동 시퀀스", "저장할 블럭을 선택하세요", False, 1)
            Return
        End If
        If ntmpCheck = 1 Then
            SaveData1(pnSelectPosition)
        ElseIf ntmpCheck > 1 Then
            frmMSG.ShowMsg("변위 센서 자동 시퀀스", "저장할 블럭을 한개만 선택하세요", False, 1)
        ElseIf ntmpCheck = 0 Then
            frmMSG.ShowMsg("변위 센서 자동 시퀀스", "저장할 블럭을 선택하세요", False, 1)
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        GridListView.Rows.Add()

    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        On Error GoTo syserr

        GridListView.Rows.RemoveAt(GridListView.CurrentCell.RowIndex)
syserr:

    End Sub
End Class
