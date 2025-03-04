using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeAssembly : Assembly
{

    private RuntimeAssembly[] _assemblyRefs;
    private RuntimeTypeInfo[] _typeRefs;
    private RuntimeTypeInfo[] _typeDefs;
    private MethodBase[] _methodDefs;
    private RuntimeFieldInfo[] _fields;
    private RuntimeTypeInfo[] _genericParams;
    private RuntimeTypeInfo[] _params;
    private UIntPtr _metadata;
    private RuntimeModule _module;
    private RuntimeMethodInfo _entryPoint;
    private UIntPtr _stringTables;
    private uint _flags;

}