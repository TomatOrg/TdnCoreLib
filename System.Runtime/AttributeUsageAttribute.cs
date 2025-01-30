namespace System;

[AttributeUsage(AttributeTargets.Class, Inherited=true)]
public sealed class AttributeUsageAttribute(AttributeTargets validOn) : Attribute
{

    public AttributeTargets ValidOn => validOn;
    
    public bool AllowMultiple { get; set; }
    public bool Inherited { get; set; }
    
}