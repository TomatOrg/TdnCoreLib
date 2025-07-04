using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class RuntimeTypeInfo : Type
{

    internal RuntimeTypeInfo _declaringType;
    internal RuntimeModule _module;
    internal string _name;
    internal int _metadataToken;
    internal int _padding;
    
    internal RuntimeTypeInfo? _arrayType;
    internal RuntimeTypeInfo? _byRefType;
    internal RuntimeTypeInfo? _pointerType;
    internal ulong _interfacePrime;
    internal ulong _interfaceId;
    internal string _namespace;
    internal TypeAttributes _attributes;
    internal RuntimeTypeInfo _baseType;
    internal UIntPtr _genericTypeInstances;
    internal RuntimeConstructorInfo _typeInitialized;
    internal UIntPtr _managedPointers;
    internal UIntPtr _interfaceImpls;
    internal RuntimeTypeInfo _interfaceImplementors;
    internal RuntimeConstructorInfo[] _declaredConstructors;
    internal RuntimeMethodInfo[] _declaredMethods;
    internal RuntimeFieldInfo[] _declaredFields;
    internal RuntimeMethodInfo[] _vtable;
    internal UIntPtr _jitVTable;
    internal RuntimeTypeInfo _declaredNestedTypes;
    internal RuntimeTypeInfo _nextNestedType;
    internal RuntimeTypeInfo _elementType;
    internal RuntimeTypeInfo _enumUnderlyingType;
    internal uint _stackSize;
    internal uint _stackAlignment;
    internal uint _heapSize;
    internal uint _heapAlignment;
    internal uint _packing;
    internal uint _vtableSize;
    internal MethodBase _declaringMethod;
    internal RuntimeTypeInfo[] _genericArguments;
    internal RuntimeTypeInfo[] _genericParameterConstraints;
    internal RuntimeTypeInfo _genericTypeDefinition;
    internal GenericParameterAttributes _genericParameterAttributes;
    internal uint _genericParameterPosition;
    internal uint _flags;
    
    public override string Name => _name;

    public override string ToString()
    {
        return Name;
    }
}