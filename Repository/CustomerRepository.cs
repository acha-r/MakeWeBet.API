using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private RepositoryContext _repo;

        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repo = repositoryContext;
        }

        public Customer? GetCustomer(int buyerId, bool trackChanges)=>
            _repo.Customers.SingleOrDefault(c => c.Id == buyerId);
        
    }
}
