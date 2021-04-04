using Unity.Mathematics;

namespace Unity.MathematicsX
{
    public static partial class mathX
    {
        public static class Trajectory
        {
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