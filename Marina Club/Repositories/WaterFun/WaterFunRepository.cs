using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;
namespace Marina_Club.Repositories.WaterFun
{
    public class WaterFunRepository : BaseRepository, IWaterFunRepository
    {
        public WaterFunRepository(MarinaClubContext context) : base(context)
        {
        }

        #region WaterFun

        /// <summary>
        /// Get WaterFun
        /// </summary>
        /// <returns>گرفتن کل تفریحات ابی </returns> 
        public async Task<IList<Model.WaterFun>> ListAsyncWaterFun()
        {
            return await _context.WaterFuns
                .Include(q => q.Discounts)
                .ToListAsync();
        }
        /// <summary>
        /// Post WaterFun
        /// </summary>
        /// <param name="command">دادن اطلاعات کلاس تقریحات ابی</param>
        /// <returns>ساخت تفزیحات دریایی</returns>
        public async Task<bool> WaterFunAsync(Model.WaterFun waterFun)
        {
            await _context.WaterFuns.AddAsync(waterFun);
            return await _context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// OneGetWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی</param>
        /// <returns>گرفتن اطلاعات ایدی داده شده</returns>
        public async Task<Model.WaterFun> OneGetWaterFunAsync(Guid id)
        {
            return await _context.WaterFuns
                .Include(q => q.Discounts)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
        /// <summary>
        /// GetIdWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی </param>
        /// <returns>گرفتن لیست تمام اطلاعات مربوط به اون ایدی و بقیه ایدی </returns>
        public async Task<IList<Model.WaterFun>> GetByIdCustomerAsync(Guid id)
        {
            return await _context.WaterFuns.Where(q => q.Id == id).ToListAsync();
        }
        /// <summary>
        /// PutWaterFun
        /// </summary>
        /// <param name="command">دادن تمام اطلاعت تفریحات ابی </param>
        /// <returns>تغییرات همه اطلاعت یکی از تفریخات ابی</returns>
        public async Task<Model.WaterFun> GetUpdateWaterFunAsync(Guid id)
        {
            return await _context.WaterFuns.FirstOrDefaultAsync(q => q.Id == id);
        }
        public async Task<bool> UpdateWaterFunAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion


        public async Task<List<Model.Ticket>> GetSellerPanelTicketDtoAsync()
        {
            var result = await _context.Tickets
                .Where(q => q.ESoldType == ESoldType.SoldSeller)
                .OrderBy(q => q.Date)
                .ToListAsync();
            return result;
        }
    }

}
