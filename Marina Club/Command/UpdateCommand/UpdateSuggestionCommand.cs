using System;
using System.Collections.Generic;
using Marina_Club.Command.SiteManagerCommand;
using Marina_Club.Model;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateSuggestionCommand
    {
        public Guid SuggestionId { get; set; }

        public List<UpdateSliderSuggestionCommand> NewSliderSuggestion { get; set; }
        
        public Guid NewFunTypeSuggestion { get; set; }
        
        public ETitleOfSuggestion NewETitleOfSuggestions { get; set; }
    }
}
