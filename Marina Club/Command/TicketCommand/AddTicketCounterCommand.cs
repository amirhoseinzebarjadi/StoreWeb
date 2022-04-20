using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Command.TicketCommand
{
    public class AddCounterTicketCommand
    {

        public Guid WaterFunId { get; set; }

        public  Guid SansId { get; set; }

        public int TicketReservationMan { get; set; }

        public int TicketReservationWoman { get; set; }

        public string AddressCounter { get; set; }

        public string NationalCodeCounter { get; set; }

        public string PhoneNumberCounter { get; set; }
        
        public double AmountPaid { get; set; }

        public string FirstNameAndLastNameCounter { get; set; }

        public Guid SellerManagerInCounterId { get; set; }

        public DateTime DateTicketCounter { get; set; }

    }
}
