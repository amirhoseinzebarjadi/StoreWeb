using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.SellerPanel
{
    public class SellerPanelRepository : BaseRepository, ISellerPanelRepository
    {
        public SellerPanelRepository(MarinaClubContext context) : base(context)
        {
        }
        
        public async Task<Model.Ticket> GetSellerPanelAsync(Guid SellerPanelId)
        {
            var result = await _context.Tickets
                .FirstOrDefaultAsync(p => p.SellerId == SellerPanelId);
            return result;
        }


        /// <summary>
        /// Get Dto WaterFun
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        public async Task<Model.WaterFun> GetSellerReservationDtoAsync(Guid Id)
        {
            var result = await _context.WaterFuns.FirstOrDefaultAsync(q=>q.Id==Id);
            return result;
        }

        public async Task<List<Model.Ticket>> GetReservationSellerAsync(int PageNumber, int PageSize)
        {
            var result = await _context.Tickets
                .OrderBy(q=>q.Date)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
            return result;
        }

        public async void AddReservationSellerAsync(Model.Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket) ;
        }

        public async Task<Model.Ticket> GetReservationForDelete(Guid ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(e => e.TicketId == ticketId);
        }

        /// <summary>
        /// Seller Dto With Search
        /// </summary>
        /// <returns></returns>
        public async Task<List<Model.Ticket>> GetSellerPanelDtoAsync(int PageSize, int PageNumber)
        {
            var result = await _context.Tickets.OrderBy(q=>q.Date)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            return result;
        }

        public async Task<List<Model.Ticket>> GetSellerPanelsDtoAsync(/*string SearchWordSeller, int PageSize, int PageNumber*/)
        {

            var result = await _context.Tickets.OrderBy(q=>q.Date)
                .ToListAsync();

            return result;
        }

        public async Task<bool> DeleteReservationAsync(Model.Ticket ticket)
        {
            _context.Tickets.RemoveRange(ticket);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }

        public async Task<Model.WaterFun> OneGetWaterFunAsync(Guid waterFunId)
        {
            return await _context.WaterFuns
                .Include(q=>q.Discounts)
                .FirstOrDefaultAsync(q => q.Id == waterFunId);
        }
        
        public async Task<Model.Sans> OneGetSansAsync(Guid sansId)
        {
            return await _context.Sanses
                .FirstOrDefaultAsync(q => q.SansId == sansId);
        }

        public async Task<int> UpdateSoldTicketAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="TicketId"></param>
        /// <returns></returns>
        public async Task<Model.Ticket> GetTicketPanelForUpdateAsync(Guid TicketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(q => q.TicketId == TicketId&&q.ESoldType==ESoldType.SoldSeller);
        }
       
        public async Task<bool> UpdateTicketPanelAsync()
        {
            var result = await _context
                .SaveChangesAsync();
            return result > 0;
        }
        //public async Task<List<Model.ReservationSellerInfo>> GetSellerMyReservDtoAsync(string FunTypeSearchMyReservationSeller, DateTime DateSearchSansMyReservationSeller)
        //{
        //    var result = await _context.ReservationSellerInfos.ToListAsync();
        //    if (!string.IsNullOrEmpty(FunTypeSearchMyReservationSeller))
        //        result = result.Where(q => q.WaterFunReservationSeller.FunType == FunTypeSearchMyReservationSeller).ToList();
        //    //تفریح پر و تاریخ نال//نشون بده همه با اون تفریح رو
        //    if (!string.IsNullOrEmpty(DateSearchSansMyReservationSeller.ToString()))
        //        result = result.Where(q => q.DateReservationSeller == DateSearchSansMyReservationSeller).ToList();
        //    return result;
        //}
        //#
    }
}


