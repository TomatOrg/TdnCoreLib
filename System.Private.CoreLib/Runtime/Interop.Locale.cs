using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Runtime;

internal static partial class Interop
{
    internal static partial class Globalization
    {
        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern unsafe bool GetLocaleName(string localeName, char* value, int valueLength);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern unsafe bool GetLocaleInfoString(string localeName, uint localeStringData, char* value, int valueLength, string? uiLocaleName = null);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern unsafe bool GetDefaultLocaleName(char* value, int valueLength);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern bool IsPredefinedLocale(string localeName);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern unsafe bool GetLocaleTimeFormat(string localeName, bool shortFormat, char* value, int valueLength);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern bool GetLocaleInfoInt(string localeName, uint localeNumberData, ref int value);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern bool GetLocaleInfoGroupingSizes(string localeName, uint localeGroupingData, ref int primaryGroupSize, ref int secondaryGroupSize);

        [MethodImpl(MethodCodeType = MethodCodeType.Native)]
        internal static extern int GetLocales([Out] char[]? value, int valueLength);
    }
}
