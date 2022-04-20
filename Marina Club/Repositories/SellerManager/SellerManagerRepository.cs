using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.SellerManager
{
    public class SellerManagerRepository : BaseRepository, ISellerManagerRepository
    {
        public SellerManagerRepository(MarinaClubContext context) : base(context)
        {
        }

        #region Seller Manager

        /// <summary>
        /// Get Seller
        /// </summary>
        /// <returns></returns>
        public async Task<Model.SellerManager> GetSellerManagerAsync(Guid SellerManagerId)
        {
            var result = await _context.SellerManagers
                .Include(q => q.SellerAddress)
                .Include(s => s.SellerInfo)
                .FirstOrDefaultAsync(p=>p.SellerManagerId==SellerManagerId);
            return result;
        }

        /// <summary>
        /// Add Seller
        /// </summary>
        /// <param name="sellerManager"></param>
        /// <returns></returns>
        public async Task<bool> AddSellerManagerAsync(Model.SellerManager sellerManager)
        {
            await _context.SellerManagers
                .AddRangeAsync(sellerManager);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Updates Seller
        /// </summary>
        /// <param name="DiscountSeller"></param>
        /// <param name="SellerCode"></param>
        /// <returns></returns>
        public async Task<Model.SellerManager> GetSellerManagerForUpdateAsync(Guid SellerManagerId)
        {
            return await _context.SellerManagers.FirstOrDefaultAsync(q => q.SellerManagerId == SellerManagerId);
        }

        public async Task<bool> UpdateSellerManagerAsync()
        {
            var result = await _context
                .SaveChangesAsync();
            return result > 0;
        }

        /// <summary>
        /// Seller Dto With Search
        /// </summary>
        /// <param name="SearchWordSeller"></param>
        /// <param name="SearchWordCityNameSeller"></param>
        /// <returns></returns>
        public async Task<List<Model.SellerManager>> GetSellerManagerDtoAsync(int PageSize, int PageNumber)
        {
            var result = await _context.SellerManagers
                .Include(q => q.SellerInfo)
                .Include(q => q.SellerAddress)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            return result;
        }

        public async Task<List<Model.SellerManager>> GetSellerManagersDtoAsync(/*string SearchWordSeller, int PageSize, int PageNumber*/)
        {

            var result = await _context.SellerManagers
                .Include(q => q.SellerInfo)
                .Include(q => q.SellerAddress)
                .ToListAsync();
          
            return result;
        }
        #endregion
    }
}
