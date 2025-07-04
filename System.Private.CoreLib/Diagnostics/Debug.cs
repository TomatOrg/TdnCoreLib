using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

public static class Debug
{

    [Conditional("DEBUG")]
    public static void Assert([DoesNotReturnIf(false)] bool condition)
    {
        // TODO: thing
    }

}