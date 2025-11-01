using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Runtime;

internal static partial class Interop
{
    internal static partial class Globalization
    {
        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern int LoadICU();

        internal static void InitICUFunctions(IntPtr icuuc, IntPtr icuin, ReadOnlySpan<char> version, ReadOnlySpan<char> suffix)
        {
            Debug.Assert(icuuc != IntPtr.Zero);
            Debug.Assert(icuin != IntPtr.Zero);

            InitICUFunctions(icuuc, icuin, version.ToString(), suffix.Length > 0 ? suffix.ToString() : null);
        }

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern void InitICUFunctions(IntPtr icuuc, IntPtr icuin, string version, string? suffix);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern int GetICUVersion();
    }
}
