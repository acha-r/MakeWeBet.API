using Contracts;
using Entities.Models;
using Moq;
using Repository;
using Service;
using Service.Contract;
using SharedDTO;

namespace MakeWeBetTest
{
    public class ProductServiceTests
    {
        private readonly Mock<IRepositoryManager> _repositoryMock;
        private readonly Mock<ILoggerManager> _loggerMock;
        private readonly Mock<RepositoryContext> _context;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            _repositoryMock = new Mock<IRepositoryManager>();
            _loggerMock = new Mock<ILoggerManager>();
            _context = new Mock<RepositoryContext>();
            _productService = new ProductService(_repositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public void GetProductInfo_ReturnsProductDto_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var trackChanges = true;
            var product = new Product { Name = "Product 1", Price = 50, Store = new Store { Name = "Store 1" } };
            _repositoryMock.Setup(repo => repo.Product.GetProductInfo(productId, trackChanges)).Returns(product);

            // Act
            var result = _productService.GetProductInfo(productId, trackChanges);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.ProductName);
            Assert.Equal(product.Price, result.Price);
            Assert.Equal(product.Store.Name, result.StoreName);
        }

        [Fact]
        public void GetProductInfo_ThrowsException_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 1;
            var trackChanges = true;
            _repositoryMock.Setup(repo => repo.Product.GetProductInfo(productId, trackChanges)).Returns((Product)null);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => _productService.GetProductInfo(productId, trackChanges));
        }      

        [Fact]
        public void AddProduct_ThrowsException_WhenStoreDoesNotExist()
        {
            // Arrange
            var productDto = new ProductDto { Name = "Product 1", Price = 50, StoreId = 1 };
            _repositoryMock.Setup(repo => repo.Store.GetStore(productDto.StoreId, false)).Returns((Store)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _productService.AddProduct(productDto));
        }
    }
}


