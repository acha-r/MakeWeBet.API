using Contracts;
using Entities.Models;

namespace Repository
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Store GetStore(int storeId, bool trackChanges)
        => FindByCondition(c => c.Id == storeId, trackChanges)
            .SingleOrDefault();
    }
}
