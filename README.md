This project shows some behaviour differences with `System.IO.Pipes.NamedPipeServerStream` between .NET Core 2.0 and 2.1-Preview1.
Look in [Output.md](https://github.com/liserdarts/NamedPipeServerStreamTest/blob/master/Output.md) to see this program output from different platforms and versios of .NET Core.

## Differences

When using .NET Core built from the v2.1-Preview1 branch some new exceptions are thrown.

### SocketException
`System.Net.Sockets.SocketException` is thrown on one background thread calling `NamedPipeServerStream.EndWaitForConnection`.
This is new behaviour.

### NullReferenceException
On Debian9 / x86 there is also a `System.NullReferenceException` on a background thread.
This comes out of `System.Threading.ThreadPoolWorkQueue.Dispatch()` and I don't know of any way to catch it.
This is an unhandled exception and will cause the program to crash.

### ObjectDisposedException
There is a `System.ObjectDisposedException` when calling `NamedPipeServerStream.EndWaitForConnection`.
This was expected behaviour in 2.0 even though this program does not show it.