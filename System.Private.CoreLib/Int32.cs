namespace System;

public readonly struct Int32
    : IComparable
    , IComparable<Int32> 
    , IEquatable<Int32>
{
    
    public const int MaxValue = 0x7fffffff;
    public const int MinValue = unchecked((int)0x80000000);
    
    private readonly int _value;
    
    public int CompareTo(object? value)
    {
        if (value == null)
        {
            return 1;
        }
        
        if (value is int i)
        {
            if (this < i) return -1;
            if (this > i) return 1;
            return 0;
        }

        throw new ArgumentException("Object must be of type Int32.");
    }

    public int CompareTo(int other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(int other)
    {
        throw new NotImplementedException();
    }
}