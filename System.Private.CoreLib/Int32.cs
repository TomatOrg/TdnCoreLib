namespace System;

public readonly struct Int32
{
    
    public const int MaxValue = 0x7fffffff;
    public const int MinValue = unchecked((int)0x80000000);
    
    private readonly int _value;
    
    public override string ToString() {
        return null;
    }

}