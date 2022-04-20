using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.Sans
{

    public class SansRepository : BaseRepository, ISansRepository
    {
        public SansRepository(MarinaClubContext context) : base(context)
        {
        }

        #region Sans

        //public async Task<List<Sans>> GetFunTypeAsync(Guid dateQuery, Guid funTypeQuery)
        //{
        //    var result = await _context.Sanses.ToListAsync();
        //    if (!funTypeQuery.Equals() == Guid.Empty && Guid.IsNullOrEmpty(dateQuery))
        //    {
        //        result = result.Where(q => q.WaterFunId == funTypeQuery)
        //            .Where(a => a.Date.ToString() == DateTime.Now.ToString()).ToList();
        //    }
        //    if (!string.IsNullOrEmpty(funTypeQuery) && !string.IsNullOrEmpty(dateQuery))
        //    {
        //        result = result.Where(q => q.Date.ToString() == dateQuery)
        //            .Where(a => a.WaterFunId == funTypeQuery)
        //            .ToList();
        //    }
        //    return result;
        //}
        /// <summary>
        /// GetSans
        /// </summary>
        /// <returns>گرفتن تمام سانس ها</returns>
        public async Task<IList<Model.Sans>> GetSansAsync()
        {
            return await _context.Sanses.OrderBy(q => q.Date).ToListAsync();
        }

        /// <summary>
        /// PostWaterFunSans
        /// </summary>
        /// <param name="command">دادن ایدی و تاریخ شروع سانس ها</param>
        /// <returns>ساخت سانس جدید</returns>
        public async Task<bool> AddWaterFunSansAsync(List<Model.Sans> sanses)
        {
            await _context.Sanses
                .AddRangeAsync(sanses);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// PutWaterFunSans
        /// </summary>
        /// <param name="command">دادن اطلاعت بولین سانس ها</param>
        /// <returns>تغییر لغو یا تمام شدن سانس ها</returns>
        public async Task<Model.Sans> GetUpdateWaterFunSansAsync(Guid sansId)
        {
            return await _context.Sanses.FirstOrDefaultAsync(q => q.SansId == sansId);
        }

        public async Task<bool> UpdateWaterFunSansAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Model.WaterFun> OneGetWaterFunAsync(Guid id)
        {
            return await _context.WaterFuns
                .Include(q=>q.Discounts).FirstOrDefaultAsync(q => q.Id == id);

            #endregion


        }
    }
}

