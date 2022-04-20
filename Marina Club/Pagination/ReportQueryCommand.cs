using System;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Model;

namespace Marina_Club.Pagination
{
    public class PaginationCommand
    {
        public  int PageNumber { get; set; }
        public  int PageSize { get; set; }
        public  ETitleOfSuggestion ETitleOfSuggestion { get; set; }
      
            
    }
}
