namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, Inherited=false)]
public sealed class NotNullAttribute : Attribute;