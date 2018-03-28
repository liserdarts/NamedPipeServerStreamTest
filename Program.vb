Module Program
    Sub Main(args As String())
        If args.Count > 0 Then
            RunAsClient(args(0))
            Return
        End If

        Dim Server As New Listener

        Dim StartInfo As New ProcessStartInfo
        StartInfo.FileName = "dotnet"
        StartInfo.Arguments = String.Format("""{0}"" {1}", Reflection.Assembly.GetExecutingAssembly.Location, Server.PipeName)
        Dim Child = Process.Start(StartInfo)
        Child.WaitForExit

        Server.StopListening

        SyncLock GetType(Console)
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.WriteLine("The background exception(s) can take a second. Don't finish too quickly")
            Console.WriteLine("Press any key to continue")
            Console.ResetColor
        End SyncLock
        Console.ReadKey
    End Sub

    Private Sub RunAsServer()
        Dim Server As New Listener
        Server.StopListening
    End Sub

    Private Sub RunAsClient(PipeName As String)
        Dim Client As New IO.Pipes.NamedPipeClientStream(".", PipeName, IO.Pipes.PipeDirection.Out)
        Client.Connect

        Dim Bytes = Text.Encoding.UTF8.GetBytes("This is a message sent via a named pipe.")
        Client.Write(Bytes, 0, Bytes.Length)
        
        'Slow down to make sure the message gets processed
        Threading.Thread.Sleep(1000)
        
        Client.Dispose
    End Sub
End Module