using System;
using System.Collections.Generic;
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
        Debug.WriteLine(string.Format("{0} {1}!", "Hello", "World"));
        return 0;
        // var list = new List<string>();
        // list.Add("1");
        // list.Add("3");
        // list.Add("6");
        // foreach (var i in list)
        // {
        //     Debug.WriteLine(i);
        // }
        // return 0;
    }
}