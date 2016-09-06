using SalesApp.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Receipt
{
    public class ReceiptBuilder : IReceipt
    {
        private List<IProduct> _products;

        public ReceiptBuilder(List<IProduct> products)
        {
            _products = products;
        }

        public string GenerateReceipt()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in _products)
            { }

            return sb.ToString();
        }
    }
}
