namespace System.Reflection;

[Flags]
public enum TypeAttributes
{
    AnsiClass = 0,
    AutoLayout = 0,
    Class = 0,
    NotPublic = 0,
    Public = 1,
    NestedPublic = 2,
    NestedPrivate = 3,
    NestedFamily = 4,
    NestedAssembly = 5,
    NestedFamANDAssem = 6,
    NestedFamORAssem = 7,
    VisibilityMask = 7,
    SequentialLayout = 8,
    ExplicitLayout = 16,
    LayoutMask = 24,
    ClassSemanticsMask = 32,
    Interface = 32,
    Abstract = 128,
    Sealed = 256,
    SpecialName = 1024,
    RTSpecialName = 2048,
    Import = 4096,
        
    [Obsolete("Formatter-based serialization is obsolete and should not be used.", DiagnosticId = "SYSLIB0050", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
    Serializable = 8192,
        
    WindowsRuntime = 16384,
    UnicodeClass = 65536,
    AutoClass = 131072,
    CustomFormatClass = 196608,
    StringFormatMask = 196608,
    HasSecurity = 262144,
    ReservedMask = 264192,
    BeforeFieldInit = 1048576,
    CustomFormatMask = 12582912,
}