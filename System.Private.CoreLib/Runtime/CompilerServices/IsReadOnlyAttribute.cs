using System.ComponentModel;

namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.All, Inherited = false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class IsReadOnlyAttribute : Attribute;
