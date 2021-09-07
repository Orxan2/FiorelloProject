using FiorelloProject.DAL;
using FiorelloProject.Models;
using FiorelloProject.ViewModels.Basket;
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
       
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
                .Where(pc => pc.Product.IsDeleted == false && pc.Category.IsDeleted == false).OrderByDescending(pc => pc.ProductCategoryId).Count();
           
            return View();
            
        }
        public async Task<IActionResult> LoadMore(int skip=8,int take=4)
        {           
            var productCategories = await _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
                .Where(pc => pc.Product.IsDeleted == false && pc.Category.IsDeleted == false).OrderByDescending(pc => pc.ProductCategoryId).Skip(skip).Take(take).ToListAsync();
            return PartialView("_LoadMore",productCategories);
        }
        public IActionResult AddBasket(int id)
        {
            var dbProduct = _context.Products.ToList().FirstOrDefault(b => b.ProductId == id && b.IsDeleted == false);
            if (dbProduct == null)
            {
                return NotFound();
            }
            
            List<AddedProduct> temporaryList = new List<AddedProduct>();
            var myCookie = Request.Cookies["basket"];
            if (string.IsNullOrEmpty(myCookie))
            {               
                AddedProduct temporaryProduct = new AddedProduct
                {
                    Id = id,
                    Count = 1
                };
                temporaryList.Add(temporaryProduct);

            }
            else
            {
               temporaryList = JsonSerializer.Deserialize<List<AddedProduct>>(myCookie);              
               var temporaryProduct = temporaryList.FirstOrDefault(tp=>tp.Id == id);

                if (temporaryProduct == null)
                {
                    temporaryProduct = new AddedProduct
                    {
                        Id = id,
                        Count = 1                       
                };
                    temporaryList.Add(temporaryProduct);
                }
                else
                {
                    temporaryProduct.Count++;
                }

                

            }
                        
            Response.Cookies.Append("basket", JsonSerializer.Serialize<List<AddedProduct>>(temporaryList));

            return RedirectToAction(nameof(Index));

        }
        public IActionResult DeleteBasket(int id)
        {
            var dbProduct = _context.Products.ToList().FirstOrDefault(b => b.ProductId == id && b.IsDeleted == false);
            if (dbProduct == null)
            {
                return NotFound();
            }

           var temporaryList = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["basket"]);
            var product = temporaryList.FirstOrDefault(p=>p.Id == id);
            if (product.Count == 1)
            {
                temporaryList.Remove(product);
            }
            else
            {
                product.Count--;
            }
            Response.Cookies.Append("basket", JsonSerializer.Serialize<List<AddedProduct>>(temporaryList));

            return RedirectToAction(nameof(Index));

        }
    }
}
