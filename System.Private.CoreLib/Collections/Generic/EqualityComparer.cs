using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
{
    public static EqualityComparer<T> Default { get; } = (EqualityComparer<T>)ComparerHelpers.CreateDefaultEqualityComparer(typeof(T));

    /// <summary>
    /// Creates an <see cref="EqualityComparer{T}"/> by using the specified delegates as the implementation of the comparer's
    /// <see cref="EqualityComparer{T}.Equals"/> and <see cref="EqualityComparer{T}.GetHashCode"/> methods.
    /// </summary>
    /// <param name="equals">The delegate to use to implement the <see cref="EqualityComparer{T}.Equals"/> method.</param>
    /// <param name="getHashCode">
    /// The delegate to use to implement the <see cref="EqualityComparer{T}.GetHashCode"/> method.
    /// If no delegate is supplied, calls to the resulting comparer's <see cref="EqualityComparer{T}.GetHashCode"/>
    /// will throw <see cref="NotSupportedException"/>.
    /// </param>
    /// <returns>The new comparer.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="equals"/> delegate was null.</exception>
    public static EqualityComparer<T> Create(Func<T?, T?, bool> equals, Func<T, int>? getHashCode = null)
    {
        ArgumentNullException.ThrowIfNull(equals);

        getHashCode ??= _ => throw new NotSupportedException();

        return new DelegateEqualityComparer<T>(equals, getHashCode);
    }

    public abstract bool Equals(T? x, T? y);
    public abstract int GetHashCode([DisallowNull] T obj);

    int IEqualityComparer.GetHashCode(object? obj)
    {
        if (obj == null) return 0;
        if (obj is T) return GetHashCode((T)obj);
        ThrowHelper.ThrowArgumentException(SR.Argument_InvalidArgumentForComparison);
        return 0;
    }

    bool IEqualityComparer.Equals(object? x, object? y)
    {
        if (x == y) return true;
        if (x == null || y == null) return false;
        if ((x is T) && (y is T)) return Equals((T)x, (T)y);
        ThrowHelper.ThrowArgumentException(SR.Argument_InvalidArgumentForComparison);
        return false;
    }
}

internal sealed class DelegateEqualityComparer<T> : EqualityComparer<T>
{
    private readonly Func<T?, T?, bool> _equals;
    private readonly Func<T, int> _getHashCode;

    public DelegateEqualityComparer(Func<T?, T?, bool> equals, Func<T, int> getHashCode)
    {
        _equals = equals;
        _getHashCode = getHashCode;
    }

    public override bool Equals(T? x, T? y) =>
        _equals(x, y);

    public override int GetHashCode([DisallowNull] T obj) =>
        _getHashCode(obj);

    public override bool Equals(object? obj) =>
        obj is DelegateEqualityComparer<T> other &&
        _equals == other._equals &&
        _getHashCode == other._getHashCode;

    public override int GetHashCode() =>
        HashCode.Combine(_equals.GetHashCode(), _getHashCode.GetHashCode());
}
