using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Model;

namespace Marina_Club.Repositories.WaterFun
{
    public interface IWaterFunRepository
    {

        /// <summary>
        /// Get WaterFun
        /// </summary>
        /// <returns>گرفتن کل تفریحات ابی </returns> 
        Task<IList<Model.WaterFun>> ListAsyncWaterFun();
        /// <summary>
        /// Post WaterFun
        /// </summary>
        /// <param name="command">دادن اطلاعات کلاس تقریحات ابی</param>
        /// <returns>ساخت تفزیحات دریایی</returns>
        Task<bool> WaterFunAsync(Model.WaterFun waterFun);
        /// <summary>
        /// OneGetWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی</param>
        /// <returns>گرفتن اطلاعات ایدی داده شده</returns>
        Task<Model.WaterFun> OneGetWaterFunAsync(Guid id);
        /// <summary>
        /// GetIdWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی </param>
        /// <returns>گرفتن لیست تمام اطلاعات مربوط به اون ایدی و بقیه ایدی </returns>
        Task<IList<Model.WaterFun>> GetByIdCustomerAsync(Guid id);
        /// <summary>
        /// PutWaterFun
        /// </summary>
        /// <param name="command">دادن تمام اطلاعت تفریحات ابی </param>
        /// <returns>تغییرات همه اطلاعت یکی از تفریخات ابی</returns>
        Task<Model.WaterFun> GetUpdateWaterFunAsync(Guid id);

        Task<bool> UpdateWaterFunAsync();

        //Task<List<Sans>> GetFunTypeAsync(string dateQuery , string funTypeQuery);

        
        Task<List<Model.Ticket>> GetSellerPanelTicketDtoAsync();
    }
}
