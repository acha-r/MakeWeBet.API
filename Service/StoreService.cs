using Contracts;
using Entities.Models;
using Service.Contract;
using SharedDTO;

namespace Service
{
    public sealed class StoreService : IStoreService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public StoreService(IRepositoryManager repository, ILoggerManager logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public GetStoreDTO GetStoreInfo(int storeId, bool trackChanges)
        {
            try
            {
                var store = _repository.Store.GetStore(storeId, trackChanges);

                var getStoreDto = new GetStoreDTO()
                {
                    Name = store.Name,
                    Address = store.Address,
                };

                return getStoreDto;

            }
            catch (Exception ex)
            {
                _logger.LogError($"No vex. E no work");
                throw;
            }
        }
    
        public ScanProductDto RegisterProduct(int productId, bool trackChanges)
        {
            var product = _repository.Product.GetProductInfo(productId, false);

            if (product == null)
                return null;

            product.ProductBarcCode = Guid.NewGuid().ToString();
            _repository.Save();

            return new ScanProductDto
            {
                Name = product.Name,
                Price = product.Price,
                ProductBarcCode = product.ProductBarcCode,
                StoreId = product.StoreId,
            };
        }
    }
}
