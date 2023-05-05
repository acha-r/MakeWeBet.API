using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData
                (
                    new Product
                    {
                        Id = 1,
                        Name = "Gummies",
                        Price = 1200,
                        StoreId = 1,
                        ProductBarcCode = Guid.NewGuid().ToString()
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Yogurt",
                        Price = 1500,
                        StoreId = 2,
                        ProductBarcCode = Guid.NewGuid().ToString()
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Orbit",
                        Price = 400,
                        StoreId = 1,
                        ProductBarcCode = Guid.NewGuid().ToString()
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Malt",
                        Price = 800,
                        StoreId = 3,
                        ProductBarcCode = Guid.NewGuid().ToString()
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Coke",
                        Price = 300,
                        StoreId = 2,
                        ProductBarcCode = Guid.NewGuid().ToString()
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Yogurt",
                        Price = 1200,
                        StoreId = 3,
                        ProductBarcCode = Guid.NewGuid().ToString()
                    },
                     new Product
                     {
                         Id = 7,
                         Name = "Life",
                         Price = 50000,
                         StoreId = 0,
                         ProductBarcCode = ""
                     },
                      new Product
                      {
                          Id = 8,
                          Name = "Cofee",
                          Price = 120,
                          StoreId = 0,
                          ProductBarcCode = ""
                      }


                );
        }
    }

}

