namespace System.Collections.Generic;

public abstract class Comparer<T> : IComparer, IComparer<T>
{
    public static Comparer<T> Default { get; } = (Comparer<T>)ComparerHelpers.CreateDefaultComparer(typeof(T));

    public static Comparer<T> Create(Comparison<T> comparison)
    {
        ArgumentNullException.ThrowIfNull(comparison);

        return new ComparisonComparer<T>(comparison);
    }

    public abstract int Compare(T? x, T? y);

    int IComparer.Compare(object? x, object? y)
    {
        if (x == null) return y == null ? 0 : -1;
        if (y == null) return 1;
        if (x is T && y is T) return Compare((T)x, (T)y);
        ThrowHelper.ThrowArgumentException(SR.Argument_InvalidArgumentForComparison);
        return 0;
    }
}

internal sealed class ComparisonComparer<T> : Comparer<T>
{
    private readonly Comparison<T> _comparison;

    public ComparisonComparer(Comparison<T> comparison)
    {
        _comparison = comparison;
    }

    public override int Compare(T? x, T? y) => _comparison(x!, y!);
}
