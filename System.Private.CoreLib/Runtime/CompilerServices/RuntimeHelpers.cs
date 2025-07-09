namespace System.Runtime.CompilerServices;

public static class RuntimeHelpers
{

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern void InitializeArray(Array array, RuntimeFieldHandle fldHandle);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern bool IsReferenceOrContainsReferences<T>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    internal static extern bool IsBitwiseEquatable<T>();
    
}