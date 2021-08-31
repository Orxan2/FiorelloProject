using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
