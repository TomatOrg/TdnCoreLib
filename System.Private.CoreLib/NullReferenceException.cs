// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System;

/// <summary>
/// The exception that is thrown when there is an attempt to dereference a <see langword="null"/> object reference.
/// </summary>
public class NullReferenceException : SystemException
{
    public NullReferenceException()
        : base(SR.Arg_NullReferenceException)
    {
    }

    public NullReferenceException(string? message)
        : base(message)
    {
    }

    public NullReferenceException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}