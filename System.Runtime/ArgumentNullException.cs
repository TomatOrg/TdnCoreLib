using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

public class ArgumentNullException : ArgumentException
{

    public ArgumentNullException()
        : base("Value cannot be null.")
    {
    }

    public ArgumentNullException(string? paramName)
        : base("Value cannot be null.", paramName)
    {
    }

    public ArgumentNullException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public ArgumentNullException(string? paramName, string? message)
        : base(message, paramName)
    {
    }
    
    public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
        {
            Throw(paramName);
        }
    }
    
    public static unsafe void ThrowIfNull([NotNull] void* argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
        {
            Throw(paramName);
        }
    }
    
    internal static unsafe void ThrowIfNull(IntPtr argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument == IntPtr.Zero)
        {
            Throw(paramName);
        }
    }

    [DoesNotReturn]
    internal static void Throw(string? paramName)
    {
        throw new ArgumentNullException(paramName);
    }
}