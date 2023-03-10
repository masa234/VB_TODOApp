Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView

Public Class Task

    ''' <summary>
    ''' タスク登録
    ''' </summary>
    ''' 2023/03/06
    Public Shared Function InsertTask(ByVal taskName As String,
                                    ByVal expiredDate As Date,
                                    ByVal strPriority As String,
                                    ByVal detail As String,
                                    ByVal comment As String,
                                    ByVal loginUserID As Long) As Boolean

        Dim intPriority As Integer
        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        '優先度をint型に変換する
        intPriority = OtherProc.PriorityToInt(strPriority)

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("TaskName", taskName),
            New SqlParameter("ExpiredDate", expiredDate),
            New SqlParameter("Priority", intPriority),
            New SqlParameter("Detail", detail),
            New SqlParameter("Comment", comment),
            New SqlParameter("UserId", loginUserID)
        })

        'SQL取得
        sql = Constant.INSERT_TASK_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function


    ''' <summary>
    ''' ユーザのタスクリスト取得
    ''' </summary>
    ''' 2023/03/06
    Public Shared Function GetUserTaskList(ByVal userID As Long) As List(Of TaskData)

        Dim sql As String
        Dim taskList As List(Of TaskData)
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserId", userID)
        })

        'SQL取得
        sql = Constant.GET_USER_TASKS_SQL

        'インスタンス化
        db = New DB()

        'リスト作成
        taskList = New List(Of TaskData)

        '実行結果(データを取得)
        'TODO: もっと良い方法があるかもしれない
        Using dt = db.GetDt(sql, paramList)
            taskList = DtToTaskList(dt)
        End Using

        Return taskList

    End Function


    ''' <summary>
    ''' データをタスクリストに変換する
    ''' </summary>
    ''' 2023/03/06
    Public Shared Function DtToTaskList(ByVal dt As DataTable) As List(Of TaskData)

        Dim taskData As TaskData
        Dim taskList As List(Of TaskData)

        'リスト作成
        taskList = New List(Of TaskData)

        '行数分繰り返す
        For Each row As DataRow In dt.Rows
            'インスタンス化
            taskData = New TaskData

            '設定
            'ID
            taskData.Id = row("Id").ToString()
            'タスク名
            taskData.TaskName = row("TaskName").ToString()
            '有効期限
            taskData.ExpiredDate = CDate(row("ExpiredDate").ToString())
            '優先度
            taskData.Priority = OtherProc.PriorityToString(Integer.Parse(row("Priority").ToString()))
            '詳細
            taskData.Detail = row("Detail").ToString()
            'コメント
            taskData.Comment = row("Comment").ToString()
            'ユーザID
            taskData.UserId = row("UserId").ToString()

            'リストに追加する
            taskList.Add(taskData)

        Next row

        Return taskList

    End Function


    ''' <summary>
    ''' タスク削除
    ''' </summary>
    ''' 2023/03/06
    Public Shared Function DeleteTask(ByVal deleteTaskID As Long) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("Id", deleteTaskID)
        })

        'SQL取得
        sql = Constant.DELETE_TASK_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function


    ''' <summary>
    ''' タスク情報取得
    ''' </summary>
    ''' 2023/03/07
    Public Shared Function GetTask(ByVal taskID As Long) As TaskData

        Dim sql As String
        Dim taskData As TaskData
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("Id", taskID)
        })

        'SQL取得
        sql = Constant.GET_TASK_SQL

        'インスタンス化
        db = New DB()

        'インスタンス化
        taskData = New TaskData

        '実行結果を取得
        Using reader = db.ExecuteReader(sql, paramList)
            '読み込める間、繰り返す
            While reader.Read
                '設定
                'ID
                taskData.Id = reader(0)
                'タスク名
                taskData.TaskName = reader(1)
                '有効期限
                taskData.ExpiredDate = DateTime.Parse(reader(2))
                '優先度
                taskData.Priority = OtherProc.PriorityToString(reader(3))
                '詳細
                taskData.Detail = reader(4)
                'コメント
                taskData.Comment = reader(5)
                'ユーザID
                taskData.UserId = reader(6)

                Return taskData

            End While
        End Using

        Return taskData

    End Function


    ''' <summary>
    ''' タスク更新
    ''' </summary>
    ''' 2023/03/07
    Public Shared Function UpdateTask(ByVal taskName As String,
                                    ByVal expiredDate As Date,
                                    ByVal strPriority As String,
                                    ByVal detail As String,
                                    ByVal comment As String,
                                    ByVal loginUserID As Long,
                                    ByVal updateTaskID As Long) As Boolean

        Dim intPriority As Integer
        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        '優先度をint型に変換する
        intPriority = OtherProc.PriorityToInt(strPriority)

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("TaskName", taskName),
            New SqlParameter("ExpiredDate", expiredDate),
            New SqlParameter("Priority", intPriority),
            New SqlParameter("Detail", detail),
            New SqlParameter("Comment", comment),
            New SqlParameter("UserId", loginUserID),
            New SqlParameter("Id", updateTaskID)
        })

        'SQL取得
        sql = Constant.UPDATE_TASK_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function


    ''' <summary>
    ''' 検索用、タスクリスト取得
    ''' </summary>
    ''' 2023/03/07
    ''' TODO：関数名改善の余地あり
    Public Shared Function GetSearchResult(ByVal loginUserID As Long,
                                           ByVal taskName As String) As List(Of TaskData)

        Dim sql As String
        Dim taskList As List(Of TaskData)
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserId", loginUserID),
            New SqlParameter("TaskName", taskName)
        })

        'SQL取得
        sql = Constant.SEARCH_TASK_SQL

        'リスト作成
        taskList = New List(Of TaskData)

        'インスタンス化
        db = New DB()

        '実行結果(データを取得)
        Using dt = db.GetDt(sql, paramList)
            'データをタスクリストに変換する
            taskList = DtToTaskList(dt)
        End Using

        Return taskList

    End Function


    ''' <summary>
    ''' 検索用、件数取得
    ''' </summary>
    ''' 2023/03/07
    Public Shared Function GetSearchCount(ByVal loginUserID As Long,
                                           ByVal taskName As String) As Long

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserId", loginUserID),
            New SqlParameter("TaskName", taskName)
        })

        'SQL取得
        sql = Constant.GET_SEARCH_COUNT_SQL

        'インスタンス化
        db = New DB()

        '実行結果(件数)を取得
        Return db.ExecuteScalar(sql, paramList)

    End Function


    ''' <summary>
    ''' CSV出力
    ''' </summary>
    ''' 2023/03/10
    Public Shared Function OutputCSV(ByVal taskList As List(Of TaskData),
                                     ByVal outputCSVPath As String) As Boolean

        Dim stringList As List(Of String)

        'Stringのリストに変換
        stringList = TaskListToStringList(taskList)

        '区切り文字で区切る
        String.Join(",", stringList)

        '出力
        File.WriteAllLines(outputCSVPath, stringList)

        Return True

    End Function


    ''' <summary>
    ''' タスクリストを文字列のリストに変換する
    ''' </summary>
    ''' 2023/03/10
    Public Shared Function TaskListToStringList(ByVal taskList As List(Of TaskData)) As List(Of String)

        Dim retList As List(Of String)

        'リスト作成
        retList = New List(Of String)

        'タスクリストの数だけ繰り返す
        For Each task In taskList
            'リストに追加
            retList.Add(task.TaskName)
        Next task

        Return retList

    End Function

End Class
