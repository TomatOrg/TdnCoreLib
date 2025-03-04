namespace System.Runtime.InteropServices;

[AttributeUsage(System.AttributeTargets.Field, Inherited=false)]
public sealed class FieldOffsetAttribute(int offset) : Attribute
{
    
    public int Value => offset;
    
}