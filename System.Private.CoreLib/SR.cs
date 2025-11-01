namespace System;

internal static class SR
{
    
    public const string DebugAssertBanner = "---- DEBUG ASSERTION FAILED ----";
    public const string DebugAssertLongMessage = "---- Assert Long Message ----";
    public const string DebugAssertShortMessage = "---- Assert Short Message ----";

    public const string Exception_WasThrown = "Exception of type '{0}' was thrown.";
    public const string Exception_EndOfInnerExceptionStack = "--- End of inner exception stack trace ---";

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
    public const string Arg_OutOfMemoryException = "Insufficient memory to continue the execution of the program.";
    public const string Arg_MustBeNullTerminatedString = "The string must be null-terminated.";
    public const string Arg_BogusIComparer = "Unable to sort because the IComparer.Compare() method returns inconsistent results. Either a value does not compare equal to itself, or one value repeatedly compared to another value yields different results. IComparer: '{0}'.";
    public const string Arg_ArgumentException = "Value does not fall within the expected range.";
    public const string Arg_FormatException = "One of the identified items was in an invalid format.";
    public const string Arg_InvalidCastException = "Specified cast is not valid.";
    public const string Arg_LongerThanSrcString = "Source string was not long enough. Check sourceIndex and count.";
    public const string Arg_InvalidHexBinaryStyle = "With the AllowHexSpecifier or AllowBinarySpecifier bit set in the enum bit field, the only other valid bits that can be combined into the enum value must be AllowLeadingWhite and AllowTrailingWhite.";
    public const string Arg_HexBinaryStylesNotSupported = "The number styles AllowHexSpecifier and AllowBinarySpecifier are not supported on floating point data types.";
    public const string Arg_GuidArrayCtor = "Byte array for Guid must be exactly {0} bytes long.";
    
    public const string Arg_MustBeHalf = "Object must be of type Half.";
    public const string Arg_MustBeSingle = "Object must be of type Single.";
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
    public const string Arg_MustBeString = "Object must be of type String.";
    public const string Arg_MustBeRune = "Object must be of type Rune.";
    public const string Arg_MustBeGuid = "Object must be of type GUID.";
    
    public const string Overflow_NegateTwosCompNum = "Negating the minimum value of a twos complement number is invalid.";
    public const string Overflow_Char = "Value was either too large or too small for a character.";
    public const string Overflow_Byte = "Value was either too large or too small for an unsigned byte.";
    public const string Overflow_UInt16 = "Value was either too large or too small for a UInt16.";
    public const string Overflow_UInt32 = "Value was either too large or too small for a UInt32.";
    public const string Overflow_UInt64 = "Value was either too large or too small for a UInt64.";
    public const string Overflow_SByte = "Value was either too large or too small for a signed byte.";
    public const string Overflow_Int16 = "Value was either too large or too small for an Int16.";
    public const string Overflow_Int32 = "Value was either too large or too small for an Int32.";
    public const string Overflow_Int64 = "Value was either too large or too small for an Int64.";
    
    public const string ArgumentNull_Generic = "Value cannot be null.";
    public const string ArgumentNull_ArrayValue = "Found a null value within an array.";

    public const string ArgumentException_ValueTupleIncorrectType = "Argument must be of type {0}.";
    public const string ArgumentException_ValueTupleLastArgumentNotAValueTuple = "The last element of an eight element ValueTuple must be a ValueTuple.";
    
    public const string Argument_InvalidOffLen = "Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.";
    public const string Argument_DestinationTooShort = "Destination is too short.";
    public const string Argument_OverlapAlignmentMismatch = "Overlapping spans have mismatching alignment.";
    public const string Argument_InvalidLowSurrogate = "Found a low surrogate char without a preceding high surrogate at index: {0}. The input may not be in this encoding, or may not contain valid Unicode (UTF-16) characters.";
    public const string Argument_InvalidHighSurrogate = "Found a high surrogate char without a following low surrogate at index: {0}. The input may not be in this encoding, or may not contain valid Unicode (UTF-16) characters.";
    public const string Argument_InvalidEnumValue = "The value '{0}' is not valid for this usage of the type {1}.";
    public const string Argument_MinMaxValue = "'{0}' cannot be greater than {1}.";
    public const string Argument_SpansMustHaveSameLength = "Input span arguments must all have the same length.";
    public const string Argument_InvalidArgumentForComparison = "Type of argument is not compatible with the generic comparer.";
    public const string Argument_InvalidFlag = "Value of flags is invalid.";
    public const string Argument_EmptyString = "The value cannot be an empty string.";
    public const string Argument_EmptyOrWhiteSpaceString = "The value cannot be an empty string or composed entirely of whitespace.";
    public const string Argument_CannotExtractScalar = "Cannot extract a Unicode scalar value from the specified index in the input.";
    public const string Argument_InvalidNativeDigitCount = "The NativeDigits array must contain exactly ten members.";
    public const string Argument_InvalidNativeDigitValue = "Each member of the NativeDigits array must be a single text element (one or more UTF-16 code points) with a Unicode Nd (Number, Decimal Digit) property indicating it is a digit.";
    public const string Argument_InvalidDigitSubstitution = "The DigitSubstitution property must be of a valid member of the DigitShapes enumeration. Valid entries include Context, NativeNational or None.";
    public const string Argument_InvalidGroupSize = "Every element in the value array should be between one and nine, except for the last element, which can be zero.";
    public const string Argument_InvalidNumberStyles = "An undefined NumberStyles value is being used.";
    public const string Argument_BadFormatSpecifier = "Format specifier was invalid.";
    public const string ArgumentOutOfRange_PartialWCHAR = "Pointer startIndex and length do not refer to a valid string.";
    
    public const string ArgumentOutOfRange_NeedNonNegNum = "Non-negative number required.";
    public const string ArgumentOutOfRange_IndexMustBeLess = "Index was out of range. Must be non-negative and less than the size of the collection.";
    public const string ArgumentOutOfRange_IndexMustBeLessOrEqual = "Index was out of range. Must be non-negative and less than or equal to the size of the collection.";
    public const string ArgumentOutOfRange_HugeArrayNotSupported = "Arrays larger than 2GB are not supported.";
    public const string ArgumentOutOfRange_Count = "Count must be positive and count must refer to a location within the string/array/collection.";
    public const string ArgumentOutOfRange_RoundingDigits = "Rounding digits must be between 0 and 15, inclusive.";
    public const string ArgumentOutOfRange_InvalidHighSurrogate = "A valid high surrogate character is between 0xd800 and 0xdbff, inclusive.";
    public const string ArgumentOutOfRange_InvalidLowSurrogate = "A valid low surrogate character is between 0xdc00 and 0xdfff, inclusive.";
    public const string ArgumentOutOfRange_StartIndex = "StartIndex cannot be less than zero.";
    public const string ArgumentOutOfRange_StartIndexLargerThanLength = "startIndex cannot be larger than length of string.";
    public const string ArgumentOutOfRange_Generic_MustBeNonZero = "{0} ('{1}') must be a non-zero value.";
    public const string ArgumentOutOfRange_Generic_MustBeNonNegative = "{0} ('{1}') must be a non-negative value.";
    public const string ArgumentOutOfRange_Generic_MustBeNonNegativeNonZero = "{0} ('{1}') must be a non-negative and non-zero value.";
    public const string ArgumentOutOfRange_Generic_MustBeLessOrEqual = "{0} ('{1}') must be less than or equal to '{2}";
    public const string ArgumentOutOfRange_Generic_MustBeLess = "{0} ('{1}') must be less than '{2}";
    public const string ArgumentOutOfRange_Generic_MustBeGreaterOrEqual = "{0} ('{1}') must be greater than or equal to '{2}";
    public const string ArgumentOutOfRange_Generic_MustBeGreater = "{0} ('{1}') must be greater than '{2}";
    public const string ArgumentOutOfRange_Generic_MustBeEqual = "{0} ('{1}') must be equal to '{2}";
    public const string ArgumentOutOfRange_Generic_MustBeNotEqual = "{0} ('{1}') must not be equal to '{2}";
    public const string ArgumentOutOfRange_IndexLength = "Index and length must refer to a location within the string.";
    public const string ArgumentOutOfRange_SmallCapacity = "capacity was less than the current size.";
    public const string ArgumentOutOfRange_ListInsert = "Index must be within the bounds of the List.";
    public const string ArgumentOutOfRange_BiggerThanCollection = "Larger than collection size.";
    public const string ArgumentOutOfRange_Capacity = "Capacity exceeds maximum capacity.";
    public const string ArgumentOutOfRange_LengthGreaterThanCapacity = "The length cannot be greater than the capacity.";
    public const string ArgumentOutOfRange_OffsetOut = "Either offset did not refer to a position in the string, or there is an insufficient length of destination character array.";
    public const string ArgumentOutOfRange_RoundingDigits_MathF = "Rounding digits must be between 0 and 6, inclusive.";
    public const string ArgumentOutOfRange_InvalidUTF32 = "A valid UTF32 value is between 0x000000 and 0x10ffff, inclusive, and should not include surrogate codepoint values (0x00d800 ~ 0x00dfff).";
    public const string ArgumentOutOfRange_Range = "Valid values are between {0} and {1}, inclusive.";
    
    public const string InvalidOperation_EnumNotStarted = "Enumeration has not started. Call MoveNext.";
    public const string InvalidOperation_EnumEnded = "Enumeration already finished.";
    public const string InvalidOperation_NullArray = "The underlying array is null.";
    public const string InvalidOperation_SpanOverlappedOperation = "This operation is invalid on overlapping buffers.";
    public const string InvalidOperation_IComparerFailed = "Failed to compare two elements in the array.";
    public const string InvalidOperation_EnumFailedVersion = "Collection was modified after the enumerator was instantiated.";
    public const string InvalidOperation_EnumOpCantHappen = "Enumeration has either not started or has already finished.";
    public const string InvalidOperation_ReadOnly = "Instance is read-only.";
    
    public const string HashCode_HashCodeNotSupported = "HashCode is a mutable struct and should not be compared with other HashCodes. Use ToHashCode to retrieve the computed hash code.";
    public const string HashCode_EqualityNotSupported = "HashCode is a mutable struct and should not be compared with other HashCodes.";

    public const string NotSupported_CannotCallEqualsOnSpan = "Equals() on Span and ReadOnlySpan is not supported. Use operator== instead.";
    public const string NotSupported_CannotCallGetHashCodeOnSpan = "GetHashCode() on Span and ReadOnlySpan is not supported.";
    public const string NotSupported_StringComparison = "The string comparison type passed in is currently not supported.";
    public const string NotSupported_ReadOnlyCollection = "Collection is read-only.";
    
    public const string Arithmetic_NaN = "Function does not accept floating point Not-a-Number values.";

    public const string Format_BadBoolean = "String '{0}' was not recognized as a valid Boolean.";
    public const string Format_UnclosedFormatItem = "Format item ends prematurely.";
    public const string Format_ExpectedAsciiDigit = "Expected an ASCII digit.";
    public const string Format_InvalidString = "Input string was not in a correct format.";
    public const string Format_InvalidStringWithOffsetAndReason = "Input string was not in a correct format. Failure to parse near offset {0}. {1}";
    public const string Format_UnexpectedClosingBrace = "Unexpected closing brace without a corresponding opening brace.";
    public const string Format_IndexOutOfRange = "Index (zero based) must be greater than or equal to zero and less than the size of the argument list.";
    public const string Format_InvalidStringWithValue = "The input string '{0}' was not in a correct format.";
    public const string Format_NeedSingleChar = "String must be exactly one character long.";
    public const string Format_ExtraJunkAtEnd = "Additional non-parsable characters are at the end of the string.";
    public const string Format_GuidBraceAfterLastNumber = "Could not find a brace, or the length between the previous token and the brace was zero (i.e., '0x,'etc.).";
    public const string Format_GuidBrace = "Expected {0xdddddddd, etc}.";
    public const string Format_GuidComma = "Could not find a comma, or the length between the previous token and the comma was zero (i.e., '0x,'etc.).";
    public const string Format_GuidDashes = "Dashes are in the wrong position for GUID parsing.";
    public const string Format_GuidEndBrace = "Could not find the ending brace.";
    public const string Format_GuidHexPrefix = "Expected 0x prefix.";
    public const string Format_GuidInvalidChar = "Guid string should only contain hexadecimal characters.";
    public const string Format_GuidInvLen = "Guid should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).";
    public const string Format_GuidUnrecognized = "Unrecognized Guid format.";
    public const string Format_InvalidGuidFormatSpecification = "Format string can be only \"D\", \"d\", \"N\", \"n\", \"P\", \"p\", \"B\", \"b\", \"X\" or \"x\".";
    
    public const string OutOfMemory_StringTooLong = "String length exceeded supported range.";

}