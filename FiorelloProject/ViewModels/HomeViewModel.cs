using FiorelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Slogan> Slogan { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Profession> Professions { get; set; }
        public List<Expert> Experts { get; set; }
        public List<InstagramPhoto> InstagramPhotos { get; set; }
        public List<ExpertSlider> ExpertSliders { get; set; }
        public List<BlogCard> BlogCards { get; set; }
        public List<About> About { get; set; }
        public List<AboutList> AboutLists { get; set; }
        public List<BlogHeading> BlogHeading { get; set; }
        public List<ExpertHeading> ExpertHeading { get; set; }
    }
}
