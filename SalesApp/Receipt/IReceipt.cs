using SalesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Receipt
{
    public interface IReceipt
    {
        void AddtoReceipt(List<ReceiptItem> receiptItem);
        string GenerateReceipt();
    }
}
