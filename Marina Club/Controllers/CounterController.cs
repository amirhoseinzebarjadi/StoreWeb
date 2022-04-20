using System;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Dto;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Services.Counter;
using Microsoft.AspNetCore.Mvc;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class CounterController : Controller
    {
        private readonly ICounterService _counterService;
        public CounterController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        #region Counter
        /// <summary>
        /// Sans Dto In Counter
        /// </summary>
        /// <param >بر اساس نوع تفریح و تاریخ سانس</param>
        /// <returns>لیستی از سانس ها با تاریخ وساعت و اون تفریح</returns>
        [HttpGet("sans-Dto")]
        public async Task<IActionResult> GetSansDtoInCounterAsync(int PageSize, int PageNumber)
        {
            var result = await _counterService.GetSansDtoInCounterAsync(PageSize,PageNumber);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");
            var SansDto = result.Select(q =>

                 new SansDtoInCounter()
                 {
                     StartTimSans = q.StartTimeSans,
                     Date = q.Date,
                     WaterFunId = ToDto3(q.WaterFunIdForDto)
                 });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = SansDto });
        }
        /// <summary>
        /// Sans Search
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("sans-Search")]
        public async Task<IActionResult> GetSansDtoInCounterAsync(int PageSize, int PageNumber, string SearchWordDateSansCounter, string SearchWordFunSansTypeCounter)
        {
            var result = await _counterService.GetSansDtoInCounterAsync(PageSize, PageNumber, SearchWordDateSansCounter, SearchWordFunSansTypeCounter);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");
            var SansDto = result.Select(q =>
            {
                return new SansDtoInCounter()
                {
                    StartTimSans = q.StartTimeSans,
                    Date = q.Date,
                    WaterFunId = ToDto3(q.WaterFunIdForDto)
                };
            });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = SansDto });
        }

        /// <summary>
        ///Get All Infos In Counter
        /// </summary>
        /// <param >سرچ بر اساس تفریح و تاریخ بلیط که در باجه خریداری شده</param>
        /// <returns>بلیط ها و اطلاعات خریداران</returns>
        [HttpGet("All-Counter")]
        public async Task<IActionResult> GetSellerManagerInCounterAsync(int PageSize, int PageNumber)
        {
            var result = await _counterService.GetSellerManagerInCounterAsync(PageSize, PageNumber);
            if (result == null)
                return NotFound("  مقادیر مورد نظر یافت نشد ");
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Search Infos Ic Counter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Search-Counter")]
        public async Task<IActionResult> GetSellerManagerInCounterAsync(int PageSize, int PageNumber, string SearchWordDateInCounter, string SearchWordFunTypeInCounter)
        {
            var result = await _counterService.GetSellerManagerInCounterAsync(PageSize,  PageNumber, SearchWordDateInCounter,  SearchWordFunTypeInCounter);
            if (result == null)
                return NotFound(" مقادیر مورد نظر یافت نشد ");
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Add Infos In Counter
        /// </summary>
        /// <param>اضافه کردن فروش وخریدار جدید از باجه</param>
        /// <returns>/****</returns>
        [HttpPost("Add-Counter")]
        public async Task<IActionResult> AddSellerManagerInCounterAsync([FromBody] AddCounterTicketCommand command)
        {
            if (!(!string.IsNullOrEmpty(command.FirstNameAndLastNameCounter)
                && !string.IsNullOrEmpty(command.PhoneNumberCounter)
                && !string.IsNullOrEmpty(command.AmountPaid.ToString())
                && !string.IsNullOrEmpty(command.NationalCodeCounter)
                && !string.IsNullOrEmpty(command.DateTicketCounter.ToString())))
                return BadRequest("مقادیر مورد نظر یافت نشد ");

            var result = await _counterService.AddSellerManagerInCounterAsync(command);

            if (result == 0)
            {
                return BadRequest("عملیات با موفقیت انجام نشد");
            }

            else if (result == 2)
            {
                return BadRequest("تعداد بلیط ذرخواستی از تعداد بلیط باقی مانده بیشتر است");
            }
            return Ok(true);
        }
       
        /// <summary>
        /// نمایش لیستی از تفریحات که در همه جا کاربرد داره #
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("FunTypes-Dto-In-Counter")]
        public async Task<IActionResult> GetWaterFunDtoInCounterAsync()
        {
            var result = await _counterService.GetWaterFunDtoInCounterAsync();
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");
            var WaterFunsDto = result.Select(q =>
            {
                return new WaterFunDtoInCounter()
                {
                    FunTypes = q.FunType,
                };
            });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = WaterFunsDto });
        }

        /// <summary>
        /// Cancel 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTicketPanelAsync([FromBody] UpdateTicketCommand command)
        {
            if (command.TicketId == Guid.Empty)
                return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _counterService.UpdateTicketCounterAsync(command);
           
          
            return Ok(new { Message = " عملیات با موفقیت انجام شد", Result = result });
        }

        #endregion

        #region privateMethod
        private WaterFunDto ToDto3(WaterFun waterFun)
        {
            return new WaterFunDto()
            {
                FunType = waterFun.FunType
            };
        }

#endregion
    }
}
