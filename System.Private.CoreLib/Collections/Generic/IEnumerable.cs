namespace System.Collections.Generic;

public interface IEnumerable<out T> : IEnumerable
{
    IEnumerator<T> GetEnumerator();
}