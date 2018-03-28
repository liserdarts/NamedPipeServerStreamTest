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

        'End the listening thread
        ConnectedEventHandler.Set
    End Sub

    Private Sub ListenLoop()
        ConnectedEventHandler.Set
        Do
            If ConnectedEventHandler.WaitOne Then
                ConnectedEventHandler.Reset
                SyncLock GetType(Console)
                    Console.WriteLine("BeginWaitForConnection")
                End SyncLock
                Try
                    Pipe.BeginWaitForConnection(AddressOf HandleConnection, Pipe)
                Catch Ex As Exception
                    HandleException("BeginWaitForConnection", Ex)
                End Try
            End If
        Loop Until Not Listen

        SyncLock GetType(Console)
            Console.WriteLine("Calling NamedPipeServerStream.Dispose")
        End SyncLock
        Pipe.Dispose

        SyncLock GetType(Console)
            Console.WriteLine("Exiting loop")
        End SyncLock
    End Sub

    Private Sub HandleConnection(Result As IAsyncResult)
        Dim Stream As IO.Pipes.NamedPipeServerStream = Result.AsyncState

        SyncLock GetType(Console)
            Console.WriteLine("EndWaitForConnection")
        End SyncLock
        Try
            Stream.EndWaitForConnection(Result)

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

            SyncLock GetType(Console)
                Console.WriteLine(String.Format("Received {0} bytes", RequestBytes.Count))
                Console.WriteLine(Text.Encoding.UTF8.GetChars(RequestBytes))
            End SyncLock

            If Stream.IsConnected Then
                SyncLock GetType(Console)
                    Console.WriteLine("Disconnect")
                End SyncLock
                Stream.Disconnect
            End If
        Catch Ex As Exception
            HandleException("EndWaitForConnection", Ex)
            Return
        End Try

        ConnectedEventHandler.Set
    End Sub

    Private Sub HandleException(Source As String, Ex As Exception)
        SyncLock GetType(Console)
            Console.WriteLine(String.Format("{0} had exception.", Source))

            If TypeOf Ex Is ObjectDisposedException Then
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(String.Format("{0} was thrown. Expected in 2.0.", Ex.GetType.FullName))
            Else
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(String.Format("{0} was thrown. New behavior in 2.1", Ex.GetType.FullName))
            End If

            Console.ResetColor
        End SyncLock
    End Sub

End Class