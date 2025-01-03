// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Reserved for use by a compiler for tracking metadata.
    /// This attribute should not be used by developers in source code.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class ScopedRefAttribute : Attribute
    {
        /// <summary>Initializes the attribute.</summary>
        public ScopedRefAttribute()
        {
        }
    }
}
