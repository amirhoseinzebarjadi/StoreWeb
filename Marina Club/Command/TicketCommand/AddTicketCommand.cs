using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.TicketCommand
{
    public class AddTicketCommand
    {
        public Guid CustomerId { get; set; }

        public Guid WaterFunId { get; set; }

        public Guid SansId { get; set; }

        public int TicketReservationMan { get; set; }

        public int TicketReservationWoman { get; set; }
    }
}
