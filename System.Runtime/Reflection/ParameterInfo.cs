using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
public class ParameterInfo
{
    
    protected ParameterAttributes AttrsImpl;
    protected Type? ClassImpl;
    protected object? DefaultValueImpl;
    protected System.Reflection.MemberInfo MemberImpl;
    protected string? NameImpl;
    protected int PositionImpl;
    
    private uint _flags;

    protected ParameterInfo()
    {
    }

}