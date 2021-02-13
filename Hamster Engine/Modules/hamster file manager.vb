Imports System.Text
Imports System.IO
Imports System.IO.Directory
Imports System.IO.DirectoryInfo
Imports System.Security
Imports HamsterEngine.Engine

Module Filemanager
    Public Version As New HamsterVersion("File Manager", 1, 0, 119, 0)

    Public Class File
        Public Shared Sub HelpString()
            Console.Print("Console", 0, "-------------Hamster File Manager 모드 설정 명령어")
            Console.Print("Console", 0, "접근을 위한 첫 명령어는 file 입니다")
            Console.Print("Console", 0, "file, help 또는 h - 도움말")
            Console.Print("Console", 0, "read <경로:문자열> 또는 r <경로:문자열> - VFM 형식의 파일을 읽습니다")
            Console.Print("Console", 0, "read <경로:문자열> 또는 r <경로:문자열> - VFM 형식의 파일을 읽습니다")
            Console.Print("Console", 0, "check <경로:문자열> 또는 c <경로:문자열> - 파일의 존재유무를 확인합니다")
            Console.Print("Console", 0, "created <경로:문자열> 또는 crd <경로:문자열> - 디렉터리를 생성합니다")
            Console.Print("Console", 0, "deleted <경로:문자열> <하위 디렉터리 삭제:True 또는 False> 또는 ded <경로:문자열> <하위 디렉터리 삭제:True 또는 False> - 디렉터리를 삭제합니다")
            Console.Print("Console", 0, "getcreatedtimed <경로:문자열> <UTC 시간 반환 여부:True 또는 False> 또는 gctd <경로:문자열> <UTC 시간 반환 여부:True 또는 False> - 디렉터리의 생성시간을 반환합니다")
            Console.Print("Console", 0, "getdirectories <경로:문자열> 또는 gdrt <경로:문자열> - 하위 디렉터리를 반환합니다")
            Console.Print("Console", 0, "getfiles <경로:문자열> 또는 gfls <경로:문자열> - 경로 디렉터리의 하위 파일을 반환합니다")
            Console.Print("Console", 0, "getentries <경로:문자열> 또는 gent <경로:문자열> - 경로 디렉터리의 하위 파일과 디렉터리를 반환합니다")
            Console.Print("Console", 0, "getparentdirectory <경로:문자열> 또는 gpdt <경로:문자열> - 경로 디렉터리의 부모 디렉터리를 반환합니다")
            Console.Print("Console", 0, "movedirectory <이동할 경로:문자열> <목적지 경로:문자열> 또는 m <이동할 경로:문자열> <목적지 경로:문자열> - 이동할 경로 인수의 디렉터리를 목적지 경로 인수의 디렉터리로 이동합니다")
        End Sub

        Public Shared Function Delete(path As String)
            My.Computer.FileSystem.DeleteFile(path)
        End Function

        Public Shared Function Check(path As String, log As Boolean)
            If Not log Then
                Console.Print("HFM", 2, path & " 의 유무를 점검합니다")
            End If
            If Not System.IO.File.Exists(path) Then
                Console.Print("HFM", 2, "파일을 찾을수 없습니다")
                Return False
                Exit Function
            Else
                Console.Print("HFM", 2, "파일이 존재 합니다")
                Return True
                Exit Function
            End If
        End Function


        Public Shared Function Readtext(filename As String)

            Dim data = My.Computer.FileSystem.ReadAllText(filename, Encoding.UTF8)
            Return data
          
        End Function

        Public Shared Function writetext(path As String, data As String, overwrite As Boolean, log As Boolean)

            If Not log Then
                Console.Print("HFM", 2, "텍스트 파일을 씁니다, 경로 : " & path & " 덮어쓰기 : " & overwrite & " 내용 : " & data)
            End If

            My.Computer.FileSystem.WriteAllText(path, vbCrLf & data, overwrite, System.Text.Encoding.UTF8)
            
        End Function

        Public Class Directory

            Public Shared Function Create(path As String)

                Console.Print("HFM", 2, path & " 디렉터리를 생성합니다")
                    System.IO.Directory.CreateDirectory(path)
                Console.Print("HFM", 2, path & " 디렉터리가 생성됬습니다")
            End Function

            Public Shared Function Delete(path As String, deletechild As Boolean)
                Console.Print("HFM", 2, path & " 디렉터리를 삭제합니다")

                System.IO.Directory.Delete(path, deletechild)
             
                Console.Print("HFM", 2, path & " 디렉터리가 삭제됬습니다")
            End Function

            Public Shared Function Check(path As String)
                Console.Print("HFM", 2, path & " 디렉터리가 존재하는지 검사합니다")
                Dim exist As Boolean
                exist = System.IO.Directory.Exists(path)

                If exist = True Then
                    Console.Print("HFM", 1, path & " 디렉터리가 존재합니다")
                    Return True
                ElseIf exist = False Then
                    Console.Print("HFM", 1, path & " 디렉터리가 존재하지 않습니다")
                    Return False
                Else
                    Console.Print("HFM", 1, path & " 디렉터리 검사에 따른 반환값이 올바르지 않습니다, 정의되지 않은 오류입니다")
                    Return 0
                End If
            End Function

            Public Shared Function GetCreatedTime(path As String, utc As Boolean)
                Dim createdtime As New Date

                Console.Print("HFM", 2, path & " 디렉터리가 만들어진 시간을 반환합니다")
                    If utc = False Then
                        createdtime = System.IO.Directory.GetCreationTime(path)
                        Console.Print("HFM", 2, "시간을 UTC 시간이 아닌 현지시간(컴퓨터 시간)으로 반환합니다")
                    ElseIf utc = True Then
                        createdtime = System.IO.Directory.GetCreationTimeUtc(path)
                        Console.Print("HFM", 2, "시간을 UTC 시간으로 반환합니다")
                    Else
                        Console.Print("HFM", 1, "UTC 인수값이 올바르지 않습니다, 정보는 반환되지 않았습니다")
                        Return 3
                        Exit Function
                    End If

                Console.Print("HFM", 2, path & " 디렉터리가 만들어진 시간은 " & createdtime & " 입니다")
                Return createdtime
            End Function

            Public Shared Function GetChildDirectories(path As String)
                Dim directory As String()
                Console.Print("HFM", 2, path & " 경로인수의 모든 하위 디렉터리 이름을 반환합니다.")

                directory = System.IO.Directory.GetDirectories(path)

                Console.Print("HFM", 3, UBound(directory) & "개의 항목을 찾았습니다")
                Console.Printarrange("HFM", 3, directory)
                Console.Print("HFM", 2, path & " 의 하위디렉터리 정보가 반환되었습니다")



                Return directory
            End Function

            Public Shared Function GetChildFiles(path As String)
                Dim directory As String()
                Console.Print("HFM", 2, path & " 경로인수 디렉터리의 모든 하위 파일 이름을 반환합니다.")
                    directory = System.IO.Directory.GetFiles(path)
               
                Console.Print("HFM", 2, UBound(directory) & "개의 항목을 찾았습니다")
                Console.Printarrange("HFM", 2, directory)
                Console.Print("HFM", 2, path & " 디렉터리의 하위 파일 정보가 반환되었습니다")



                Return directory
            End Function

            Public Shared Function GetEntries(path As String)
                Dim directory As String()
                Console.Print("HFM", 2, path & " 경로인수 디렉터리의 모든 하위 파일과 디렉터리 이름을 반환합니다.")

                    directory = System.IO.Directory.GetFileSystemEntries(path)
               
                Console.Print("HFM", 3, UBound(directory) & "개의 항목을 찾았습니다")
                Console.Printarrange("HFM", 3, directory)
                Console.Print("HFM", 2, path & " 디렉터리의 하위 파일과 디렉터리 정보가 반환되었습니다")

                Return directory
            End Function

            Public Shared Function GetParentDirectory(path As String)
                Dim directory As System.IO.DirectoryInfo
                Console.Print("2", False, path & " 디렉터리의 부모 디렉터리를 반환합니다")


                directory = System.IO.Directory.GetParent(path)
               
                Console.Print("HFM", 3, path & "의 부모 디렉터리는 " & directory.FullName & " 입니다")
                Console.Print("HFM", 2, path & " 디렉터리의 부모 디렉터리를 반환했습니다")

                Return directory.FullName
            End Function

            Public Shared Function Move(sourcepath As String, destpath As String)
                Console.Print("HFM", 2, sourcepath & " 디렉터리를 " & destpath & " 디렉터리로 이동합니다")


                System.IO.Directory.Move(sourcepath, destpath)
                Console.Print("HFM", 2, sourcepath & " 디렉터리를 성공적으로 " & destpath & " 로 이동했습니다")


            End Function
        End Class
    End Class

End Module
