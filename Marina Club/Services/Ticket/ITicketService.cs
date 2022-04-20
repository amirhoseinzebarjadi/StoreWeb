using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;

namespace Marina_Club.Services.Ticket
{
    public interface ITicketService
    {
        Task<List<Model.Ticket>> ListAsyncTicket(int pageNumber, int pageSize);
        Task<List<Model.Ticket>> ListAsyncTicket();
        Task <int> AddTicketAsync(AddTicketCommand command);
        Task <Model.Ticket> OneGetTicketAsync(Guid ticketId);
        Task<List<Model.Ticket>> TicketDtoAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion);
        Task<List<Model.Ticket>> TicketDtoHistoryAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion);
        Task<bool> UpdateTicketAsync(UpdateTicketCommand command);
    }
}
