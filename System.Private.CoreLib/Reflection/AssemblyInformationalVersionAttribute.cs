namespace System.Reflection;

[AttributeUsage(System.AttributeTargets.Assembly, Inherited=false)]
public sealed class AssemblyInformationalVersionAttribute(string informationalVersion) : Attribute
{
    public string InformationalVersion => informationalVersion;
}