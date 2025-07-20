using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System;

[StackTraceHidden]
internal static class ThrowHelper
{
    
    [DoesNotReturn]
    internal static void ThrowFormatException_NeedSingleChar()
    {
        throw new FormatException(SR.Format_NeedSingleChar);
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentException_CannotExtractScalar(string argument)
    {
        throw new ArgumentException(SR.Argument_CannotExtractScalar, argument);
    }

    internal static void ThrowFormatException_BadFormatSpecifier()
    {
        throw new FormatException(SR.Argument_BadFormatSpecifier);
    }
    
    [DoesNotReturn]
    internal static void ThrowNotSupportedException()
    {
        throw new NotSupportedException();
    }
    
    [DoesNotReturn]
    internal static void ThrowFormatIndexOutOfRange()
    {
        throw new FormatException(SR.Format_IndexOutOfRange);
    }
    
    [DoesNotReturn]
    internal static void ThrowFormatInvalidString()
    {
        throw new FormatException(SR.Format_InvalidString);
    }

    [DoesNotReturn]
    internal static void ThrowFormatInvalidString(int offset, string resource)
    {
        throw new FormatException(string.Format(SR.Format_InvalidStringWithOffsetAndReason, offset, resource));
    }
    
    [DoesNotReturn]
    internal static void ThrowIndexArgumentOutOfRange_NeedNonNegNumException()
    {
        throw new ArgumentOutOfRangeException("index", SR.ArgumentOutOfRange_NeedNonNegNum);
    }
    
    [DoesNotReturn]
    internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLess()
    {
        throw new ArgumentOutOfRangeException("startIndex", SR.ArgumentOutOfRange_IndexMustBeLess);
    }
    
    [DoesNotReturn]
    internal static void ThrowNotSupportedException(string resource)
    {
        throw new NotSupportedException(resource);
    }

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion()
    {
        throw new InvalidOperationException(SR.InvalidOperation_EnumFailedVersion);
    }
    
    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen()
    {
        throw new InvalidOperationException(SR.InvalidOperation_EnumOpCantHappen);
    }

    [DoesNotReturn]
    internal static void ThrowFormatException_BadBoolean(ReadOnlySpan<char> value)
    {
        throw new FormatException(string.Format(SR.Format_BadBoolean, new string(value)));
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentException_BadComparer(object? comparer)
    {
        throw new ArgumentException(string.Format(SR.Arg_BogusIComparer, comparer));
    }
    
    [DoesNotReturn]
    internal static void ThrowOutOfMemoryException_StringTooLong()
    {
        throw new OutOfMemoryException(SR.OutOfMemory_StringTooLong);
    }
    
    [DoesNotReturn]
    internal static void ThrowValueArgumentOutOfRange_NeedNonNegNumException()
    {
        throw new ArgumentOutOfRangeException("value", SR.ArgumentOutOfRange_NeedNonNegNum);
    }

    [DoesNotReturn]
    internal static void ThrowIndexOutOfRangeException()
    {
        throw new IndexOutOfRangeException();
    }
    
    [DoesNotReturn]
    internal static void ThrowOverflowException()
    {
        throw new OverflowException();
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentException_OverlapAlignmentMismatch()
    {
        throw new ArgumentException(SR.Argument_OverlapAlignmentMismatch);
    }

    [DoesNotReturn]
    internal static void ThrowInvalidOperationException(string resource)
    {
        throw new InvalidOperationException(resource);
    }
    
    [DoesNotReturn]
    internal static void ThrowInvalidOperationException(string resource, Exception e)
    {
        throw new InvalidOperationException(resource, e);
    }
    
    [DoesNotReturn]
    internal static void ThrowInvalidOperationException_InvalidOperation_NoValue()
    {
        throw new InvalidOperationException("Nullable object must have a value.");
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentException(string resource)
    {
        throw new ArgumentException(resource);
    }
    
    [DoesNotReturn]
    internal static void ThrowArgumentException(string resource, string argument)
    {
        throw new ArgumentException(resource, argument);
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
        throw new ArgumentException(string.Format(SR.ArgumentException_ValueTupleIncorrectType, obj.GetType()), "other");
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
    internal static void ThrowArgumentOutOfRangeException(string argument)
    {
        throw new ArgumentOutOfRangeException(argument);
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
    
    [DoesNotReturn]
    internal static void ThrowArgumentOutOfRange_Range<T>(string parameterName, T value, T minInclusive, T maxInclusive)
    {
        throw new ArgumentOutOfRangeException(parameterName, value, string.Format(SR.ArgumentOutOfRange_Range, minInclusive, maxInclusive));
    }

}