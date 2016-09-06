using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.Products;

namespace SalesApp.UnitTests.Products
{
    [TestClass]
    public class OtherUnitTest
    {
        private IProduct _otherProduct;

        [TestMethod]
        public void Test_Other_has_no_basictax()
        {
            _otherProduct = new Other("other", 10.00m, false);

            Assert.IsTrue(_otherProduct.HasaBasicTax);
        }

        [TestMethod]
        public void Test_Other_has_importtax()
        {
            _otherProduct = new Other("other", 10.00m, true);

            Assert.IsTrue(_otherProduct.HasaBasicTax);
        }
    }
}
