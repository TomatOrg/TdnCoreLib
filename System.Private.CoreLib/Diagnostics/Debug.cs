using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

public static class Debug
{

    [Conditional("DEBUG")]
    public static void Assert([DoesNotReturnIf(false)] bool condition)
    {
        // TODO: thing
    }

    [Conditional("DEBUG")]
    [DoesNotReturn]
    public static void Fail(string? message)
    {
        // TODO: thing        
    }

}