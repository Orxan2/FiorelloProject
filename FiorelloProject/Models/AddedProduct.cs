using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class AddedProduct
    {
        public int Id { get; set; }       
        public String Title { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }        
        public decimal TotalPrice { get; set; }
    }
}
