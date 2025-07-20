using System.Diagnostics;

namespace System.Globalization;

public sealed class CultureData
{
    private const int LocaleNameMaxLength = 85;
    private const int undef = -1;

    // Override flag
    private string _sRealName = null!; // Name you passed in (ie: en-US, en, or de-DE_phoneb). Initialized by helper called during initialization.
    private string? _sWindowsName; // Name OS thinks the object is (ie: de-DE_phoneb, or en-US (even if en was passed in))

    // Identity
    private string? _sName; // locale name (ie: en-us, NO sort info, but could be neutral)
    private string? _sParent; // Parent name (which may be a custom locale/culture)
    private string? _sEnglishDisplayName; // English pretty name for this locale
    private string? _sNativeDisplayName; // Native pretty name for this locale
    private string? _sSpecificCulture; // The culture name to be used in CultureInfo.CreateSpecificCulture(), en-US form if neutral, sort name if sort

    // Language
    private string? _sISO639Language; // ISO 639 Language Name
    private string? _sISO639Language2; // ISO 639 Language Name
    private string? _sEnglishLanguage; // English name for this language
    private string? _sNativeLanguage; // Native name of this language
    private string? _sAbbrevLang; // abbreviated language name (Windows Language Name) ex: ENU
    private string? _sConsoleFallbackName; // The culture name for the console fallback UI culture
    private int _iInputLanguageHandle = undef; // input language handle

    // Region
    private string? _sRegionName; // (RegionInfo)
    private string? _sLocalizedCountry; // localized country name
    private string? _sEnglishCountry; // english country name (RegionInfo)
    private string? _sNativeCountry; // native country name
    private string? _sISO3166CountryName; // ISO 3166 (RegionInfo), ie: US
    private string? _sISO3166CountryName2; // 3 char ISO 3166 country name 2 2(RegionInfo) ex: USA (ISO)
    private int _iGeoId = undef; // GeoId

    // Numbers
    private string? _sPositiveSign; // (user can override) positive sign
    private string? _sNegativeSign; // (user can override) negative sign
    // (nfi populates these 5, don't have to be = undef)
    private int _iDigits; // (user can override) number of fractional digits
    private int _iNegativeNumber; // (user can override) negative number format
    private int[]? _waGrouping; // (user can override) grouping of digits
    private string? _sDecimalSeparator; // (user can override) decimal separator
    private string? _sThousandSeparator; // (user can override) thousands separator
    private string? _sNaN; // Not a Number
    private string? _sPositiveInfinity; // + Infinity
    private string? _sNegativeInfinity; // - Infinity

    // Percent
    private int _iNegativePercent = undef; // Negative Percent (0-3)
    private int _iPositivePercent = undef; // Positive Percent (0-11)
    private string? _sPercent; // Percent (%) symbol
    private string? _sPerMille; // PerMille symbol

    // Currency
    private string? _sCurrency; // (user can override) local monetary symbol
    private string? _sIntlMonetarySymbol; // international monetary symbol (RegionInfo)
    private string? _sEnglishCurrency; // English name for this currency
    private string? _sNativeCurrency; // Native name for this currency
    // (nfi populates these 4, don't have to be = undef)
    private int _iCurrencyDigits; // (user can override) # local monetary fractional digits
    private int _iCurrency; // (user can override) positive currency format
    private int _iNegativeCurrency; // (user can override) negative currency format
    private int[]? _waMonetaryGrouping; // (user can override) monetary grouping of digits
    private string? _sMonetaryDecimal; // (user can override) monetary decimal separator
    private string? _sMonetaryThousand; // (user can override) monetary thousands separator

    // Misc
    private int _iMeasure = undef; // (user can override) system of measurement 0=metric, 1=US (RegionInfo)
    private string? _sListSeparator; // (user can override) list separator

    // Time
    private string? _sAM1159; // (user can override) AM designator
    private string? _sPM2359; // (user can override) PM designator
    private string? _sTimeSeparator;
    private volatile string[]? _saLongTimes; // (user can override) time format
    private volatile string[]? _saShortTimes; // (user can override) short time format
    private volatile string[]? _saDurationFormats; // time duration format

    // Calendar specific data
    private int _iFirstDayOfWeek = undef; // (user can override) first day of week (gregorian really)
    private int _iFirstWeekOfYear = undef; // (user can override) first week of year (gregorian really)
    // private volatile CalendarId[]? _waCalendars; // all available calendar type(s).  The first one is the default calendar

    // Store for specific data about each calendar
    // private CalendarData?[]? _calendars; // Store for specific calendar data

    // Text information
    private int _iReadingLayout = undef; // Reading layout data
    // 0 - Left to right (eg en-US)
    // 1 - Right to left (eg arabic locales)
    // 2 - Vertical top to bottom with columns to the left and also left to right (ja-JP locales)
    // 3 - Vertical top to bottom with columns proceeding to the right

    // CoreCLR depends on this even though its not exposed publicly.

    private int _iDefaultAnsiCodePage = undef; // default ansi code page ID (ACP)
    private int _iDefaultOemCodePage = undef; // default oem code page ID (OCP or OEM)
    private int _iDefaultMacCodePage = undef; // default macintosh code page
    private int _iDefaultEbcdicCodePage = undef; // default EBCDIC code page

    private int _iLanguage; // locale ID (0409) - NO sort information
    private bool _bUseOverrides; // use user overrides? this depends on user setting and if is user default locale.
    private bool _bUseOverridesUserSetting; // the setting the user requested for.
    private bool _bNeutral; // Flags for the culture (ie: neutral or not right now)

    private static CultureData CreateCultureWithInvariantData()
    {
        // Make a new culturedata
        CultureData invariant = new CultureData();

        // Basics
        // Note that we override the resources since this IS NOT supposed to change (by definition)
        invariant._bUseOverrides = false;
        invariant._bUseOverridesUserSetting = false;
        invariant._sRealName = "";                     // Name you passed in (ie: en-US, en, or de-DE_phoneb)
        invariant._sWindowsName = "";                     // Name OS thinks the object is (ie: de-DE_phoneb, or en-US (even if en was passed in))

        // Identity
        invariant._sName = "";                     // locale name (ie: en-us)
        invariant._sParent = "";                     // Parent name (which may be a custom locale/culture)
        invariant._bNeutral = false;                   // Flags for the culture (ie: neutral or not right now)
        invariant._sEnglishDisplayName = "Invariant Language (Invariant Country)"; // English pretty name for this locale
        invariant._sNativeDisplayName = "Invariant Language (Invariant Country)";  // Native pretty name for this locale
        invariant._sSpecificCulture = "";                     // The culture name to be used in CultureInfo.CreateSpecificCulture()

        // Language
        invariant._sISO639Language = "iv";                   // ISO 639 Language Name
        invariant._sISO639Language2 = "ivl";                  // 3 char ISO 639 lang name 2
        invariant._sEnglishLanguage = "Invariant Language";   // English name for this language
        invariant._sNativeLanguage = "Invariant Language";   // Native name of this language
        invariant._sAbbrevLang = "IVL";                  // abbreviated language name (Windows Language Name)
        invariant._sConsoleFallbackName = "";            // The culture name for the console fallback UI culture
        invariant._iInputLanguageHandle = 0x07F;         // input language handle

        // Region
        invariant._sRegionName = "IV";                    // (RegionInfo)
        invariant._sEnglishCountry = "Invariant Country"; // english country name (RegionInfo)
        invariant._sNativeCountry = "Invariant Country";  // native country name (Windows Only)
        invariant._sISO3166CountryName = "IV";            // (RegionInfo), ie: US
        invariant._sISO3166CountryName2 = "ivc";          // 3 char ISO 3166 country name 2 2(RegionInfo)
        invariant._iGeoId = 244;                          // GeoId (Windows Only)

        // Numbers
        invariant._sPositiveSign = "+";                    // positive sign
        invariant._sNegativeSign = "-";                    // negative sign
        invariant._iDigits = 2;                      // number of fractional digits
        invariant._iNegativeNumber = 1;                      // negative number format
        invariant._waGrouping = new int[] { 3 };          // grouping of digits
        invariant._sDecimalSeparator = ".";                    // decimal separator
        invariant._sThousandSeparator = ",";                    // thousands separator
        invariant._sNaN = "NaN";                  // Not a Number
        invariant._sPositiveInfinity = "Infinity";             // + Infinity
        invariant._sNegativeInfinity = "-Infinity";            // - Infinity

        // Percent
        invariant._iNegativePercent = 0;                      // Negative Percent (0-3)
        invariant._iPositivePercent = 0;                      // Positive Percent (0-11)
        invariant._sPercent = "%";                    // Percent (%) symbol
        invariant._sPerMille = "\x2030";               // PerMille symbol

        // Currency
        invariant._sCurrency = "\x00a4";                // local monetary symbol: for international monetary symbol
        invariant._sIntlMonetarySymbol = "XDR";                  // international monetary symbol (RegionInfo)
        invariant._sEnglishCurrency = "International Monetary Fund"; // English name for this currency (Windows Only)
        invariant._sNativeCurrency = "International Monetary Fund"; // Native name for this currency (Windows Only)
        invariant._iCurrencyDigits = 2;                      // # local monetary fractional digits
        invariant._iCurrency = 0;                      // positive currency format
        invariant._iNegativeCurrency = 0;                      // negative currency format
        invariant._waMonetaryGrouping = new int[] { 3 };          // monetary grouping of digits
        invariant._sMonetaryDecimal = ".";                    // monetary decimal separator
        invariant._sMonetaryThousand = ",";                    // monetary thousands separator

        // Misc
        invariant._iMeasure = 0;                      // system of measurement 0=metric, 1=US (RegionInfo)
        invariant._sListSeparator = ",";                    // list separator

        // Time
        invariant._sTimeSeparator = ":";
        invariant._sAM1159 = "AM";                   // AM designator
        invariant._sPM2359 = "PM";                   // PM designator
        invariant._saLongTimes = new string[] { "HH:mm:ss" };                             // time format
        invariant._saShortTimes = new string[] { "HH:mm", "hh:mm tt", "H:mm", "h:mm tt" }; // short time format
        invariant._saDurationFormats = new string[] { "HH:mm:ss" };                             // time duration format

        // Calendar specific data
        invariant._iFirstDayOfWeek = 0;                      // first day of week
        invariant._iFirstWeekOfYear = 0;                      // first week of year

        // all available calendar type(s).  The first one is the default calendar
        // invariant._waCalendars = new CalendarId[] { CalendarId.GREGORIAN };

        // // Store for specific data about each calendar
        // invariant._calendars = new CalendarData[CalendarData.MAX_CALENDARS];
        // invariant._calendars[0] = CalendarData.Invariant;
        //
        // Text information
        invariant._iReadingLayout = 0;

        // These are .NET Framework only, not coreclr

        invariant._iLanguage = CultureInfo.LOCALE_INVARIANT;   // locale ID (0409) - NO sort information
        invariant._iDefaultAnsiCodePage = 1252;         // default ansi code page ID (ACP)
        invariant._iDefaultOemCodePage = 437;           // default oem code page ID (OCP or OEM)
        invariant._iDefaultMacCodePage = 10000;         // default macintosh code page
        invariant._iDefaultEbcdicCodePage = 037;        // default EBCDIC code page
        
        return invariant;
    }

    /// <summary>
    /// Build our invariant information
    /// We need an invariant instance, which we build hard-coded
    /// </summary>
    internal static CultureData Invariant => s_Invariant ??= CreateCultureWithInvariantData();
    private static volatile CultureData? s_Invariant;

    
    /// <summary>
    /// The real name used to construct the locale (ie: de-DE_phoneb)
    /// </summary>
    internal string CultureName
    {
        get
        {
            Debug.Assert(_sRealName != null, "[CultureData.CultureName] Expected _sRealName to be populated by already");
            return _sRealName;
        }
    }
    
}