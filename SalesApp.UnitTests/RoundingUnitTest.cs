using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesApp.UnitTests
{
    [TestClass]
    public class RoundingUnitTest
    {
        [TestMethod]
        public void TestRoundUptoTwoDecimals()
        {
            decimal value = 1.499m;

            var actual = Math.Ceiling(value * 100) / 100.0M;

            Assert.AreEqual(1.50m, actual);
        }
    }
}
