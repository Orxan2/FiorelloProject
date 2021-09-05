using FiorelloProject.DAL;
using FiorelloProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            ViewBag.ProductCount = _context.ProductCategories.Count();
            var productCategories = await _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
                .Where(pc => pc.Product.IsDeleted == false).OrderByDescending(pc => pc.ProductCategoryId).Take(8).ToListAsync();
            return View(productCategories);
            
        }
        public async Task<IActionResult> LoadMore(int skip=8,int take=4)
        {           
            var productCategories = await _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
                .Where(pc => pc.Product.IsDeleted == false).OrderByDescending(pc => pc.ProductCategoryId).Skip(skip).Take(take).ToListAsync();
            return PartialView("_LoadMore",productCategories);
        }
        public async Task<IActionResult> AddBasket(int id)
        {
            List<AddedProduct> basket = new List<AddedProduct>();
            var orxan = Request.Cookies["baskets"];
            if (orxan != null)
            {
                basket = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["baskets"]);
            }


            if (basket.Exists(b => b.Id == id))
            {
                basket.FirstOrDefault(b => b.Id == id).Count++;
            }
            else
            {
                AddedProduct pro = new AddedProduct
                {
                    Id = id,
                    Count = 1
                };
                basket.Add(pro);
            }


            Response.Cookies.Append("baskets", JsonSerializer.Serialize<List<AddedProduct>>(basket));

            return RedirectToAction(nameof(Index));

        }
    }
}
