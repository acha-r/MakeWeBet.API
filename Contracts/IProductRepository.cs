using Entities.Models;

namespace Contracts
{
    public interface IProductRepository
    {
        Product GetProductInfo(int productId, bool trackChanges);
        void AddProduct(Product product);
    }
}
