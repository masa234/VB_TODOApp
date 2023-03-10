Public Class frmUsers

    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick

        Dim deleteUserID As Long

        Try

            '削除ボタンが押されている場合
            If dgvUsers.Columns(e.ColumnIndex).Name = "btnUserDelete" Then

                '削除対象ID
                deleteUserID = Long.Parse(dgvUsers.Rows(e.RowIndex).Cells(1).Value.ToString())

                '削除
                If Not User.DeleteUser(deleteUserID) Then
                    'メッセージボックス
                    MessageBox.Show(Constant.FAILED_DELETE_USER,
                                        Constant.CONFIRM,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information)
                    Return
                End If

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
    ''' 2023/03/01
    Private Sub InitForm()

        'データソース設定
        SetDataSource()

    End Sub


    ''' <summary>
    ''' データソース設定
    ''' </summary>
    ''' 2023/03/01
    Private Sub SetDataSource()

        'データソース設定
        Me.dgvUsers.DataSource = User.GetUsers

    End Sub

End Class