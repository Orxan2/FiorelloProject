using FiorelloProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.DAL
{
    public class FiorelloContext:IdentityDbContext<AppUser>
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
        public DbSet<InstagramPhoto> InstagramPhotos { get; set; }
        public DbSet<ExpertSlider> ExpertSliders { get; set; }
        public DbSet<BlogCard> BlogCards { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<AboutList> AboutLists { get; set; }
        public DbSet<BlogHeading> BlogHeading { get; set; }
        public DbSet<ExpertHeading> ExpertHeading { get; set; }
        public DbSet<Biography> Biography { get; set; }


    }
}
