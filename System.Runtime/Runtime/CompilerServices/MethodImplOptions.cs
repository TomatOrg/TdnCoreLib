namespace System.Runtime.CompilerServices;

[Flags]
public enum MethodImplOptions
{
    Unmanaged = 4,
    NoInlining = 8,
    ForwardRef = 16,
    Synchronized = 32,
    NoOptimization = 64,
    PreserveSig = 128,
    AggressiveInlining = 256,
    AggressiveOptimization = 512,
    InternalCall = 4096,
}