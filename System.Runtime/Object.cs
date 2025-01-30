namespace System;

public class Object
{

    private uint _vtable;
    private uint _reserved;
    
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
        throw null;
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