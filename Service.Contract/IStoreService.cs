using SharedDTO;

namespace Service.Contract
{
    public interface IStoreService
    {
        GetStoreDTO GetStoreInfo(int storeId, bool trackChanges);
        ScanProductDto RegisterProduct(int productId, bool trackChanges);
    }
}
