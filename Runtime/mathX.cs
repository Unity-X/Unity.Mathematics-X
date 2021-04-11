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

        /// <summary>
        /// Ceils a value to a given step (e.g. ceil(145, 50) = 150). Using a negative step value with floor instead
        /// </summary>
        public static int ceil(int value, int step)
        {
            int extra = value % step;

            if (extra != 0 && math.sign(extra) == math.sign(step))
                extra -= step;

            return value - extra;
        }

        /// <summary>
        /// Ceils a value to a given step (e.g. ceil(145, 50) = 150). Using a negative step value with floor instead
        /// </summary>
        public static float ceil(float value, float step)
        {
            float extra = value % step;

            if (extra != 0 && math.sign(extra) == math.sign(step))
                extra -= step;

            return value - extra;
        }

        public static int round(int value, int stepSize)
        {
            return (int)(math.round(value / (float)stepSize) * stepSize);
        }

        public static float round(float value, float stepSize)
        {
            return math.round(value / stepSize) * stepSize;
        }

        /// <summary>
        /// Floors a value to a given step (e.g. ceil(145, 50) = 100). Using a negative step value with ceil instead
        /// </summary>
        public static int floor(int value, int step)
        {
            int extra = value % step;

            if (extra != 0 && math.sign(extra) != math.sign(step))
                extra += step;

            return value - extra;
        }

        /// <summary>
        /// Floors a value to a given step (e.g. ceil(145, 50) = 100). Using a negative step value with ceil instead
        /// </summary>
        public static float floor(float value, float step)
        {
            float extra = value % step;

            if (extra != 0 && math.sign(extra) != math.sign(step))
                extra += step;

            return value - extra;
        }

        /// <summary>
        /// Modulo operation (the positive remainder). 
        /// </summary>
        public static int mod(int value, int modulo)
        {
            int result = value % modulo;
            if ((result < 0 && modulo > 0) || (result > 0 && modulo < 0))
            {
                result += modulo;
            }
            return result;
        }

        /// <summary>
        /// Modulo operation (the positive remainder). 
        /// </summary>
        public static float mod(float value, float modulo)
        {
            float result = value % modulo;
            if ((result < 0 && modulo > 0) || (result > 0 && modulo < 0))
            {
                result += modulo;
            }
            return result;
        }

        public static bool even(int v) => v % 2 == 0;
        public static bool odd(int v) => v % 2 != 0;

        public static float2 clampLength(float2 v, float min, float max)
        {
            float l = math.length(v);
            return math.clamp(l, min, max) * (v / l);
        }

        public static float3 clampLength(float3 v, float min, float max)
        {
            float l = math.length(v);
            return math.clamp(l, min, max) * (v / l);
        }

        public static int lengthmanhattan(int2 v) => math.abs(v.x) + math.abs(v.y);
        public static int lengthmanhattan(int3 v) => math.abs(v.x) + math.abs(v.y) + math.abs(v.z);
        public static int lengthmanhattan(int4 v) => math.abs(v.x) + math.abs(v.y) + math.abs(v.z) + math.abs(v.w);

        public static int distancemanhattan(int a , int  b) => math.abs(a - b);
        public static int distancemanhattan(int2 a, int2 b) => lengthmanhattan(a - b);
        public static int distancemanhattan(int3 a, int3 b) => lengthmanhattan(a - b);
        public static int distancemanhattan(int4 a, int4 b) => lengthmanhattan(a - b);
    }
#pragma warning restore IDE1006 // Naming Styles
}