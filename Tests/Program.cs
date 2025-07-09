using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

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
        var span = new Span<int>([1, 2, 3]);
        Debug.WriteLine(span.ToString());
        return 0;
    }
}