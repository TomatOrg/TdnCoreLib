using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace System;

public class ArgumentOutOfRangeException : ArgumentException
{
    
    private readonly object? _actualValue;
    
    public ArgumentOutOfRangeException()
        : base(SR.Arg_ArgumentOutOfRangeException)
    {
    }

    public ArgumentOutOfRangeException(string? paramName)
        : base(SR.Arg_ArgumentOutOfRangeException, paramName)
    {
    }

    public ArgumentOutOfRangeException(string? paramName, string? message)
        : base(message ?? SR.Arg_ArgumentOutOfRangeException, paramName)
    {
    }

    public ArgumentOutOfRangeException(string? message, Exception? innerException)
        : base(message ?? SR.Arg_ArgumentOutOfRangeException, innerException)
    {
    }

    public ArgumentOutOfRangeException(string? paramName, object? actualValue, string? message)
        : base(message ?? SR.Arg_ArgumentOutOfRangeException, paramName)
    {
        _actualValue = actualValue;
    }
    
    public static void ThrowIfLessThan<T>(T value, T other, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        where T : IComparable<T>
    {
        if (value.CompareTo(other) < 0)
            ThrowLess(value, other, paramName);
    }
    
    public static void ThrowIfNegative<T>(T value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        where T : INumberBase<T>
    {
        if (T.IsNegative(value))
            ThrowNegative(value, paramName);
    }

    // [DoesNotReturn]
    // private static void ThrowLess<T>(T value, T other, string? paramName) =>
    //     throw new ArgumentOutOfRangeException(paramName, value, SR.Format(SR.ArgumentOutOfRange_Generic_MustBeGreaterOrEqual, paramName, value, other));
    [DoesNotReturn]
    private static void ThrowLess<T>(T value, T other, string? paramName) =>
        throw new ArgumentOutOfRangeException(paramName, value, SR.ArgumentOutOfRange_Generic_MustBeGreaterOrEqual);
    
    // [DoesNotReturn]
    // private static void ThrowNegative<T>(T value, string? paramName) =>
    //     throw new ArgumentOutOfRangeException(paramName, value, SR.Format(SR.ArgumentOutOfRange_Generic_MustBeNonNegative, paramName, value));
    [DoesNotReturn]
    private static void ThrowNegative<T>(T value, string? paramName) =>
        throw new ArgumentOutOfRangeException(paramName, value, SR.ArgumentOutOfRange_Generic_MustBeNonNegative);

    
}