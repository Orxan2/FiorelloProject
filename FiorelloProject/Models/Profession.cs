using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }
        public string Name { get; set; }
        public List<Expert> Experts { get; set; }
        public List<ExpertSlider> ExpertSliders { get; set; }
    }
}
