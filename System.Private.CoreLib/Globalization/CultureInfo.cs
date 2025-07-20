using System.Diagnostics;

namespace System.Globalization;

public class CultureInfo : IFormatProvider
{

    // We use an RFC4646 type string to construct CultureInfo.
    // This string is stored in _name and is authoritative.
    // We use the _cultureData to get the data for our object

    private bool _isReadOnly;
    // private CompareInfo? _compareInfo;
    // private TextInfo? _textInfo;
    internal NumberFormatInfo? _numInfo;
    // internal DateTimeFormatInfo? _dateTimeInfo;
    // private Calendar? _calendar;
    //
    // The CultureData instance that we are going to read data from.
    // For supported culture, this will be the CultureData instance that read data from mscorlib assembly.
    // For customized culture, this will be the CultureData instance that read data from user customized culture binary file.
    //
    internal CultureData _cultureData;

    internal bool _isInherited;

    private CultureInfo? _consoleFallbackCulture;

    // Names are confusing.  Here are 3 names we have:
    //
    //  new CultureInfo()   _name          _nonSortName    _sortName
    //      en-US           en-US           en-US           en-US
    //      de-de_phoneb    de-DE_phoneb    de-DE           de-DE_phoneb
    //      fj-fj (custom)  fj-FJ           fj-FJ           en-US (if specified sort is en-US)
    //      en              en
    //
    // Note that in Silverlight we ask the OS for the text and sort behavior, so the
    // textinfo and compareinfo names are the same as the name

    // This has a de-DE, de-DE_phoneb or fj-FJ style name
    internal string _name;

    // This will hold the non sorting name to be returned from CultureInfo.Name property.
    // This has a de-DE style name even for de-DE_phoneb type cultures
    private string? _nonSortName;

    // This will hold the sorting name to be returned from CultureInfo.SortName property.
    // This might be completely unrelated to the culture name if a custom culture.  Ie en-US for fj-FJ.
    // Otherwise its the sort name, ie: de-DE or de-DE_phoneb
    private string? _sortName;

    
    internal const int LOCALE_INVARIANT       = 0x007F;
    
    // The Invariant culture;
    private static readonly CultureInfo s_InvariantCultureInfo = new CultureInfo(CultureData.Invariant, isReadOnly: true);
    
    private CultureInfo(CultureData cultureData, bool isReadOnly = false)
    {
        Debug.Assert(cultureData != null);
        _cultureData = cultureData;
        _name = cultureData.CultureName;
        _isReadOnly = isReadOnly;
    }
    
    public static CultureInfo InvariantCulture
    {
        get
        {
            Debug.Assert(s_InvariantCultureInfo != null);
            return s_InvariantCultureInfo;
        }
    }

    
    public virtual NumberFormatInfo NumberFormat
    {
        get
        {
            if (_numInfo == null)
            {
                NumberFormatInfo temp = new NumberFormatInfo(_cultureData);
                temp._isReadOnly = _isReadOnly;
                _numInfo = temp;
                // TODO: Interlocked.CompareExchange(ref _numInfo, temp, null);
            }
            return _numInfo!;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            VerifyWritable();
            _numInfo = value;
        }
    }
    
    private void VerifyWritable()
    {
        if (_isReadOnly)
        {
            throw new InvalidOperationException(SR.InvalidOperation_ReadOnly);
        }
    }
    
    // Get the current user default culture. This one is almost always used, so we create it by default.
    private static volatile CultureInfo s_userDefaultCulture = InvariantCulture;
    
    public static CultureInfo CurrentCulture
    {
        get
        {
            return /*s_currentThreadCulture ??
                   s_DefaultThreadCurrentCulture ??*/
                   s_userDefaultCulture;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            throw new NotImplementedException();
            // if (s_asyncLocalCurrentCulture == null)
            // {
            //     Interlocked.CompareExchange(ref s_asyncLocalCurrentCulture, new AsyncLocal<CultureInfo>(AsyncLocalSetCurrentCulture), null);
            // }
            // s_asyncLocalCurrentCulture!.Value = value;
        }
    }


    public virtual object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(NumberFormatInfo))
        {
            return NumberFormat;
        }
        // if (formatType == typeof(DateTimeFormatInfo))
        // {
        //     return DateTimeFormat;
        // }

        return null;
    }
    
}