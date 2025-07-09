// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using System.Runtime.CompilerServices;

#pragma warning disable 8500 // sizeof of managed types

namespace System;

internal static partial class SpanHelpers
{
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern void ClearWithoutReferences(ref byte b, nuint byteLength);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern void ClearWithReferences(ref IntPtr ip, nuint pointerSizeLength);
    
    public static void Reverse(ref int buf, nuint length)
    {
        Debug.Assert(length > 1);

        nint remainder = (nint)length;
        nint offset = 0;

        // if (Vector512.IsHardwareAccelerated && remainder >= Vector512<int>.Count * 2)
        // {
        //     nint lastOffset = remainder - Vector512<int>.Count;
        //     do
        //     {
        //         // Load in values from beginning and end of the array.
        //         Vector512<int> tempFirst = Vector512.LoadUnsafe(ref buf, (nuint)offset);
        //         Vector512<int> tempLast = Vector512.LoadUnsafe(ref buf, (nuint)lastOffset);
        //
        //         // Shuffle to reverse each vector:
        //         //     +---------------+
        //         //     | A | B | C | D |
        //         //     +---------------+
        //         //          --->
        //         //     +---------------+
        //         //     | D | C | B | A |
        //         //     +---------------+
        //         tempFirst = Vector512.Shuffle(tempFirst, Vector512.Create(15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0));
        //         tempLast = Vector512.Shuffle(tempLast, Vector512.Create(15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0));
        //
        //         // Store the reversed vectors
        //         tempLast.StoreUnsafe(ref buf, (nuint)offset);
        //         tempFirst.StoreUnsafe(ref buf, (nuint)lastOffset);
        //
        //         offset += Vector512<int>.Count;
        //         lastOffset -= Vector512<int>.Count;
        //     } while (lastOffset >= offset);
        //
        //     remainder = lastOffset + Vector512<int>.Count - offset;
        // }
        // else if (Avx2.IsSupported && remainder >= Vector256<int>.Count * 2)
        // {
        //     nint lastOffset = remainder - Vector256<int>.Count;
        //     do
        //     {
        //         // Load the values into vectors
        //         Vector256<int> tempFirst = Vector256.LoadUnsafe(ref buf, (nuint)offset);
        //         Vector256<int> tempLast = Vector256.LoadUnsafe(ref buf, (nuint)lastOffset);
        //
        //         // Permute to reverse each vector:
        //         //     +-------------------------------+
        //         //     | A | B | C | D | E | F | G | H |
        //         //     +-------------------------------+
        //         //         --->
        //         //     +-------------------------------+
        //         //     | H | G | F | E | D | C | B | A |
        //         //     +-------------------------------+
        //         tempFirst = Avx2.PermuteVar8x32(tempFirst, Vector256.Create(7, 6, 5, 4, 3, 2, 1, 0));
        //         tempLast = Avx2.PermuteVar8x32(tempLast, Vector256.Create(7, 6, 5, 4, 3, 2, 1, 0));
        //
        //         // Store the reversed vectors
        //         tempLast.StoreUnsafe(ref buf, (nuint)offset);
        //         tempFirst.StoreUnsafe(ref buf, (nuint)lastOffset);
        //
        //         offset += Vector256<int>.Count;
        //         lastOffset -= Vector256<int>.Count;
        //     } while (lastOffset >= offset);
        //
        //     remainder = lastOffset + Vector256<int>.Count - offset;
        // }
        // else if (Vector128.IsHardwareAccelerated && remainder >= Vector128<int>.Count * 2)
        // {
        //     nint lastOffset = remainder - Vector128<int>.Count;
        //     do
        //     {
        //         // Load in values from beginning and end of the array.
        //         Vector128<int> tempFirst = Vector128.LoadUnsafe(ref buf, (nuint)offset);
        //         Vector128<int> tempLast = Vector128.LoadUnsafe(ref buf, (nuint)lastOffset);
        //
        //         // Shuffle to reverse each vector:
        //         //     +---------------+
        //         //     | A | B | C | D |
        //         //     +---------------+
        //         //          --->
        //         //     +---------------+
        //         //     | D | C | B | A |
        //         //     +---------------+
        //         tempFirst = Vector128.Shuffle(tempFirst, Vector128.Create(3, 2, 1, 0));
        //         tempLast = Vector128.Shuffle(tempLast, Vector128.Create(3, 2, 1, 0));
        //
        //         // Store the reversed vectors
        //         tempLast.StoreUnsafe(ref buf, (nuint)offset);
        //         tempFirst.StoreUnsafe(ref buf, (nuint)lastOffset);
        //
        //         offset += Vector128<int>.Count;
        //         lastOffset -= Vector128<int>.Count;
        //     } while (lastOffset >= offset);
        //
        //     remainder = lastOffset + Vector128<int>.Count - offset;
        // }

        // Store any remaining values one-by-one
        if (remainder > 1)
        {
            ReverseInner(ref Unsafe.Add(ref buf, offset), (nuint)remainder);
        }
    }

    public static void Reverse(ref long buf, nuint length)
    {
        Debug.Assert(length > 1);

        nint remainder = (nint)length;
        nint offset = 0;

        // if (Vector512.IsHardwareAccelerated && remainder >= Vector512<long>.Count * 2)
        // {
        //     nint lastOffset = remainder - Vector512<long>.Count;
        //     do
        //     {
        //         // Load in values from beginning and end of the array.
        //         Vector512<long> tempFirst = Vector512.LoadUnsafe(ref buf, (nuint)offset);
        //         Vector512<long> tempLast = Vector512.LoadUnsafe(ref buf, (nuint)lastOffset);
        //
        //         // Shuffle to reverse each vector:
        //         //     +-------+
        //         //     | A | B |
        //         //     +-------+
        //         //          --->
        //         //     +-------+
        //         //     | B | A |
        //         //     +-------+
        //         tempFirst = Vector512.Shuffle(tempFirst, Vector512.Create(7, 6, 5, 4, 3, 2, 1, 0));
        //         tempLast = Vector512.Shuffle(tempLast, Vector512.Create(7, 6, 5, 4, 3, 2, 1, 0));
        //
        //         // Store the reversed vectors
        //         tempLast.StoreUnsafe(ref buf, (nuint)offset);
        //         tempFirst.StoreUnsafe(ref buf, (nuint)lastOffset);
        //
        //         offset += Vector512<long>.Count;
        //         lastOffset -= Vector512<long>.Count;
        //     } while (lastOffset >= offset);
        //
        //     remainder = lastOffset + Vector512<long>.Count - offset;
        // }
        // else if (Avx2.IsSupported && remainder >= Vector256<long>.Count * 2)
        // {
        //     nint lastOffset = remainder - Vector256<long>.Count;
        //     do
        //     {
        //         // Load the values into vectors
        //         Vector256<long> tempFirst = Vector256.LoadUnsafe(ref buf, (nuint)offset);
        //         Vector256<long> tempLast = Vector256.LoadUnsafe(ref buf, (nuint)lastOffset);
        //
        //         // Permute to reverse each vector:
        //         //     +---------------+
        //         //     | A | B | C | D |
        //         //     +---------------+
        //         //         --->
        //         //     +---------------+
        //         //     | D | C | B | A |
        //         //     +---------------+
        //         tempFirst = Avx2.Permute4x64(tempFirst, 0b00_01_10_11);
        //         tempLast = Avx2.Permute4x64(tempLast, 0b00_01_10_11);
        //
        //         // Store the reversed vectors
        //         tempLast.StoreUnsafe(ref buf, (nuint)offset);
        //         tempFirst.StoreUnsafe(ref buf, (nuint)lastOffset);
        //
        //         offset += Vector256<long>.Count;
        //         lastOffset -= Vector256<long>.Count;
        //     } while (lastOffset >= offset);
        //
        //     remainder = lastOffset + Vector256<long>.Count - offset;
        // }
        // else if (Vector128.IsHardwareAccelerated && remainder >= Vector128<long>.Count * 2)
        // {
        //     nint lastOffset = remainder - Vector128<long>.Count;
        //     do
        //     {
        //         // Load in values from beginning and end of the array.
        //         Vector128<long> tempFirst = Vector128.LoadUnsafe(ref buf, (nuint)offset);
        //         Vector128<long> tempLast = Vector128.LoadUnsafe(ref buf, (nuint)lastOffset);
        //
        //         // Shuffle to reverse each vector:
        //         //     +-------+
        //         //     | A | B |
        //         //     +-------+
        //         //          --->
        //         //     +-------+
        //         //     | B | A |
        //         //     +-------+
        //         tempFirst = Vector128.Shuffle(tempFirst, Vector128.Create(1, 0));
        //         tempLast = Vector128.Shuffle(tempLast, Vector128.Create(1, 0));
        //
        //         // Store the reversed vectors
        //         tempLast.StoreUnsafe(ref buf, (nuint)offset);
        //         tempFirst.StoreUnsafe(ref buf, (nuint)lastOffset);
        //
        //         offset += Vector128<long>.Count;
        //         lastOffset -= Vector128<long>.Count;
        //     } while (lastOffset >= offset);
        //
        //     remainder = lastOffset + Vector128<long>.Count - offset;
        // }

        // Store any remaining values one-by-one
        if (remainder > 1)
        {
            ReverseInner(ref Unsafe.Add(ref buf, offset), (nuint)remainder);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe void Reverse<T>(ref T elements, nuint length)
    {
        Debug.Assert(length > 1);

        if (!RuntimeHelpers.IsReferenceOrContainsReferences<T>())
        {
            if (sizeof(T) == sizeof(byte))
            {
                Reverse(ref Unsafe.As<T, byte>(ref elements), length);
                return;
            }
            else if (sizeof(T) == sizeof(char))
            {
                Reverse(ref Unsafe.As<T, char>(ref elements), length);
                return;
            }
            else if (sizeof(T) == sizeof(int))
            {
                Reverse(ref Unsafe.As<T, int>(ref elements), length);
                return;
            }
            else if (sizeof(T) == sizeof(long))
            {
                Reverse(ref Unsafe.As<T, long>(ref elements), length);
                return;
            }
        }

        ReverseInner(ref elements, length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void ReverseInner<T>(ref T elements, nuint length)
    {
        Debug.Assert(length > 1);

        ref T first = ref elements;
        ref T last = ref Unsafe.Subtract(ref Unsafe.Add(ref first, length), 1);
        do
        {
            T temp = first;
            first = last;
            last = temp;
            first = ref Unsafe.Add(ref first, 1);
            last = ref Unsafe.Subtract(ref last, 1);
        } while (Unsafe.IsAddressLessThan(ref first, ref last));
    }
}