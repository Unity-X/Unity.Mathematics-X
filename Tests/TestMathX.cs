using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MathematicsX;

namespace Unity.MathematicsX.Tests
{
    [TestFixture]
    public class TestMathX
    {
        [Test]
        public static void TestRound()
        {
            // ints
            {
                // positive mod
                {
                    Assert.AreEqual(100, mathX.roundStep(115, 50)); // down
                    Assert.AreEqual(150, mathX.roundStep(145, 50)); // up
                    Assert.AreEqual(150, mathX.roundStep(150, 50)); // equal
                    Assert.AreEqual(-50, mathX.roundStep(-40, 50)); // down
                    Assert.AreEqual(0, mathX.roundStep(-10, 50));   // up
                    Assert.AreEqual(-50, mathX.roundStep(-50, 50)); // equal

                }

                // negative mod
                {
                    Assert.AreEqual(100, mathX.roundStep(115, -50)); // down
                    Assert.AreEqual(150, mathX.roundStep(145, -50)); // up
                    Assert.AreEqual(150, mathX.roundStep(150, -50)); // equal
                    Assert.AreEqual(-50, mathX.roundStep(-40, -50)); // down
                    Assert.AreEqual(0, mathX.roundStep(-10, -50));   // up
                    Assert.AreEqual(-50, mathX.roundStep(-50, -50)); // equal
                }
            }

            // floats
            {
                // positive mod
                {
                    Assert.AreEqual(101, mathX.roundStep(115.5f, 50.5f)); // down
                    Assert.AreEqual(151.5f, mathX.roundStep(145.5f, 50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.roundStep(150.5f, 50.5f)); // equal
                    Assert.AreEqual(-50.5f, mathX.roundStep(-40.5f, 50.5f)); // down
                    Assert.AreEqual(0, mathX.roundStep(-10.5f, 50.5f));   // up
                    Assert.AreEqual(-50.5f, mathX.roundStep(-50.5f, 50.5f)); // equal

                }

                // negative mod
                {
                    Assert.AreEqual(101, mathX.roundStep(115.5f, -50.5f)); // down
                    Assert.AreEqual(151.5f, mathX.roundStep(145.5f, -50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.roundStep(150.5f, -50.5f)); // equal
                    Assert.AreEqual(-50.5f, mathX.roundStep(-40.5f, -50.5f)); // down
                    Assert.AreEqual(0, mathX.roundStep(-10.5f, -50.5f));   // up
                    Assert.AreEqual(-50.5f, mathX.roundStep(-50.5f, -50.5f)); // equal
                }
            }
        }

        [Test]
        public static void TestCeil()
        {
            // ints
            {
                // positive mod
                {
                    Assert.AreEqual(150, mathX.ceil(115, 50)); // down
                    Assert.AreEqual(150, mathX.ceil(145, 50)); // up
                    Assert.AreEqual(150, mathX.ceil(150, 50)); // equal
                    Assert.AreEqual(-100, mathX.ceil(-115, 50)); // down
                    Assert.AreEqual(-100, mathX.ceil(-145, 50)); // up
                    Assert.AreEqual(-150, mathX.ceil(-150, 50)); // equal
                }

                // negative mod
                {
                    Assert.AreEqual(100, mathX.ceil(115, -50)); // down
                    Assert.AreEqual(100, mathX.ceil(145, -50)); // up
                    Assert.AreEqual(150, mathX.ceil(150, -50)); // equal
                    Assert.AreEqual(-50, mathX.ceil(-40, -50)); // down
                    Assert.AreEqual(-50, mathX.ceil(-10, -50));   // up
                    Assert.AreEqual(-50, mathX.ceil(-50, -50)); // equal
                }
            }

            // floats
            {
                // positive mod
                {
                    Assert.AreEqual(151.5f, mathX.ceil(115.5f, 50.5f)); // down
                    Assert.AreEqual(151.5f, mathX.ceil(145.5f, 50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.ceil(151.5f, 50.5f)); // equal
                    Assert.AreEqual(0, mathX.ceil(-40.5f, 50.5f)); // down
                    Assert.AreEqual(0, mathX.ceil(-10.5f, 50.5f));   // up
                    Assert.AreEqual(-50.5f, mathX.ceil(-50.5f, 50.5f)); // equal

                }

                // negative mod
                {
                    Assert.AreEqual(101f, mathX.ceil(115.5f, -50.5f)); // down
                    Assert.AreEqual(101f, mathX.ceil(145.5f, -50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.ceil(151.5f, -50.5f)); // equal
                    Assert.AreEqual(-50.5f, mathX.ceil(-40.5f, -50.5f)); // down
                    Assert.AreEqual(-50.5f, mathX.ceil(-10.5f, -50.5f));   // up
                    Assert.AreEqual(-50.5f, mathX.ceil(-50.5f, -50.5f)); // equal
                }
            }
        }

        [Test]
        public static void TestFloor()
        {
            // ints
            {
                // positive mod
                {
                    Assert.AreEqual(100, mathX.floorStep(115, 50)); // down
                    Assert.AreEqual(100, mathX.floorStep(145, 50)); // up
                    Assert.AreEqual(150, mathX.floorStep(150, 50)); // equal
                    Assert.AreEqual(-150, mathX.floorStep(-115, 50)); // down
                    Assert.AreEqual(-150, mathX.floorStep(-145, 50)); // up
                    Assert.AreEqual(-150, mathX.floorStep(-150, 50)); // equal
                }

                // negative mod
                {
                    Assert.AreEqual(150, mathX.floorStep(115, -50)); // down
                    Assert.AreEqual(150, mathX.floorStep(145, -50)); // up
                    Assert.AreEqual(150, mathX.floorStep(150, -50)); // equal
                    Assert.AreEqual(-100, mathX.floorStep(-140, -50)); // down
                    Assert.AreEqual(-100, mathX.floorStep(-110, -50));   // up
                    Assert.AreEqual(-150, mathX.floorStep(-150, -50)); // equal
                }
            }

            // floats
            {
                // positive mod
                {
                    Assert.AreEqual(101f, mathX.floorStep(115.5f, 50.5f)); // down
                    Assert.AreEqual(101f, mathX.floorStep(145.5f, 50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.floorStep(151.5f, 50.5f)); // equal
                    Assert.AreEqual(-151.5f, mathX.floorStep(-140.5f, 50.5f)); // down
                    Assert.AreEqual(-151.5f, mathX.floorStep(-110.5f, 50.5f));   // up
                    Assert.AreEqual(-151.5f, mathX.floorStep(-151.5f, 50.5f)); // equal

                }

                // negative mod
                {
                    Assert.AreEqual(151.5f, mathX.floorStep(115.5f, -50.5f)); // down
                    Assert.AreEqual(151.5f, mathX.floorStep(145.5f, -50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.floorStep(151.5f, -50.5f)); // equal
                    Assert.AreEqual(-101f, mathX.floorStep(-140.5f, -50.5f)); // down
                    Assert.AreEqual(-101f, mathX.floorStep(-110.5f, -50.5f));   // up
                    Assert.AreEqual(-151.5f, mathX.floorStep(-151.5f, -50.5f)); // equal
                }
            }
        }
    }
}