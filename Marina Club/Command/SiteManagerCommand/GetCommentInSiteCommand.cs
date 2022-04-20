using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.SiteManagerCommand
{
    public class GetCommentInSiteCommand
    {
        public Guid FunTypeId { get; set; }
        
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }

    }
}
