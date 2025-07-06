namespace System;

public readonly struct Double
{

    public const double MinValue = -1.7976931348623157E+308;
    public const double MaxValue = 1.7976931348623157E+308;
    
    public const double Epsilon = 4.9406564584124654E-324;
    
    private readonly double _value;
}