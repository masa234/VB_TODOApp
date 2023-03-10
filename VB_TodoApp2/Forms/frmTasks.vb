Imports Microsoft.VisualBasic.ApplicationServices

Public Class frmTasks

    'ログインユーザID
    Private loginUserID As Long

    Public Sub New(ByVal loginUserID As Long)

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        'ログインユーザID設定
        Me.loginUserID = loginUserID

    End Sub
    Private Sub frmTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


    Private Sub dgvTasks_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTasks.CellContentClick

        Dim taskId As Long
        'TODO: 変数名改善の余地あり
        Dim taskCreateUserID As Long

        Try
            'タスクID
            'TODO : ここに書くべきかは議論の余地がある
            taskId = Long.Parse(dgvTasks.Rows(e.RowIndex).Cells(2).Value.ToString())

            '削除ボタンが押されている場合
            If dgvTasks.Columns(e.ColumnIndex).Name = "btnTaskDelete" Then
                'ユーザID
                taskCreateUserID = Long.Parse(dgvTasks.Rows(e.RowIndex).Cells(8).Value.ToString())

                'ログインユーザのタスクかどうか?
                If taskCreateUserID <> Me.loginUserID Then
                    '終了(メッセージは表示しない)
                    Return
                End If

                '削除
                If Not Task.DeleteTask(taskId) Then
                    'メッセージボックス
                    MessageBox.Show(Constant.FAILED_DELETE_TASK,
                                    Constant.CONFIRM,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information)
                    Return
                End If

                '成功メッセージ
                MessageBox.Show(Constant.SUCCESS_DELETE_TASK,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                'データソースの再設定
                SetDataSource()

            End If

            '更新ボタンが押されている場合
            If dgvTasks.Columns(e.ColumnIndex).Name = "btnTaskUpdate" Then

                '更新画面に遷移
                CommonProc.HideAndOpen(Me, New frmUpdateTask(Me.loginUserID, taskId))

            End If

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                            Constant.WARNING,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Dim taskCount As Long
        Dim searchTaskName As String

        Try
            '検索タスク名
            searchTaskName = txtSearchTaskName.Text

            'カウントを取得
            taskCount = Task.GetSearchCount(Me.loginUserID, searchTaskName)

            '画面に設定
            'TODO: もっと良い書き方があるかもしれない
            Me.lblSearchCount.Text = CStr(taskCount) & "件"

            'データソースの設定
            SetSearchDataSource(searchTaskName)

        Catch ex As Exception
            'メッセージボックス
            MessageBox.Show(ex.Message,
                    Constant.WARNING,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnOutputCSV_Click(sender As Object, e As EventArgs) Handles btnOutputCSV.Click

        Dim taskList As List(Of TaskData)

        Try
            'タスクリストを取得
            taskList = Task.GetUserTaskList(Me.loginUserID)

            'CSV出力
            If Not Task.OutputCSV(taskList, Constant.OUTPUT_CSV_PATH) Then
                'メッセージボックス
                MessageBox.Show(Constant.FAILED_OUTPUT_CSV,
                                Constant.CONFIRM,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Return
            End If

            '成功メッセージ
            MessageBox.Show(Constant.SUCCESS_OUTPUT_CSV,
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


    ''' <summary>
    ''' フォーム初期化
    ''' </summary>
    ''' 2023/03/06
    Private Sub InitForm()

        'データソースの設定
        SetDataSource()

    End Sub


    ''' <summary>
    ''' データソースの設定
    ''' </summary>
    ''' 2023/03/06
    Private Sub SetDataSource()

        'データソースの設定
        Me.dgvTasks.DataSource = Task.GetUserTaskList(Me.loginUserID)

    End Sub


    ''' <summary>
    ''' データソースの設定(検索用)
    ''' </summary>
    ''' 2023/03/06
    ''' TODO：サブルーチン名改善の余地あり
    Private Sub SetSearchDataSource(ByVal searchTaskName As String)

        'データソースの設定
        Me.dgvTasks.DataSource = Task.GetSearchResult(Me.loginUserID, searchTaskName)

    End Sub

End Class