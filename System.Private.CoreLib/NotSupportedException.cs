// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System;

/// <summary>
/// The exception that is thrown when an invoked method is not supported,
/// typically because it should have been implemented on a subclass.
/// </summary>
public class NotSupportedException : SystemException
{
    public NotSupportedException()
        : base(SR.Arg_NotSupportedException)
    {
    }

    public NotSupportedException(string? message)
        : base(message)
    {
    }

    public NotSupportedException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}