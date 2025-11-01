using System.Runtime.CompilerServices;

namespace System;

public class Activator
{

    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern T CreateInstance<T>() where T : new();

}