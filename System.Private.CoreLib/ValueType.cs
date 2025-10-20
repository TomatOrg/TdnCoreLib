using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

public class ValueType
{
    public override int GetHashCode()
    {
        var hashcode = new HashCode();
        
        // add the type itself
        var type = Unsafe.As<RuntimeTypeInfo>(GetType());
        hashcode.Add(type);
        
        // get the data reference
        var align = type._stackAlignment;
        const int objectHeaderSize = 16;
        var offset = (objectHeaderSize + align - 1) & ~(align - 1);
        ref var dataRef = ref Unsafe.AddByteOffset(ref Unsafe.As<RawData>(this).Data, offset);
        
        // add all the content into it 
        hashcode.AddBytes(new ReadOnlySpan<byte>(ref dataRef, (int)type._stackSize));
        
        // and finalize the hashcode
        return hashcode.ToHashCode();
    }
}