using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.WaterFunCommand;

namespace Marina_Club.Services.Sans
{
    public interface ISansService
    {
        /// <summary>
        /// GetSans
        /// </summary>
        /// <returns>گرفتن تمام سانس ها</returns>
        Task<IList<Model.Sans>> GetSansAsync();
        /// <summary>
        /// PostWaterFunSans
        /// </summary>
        /// <param name="command">دادن ایدی و تاریخ شروع سانس ها</param>
        /// <returns>ساخت سانس جدید</returns>
        Task<bool> AddWaterFunSansAsync(AddWaterFunSansCommand command);
        /// <summary>
        /// PutWaterFunSans
        /// </summary>
        /// <param name="command">دادن اطلاعت بولین سانس ها</param>
        /// <returns>تغییر لغو یا تمام شدن سانس ها</returns>
        Task<bool> UpdateWaterFunSansAsync(UpdateWaterFunSansCommand command);
    }
}
