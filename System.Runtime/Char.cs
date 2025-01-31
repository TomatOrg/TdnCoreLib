namespace System;

public readonly struct Char
{
 
    public static bool IsWhiteSpace(char c)
    {
        return c == ' ' || c - '\t' < 5;
    }
    
}