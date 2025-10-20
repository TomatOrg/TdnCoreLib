using System.ComponentModel;

namespace System.Runtime.CompilerServices;

[EditorBrowsable(EditorBrowsableState.Never)]
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class ScopedRefAttribute : Attribute
{
    public ScopedRefAttribute()
    {
    }
}