namespace System.Runtime.CompilerServices;

public static class RuntimeFeature
{
    
    public const string ByRefFields = nameof(ByRefFields);
    public const string CovariantReturnsOfClasses = nameof(CovariantReturnsOfClasses);
    public const string DefaultImplementationsOfInterfaces = nameof(DefaultImplementationsOfInterfaces);
    public const string NumericIntPtr = nameof(NumericIntPtr);
    public const string PortablePdb = nameof(PortablePdb);
    public const string UnmanagedSignatureCallingConvention = nameof(UnmanagedSignatureCallingConvention);
    public const string VirtualStaticsInInterfaces = nameof(VirtualStaticsInInterfaces);

    public static bool IsDynamicCodeCompiled => false;
    public static bool IsDynamicCodeSupported => false;

    public static bool IsSupported(string feature)
    {
        switch (feature)
        {
            case CovariantReturnsOfClasses:
            case ByRefFields:
            case DefaultImplementationsOfInterfaces:
            case VirtualStaticsInInterfaces:
                return true;
        }

        return false;
    }
    
}