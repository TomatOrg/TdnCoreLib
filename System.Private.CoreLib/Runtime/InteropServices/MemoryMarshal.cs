// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class RawData
{
    public byte Data;
}

/// <summary>
/// Provides a collection of methods for interoperating with <see cref="Memory{T}"/>, <see cref="ReadOnlyMemory{T}"/>,
/// <see cref="Span{T}"/>, and <see cref="ReadOnlySpan{T}"/>.
/// </summary>
public static partial class MemoryMarshal
{
    /// <summary>
    /// Casts a Span of one primitive type <typeparamref name="T"/> to Span of bytes.
    /// That type may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <param name="span">The source slice, of type <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <typeparamref name="T"/> contains pointers.
    /// </exception>
    /// <exception cref="OverflowException">
    /// Thrown if the Length property of the new Span would exceed int.MaxValue.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe Span<byte> AsBytes<T>(Span<T> span)
        where T : unmanaged
    {
        return new Span<byte>(
            ref Unsafe.As<T, byte>(ref GetReference(span)),
            checked(span.Length * sizeof(T)));
    }

    /// <summary>
    /// Casts a ReadOnlySpan of one primitive type <typeparamref name="T"/> to ReadOnlySpan of bytes.
    /// That type may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <param name="span">The source slice, of type <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <typeparamref name="T"/> contains pointers.
    /// </exception>
    /// <exception cref="OverflowException">
    /// Thrown if the Length property of the new Span would exceed int.MaxValue.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ReadOnlySpan<byte> AsBytes<T>(ReadOnlySpan<T> span)
        where T : unmanaged
    {
        return new ReadOnlySpan<byte>(
            ref Unsafe.As<T, byte>(ref GetReference(span)),
            checked(span.Length * sizeof(T)));
    }

    /// <summary>Creates a <see cref="Memory{T}"/> from a <see cref="ReadOnlyMemory{T}"/>.</summary>
    /// <param name="memory">The <see cref="ReadOnlyMemory{T}"/>.</param>
    /// <returns>A <see cref="Memory{T}"/> representing the same memory as the <see cref="ReadOnlyMemory{T}"/>, but writable.</returns>
    /// <remarks>
    /// <see cref="AsMemory{T}(ReadOnlyMemory{T})"/> must be used with extreme caution.  <see cref="ReadOnlyMemory{T}"/> is used
    /// to represent immutable data and other memory that is not meant to be written to; <see cref="Memory{T}"/> instances created
    /// by <see cref="AsMemory{T}(ReadOnlyMemory{T})"/> should not be written to.  The method exists to enable variables typed
    /// as <see cref="Memory{T}"/> but only used for reading to store a <see cref="ReadOnlyMemory{T}"/>.
    /// </remarks>
    internal static Memory<T> AsMemory<T>(ReadOnlyMemory<T> memory) =>
        Unsafe.As<ReadOnlyMemory<T>, Memory<T>>(ref memory);

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

    /// <summary>
    /// Creates a new span over a portion of a regular managed object. This can be useful
    /// if part of a managed object represents a "fixed array." This is dangerous because the
    /// <paramref name="length"/> is not checked.
    /// </summary>
    /// <param name="reference">A reference to data.</param>
    /// <param name="length">The number of <typeparamref name="T"/> elements the memory contains.</param>
    /// <returns>A span representing the specified reference and length.</returns>
    /// <remarks>
    /// This method should be used with caution. It is dangerous because the length argument is not checked.
    /// Even though the ref is annotated as scoped, it will be stored into the returned span, and the lifetime
    /// of the returned span will not be validated for safety, even by span-aware languages.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static Span<T> CreateSpan<T>(scoped ref T reference, int length) =>
        new Span<T>(ref Unsafe.AsRef(in reference), length);

    /// <summary>
    /// Creates a new read-only span over a portion of a regular managed object. This can be useful
    /// if part of a managed object represents a "fixed array." This is dangerous because the
    /// <paramref name="length"/> is not checked.
    /// </summary>
    /// <param name="reference">A reference to data.</param>
    /// <param name="length">The number of <typeparamref name="T"/> elements the memory contains.</param>
    /// <returns>A read-only span representing the specified reference and length.</returns>
    /// <remarks>
    /// This method should be used with caution. It is dangerous because the length argument is not checked.
    /// Even though the ref is annotated as scoped, it will be stored into the returned span, and the lifetime
    /// of the returned span will not be validated for safety, even by span-aware languages.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ReadOnlySpan<T> CreateReadOnlySpan<T>(scoped ref readonly T reference, int length) =>
        new ReadOnlySpan<T>(ref Unsafe.AsRef(in reference), length);

    /// <summary>
    /// Creates an <see cref="IEnumerable{T}"/> view of the given <paramref name="memory" /> to allow
    /// the <paramref name="memory" /> to be used in existing APIs that take an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The element type of the <paramref name="memory" />.</typeparam>
    /// <param name="memory">The ReadOnlyMemory to view as an <see cref="IEnumerable{T}"/></param>
    /// <returns>An <see cref="IEnumerable{T}"/> view of the given <paramref name="memory" /></returns>
    public static IEnumerable<T> ToEnumerable<T>(ReadOnlyMemory<T> memory)
    {
        object? obj = memory.GetObjectStartLength(out int index, out int length);

        // If the memory is empty, just return an empty array as the enumerable.
        if (length is 0 || obj is null)
        {
            return Array.Empty<T>();
        }

        // If the object is a string, we can optimize. If it isn't a slice, just return the string as the
        // enumerable. Otherwise, return an iterator dedicated to enumerating the object; while we could
        // use the general one for any ReadOnlyMemory, that will incur a .Span access for every element.
        if (typeof(T) == typeof(char) && obj is string str)
        {
            return (IEnumerable<T>)(object)(index == 0 && length == str.Length ?
                str :
                FromString(str, index, length));

            static IEnumerable<char> FromString(string s, int offset, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    yield return s[offset + i];
                }
            }
        }

        // // If the object is an array, we can optimize. If it isn't a slice, just return the array as the
        // // enumerable. Otherwise, return an iterator dedicated to enumerating the object.
        // if (RuntimeHelpers.ObjectHasComponentSize(obj)) // Same check as in TryGetArray to confirm that obj is a T[] or a U[] which is blittable to a T[].
        // {
        //     T[] array = Unsafe.As<T[]>(obj);
        //     index &= ReadOnlyMemory<T>.RemoveFlagsBitMask; // the array may be prepinned, so remove the high bit from the start index in the line below.
        //     return index == 0 && length == array.Length ?
        //         array :
        //         FromArray(array, index, length);
        //
        //     static IEnumerable<T> FromArray(T[] array, int offset, int count)
        //     {
        //         for (int i = 0; i < count; i++)
        //         {
        //             yield return array[offset + i];
        //         }
        //     }
        // }

        // The ROM<T> wraps a MemoryManager<T>. The best we can do is iterate, accessing .Span on each MoveNext.
        return FromMemoryManager(memory);

        static IEnumerable<T> FromMemoryManager(ReadOnlyMemory<T> memory)
        {
            for (int i = 0; i < memory.Length; i++)
            {
                yield return memory.Span[i];
            }
        }
    }

    /// <summary>Attempts to get the underlying <see cref="string"/> from a <see cref="ReadOnlyMemory{T}"/>.</summary>
    /// <param name="memory">The memory that may be wrapping a <see cref="string"/> object.</param>
    /// <param name="text">The string.</param>
    /// <param name="start">The starting location in <paramref name="text"/>.</param>
    /// <param name="length">The number of items in <paramref name="text"/>.</param>
    /// <returns></returns>
    public static bool TryGetString(ReadOnlyMemory<char> memory, [NotNullWhen(true)] out string? text, out int start, out int length)
    {
        if (memory.GetObjectStartLength(out int offset, out int count) is string s)
        {
            Debug.Assert(offset >= 0);
            Debug.Assert(count >= 0);
            text = s;
            start = offset;
            length = count;
            return true;
        }
        else
        {
            text = null;
            start = 0;
            length = 0;
            return false;
        }
    }

    /// <summary>
    /// Reads a structure of type T out of a read-only span of bytes.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe T Read<T>(ReadOnlySpan<byte> source)
        where T : unmanaged
    {
        if (sizeof(T) > source.Length)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException("length");
        }
        return Unsafe.ReadUnaligned<T>(ref GetReference(source));
    }

    /// <summary>
    /// Reads a structure of type T out of a span of bytes.
    /// </summary>
    /// <returns>If the span is too small to contain the type T, return false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe bool TryRead<T>(ReadOnlySpan<byte> source, out T value)
        where T : unmanaged
    {
        if (sizeof(T) > (uint)source.Length)
        {
            value = default;
            return false;
        }
        value = Unsafe.ReadUnaligned<T>(ref GetReference(source));
        return true;
    }

    /// <summary>
    /// Writes a structure of type T into a span of bytes.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Write<T>(Span<byte> destination, in T value)
        where T : unmanaged
    {
        if ((uint)sizeof(T) > (uint)destination.Length)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException("length");
        }
        Unsafe.WriteUnaligned(ref GetReference(destination), value);
    }

    /// <summary>
    /// Writes a structure of type T into a span of bytes.
    /// </summary>
    /// <returns>If the span is too small to contain the type T, return false.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe bool TryWrite<T>(Span<byte> destination, in T value)
        where T : unmanaged
    {
        if (sizeof(T) > (uint)destination.Length)
        {
            return false;
        }
        Unsafe.WriteUnaligned(ref GetReference(destination), value);
        return true;
    }

    /// <summary>
    /// Re-interprets a span of bytes as a reference to structure of type T.
    /// The type may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <remarks>
    /// Supported only for platforms that support misaligned memory access or when the memory block is aligned by other means.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref T AsRef<T>(Span<byte> span)
        where T : unmanaged
    {
        if (sizeof(T) > (uint)span.Length)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException("length");
        }
        return ref Unsafe.As<byte, T>(ref GetReference(span));
    }

    /// <summary>
    /// Re-interprets a span of bytes as a reference to structure of type T.
    /// The type may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <remarks>
    /// Supported only for platforms that support misaligned memory access or when the memory block is aligned by other means.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe ref readonly T AsRef<T>(ReadOnlySpan<byte> span)
        where T : unmanaged
    {
        if (sizeof(T) > (uint)span.Length)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException("length");
        }
        return ref Unsafe.As<byte, T>(ref GetReference(span));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    internal static extern ref T GetArrayDataReference<T>(T[] array);

    internal static ref byte GetArrayDataReference(Array array)
    {
        var type = Unsafe.As<RuntimeTypeInfo>(array.GetType());
        var align = type._stackAlignment;
        const int arrayHeaderSize = 24;
        var offset = (arrayHeaderSize + align - 1) & ~(align - 1);
        return ref Unsafe.AddByteOffset(ref Unsafe.As<RawData>(array).Data, offset);
    }

}