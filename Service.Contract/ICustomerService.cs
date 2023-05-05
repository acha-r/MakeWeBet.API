using SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ICustomerService
    {
        MyBarcodeInfo GetBarcodeInfo(int customerId, bool trackChanges);
        PurchaseSummaryDto MakePayment(int customerId, int productId, bool trackChanges);
    }
}
