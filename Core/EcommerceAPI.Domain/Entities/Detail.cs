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

        public required string Tittle { get; set; }
        public required string Description { get; set; }


        public required int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
