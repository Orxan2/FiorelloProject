using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="You can't send empty"),StringLength(25,ErrorMessage ="You Write Nothing!")]
        public string Title { get; set; }
        public Boolean IsDeleted { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
