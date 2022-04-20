using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.SellerPanel
{
    public class SellerPanelDtoSearchCommand
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FunTypeSearch { get; set; }
        public string DateSearch { get; set; }
    }
}
