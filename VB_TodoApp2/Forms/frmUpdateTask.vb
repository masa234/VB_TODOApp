Public Class frmUpdateTask

    'ログインユーザID
    Private loginUserID As Long
    '更新対象タスクID
    Private updateTaskID As Long

    Public Sub New(ByVal loginUserId As Long,
                   ByVal updateTaskId As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        '設定
        'ログインユーザID
        Me.loginUserID = loginUserId
        '更新対象タスクID
        Me.updateTaskID = updateTaskId

    End Sub


    Private Sub frmUpdateTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btnUpdateTask_Click(sender As Object, e As EventArgs) Handles btnUpdateTask.Click

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

            '未来日チェック(有効期限)
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

            '更新
            If Not Task.UpdateTask(taskName,
                                   expiredDate,
                                   priority,
                                   detail,
                                   comment,
                                   Me.loginUserID,
                                   Me.updateTaskID) Then
                'メッセージボックス
                MessageBox.Show(Constant.FAILED_UPDATE_TASK,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '成功メッセージ
            MessageBox.Show(Constant.SUCCESS_UPDATE_TASK,
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


    Private Sub InitForm()

        Dim priorityList As List(Of String)
        Dim taskData As TaskData

        'タスク情報を取得
        taskData = Task.GetTask(Me.updateTaskID)

        '画面に設定
        'タスク名
        Me.txtTaskName.Text = taskData.TaskName
        '有効期限
        Me.dateExpiredDate.Value = taskData.ExpiredDate
        '優先度のリストを取得          
        priorityList = OtherProc.GetPriorityList
        '優先度(コンボボックス)
        CommonProc.SetCmb(cmbPriority, priorityList)
        '優先度
        Me.cmbPriority.Text = taskData.Priority
        '詳細
        Me.txtDetail.Text = taskData.Detail
        'コメント
        Me.txtComment.Text = taskData.Comment

    End Sub

End Class