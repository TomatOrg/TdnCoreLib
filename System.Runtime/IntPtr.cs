using System.Diagnostics.CodeAnalysis;

namespace System;

public readonly struct IntPtr
    : IEquatable<IntPtr>
    , IComparable
    , IComparable<IntPtr>
{
    
    public static readonly nint Zero = 0;

    public static int Size => sizeof(long);

    public static nint MaxValue => (nint)long.MaxValue;
    public static nint MinValue => (nint)long.MinValue;

    
    private readonly long _value;

    public IntPtr(int value)
    {
        _value = value;
    }
    
    public IntPtr(long value)
    {
        _value = (nint)value;
    }
 
    public unsafe IntPtr(void* value)
    {
        _value = (nint)value;
    }
    
    public override bool Equals([NotNullWhen(true)] object? obj) => (obj is nint other) && Equals(other);
    public bool Equals(nint other) => _value == other;
    
    public override int GetHashCode()
    {
        long value = _value;
        return value.GetHashCode();
    }
    
    public int ToInt32() => checked((int)_value);
    public long ToInt64() => _value;
    public unsafe void* ToPointer() => (void*)_value;

    public static explicit operator nint(int value) => value;
    public static explicit operator nint(long value) => checked((nint)value);
    public static unsafe explicit operator nint(void* value) => (nint)value;
    public static unsafe explicit operator void*(nint value) => (void*)value;
    public static explicit operator int(nint value) => checked((int)value);
    public static explicit operator long(nint value) => value;

    public static bool operator ==(nint value1, nint value2) => value1 == value2;
    public static bool operator !=(nint value1, nint value2) => value1 != value2;

    public static nint Add(nint pointer, int offset) => pointer + offset;
    public static nint operator +(nint pointer, int offset) => pointer + offset;

    public static nint Subtract(nint pointer, int offset) => pointer - offset;
    public static nint operator -(nint pointer, int offset) => pointer - offset;

    public int CompareTo(object? value)
    {
        if (value is nint other)
        {
            return CompareTo(other);
        }
        else if (value is null)
        {
            return 1;
        }

        throw new ArgumentException("Object must be of type IntPtr.");
    }
    
    public int CompareTo(nint value)
    {
        if (_value < value) return -1;
        if (_value > value) return 1;
        return 0;
    }

}