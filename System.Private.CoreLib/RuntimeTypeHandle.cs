using System.Reflection;
using System.Runtime.InteropServices;

namespace System;

[StructLayout(LayoutKind.Sequential)]
public struct RuntimeTypeHandle
{
    internal RuntimeTypeInfo _type;
}