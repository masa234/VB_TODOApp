Public Class frmInsertTask

    'ログインユーザID
    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub

    Private Sub frmTaskInsert_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btnTaskRegister_Click(sender As Object, e As EventArgs) Handles btnTaskRegister.Click

        Dim taskName As String
        Dim expiredDate As Date
        Dim priority As String
        Dim detail As String
        Dim comment As String

        Try
            'タスク名
            taskName = Me.txtTaskName.Text
            '有効期限
            expiredDate = Me.dateExpiredDate.Value
            '優先度
            priority = Me.cmbPriority.Text
            '詳細
            detail = Me.txtDetail.Text
            'コメント
            comment = Me.txtComment.Text

            '文字数チェック(タスク名)
            If Not CommonProc.IsFitInText(taskName, Constant.TASKNAME_MAX_LENGTH) Then
                'メッセージボックス
                MessageBox.Show(Constant.INVALID_TASKNAME_LENGTH,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '入力チェック(有効期限)
            If Not CommonProc.IsInputed(expiredDate) Then
                'メッセージボックス
                MessageBox.Show(Constant.EXPIREDDATE_MUST_INPUT,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '未来日になっているかどうか?(有効期限)
            If Not CommonProc.IsFuture(expiredDate) Then
                'メッセージボックス
                MessageBox.Show(Constant.EXPIREDDATE_MUST_FUTURE,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '入力チェック(優先度)
            If Not CommonProc.IsInputed(priority) Then
                'メッセージボックス
                MessageBox.Show(Constant.PRIORITY_MUST_INPUT,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '文字数チェック(詳細)
            If Not CommonProc.IsFitInText(detail, Constant.DETAIL_MAX_LENGTH) Then
                'メッセージボックス
                MessageBox.Show(Constant.INVALID_DETAIL_LENGTH,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '文字数チェック(コメント)
            If Not CommonProc.IsFitInText(comment, Constant.COMMENT_MAX_LENGTH) Then
                'メッセージボックス
                MessageBox.Show(Constant.INVALID_COMMENT_LENGTH,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '登録
            If Not Task.InsertTask(taskName, expiredDate, priority, detail, comment, Me.loginUserID) Then
                'メッセージボックス
                MessageBox.Show(Constant.FAILED_INSERT_TASK,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '成功メッセージ
            MessageBox.Show(Constant.SUCCESS_INSERT_TASK,
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
    ''' 2023/03/03
    Private Sub InitForm()

        Dim priorityList As List(Of String)

        Try
            '優先度のリストを取得
            priorityList = OtherProc.GetPriorityList

            '設定
            '優先度(コンボボックス)
            CommonProc.SetCmb(cmbPriority, priorityList)

            '有効期限
            dateExpiredDate.Value = DateTime.Now

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                        Constant.WARNING,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtTaskName_TextChanged(sender As Object, e As EventArgs) Handles txtTaskName.TextChanged

    End Sub

    Private Sub lblExpiredDate_Click(sender As Object, e As EventArgs) Handles lblExpiredDate.Click

    End Sub

    Private Sub dateExpiredDate_ValueChanged(sender As Object, e As EventArgs) Handles dateExpiredDate.ValueChanged

    End Sub

    Private Sub lblPriority_Click(sender As Object, e As EventArgs) Handles lblPriority.Click

    End Sub

    Private Sub cmbPriority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPriority.SelectedIndexChanged

    End Sub

    Private Sub txtDetail_TextChanged(sender As Object, e As EventArgs) Handles txtDetail.TextChanged

    End Sub

    Private Sub lblDetail_Click(sender As Object, e As EventArgs) Handles lblDetail.Click

    End Sub

    Private Sub lblTaskName_Click(sender As Object, e As EventArgs) Handles lblTaskName.Click

    End Sub
End Class