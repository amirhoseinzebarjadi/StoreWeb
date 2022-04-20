using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Repositories.Counter;
namespace Marina_Club.Services.Counter
{
    public class CounterService : ICounterService
    {
        private readonly ICounterRepository _counterRepository;
        public CounterService(ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
        }

        #region Counter
        /// <summary>
        /// Sans Dto In Counter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.Sans>> GetSansDtoInCounterAsync(int PageSize, int PageNumber)
        {
            var result = await _counterRepository.GetSansDtoInCounterAsync(PageSize,PageNumber);
            return result;
        }

        public async Task<List<Model.Sans>> GetSansDtoInCounterAsync(int PageSize, int PageNumber, string SearchWordDateSansCounter, string SearchWordFunSansTypeCounter)
        {
            var result = await _counterRepository.GetSansDtoInCounterAsync();
            var sans = new List<Model.Sans>();
            if (!string.IsNullOrEmpty(SearchWordFunSansTypeCounter) && !string.IsNullOrEmpty(SearchWordDateSansCounter))
            {
                var searchFunType = result.Where(q => q.WaterFunIdForDto.FunType.Contains(SearchWordFunSansTypeCounter)).ToList();
                var searchDate = result.Where(s => s.Date.ToString().Contains(SearchWordDateSansCounter)).ToList();
                sans.AddRange(searchFunType);
                sans.AddRange(searchDate);
            }

            var results = sans.GroupBy(a => a.SansId)
                .Select(g => g.First())
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToList();

            return results;
        }

        /// <summary>
        /// Get Counter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.Ticket>> GetSellerManagerInCounterAsync(int PageSize, int PageNumber)
        {
            var result = await _counterRepository.GetSellerManagerInCounterAsync( PageSize, PageNumber);
            return result;
        }

        public async Task<List<Model.Ticket>> GetSellerManagerInCounterAsync(int PageSize, int PageNumber, string SearchWordDateInCounter, string SearchWordFunTypeInCounter)
        {
            var result = await _counterRepository.GetSellerManagerInCounterAsync();
            var sans = new List<Model.Ticket>();
            if (!string.IsNullOrEmpty(SearchWordDateInCounter) && !string.IsNullOrEmpty(SearchWordFunTypeInCounter))
            {
                var searchFunTypes = result.Where(q => q.FunType.ToString() == SearchWordFunTypeInCounter).ToList();
                var searchDates = result.Where(s => s.Date.ToString() == SearchWordDateInCounter).ToList();
                sans.AddRange(searchFunTypes);
                sans.AddRange(searchDates);
            }
            var results = sans.GroupBy(a => a.TicketId)
                .Select(g => g.First())
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToList();
            return results;
        }

        /// <summary>
        /// Add Seller In Counter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<int> AddSellerManagerInCounterAsync(AddCounterTicketCommand command)
        {
            int result;
            
            var waterFun = await _counterRepository.OneGetWaterFunAsync(command.WaterFunId);
            var sans = await _counterRepository.OneGetSansAsync(command.SansId);

            var ticket = new Model.Ticket();

            // تعداد درخواست بلیط به صورت حضوری
            var requestTickets = RequestTickets(command.TicketReservationMan, command.TicketReservationWoman);

            // ظرفیت باقی مانده حضوری
            var remainingCapacityPerson = RemainingCapacityPerson(sans.SoldTicketPerson, sans.SalesCapacityPerson);

            // مبلغ نهایی
            var totalPrice = this.TotalPrice(waterFun.Price, requestTickets);

            // آیا تعداد بلیط های درخواست بیشتر از تعداد باقی مانده هست؟
            if (requestTickets > remainingCapacityPerson)
                return 2;

            var soldTicketPerson = SoldTicketPerson(requestTickets, sans.SalesCapacityPerson);


            ticket.TicketId = Guid.Empty;
            ticket.TicketNumber = Guid.NewGuid();
            ticket.FirstNameAndLastName = command.FirstNameAndLastNameCounter;
            ticket.PhoneNumber = command.PhoneNumberCounter;
            ticket.TotalPrice = totalPrice;
            ticket.NationalCode = command.NationalCodeCounter;
            ticket.Date = command.DateTicketCounter;
            ticket.FunType = waterFun.FunType;
            ticket.AddressCounter = command.AddressCounter;
            ticket.TicketReservation = requestTickets;
            ticket.TicketReservationMan = command.TicketReservationMan;
            ticket.TicketReservationWoman = command.TicketReservationWoman;
            ticket.ESoldType = ESoldType.SoldSellerCounter;
            ticket.SellerCounterId = Guid.NewGuid();
            ticket.RemainingCapacityPerson = remainingCapacityPerson;
            ticket.SoldTicketPerson = soldTicketPerson;
            ticket.IsCancelReservation = false;
            ticket.SansId = command.SansId;
            ticket.WaterFunId = command.WaterFunId;

            await _counterRepository.AddSellerManagerInCounterAsync(ticket);

            sans.SoldTicketPerson = soldTicketPerson;

            result = await _counterRepository.UpdateTicketCounterAsync();

            return result;
        }
        //public async Task<int> AddReservationSellerAsync(AddSellerTicketCommand command)
        //{
        //    int result;

        //    var waterFun = await _sellerPanelRepository.OneGetWaterFunAsync(command.WaterFunId);
        //    var sans = await _sellerPanelRepository.OneGetSansAsync(command.SansId);

        //    var ticket = new Model.Ticket();
        //    var tickets = RequestTickets(command.TicketReservationMan, command.TicketReservationWoman);
        //    var totalPrice = TotalPrice(sans.Price, tickets);
        //    var remainingCapacityOnline = RemainingCapacityOnline(sans.SoldTicketOnline, sans.SalesCapacityOnline);
        //    var soldTicketOnline = SoldTicketOnline(tickets, sans.SoldTicketOnline);


        //    if (tickets > remainingCapacityOnline)
        //        return 2;

        //    ticket.TicketNumber = Guid.NewGuid();
        //    ticket.TicketReservation = tickets;
        //    ticket.IsCancelReservation = false;
        //    ticket.TotalPrice = totalPrice;
        //    ticket.FunType = waterFun.FunType;
        //    ticket.DurationMinutes = waterFun.DurationMinutes;
        //    ticket.Date = sans.Date;
        //    ticket.StartTimeSans = sans.StartTimeSans;
        //    ticket.FirstNameAndLastName = command.FirstNameAndLastName;
        //    ticket.PhoneNumber = command.PhoneNumber;
        //    ticket.TicketReservationMan = command.TicketReservationMan;
        //    ticket.TicketReservationWoman = command.TicketReservationWoman;
        //    ticket.NationalCode = command.NationalCodeReservationSeller;
        //    ticket.SellerId = command.SellerInfoId;
        //    ticket.ESoldType = ESoldType.SoldSeller;
        //    ticket.RemainingCapacityOnline = remainingCapacityOnline;
        //    ticket.SoldTicketOnline = soldTicketOnline;

        //    _sellerPanelRepository.AddReservationSellerAsync(ticket);

        //    sans.SoldTicketOnline = soldTicketOnline;

        //    result = await _sellerPanelRepository.UpdateSoldTicketAsync();

        //    return result;
        //}

        public async Task<List<Model.WaterFun>> GetWaterFunDtoInCounterAsync()
        {
            var result = await _counterRepository.GetWaterFunDtoInCounterAsync();
            return result;
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<int> UpdateTicketCounterAsync(UpdateTicketCommand command)
        {
            var ticket = await _counterRepository.GetTicketCounterForUpdateAsync(command.TicketId);

            
            var Sans = await _counterRepository.OneGetSansAsync(ticket.SansId);

            ticket.IsCancelReservation = true;

            var newsoldTicketPerson = NewSoldTicketperson(ticket.TicketReservation, Sans.SoldTicketPerson);

            var newremainingCapacityPerson = NewRemainingCapacityperson(ticket.RemainingCapacityPerson, ticket.TicketReservation);

            Sans.SoldTicketPerson = newsoldTicketPerson;
            ticket.RemainingCapacityOnline = newremainingCapacityPerson;

            var result = await _counterRepository.UpdateTicketCounterAsync();

            return result;
        }

        #endregion

        #region MyMethod

        private int RequestTickets(int ticketReservationMan, int ticketReservationWoman)
        {
            var tickets = ticketReservationMan + ticketReservationWoman;
            return tickets;
        }

        private double TotalPrice(double price, int ticketReservation)
        {
            var totalPrice = price * ticketReservation;
            return totalPrice;
        }

        private int RemainingCapacityPerson(int SoldTicket, int SalesCapacityPerson)
        {
            var remainingCapacityPerson = SalesCapacityPerson - SoldTicket;
            return remainingCapacityPerson;
        }

        private int SoldTicketPerson(int tickets, int SoldTicket)
        {
            var soldTicketPerson = SoldTicket + tickets;
            return soldTicketPerson;
        }

        private int NewSoldTicketperson(int TicketReservation, int SoldTicket)
        {
            var newsoldTicketPerson = SoldTicket - TicketReservation;
            return newsoldTicketPerson;
        }

        private int NewRemainingCapacityperson(int RemainingCapacityPerson, int TicketReservation)
        {
            var newremainingCapacityPerson = TicketReservation + RemainingCapacityPerson;
            return newremainingCapacityPerson;
        }

        #endregion

    }
}
