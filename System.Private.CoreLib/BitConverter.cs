using System.Runtime.CompilerServices;

namespace System;

public static class BitConverter
{
    
    public static long DoubleToInt64Bits(double value) => Unsafe.BitCast<double, long>(value);
    public static double Int64BitsToDouble(long value) => Unsafe.BitCast<long, double>(value);
    public static int SingleToInt32Bits(float value) => Unsafe.BitCast<float, int>(value);
    public static float Int32BitsToSingle(int value) => Unsafe.BitCast<int, float>(value);
    public static ulong DoubleToUInt64Bits(double value) => Unsafe.BitCast<double, ulong>(value);
    public static double UInt64BitsToDouble(ulong value) => Unsafe.BitCast<ulong, double>(value);
    public static uint SingleToUInt32Bits(float value) => Unsafe.BitCast<float, uint>(value);
    public static float UInt32BitsToSingle(uint value) => Unsafe.BitCast<uint, float>(value);

}