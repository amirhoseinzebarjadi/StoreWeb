using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Services.Sans;
using Microsoft.AspNetCore.Mvc;
namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class SansController : Controller
    {
        private readonly ISansService _sansService;
        public SansController(ISansService sansService)
        {
            _sansService = sansService;
        }

        #region Sans
        //[HttpGet("GetFunType")]
        //public async Task<IActionResult> GetFunTypeAsync([FromBody] QueryFunTypeCommand command)
        //{
        //    var result = await _waterFunService.GetFunTypeAsync(command);
        //    if (result == null)
        //        return NotFound(new { Message = "NotFound" });
        //    var resultDto = result.Select(q =>
        //    {
        //        return new FunTypeDto()
        //        {
        //            FunType = q.WaterFunId,
        //            StartTimeSans = q.StartTimeSans,
        //            Date = q.Date
        //        };
        //    });
        //    return Ok(resultDto);
        //}

        /// <summary>
        /// GetSans
        /// </summary>
        /// <returns>گرفتن تمام سانس ها</returns>
        [HttpGet("All-sans")]
        public async Task<IActionResult> GetSansAsync()
        {
            var result = await _sansService.GetSansAsync();

            if (result.Count == 0)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PostWaterFunSans
        /// </summary>
        /// <param name="command">دادن ایدی و تاریخ شروع سانس ها</param>
        /// <returns>ساخت سانس جدید</returns>
        [HttpPost("{Id}/add-sans")]
        public async Task<IActionResult> AddWaterFunSansAsync([FromBody] AddWaterFunSansCommand command)
        {
            if (command.WaterId == Guid.Empty)
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });

            var result = await _sansService.AddWaterFunSansAsync(command);

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PutWaterFunSans
        /// </summary>
        /// <param name="command">دادن اطلاعت بولین سانس ها</param>
        /// <returns>تغییر لغو یا تمام شدن سانس ها</returns>
        [HttpPut("{Id}/update-sans")]
        public async Task<IActionResult> UpdateWaterFunSansAsync([FromBody] UpdateWaterFunSansCommand command)
        {
            if (command.SansId == Guid.Empty)
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });

            var result = await _sansService.UpdateWaterFunSansAsync(command);

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }
        //[HttpGet("{Id}")]
        //public async Task<IActionResult> OneGetTicketAsync([FromBody] OneGetTicketCommand command)
        //{
        //    var result = await _waterFunService.OneGetTicketAsync(command);

        //    if (result.tickeyid == Guid.Empty)
        //        return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

        //    return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        //}
        #endregion
    }
}