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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasData
            (
                new Product
                {
                      Id = 1,
                      ImageUrl = "https://cdn11.bigcommerce.com/s-27y5anms1z/images/stencil/728x728/products/64957/30204/126988__95020.1583560155.jpg?c=2",
                      ProductName = "Propellerkeps Hund",
                      ProductDescription = "Elegant, multifärgad propellerkeps till din hund eller väldigt håriga respektive.",
                      Color = "Multifärgad",
                      Size = "XL",
                      Model = "Hund",
                      Gender = "Unisex",
                      Price = 399,
                      Discount = 0,
                      Stock = 5000,
                      Category = "Djur"
                },
                new Product
                {
                    Id = 2,
                    ImageUrl = "https://i.etsystatic.com/5376657/r/il/4dead6/1511480960/il_570xN.1511480960_7c63.jpg",
                    ProductName = "Propellerkeps Katt",
                    ProductDescription = "Elegant, multifärgad propellerkeps till din katt eller väldigt håriga respektive.",
                    Color = "Multifärgad",
                    Size = "XS",
                    Model = "Katt",
                    Gender = "Unisex",
                    Price = 399,
                    Discount = 0,
                    Stock = 5000,
                    Category = "Djur"
                },
                new Product
                {
                    Id = 3,
                    ImageUrl = "https://i.pinimg.com/474x/59/d7/54/59d754c8a1d6f57dc8ddc31b49371650.jpg",
                    ProductName = "Propellerkeps Affärsperson",
                    ProductDescription = "Oavsett om du tuggar qualudes på Wall Street med trippla telefoner i öronen eller klickar " +
                    "                    'Köp' på Avanza så visar denna modell att du är nästa Warren Buffet.",
                    Color = "Multifärgad",
                    Size = "M",
                    Model = "Standard",
                    Gender = "Unisex",
                    Price = 499,
                    Discount = 0,
                    Stock = 5000,
                    Category = "Människa"
                },
                new Product
                {
                    Id = 4,
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/615G86JGkpL._AC_SL1001_.jpg",
                    ProductName = "Propellerkeps Gummianka",
                    ProductDescription = "Är du en gummianka med medelsålderskris? Då är den här modellen för dig. Fem-växlad, highway-to-hell " +
                                         "hjälm som visar damerna på Sweden Rock festival att du fortfarande är viril och har ett outömligt förråd av gummi. " +
                                         "OBS! Pilotbrillor ingår ej.",
                    Color = "Svart",
                    Size = "S",
                    Model = "Hjälm",
                    Gender = "Unisex",
                    Price = 599,
                    Discount = 0,
                    Stock = 5000,
                    Category = "Speciellatillfällen"
                },
                new Product
                {
                    Id = 5,
                    ImageUrl = "https://i.imgflip.com/4/3spz10.jpg",
                    ProductName = "Propellerkeps Bäst",
                    ProductDescription = "Alla säger att denna propellerkeps är bäst. Jag har många vänner, alla vänner och de säger miljarder gånger " +
                                         "att denna propellerkeps är det bästa som har hänt dem.",
                    Color = "Multifärgad",
                    Size = "5XL",
                    Model = "President",
                    Gender = "Man",
                    Price = 10000,
                    Discount = 0,
                    Stock = 5000,
                    Category = "Speciellatillfällen"
                },
                new Product
                {
                    Id = 6,
                    ImageUrl = "https://ih1.redbubble.net/image.745680506.6038/st,small,507x507-pad,600x600,f8f8f8.u2.jpg",
                    ProductName = "Propellerkeps Peak Performance",
                    ProductDescription = "Läser du till systemutvecklare hos Newton i Malmö? Då vet du att du har nått zenith i ditt liv. " +
                                         "Det blir inte bättre än så här, förutom med denna keps! Köp den nu och sälla dig till legenderna som tar examen 2022.",
                    Color = "Multifärgad",
                    Size = "L",
                    Model = "Sport",
                    Gender = "Kvinna",
                    Price = 10000,
                    Discount = 0,
                    Stock = 5000,
                    Category ="Människa"
                }
                );
        }
    }
}
