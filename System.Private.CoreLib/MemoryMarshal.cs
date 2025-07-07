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
    internal static extern ref T GetArrayDataReference<T>(T[] array);

    internal static ref byte GetArrayDataReference(Array array)
    {
        var type = Unsafe.As<RuntimeTypeInfo>(array.GetType());
        var align = type._stackAlignment;
        var offset = (((16 + 8) + align - 1) & ~(align - 1)) - 16;
        return ref Unsafe.AddByteOffset(ref Unsafe.As<RawData>(array).Data, offset);
    }
    
    /// <summary>
    /// Returns a reference to the 0th element of the Span. If the Span is empty, returns a reference to the location where the 0th element
    /// would have been stored. Such a reference may or may not be null. It can be used for pinning but must never be dereferenced.
    /// </summary>
    internal static ref T GetReference<T>(Span<T> span) => ref span._reference;

    /// <summary>
    /// Returns a reference to the 0th element of the ReadOnlySpan. If the ReadOnlySpan is empty, returns a reference to the location where the 0th element
    /// would have been stored. Such a reference may or may not be null. It can be used for pinning but must never be dereferenced.
    /// </summary>
    internal static ref T GetReference<T>(ReadOnlySpan<T> span) => ref span._reference;
    
    /// <summary>
    /// Casts a Span of one primitive type <typeparamref name="TFrom"/> to another primitive type <typeparamref name="TTo"/>.
    /// These types may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <remarks>
    /// Supported only for platforms that support misaligned memory access or when the memory block is aligned by other means.
    /// </remarks>
    /// <param name="span">The source slice, of type <typeparamref name="TFrom"/>.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <typeparamref name="TFrom"/> or <typeparamref name="TTo"/> contains pointers.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<TTo> Cast<TFrom, TTo>(Span<TFrom> span)
        where TFrom : unmanaged
        where TTo : unmanaged
    {
        // Use unsigned integers - unsigned division by constant (especially by power of 2)
        // and checked casts are faster and smaller.
        uint fromSize = (uint)Unsafe.SizeOf<TFrom>();
        uint toSize = (uint)Unsafe.SizeOf<TTo>();
        uint fromLength = (uint)span.Length;
        int toLength;
        if (fromSize == toSize)
        {
            // Special case for same size types - `(ulong)fromLength * (ulong)fromSize / (ulong)toSize`
            // should be optimized to just `length` but the JIT doesn't do that today.
            toLength = (int)fromLength;
        }
        else if (fromSize == 1)
        {
            // Special case for byte sized TFrom - `(ulong)fromLength * (ulong)fromSize / (ulong)toSize`
            // becomes `(ulong)fromLength / (ulong)toSize` but the JIT can't narrow it down to `int`
            // and can't eliminate the checked cast. This also avoids a 32 bit specific issue,
            // the JIT can't eliminate long multiply by 1.
            toLength = (int)(fromLength / toSize);
        }
        else
        {
            // Ensure that casts are done in such a way that the JIT is able to "see"
            // the uint->ulong casts and the multiply together so that on 32 bit targets
            // 32x32to64 multiplication is used.
            ulong toLengthUInt64 = (ulong)fromLength * (ulong)fromSize / (ulong)toSize;
            toLength = checked((int)toLengthUInt64);
        }

        return new Span<TTo>(
            ref Unsafe.As<TFrom, TTo>(ref span._reference),
            toLength);
    }

    /// <summary>
    /// Casts a ReadOnlySpan of one primitive type <typeparamref name="TFrom"/> to another primitive type <typeparamref name="TTo"/>.
    /// These types may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <remarks>
    /// Supported only for platforms that support misaligned memory access or when the memory block is aligned by other means.
    /// </remarks>
    /// <param name="span">The source slice, of type <typeparamref name="TFrom"/>.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <typeparamref name="TFrom"/> or <typeparamref name="TTo"/> contains pointers.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlySpan<TTo> Cast<TFrom, TTo>(ReadOnlySpan<TFrom> span)
        where TFrom : unmanaged
        where TTo : unmanaged
    {
        // Use unsigned integers - unsigned division by constant (especially by power of 2)
        // and checked casts are faster and smaller.
        uint fromSize = (uint)Unsafe.SizeOf<TFrom>();
        uint toSize = (uint)Unsafe.SizeOf<TTo>();
        uint fromLength = (uint)span.Length;
        int toLength;
        if (fromSize == toSize)
        {
            // Special case for same size types - `(ulong)fromLength * (ulong)fromSize / (ulong)toSize`
            // should be optimized to just `length` but the JIT doesn't do that today.
            toLength = (int)fromLength;
        }
        else if (fromSize == 1)
        {
            // Special case for byte sized TFrom - `(ulong)fromLength * (ulong)fromSize / (ulong)toSize`
            // becomes `(ulong)fromLength / (ulong)toSize` but the JIT can't narrow it down to `int`
            // and can't eliminate the checked cast. This also avoids a 32 bit specific issue,
            // the JIT can't eliminate long multiply by 1.
            toLength = (int)(fromLength / toSize);
        }
        else
        {
            // Ensure that casts are done in such a way that the JIT is able to "see"
            // the uint->ulong casts and the multiply together so that on 32 bit targets
            // 32x32to64 multiplication is used.
            ulong toLengthUInt64 = (ulong)fromLength * (ulong)fromSize / (ulong)toSize;
            toLength = checked((int)toLengthUInt64);
        }

        return new ReadOnlySpan<TTo>(
            ref Unsafe.As<TFrom, TTo>(ref GetReference(span)),
            toLength);
    }

}