namespace System.Globalization;

public static class CharUnicodeInfo
{
    
    internal const char HIGH_SURROGATE_START = '\ud800';
    internal const char HIGH_SURROGATE_END = '\udbff';
    internal const char LOW_SURROGATE_START = '\udc00';
    internal const char LOW_SURROGATE_END = '\udfff';
    internal const int  HIGH_SURROGATE_RANGE = 0x3FF;

    internal const int UNICODE_CATEGORY_OFFSET = 0;
    internal const int BIDI_CATEGORY_OFFSET = 1;

    // The starting codepoint for Unicode plane 1.  Plane 1 contains 0x010000 ~ 0x01ffff.
    internal const int UNICODE_PLANE01_START = 0x10000;
    
    public static UnicodeCategory GetUnicodeCategory(char ch)
    {
        throw new NotImplementedException();
    }
    
    public static UnicodeCategory GetUnicodeCategory(int codePoint)
    {
        throw new NotImplementedException();
    }
    
    public static double GetNumericValue(char ch)
    {
        throw new NotImplementedException();
    }

    internal static double GetNumericValueInternal(string s, int index)
    {
        throw new NotImplementedException();
    }
    
    internal static UnicodeCategory GetUnicodeCategoryInternal(string value, int index)
    {
        throw new NotImplementedException();
    }
    
    internal static bool GetIsWhiteSpace(char ch)
    {
        throw new NotImplementedException();
    }
    
}