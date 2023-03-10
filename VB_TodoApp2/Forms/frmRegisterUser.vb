Public Class frmRegisterUser

    'ログインユーザID
    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub
    Private Sub btnRegisterUser_Click(sender As Object, e As EventArgs) Handles btnRegisterUser.Click

        Dim userName As String
        Dim password As String

        Try
            '管理者判定
            If Not User.IsAdmin(Me.loginUserID) Then
                '終了(メッセージは表示しない)
                Return
            End If

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

            '登録
            If Not User.RegisterUser(userName, password) Then
                'メッセージボックス
                MessageBox.Show(Constant.FAILED_REGISTER_USER,
                            Constant.CONFIRM,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
                Return
            End If

            '成功メッセージ
            MessageBox.Show(Constant.SUCCESS_REGISTER_USER,
                            Constant.CONFIRM,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                        Constant.WARNING,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click


        Try
            'メイン画面に遷移
            CommonProc.HideAndOpen(Me, New frmMain(Me.loginUserID))

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                            Constant.WARNING,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub

End Class