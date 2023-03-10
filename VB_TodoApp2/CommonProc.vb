Imports System.ComponentModel

Public Class CommonProc

    ''' <summary>
    ''' 文字列がおさまっているかどうか?
    ''' </summary>
    ''' 2023/02/27
    Public Shared Function IsFitInText(ByVal str As String,
                                        ByVal maxLength As Long) As Boolean

        '空の場合、False
        If String.IsNullOrEmpty(str) Then
            Return False
        End If

        '文字数オーバーの場合、False
        If maxLength < str.Length Then
            Return False
        End If

        Return True

    End Function


    ''' <summary>
    ''' 入力されているかどうか?
    ''' </summary>
    ''' 2023/03/03
    Public Shared Function IsInputed(ByVal str As String) As Boolean

        '空の場合、False
        If String.IsNullOrEmpty(str) Then
            Return False
        End If

        Return True

    End Function


    ''' <summary>
    ''' 未来日かどうか?
    ''' </summary>
    ''' 2023/03/03
    Public Shared Function IsFuture(ByVal chkDate As Date) As Boolean

        '現在日時を超えていない場合、False
        If chkDate < DateTime.Now Then
            Return False
        End If

        Return True

    End Function


    ''' <summary>
    ''' 画面遷移
    ''' </summary>
    ''' 2023/02/27
    Public Shared Sub HideAndOpen(ByVal openedForm As Form,
                                ByVal openForm As Form)

        '自画面を非表示にする
        openedForm.Hide()

        'フォームを開く
        openForm.Show()

    End Sub


    ''' <summary>
    ''' コンボボックスに値を設定
    ''' </summary>
    ''' 2023/02/27
    Public Shared Sub SetCmb(ByVal cmb As ComboBox,
                            ByVal cmbTxtList As List(Of String))

        'リストの要素数だけ繰り返す
        For Each cmbTxt As String In cmbTxtList
            'コンボボックスに値を設定
            cmb.Items.Add(cmbTxt)
        Next cmbTxt

    End Sub

End Class
