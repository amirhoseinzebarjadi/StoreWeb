using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Model;

namespace Marina_Club.Command.UpdateCommand
{
    public class UpdateTicketInfoCommand
    {
        public Guid TicketId { get; set; }

        public Guid SansId { get; set; }



    }
}
