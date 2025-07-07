namespace System;

internal static class SR
{

    public const string Arg_ArgumentOutOfRangeException = "Specified argument was out of the range of valid values.";
    public const string Arg_NotSupportedException = "Specified method is not supported.";
    public const string Arg_NotImplementedException = "The method or operation is not implemented.";
    public const string Arg_InvalidOperationException = "Operation is not valid due to the current state of the object.";
    public const string Arg_IndexOutOfRangeException = "Index was outside the bounds of the array.";
    public const string Arg_DivideByZero = "Attempted to divide by zero.";
    public const string Arg_ArithmeticException = "Overflow or underflow in the arithmetic operation.";
    public const string Arg_LongerThanSrcArray = "Source array was not long enough. Check the source index, length, and the array's lower bounds.";
    public const string Arg_LongerThanDestArray = "Destination array was not long enough. Check the destination index, length, and the array's lower bounds.";
    public const string Arg_OverflowException = "Arithmetic operation resulted in an overflow.";
    public const string Arg_ByteArrayTooSmallForValue = "The array starting from the specified index is not long enough to read a value of the specified type.";
    public const string Arg_BufferTooSmall = "Not enough space available in the buffer.";
    
    public const string Arg_MustBeDouble = "Object must be of type Double.";
    public const string Arg_MustBeSByte = "Object must be of type SByte.";
    public const string Arg_MustBeInt16 = "Object must be of type Int16.";
    public const string Arg_MustBeInt32 = "Object must be of type Int32.";
    public const string Arg_MustBeInt64 = "Object must be of type Int64.";
    public const string Arg_MustBeIntPtr = "Object must be of type IntPtr.";
    public const string Arg_MustBeByte = "Object must be of type Byte.";
    public const string Arg_MustBeUInt16 = "Object must be of type UInt16.";
    public const string Arg_MustBeUInt32 = "Object must be of type UInt32.";
    public const string Arg_MustBeUInt64 = "Object must be of type UInt64.";
    public const string Arg_MustBeUIntPtr = "Object must be of type UIntPtr.";
    public const string Arg_MustBeChar = "Object must be of type Char.";
    public const string Arg_MustBeBoolean = "Object must be of type Boolean.";
    
    public const string Overflow_NegateTwosCompNum = "Negating the minimum value of a twos complement number is invalid.";
    
    public const string ArgumentNull_Generic = "Value cannot be null.";

    public const string ArgumentException_ValueTupleIncorrectType = "Argument must be of type {0}.";
    public const string ArgumentException_ValueTupleLastArgumentNotAValueTuple = "The last element of an eight element ValueTuple must be a ValueTuple.";
    
    public const string Argument_InvalidOffLen = "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.";
    public const string Argument_DestinationTooShort = "Destination is too short.";
    public const string Argument_OverlapAlignmentMismatch = "Overlapping spans have mismatching alignment.";
    public const string Argument_InvalidLowSurrogate = "Found a low surrogate char without a preceding high surrogate at index: {0}. The input may not be in this encoding, or may not contain valid Unicode (UTF-16) characters.";
    public const string Argument_InvalidHighSurrogate = "Found a high surrogate char without a following low surrogate at index: {0}. The input may not be in this encoding, or may not contain valid Unicode (UTF-16) characters.";
    public const string Argument_InvalidEnumValue = "The value '{0}' is not valid for this usage of the type {1}.";
    public const string Argument_MinMaxValue = "'{0}' cannot be greater than {1}.";
    
    public const string ArgumentOutOfRange_NeedNonNegNum = "Non-negative number required.";
    public const string ArgumentOutOfRange_IndexMustBeLess = "Index was out of range. Must be non-negative and less than the size of the collection.";
    public const string ArgumentOutOfRange_IndexMustBeLessOrEqual = "Index was out of range. Must be non-negative and less than or equal to the size of the collection.";
    public const string ArgumentOutOfRange_HugeArrayNotSupported = "Arrays larger than 2GB are not supported.";
    public const string ArgumentOutOfRange_Count = "Count must be positive and count must refer to a location within the string/array/collection.";
    public const string ArgumentOutOfRange_RoundingDigits = "Rounding digits must be between 0 and 15, inclusive.";
    public const string ArgumentOutOfRange_InvalidHighSurrogate = "A valid high surrogate character is between 0xd800 and 0xdbff, inclusive.";
    public const string ArgumentOutOfRange_InvalidLowSurrogate = "A valid low surrogate character is between 0xdc00 and 0xdfff, inclusive.";
    
    public const string ArgumentOutOfRange_Generic_MustBeNonNegative = "{0} ('{1}') must be a non-negative value.";
    public const string ArgumentOutOfRange_Generic_MustBeGreaterOrEqual = "{0} ('{1}') must be greater than or equal to '{2}'.";
    
    public const string InvalidOperation_EnumNotStarted = "Enumeration has not started. Call MoveNext.";
    public const string InvalidOperation_EnumEnded = "Enumeration already finished.";
    public const string InvalidOperation_NullArray = "The underlying array is null.";

    public const string HashCode_HashCodeNotSupported = "HashCode is a mutable struct and should not be compared with other HashCodes. Use ToHashCode to retrieve the computed hash code.";
    public const string HashCode_EqualityNotSupported = "HashCode is a mutable struct and should not be compared with other HashCodes.";

    public const string NotSupported_CannotCallEqualsOnSpan = "Equals() on Span and ReadOnlySpan is not supported. Use operator== instead.";
    public const string NotSupported_CannotCallGetHashCodeOnSpan = "GetHashCode() on Span and ReadOnlySpan is not supported.";

    public const string Arithmetic_NaN = "Function does not accept floating point Not-a-Number values.";

}