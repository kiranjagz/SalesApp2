using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.Products;

namespace SalesApp.TaxCalculators
{
    public class AggregatedTaxCalculator : ITaxCalculator
    {
        private List<ITaxCalculator> _taxCalculators;

        public AggregatedTaxCalculator(List<ITaxCalculator> taxCalculators)
        {
            _taxCalculators = taxCalculators;
        }

        public decimal CalculateTax(IProduct product)
        {
            decimal totalTax = 0;

            foreach (var item in _taxCalculators)
            {
                var tax = item.CalculateTax(product);

                totalTax = totalTax + tax;
            }

            return totalTax;
        }
    }
}
