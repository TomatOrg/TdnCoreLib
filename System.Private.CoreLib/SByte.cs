namespace System;

public readonly struct SByte
{
    public const sbyte MaxValue = (sbyte)0x7F;
    public const sbyte MinValue = unchecked((sbyte)0x80);

    private readonly sbyte _value;
    
}