Imports HamsterEngine.Words.Project
Imports HamsterEngine.Engine

Public Class FrmConnect
    Public Shared gameSocket As New Networkmanager '게임용 네트워크 소켓
    Private Shared StatcheckTimer As New System.Timers.Timer(100) 'btnConn 활성화 위한 상황체크 타이머
    Private Shared TimeOutCheckTimer As New System.Timers.Timer(1024) '서버 응답없음 감시를 위한 타이머

    Private Shared TimeOutCheckCounter As Integer = 0 '서버 응답없음 횟수 저장 변수

    Delegate Sub tStatusCHK() '크로스 스레드를 위한 대리자
    Delegate Sub tConnResult(result As Boolean) '크로스 스레드를 위한 대리자
    Delegate Sub tTimeOutCheck() '크로스 스레드를 위한 대리자
    Delegate Sub tHandShake(num As Byte, data As String()) '크로스 스레드를 위한 대리자


    Private Shared Sub IPADDR_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIPaddress.TextChanged
        Dim IPtxt = txtIPaddress.Text
        Dim IPtxtList As Char() = txtIPaddress.Text.ToCharArray

        IPtxt = Replace(IPtxt, ".", "")

        If SearchCharAmount(IPtxtList, ".") > 3 Then
            Console.Print("FrmConnect", 1, "올바른 IP 주소를 입력해주세요!!", "TextChange")
            txtIPaddress.Text = ""
        End If

        If Not IsNumeric(IPtxt) Then
            Console.Print("FrmConnect", 1, "올바른 IP 주소를 입력해주세요!!", "TextChange")
            txtIPaddress.Text = ""
        End If



    End Sub

    Private Shared Sub CheckLength()

    End Sub

    Private Shared Sub btnConn_Click(sender As System.Object, e As System.EventArgs) Handles btnConn.Click
        StatcheckTimer.Stop()

        Dim IPtxtSpilted As String() = txtIPaddress.Text.Split(".")

        If IPtxtSpilted(0) > 254 Or IPtxtSpilted(1) > 254 Or IPtxtSpilted(3) > 254 Or IPtxtSpilted(0) > 254 Then
            Console.Print("FrmConnect", 1, "올바른 IP 주소를 입력해주세요!!", "TextChange")
            txtIPaddress.Text = ""
            Exit Sub
        End If

        btnConn.Text = "리소스 초기화중...."
        Console.Print("FrmConnect", 0, "접속을 위해 리소스를 초기화 하고 있습니다", "Click")

        txtIPaddress.Enabled = False
        txtNickname.Enabled = False
        btnConn.Enabled = False

        Engine.IPAddr = txtIPaddress.Text
        Engine.NickName = txtNickname.Text

        gameSocket.Init(False, IPAddr, 63322, Words.hNetwork.Socket.Client)

        btnConn.Text = "접속 시도중..."
        Console.Print("FrmConnect", 0, "초기화 완료, 서버에 연결을 시도합니다", "Click")

        gameSocket.Connect()
    End Sub

    Private Sub StatusCHK()
        If btnConn.InvokeRequired Then
            Dim chkdel As tStatusCHK = New tStatusCHK(AddressOf StatusCHK)
            btnConn.BeginInvoke(chkdel)
        Else
            If SearchCharAmount(txtIPaddress.Text.ToCharArray, ".") = 3 And txtNickname.TextLength > 0 Then
                btnConn.Enabled = True
            Else
                btnConn.Enabled = False
            End If
        End If
    End Sub

    Public Shared Sub ConnResult(result As Boolean)
        If btnConn.InvokeRequired Then
            Dim resdel As tConnResult = New tConnResult(AddressOf ConnResult)
            btnConn.BeginInvoke(resdel, result)
        Else

            If Not result Then
                recoveryObjState("접속에 실패했습니다!(재시도)")
            Else
                btnConn.Text = "접속성공! 핸드셰이크 시작"
                gameSocket.SetListen()

                TimeOutCheckCounter = 20

                AddHandler TimeOutCheckTimer.Elapsed, AddressOf TimeOutCheck
                TimeOutCheckTimer.Start()

                gameSocket.Send("JOIN" & ParseString & NickName & ParseString & ProjVersion.GetName & ParseString & ProjVersion.GetVersion(True), 0)
            End If

        End If


    End Sub

    Public Shared Sub ListenEvent(data As String)
        data = data.Replace(ParseString, "๑")
        Dim recieveData = data.Split("๑")
        Console.Print("FrmConnect", 2, "치환한 데이터 : " & data, "ListenEvent")
        Console.Print("FrmConnect", 2, "파싱한 데이터 배열 최대 첨자 : " & UBound(recieveData), "ListenEvent")
        'Console.Printarrange("FrmConnect", 2, recieveData, "ListenEvent", "파싱된 데이터 : ")
        If recieveData(0) = "JOINOK" Or recieveData(0) = "JOINFAIL" Then '초기 접속
            HandShake(0, recieveData)
        ElseIf recieveData(0) = "REFPLAYER" Or recieveData(0) = "REFVERSION" Or recieveData(0) = "REFCLINAME" Then '대기방 정보 갱신
            HandShake(1, recieveData)
        ElseIf recieveData(0) = "CHAT" Then
            HandShake(2, recieveData)
        ElseIf recieveData(0) = "INFO" Then
            HandShake(3, recieveData)
        ElseIf recieveData(0) = "VOTERES" Then
            HandShake(4, recieveData)
        ElseIf recieveData(0) = "GAMESTART" Then
            HandShake(5, recieveData)
        ElseIf recieveData(0) = "NIGHT" Then
            HandShake(6, recieveData)
        ElseIf recieveData(0) = "DAY" Then
            HandShake(7, recieveData)
        ElseIf recieveData(0) = "TIMEREF" Then
            HandShake(8, recieveData)
        ElseIf recieveData(0) = "STARTDVOTE" Then
            HandShake(9, recieveData)
        ElseIf recieveData(0) = "ENDDVOTE" Then
            HandShake(10, recieveData)
        ElseIf recieveData(0) = "MEMO" Then
            HandShake(11, recieveData)
        ElseIf recieveData(0) = "DEATH" Then
            HandShake(12, recieveData)
        ElseIf recieveData(0) = "DVOTEREF" Then
            HandShake(13, recieveData)
        ElseIf recieveData(0) = "SKILLRES" Then
            HandShake(14, recieveData)
        ElseIf recieveData(0) = "GAMEOVER" Then
            HandShake(15, recieveData)
        ElseIf recieveData(0) = "MSG" Then
            HandShake(16, recieveData)
        ElseIf recieveData(0) = "KICK" Then
            FrmGame.Close()
            FrmRoom.Close()
            FrmConnect.Show()
            MsgBox("서버에서 강퇴당했습니다")
        End If
    End Sub

    

    Public Shared Sub HandShake(processNum As Byte, data As String())
        Static Dim rNickname As String(), rVersion As String(), rClientName As String() 'REF 명령어에 대한 데이터 저장 배열 
        Static Dim rRefreshCounter As Byte = 0 '이변수가 3이되면 LISTVIEW에 아이템 추가

        Try

            If btnConn.InvokeRequired Then
                Dim resdel As tHandShake = New tHandShake(AddressOf HandShake)
                btnConn.BeginInvoke(resdel, processNum, data)
            Else
                If processNum = 0 Then
                    If data(0) = "JOINOK" Then
                        Console.Print("FrmConnect", 0, "서버로부터 접속허가를 받았습니다. 정보 수신을 대기하고 있습니다", "HandShake")
                        btnConn.Text = "정보 수신 대기중"
                        FrmRoom.Show()
                        FrmConnect.Hide()

                        TimeOutCheckCounter = 20 '타임아웃 카운터 끝나면 작업 취소
                        TimeOutCheckTimer.Start()

                    ElseIf data(0) = "JOINFAIL" Then
                        If data(1) = "GAMEALREADYSTARTED" Then '게임이 이미 시작됨
                            recoveryObjState("게임이 이미 시작됨(재시도)")
                        ElseIf data(1) = "REJECTBYHOST" Then '서버에 의해 거부됨
                            recoveryObjState("서버가 접속 거부(재시도)")
                        ElseIf data(1) = "OVERPLAYER" Then '플레이어 공간이 없음
                            recoveryObjState("플레이어 공간X(재시도)")
                        ElseIf data(1) = "INTERNALSERVERERR" Then '내부 서버 오류
                            recoveryObjState("서버 내부 오류(재시도)")
                        End If

                    End If

                ElseIf processNum = 1 Then
                    If data(0) = "REFPLAYER" Then
                        ReDim Preserve rNickname(UBound(data))
                        rNickname = data
                        rRefreshCounter = rRefreshCounter + 1
                    ElseIf data(0) = "REFVERSION" Then
                        ReDim Preserve rVersion(UBound(data))
                        rVersion = data
                        rRefreshCounter = rRefreshCounter + 1
                    ElseIf data(0) = "REFCLINAME" Then
                        ReDim Preserve rNickname(UBound(data))
                        rClientName = data
                        rRefreshCounter = rRefreshCounter + 1
                    End If

                    If rRefreshCounter = 3 Then
                        rRefreshCounter = 0
                        Dim i = 1
                        FrmRoom.lstPlayer.Items.Clear()
                        Do While True
                            If i > UBound(rNickname) Then
                                FrmRoom.Show()
                                FrmConnect.Hide()
                                Exit Do

                            End If


                            FrmRoom.AddListItem(rNickname(i), rClientName(i), rVersion(i))
                            Console.Print("FrmConnect", 0, "배열주소 : " & i & " / 서버로 부터 송신받은 내용 : " & " /닉네임 : " & rNickname(i) & " /클라 이름 : " & rClientName(i) & " /클라 버젼 : " & rVersion(i))

                            If i >= UBound(rNickname) + 1 Then
                                FrmRoom.Show()
                                Exit Do
                            End If


                            i = i + 1
                        Loop
                    End If
                ElseIf processNum = 2 Then
                    If GameStarted Then
                        FrmGame.PrintChat(data(1))
                    Else
                        FrmRoom.PrintChat(data(1))
                    End If
                ElseIf processNum = 3 Then
                    If Not GameStarted Then
                        FrmRoom.btnServerInfo.Text = "서버 정보"
                        FrmRoom.btnServerInfo.BackColor = System.Drawing.SystemColors.Control
                        MsgBox(data(1), MsgBoxStyle.OkOnly, "서버 정보")
                    Else
                        FrmGame.btnInfo.Text = "서버 정보"
                        FrmGame.btnInfo.BackColor = System.Drawing.SystemColors.Control
                        MsgBox(data(1), MsgBoxStyle.OkOnly, "서버 정보")
                    End If
                    
                ElseIf processNum = 4 Then
                    FrmRoom.voteResult(data(1))
                ElseIf processNum = 5 Then
                    FrmRoom.Close()
                    FrmGame.Show()
                    FrmGame.GameStart(data(2), data(1))
                ElseIf processNum = 6 Then
                    FrmGame.ChangeDayNihgt(False, data(1), data(2))
                ElseIf processNum = 7 Then
                    FrmGame.ChangeDayNihgt(True, data(1), data(2))
                ElseIf processNum = 8 Then
                    FrmGame.GameTime = data(1)
                ElseIf processNum = 9 Then
                    FrmGame.DVoteStart()
                ElseIf processNum = 10 Then
                    FrmGame.DVoteEnd()
                ElseIf processNum = 11 Then
                    FrmGame.PrintMemo(data(1))
                ElseIf processNum = 12 Then
                    FrmGame.DeathPlayer(data(1))
                ElseIf processNum = 13 Then
                    FrmGame.RefVoteResult(data)
                ElseIf processNum = 14 Then
                    FrmGame.skillRes(data(1), data(2), data(3))
                ElseIf processNum = 15 Then
                    FrmGame.GameOver(data)
                ElseIf processNum = 16 Then
                    MsgBox(data(1), , "서버의 메세지")
                End If


            End If
        Catch ex As Exception
            ErrorReporter.ReportError(ex, "FrmConnect", "HandShake")
        End Try
    End Sub

    Private Shared Sub TimeOutCheck()
        If btnConn.InvokeRequired Then
            Dim chkdel As tTimeOutCheck = New tTimeOutCheck(AddressOf TimeOutCheck)
            btnConn.BeginInvoke(chkdel)
            'MsgBox(TimeOutCheckCounter)
        Else

            If TimeOutCheckCounter < 1 Then
                recoveryObjState("서버 응답 없음!(재시도)")
                TimeOutCheckTimer.Stop()
                Exit Sub
            Else
                TimeOutCheckCounter = TimeOutCheckCounter - 1
            End If


            btnConn.Text = "서버 응답 대기중..." & TimeOutCheckCounter
        End If
    End Sub

    Private Shared Function SearchCharAmount(sourceList As Char(), searchChar As Char) As Integer
        Dim i, amount As Integer

        Do While True
            If i > sourceList.Length - 1 Then Return amount

            If sourceList(i) = searchChar Then
                amount = amount + 1
            End If
            'Console.Print("FrmConnect", 2, "길이 : " & sourceList.Length & ", i : " & i & ",amount : " & amount, "SearchCharAmount")
            i = i + 1
        Loop

    End Function

    Private Shared Sub recoveryObjState(text As String)
        btnConn.Text = text
        TimeOutCheckTimer.Stop()
        TimeOutCheckCounter = 20
        txtIPaddress.Enabled = True
        txtNickname.Enabled = True
        btnConn.Enabled = True
        StatcheckTimer.Start()
    End Sub

    Private Sub FrmConnect_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler StatcheckTimer.Elapsed, AddressOf StatusCHK
        StatcheckTimer.Enabled = True
        Me.Text = Engine.ProjVersion.GetName + " " + Engine.ProjVersion.GetVersion(True)
    End Sub

    Private Sub btnEND_Click(sender As System.Object, e As System.EventArgs) Handles btnEND.Click
        Engine.shutdown()
    End Sub
End Class