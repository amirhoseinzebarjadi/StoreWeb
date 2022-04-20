using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.CustomerCommand;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Pagination;
namespace Marina_Club.Services.Report
{
    public interface IReportService
    {
        Task<List<Model.Ticket>> TicketDtoReportAsync(ReportQueryCommand command);
        Task<List<Model.Ticket>> TicketSellerDtoReportAsync(ReportQueryCommand command);
        Task<List<Model.Ticket>> TicketCounterDtoReportAsync(ReportQueryCommand command);
    }
}
