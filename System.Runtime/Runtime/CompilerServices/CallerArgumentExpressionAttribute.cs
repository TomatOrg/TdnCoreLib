namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple=false, Inherited=false)]
public class CallerArgumentExpressionAttribute(string parameterName) : Attribute
{
    public string ParameterName => parameterName;
}