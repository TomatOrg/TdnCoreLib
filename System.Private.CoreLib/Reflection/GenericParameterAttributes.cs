namespace System.Reflection;

[Flags]
public enum GenericParameterAttributes
{
    None = 0,
    Covariant = 1,
    Contravariant = 2,
    VarianceMask = 3,
    ReferenceTypeConstraint = 4,
    NotNullableValueTypeConstraint = 8,
    DefaultConstructorConstraint = 16,
    SpecialConstraintMask = 28,
}