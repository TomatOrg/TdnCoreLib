using System.Runtime.CompilerServices;

namespace System;

public static class Buffer
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static unsafe void Memmove<T>(ref T destination, ref T source, nuint elementCount)
    {
        if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
            // Blittable memmove
            Memmove(
                ref Unsafe.As<T, byte>(ref destination),
                ref Unsafe.As<T, byte>(ref source),
                elementCount * (nuint)sizeof(T));
        }
        else
        {
            // Non-blittable memmove
            BulkMoveWithWriteBarrier(
                ref Unsafe.As<T, byte>(ref destination),
                ref Unsafe.As<T, byte>(ref source),
                elementCount * (nuint)sizeof(T));
        }
    }
    
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    internal static extern void Memmove(ref byte dest, ref byte src, nuint len);
    
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    internal static extern void BulkMoveWithWriteBarrier(ref byte destination, ref byte source, nuint byteCount);

}