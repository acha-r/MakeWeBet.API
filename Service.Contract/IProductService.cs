using SharedDTO;

namespace Service.Contract
{
    public interface IProductService
    {
        ProductDto AddProduct(ProductDto product); 
        GetPoductDTO GetProductInfo (int  productId, bool trackChanges);
    }
}
