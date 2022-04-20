using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Marina_Club.Repositories.Report
{
    public interface IReportRepository
    {
        Task<List<Model.Ticket>> TicketDtoReportAsync();

        Task<List<Model.Ticket>> TicketSellerDtoReportAsync();
     
        Task<List<Model.Ticket>> TicketCounterDtoReportAsync();
    }
}
