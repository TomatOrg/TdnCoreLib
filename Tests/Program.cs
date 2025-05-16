using System;
using System.Runtime.CompilerServices;

namespace Tests;

internal static class Program
{

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static double ReduceDelegate(double[] a, Func<double,double,double> d)
    {
        if (a.Length == 0) return 0;

        var result = a[0];
        for (int i = 1; i < a.Length; i++) {
            result = d(result, a[i]);
        }
        return result;
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }
    
    public static int Main(string[] args)
    {
        var a = new Func<double, double, double>(Add);
        // return a(1, 2);
        return (int)ReduceDelegate([1,2,3], new Func<double, double, double>(Add));
    }
}