### v2.0.5/Win10/Amd64
### v2.0.6/Debian9/x86
### v2.0.5/Debian9/Amd64
### v2.0.4/Raspbian9/ARM64

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

### v2.1-preview1/Win10/Amd64
#### Without COMPlus_UseManagedHttpClientHandler
#### COMPlus_UseManagedHttpClientHandler=true
#### COMPlus_UseManagedHttpClientHandler=false

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
EndWaitForConnection
EndWaitForConnection had exception.
System.ObjectDisposedException was thrown. Expected in 2.0.
```

### v2.1-preview1/Debian9/Amd64
#### Without AppContext.SetSwitch
#### With AppContext.SetSwitch("System.Net.Http.UseManagedHttpClientHandler", True)
#### With AppContext.SetSwitch("System.Net.Http.UseManagedHttpClientHandler", False)

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
EndWaitForConnection
EndWaitForConnection had exception.
System.ObjectDisposedException was thrown. Expected in 2.0.
EndWaitForConnection
EndWaitForConnection had exception.
System.Net.Sockets.SocketException was thrown. New behavior in 2.1
```

### v2.1-preview1/Debian9/x86
#### Without AppContext.SetSwitch
#### With AppContext.SetSwitch("System.Net.Http.UseManagedHttpClientHandler", True)
#### With AppContext.SetSwitch("System.Net.Http.UseManagedHttpClientHandler", False)

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
EndWaitForConnection
EndWaitForConnection had exception.
System.Net.Sockets.SocketException was thrown. New behavior in 2.1
EndWaitForConnection
EndWaitForConnection had exception.
System.ObjectDisposedException was thrown. Expected in 2.0.
```