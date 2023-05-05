using Contracts;
using Service.Contract;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IStoreService> _storeService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _customerService = new Lazy<ICustomerService>(() => new
            CustomerService(repositoryManager, logger));
            _storeService = new Lazy<IStoreService>(() => new 
            StoreService(repositoryManager, logger));
            _productService = new Lazy<IProductService>(() => new
            ProductService(repositoryManager, logger));
        }

        public ICustomerService CustomerService => _customerService.Value;

        public IStoreService StoreService => _storeService.Value;

        public IProductService ProductService => _productService.Value;
    }
}
