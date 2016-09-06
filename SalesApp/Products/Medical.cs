using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Products
{
    public class Medical : IProduct
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool HasaBasicTax { get; private set; }
        public bool HasaImportTax { get; private set; }

        public Medical(string name, decimal price, bool hasaImportTax)
        {
            Name = name;
            Price = price;
            HasaBasicTax = false;
            HasaImportTax = hasaImportTax;
        }
    }
}
