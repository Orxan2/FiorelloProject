using FiorelloProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.DAL
{
    public class FiorelloContext:DbContext
    {
        public FiorelloContext(DbContextOptions<FiorelloContext> options):base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Slogan> Slogan { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Expert> Experts { get; set; }
    }
}
