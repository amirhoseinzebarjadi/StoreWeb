using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marina_Club.Model
{
    public class Suggestion//Get//post
    {
        [Key]
        public Guid SuggestionId { get; set; }

        public List<SliderSuggestion> SliderSuggestion { get; set; }
        public Guid FunTypeSuggestion { get; set; }
        public ETitleOfSuggestion ETitleOfSuggestions { get; set; }
    }
}