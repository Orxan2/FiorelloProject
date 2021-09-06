using FiorelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.ViewModels.Basket
{
    public class BasketViewModel
    {
        public List<BasketItemViewModel> ProductDetails { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Biography> Biography { get; set; }
    }
}
