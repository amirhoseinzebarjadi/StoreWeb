using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Command.SellerManagerCommand;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Repositories.SellerPanel;

namespace Marina_Club.Services.SellerPanel
{
    public class SellerPanelService : ISellerPanelService
    {
        private readonly ISellerPanelRepository _sellerPanelRepository;
        public SellerPanelService(ISellerPanelRepository sellerPanelRepository)
        {
            _sellerPanelRepository = sellerPanelRepository;
        }

        public async Task<Model.WaterFun> GetSellerReservationDtoAsync(GetOneDtoWaterFunInSellerPanel command)
        {
            var result = await _sellerPanelRepository.GetSellerReservationDtoAsync(command.Id);
            return result;
        }

        public async Task<Model.Ticket> GetSellerPanelAsync(Guid SellerPanelId)
        {
            var result = await _sellerPanelRepository.GetSellerPanelAsync(SellerPanelId);
            return result;
        }

        public async Task<List<Model.Ticket>> GetReservationSellerAsync(int PageSize, int PageNumber)
        {
            var result = await _sellerPanelRepository.GetReservationSellerAsync(PageSize, PageNumber);
            return result;
        }
        //##
        public async Task<int> AddReservationSellerAsync(AddSellerTicketCommand command)
        {
            int result;

            var waterFun = await _sellerPanelRepository.OneGetWaterFunAsync(command.WaterFunId);
            var sans = await _sellerPanelRepository.OneGetSansAsync(command.SansId);

            var ticket = new Model.Ticket();
            var tickets = Tickets(command.TicketReservationMan, command.TicketReservationWoman);
            var totalPrice = TotalPrice(sans.Price, tickets);
            var remainingCapacityOnline = RemainingCapacityOnline(sans.SoldTicketOnline, sans.SalesCapacityOnline);
            var soldTicketOnline = SoldTicketOnline(tickets, sans.SoldTicketOnline);


            if (tickets > remainingCapacityOnline)
                return 2;

            ticket.TicketNumber = Guid.NewGuid();
            ticket.SellerId=Guid.NewGuid();
            ticket.TicketReservation = tickets;
            ticket.IsCancelReservation = false;
            ticket.TotalPrice = totalPrice;
            ticket.FunType = waterFun.FunType;
            ticket.DurationMinutes = waterFun.DurationMinutes;
            ticket.Date = sans.Date;
            ticket.StartTimeSans = sans.StartTimeSans;
            ticket.FirstNameAndLastName = command.FirstNameAndLastName;
            ticket.PhoneNumber = command.PhoneNumber;
            ticket.TicketReservationMan = command.TicketReservationMan;
            ticket.TicketReservationWoman = command.TicketReservationWoman;
            ticket.NationalCode = command.NationalCodeReservationSeller;
            ticket.SellerId = command.SellerInfoId;
            ticket.ESoldType = ESoldType.SoldSeller;
            ticket.SansId = command.SansId;
            ticket.WaterFunId = command.WaterFunId;
            ticket.RemainingCapacityOnline = remainingCapacityOnline;
            ticket.SoldTicketOnline = soldTicketOnline;

            _sellerPanelRepository.AddReservationSellerAsync(ticket);

            sans.SoldTicketOnline = soldTicketOnline;

            result = await _sellerPanelRepository.UpdateSoldTicketAsync();
            result = 1;
            return result;
        }

        /// <summary>
        /// Seller Dto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.Ticket>> GetSellerPanelDtoAsync(int PageSize, int PageNumber)
        {
            var result = await _sellerPanelRepository.GetSellerPanelDtoAsync(PageNumber, PageSize);
            return result;
        }

        /// <summary>
        /// Seller Dto Search
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.Ticket>> GetSellerPanelsDtoAsync(int PageNumber, int PageSize, DateTime SearchWordDate, string SearchWordFunType)
        {
            var sellerPanel = await _sellerPanelRepository.GetSellerPanelsDtoAsync();
            var result = new List<Model.Ticket>();
            if (!string.IsNullOrEmpty(SearchWordFunType))
            {
                var searchFunType = sellerPanel.Where(q => q.FunType == SearchWordFunType).ToList();
                var searchDate = sellerPanel.Where(s => s.Date == SearchWordDate).ToList();
                result.AddRange(searchDate);
                result.AddRange(searchFunType);
            }
            var results = result.GroupBy(x => x.TicketId)
                .Select(g => g.First())
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToList();
            return results;
        }

        public async Task<bool> DeleteReservationAsync(DeleteReservationCommand command)
        {
            var suggestion = await _sellerPanelRepository.GetReservationForDelete(command.ReservSellerInfoId);
            if (suggestion is null)
                return false;

            return await _sellerPanelRepository.DeleteReservationAsync(suggestion);
        }
        public async Task<bool> UpdateTicketPanelAsync(UpdateTicketCommand command)
        {
            var ticket = await _sellerPanelRepository.GetTicketPanelForUpdateAsync(command.TicketId);

            var Sans = await _sellerPanelRepository.OneGetSansAsync(ticket.SansId);

            ticket.IsCancelReservation = true;

            var newsoldTicketOnline = NewSoldTicketOnline(ticket.TicketReservation, Sans.SoldTicketOnline);

            var newremainingCapacityOnline = NewRemainingCapacityOnline(ticket.RemainingCapacityOnline, ticket.TicketReservation);

            Sans.SoldTicketOnline = newsoldTicketOnline;
            ticket.RemainingCapacityOnline = newremainingCapacityOnline;

            var result = await _sellerPanelRepository.UpdateTicketPanelAsync();

            return result;
        }

        #region privateMethod

        private double TotalPrice(double price, int ticketReservation)
        {
            var totalPrice = price * ticketReservation;
            return totalPrice;
        }

        private int Tickets(int ticketReservationMan, int ticketReservationWoman)
        {
            var tickets = ticketReservationMan + ticketReservationWoman;
            return tickets;
        }
        private int RemainingCapacityOnline(int SoldTicket, int SalesCapacityOnline)
        {
            var remainingCapacityOnline = SalesCapacityOnline - SoldTicket;
            return remainingCapacityOnline;
        }
        /// <summary>
        /// New SpldTicket
        /// </summary>
        /// <param name="TicketReservation"></param>
        /// <param name="SalesCapacityOnline"></param>
        /// <returns></returns>
        private int SoldTicketOnline(int tickets, int SoldTicket)
        {
            var soldTicketOnline = SoldTicket + tickets;
            return soldTicketOnline;
        }
        private int NewSoldTicketOnline(int TicketReservation, int SoldTicket)
        {
            var soldTicketOnline = SoldTicket - TicketReservation;
            return soldTicketOnline;
        }
        private int NewRemainingCapacityOnline(int RemainingCapacityOnline, int TicketReservation)
        {
            var remainingCapacityOnline = TicketReservation + RemainingCapacityOnline;
            return remainingCapacityOnline;
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>


        #endregion
    }
}

