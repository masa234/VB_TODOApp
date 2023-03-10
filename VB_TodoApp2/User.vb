Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.VisualBasic.ApplicationServices

Public Class User


    ''' <summary>
    ''' ユーザが存在するかどうか?
    ''' </summary>
    ''' 2023/02/27
    Public Shared Function IsExistsUser(userName As String,
                                        password As String) As Boolean

        Dim userCount As Long
        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserName", userName),
            New SqlParameter("Password", password)
        })

        'SQL取得
        sql = Constant.GET_USER_COUNT_SQL

        'インスタンス化
        db = New DB()

        '実行結果(件数)を取得
        userCount = db.ExecuteScalar(sql, paramList)

        '実行結果が1件を超えている場合
        If 1 <= userCount Then
            Return True
        End If

        Return False

    End Function


    ''' <summary>
    ''' ユーザ名が存在するかどうか?
    ''' </summary>
    ''' 2023/03/02
    Public Shared Function IsExistsUserName(userName As String) As Boolean

        Dim userCount As Long
        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserName", userName)
        })

        'SQL取得
        sql = Constant.GET_USERNAME_COUNT_SQL

        'インスタンス化
        db = New DB()

        '実行結果(件数)を取得
        userCount = db.ExecuteScalar(sql, paramList)

        '件数が1件を超えているか?
        If 1 <= userCount Then
            Return True
        End If

        Return False

    End Function


    ''' <summary>
    ''' ユーザID取得
    ''' </summary>
    ''' 2023/02/27
    Public Shared Function GetUserID(ByVal userName As String,
                                    ByVal password As String) As Long

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserName", userName),
            New SqlParameter("Password", password)
        })

        'SQL取得
        sql = Constant.GET_USERID_SQL

        'インスタンス化
        db = New DB()

        '実行結果を取得
        Using reader = db.ExecuteReader(sql, paramList)
            '読み込める間、繰り返す
            While reader.Read()
                'Long型に変換
                Return Long.Parse(reader(0))
            End While
        End Using

        Return False

    End Function


    ''' <summary>
    ''' 管理者かどうか?
    ''' </summary>
    ''' 2023/02/27
    Public Shared Function IsAdmin(ByVal userID As Long) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("Id", userID)
        })

        'SQL取得
        sql = Constant.GET_ADMIN_SQL

        'インスタンス化
        db = New DB()

        '実行結果を取得
        Using reader = db.ExecuteReader(sql, paramList)
            '読み込める間、繰り返す
            While reader.Read()
                '管理者であれば、True
                If Integer.Parse(reader(0)) = EnumValue.UserType.Admin Then
                    Return True
                End If
            End While
        End Using

        Return False

    End Function


    ''' <summary>
    ''' ユーザ登録
    ''' </summary>
    ''' 2023/02/27
    Public Shared Function RegisterUser(ByVal userName As String,
                                        ByVal password As String) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserName", userName),
            New SqlParameter("Password", password),
            New SqlParameter("Admin", EnumValue.UserType.Normal),
            New SqlParameter("LockFlag", EnumValue.IsLock.NotLock)
        })

        'SQL取得
        sql = Constant.REGISTER_USER_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function


    ''' <summary>
    ''' ユーザ一覧
    ''' </summary>
    ''' 2023/03/01
    Public Shared Function GetUsers() As DataTable

        Dim sql As String
        Dim db As DB

        'SQL取得
        sql = Constant.GET_USERS_SQL

        'インスタンス化
        db = New DB()

        '実行結果(データ)を返却
        Return db.GetDt(sql)

    End Function


    ''' <summary>
    ''' ロックされているユーザ取得
    ''' </summary>
    ''' 2023/03/03
    Public Shared Function GetLockedUsers() As DataTable

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("LockFlag", EnumValue.IsLock.Locked)
        })

        'SQL取得
        sql = Constant.GET_LOCKED_USERS_SQL

        'インスタンス化
        db = New DB()

        '実行結果(データ)を返却
        Return db.GetDt(sql, paramList)

    End Function


    ''' <summary>
    ''' ユーザ削除
    ''' </summary>
    ''' 2023/03/01
    Public Shared Function DeleteUser(ByVal deleteUserID As Long) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("Id", deleteUserID)
        })

        'SQL取得
        sql = Constant.DELETE_USER_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function


    ''' <summary>
    ''' ユーザ情報取得
    ''' </summary>
    ''' 2023/03/01
    Public Shared Function GetUser(ByVal userID As Long) As UserData

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB
        Dim user As UserData

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("Id", userID)
        })

        'SQL取得
        sql = Constant.GET_USER_SQL

        'インスタンス化
        db = New DB()

        'インスタンス化
        user = New UserData

        '実行結果(リーダー)を取得
        Using reader = db.ExecuteReader(sql, paramList)
            '読み込める間、繰り返す
            While reader.Read()

                '設定
                'ユーザ名
                user.UserName = reader(0)
                'パスワード
                user.Password = reader(1)

                Return user

            End While
        End Using

        Return user

    End Function


    ''' <summary>
    ''' ユーザ更新
    ''' </summary>
    ''' 2023/03/01
    Public Shared Function UpdateUser(ByVal userName As String,
                                      ByVal password As String,
                                      ByVal updateUserID As Long) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserName", userName),
            New SqlParameter("Password", password),
            New SqlParameter("Id", updateUserID)
        })

        'SQL取得
        sql = Constant.UPDATE_USER_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function


    ''' <summary>
    ''' 権限更新
    ''' </summary>
    ''' 2023/03/02
    Public Shared Function UpdateAuthority(ByVal updateUserID As Long,
                                        ByVal updateUserType As Long) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("Admin", updateUserType),
            New SqlParameter("Id", updateUserID)
        })

        'SQL取得
        sql = Constant.UPDATE_ADMIN_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function


    ''' <summary>
    ''' ロックされているユーザ名かどうか?
    ''' </summary>
    ''' 2023/02/27
    Public Shared Function IsLockedUserName(ByVal userName As String) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("UserName", userName)
        })

        'SQL取得
        sql = Constant.GET_LOCKFLAG_BY_USERNAME_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        Using reader = db.ExecuteReader(sql, paramList)
            '読み込める間、繰り返す
            While reader.Read()
                'ロックされているかどうか?
                If Integer.Parse(reader(0)) = EnumValue.IsLock.Locked Then
                    Return True
                End If
            End While
        End Using

        Return False

    End Function


    ''' <summary>
    ''' ロック状態更新
    ''' </summary>
    ''' 2023/03/02
    ''' TODO: 変数名改善の余地あり(updateIsLock)
    Public Shared Function UpdateLock(ByVal userName As String,
                                      ByVal updateIsLock As Long) As Boolean

        Dim sql As String
        Dim paramList As List(Of SqlParameter)
        Dim db As DB

        'パラム設定
        paramList = New List(Of SqlParameter)(New SqlParameter() {
            New SqlParameter("LockFlag", updateIsLock),
            New SqlParameter("UserName", userName)
        })

        'SQL取得
        sql = Constant.UPDATE_LOCKFLAG_SQL

        'インスタンス化
        db = New DB()

        'SQL実行
        db.ExecuteNonQuery(sql, paramList)

        Return True

    End Function

End Class
