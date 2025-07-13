using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public class Exception
{

    private string? _message;
    private readonly Exception? _innerException;

    public Exception()
    {
    }

    public Exception(string? message)
    {
        _message = message;
    }

    public Exception(string? message, System.Exception? innerException)
    {
        _message = message;
        _innerException =  innerException;
    }

    
}