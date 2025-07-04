namespace System;

public class DivideByZeroException : ArithmeticException
{
    
    public DivideByZeroException()
        : base(SR.Arg_DivideByZero)
    {
    }
    
    public DivideByZeroException(string? message)
        : base(message ?? SR.Arg_DivideByZero)
    {
    }

    public DivideByZeroException(string? message, Exception? innerException)
        : base(message ?? SR.Arg_DivideByZero, innerException)
    {
    }
    
}