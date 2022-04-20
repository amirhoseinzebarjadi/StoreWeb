using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.Counter
{
    public class CounterRepository : BaseRepository, ICounterRepository
    {
        public CounterRepository(MarinaClubContext context) : base(context)
        {
        }


        #region Counter

        /// <summary>
        /// Sans Dto In Counter
        /// </summary>
        /// <param name="SearchWordDateSansCounter"></param>
        /// <param name="SearchWordFunSansTypeCounter"></param>
        /// <returns></returns>
        public async Task<List<Model.Sans>> GetSansDtoInCounterAsync(int PageSize, int PageNumber)
        {
            var result = await _context.Sanses
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .Include(q => q.WaterFunIdForDto)
                .ToListAsync();
            return result;
        }

        public async Task<List<Model.Sans>> GetSansDtoInCounterAsync(/* int PageSize, int PageNumber*/)
        {
            var result = await _context.Sanses
                .Include(q => q.WaterFunIdForDto)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// Seller Infos or Ticket In Counter With Search
        /// </summary>
        /// <param name="SearchWordDateInCounter"></param>
        /// <param name="SearchWordFunTypeInCounter"></param>
        /// <returns></returns>
        public async Task<List<Model.Ticket>> GetSellerManagerInCounterAsync(int PageSize, int PageNumber)
        {
            var result = await _context.Tickets
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            return result;
        }

        public async Task<List<Model.Ticket>> GetSellerManagerInCounterAsync(/* int PageSize, int PageNumber*/)
        {
            var result = await _context.Tickets
               /* .Include(q => q.FunTypeTicketCounter)*/.ToListAsync();
            return result;
        }

        /// <summary>
        /// Add Seller Or Ticket In Counter
        /// </summary>
        /// <param name="sellerManagerInCounter"></param>
        /// <returns></returns>
        public async Task<bool> AddSellerManagerInCounterAsync(Model.Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Model.WaterFun>> GetWaterFunDtoInCounterAsync()
        {
            var result = await _context.WaterFuns.ToListAsync();
            return result;
        }

        public async Task<Model.WaterFun> OneGetWaterFunAsync(Guid waterFunId)
        {
            return await _context.WaterFuns
                .Include(q=>q.Discounts)
                .FirstOrDefaultAsync(q => q.Id == waterFunId);
        }
        public async Task<Model.Sans> OneGetSansAsync(Guid SansId)
        {
            return await _context.Sanses
                .FirstOrDefaultAsync(q => q.SansId == SansId);
        }
        public async Task<Model.Ticket> GetTicketCounterForUpdateAsync(Guid TicketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(q => q.TicketId == TicketId&&q.ESoldType == ESoldType.SoldSellerCounter);
        }
        public async Task<int> UpdateTicketCounterAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
        //public async Task<int> UpdateSoldTicketAsync()
        //{
        //    var result = await _context.SaveChangesAsync();
        //    return result;
        //}
       
        #endregion
    }
}
