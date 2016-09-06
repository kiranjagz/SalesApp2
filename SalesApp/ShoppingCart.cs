using SalesApp.Products;
using SalesApp.Rounding;
using SalesApp.TaxCalculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp
{
    public class ShoppingCart
    {
        private List<IProduct> _products;
        private List<ITaxCalculator> _listTaxCalculator;
        private ITaxCalculator _aggregatedTaxCalculator;

        decimal total = 0;
        decimal totalTaxes = 0;

        public ShoppingCart(List<IProduct> products, List<ITaxCalculator> iTaxCalculator)
        {
            _products = products;
            _listTaxCalculator = iTaxCalculator;
        }

        public string Display()
        {
            StringBuilder sb = new StringBuilder();
            _aggregatedTaxCalculator = new AggregatedTaxCalculator(_listTaxCalculator);

            foreach (var item in _products)
            {
                var itemTaxes = _aggregatedTaxCalculator.CalculateTax(item);
                var itemTotal = item.Price + itemTaxes;

                totalTaxes = totalTaxes + itemTaxes;
                total = total + itemTotal;

                sb.AppendLine("1 " + item.Name + " at " + itemTotal.ToString("f"));
            }

            sb.AppendLine("Sales Taxes: " + totalTaxes.ToString("f"));
            sb.AppendLine("Total: " + total.ToString("f"));
            sb.AppendLine("=================================================");

            return sb.ToString();
        }

        //    private decimal CalculateTotal(decimal itemTotal)
        //    {
        //        decimal total = 0;

        //        return total;
        //    }

        //    private decimal ProductCalculateTotalTaxes(IProduct product)
        //    {
        //        decimal totalTaxes = 0;

        //        return totalTaxes;
        //    }
    }
}
