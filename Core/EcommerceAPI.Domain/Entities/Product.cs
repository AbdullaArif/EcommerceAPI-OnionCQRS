using EcommerceAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Domain.Entities
{
    public class Product:EntityBase
    {
        public Product()
        {

        }


        public Product(string tittle, string description, decimal price, decimal discount, int brandId)
        {
            Tittle = tittle;
            Description = description;
            Price = price;
            Discount = discount;
            BrandId = brandId;

        }


        public  string Tittle { get; set; }
        public  string Description { get; set; }
        public  decimal Price { get; set; }
        public  decimal Discount { get; set; }
        //public required string ImagePath { get; set; }

        public  int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
