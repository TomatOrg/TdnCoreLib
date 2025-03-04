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

    
}