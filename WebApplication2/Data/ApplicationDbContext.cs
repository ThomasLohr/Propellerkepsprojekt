using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApplication2.Configuration;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=PropStoreDB; Trusted_Connection=True; MultipleActiveResultSets=true; Pooling=false");
            }
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Seed DB with Products, Orders and OrderProducts

            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderProductConfiguration());

            // Set entity dependencies and foreign keys

            builder.Entity<Order>().HasMany(op => op.OrderProducts).WithOne(o => o.Order);
            builder.Entity<Order>().HasOne(u => u.User).WithMany(o => o.Orders);
            builder.Entity<OrderProduct>().HasMany(p => p.Products).WithOne(op => op.OrderProduct);

            // Set default Admin guid and assign it to role
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = ADMIN_ID;

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            var hasher = new PasswordHasher<ApplicationUser>();

            // Create Admin account

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "password123"),
                SecurityStamp = string.Empty
            });

            // Assign admin to admin role

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

        // Overrides SaveChanges() to DB so that ModifiedDate /CreatedDate is updated before save occurs
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // Entities that implement IModelDate set CreatedDate / ModifiedDate appropriately
                if (entry.Entity is IModelDates trackable)
                {

                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // Set the updated date to "now"
                            trackable.ModifiedDate = utcNow;

                            // Mark property as "don't touch" so CreatedDate is not updated on a Modify operation
                            entry.Property("CreatedDate").IsModified = false;
                            break;

                        case EntityState.Added:
                            // Set CreatedDate and ModifiedDate to now
                            trackable.CreatedDate = utcNow;
                            trackable.ModifiedDate = utcNow;
                            break;
                    }
                }
            }
        }
    }
}

