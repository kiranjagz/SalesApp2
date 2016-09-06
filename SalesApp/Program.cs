
using SalesApp.Products;
using SalesApp.TaxCalculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ITaxCalculator> listTaxCalculator = new List<ITaxCalculator>();
            ITaxCalculator importTaxCalculator = new ImportTaxCalculator(new Rounding.RoundingUp());
            ITaxCalculator basicTaxCalculator = new BasicTaxCalculator(new Rounding.RoundingUp());
            listTaxCalculator.Add(importTaxCalculator);
            listTaxCalculator.Add(basicTaxCalculator);

            #region input1
            List<IProduct> productsInput1 = new List<IProduct>();
            productsInput1.Add(new Book("book", 12.49m, false));
            productsInput1.Add(new Other("music CD", 14.99m, false));
            productsInput1.Add(new Food("chocolate bar", 0.85m, false));

            ShoppingCart shoppingCart = new ShoppingCart(productsInput1, listTaxCalculator);
            var output = shoppingCart.Display();

            Console.Write(output);
            #endregion

            #region input2
            List<IProduct> productsInput2 = new List<IProduct>();
            productsInput2.Add(new Food("imported box of chocolates", 10.00m, true));
            productsInput2.Add(new Other("bottle of perfume", 47.50m, true));

            ShoppingCart shoppingCart2 = new ShoppingCart(productsInput2, listTaxCalculator);
            var output2 = shoppingCart2.Display();

            Console.Write(output2);
            #endregion

            #region input3
            List<IProduct> productsInput3 = new List<IProduct>();
            productsInput3.Add(new Other("imported bottle of perfume", 27.99m, true));
            productsInput3.Add(new Other("bottle of perfume", 18.99m, false));
            productsInput3.Add(new Medical("packet of headache pills", 9.75m, false));
            productsInput3.Add(new Food("imported box of chocolates", 11.25m, true));

            ShoppingCart shoppingCart3 = new ShoppingCart(productsInput3, listTaxCalculator);
            var output3 = shoppingCart3.Display();

            Console.Write(output3);
            #endregion

            Console.ReadLine();
        }
    }
}
