using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Repositories.Sans
{
    public interface ISansRepository
    {/// <summary>
        /// GetSans
        /// </summary>
        /// <returns>گرفتن تمام سانس ها</returns>
        Task<IList<Model.Sans>> GetSansAsync();
        /// <summary>
        /// PostWaterFunSans
        /// </summary>
        /// <param name="command">دادن ایدی و تاریخ شروع سانس ها</param>
        /// <returns>ساخت سانس جدید</returns>
        Task<bool> AddWaterFunSansAsync(List<Model.Sans> sanses);
        /// <summary>
        /// PutWaterFunSans
        /// </summary>
        /// <param name="command">دادن اطلاعت بولین سانس ها</param>
        /// <returns>تغییر لغو یا تمام شدن سانس ها</returns>
        Task<Model.Sans> GetUpdateWaterFunSansAsync(Guid sansId);
        Task<bool> UpdateWaterFunSansAsync();

        /// <summary>
        /// OneGetWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی</param>
        /// <returns>گرفتن اطلاعات ایدی داده شده</returns>
        Task<Model.WaterFun> OneGetWaterFunAsync(Guid id);
    }
}
