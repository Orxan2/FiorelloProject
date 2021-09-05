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
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.ProductCategories.Count();
           
            return View();
            
        }
        public async Task<IActionResult> LoadMore(int skip=8,int take=4)
        {           
            var productCategories = await _context.ProductCategories.Include(pc => pc.Category).Include(pc => pc.Product)
                .Where(pc => pc.Product.IsDeleted == false).OrderByDescending(pc => pc.ProductCategoryId).Skip(skip).Take(take).ToListAsync();
            return PartialView("_LoadMore",productCategories);
        }
        public IActionResult AddBasket(int id)
        {
            var product = _context.Products.ToList().FirstOrDefault(b => b.ProductId == id);
            List<AddedProduct> basket = new List<AddedProduct>();
            var orxan = Request.Cookies["baskets"];
            if (orxan != null)
            {
                basket = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["baskets"]);
            }


            if (basket.Exists(b => b.Id == id))
            {
                basket.FirstOrDefault(b => b.Id == id).Count++;
                basket.FirstOrDefault(b => b.Id == id).TotalPrice *= basket.FirstOrDefault(b => b.Id == id).Count;

            }
            else
            {
                AddedProduct pro = new AddedProduct
                {
                    Id = id,
                    Count = 1,
                    Title = product.Title,
                    Image = product.Image,
                    Price = product.Price,
                    TotalPrice = product.Price
                };
                basket.Add(pro);
            }


            Response.Cookies.Append("baskets", JsonSerializer.Serialize<List<AddedProduct>>(basket));

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Basket()
        {
            var basket = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["baskets"]);

            return View(basket);
        }
        public IActionResult Minus(int id)
        {
            //var basket = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["baskets"]);
            //var product = basket.FirstOrDefault(b => b.Id == id);
            //basket.FirstOrDefault(b => b.Id == id).Count--;
            //basket.FirstOrDefault(b => b.Id == id).TotalPrice = product.Price * product.Count;
            var basket = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["baskets"]);
            var product = basket.FirstOrDefault(b => b.Id == id);
            product.Count--;
            product.TotalPrice = product.Price * product.Count;
            if (product.Count == 0)
            {
                basket.Remove(product);
            }
            else
            {
                basket.FirstOrDefault(p => p.Id == product.Id).Count = product.Count;
                basket.FirstOrDefault(p => p.Id == product.Id).TotalPrice = product.TotalPrice;
            }
            Response.Cookies.Append("baskets", JsonSerializer.Serialize<List<AddedProduct>>(basket));
            return RedirectToAction("Basket", basket);

        }
        
        public IActionResult Plus(int id)
        {
            var basket = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["baskets"]);
            var product = basket.FirstOrDefault(b => b.Id == id);
            basket.FirstOrDefault(p => p.Id == product.Id).Count++;
            basket.FirstOrDefault(b => b.Id == id).TotalPrice = product.Price * product.Count;

            Response.Cookies.Append("baskets", JsonSerializer.Serialize<List<AddedProduct>>(basket));
            return RedirectToAction("Basket", basket);
        }
        public IActionResult Close(int id)
        {
            var basket = JsonSerializer.Deserialize<List<AddedProduct>>(Request.Cookies["baskets"]);
            var product = basket.FirstOrDefault(b => b.Id == id);
            basket.Remove(product);
            Response.Cookies.Append("baskets", JsonSerializer.Serialize<List<AddedProduct>>(basket));
            return RedirectToAction("Basket", basket);
        }
    }
}
