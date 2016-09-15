using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Products
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
        bool HasaBasicTax { get; }
        bool HasaImportTax { get; }
    }
}
