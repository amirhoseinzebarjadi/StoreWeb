using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Model;

namespace Marina_Club.Repositories.Ticket
{
    public interface ITicketRepository
    {
        Task<List<Model.Ticket>> GetTicketAsync(int PageSize , int PageNumber);
        Task<List<Model.Ticket>> GetTicketAsync();
        void AddTicketAsync(Model.Ticket ticket);
        Task<Model.Ticket> OneGetTicketAsync(Guid ticketId);
        Task <Model.WaterFun> OneGetWaterFunAsync(Guid waterFunId);
        Task <Model.Customer> OneGetCustomerAsync(Guid customerId);
        Task <Model.Sans> OneGetSansAsync(Guid sansId);
        Task<List<Model.Ticket>> TicketDtoAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion);
        Task<List<Model.Ticket>> TicketDtoHistoryAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion);
        Task<Model.Ticket> GetTicketForUpdateAsync(Guid TicketId);
        Task<bool> UpdateTicketAsync();
        //Task <Model.Ticket> GetTicketInfoForUpdateAsync(Guid TicketId);
        //Task<bool> UpdateTicketInfoAsync();

        Task<int> UpdateSoldTicketAsync();
    }
}
