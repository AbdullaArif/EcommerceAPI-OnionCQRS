using EcommerceAPI.Domain.Common;
using EcommerceAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Domain.Entities
{
    public class Product:EntityBase
    {
        public  string Tittle { get; set; }
        public  string Description { get; set; }
        public  decimal Price { get; set; }
        public  decimal Discount { get; set; }
        //public required string ImagePath { get; set; }

        public  int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Category> Categories { get; set; }


    }
}
