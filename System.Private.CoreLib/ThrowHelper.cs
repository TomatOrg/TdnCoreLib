using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System;

[StackTraceHidden]
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
    internal static void ThrowInvalidOperationException(string resource)
    {
        throw new InvalidOperationException(resource);
    }

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_NoValue()
    {
        throw new InvalidOperationException("Nullable object must have a value.");
    }
    
    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_EnumCurrent(int index)
    {
        throw GetInvalidOperationException_EnumCurrent(index);
    }
    
    private static InvalidOperationException GetInvalidOperationException_EnumCurrent(int index)
    {
        return new InvalidOperationException(
            index < 0 ?
                SR.InvalidOperation_EnumNotStarted :
                SR.InvalidOperation_EnumEnded);
    }

    [DoesNotReturn]
    internal static void ThrowArgumentNullException(string argument)
    {
        throw new ArgumentNullException(argument);
    }
    
    
    [DoesNotReturn]
    internal static void ThrowArgumentException_TupleIncorrectType(object obj)
    {
        throw new ArgumentException(SR.ArgumentException_ValueTupleIncorrectType, "other");
    }
    
    [DoesNotReturn]
    internal static void ThrowArraySegmentCtorValidationFailedExceptions(Array? array, int offset, int count)
    {
        throw GetArraySegmentCtorValidationFailedException(array, offset, count);
    }
    
    private static Exception GetArraySegmentCtorValidationFailedException(Array? array, int offset, int count)
    {
        if (array == null)
            return new ArgumentNullException(nameof(array));
        if (offset < 0)
            return new ArgumentOutOfRangeException(nameof(offset), SR.ArgumentOutOfRange_NeedNonNegNum);
        if (count < 0)
            return new ArgumentOutOfRangeException(nameof(count), SR.ArgumentOutOfRange_NeedNonNegNum);

        Debug.Assert(array.Length - offset < count);
        return new ArgumentException(SR.Argument_InvalidOffLen);
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_IndexMustBeLessException()
    {
        throw new ArgumentOutOfRangeException("index", SR.ArgumentOutOfRange_IndexMustBeLess);
    }

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_IndexMustBeLessOrEqualException()
    {
        throw new ArgumentOutOfRangeException("index", SR.ArgumentOutOfRange_IndexMustBeLessOrEqual);
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentException_DestinationTooShort()
    {
        throw new ArgumentException(SR.Argument_DestinationTooShort, "destination");
    }
    
    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumNotStarted()
    {
        throw new InvalidOperationException(SR.InvalidOperation_EnumNotStarted);
    }
    
    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumEnded()
    {
        throw new InvalidOperationException(SR.InvalidOperation_EnumEnded);
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException()
    {
        throw new ArgumentOutOfRangeException();
    }

    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRangeException(string argument, string resource)
    {
        throw new ArgumentOutOfRangeException(argument, resource);
    }
    
    [DoesNotReturn]
    internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLessOrEqual()
    {
        throw new ArgumentOutOfRangeException("startIndex", SR.ArgumentOutOfRange_IndexMustBeLessOrEqual);
    }
    [DoesNotReturn]
    internal static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count()
    {
        throw new ArgumentOutOfRangeException("count", SR.ArgumentOutOfRange_Count);
    }

}