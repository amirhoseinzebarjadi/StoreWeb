using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Command.SellerPanel;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;

namespace Marina_Club.Services.WaterFun
{
    public interface IWaterFunService
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
        Task<bool> AddWaterFunAsync(AddWaterFunCommand command);
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
        Task<IList<Model.WaterFun>> GetByIdWaterFunAsync(GetByIdWaterFunCommand command);
        /// <summary>
        /// PutWaterFun
        /// </summary>
        /// <param name="command">دادن تمام اطلاعت تفریحات ابی </param>
        /// <returns>تغییرات همه اطلاعت یکی از تفریخات ابی</returns>
        Task<bool> UpdateWaterFunAsync(UpdateWaterFun command);
        //Task <List<Sans>> GetFunTypeAsync(QueryFunTypeCommand command);
        Task<List<Model.Ticket>> GetSellerPanelTicketDtoAsync(SellerPanelDtoSearchCommand command);

    }
}
