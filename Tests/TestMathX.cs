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
                    Assert.AreEqual(100, mathX.round(115, 50)); // down
                    Assert.AreEqual(150, mathX.round(145, 50)); // up
                    Assert.AreEqual(150, mathX.round(150, 50)); // equal
                    Assert.AreEqual(-50, mathX.round(-40, 50)); // down
                    Assert.AreEqual(0, mathX.round(-10, 50));   // up
                    Assert.AreEqual(-50, mathX.round(-50, 50)); // equal

                }

                // negative mod
                {
                    Assert.AreEqual(100, mathX.round(115, -50)); // down
                    Assert.AreEqual(150, mathX.round(145, -50)); // up
                    Assert.AreEqual(150, mathX.round(150, -50)); // equal
                    Assert.AreEqual(-50, mathX.round(-40, -50)); // down
                    Assert.AreEqual(0, mathX.round(-10, -50));   // up
                    Assert.AreEqual(-50, mathX.round(-50, -50)); // equal
                }
            }

            // floats
            {
                // positive mod
                {
                    Assert.AreEqual(101, mathX.round(115.5f, 50.5f)); // down
                    Assert.AreEqual(151.5f, mathX.round(145.5f, 50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.round(150.5f, 50.5f)); // equal
                    Assert.AreEqual(-50.5f, mathX.round(-40.5f, 50.5f)); // down
                    Assert.AreEqual(0, mathX.round(-10.5f, 50.5f));   // up
                    Assert.AreEqual(-50.5f, mathX.round(-50.5f, 50.5f)); // equal

                }

                // negative mod
                {
                    Assert.AreEqual(101, mathX.round(115.5f, -50.5f)); // down
                    Assert.AreEqual(151.5f, mathX.round(145.5f, -50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.round(150.5f, -50.5f)); // equal
                    Assert.AreEqual(-50.5f, mathX.round(-40.5f, -50.5f)); // down
                    Assert.AreEqual(0, mathX.round(-10.5f, -50.5f));   // up
                    Assert.AreEqual(-50.5f, mathX.round(-50.5f, -50.5f)); // equal
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
                    Assert.AreEqual(100, mathX.floor(115, 50)); // down
                    Assert.AreEqual(100, mathX.floor(145, 50)); // up
                    Assert.AreEqual(150, mathX.floor(150, 50)); // equal
                    Assert.AreEqual(-150, mathX.floor(-115, 50)); // down
                    Assert.AreEqual(-150, mathX.floor(-145, 50)); // up
                    Assert.AreEqual(-150, mathX.floor(-150, 50)); // equal
                }

                // negative mod
                {
                    Assert.AreEqual(150, mathX.floor(115, -50)); // down
                    Assert.AreEqual(150, mathX.floor(145, -50)); // up
                    Assert.AreEqual(150, mathX.floor(150, -50)); // equal
                    Assert.AreEqual(-100, mathX.floor(-140, -50)); // down
                    Assert.AreEqual(-100, mathX.floor(-110, -50));   // up
                    Assert.AreEqual(-150, mathX.floor(-150, -50)); // equal
                }
            }

            // floats
            {
                // positive mod
                {
                    Assert.AreEqual(101f, mathX.floor(115.5f, 50.5f)); // down
                    Assert.AreEqual(101f, mathX.floor(145.5f, 50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.floor(151.5f, 50.5f)); // equal
                    Assert.AreEqual(-151.5f, mathX.floor(-140.5f, 50.5f)); // down
                    Assert.AreEqual(-151.5f, mathX.floor(-110.5f, 50.5f));   // up
                    Assert.AreEqual(-151.5f, mathX.floor(-151.5f, 50.5f)); // equal

                }

                // negative mod
                {
                    Assert.AreEqual(151.5f, mathX.floor(115.5f, -50.5f)); // down
                    Assert.AreEqual(151.5f, mathX.floor(145.5f, -50.5f)); // up
                    Assert.AreEqual(151.5f, mathX.floor(151.5f, -50.5f)); // equal
                    Assert.AreEqual(-101f, mathX.floor(-140.5f, -50.5f)); // down
                    Assert.AreEqual(-101f, mathX.floor(-110.5f, -50.5f));   // up
                    Assert.AreEqual(-151.5f, mathX.floor(-151.5f, -50.5f)); // equal
                }
            }
        }
    }
}