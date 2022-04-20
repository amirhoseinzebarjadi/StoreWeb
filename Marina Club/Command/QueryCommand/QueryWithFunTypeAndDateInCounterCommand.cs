using System;

namespace Marina_Club.Command.QueryCommand
{
    public class QueryWithFunTypeAndDateInCounterCommand
    {
        public string SearchWordDateInCounter { get; set; }
        
        public string SearchWordFunTypeInCounter { get; set; }
        
        public int PageNumber { get; set; }
        
        public int PageSize { get; set; }
    }
}
