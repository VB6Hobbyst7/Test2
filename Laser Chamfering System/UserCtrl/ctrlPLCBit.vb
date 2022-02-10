Public Class ctrlPLCBit

    Dim nBoardIdPC As Integer
    Dim nBoardIdPLC As Integer
    Dim nBoardIdPCWord As Integer
    Dim nBoardIdPLCWord As Integer

    Private lWriteBits As New List(Of PlcBitMemoryModel)
    Private lReadBits As New List(Of PlcBitMemoryModel)
    Private lWriteWords As New List(Of PlcWordMemoryModel)
    Private lReadWords As New List(Of PlcWordMemoryModel)

    Private Sub ctrlPLCBit_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AddPCBitData()
        AddPLCBitData()

        nBoardIdPC = 1
        nBoardIdPLC = 1

        nBoardIdPCWord = 0
        nBoardIdPLCWord = 0

    End Sub

    Private Sub fnBtnSelect(ByVal nType As Integer, ByVal nIndex As Integer)

        Select Case nType

            Case 0
                Select Case nIndex

                    Case 0
                        btnPLCBit.BackColor = Color.Lime
                        btnPLCWord.BackColor = Color.White
                    Case 1
                        btnPLCBit.BackColor = Color.White
                        btnPLCWord.BackColor = Color.Lime
                End Select
            Case 1
                Select Case nIndex

                    Case 0
                        btnPCBit.BackColor = Color.Lime
                        btnPCWord.BackColor = Color.White
                    Case 1
                        btnPCBit.BackColor = Color.White
                        btnPCWord.BackColor = Color.Lime
                End Select

        End Select
    End Sub

    Private Function AddPCBitData() As Boolean
        On Error GoTo SysErr

        lWriteBits = pMXComponent.GetWriteBits
        dgvPCBitData.RowCount = lWriteBits.Count

        For i As Integer = 0 To dgvPCBitData.RowCount - 1
            dgvPCBitData.Rows(i).Cells(0).Value = Hex(lWriteBits.Item(i).nAddress)
            dgvPCBitData.Rows(i).Cells(1).Value = lWriteBits.Item(i).strComment
            dgvPCBitData.Rows(i).Cells(2).Value = ""
            dgvPCBitData.Rows(i).Cells(2).ReadOnly = True
        Next

        btnPCBit.Text = "PC_Bit"
        fnBtnSelect(1, 0)

        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Private Function AddPLCBitData() As Boolean
        On Error GoTo SysErr

        lReadBits = pMXComponent.GetReadBits()
        dgvPLCBitData.RowCount = lReadBits.Count

        For i As Integer = 0 To dgvPLCBitData.RowCount - 1
            dgvPLCBitData.Rows(i).Cells(0).Value = Hex(lReadBits.Item(i).nAddress)
            dgvPLCBitData.Rows(i).Cells(1).Value = lReadBits.Item(i).strComment
            dgvPLCBitData.Rows(i).Cells(2).Value = ""
        Next

        btnPLCBit.Text = "PLC_Bit"
        fnBtnSelect(0, 0)

        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Private Function AddPCWordData() As Boolean
        On Error GoTo SysErr

        lWriteWords = pMXComponent.GetWriteWords()
        dgvPCBitData.RowCount = lWriteWords.Count

        For i As Integer = 0 To dgvPCBitData.RowCount - 1
            dgvPCBitData.Rows(i).Cells(0).Value = Hex(lWriteWords.Item(i).nAddress)
            dgvPCBitData.Rows(i).Cells(1).Value = lWriteWords.Item(i).strComment
            dgvPCBitData.Rows(i).Cells(2).Value = ""
        Next

        btnPLCBit.Text = "PLC_Word"
        fnBtnSelect(1, 1)

        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Private Function AddPLCWordData() As Boolean
        On Error GoTo SysErr

        lReadWords = pMXComponent.GetReadWords()
        dgvPLCBitData.RowCount = lReadWords.Count

        For i As Integer = 0 To dgvPLCBitData.RowCount - 1
            dgvPLCBitData.Rows(i).Cells(0).Value = Hex(lReadWords.Item(i).nAddress)
            dgvPLCBitData.Rows(i).Cells(1).Value = lReadWords.Item(i).strComment
            dgvPLCBitData.Rows(i).Cells(2).Value = ""
        Next

        btnPLCBit.Text = "PLC_Word"
        fnBtnSelect(0, 1)

        Return True

        Exit Function
SysErr:
        Return False
    End Function

    Private Sub btnPCBit_Click(sender As System.Object, e As System.EventArgs) Handles btnPCBit.Click
        AddPCBitData()
    End Sub

    Private Sub btnPLCBit_Click(sender As System.Object, e As System.EventArgs) Handles btnPLCBit.Click
        AddPLCBitData()
    End Sub

    Private Sub btnPLCWord_Click(sender As System.Object, e As System.EventArgs) Handles btnPLCWord.Click
        AddPLCWordData()
    End Sub

    Private Sub btnPCWord_Click(sender As System.Object, e As System.EventArgs) Handles btnPCWord.Click
        AddPCWordData()
    End Sub

    Private Sub dgvPCBitData_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPCBitData.CellMouseDoubleClick
        Dim PCWordData As String

        If bLogInAdmin = True Then
            If btnPCBit.BackColor = Color.Lime Then
                If dgvPCBitData.Rows(e.RowIndex).Cells(0).Value <> "PC_BitNo" Then
                    If dgvPCBitData.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.White Then
                        Dim nRet As Integer = -1
                        nRet = MsgBox(dgvPCBitData.Rows(e.RowIndex).Cells(0).Value & " Bit Set?", MsgBoxStyle.YesNo, "PLC Bit")

                        If nRet = 7 Then
                            Return
                        End If
                        'pMXComponent.WriteBitByAddress(dgvPCBitData.Rows(e.RowIndex).Cells(0).Value, True)
                        pMXComponent.WriteBitByAddress(lWriteBits.Item(e.RowIndex).nAddress, True)
                        dgvPCBitData.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Lime

                    ElseIf dgvPCBitData.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.Lime Then
                        Dim nRet As Integer = -1
                        nRet = MsgBox(dgvPCBitData.Rows(e.RowIndex).Cells(0).Value & " Bit ReSet?", MsgBoxStyle.YesNo, "PLC Bit")

                        If nRet = 7 Then
                            Return
                        End If
                        pMXComponent.WriteBitByAddress(lWriteBits.Item(e.RowIndex).nAddress, False)
                        dgvPCBitData.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.White
                    End If

                    dgvPCBitData.Update()
                End If
            ElseIf btnPCWord.BackColor = Color.Lime Then
                If dgvPCBitData.Rows(e.RowIndex).Cells(0).Value <> "PC_WordNo" Then
                    PCWordData = dgvPCBitData.Rows(e.RowIndex).Cells(2).Value
                    Dim nRet As Integer = -1
                    nRet = MsgBox("Word Number : " & dgvPCBitData.Rows(e.RowIndex).Cells(0).Value & Chr(13) & "Word Data : " & dgvPCBitData.Rows(e.RowIndex).Cells(2).Value, MsgBoxStyle.YesNo, "PC Word")

                    If nRet = 7 Then
                        Return
                    End If
                    pMXComponent.WriteWordIntegerByAddress(dgvPCBitData.Rows(e.RowIndex).Cells(0).Value, PCWordData)
                End If
            End If
            

        End If

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        On Error GoTo SysErr
        Dim PCBit_First As Integer
        Dim PCBit_Second As Integer
        Dim PLCBit_First As Integer
        Dim PLCBit_Second As Integer
        Dim BitNo_check As String
        Dim PCWord As Integer
        Dim PLCWord As Integer

        For i As Integer = 0 To dgvPCBitData.RowCount - 1
            If btnPCBit.BackColor = Color.Lime Then
                If dgvPCBitData.Rows(i).Cells(0).Value = "PC_BitNo" Then
                    dgvPCBitData.Rows(i).Cells(2).Style.BackColor = Color.White
                Else
                    If lWriteBits.Item(i).bValue = True Then
                        dgvPCBitData.Rows(i).Cells(2).Style.BackColor = Color.Lime
                    Else
                        dgvPCBitData.Rows(i).Cells(2).Style.BackColor = Color.White
                    End If
                End If
            ElseIf btnPCWord.BackColor = Color.Lime Then
                If dgvPCBitData.Rows(i).Cells(0).Value = "PC_WordNo" Then
                    dgvPCBitData.Rows(i).Cells(2).Value = ""
                Else
                    dgvPCBitData.Rows(i).Cells(2).Value = lWriteWords.Item(i).sValue
                End If
            End If
            
        Next
        For i As Integer = 0 To dgvPLCBitData.RowCount - 1
            If btnPLCBit.BackColor = Color.Lime Then
                If dgvPLCBitData.Rows(i).Cells(0).Value = "PLC_BitNo" Then
                    dgvPLCBitData.Rows(i).Cells(2).Style.BackColor = Color.White
                Else
                    If lReadBits.Item(i).bValue = True Then
                        dgvPLCBitData.Rows(i).Cells(2).Style.BackColor = Color.Lime
                    Else
                        dgvPLCBitData.Rows(i).Cells(2).Style.BackColor = Color.White
                    End If
                End If
            ElseIf btnPLCWord.BackColor = Color.Lime Then
                If dgvPLCBitData.Rows(i).Cells(0).Value = "PLC_WordNo" Then
                    dgvPLCBitData.Rows(i).Cells(2).Value = ""
                Else
                    dgvPLCBitData.Rows(i).Cells(2).Value = lReadWords.Item(i).sValue
                End If
            End If

        Next
SysErr:
    End Sub


End Class
