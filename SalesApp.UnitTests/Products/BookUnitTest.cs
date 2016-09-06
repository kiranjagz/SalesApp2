using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.Products;

namespace SalesApp.UnitTests.Products
{
    [TestClass]
    public class BookUnitTest
    {
        private IProduct _bookProduct;

        [TestMethod]
        public void Test_Books_has_no_basictax()
        {
            _bookProduct = new Book("book", 10.00m, false);

            Assert.IsFalse(_bookProduct.HasaBasicTax);
        }

        [TestMethod]
        public void Test_Books_has_importtax()
        {
            _bookProduct = new Book("book", 10.00m, true);

            Assert.IsTrue(_bookProduct.HasaImportTax);
        }
    }
}
