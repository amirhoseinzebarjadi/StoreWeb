using System;
using System.Collections.Generic;
using Marina_Club.Model;

namespace Marina_Club.Command.SiteManagerCommand
{
    public class AddSuggestionCommand
    {
        public List<AddSliderSuggestionCommand> SliderSuggestion { get; set; }
        
        public Guid FunTypeSuggestion { get; set; }
        
        public ETitleOfSuggestion ETitleOfSuggestions { get; set; }

    }
}
