using System.Reflection;

namespace System;

public abstract class Type : MemberInfo
{

    public abstract Type? BaseType { get; }
    
    protected Type()
    {
    }

    public static TypeCode GetTypeCode(Type? type)
    {
        return TypeCode.Object;
    }

    public static Type? GetTypeFromHandle(RuntimeTypeHandle handle)
    {
        return handle._type;
    }
    
    public bool IsValueType { get => IsValueTypeImpl(); }
    protected virtual bool IsValueTypeImpl() => IsSubclassOf(typeof(ValueType));
    
    public virtual bool IsSubclassOf(Type c)
    {
        Type? p = this;
        if (p == c)
            return false;
        while (p != null)
        {
            if (p == c)
                return true;
            p = p.BaseType;
        }
        return false;
    }
    
}