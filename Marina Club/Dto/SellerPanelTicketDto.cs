using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Model;

namespace Marina_Club.Dto
{
    public class SellerPanelTicketDto
    {
        public Guid TicketId { get; set; }

        public Guid SellerId { get; set; }

        public Guid SellerCounterId { get; set; }

        public Guid TicketNumber { get; set; }

        public int TicketReservation { get; set; }

        public int TicketReservationMan { get; set; }

        public int TicketReservationWoman { get; set; }

        public bool IsCancelReservation { get; set; }

        public double TotalPrice { get; set; }

        public string FunType { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartTimeSans { get; set; }

        public string FirstNameAndLastName { get; set; }

        public string PhoneNumber { get; set; }

        public int DurationMinutes { get; set; }

        public int CapacityOnline { get; set; }

        public ESoldType ESoldType { get; set; }

        public int RemainingCapacityOnline { get; set; }

        public int SoldTicketOnline { get; set; }

        public string NationalCode { get; set; }

        public string AddressCounter { get; set; }
    }
}
