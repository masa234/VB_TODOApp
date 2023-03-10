Public Class frmMain

    'ログインユーザID
    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'フォーム初期化
            InitForm()

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                            Constant.WARNING,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        Try
            'ログイン画面に遷移
            CommonProc.HideAndOpen(Me, New frmLogin)

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                            Constant.WARNING,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRegisterUser_Click(sender As Object, e As EventArgs) Handles btnRegisterUser.Click

        Try
            '登録画面に遷移
            CommonProc.HideAndOpen(Me, New frmRegisterUser(Me.loginUserID))

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                            Constant.WARNING,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click

        Try
            'ユーザ一覧画面に遷移
            CommonProc.HideAndOpen(Me, New frmUsers(Me.loginUserID))

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                        Constant.WARNING,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnUpdateUser_Click(sender As Object, e As EventArgs) Handles btnUpdateUser.Click

        Try
            'ユーザ更新画面に遷移
            CommonProc.HideAndOpen(Me, New frmUpdateUser(Me.loginUserID))

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                    Constant.WARNING,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        End Try

    End Sub


    ''' <summary>
    ''' フォーム初期化
    ''' </summary>
    ''' 2023/02/27
    Private Sub InitForm()

        'ボタンの表示非表示を設定
        SetBtnVisible()

    End Sub


    ''' <summary>
    ''' ボタンの表示非表示を設定
    ''' </summary>
    ''' 2023/02/27
    Private Sub SetBtnVisible()

        '管理者でない場合
        If Not User.IsAdmin(Me.loginUserID) Then
            'ボタンを非表示にする
            '登録ボタン
            Me.btnRegisterUser.Visible = False
        End If

    End Sub

End Class