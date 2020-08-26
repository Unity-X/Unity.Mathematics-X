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
    }
#pragma warning restore IDE1006 // Naming Styles
}