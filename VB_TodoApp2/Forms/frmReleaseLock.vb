Public Class frmReleaseLock

    'ログインユーザID
    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub


    Private Sub frmReleaseLock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub dgvLockUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLockUsers.CellContentClick

        Dim lockedUserName As String

        Try
            'ロック解除ボタンが押されている場合
            If dgvLockUsers.Columns(e.ColumnIndex).Name = "btnReleaseLock" Then

                '管理者かどうか?
                If Not User.IsAdmin(Me.loginUserID) Then
                    '管理者でない場合、終了
                    Return
                End If

                '対象ユーザ名
                lockedUserName = dgvLockUsers.Rows(e.RowIndex).Cells(2).Value.ToString()

                'ロック解除
                If Not User.UpdateLock(lockedUserName, EnumValue.IsLock.NotLock) Then
                    'メッセージボックス
                    MessageBox.Show(Constant.FAILED_RELEASE_LOCK,
                                    Constant.CONFIRM,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Return
                End If

                '成功メッセージ
                MessageBox.Show(Constant.SUCCESS_RELEASE_LOCK,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                'データソースの再設定
                SetDataSource()

            End If

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
    ''' 2023/03/02
    Private Sub InitForm()

        'データソース設定
        SetDataSource()

    End Sub


    ''' <summary>
    ''' データソース設定
    ''' </summary>
    ''' 2023/03/02
    Private Sub SetDataSource()

        'データソース設定
        Me.dgvLockUsers.DataSource = User.GetLockedUsers

    End Sub

End Class