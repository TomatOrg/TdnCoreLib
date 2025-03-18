using System.Diagnostics.CodeAnalysis;

namespace System;

internal static class ThrowHelper
{
    
    [DoesNotReturn]
    internal static void ThrowNotSupportedException()
    {
        throw new NotSupportedException();
    }

    [DoesNotReturn]
    internal static void ThrowIndexOutOfRangeException()
    {
        throw new IndexOutOfRangeException();
    }


    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_NoValue()
    {
        throw new InvalidOperationException("Nullable object must have a value.");
    }
    
}