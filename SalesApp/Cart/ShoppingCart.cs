using SalesApp.Models;
using SalesApp.Products;
using SalesApp.Receipt;
using SalesApp.Rounding;
using SalesApp.TaxCalculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Cart
{
    public class ShoppingCart
    {
        private List<IProduct> _products;
        private List<ITaxCalculator> _listTaxCalculator;
        private IReceipt _receipt;

        private List<ReceiptItem> _receiptItem;

        public ShoppingCart(List<IProduct> products, List<ITaxCalculator> listTaxCalculator, IReceipt receipt)
        {
            _receiptItem = new List<ReceiptItem>();
            _products = products;
            _listTaxCalculator = listTaxCalculator;
            _receipt = receipt;
        }

        public string Display()
        {
            foreach (var item in _products)
            {
                ReceiptItem receiptItem = new ReceiptItem();
                var itemTaxes = CalculateProductTax(item);

                receiptItem.Name = item.Name;
                receiptItem.Price = item.Price;
                receiptItem.Taxes = itemTaxes;
                receiptItem.PricewithTaxes = item.Price + itemTaxes;
                _receiptItem.Add(receiptItem);
            }

            _receipt.AddtoReceipt(_receiptItem);
            var sb = _receipt.GenerateReceipt();

            return sb.ToString();
        }

        private decimal CalculateProductTax(IProduct product)
        {
            decimal productTax = 0;

            foreach (var tax in _listTaxCalculator)
                productTax = productTax + tax.CalculateTax(product);

            return productTax;
        }
    }
}
