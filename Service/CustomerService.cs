using Contracts;
using Service.Contract;
using SharedDTO;

namespace Service
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CustomerService(IRepositoryManager repository, ILoggerManager logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public MyBarcodeInfo GetBarcodeInfo(int customerId, bool trackChanges)        
        {
            var customer = _repository.Customer.GetCustomer(customerId, trackChanges);
            if (customer == null)
                return null;

            return new MyBarcodeInfo
            {
                Name = customer.Name,
                BarcodeId = customer.BarcodeId,
                WalletBal = customer.WalletBal
            };

            
        }

        public PurchaseSummaryDto MakePayment(int customerId, int productId, bool trackChanges)
        {
            try
            {
                var customer = _repository.Customer.GetCustomer(customerId, trackChanges) ?? throw new ArgumentException("");
                var product = _repository.Product.GetProductInfo(productId, trackChanges) ?? throw new ArgumentException("");
                               
                if (string.IsNullOrEmpty(product.ProductBarcCode))
                    throw new InvalidOperationException("");


                if (product.Price > customer.WalletBal)
                {
                    trackChanges = false;
                    return (
                        new PurchaseSummaryDto
                        {
                            Name = customer.Name,
                            WalletBal = customer.WalletBal,
                            BarcodeId = customer.BarcodeId,
                            Item = product.Name,
                            Price = product.Price,
                            Remark = $"Boss, your money no reach. If you still wan run am, add extra {product.Price - customer.WalletBal} naira"
                        });
                }
                    

                customer.WalletBal -= product.Price;

                _repository.Save();

                return (new PurchaseSummaryDto
                {
                    Name = customer.Name,
                    WalletBal = customer.WalletBal,
                    BarcodeId = customer.BarcodeId,
                    Remark = "Carry go!"
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"No vex. E no work");
                throw;
            }
        }

    }
}
