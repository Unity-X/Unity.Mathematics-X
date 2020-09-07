using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Unity.MathematicsX
{
#pragma warning disable IDE1006 // Naming Styles
    public static partial class mathX
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle2d(float2 v)
        {
            return math.atan2(v.y, v.x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(int v)
        {
            return Math.Sign(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(int2 v)
        {
            return math.int2(sign(v.x), sign(v.y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(int3 v)
        {
            return math.int3(sign(v.x), sign(v.y), sign(v.z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(int4 v)
        {
            return math.int4(sign(v.x), sign(v.y), sign(v.z), sign(v.w));
        }
    }
#pragma warning restore IDE1006 // Naming Styles
}