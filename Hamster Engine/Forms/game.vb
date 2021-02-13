Imports HamsterEngine.Engine
Public Class FrmGame
    Delegate Sub tPrintChat(data As String) '크로스 스레드를 위한 대리자
    Delegate Sub tPrintMemo(data As String) '크로스 스레드를 위한 대리자
    Delegate Sub tGametimeRef() '크로스 스레드를 위한 대리자

    Private Shared GameTimeTimer As New System.Timers.Timer(1024)
    Private Shared PlayerBtn() As Button
    Private Shared VoteBtn() As Button

    Public Shared GameTime As Integer
    Private Shared pmyjob As String
    Private Shared isDay As Boolean
    Private Shared firstday As Boolean = True

    Private Shared skillUse As Integer = -1

    Private Sub FrmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Engine.ProjVersion.GetName + " " + Engine.ProjVersion.GetVersion(True)
        AddHandler GameTimeTimer.Elapsed, AddressOf GameTimeRef
        GameTimeTimer.Start()
        Engine.GameStarted = True
        BoxVote.Enabled = False

        PlayerBtn = {btnP1, btnP2, btnP3, btnP4, btnP5, btnP6, btnP7, btnP8, btnP9, btnP10, btnP11, btnP12}
        VoteBtn = {btnVP1, btnVP2, btnVP3, btnVP4, btnVP5, btnVP6, btnVP7, btnVP8, btnVP9, btnVP10, btnVP11, btnVP12}
    End Sub

    Public Shared Sub GameStart(PlayerAmo As Integer, Myjob As String)
        pmyjob = Myjob
        If Myjob = "MAFIA" Then
            txtjob.Text = "마피아"
        ElseIf Myjob = "CITIZEN" Then
            txtjob.Text = "시민"
        ElseIf Myjob = "MEDIC" Then
            txtjob.Text = "의사"
        ElseIf Myjob = "POLICE" Then
            txtjob.Text = "경찰"
        End If

        PrintMemo("[1일차]")

        Dim i As Integer
        Do While True
            If i > PlayerAmo - 1 Then
                PlayerBtn(i).Enabled = False
                VoteBtn(i).Enabled = False
                PlayerBtn(i).Visible = False
                VoteBtn(i).Visible = False
            Else
                VoteBtn(i).Enabled = True
                PlayerBtn(i).Enabled = True
            End If
            i = i + 1
            If i > UBound(PlayerBtn) Then
                Exit Do
            End If
        Loop
    End Sub

    Public Sub GameTimeRef()
        If txtTime.InvokeRequired Then
            Dim prtdel As tGametimeRef = New tGametimeRef(AddressOf GameTimeRef)
            lstmemo.BeginInvoke(prtdel)
        Else


            If Not GameTime = 0 Then
                GameTime = GameTime - 1


                If GameTime < 59 Then
                    txtTime.Text = GameTime
                Else
                    Dim gameminute As Integer = GameTime / 60
                    txtTime.Text = gameminute & ":" & GameTime Mod 60
                End If

            End If
        End If
    End Sub

    Public Sub ChangeDayNihgt(day As Boolean, days As Integer, time As Integer)
        If day Then
            If Not skillUse = -1 Then
                PrintMemo("<스킬 사용 - " & skillUse & ">")
                skillUse = -1
            End If
            btnchat.Enabled = True
            txtchat.Enabled = True
            PrintMemo("[" & days & "일차]")
            GameTime = time
            btnTimeMinus.Enabled = True
            btnTimePlus.Enabled = True
            isDay = True
            Me.BackColor = Color.WhiteSmoke
            BoxVote.BackColor = Color.WhiteSmoke
            firstday = False
        Else
            GameTime = time
            btnTimeMinus.Enabled = False
            btnTimePlus.Enabled = False
            isDay = False
            Me.BackColor = Color.Gray
            BoxVote.BackColor = Color.Gray
            If Not pmyjob = "MAFIA" Then
                btnchat.Enabled = False
                txtchat.Enabled = False
            End If
        End If
    End Sub

    Public Shared Sub RefVoteResult(data As String())
        Dim i As Integer

        Do While True
            VoteBtn(i).Text = "플레이어" & i + 1 & " - " & data(i + 1) & "표"
            i = i + 1

            If i > UBound(VoteBtn) Then
                Exit Do
            End If
        Loop
    End Sub

    Public Shared Sub DeathPlayer(target As Integer)
        target = target - 1
        My.Computer.Audio.Play(Environment.CurrentDirectory & "\music\death.wav", AudioPlayMode.Background)
        PlayerBtn(target).BackColor = Color.Red
        PlayerBtn(target).Text = PlayerBtn(target).Text & vbCrLf & "사망"
        PlayerBtn(target).Enabled = False
        VoteBtn(target).Visible = False
    End Sub

    Public Shared Sub UseSkill(target As Integer)
        If Not firstday Then
            If Not isDay Then
                If pmyjob = "MAFIA" Then
                    FrmConnect.gameSocket.Send("SKILL" & Project.ParseString & "MAFIA" & Project.ParseString & target, 0)
                    skillUse = target
                ElseIf pmyjob = "MEDIC" Then
                    FrmConnect.gameSocket.Send("SKILL" & Project.ParseString & "MEDIC" & Project.ParseString & target, 0)
                    skillUse = target
                ElseIf pmyjob = "POLICE" Then
                    FrmConnect.gameSocket.Send("SKILL" & Project.ParseString & "POLICE" & Project.ParseString & target, 0)
                    skillUse = target
                End If
            End If
        End If
    End Sub

    Public Shared Sub skillRes(Skillkind As String, targetP As Integer, result As Integer)
        If Skillkind = "POLICE" Then
            If result = 0 Then
                PlayerBtn(targetP).BackColor = Color.Pink
                PlayerBtn(targetP).Text = PlayerBtn(targetP).Text & vbCrLf & "마피아세력"
            ElseIf result = 1 Then
                PlayerBtn(targetP).BackColor = Color.Green
                PlayerBtn(targetP).Text = PlayerBtn(targetP).Text & vbCrLf & "시민세력"
            End If
        End If
    End Sub

    Public Shared Sub GameOver(data As String())
        Dim i As Integer

        Do While True
            PlayerBtn(i).Text = PlayerBtn(i).Text & vbCrLf & data(i + 1)
            i = i + 1

            If i > UBound(data) + 1 Then
                Exit Do
            End If
        Loop

    End Sub

    Public Shared Sub DVoteStart()
        BoxVote.Enabled = True
    End Sub

    Public Shared Sub DVoteEnd()
        BoxVote.Enabled = False
    End Sub

    Public Shared Sub DVote(target As Integer)
        FrmConnect.gameSocket.Send("DVOTERES" & Project.ParseString & target, 0)
        BoxVote.Enabled = False
    End Sub

    Public Sub PrintChat(data As String)
        If lstChat.InvokeRequired Then
            Dim prtdel As tPrintChat = New tPrintChat(AddressOf PrintChat)
            lstChat.BeginInvoke(prtdel, data)
        Else
            lstChat.Items.Add(data)
            lstChat.TopIndex = lstChat.Items.Count - 1
        End If
    End Sub

    Public Shared Sub PrintMemo(data As String)
        If lstmemo.InvokeRequired Then
            Dim prtdel As tPrintMemo = New tPrintMemo(AddressOf PrintMemo)
            lstmemo.BeginInvoke(prtdel, data)
        Else
            lstmemo.Items.Add(data)
            lstmemo.TopIndex = lstChat.Items.Count - 1
        End If
    End Sub

    Private Shared Sub btnTimePlus_Click(sender As Object, e As EventArgs) Handles btnTimePlus.Click
        FrmConnect.gameSocket.Send("TIMEPLUS", 0)
        btnTimePlus.Enabled = False
        btnTimeMinus.Enabled = True
    End Sub

    Private Shared Sub btnTimeMinus_Click(sender As Object, e As EventArgs) Handles btnTimeMinus.Click
        FrmConnect.gameSocket.Send("TIMEMINUS", 0)
        btnTimePlus.Enabled = True
        btnTimeMinus.Enabled = False
    End Sub

    Private Shared Sub btnchat_Click(sender As Object, e As EventArgs) Handles btnchat.Click
        FrmConnect.gameSocket.Send("CHAT" & Project.ParseString & txtchat.Text, 0)
        txtchat.Text = ""
    End Sub

    Private Shared Sub txtchat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtchat.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If Not txtchat.Text = "" Then
                    Call btnchat_Click(Nothing, Nothing)

                End If
            End If
        Catch exp As Exception
            ErrorReporter.ReportError(exp, Words.hName.ModuleName.Console, "txtIn_Keydown")
        End Try
    End Sub

    Private Shared Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        FrmConnect.gameSocket.Send("INFO", 0)
        btnInfo.Text = "서버 응답 대기중"
        btnInfo.BackColor = Color.Yellow
    End Sub

    Private Shared Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        FrmConnect.gameSocket.Send("EXIT", 0)
        System.Threading.Thread.Sleep(1000)
        End
    End Sub

    Private Shared Sub btnPrivateMemo_Click(sender As Object, e As EventArgs) Handles btnPrivateMemo.Click
        If Not txtmemo.Text = "" Then
            PrintMemo(txtmemo.Text)
            txtmemo.Text = ""
        End If
    End Sub

    Private Shared Sub btnPublicmemo_Click(sender As Object, e As EventArgs) Handles btnPublicmemo.Click
        FrmConnect.gameSocket.Send("MEMO" & Project.ParseString & txtmemo.Text, 0)
        txtmemo.Text = ""
    End Sub

    Private Shared Sub btnP1_Click(sender As Object, e As EventArgs) Handles btnP1.Click
        UseSkill(1)
    End Sub

    Private Shared Sub btnP10_Click(sender As Object, e As EventArgs) Handles btnP10.Click
        UseSkill(10)
    End Sub

    Private Shared Sub btnP11_Click(sender As Object, e As EventArgs) Handles btnP11.Click
        UseSkill(11)
    End Sub

    Private Shared Sub btnP12_Click(sender As Object, e As EventArgs) Handles btnP12.Click
        UseSkill(12)
    End Sub

    Private Shared Sub btnP2_Click(sender As Object, e As EventArgs) Handles btnP2.Click
        UseSkill(2)
    End Sub

    Private Shared Sub btnP3_Click(sender As Object, e As EventArgs) Handles btnP3.Click
        UseSkill(3)
    End Sub

    Private Shared Sub btnP4_Click(sender As Object, e As EventArgs) Handles btnP4.Click
        UseSkill(4)
    End Sub

    Private Shared Sub btnP5_Click(sender As Object, e As EventArgs) Handles btnP5.Click
        UseSkill(5)
    End Sub

    Private Shared Sub btnP6_Click(sender As Object, e As EventArgs) Handles btnP6.Click
        UseSkill(6)
    End Sub

    Private Shared Sub btnP7_Click(sender As Object, e As EventArgs) Handles btnP7.Click
        UseSkill(7)
    End Sub

    Private Shared Sub btnP8_Click(sender As Object, e As EventArgs) Handles btnP8.Click
        UseSkill(8)
    End Sub

    Private Shared Sub btnP9_Click(sender As Object, e As EventArgs) Handles btnP9.Click
        UseSkill(9)
    End Sub

    Private Shared Sub btnVNo_Click(sender As Object, e As EventArgs) Handles btnVNo.Click
        DVote(-1)
    End Sub

    Private Shared Sub btnVP1_Click(sender As Object, e As EventArgs) Handles btnVP1.Click
        DVote(1)
    End Sub

    Private Shared Sub btnVP10_Click(sender As Object, e As EventArgs) Handles btnVP10.Click
        DVote(10)
    End Sub

    Private Shared Sub btnVP11_Click(sender As Object, e As EventArgs) Handles btnVP11.Click
        DVote(11)
    End Sub

    Private Shared Sub btnVP12_Click(sender As Object, e As EventArgs) Handles btnVP12.Click
        DVote(12)
    End Sub

    Private Shared Sub btnVP2_Click(sender As Object, e As EventArgs) Handles btnVP2.Click
        DVote(2)
    End Sub

    Private Shared Sub btnVP3_Click(sender As Object, e As EventArgs) Handles btnVP3.Click
        DVote(3)
    End Sub

    Private Shared Sub btnVP4_Click(sender As Object, e As EventArgs) Handles btnVP4.Click
        DVote(4)
    End Sub

    Private Shared Sub btnVP5_Click(sender As Object, e As EventArgs) Handles btnVP5.Click
        DVote(5)
    End Sub

    Private Shared Sub btnVP6_Click(sender As Object, e As EventArgs) Handles btnVP6.Click
        DVote(6)
    End Sub

    Private Shared Sub btnVP7_Click(sender As Object, e As EventArgs) Handles btnVP7.Click
        DVote(7)
    End Sub

    Private Shared Sub btnVP8_Click(sender As Object, e As EventArgs) Handles btnVP8.Click
        DVote(8)
    End Sub

    Private Shared Sub btnVP9_Click(sender As Object, e As EventArgs) Handles btnVP9.Click
        DVote(9)
    End Sub
End Class