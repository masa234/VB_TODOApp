Public Class Constant

    'メッセージ
    Public Const USER_IS_ADMIN = "既に管理者権限を保有しています。"
    Public Const USER_IS_NORMAL = "既に一般ユーザです。"
    Public Const USER_IS_LOCKED = "アカウントがロックされています。管理者に問い合わせてください。"
    Public Const USER_IS_LOCK = "アカウントがロックされました。管理者に問い合わせてください。"
    'バリデーションメッセージ
    Public Const INVALID_USERNAME_LENGTH = "ユーザ名は1～255文字以内で指定してください。"
    Public Const INVALID_PASSWORD_LENGTH = "パスワードは1～255文字以内で指定してください。"
    Public Const INVALID_TASKNAME_LENGTH = "タスク名は1～255文字以内で指定してください。"
    Public Const INVALID_DETAIL_LENGTH = "詳細は1～255文字以内で指定してください。"
    Public Const INVALID_COMMENT_LENGTH = "コメントは1～255文字以内で指定してください。"
    Public Const EXPIREDDATE_MUST_INPUT = "有効期限を入力してください。"
    Public Const PRIORITY_MUST_INPUT = "優先度を入力してください。"
    Public Const EXPIREDDATE_MUST_FUTURE = "有効期限は未来日でなければいけません。"
    '失敗メッセージ
    Public Const FAILED_LOGIN = "ログインに失敗しました。"
    Public Const FAILED_REGISTER_USER = "ユーザ登録に失敗しました。"
    Public Const FAILED_DELETE_USER = "ユーザ削除に失敗しました。"
    Public Const FAILED_UPDATE_USER = "ユーザ更新に失敗しました。"
    Public Const FAILED_UPDATE_AUTHORITY = "権限更新に失敗しました。"
    Public Const FAILED_RELEASE_LOCK = "ロック解除に失敗しました。"
    Public Const FAILED_INSERT_TASK = "タスク登録に失敗しました。"
    Public Const FAILED_DELETE_TASK = "タスク削除に失敗しました。"
    Public Const FAILED_UPDATE_TASK = "タスク更新に失敗しました。"
    Public Const FAILED_OUTPUT_CSV = "CSV出力に失敗しました。"
    '成功メッセージ
    Public Const SUCCESS_REGISTER_USER = "ユーザ登録に成功しました。"
    Public Const SUCCESS_UPDATE_USER = "ユーザ更新に成功しました。"
    Public Const SUCCESS_UPDATE_AUTHORITY = "権限更新に成功しました。"
    Public Const SUCCESS_RELEASE_LOCK = "ロック解除に成功しました。"
    Public Const SUCCESS_INSERT_TASK = "タスク登録に成功しました。"
    Public Const SUCCESS_DELETE_TASK = "タスク削除に成功しました。"
    Public Const SUCCESS_UPDATE_TASK = "タスク更新に成功しました。"
    Public Const SUCCESS_OUTPUT_CSV = "CSV出力に成功しました。"
    '接続文字列
    Public Const CONNECTION_STRING = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=testdb3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
    'メッセージタイトル
    Public Const WARNING = "警告"
    Public Const CONFIRM = "確認"
    '最大文字数
    Public Const USERNAME_MAX_LENGTH = 255
    Public Const PASSWORD_MAX_LENGTH = 255
    Public Const TASKNAME_MAX_LENGTH = 255
    Public Const DETAIL_MAX_LENGTH = 255
    Public Const COMMENT_MAX_LENGTH = 255
    'その他
    Public Const LOCK_COUNT = 3
    Public Const OUTPUT_CSV_PATH = "C:\Users\PC01\Desktop"
    'SQL
    Public Const GET_USER_COUNT_SQL = "SELECT " &
                                     "  COUNT(*) " &
                                     "FROM " &
                                     "  Users " &
                                     "WHERE " &
                                     "  UserName = " &
                                     "  @UserName " &
                                     "AND " &
                                     "  Password = " &
                                     "  @Password "
    Public Const GET_USERNAME_COUNT_SQL = "SELECT " &
                                        "    COUNT(*) " &
                                        "  FROM " &
                                        "    Users " &
                                        "  WHERE " &
                                        "    UserName = @UserName "
    Public Const GET_USERID_SQL = "  SELECT " &
                                    "  Id " &
                                    "FROM " &
                                    "  Users " &
                                    "WHERE " &
                                    "  UserName = @UserName " &
                                    "AND " &
                                    "  Password = @Password "
    Public Const GET_ADMIN_SQL = "SELECT " &
                                "   Admin " &
                                " FROM " &
                                "   Users " &
                                " WHERE " &
                                "   Id = @Id "
    'TODO: 変数名が長い
    Public Const GET_LOCKFLAG_BY_USERNAME_SQL = "SELECT " &
                                                "  LockFlag " &
                                                "FROM " &
                                                "  Users " &
                                                "WHERE " &
                                                "  UserName = @UserName "
    Public Const GET_USERS_SQL = "SELECT " &
                                "   Id, " &
                                "   UserName, " &
                                "   Password " &
                                " FROM " &
                                "   Users " &
                                " ORDER BY " &
                                "   Id ASC "
    Public Const GET_LOCKED_USERS_SQL = "SELECT " &
                                        "   Id, " &
                                        "   UserName, " &
                                        "   Password " &
                                        " FROM " &
                                        "   Users " &
                                        " WHERE " &
                                        "   LockFlag = @LockFlag " &
                                        " ORDER BY " &
                                        "   Id ASC "
    Public Const REGISTER_USER_SQL = "INSERT " &
                                    "   INTO " &
                                    " Users " &
                                    "   (UserName, " &
                                    "   Password, " &
                                    "   Admin, " &
                                    "   LockFlag) " &
                                    " VALUES" &
                                    "   (@UserName, " &
                                    "   @Password, " &
                                    "   @Admin, " &
                                    "   @LockFlag) "
    Public Const DELETE_USER_SQL = " DELETE " &
                                    "FROM " &
                                    "  Users " &
                                    "WHERE " &
                                    "  Id = @Id "
    Public Const UPDATE_USER_SQL = " UPDATE " &
                                    "  Users " &
                                    "SET " &
                                    "  UserName = @UserName, " &
                                    "  Password = @Password " &
                                    "WHERE " &
                                    "  Id = @Id "
    Public Const UPDATE_ADMIN_SQL = "UPDATE " &
                                    "  Users " &
                                    "SET " &
                                    "  Admin = @Admin " &
                                    "WHERE " &
                                    "  Id = @Id "
    Public Const UPDATE_LOCKFLAG_SQL = "UPDATE " &
                                    "     Users " &
                                    "   SET " &
                                    "     LockFlag = @LockFlag " &
                                    "   WHERE " &
                                    "     UserName = @UserName "
    Public Const GET_USER_SQL = "SELECT " &
                                "  UserName, " &
                                "  Password " &
                                "FROM " &
                                "  Users " &
                                "WHERE " &
                                "  Id = @Id "
    Public Const INSERT_TASK_SQL = "  INSERT " &
                                    "   INTO " &
                                    " Tasks " &
                                    "   (TaskName, " &
                                    "   ExpiredDate, " &
                                    "   Priority, " &
                                    "   Detail, " &
                                    "   Comment, " &
                                    "   UserId) " &
                                    " VALUES" &
                                    "   (@TaskName, " &
                                    "   @ExpiredDate, " &
                                    "   @Priority, " &
                                    "   @Detail, " &
                                    "   @Comment, " &
                                    "   @UserId) "
    Public Const GET_USER_TASKS_SQL = " SELECT " &
                                    "     Id, " &
                                    "     TaskName, " &
                                    "     ExpiredDate, " &
                                    "     Priority, " &
                                    "     Detail, " &
                                    "     Comment, " &
                                    "     UserId " &
                                    "   FROM " &
                                    "     Tasks " &
                                    "   WHERE " &
                                    "     UserId = @UserId "

    Public Const DELETE_TASK_SQL = " DELETE " &
                                    "FROM " &
                                    "  Tasks " &
                                    "WHERE " &
                                    "  Id = @Id "
    Public Const GET_TASK_SQL = " SELECT " &
                                "   Id, " &
                                "   TaskName, " &
                                "   ExpiredDate, " &
                                "   Priority, " &
                                "   Detail, " &
                                "   Comment, " &
                                "   UserId " &
                                " FROM " &
                                "   Tasks " &
                                " WHERE " &
                                "   Id = @Id "
    Public Const UPDATE_TASK_SQL = " UPDATE " &
                                    "  Tasks " &
                                    "SET " &
                                    "  TaskName = @TaskName, " &
                                    "  ExpiredDate = @ExpiredDate, " &
                                    "  Priority = @Priority, " &
                                    "  Detail = @Detail, " &
                                    "  Comment = @Comment, " &
                                    "  UserId = @UserId " &
                                    "WHERE " &
                                    "  Id = @Id "
    Public Const GET_SEARCH_COUNT_SQL = " SELECT " &
                                        "   COUNT(*) " &
                                        " FROM " &
                                        "   Tasks " &
                                        " WHERE " &
                                        "   UserId = @UserId " &
                                        " AND " &
                                        "   TaskName Like @TaskName "
    Public Const SEARCH_TASK_SQL = " SELECT " &
                                    "  Id, " &
                                    "  TaskName, " &
                                    "  ExpiredDate, " &
                                    "  Priority, " &
                                    "  Detail, " &
                                    "  Comment, " &
                                    "  UserId " &
                                    " FROM " &
                                    "  Tasks " &
                                    " WHERE " &
                                    "  UserId = @UserId " &
                                    " AND " &
                                    "  TaskName Like @TaskName "

End Class
