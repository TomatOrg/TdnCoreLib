namespace System.Diagnostics;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module, AllowMultiple=false)]
public sealed class DebuggableAttribute : Attribute
{
    
    [Flags]
    public enum DebuggingModes
    {
        None = 0,
        Default = 1,
        IgnoreSymbolStoreSequencePoints = 2,
        EnableEditAndContinue = 4,
        DisableOptimizations = 256,
    }
    
    public bool IsJITOptimizerDisabled { get; }
    public bool IsJITTrackingEnabled { get; }
    public DebuggingModes DebuggingFlags { get; }

    public DebuggableAttribute(DebuggingModes modes)
    {
        DebuggingFlags = modes;
    }

    public DebuggableAttribute(bool isJITTrackingEnabled, bool isJITOptimizerDisabled)
    {
        IsJITOptimizerDisabled = isJITOptimizerDisabled;
        IsJITTrackingEnabled = isJITTrackingEnabled;
    }
    
}