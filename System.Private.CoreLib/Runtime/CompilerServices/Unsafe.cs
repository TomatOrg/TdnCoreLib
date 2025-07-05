using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.CompilerServices;

public static unsafe class Unsafe
{
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void* AsPointer<T>(ref T value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int SizeOf<T>()
    {
        return sizeof(T);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    [return: NotNullIfNotNull(nameof(o))]
    public static extern T As<T>(object? o) where T : class?;

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern ref TTo As<TFrom, TTo>(ref TFrom source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T Add<T>(ref T source, int elementOffset)
    {
        return ref AddByteOffset(ref source, elementOffset * (nint)sizeof(T));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T Add<T>(ref T source, IntPtr elementOffset)
    {
        return ref AddByteOffset(ref source, elementOffset * sizeof(T));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* Add<T>(void* source, int elementOffset)
    {
        return (byte*)source + elementOffset * (nint)sizeof(T);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T Add<T>(ref T source, nuint elementOffset)
    {
        return ref AddByteOffset(ref source, elementOffset * (nuint)sizeof(T));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T AddByteOffset<T>(ref T source, nuint byteOffset)
    {
        return ref AddByteOffset(ref source, (IntPtr)(void*)byteOffset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern bool AreSame<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo BitCast<TFrom, TTo>(TFrom source)
        where TFrom : struct
        where TTo : struct
    {
        if (sizeof(TFrom) != sizeof(TTo)) ThrowHelper.ThrowNotSupportedException();
        return ReadUnaligned<TTo>(ref As<TFrom, byte>(ref source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void Copy<T>(void* destination, ref readonly T source);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void Copy<T>(ref T destination, void* source);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void CopyBlock(void* destination, void* source, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void CopyBlock(ref byte destination, ref readonly byte source, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void CopyBlockUnaligned(void* destination, void* source, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void CopyBlockUnaligned(ref byte destination, ref readonly byte source, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern bool IsAddressGreaterThan<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern bool IsAddressLessThan<T>([AllowNull] ref readonly T left, [AllowNull] ref readonly T right);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void InitBlock(void* startAddress, byte value, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void InitBlock(ref byte startAddress, byte value, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void InitBlockUnaligned(void* startAddress, byte value, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void InitBlockUnaligned(ref byte startAddress, byte value, uint byteCount);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ReadUnaligned<T>(void* source)
    {
        return *(T*)source;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ReadUnaligned<T>(ref readonly byte source)
    {
        return As<byte, T>(ref AsRef(in source));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUnaligned<T>(void* destination, T value)
    {
        *(T*)destination = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUnaligned<T>(ref byte destination, T value)
    {
        As<byte, T>(ref destination) = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern ref T AddByteOffset<T>(ref T source, IntPtr byteOffset);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Read<T>(void* source)
    {
        return *(T*)source;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write<T>(void* destination, T value)
    {
        *(T*)destination = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T AsRef<T>(void* source)
    {
        return ref *(T*)source;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern ref T AsRef<T>(scoped ref readonly T source);

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern IntPtr ByteOffset<T>([AllowNull] ref readonly T origin, [AllowNull] ref readonly T target);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T NullRef<T>()
    {
        return ref AsRef<T>(null);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullRef<T>(ref readonly T source)
    {
        return AsPointer(ref AsRef(in source)) == null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern void SkipInit<T>(out T value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T Subtract<T>(ref T source, int elementOffset)
    {
        return ref SubtractByteOffset(ref source, elementOffset * (nint)sizeof(T));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void* Subtract<T>(void* source, int elementOffset)
    {
        return (byte*)source - elementOffset * (nint)sizeof(T);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T Subtract<T>(ref T source, IntPtr elementOffset)
    {
        return ref SubtractByteOffset(ref source, elementOffset * sizeof(T));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T Subtract<T>(ref T source, nuint elementOffset)
    {
        return ref SubtractByteOffset(ref source, elementOffset * (nuint)sizeof(T));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern ref T SubtractByteOffset<T>(ref T source, IntPtr byteOffset);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T SubtractByteOffset<T>(ref T source, nuint byteOffset)
    {
        return ref SubtractByteOffset(ref source, (IntPtr)(void*)byteOffset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern ref T Unbox<T>(object box) where T : struct;
}