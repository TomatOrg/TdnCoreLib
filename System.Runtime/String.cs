using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public sealed partial class String
{

    public static readonly string Empty = "";
    
    private int _length;
    private char _firstChar;

    public int Length => _length;
    
    [IndexerName("Chars")]
    public char this[int index]
    {
        get
        {
            if ((uint)index >= (uint)_length)
            {
                ThrowHelper.ThrowIndexOutOfRangeException();
            }
            return Unsafe.Add(ref _firstChar, (nint)(uint)index /* force zero-extension */);
        }
    }
    
    public static bool IsNullOrEmpty([NotNullWhen(false)] string? value)
    {
        return value == null || value.Length == 0;
    }

    public static bool IsNullOrWhiteSpace([NotNullWhenAttribute(false)] string? value)
    {
        if (value == null)
            return true;
        
        for (var i = 0; i < value.Length; i++)
        {
            if (!char.IsWhiteSpace(value[i]))
            {
                return false;
            }
        }
        
        return true;
    }

    
}