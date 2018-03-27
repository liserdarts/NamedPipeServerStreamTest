Public Class Listener
    Dim Listen As Boolean
    Public PipeName As String
    Dim ConnectedEventHandler As New Threading.ManualResetEvent(False)
    Dim Pipe As IO.Pipes.NamedPipeServerStream

    Public Sub New()
        StartListening
    End Sub

    Public Sub StartListening()
        If Listen Then Return
        Listen = True

        PipeName = IO.Path.GetRandomFileName
        Pipe = New IO.Pipes.NamedPipeServerStream(PipeName, IO.Pipes.PipeDirection.In)

        Dim Thread As New Threading.Thread(AddressOf ListenLoop)
        Thread.Name = String.Format("Named pipe listener {0}", PipeName)
        Thread.IsBackground = True
        Thread.Start
    End Sub

    Public Sub StopListening()
        Listen = False

        If Pipe IsNot Nothing Then
            Console.WriteLine("Calling NamedPipeServerStream.Dispose")
            Pipe.Dispose
        End If

        'End the listening thread
        ConnectedEventHandler.Set
    End Sub

    Private Sub ListenLoop()
        ConnectedEventHandler.Set
        Do
            If ConnectedEventHandler.WaitOne Then
                ConnectedEventHandler.Reset
                Console.WriteLine("BeginWaitForConnection")
                Pipe.BeginWaitForConnection(AddressOf HandleConnection, Pipe)
            End If
        Loop Until Not Listen

        Console.WriteLine("Exiting loop")
    End Sub

    Private Sub HandleConnection(Result As IAsyncResult)
        Dim Stream As IO.Pipes.NamedPipeServerStream = Result.AsyncState

        Console.WriteLine("EndWaitForConnection")
        Try
            Stream.EndWaitForConnection(Result)
        Catch Ex As ObjectDisposedException
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine(String.Format("{0} was thrown", Ex.GetType.FullName))
            Console.WriteLine("Expected in 2.0")
            Console.ResetColor
            Return
        Catch Ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(String.Format("{0} was thrown", Ex.GetType.FullName))
            Console.WriteLine("New behavior in 2.1")
            Console.ResetColor
            Return
        End Try

        Dim RequestBytes(-1) As Byte
        Dim Buffer(1024) As Byte
        Dim Start As Integer = 0
        Dim Length As Integer

        Do
            Length = Stream.Read(Buffer, 0, Buffer.Length)
                
            If Length > 0 Then
                Array.Resize(RequestBytes, RequestBytes.Length + Length)
                Array.Copy(Buffer, 0, RequestBytes, Start, Length)
                Start = Start + Length
            End If
        Loop Until Length < Buffer.Length

        Console.WriteLine(String.Format("Received {0} bytes", RequestBytes.Count))
        Console.WriteLine(Text.Encoding.UTF8.GetChars(RequestBytes))
        
        If Stream.IsConnected Then
            Console.WriteLine("Disconnect")
            Stream.Disconnect
        End If
        ConnectedEventHandler.Set
    End Sub

End Class