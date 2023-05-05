using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTO
{
    public class PurchaseSummaryDto : MyBarcodeInfo
    {
        public string Remark { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }
      
    }

    public class MyBarcodeInfo
    {
        public string BarcodeId { get; set; }
        public string Name { get; set; }
        public decimal WalletBal { get; set; }

    }
}
