using Bogus;
using EcommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           Faker faker = new Faker();

            Product product1 = new()
            {
                Id = 1,
                Tittle = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Discount = faker.Random.Decimal(1, 10),
                Price = faker.Random.Decimal(100,1000),
                CreateDate = DateTime.Now,
                IsDeleted = false
            };

            Product product2 = new()
            {
                Id = 2,
                Tittle = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,
                Discount = faker.Random.Decimal(1, 10),
                Price = faker.Random.Decimal(100, 1000),
                CreateDate = DateTime.Now,
                IsDeleted = false
            };
            builder.HasData(product1,product2);
        }
    }
}
