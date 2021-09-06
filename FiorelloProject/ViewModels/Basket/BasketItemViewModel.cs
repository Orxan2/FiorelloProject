using FiorelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.ViewModels.Basket
{
    public class BasketItemViewModel
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
