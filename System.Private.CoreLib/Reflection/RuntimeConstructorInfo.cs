using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeConstructorInfo : ConstructorInfo
{

    private RuntimeTypeInfo _declaringType;
    private RuntimeModule _module;
    private string _name;
    private int _metadataToken;

    private ParameterInfo[] _parameters;
    private MethodAttributes _attributes;
    private MethodImplAttributes _implAttributes;
    private RuntimeMethodBody _methodBody;
    private ParameterInfo _returnParameter;
    private RuntimeTypeInfo _genericArguments;
    private RuntimeMethodInfo _genericMethodDefinition;
    private UIntPtr _genericMethodInstances;
    private UIntPtr _methodPtr;
    private UIntPtr _methodSize;
    private UIntPtr _thunkPtr;
    private UIntPtr _thunkSize;
    private int _vtableOffset;
    private uint _flags;

    public override string Name => _name;

}