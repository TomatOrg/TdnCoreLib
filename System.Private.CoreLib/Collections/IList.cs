// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections
{
    // An IList is an ordered collection of objects.  The exact ordering
    // is up to the implementation of the list, ranging from a sorted
    // order to insertion order.
    public interface IList : ICollection
    {

        // Removes all items from the list.
        void Clear();

        bool IsReadOnly
        { get; }


        bool IsFixedSize
        {
            get;
        }
    }
}
