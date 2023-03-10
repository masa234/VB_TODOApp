Imports Microsoft.VisualBasic.ApplicationServices

Public Class frmControlAuthority

    'ログインユーザID
    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub

    Private Sub frmControlAuthority_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Dim updateUserID As Long

        Try
            'TODO: ここに書くべきかは議論の余地がある
            '管理者でない場合
            If Not User.IsAdmin(Me.loginUserID) Then
                '終了
                Return
            End If

            '対象ユーザID
            updateUserID = Long.Parse(dgvUsers.Rows(e.RowIndex).Cells(2).Value.ToString())

            '管理者にするボタンが押されている場合
            If dgvUsers.Columns(e.ColumnIndex).Name = "btnUpdateAdmin" Then
                '既に管理者かどうか?
                If User.IsAdmin(updateUserID) Then
                    'メッセージボックス
                    MessageBox.Show(Constant.USER_IS_ADMIN,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                    Return
                End If

                '権限更新
                If Not User.UpdateAuthority(updateUserID, EnumValue.UserType.Admin) Then
                    'メッセージボックス
                    MessageBox.Show(Constant.FAILED_UPDATE_AUTHORITY,
                                    Constant.CONFIRM,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Return
                End If

                '成功メッセージ
                MessageBox.Show(Constant.SUCCESS_UPDATE_AUTHORITY,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

            End If

            '一般ユーザにするボタンが押されている場合
            If dgvUsers.Columns(e.ColumnIndex).Name = "btnUpdateNormal" Then
                '既に一般ユーザかどうか?
                If Not User.IsAdmin(updateUserID) Then
                    'メッセージボックス
                    MessageBox.Show(Constant.USER_IS_NORMAL,
                                    Constant.CONFIRM,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Return
                End If

                '権限更新
                If Not User.UpdateAuthority(updateUserID, EnumValue.UserType.Normal) Then
                    'メッセージボックス
                    MessageBox.Show(Constant.FAILED_UPDATE_AUTHORITY,
                                    Constant.CONFIRM,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Return
                End If

                '成功メッセージ
                MessageBox.Show(Constant.SUCCESS_UPDATE_AUTHORITY,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
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
        Me.dgvUsers.DataSource = User.GetUsers

    End Sub

End Class