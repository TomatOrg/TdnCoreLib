using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public struct Nullable<T> where T : struct
{

    private T _value;
    private readonly bool _hasValue;

    public Nullable(T value)
    {
        _value = value;
        _hasValue = true;
    }
    
    public readonly bool HasValue => _hasValue;

    public T Value
    {
        get
        {
            if (!_hasValue)
            {
                ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
            }
            return _value;
        }
    }
    
    public readonly T GetValueOrDefault() => _value;
    public readonly T GetValueOrDefault(T defaultValue) => _hasValue ? _value : defaultValue;
    
    public override bool Equals(object? other)
    {
        if (!_hasValue) return other == null;
        if (other == null) return false;
        return _value.Equals(other);
    }
    
    public override int GetHashCode() => _hasValue ? _value.GetHashCode() : 0;
    public override string? ToString() => _hasValue ? _value.ToString() : "";
    
    public static implicit operator T?(T value) => new T?(value);
    public static explicit operator T(T? value) => value!.Value;
    
}