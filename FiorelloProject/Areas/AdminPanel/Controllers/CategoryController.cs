using FiorelloProject.DAL;
using FiorelloProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {       
        public FiorelloContext _context { get; }
        public CategoryController(FiorelloContext context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var category = _context.Categories;
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            
            if (!ModelState.IsValid)
            {                
                return View();
            }

            bool dublicateControl = _context.Categories.Any(c=>c.Title.ToLower() == category.Title.ToLower());
            if (dublicateControl)
            {
                ModelState.AddModelError("Title","Has Already this Category at Database");
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); ;
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
               return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c=>c.CategoryId == id && c.IsDeleted==false);

            if (category == null)
            {
              return  NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Update(int? id,Category category)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool dublicateControl = _context.Categories.Any(c => c.Title.ToLower() == category.Title.ToLower());
            if (dublicateControl)
            {
                ModelState.AddModelError("Title", "Has Already this Category at Database");
                return View();
            }
            if (id != category.CategoryId)
            {
                return BadRequest();
            }           

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
       
      
        public IActionResult DeleteOrActive(int id)
        {
            var updatedCategory = _context.Categories.FirstOrDefault(p=>p.CategoryId == id);

            if (updatedCategory == null)
            {
               return NotFound();
            }

            if (updatedCategory.IsDeleted == false)
            {
                updatedCategory.IsDeleted = true;
                updatedCategory.DeletedDate = DateTime.UtcNow.AddHours(4);
            }
            else
            {
                updatedCategory.IsDeleted = false;
                updatedCategory.DeletedDate = null;
            }
            
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);            
        }


    }
}
