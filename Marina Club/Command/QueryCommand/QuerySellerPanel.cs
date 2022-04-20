using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.QueryCommand
{
    public class QuerySellerPanel
    {
        public  string SearchWordFunType { get; set; }
        public string SearchWordDate { get; set; }

        public int PageSize { get; set; }
        
        public int PageNumber { get; set; }
    }
}
