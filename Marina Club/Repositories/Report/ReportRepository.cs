using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;
namespace Marina_Club.Repositories.Report
{
    public class ReportRepository : BaseRepository, IReportRepository
    {
        public ReportRepository(MarinaClubContext context) : base(context)
        {
        }

        public async Task<List<Model.Ticket>> TicketDtoReportAsync()
        {
            return await _context.Tickets
                .Where(q=>q.ESoldType==ESoldType.SoldCustomer && q.IsCancelReservation == false)
                .ToListAsync();
        }

        public async Task<List<Model.Ticket>> TicketSellerDtoReportAsync()
        {
            return await _context.Tickets
                .Where(q => q.ESoldType == ESoldType.SoldSeller && q.IsCancelReservation == false)
                .ToListAsync();
        }

        public async Task<List<Model.Ticket>> TicketCounterDtoReportAsync()
        {
            return await _context.Tickets
                .Where(q => q.ESoldType == ESoldType.SoldCustomer&&q.IsCancelReservation==false)
                .ToListAsync();
        }

    }
}
