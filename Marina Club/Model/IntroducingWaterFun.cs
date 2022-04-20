using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class IntroducingWaterFun
    {
        [Key]
        public Guid SliderIntroducingId { get; set; }
        public string IntroducingText { get; set; }
        public Guid WaterFunIntroducing { get; set; }
        public  string IconePathFileIntroducing { get; set; }
        public  string SliderpathFileIntroducing { get; set; }
        public  string FunTypeIntroducing { get; set; }
    }
}
