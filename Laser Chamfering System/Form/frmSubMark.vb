Public Class frmSubMark
    Dim nTotalcnt As Integer = 0
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        nTotalcnt = CInt(txtTotal.Text)
        lblA1Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(0, 0) / nTotalcnt) * 100, 3) & "%"
        lblA1Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(0, 0) / nTotalcnt) * 100, 3) & "%"
        lblA1Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(0, 0) / nTotalcnt) * 100, 3) & "%"
        lblA1Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(0, 1) / nTotalcnt) * 100, 3) & "%"
        lblA1Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(0, 1) / nTotalcnt) * 100, 3) & "%"
        lblA1Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(0, 1) / nTotalcnt) * 100, 3) & "%"
        lblA2Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(1, 0) / nTotalcnt) * 100, 3) & "%"
        lblA2Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(1, 0) / nTotalcnt) * 100, 3) & "%"
        lblA2Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(1, 0) / nTotalcnt) * 100, 3) & "%"
        lblA2Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(1, 1) / nTotalcnt) * 100, 3) & "%"
        lblA2Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(1, 1) / nTotalcnt) * 100, 3) & "%"
        lblA2Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(1, 1) / nTotalcnt) * 100, 3) & "%"
        lblA3Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(2, 0) / nTotalcnt) * 100, 3) & "%"
        lblA3Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(2, 0) / nTotalcnt) * 100, 3) & "%"
        lblA3Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(2, 0) / nTotalcnt) * 100, 3) & "%"
        lblA3Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(2, 1) / nTotalcnt) * 100, 3) & "%"
        lblA3Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(2, 1) / nTotalcnt) * 100, 3) & "%"
        lblA3Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(2, 1) / nTotalcnt) * 100, 3) & "%"
        lblA4Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(3, 0) / nTotalcnt) * 100, 3) & "%"
        lblA4Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(3, 0) / nTotalcnt) * 100, 3) & "%"
        lblA4Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(3, 0) / nTotalcnt) * 100, 3) & "%"
        lblA4Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(3, 1) / nTotalcnt) * 100, 3) & "%"
        lblA4Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(3, 1) / nTotalcnt) * 100, 3) & "%"
        lblA4Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(3, 1) / nTotalcnt) * 100, 3) & "%"

        lblB1Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(4, 0) / nTotalcnt) * 100, 3) & "%"
        lblB1Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(4, 0) / nTotalcnt) * 100, 3) & "%"
        lblB1Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(4, 0) / nTotalcnt) * 100, 3) & "%"
        lblB1Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(4, 1) / nTotalcnt) * 100, 3) & "%"
        lblB1Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(4, 1) / nTotalcnt) * 100, 3) & "%"
        lblB1Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(4, 1) / nTotalcnt) * 100, 3) & "%"
        lblB2Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(5, 0) / nTotalcnt) * 100, 3) & "%"
        lblB2Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(5, 0) / nTotalcnt) * 100, 3) & "%"
        lblB2Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(5, 0) / nTotalcnt) * 100, 3) & "%"
        lblB2Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(5, 1) / nTotalcnt) * 100, 3) & "%"
        lblB2Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(5, 1) / nTotalcnt) * 100, 3) & "%"
        lblB2Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(5, 1) / nTotalcnt) * 100, 3) & "%"
        lblB3Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(6, 0) / nTotalcnt) * 100, 3) & "%"
        lblB3Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(6, 0) / nTotalcnt) * 100, 3) & "%"
        lblB3Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(6, 0) / nTotalcnt) * 100, 3) & "%"
        lblB3Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(6, 1) / nTotalcnt) * 100, 3) & "%"
        lblB3Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(6, 1) / nTotalcnt) * 100, 3) & "%"
        lblB3Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(6, 1) / nTotalcnt) * 100, 3) & "%"
        lblB4Mark1_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(7, 0) / nTotalcnt) * 100, 3) & "%"
        lblB4Mark1_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(7, 0) / nTotalcnt) * 100, 3) & "%"
        lblB4Mark1_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(7, 0) / nTotalcnt) * 100, 3) & "%"
        lblB4Mark2_1st.Text = Math.Round((modSubMark.nMark1_AlignCnt(7, 1) / nTotalcnt) * 100, 3) & "%"
        lblB4Mark2_2st.Text = Math.Round((modSubMark.nMark2_AlignCnt(7, 1) / nTotalcnt) * 100, 3) & "%"
        lblB4Mark2_3st.Text = Math.Round((modSubMark.nMark3_AlignCnt(7, 1) / nTotalcnt) * 100, 3) & "%"





    End Sub


End Class