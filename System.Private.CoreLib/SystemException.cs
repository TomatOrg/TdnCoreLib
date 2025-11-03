// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;

namespace System;

public class SystemException : Exception
{
    public SystemException()
        : base(SR.Arg_SystemException)
    {
    }

    public SystemException(string? message)
        : base(message)
    {
    }

    public SystemException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}