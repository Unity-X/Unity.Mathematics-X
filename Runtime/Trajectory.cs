using Unity.Mathematics;
using static Unity.Mathematics.math;

namespace Unity.MathematicsX
{
    public static partial class mathX
    {
        public static class Trajectory
        {

            /// <summary>
            /// Given a displacement and a gravity, returns the smallest launch required launch velocity for a projectile.
            /// <para/>
            /// <b>NB:</b> If gravity is 0, the return vector will be 0.
            /// </summary>
            /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
            /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
            /// <param name="g">The 2D gravity.</param>
            /// <returns>The smallest launch required launch velocity.</returns>
            public static float2 SmallestLaunchVelocity(float dx, float dy, float2 g)
            {
                // No gravity ? return 0
                if (lengthsq(g) < EPSILON)
                    return new float2(0, 0);

                // Gravity already 1D ? Don't rotate
                if (g.x == 0)
                {
                    return SmallestLaunchVelocity(dx, dy, g.y);
                }

                // Rotate all the values so the gravity points downward
                float gravityAngleAdjustment = angle2d(g) + 0.5f * PI;
                float2x2 rot = Unity.Mathematics.float2x2.Rotate(-gravityAngleAdjustment);

                float2 d = new float2(dx, dy);

                d = mul(rot, d);
                g = mul(rot, g);

                float2 result = SmallestLaunchVelocity(d.x, d.y, g.y);

                // Rotate the result in opposite direction
                return mul(inverse(rot), result);
            }

            /// <summary>
            /// Given a displacement and a gravity, returns the smallest launch required launch velocity for a projectile.
            /// <para/>
            /// <b>NB:</b> If gravity is 0, the return vector will be 0.
            /// </summary>
            /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
            /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
            /// <param name="g">The vertical gravity.</param>
            /// <returns>The smallest launch required launch velocity.</returns>
            public static float2 SmallestLaunchVelocity(float dx, float dy, float g)
            {
                float angle = AngleForSmallestLaunchVelocity(dx, dy, g);
                float speed = LaunchSpeed(dx, dy, angle, g);
                return new float2(cos(angle) * speed, sin(angle) * speed);
            }

            /// <summary>
            /// Given a displacement and a gravity, returns the launch angle of a projectile which will require the smallest launch speed.
            /// </summary>
            /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
            /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
            /// <param name="g">The vertical gravity.</param>
            /// <returns>The launch angle of a projectile which will require the smallest launch speed. Between -0.5*PI and 1.5*PI</returns>
            public static float AngleForSmallestLaunchVelocity(float dx, float dy, float g)
            {
                float yOverX = dy / dx;

                if (isnan(yOverX) || !isfinite(yOverX))
                    return dy > 0
                        ? PI * 0.5f
                        : PI * -0.5f;

                float angle = atan(yOverX);
                const float PI_OVER_2 = 0.5f * PI;

                float gSign = math.sign(g);

                if (dx > 0)
                    return remap(PI_OVER_2 * gSign, PI_OVER_2 * -gSign, 0, PI_OVER_2 * -gSign, angle);
                else
                    return remap(PI_OVER_2 * -gSign, PI_OVER_2 * gSign, PI, PI + (PI_OVER_2 * gSign), angle);
            }

            /// <summary>
            /// Given a displacement, a launch angle and a gravity, returns the required launch speed of a projectile.
            /// <para/>
            /// <b>NB:</b> If gravity is 0, the return value will be 0.
            /// </summary>
            /// <param name="dx">The horizontal displacement. finalPosition.x - startPosition.x</param>
            /// <param name="dy">The vertical displacement. finalPosition.y - startPosition.y</param>
            /// <param name="angle">The launch angle of the projectile.</param>
            /// <param name="g">The vertical gravity.</param>
            /// <returns>The required launch speed of a projectile.</returns>
            public static float LaunchSpeed(float dx, float dy, float angle, float g)
            {
                // No gravity ? return 0
                if (abs(g) < EPSILON)
                    return 0;

                // With the following formulas, find v
                // dx = v * cos(angle) * t
                // dy = v * sin(angle) * t   +   (g * t^2) / 2

                // get angle sin/cos
                sincos(angle, out float sin, out float cos);

                // If cos is close to zero, this means the angle is vertical. To avoid calculation errors, treat the problem in 1D instead
                if (abs(cos) < 0.0001f)
                {
                    if (samesign(dy, g))
                    {
                        return 0; // no need for any launch speed, the gravity will do all the work
                    }
                    else
                    {
                        // 1D calculation
                        float t = sqrt(-2 * dy / g);

                        return abs(t) < EPSILON
                            ? 0
                            : -math.sign(g) * (dy - (0.5f * g * t * t)) / t;
                    }
                }

                // 2D calculations
                return dx / (sqrt(2 * (dy - (dx * sin / cos)) / g) * cos);
            }

            public static float2 Position(float2 startingPosition, float2 velocity, float2 gravity, float time)
            {
                return startingPosition + Displacement(velocity, gravity, time);
            }

            public static float2 Displacement(float2 velocity, float2 gravity, float time)
            {
                return time * velocity + (time * time * 0.5f * gravity);
            }

            public static float TravelDistance(float2 velocity, float2 gravity, float time)
            {
                // based on this formula:
                // https://www.desmos.com/calculator/erz2yzyffy
                // It's the integral of the velocity function: sqrt((v1 + t*g1)^2 + (v2 + t*g2)^2)

                float a = velocity.x;
                float b = velocity.y;
                float g = gravity.x;
                float h = gravity.y;
                float v = a * a + b * b;
                float p = g * g + h * h;

                if (p <= math.EPSILON)
                {
                    return math.length(velocity) * time;
                }

                if (v <= math.EPSILON)
                {
                    return (time / 2f) * math.sqrt(time * time * math.lengthsq(gravity));
                }

                float x = time;

                float k = 1f / (2 * math.pow(p, 1.5f));
                float srp = math.sqrt(p);
                float srv = math.sqrt(v);
                float ag = a * g;
                float bh = b * h;
                float bg = b * g;
                float ah = a * h;
                float bgah2 = (bg - ah) * (bg - ah);

                float c = -k * (srp * (ag + bh) * srv + bgah2 * math.log(math.max(srp * srv + ag + bh, 0.0001f)));
                float longSquareRoot = math.sqrt(v + (2 * ag * x) + (2 * bh * x) + (p * x * x));
                return k * (srp * (ag + bh + x * p) * longSquareRoot + bgah2 * math.log(srp * longSquareRoot + ag + bh + g * g * x + h * h * x)) + c;
            }

            public static float TravelDurationApprox(float2 velocity, float2 gravity, float traveledDistance, float precision = 0.01f)
            {
                if (traveledDistance <= math.EPSILON) // if distance 0, already reached!
                    return 0f;

                float vl2 = math.lengthsq(velocity);
                float gl2 = math.lengthsq(gravity);

                if (vl2 + gl2 < math.EPSILON * 2f) // if moving or accelerating to slow, takes infinit time
                    return float.PositiveInfinity;


                // Try approximating the needed travel duration. Slowly getting closer to the real value
                // NB: With a precision of 0.01f, results usually take between 8 and 20 iterations
                // WHY ? Why not find the actual formula for this? Because it's hell'a complicated. Try to isolate X in the 'TraveledDistance' formula if you want.

                float time = 5f + math.sqrt(traveledDistance / math.max(gl2, 0.0001f));

                float radius = time / 2f;
                bool maxRadiusSet = false;

                while (radius > precision)
                {
                    var dist = mathX.Trajectory.TravelDistance(velocity, gravity, time);

                    if (dist > traveledDistance)
                    {
                        time -= radius;

                        maxRadiusSet = true;
                    }
                    else
                    {
                        if (!maxRadiusSet)
                        {
                            time *= 2f;
                            radius *= 2f;
                        }
                        else
                        {
                            time += radius;
                        }
                    }

                    radius *= maxRadiusSet ? 0.5f : 1;
                }
                return time;
            }
        }
    }
}