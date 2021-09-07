using FiorelloProject.DAL;
using FiorelloProject.Models;
using FiorelloProject.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FiorelloProject.ViewComponents
{
    public class MyHeaderViewComponent:ViewComponent
    {
        public FiorelloContext _context { get; }
        public MyHeaderViewComponent(FiorelloContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            BasketViewModel basketVM = new BasketViewModel
            {
                Biography = _context.Biography.ToList(),
                TotalCount = 0,
                TotalPrice = 0,
                ProductDetails = new List<BasketItemViewModel>()
            };

            var cookie = HttpContext.Request.Cookies["basket"];

            if (cookie != null)
            {
                var temporaryList = JsonSerializer.Deserialize<List<AddedProduct>>(cookie);

                if (temporaryList.FirstOrDefault() != null)
                {
                    foreach (var temporaryProduct in temporaryList)
                    {
                        if (temporaryProduct != null)
                        {
                            var dbProduct = _context.Products.ToList().FirstOrDefault(p => p.ProductId == temporaryProduct.Id && p.IsDeleted == false);

                            BasketItemViewModel basketItem = new BasketItemViewModel
                            {

                                Product = dbProduct,
                                Count = temporaryProduct.Count
                            };
                            basketVM.ProductDetails.Add(basketItem);
                            basketVM.TotalCount++;
                            basketVM.TotalPrice += dbProduct.Price * basketItem.Count;
                        }
                    }
                }
            }

            return View(await Task.FromResult(basketVM));
        }

       
    }
}
