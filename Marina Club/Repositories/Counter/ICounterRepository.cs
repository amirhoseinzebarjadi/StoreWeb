using Marina_Club.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marina_Club.Repositories.Counter
{
    public interface ICounterRepository
    {
        /// <summary>
        /// Sans Dto In Counter With Search
        /// </summary>
        /// <param name="SearchWordDateSansCounter"></param>
        /// <param name="SearchWordFunSansTypeCounter"></param>
        /// <returns></returns>
        Task<List<Model.Sans>> GetSansDtoInCounterAsync(int PageSize, int PageNumber);

        Task<List<Model.Sans>> GetSansDtoInCounterAsync(/* int PageSize, int PageNumber*/);

        /// <summary>
        /// Get Seller Manager Or Ticket In Counter
        /// </summary>
        /// <param name="SearchWordDateInCounter"></param>
        /// <param name="SearchWordFunTypeInCounter"></param>
        /// <returns></returns>
        Task<List<Model.Ticket>> GetSellerManagerInCounterAsync(int PageSize, int PageNumber);

        Task<List<Model.Ticket>> GetSellerManagerInCounterAsync( /*int PageSize, int PageNumber*/);

        /// <summary>
        /// Add Seller In Counter
        /// </summary>
        /// <param name="sellerManagerInCounter"></param>
        /// <returns></returns>
        Task<bool> AddSellerManagerInCounterAsync(Model.Ticket ticket);

        Task<List<Model.WaterFun>> GetWaterFunDtoInCounterAsync();

        Task<Model.WaterFun> OneGetWaterFunAsync(Guid waterFunId);
        Task<Model.Sans> OneGetSansAsync(Guid SansId);
        Task<Model.Ticket> GetTicketCounterForUpdateAsync(Guid TicketId);
        Task<int> UpdateTicketCounterAsync();

    }
}
