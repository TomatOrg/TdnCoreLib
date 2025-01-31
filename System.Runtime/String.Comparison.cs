namespace System;

public partial class String
{
    
    public static bool operator ==(string? a, string? b) => Equals(a, b);
    public static bool operator !=(string? a, string? b) => !Equals(a, b);

    
}