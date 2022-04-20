using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Repositories.Ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore.Update;
namespace Marina_Club.Services.Ticket
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.Ticket>> ListAsyncTicket(int pageNumber ,int  pageSize)
        {
            return await _ticketRepository.GetTicketAsync(pageSize, pageNumber);
        }

        public async Task<List<Model.Ticket>> ListAsyncTicket()
        {
            return await _ticketRepository.GetTicketAsync();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<int> AddTicketAsync(AddTicketCommand command)
        {
            int result;
            var waterFun = await _ticketRepository.OneGetWaterFunAsync(command.WaterFunId);
            var customer = await _ticketRepository.OneGetCustomerAsync(command.CustomerId);
            var sans = await _ticketRepository.OneGetSansAsync(command.SansId);
            var ticket = new Model.Ticket();
            var tickets = Tickets(command.TicketReservationMan, command.TicketReservationWoman);
            var totalPrice = TotalPrice(sans.Price, tickets);
            var remainingCapacityOnline = RemainingCapacityOnline(sans.SoldTicketOnline, sans.SalesCapacityOnline);
            var soldTicketOnline = SoldTicketOnline(tickets, sans.SoldTicketOnline);

            if (tickets > remainingCapacityOnline)
            {
                return 50;
            }

            ticket.TicketId = Guid.NewGuid();
            ticket.TicketNumber = Guid.NewGuid();
            ticket.TicketReservation = tickets;
            ticket.IsCancelReservation = false;
            ticket.TotalPrice = totalPrice;
            ticket.FunType = waterFun.FunType;
            ticket.DurationMinutes = waterFun.DurationMinutes;
            ticket.Date = sans.Date;
            ticket.StartTimeSans = sans.StartTimeSans;
            ticket.FirstNameAndLastName = customer.FirstNameAndLastName;
            ticket.PhoneNumber = customer.PhoneNumber;
            ticket.TicketReservationMan = command.TicketReservationMan;
            ticket.TicketReservationWoman = command.TicketReservationWoman;
            ticket.CapacityOnline = sans.SalesCapacityOnline;
            ticket.ESoldType = ESoldType.SoldCustomer;
            ticket.RemainingCapacityOnline = remainingCapacityOnline;
            ticket.SoldTicketOnline = soldTicketOnline;
            ticket.SansId = command.SansId;
            ticket.WaterFunId = command.WaterFunId;

            _ticketRepository.AddTicketAsync(ticket);

            sans.SoldTicketOnline = soldTicketOnline;

            result = await _ticketRepository.UpdateSoldTicketAsync();

            return result;
        }

        /// <summary>
        /// Get One
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<Model.Ticket> OneGetTicketAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.OneGetTicketAsync(ticketId);
            return ticket;
        }

        /// <summary>
        /// Dto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.Ticket>> TicketDtoAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion)
        {
            var Result = await _ticketRepository.TicketDtoAsync(PageNumber, PageSize , eTitleOfSuggestion);
            var tickets = new Model.Ticket();
            var newResult = Result.Where(q => q.Date > DateTime.Now).ToList();
            return newResult;
        }

        public async Task<List<Model.Ticket>> TicketDtoHistoryAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion)
        {
            var Result = await _ticketRepository.TicketDtoHistoryAsync(PageNumber, PageSize , eTitleOfSuggestion);
            var tickets = new Model.Ticket();
            var newResult = Result.Where(q => q.Date > DateTime.Now).ToList();
            return newResult;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<bool> UpdateTicketAsync(UpdateTicketCommand command)
        {
            var ticket = await _ticketRepository.GetTicketForUpdateAsync(command.TicketId);

            var Sans = await _ticketRepository.OneGetSansAsync(ticket.SansId);

            ticket.IsCancelReservation = true;

            var newsoldTicketOnline = NewSoldTicketOnline(ticket.TicketReservation, Sans.SoldTicketOnline);

            var newremainingCapacityOnline = NewRemainingCapacityOnline(ticket.RemainingCapacityOnline, ticket.TicketReservation);

            Sans.SoldTicketOnline = newsoldTicketOnline;
            ticket.RemainingCapacityOnline = newremainingCapacityOnline;
            var result = await _ticketRepository.UpdateTicketAsync();



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
            var newsoldTicketOnline = SoldTicket - TicketReservation;
            return newsoldTicketOnline;
        }
        private int NewRemainingCapacityOnline(int RemainingCapacityOnline, int TicketReservation)
        {
            var newremainingCapacityOnline = TicketReservation + RemainingCapacityOnline;
            return newremainingCapacityOnline;
        }

        #endregion

    }
}
