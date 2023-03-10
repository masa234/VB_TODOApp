Public Class frmLogin
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

            'ユーザが存在するかどうか?
            If Not User.IsExistsUser(userName, password) Then
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
