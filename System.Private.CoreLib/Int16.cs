namespace System;

public readonly struct Int16
{

    public const short MaxValue = (short)0x7FFF;
    public const short MinValue = unchecked((short)0x8000);
    
    private readonly short _value;

}