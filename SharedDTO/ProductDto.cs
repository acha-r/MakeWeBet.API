using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTO
{
    public class ProductDto
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ScanProductDto : ProductDto
    {
        public string ProductBarcCode { get; set; }
    }
}
