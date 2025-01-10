using EcommerceAPI.Domain.Common;
using EcommerceAPI.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Domain.Entities
{
    public class Detail:EntityBase
    {
        public Detail()
        {
            
        }
        public Detail(string tittle, string description, int categoryId)
        {
            Tittle = tittle;
            Description = description;
            CategoryId = categoryId;
        }

        public  string Tittle { get; set; }
        public  string Description { get; set; }


        public  int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
