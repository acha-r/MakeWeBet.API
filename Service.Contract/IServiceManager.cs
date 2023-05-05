namespace Service.Contract
{
    public interface IServiceManager 
    {
        ICustomerService CustomerService { get; }
        IStoreService StoreService { get; }
        IProductService ProductService { get; }
    }
}
