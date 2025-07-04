using System.Runtime.CompilerServices;

namespace System;

public static class Buffer
{

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    internal static extern void Memmove(ref byte dest, ref byte src, nuint len);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    internal static extern void BulkMoveWithWriteBarrier(ref byte destination, ref byte source, nuint byteCount);

}