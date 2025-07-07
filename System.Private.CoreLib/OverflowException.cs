// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System;

/// <summary>
/// The exception that is thrown when an arithmetic, casting, or conversion operation in a checked context results in an overflow.
/// </summary>
public class OverflowException : ArithmeticException
{
    public OverflowException()
        : base(SR.Arg_OverflowException)
    {
    }

    public OverflowException(string? message)
        : base(message)
    {
    }

    public OverflowException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}