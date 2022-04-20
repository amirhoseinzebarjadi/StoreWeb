using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Repositories.Sans;
namespace Marina_Club.Services.Sans
{
    public class SansService : ISansService
    {
        private readonly ISansRepository _sansRepository;
        public SansService(ISansRepository sansRepository)
        {
            _sansRepository = sansRepository;
        }

        #region Sans

        /// <summary>
        /// GetSans
        /// </summary>
        /// <returns>گرفتن تمام سانس ها</returns>
        public async Task<IList<Model.Sans>> GetSansAsync()
        {
            return await _sansRepository.GetSansAsync();
        }

        /// <summary>
        /// PostWaterFunSans
        /// </summary>
        /// <param name="command">دادن ایدی و تاریخ شروع سانس ها</param>
        /// <returns>ساخت سانس جدید</returns>
        public async Task<bool> AddWaterFunSansAsync(AddWaterFunSansCommand command)
        {
            var waterFunSans = await _sansRepository.OneGetWaterFunAsync(command.WaterId);//فک کنم باید اینجا توی کامند روز رو بگیریم . شاهرخ تست کردی ؟

            var startTimeList = GetStartTimeSpanOfSansList(waterFunSans.StartTimeWork, waterFunSans.EndTimeWork, waterFunSans.GapMinutes, waterFunSans.DurationMinutes);

            var finalPrice = GetFinalPrice(waterFunSans.Price, waterFunSans.Discounts.DiscountAmount);

            var list = new List<Model.Sans>();
            for (var i = 0; i < command.DaysNumber; i++)
            {
                foreach (var time in startTimeList)
                {
                    var sans = new Model.Sans
                    {
                        Date = command.DateTime.AddDays(i),
                        StartTimeSans = time,
                        Capacity = waterFunSans.Capacity,
                        WaterFunId = waterFunSans.Id,
                        IsCancel = false,
                        IsEnable = true,
                        SalesCapacityOnline = waterFunSans.SalesCapacityOnline,
                        SalesCapacityPerson = waterFunSans.SalesCapacityPerson,
                        SansId = Guid.NewGuid(),
                        SoldTicketOnline = 0,
                        SoldTicketPerson = 0,
                        Price = finalPrice,
                    };

                    list.Add(sans);
                }
            }
            return await _sansRepository.AddWaterFunSansAsync(list);
        }

        /// <summary>
        /// PutWaterFunSans/
        /// </summary>
        /// <param name="command">دادن اطلاعت بولین سانس ها</param>
        /// <returns>تغییر لغو یا تمام شدن سانس ها</returns>
        public async Task<bool> UpdateWaterFunSansAsync(UpdateWaterFunSansCommand command)
        {
            var sans = await _sansRepository.GetUpdateWaterFunSansAsync(command.SansId);
            sans.IsCancel = command.IsCancel;
            sans.IsEnable = command.IsEnable;

            return await _sansRepository.UpdateWaterFunSansAsync();
        }

        #endregion

        #region privateMethod

        /// <summary>
        /// فرمول سانس
        /// </summary>
        private List<TimeSpan> GetStartTimeSpanOfSansList(TimeSpan startTime, TimeSpan endTime, int gapsSpan, int durationsSpan)
        {
            var resultList = new List<TimeSpan>();

            var duration = TimeSpan.FromMinutes(durationsSpan);
            var gap = TimeSpan.FromMinutes(gapsSpan);

            var scheduleCount = (int)((endTime - startTime) / (duration + gap));

            for (var i = 1; i <= scheduleCount; i++)
            {
                var durationAndGapMultipliedByNumberOfChances = (gap + duration) * i;
                var durationAndGapMultipliedByNumberOfChancesPlusStartWork = durationAndGapMultipliedByNumberOfChances + startTime;
                resultList.Add(durationAndGapMultipliedByNumberOfChancesPlusStartWork - (gap + duration));
            }

            return resultList;
        }

        /// <summary>
        /// فرمول تخفیف
        /// </summary>
        private double GetFinalPrice(double price, double discount)
        {
            var finalPrice = price - (price * discount / 100);

            return finalPrice;
        }

        #endregion
    }
}
