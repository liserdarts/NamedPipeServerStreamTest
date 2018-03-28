# v2.0.5/Win10/Amd64

```text
BeginWaitForConnection
EndWaitForConnection
Received 40 bytes
This is a message sent via a named pipe.
Disconnect
BeginWaitForConnection
The background exception(s) can take a second. Don't finish too quickly
Press any key to continue
BeginWaitForConnection
Calling NamedPipeServerStream.Dispose
Exiting loop
```

# v2.0.6/Debian9/x86

```text
BeginWaitForConnection
EndWaitForConnection
Received 40 bytes
This is a message sent via a named pipe.
Disconnect
BeginWaitForConnection
The background exception(s) can take a second. Don't finish too quickly
Press any key to continue
BeginWaitForConnection
Calling NamedPipeServerStream.Dispose
Exiting loop
```

# v2.1-preview1/Debian9/x86

```text
BeginWaitForConnection
EndWaitForConnection
Received 40 bytes
This is a message sent via a named pipe.
Disconnect
BeginWaitForConnection
The background exception(s) can take a second. Don't finish too quickly
Press any key to continue
BeginWaitForConnection
Calling NamedPipeServerStream.Dispose
EndWaitForConnection
EndWaitForConnection had exception.
System.Net.Sockets.SocketException was thrown. New behavior in 2.1

EndWaitForConnection
Unhandled Exception: EndWaitForConnection had exception.
System.ObjectDisposedException was thrown. Expected in 2.0.

Unhandled Exception:
Unhandled Exception: System.NullReferenceException: Object reference not set to an instance of an object.
   at System.Net.Sockets.SocketAsyncContext.AcceptOperation.InvokeCallback() in /home/nick/Documents/builds/branches/corefx/src/System.Net.Sockets/src/System/Net/Sockets/SocketAsyncContext.Unix.cs:line 543
   at System.Net.Sockets.SocketAsyncContext.AsyncOperation.<>c.<TryCancel>b__18_0(Object o) in /home/nick/Documents/builds/branches/corefx/src/System.Net.Sockets/src/System/Net/Sockets/SocketAsyncContext.Unix.cs:line 271
   at System.Threading.QueueUserWorkItemCallbackDefaultContext.WaitCallback_Context(Object state)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.QueueUserWorkItemCallbackDefaultContext.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem()
   at System.Threading.ThreadPoolWorkQueue.Dispatch()
   at System.Threading._ThreadPoolWaitCallback.PerformWaitCallback()
System.NullReferenceException: Object reference not set to an instance of an object.
   at System.Net.Sockets.SocketAsyncContext.AcceptOperation.InvokeCallback() in /home/nick/Documents/builds/branches/corefx/src/System.Net.Sockets/src/System/Net/Sockets/SocketAsyncContext.Unix.cs:line 543
   at System.Net.Sockets.SocketAsyncContext.AsyncOperation.<>c.<TryCancel>b__18_0(Object o) in /home/nick/Documents/builds/branches/corefx/src/System.Net.Sockets/src/System/Net/Sockets/SocketAsyncContext.Unix.cs:line 271
   at System.Threading.QueueUserWorkItemCallbackDefaultContext.WaitCallback_Context(Object state)
   at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.QueueUserWorkItemCallbackDefaultContext.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem()
   at System.Threading.ThreadPoolWorkQueue.Dispatch()
   at System.Threading._ThreadPoolWaitCallback.PerformWaitCallback()
Segmentation fault
```

# v2.0.5/Debian9/Amd64

```text
BeginWaitForConnection
EndWaitForConnection
Received 40 bytes
This is a message sent via a named pipe.
Disconnect
BeginWaitForConnection
The background exception(s) can take a second. Don't finish too quickly
Press any key to continue
BeginWaitForConnection
Calling NamedPipeServerStream.Dispose
Exiting loop
```

# v2.0.4/Raspbian9/ARM64

```text
BeginWaitForConnection
EndWaitForConnection
Received 40 bytes
This is a message sent via a named pipe.
Disconnect
BeginWaitForConnection
The background exception(s) can take a second. Don't finish too quickly
Press any key to continue
BeginWaitForConnection
Calling NamedPipeServerStream.Dispose
Exiting loop
```