using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesApp.TaxCalculators;
using System.Collections.Generic;
using SalesApp.Rounding;
using SalesApp.Products;

namespace SalesApp.UnitTests.TaxCalculators
{
    [TestClass]
    public class AggregatedTaxCalculatorUnitTest
    {
        private List<ITaxCalculator> _listTaxCalculator;
        private ITaxCalculator _aggregatedTaxCalculator;
        private ITaxCalculator _importTaxCalculator;
        private ITaxCalculator _basicTaxCalculator;
        private IProduct _product;

        [TestMethod]
        public void Test_with_both_basic_and_import_tax()
        {
            _importTaxCalculator = new ImportTaxCalculator(new RoundingUp());
            _basicTaxCalculator = new BasicTaxCalculator(new RoundingUp());
            _listTaxCalculator = new List<ITaxCalculator>();
            _listTaxCalculator.Add(_importTaxCalculator);
            _listTaxCalculator.Add(_basicTaxCalculator);

            _product = new Other("other product that has both taxes", 10.00m, true);

            _aggregatedTaxCalculator = new AggregatedTaxCalculator(_listTaxCalculator);

            var tax = _aggregatedTaxCalculator.CalculateTax(_product);

            Assert.AreEqual(1.50m, tax);
        }
    }
}
