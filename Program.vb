Module Program
    Sub Main(args As String())
        Dim Server As New Listener

        Using Client = New IO.Pipes.NamedPipeClientStream(".", Server.PipeName, IO.Pipes.PipeDirection.Out)
            Client.Connect

            Dim Bytes = Text.Encoding.UTF8.GetBytes("This is a message sent via a named pipe.")
            Client.Write(Bytes, 0, Bytes.Length)
        End Using

        Server.StopListening

        'Slow down to make sure the background threads have a chance to finish
        Threading.Thread.Sleep(1000)

#If Debug Then
        If Debugger.IsAttached Then
            Console.WriteLine("Press any key to continue")
            Console.ReadKey
        End If
#End If
    End Sub
End Module