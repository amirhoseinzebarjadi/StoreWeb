using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.TicketCommand
{
    public class ReportQueryCommand
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public  string SearchFunType { get; set; }
        public  DateTime SearchDate { get; set; }
        public  DateTime SearchDate2 { get; set; }
    }
}
