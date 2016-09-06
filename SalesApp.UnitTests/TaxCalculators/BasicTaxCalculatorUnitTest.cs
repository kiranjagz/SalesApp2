using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.TaxCalculators;
using SalesApp.Products;
using SalesApp.Rounding;

namespace SalesApp.UnitTests.TaxCalculators
{
    [TestClass]
    public class BasicTaxCalculatorUnitTest
    {
        private ITaxCalculator _basicTaxCalculator;
        private IProduct _product;

        [TestMethod]
        public void Test_for_a_product_that_has_a_basic_tax()
        {
            _basicTaxCalculator = new BasicTaxCalculator(new RoundingUp());

            _product = new Other("other product that has basic tax", 10.00m, true);

            var basicTax = _basicTaxCalculator.CalculateTax(_product);

            Assert.AreEqual(1.00m, basicTax);
        }

        [TestMethod]
        public void Test_for_a_product_that_has_not_have_a_basic_tax()
        {
            _basicTaxCalculator = new BasicTaxCalculator(new RoundingUp());

            _product = new Book("book product that has no basic tax", 10.00m, false);

            var basicTax = _basicTaxCalculator.CalculateTax(_product);

            Assert.AreEqual(0.00m, basicTax);
        }

        [TestMethod]
        public void Test_for_a_product_that_has_a_basic_tax_with_a_negative_price()
        {
            try
            {
                _basicTaxCalculator = new BasicTaxCalculator(new RoundingUp());

                _product = new Other("other product that has basic tax with a negative price", -10.00m, true);

                var baiscTax = _basicTaxCalculator.CalculateTax(_product);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }
    }
}
