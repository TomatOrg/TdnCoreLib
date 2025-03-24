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
    
}