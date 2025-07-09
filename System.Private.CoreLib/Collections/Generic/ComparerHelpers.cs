// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;
using static System.RuntimeTypeHandle;

namespace System.Collections.Generic;

/// <summary>
/// Helper class for creating the default <see cref="Comparer{T}"/> and <see cref="EqualityComparer{T}"/>.
/// </summary>
/// <remarks>
/// This class is intentionally type-unsafe and non-generic to minimize the generic instantiation overhead of creating
/// the default comparer/equality comparer for a new type parameter. Efficiency of the methods in here does not matter too
/// much since they will only be run once per type parameter, but generic code involved in creating the comparers needs to be
/// kept to a minimum.
/// </remarks>
internal static class ComparerHelpers
{
    /// <summary>
    /// Creates the default <see cref="Comparer{T}"/>.
    /// </summary>
    /// <param name="type">The type to create the default comparer for.</param>
    /// <remarks>
    /// The logic in this method is replicated in vm/compile.cpp to ensure that NGen saves the right instantiations,
    /// and in vm/jitinterface.cpp so the jit can model the behavior of this method.
    /// </remarks>
    internal static object CreateDefaultComparer(Type type)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates the default <see cref="EqualityComparer{T}"/>.
    /// </summary>
    /// <param name="type">The type to create the default equality comparer for.</param>
    /// <remarks>
    /// The logic in this method is replicated in vm/compile.cpp to ensure that NGen saves the right instantiations.
    /// </remarks>
    internal static object CreateDefaultEqualityComparer(Type type)
    {
        throw new NotImplementedException();
    }
}