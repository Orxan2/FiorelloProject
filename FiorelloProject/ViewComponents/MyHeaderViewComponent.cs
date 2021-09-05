using FiorelloProject.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var model = _context.Biography;
            return View(await Task.FromResult(model));
        }
    }
}
