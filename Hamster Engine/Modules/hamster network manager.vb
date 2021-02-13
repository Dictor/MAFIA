Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports HamsterEngine.Engine

Public Class Networkmanager
    Public version As New HamsterVersion("Network Manager", 2, 6, 140801, 0)

    Private Socket As Socket '소켓
    Private clientSoc As Socket '클라이언트 소켓 인스턴스
    Private ClientSocCache(255) As Socket '클라이언트 소켓 버퍼

    Private IPA As IPEndPoint '모듈 공용 ipa

    Private hlistner As Boolean '모듈 공용 상태 변수

    Private ClientAmo As Byte '모듈 공용 클라이언트 연결 제한 갯수

    Private ListenThread As Thread '소켓 리슨용 스레드
    Private ConnectThread As Thread '소켓 연결용 스레드
    Private ConnectAcceptThread As Thread '연결 요청 허가용 스레드(서버)

    Private ClientSocAmount As Integer = 0 '클라이언트 소켓 갯수
    Private databuffer(1024) As Byte  '데이터 버퍼
    Private tdatabuffer(255, 1024) As Byte  '데이터 버퍼
    Private CompleteData As String '데이터 버퍼에서 잉여 문자 처리한 최종 데이터
    Public connectResult As Boolean '접속 성공여부

    Private ListenEventFunc As String
    Private CallListenEvent As Boolean = False





    Public Sub HelpString()
        Console.Print("Console", 0, "-------------Hamster Network Manager 모드 설정 명령어")
        Console.Print("Console", 0, "init 또는 i <IP주소 : 마침표로 구분된 문자열 (서버인 경우  's')> <포트 : 정수> <연결 가능한 최대클라이언트 수 (클라이언트인 경우 'c' 이며 최대값은 'max', 최소값은 'min') : 정수 또는 문자열> - 소켓을 초기화 합니다")
        Console.Print("Console", 0, "connect 또는 c - 초기화된 정보로 연결합니다")
        Console.Print("Console", 0, "listen 또는 l - 초기화된 정보로 대기합니다")
        Console.Print("Console", 0, "shutdown 또는 shdw - 종료합니다")
    End Sub

  


    Public Function Init(ByVal listen As Boolean, ByVal IP As String, ByVal Port As Integer, ByVal CanAcceptClientAmoount As Byte) As HamsterReturn
        Try

            Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            If listen Then
                Dim IPep = New IPEndPoint(IPAddress.Any, Port)
                Socket.Bind(IPep)
                ClientAmo = CanAcceptClientAmoount
                hlistner = listen
                IPA = IPep
                Socket.ReceiveTimeout = 1

                Return New HamsterReturn(True)
            Else
                Dim IPep = New IPEndPoint(IPAddress.Parse(IP), Port)
                'Socket.bind(IPep) //제거시 문제 없으면 이 줄 삭제
                hlistner = listen
                IPA = IPep

                Return New HamsterReturn(True)
            End If
        Catch exp As Exception
            Return New HamsterReturn(False, exp, "General", "초기화중에 오류가 발생했습니다.")
        End Try
    End Function


    Public Function Connect() As HamsterReturn
        Try
            ConnectThread = New Thread(AddressOf tConnect)
            ConnectThread.Start()

            Thread.Sleep(100)

            Return New HamsterReturn(True)

        Catch EX As Exception
            If ConnectThread.ThreadState = ThreadState.Unstarted Or ConnectThread.Equals(Nothing) Then
            Else
                ConnectThread.Abort()
                ConnectThread.Join()
            End If

            Return New HamsterReturn(False, EX, "General", "연결중에 오류가 발생했습니다.")
        Finally
        End Try
    End Function

    Public Function tConnect() As HamsterReturn

        Try
            If hlistner = False Then
                Socket.Connect(IPA)
                connectResult = True
            Else
                connectResult = False
            End If


        Catch ex As NullReferenceException
            connectResult = False
        Catch ex As SocketException
            Console.WarningMsg.Print(2, ex.Message, 10)
            connectResult = False
        Catch exp As Exception
            ErrorReporter.ReportError(exp, "NetworkManager", "Connect")
            connectResult = False
        Finally
            ConnectThread.Abort()
            ConnectThread.Join()
        End Try
    End Function

    Public Function Send(data As String, targetSocketAddress As Integer) As HamsterReturn
        Try
            Dim databuffer() As Byte = Encoding.Default.GetBytes(data)
            Dim i As Integer

            If hlistner Then
                ClientSocCache(targetSocketAddress).Send(databuffer)
                Do While True
                    i = i + 1
                    If i > UBound(databuffer) Then
                        Exit Do
                    End If
                Loop
            Else
                Do While True
                    i = i + 1
                    If i > UBound(databuffer) Then
                        Exit Do
                    End If
                Loop
                Socket.Send(databuffer)
            End If

            Return New HamsterReturn(True)
        Catch ex As NullReferenceException
            Return New HamsterReturn(False, ex, "NullSocket", "소켓이 초기화되지 않았습니다")
        Catch ex As SocketException
            Return New HamsterReturn(False, ex, "SockerError", "전송 시도중에 오류가 발생했습니다")
        Catch exp As Exception
            Return New HamsterReturn(False, exp, "SocketError", "소켓오류가 발생했습니다")
        End Try

    End Function


    Public Overloads Function SetListen() As HamsterReturn
        Try
            ListenThread = New Thread(AddressOf Listen)
            ConnectAcceptThread = New Thread(AddressOf ConnectAcceptListen)

            If hlistner Then
                ConnectAcceptThread.Start()
            End If

            ListenThread.Start()
            Thread.Sleep(100)

            Return New HamsterReturn(True)
        Catch EX As Exception
            ErrorReporter.ReportError(EX, "NetworkManager", "SetListen")
            Return New HamsterReturn(False, EX, "ThreadCreateError", "스레드 생성중 오류가 발생했습니다")

            If ListenThread.ThreadState = ThreadState.Unstarted Or ListenThread.Equals(Nothing) Then
            Else
                ListenThread.Abort()
                ConnectAcceptThread.Abort()
                ListenThread.Join()
                ConnectAcceptThread.Join()
            End If
        Finally
        End Try

    End Function

    Public Overloads Function SetListen(eventfunc As String) As HamsterReturn
        Try
            ListenThread = New Thread(AddressOf Listen)
            ConnectAcceptThread = New Thread(AddressOf ConnectAcceptListen)

            If hlistner Then
                ConnectAcceptThread.Start()
            End If

            CallListenEvent = True
            ListenEventFunc = eventfunc

            ListenThread.Start()
            Thread.Sleep(100)

            Return New HamsterReturn(True)
        Catch EX As Exception
            ErrorReporter.ReportError(EX, "NetworkManager", "SetListen")
            Return New HamsterReturn(False, EX, "ThreadCreateError", "스레드 생성중 오류가 발생했습니다")

            If ListenThread.ThreadState = ThreadState.Unstarted Or ListenThread.Equals(Nothing) Then
            Else
                ListenThread.Abort()
                ConnectAcceptThread.Abort()
                ListenThread.Join()
                ConnectAcceptThread.Join()
            End If
        Finally
        End Try

    End Function



    Private Function Listen() As HamsterReturn
        Dim trycount As ULong
        Dim i As Integer = -1

        Try
            If hlistner Then
                Do While True
                    Try
retry:
                        i = i + 1

                        If i = 255 Then
                            i = 0
                        End If

                        If i = ClientSocAmount Then
                            i = 0
                        End If

                        If Not ClientSocCache(i).Available = 0 Then
                            ClientSocCache(i).Receive(databuffer)
                            CompleteData = Encoding.Default.GetString(databuffer, 0, ReturnWithoutNulldataLength(databuffer))
                            If CallListenEvent Then
                                CallFunction(ListenEventFunc, {CompleteData})
                            End If
                        End If

                    Catch
                    Finally
                        ReDim databuffer(1024)
                    End Try
                Loop

            Else
                Do While True
                    Try
                        If Not (Socket.Receive(databuffer) = 0) Then '
                            CompleteData = Encoding.Default.GetString(databuffer, 0, ReturnWithoutNulldataLength(databuffer))
                        End If
                        ReDim databuffer(1024)
                        If i > 255 Then
                            i = 0
                        End If
                    Catch ex As Exception
                        ErrorReporter.ReportError(ex, "Listen")
                    End Try

                    trycount = trycount + 1
                Loop
            End If
        Catch ex As NullReferenceException
            Return New HamsterReturn(False, ex, "NullSocket", "소켓이 초기화되지 않았습니다")
            Shutdown()
        Catch exp As Exception
            Return New HamsterReturn(False, exp, "ListenError", "대기중에 오류가 발생했습니다")
            ErrorReporter.ReportError(exp, "NetworkManager", "ListenThread\Listen")
        End Try

    End Function



    Private Function ReturnWithoutNulldataLength(data As Byte()) As Integer
        Dim i As Integer = 0
        Dim Datalength As Integer

        Do While True
            If data(i) = 0 Then
                Datalength = i
                Exit Do
            End If

            i = i + 1
        Loop

        Return Datalength
    End Function

    Private Function ConnectAcceptListen() As HamsterReturn
        Try
            Socket.Listen(ClientAmo)
reListen:
            Dim i As Integer
            Do While True
                If hlistner Then
                    clientSoc = Socket.Accept()

                    ClientSocAmount = ClientSocAmount + 1
                    ClientSocCache(ClientSocAmount - 1) = clientSoc
                    ClientSocCache(ClientSocAmount - 1).ReceiveTimeout = 1

                    i = 0

                    Do While True
                        Try
                            Dim clisoc = ClientSocCache(i)
                            i = i + 1

                            If i > ClientSocAmount - 1 Then
                                Exit Do
                            End If
                        Catch ex As NullReferenceException
                            GoTo reListen
                        End Try
                    Loop
                Else
                    Exit Do
                End If
            Loop
        Catch exp As Exception
            Return New HamsterReturn(False, exp, "ListenError", "연결 대기중에 오류가 발생했습니다")
            ErrorReporter.ReportError(exp, "NetworkManager", "ConnectAcceptThread")
        End Try

    End Function

    Public Sub CloseClient(socketnum As Integer)
        ClientSocCache(socketnum).Shutdown(SocketShutdown.Both)
        ClientSocCache(socketnum).Close()
        ClientSocCache(socketnum).Dispose()
    End Sub

    Public Function Shutdown() As HamsterReturn
        Try
            ReDim ClientSocCache(1024)
            If Not Socket.Equals(Nothing) Then
                Socket.Shutdown(SocketShutdown.Both)
                Socket.Close()
            End If

            If Not clientSoc.Equals(Nothing) Then
                Socket.Shutdown(SocketShutdown.Both)
                clientSoc.Close()
            End If

            If ListenThread.ThreadState = ThreadState.Unstarted Or ListenThread.Equals(Nothing) Then
            Else
                ListenThread.Abort()
                ListenThread.Join()
            End If
            Return New HamsterReturn(True)
        Catch ex As NullReferenceException
            Return New HamsterReturn(False, ex, "NullSocket", "소켓이 초기화되지 않았습니다")
        Catch ex As Exception
            'ErrorReporter.ReportError(ex, "NetworkManager", "shutdown")
            Return New HamsterReturn(False, ex, "ShutdownError", "객체를 제거하는중 오류가 발생했습니다")
        Finally


            ' Console.Print("Network", 2, "대기 스레드 해시 : " + ListenThread.GetHashCode.ToString + ", 스레드 상태 : " + ListenThread.ThreadState.ToString)
            'Console.Print("Network", 2, "연결 요청 스레드 해시 : " + ConnectAcceptThread.GetHashCode.ToString + ", 스레드 상태 : " + ConnectAcceptThread.ThreadState.ToString)
        End Try

    End Function


End Class
