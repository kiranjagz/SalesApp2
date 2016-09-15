using SalesApp.Models;
using SalesApp.Products;
using SalesApp.TaxCalculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Receipt
{
    public class ReceiptBuilder : IReceipt
    {
        private List<ReceiptItem> _items;
        private decimal _totalTaxes;
        private decimal _totalAmount;

        public void AddtoReceipt(List<ReceiptItem> receiptItem)
        {
            _items = receiptItem;
        }

        public string GenerateReceipt()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in _items)
            {
                var itemTotal = item.Price + item.Taxes;
                sb.AppendLine("1 " + item.Name + " at " + itemTotal.ToString("f"));
            }

            _totalTaxes = CalculateTaxes();
            _totalAmount = CalculateTotal();

            sb.AppendLine("Sales Taxes: " + _totalTaxes.ToString("f"));
            sb.AppendLine("Total: " + _totalAmount.ToString("f"));
            sb.AppendLine("=================================================");

            return sb.ToString();
        }

        private decimal CalculateTaxes()
        {
            return _items.Sum(item => item.Taxes);
        }

        private decimal CalculateTotal()
        {
            return _items.Sum(item => item.Price) + _items.Sum(x => x.Taxes);
        }
    }
}
