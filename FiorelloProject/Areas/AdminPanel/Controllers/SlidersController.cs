using FiorelloProject.DAL;
using FiorelloProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SlidersController : Controller
    {
        
        public FiorelloContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public SlidersController(FiorelloContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: SlidersController
        public IActionResult Index()
        {
            var slider = _context.Sliders;
            return View(slider);
        }

        // GET: SlidersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SlidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return NotFound();
            };
            if (!slider.Photo.ContentType.Contains("image"))
            {
                return NotFound();
            }
            if (slider.Photo.Length / 1024 > 3000)
            {
                return NotFound();
            }
            string filename = Guid.NewGuid().ToString() + '-' + slider.Photo.FileName;
            string environment = _env.WebRootPath;
            string newSlider = Path.Combine(environment, "img", filename);
            using (FileStream file = new FileStream(newSlider, FileMode.Create))
            {
                slider.Photo.CopyTo(file);
            }
            slider.ImagePath = filename;
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: SlidersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SlidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlidersController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var slider = _context.Sliders.FirstOrDefault(s=>s.SliderId == id);
            if (slider == null)
            {
                return BadRequest();
            }


            return View(slider);
        }

        // POST: SlidersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var slider = _context.Sliders.FirstOrDefault(s => s.SliderId == id);
            if (slider == null)
            {
                return BadRequest();
            }
            else if (id != slider.SliderId)
            {
                return BadRequest();
            }


            string environment = _env.WebRootPath;
            string folderPath = Path.Combine(environment, "img", slider.ImagePath);
            FileInfo file = new FileInfo(folderPath);
            file.Delete();

            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
