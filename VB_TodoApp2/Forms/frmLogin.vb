Public Class frmLogin

    'ログインカウント
    Dim loginCount As Long

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインカウント初期化
        Me.loginCount = 0

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try
            Dim loginUserID As Long
            Dim userName As String
            Dim password As String

            'ユーザ名
            userName = txtUserName.Text
            'パスワード
            password = txtPassword.Text

            '入力チェック(ユーザ名)
            If Not CommonProc.IsFitInText(userName, Constant.USERNAME_MAX_LENGTH) Then
                'メッセージボックス
                MessageBox.Show(Constant.INVALID_USERNAME_LENGTH,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '入力チェック(パスワード)
            If Not CommonProc.IsFitInText(password, Constant.PASSWORD_MAX_LENGTH) Then
                'メッセージボックス
                MessageBox.Show(Constant.INVALID_PASSWORD_LENGTH,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            'ユーザ名が存在するか?
            If Not User.IsExistsUserName(userName) Then
                'TODO: 同じコードを2回書いている
                'メッセージボックス
                MessageBox.Show(Constant.FAILED_LOGIN,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            End If

            'アカウントがロックされているかどうか?
            If User.IsLockedUserName(userName) Then
                'メッセージボックス
                MessageBox.Show(Constant.USER_IS_LOCKED,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            'ユーザが存在するかどうか?
            If Not User.IsExistsUser(userName, password) Then
                'ロックカウントをカウントアップ
                Me.loginCount = Me.loginCount + 1

                'ログイン失敗回数が指定回数を超えた場合
                If Constant.LOCK_COUNT <= Me.loginCount Then
                    'アカウントロック(失敗時、メッセージは表示しない)
                    User.UpdateLock(userName, EnumValue.IsLock.Locked)

                    'メッセージボックス
                    MessageBox.Show(Constant.USER_IS_LOCK,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                    Return
                End If

                'メッセージボックス
                MessageBox.Show(Constant.FAILED_LOGIN,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            'ユーザID取得
            loginUserID = User.GetUserID(userName, password)

            'メイン画面に遷移
            CommonProc.HideAndOpen(Me, New frmMain(loginUserID))

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                            Constant.WARNING,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub
End Class
