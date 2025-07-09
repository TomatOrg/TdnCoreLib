// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System;

/// <summary>
/// The exception that is thrown when the format of an argument is invalid, or when a composite format string is not well formed.
/// </summary>
public class FormatException : SystemException
{
    public FormatException()
        : base(SR.Arg_FormatException)
    {
    }

    public FormatException(string? message)
        : base(message)
    {
    }

    public FormatException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}