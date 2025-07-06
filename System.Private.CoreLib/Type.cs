using System.Reflection;

namespace System;

public abstract class Type : MemberInfo
{

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
    
}