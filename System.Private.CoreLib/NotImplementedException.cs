// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System;

/// <summary>
/// The exception that is thrown when a requested method or operation is not implemented.
/// </summary>
public class NotImplementedException : SystemException
{
    public NotImplementedException()
        : base(SR.Arg_NotImplementedException)
    {
    }
    public NotImplementedException(string? message)
        : base(message)
    {
    }
    public NotImplementedException(string? message, Exception? inner)
        : base(message, inner)
    {
    }
}