namespace System.Reflection;

[AttributeUsage(System.AttributeTargets.Assembly, Inherited=false)]
public sealed class AssemblyCompanyAttribute(string company) : Attribute
{

    public string Company => company;

}