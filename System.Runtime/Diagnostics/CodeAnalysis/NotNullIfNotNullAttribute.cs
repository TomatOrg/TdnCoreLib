namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, AllowMultiple=true, Inherited=false)]
public sealed class NotNullIfNotNullAttribute(string parameterName) : Attribute
{
    public string ParameterName => parameterName;
}