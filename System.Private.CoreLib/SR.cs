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
    
    public const string ArgumentNull_Generic = "Value cannot be null.";
    public const string Argument_InvalidOffLen = "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.";
    public const string Argument_DestinationTooShort = "Destination is too short.";
    
    public const string ArgumentOutOfRange_NeedNonNegNum = "Non-negative number required.";
    public const string ArgumentOutOfRange_IndexMustBeLess = "Index was out of range. Must be non-negative and less than the size of the collection.";
    public const string ArgumentOutOfRange_IndexMustBeLessOrEqual = "Index was out of range. Must be non-negative and less than or equal to the size of the collection.";
    public const string ArgumentOutOfRange_HugeArrayNotSupported = "Arrays larger than 2GB are not supported.";
    public const string ArgumentOutOfRange_Count = "Count must be positive and count must refer to a location within the string/array/collection.";
    
    public const string ArgumentOutOfRange_Generic_MustBeNonNegative = "{0} ('{1}') must be a non-negative value.";
    public const string ArgumentOutOfRange_Generic_MustBeGreaterOrEqual = "{0} ('{1}') must be greater than or equal to '{2}'.";
    
    public const string InvalidOperation_EnumNotStarted = "Enumeration has not started. Call MoveNext.";
    public const string InvalidOperation_EnumEnded = "Enumeration already finished.";
    public const string InvalidOperation_NullArray = "The underlying array is null.";

    public const string HashCode_HashCodeNotSupported = "HashCode is a mutable struct and should not be compared with other HashCodes. Use ToHashCode to retrieve the computed hash code.";
    public const string HashCode_EqualityNotSupported = "HashCode is a mutable struct and should not be compared with other HashCodes.";

}