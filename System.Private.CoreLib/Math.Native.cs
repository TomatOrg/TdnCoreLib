// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/*============================================================
**
**
**
** Purpose: Some floating-point math operations
**
**
===========================================================*/

using System.Runtime.CompilerServices;

namespace System;

public static partial class Math
{
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Acos(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Acosh(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Asin(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Asinh(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Atan(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Atanh(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Atan2(double y, double x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Cbrt(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Ceiling(double a);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Cos(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Cosh(double value);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Exp(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Floor(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double FusedMultiplyAdd(double x, double y, double z);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Log(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Log2(double x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Log10(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Pow(double x, double y);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Sin(double a);

    public static unsafe (double Sin, double Cos) SinCos(double x)
    {
        double sin, cos;
        SinCos(x, &sin, &cos);
        return (sin, cos);
    }

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Sinh(double value);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Sqrt(double d);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Tan(double a);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern double Tanh(double value);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern double FMod(double x, double y);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern unsafe double ModF(double x, double* intptr);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern unsafe void SinCos(double x, double* sin, double* cos);
}