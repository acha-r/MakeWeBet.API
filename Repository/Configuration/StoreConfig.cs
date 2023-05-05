using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{

    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData
                (
                    new Store
                    {
                        Id = 1,
                        Name = "GIG",
                        Address = "No 2 CD Close, Enugu"
                    },
                    new Store
                    {
                        Id = 2,
                        Name = "ATM",
                        Address = "12 New Heaven, Enugu"
                    },
                    new Store
                    {
                        Id = 3,
                        Name = "MGIG",
                        Address = "=Port Harcourt"
                    }
                );
        }
    }

}

