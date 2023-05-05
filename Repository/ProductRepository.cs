using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private RepositoryContext _repo;
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repo = repositoryContext;
        }

        public void AddProduct(Product product)
            => Create(product);

        public Product GetProductInfo(int productId, bool trackChanges)
        {
            var product = _repo.Products.Include(p => p.Store)
                .SingleOrDefault(p => p.Id == productId);
            return product;
        }
    }
}
