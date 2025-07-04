using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace System;

public readonly struct Int32
    : IComparable<int>, 
        INumberBase<int>
{
    
    public const int MaxValue = 0x7fffffff;
    public const int MinValue = unchecked((int)0x80000000);
    
    private readonly int _value;

    public int CompareTo(int value)
    {
        if (_value < value) return -1;
        if (_value > value) return 1;
        return 0;
    }

    public static bool IsNegative(int value) => value < 0;
    
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (!(obj is int))
        {
            return false;
        }
        return _value == ((int)obj)._value;
    }
    
    public override int GetHashCode()
    {
        return _value;
    }

    public override string ToString()
    {
        return null;
    }

}