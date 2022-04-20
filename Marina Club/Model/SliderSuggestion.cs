using System;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class SliderSuggestion
    {
        [Key]
        public Guid SliderSuggestionId { get; set; }
        public string TextFileSuggestion { get; set; }
        public  string PathFileSuggestion { get; set; }
        public string NameFileSuggestion { get; set; }

    }
}
