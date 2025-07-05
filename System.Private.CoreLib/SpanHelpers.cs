using System.Runtime.CompilerServices;

namespace System;

internal static partial class SpanHelpers
{
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void ClearWithoutReferences(ref byte b, nuint byteLength);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void ClearWithReferences(ref IntPtr ip, nuint pointerSizeLength);

}