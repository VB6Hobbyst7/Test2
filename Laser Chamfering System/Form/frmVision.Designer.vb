<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVision
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbVisionChoice = New System.Windows.Forms.GroupBox()
        Me.btnVisionA1 = New System.Windows.Forms.Button()
        Me.btnVisionB2 = New System.Windows.Forms.Button()
        Me.btnVisionB1 = New System.Windows.Forms.Button()
        Me.btnVisionA2 = New System.Windows.Forms.Button()
        Me.btnManualAlignOK = New System.Windows.Forms.Button()
        Me.btnManualZoom_ORI = New System.Windows.Forms.Button()
        Me.btnManualZoom = New System.Windows.Forms.Button()
        Me.btnManualAlignNG = New System.Windows.Forms.Button()
        Me.gbVisionChoice.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbVisionChoice
        '
        Me.gbVisionChoice.Controls.Add(Me.btnVisionA1)
        Me.gbVisionChoice.Controls.Add(Me.btnVisionB2)
        Me.gbVisionChoice.Controls.Add(Me.btnVisionB1)
        Me.gbVisionChoice.Controls.Add(Me.btnVisionA2)
        Me.gbVisionChoice.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbVisionChoice.Location = New System.Drawing.Point(5, 20)
        Me.gbVisionChoice.Name = "gbVisionChoice"
        Me.gbVisionChoice.Size = New System.Drawing.Size(436, 88)
        Me.gbVisionChoice.TabIndex = 12
        Me.gbVisionChoice.TabStop = False
        Me.gbVisionChoice.Text = "Select Vision"
        '
        'btnVisionA1
        '
        Me.btnVisionA1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnVisionA1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVisionA1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisionA1.ImageIndex = 0
        Me.btnVisionA1.Location = New System.Drawing.Point(7, 27)
        Me.btnVisionA1.Name = "btnVisionA1"
        Me.btnVisionA1.Size = New System.Drawing.Size(101, 45)
        Me.btnVisionA1.TabIndex = 161
        Me.btnVisionA1.Tag = "0"
        Me.btnVisionA1.Text = "Line A Camera 1"
        Me.btnVisionA1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVisionA1.UseVisualStyleBackColor = False
        '
        'btnVisionB2
        '
        Me.btnVisionB2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnVisionB2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVisionB2.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisionB2.ImageIndex = 0
        Me.btnVisionB2.Location = New System.Drawing.Point(328, 27)
        Me.btnVisionB2.Name = "btnVisionB2"
        Me.btnVisionB2.Size = New System.Drawing.Size(101, 45)
        Me.btnVisionB2.TabIndex = 160
        Me.btnVisionB2.Tag = "3"
        Me.btnVisionB2.Text = "Line B Camera 2"
        Me.btnVisionB2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVisionB2.UseVisualStyleBackColor = False
        '
        'btnVisionB1
        '
        Me.btnVisionB1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnVisionB1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVisionB1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisionB1.ImageIndex = 0
        Me.btnVisionB1.Location = New System.Drawing.Point(221, 27)
        Me.btnVisionB1.Name = "btnVisionB1"
        Me.btnVisionB1.Size = New System.Drawing.Size(101, 45)
        Me.btnVisionB1.TabIndex = 159
        Me.btnVisionB1.Tag = "2"
        Me.btnVisionB1.Text = "Line B Camera 1"
        Me.btnVisionB1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVisionB1.UseVisualStyleBackColor = False
        '
        'btnVisionA2
        '
        Me.btnVisionA2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnVisionA2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVisionA2.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisionA2.ImageIndex = 0
        Me.btnVisionA2.Location = New System.Drawing.Point(114, 27)
        Me.btnVisionA2.Name = "btnVisionA2"
        Me.btnVisionA2.Size = New System.Drawing.Size(101, 45)
        Me.btnVisionA2.TabIndex = 158
        Me.btnVisionA2.Tag = "1"
        Me.btnVisionA2.Text = "Line A Camera 2"
        Me.btnVisionA2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnVisionA2.UseVisualStyleBackColor = False
        '
        'btnManualAlignOK
        '
        Me.btnManualAlignOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnManualAlignOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManualAlignOK.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualAlignOK.ImageIndex = 0
        Me.btnManualAlignOK.Location = New System.Drawing.Point(446, 63)
        Me.btnManualAlignOK.Name = "btnManualAlignOK"
        Me.btnManualAlignOK.Size = New System.Drawing.Size(114, 45)
        Me.btnManualAlignOK.TabIndex = 339
        Me.btnManualAlignOK.Tag = "2"
        Me.btnManualAlignOK.Text = "Manual Align OK"
        Me.btnManualAlignOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnManualAlignOK.UseVisualStyleBackColor = False
        '
        'btnManualZoom_ORI
        '
        Me.btnManualZoom_ORI.BackColor = System.Drawing.SystemColors.Control
        Me.btnManualZoom_ORI.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManualZoom_ORI.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualZoom_ORI.ImageIndex = 0
        Me.btnManualZoom_ORI.Location = New System.Drawing.Point(446, 12)
        Me.btnManualZoom_ORI.Name = "btnManualZoom_ORI"
        Me.btnManualZoom_ORI.Size = New System.Drawing.Size(114, 45)
        Me.btnManualZoom_ORI.TabIndex = 363
        Me.btnManualZoom_ORI.Tag = "2"
        Me.btnManualZoom_ORI.Text = "1:1"
        Me.btnManualZoom_ORI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnManualZoom_ORI.UseVisualStyleBackColor = False
        Me.btnManualZoom_ORI.Visible = False
        '
        'btnManualZoom
        '
        Me.btnManualZoom.BackColor = System.Drawing.SystemColors.Control
        Me.btnManualZoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManualZoom.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualZoom.ImageIndex = 0
        Me.btnManualZoom.Location = New System.Drawing.Point(566, 12)
        Me.btnManualZoom.Name = "btnManualZoom"
        Me.btnManualZoom.Size = New System.Drawing.Size(114, 45)
        Me.btnManualZoom.TabIndex = 364
        Me.btnManualZoom.Tag = "2"
        Me.btnManualZoom.Text = "Zoom"
        Me.btnManualZoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnManualZoom.UseVisualStyleBackColor = False
        Me.btnManualZoom.Visible = False
        '
        'btnManualAlignNG
        '
        Me.btnManualAlignNG.BackColor = System.Drawing.SystemColors.Control
        Me.btnManualAlignNG.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManualAlignNG.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualAlignNG.ImageIndex = 0
        Me.btnManualAlignNG.Location = New System.Drawing.Point(566, 63)
        Me.btnManualAlignNG.Name = "btnManualAlignNG"
        Me.btnManualAlignNG.Size = New System.Drawing.Size(114, 45)
        Me.btnManualAlignNG.TabIndex = 365
        Me.btnManualAlignNG.Tag = "2"
        Me.btnManualAlignNG.Text = "Manual Align NG"
        Me.btnManualAlignNG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnManualAlignNG.UseVisualStyleBackColor = False
        Me.btnManualAlignNG.Visible = False
        '
        'frmVision
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(690, 914)
        Me.Controls.Add(Me.btnManualAlignNG)
        Me.Controls.Add(Me.btnManualZoom)
        Me.Controls.Add(Me.btnManualZoom_ORI)
        Me.Controls.Add(Me.btnManualAlignOK)
        Me.Controls.Add(Me.gbVisionChoice)
        Me.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmVision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmVision"
        Me.gbVisionChoice.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbVisionChoice As System.Windows.Forms.GroupBox
    Friend WithEvents btnVisionA1 As System.Windows.Forms.Button
    Friend WithEvents btnVisionB2 As System.Windows.Forms.Button
    Friend WithEvents btnVisionB1 As System.Windows.Forms.Button
    Friend WithEvents btnVisionA2 As System.Windows.Forms.Button
    Friend WithEvents btnManualAlignOK As System.Windows.Forms.Button
    Friend WithEvents btnManualZoom_ORI As System.Windows.Forms.Button
    Friend WithEvents btnManualZoom As System.Windows.Forms.Button
    Friend WithEvents btnManualAlignNG As System.Windows.Forms.Button
    '#If SIMUL <> 1 Then
    '    Friend WithEvents MImage_A1 As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MGraphicContext_A1 As AxMatrox.ActiveMIL.AxMGraphicContext
    '    Friend WithEvents MDigitizer_A As AxMatrox.ActiveMIL.AxMDigitizer
    '    Friend WithEvents MSystem_A As AxMatrox.ActiveMIL.AxMSystem
    '    Friend WithEvents MDigitizer_B As AxMatrox.ActiveMIL.AxMDigitizer
    '    Friend WithEvents MGraphicContext_B1 As AxMatrox.ActiveMIL.AxMGraphicContext
    '    Friend WithEvents MImage_B1 As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MImage_B2 As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MSystem_B As AxMatrox.ActiveMIL.AxMSystem
    '    Friend WithEvents MImage_A2 As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MMF_Image_B As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MMF_Image_A As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MMF_Image_Child_B As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MMF_Image_Child_A As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MDisplay_B2 As AxMatrox.ActiveMIL.AxMDisplay
    '    Friend WithEvents MDisplay_B1 As AxMatrox.ActiveMIL.AxMDisplay
    '    Friend WithEvents MDisplay_A2 As AxMatrox.ActiveMIL.AxMDisplay
    '    Friend WithEvents MDisplay_A1 As AxMatrox.ActiveMIL.AxMDisplay
    '    Friend WithEvents MainImage_B As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MainImage_A As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MGraphicContext_B2 As AxMatrox.ActiveMIL.AxMGraphicContext
    '    Friend WithEvents MGraphicContext_A2 As AxMatrox.ActiveMIL.AxMGraphicContext
    '    Friend WithEvents MMF_Image_Save_B As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MMF_Image_Save_A As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MModelFinder_A As AxMatrox.ActiveMIL.ModelFinder.AxMModelFinder
    '    Friend WithEvents MImageProcessing_A As AxMatrox.ActiveMIL.ImageProcessing.AxMImageProcessing
    '    Friend WithEvents MImageProcessing_B As AxMatrox.ActiveMIL.ImageProcessing.AxMImageProcessing
    '    Friend WithEvents MModelFinder_B As AxMatrox.ActiveMIL.ModelFinder.AxMModelFinder
    '    Friend WithEvents AxMApplication1 As AxMatrox.ActiveMIL.AxMApplication
    '    Friend WithEvents MGraphicContext_MMF_B As AxMatrox.ActiveMIL.AxMGraphicContext
    '    Friend WithEvents MGraphicContext_MMF_A As AxMatrox.ActiveMIL.AxMGraphicContext
    '    Friend WithEvents MImageZoom_A As AxMatrox.ActiveMIL.AxMImage
    '    Friend WithEvents MImageZoom_B As AxMatrox.ActiveMIL.AxMImage
    '#End If
End Class
