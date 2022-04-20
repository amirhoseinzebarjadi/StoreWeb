using Marina_Club.Command.QueryCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;

namespace Marina_Club.Services.Counter
{
    public interface ICounterService
    {
        /// <summary>
        /// Sans Dto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<List<Model.Sans>> GetSansDtoInCounterAsync(int PageSize, int PageNumber);

        Task<List<Model.Sans>> GetSansDtoInCounterAsync(int PageSize, int PageNumber, string SearchWordDateSansCounter, string SearchWordFunSansTypeCounter);

        /// <summary>
        /// GetSeller Or Ticket In Counter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<List<Model.Ticket>> GetSellerManagerInCounterAsync(int PageSize, int PageNumber);

        Task<List<Model.Ticket>> GetSellerManagerInCounterAsync(int PageSize, int PageNumber, string SearchWordDateInCounter, string SearchWordFunTypeInCounter);

        /// <summary>
        /// Add Seller OrTicket In Counter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<int> AddSellerManagerInCounterAsync(AddCounterTicketCommand command);

        Task<List<Model.WaterFun>> GetWaterFunDtoInCounterAsync(/*QueryWithFunTypeAndDateInCounterCommand command*/);

        Task<int> UpdateTicketCounterAsync(UpdateTicketCommand command);
    }
}
