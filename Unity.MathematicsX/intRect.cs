using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using static Unity.Mathematics.math;

namespace Unity.MathematicsX
{
#pragma warning disable IDE1006 // Naming Styles
    [StructLayout(LayoutKind.Sequential)]
    public struct intRect : IEquatable<intRect>, IFormattable
    {
        /// <summary>
        /// Left coordinate of the rectangle.
        /// </summary>
        public int x;

        /// <summary>
        /// Top coordinate of the rectangle.
        /// </summary>
        public int y;

        /// <summary>
        /// Width of the rectangle.
        /// </summary>
        public int width;

        /// <summary>
        /// Height of the rectangle.
        /// </summary>
        public int height;

        /// <summary>
        /// Top left corner of the rectangle. 
        /// </summary>
        public int2 min { get { return new int2(xMin, yMin); } set { xMin = value.x; yMin = value.y; } }

        /// <summary>
        /// Bottom right corner of the rectangle. 
        /// </summary>
        public int2 max { get { return new int2(xMax, yMax); } set { xMax = value.x; yMax = value.y; } }

        public int xMin { get { return math.min(x, x + width); } set { int oldxmax = xMax; x = value; width = oldxmax - x; } }
        public int yMin { get { return math.min(y, y + height); } set { int oldymax = yMax; y = value; height = oldymax - y; } }
        public int xMax { get { return math.max(x, x + width); } set { width = value - x; } }
        public int yMax { get { return math.max(y, y + height); } set { height = value - y; } }

        public int2 position { get { return new int2(x, y); } set { x = value.x; y = value.y; } }
        public int2 size { get { return new int2(width, height); } set { width = value.x; height = value.y; } }

        public intRect(int xMin, int yMin, int width, int height)
        {
            x = xMin;
            y = yMin;
            this.width = width;
            this.height = height;
        }

        public intRect(int2 position, int2 size)
        {
            x = position.x;
            y = position.y;
            width = size.x;
            height = size.y;
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture.NumberFormat);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture.NumberFormat);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("(x:{0}, y:{1}, width:{2}, height:{3})", x.ToString(format, formatProvider), y.ToString(format, formatProvider), width.ToString(format, formatProvider), height.ToString(format, formatProvider));
        }

        public bool Equals(intRect other)
        {
            return x == other.x &&
                y == other.y &&
                width == other.width &&
                height == other.height;
        }
    }

    public static partial class mathX
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static intRect intRect(int xMin, int yMin, int width, int height)
        {
            return new intRect(xMin, yMin, width, height);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static intRect intRect(int2 position, int2 size)
        {
            return new intRect(position, size);
        }

        /// <summary>
        /// Center coordinate of the rectangle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 center(in intRect rect)
        {
            return float2(rect.x + rect.width / 2f, rect.y + rect.height / 2f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static intRect clamp(in intRect rect, in intRect bounds)
        {
            return new intRect(
                xMin: math.clamp(rect.x, bounds.xMin, bounds.xMax),
                yMin: math.clamp(rect.y, bounds.yMin, bounds.yMax),
                width: min(bounds.xMax - rect.x, rect.width),
                height: min(bounds.yMax - rect.y, rect.height));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool contains(in int2 position, in intRect rect)
        {
            return contains(rect, position);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool contains(in intRect rect, in int2 position)
        {
            return position.x >= rect.xMin
                && position.y >= rect.yMin
                && position.x < rect.xMax
                && position.y < rect.yMax;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool overlaps(in intRect a, in intRect b)
        {
            return b.xMin < a.xMax
                && b.xMax > a.xMin
                && b.yMin < a.yMax
                && b.yMax > a.yMin;
        }
    }
#pragma warning restore IDE1006 // Naming Styles
}