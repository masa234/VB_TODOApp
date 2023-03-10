Public Class OtherProc

    ''' <summary>
    ''' 優先度のリストを取得
    ''' </summary>
    ''' 2023/03/03
    Public Shared Function GetPriorityList() As List(Of String)

        Dim priorityList As List(Of String)

        'リストを作成
        priorityList = New List(Of String)

        '設定
        'TODO :もっと良い書き方があるかもしれない
        With priorityList
            .Add("高")
            .Add("中")
            .Add("低")
        End With

        Return priorityList

    End Function


    ''' <summary>
    ''' 優先度をint型に変換
    ''' </summary>
    ''' 2023/03/06
    Public Shared Function PriorityToInt(ByVal strPriority As String) As Integer

        '値によって設定
        Select Case strPriority
            Case "高"
                Return EnumValue.Priority.High
            Case "中"
                Return EnumValue.Priority.Middle
            Case "低"
                Return EnumValue.Priority.Low
        End Select

        Return 0

    End Function


    ''' <summary>
    ''' 優先度をstring型に変換
    ''' </summary>
    ''' 2023/03/06
    Public Shared Function PriorityToString(ByVal intPriority As Integer) As String

        '値によって設定
        Select Case intPriority
            Case EnumValue.Priority.High
                Return "高"
            Case EnumValue.Priority.Middle
                Return "中"
            Case EnumValue.Priority.Low
                Return "低"
        End Select

        Return String.Empty

    End Function

End Class
