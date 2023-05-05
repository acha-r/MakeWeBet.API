using Contracts;
using Entities.Models;
using Service.Contract;
using SharedDTO;

namespace Service
{
    public sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ProductService(IRepositoryManager repository, ILoggerManager logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public GetPoductDTO GetProductInfo(int productId, bool trackChanges)
        {
            try
            {
                var product = _repository.Product.GetProductInfo(productId, trackChanges);

                var getProductDto = new GetPoductDTO()
                {
                    Price = product.Price,
                    ProductName = product.Name,
                    StoreName = product.Store.Name
                };
                
                return getProductDto;
                
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError($"No vex. E no work");
                throw;
            }
        }

        public ProductDto AddProduct(ProductDto product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));

                var newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    ProductBarcCode = " ",
                    StoreId = product.StoreId
                };

                if (newProduct == null)
                    throw new NullReferenceException();

                var store = _repository.Store.GetStore(product.StoreId, false);
                if (store == null)
                    throw new Exception("Store not found.");

                _repository.Product.AddProduct(newProduct);
                _repository.Save();

                return product;
            }
            catch (ArgumentNullException ex)
            {
                _ = ex.Message;
                throw;
            }
            catch (NullReferenceException ex)
            {
                _ = ex.Message; throw;
            }
            catch (Exception ex)
            {
                _ = ex.Message; 
                throw;
            }
        }

    }
}
