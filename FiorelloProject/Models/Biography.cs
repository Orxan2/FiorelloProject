using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloProject.Models
{    
    public class Biography
    {
       public enum TitleType
        {
            Logo = 1,
            SocialMedia = 2
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }        
        public TitleType Type { get; set; }
       
    }
}
