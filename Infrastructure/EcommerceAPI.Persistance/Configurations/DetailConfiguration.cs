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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new Faker();

            Detail detail1 = new()
            {
                Id = 1,
                Tittle = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreateDate = DateTime.Now,
                IsDeleted = false
            };
            Detail detail2 = new()
            {
                Id = 2,
                Tittle = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,
                CreateDate = DateTime.Now,
                IsDeleted = true
            };
            Detail detail3 = new()
            {
                Id = 3,
                Tittle = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreateDate = DateTime.Now,
                IsDeleted = false
            };

            builder.HasData(detail1, detail2, detail3);
        }
    }
}
