namespace System.Runtime.Versioning;

[AttributeUsage(System.AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
public class TargetFrameworkAttribute(string frameworkName) : Attribute
{

    public string FrameworkName => frameworkName;
    
    public string? FrameworkDisplayName { get; set; }

}