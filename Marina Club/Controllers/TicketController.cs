using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Dto;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Services.Ticket;
using Marina_Club.Services.WaterFun;
using Microsoft.AspNetCore.Mvc;
namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello Im Robin ;)";
        }

        #region Ticket

        /// <summary>
        /// Get List Ticket
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsyncTicket(int pageNumber ,int pageSize)
        {
            var result = await _ticketService.ListAsyncTicket(pageNumber, pageSize);

            if (pageSize == 0)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Get List Ticket For Formol
        /// </summary>
        /// <returns></returns>
        [HttpGet("All-Formula")]
        public async Task<IActionResult> GetAllAsyncTicket()
        {
            var result = await _ticketService.ListAsyncTicket();

            if (result.Count == 0)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Add Ticket
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddTicketAsync([FromBody] AddTicketCommand command)
        {
            if (string.IsNullOrEmpty(command.CustomerId.ToString()))

                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });

            var result = await _ticketService.AddTicketAsync(command);

            if (result == 0)
            {
                return BadRequest();
            }

            else if (result == 50)
            {
                return BadRequest();
            }

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });

        }

        /// <summary>
        /// Get One By Id Ticket
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("One")]
        public async Task<IActionResult> OneGetTicketAsync(Guid ticketId)
        {
            var result = await _ticketService.OneGetTicketAsync(ticketId);

            if (ticketId == Guid.Empty)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        //nemidonam chikar mikone
        /// <summary>
        /// List Dto Ticket
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("List-Dto-Reserv")]//
        public async Task<IActionResult> TicketDtoAsync(int PageNumber ,int PageSize , ETitleOfSuggestion eTitleOfSuggestion )
        {
            var result = await _ticketService.TicketDtoAsync(PageNumber , PageSize , eTitleOfSuggestion);

            if (result == null)
                return NotFound(new { Message = " موردی یافت نشد" });

            var results = result.Select(q =>
                new TicketDto()
                {
                    FunType = q.FunType,
                    Date = q.Date,
                    StartTimeSans = q.StartTimeSans,
                    TicketReservation = q.TicketReservation
                });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = results });
        }
        //nemidonam chikar mikone
        /// <summary>
        /// List Dto Ticket History
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("List-Dto-History")]//
        public async Task<IActionResult> TicketDtoHistoryAsync(int PageNumber, int PageSize, ETitleOfSuggestion eTitleOfSuggestion)
        {
            var result = await _ticketService.TicketDtoHistoryAsync(PageNumber, PageSize, eTitleOfSuggestion);

            if (result == null)
                return NotFound(new { Message = " موردی یافت نشد" });

            var results = result.Select(q =>
                new TicketDto()
                {
                    FunType = q.FunType,
                    Date = q.Date,
                    StartTimeSans = q.StartTimeSans,
                    TicketReservation = q.TicketReservation
                });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = results });
        }
        //nemidonam chikar mikone
        /// <summary>
        /// Cancel 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTicketAsync([FromBody] UpdateTicketCommand command)
        {
            if (command.TicketId == Guid.Empty)

                return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _ticketService.UpdateTicketAsync(command);
            return Ok(new { Message=" عملیات با موفقیت انجام شد", Result = result });
        }

        ///// <summary>
        ///// Update Sold /Capacity / RemainingCapacityOnline
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPut("Update-Info")]
        //public async Task<IActionResult> UpdateTicketInfoAsync(UpdateTicketInfoCommand command)
        //{
        //    var result = await _ticketService.UpdateTicketInfoAsync(command);
        //    return Ok(new { Message = " عملیات با موفقیت انجام شد", Result = result });
        //}

        #endregion
    }
}
