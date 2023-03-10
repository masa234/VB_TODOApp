<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.txtUserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnUserDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(475, 338)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(143, 43)
        Me.btnBack.TabIndex = 38
        Me.btnBack.Text = "戻る"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'dgvUsers
        '
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txtUserName, Me.txtPassword, Me.btnUserDelete, Me.txtID})
        Me.dgvUsers.Location = New System.Drawing.Point(182, 70)
        Me.dgvUsers.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.RowHeadersWidth = 62
        Me.dgvUsers.RowTemplate.Height = 27
        Me.dgvUsers.Size = New System.Drawing.Size(436, 223)
        Me.dgvUsers.TabIndex = 37
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
        'btnUserDelete
        '
        Me.btnUserDelete.HeaderText = "削除"
        Me.btnUserDelete.MinimumWidth = 8
        Me.btnUserDelete.Name = "btnUserDelete"
        Me.btnUserDelete.Width = 150
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
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.dgvUsers)
        Me.Name = "frmUsers"
        Me.Text = "frmUsers"
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBack As Button
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents txtUserName As DataGridViewTextBoxColumn
    Friend WithEvents txtPassword As DataGridViewTextBoxColumn
    Friend WithEvents btnUserDelete As DataGridViewButtonColumn
    Friend WithEvents txtID As DataGridViewTextBoxColumn
End Class
