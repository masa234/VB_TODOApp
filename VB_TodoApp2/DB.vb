Imports System.Data.SqlClient
Imports System.Xml

Public Class DB
    Implements IDisposable

    'コネクション
    Private Property con As SqlConnection

    'トランザクション
    Private Property tran As SqlTransaction


    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' 2023/02/23
    Public Sub New()

        'コネクションを開く
        OpenCon(Constant.CONNECTION_STRING)

        'トランザクション開始
        BeginTran()

    End Sub


    ''' <summary>
    ''' コネクションを開く
    ''' </summary>
    ''' 2023/02/23
    Private Sub OpenCon(ByVal conStr As String)

        'コネクションが存在しない場合
        If Me.con Is Nothing Then

            'コネクション作成
            Me.con = New SqlConnection

            '接続文字列を設定する
            Me.con.ConnectionString = conStr

            'コネクションを開く
            Me.con.Open()
        End If

    End Sub


    ''' <summary>
    ''' トランザクション開始
    ''' </summary>
    ''' 2023/02/23
    Private Sub BeginTran()

        'トランザクションが存在しない場合
        If Me.tran Is Nothing Then

            'トランザクション作成
            Me.tran = Me.con.BeginTransaction()

        End If

    End Sub


    ''' <summary>
    ''' コミット
    ''' </summary>
    ''' 2023/02/23
    Private Sub Commit()

        'トランザクションが存在する場合
        If Not Me.tran Is Nothing Then

            'コミット
            Me.tran.Commit()

            '破棄
            Me.tran.Dispose()
        End If
    End Sub


    ''' <summary>
    ''' ロールバック
    ''' </summary>
    ''' 2023/02/23
    Private Sub RollBack()

        'トランザクションが存在する場合
        If Not Me.tran Is Nothing Then

            'ロールバック
            Me.tran.Rollback()

            '破棄
            Me.tran.Dispose()

        End If
    End Sub


    ''' <summary>
    ''' INSERT, UPDATE, DELETE用
    ''' </summary>
    ''' 2023/02/23
    Public Sub ExecuteNonQuery(ByVal sql As String,
                               Optional ByVal paramList As List(Of SqlParameter) = Nothing)

        Try
            'コマンド作成
            Using cmd = New SqlCommand(sql, Me.con, Me.tran)

                'パラム設定
                If Not paramList Is Nothing Then
                    'パラメータ設定
                    cmd.Parameters.AddRange(paramList.ToArray())
                End If

                'SQL実行
                cmd.ExecuteNonQuery()

                'コミット
                Commit()

            End Using

        Catch ex As Exception

            'ロールバック
            RollBack()

            '例外を投げる
            Throw

        End Try

    End Sub


    ''' <summary>
    ''' 実行結果(件数)を取得
    ''' </summary>
    ''' 2023/02/23
    Public Function ExecuteScalar(ByVal sql As String,
                               Optional ByVal paramList As List(Of SqlParameter) = Nothing) As Long

        'コマンド作成
        Using cmd = New SqlCommand(sql, Me.con, Me.tran)

            'パラム設定
            If Not paramList Is Nothing Then
                'パラメータ設定
                cmd.Parameters.AddRange(paramList.ToArray())
            End If

            '実行結果(件数)を返却
            Return Long.Parse(cmd.ExecuteScalar())

        End Using

    End Function


    ''' <summary>
    ''' SELECT用
    ''' </summary>
    ''' 2023/02/24
    Public Function ExecuteReader(ByVal sql As String,
                               Optional ByVal paramList As List(Of SqlParameter) = Nothing) As SqlDataReader

        'コマンド作成
        Using cmd = New SqlCommand(sql, Me.con, Me.tran)

            'パラム設定
            If Not paramList Is Nothing Then
                'パラメータ設定
                cmd.Parameters.AddRange(paramList.ToArray())
            End If

            'リーダーを返却
            Return cmd.ExecuteReader

        End Using

    End Function


    ''' <summary>
    ''' SELECT用
    ''' </summary>
    ''' 2023/02/24
    Public Function GetDt(ByVal sql As String,
                          Optional ByVal paramList As List(Of SqlParameter) = Nothing) As DataTable

        Dim dt As DataTable

        'コマンド作成
        Using cmd = New SqlCommand(sql, Me.con, Me.tran)

            'パラメータが存在する場合
            If Not paramList Is Nothing Then
                'パラメータ設定
                cmd.Parameters.AddRange(paramList.ToArray)
            End If

            'アダプター作成
            Using adapter = New SqlDataAdapter(cmd)

                'データテーブル作成
                dt = New DataTable

                adapter.Fill(dt)

                Return dt

            End Using

        End Using

    End Function


    ''' <summary>
    ''' 全てのオブジェクトを破棄
    ''' </summary>
    ''' 2023/02/24
    Public Sub DisposeAllObject()

        'コネクションが存在する場合
        If Not Me.con Is Nothing Then

            'コネクションが開いている場合
            If Me.con.State = ConnectionState.Connecting Then

                'コネクションを閉じる
                Me.con.Close()

                '破棄
                Me.con = Nothing

            End If

        End If

        'トランザクションが存在する場合
        If Not Me.tran Is Nothing Then

            '破棄
            Me.tran = Nothing

        End If

    End Sub


    ''' <summary>
    ''' デストラクタ
    ''' </summary>
    ''' 2023/02/24
    Protected Overrides Sub Finalize()

        'オブジェクト破棄
        DisposeAllObject()

    End Sub


    '自動生成コード
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: マネージド状態を破棄します (マネージド オブジェクト)
            End If

            ' TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
            ' TODO: 大きなフィールドを null に設定します
            disposedValue = True
        End If
    End Sub

    ' ' TODO: 'Dispose(disposing As Boolean)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
    ' Protected Overrides Sub Finalize()
    '     ' このコードを変更しないでください。クリーンアップ コードを 'Dispose(disposing As Boolean)' メソッドに記述します
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' このコードを変更しないでください。クリーンアップ コードを 'Dispose(disposing As Boolean)' メソッドに記述します
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
