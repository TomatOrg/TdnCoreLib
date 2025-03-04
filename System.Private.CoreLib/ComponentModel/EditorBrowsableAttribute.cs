using System.Diagnostics.CodeAnalysis;

namespace System.ComponentModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct)]
public sealed class EditorBrowsableAttribute(EditorBrowsableState state) : Attribute
{
    
    public EditorBrowsableState State => state;
    
    public EditorBrowsableAttribute() 
        : this(EditorBrowsableState.Always)
    {
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj == this)
        {
            return true;
        }

        return (obj is EditorBrowsableAttribute other) && other.State == State;
    }
    
}