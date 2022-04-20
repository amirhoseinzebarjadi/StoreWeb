using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Marina_Club.Model
{
    public class Report
    {
        public  Guid ReportId { get; set; }
        public List<Ticket> ticket  { get; set; }
        public double Price { get; set; }
        public int Ticket { get; set; }
    }
}
