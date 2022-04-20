using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class AboutUs
    {
        [Key]
        public  Guid AboutUsId { get; set; }
        public  string TextAboutUs { get; set; }
    }
}
