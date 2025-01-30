namespace System.Reflection;

[Flags]
public enum FieldAttributes
{
    PrivateScope = 0,
    Private = 1,
    FamANDAssem = 2,
    Assembly = 3,
    Family = 4,
    FamORAssem = 5,
    Public = 6,
    FieldAccessMask = 7,
    Static = 16,
    InitOnly = 32,
    Literal = 64,
    [Obsolete("Formatter-based serialization is obsolete and should not be used.", DiagnosticId = "SYSLIB0050", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
    NotSerialized = 128,
    HasFieldRVA = 256,
    SpecialName = 512,
    RTSpecialName = 1024,
    HasFieldMarshal = 4096,
    PinvokeImpl = 8192,
    HasDefault = 32768,
    ReservedMask = 38144,
}