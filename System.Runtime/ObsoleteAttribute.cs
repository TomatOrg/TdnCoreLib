namespace System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct, Inherited=false)]
public sealed class ObsoleteAttribute : Attribute
{

    public string? DiagnosticId { get; set; }
    public bool IsError { get; set; }
    public string? Message { get; set; }
    public string? UrlFormat { get; set; }

    public ObsoleteAttribute()
    {
    }

    public ObsoleteAttribute(string? message)
    {
        Message = message;
    }

    public ObsoleteAttribute(string? message, bool error)
    {
        Message = message;
        IsError = error;
    }
    
    
}