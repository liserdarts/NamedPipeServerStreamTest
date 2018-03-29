This project shows some behaviour differences with `System.IO.Pipes.NamedPipeServerStream` between .NET Core 2.0 and 2.1-Preview1.
Look in [Output.md](https://github.com/liserdarts/NamedPipeServerStreamTest/blob/master/Output.md) to see this program output from different platforms and versios of .NET Core.

## NoSubProcess

This branch is to show yet more differences when not spawing a child process.
When running this program on v2.1-preview1/Debian9/x86 and spawing a child process there is a `NullReferneceException` in `System.Net.Sockets.SocketAsyncContext.AcceptOperation.InvokeCallback()`.
When using the branch and not spawing a child process this exception does not happen.

## Differences

When using .NET Core built from the v2.1-Preview1 branch some new exceptions are thrown.

### SocketException
`System.Net.Sockets.SocketException` is thrown on one background thread calling `NamedPipeServerStream.EndWaitForConnection`.
This is new behaviour.

### NullReferenceException
This exception does not happen in the NoSubProcess branch of NamedPipeServerStreamTest.
On Debian9 / x86 there is also a `System.NullReferenceException` on a background thread.
This comes out of `System.Threading.ThreadPoolWorkQueue.Dispatch()` and I don't know of any way to catch it.
This is an unhandled exception and will cause the program to crash.

### ObjectDisposedException
There is a `System.ObjectDisposedException` when calling `NamedPipeServerStream.EndWaitForConnection`.
This was expected behaviour in 2.0 even though this program does not show it.