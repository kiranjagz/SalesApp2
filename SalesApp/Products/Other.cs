using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Products
{
    public class Other : IProduct
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool HasaBasicTax { get; private set; }
        public bool HasaImportTax { get; private set; }

        public Other(string name, decimal price, bool hasaImportTax)
        {
            Name = name;
            Price = price;
            HasaBasicTax = true;
            HasaImportTax = hasaImportTax;
        }
    }
}
