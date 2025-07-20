namespace System.Text;

public abstract class Encoding
{

    public static Encoding UTF8
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public virtual bool TryGetBytes(ReadOnlySpan<char> chars, Span<byte> bytes, out int bytesWritten)
    {
        throw new NotImplementedException();
    }
    
    public virtual byte[] GetBytes(string s)
    {
        ArgumentNullException.ThrowIfNull(s);
        throw new NotImplementedException();
    }
    
}