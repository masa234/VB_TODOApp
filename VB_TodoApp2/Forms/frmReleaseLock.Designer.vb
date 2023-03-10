<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReleaseLock
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
        Me.dgvLockUsers = New System.Windows.Forms.DataGridView()
        Me.txtUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnReleaseLock = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvLockUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(475, 338)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(143, 43)
        Me.btnBack.TabIndex = 40
        Me.btnBack.Text = "戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'dgvLockUsers
        '
        Me.dgvLockUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLockUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txtUserName, Me.txtPassword, Me.btnReleaseLock, Me.txtID})
        Me.dgvLockUsers.Location = New System.Drawing.Point(170, 68)
        Me.dgvLockUsers.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvLockUsers.Name = "dgvLockUsers"
        Me.dgvLockUsers.RowHeadersWidth = 62
        Me.dgvLockUsers.RowTemplate.Height = 27
        Me.dgvLockUsers.Size = New System.Drawing.Size(436, 223)
        Me.dgvLockUsers.TabIndex = 39
        '
        'txtUserName
        '
        Me.txtUserName.DataPropertyName = "UserName"
        Me.txtUserName.HeaderText = "ユーザ名"
        Me.txtUserName.MinimumWidth = 8
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Width = 150
        '
        'txtPassword
        '
        Me.txtPassword.DataPropertyName = "Password"
        Me.txtPassword.HeaderText = "パスワード"
        Me.txtPassword.MinimumWidth = 8
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Visible = False
        Me.txtPassword.Width = 150
        '
        'btnReleaseLock
        '
        Me.btnReleaseLock.HeaderText = "ロック解除"
        Me.btnReleaseLock.MinimumWidth = 8
        Me.btnReleaseLock.Name = "btnReleaseLock"
        Me.btnReleaseLock.Width = 150
        '
        'txtID
        '
        Me.txtID.DataPropertyName = "Id"
        Me.txtID.HeaderText = "ID"
        Me.txtID.MinimumWidth = 8
        Me.txtID.Name = "txtID"
        Me.txtID.Visible = False
        Me.txtID.Width = 150
        '
        'frmReleaseLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dgvLockUsers)
        Me.Name = "frmReleaseLock"
        Me.Text = "frmReleaseLock"
        CType(Me.dgvLockUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents dgvLockUsers As DataGridView
    Friend WithEvents txtUserName As DataGridViewTextBoxColumn
    Friend WithEvents txtPassword As DataGridViewTextBoxColumn
    Friend WithEvents btnReleaseLock As DataGridViewButtonColumn
    Friend WithEvents txtID As DataGridViewTextBoxColumn
End Class
