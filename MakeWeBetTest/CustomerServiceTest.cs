using Contracts;
using Entities.Models;
using Moq;
using Service;
using Service.Contract;
using Xunit.Abstractions;

namespace MakeWeBetTest
{
    public class CustomerServiceTest
    {
        private readonly Mock<IRepositoryManager> _repositoryMock;
        private readonly Mock<ILoggerManager> _loggerMock;
        private readonly ICustomerService _customerService;
        private readonly ITestOutputHelper _testOutputHelper;

        public CustomerServiceTest(ITestOutputHelper testOutputHelper)
        {
            _repositoryMock = new Mock<IRepositoryManager>();
            _loggerMock = new Mock<ILoggerManager>();
            _customerService = new CustomerService(_repositoryMock.Object, _loggerMock.Object);
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetBarcodeInfo_ReturnsMyBarcodeInfo_WhenCustomerExists()
        {
            // Arrange
            var customerId = 1;
            var trackChanges = true;
            var customer = new Customer { Name = "John Doe", BarcodeId = "123456", WalletBal = 100 };
            _repositoryMock.Setup(repo => repo.Customer.GetCustomer(customerId, trackChanges)).Returns(customer);

            // Act
            var result = _customerService.GetBarcodeInfo(customerId, trackChanges);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.BarcodeId, result.BarcodeId);
            Assert.Equal(customer.WalletBal, result.WalletBal);
        }

        [Fact]
        public void GetBarcodeInfo_ReturnsNull_WhenCustomerDoesNotExist()
        {
            // Arrange
            var customerId = 1;
            var trackChanges = true;
            _repositoryMock.Setup(repo => repo.Customer.GetCustomer(customerId, trackChanges)).Returns((Customer)null);

            // Act
            var result = _customerService.GetBarcodeInfo(customerId, trackChanges);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void MakePayment_ReturnsPurchaseSummaryDto_WhenPaymentIsSuccessful()
        {
            // Arrange
            var customerId = 1;
            var productId = 1;
            var trackChanges = true;
            var customer = new Customer { Name = "John Doe", BarcodeId = "123456", WalletBal = 100 };
            var product = new Product { Name = "Product 1", Price = 50, ProductBarcCode = "123" };
            _repositoryMock.Setup(repo => repo.Customer.GetCustomer(customerId, trackChanges)).Returns(customer);
            _repositoryMock.Setup(repo => repo.Product.GetProductInfo(productId, trackChanges)).Returns(product);

            // Act
            var result = _customerService.MakePayment(customerId, productId, trackChanges);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.BarcodeId, result.BarcodeId);
           _testOutputHelper.WriteLine(customer.WalletBal.ToString());
            Assert.Equal(result.WalletBal, customer.WalletBal);
            Assert.Equal("Carry go!", result.Remark);
        }

        [Fact]
        public void MakePayment_ThrowsException_WhenCustomerDoesNotExist()
        {
            // Arrange
            var customerId = 1;
            var productId = 1;
            var trackChanges = true;
            _repositoryMock.Setup(repo => repo.Customer.GetCustomer(customerId, trackChanges)).Returns((Customer)null);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _customerService.MakePayment(customerId, productId, trackChanges));
        }

        [Fact]
        public void MakePayment_ThrowsException_WhenProductDoesNotHaveBarcode()
        {
            // Arrange
            var customerId = 1;
            var productId = 1;
            var trackChanges = true;
            var customer = new Customer { Name = "John Doe", BarcodeId = "123456", WalletBal = 100 };
            var product = new Product { Name = "Product 1", Price = 50, ProductBarcCode = null };
            _repositoryMock.Setup(repo => repo.Customer.GetCustomer(customerId, trackChanges)).Returns(customer);
            _repositoryMock.Setup(repo => repo.Product.GetProductInfo(productId, trackChanges)).Returns(product);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _customerService.MakePayment(customerId, productId, trackChanges));
        }

        [Fact]
        public void MakePayment_ReturnsPurchaseSummaryDto_WhenWalletBalanceIsNotEnough()
        {
            // Arrange
            var customerId = 1;
            var productId = 1;
            var trackChanges = true;
            var customer = new Customer { Name = "John Doe", BarcodeId = "123456", WalletBal = 50 };
            var product = new Product { Name = "Product 1", Price = 100, ProductBarcCode = "123" };
            _repositoryMock.Setup(repo => repo.Customer.GetCustomer(customerId, trackChanges)).Returns(customer);
            _repositoryMock.Setup(repo => repo.Product.GetProductInfo(productId, trackChanges)).Returns(product);

            // Act
            var result = _customerService.MakePayment(customerId, productId, trackChanges);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.BarcodeId, result.BarcodeId);
            Assert.Equal(customer.WalletBal, result.WalletBal);
            Assert.Equal(product.Name, result.Item);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal($"Boss, your money no reach. If you still wan run am, add extra {product.Price - customer.WalletBal} naira", result.Remark);
        }
    }
}