namespace System;

public class NotSupportedException : SystemException
{
    
    public NotSupportedException()
        : base("Specified method is not supported.")
    {
    }

    public NotSupportedException(string? message)
        : base(message)
    {
    }

    public NotSupportedException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
    
}