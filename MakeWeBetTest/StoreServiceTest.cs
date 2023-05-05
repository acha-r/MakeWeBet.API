using Contracts;
using Entities.Models;
using Moq;
using Service;
using Service.Contract;

namespace MakeWeBetTest
{
    public class StoreServiceTest
    {
        private readonly Mock<IRepositoryManager> _repositoryMock;
        private readonly Mock<ILoggerManager> _loggerMock;
        private readonly IStoreService _storeService;

        public StoreServiceTest()
        {
            _repositoryMock = new Mock<IRepositoryManager>();
            _loggerMock = new Mock<ILoggerManager>();
            _storeService = new StoreService(_repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetStoreInfo_ReturnsGetStoreDto_WhenStoreExists()
        {
            // Arrange
            var storeId = 1;
            var trackChanges = true;
            var store = new Store { Name = "Store 1", Address = "123 Main St" };
            _repositoryMock.Setup(repo => repo.Store.GetStore(storeId, trackChanges)).Returns(store);

            // Act
            var result = _storeService.GetStoreInfo(storeId, trackChanges);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(store.Name, result.Name);
            Assert.Equal(store.Address, result.Address);
        }

        [Fact]
        public void RegisterProduct_ReturnsScanProductDto_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var trackChanges = false;
            var product = new Product { Name = "Product 1", Price = 50, StoreId = 1 };
            _repositoryMock.Setup(repo => repo.Product.GetProductInfo(productId, trackChanges)).Returns(product);

            // Act
            var result = _storeService.RegisterProduct(productId, trackChanges);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal(product.StoreId, result.StoreId);
            Assert.NotNull(result.ProductBarcCode);
        }

        [Fact]
        public void RegisterProduct_ReturnsNull_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 1;
            var trackChanges = false;
            _repositoryMock.Setup(repo => repo.Product.GetProductInfo(productId, trackChanges)).Returns((Product)null);

            // Act
            var result = _storeService.RegisterProduct(productId, trackChanges);

            // Assert
            Assert.Null(result);
        }
    }
}


