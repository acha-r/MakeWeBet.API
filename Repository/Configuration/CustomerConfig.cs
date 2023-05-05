using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public partial class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
                (
                    new Customer
                    {
                        Id = 1,
                        Name = "Iam",
                        BarcodeId = Guid.NewGuid().ToString(),
                        WalletBal = 56000
                    },
                     new Customer
                     {
                         Id = 2,
                         Name = "Yah",
                         BarcodeId = Guid.NewGuid().ToString(),
                         WalletBal = 200000
                     },
                      new Customer
                      {
                          Id = 3,
                          Name = "Jah",
                          BarcodeId = Guid.NewGuid().ToString(),
                          WalletBal = 149000
                      }
                );
        }

    }

  
}
