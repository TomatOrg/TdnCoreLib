using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

public class ArgumentException : SystemException
{
    
    public virtual string? ParamName { get; }

    public ArgumentException()
        : base("Value does not fall within the expected range.")
    {
    }
    
    public ArgumentException(string? message)
        : base(message)
    {
    }
    
    public ArgumentException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
    
    public ArgumentException(string? message, string? paramName, Exception? innerException)
        : base(message, innerException)
    {
        ParamName = paramName;
    }

    public ArgumentException(string? message, string? paramName)
        : base(message)
    {
        ParamName = paramName;
    }
    
    public static void ThrowIfNullOrEmpty([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(argument))
        {
            ThrowNullOrEmptyException(argument, paramName);
        }
    }

    public static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            ThrowNullOrWhiteSpaceException(argument, paramName);
        }
    }

    [DoesNotReturn]
    private static void ThrowNullOrEmptyException(string? argument, string? paramName)
    {
        ArgumentNullException.ThrowIfNull(argument, paramName);
        throw new ArgumentException("The value cannot be an empty string.", paramName);
    }

    [DoesNotReturn]
    private static void ThrowNullOrWhiteSpaceException(string? argument, string? paramName)
    {
        ArgumentNullException.ThrowIfNull(argument, paramName);
        throw new ArgumentException("The value cannot be an empty string or composed entirely of whitespace.", paramName);
    }
    
}