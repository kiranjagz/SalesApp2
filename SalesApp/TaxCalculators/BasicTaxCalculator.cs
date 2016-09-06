using SalesApp.Products;
using SalesApp.Rounding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.TaxCalculators
{
    public class BasicTaxCalculator : ITaxCalculator
    {
        private IRounding _rounding;

        public BasicTaxCalculator(IRounding rounding)
        {
            _rounding = rounding;
        }

        public decimal CalculateTax(IProduct product)
        {
            decimal tax;
            if (!product.HasaBasicTax)
                return 0;

            if (product.Price >= 0)
            {
                tax = (product.Price * 10 / 100);
                tax = _rounding.Round(tax);
            }
            else
                throw new ArgumentOutOfRangeException(product.Price.ToString());

            return tax;
        }
    }
}
