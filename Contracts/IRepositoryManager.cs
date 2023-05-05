namespace Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        IStoreRepository Store { get; }
        IProductRepository Product { get; }
        void Save();
    }
}
