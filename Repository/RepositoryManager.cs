using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IStoreRepository> _storeRepository;
        private readonly Lazy<IProductRepository> _productRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _customerRepository = new Lazy<ICustomerRepository>(()=>
            new CustomerRepository(repositoryContext));
            _storeRepository = new Lazy<IStoreRepository>(()=>
            new StoreRepository(repositoryContext));
            _productRepository = new Lazy<IProductRepository>(()=>
            new ProductRepository(repositoryContext));
        }

        public ICustomerRepository Customer => _customerRepository.Value;
        public IStoreRepository Store => _storeRepository.Value;
        public IProductRepository Product => _productRepository.Value;
       
        public void Save() => _repositoryContext.SaveChanges();
    }
}
