using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.Products;

namespace SalesApp.UnitTests.Products
{
    [TestClass]
    public class FoodUnitTest
    {
        private IProduct _foodProduct;

        [TestMethod]
        public void Test_Food_has_no_basictax()
        {
            _foodProduct = new Food("food", 10.00m, false);

            Assert.IsFalse(_foodProduct.HasaBasicTax);
        }

        [TestMethod]
        public void Test_Food_has_importtax()
        {
            _foodProduct = new Food("food", 10.00m, true);

            Assert.IsTrue(_foodProduct.HasaImportTax);
        }
    }
}
