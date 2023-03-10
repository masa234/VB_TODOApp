<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateTask
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.txtDetail = New System.Windows.Forms.TextBox()
        Me.lblDetail = New System.Windows.Forms.Label()
        Me.cmbPriority = New System.Windows.Forms.ComboBox()
        Me.lblPriority = New System.Windows.Forms.Label()
        Me.dateExpiredDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpiredDate = New System.Windows.Forms.Label()
        Me.txtTaskName = New System.Windows.Forms.TextBox()
        Me.lblTaskName = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnUpdateTask = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(103, 515)
        Me.txtComment.Margin = New System.Windows.Forms.Padding(2)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtComment.Size = New System.Drawing.Size(406, 107)
        Me.txtComment.TabIndex = 58
        '
        'lblComment
        '
        Me.lblComment.AutoSize = True
        Me.lblComment.Location = New System.Drawing.Point(105, 471)
        Me.lblComment.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblComment.Size = New System.Drawing.Size(49, 15)
        Me.lblComment.TabIndex = 57
        Me.lblComment.Text = "コメント"
        '
        'txtDetail
        '
        Me.txtDetail.Location = New System.Drawing.Point(105, 346)
        Me.txtDetail.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDetail.Multiline = True
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDetail.Size = New System.Drawing.Size(406, 107)
        Me.txtDetail.TabIndex = 56
        '
        'lblDetail
        '
        Me.lblDetail.AutoSize = True
        Me.lblDetail.Location = New System.Drawing.Point(107, 305)
        Me.lblDetail.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDetail.Name = "lblDetail"
        Me.lblDetail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDetail.Size = New System.Drawing.Size(37, 15)
        Me.lblDetail.TabIndex = 55
        Me.lblDetail.Text = "詳細"
        '
        'cmbPriority
        '
        Me.cmbPriority.FormattingEnabled = True
        Me.cmbPriority.Location = New System.Drawing.Point(105, 252)
        Me.cmbPriority.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbPriority.Name = "cmbPriority"
        Me.cmbPriority.Size = New System.Drawing.Size(98, 23)
        Me.cmbPriority.TabIndex = 54
        '
        'lblPriority
        '
        Me.lblPriority.AutoSize = True
        Me.lblPriority.Location = New System.Drawing.Point(107, 227)
        Me.lblPriority.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPriority.Name = "lblPriority"
        Me.lblPriority.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPriority.Size = New System.Drawing.Size(52, 15)
        Me.lblPriority.TabIndex = 53
        Me.lblPriority.Text = "優先度"
        '
        'dateExpiredDate
        '
        Me.dateExpiredDate.Location = New System.Drawing.Point(107, 182)
        Me.dateExpiredDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dateExpiredDate.Name = "dateExpiredDate"
        Me.dateExpiredDate.Size = New System.Drawing.Size(161, 22)
        Me.dateExpiredDate.TabIndex = 52
        '
        'lblExpiredDate
        '
        Me.lblExpiredDate.AutoSize = True
        Me.lblExpiredDate.Location = New System.Drawing.Point(107, 148)
        Me.lblExpiredDate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblExpiredDate.Name = "lblExpiredDate"
        Me.lblExpiredDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblExpiredDate.Size = New System.Drawing.Size(67, 15)
        Me.lblExpiredDate.TabIndex = 51
        Me.lblExpiredDate.Text = "有効期限"
        '
        'txtTaskName
        '
        Me.txtTaskName.Location = New System.Drawing.Point(105, 97)
        Me.txtTaskName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTaskName.Name = "txtTaskName"
        Me.txtTaskName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTaskName.Size = New System.Drawing.Size(406, 22)
        Me.txtTaskName.TabIndex = 50
        '
        'lblTaskName
        '
        Me.lblTaskName.AutoSize = True
        Me.lblTaskName.Location = New System.Drawing.Point(107, 65)
        Me.lblTaskName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTaskName.Name = "lblTaskName"
        Me.lblTaskName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTaskName.Size = New System.Drawing.Size(53, 15)
        Me.lblTaskName.TabIndex = 49
        Me.lblTaskName.Text = "タスク名"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(204, 668)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(143, 43)
        Me.btnBack.TabIndex = 60
        Me.btnBack.Text = "戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnUpdateTask
        '
        Me.btnUpdateTask.Location = New System.Drawing.Point(368, 668)
        Me.btnUpdateTask.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUpdateTask.Name = "btnUpdateTask"
        Me.btnUpdateTask.Size = New System.Drawing.Size(143, 43)
        Me.btnUpdateTask.TabIndex = 59
        Me.btnUpdateTask.Text = "更新"
        Me.btnUpdateTask.UseVisualStyleBackColor = True
        '
        'frmUpdateTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 870)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnUpdateTask)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.txtDetail)
        Me.Controls.Add(Me.lblDetail)
        Me.Controls.Add(Me.cmbPriority)
        Me.Controls.Add(Me.lblPriority)
        Me.Controls.Add(Me.dateExpiredDate)
        Me.Controls.Add(Me.lblExpiredDate)
        Me.Controls.Add(Me.txtTaskName)
        Me.Controls.Add(Me.lblTaskName)
        Me.Name = "frmUpdateTask"
        Me.Text = "frmTaskUpdate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtComment As TextBox
    Friend WithEvents lblComment As Label
    Friend WithEvents txtDetail As TextBox
    Friend WithEvents lblDetail As Label
    Friend WithEvents cmbPriority As ComboBox
    Friend WithEvents lblPriority As Label
    Friend WithEvents dateExpiredDate As DateTimePicker
    Friend WithEvents lblExpiredDate As Label
    Friend WithEvents txtTaskName As TextBox
    Friend WithEvents lblTaskName As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnUpdateTask As Button
End Class
