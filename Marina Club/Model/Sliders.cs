using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Marina_Club.Model
{
    public class Sliders
    {[Key]
        public Guid SlidersId { get; set; }
        public string PathSlider { get; set; }
        public  string NameSlider { get; set; }
    }
}
