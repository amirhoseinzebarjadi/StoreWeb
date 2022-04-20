using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.Ticket
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        public TicketRepository(MarinaClubContext context) : base(context)
        {
        }

        public async Task<List<Model.Ticket>> GetTicketAsync(int PageSize, int PageNumber)
        {
            return await _context.Tickets
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
        }
        public async Task<List<Model.Ticket>> GetTicketAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async void AddTicketAsync(Model.Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task<Model.Ticket> OneGetTicketAsync(Guid ticketId)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(q => q.TicketId == ticketId);
        }

        public async Task<Model.WaterFun> OneGetWaterFunAsync(Guid waterFunId)
        {
            return await _context.WaterFuns
                .FirstOrDefaultAsync(q => q.Id == waterFunId );
        }

        public async Task<Model.Customer> OneGetCustomerAsync(Guid customerId)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(q => q.CustomerId == customerId);
        }

        public async Task<Model.Sans> OneGetSansAsync(Guid sansId)
        {
            return await _context.Sanses
                .FirstOrDefaultAsync(q => q.SansId == sansId);
        }
        public async Task<List<Model.Ticket>> TicketDtoAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion)
        {
            return await _context.Tickets
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
        }

        public async Task<List<Model.Ticket>> TicketDtoHistoryAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion)
        {
            return await _context.Tickets
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
        }
        public async Task<Model.Ticket> GetTicketForUpdateAsync(Guid TicketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(q => q.TicketId == TicketId);
        }
        public async Task<bool> UpdateTicketAsync()
        {
            var result = await _context
                .SaveChangesAsync();
            return result > 0;
        }

        public async Task<int> UpdateSoldTicketAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
        //public async Task <Model.Ticket> GetTicketInfoForUpdateAsync( Guid TicketId)
        //{
        //    return await _context.Tickets.FirstOrDefaultAsync(q=>q.TicketId==TicketId);
        //}
        //public async Task<bool> UpdateTicketInfoAsync()
        //{
        //    var result = await _context
        //        .SaveChangesAsync();
        //    return result > 0;
        //}
    }
}
