namespace System;

public sealed class IndexOutOfRangeException : SystemException
{
    
    public IndexOutOfRangeException()
        : base(SR.Arg_IndexOutOfRangeException)
    {
    }

    public IndexOutOfRangeException(string? message)
        : base(message ?? SR.Arg_IndexOutOfRangeException)
    {
    }

    public IndexOutOfRangeException(string? message, Exception? innerException)
        : base(message ?? SR.Arg_IndexOutOfRangeException, innerException)
    {
    }

}