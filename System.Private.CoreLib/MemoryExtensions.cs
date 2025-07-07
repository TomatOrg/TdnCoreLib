using System.Runtime.CompilerServices;

namespace System;

public static class MemoryExtensions
{
    
    /// <summary>
    /// Creates a new span over the portion of the target array.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<T> AsSpan<T>(this T[]? array, int start)
    {
        if (array == null)
        {
            if (start != 0)
                ThrowHelper.ThrowArgumentOutOfRangeException();
            return default;
        }
        if ((uint)start > (uint)array.Length)
            ThrowHelper.ThrowArgumentOutOfRangeException();

        return new Span<T>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), (nint)(uint)start /* force zero-extension */), array.Length - start);
    }

    /// <summary>
    /// Creates a new span over the portion of the target array.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<T> AsSpan<T>(this T[]? array, Index startIndex)
    {
        if (array == null)
        {
            if (!startIndex.Equals(Index.Start))
                ThrowHelper.ThrowArgumentNullException(nameof(array));

            return default;
        }

        int actualIndex = startIndex.GetOffset(array.Length);
        if ((uint)actualIndex > (uint)array.Length)
            ThrowHelper.ThrowArgumentOutOfRangeException();

        return new Span<T>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), (nint)(uint)actualIndex /* force zero-extension */), array.Length - actualIndex);
    }

    /// <summary>
    /// Creates a new span over the portion of the target array.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<T> AsSpan<T>(this T[]? array, Range range)
    {
        if (array == null)
        {
            Index startIndex = range.Start;
            Index endIndex = range.End;

            if (!startIndex.Equals(Index.Start) || !endIndex.Equals(Index.Start))
                ThrowHelper.ThrowArgumentNullException(nameof(array));

            return default;
        }

        (int start, int length) = range.GetOffsetAndLength(array.Length);
        return new Span<T>(ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), (nint)(uint)start /* force zero-extension */), length);
    }
    
    //
    //  Overlaps
    //  ========
    //
    //  The following methods can be used to determine if two sequences
    //  overlap in memory.
    //
    //  Two sequences overlap if they have positions in common and neither
    //  is empty. Empty sequences do not overlap with any other sequence.
    //
    //  If two sequences overlap, the element offset is the number of
    //  elements by which the second sequence is offset from the first
    //  sequence (i.e., second minus first). An exception is thrown if the
    //  number is not a whole number, which can happen when a sequence of a
    //  smaller type is cast to a sequence of a larger type with unsafe code
    //  or NonPortableCast. If the sequences do not overlap, the offset is
    //  meaningless and arbitrarily set to zero.
    //
    //  Implementation
    //  --------------
    //
    //  Implementing this correctly is quite tricky due of two problems:
    //
    //  * If the sequences refer to two different objects on the managed
    //    heap, the garbage collector can move them freely around or change
    //    their relative order in memory.
    //
    //  * The distance between two sequences can be greater than
    //    int.MaxValue (on a 32-bit system) or long.MaxValue (on a 64-bit
    //    system).
    //
    //  (For simplicity, the following text assumes a 32-bit system, but
    //  everything also applies to a 64-bit system if every 32 is replaced a
    //  64.)
    //
    //  The first problem is solved by calculating the distance with exactly
    //  one atomic operation. If the garbage collector happens to move the
    //  sequences afterwards and the sequences overlapped before, they will
    //  still overlap after the move and their distance hasn't changed. If
    //  the sequences did not overlap, the distance can change but the
    //  sequences still won't overlap.
    //
    //  The second problem is solved by making all addresses relative to the
    //  start of the first sequence and performing all operations in
    //  unsigned integer arithmetic modulo 2^32.
    //
    //  Example
    //  -------
    //
    //  Let's say there are two sequences, x and y. Let
    //
    //      ref T xRef = MemoryMarshal.GetReference(x)
    //      uint xLength = x.Length * sizeof(T)
    //      ref T yRef = MemoryMarshal.GetReference(y)
    //      uint yLength = y.Length * sizeof(T)
    //
    //  Visually, the two sequences are located somewhere in the 32-bit
    //  address space as follows:
    //
    //      [----------------------------------------------)                            normal address space
    //      0                                             2^32
    //                            [------------------)                                  first sequence
    //                            xRef            xRef + xLength
    //              [--------------------------)     .                                  second sequence
    //              yRef          .         yRef + yLength
    //              :             .            .     .
    //              :             .            .     .
    //                            .            .     .
    //                            .            .     .
    //                            .            .     .
    //                            [----------------------------------------------)      relative address space
    //                            0            .     .                          2^32
    //                            [------------------)             :                    first sequence
    //                            x1           .     x2            :
    //                            -------------)                   [-------------       second sequence
    //                                         y2                  y1
    //
    //  The idea is to make all addresses relative to xRef: Let x1 be the
    //  start address of x in this relative address space, x2 the end
    //  address of x, y1 the start address of y, and y2 the end address of
    //  y:
    //
    //      nuint x1 = 0
    //      nuint x2 = xLength
    //      nuint y1 = (nuint)Unsafe.ByteOffset(xRef, yRef)
    //      nuint y2 = y1 + yLength
    //
    //  xRef relative to xRef is 0.
    //
    //  x2 is simply x1 + xLength. This cannot overflow.
    //
    //  yRef relative to xRef is (yRef - xRef). If (yRef - xRef) is
    //  negative, casting it to an unsigned 32-bit integer turns it into
    //  (yRef - xRef + 2^32). So, in the example above, y1 moves to the right
    //  of x2.
    //
    //  y2 is simply y1 + yLength. Note that this can overflow, as in the
    //  example above, which must be avoided.
    //
    //  The two sequences do *not* overlap if y is entirely in the space
    //  right of x in the relative address space. (It can't be left of it!)
    //
    //          (y1 >= x2) && (y2 <= 2^32)
    //
    //  Inversely, they do overlap if
    //
    //          (y1 < x2) || (y2 > 2^32)
    //
    //  After substituting x2 and y2 with their respective definition:
    //
    //      == (y1 < xLength) || (y1 + yLength > 2^32)
    //
    //  Since yLength can't be greater than the size of the address space,
    //  the overflow can be avoided as follows:
    //
    //      == (y1 < xLength) || (y1 > 2^32 - yLength)
    //
    //  However, 2^32 cannot be stored in an unsigned 32-bit integer, so one
    //  more change is needed to keep doing everything with unsigned 32-bit
    //  integers:
    //
    //      == (y1 < xLength) || (y1 > -yLength)
    //
    //  Due to modulo arithmetic, this gives exactly same result *except* if
    //  yLength is zero, since 2^32 - 0 is 0 and not 2^32. So the case
    //  y.IsEmpty must be handled separately first.
    //

    /// <summary>
    /// Determines whether two sequences overlap in memory.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Overlaps<T>(this Span<T> span, ReadOnlySpan<T> other)
    {
        return Overlaps((ReadOnlySpan<T>)span, other);
    }

    /// <summary>
    /// Determines whether two sequences overlap in memory and outputs the element offset.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Overlaps<T>(this Span<T> span, ReadOnlySpan<T> other, out int elementOffset)
    {
        return Overlaps((ReadOnlySpan<T>)span, other, out elementOffset);
    }

    /// <summary>
    /// Determines whether two sequences overlap in memory.
    /// </summary>
    public static unsafe bool Overlaps<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> other)
    {
        if (span.IsEmpty || other.IsEmpty)
        {
            return false;
        }

        nint byteOffset = Unsafe.ByteOffset(
            ref MemoryMarshal.GetReference(span),
            ref MemoryMarshal.GetReference(other));

        return (nuint)byteOffset < (nuint)((nint)span.Length * sizeof(T)) ||
                (nuint)byteOffset > (nuint)(-((nint)other.Length * sizeof(T)));
    }

    /// <summary>
    /// Determines whether two sequences overlap in memory and outputs the element offset.
    /// </summary>
    public static unsafe bool Overlaps<T>(this ReadOnlySpan<T> span, ReadOnlySpan<T> other, out int elementOffset)
    {
        if (span.IsEmpty || other.IsEmpty)
        {
            elementOffset = 0;
            return false;
        }

        nint byteOffset = Unsafe.ByteOffset(
            ref MemoryMarshal.GetReference(span),
            ref MemoryMarshal.GetReference(other));

        if ((nuint)byteOffset < (nuint)((nint)span.Length * sizeof(T)) ||
            (nuint)byteOffset > (nuint)(-((nint)other.Length * sizeof(T))))
        {
            if (byteOffset % sizeof(T) != 0)
                ThrowHelper.ThrowArgumentException_OverlapAlignmentMismatch();

            elementOffset = (int)(byteOffset / sizeof(T));
            return true;
        }
        else
        {
            elementOffset = 0;
            return false;
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept<T>(this Span<T> span, T value) where T : IEquatable<T>? =>
        throw new NotImplementedException();
 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAnyExcept<T>(this ReadOnlySpan<T> span, T value) where T : IEquatable<T>? =>
        throw new NotImplementedException();

    
}