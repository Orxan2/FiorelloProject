using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
