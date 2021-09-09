using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class Slider
    {
        public int SliderId { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required,NotMapped]
        public IFormFile Photo { get; set; }
    }
}
