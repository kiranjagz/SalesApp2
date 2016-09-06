using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.TaxCalculators;
using SalesApp.Rounding;
using SalesApp.Products;

namespace SalesApp.UnitTests.TaxCalculators
{
    [TestClass]
    public class ImportTaxCalculatorUnitTest
    {
        private ITaxCalculator _importTaxCalculator;
        private IProduct _otherProduct;

        [TestMethod]
        public void Test_for_a_product_that_has_a_import_tax()
        {
            _importTaxCalculator = new ImportTaxCalculator(new RoundingUp());

            _otherProduct = new Other("other product that has import tax", 10.00m, true);

            var importTax = _importTaxCalculator.CalculateTax(_otherProduct);

            Assert.AreEqual(0.50m, importTax);
        }

        [TestMethod]
        public void Test_for_a_product_that_has_not_have_a_import_tax()
        {
            _importTaxCalculator = new ImportTaxCalculator(new RoundingUp());

            _otherProduct = new Other("other product that has import tax", 10.00m, false);

            var importTax = _importTaxCalculator.CalculateTax(_otherProduct);

            Assert.AreEqual(0.00m, importTax);
        }

        [TestMethod]
        public void Test_for_a_product_that_has_a_import_tax_with_a_negative_price()
        {
            try
            {
                _importTaxCalculator = new ImportTaxCalculator(new RoundingUp());

                _otherProduct = new Other("other product that has import tax", -10.00m, true);

                var importTax = _importTaxCalculator.CalculateTax(_otherProduct);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }
    }
}
