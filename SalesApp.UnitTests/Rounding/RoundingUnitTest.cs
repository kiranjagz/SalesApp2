using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.Rounding;

namespace SalesApp.UnitTests.Rounding
{
    [TestClass]
    public class RoundingUnitTest
    {
        private IRounding _roundingUp;

        [TestMethod]
        public void Test_that_rounds_to_two_decimal_place()
        {
            _roundingUp = new RoundingUp();

            decimal value = 1.499m;

            var actual = _roundingUp.Round(value);

            Assert.AreEqual(1.50m, actual);
        }
    }
}
