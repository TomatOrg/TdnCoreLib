using System;
using System.Runtime.CompilerServices;

namespace Tests;

internal static class Program
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ReduceDelegate(int[] a, Func<int,int,int> d)
    {
        if (a.Length == 0) return 0;

        var result = a[0];
        for (int i = 1; i < a.Length; i++) {
            result = d(result, a[i]);
        }
        return result;
    }

    public static int Add(int a, int b)
    {
        return a + b;
    }
    
    public static int Main(string[] args)
    {
        var a = new Func<int, int, int>(Add);
        return a(1, 2);
        // return ReduceDelegate([1,2,3], new Func<int, int, int>(Add));
    }
}