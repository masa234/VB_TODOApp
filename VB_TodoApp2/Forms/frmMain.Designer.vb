<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnRegisterUser = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnUpdateUser = New System.Windows.Forms.Button()
        Me.btnControlAuthority = New System.Windows.Forms.Button()
        Me.btnReleaseLock = New System.Windows.Forms.Button()
        Me.btnInsertTask = New System.Windows.Forms.Button()
        Me.btnTasks = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(623, 372)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(129, 55)
        Me.btnLogout.TabIndex = 1
        Me.btnLogout.Text = "ログアウト"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnRegisterUser
        '
        Me.btnRegisterUser.Location = New System.Drawing.Point(35, 42)
        Me.btnRegisterUser.Name = "btnRegisterUser"
        Me.btnRegisterUser.Size = New System.Drawing.Size(129, 55)
        Me.btnRegisterUser.TabIndex = 2
        Me.btnRegisterUser.Text = "登録"
        Me.btnRegisterUser.UseVisualStyleBackColor = True
        '
        'btnUsers
        '
        Me.btnUsers.Location = New System.Drawing.Point(184, 42)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Size = New System.Drawing.Size(129, 55)
        Me.btnUsers.TabIndex = 3
        Me.btnUsers.Text = "一覧"
        Me.btnUsers.UseVisualStyleBackColor = True
        '
        'btnUpdateUser
        '
        Me.btnUpdateUser.Location = New System.Drawing.Point(340, 42)
        Me.btnUpdateUser.Name = "btnUpdateUser"
        Me.btnUpdateUser.Size = New System.Drawing.Size(129, 55)
        Me.btnUpdateUser.TabIndex = 4
        Me.btnUpdateUser.Text = "更新"
        Me.btnUpdateUser.UseVisualStyleBackColor = True
        '
        'btnControlAuthority
        '
        Me.btnControlAuthority.Location = New System.Drawing.Point(35, 139)
        Me.btnControlAuthority.Name = "btnControlAuthority"
        Me.btnControlAuthority.Size = New System.Drawing.Size(129, 55)
        Me.btnControlAuthority.TabIndex = 5
        Me.btnControlAuthority.Text = "権限更新"
        Me.btnControlAuthority.UseVisualStyleBackColor = True
        '
        'btnReleaseLock
        '
        Me.btnReleaseLock.Location = New System.Drawing.Point(184, 139)
        Me.btnReleaseLock.Name = "btnReleaseLock"
        Me.btnReleaseLock.Size = New System.Drawing.Size(129, 55)
        Me.btnReleaseLock.TabIndex = 6
        Me.btnReleaseLock.Text = "アカウントロック解除"
        Me.btnReleaseLock.UseVisualStyleBackColor = True
        '
        'btnInsertTask
        '
        Me.btnInsertTask.Location = New System.Drawing.Point(35, 225)
        Me.btnInsertTask.Name = "btnInsertTask"
        Me.btnInsertTask.Size = New System.Drawing.Size(129, 55)
        Me.btnInsertTask.TabIndex = 7
        Me.btnInsertTask.Text = "タスク追加"
        Me.btnInsertTask.UseVisualStyleBackColor = True
        '
        'btnTasks
        '
        Me.btnTasks.Location = New System.Drawing.Point(184, 225)
        Me.btnTasks.Name = "btnTasks"
        Me.btnTasks.Size = New System.Drawing.Size(129, 55)
        Me.btnTasks.TabIndex = 8
        Me.btnTasks.Text = "タスク一覧"
        Me.btnTasks.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnTasks)
        Me.Controls.Add(Me.btnInsertTask)
        Me.Controls.Add(Me.btnReleaseLock)
        Me.Controls.Add(Me.btnControlAuthority)
        Me.Controls.Add(Me.btnUpdateUser)
        Me.Controls.Add(Me.btnUsers)
        Me.Controls.Add(Me.btnRegisterUser)
        Me.Controls.Add(Me.btnLogout)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLogout As Button
    Friend WithEvents btnRegisterUser As Button
    Friend WithEvents btnUsers As Button
    Friend WithEvents btnUpdateUser As Button
    Friend WithEvents btnControlAuthority As Button
    Friend WithEvents btnReleaseLock As Button
    Friend WithEvents btnInsertTask As Button
    Friend WithEvents btnTasks As Button
End Class
