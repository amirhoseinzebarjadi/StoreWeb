using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.SellerPanel;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Repositories.WaterFun;
using Microsoft.AspNetCore.Mvc;

namespace Marina_Club.Services.WaterFun
{
    public class WaterFunService : IWaterFunService
    {
        private readonly IWaterFunRepository _waterFunRepository;
        public WaterFunService(IWaterFunRepository waterFunRepository)
        {
            _waterFunRepository = waterFunRepository;
        }

        #region WaterFun

        /// <summary>
        /// Get WaterFun
        /// </summary>
        /// <returns>گرفتن کل تفریحات ابی </returns> 
        public async Task<IList<Model.WaterFun>> ListAsyncWaterFun()
        {
            return await _waterFunRepository.ListAsyncWaterFun();
        }
        /// <summary>
        /// Post WaterFun
        /// </summary>
        /// <param name="command">دادن اطلاعات کلاس تقریحات ابی</param>
        /// <returns>ساخت تفزیحات دریایی</returns>
        public async Task<bool> AddWaterFunAsync([FromBody] AddWaterFunCommand command)
        {
            var waterFun = new Model.WaterFun()
            {
                Id = Guid.NewGuid(),
                FunType = command.FunType,
                Price = command.Price,
                DurationMinutes = command.DurationMinutes,
                GapMinutes = command.GapMinutes,
                StartTimeWork = TimeSpan.Parse(command.StartTimeWork),
                EndTimeWork = TimeSpan.Parse(command.EndTimeWork),
                IsActiveWaterFun = command.IsActiveWaterFun,
                SalesCapacityPerson = command.SalesCapacityPerson,
                SalesCapacityOnline = command.SalesCapacityOnline,
                Capacity = command.Capacity,
                Discounts = ToDto(command.Discounts)
            };

            return await _waterFunRepository.WaterFunAsync(waterFun);
        }

        /// <summary>
        /// OneGetWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی</param>
        /// <returns>گرفتن اطلاعات ایدی داده شده</returns>
        public async Task<Model.WaterFun> OneGetWaterFunAsync(Guid id)
        {
            var waterFun = await _waterFunRepository.OneGetWaterFunAsync(id);
            return waterFun;
        }

        /// <summary>
        /// GetIdWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی </param>
        /// <returns>گرفتن لیست تمام اطلاعات مربوط به اون ایدی و بقیه ایدی </returns>
        public async Task<IList<Model.WaterFun>> GetByIdWaterFunAsync(GetByIdWaterFunCommand command)
        {
            var waterFun = await _waterFunRepository.GetByIdCustomerAsync(command.Id);
            return waterFun;
        }

        /// <summary>
        /// PutWaterFun
        /// </summary>
        /// <param name="command">دادن تمام اطلاعت تفریحات ابی </param>
        /// <returns>تغییرات همه اطلاعت یکی از تفریخات ابی</returns>
        public async Task<bool> UpdateWaterFunAsync(UpdateWaterFun command)
        {
            var waterFun = await _waterFunRepository.GetUpdateWaterFunAsync(command.Id);

            waterFun.FunType = command.FunType;
            waterFun.Price = command.Price;
            waterFun.DurationMinutes = command.DurationMinutes;
            waterFun.GapMinutes = command.GapMinutes;
            waterFun.StartTimeWork = command.StartTimeWork;
            waterFun.EndTimeWork = command.EndTimeWork;
            waterFun.IsActiveWaterFun = command.IsActiveWaterFun;
            waterFun.SalesCapacityPerson = command.SalesCapacityPerson;
            waterFun.SalesCapacityOnline = command.SalesCapacityOnline;
            waterFun.Capacity = command.Capacity;

            waterFun.Discounts = ToDto(command.Discounts);

            return await _waterFunRepository.UpdateWaterFunAsync();
        }
        #endregion

        

        public async Task<List<Model.Ticket>> GetSellerPanelTicketDtoAsync(SellerPanelDtoSearchCommand command)
        {
            var result = await _waterFunRepository.GetSellerPanelTicketDtoAsync();
            var results = new List<Model.Ticket>();
            if (/*!string.IsNullOrEmpty(command.DateSearch)&&*/!string.IsNullOrEmpty(command.FunTypeSearch))
            {
                var searchFunType = result.Where(q => q.FunType == command.FunTypeSearch).ToList();
                //var searchDate = result.Where(s => s.Date.ToString() == command.DateSearch).ToList();
                //results.AddRange(searchDate);
                results.AddRange(searchFunType);
            }
            var resultss = result.GroupBy(x => x.TicketId)
                .Select(g => g.First())
                .Skip((command.PageNumber - 1) * command.PageSize)
                .Take(command.PageSize).ToList();
            return resultss;
        }
        #region privateMethod

        /// <summary>
        /// تخفیف متد
        /// </summary>
        private Discount ToDto(DiscountCommand command)
        {
            return new Discount
            {
                DiscountAmount = command.DiscountAmount,
                EndDiscount = command.EndDiscount,
                FunType = command.FunType,
                StartDiscount = command.StartDiscount,
                FinalPrice = command.FinalPrice
            };
        }
        
        #endregion
    }
}
