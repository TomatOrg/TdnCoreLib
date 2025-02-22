using System.Reflection;
using System.Runtime.InteropServices;

namespace System;


public class Object
{

    [StructLayout(LayoutKind.Sequential)]
    private struct ObjectVTable
    {
        public RuntimeTypeInfo Type;
    }
    
    private unsafe ObjectVTable* _vtable;
    private ulong _reserved;
    
    public Object()
    {
        
    }

    ~Object()
    {
        
    }

    public virtual bool Equals(object? obj)
    {
        return this == obj;
    }

    public virtual int GetHashCode()
    {
        throw null;
    }

    public Type GetType()
    {
        unsafe
        {
            return _vtable->Type;
        }
    }

    protected object MemberwiseClone()
    {
        throw null;
    }

    public virtual string? ToString()
    {
        return GetType().ToString();
    }

    public static bool Equals(Object? objA, object? objB)
    {
        if (objA == objB)
        {
            return true;
        }
        if (objA == null || objB == null)
        {
            return false;
        }
        return objA.Equals(objB);   
    }

    public static bool ReferenceEquals(object? objA, object? objB)
    {
        return objA == objB;
    }
    
}