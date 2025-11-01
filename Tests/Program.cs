using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tests;

internal static class Program
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T ReduceDelegate<T>(T[] a)
        where T : INumber<T>
    {
        if (a.Length == 0) return T.Zero;
        var result = a[0];
        for (var i = 1; i < a.Length; i++) {
            result += a[i];
        }
        return result;
    }
    
    public static int Main(string[] args)
    {
        Debug.WriteLine(1.0);
        return 0;
    }
}