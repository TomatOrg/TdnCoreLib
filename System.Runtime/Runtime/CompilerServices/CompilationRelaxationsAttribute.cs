namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Module)]
public class CompilationRelaxationsAttribute(int relaxations) : Attribute
{

    public int CompilationRelaxations { get; } = relaxations;

    public CompilationRelaxationsAttribute(CompilationRelaxations relaxations) 
        : this((int)relaxations)
    {
    }
    
}