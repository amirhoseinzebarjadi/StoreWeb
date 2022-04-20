using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Dto
{
    public class TicketDto
    {
        public Guid TicketNumber { get; set; }

        public int TicketReservation { get; set; }

        public string FunType { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTimeSans { get; set; }

        public  int Tickets { get; set; }

        public  double Price { get; set; }

        public  Guid SellerId { get; set; }
    }
}
