using Entities.Models;

namespace Contracts
{
    public interface IStoreRepository
    {
        Store GetStore (int storeId, bool trackChanges);


    }
}
