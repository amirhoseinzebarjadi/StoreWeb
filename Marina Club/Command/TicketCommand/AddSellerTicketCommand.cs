using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.TicketCommand
{
    public class AddSellerTicketCommand
    {
        public string FirstNameAndLastName { get; set; }

        public string PhoneNumber { get; set; }

        public string NationalCodeReservationSeller { get; set; }

        public Guid WaterFunId { get; set; }

        public Guid SansId { get; set; }

        public Guid SellerInfoId { get; set; }

        public int TicketReservationMan { get; set; }

        public int TicketReservationWoman { get; set; }
    }
}
