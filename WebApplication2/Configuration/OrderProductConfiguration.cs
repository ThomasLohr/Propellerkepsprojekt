using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

// Add to OnModelCreating(): modelBuilder.ApplyConfiguration(new UserConfiguration());

namespace WebApplication2.Configuration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");
            builder.HasData
            (
                new OrderProduct
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 500

                },
                new OrderProduct
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 2,
                    Quantity = 300

                }
                );
        }
    }
}
