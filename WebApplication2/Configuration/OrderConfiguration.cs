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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasData
            (
                new Order
                {
                    Id = 1,
                    OrderSent = true,
                    UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                    ShippedDate = DateTime.UtcNow

                },
                new Order
                {
                    Id = 2,
                    OrderSent = false,
                    UserId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"

                }
                );
        }
    }
}
