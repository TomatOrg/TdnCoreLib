namespace System.Numerics;

public interface INumberBase<TSelf>
    where  TSelf : INumberBase<TSelf>?
{
    static abstract bool IsNegative(TSelf value);
}