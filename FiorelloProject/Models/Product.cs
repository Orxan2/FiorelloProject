using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DefaultValue(false)]
        public Boolean IsDeleted { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
