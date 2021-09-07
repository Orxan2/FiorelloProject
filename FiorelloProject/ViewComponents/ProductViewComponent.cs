using FiorelloProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public FiorelloContext _context { get; }
        public ProductViewComponent(FiorelloContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int product)
        {
            var productCategories = _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
               .Where(pc => pc.Product.IsDeleted == false && pc.Category.IsDeleted==false).OrderByDescending(pc => pc.ProductCategoryId).Take(product);
            return View(await Task.FromResult(productCategories));
        }
    }
}
