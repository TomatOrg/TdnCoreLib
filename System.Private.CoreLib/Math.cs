using System.Runtime.CompilerServices;

namespace System;

public static class Math
{
    
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Sqrt(double d);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Abs(double value)
    {
        const ulong mask = 0x7FFFFFFFFFFFFFFF;
        var raw = BitConverter.DoubleToUInt64Bits(value);
        return BitConverter.UInt64BitsToDouble(raw & mask);
    }

}