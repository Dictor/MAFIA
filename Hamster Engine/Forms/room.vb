Imports HamsterEngine.Engine
Imports HamsterEngine.Words.Project

Public Class FrmRoom

    Delegate Sub tAddListitem(nickname As String, name As String, version As String) '크로스 스레드를 위한 대리자
    Delegate Sub tPrintChat(data As String) '크로스 스레드를 위한 대리자

    Private Shared voteStatus As Boolean = False

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = Engine.ProjVersion.GetName + " " + Engine.ProjVersion.GetVersion(True)
        Me.Hide()
        Engine.MusicThread.Start()
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstPlayer.SelectedIndexChanged

    End Sub

    Public Sub AddListItem(Nickname As String, name As String, Version As String)
        If lstPlayer.InvokeRequired Then
            Dim resdel As tAddListitem = New tAddListitem(AddressOf AddListItem)
            lstPlayer.BeginInvoke(resdel, Nickname, name, Version)
        Else
            Dim additem As New ListViewItem(Nickname)
            additem.SubItems.Add(name)
            additem.SubItems.Add(Version)
            lstPlayer.Items.Add(additem)
        End If
    End Sub

    Private Sub lstChat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstChat.SelectedIndexChanged

    End Sub

    Public Sub PrintChat(data As String)
        If lstPlayer.InvokeRequired Then
            Dim prtdel As tPrintChat = New tPrintChat(AddressOf PrintChat)
            lstPlayer.BeginInvoke(prtdel, data)
        Else
            lstChat.Items.Add(data)
            lstChat.TopIndex = lstChat.Items.Count - 1
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        FrmConnect.gameSocket.Send("CHAT" & ParseString & txtChat.Text, 0)
        txtChat.Text = ""
    End Sub

    Private Sub txtChat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Not txtChat.Text = "" Then
                    Call btnSend_Click(Nothing, Nothing)

                End If
            End If
        Catch exp As Exception
            ErrorReporter.ReportError(exp, Words.hName.ModuleName.Console, "txtIn_Keydown")
        End Try
    End Sub

    Private Sub txtChat_TextChanged(sender As Object, e As EventArgs) Handles txtChat.TextChanged

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        FrmConnect.gameSocket.Send("EXIT", 0)
        System.Threading.Thread.Sleep(1000)
        End
    End Sub

    Private Shared Sub btnServerInfo_Click(sender As Object, e As EventArgs) Handles btnServerInfo.Click
        FrmConnect.gameSocket.Send("INFO", 0)
        btnServerInfo.Text = "서버 응답 대기중"
        btnServerInfo.BackColor = Color.Yellow
    End Sub

    Private Shared Sub btnvote_Click(sender As Object, e As EventArgs) Handles btnvote.Click
        If Not voteStatus Then
            FrmConnect.gameSocket.Send("VOTE", 0)
            voteStatus = True
            btnvote.Text = "투표 취소"
        Else
            FrmConnect.gameSocket.Send("VOTECANCLE", 0)
            voteStatus = False
            btnvote.Text = "게임 시작 투표"
        End If
    End Sub

    Public Shared Sub voteResult(data As String)
        If voteStatus Then
            btnvote.Text = "투표 취소(" & data & ")"
        Else
            btnvote.Text = "게임 시작 투표(" & data & ")"
        End If
    End Sub

End Class