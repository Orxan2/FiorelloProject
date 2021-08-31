using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class ExpertSlider
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public Profession Profession { get; set; }
        public int ProfessionId { get; set; }
    }
}
