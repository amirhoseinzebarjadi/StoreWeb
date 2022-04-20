using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Dto;
using Marina_Club.Pagination;
using Marina_Club.Repositories.Report;
namespace Marina_Club.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<Model.Ticket>> TicketDtoReportAsync(ReportQueryCommand command)
        {
            var result = await _reportRepository.TicketDtoReportAsync();

            return result;
        }

        public async Task<List<Model.Ticket>> TicketSellerDtoReportAsync(ReportQueryCommand command)
        {
            var result = await _reportRepository.TicketSellerDtoReportAsync();
           
            return result;
        }

        public async Task<List<Model.Ticket>> TicketCounterDtoReportAsync(ReportQueryCommand command)
        {
            var result = await _reportRepository.TicketCounterDtoReportAsync();
            return result;
        }
    }
}