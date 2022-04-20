using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Dto;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Services.Report;
using Marina_Club.Services.WaterFun;
using Microsoft.AspNetCore.Mvc;

namespace Marina_Club.Controllers
{

    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        /// <summary>
        /// Report Customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Report-Customer")]
        public async Task<IActionResult> AddTicketDtoReportAsync([FromBody] ReportQueryCommand command)
        {
            var result = await _reportService.TicketDtoReportAsync(command);

            if (result == null)
                return NotFound(new { Message = " موردی یافت نشد" });
            var Price = Bagherasion(result.Select(q => q.TotalPrice).ToList());
            var Ticket = Bagherasions(result.Select(q => q.TicketReservation).ToList());

            var results = result.Select(q =>
                new TicketDto()
                {
                    FunType = q.FunType,
                    Date = q.Date,
                    StartTimeSans = q.StartTimeSans,
                    TicketReservation = q.TicketReservation,
                    Tickets = Ticket,
                    Price = Price,
                    TicketNumber = q.TicketNumber,
                    SellerId = q.SellerId

                });

            var tickets = new List<TicketDto>();

            var queryFunType = results.Where(q => q.FunType == command.SearchFunType).ToList();
            //اولی نمایش تمام  بلیط هایی که تاریخ آنها کوچک تر از تاریخ وارد شده است
            //بالعکس اولی
            var queryDate = results.Where(q => q.Date >= command.SearchDate && q.Date <= command.SearchDate2).ToList();

            tickets.AddRange(queryDate);
            tickets.AddRange(queryFunType);

            var resultss = tickets.GroupBy(x => x.TicketNumber)
                .Select(g => g.First())
                .Skip((command.PageNumber - 1) * command.PageSize)
                .Take(command.PageSize).ToList();


            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = resultss });
        }

        /// <summary>
        /// Report-Seller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Report-Seller")]
        public async Task<IActionResult> TicketSellerDtoReportAsync([FromBody] ReportQueryCommand command)
        {
            var result = await _reportService.TicketSellerDtoReportAsync(command);
            if (result == null)
                return NotFound(new { Message = " موردی یافت نشد" });

            var Price = Bagherasion(result.Select(q => q.TotalPrice).ToList());
            var Ticket = Bagherasions(result.Select(q => q.TicketReservation).ToList());

            var results = result.Select(q =>
                new TicketDto()
                {
                    FunType = q.FunType,
                    Date = q.Date,
                    StartTimeSans = q.StartTimeSans,
                    TicketReservation = q.TicketReservation,
                    Tickets = Ticket,
                    Price = Price,
                    TicketNumber = q.TicketNumber,
                    SellerId = q.SellerId

                });

            var tickets = new List<TicketDto>();

            var queryFunType = results.Where(q => q.FunType == command.SearchFunType).ToList();
            //اولی نمایش تمام  بلیط هایی که تاریخ آنها کوچک تر از تاریخ وارد شده است
            //بالعکس اولی
            var queryDate = results.Where(q => q.Date >= command.SearchDate && q.Date <= command.SearchDate2).ToList();

            tickets.AddRange(queryDate);
            tickets.AddRange(queryFunType);

            var resultss = tickets.GroupBy(x => x.TicketNumber)
                .Select(g => g.First())
                .Skip((command.PageNumber - 1) * command.PageSize)
                .Take(command.PageSize).ToList();


            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = resultss });
        }

        /// <summary>
        /// Report Counter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Report-Counter")]
        public async Task<IActionResult> TicketCounterDtoReportAsync([FromBody] ReportQueryCommand command)
        {
            var result = await _reportService.TicketCounterDtoReportAsync(command);

            if (result == null)
                return NotFound(new { Message = " موردی یافت نشد" });

            var Price = Bagherasion(result.Select(q => q.TotalPrice).ToList());
            var Ticket = Bagherasions(result.Select(q => q.TicketReservation).ToList());

            var results = result.Select(q =>
                new TicketDto()
                {
                    FunType = q.FunType,
                    Date = q.Date,
                    StartTimeSans = q.StartTimeSans,
                    TicketReservation = q.TicketReservation,
                    Tickets = Ticket,
                    Price = Price,
                    TicketNumber = q.TicketNumber,
                    SellerId = q.SellerId

                });

            var tickets = new List<TicketDto>();

            var queryFunType = results.Where(q => q.FunType == command.SearchFunType).ToList();
            //اولی نمایش تمام  بلیط هایی که تاریخ آنها کوچک تر از تاریخ وارد شده است
            //بالعکس اولی
            var queryDate = results.Where(q => q.Date >= command.SearchDate && q.Date <= command.SearchDate2).ToList();

            tickets.AddRange(queryDate);
            tickets.AddRange(queryFunType);

            var resultss = tickets.GroupBy(x => x.TicketNumber)
                .Select(g => g.First())
                .Skip((command.PageNumber - 1) * command.PageSize)
                .Take(command.PageSize).ToList();


            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = resultss });
        }
        
        #region Private Methode

        public double Bagherasion(List<double> TotalPrice)
        {
            var Price = TotalPrice.Sum();
            return Price;
        }

        public int Bagherasions(List<int> TicketReservation)
        {
            var Price = TicketReservation.Sum();
            return Price;
        }

        #endregion
    }
}