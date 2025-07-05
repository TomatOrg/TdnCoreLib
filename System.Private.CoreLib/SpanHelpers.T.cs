using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace System;

internal static partial class SpanHelpers
{

    public static void Fill<T>(ref T refData, nuint numElements, T value)
    {
        // TODO: special case for 1 byte to use memset instead
        
        // If we reached this point, we cannot vectorize this T, or there are too few
        // elements for us to vectorize. Fall back to an unrolled loop.

        nuint i = 0;

        // Write 8 elements at a time

        if (numElements >= 8)
        {
            nuint stopLoopAtOffset = numElements & ~(nuint)7;
            do
            {
                Unsafe.Add(ref refData, (nint)i + 0) = value;
                Unsafe.Add(ref refData, (nint)i + 1) = value;
                Unsafe.Add(ref refData, (nint)i + 2) = value;
                Unsafe.Add(ref refData, (nint)i + 3) = value;
                Unsafe.Add(ref refData, (nint)i + 4) = value;
                Unsafe.Add(ref refData, (nint)i + 5) = value;
                Unsafe.Add(ref refData, (nint)i + 6) = value;
                Unsafe.Add(ref refData, (nint)i + 7) = value;
            } while ((i += 8) < stopLoopAtOffset);
        }

        // Write next 4 elements if needed

        if ((numElements & 4) != 0)
        {
            Unsafe.Add(ref refData, (nint)i + 0) = value;
            Unsafe.Add(ref refData, (nint)i + 1) = value;
            Unsafe.Add(ref refData, (nint)i + 2) = value;
            Unsafe.Add(ref refData, (nint)i + 3) = value;
            i += 4;
        }

        // Write next 2 elements if needed

        if ((numElements & 2) != 0)
        {
            Unsafe.Add(ref refData, (nint)i + 0) = value;
            Unsafe.Add(ref refData, (nint)i + 1) = value;
            i += 2;
        }

        // Write final element if needed

        if ((numElements & 1) != 0)
        {
            Unsafe.Add(ref refData, (nint)i) = value;
        }
    }
    
}