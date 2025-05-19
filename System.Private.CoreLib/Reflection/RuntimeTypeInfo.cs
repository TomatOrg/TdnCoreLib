using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeTypeInfo : Type
{

    private RuntimeTypeInfo _declaringType;
    private RuntimeModule _module;
    private string _name;
    private int _metadataToken;
    private int _padding;
    
    private RuntimeTypeInfo? _arrayType;
    private RuntimeTypeInfo? _byRefType;
    private RuntimeTypeInfo? _pointerType;
    private ulong _interfacePrime;
    private ulong _interfaceId;
    private string _namespace;
    private TypeAttributes _attributes;
    private RuntimeTypeInfo _baseType;
    private UIntPtr _genericTypeInstances;
    private RuntimeConstructorInfo _typeInitialized;
    private UIntPtr _managedPointers;
    private UIntPtr _interfaceImpls;
    private RuntimeTypeInfo _interfaceImplementors;
    private RuntimeConstructorInfo[] _declaredConstructors;
    private RuntimeMethodInfo[] _declaredMethods;
    private RuntimeFieldInfo[] _declaredFields;
    private RuntimeMethodInfo[] _vtable;
    private UIntPtr _jitVTable;
    private RuntimeTypeInfo _declaredNestedTypes;
    private RuntimeTypeInfo _nextNestedType;
    private RuntimeTypeInfo _elementType;
    private RuntimeTypeInfo _enumUnderlyingType;
    private uint _stackSize;
    private uint _stackAlignment;
    private uint _heapSize;
    private uint _heapAlignment;
    private uint _packing;
    private uint _vtableSize;
    private MethodBase _declaringMethod;
    private RuntimeTypeInfo[] _genericArguments;
    private RuntimeTypeInfo[] _genericParameterConstraints;
    private RuntimeTypeInfo _genericTypeDefinition;
    private GenericParameterAttributes _genericParameterAttributes;
    private uint _genericParameterPosition;
    private uint _flags;
    
    public override string Name => _name;

    public override string ToString()
    {
        return Name;
    }
}