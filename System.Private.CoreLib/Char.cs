namespace System;

public readonly struct Char
{
 
    private readonly char _value;
    
    public static bool IsWhiteSpace(char c)
    {
        return c == ' ' || c - '\t' < 5;
    }
    
}