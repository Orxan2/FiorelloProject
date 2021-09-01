using FiorelloProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Controllers
{
    public class ProductController : Controller
    {
        public FiorelloContext _context { get; }
        public ProductController(FiorelloContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var productCategories = await _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
                .OrderByDescending(pc => pc.ProductCategoryId).Take(8).ToListAsync();
            return View(productCategories);
        }
        public async Task<IActionResult> LoadMore(int skip=8,int take=4)
        {
            var productCategories = await _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
                .OrderByDescending(pc => pc.ProductCategoryId).Skip(skip).Take(take).ToListAsync();
            return PartialView("_LoadMore",productCategories);
        }
    }
}
