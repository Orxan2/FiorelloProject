using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
