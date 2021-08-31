﻿using FiorelloProject.DAL;
using FiorelloProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Controllers
{
    public class HomeController : Controller
    {
        public FiorelloContext _context { get; }
        public HomeController(FiorelloContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel HMV = new HomeViewModel
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Slogan = await _context.Slogan.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                ProductCategories = await _context.ProductCategories.
                Include(pc=>pc.Category).Where(pc=>pc.CategoryId == pc.Category.CategoryId).
                Include(pc=>pc.Product).Where(pc=>pc.ProductId == pc.Product.ProductId).ToListAsync(),
                Experts = await _context.Experts.Include(e => e.Profession).Where(e => e.ProfessionId == e.Profession.ProfessionId).ToListAsync(),
                InstagramPhotos = await _context.InstagramPhotos.ToListAsync(),
                ExpertSliders = await _context.ExpertSliders.Include(e => e.Profession).Where(e => e.ProfessionId == e.Profession.ProfessionId).ToListAsync(),
                BlogCards = await _context.BlogCards.ToListAsync(),
                About = await _context.About.ToListAsync(),
                AboutLists = await _context.AboutLists.ToListAsync(),
                BlogHeading = await _context.BlogHeading.ToListAsync(),
                ExpertHeading = await _context.ExpertHeading.ToListAsync()
            };
            return View(HMV);
        }
    }
}