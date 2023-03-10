Imports System.Data.Common

Public Class frmUpdateUser

    'ログインユーザID
    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub
    Private Sub frmUserUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btnUpdateUser_Click(sender As Object, e As EventArgs) Handles btnUpdateUser.Click

        Dim userName As String
        Dim password As String

        Try
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

            '更新
            If Not User.UpdateUser(userName, password, Me.loginUserID) Then
                'メッセージボックス
                MessageBox.Show(Constant.FAILED_UPDATE_USER,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '成功メッセージ
            MessageBox.Show(Constant.SUCCESS_UPDATE_USER,
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


    ''' <summary>
    ''' フォーム初期化
    ''' </summary>
    ''' 2023/03/01
    Private Sub InitForm()

        Dim userData As UserData

        'ユーザ情報取得
        userData = User.GetUser(Me.loginUserID)

        '画面に設定
        'ユーザ名
        Me.txtUserName.Text = userData.UserName
        'パスワード
        Me.txtPassword.Text = userData.Password

    End Sub

End Class