using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.Products;

namespace SalesApp.UnitTests.Products
{
    [TestClass]
    public class MedicalUnitTest
    {
        private IProduct _medicalProduct;

        [TestMethod]
        public void Test_Medical_has_no_basictax()
        {
            _medicalProduct = new Medical("medical", 10.00m, false);

            Assert.IsFalse(_medicalProduct.HasaBasicTax);
        }

        [TestMethod]
        public void Test_Medical_has_importtax()
        {
            _medicalProduct = new Medical("medical", 10.00m, true);

            Assert.IsTrue(_medicalProduct.HasaImportTax);
        }
    }
}
