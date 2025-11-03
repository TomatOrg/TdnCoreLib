using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public abstract class Array
{
    
    internal const int IntrosortSizeThreshold = 16;
    
    private static class EmptyArray<T>
    {
        internal static readonly T[] Value = new T[0];
    }

    public static T[] Empty<T>()
    {
        return EmptyArray<T>.Value;
    }

    private int _length;
    internal int _subLength;
    
    public int Length => _length;
    
    internal Array()
    {
    }
    
    public static int IndexOf<T>(T[]? array, T value, int startIndex, int count)
    {
        if (array == null)
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
        // if (array.Rank != 1)
        //     ThrowHelper.ThrowRankException(ExceptionResource.Rank_MultiDimNotSupported);

        // int lb = array.GetLowerBound(0);
        int lb = 0;
        if (startIndex < lb || startIndex > array.Length + lb)
            ThrowHelper.ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_IndexMustBeLessOrEqual();
        if (count < 0 || count > array.Length - startIndex + lb)
            ThrowHelper.ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count();
        
        int endIndex = startIndex + count;
        for (int i = startIndex; i < endIndex; i++)
        {
            var obj = array[i];
            if (obj != null && obj.Equals(value))
                return i;
        }

        return lb - 1;
    }
    
    public static void Copy<T>(T[] sourceArray, T[] destinationArray, long length)
    {
        int ilength = (int)length;
        if (length != ilength)
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length, ExceptionResource.ArgumentOutOfRange_HugeArrayNotSupported);

        Copy(sourceArray, destinationArray, ilength);
    }

    public static void Copy<T>(T[] sourceArray, T[] destinationArray, int length)
    {
        Copy(sourceArray, 0, destinationArray, 0, length);
    }
    
    public static void Copy<T>(T[] sourceArray, int sourceIndex, T[] destinationArray, int destinationIndex, int length)
    {
        if (sourceArray == null)
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.sourceArray);
        if (destinationArray == null)
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.destinationArray);

        ArgumentOutOfRangeException.ThrowIfNegative(length);

        // int srcLB = sourceArray.GetLowerBound(0);
        int srcLB = 0;
        ArgumentOutOfRangeException.ThrowIfLessThan(sourceIndex, srcLB);
        ArgumentOutOfRangeException.ThrowIfNegative(sourceIndex - srcLB, nameof(sourceIndex));
        sourceIndex -= srcLB;
        
        // int dstLB = destinationArray.GetLowerBound(0);
        int dstLB = 0;
        ArgumentOutOfRangeException.ThrowIfLessThan(destinationIndex, dstLB);
        ArgumentOutOfRangeException.ThrowIfNegative(destinationIndex - dstLB, nameof(destinationIndex));
        destinationIndex -= dstLB;
        
        if ((uint)(sourceIndex + length) > (nuint)sourceArray._length)
            throw new ArgumentException(SR.Arg_LongerThanSrcArray, nameof(sourceArray));
        if ((uint)(destinationIndex + length) > (nuint)destinationArray._length)
            throw new ArgumentException(SR.Arg_LongerThanDestArray, nameof(destinationArray));

        Buffer.Memmove(ref destinationArray[destinationIndex], ref sourceArray[sourceIndex], (nuint)length);
    }
    
    public static void Resize<T>([NotNull] ref T[]? array, int newSize)
    {
        if (newSize < 0)
            ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.newSize, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);

        T[]? larray = array; // local copy
        if (larray == null)
        {
            array = new T[newSize];
            return;
        }

        if (larray.Length != newSize)
        {
            // Due to array variance, it's possible that the incoming array is
            // actually of type U[], where U:T; or that an int[] <-> uint[] or
            // similar cast has occurred. In any case, since it's always legal
            // to reinterpret U as T in this scenario (but not necessarily the
            // other way around), we can use Buffer.Memmove here.

            T[] newArray = new T[newSize];
            Buffer.Memmove(
                ref MemoryMarshal.GetArrayDataReference(newArray),
                ref MemoryMarshal.GetArrayDataReference(larray),
                (uint)Math.Min(newSize, larray.Length));
            array = newArray;
        }

        Debug.Assert(array != null);
    }
    
    public object Clone()
    {
        return MemberwiseClone();
    }
    
}