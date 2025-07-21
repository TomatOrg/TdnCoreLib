// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Threading;

/// <summary>Provides atomic operations for variables that are shared by multiple threads.</summary>
public static class Interlocked
{
    #region Increment
    /// <summary>Increments a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be incremented.</param>
    /// <returns>The incremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Increment(ref uint location) =>
        Add(ref location, 1);

    /// <summary>Increments a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be incremented.</param>
    /// <returns>The incremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Increment(ref ulong location) =>
        Add(ref location, 1);
        
    /// <summary>Increments a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be incremented.</param>
    /// <returns>The incremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    public static int Increment(ref int location) =>
        Add(ref location, 1);

    /// <summary>Increments a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be incremented.</param>
    /// <returns>The incremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    public static long Increment(ref long location) =>
        Add(ref location, 1);
    #endregion

    #region Decrement
    /// <summary>Decrements a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be decremented.</param>
    /// <returns>The decremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Decrement(ref uint location) =>
        (uint)Add(ref Unsafe.As<uint, int>(ref location), -1);

    /// <summary>Decrements a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be decremented.</param>
    /// <returns>The decremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Decrement(ref ulong location) =>
        (ulong)Add(ref Unsafe.As<ulong, long>(ref location), -1);
        
    /// <summary>Decrements a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be decremented.</param>
    /// <returns>The decremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    public static int Decrement(ref int location) =>
        Add(ref location, -1);

    /// <summary>Decrements a specified variable and stores the result, as an atomic operation.</summary>
    /// <param name="location">The variable whose value is to be decremented.</param>
    /// <returns>The decremented value.</returns>
    /// <exception cref="NullReferenceException">The address of location is a null pointer.</exception>
    public static long Decrement(ref long location) =>
        Add(ref location, -1);
    #endregion

    #region Exchange
    /// <summary>Sets a 32-bit unsigned integer to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Exchange(ref uint location1, uint value) =>
        (uint)Exchange(ref Unsafe.As<uint, int>(ref location1), (int)value);

    /// <summary>Sets a 64-bit unsigned integer to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Exchange(ref ulong location1, ulong value) =>
        (ulong)Exchange(ref Unsafe.As<ulong, long>(ref location1), (long)value);

    /// <summary>Sets a single-precision floating point number to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Exchange(ref float location1, float value)
        => Unsafe.BitCast<int, float>(Exchange(ref Unsafe.As<float, int>(ref location1), Unsafe.BitCast<float, int>(value)));

    /// <summary>Sets a double-precision floating point number to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Exchange(ref double location1, double value)
        => Unsafe.BitCast<long, double>(Exchange(ref Unsafe.As<double, long>(ref location1), Unsafe.BitCast<double, long>(value)));

    /// <summary>Sets a platform-specific handle or pointer to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr Exchange(ref IntPtr location1, IntPtr value)
        => (IntPtr)Interlocked.Exchange(ref Unsafe.As<IntPtr, long>(ref location1), (long)value);

    /// <summary>Sets a platform-specific handle or pointer to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr Exchange(ref UIntPtr location1, UIntPtr value)
        => (UIntPtr)Interlocked.Exchange(ref Unsafe.As<UIntPtr, long>(ref location1), (long)value);
        
    /// <summary>Sets a 32-bit signed integer to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern int Exchange(ref int location1, int value);

    /// <summary>Sets a 64-bit signed integer to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern long Exchange(ref long location1, long value);

    /// <summary>Sets an object to the specified value and returns a reference to the original object, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    [return: NotNullIfNotNull(nameof(location1))]
    public static extern object? Exchange([NotNullIfNotNull(nameof(value))] ref object? location1, object? value);

    // The below whole method reduces to a single call to Exchange(ref object, object) but
    // the JIT thinks that it will generate more native code than it actually does.

    /// <summary>Sets a variable of the specified type <typeparamref name="T"/> to a specified value and returns the original value, as an atomic operation.</summary>
    /// <param name="location1">The variable to set to the specified value.</param>
    /// <param name="value">The value to which the <paramref name="location1"/> parameter is set.</param>
    /// <returns>The original value of <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of location1 is a null pointer.</exception>
    /// <typeparam name="T">The type to be used for <paramref name="location1"/> and <paramref name="value"/>. This type must be a reference type.</typeparam>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNullIfNotNull(nameof(location1))]
    public static T Exchange<T>([NotNullIfNotNull(nameof(value))] ref T location1, T value) where T : class? =>
        Unsafe.As<T>(Exchange(ref Unsafe.As<T, object?>(ref location1), value));
    #endregion

    #region CompareExchange
    /// <summary>Compares two 32-bit signed integers for equality and, if they are equal, replaces the first value.</summary>
    /// <param name="location1">The destination, whose value is compared with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The value that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern int CompareExchange(ref int location1, int value, int comparand);

    /// <summary>Compares two 64-bit signed integers for equality and, if they are equal, replaces the first value.</summary>
    /// <param name="location1">The destination, whose value is compared with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The value that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern long CompareExchange(ref long location1, long value, long comparand);

    /// <summary>Compares two objects for reference equality and, if they are equal, replaces the first object.</summary>
    /// <param name="location1">The destination object that is compared by reference with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The object that replaces the destination object if the reference comparison results in equality.</param>
    /// <param name="comparand">The object that is compared by reference to the object at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    [return: NotNullIfNotNull(nameof(location1))]
    public static extern object? CompareExchange(ref object? location1, object? value, object? comparand);

    /// <summary>Compares two instances of the specified reference type <typeparamref name="T"/> for reference equality and, if they are equal, replaces the first one.</summary>
    /// <param name="location1">The destination, whose value is compared by reference with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The value that replaces the destination value if the comparison by reference results in equality.</param>
    /// <param name="comparand">The object that is compared by reference to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    /// <typeparam name="T">The type to be used for <paramref name="location1"/>, <paramref name="value"/>, and <paramref name="comparand"/>. This type must be a reference type.</typeparam>
    [return: NotNullIfNotNull(nameof(location1))]
    public static T CompareExchange<T>(ref T location1, T value, T comparand) where T : class? =>
        Unsafe.As<T>(CompareExchange(ref Unsafe.As<T, object?>(ref location1), value, comparand));
    #endregion

    #region CompareExchange
    /// <summary>Compares two 32-bit unsigned integers for equality and, if they are equal, replaces the first value.</summary>
    /// <param name="location1">The destination, whose value is compared with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The value that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint CompareExchange(ref uint location1, uint value, uint comparand) =>
        (uint)CompareExchange(ref Unsafe.As<uint, int>(ref location1), (int)value, (int)comparand);

    /// <summary>Compares two 64-bit unsigned integers for equality and, if they are equal, replaces the first value.</summary>
    /// <param name="location1">The destination, whose value is compared with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The value that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong CompareExchange(ref ulong location1, ulong value, ulong comparand) =>
        (ulong)CompareExchange(ref Unsafe.As<ulong, long>(ref location1), (long)value, (long)comparand);

    /// <summary>Compares two single-precision floating point numbers for equality and, if they are equal, replaces the first value.</summary>
    /// <param name="location1">The destination, whose value is compared with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The value that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float CompareExchange(ref float location1, float value, float comparand)
        => Unsafe.BitCast<int, float>(CompareExchange(ref Unsafe.As<float, int>(ref location1), Unsafe.BitCast<float, int>(value), Unsafe.BitCast<float, int>(comparand)));

    /// <summary>Compares two double-precision floating point numbers for equality and, if they are equal, replaces the first value.</summary>
    /// <param name="location1">The destination, whose value is compared with <paramref name="comparand"/> and possibly replaced.</param>
    /// <param name="value">The value that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The value that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double CompareExchange(ref double location1, double value, double comparand)
        => Unsafe.BitCast<long, double>(CompareExchange(ref Unsafe.As<double, long>(ref location1), Unsafe.BitCast<double, long>(value), Unsafe.BitCast<double, long>(comparand)));

    /// <summary>Compares two platform-specific handles or pointers for equality and, if they are equal, replaces the first one.</summary>
    /// <param name="location1">The destination <see cref="IntPtr"/>, whose value is compared with the value of <paramref name="comparand"/> and possibly replaced by <paramref name="value"/>.</param>
    /// <param name="value">The <see cref="IntPtr"/> that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The <see cref="IntPtr"/> that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IntPtr CompareExchange(ref IntPtr location1, IntPtr value, IntPtr comparand)
        => (IntPtr)Interlocked.CompareExchange(ref Unsafe.As<IntPtr, long>(ref location1), (long)value, (long)comparand);

    /// <summary>Compares two platform-specific handles or pointers for equality and, if they are equal, replaces the first one.</summary>
    /// <param name="location1">The destination <see cref="UIntPtr"/>, whose value is compared with the value of <paramref name="comparand"/> and possibly replaced by <paramref name="value"/>.</param>
    /// <param name="value">The <see cref="UIntPtr"/> that replaces the destination value if the comparison results in equality.</param>
    /// <param name="comparand">The <see cref="UIntPtr"/> that is compared to the value at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UIntPtr CompareExchange(ref UIntPtr location1, UIntPtr value, UIntPtr comparand)
        => (UIntPtr)Interlocked.CompareExchange(ref Unsafe.As<UIntPtr, long>(ref location1), (long)value, (long)comparand);
    #endregion

    #region Add
    /// <summary>Adds two 32-bit unsigned integers and replaces the first integer with the sum, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be added. The sum of the two values is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be added to the integer at <paramref name="location1"/>.</param>
    /// <returns>The new value stored at <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Add(ref uint location1, uint value) =>
        (uint)Add(ref Unsafe.As<uint, int>(ref location1), (int)value);

    /// <summary>Adds two 64-bit unsigned integers and replaces the first integer with the sum, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be added. The sum of the two values is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be added to the integer at <paramref name="location1"/>.</param>
    /// <returns>The new value stored at <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Add(ref ulong location1, ulong value) =>
        (ulong)Add(ref Unsafe.As<ulong, long>(ref location1), (long)value);
        
    /// <summary>Adds two 32-bit signed integers and replaces the first integer with the sum, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be added. The sum of the two values is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be added to the integer at <paramref name="location1"/>.</param>
    /// <returns>The new value stored at <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    public static int Add(ref int location1, int value) =>
        ExchangeAdd(ref location1, value) + value;

    /// <summary>Adds two 64-bit signed integers and replaces the first integer with the sum, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be added. The sum of the two values is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be added to the integer at <paramref name="location1"/>.</param>
    /// <returns>The new value stored at <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    public static long Add(ref long location1, long value) =>
        ExchangeAdd(ref location1, value) + value;

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern int ExchangeAdd(ref int location1, int value);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern long ExchangeAdd(ref long location1, long value);
    #endregion

    #region Read
    /// <summary>Returns a 64-bit unsigned value, loaded as an atomic operation.</summary>
    /// <param name="location">The 64-bit value to be loaded.</param>
    /// <returns>The loaded value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Read(ref readonly ulong location) =>
        CompareExchange(ref Unsafe.AsRef(in location), 0, 0);
        
    /// <summary>Returns a 64-bit signed value, loaded as an atomic operation.</summary>
    /// <param name="location">The 64-bit value to be loaded.</param>
    /// <returns>The loaded value.</returns>
    public static long Read(ref readonly long location) =>
        CompareExchange(ref Unsafe.AsRef(in location), 0, 0);
    #endregion

    #region And

    /// <summary>Bitwise "ands" two 32-bit signed integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern int And(ref int location1, int value);

    /// <summary>Bitwise "ands" two 32-bit unsigned integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint And(ref uint location1, uint value) =>
        (uint)And(ref Unsafe.As<uint, int>(ref location1), (int)value);

    /// <summary>Bitwise "ands" two 64-bit signed integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern long And(ref long location1, long value);

    /// <summary>Bitwise "ands" two 64-bit unsigned integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong And(ref ulong location1, ulong value) =>
        (ulong)And(ref Unsafe.As<ulong, long>(ref location1), (long)value);
    #endregion

    #region Or

    /// <summary>Bitwise "ors" two 32-bit signed integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern int Or(ref int location1, int value);

    /// <summary>Bitwise "ors" two 32-bit unsigned integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint Or(ref uint location1, uint value) =>
        (uint)Or(ref Unsafe.As<uint, int>(ref location1), (int)value);

    /// <summary>Bitwise "ors" two 64-bit signed integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern long Or(ref long location1, long value);

    /// <summary>Bitwise "ors" two 64-bit unsigned integers and replaces the first integer with the result, as an atomic operation.</summary>
    /// <param name="location1">A variable containing the first value to be combined. The result is stored in <paramref name="location1"/>.</param>
    /// <param name="value">The value to be combined with the integer at <paramref name="location1"/>.</param>
    /// <returns>The original value in <paramref name="location1"/>.</returns>
    /// <exception cref="NullReferenceException">The address of <paramref name="location1"/> is a null pointer.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Or(ref ulong location1, ulong value) =>
        (ulong)Or(ref Unsafe.As<ulong, long>(ref location1), (long)value);
    #endregion

    #region MemoryBarrier
    /// <summary>
    /// Synchronizes memory access as follows:
    /// The processor that executes the current thread cannot reorder instructions in such a way that memory accesses before
    /// the call to <see cref="MemoryBarrier"/> execute after memory accesses that follow the call to <see cref="MemoryBarrier"/>.
    /// </summary>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern void MemoryBarrier();

    /// <summary>
    /// Synchronizes memory access as follows:
    /// The processor that executes the current thread cannot reorder instructions in such a way that memory reads before
    /// the call to <see cref="ReadMemoryBarrier"/> execute after memory accesses that follow the call to <see cref="ReadMemoryBarrier"/>.
    /// </summary>
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    internal static extern void ReadMemoryBarrier();
    #endregion
}