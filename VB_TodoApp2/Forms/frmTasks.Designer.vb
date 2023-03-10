<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTasks
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTaskName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtExpiredDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPriority = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtComment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnTaskDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnTaskUpdate = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtUserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblTaskName = New System.Windows.Forms.Label()
        Me.txtSearchTaskName = New System.Windows.Forms.TextBox()
        Me.lblSearchCount = New System.Windows.Forms.Label()
        Me.btnOutputCSV = New System.Windows.Forms.Button()
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(486, 457)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(143, 43)
        Me.btnBack.TabIndex = 43
        Me.btnBack.Text = "戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'dgvTasks
        '
        Me.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.txtTaskName, Me.txtExpiredDate, Me.txtPriority, Me.txtDetail, Me.txtComment, Me.btnTaskDelete, Me.btnTaskUpdate, Me.txtUserID})
        Me.dgvTasks.Location = New System.Drawing.Point(149, 165)
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.RowHeadersWidth = 51
        Me.dgvTasks.RowTemplate.Height = 24
        Me.dgvTasks.Size = New System.Drawing.Size(480, 240)
        Me.dgvTasks.TabIndex = 42
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "ID"
        Me.Id.MinimumWidth = 6
        Me.Id.Name = "Id"
        Me.Id.Visible = False
        Me.Id.Width = 125
        '
        'txtTaskName
        '
        Me.txtTaskName.DataPropertyName = "TaskName"
        Me.txtTaskName.HeaderText = "タスク名"
        Me.txtTaskName.MinimumWidth = 6
        Me.txtTaskName.Name = "txtTaskName"
        Me.txtTaskName.Width = 125
        '
        'txtExpiredDate
        '
        Me.txtExpiredDate.DataPropertyName = "ExpiredDate"
        Me.txtExpiredDate.HeaderText = "有効期限"
        Me.txtExpiredDate.MinimumWidth = 6
        Me.txtExpiredDate.Name = "txtExpiredDate"
        Me.txtExpiredDate.Width = 125
        '
        'txtPriority
        '
        Me.txtPriority.DataPropertyName = "Priority"
        Me.txtPriority.HeaderText = "優先度"
        Me.txtPriority.MinimumWidth = 6
        Me.txtPriority.Name = "txtPriority"
        Me.txtPriority.Width = 125
        '
        'txtDetail
        '
        Me.txtDetail.DataPropertyName = "Detail"
        Me.txtDetail.HeaderText = "詳細"
        Me.txtDetail.MinimumWidth = 6
        Me.txtDetail.Name = "txtDetail"
        Me.txtDetail.Width = 125
        '
        'txtComment
        '
        Me.txtComment.DataPropertyName = "Comment"
        Me.txtComment.HeaderText = "コメント"
        Me.txtComment.MinimumWidth = 6
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Width = 125
        '
        'btnTaskDelete
        '
        Me.btnTaskDelete.HeaderText = "削除"
        Me.btnTaskDelete.MinimumWidth = 6
        Me.btnTaskDelete.Name = "btnTaskDelete"
        Me.btnTaskDelete.Width = 125
        '
        'btnTaskUpdate
        '
        Me.btnTaskUpdate.HeaderText = "更新"
        Me.btnTaskUpdate.MinimumWidth = 6
        Me.btnTaskUpdate.Name = "btnTaskUpdate"
        Me.btnTaskUpdate.Width = 125
        '
        'txtUserID
        '
        Me.txtUserID.DataPropertyName = "UserId"
        Me.txtUserID.HeaderText = "ユーザID"
        Me.txtUserID.MinimumWidth = 6
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Visible = False
        Me.txtUserID.Width = 125
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(486, 102)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(143, 43)
        Me.btnSearch.TabIndex = 53
        Me.btnSearch.Text = "検索"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblTaskName
        '
        Me.lblTaskName.AutoSize = True
        Me.lblTaskName.Location = New System.Drawing.Point(148, 21)
        Me.lblTaskName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTaskName.Name = "lblTaskName"
        Me.lblTaskName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTaskName.Size = New System.Drawing.Size(53, 15)
        Me.lblTaskName.TabIndex = 52
        Me.lblTaskName.Text = "タスク名"
        '
        'txtSearchTaskName
        '
        Me.txtSearchTaskName.Location = New System.Drawing.Point(149, 49)
        Me.txtSearchTaskName.Name = "txtSearchTaskName"
        Me.txtSearchTaskName.Size = New System.Drawing.Size(480, 22)
        Me.txtSearchTaskName.TabIndex = 51
        '
        'lblSearchCount
        '
        Me.lblSearchCount.AutoSize = True
        Me.lblSearchCount.Location = New System.Drawing.Point(649, 55)
        Me.lblSearchCount.Name = "lblSearchCount"
        Me.lblSearchCount.Size = New System.Drawing.Size(0, 15)
        Me.lblSearchCount.TabIndex = 54
        '
        'btnOutputCSV
        '
        Me.btnOutputCSV.Location = New System.Drawing.Point(326, 457)
        Me.btnOutputCSV.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOutputCSV.Name = "btnOutputCSV"
        Me.btnOutputCSV.Size = New System.Drawing.Size(143, 43)
        Me.btnOutputCSV.TabIndex = 55
        Me.btnOutputCSV.Text = "CSV出力"
        Me.btnOutputCSV.UseVisualStyleBackColor = True
        '
        'frmTasks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 553)
        Me.Controls.Add(Me.btnOutputCSV)
        Me.Controls.Add(Me.lblSearchCount)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.lblTaskName)
        Me.Controls.Add(Me.txtSearchTaskName)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dgvTasks)
        Me.Name = "frmTasks"
        Me.Text = "frmTasks"
        CType(Me.dgvTasks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents dgvTasks As DataGridView
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents txtTaskName As DataGridViewTextBoxColumn
    Friend WithEvents txtExpiredDate As DataGridViewTextBoxColumn
    Friend WithEvents txtPriority As DataGridViewTextBoxColumn
    Friend WithEvents txtDetail As DataGridViewTextBoxColumn
    Friend WithEvents txtComment As DataGridViewTextBoxColumn
    Friend WithEvents btnTaskDelete As DataGridViewButtonColumn
    Friend WithEvents btnTaskUpdate As DataGridViewButtonColumn
    Friend WithEvents txtUserID As DataGridViewTextBoxColumn
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblTaskName As Label
    Friend WithEvents txtSearchTaskName As TextBox
    Friend WithEvents lblSearchCount As Label
    Friend WithEvents btnOutputCSV As Button
End Class
