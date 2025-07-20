namespace System.Runtime.CompilerServices;

public static class RuntimeHelpers
{

    public static extern int OffsetToStringData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
        get;
    }
    
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern void InitializeArray(Array array, RuntimeFieldHandle fldHandle);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    public static extern bool IsReferenceOrContainsReferences<T>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.Runtime)]
    internal static extern bool IsBitwiseEquatable<T>();
    
}