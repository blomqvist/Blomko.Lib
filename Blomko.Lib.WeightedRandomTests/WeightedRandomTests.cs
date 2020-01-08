using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Blomko.Lib.WeightedRandom.Tests
{
    [TestClass()]
    public class WeightedRandomTests
    {
        const int RUN_MULTIPLIER = 10000;

        [TestMethod()]
        public void NextRandomWeightTest()
        {
            var w = new WeightedRandom<int>(
                WeightedParameterFactory.Create(1, 1),
                WeightedParameterFactory.Create(2, 29),
                WeightedParameterFactory.Create(3, 60),
                WeightedParameterFactory.Create(4, 10));


            var dict = new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 }
            };

            for (int i = 0; i < 100 * RUN_MULTIPLIER; i++)
            {
                dict[w.Next()]++;
            }

            Assert.IsTrue(Math.Round(dict[1] / (double)RUN_MULTIPLIER, 0) == 1);
            Assert.IsTrue(Math.Round(dict[2] / (double)RUN_MULTIPLIER, 0) == 29);
            Assert.IsTrue(Math.Round(dict[3] / (double)RUN_MULTIPLIER, 0) == 60);
            Assert.IsTrue(Math.Round(dict[4] / (double)RUN_MULTIPLIER, 0) == 10);
        }

        [TestMethod()]
        public void NextEvenWeightTest()
        {
            var w = new WeightedRandom<int>(
                WeightedParameterFactory.Create(1, 25),
                WeightedParameterFactory.Create(2, 25),
                WeightedParameterFactory.Create(3, 25),
                WeightedParameterFactory.Create(4, 25));


            var dict = new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 }
            };

            for (int i = 0; i < 100 * RUN_MULTIPLIER; i++)
            {
                dict[w.Next()]++;
            }

            Assert.IsTrue(Math.Round(dict[1] / (double)RUN_MULTIPLIER, 0) == 25);
            Assert.IsTrue(Math.Round(dict[2] / (double)RUN_MULTIPLIER, 0) == 25);
            Assert.IsTrue(Math.Round(dict[3] / (double)RUN_MULTIPLIER, 0) == 25);
            Assert.IsTrue(Math.Round(dict[4] / (double)RUN_MULTIPLIER, 0) == 25);
        }
    }
}