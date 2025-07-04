using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
internal class RawData
{
    public byte Data;
}

public static class MemoryMarshal
{
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern ref T GetArrayDataReference<T>(T[] array);

    public static ref byte GetArrayDataReference(Array array)
    {
        var type = Unsafe.As<RuntimeTypeInfo>(array.GetType());
        var align = type._stackAlignment;
        var offset = (((16 + 8) + align - 1) & ~(align - 1)) - 16;
        return ref Unsafe.AddByteOffset(ref Unsafe.As<RawData>(array).Data, offset);
    }
    
}