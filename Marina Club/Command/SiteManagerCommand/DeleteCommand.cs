using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.SiteManagerCommand
{
    public class DeleteCommand
    {
        public Guid SlidersId { get; set; }
        
        public Guid Id { get; set; }
        
        public Guid SliderIntroducingId { get; set; }
    }
}
