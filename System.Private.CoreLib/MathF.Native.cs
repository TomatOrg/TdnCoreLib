// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

/*============================================================
**
** Purpose: Some single-precision floating-point math operations
**
===========================================================*/

using System.Runtime.CompilerServices;

namespace System;

public static partial class MathF
{
    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Acos(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Acosh(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Asin(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Asinh(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Atan(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Atanh(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Atan2(float y, float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Cbrt(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Ceiling(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Cos(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Cosh(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Exp(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Floor(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float FusedMultiplyAdd(float x, float y, float z);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Log(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Log2(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Log10(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Pow(float x, float y);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Sin(float x);

    public static unsafe (float Sin, float Cos) SinCos(float x)
    {
        float sin, cos;
        SinCos(x, &sin, &cos);
        return (sin, cos);
    }

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Sinh(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Sqrt(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Tan(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    public static extern float Tanh(float x);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern float FMod(float x, float y);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern unsafe float ModF(float x, float* intptr);

    [MethodImpl(MethodCodeType = MethodCodeType.Native)]
    private static extern unsafe void SinCos(float x, float* sin, float* cos);
}